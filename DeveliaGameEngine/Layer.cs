
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

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
                                              set { _components = value; } }
        public Layout Layout                { get { return _layout; }
                                              set { _layout = value; Arrange(); } }
        private bool isLoad = false;

        public Layer()
        { ObjectList = new List<Object2D>(); }        

        protected override void LoadContent()
        {
            if (isLoad) return;
            isLoad = true;
            base.LoadContent();
            Console.WriteLine("\nLayer " + this + " :LoadContent - Current Components : ");
            foreach (GameComponent tmp in Game.Components)
            {
                Console.Write(tmp + " ");
            }
            foreach (Object2D tmp in ObjectList)
            {
                try
                {
                    Console.WriteLine ("\n" + this + " : Adding Component : " + tmp);
                    Game.Components.Add(tmp);
                    if (tmp is Layer) ((Layer)(tmp)).ForceLoad();
                }
                catch (Exception e)
                {
                    Console.WriteLine( e +"\n" +this +" : Duplicate Component : " + tmp);
                }
            }
            Arrange();
        }

        protected override void UnloadContent()
        {
            if (!isLoad) return;
            
            base.UnloadContent();
            foreach (Object2D tmp in ObjectList)
            {
                Game.Components.Remove(tmp);
                if (tmp is Layer) ((Layer)(tmp)).ForceUnload();
            }
            Console.WriteLine("Called unload xxxxxxxxxx : tmp :" + this );
            isLoad = false;
        }

        public void addComponent(Object2D component)
        {        
            ObjectList.Add(component);
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
            return false;
            
        }

        public void ForceLoad()
        {            
            LoadContent();
        }
        public void ForceUnload()
        {            
            UnloadContent();
        }

        public void Arrange()
        {
            if (_layout != null) _layout.Arrange(_components,Bound);
        }
    }
}
