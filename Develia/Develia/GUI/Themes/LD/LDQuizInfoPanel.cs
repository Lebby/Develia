using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeveliaGameEngine;
using Microsoft.Xna.Framework;

namespace Develia.GUI.Themes.LD
{
    public class LDQuizInfoPanel : Layer
    {

        public LDQuizInfoPanel()
        {
            RectangleShape tmp;

            tmp = new RectangleShape(LDTheme.QuizInfoPanelBound);
            //tmp.FillColor = Color.Purple;
            tmp.BorderColor = Color.Green;
            addComponent(tmp);
        }
    }
}
