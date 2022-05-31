using System;
using System.Collections.Generic;
using System.Text;

namespace My
{
    class SplineLerp
    {
        public static float Spline(float x, params Vector2[] pnt)
		{
			int N = pnt.Length;
			int idx = -1, k;
			float[] h=new float[N - 1],
				b = new float[N - 1],
				d = new float[N - 1],
				g = new float[N - 1],
				u = new float[N - 1],
				r = new float[N];

			int i;
			for (i = 1; i < N - 1 && idx < 0; i++)
			{
				if (x < pnt[i].x)
					idx = i - 1;
			}

			if (idx < 0)
				idx = N - 2;

			for (i = 0; i < N - 1; i++)
			{
				h[i] = pnt[i + 1].x - pnt[i].x;
			}

			for (i = 1; i < N - 1; i++)
			{
				b[i] = 2.0f * (h[i] + h[i - 1]);
				d[i] = 3.0f * ((pnt[i + 1].y - pnt[i].y) / h[i] - (pnt[i].y - pnt[i - 1].y) / h[i - 1]);
			}

			g[1] = h[1] / b[1];

			for (i = 2; i < N - 2; i++)
			{
				g[i] = h[i] / (b[i] - h[i - 1] * g[i - 1]);
			}

			u[1] = d[1] / b[1];

			for (i = 2; i < N - 1; i++)
			{
				u[i] = (d[i] - h[i - 1] * u[i - 1]) / (b[i] - h[i - 1] * g[i - 1]);
			}

			if (idx > 1)
			{
				k = idx;
			}
			else
			{
				k = 1;
			}

			r[0] = 0.0f;
			r[N - 1] = 0.0f;
			r[N - 2] = u[N - 2];

			for (i = N - 3; i >= k; i--)
			{
				r[i] = u[i] - g[i] * r[i + 1];
			}

			float dx = x - pnt[idx].x;
			float q = (pnt[idx + 1].y - pnt[idx].y) / h[idx] - h[idx] * (r[idx + 1] + 2.0f * r[idx]) / 3.0f;
			float s = (r[idx + 1] - r[idx]) / (3.0f * h[idx]);

			return pnt[idx].y + dx * (q + dx * (r[idx] + s * dx));
		}

		public SplineLerp(List<float> y)
        {
			InitParametre(y);
		}
		public SplineLerp(params float[] y)
		{
			InitParametre(new List<float>(y));
		}

		public float Calc(float t)
        {
			int j = (int)(MathF.Floor(t));
			if (j < 0)
			{
				j = 0;
			}
			else if (j >= a_.Count)
            {
				j = (a_.Count - 1);
            }
			float dt = t - j;
			float result = a_[j] + (b_[j] + (c_[j] + d_[j] * dt) * dt) * dt;
			return result;
        }

		List<float> a_ = new List<float>();
		List<float> b_ = new List<float>();
		List<float> c_ = new List<float>();
		List<float> d_ = new List<float>();
		List<float> w_ = new List<float>();

		void InitParametre(List<float> y)
		{
			int ndata = y.Count - 1;

            for (int i = 0; i < ndata; i++)
            {
                if (i==0)
                {
					c_.Add(0f);
                }
				else if (i == ndata)
                {
					c_.Add(0f);
				}
				else
				{
					c_.Add(3f * (a_[i - 1] - 2f * a_[i] + a_[i + 1]));
				}
			}

            for (int i = 0; i < ndata; i++)
            {
                if (i == 0)
                {
					w_.Add(0f);
                }
                else
                {
					float tmp = 4f - w_[i - 1];
					c_[i] = (c_[i] - c_[i - 1]) / tmp;
					w_.Add(1f / tmp);
                }
            }

            for (int i = (ndata-1); i < 0; i--)
            {
				c_[i] = c_[i] - c_[i + 1] * w_[i];
            }

            for (int i = 0; i <= ndata; i++)
            {
                if (i == ndata)
                {
					d_.Add(0f);
					b_.Add(0f);
                }
                else
                {
					d_.Add((c_[i + 1] - c_[i]) / 3f);
					b_.Add(a_[i + 1] - a_[i] - c_[i] - d_[i]);
                }
            }
		}
	}
}
