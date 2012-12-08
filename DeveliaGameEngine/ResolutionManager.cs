using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace DeveliaGameEngine
{
    public class ResolutionManager
    {
        private float resizeRateX;
        private List<Vector2> _availableDisplayMode;
        private Vector3 _screenScalingFactor;
        private Vector2 _defautScreenSize;
        private Vector2 _choosedScreenSize;
        
        public bool FullScreen
        {
            get
            {
                return Engine.Instance.GraphicsDeviceManager.IsFullScreen;
            }
            set
            {
                Engine.Instance.GraphicsDeviceManager.IsFullScreen = value;
                Engine.Instance.GraphicsDeviceManager.ApplyChanges();
            }
        }

        public Vector2 DefaultScreenSize
        {
            get
            {
                return _defautScreenSize;
            }
            set
            {
                _defautScreenSize = value;
            }
        }

        public Vector2 ScreenSize
        {
            get
            {
                return _choosedScreenSize;
            }
            set
            {
                _choosedScreenSize = value;
                //setting size of screen

                GraphicsDeviceManager gd = Engine.Instance.GraphicsDeviceManager;
                /*
                gd.Viewport.Height = (int)value.Y;
                gd.Viewport.Width = (int)value.X;*/
                gd.PreferredBackBufferHeight = (int)value.Y;
                gd.PreferredBackBufferWidth = (int)value.X;
                gd.ApplyChanges();
            }
        }
        
        public List<Vector2> AvailableDisplayMode { get { return _availableDisplayMode; } }

        public ResolutionManager()
        {
            _availableDisplayMode = new List<Vector2>();
            foreach (DisplayMode mode in GraphicsAdapter.DefaultAdapter.SupportedDisplayModes)
            {
                _availableDisplayMode.Add(new Vector2(mode.Width, mode.Height));
            }
            _choosedScreenSize = new Vector2(800,600);
            _defautScreenSize = new Vector2(800, 600);
        }

        public Vector2 CurrentDisplayMode()
        {
            int height = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            int width = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            return new Vector2(width, height);
        }



        public Vector3 ScreenScalingFactor{ 
            get { 
                //float horScaling = (float)device.PresentationParameters.BackBufferWidth / DefaultScreenSize.X;
                //float verScaling = (float)device.PresentationParameters.BackBufferHeight / DefaultScreenSize.Y;
                float horScaling = (float)CurrentDisplayMode().X / DefaultScreenSize.X;
                float verScaling = (float)CurrentDisplayMode().Y / DefaultScreenSize.Y;

                _screenScalingFactor = new Vector3(horScaling, verScaling, 1);
                /*else
                {
                    screenScalingFactor = new Vector3(1, 1, 1);
                }*/
                Matrix globalTransformation = Matrix.CreateScale(_screenScalingFactor);
                return _screenScalingFactor;
            }
        }

        /*GraphicsDevice graphics = ScreenManager.GraphicsDevice;
            
            gd.PreferredBackBufferHeight = height;
            gd.PreferredBackBufferWidth = width;
            GraphicsDevice.ApplyChanges();
            if (!GraphicsDevice.IsFullScreen)
                GraphicsDevice.ToggleFullScreen();*/        
        
    }
}

