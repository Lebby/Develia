using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using DeveliaGameEngine;
using Microsoft.Xna.Framework;

namespace Develia.GUI.Components
{
    public class DeveliaTheme
    {
        public static SpriteFont QuestionFont = Engine.Instance.Game.Content.Load<SpriteFont>("Arial");
        public static SpriteFont AnswerFont = Engine.Instance.Game.Content.Load<SpriteFont>("Arial");
        public static SpriteFont MenuFont = Engine.Instance.Game.Content.Load<SpriteFont>("Arial");
        public static SpriteFont TipFont = Engine.Instance.Game.Content.Load<SpriteFont>("Arial");
        public static Color MenuFontColor = Color.Blue;
        public static Color QuestionFontColor = Color.Blue;
        public static Color AnswerFontColor = Color.Blue;
        public static Color TipFontColor = Color.Blue;
    }
}
