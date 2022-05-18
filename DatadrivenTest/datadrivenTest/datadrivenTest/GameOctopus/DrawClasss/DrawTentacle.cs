using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using datadrivenTest.GameOctopus.ObjectClasss;

namespace datadrivenTest.GameOctopus.DrawClasss
{
    class DrawTentacle
    {
        Tentacle tentacle;
        List<DrawTexture> textures;

        public DrawTentacle(Tentacle tentacle, params DrawTexture[] tex)
        {
            this.tentacle = tentacle;

            textures = new List<DrawTexture>(tex);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < tentacle.Step; i++)
            {
                textures[i].Draw(spriteBatch);
            }
        }
    }
}
