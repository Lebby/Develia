using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DeveliaGameEngine
{
    public class Object2D : DrawableGameComponent
    {
        private SpriteBatch _spriteBatch;
        private SpriteEffects _effects;
        private DrawMode _drawMode = null;

        private Color _color;
        
        private Texture2D _texture;
        
        private Vector2 _position;
        private Vector2 _origin;
        private Vector2 _scale;
        private Rectangle _bound;
        private float _rotation;

        private float _layerDepth;

        public Vector2 Position { get { return _position; } set { _position = value; Bound = CalculateBound(); } }
        public Vector2 Origin{ get{ return _origin;} set{ _origin= value;} }
        public Vector2 Scale { get { return _scale; } set { _scale = value; Bound = CalculateBound(); } }
        public Rectangle Bound{ get{ return _bound; } set{ _bound= value;} }
        public float Rotation { get { return _rotation; } set { _rotation = value; Bound = CalculateBound(); } }
        public float LayerDepth{ get{ return _layerDepth;}     set{_layerDepth = value;} }
        public Color TintColor{ get{ return _color;} set{_color = value;} }
        public SpriteEffects Effects { get { return _effects; } set { _effects = value; Bound = CalculateBound(); } }
        
        
        public DrawMode DrawMode { get { return _drawMode; } set { _drawMode=value; }}

        public Texture2D BackgroundImage { get { return _texture; } set { _texture = value; Bound = CalculateBound(); } }

        public Object2D()
            : base(Engine.Instance.Game) 
        {
            _spriteBatch = Engine.Instance.SpriteBatch;
            _position = Vector2.Zero;
            _origin=Vector2.Zero;
            _scale=Vector2.One;
            _rotation = 0f;
            _color = Color.White;
        }

        public override void Initialize()
        {            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            _texture = new Texture2D(GraphicsDevice, 100, 100);
        }

        public virtual bool Contains(float x, float y)
        {
            return Bound.Contains((int)x, (int)y);
        }
        
        public SpriteBatch SpriteBatch { get { return _spriteBatch; } set { _spriteBatch = value; } }

        public override void Draw(GameTime gameTime)
        {
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
            SpriteBatch.Draw(_texture, _position, _bound, _color, _rotation, _origin, _scale, _effects, _layerDepth);
        }

        public virtual Rectangle CalculateBound()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, _texture.Bounds.Width, _texture.Bounds.Height);
        }

        public virtual void OnLoad() { }
        public virtual void OnUnload() { }
        public virtual void OnShow() { }
        public virtual void OnHide() { }
    }
}
