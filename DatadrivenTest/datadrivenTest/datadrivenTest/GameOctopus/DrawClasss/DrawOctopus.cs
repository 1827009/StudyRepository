using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using datadrivenTest.GameOctopus.ObjectClasss;

namespace datadrivenTest.GameOctopus.DrawClasss
{
    class DrawOctopus
    {
        Octopus octopus;

        List<DrawTexture> attackPlayerTextures = new List<DrawTexture>();
        DrawTexture texture;
        List<DrawTentacle> drawTentacle;

        public DrawOctopus(ContentManager content, Octopus octopus, Vector2 pos)
        {
            texture = new DrawTexture("Images/octopus", pos, content);

            this.octopus = octopus;

            drawTentacle = new List<DrawTentacle>(5);

            attackPlayerTextures.Add(new DrawTexture("Images/player0_1", Vector2.Zero, content));
            attackPlayerTextures.Add(new DrawTexture("Images/player0_2", Vector2.Zero, content));

            drawTentacle.Add(new DrawTentacle(octopus.tentacles[0],
                new DrawTexture("Images/tentacle1_3", new Vector2(-20f, 22f) + texture.position, content),
                new DrawTexture("Images/tentacle1_2", new Vector2(-43f, 22f) + texture.position, content),
                new DrawTexture("Images/tentacle1_1", new Vector2(-62f, 13f) + texture.position, content)
                ));

            drawTentacle.Add(new DrawTentacle(octopus.tentacles[1],
                new DrawTexture("Images/tentacle1_3", new Vector2(-20f, 22f) + texture.position, content),
                new DrawTexture("Images/tentacle1_2_3", new Vector2(-33f, 35f) + texture.position, content),
                new DrawTexture("Images/tentacle1_2_2", new Vector2(-38f, 43f) + texture.position, content),
                new DrawTexture("Images/tentacle1_2_1", new Vector2(-53f, 57f) + texture.position, content)
                ));

            drawTentacle.Add(new DrawTentacle(octopus.tentacles[2],
                new DrawTexture("Images/tentacle2_5", new Vector2(7f, 35f) + texture.position, content),
                new DrawTexture("Images/tentacle2_4", new Vector2(7f, 42f) + texture.position, content),
                new DrawTexture("Images/tentacle2_3", new Vector2(0f, 57f) + texture.position, content),
                new DrawTexture("Images/tentacle2_2", new Vector2(-3f, 68f) + texture.position, content),
                new DrawTexture("Images/tentacle2_1", new Vector2(-7f, 81f) + texture.position, content)
                ));

            drawTentacle.Add(new DrawTentacle(octopus.tentacles[3],
                new DrawTexture("Images/tentacle3_4", new Vector2(40f, 50f) + texture.position, content),
                new DrawTexture("Images/tentacle3_3", new Vector2(40f, 63f) + texture.position, content),
                new DrawTexture("Images/tentacle3_2", new Vector2(40f, 78f) + texture.position, content),
                new DrawTexture("Images/tentacle3_1", new Vector2(40f, 95f) + texture.position, content)
                ));

            drawTentacle.Add(new DrawTentacle(octopus.tentacles[4],
                new DrawTexture("Images/tentacle4_3", new Vector2(95f, 67f) + texture.position, content),
                new DrawTexture("Images/tentacle4_2", new Vector2(98f, 77f) + texture.position, content),
                new DrawTexture("Images/tentacle4_1", new Vector2(101f, 92f) + texture.position, content)
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
                    attackPlayerTextures[0].Draw(spriteBatch, new Vector2(18, 40) + texture.position);
                else
                    attackPlayerTextures[1].Draw(spriteBatch, new Vector2(18, 40) + texture.position);
            }

            texture.Draw(spriteBatch);
            foreach (var item in drawTentacle)
            {
                item.Draw(spriteBatch);
            }
        }
    }
}
