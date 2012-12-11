using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeveliaGameEngine;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using DataManagement.Datatype.Test;


namespace Develia.GUI.Components
{
    public class AnswerBlock : Layer
    {
        private List<Answer>        _answerList;
        private List<AnswerWidget>  _answerListWidget;

        /// <summary>
        ///  This class performs an important function.
        /// </summary> 
        public List<AnswerWidget> AnswerListWidget 
        {
            get
            {
                return _answerListWidget;
            }
            set
            {
                if (_answerListWidget.Count != 0)
                {
                    foreach (AnswerWidget tmp in _answerListWidget)
                    {
                        removeComponent(tmp);
                    }
                }
                _answerListWidget = value;
                foreach (AnswerWidget tmp in _answerListWidget)
                {
                    addComponent(tmp);
                }
            }
        }

        /// <summary>
        ///  This class performs an important function.
        /// </summary>
        public List<Answer> AnswerList 
        {
 
            get
            {
                return _answerList;
            }
            
            set
            {
                _answerList = value;
                List<AnswerWidget> tmp = new List<AnswerWidget>();
                
                foreach (Answer tmpAnswer in _answerList)
                {
                    AnswerWidget tmpa = new AnswerWidget();
                    tmpa.Answer = tmpAnswer;
                    tmp.Add(tmpa);
                }
                AnswerListWidget = tmp;
            }

        }

        /// <summary>
        ///  This class performs an important function.
        /// </summary>
        public AnswerBlock(): base()
        {           
            _answerListWidget = new List<AnswerWidget>();
            _answerList = new List<Answer>();
        }        
    }
}