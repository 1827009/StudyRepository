using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MyXNA;

namespace CalculationTest.SampleGames
{
    class SampleGame3 : SampleGame
    {
        const float TIME_LINE = 6;

        List<DrawClass> drawClasses = new List<DrawClass>();

        DrawCircle start = new DrawCircle();
        DrawCircle point1 = new DrawCircle();
        DrawCircle point2 = new DrawCircle();
        DrawCircle point3 = new DrawCircle();
        DrawCircle point4 = new DrawCircle();
        DrawCircle end = new DrawCircle();

        DrawCircle circle1 = new DrawCircle();

        DrawCurveLine curve;

        float timeLine = 0;

        public SampleGame3()
        {
            start.position = new Vector2(0, Game1.WINDOW_SIZE_X * 0.5f);

            point1.position = new Vector2(Game1.WINDOW_SIZE_X * 0.2f, Game1.WINDOW_SIZE_Y * 0.6f);
            point2.position = new Vector2(Game1.WINDOW_SIZE_X * 0.4f, Game1.WINDOW_SIZE_Y * 0.4f);
            point3.position = new Vector2(Game1.WINDOW_SIZE_X * 0.6f, Game1.WINDOW_SIZE_Y * 0.8f);
            point4.position = new Vector2(Game1.WINDOW_SIZE_X * 0.8f, Game1.WINDOW_SIZE_Y * 0.2f);

            end.position = new Vector2(Game1.WINDOW_SIZE_X, Game1.WINDOW_SIZE_X * 0.5f);
            curve = new DrawCurveLine(Color.Green);

            drawClasses.Add(start);
            drawClasses.Add(point1);
            drawClasses.Add(point2);
            drawClasses.Add(point3);
            drawClasses.Add(point4);
            drawClasses.Add(end);
            drawClasses.Add(circle1);
            drawClasses.Add(curve);
        }

        public override void Update(GameTime time)
        {  
            circle1.position = ChangeXNA.Change(My.Vector2.Lerp(ChangeXNA.Change(start.position), ChangeXNA.Change(end.position), timeLine));
            float a = My.SplineLerp.Spline(Game1.WINDOW_SIZE_Y * timeLine, ChangeXNA.Change(start.position), ChangeXNA.Change(point1.position), ChangeXNA.Change(point2.position), ChangeXNA.Change(point3.position), ChangeXNA.Change(point4.position), ChangeXNA.Change(end.position));
            circle1.position.Y = a;
            circle1.position.X = My.SplineLerp.Spline(a, ChangeXNA.Change(start.position), ChangeXNA.Change(point1.position), ChangeXNA.Change(point2.position), ChangeXNA.Change(point3.position), ChangeXNA.Change(point4.position), ChangeXNA.Change(end.position)); ;
            curve.Update(circle1.position);
            if (timeLine < 1)
                timeLine += (float)time.ElapsedGameTime.TotalSeconds / TIME_LINE;
            else
                timeLine = 1;
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
