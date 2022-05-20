using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using MyXNA;

namespace CalculationTest.SampleGames
{
    class CalcuGame1:SampleGame
    {
        const float TIME_LINE = 5;

        List<DrawClass> drawClasses = new List<DrawClass>();

        DrawCircle start=new DrawCircle();
        DrawCircle end=new DrawCircle();

        DrawCircle circle1=new DrawCircle();

        DrawLine line1;

        float timeLine = 0;

        public CalcuGame1()
        {
            start.position = Vector2.Zero;
            end.position = new Vector2(Game1.WINDOW_SIZE_X, Game1.WINDOW_SIZE_Y);
            line1 = new DrawLine(start.position, circle1.position);

            drawClasses.Add(start);
            drawClasses.Add(end);
            drawClasses.Add(circle1);
            drawClasses.Add(line1);
        }

        public override void Update(GameTime time)
        {
            circle1.position =ChangeXNA.Change(My.Vector2.Lerp(ChangeXNA.Change(start.position), ChangeXNA.Change(end.position), timeLine));
            line1.endPosition = circle1.position;

            if (timeLine < 5)
                timeLine += (float)time.ElapsedGameTime.TotalSeconds/TIME_LINE;
            else
                timeLine = 5;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime time)
        {
            foreach (var item in drawClasses)
            {
                item.Draw(spriteBatch, time);
            }
        }
    }
}
