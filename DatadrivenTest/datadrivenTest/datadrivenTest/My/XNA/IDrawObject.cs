using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyXNA
{
    interface IDrawSprite
    {
        public abstract void Draw(SpriteBatch spriteBatch, GameTime time);
    }
    interface IDrawModel
    {
        public abstract void Draw(GraphicsDevice graphics, GameTime time);
    }
}
