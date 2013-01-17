using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Develia.GUI.Components;
using DeveliaGameEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.CompilerServices;

namespace Develia.GUI.Themes.LD
{
    public class LDQuizBlock : QuizBlock
    {        
        public LDQuizBlock()
        {                        
            Bound = LDTheme.QuizBlockBound;            
            AutoBound = false;
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            BackgroundImage = Game.Content.Load<Texture2D>("Images\\paper");
            Vector2 tmp = new Microsoft.Xna.Framework.Vector2();
            tmp.X = (float)LDTheme.QuizBlockBound.Width / (float)(BackgroundImage.Bounds.Width);
            tmp.Y = (float)LDTheme.QuizBlockBound.Height / (float)(BackgroundImage.Bounds.Height);
            Console.WriteLine("Scale X: " + tmp.X);
            Console.WriteLine("Scale Y: " + tmp.Y);            
            this.Scale = tmp;
            Console.WriteLine(RuntimeHelpers.GetHashCode(this));
        }
    }
}