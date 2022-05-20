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
    }
}
