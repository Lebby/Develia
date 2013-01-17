using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DeveliaGameEngine
{
    public class Button : Layer
    {
        private TextWidget  _text;
        private Object2D    _image;
        private bool        _onOver     = false;
        private bool        _isClicked  = false;

        public  TextWidget  Label { get { return _text;  }  set { _text  = value; } }
        public  Object2D    Image { get { return _image; }  set { _image = value; } }

        public Button()
        {
            SpriteFont font = Engine.Instance.Game.Content.Load<SpriteFont>("Arial");
            _image          = new Object2D();
            
            _text           = new TextWidget(font);
            _text.Text      = "";

            _image.DrawOrder= DrawOrder + 1;
            _text.DrawOrder = DrawOrder + 2;

            addComponent(_image);
            addComponent(_text);
        }

        public override void Update(GameTime gameTime)
        {
            if (!Visible) return;

            MouseState mouseState   = Mouse.GetState();
            ButtonState buttonState = mouseState.LeftButton;

            base.Update(gameTime);
            if (Contains(mouseState.X, mouseState.Y))
            {
                OnOver(mouseState);
                _onOver = true;
                if ((buttonState == ButtonState.Pressed))
                {
                    if (_isClicked) return;
                    _isClicked = false;
                    OnClick(mouseState);
                }else
                    _isClicked = false;            
            }
            else
            {
                if (_onOver)
                {
                    _onOver = false;
                    OnBlur(mouseState);
                }
            }
        }

        public override void Arrange()
        {            
            base.Arrange();            
            float x = (Bound.Width  - _text.Bound.Width)    / 2;
            float y = (Bound.Height - _text.Bound.Height)   / 2;
            _text.Position = new Vector2(Position.X + x, Position.Y + y);
        }

        public virtual void OnClick (MouseState state) { }
        public virtual void OnOver  (MouseState state) { }
        public virtual void OnBlur  (MouseState state) { }

        
    }
}
