using System;
using System.Collections.Generic;

namespace My
{
    struct VectorN
    {
        public float[] n;

        public String Text
        {
            get
            {
                string result = "";
                foreach (float i in n)
                    result += i + "i, ";
                return result;
            }
        }

        /// <summary>
        /// 引数が複数、もしくは明示的にfloat型宣言した場合、要素として代入、
        /// int型のみにした場合要素数として生成
        /// </summary>
        /// <param name="values"></param>
        public VectorN(params float[] values)
        {
            this.n = values;
        }
        public VectorN(int elements)
        {
            this.n = new float[elements];
        }

        /// <summary>
        /// 指定した要素数の0を代入したVectorNを生成
        /// </summary>
        /// <param name="n">要素数</param>
        /// <returns></returns>
        public static VectorN Zero(int n)
        {
            float[] result = new float[n];
            for (int i = 0; i < n; i++)
            {
                result[i] = 0;
            }
            return new VectorN(result);
        }

        public override string ToString()
        { 
            string result = "[";
            foreach (float i in n)
            {
                result += i + " ";
            }
            result += "]";
            return result;
        }

        public static VectorN operator +(VectorN a, VectorN b)
        {
            int len = a.n.Length < b.n.Length ? a.n.Length : b.n.Length;
            for (int i = 0; i < len; i++)
            {
                a.n[i] += b.n[i];
            }
            return a;
        }
        public static VectorN operator -(VectorN a, VectorN b)
        {
            int len = a.n.Length < b.n.Length ? a.n.Length : b.n.Length;
            for (int i = 0; i < len; i++)
            {
                a.n[i] -= b.n[i];
            }
            return a;
        }
        public static VectorN operator *(VectorN a, VectorN b)
        {
            int len = a.n.Length < b.n.Length ? a.n.Length : b.n.Length;
            for (int i = 0; i < len; i++)
            {
                a.n[i] *= b.n[i];
            }
            return a;
        }
        public static VectorN operator /(VectorN a, VectorN b)
        {
            int len = a.n.Length < b.n.Length ? a.n.Length : b.n.Length;
            for (int i = 0; i < len; i++)
            {
                a.n[i] /= b.n[i];
            }
            return a;
        }
    }
}
