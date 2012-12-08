using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataManagement.Datatype.Test;

namespace DataManagement.Managers
{
    public interface Manager
    {
        Test LoadTest(long id);
        Quiz LoadQuiz(long id);
        Question LoadQuestion(long id);        
        Answer LoadAnswer(long id);
        Tip LoadTip(long id);
        
        void SaveTest(Test test);
        void SaveQuiz(Quiz quiz);
        void SaveQuestion(Question question);
        void SaveAnswer(Answer answer);
        void SaveTip(Tip tip);

    }
}
