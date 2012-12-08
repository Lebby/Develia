using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataManagement.Datatype.Test;
using DeveliaGameEngine;


namespace DataManagement.Managers
{
    public class DataManager
    {        
        static Manager manager=new FileManager();
        private static DataManager _instance;
        public static DataManager Instance
        {
            get
            {
                if (_instance == default(DataManager))
                {
                    _instance = new DataManager();
                }
                return _instance;
            }
        }
        

        public Question GetQuestion(long ID)
        {
            Question question = manager.LoadQuestion(ID);
            return question;
        }
        public Answer GetAnswer(long ID){return manager.LoadAnswer(ID);}
        public Quiz GetQuiz(long ID) { return manager.LoadQuiz(ID); }
        public Test GetTest(long ID) { return manager.LoadTest(ID); }

        
        public void SaveQuestion(Question question)
        {
            manager.SaveQuestion(question);
        }

        public void SaveTest(Test test)
        {
            foreach (long tmp in test.QuizList)
            {
                Quiz tmpQuiz = GetQuiz(tmp);
                SaveQuiz(tmpQuiz);                
            }
            manager.SaveTest(test);

        }

        public void SaveQuiz(Quiz quiz)
        {
            SaveQuestion(GetQuestion(quiz.QuestionID));
            foreach(long tmpAnswer in quiz.Answers)
            {
                SaveAnswer(GetAnswer(tmpAnswer));
            }
            manager.SaveQuiz(quiz);
        }


        public void SaveAnswer(Answer answer)
        {
            manager.SaveAnswer(answer);
        }
    }
}
