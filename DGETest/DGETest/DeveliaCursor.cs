using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeveliaGameEngine;
using Microsoft.Xna.Framework.Graphics;

namespace DGETest
{
    public class DeveliaCursor : MouseCursor
    {
        protected override void LoadContent()
        {
            base.LoadContent();
            System.Diagnostics.Debug.Write("LoadContent");
            BackgroundImage = Game.Content.Load<Texture2D>("Images\\cursor");
            TintColor = Microsoft.Xna.Framework.Color.White;
        }
    }
}
