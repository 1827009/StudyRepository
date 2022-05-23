﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using datadrivenTest.GameOctopus.ObjectClasss;

namespace datadrivenTest.GameOctopus.DrawClasss
{
    class DrawStage:My.BoneMatrix
    {
        Stage stage;

        List<DrawTexture> buckGround=new List<DrawTexture>();
        DrawPlayer drawPlayer;
        DrawTexture stockTextures;
        List<DrawOctopus> drawOctopus=new List<DrawOctopus>();

        DrawText text;

        public DrawStage(ContentManager content, Stage stage)
        {
            this.stage = stage;

            drawPlayer = new DrawPlayer(content, stage.player, this);
            for (int i = 0; i < stage.enemy.Count; i++)
            {
                drawOctopus.Add(new DrawOctopus(content, stage.enemy[i], new Vector3(120 + (i * 304), 40, 0), this));
            }
            LoadStageTextuer(content);

            text = new DrawText(content, new Vector2(200f, 10f));
        }

        public void LoadStageTextuer(ContentManager content)
        {

            for (int i = 0; i < stage.Size / Stage.STAGE_SIZE - 1; i++)
            {
                buckGround.Add(new DrawTexture("Images/octopus_display_plus", this, Vector3.Zero, content));
            }
            buckGround.Add(new DrawTexture("Images/octopus_display", this, Vector3.Zero, content));

            for (int i = 0; i < buckGround.Count; i++)
            {
                buckGround[i].LocalMatrix = My.Vector3.CreateTrancerate(new My.Vector3(buckGround[0].texture.Width * i, 0, 0));
            }
            LocalMatrix = My.Matrix4x4.CreateTrancerate(new My.Vector3((Game1.WINDOW_SIZE_X * 0.5f) - (buckGround[0].texture.Width * 0.5f * buckGround.Count), 0, 0));

            stockTextures = new DrawTexture("Images/stock", this, new Vector3(230f, 100f, 0), content);
        }

        public void Draw(GameTime time, SpriteBatch spriteBatch)
        {
            Update(new My.BoneMatrix(),true);


            foreach (var item in buckGround)
            {
                item.Draw(spriteBatch);
            }
            for (int i = 0; i < stage.player.stock; i++)
            {
                stockTextures.Draw(new Vector3(27 * i + 62 , 7, 0) + MyXNA.ChangeXNA.Change(Matrix.Translation), spriteBatch);
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