using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyXNA
{
    abstract class DrawClass
    {

        public abstract void Draw(SpriteBatch spriteBatch, GameTime time);
    }
}
