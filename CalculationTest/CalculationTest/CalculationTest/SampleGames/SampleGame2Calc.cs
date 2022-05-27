using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MyXNA;

namespace CalculationTest.SampleGames
{
    class SampleGame2Calc : SampleGame
    {
        const float TIME_LINE = 5;

        List<IDrawSprite> drawClasses = new List<IDrawSprite>();

        DrawCircle start = new DrawCircle();
        DrawCircle end = new DrawCircle();
        DrawCircle brend = new DrawCircle();

        DrawCircle circle1 = new DrawCircle();

        DrawCurveLine curve;

        float timeLine = 0;

        public SampleGame2Calc()
        {
            start.position = Vector2.Zero;
            end.position = new Vector2(Game1.WINDOW_SIZE_X, Game1.WINDOW_SIZE_Y);
            brend.position = new Vector2(0, Game1.WINDOW_SIZE_Y);
            curve = new DrawCurveLine(Color.Green);

            drawClasses.Add(start);
            drawClasses.Add(end);
            drawClasses.Add(brend);
            drawClasses.Add(circle1);
            drawClasses.Add(curve);
        }

        public override void Update(GameTime time)
        {
            circle1.position = ChangeXNA.Change(My.Vector2.BrendLerp(ChangeXNA.Change(start.position), ChangeXNA.Change(end.position), ChangeXNA.Change(brend.position), timeLine));

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
