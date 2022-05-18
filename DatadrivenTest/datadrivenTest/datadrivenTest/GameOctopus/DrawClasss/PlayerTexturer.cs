using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using datadrivenTest.GameOctopus.DrawClasss;
using datadrivenTest.GameOctopus.ObjectClasss;

namespace datadrivenTest.GameOctopus.DrawClasss
{
    class PlayerTexturer
    {
        public Player player;

        List<DrawTexture> playerTextures = new List<DrawTexture>();
        DrawTexture stockTextures;

        float animationTime = 0f;

        public PlayerTexturer(ContentManager content)
        {
            playerTextures.Add(new DrawTexture("Images/player6_1", new Vector2(190f, 100f), content));
            playerTextures.Add(new DrawTexture("Images/player5", new Vector2(185f, 150f), content));
            playerTextures.Add(new DrawTexture("Images/player4", new Vector2(185f, 205f), content));
            playerTextures.Add(new DrawTexture("Images/player3", new Vector2(245f, 225f), content));
            playerTextures.Add(new DrawTexture("Images/player2", new Vector2(305f, 225f), content));
            playerTextures.Add(new DrawTexture("Images/player1_3", new Vector2(350f, 225f), content));

            playerTextures.Add(new DrawTexture("Images/player6_2", new Vector2(190f, 100f), content));
            playerTextures.Add(new DrawTexture("Images/player1_1", new Vector2(355f, 235f), content));
            playerTextures.Add(new DrawTexture("Images/player1_2", new Vector2(355f, 235f), content));
            playerTextures.Add(new DrawTexture("Images/player0_1", new Vector2(298f, 173f), content));
            playerTextures.Add(new DrawTexture("Images/player0_2", new Vector2(298f, 173f), content));


            stockTextures=new DrawTexture("Images/stock", new Vector2(230f, 100f), content);
        }

        public void Initialize(Player player)
        {
            this.player = player;
        }

        public void Draw(GameTime time, SpriteBatch sprite)
        {
            for (int i = 0; i < player.stock; i++)
            {
                stockTextures.Draw(sprite, new Vector2(25 * i, 0));
            }

            switch (player.states)
            {
                case States.Damage:
                    animationTime += (float)time.ElapsedGameTime.TotalSeconds;
                    animationTime %= 1f;
                    if (animationTime > 0.5f)
                        playerTextures[9].Draw(sprite);
                    else
                        playerTextures[10].Draw(sprite);
                    break;

                case States.Geting:
                    animationTime += (float)time.ElapsedGameTime.TotalSeconds;
                    float animFrame = player.getItemRespons/3;
                    animationTime %= player.getItemRespons;
                    if(animationTime > animFrame*2)
                        playerTextures[7].Draw(sprite);
                    else if (animationTime > animFrame)
                        playerTextures[8].Draw(sprite);
                    else
                        playerTextures[5].Draw(sprite);
                    break;

                case States.House:
                    animationTime += (float)time.ElapsedGameTime.TotalSeconds;
                    float houseAnimFrame = player.houseItemRespons / 6;
                    animationTime %= houseAnimFrame * 2;
                    if (animationTime > houseAnimFrame)
                        playerTextures[6].Draw(sprite);
                    else
                        playerTextures[0].Draw(sprite);

                    break;

                case States.Normal:
                    playerTextures[player.position].Draw(sprite);
                    break;
            }
        }
    }
}
