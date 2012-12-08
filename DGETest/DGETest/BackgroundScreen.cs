using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeveliaGameEngine;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Storage;

namespace DGETest
{
    public class BackgroundScreen : Screen
    {
        protected override void LoadContent()
        {
            base.LoadContent();
            BackgroundImage = Game.Content.Load<Texture2D>("Images/background");
            TintColor = Microsoft.Xna.Framework.Color.White;
            Position = Vector2.Zero;            
        }
    }
}
