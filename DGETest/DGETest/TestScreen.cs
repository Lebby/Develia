using System;
using DeveliaGameEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using Microsoft.Xna.Framework.Storage;

namespace DGETest
{
    public class TestScreen : Screen
    {
        private String text = "";
        TextWidget heightLabel,widthLabel, fadeLabel, focusLabel, mousePosition;
        SpriteFont Font1;
        DeveliaCursor cursor;
        float fadeStep = 0.1f;
        float tmpFade = 0;
        bool load = false;
        bool unload = false;

        public TestScreen()
        {
            try
            {
                Font1 = Game.Content.Load<SpriteFont>("ExampleFont");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.StackTrace);
            }

            heightLabel = new TextWidget(Font1, Engine.Instance.Game.GraphicsDevice.DisplayMode.Height.ToString());
            widthLabel = new TextWidget(Font1, Engine.Instance.Game.GraphicsDevice.DisplayMode.Width.ToString());
            fadeLabel = new TextWidget(Font1, tmpFade.ToString());
            focusLabel = new TextWidget(Font1, "Load : " + load.ToString() + " Unload : " + unload.ToString());
            mousePosition = new TextWidget(Font1, "");
            cursor = new DeveliaCursor();

            heightLabel.Position = new Vector2(0, 250);
            widthLabel.Position = new Vector2(0, 300);
            fadeLabel.Position = new Vector2(0, 100);
            focusLabel.Position = new Vector2(0, 150);
            mousePosition.Position = new Vector2(0, 200);
            
            addComponent(heightLabel);
            addComponent(widthLabel);
            addComponent(fadeLabel);
            addComponent(focusLabel);
            addComponent(mousePosition);
            addComponent(cursor);                        
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

        public String Text { get { return text; } set { text = value; } }

        public override void OnLoad()
        {
            load = true; 
            unload = false;
            tmpFade = 0;
        }

        public override void OnUnload()
        {
            unload = true;
            load = false; 
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            
            if (load)
            {
                if (!(tmpFade >= 100))
                tmpFade += fadeStep;                     
            }
            if (unload)
            {
                if (!(tmpFade <= 0))
                tmpFade -= fadeStep;                     
            }

            heightLabel.Text = Engine.Instance.Game.GraphicsDevice.DisplayMode.Height.ToString();
            widthLabel.Text = Engine.Instance.Game.GraphicsDevice.DisplayMode.Width.ToString();
            fadeLabel.Text = tmpFade.ToString();
            focusLabel.Text = "Load : " + load.ToString() + " Unload : " + unload.ToString();
            mousePosition.Text = "Mouse Position X : " + cursor.Position.X + " Y : " + cursor.Position.Y ;
            
            if (focusLabel.Contains(cursor.Position.X, cursor.Position.Y))
            {
                cursor.TintColor = Color.Red;
            }
            else cursor.TintColor = Color.White;

        }
    }
}
