using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using DataManagement.Datatype.Test;

namespace DataManagement.Managers
{
    public class FileManager : Manager
    {
        static string BASE_PATH = "data\\";
        static string BASE_EXTENTIONS = ".xml";
        static string ANSWER_PATH = BASE_PATH + "Answers\\";
        static string QUESTION_PATH = BASE_PATH + "Questions\\";
        static string TIP_PATH = BASE_PATH + "Tips\\";
        static string TEST_PATH = BASE_PATH + "Tests\\";
        static string QUIZ_PATH = BASE_PATH + "Quizzes\\";

        public void Save<T>(string filename, T data)
        {
            try
            {
                Stream stream = File.Create(filename);
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(stream, data);
                stream.Close();
            }
            catch (Exception e)
            {
                System.Console.Out.WriteLine(e.StackTrace);
            }
        }

        public T Load<T>(string filename)
        {
            T data;
            try
            {
                Console.WriteLine("Opening : " + filename);
                Stream stream = File.OpenRead(filename);
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                data = (T)serializer.Deserialize(stream);
                stream.Close();
            }
            catch (Exception e)
            {
                data = default(T);
                System.Console.Out.WriteLine(e.StackTrace);
            }
            return data;
        }


        public Test LoadTest(long id) {
            return Load<Test>(TEST_PATH + id + BASE_EXTENTIONS);
        }

        public Quiz LoadQuiz(long id) {
            return Load<Quiz>(QUIZ_PATH + id + BASE_EXTENTIONS);
        }

        public Question LoadQuestion(long id)
        {
            return Load<Question>(QUESTION_PATH + id + BASE_EXTENTIONS);
        }

        public Answer LoadAnswer(long id)
        {
            return Load<Answer>(ANSWER_PATH + id + BASE_EXTENTIONS);
        }

        public Tip LoadTip(long id) {
            return Load<Tip>(TIP_PATH + id + BASE_EXTENTIONS);
        }

        public void SaveTest(Test test)
        {
            Save<Test>(TEST_PATH + test.ID + BASE_EXTENTIONS,test);
        }

        public void SaveQuiz(Quiz quiz)
        {
            Save<Quiz>(QUIZ_PATH + quiz.ID + BASE_EXTENTIONS, quiz);
        }

        public void SaveQuestion(Question question)
        {
            Save<Question>(QUESTION_PATH + question.ID + BASE_EXTENTIONS, question);
        }

        public void SaveAnswer(Answer answer)
        {
            Save<Answer>(ANSWER_PATH + answer.ID + BASE_EXTENTIONS, answer);
        }

        public void SaveTip(Tip tip)
        {
            Save<Tip>(TIP_PATH + tip.ID + BASE_EXTENTIONS, tip);
        }        
    }
}