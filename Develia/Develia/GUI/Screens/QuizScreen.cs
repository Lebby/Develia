using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeveliaGameEngine;
using Develia.GUI.Components;
using DataManagement.Managers;
using DataManagement.Datatype.Test;



namespace Develia.GUI.Screens
{
    public class QuizScreen : Screen
    {
        private QuizBlock _quizBlock;
        public QuizBlock QuizBlock
        {
            get { return _quizBlock; }
            set
            {
                if (_quizBlock != default(QuizBlock)) removeComponent(_quizBlock);
                _quizBlock = value;
            }
        }
       
        public QuizScreen()
        {            
            QuizBlock = new QuizBlock();                        
        }

        public override void OnLoad()
        {
            base.OnLoad();
            Console.WriteLine("ONLOAD QUIZSCREEN");
            addComponent(QuizBlock);
        }
    }
}
