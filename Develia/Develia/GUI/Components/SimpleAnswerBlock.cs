using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Develia.GUI.Components
{
    public class SimpleAnswerBlock : AnswerBlock
    {
        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);
            foreach(AnswerWidget tmp in AnswerListWidget)
            {
                MouseState state = Mouse.GetState(); 
                if (tmp.Contains(state.X,state.Y))
                {
                    tmp.Scale = Vector2.One * 2;
                    tmp.TintColor = Color.Red;
                }
                else
                {
                    tmp.Scale = Vector2.One;
                    tmp.TintColor = DeveliaTheme.AnswerFontColor;
                }
            }
        }

        public override void OnLoad()
        {
            base.OnLoad();
            float vpos=this.Position.Y;
            foreach (AnswerWidget tmp in AnswerListWidget)
            {
                tmp.Position = new Vector2(tmp.Position.X, vpos);
                vpos = tmp.Bound.Height;
            }
        }
    }
}
