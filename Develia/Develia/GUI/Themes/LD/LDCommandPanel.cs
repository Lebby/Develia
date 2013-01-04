using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeveliaGameEngine;
using Microsoft.Xna.Framework;

namespace Develia.GUI.Themes.LD
{
    public class LDCommandPanel : Layer
    {        
        private XButton xButton;
        private VButton vButton;
        private TipsButton tipsButton;

        public LDCommandPanel()
        {
            RectangleShape tmp;
            tmp = new RectangleShape(LDTheme.CommandPanelBound);
            //tmp.FillColor = Color.Peru;
            tmp.BorderColor = Color.Green;
            addComponent(tmp);

            xButton = new XButton();
            vButton = new VButton();
            tipsButton = new TipsButton();
            this.addComponent(xButton);            
            this.addComponent(vButton);
            this.addComponent(tipsButton);
        }
        public override void OnLoad()
        {
            base.OnLoad();
            xButton.Position = Position;
            vButton.Position = Position;
            tipsButton.Position = Position;
        }
        
    }
}
