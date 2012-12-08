using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DataManagement.Datatype.Test
{
    public class Tip : IDValueType<long,string,TipType>
    {
        public Tip() : base() { }
    }
}
