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
    class DrawPlayer
    {
        public Player player;
        Vector2 rootPosition = new Vector2(-158, -95);

        List<DrawTexture> playerTextures = new List<DrawTexture>();
        DrawTexture stockTextures;

        float animationTime = 0f;

        public DrawPlayer(ContentManager content, Player player)
        {
            this.player = player;

            playerTextures.Add(new DrawTexture("Images/player6_1", Vector2.Zero, content));
            playerTextures.Add(new DrawTexture("Images/player5", Vector2.Zero, content));
            playerTextures.Add(new DrawTexture("Images/player4", Vector2.Zero, content));
            playerTextures.Add(new DrawTexture("Images/player3", Vector2.Zero, content));
            playerTextures.Add(new DrawTexture("Images/player2", Vector2.Zero, content));
            playerTextures.Add(new DrawTexture("Images/player1_3", Vector2.Zero, content));

            playerTextures.Add(new DrawTexture("Images/player6_2", Vector2.Zero, content));
            playerTextures.Add(new DrawTexture("Images/player1_1", Vector2.Zero, content));
            playerTextures.Add(new DrawTexture("Images/player1_2", Vector2.Zero, content));

            stockTextures = new DrawTexture("Images/stock", new Vector2(230f, 100f) + rootPosition, content);

        }

        Vector2 PositionSet()
        {
            switch (player.position)
            {
                case 0:
                    return new Vector2(190f, 100f) + rootPosition;

                case 1:
                    return new Vector2(185f, 150f) + rootPosition;

                case 2:
                    return new Vector2(185f, 205f) + rootPosition;

                case 3:
                    return new Vector2(245f, 225f) + rootPosition;

                case 4:
                    return new Vector2(305f, 225f) + rootPosition;

                case 5:
                    return new Vector2(350f, 225f) + rootPosition;

                case 6:
                    return new Vector2(489f, 150f) + rootPosition;

                case 7:
                    return new Vector2(489f, 205f) + rootPosition;

                case 8:
                    return new Vector2(549f, 225f) + rootPosition;

                case 9:
                    return new Vector2(604f, 225f) + rootPosition;

                case 10:
                    return new Vector2(654f, 225f) + rootPosition;
            }
            throw new Exception();
        }

        public void Draw(GameTime time, SpriteBatch spriteBatch)
        {
            for (int i = 0; i < player.stock; i++)
            {
                stockTextures.Draw(spriteBatch, new Vector2(25 * i, 0));
            }

            switch (player.states)
            {
                case Ready.Damage:
                    break;

                case Ready.Geting:
                    animationTime += (float)time.ElapsedGameTime.TotalSeconds;
                    float animFrame = player.getItemRespons/3;
                    animationTime %= player.getItemRespons;
                    if(animationTime > animFrame*2)
                        playerTextures[7].Draw(spriteBatch, PositionSet());
                    else if (animationTime > animFrame)
                        playerTextures[8].Draw(spriteBatch, PositionSet());
                    else
                        playerTextures[5].Draw(spriteBatch, PositionSet());
                    break;

                case Ready.House:
                    animationTime += (float)time.ElapsedGameTime.TotalSeconds;
                    float houseAnimFrame = player.houseItemRespons / 6;
                    animationTime %= houseAnimFrame * 2;
                    if (animationTime > houseAnimFrame)
                        playerTextures[6].Draw(spriteBatch, PositionSet());
                    else
                        playerTextures[0].Draw(spriteBatch, PositionSet());

                    break;

                case Ready.Normal:
                    int texNo = player.position % 6;                    
                    if (player.position > 5 && texNo < 3)
                        texNo += 3;
                    playerTextures[texNo].Draw(spriteBatch, PositionSet());
                    break;
            }
        }
    }
}
