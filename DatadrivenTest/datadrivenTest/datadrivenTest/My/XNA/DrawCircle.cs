using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using C3.MonoGame;

namespace MyXNA
{
    class DrawCircle : IDrawSprite
    {
        public Vector2 position = Vector2.Zero;
        public float radius = 5f;
        public int fineness = 50;
        public float lineSize = 1;
        public Color color = Color.White;

        public DrawCircle()
        {
        }
        public DrawCircle(Vector2 pos)
        {
            position = pos;
        }
        public DrawCircle(float radius)
        {
            this.radius = radius;
            this.lineSize = radius;
        }

        public void Draw(SpriteBatch spriteBatch, GameTime time)
        {
            spriteBatch.DrawCircle(position, radius, fineness, color, lineSize);
        }
    }
}