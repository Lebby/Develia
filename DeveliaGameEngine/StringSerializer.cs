using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace DeveliaGameEngine
{
    public class StringSerializer
    {
        public static string Serialize<T>(T tData)
        {
            var serializer = new XmlSerializer(typeof(T));

            TextWriter writer = new StringWriter();
            serializer.Serialize(writer, tData);

            return writer.ToString();
        }

        public static T Deserialize<T>(string tData)
        {
            var serializer = new XmlSerializer(typeof(T));

            TextReader reader = new StringReader(tData);

            return (T)serializer.Deserialize(reader);
        }
        
        /*
        public void deserialize()
        {
            Object city = new Object();

            XmlSerializer serializer = new XmlSerializer(city.GetType());

            StreamReader reader = new StreamReader(@"D:\Temporary\myfile.xml");
            object deserialized = serializer.Deserialize(reader.BaseStream);

            city = (Object)deserialized;
        }


        public void serialize()
        {
            XmlSerializer xsSubmit = new XmlSerializer(typeof(Object));
            var subReq = new Object();
            StringWriter sww = new StringWriter();
            XmlWriter writer = XmlWriter.Create(sww);
            xsSubmit.Serialize(writer, subReq);
            var xml = sww.ToString(); // Your xml
        }
        
        */

    }
}
