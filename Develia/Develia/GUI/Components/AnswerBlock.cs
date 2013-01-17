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
    /// <summary>
    ///  This class is UI Base Container of Answers.
    /// </summary> 
    public class AnswerBlock : Layer
    {
        private List<Answer>        _answerList;
        private List<AnswerWidget>  _answerListWidget;

        /// <summary>
        ///  AnswerListWidget contains a list of UI rappresentation of Answers
        /// </summary> 
        public List<AnswerWidget> AnswerListWidget 
        {
            get { return _answerListWidget;  }
            set { _answerListWidget = value; }
        }

        /// <summary>
        /// List of Answers
        /// </summary>
        public List<Answer> AnswerList 
        { 
            get  {    return _answerList;  }
            set  {    _answerList = value; }
        }

        /// <summary>
        /// Default ctor
        /// </summary>
        public AnswerBlock(): base()
        {           
            _answerListWidget = new List<AnswerWidget>();
            _answerList = new List<Answer>();
        }

        /// <summary>
        /// On call it builds a widget for each answer and it add all widgets to render Engine.
        /// </summary>
        public override void OnLoad()
        {
            base.OnLoad();            
            List<AnswerWidget> tmpList = new List<AnswerWidget>();
            foreach (Answer tmpAnswer in _answerList)
            {
                AnswerWidget tmpa = new AnswerWidget();
                tmpa.Answer = tmpAnswer;
                tmpList.Add(tmpa);
                addComponent(tmpa);
            }                            
        }
    }
}