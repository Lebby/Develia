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
            /*RectangleShape tmp;
            tmp = new RectangleShape(LDTheme.CommandPanelBound);
            tmp.FillColor = Color.Green;
            tmp.BorderColor = Color.Green;
            addComponent(tmp);*/
            Bound = LDTheme.CommandPanelBound;
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
        }

        public override void Arrange()
        {
            base.Arrange();
            tipsButton.Position = Position;
            vButton.Position    = new Vector2(Position.X, Position.Y         + tipsButton.Bound.Height);
            xButton.Position    = new Vector2(Position.X, vButton.Position.Y + vButton.Bound.Height);            
        }
        
    }
}
