using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace DeveliaGameEngine
{
    public class Object2D : DrawableGameComponent
    {
        private SpriteBatch     _spriteBatch;
        private SpriteEffects   _effects;
        private DrawMode        _drawMode = null;

        private Color           _color;
        
        private Texture2D       _texture;
        
        
        private Vector2         _origin;
        private Vector2         _scale;
        private Rectangle       _bound;
        private Rectangle?      _rectangleSource;
        private float           _rotation;
        
        private float           _layerDepth;

        private bool            _isToUpdate;

        public Vector2          Position { get  { return new Vector2(Bound.X, Bound.Y); }
                                           set  { _bound = new Rectangle((int)value.X, (int)value.Y,_bound.Width, _bound.Height ); }}
        
        public Vector2          Origin   { get  { return    _origin;}       
                                           set  { _origin   = value;}}
        
        public Vector2          Scale    { get  { return    _scale;}
                                           set  { _scale    = value; _isToUpdate = true;}}

        public bool             AutoBound = true;
        
        public Rectangle        Bound    { get  { return    _bound;} 
                                           set  { _bound    = value; isBoundToUpdate = false;}}

        public Rectangle?       RectangleSource 
                                         { get { return     _rectangleSource; }
                                           set { _rectangleSource = value; }
                                         }

        
        public float            Rotation { get { return    _rotation;}
                                           set { _rotation = value; _isToUpdate = true;}}
        
        public float            LayerDepth
                                         { get { return    _layerDepth;}     
                                           set { _layerDepth = value;}}
        
        public Color            TintColor{ get { return    _color;} 
                                           set { _color     = value;}}
        
        public SpriteEffects    Effects  { get { return    _effects;} 
                                           set { _effects  = value;}}
        
        
        public DrawMode         DrawMode { get { return     _drawMode;} 
                                           set { _drawMode  = value;}}

        public Texture2D BackgroundImage { get { return     _texture;} 
                                           set { _texture   = value; _isToUpdate = true; }}

        public bool      IsToUpdate      { get { return     _isToUpdate||isBoundToUpdate; }
                                           set { _isToUpdate = value;                    }}

        public bool      ManualDepth       = false;

        public bool      isLoaded          = false;

        public bool      isBoundToUpdate   = false;

        public Object2D()
            : base(Engine.Instance.Game) 
        {
            //_spriteBatch     = new SpriteBatch(Engine.Instance.GraphicsDeviceManager.GraphicsDevice);            
            _spriteBatch     = Engine.Instance.SpriteBatch;
            _origin          = Vector2.Zero;
            _scale           = Vector2.One;
            _rotation        = 0f;
            _color           = Color.White;
            _rectangleSource = null;
            VisibleChanged += new EventHandler<EventArgs>(this._changeVisibility);
        }

        void _changeVisibility(Object sender, EventArgs args)
        {
            Object2D tmp = null;
            if (sender is Object2D) tmp = (Object2D)sender;
            else return;
            if ((tmp.Visible == false ) && (this.Visible == true )) OnShow();
            if ((tmp.Visible == true ) && (this.Visible == false )) OnHide();
        }
        
        public override void Initialize()
        {            
            base.Initialize();
            IsToUpdate = true;
        }

        protected override void LoadContent()
        {
            if (isLoaded) return;
            base.LoadContent();            
            OnLoad();
            isLoaded = true;
        }

        protected override void UnloadContent()
        {
            if (!isLoaded) return;
            base.UnloadContent();
            OnUnload();
            isLoaded = false;
        }

        public virtual bool Contains(float x, float y)
        {
            return Bound.Contains((int)x, (int)y);
        }
        
        public SpriteBatch SpriteBatch { get { return _spriteBatch; } set { _spriteBatch = value; } }

        public override void Draw(GameTime gameTime)
        {
            if (!isLoaded) return;
            base.Draw(gameTime);           

            if (SpriteBatch == null)
            {
                SpriteBatch = Engine.Instance.SpriteBatch;
            }
            else if (_drawMode == null)
            {                
                SpriteBatch.Begin();                
            }
            else
            {
                SpriteBatch.Begin(
                DrawMode.SortMode,
                DrawMode.BlendState,
                DrawMode.SamplerState,
                DrawMode.DepthStencilState,
                DrawMode.RasterizerState,
                DrawMode.Effect,
                DrawMode.TransformMatrix);
            }            
            Draw();
            SpriteBatch.End();
        }

        public virtual void Draw()
        {
            if(_texture!=null)
            SpriteBatch.Draw(
                _texture, 
                Position,
                _rectangleSource, 
                _color, 
                _rotation, 
                _origin, 
                _scale, 
                _effects, 
                _layerDepth);            
        }

        public virtual Rectangle CalculateBound()
        {
            if (!AutoBound) return Bound;
            if (_texture == null) return default(Rectangle);
            
            return new Rectangle(
                (int)Position.X, 
                (int)Position.Y, 
                _texture.Bounds.Width, 
                _texture.Bounds.Height);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (_isToUpdate)
            {
                if (AutoBound) Bound = CalculateBound();
                _isToUpdate = false;
            }
        }

        public virtual void Redraw()
        {
            if (SpriteBatch == null)
            {
                SpriteBatch = Engine.Instance.SpriteBatch;
            }
            else if (_drawMode == null)
            {
                SpriteBatch.Begin();
            }
            Draw();
            SpriteBatch.End();
        }
        
        public void ForceLoad()
        {
            LoadContent();
            IsToUpdate = true;
        }

        public void ForceUnload()
        {
            UnloadContent();
        }

        public virtual void OnLoad() { }
        public virtual void OnUnload() { }
        public virtual void OnShow() { }
        public virtual void OnHide() { }

    }
}
