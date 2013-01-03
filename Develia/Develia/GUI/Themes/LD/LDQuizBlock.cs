using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Develia.GUI.Components;
using DeveliaGameEngine;
using Microsoft.Xna.Framework;

namespace Develia.GUI.Themes.LD
{
    public class LDQuizBlock : QuizBlock
    {
        public LDQuizBlock()
        {
            RectangleShape tmp;
            tmp = new RectangleShape(LDTheme.QuizBlockBound);
            tmp.FillColor = Color.Red;
            tmp.BorderColor = Color.Green;
            addComponent(tmp);
        }
    }
}
