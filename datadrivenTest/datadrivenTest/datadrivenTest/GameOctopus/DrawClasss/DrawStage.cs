using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace datadrivenTest.GameOctopus.DrawClasss
{
    class DrawStage
    {
        public static readonly float BLOCK_SPACE = 0.21f;

        Stage stage;

        DrawText text;
        DrawPlayer player;
        List<DrawTentacle> tentacles;

        public Matrix matrix=Matrix.Identity;

        public DrawStage(Stage stage, ContentManager content, SpriteBatch spriteBatch)
        {
            text = new DrawText(content, spriteBatch);

            matrix.Translation = new Vector3(-1 + DrawStage.BLOCK_SPACE, -0.5f, 0);

            player = new DrawPlayer(stage.player);

            this.stage = stage;
            tentacles = new List<DrawTentacle>(stage.tentacles.Count);
            for (int i = 0; i < stage.tentacles.Count; i++)
            {
                Matrix pos = Matrix.Identity;
                pos.Translation += new Vector3(BLOCK_SPACE * i, BLOCK_SPACE*5, 0);
                tentacles.Add(new DrawTentacle(pos, stage.tentacles[i]));
            }
        }

        public void Update(GameTime time)
        {
            stage.Update(time);

            player.Update(matrix);
            for (int i = 0; i < tentacles.Count; i++)
            {
                tentacles[i].Update(matrix);
            }

        }

        public void DrawUi()
        {
            text.Draw("STOCK " + stage.player.stock, Vector2.Zero);
            text.Draw("ITEM " + stage.player.totalItems, new Vector2(0, 12));

            if (stage.gameover)
                text.Draw("GAME OVER", new Vector2(0, 24));
        }

        public void Draw(GameTime time, GraphicsDevice graphics)
        {
            player.Draw(graphics);
            for (int i = 0; i < tentacles.Count; i++)
            {
                tentacles[i].Draw(stage.tentacles[i], graphics);
            }
        }
    }
}
