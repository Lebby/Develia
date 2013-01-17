using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Develia.GUI.Screens;
using DeveliaGameEngine;
using Microsoft.Xna.Framework;
using Develia.GUI.Themes.LD.Buttons;
using DeveliaGameEngine.Layouts;
using Develia.GUI.Themes.LD.Panels;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace Develia.GUI.Themes.LD.Screens
{
    public class LDQuizScreen       : QuizScreen
    {
        private LDQuestionInfoPanel QuestionInfoPanel;
        private LDQuizInfoPanel     QuizInfoPanel;
        private LDCommandPanel      CommandPanel;
        private LDNavButton         Prev, Next; 

        //quiz panel is inside QuizScreen

        public LDQuizScreen()
        {
            AutoBound = false;            

            //move this to factory
            QuizBlock               =   new LDQuizBlock();
            QuestionInfoPanel       =   new LDQuestionInfoPanel();
            QuizInfoPanel           =   new LDQuizInfoPanel();
            CommandPanel            =   new LDCommandPanel();

            Prev = new LDNavButton();
            Next = new LDNavButton();            
            Prev.Label.Text = "Precedente";
            Next.Label.Text = "Successivo";
            Layout = new RelativePositionLayout();            
        }

        public override void Arrange()
        {
            base.Arrange();
            ((RelativePositionLayout)Layout).
                Arrange(Prev, LDTheme.QuizBlockBound, (int)RelativePosition.BORDER_LEFT_CENTER_LEFT);
            ((RelativePositionLayout)Layout).
                Arrange(Next, LDTheme.QuizBlockBound, (int)RelativePosition.BORDER_RIGHT_CENTER_RIGHT);
            
            Prev.Position       = new Vector2(Prev.Position.X-5, Prev.Position.Y - 50);
            Prev.Label.Position = new Vector2(200, Prev.Label.Position.Y);
            Next.Position       = new Vector2(Next.Position.X+5, Next.Position.Y - 50);
                        
            StackTrace st = new StackTrace(1);
            String lastCaller = st.ToString();
            string[] seq;
            seq = lastCaller.Split('\n');
            seq[0].Replace("\n", "");
            seq[1].Replace("\n", "");
            Console.Write(seq[0]);
            Console.Write(seq[1]);
            
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            BackgroundImage = Game.Content.Load<Texture2D>("Images\\LDQuizScreenBg");
            Prev.BackgroundImage = Game.Content.Load<Texture2D>("Buttons\\nav_left");
            Next.BackgroundImage = Game.Content.Load<Texture2D>("Buttons\\nav_right");            
            RectangleSource      = LDTheme.DeveliaBaseScreen;
            
            addComponent(QuizInfoPanel);
            addComponent(QuestionInfoPanel);
            addComponent(CommandPanel);
            addComponent(Prev);
            addComponent(Next);            
        }

        public override void OnLoad()
        {
            base.OnLoad();
            ForceArrange();
            
        }
    }
}
