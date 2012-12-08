using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DataManagement
{
    public class User
    {
        [XmlElement()]
        public long ID { get; set; }
        [XmlElement()]
        public String name { get; set; }
        [XmlElement()]
        public String surName { get; set; }
        [XmlElement()]
        public String address { get; set; }
        [XmlElement()]
        public String email { get; set; }
        [XmlElement()]
        public String telephone { get; set; }
        [XmlElement()]
        public String birthDate { get; set; }
        
        [XmlElement()]
        public String username { get; set; }
        [XmlElement()]
        public String password { get; set; }

        public User()
        {
        }
    }
}
