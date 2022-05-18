using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace datadrivenTest.GameOctopus.DrawClasss
{
    class DrawTexture
    {
        Texture2D texture = null;
        public Vector2 position;

        public DrawTexture(string fileName, Vector2 pos, ContentManager content)
        {
            this.texture = content.Load<Texture2D>(fileName);
            this.position = pos;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, position, Color.White);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 loaclPos)
        {
            spriteBatch.Draw(this.texture, position+loaclPos, Color.White);
        }
    }
}
