using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DataManagement.Datatype.Test
{
    public class IDValueType<K,V,T> : IDValue<K,V>
    {
        [XmlElement()]
        public T Type { get; set; }

        public IDValueType() : base()
        {            
            Type = default(T);
        }
        public IDValueType(K ID, V value, T type) : base (ID,value)
        {            
            this.Type = type;
        }

    }
}
