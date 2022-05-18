using System;
using System.Collections.Generic;

namespace My
{
    struct MatrixMxN
    {
        public float[][] matrix;

        public VectorN Translation
        {
            get
            {
                float[] result=new float[matrix.Length - 1];
                Array.Copy(matrix[matrix.Length - 1],0,result,0, matrix.Length - 1);
                return new VectorN(result);
            }
            set
            {
                float[] result = new float[matrix.Length];
                for (int i = 0; i < matrix[matrix.Length - 1].Length; i++)
                {
                    result[i] = i < matrix[matrix.Length - 1].Length - 1 ? value.n[i] : matrix[matrix.Length - 1][matrix.Length - 1];
                }
                matrix[matrix.Length - 1] = result;
            }
        }

        public MatrixMxN(int m, int n)
        {
            matrix = new float[m][];
            for (int i = 0; i < m; i++)
            {
                matrix[i] = new float[n];
                for (int j = 0; j < n; j++)
                {
                    matrix[i][j] = 0;
                }
            }
        }

        public override string ToString()
        {
            string result="";
            foreach (float[] i in matrix)
            {
                result += "[";
                foreach (float j in i)
                {
                    result += j + " ";
                }
                result += "]\r\n";
            }
            return result;
        }

        public static MatrixMxN Identity(int dimension)
        {
            MatrixMxN result = new MatrixMxN(dimension, dimension);
            for (int i = 0; i < dimension; i++)
            {
                result.matrix[i][i] = 1;
            }
            return result;
        }

        public static MatrixMxN operator *(MatrixMxN a, MatrixMxN b)
        {
            if (a.matrix.Length != b.matrix[0].Length)
                throw new MatrixSizeErrer();

            MatrixMxN result=new MatrixMxN(a.matrix[0].Length, b.matrix.Length);

            for (int i = 0; i < result.matrix.Length; i++)
            {
                for (int j = 0; j < result.matrix[0].Length; j++)
                {
                    float temp = 0;
                    for (int k = 0; k < a.matrix.Length; k++)
                    {
                        temp += a.matrix[k][i] * b.matrix[j][k];

                    }
                    result.matrix[j][i] = temp;
                }

            }

            return result;
        }

        public static VectorN operator *(VectorN a, MatrixMxN b)
        {
            if(a.n.Length!=b.matrix[0].Length)
                throw new MatrixSizeErrer();

            VectorN result = new VectorN(b.matrix.Length);

            for (int i = 0; i < b.matrix.Length; i++)
            {
                float temp = 0;
                for (int j = 0; j < a.n.Length; j++)
                {
                    temp += a.n[j] * b.matrix[i][j];

                }
                result.n[i] = temp;
            }

            return result;
        }

    }

    [Serializable()]
    class MatrixSizeErrer: Exception
    {
        public MatrixSizeErrer()
        {
            System.Diagnostics.Debug.WriteLine("左辺の行の要素数と左辺の列の要素数が一致しません");
        }
    }
}
