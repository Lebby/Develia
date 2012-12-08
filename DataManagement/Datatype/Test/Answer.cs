using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;


namespace DataManagement.Datatype.Test
{
    public class Answer
    {
        [XmlElement()]
        public long ID { get; set; }
        [XmlElement()]
        public string Value { get; set; }
        [XmlElement()]
        public AnswerType Type { get; set; }

        public Answer()
            : base()
        {
        }
        public Answer(long ID, string value, AnswerType type)
        {
            this.ID = ID;
            this.Value = value;
            this.Type = type;
        }
    }
}
