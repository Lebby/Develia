
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace DeveliaGameEngine
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// Contains drawable component
    /// </summary>
    /// 
    public class Layer : Object2D
    {
        private List<Object2D> _components;
        private Layout _layout;

        public List<Object2D> ObjectList    { get { return _components; } 
                                              set { _components = value;
                                            } }
        public Layout Layout                { get { return _layout; }
                                              set { _layout = value;                                                   
                                            } }        

        
        

        public Layer()
        { 
            ObjectList = new List<Object2D>();
            ObjectList.OrderBy(x=>x.LayerDepth);
            LayerDepth = DefaultEngineSettings.Engine_Layer_Layer_Depth_Start;
        }        

        protected override void LoadContent()
        {
            Console.WriteLine("LoadContent : " + this + " isLoad" + isLoaded) ;
            base.LoadContent();
            Object2D tmpex = null;
            try
            {
                foreach (Object2D tmp in ObjectList)
                {
                    tmpex = tmp;
                    if (!Game.Components.Contains(tmp))
                    {
                        Game.Components.Add(tmp);
                        tmp.Initialize();
                        if (!tmp.isLoaded)
                            tmp.ForceLoad();
                    }
                }                
            }             
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine( e +"\n" +this +" : Duplicate Component : " + tmpex);
            }            
        }

        protected override void UnloadContent()
        {
            if (!isLoaded) return;            
            base.UnloadContent();
            
            foreach (Object2D tmp in ObjectList)
            {
                Game.Components.Remove(tmp);
                if (tmp is Layer) ((Layer)(tmp)).ForceUnload();
            }
        }

        public void addComponent(Object2D component)
        {            
            ObjectList.Add(component);
            if (component.ManualDepth) return;
            
            if (component is Layer )
                component.LayerDepth = LayerDepth + DefaultEngineSettings.Engine_Layer_Layer_Depth_Step;
            else if (ObjectList.Count == 0)
                component.LayerDepth = LayerDepth + DefaultEngineSettings.Engine_Layer_Object_Depth_Step;
            else
                component.LayerDepth = this.LayerDepth + ObjectList.Last().LayerDepth 
                                     + DefaultEngineSettings.Engine_Layer_Object_Depth_Step;
            Console.WriteLine("Layer Depth after add :" + component + " : depth : " + component.LayerDepth);
        }       


        //relativeLayerDepth = relative Depth
        public void addComponent(Object2D component, float relativeLayerDepth)
        {
            component.LayerDepth = this.LayerDepth + LayerDepth;
            addComponent(component);
        }

        public void removeComponent(Object2D component)
        {
            ObjectList.Remove(component);
        }

        public override bool Contains(float x, float y)
        {
            foreach (Object2D tmp in ObjectList)
            {
                if (tmp.Contains(x,y)) return true;
            }
            if (Bound.Contains((int)x,(int)y)) return true;
            return false;            
        }

        public virtual void Arrange()
        {
            if ((Layout != null) && (IsToUpdate))
            {
                ForceArrange();
                foreach(Object2D tmp in ObjectList)
                {
                    if (tmp is Layer)
                    {
                        ((Layer)tmp).ForceArrange();
                    }
                }
            }
        }

        public virtual void ForceArrange()
        {
            Bound = CalculateBound();
            Layout.Arrange(this.ObjectList, Bound);
        }

        public override Rectangle CalculateBound()
        {
            Rectangle ret = base.CalculateBound();
            if (!AutoBound || !IsToUpdate) return Bound;

            if (ret == default(Rectangle))
                ret.Location = new Point((int)Engine.Instance.ResolutionManager.ScreenSize.X, 
                                         (int)Engine.Instance.ResolutionManager.ScreenSize.Y);
            foreach(Object2D tmp in _components)
            {                
                Rectangle recTmp = Bound;               
                
                if (ret.Height <= recTmp.Height)
                {
                    ret.Height = recTmp.Height;
                }
                if (ret.Width <= recTmp.Width)
                {
                    ret.Width =  recTmp.Width;
                }
                if (ret.Top >= recTmp.Top)
                {
                    ret.Location = new Point( ret.Left    , recTmp.Top);
                }
                if (ret.Left >= recTmp.Left)
                {
                    ret.Location = new Point( recTmp.Left , ret.Top);
                }
            }            
            Position = new Vector2(ret.Location.X, ret.Location.Y);
            //Console.Write("Calculate Bound : " + this + " istoU: " + this.IsToUpdate + " Ab: " + AutoBound);
            //Console.WriteLine(" rect final : X " + ret.X + " Y : " + ret.Y + " H : " + ret.Height + " W : " + ret.Width);            
            return ret;
        }

        public override void Update(GameTime gameTime)
        {
            if (IsToUpdate)
            {
                base.Update(gameTime);
                Arrange();
                IsToUpdate = false;
            }            
        }
    }
}
