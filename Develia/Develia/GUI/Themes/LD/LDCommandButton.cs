using System;
using System.Collections.Generic;
using DeveliaGameEngine;

namespace Develia.GUI.Themes.LD
{
    
    public class LDCommandButton : Button
    {
        public LDCommandButton()
        {
            Label.Visible = false;
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
    }
}
