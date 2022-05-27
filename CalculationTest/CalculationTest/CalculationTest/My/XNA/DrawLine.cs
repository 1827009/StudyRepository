using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using C3.MonoGame;

namespace MyXNA
{
    class DrawLine:IDrawSprite
    {
        public Vector2 startPosition;
        public Vector2 endPosition;
        public Color color = Color.White;

        public DrawLine(Vector2 start, Vector2 end)
        {
            this.startPosition = start;
            this.endPosition = end;
        }
        public DrawLine(Vector2 start, Vector2 end, Color color)
        {
            this.startPosition = start;
            this.endPosition = end;
            this.color = color;
        }
        public void Draw(SpriteBatch spriteBatch, GameTime time)
        {
            spriteBatch.DrawLine(startPosition, endPosition, color);
        }
    }
}
