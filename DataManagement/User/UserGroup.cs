using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DataManagement
{
    public class UserGroup
    {
        [XmlElement()]
        public String name { get; set; }
        [XmlElement()]
        public long ID { get; set; }
        [XmlElement()]
        public HashSet<long> users { get; set; }
    }
}
