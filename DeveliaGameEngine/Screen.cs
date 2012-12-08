using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace DeveliaGameEngine
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// Contains Layer, a screen is exclusive
    /// </summary>
    public class Screen : Layer
    {
        public int ID;
        //private Color _color = null;

        //public Color BackgroundColor { get { return _color; } set { _color = value; } }

        /*public override void Draw()
        {
            GraphicsDevice.Clear(BackgroundColor);
            base.Draw();
            
        }*/
        
    }
}
