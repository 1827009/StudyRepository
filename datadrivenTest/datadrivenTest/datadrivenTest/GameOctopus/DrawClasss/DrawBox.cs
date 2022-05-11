using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace datadrivenTest.GameOctopus
{
    class DrawBox
    {
        Matrix[] verMatrix;
        public Matrix matrix;

        VertexPositionColor[] vertices;

        public DrawBox(Matrix parent, Matrix pos, Color color, Vector2 size)
        {
            matrix = pos;

            verMatrix = new Matrix[6];
            for (int i = 0; i < 6; i++)
                verMatrix[i] = Matrix.Identity;
            verMatrix[0].Translation = new Vector3(-0.1f*size.X, 0.1f * size.Y, 0);
            verMatrix[1].Translation = new Vector3(0.1f * size.X, 0.1f * size.Y, 0);
            verMatrix[2].Translation = new Vector3(0.1f * size.X, -0.1f * size.Y, 0);

            verMatrix[3].Translation = new Vector3(0.1f * size.X, -0.1f * size.Y, 0);
            verMatrix[4].Translation = new Vector3(-0.1f * size.X, -0.1f * size.Y, 0);
            verMatrix[5].Translation = new Vector3(-0.1f * size.X, 0.1f * size.Y, 0);

            vertices = new VertexPositionColor[6];
            for (int i = 0; i < 6; i++)
                vertices[i] = new VertexPositionColor(Vector3.Zero, color);
            Update(parent);
        }
        public void Update(Matrix parent)
        {
            for (int i = 0; i < vertices.Length; i++)
                vertices[i].Position = (parent * matrix * verMatrix[i]).Translation;
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
    }
}
