using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using datadrivenTest.GameOctopus.ObjectClasss;

namespace datadrivenTest.GameOctopus.DrawClasss
{
    class DrawOctopus:My.BoneMatrix
    {
        Octopus octopus;

        List<DrawTexture> attackPlayerTextures = new List<DrawTexture>();
        DrawTexture texture;
        List<DrawTentacle> drawTentacle;

        public DrawOctopus(ContentManager content, Octopus octopus, Vector3 pos, My.BoneMatrix root):base(root)
        {
            LocalMatrix = My.Matrix4x4.CreateTrancerate(MyXNA.ChangeXNA.Change(pos));
            this.octopus = octopus;
            texture = new DrawTexture("Images/octopus", this, Vector3.Zero, content);


            drawTentacle = new List<DrawTentacle>(5);

            attackPlayerTextures.Add(new DrawTexture("Images/player0_1", this, new Vector3(18, 40,0), content));
            attackPlayerTextures.Add(new DrawTexture("Images/player0_2", this, new Vector3(18, 40,0), content));

            drawTentacle.Add(new DrawTentacle(octopus.tentacles[0],this,
                new DrawTexture("Images/tentacle1_3", this, new Vector3(-20f, 22f, 0), content),
                new DrawTexture("Images/tentacle1_2", this, new Vector3(-43f, 22f, 0), content),
                new DrawTexture("Images/tentacle1_1", this, new Vector3(-62f, 13f, 0), content)
                ));

            drawTentacle.Add(new DrawTentacle(octopus.tentacles[1], this,
                new DrawTexture("Images/tentacle1_3", this, new Vector3(-20f, 22f, 0), content),
                new DrawTexture("Images/tentacle1_2_3", this, new Vector3(-33f, 35f, 0), content),
                new DrawTexture("Images/tentacle1_2_2", this, new Vector3(-38f, 43f, 0), content),
                new DrawTexture("Images/tentacle1_2_1", this, new Vector3(-53f, 57f, 0), content)
                ));

            drawTentacle.Add(new DrawTentacle(octopus.tentacles[2], this,
                new DrawTexture("Images/tentacle2_5", this, new Vector3(7f, 35f, 0), content),
                new DrawTexture("Images/tentacle2_4", this, new Vector3(7f, 42f, 0), content),
                new DrawTexture("Images/tentacle2_3", this, new Vector3(0f, 57f, 0), content),
                new DrawTexture("Images/tentacle2_2", this, new Vector3(-3f, 68f, 0), content),
                new DrawTexture("Images/tentacle2_1", this, new Vector3(-7f, 81f, 0), content)
                ));

            drawTentacle.Add(new DrawTentacle(octopus.tentacles[3], this,
                new DrawTexture("Images/tentacle3_4", this, new Vector3(40f, 50f, 0), content),
                new DrawTexture("Images/tentacle3_3", this, new Vector3(40f, 63f, 0), content),
                new DrawTexture("Images/tentacle3_2", this, new Vector3(40f, 78f, 0), content),
                new DrawTexture("Images/tentacle3_1", this, new Vector3(40f, 95f, 0), content)
                ));

            drawTentacle.Add(new DrawTentacle(octopus.tentacles[4], this,
                new DrawTexture("Images/tentacle4_3", this, new Vector3(95f, 67f, 0), content),
                new DrawTexture("Images/tentacle4_2", this, new Vector3(98f, 77f, 0), content),
                new DrawTexture("Images/tentacle4_1", this, new Vector3(101f, 92f, 0), content)
                ));
        }

        public void Initialize(Octopus octopus)
        {
            this.octopus = octopus;
        }

        float animationTime = 0f;
        public void Draw( GameTime time,SpriteBatch spriteBatch)
        {
            if (octopus.ready == EnemyReady.Attack)
            {
                animationTime += (float)time.ElapsedGameTime.TotalSeconds;
                animationTime %= 1f;
                if (animationTime > 0.5f)
                    attackPlayerTextures[0].Draw(spriteBatch);
                else
                    attackPlayerTextures[1].Draw(spriteBatch);
            }

            texture.Draw(spriteBatch);
            foreach (var item in drawTentacle)
            {
                item.Draw(spriteBatch);
            }
        }
    }
}
