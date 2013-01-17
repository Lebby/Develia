using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeveliaGameEngine;
using DataManagement.Datatype.Test;

namespace Develia.GUI.Components
{
    public class TipBlock : Layer
    {
        private List<Tip>        _tipList;
        private List<TipWidget>  _tipListWidget;

        /// <summary>
        ///  This class performs an important function.
        /// </summary> 
        public List<TipWidget> TipListWidget 
        {
            get
            {
                return _tipListWidget;
            }
            set
            {                
                _tipListWidget = value;                
            }
        }

        /// <summary>
        ///  This class performs an important function.
        /// </summary>
        public List<Tip> TipList 
        {
 
            get
            {
                return _tipList;
            }
            
            set
            {
                _tipList = value;                
            }

        }

        /// <summary>
        ///  This class performs an important function.
        /// </summary>
        public TipBlock(): base()
        {           
            _tipListWidget = new List<TipWidget>();
            _tipList = new List<Tip>();
        }

        public override void OnLoad()
        {
            base.OnLoad();
            List<TipWidget> tmpL = new List<TipWidget>();
            foreach (Tip tmpTip in _tipList)
            {
                TipWidget tmpa = new TipWidget();
                tmpa.Tip = tmpTip;
                tmpL.Add(tmpa);
                addComponent(tmpa);
            }
            TipListWidget = tmpL;
        }
    }
}
