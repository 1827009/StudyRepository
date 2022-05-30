using System;
using System.Collections.Generic;
using System.Text;

namespace My
{
    struct Quaternion
    {
        public float x;
        public float y;
        public float z;
        public float w;

        public Quaternion(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public static Quaternion Identity
        {
            get { return new Quaternion(0, 0, 0, 1); }
        }

        public Matrix4x4 ToMatrix
        {
            get
            {
                float m11 = 1 - 2 * (y * y) - 2 * (z * z);
                float m12 = 2 * x * y - 2 * w * z;
                float m13 = 2 * x * z - 2 * w * y;

                float m21 = 2 * x * y - 2 * w * z;
                float m22 = 1 - 2 * (x * x) - 2 * (z * z);
                float m23 = 2 * y * z - 2 * w * x;

                float m31 = 2 * x * z - 2 * w * y;
                float m32 = 2 * y * z - 2 * w * x;
                float m33 = 1 - 2 * (x * x) - 2 * (y * y);

                return new Matrix4x4(
                    m11, m12, m13, 0,
                    m21, m22, m23, 0,
                    m31, m32, m33, 0,
                    0, 0, 0, 1
                    );
            }
        }

        public static Quaternion CreateRotate(Vector3 axis, float angle)
        {
            axis = axis.Normalize;
            angle *= 0.5f;
            float sin = MathF.Sin(angle);
            float cos = MathF.Cos(angle);

            Quaternion result = new Quaternion(axis.x * sin, axis.y * sin, axis.z * sin, cos);

            return result;
        }

        public static Quaternion operator*(Quaternion a, Quaternion b)
        {
            Quaternion result;
            float num = (a.y * b.z) - (a.z * b.y);
            float num2 = (a.z * b.x) - (a.x * b.z);
            float num3 = (a.x * b.y) - (a.y * b.x);
            float num4 = (a.x * b.x) + (a.y * b.y) + (a.z * b.z);

            result = new Quaternion(
                ((a.x * b.w) + (b.x * a.w)) + num,
                ((a.y * b.w) + (b.y * a.w)) + num2,
                ((a.z * b.w) + (b.z * a.w)) + num3,
                (a.w * b.w) - num4
                );

            return result;
        }

    }
}
