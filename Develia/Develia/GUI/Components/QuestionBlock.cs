using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeveliaGameEngine;
using DataManagement.Datatype.Test;


namespace Develia.GUI.Components
{
    public class QuestionBlock : Layer
    {
        private QuestionWidget _questionWidget;
        public QuestionWidget QuestionWidget {
            get { return _questionWidget; }
            set
            {               
                _questionWidget = value;                
            } 
        }

        public Question Question
        {
            get { return QuestionWidget.Question; }
            set { QuestionWidget.Question = value; }
        }

        public QuestionBlock()
        {
            QuestionWidget = new QuestionWidget();
        }

        public override void OnLoad()
        {
            base.OnLoad();            
            addComponent(_questionWidget);                
        }
    }
}
