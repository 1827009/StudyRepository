using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using datadrivenTest.GameOctopus.ObjectClasss;

namespace datadrivenTest.GameOctopus.DrawClasss
{
    class DrawGame
    {
        Stage stage;

        List<DrawTexture> textures=new List<DrawTexture>();
        DrawPlayer drawPlayer;
        List<DrawOctopus> drawOctopus=new List<DrawOctopus>();

        DrawText text;

        public DrawGame(ContentManager content, Stage stage)
        {
            this.stage = stage;

            drawPlayer = new DrawPlayer(content, stage.player);
            for (int i = 0; i < stage.enemy.Count; i++)
            {
                drawOctopus.Add(new DrawOctopus(content, stage.enemy[i], new Vector2(120 + (i * 304), 40)));
            }
            LoadStageTextuer(content);

            text = new DrawText(content, new Vector2(200f, 10f));
        }

        public void LoadStageTextuer(ContentManager content)
        {
            if (stage.size <= 6)
                textures.Add(new DrawTexture("Images/octopus_display", Vector2.Zero, content));
            else
            {
                textures.Add(new DrawTexture("Images/octopus_display_plus", Vector2.Zero, content));
                textures.Add(new DrawTexture("Images/octopus_display", new Vector2(Game1.WINDOW_SIZE_X * 0.5f, 0), content));
            }
        }

        public void Draw(GameTime time, SpriteBatch spriteBatch)
        {
            foreach (var item in textures)
            {
                item.Draw(spriteBatch);
            }
            foreach (var item in drawOctopus)
            {
                item.Draw(time, spriteBatch);
            }
            drawPlayer.Draw(time, spriteBatch);

            if (stage.GameClear)
                text.Draw(spriteBatch, "GAME CLEAR");
            else
                text.Draw(spriteBatch, stage.player.totalItems.ToString());
        }
    }
}
