using System;
using System.Collections.Generic;
using System.Text;
using Tutorial.Vector;

namespace Tutorial.Matrix
{
    struct Matrix3x3
    {
        public float M11;
        public float M12;
        public float M13;
        public float M21;
        public float M22;
        public float M23;
        public float M31;
        public float M32;
        public float M33;
        public String Text
        {
            get
            {
                String output = this.M11 + ",\t" + this.M12 + ",\t" + this.M13 + "\n" +
                                this.M21 + ",\t" + this.M22 + ",\t" + this.M23 + "\n" +
                                this.M31 + ",\t" + this.M32 + ",\t" + this.M33;
                return output;
            }
        }

        private static Matrix3x3 identity = new Matrix3x3(1f, 0f, 0f,
                                                         0f, 1f, 0f,
                                                         0f, 0f, 1f);
        public static Matrix3x3 Identity { get { return identity; } }

        public Matrix3x3(float m11, float m12, float m13, float m21, float m22, float m23, float m31, float m32, float m33)
        {
            M11 = m11;
            M12 = m12;
            M13 = m13;
            M21 = m21;
            M22 = m22;
            M23 = m23;
            M31 = m31;
            M32 = m32;
            M33 = m33;
        }
        public Matrix3x3(Vector3 row1, Vector3 row2, Vector3 row3)
        {
            M11 = row1.x;
            M12 = row1.y;
            M13 = row1.z;
            M21 = row2.x;
            M22 = row2.y;
            M23 = row2.z;
            M31 = row3.x;
            M32 = row3.y;
            M33 = row3.z;
        }

        public Vector2 Left
        {
            get { return new Vector2(-this.M11, -this.M12); }
            set { this.M11 = -value.x; this.M12 = -value.y; }
        }
        public Vector2 Right
        {
            get { return new Vector2(this.M11, this.M12); }
            set
            {
                this.M11 = value.x;
                this.M12 = value.y;
            }
        }
        public Vector2 Translation
        {
            get { return new Vector2(this.M31, this.M32); }
            set
            {
                M31 = value.x;
                M32 = value.y;
            }
        }
        public Vector2 Up
        {
            get { return new Vector2(this.M21, this.M22); }
            set
            {
                M21 = value.x;
                M22 = value.y;
            }
        }
        public Vector2 Down
        {
            get { return new Vector2(-this.M21, -this.M22); }
            set
            {
                M21 = -value.x;
                M22 = -value.y;
            }
        }

        public static Matrix3x3 Add(Matrix3x3 matrix1, Matrix3x3 matrix2)
        {
            Matrix3x3 output;
            output.M11 = matrix1.M11 + matrix2.M11;
            output.M12 = matrix1.M12 + matrix2.M12;
            output.M13 = matrix1.M13 + matrix2.M13;
            output.M21 = matrix1.M21 + matrix2.M21;
            output.M22 = matrix1.M22 + matrix2.M22;
            output.M23 = matrix1.M23 + matrix2.M23;
            output.M31 = matrix1.M31 + matrix2.M31;
            output.M32 = matrix1.M32 + matrix2.M32;
            output.M33 = matrix1.M33 + matrix2.M33;
            return output;
        }

        public static Matrix3x3 Multiply(Matrix3x3 matrix1, Matrix3x3 matrix2)
        {
            Matrix3x3 output;
            output.M11 = (matrix1.M11 * matrix2.M11) + (matrix1.M12 * matrix2.M21) + (matrix1.M13 * matrix2.M31);
            output.M12 = (matrix1.M11 * matrix2.M12) + (matrix1.M12 * matrix2.M22) + (matrix1.M13 * matrix2.M32);
            output.M13 = (matrix1.M11 * matrix2.M13) + (matrix1.M12 * matrix2.M23) + (matrix1.M13 * matrix2.M33);

            output.M21 = (matrix1.M21 * matrix2.M11) + (matrix1.M22 * matrix2.M21) + (matrix1.M23 * matrix2.M31);
            output.M22 = (matrix1.M21 * matrix2.M12) + (matrix1.M22 * matrix2.M22) + (matrix1.M23 * matrix2.M32);
            output.M23 = (matrix1.M21 * matrix2.M13) + (matrix1.M22 * matrix2.M23) + (matrix1.M23 * matrix2.M33);

            output.M31 = (matrix1.M31 * matrix2.M11) + (matrix1.M32 * matrix2.M21) + (matrix1.M33 * matrix2.M31);
            output.M32 = (matrix1.M31 * matrix2.M12) + (matrix1.M32 * matrix2.M22) + (matrix1.M33 * matrix2.M32);
            output.M33 = (matrix1.M31 * matrix2.M13) + (matrix1.M32 * matrix2.M23) + (matrix1.M33 * matrix2.M33);

            return output;
        }
        public static Vector3 Multiply(Vector3 vector, Matrix3x3 conversion)
        {
            Vector3 output;
            output.x = vector.x * conversion.M11 + vector.y * conversion.M21 + vector.z * conversion.M31;
            output.y = vector.x * conversion.M12 + vector.y * conversion.M22 + vector.z * conversion.M32;
            output.z = vector.x * conversion.M13 + vector.y * conversion.M23 + vector.z * conversion.M33;

            return output;
        }
        // xna対応版
        public static Microsoft.Xna.Framework.Vector3 Multiply(Microsoft.Xna.Framework.Vector3 vector, Matrix3x3 conversion)
        {
            Microsoft.Xna.Framework.Vector3 output;
            output.X = vector.X * conversion.M11 + vector.Y * conversion.M21 + vector.Z * conversion.M31;
            output.Y = vector.X * conversion.M12 + vector.Y * conversion.M22 + vector.Z * conversion.M32;
            output.Z = vector.X * conversion.M13 + vector.Y * conversion.M23 + vector.Z * conversion.M33;

            return output;
        }
        public static Vector2 Multiply(Vector2 vector, Matrix3x3 conversion)
        {
            Vector2 output;
            output.x = vector.x * conversion.M11 + vector.y * conversion.M21 + conversion.M31;
            output.y = vector.x * conversion.M12 + vector.y * conversion.M22 + conversion.M32;

            return output;
        }

        public static Matrix3x3 operator *(Matrix3x3 matrix1, Matrix3x3 matrix2)
        {
            return Multiply(matrix1, matrix2);
        }
        public static Microsoft.Xna.Framework.Vector3 operator *(Microsoft.Xna.Framework.Vector3 vector, Matrix3x3 conversion)
        {
            return Multiply(vector, conversion);
        }
        public static Vector2 operator *(Vector2 vector, Matrix3x3 conversion)
        {
            return Multiply(vector, conversion);
        }

        public static Matrix3x3 CreateRotation(float rag)
        {
            return new Matrix3x3(
                (float)Math.Cos(rag), (float)-Math.Sin(rag), 0,
                (float)Math.Sin(rag), (float)Math.Cos(rag), 0,
                0, 0, 1
                );
        }
        public static Matrix3x3 CreateTrancerate(Vector2 vec)
        {
            return new Matrix3x3(
                1, 0, 0,
                0, 1, 0,
                vec.x, vec.y, 1
                );
        }
        public static Matrix3x3 CreateTrancerate(Vector3 vec)
        {
            return new Matrix3x3(
                1, 0, 0,
                0, 1, 0,
                vec.x, vec.y, 1
                );
        }
    }
}