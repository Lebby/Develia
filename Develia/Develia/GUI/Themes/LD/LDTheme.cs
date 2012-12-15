using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Develia.GUI.Components;
using Microsoft.Xna.Framework;

namespace Develia.GUI.Themes.LD
{
    public class LDTheme : DeveliaTheme
    {
        // right panel
        public static Rectangle QuizInfoPanelBound      = new Rectangle(600 ,0      ,200    ,480); //ok
        // top panel
        public static Rectangle QuestionInfoPanelBound  = new Rectangle(0   ,0      ,600    ,50); //ok
        // Contains both question and answer
        public static Rectangle QuizBlockBound          = new Rectangle(50  ,50     ,500    ,430); //ok       
        // Question container
        public static Rectangle QuestionBlockBound      = new Rectangle(50  ,50     ,500    ,230);//ok
        // Answer container
        public static Rectangle AnswerBlockBound        = new Rectangle(50  ,280    ,500    ,200);//ok
        // Command panel : v,x,?
        public static Rectangle CommandPanelBound       = new Rectangle(550 ,250    ,50     ,230);//ok
        


    }
}
