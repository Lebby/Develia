using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DataManagement.Datatype.Test
{
    public class Quiz
    {
        [XmlElement()]
        public long ID { get; set; }
        
        [XmlElement()]
        public long QuestionID { get; set; }

        [XmlElement()]
        public QuestionType QuestionType { get; set; }

        [XmlElement()]
        public QuizType QuizType { get; set; }

        [XmlElement()]
        public AnswerType AnswerType { get; set; }

        [XmlElement()]
        public TipType TipType { get; set; }

        [XmlElement()]
        public HashSet<long> MainTopic { get; set; }

        [XmlElement()]
        public HashSet<long> SubTopic { get; set; }

        [XmlElement()]
        public long LevelID { get; set; }
        
        [XmlElement()]
        public HashSet<long> Answers { get; set; }

        [XmlElement()]
        public HashSet<long> CorrectAnswers { get; set; }

        [XmlElement()]
        public HashSet<long> Tips { get; set; }

        [XmlElement()]
        public float Difficulty { get; set; }

        public Quiz()
        {
            ID = 0;
            QuestionID = 0;
            QuestionType = QuestionType.NONE;
            MainTopic = new HashSet<long>();
            SubTopic = new HashSet<long>();
            LevelID = 0;
            Answers = new HashSet<long>();
            CorrectAnswers = new HashSet<long>();
            Tips = new HashSet<long>();
        }

    }
}
