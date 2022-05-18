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

        DrawTexture textures;
        PlayerTexturer playerTexturer;
        TentacleTexturer tentacleTexturer;

        DrawText text;

        public DrawGame(ContentManager content)
        {
            playerTexturer = new PlayerTexturer(content);
            tentacleTexturer = new TentacleTexturer(content);

            textures = new DrawTexture("Images/octopus_main", Vector2.Zero, content);

            text = new DrawText(content, new Vector2(350f, 100f));
        }

        public void Initialize(Stage stage)
        {
            this.stage = stage;
            playerTexturer.Initialize(stage.player);
            tentacleTexturer.Initialize(stage.tentacles);
        }

        public void Draw(GameTime time, SpriteBatch spriteBatch)
        {
            textures.Draw(spriteBatch);
            tentacleTexturer.Draw(spriteBatch);
            playerTexturer.Draw(time, spriteBatch);

            text.Draw(spriteBatch, stage.player.totalItems.ToString());
        }
    }
}
