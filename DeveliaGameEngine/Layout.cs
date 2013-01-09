using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace DeveliaGameEngine
{
    public interface Layout
    {
        void Arrange(List<Object2D> objectList, Rectangle container);
        //void Arrange(Object2D objectToPosition, Rectangle container);
        //void Arrange(List<Object2D> objectList, Rectangle container, int typeOfLayout);
        //void Arrange(Object2D objectToPosition, Rectangle container, int typeOfLayout);
    }
}
