using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace DeveliaGameEngine
{
    /// <summary>
    /// 
    /// </summary>
    public class Engine : Microsoft.Xna.Framework.GameComponent
    {        
        private static Engine instance;

        Screen _currentScreen = null;
       
        private DrawMode _drawMode = new DrawMode();
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private ResolutionManager _resolutionManager;
        private Library _library;
        

        public Library Library
        {
            get
            {
                return instance._library; ;
            }
        }

        public DrawMode DefaultDrawMode { get { return _drawMode; } }
        
        private Engine(Game game)
            : base(game)
        {
            _graphics = new GraphicsDeviceManager(game);
            _library = Library.Instance;
            _resolutionManager = new ResolutionManager();
            
            // Set Graphic Profile to minimum requirements
            _graphics.GraphicsProfile = GraphicsProfile.Reach;
            _graphics.ApplyChanges();
        }

        public GraphicsDeviceManager GraphicsDeviceManager
        {
            get
            {
                return instance._graphics;
            }
        }

        public ResolutionManager ResolutionManager
        {
            get
            {
                return instance._resolutionManager;
            }
        }
      


        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {            
            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            /*if (instance._spriteBatch == null)
            {                
                instance._spriteBatch = new SpriteBatch(instance.Game.GraphicsDevice);                
            }*/
            
        }

        

        //public static Game Game { get { return instance.Game; }  }
        public static Engine Instance { get { return instance; } }


        public SpriteBatch SpriteBatch { 
            get 
            {
                if (instance._spriteBatch == null)
                {
                    instance._spriteBatch = new SpriteBatch(instance.Game.GraphicsDevice);
                }
                return _spriteBatch; 
            } 
        }
        

        public static void init(Game game)
        {
            if ((instance == null) && ( game != null ))
            {
                instance = new Engine(game);                
            }            
        }


        public void loadScreen(Screen screen)
        {            
            System.Diagnostics.Debug.WriteLine("CurrentScreen On Load " + screen.ID); //stampa di prova
            System.Diagnostics.Debug.WriteLine("Components " + Game.Components.Count); //stampa di prova
            if (_currentScreen != null)
            {
                _currentScreen.OnUnload();                
                Unload(_currentScreen);
                Hide(_currentScreen);
                System.Diagnostics.Debug.WriteLine("CurrentScreen On UnLoad " + _currentScreen.ID); //stampa di prova                
            }            
            _currentScreen = screen;
            Load(screen);
            Show(screen);
        }

        public void Load(Layer layer)
        {
            layer.OnLoad();
            Game.Components.Add(layer);
            layer.ForceLoad();
                
            
            /*
            foreach (Object2D tmp in layer.ObjectList)
            {
                Game.Components.Add(tmp);
            }*/
            layer.Enabled = true;
        }        

        public void Show(Layer layer)
        {
            layer.OnShow();
            layer.Visible = true;
            foreach (Object2D tmp in layer.ObjectList)
            {
                //Game.Components.Add(tmp);                
                tmp.Visible = true;
                tmp.OnShow();
            }            
        }        

        public void Hide(Layer layer)
        {            
            foreach (Object2D tmp in layer.ObjectList)
            {
                tmp.OnHide();
                tmp.Visible = false;                
                //Game.Components.Remove(tmp);
            }
            layer.OnHide();
            layer.Visible = false;
        }

        public void Unload(Layer layer)
        {
            layer.OnUnload();
            Game.Components.Remove(layer);
            layer.ForceUnload();

            
            /*
            foreach (Object2D tmp in layer.ObjectList)
            {
                Game.Components.Remove(tmp);
            }*/
            layer.Enabled = false;
        }



        public static Dictionary<String, Texture> LoadContent(ContentManager contentManager, string contentFolder)
        {
            //Load directory info, abort if none
            DirectoryInfo dir = new DirectoryInfo(contentManager.RootDirectory + "\\" + contentFolder);
            System.Diagnostics.Debug.WriteLine(dir.FullName);
            if (!dir.Exists)
                throw new DirectoryNotFoundException();
            //Init the resulting list
            Dictionary<String, Texture> result = new Dictionary<String, Texture>();

            //Load all files that matches the file filter
            FileInfo[] files = dir.GetFiles("*.*");
            foreach (FileInfo file in files)
            {
                string key = Path.GetFileNameWithoutExtension(file.Name);

                //result[key] = contentManager.Load<Texture>(contentManager.RootDirectory + "/" + contentFolder + "/" + key);
            }
            //Return the result
            return result;
        }
    }
}
