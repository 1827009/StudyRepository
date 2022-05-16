using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MyXNA
{
    class ChangeXNA
    {
        public static Vector3 Vector3MyToXNA(My.Vector3 vector)
        {
            return new Vector3(vector.x, vector.y, vector.z);
        }
        public static My.Vector3 Vector3XNAToMy(Vector3 vector)
        {
            return new My.Vector3(vector.X, vector.X, vector.X);
        }
        public static Matrix MatrixMyToXNA(My.Matrix4x4 matrix)
        {
            return new Matrix(matrix.M11, matrix.M12, matrix.M13, matrix.M14, matrix.M21, matrix.M22, matrix.M23, matrix.M24, matrix.M31, matrix.M32, matrix.M33, matrix.M34, matrix.M41, matrix.M42, matrix.M43, matrix.M44);
        }
        public static My.Matrix4x4 MatrixXNAToMy(Matrix matrix)
        {
            return new My.Matrix4x4(matrix.M11, matrix.M12, matrix.M13, matrix.M14, matrix.M21, matrix.M22, matrix.M23, matrix.M24, matrix.M31, matrix.M32, matrix.M33, matrix.M34, matrix.M41, matrix.M42, matrix.M43, matrix.M44);
        }
    }
}
