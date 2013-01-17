using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeveliaGameEngine;
using Microsoft.Xna.Framework.Graphics;
using DeveliaGameEngine.Layouts;
using Microsoft.Xna.Framework;

namespace Develia.GUI.Themes.LD.Buttons
{
    public class LDNavButton : Button
    {

        public LDNavButton()
        {
            Label.Visible = false;
            Layout = new RelativePositionLayout();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Arrange()
        {
            base.Arrange();
            ((RelativePositionLayout)Layout).Arrange(Label, this.Bound, (int)RelativePosition.BORDER_TOP_TOP_CENTER);
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

        public override bool Contains(float x, float y)
        {
            return (base.Contains(x, y) && !Label.Contains(x, y));
        }
    }
}
