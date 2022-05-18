using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using datadrivenTest.GameOctopus.ObjectClasss;

namespace datadrivenTest.GameOctopus.DrawClasss
{
    class TentacleTexturer
    {
        List<Tentacle> tentacles;

        List<List<DrawTexture>> textures;

        public TentacleTexturer(ContentManager content)
        {
            textures = new List<List<DrawTexture>>();
            textures.Add(new List<DrawTexture>());
            textures[0].Add(new DrawTexture("Images/tentacle1_3", new Vector2(258f, 157f), content));
            textures[0].Add(new DrawTexture("Images/tentacle1_2", new Vector2(235f, 157f), content));
            textures[0].Add(new DrawTexture("Images/tentacle1_1", new Vector2(216f, 148f), content));

            textures.Add(new List<DrawTexture>());
            textures[1].Add(new DrawTexture("Images/tentacle1_3", new Vector2(258f, 157f), content));
            textures[1].Add(new DrawTexture("Images/tentacle1_2_3", new Vector2(245f, 170f), content));
            textures[1].Add(new DrawTexture("Images/tentacle1_2_2", new Vector2(240f, 178f), content));
            textures[1].Add(new DrawTexture("Images/tentacle1_2_1", new Vector2(225f, 192f), content));

            textures.Add(new List<DrawTexture>());
            textures[2].Add(new DrawTexture("Images/tentacle2_5", new Vector2(285f, 170f), content));
            textures[2].Add(new DrawTexture("Images/tentacle2_4", new Vector2(285f, 177f), content));
            textures[2].Add(new DrawTexture("Images/tentacle2_3", new Vector2(278f, 192f), content));
            textures[2].Add(new DrawTexture("Images/tentacle2_2", new Vector2(275f, 203f), content));
            textures[2].Add(new DrawTexture("Images/tentacle2_1", new Vector2(271f, 216f), content));

            textures.Add(new List<DrawTexture>());
            textures[3].Add(new DrawTexture("Images/tentacle3_4", new Vector2(318f, 185f), content));
            textures[3].Add(new DrawTexture("Images/tentacle3_3", new Vector2(318f, 198f), content));
            textures[3].Add(new DrawTexture("Images/tentacle3_2", new Vector2(318f, 213f), content));
            textures[3].Add(new DrawTexture("Images/tentacle3_1", new Vector2(318f, 230f), content));

            textures.Add(new List<DrawTexture>());
            textures[4].Add(new DrawTexture("Images/tentacle4_3", new Vector2(373f, 202f), content));
            textures[4].Add(new DrawTexture("Images/tentacle4_2", new Vector2(376f, 212f), content));
            textures[4].Add(new DrawTexture("Images/tentacle4_1", new Vector2(379f, 227f), content));
        }

        public void Initialize(List<Tentacle> tentacles)
        {
            this.tentacles = tentacles;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 1; i < tentacles.Count; i++)
            {
                for (int j = 0; j < tentacles[i].Step; j++)
                {
                    //if (tentacles[i].Step >= j)
                    textures[i - 1][j].Draw(spriteBatch);
                }

            }
        }
    }
}
