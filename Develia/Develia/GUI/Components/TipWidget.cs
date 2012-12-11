using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeveliaGameEngine;
using DataManagement.Datatype.Test;

namespace Develia.GUI.Components
{
    public class TipWidget : TextWidget
    {
        private Tip _tip;
        
        public Tip Tip{
            get 
            {
                return _tip;
            }
            set
            {
                _tip = value;
                Text = _tip.Value;
            }

        }
        public AbstractEffect OnLoadEffect { get; set; }

        

        public override void OnLoad()
        {
            base.OnLoad();
        }
    
        public TipWidget() : base(DeveliaTheme.TipFont)
        {}
    }
}
