using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeveliaGameEngine;
using DataManagement.Managers;
using DataManagement.Datatype.Test;


namespace Develia.GUI.Components
{
    public class QuizBlock : Layer
    {
        private AnswerBlock _answerBlock;
        private QuestionBlock _questionBlock;
        private TipBlock _tipBlock;
        private Quiz _quiz;

        public AnswerBlock AnswerBlock {
            get { return _answerBlock; } 
            set
            {
                if (_answerBlock != default(AnswerBlock)) removeComponent(_answerBlock);
                _answerBlock = value;
                addComponent(_answerBlock);
            }
        }
        
        public QuestionBlock QuestionBlock
        {
            get { return _questionBlock; }
            set {
                if (_questionBlock != default(QuestionBlock)) removeComponent(_questionBlock);
                _questionBlock = value;
                addComponent(_questionBlock);
            } 
        }

        public TipBlock TipBlock
        {
            get { return _tipBlock; }
            set
            {
                if (_tipBlock != default(TipBlock)) removeComponent(_tipBlock);
                _tipBlock = value;
                addComponent(_tipBlock);
            }
        }
        
        public Quiz Quiz
        {
            get { return _quiz; }
            set
            {                
                if (value == null) return;
                _quiz = value;
                QuestionBlock.Question = DataManager.Instance.GetQuestion(value.QuestionID);                

                List<Answer> tmp = new List<Answer>();
                foreach(long idAnswer in value.Answers)
                {                    
                    tmp.Add(DataManager.Instance.GetAnswer(idAnswer));
                }
                AnswerBlock.AnswerList = tmp;
                //TODO: TIP BLOCK
            }
        }

        public QuizBlock()
        {
            QuestionBlock = new QuestionBlock();
            AnswerBlock = new AnswerBlock();
            TipBlock = new TipBlock();
        }

        public override void OnLoad()
        {
            base.OnLoad();
            addComponent(QuestionBlock);
            addComponent(AnswerBlock);
            addComponent(TipBlock);
        }
    }
}
