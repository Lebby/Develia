using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeveliaGameEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using DataManagement.Datatype.Test;

namespace Develia.GUI.Components
{
    public class AnswerWidget : TextWidget
    {
        private Answer _answer;
        public Answer Answer{
            get 
            {
                return _answer;
            }
            set
            {
                _answer = value;
                Text = _answer.Value;
            }

        }
        public AbstractEffect OnLoadEffect { get; set; }

        public AnswerWidget() : base(DeveliaTheme.AnswerFont)
        {
        }

        public override void OnLoad()
        {
            base.OnLoad();
        }
    }
}
