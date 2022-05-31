using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MyXNA
{
    class DrawSquare_Quaternion:My.BoneTransform
    {
        Matrix[] vertexMatrix;

        VertexPositionColor[] vertices;
        public Vector3[] VartexPoints
        {
            get
            {
                Vector3[] result = new Vector3[4] { vertices[0].Position, vertices[1].Position, vertices[2].Position, vertices[4].Position };
                return result;
            }
        }

        public DrawSquare_Quaternion(My.BoneTransform parent, Color color, Vector3 size) : base(parent)
        {
            UpdateEvent += Update;

            vertexMatrix = new Matrix[6];
            for (int i = 0; i < 6; i++)
                vertexMatrix[i] = Microsoft.Xna.Framework.Matrix.Identity;
            vertexMatrix[0].Translation = new Vector3(-0.1f * size.X, 0.1f * size.Y, 0);
            vertexMatrix[1].Translation = new Vector3(0.1f * size.X, 0.1f * size.Y, 0);
            vertexMatrix[2].Translation = new Vector3(0.1f * size.X, -0.1f * size.Y, 0);

            vertexMatrix[3].Translation = new Vector3(0.1f * size.X, -0.1f * size.Y, 0);
            vertexMatrix[4].Translation = new Vector3(-0.1f * size.X, -0.1f * size.Y, 0);
            vertexMatrix[5].Translation = new Vector3(-0.1f * size.X, 0.1f * size.Y, 0);

            vertices = new VertexPositionColor[6];
            for (int i = 0; i < 6; i++)
                vertices[i] = new VertexPositionColor(Vector3.Zero, color);
        }
        void Update()
        {
            for (int i = 0; i < vertices.Length; i++)
            {
                Vector3 vec = (vertexMatrix[i] * ChangeXNA.Change(Transform)).Translation;
                vertices[i].Position = vec;
            }
        }
        public void Draw(GraphicsDevice graphics, GameTime time)
        {
            graphics.DrawUserPrimitives<VertexPositionColor>(
                PrimitiveType.TriangleList,
                vertices,
                0,
                2
                );

            VertexPositionColor[] cal = { vertices[5], vertices[4], vertices[3], vertices[2], vertices[1], vertices[0] };
            graphics.DrawUserPrimitives<VertexPositionColor>(
                PrimitiveType.TriangleList,
                cal,
                0,
                2
                );
        }

        public void ChengeColor(params Color[] color)
        {
            for (int i = 0; i < vertices.Length; i++)
            {
                vertices[i].Color = color[i % color.Length];
            }
        }

    }
}
