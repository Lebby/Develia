using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DataManagement.Datatype.Test
{
    public class IDValue<K,V>
    {
        [XmlElement()]
        public K ID { get; set; }
        [XmlElement()]
        public V Value { get; set; }

        public IDValue()
        {
            ID = default(K);
            Value = default(V);            
        }

        public IDValue(K ID, V value)
        {
            this.ID = ID;
            this.Value = value;            
        }
    }
}
