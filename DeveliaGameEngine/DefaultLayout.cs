using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace DeveliaGameEngine
{
    public class DefaultLayout : Layout
    {
        private float   _marginTop = 0, 
                        _marginBot = 0, 
                        _marginLeft = 0, 
                        _marginRight = 0;
        public float MarginTop      { get { return _marginTop; }    set { _marginTop    = value; } }
        public float MarginBottom   { get { return _marginBot; }    set { _marginBot    = value; } }
        public float MarginLeft     { get { return _marginLeft; }   set { _marginLeft   = value; } }
        public float MarginRight    { get { return _marginRight; }  set { _marginRight  = value; } }

        
        
        public void Arrange(List<Object2D> list, Rectangle container)
        {
            float x  = MarginLeft+container.Left , y = MarginTop + container.Top;
            Console.WriteLine("Layout! ");            
            foreach(Object2D tmp in list)
            {
                Console.WriteLine("" + tmp);
                Console.WriteLine("x : " + x + " y : " + y + " cont H : " + container.Height + " cont W : " + container.Width);
                Console.WriteLine("Container W : " + container.Width + " tmp H : " + tmp.Bound.Height);
                //if (y < container.Height - tmp.Bound.Height)
                {
                    y += tmp.Bound.Height;
                    
                    if (x < container.Width - tmp.Bound.Width)
                    {
                        //x += tmp.Bound.Width;
                    }
                    //else x = MarginLeft + container.Left;
                }
                //else y = MarginTop + container.Top;

                tmp.Position = new Vector2(x, y);

            }
        }
    }
}
