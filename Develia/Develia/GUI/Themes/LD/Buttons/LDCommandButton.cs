using System;
using System.Collections.Generic;
using DeveliaGameEngine;
using DeveliaGameEngine.Layouts;

namespace Develia.GUI.Themes.LD.Buttons
{
    
    public class LDCommandButton : Button
    {
        public LDCommandButton()
        {
            Label.Visible = false;
            this.Layout = new RelativePositionLayout();
        }

        public override void OnOver(Microsoft.Xna.Framework.Input.MouseState state)
        {
            base.OnOver(state);
            Label.Visible = true;
        }

        public override void OnBlur(Microsoft.Xna.Framework.Input.MouseState state)
        {
            base.OnBlur(state);
            Label.Visible = false;
        }

        public override void Arrange()
        {
            base.Arrange();
            ((RelativePositionLayout)Layout).Arrange(Label, this.Bound, (int)RelativePosition.BORDER_LEFT_CENTER_LEFT);
        }
        
    }
}
