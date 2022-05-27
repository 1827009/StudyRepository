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
        My.BoneMatrix root;
        Camera camera;
        // objects
        DrawSquare square;
        DrawBox box;

        public SampleGame6CameraView(Camera camera, My.BoneMatrix root)
        {
            this.root = root;
            this.camera = camera;

            square = new DrawSquare(root, My.Matrix4x4.CreateRotationX(MathHelper.ToRadians(90)), Color.Brown, Vector3.One * 10);
            square.ChengeColor(Color.Red, Color.Green, Color.Blue);
            box = new DrawBox(root, 0.25f);
            box.Position = new My.Vector3(0, 1.0f, 0);

        }
        float a = 0;
        public override void Update(GameTime time)
        {
            Vector3 plancVec1 = square.VartexPoints[1] - square.VartexPoints[0];
            Vector3 plancVec2 = square.VartexPoints[3] - square.VartexPoints[0];

            Vector3 nor = ChangeXNA.Change(box.Position) - square.VartexPoints[0];
            float ans = Vector3.Dot(Vector3.Cross(plancVec1, plancVec2), nor);

            System.Diagnostics.Debug.WriteLine(square.VartexPoints[1]);
            System.Diagnostics.Debug.WriteLine((decimal)ans);
            if (ans < 0)
                box.ChengeColor(Color.Red);
            else
                box.ChengeColor(Color.White);

            if (InputManager.IsKeyDown(Keys.W))
                a++;
            if (InputManager.IsKeyDown(Keys.S))
                a--;
            square.Position = new My.Vector3(square.Position.x, a * 0.01f, square.Position.z);

            camera.MoveUpdate();

        }

        public override void Draw(GraphicsDevice graphics, GameTime time)
        {
            square.Draw(graphics, time);
            box.Draw(graphics, time);
        }
    }
}
