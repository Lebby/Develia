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
                if (_questionWidget != default(QuestionWidget)) removeComponent(_questionWidget);
                _questionWidget = value;
                addComponent(_questionWidget);
            } 
        }

        public Question Question
        {
            get { return QuestionWidget.Question; }
            set
            {
                QuestionWidget.Question = value;                
            }
        }

        public QuestionBlock()
        {
            QuestionWidget = new QuestionWidget();
        }

    }
}
