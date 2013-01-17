using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace DeveliaGameEngine.Layouts
{
    public enum RelativePosition
    {
        TOP_LEFT,       TOP_CENTER,     TOP_RIGHT,
        CENTER_LEFT,    MIDDLE,         CENTER_RIGHT, 
        BOTTOM_LEFT,    BOTTOM_CENTER,  BOTTOM_RIGHT,

        BORDER_LEFT_TOP_LEFT,
        BORDER_LEFT_CENTER_LEFT,
        BORDER_LEFT_BOTTOM_LEFT,
        BORDER_LEFT_TOP_CENTER,     BORDER_LEFT_CENTER_CENTER,  BORDER_LEFT_BOTTOM_CENTER,
        
        BORDER_RIGHT_TOP_RIGHT,
        BORDER_RIGHT_CENTER_RIGHT,
        BORDER_RIGHT_BOTTOM_RIGHT,
        BORDER_RIGHT_TOP_CENTER,    BORDER_RIGHT_CENTER_CENTER, BORDER_RIGHT_BOTTOM_CENTER, 
        
        BORDER_TOP_TOP_LEFT,        BORDER_TOP_TOP_CENTER,      BORDER_TOP_TOP_RIGHT,
        BORDER_TOP_CENTER_LEFT,     BORDER_TOP_CENTER_CENTER,   BORDER_TOP_CENTER_RIGHT,

        BORDER_BOTTOM_BOTTOM_LEFT,  BORDER_BOTTOM_BOTTOM_CENTER,BORDER_BOTTOM_BOTTOM_RIGHT,
        BORDER_BOTTOM_CENTER_LEFT,  BORDER_BOTTOM_CENTER_CENTER,BORDER_BOTTOM_CENTER_RIGHT

    }
    public class RelativePositionLayout : Layout
    {        
        public void  Arrange(List<Object2D> objectList, Microsoft.Xna.Framework.Rectangle container)
        {
            //throw new NotImplementedException();
        }
        

        public void Arrange(Object2D objectToPosition, Microsoft.Xna.Framework.Rectangle container)
        {
            throw new NotImplementedException();
        }

        public void Arrange(List<Object2D> objectList, Microsoft.Xna.Framework.Rectangle container, int typeOfLayout)
        {
            throw new NotImplementedException();
        }

        public void Arrange(Object2D objectToPosition, Microsoft.Xna.Framework.Rectangle container, int typeOfLayout)
        {
            Rectangle tmp = objectToPosition.Bound;
            switch ((RelativePosition)typeOfLayout)
            {
                case RelativePosition.TOP_LEFT:
                    tmp.Location= new Point(container.X,container.Y);
                    break;
                case RelativePosition.TOP_CENTER:
                    tmp.Location = new Point((int)midh(tmp, container), container.Y);
                    break;
                case RelativePosition.TOP_RIGHT:
                    tmp.Location = new Point((int)right(tmp,container), container.Y);
                    break;
                
                
                case RelativePosition.CENTER_LEFT:
                    tmp.Location = new Point(container.X, (int)midv(tmp, container));
                    break;
                case RelativePosition.MIDDLE:
                    tmp.Location = new Point((int)midh(tmp,container), (int)midv(tmp,container));
                    break;
                case RelativePosition.CENTER_RIGHT:
                    tmp.Location = new Point((int)right(tmp,container), (int)midv(tmp, container));
                    break;
                
                
                case RelativePosition.BOTTOM_LEFT:
                    tmp.Location = new Point(container.X, (int)bot(tmp,container));
                    break;
                case RelativePosition.BOTTOM_CENTER:
                    tmp.Location = new Point((int)midh(tmp, container), (int)bot(tmp,container));
                    break;
                case RelativePosition.BOTTOM_RIGHT: 
                    tmp.Location = new Point((int)right(tmp, container), (int)bot(tmp,container));
                    break;
                
                
                case RelativePosition.BORDER_LEFT_TOP_LEFT:
                    tmp.Location = new Point(container.X - tmp.Width,container.Y);
                    break;
                case RelativePosition.BORDER_LEFT_CENTER_LEFT:
                    tmp.Location = new Point(container.X - tmp.Width, (int)midv(tmp,container));
                    break;
                case RelativePosition.BORDER_LEFT_BOTTOM_LEFT:
                    tmp.Location = new Point(container.X - tmp.Width, (int)bot(tmp,container));
                    break;
                case RelativePosition.BORDER_LEFT_TOP_CENTER:
                    tmp.Location = new Point(container.X - tmp.Width/2, container.Y);
                    break;
                case RelativePosition.BORDER_LEFT_CENTER_CENTER:
                    tmp.Location = new Point(container.X - tmp.Width/2, (int)midv(tmp, container));
                    break;
                case RelativePosition.BORDER_LEFT_BOTTOM_CENTER:
                    tmp.Location = new Point(container.X - tmp.Width/2, (int)bot(tmp,container));
                    break;
                
                
                case RelativePosition.BORDER_RIGHT_TOP_RIGHT:
                    tmp.Location = new Point(container.X + container.Width, container.Y);
                    break;
                case RelativePosition.BORDER_RIGHT_CENTER_RIGHT:
                    tmp.Location = new Point(container.X + container.Width, (int)midv(tmp,container));
                    break;
                case RelativePosition.BORDER_RIGHT_BOTTOM_RIGHT:
                    tmp.Location = new Point(container.X + container.Width, (int)bot(tmp,container));
                    break;
                case RelativePosition.BORDER_RIGHT_TOP_CENTER:
                    tmp.Location = new Point(container.X + container.Width - tmp.Width/2, container.Y);
                    break;
                case RelativePosition.BORDER_RIGHT_CENTER_CENTER:
                    tmp.Location = new Point(container.X + container.Width - tmp.Width/2, (int)midv(tmp, container));
                    break;
                case RelativePosition.BORDER_RIGHT_BOTTOM_CENTER:
                    tmp.Location = new Point(container.X + container.Width - tmp.Width/2, (int)bot(tmp, container));
                    break;
                
                
                case RelativePosition.BORDER_TOP_TOP_LEFT:
                    tmp.Location = new Point(container.X , container.Y - tmp.Height);
                    break;
                case RelativePosition.BORDER_TOP_TOP_CENTER:
                    tmp.Location = new Point((int)midh(tmp,container) , container.Y - tmp.Height);
                    break;
                case RelativePosition.BORDER_TOP_TOP_RIGHT:
                    tmp.Location = new Point((int)right(tmp,container), container.Y - tmp.Height);
                    break;

                
                case RelativePosition.BORDER_TOP_CENTER_LEFT:
                    tmp.Location = new Point(container.X, container.Y - tmp.Height/2);
                    break;
                case RelativePosition.BORDER_TOP_CENTER_CENTER:
                    tmp.Location = new Point((int)midh(tmp, container), container.Y - tmp.Height/2);
                    break;
                case RelativePosition.BORDER_TOP_CENTER_RIGHT:
                    tmp.Location = new Point((int)right(tmp, container), container.Y - tmp.Height/2);
                    break;
                
                
                case RelativePosition.BORDER_BOTTOM_BOTTOM_LEFT:
                    tmp.Location = new Point(container.X,(int)bot(tmp,container)+tmp.Height);
                    break;
                case RelativePosition.BORDER_BOTTOM_BOTTOM_CENTER:
                    tmp.Location = new Point((int)midh(tmp,container), (int)bot(tmp, container) + tmp.Height);
                    break;
                case RelativePosition.BORDER_BOTTOM_BOTTOM_RIGHT:
                    tmp.Location = new Point((int)right(tmp,container), (int)bot(tmp, container) + tmp.Height);
                    break;


                case RelativePosition.BORDER_BOTTOM_CENTER_LEFT:
                    tmp.Location = new Point(container.X,(int)bot(tmp,container)+tmp.Height/2);
                    break;
                case RelativePosition.BORDER_BOTTOM_CENTER_CENTER:
                    tmp.Location = new Point((int)midh(tmp,container),(int)bot(tmp,container)+tmp.Height/2);
                    break;
                case RelativePosition.BORDER_BOTTOM_CENTER_RIGHT:
                    tmp.Location = new Point((int)right(tmp,container),(int)bot(tmp,container)+tmp.Height/2);
                    break;
                default: break;
            }
            objectToPosition.Bound = tmp;
        }

        private float midh(Rectangle toPosition, Rectangle container)
        {
            return container.X + (container.Width - toPosition.Width) / 2;            
        }

        private float midv(Rectangle toPosition, Rectangle container)
        {
            return container.Y + (container.Height - toPosition.Height) / 2;
        }

        private float bot(Rectangle toPosition,Rectangle container)
        {
            return container.Y + container.Height - toPosition.Height;
        }

        private float right(Rectangle toPosition, Rectangle container)
        {
            return container.X + container.Width - toPosition.Width;
        }        
    }   
}
