using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeveliaGameEngine;
using Microsoft.Xna.Framework.Graphics;
using DataManagement.Datatype.Test;

namespace Develia.GUI.Components
{
    public class QuestionWidget : TextWidget
    {
        public QuestionWidget() : base(DeveliaTheme.QuestionFont)
        {            
        }

        private Question _question;

        public Question Question
        {
            get { return _question; }
            set
            {
                if (value == null) return;
                _question = value;
                Text = value.Value;
                Console.WriteLine("Question added: " + Text);
            }
        }
    }
}
