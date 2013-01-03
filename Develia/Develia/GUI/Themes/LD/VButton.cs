using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Develia.GUI.Themes.LD
{
    public class VButton : LDCommandButton
    {
        protected override void LoadContent()
        {
            base.LoadContent();
            this.BackgroundImage = Game.Content.Load<Texture2D>("Buttons\\v");
            CalculateBound();
        }
    }
}
