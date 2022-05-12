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
        delegate void Updates(Matrix matrix);
        Updates tentacleUpdates;

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
                DrawTentacle tentacle = new DrawTentacle(pos, stage.tentacles[i]);
                tentacles.Add(tentacle);
                tentacleUpdates += tentacle.Update;
            }
        }

        public void Update()
        {
            player.Update(matrix);
            tentacleUpdates(matrix);
        }

        public void DrawUi()
        {
            text.Draw("STAGE " + (stage.Id+1), new Vector2(0, DrawText.FONT_SIZE * 0));
            text.Draw("STOCK " + stage.player.stock, new Vector2(0, DrawText.FONT_SIZE * 1));
            text.Draw("ITEM " + stage.player.totalItems + "/" + stage.clearPoint, new Vector2(0, DrawText.FONT_SIZE * 2));

            if (stage.gameover)
                text.Draw("GAME OVER", new Vector2(0, DrawText.FONT_SIZE * 3));
            if (stage.GameClear)
                text.Draw("GAME CLEAR", new Vector2(0, DrawText.FONT_SIZE * 3));
        }

        public void Draw(GameTime time, GraphicsDevice graphics)
        {
            if (!stage.gameover)
            {
                player.Draw(graphics);
                for (int i = 0; i < tentacles.Count; i++)
                {
                    tentacles[i].Draw(stage.tentacles[i], graphics);
                }
            }
        }
    }
}
