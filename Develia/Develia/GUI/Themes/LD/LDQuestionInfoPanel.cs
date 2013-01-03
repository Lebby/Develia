using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeveliaGameEngine;
using Microsoft.Xna.Framework;

namespace Develia.GUI.Themes.LD
{
    public class LDQuestionInfoPanel : Layer
    {
        public LDQuestionInfoPanel()
        {
            this.Bound = LDTheme.QuestionInfoPanelBound;
            
            RectangleShape tmp;

            tmp = new RectangleShape(LDTheme.QuestionInfoPanelBound);
            //tmp.FillColor = Color.Beige;
            tmp.BorderColor = Color.Green;
            addComponent(tmp);
        }
    }
}
