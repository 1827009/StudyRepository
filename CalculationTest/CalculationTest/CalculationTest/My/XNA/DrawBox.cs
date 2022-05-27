using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MyXNA
{
    class DrawBox:My.BoneMatrix, IDrawModel
    {
        DrawSquare[] squares = new DrawSquare[6];

        public DrawBox(My.BoneMatrix parent, float size):base(parent)
        {
            for (int i = 0; i < squares.Length; i++)
            {
                squares[i] = new DrawSquare(this, My.Matrix4x4.Identity, Color.White, Vector3.One);
            }
            float halfsize = size * 0.5f;
            squares[0].LocalTransform *= My.Matrix4x4.CreateTrancerate(new My.Vector3(halfsize, 0, 0)) * My.Matrix4x4.CreateRotationY(MathHelper.ToRadians(90));
            squares[1].LocalTransform *= My.Matrix4x4.CreateTrancerate(new My.Vector3(-halfsize, 0, 0)) * My.Matrix4x4.CreateRotationY(MathHelper.ToRadians(-90));

            squares[2].LocalTransform *= My.Matrix4x4.CreateTrancerate(new My.Vector3(0, halfsize, 0)) * My.Matrix4x4.CreateRotationX(MathHelper.ToRadians(90));
            squares[3].LocalTransform *= My.Matrix4x4.CreateTrancerate(new My.Vector3(0, -halfsize, 0)) * My.Matrix4x4.CreateRotationX(MathHelper.ToRadians(-90));

            squares[4].LocalTransform *= My.Matrix4x4.CreateTrancerate(new My.Vector3(0, 0, halfsize)) * My.Matrix4x4.CreateRotationX(MathHelper.ToRadians(180));
            squares[5].LocalTransform *= My.Matrix4x4.CreateTrancerate(new My.Vector3(0, 0, -halfsize));
        }

        public void Draw(GraphicsDevice graphics, GameTime time)
        {
            foreach (var item in squares)
            {
                item.Draw(graphics, time);
            }
        }

        public void ChengeColor(params Color[] colors)
        {
            foreach (var item in squares)
            {
                item.ChengeColor(colors);
            }
        }
    }
}
