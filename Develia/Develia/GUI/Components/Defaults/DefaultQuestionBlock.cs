using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeveliaGameEngine;

namespace Develia.GUI.Components.Defaults
{
    public class DefaultQuestionBlock : QuestionBlock
    {
        public AbstractEffect OnLoadEffect;

        public DefaultQuestionBlock()
        {
            OnLoadEffect = new EffectShow(this);
            Layout = new DefaultLayout();
        }
    }
}
