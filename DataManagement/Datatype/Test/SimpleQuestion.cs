using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DataManagement.Datatype.Test
{
    public class SimpleQuestion
    {
        [XmlElement()]
        public long ID { get; set; }
        
        [XmlElement()]
        public String Value { get; set; }

    }
}
