using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeveliaGameEngine
{
    public class Library
    {
        private Dictionary<String, Object2D> _data;
        private static Library _instance;
        
        public static Library Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance =  new Library();
                }
                return _instance;
            }
        }

        public Dictionary<String, Object2D>  Data
        {
            get
            {
                return _data;
            }
        }


    }
}
