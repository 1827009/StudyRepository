using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyXNA
{
    class DrawCurveLine:DrawClass
    {
        const float FINENESS = 100;

        Vector2 start = Vector2.Zero;

        Color color;
        List<DrawLine> lines=new List<DrawLine>();

        public float installationWeit=0;

        public DrawCurveLine(Color color)
        {
            this.color = color;
        }

        public void Update(Vector2 goal)
        {
            lines.Add(new DrawLine(start, goal, color));
            start = goal;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime time)
        {
            foreach (var item in lines)
            {
                item.Draw(spriteBatch, time);
            }
        }
    }
}
