using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace datadrivenTest.GameOctopus.DrawClasss
{
    /// <summary>
    /// Texture2Dの記述量を減らすためだけのクラス
    /// </summary>
    class DrawTexture:My.BoneMatrix
    {
        public Texture2D texture = null;

        public DrawTexture(string fileName, ContentManager content)
        {
            this.texture = content.Load<Texture2D>(fileName);
        }
        public DrawTexture(string fileName, My.BoneMatrix root, Vector3 pos, ContentManager content):base(root)
        {
            this.texture = content.Load<Texture2D>(fileName);
            LocalMatrix = My.Matrix4x4.CreateTrancerate(MyXNA.ChangeXNA.Change(pos));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, MyXNA.ChangeXNA.Change(Matrix.Translation.xy), Color.White);
        }
        public void Draw(Vector3 position, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, new Vector2(position.X, position.Y), Color.White);
        }
        public void Draw(Vector2 position, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, position, Color.White);
        }
    }
}
