using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Develia.GUI.Components;
using DataManagement.Datatype.Test;

namespace Develia.GUI.Factories
{
    //facade + strategy + factory + singlethon
    public class QuizFactory : IQuizFactory
    {
        //blocks
        private Dictionary<QuizType, IQuizBlockFactory>     _QuizBlockStrategy;
        private Dictionary<QuizType, IQuestionBlockFactory> _QuestionBlockStrategy;
        private Dictionary<QuizType, IAnswerBlockFactory>   _AnswerBlockStrategy;
        private Dictionary<QuizType, ITipBlockFactory>      _TipBlockStrategy;


        //widgets
        private Dictionary<QuestionType,    IQuestionWidgetFactory> _QuestionWidgetStrategy;
        private Dictionary<AnswerType,      IAnswerWidgetFactory>   _AnswerWidgetStrategy;
        private Dictionary<TipType,         ITipWidgetFactory>      _TipWidgetStrategy;


        //getters
        public Dictionary<QuizType,     IQuizBlockFactory>      QuizBlockStrategy       { get; }
        public Dictionary<QuizType,     IQuestionBlockFactory>  QuestionBlockStrategy   { get; }
        public Dictionary<QuizType,     IAnswerBlockFactory>    AnswerBlockStrategy     { get; }
        public Dictionary<QuizType,     ITipBlockFactory>       TipBlockStrategy        { get; }

        public Dictionary<QuestionType, IQuestionWidgetFactory> QuestionWidgetStrategy  { get; }
        public Dictionary<AnswerType,   IAnswerWidgetFactory>   AnswerWidgetStrategy    { get; }
        public Dictionary<TipType,      ITipWidgetFactory>      TipWidgetStrategy       { get; }


        //singlethon
        private static QuizFactory _Instance = null;

        public static QuizFactory Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new QuizFactory();
                return _Instance;
            }
        }


        private QuizFactory()
        {
            _QuizBlockStrategy      = new Dictionary<QuizType, IQuizBlockFactory>();
            _QuestionBlockStrategy  = new Dictionary<QuizType, IQuestionBlockFactory>();
            _AnswerBlockStrategy    = new Dictionary<QuizType, IAnswerBlockFactory>();
            _TipBlockStrategy       = new Dictionary<QuizType, ITipBlockFactory>();


            _QuestionWidgetStrategy = new Dictionary<QuestionType,  IQuestionWidgetFactory>();
            _AnswerWidgetStrategy   = new Dictionary<AnswerType,    IAnswerWidgetFactory>();
            _TipWidgetStrategy      = new Dictionary<TipType,       ITipWidgetFactory>();
            Init();
        }

        public void Init()
        {
            _QuizBlockStrategy      [QuizType.NONE] = new DefaultQuizBlockFactory();
            _QuestionBlockStrategy  [QuizType.NONE] = new DefaultQuestionBlockFactory();
            _AnswerBlockStrategy    [QuizType.NONE] = new DefaultAnswerBlockFactory();
            _TipBlockStrategy       [QuizType.NONE] = new DefaultTipBlockFactory();
        
            _QuestionWidgetStrategy [QuestionType.NONE] = new DefaultQuestionWidgetFactory();
            _AnswerWidgetStrategy   [AnswerType.NONE]   = new DefaultAnswerWidgetFactory();
            _TipWidgetStrategy      [TipType.NONE]      = new DefaultTipWidgetFactory();

        }



        //facade + strategy

        public QuizBlock CreateQuizBlock(Quiz quiz)
        {
            return QuizBlockStrategy[quiz.QuizType]
                   .Create(quiz);
        }

        public QuestionBlock CreateQuestionBlock(Quiz quiz)
        {
            return QuestionBlockStrategy[quiz.QuizType]
                    .Create(quiz);
        }

        public AnswerBlock CreateAnswerBlock(Quiz quiz)
        {
            return AnswerBlockStrategy[quiz.QuizType]
                    .Create(quiz);
        }

        public TipBlock CreateTipBlock(Quiz quiz)
        {
            return TipBlockStrategy[quiz.QuizType]
                    .Create(quiz);
        }

        public QuestionWidget CreateQuestionWidget(Question question)
        {
            return QuestionWidgetStrategy[question.Type]
                    .Create(question);
        }

        public AnswerWidget CreateAnswerWidget(Answer answer)
        {
            return AnswerWidgetStrategy[answer.Type]
                    .Create(answer);
        }

        public TipWidget CreateTipWidget(Tip tip)
        {
            return TipWidgetStrategy[tip.Type]
                    .Create(tip);
        }

    }
}
