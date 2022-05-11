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
        ContentManager content;
        SpriteBatch spriteBatch;

        SpriteFont font;

        public DrawText(ContentManager content, SpriteBatch spriteBatch)
        {
            this.content = content;
            this.spriteBatch = spriteBatch;

            font = content.Load<SpriteFont>("Fonts/TestFont");
        }
        public void Draw(string text, Vector2 pos)
        {
            spriteBatch.DrawString(font, text, pos, Color.Black);
        }
    }
}
