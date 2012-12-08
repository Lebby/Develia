using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DataManagement.Datatype.Test
{
    public class Question : IDValueType<long,string,QuestionType>
    {
        public Question() : base(0, "", QuestionType.NONE) { }
        public Question(long ID, string value, QuestionType type) : base (ID,value,type)
        {
            this.ID = ID;
            this.Value = value;
            this.Type = type;
        }

    }
}
