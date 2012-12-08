using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DataManagement.Datatype.Test
{
    public class Test
    {
        [XmlElement()]
        public long ID { get; set; }
        [XmlElement()]
        public SortedSet<long> QuizList { get; set; }        
        [XmlElement()]
        public long Topic { get; set; }

        public Test()
        {
            ID = 0;
            QuizList = new SortedSet<long>();
            Topic = 0;
        }
            
    }
}
