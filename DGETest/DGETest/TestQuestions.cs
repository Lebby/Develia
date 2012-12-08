using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeveliaGameEngine;
using Microsoft.Xna.Framework.Storage;
using DataManagement.Datatype.Test;
using DataManagement.Managers;

namespace DGETest
{
    public class TestQuestions
    {
        static string BASE_PATH = "data\\";
        static string BASE_EXTENTIONS = ".xml";
        static string ANSWER_PATH = BASE_PATH+"Answers\\";
        static string QUESTION_PATH = BASE_PATH + "Questions\\";
        static string TIP_PATH = BASE_PATH + "Tips\\";
        static string TEST_PATH = BASE_PATH + "Tests\\";
        static string QUIZ_PATH = BASE_PATH + "Quizzes\\";
        private LinkedList<Quiz> quizList;
        private LinkedList<Answer> answers;

        private DataManager manager;
        long quizID = 0;

        public TestQuestions()
        {            
            quizList = new LinkedList<Quiz>();
            answers = new LinkedList<Answer>();
            manager = new DataManager();

        }

        public Quiz createQuiz()
        {
            Quiz tmpQuiz = new Quiz();
            Answer tmpAnswer = createAnswer();
            Question tmpQuestion = createQuestion();
            
            writeQuestion(tmpQuestion);
            writeAnswer(tmpAnswer);
            tmpQuiz.ID = quizID;            
            tmpQuiz.QuestionType = QuestionType.ONLY_TEXT;
            tmpQuiz.MainTopic.Add(9);
            tmpQuiz.MainTopic.Add(11);
            writeQuiz(tmpQuiz);
            
            return null;
        }

        public Question createQuestion()
        {
            Question tmpQuestion = new Question(0,"",QuestionType.ONLY_TEXT);
            return tmpQuestion;
        }

        public Answer createAnswer()
        {
            Answer tmpAnswer = new Answer(0,"",AnswerType.ONLY_TEXT);
            return tmpAnswer;
        }


        public void writeAnswer(Answer answer)
        {
            //String tmp = StringSerializer.Serialize<Answer>(answer);
            //FileManager.Save<Answer>(ANSWER_PATH + answer.ID + BASE_EXTENTIONS, answer);
            manager.SaveAnswer(answer);

        }

        public void writeQuestion(Question question)
        {
            //FileManager.Save<Question>(QUESTION_PATH + question.ID + BASE_EXTENTIONS, question);
            manager.SaveQuestion(question);
        }

        void writeQuiz(Quiz quiz)
        {
            //FileManager.Save<Quiz>(QUIZ_PATH + quiz.ID + BASE_EXTENTIONS, quiz);
            manager.SaveQuiz(quiz);
        }

        public void init()
        {
            string tmp = "Supponendo che: \n int a = 2; int b = 3; float c = 4; double d = 5; int risI; int e = 2; double risD; \n" +
                "Qual e' risultato dell’espressione seguente?\n" +
                "risD = d + c * b + a / b;";
            string[] answ = {"15","18,5","18"};
            Question tmpQuestion = new Question();
            tmpQuestion.Value = tmp;
            tmpQuestion.ID = 0;
            tmpQuestion.Type = QuestionType.ONLY_TEXT;
            writeQuestion(tmpQuestion);
            Quiz tmpQuiz = new Quiz();
            tmpQuiz.ID = 0;
            tmpQuiz.LevelID = 0;
            tmpQuiz.QuestionID = 0;
            tmpQuiz.QuestionType = QuestionType.ONLY_TEXT;
            tmpQuiz.TipType = TipType.ONLY_TEXT;
            tmpQuiz.AnswerType = AnswerType.ONLY_TEXT;
            int tmpId =0 ;
            foreach (string tmpString in answ)
            {
                tmpQuiz.Answers.Add(tmpId);
                Answer answer = new Answer(tmpId, tmpString, AnswerType.ONLY_TEXT);
                writeAnswer(answer);
                tmpId++;
            }
            tmpQuiz.CorrectAnswers.Add(0);
            writeQuiz(tmpQuiz);            
        }


        public Quiz createSimpleQuiz(String question, String[] answers, int[] correctAnswers)
        {
            string tmp = question;
            string[] answ = answers;
            Question tmpQuestion = new Question();
            tmpQuestion.Value = tmp;
            tmpQuestion.ID = 0;
            tmpQuestion.Type = QuestionType.ONLY_TEXT;
            writeQuestion(tmpQuestion);
            Quiz tmpQuiz = new Quiz();
            tmpQuiz.ID = 0;
            tmpQuiz.LevelID = 0;
            tmpQuiz.QuestionID = 0;
            tmpQuiz.QuestionType = QuestionType.ONLY_TEXT;
            tmpQuiz.TipType = TipType.ONLY_TEXT;
            tmpQuiz.AnswerType = AnswerType.ONLY_TEXT;
            int tmpId = 0;
            foreach (string tmpString in answ)
            {
                tmpQuiz.Answers.Add(tmpId);
                Answer answer = new Answer(tmpId, tmpString, AnswerType.ONLY_TEXT);
                writeAnswer(answer);
                tmpId++;
            }
            foreach (int tmpC in correctAnswers)
            {
                tmpQuiz.CorrectAnswers.Add(tmpC);
            }            
            writeQuiz(tmpQuiz);            
            return tmpQuiz;
        }

    }
}
