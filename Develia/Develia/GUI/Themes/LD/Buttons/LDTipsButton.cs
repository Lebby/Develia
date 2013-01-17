using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeveliaGameEngine;
using Microsoft.Xna.Framework.Graphics;
using System.IO;

namespace Develia.GUI.Themes.LD.Buttons
{
    public class LDTipsButton : LDCommandButton
    {
        protected override void LoadContent()
        {
            base.LoadContent();
            this.BackgroundImage = Game.Content.Load<Texture2D>("Buttons\\i");            
            Label.Text = "Tips";
        }   
    }
}
