using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DataManagement.Datatype.Test
{
    public class Topic : IDValue<long,string>
    {
        public Topic() : base() { }
    }
}
