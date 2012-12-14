using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DeveliaGameEngine
{
    class Util
    {
        public static void DrawRectangle(Rectangle rectangleToDraw, Color fillColor, Color borderColor, int thicknessOfBorder = 2 )
        {            
            // Draw top line
            Texture2D pixel1 = new Texture2D(Engine.Instance.Game.GraphicsDevice, 1, 1);
            pixel1.SetData(new Color[] { fillColor });
            Engine.Instance.SpriteBatch.Draw(pixel1, rectangleToDraw, fillColor);

            Texture2D pixel = new Texture2D(Engine.Instance.Game.GraphicsDevice, 1, 1);
            pixel.SetData(new Color[] { borderColor });
            Engine.Instance.SpriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, rectangleToDraw.Width, thicknessOfBorder), borderColor);

            // Draw left line
            Engine.Instance.SpriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, thicknessOfBorder, rectangleToDraw.Height), borderColor);

            // Draw right line
            Engine.Instance.SpriteBatch.Draw(pixel, new Rectangle((rectangleToDraw.X + rectangleToDraw.Width - thicknessOfBorder),
                                            rectangleToDraw.Y,
                                            thicknessOfBorder,
                                            rectangleToDraw.Height), borderColor);
            // Draw bottom line
            Engine.Instance.SpriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X,
                                            rectangleToDraw.Y + rectangleToDraw.Height - thicknessOfBorder,
                                            rectangleToDraw.Width,
                                            thicknessOfBorder), borderColor);

        }
    }
}
