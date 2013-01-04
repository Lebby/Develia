using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace DeveliaGameEngine
{
    public class Button : Layer
    {
        private TextWidget  _text;
        private Object2D    _image;
        private Color       defaultColor;

        public Button()
        {
            defaultColor = TintColor;
        }

        public override void Update(GameTime gameTime)
        {
            if (!Visible) return;

            MouseState mouseState = Mouse.GetState();
            ButtonState buttonState = mouseState.LeftButton;

            base.Update(gameTime);
            if (Contains(mouseState.X, mouseState.Y))
            {
                //debug code
                this.Scale = new Vector2(2, 1);
                this.TintColor = Color.Red;
                if ((buttonState == ButtonState.Pressed))
                {
                    //Engine.Instance.ResolutionManager.ScreenSize = new Vector2(Width, Height);
                    //Engine.Instance.ResolutionManager.FullScreen = !Engine.Instance.ResolutionManager.FullScreen;
                    Console.WriteLine("woops");
                }
                Console.WriteLine("woops");
            }
            else
            {
                this.Scale = new Vector2(1, 1);
                this.TintColor = defaultColor;
            }
        }
    }
}
