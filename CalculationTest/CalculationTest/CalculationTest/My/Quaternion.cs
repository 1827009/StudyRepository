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
