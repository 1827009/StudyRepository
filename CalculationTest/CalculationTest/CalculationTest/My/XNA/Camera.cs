using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyXNA
{
    class Camera:My.BoneMatrix
    {
        My.BoneMatrix flontObj;

        public Camera(My.BoneMatrix parent) : base(parent)
        {
            flontObj = new My.BoneMatrix(this);
            flontObj.LocalTransform = My.Matrix4x4.CreateTrancerate(new My.Vector3(0, 0, -1));

            Target = flontObj;
            UpdateEvent += UpdateView;
            UpdateView();
            UpdateProjection();
        }

        My.BoneMatrix target;
        public My.BoneMatrix Target
        {
            get { return target; }
            set {
                target = value;
                UpdateView();
            }
        }
        public void OnFrontTarget()
        {
            Target = flontObj;
        }

        float fieldOfView=90f;
        float aspect=1;
        float maxView=10000f;
        float minView=0.1f;
        Matrix projection;
        float angle = 0;
        Matrix view;
        public Matrix View { get { return view; } }
        public Matrix Projection { get { return projection; } }
        private void UpdateProjection()
        {
            projection = ChangeXNA.Change(My.Matrix4x4.CreatePerspectiveFieldOfView(
                MathHelper.ToRadians(fieldOfView),
                aspect,
                minView,
                maxView
                ));
        }
        private void UpdateView()
        {
            My.Quaternion p = My.Quaternion.CreateRotate(Position, angle);
            My.Quaternion q = My.Quaternion.CreateRotate(new My.Vector3(0, 1, 0), angle);
            
            My.Vector3 vectorP = new My.Vector3(p.x, p.y, p.z);
            Vector3 vectorR = new Vector3(q.x, q.y, q.z);

            var radian = MathHelper.ToRadians(angle);
            var rotate = Matrix.CreateRotationZ(radian);
            var upVector = ChangeXNA.Change(Vector3.Transform(Vector3.Left, rotate));
            //var view1 = Matrix.CreateLookAt(ChangeXNA.Change(this.Position), ChangeXNA.Change(target.Transform.Translation), upVector);
            view = ChangeXNA.Change(My.Matrix4x4.ViewMatrix(Position, target.Transform.Translation, My.Vector3.UP));
        }

        My.Perlin perlin = new My.Perlin();
        List<Vector2> shakePoint=new List<Vector2>();
        public void OnShake(float timeLength)
        {
            TimeManager.AddTimer(this.ToString() + "shake", timeLength);
        }
        public void ShakeUpdate()
        {
            float timeline = TimeManager.GetTime(this.ToString() + "shake");
            Position = new My.Vector3((float)perlin.OctavePerlin(timeline, 0, 0, 10, 9), (float)perlin.OctavePerlin(0, timeline, 0, 10, 9), Position.z);
        }

        public void MoveUpdate()
        {
            if (InputManager.IsKeyDown(Keys.D) || InputManager.IsKeyDown(Keys.Right))
            {
                angle += 0.1f;
                UpdateView();
                //LocalTransform = My.Matrix4x4.CreateRotationY(MathHelper.ToRadians(1)) * LocalTransform;
            }
            if (InputManager.IsKeyDown(Keys.A) || InputManager.IsKeyDown(Keys.Left))
            {
                angle -= 0.1f;
                UpdateView();
                //LocalTransform = My.Matrix4x4.CreateRotationY(MathHelper.ToRadians(-1)) * LocalTransform;
            }
            if (InputManager.IsKeyDown(Keys.W) || InputManager.IsKeyDown(Keys.Up))
            {
                UpdateView();
                LocalTransform = My.Matrix4x4.CreateTrancerate(new My.Vector3(0, 0, -0.01f)) * LocalTransform;
            }
            if (InputManager.IsKeyDown(Keys.S) || InputManager.IsKeyDown(Keys.Down))
            {
                UpdateView();
                LocalTransform = My.Matrix4x4.CreateTrancerate(new My.Vector3(0, 0, 0.01f)) * LocalTransform;
            }
        }
    }
}
