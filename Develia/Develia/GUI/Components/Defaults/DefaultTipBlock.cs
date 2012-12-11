using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeveliaGameEngine;

namespace Develia.GUI.Components.Defaults
{
    public class DefaultTipBlock : TipBlock
    {
        public AbstractEffect OnLoadEffect;
        
        public DefaultTipBlock()
            : base()
        {
            OnLoadEffect = new EffectShow(this);
            Layout = new DefaultLayout();
        }
    }
}
