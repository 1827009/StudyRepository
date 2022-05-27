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

        public static Quaternion operator*(Quaternion a, Quaternion b)
        {
            Quaternion result;
            Vector3 aVec = new Vector3(a.x, a.y, a.z);
            Vector3 bVec = new Vector3(b.x, b.y, b.z);
            float ansW = (a.w * b.w - Vector3.Dot(aVec, bVec));
            Vector3 ansXYZ = a.w * bVec + b.w * aVec + aVec + bVec;
            result = new Quaternion(ansXYZ.x, ansXYZ.y, ansXYZ.z, ansW);

            return result;
        }

        public void Rotate(float rag, Vector3 vec)
        {
            float sin = MathF.Sin(rag * 0.5f);
            Quaternion q = new Quaternion(vec.x * sin, vec.y * sin, vec.z * sin, MathF.Cos(rag * 0.5f));
            Quaternion r = new Quaternion(-vec.x * sin, -vec.y * sin, -vec.z * sin, MathF.Cos(rag * 0.5f));

            Quaternion result = r * this * q;
            this.x = result.x;
            this.y = result.y;
            this.z = result.z;
            this.w = result.w;
        }
    }
}
