using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DeveliaGameEngine
{
    class RectangleShape : Object2D
    {
        
        public Color BorderColor;
        public Color FillColor;
        public Rectangle Rectangle;
        public int Thickness = 5;

        private void DrawFill(Rectangle rectangleToDraw, Color FillColor)
        {
            Texture2D pixel = new Texture2D(GraphicsDevice, 1, 1);
            pixel.SetData(new Color[] { FillColor });
            SpriteBatch.Draw(pixel, rectangleToDraw, FillColor);

        }
        
        private void DrawBorder(Rectangle rectangleToDraw, int thicknessOfBorder, Color borderColor)
        {

            // Draw top line
            Texture2D pixel = new Texture2D(GraphicsDevice, 1, 1);
            pixel.SetData(new Color[] { BorderColor });
            SpriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, rectangleToDraw.Width, thicknessOfBorder), borderColor);

            // Draw left line
            SpriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, thicknessOfBorder, rectangleToDraw.Height), borderColor);

            // Draw right line
            SpriteBatch.Draw(pixel, new Rectangle((rectangleToDraw.X + rectangleToDraw.Width - thicknessOfBorder),
                                            rectangleToDraw.Y,
                                            thicknessOfBorder,
                                            rectangleToDraw.Height), borderColor);
            // Draw bottom line
            SpriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X,
                                            rectangleToDraw.Y + rectangleToDraw.Height - thicknessOfBorder,
                                            rectangleToDraw.Width,
                                            thicknessOfBorder), borderColor);
        }

        public override void Draw()
        {
            base.Draw();
            DrawBorder(Rectangle, Thickness, BorderColor);
            DrawFill(Rectangle, BorderColor);
        }
    }
}
