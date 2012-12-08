using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Develia.GUI.Components;
using DataManagement.Datatype.Test;
using DataManagement.Managers;

namespace Develia.GUI.Util
{   

    public interface IQuizFactory
    {
        QuestionBlock CreateQuestionBlock(QuestionType type);
        QuestionWidget CreateQuestionWidget(Question question);
        AnswerBlock CreateAnswerBlock(QuizType type);
        AnswerWidget CreateAnswerWidget(Answer answer);
        TipBlock CreateTipBlock(TipType type);
        TipWidget CreateTipWidget(Tip tip);
        QuizBlock CreateQuizBlock(Quiz quiz);

        void Register(QuizType type, IQuizBlockFactory factory);
        void Register(QuizType type, IQuestionBlockFactory factory);
        void Register(QuizType type, IAnswerBlockFactory factory);
        void Register(QuizType type, ITipBlockFactory factory);
        
        void Register(QuestionType type, IQuestionWidgetFactory factory);
        void Register(AnswerType type, IAnswerWidgetFactory factory);
        void Register(TipType type, ITipWidgetFactory factory);
        
    }
    
    public abstract class AbstractQuizFactory : IQuizFactory
    {
        private Dictionary<QuizType, IQuizBlockFactory> _QuizBlockStrategy = new Dictionary<QuizType, IQuizBlockFactory>();
        private Dictionary<QuizType, IQuestionBlockFactory> _QuestionBlockStrategy = new Dictionary<QuizType, IQuestionBlockFactory>();
        private Dictionary<QuizType, IAnswerBlockFactory> _AnswerBlockStrategy = new Dictionary<QuizType, IAnswerBlockFactory>();
        private Dictionary<QuizType, ITipBlockFactory> _TipBlockStrategy = new Dictionary<QuizType, ITipBlockFactory>();

        
        private Dictionary<QuestionType, IQuestionWidgetFactory> _QuestionWidgetStrategy = new Dictionary<QuestionType, IQuestionWidgetFactory>();
        private Dictionary<AnswerType, IAnswerWidgetFactory> _AnswerWidgetStrategy = new Dictionary<AnswerType, IAnswerWidgetFactory>();
        private Dictionary<TipType, ITipWidgetFactory> _TipWidgetStrategy = new Dictionary<TipType, ITipWidgetFactory>();
        
        
        public QuizBlock CreateQuizBlock(Quiz quiz)
        {
            QuizBlock quizBlock = new QuizBlock();
            
            quizBlock.QuestionBlock = CreateQuestionBlock(quiz.QuestionType);
            quizBlock.AnswerBlock   = CreateAnswerBlock(quiz.QuizType);            
            quizBlock.TipBlock      = CreateTipBlock(quiz.TipType);


            foreach(long tmp in quiz.Answers )
            {
                Answer tmpAnswer = DataManager.Instance.GetAnswer(tmp);
                quizBlock.AnswerBlock.AnswerListWidget.Add(CreateAnswerWidget(tmpAnswer));
            }


            return default(QuizBlock);
        }
    }

    public interface IQuizBlockFactory
    {
        QuizBlock Create();
    }

    public interface IQuestionBlockFactory
    {
        QuestionBlock Create();
    }

    public interface IQuestionWidgetFactory
    {
        QuestionWidget Create();
    }

    public interface IAnswerBlockFactory
    {
        AnswerBlock Create();
    }

    public interface IAnswerWidgetFactory
    {
        AnswerWidget Create();
    }

    public interface ITipBlockFactory
    {
        TipBlock Create();
    }

    public interface ITipWidgetFactory
    {
        TipWidget Create();
    }

    
    /*public interface IQuizStrategy
    {
        QuestionBlock CreateQuestionBlock(Question question);
        AnswerBlock CreateAnswerBlock(List<Answer> anwser);
        QuizBlock CreateQuizBlock(Quiz quiz);
        
        AnswerWidget CreateAnswerWidget(Answer answer);
        QuestionWidget CreateQuestionWidget(Question question);
        
    }*/



}
