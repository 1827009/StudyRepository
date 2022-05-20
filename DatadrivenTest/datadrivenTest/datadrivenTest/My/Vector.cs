using System;
using System.Collections.Generic;
using System.Text;

namespace My
{
    struct Vector3
    {
        public float x;
        public float y;
        public float z;
        public static readonly Vector3 ZERO = new Vector3(0, 0, 0);
        public static readonly Vector3 ONE = new Vector3(1, 1, 1);

        public Vector2 xy
        {
            get { return new Vector2(x, y); }
        }

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public Vector3(Vector3 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
        }

        public override string ToString()
        {
            return "(" + x + ", " + y + ", " + z + ")\r\n";
        }

        public static Vector3 Lerp(Vector3 start, Vector3 end, float now)
        {
            Vector3 vec = (end - start)*now;
            return start + vec;
        }

        public static Vector3 Cross(Vector3 a, Vector3 b)
        {
            Vector3 result;
            result.x = a.y * b.z - b.y * a.z;
            result.y = -a.x * b.z + b.x * a.z;
            result.z = a.x * b.y - b.x * a.y;
            return result;
        }

        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            Vector3 output;
            output.x = a.x + b.x;
            output.y = a.y + b.y;
            output.z = a.z + b.z;
            return output;
        }
        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            Vector3 output;
            output.x = a.x - b.x;
            output.y = a.y - b.y;
            output.z = a.z - b.z;
            return output;
        }
        public static Vector3 operator *(Vector3 a, Vector3 b)
        {
            Vector3 output;
            output.x = a.x * b.x;
            output.y = a.y * b.y;
            output.z = a.z * b.z;
            return output;
        }
        public static Vector3 operator *(Vector3 a, float b)
        {
            Vector3 output;
            output.x = a.x * b;
            output.y = a.y * b;
            output.z = a.z * b;
            return output;
        }
        public static Vector3 operator /(Vector3 a, float b)
        {
            Vector3 output = a;
            if (a.x != 0)
                output.x = a.x / b;
            if (a.y != 0)
                output.y = a.y / b;
            if (a.z != 0)
                output.z = a.z / b;
            return output;
        }

        public static Matrix4x4 CreateTrancerate(Vector3 vec)
        {
            return new Matrix4x4(
                1, 0, 0, 0,
                0, 1, 0, 0,
                0, 0, 1, 0,
                vec.x, vec.y, vec.z, 1
                );
        }
    }
    struct Vector2
    {
        public float x;
        public float y;
        public static readonly Vector2 ZERO = new Vector2(0, 0);
        public static readonly Vector2 ONE = new Vector2(1, 1);

        public Vector3 xy0
        {
            get { return new Vector3(x, y, 0); }
        }

        public override string ToString()
        {
            return "(" + x + ", " + y + ")";
        }

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
        public Vector2(Vector2 v)
        {
            this.x = v.x;
            this.y = v.y;
        }
        public static Vector2 Lerp(Vector2 start, Vector2 end, float now)
        {
            Vector2 vec = (end - start) * now;
            return start + vec;
        }

        public static Vector2 BrendLerp(Vector2 start, Vector2 end, Vector2 brend, float now)
        {
            Vector2 vec = Vector2.Lerp(start, end, now);
            Vector2 brendVec = Vector2.Lerp(brend, end, now);
            return Vector2.Lerp(vec, brendVec, now);
        }

        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            Vector2 output;
            output.x = a.x + b.x;
            output.y = a.y + b.y;
            return output;
        }
        public static Vector2 operator +(Vector2 a, Vector3 b)
        {
            Vector2 output;
            output.x = a.x + b.x;
            output.y = a.y + b.y;
            return output;
        }
        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            Vector2 output;
            output.x = a.x - b.x;
            output.y = a.y - b.y;
            return output;
        }
        public static Vector2 operator *(Vector2 a, float b)
        {
            Vector2 output = a;
            if (a.x != 0)
                output.x = a.x * b;
            if (a.y != 0)
                output.y = a.y * b;
            return output;
        }
        public static Vector2 operator *(float b, Vector2 a)
        {
            Vector2 output = a;
            if (a.x != 0)
                output.x = a.x * b;
            if (a.y != 0)
                output.y = a.y * b;
            return output;
        }
        public static Vector2 operator /(Vector2 a, float b)
        {
            Vector2 output = a;
            if (a.x != 0)
                output.x = a.x / b;
            if (a.y != 0)
                output.y = a.y / b;
            return output;
        }

        public static Matrix3x3 CreateTrancerate(Vector2 vec)
        {
            return new Matrix3x3(
                1, 0, 0,
                0, 1, 0,
                vec.x, vec.y, 1
                );
        }
    }
}
