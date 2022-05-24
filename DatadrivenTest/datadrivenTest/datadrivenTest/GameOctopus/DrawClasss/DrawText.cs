using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace datadrivenTest.GameOctopus.DrawClasss
{
    class DrawText:My.BoneMatrix
    {
        public const float FONT_SIZE = 12f;

        ContentManager content;

        SpriteFont font;

        Vector3 position;

        public DrawText(ContentManager content, My.BoneMatrix parent, Vector3 pos):base(parent)
        {
            LocalMatrix = My.Matrix4x4.CreateTrancerate(MyXNA.ChangeXNA.Change(pos));

            this.content = content;

            font = content.Load<SpriteFont>("Fonts/TestFont");
        }
        public void Draw(SpriteBatch spriteBatch, string text)
        {
            spriteBatch.DrawString(font, text, MyXNA.ChangeXNA.Change(Matrix.Translation.xy), Color.Black);
        }
    }
}
