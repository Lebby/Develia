using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Develia.GUI.Screens;
using DeveliaGameEngine;
using Microsoft.Xna.Framework;

namespace Develia.GUI.Themes.LD
{
    public class LDQuizScreen : QuizScreen
    {
        
        public LDQuizScreen()
        {
            RectangleShape tmp;

            tmp = new RectangleShape(LDTheme.QuestionInfoPanelBound);
            //tmp.FillColor = Color.Beige;
            tmp.BorderColor = Color.Green;
            addComponent(tmp);

            tmp = new RectangleShape(LDTheme.QuizInfoPanelBound);
            //tmp.FillColor = Color.Purple;
            tmp.BorderColor = Color.Green;
            addComponent(tmp);

            
            tmp = new RectangleShape(LDTheme.QuizBlockBound);            
            tmp.FillColor = Color.Red;            
            tmp.BorderColor = Color.Green;
            addComponent(tmp);
            
            tmp = new RectangleShape(LDTheme.QuestionBlockBound);
            tmp.FillColor = Color.AliceBlue;
            tmp.BorderColor = Color.Green;
            addComponent(tmp);            

            tmp = new RectangleShape(LDTheme.AnswerBlockBound);
            tmp.FillColor = Color.Blue;
            tmp.BorderColor = Color.Green;
            addComponent(tmp);
            
            tmp = new RectangleShape(LDTheme.CommandPanelBound);
            tmp.FillColor = Color.Peru;
            tmp.BorderColor = Color.Green;
            addComponent(tmp);

            /*tmp = new RectangleShape(new Rectangle(100,100,100,100));
            tmp.FillColor = Color.Purple;
            tmp.BorderColor = Color.Green;
            addComponent(tmp);*/

            this.QuizBlock = new LDQuizBlock();
        }
    }
}
