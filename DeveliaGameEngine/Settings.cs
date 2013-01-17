using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace DeveliaGameEngine
{
    public class DefaultEngineSettings
    {
        public static bool      Display_FullScreen              = false;
        public static Vector2   Display_Default_Resolution;
        public static float     Engine_Layer_Layer_Depth_Start  = .0001f;
        public static float     Engine_Layer_Layer_Depth_Step   = .0001f;
        public static float     Engine_Layer_Object_Depth_Step  = .0000001f;
        
    }
}
