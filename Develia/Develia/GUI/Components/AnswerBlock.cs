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
        private List<Answer> _answerList;
        private List<AnswerWidget> _answerListWidget;

        public List<AnswerWidget> AnswerListWidget {
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
        
        public List<Answer> AnswerList {
            /*get
            {
                return _answerList;
            }*/
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
                _answerListWidget = tmp;
            }
        }
        public AbstractEffect OnLoadEffect;

        MouseState mouseState;
        ButtonState buttonState;

        public AnswerBlock(): base()
        {
            OnLoadEffect = new EffectShow(this);

            _answerListWidget = new List<AnswerWidget>();
            _answerList = new List<Answer>();
        }

        public override void Update(GameTime gameTime)
        {            
            mouseState = Mouse.GetState();
            buttonState = mouseState.LeftButton;

            base.Update(gameTime);
            if (Contains(mouseState.X, mouseState.Y))
            {
                foreach (AnswerWidget tmp in AnswerListWidget)
                {
                    if (tmp.Contains(mouseState.X, mouseState.Y))
                    {
                        this.Scale = new Vector2(2, 1);
                        this.TintColor = Color.Red;
                        if ((buttonState == ButtonState.Pressed))
                        {
                            //Engine.Instance.ResolutionManager.ScreenSize = new Vector2(Width, Height);
                        }
                        else
                        {
                            this.Scale = new Vector2(1, 1);
                            this.TintColor = Color.Yellow;
                        }
                    }
                }
            }
        }

        public override void OnLoad()
        {
            base.OnLoad();
            OnLoadEffect.Thread.Start();
        }
        
    }
}
