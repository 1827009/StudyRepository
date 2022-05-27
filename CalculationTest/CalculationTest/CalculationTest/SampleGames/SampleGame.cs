using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CalculationTest
{
    abstract class SampleGame
    {


        abstract public void Update(GameTime time);
        public virtual void Draw(SpriteBatch spriteBatch, GameTime time) { }
        public virtual void Draw(GraphicsDevice graphics, GameTime time) { }
    }
}