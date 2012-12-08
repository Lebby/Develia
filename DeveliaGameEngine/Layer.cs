
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

        public List<Object2D> ObjectList { get { return _components; } set { _components = value; } }

        public Layer()
        { ObjectList = new List<Object2D>(); }        

        protected override void LoadContent()
        {
            base.LoadContent();            
            foreach (Object2D tmp in ObjectList)
            {
                Game.Components.Add(tmp);
            }
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
            foreach (Object2D tmp in ObjectList)
            {
                Game.Components.Remove(tmp);
            }
            Console.WriteLine("Called unload");
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
    }
}
