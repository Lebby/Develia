using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeveliaGameEngine;
using Microsoft.Xna.Framework;
using Develia.GUI.Themes.LD;
using DeveliaGameEngine.Layouts;

namespace DGETest
{
    public class TestRelativeLayout: Screen
    {
        static Rectangle container = new Rectangle();

        public TestRelativeLayout()
        {            
            container.Location = new Point(100, 100);
            container.Width = 400;
            container.Height = 300;
            XXButton button = new XXButton();
            addComponent(button);
            RectangleShape tmp = new RectangleShape(container);
            tmp.BorderColor = Color.Red;
            addComponent(tmp);
        }

        class XXButton : XButton
        {
            RelativePosition tmp = RelativePosition.TOP_LEFT;
            RelativePositionLayout layout = new RelativePositionLayout();
            public override void OnClick(Microsoft.Xna.Framework.Input.MouseState state)
            {
                base.OnClick(state);
                layout.Arrange(this, container , (int)tmp);
                tmp++;
                if ((int)tmp > 40) tmp = 0;                
            }
        }
    }
}
