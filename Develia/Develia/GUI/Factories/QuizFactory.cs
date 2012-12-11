using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Develia.GUI.Components;
using DataManagement.Datatype.Test;

namespace Develia.GUI.Factories
{
    /// <summary>
    ///  This class performs an important function.
    /// </summary>
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
        public Dictionary<QuizType,     IQuizBlockFactory>      QuizBlockStrategy       { get { return _QuizBlockStrategy;} }
        public Dictionary<QuizType, IQuestionBlockFactory> QuestionBlockStrategy        { get { return _QuestionBlockStrategy; } }
        public Dictionary<QuizType,     IAnswerBlockFactory>    AnswerBlockStrategy     { get { return _AnswerBlockStrategy;} }
        public Dictionary<QuizType,     ITipBlockFactory>       TipBlockStrategy        { get { return _TipBlockStrategy;} }

        public Dictionary<QuestionType, IQuestionWidgetFactory> QuestionWidgetStrategy  { get { return _QuestionWidgetStrategy;} }
        public Dictionary<AnswerType,   IAnswerWidgetFactory>   AnswerWidgetStrategy    { get { return _AnswerWidgetStrategy;} }
        public Dictionary<TipType,      ITipWidgetFactory>      TipWidgetStrategy       { get { return _TipWidgetStrategy;} }


        //singlethon
        private static QuizFactory _Instance = null;

        /// <summary>
        ///  This class performs an important function.
        /// </summary>
        public static QuizFactory Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new QuizFactory();
                return _Instance;
            }
        }

        /// <summary>
        ///  This class performs an important function.
        /// </summary>
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

        /// <summary>
        ///  This class performs an important function.
        /// </summary>
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
        /// <summary>
        ///  This class performs an important function.
        /// </summary>
        public QuizBlock        CreateQuizBlock(Quiz quiz)
        {
            QuizBlock block = QuizBlockStrategy.ContainsKey(quiz.QuizType) ? QuizBlockStrategy[quiz.QuizType] 
                .Create(quiz) : ((new DefaultQuizBlockFactory()).Create(quiz));
            block.Quiz = quiz;
            return block;
        }

        /// <summary>
        ///  This class performs an important function.
        /// </summary>
        public QuestionBlock    CreateQuestionBlock(Quiz quiz)
        {
            return QuestionBlockStrategy.ContainsKey(quiz.QuizType)? QuestionBlockStrategy[quiz.QuizType]
                .Create(quiz) : new DefaultQuestionBlockFactory().Create(quiz);
        }

        /// <summary>
        ///  This class performs an important function.
        /// </summary>
        public AnswerBlock      CreateAnswerBlock(Quiz quiz)
        {
            return AnswerBlockStrategy.ContainsKey(quiz.QuizType)? AnswerBlockStrategy[quiz.QuizType]
                .Create(quiz) : new DefaultAnswerBlockFactory().Create(quiz);
        }

        /// <summary>
        ///  This class performs an important function.
        /// </summary>
        public TipBlock         CreateTipBlock(Quiz quiz)
        {
            return TipBlockStrategy.ContainsKey(quiz.QuizType)? TipBlockStrategy[quiz.QuizType]
                .Create(quiz) : new DefaultTipBlockFactory().Create(quiz);
        }

        /// <summary>
        ///  This class performs an important function.
        /// </summary>
        public QuestionWidget   CreateQuestionWidget(Question question)
        {
            return QuestionWidgetStrategy.ContainsKey(question.Type)? QuestionWidgetStrategy[question.Type]
                .Create(question) : new DefaultQuestionWidgetFactory().Create(question);
        }

        /// <summary>
        ///  This class performs an important function.
        /// </summary>
        public AnswerWidget     CreateAnswerWidget(Answer answer)
        {
            return AnswerWidgetStrategy.ContainsKey(answer.Type)? AnswerWidgetStrategy[answer.Type]
                .Create(answer) : new DefaultAnswerWidgetFactory().Create(answer);
        }

        /// <summary>
        ///  This class performs an important function.
        /// </summary>
        public TipWidget        CreateTipWidget(Tip tip)
        {
            return TipWidgetStrategy.ContainsKey(tip.Type) ? TipWidgetStrategy[tip.Type]
                .Create(tip) : new DefaultTipWidgetFactory().Create(tip);
        }

    }
}
