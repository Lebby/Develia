using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeveliaGameEngine;
using Microsoft.Xna.Framework;
using Develia.GUI.Themes.LD.Buttons;

namespace Develia.GUI.Themes.LD.Panels
{
    public class LDCommandPanel : Layer
    {        
        private LDXButton xButton;
        private LDVButton vButton;
        private LDTipsButton tipsButton;

        public LDCommandPanel()
        {
            /*RectangleShape tmp;
            tmp = new RectangleShape(LDTheme.CommandPanelBound);
            tmp.FillColor = Color.Green;
            tmp.BorderColor = Color.Green;
            addComponent(tmp);*/
            Bound = LDTheme.CommandPanelBound;
            xButton = new LDXButton();
            vButton = new LDVButton();
            tipsButton = new LDTipsButton();            
        }
        
        public override void OnLoad()
        {
            base.OnLoad();
            this.addComponent(xButton);
            this.addComponent(vButton);
            this.addComponent(tipsButton);
        }

        public override void Arrange()
        {
            base.Arrange();
            tipsButton.Position = Position;
            Rectangle tmp = vButton.Bound;
            tmp.Location  = new Point((int)Position.X,(int) Position.Y         + tipsButton.Bound.Height);
            vButton.Bound = tmp;
            tmp = xButton.Bound;
            tmp.Location = new Point((int)Position.X, (int)vButton.Position.Y + vButton.Bound.Height);
            xButton.Bound = tmp;
        }
        
    }
}
