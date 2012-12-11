using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeveliaGameEngine;

namespace Develia.GUI.Components.Defaults
{
    public class DefaultQuizBlock : QuizBlock
    {
        public AbstractEffect OnLoadEffect;

        public DefaultQuizBlock()
        {
            OnLoadEffect = new EffectShow(this);
            Layout = new DefaultLayout();
        }
    }
}
