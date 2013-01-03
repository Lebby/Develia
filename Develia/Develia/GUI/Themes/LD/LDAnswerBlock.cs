using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Develia.GUI.Components;
using DeveliaGameEngine;
using Microsoft.Xna.Framework;

namespace Develia.GUI.Themes.LD
{
    public class LDAnswerBlock : AnswerBlock
    {
        public LDAnswerBlock()
        {
            RectangleShape tmp;

            tmp = new RectangleShape(LDTheme.AnswerBlockBound);
            tmp.FillColor = Color.Blue;
            tmp.BorderColor = Color.Green;
            addComponent(tmp);
        }
    }
}
