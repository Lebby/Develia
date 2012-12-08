using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeveliaGameEngine
{
    class IDManager
    {
        private static IDManager _instance;
        private Dictionary<string, long> _lastID;
        private long _START_ID;

        public long START_ID
        {
            get
            {
                return _START_ID;
            }

            set
            {
                _START_ID = value;
            }
        }

        public static IDManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new IDManager();
                }
                return _instance;
            }
        }

        private IDManager()
        {
            _lastID = new Dictionary<string, long>();
            _START_ID = 0;
        }

        public long getLastID(string key)
        {
            if (_lastID.ContainsKey(key))
            {
                return _lastID[key];
            }
            return -1;
        }

        public long getID(string key)
        {
            if (!_lastID.ContainsKey(key))
            {
                _lastID[key] = _START_ID;
            }
            else _lastID[key]++;
            return _lastID[key];
        }

    }
}
