using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using MyXNA;

namespace CalculationTest.SampleGames
{
    class SampleGame6CameraView : SampleGame
    {
        My.BoneTransform root;
        Camera_Transform camera;
        // objects
        DrawSquare_Quaternion square;

        public SampleGame6CameraView(Camera_Transform camera, My.BoneTransform root)
        {
            this.root = root;
            this.camera = camera;

            square = new DrawSquare_Quaternion(root, Color.Brown, Vector3.One * 10);
            square.ChengeColor(Color.Red, Color.Green, Color.Blue);
            this.camera.Target = square;

        }
        Quaternion q = Quaternion.Identity;
        float an = 0;
        public override void Update(GameTime time)
        {
            if (InputManager.IsKeyDown(Keys.F1))
                an += 0.05f;
            q = Quaternion.CreateFromAxisAngle(Vector3.Up, an);

            square.LocalQuaternion = ChangeXNA.Change(q);
            //System.Diagnostics.Debug.WriteLine(m);
        }

        public override void Draw(GraphicsDevice graphics, GameTime time)
        {
            square.Draw(graphics, time);
        }
    }
}
