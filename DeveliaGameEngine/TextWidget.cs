using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace DeveliaGameEngine
{
    public class TextWidget : Object2D
    {
        private String _text;
        private SpriteFont _font;        
        

        public SpriteFont Font { get { return _font; } set { _font = value; } }
        public String Text{ get{return _text;}
            set { 
                _text = value;
                Bound = CalculateBound();
            } 
        }

        
        public TextWidget(SpriteFont font)
        {
            _font = font;
            _text = "";
        }

        public TextWidget(SpriteFont font, string text)
        {
            _font = font;
            _text = text;
        }        

        public override void  Draw()
        {            
            SpriteBatch.DrawString(
                Font,Text,Position,TintColor,Rotation,Origin,Scale,Effects,LayerDepth);            
        }

        public override Rectangle CalculateBound()
        {
            if ((_font != null) &&(_text != null))
                return new Rectangle((int)Position.X, (int)Position.Y, (int)_font.MeasureString(_text).X, (int)_font.MeasureString(_text).Y);
            else return new Rectangle((int)Position.X, (int)Position.Y,1,1);
        }
    }
}
