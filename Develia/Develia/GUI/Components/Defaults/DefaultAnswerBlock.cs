using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeveliaGameEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Develia.GUI.Components.Defaults
{
    /// <summary>
    ///  This class performs an important function.
    /// </summary>
    class DefaultAnswerBlock : AnswerBlock
    {
        private MouseState mouseState;
        private ButtonState buttonState;


        public AbstractEffect OnLoadEffect;


        /// <summary>
        ///  This class performs an important function.
        /// </summary>
        public DefaultAnswerBlock() : base()
        {
            OnLoadEffect = new EffectShow(this);
            Layout = new DefaultLayout();
        }

        /// <summary>
        ///  This class performs an important function.
        /// </summary>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            mouseState = Mouse.GetState();
            buttonState = mouseState.LeftButton;
                        
            if (Contains(mouseState.X, mouseState.Y))
            {
                foreach (AnswerWidget tmp in AnswerListWidget)
                {
                    if (tmp.Contains(mouseState.X, mouseState.Y))
                    {
                        this.Scale = new Vector2(2, 1);
                        this.TintColor = Color.Red;
                        if ((buttonState == ButtonState.Pressed))
                        {
                            //Engine.Instance.ResolutionManager.ScreenSize = new Vector2(Width, Height);
                        }
                        else
                        {
                            this.Scale = new Vector2(1, 1);
                            this.TintColor = Color.Yellow;
                        }
                    }
                }
            }
        }

        /// <summary>
        ///  This class performs an important function.
        /// </summary>
        public override void OnLoad()
        {
            base.OnLoad();
            OnLoadEffect = new EffectShow(this);
            //if (OnLoadEffect.Thread.IsAlive) OnLoadEffect.Thread.Abort();
            Console.WriteLine(OnLoadEffect.Thread.ThreadState);
            OnLoadEffect.Thread.Start();
        }

        

    }
}
