using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeveliaGameEngine
{
    public class EffectShow : AbstractEffect
    {
        public Object2D Target { get; set; }
        private EffectShow() : base()
        {}

        public EffectShow(Object2D target)
        {
            target.Visible = false;
        }

        public override void  run()
        { 	        
            Target.Visible = true;
        }

    }
}