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
    class DrawPlayer:My.BoneMatrix
    {
        public Player player;

        List<DrawTexture> playerTextures = new List<DrawTexture>();

        float animationTime = 0f;

        public DrawPlayer(ContentManager content, Player player, My.BoneMatrix root):base(root)
        {
            this.player = player;

            playerTextures.Add(new DrawTexture("Images/player6_1", this, Vector3.Zero, content));
            playerTextures.Add(new DrawTexture("Images/player5", this, Vector3.Zero, content));
            playerTextures.Add(new DrawTexture("Images/player4", this, Vector3.Zero, content));
            playerTextures.Add(new DrawTexture("Images/player3", this, Vector3.Zero, content));
            playerTextures.Add(new DrawTexture("Images/player2", this, Vector3.Zero, content));
            playerTextures.Add(new DrawTexture("Images/player1_3", this, Vector3.Zero, content));

            playerTextures.Add(new DrawTexture("Images/player6_2", this, Vector3.Zero, content));
            playerTextures.Add(new DrawTexture("Images/player1_1", this, Vector3.Zero, content));
            playerTextures.Add(new DrawTexture("Images/player1_2", this, Vector3.Zero, content));


        }


        public void Draw(GameTime time, SpriteBatch spriteBatch)
        {

            switch (player.ready)
            {
                case Ready.Damage:
                    break;

                case Ready.Geting:
                    animationTime += (float)time.ElapsedGameTime.TotalSeconds;
                    float animFrame = player.getItemRespons/3;
                    animationTime %= player.getItemRespons;
                    if(animationTime > animFrame*2)
                        playerTextures[7].Draw(spriteBatch);
                    else if (animationTime > animFrame)
                        playerTextures[8].Draw(spriteBatch);
                    else
                        playerTextures[5].Draw(spriteBatch);
                    break;

                case Ready.House:
                    animationTime += (float)time.ElapsedGameTime.TotalSeconds;
                    float houseAnimFrame = player.houseItemRespons / 6;
                    animationTime %= houseAnimFrame * 2;
                    if (animationTime > houseAnimFrame)
                        playerTextures[6].Draw(spriteBatch);
                    else
                        playerTextures[0].Draw(spriteBatch);

                    break;

                case Ready.Normal:
                    int texNo = player.position % 6;                    
                    if (player.position > 5 && texNo < 3)
                        texNo += 3;
                    playerTextures[texNo].Draw(spriteBatch);
                    break;
            }
            PositionSet();
        }
        void PositionSet()
        {
            Vector2 result=Vector2.Zero;
            switch (player.position)
            {
                case 0:
                    result = new Vector2(32, 5);
                    break;

                case 1:
                    result = new Vector2(27, 55);
                    break;

                case 2:
                    result = new Vector2(27, 110);
                    break;

                case 3:
                    result = new Vector2(87, 130);
                    break;

                case 4:
                    result = new Vector2(147, 130);
                    break;

                case 5:
                    result = new Vector2(192, 130);
                    break;

                case 6:
                    result = new Vector2(331, 55);
                    break;

                case 7:
                    result = new Vector2(331, 110);
                    break;

                case 8:
                    result = new Vector2(391, 130);
                    break;

                case 9:
                    result = new Vector2(446, 130);
                    break;

                case 10:
                    result = new Vector2(496, 130);
                    break;
            }
            LocalMatrix = My.Matrix4x4.CreateTrancerate(MyXNA.ChangeXNA.Change(result).xy0);
        }
    }
}
