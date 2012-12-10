using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Develia.GUI.Components;
using DataManagement.Datatype.Test;
using DataManagement.Managers;

namespace Develia.GUI.Factories
{   

    public interface IQuizFactory
    {
        QuizBlock       CreateQuizBlock     (Quiz quiz);
        QuestionBlock   CreateQuestionBlock (Quiz quiz);
        AnswerBlock     CreateAnswerBlock   (Quiz quiz);
        TipBlock        CreateTipBlock      (Quiz quiz);

        QuestionWidget  CreateQuestionWidget(Question question);        
        AnswerWidget    CreateAnswerWidget  (Answer answer);        
        TipWidget       CreateTipWidget     (Tip tip);

        void            init();        
        
    }
    
    //factory interface
    public interface    IQuizBlockFactory
    {
        QuizBlock       Create(Quiz quiz);
    }

    public interface    IQuestionBlockFactory
    {
        QuestionBlock   Create(Quiz quiz);        
    }   

    public interface    IAnswerBlockFactory
    {
        AnswerBlock     Create(Quiz quiz);        
    }

    public interface    ITipBlockFactory
    {
        TipBlock        Create(Quiz quiz);        
    }

    public interface    IQuestionWidgetFactory
    {
        QuestionWidget  Create(Question question);        
    }

    public interface    IAnswerWidgetFactory
    {
        AnswerWidget    Create(Answer answer);        
    }

    public interface    ITipWidgetFactory
    {
        TipWidget       Create(Tip tip);        
    }  

}
