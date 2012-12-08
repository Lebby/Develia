using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace DeveliaGameEngine
{
    public class DrawMode
    {
        private SpriteSortMode _sortMode = SpriteSortMode.BackToFront;
        private BlendState _blendState = null;
        private SamplerState _samplerState = null;
        private RasterizerState _rasterizerState = null;
        private Effect _effect = null;
        private Matrix _transformMatrix = Matrix.Identity;
        private DepthStencilState _depthStencilState;

        public SpriteSortMode SortMode { get { return _sortMode; } set { _sortMode = value; } }
        public BlendState BlendState { get { return _blendState; } set { _blendState = value; } }
        public SamplerState SamplerState { get { return _samplerState; } set { _samplerState = value; } }
        public RasterizerState RasterizerState { get { return _rasterizerState; } set { _rasterizerState = value; } }
        public Effect Effect { get { return _effect; } set { _effect = value; } }
        public Matrix TransformMatrix { get { return _transformMatrix; } set { _transformMatrix = value; } }
        public DepthStencilState DepthStencilState { get { return _depthStencilState; } set { _depthStencilState = value; } }

    }
}
