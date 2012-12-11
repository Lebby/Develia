using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataManagement.Datatype.Test;
using Develia.GUI.Components;
using DataManagement.Managers;
using Develia.GUI.Components.Defaults;

namespace Develia.GUI.Factories
{
    //default factories impl
    public class DefaultQuizBlockFactory : IQuizBlockFactory
    {
        public QuizBlock Create(Quiz quiz)
        {
            QuizBlock quizBlock = new QuizBlock();

            quizBlock.QuestionBlock = QuizFactory.Instance.CreateQuestionBlock  (quiz);
            quizBlock.AnswerBlock   = QuizFactory.Instance.CreateAnswerBlock    (quiz);
            quizBlock.TipBlock      = QuizFactory.Instance.CreateTipBlock       (quiz);


            foreach (long tmp in quiz.Answers)
            {
                Answer tmpAnswer = DataManager.Instance.GetAnswer(tmp);
                quizBlock
                    .AnswerBlock
                    .AnswerListWidget
                    .Add(QuizFactory.Instance.CreateAnswerWidget(tmpAnswer));
            }

            return quizBlock;
            //return default(QuizBlock);
        }
    }

    public class DefaultQuestionBlockFactory    : IQuestionBlockFactory
    {
        public QuestionBlock Create(Quiz quiz)
        {
            DefaultQuestionBlock tmp;
            tmp = new DefaultQuestionBlock();
            return tmp;
        }
    }

    public class DefaultAnswerBlockFactory      : IAnswerBlockFactory
    {
        public AnswerBlock Create(Quiz quiz)
        {
            DefaultAnswerBlock tmp;
            tmp = new DefaultAnswerBlock();
            return tmp;
        }
    }

    public class DefaultTipBlockFactory         : ITipBlockFactory
    {
        public TipBlock Create(Quiz quiz)
        {
            TipBlock tmp;
            tmp = new DefaultTipBlock();
            return tmp;
        }
    }

    public class DefaultQuestionWidgetFactory   : IQuestionWidgetFactory
    {
        public QuestionWidget Create(Question question)
        {
            QuestionWidget tmp;
            tmp = new DefaultQuestionWidget();
            return tmp;
        }
    }

    public class DefaultAnswerWidgetFactory     : IAnswerWidgetFactory
    {
        public AnswerWidget Create(Answer answer)
        {
            AnswerWidget tmp;
            tmp = new DefaultAsnwerWidget();
            return tmp;
        }
    }

    public class DefaultTipWidgetFactory        : ITipWidgetFactory
    {
        public TipWidget Create(Tip tip)
        {
            TipWidget tmp;
            tmp = new DefaultTipWidget();
            return tmp;
        }             
    }
}
