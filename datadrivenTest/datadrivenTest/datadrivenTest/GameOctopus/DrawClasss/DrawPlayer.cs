using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace datadrivenTest.GameOctopus.DrawClasss
{
    class DrawPlayer
    {
        Player player;

        DrawBox box;

        public Matrix matrix = Matrix.Identity;

        public DrawPlayer(Player player)
        {
            this.player = player;

            box = new DrawBox(Matrix.Identity, Matrix.Identity, Color.Red, Vector2.One);
        }
        public void Update(Matrix parent)
        {
            Matrix pos = Matrix.Identity;
            pos.Translation = new Vector3(DrawStage.BLOCK_SPACE * player.position, 0, 0);
            box.Update(parent * pos);
        }

        public void Draw(GraphicsDevice graphics)
        {
            box.Draw(graphics);
        }
    }
}