using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MyXNA
{
    class DrawBox
    {
        Matrix[] vertexMatrix;
        public My.BoneMatrix matrix;

        VertexPositionColor[] vertices;

        public DrawBox(My.BoneMatrix transform, Color color, Vector3 size)
        {
            matrix = transform;
            matrix.UpdateEvent += Update;

            vertexMatrix = new Matrix[6];
            for (int i = 0; i < 6; i++)
                vertexMatrix[i] = Matrix.Identity;
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
                Vector3 vec = (ChangeXNA.Change(matrix.Matrix) * vertexMatrix[i]).Translation;                
                vertices[i].Position = vec;
            }
        }
        public void Draw(GraphicsDevice graphics)
        {
            graphics.DrawUserPrimitives<VertexPositionColor>(
                PrimitiveType.TriangleList,
                vertices,
                0,
                2
                );
        }

        public void ChengeColor(Color color)
        {
            for (int i = 0; i < vertices.Length; i++)
            {
                vertices[i].Color = color;
            }
        }
    }
}
