using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Develia.GUI.Screens;
using DeveliaGameEngine;
using Microsoft.Xna.Framework;

namespace Develia.GUI.Themes.LD
{
    public class LDQuizScreen       : QuizScreen
    {
        private LDQuestionInfoPanel questionInfoPanel;
        private LDQuizInfoPanel     quizInfoPanel;
        private LDCommandPanel      commandPanel;
        //quiz panel is inside QuizScreen

        public LDQuizScreen()
        {
            this.QuizBlock          =   new LDQuizBlock();            
            questionInfoPanel       =   new LDQuestionInfoPanel();
            quizInfoPanel           =   new LDQuizInfoPanel();
            commandPanel            =   new LDCommandPanel();

            addComponent(quizInfoPanel);
            addComponent(questionInfoPanel);
            addComponent(commandPanel);
        }
    }
}
