using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using datadrivenTest.GameOctopus.ObjectClasss;

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

            box = new DrawBox(Matrix.Identity, Matrix.Identity, Color.Brown, Vector2.One);
        }
        public void Update(Matrix parent)
        {
            matrix.Translation = new Vector3(DrawStage.BLOCK_SPACE * player.position, 0, 0);
            box.Update(parent * matrix);
        }

        public void Draw(GraphicsDevice graphics)
        {
            box.Draw(graphics);
        }
    }
}