using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeveliaGameEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DGETest
{
    public class ResolutionScreen : Screen
    {
        TextWidget text;
        ResolutionManager rm;
        LinkedList<TextWidget> list;

        public ResolutionScreen()
        {
            rm = new ResolutionManager();
            SpriteFont font = Engine.Instance.Game.Content.Load<SpriteFont>("ExampleFont");
            List<Vector2> tmpList = rm.AvailableDisplayMode;
            list = new LinkedList<TextWidget>();
            int tmpHeight = 0 ;
            int tmpWidth = 0;
            Engine.Instance.Game.IsMouseVisible = true;
            
            foreach(Vector2 tmp in tmpList)
            {
                Vector2 tmpPos = new Vector2(tmpWidth, tmpHeight);
                MyTextWidget tmpTxt = new MyTextWidget(font);
                
                list.AddFirst(tmpTxt);
                tmpTxt.Position = tmpPos;
                tmpHeight += 30;
                addComponent(tmpTxt);
                tmpTxt.Width = tmp.X;
                tmpTxt.Height = tmp.Y;
                if (tmpHeight -400 >rm.CurrentDisplayMode().X)
                {
                    tmpHeight = 0;
                    tmpWidth += 100;
                }
            }
        }

    }

    class MyTextWidget : TextWidget
    {
        public float Width;
        public float Height;
        MouseState mouseState;
        ButtonState buttonState;        

        public MyTextWidget(SpriteFont font)
            : base(font)
        {
        }

        public override void Update(GameTime gameTime)
        {
            if (!Visible) return;
            Text = Width + " x " + Height;
            mouseState = Mouse.GetState();            
            buttonState = mouseState.LeftButton;
            
            base.Update(gameTime);
            if (Contains(mouseState.X, mouseState.Y) )
            {
                this.Scale = new Vector2(2, 1);
                this.TintColor = Color.Red;                
                if ((buttonState == ButtonState.Pressed) )
                {
                    Engine.Instance.ResolutionManager.ScreenSize = new Vector2(Width, Height);
                    //Engine.Instance.ResolutionManager.FullScreen = !Engine.Instance.ResolutionManager.FullScreen;
                }                
                
            }
            else
            {
                this.Scale = new Vector2(1, 1);
                this.TintColor = Color.Yellow;
            }
        }
    }
}
