using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MyXNA;

namespace CalculationTest.SampleGames
{
    class SampleGame4CamaraShake : SampleGame
    {
        My.BoneMatrix root;
        Camera camera;
        DrawBox box;

        public SampleGame4CamaraShake(Camera camera, My.BoneMatrix root)
        {
            box = new DrawBox(root, 1);
            this.camera = camera;
            this.root = root;

            camera.OnFrontTarget();
            camera.OnShake(15);
        }

        public override void Update(GameTime time)
        {
            camera.MoveUpdate();
            camera.ShakeUpdate();
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime time)
        {
            
        }
        public override void Draw(GraphicsDevice graphics, GameTime time)
        {
            box.Draw(graphics, time);
        }
    }
}
