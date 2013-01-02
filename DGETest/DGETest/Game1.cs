using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using DeveliaGameEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Develia.GUI.Screens;
using Develia.GUI.Factories;
using Develia.GUI.Themes.LD;
using System.IO;




namespace DGETest
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        TestScreen test1;
        TestScreen test2;
        BackgroundScreen bgscreen;
        ResolutionScreen resscreen;
        ContentManager cm;
        QuizScreen quizScreen;
        LDQuizScreen ldscreen;

        private KeyboardState _currentKeyboardState;
        private KeyboardState _previousKeyboardState;

        String text = "";

        public Game1()
        {
            //GraphicsDeviceManager graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "DeveliaContent";
            ServiceContainer Services = new ServiceContainer();
            cm = new ContentManager(Services, "DeveliaContent");
            Engine.init(this);
            Engine.Instance.ResolutionManager.FullScreen = false;
            Engine.Instance.ResolutionManager.ScreenSize = new Vector2(800,480);
            string[] files = Directory.GetFiles(cm.RootDirectory+"");
            foreach (String tmp in files)
            {
                Console.WriteLine(tmp);
            }

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            test1 = new TestScreen();
            test2 = new TestScreen();
            bgscreen = new BackgroundScreen();
            resscreen = new ResolutionScreen();
            quizScreen = new QuizScreen();
            ldscreen = new LDQuizScreen();
            base.Initialize();
            TestQuestions tq = new TestQuestions();                     
            string tmp = "Supponendo che: \n int a = 2; int b = 3; float c = 4; double d = 5; int risI; int e = 2; double risD; \n" +
                "Qual è risultato dell’espressione seguente?\n" +
                "risD = d + c * b + a / b;";
            string[] answ = {"15","18,5","18"};
            int[] tmp1 = {0};
            /*quizScreen.QuizBlock.Quiz = tq.createSimpleQuiz(tmp, answ, tmp1);
            Console.WriteLine("init");
            quizScreen.addComponent(quizScreen.QuizBlock.QuestionBlock.QuestionWidget);
            quizScreen.addComponent(quizScreen.QuizBlock.AnswerBlock.AnswerListWidget[0]);*/
            quizScreen.QuizBlock = QuizFactory.Instance.CreateQuizBlock(tq.createSimpleQuiz(tmp, answ, tmp1));

        }


        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>p3
        protected override void LoadContent()
        {

            Dictionary<String, Texture> turi = Engine.LoadContent(Content, "");
            foreach (String tmp in turi.Keys)
            {
                System.Diagnostics.Debug.WriteLine(tmp);
            }
            foreach (String tmp in turi.Keys)
            {
                System.Diagnostics.Debug.WriteLine(tmp);
            }
            
            test1.Text = "Test1";
            test2.Text = "Test2";
            test1.ID = 1;
            test2.ID = 2;
            // Create a new SpriteBatch, which can be used to draw textures.
            //spriteBatch = new SpriteBatch(GraphicsDevice);
            

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            _currentKeyboardState = Keyboard.GetState();
            if (_previousKeyboardState != _currentKeyboardState)
            {
                if (_currentKeyboardState.GetPressedKeys().Length > 0)
                {
                    switch (_currentKeyboardState.GetPressedKeys()[0])
                    {
                        case Keys.A:
                            Engine.Instance.loadScreen(test1);
                            text = "Pressed A";
                            break;
                        case Keys.S:
                            Engine.Instance.loadScreen(test2);
                            text = "Pressed S";
                            break;
                        case Keys.D:
                            Engine.Instance.loadScreen(bgscreen);
                            text = "Pressed d";
                            break;
                        case Keys.F:
                            Engine.Instance.loadScreen(resscreen);
                            text = "Pressed F";
                            break;
                        case Keys.G:
                            Engine.Instance.loadScreen(quizScreen);
                            text = "Pressed G";
                            break;
                        case Keys.H:
                            Engine.Instance.loadScreen(ldscreen);
                            text = "Pressed H";
                            break;


                    }
                    text += " lenght " + _currentKeyboardState.GetPressedKeys().Length.ToString();
                    //test1.Text = text;
                    //test2.Text = text;
                    System.Diagnostics.Debug.WriteLine(text); //stampa di prova
                }
            }
            _previousKeyboardState = _currentKeyboardState;
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {           
            //GraphicsDevice.Clear(Color.CornflowerBlue);
            GraphicsDevice.Clear(Color.CornflowerBlue);
            base.Draw(gameTime);
            // TODO: Add your drawing code here            
        }
    }
}
