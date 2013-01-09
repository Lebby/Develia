using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DeveliaGameEngine
{
    

    public abstract class AbstractEffect
    {

#if XBOX
    Thread.SetProcessorAffinity(); 
#endif
        
        public Thread Thread { get; set; }
        
        public AbstractEffect()
        {
            ThreadStart threadStarter = delegate
	                    {
                            run();
	                    };
                    Thread = new Thread(threadStarter);            
        }
        
        public abstract void run();

    }
}