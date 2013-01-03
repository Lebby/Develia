using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeveliaGameEngine;
using Microsoft.Xna.Framework;

namespace Develia.GUI.Themes.LD
{
    public class LDQuestionBlock : Layer
    {
        public LDQuestionBlock()
        {
            RectangleShape tmp;

            tmp = new RectangleShape(LDTheme.QuestionBlockBound);
            tmp.FillColor = Color.AliceBlue;
            tmp.BorderColor = Color.Green;
            addComponent(tmp); 
        }
    }
}
