using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DeveliaGameEngine
{
    public class MouseCursor : Object2D
    {
        

        public override void Update(GameTime gametime)
        {
            MouseState mouseState = Mouse.GetState();
            Position = new Vector2(mouseState.X, mouseState.Y);
        }

        public override void Initialize()
        {
            base.Initialize();
            SpriteBatch = new SpriteBatch(GraphicsDevice);            
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            BackgroundImage = new Texture2D(GraphicsDevice, 1, 1);
            DrawMode drawMode = new DrawMode();
            drawMode.SortMode = SpriteSortMode.FrontToBack;
        }

        public override void Draw()
        {
            if (BackgroundImage != null)
            {                
                SpriteBatch.Draw(BackgroundImage, Position, null, TintColor, Rotation, Origin, Scale, Effects, 0f);
            }
            
        }
    }
}
