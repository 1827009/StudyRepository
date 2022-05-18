using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace datadrivenTest.GameOctopus.DrawClasss
{
    class DrawText
    {
        public const float FONT_SIZE = 12f;

        ContentManager content;

        SpriteFont font;

        Vector2 position;

        public DrawText(ContentManager content, Vector2 pos)
        {
            this.content = content;

            font = content.Load<SpriteFont>("Fonts/TestFont");

            position = pos;
        }
        public void Draw(SpriteBatch spriteBatch, string text)
        {
            spriteBatch.DrawString(font, text, position, Color.Black);
        }
    }
}
