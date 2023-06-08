using System;
using System.Drawing;
using x1c8faa688b1f0b0c;

namespace x7a30b7d81100c71a;

internal class x558a6a0d6c7e9c59
{
	internal static double xbd53fd6731398f37(x9fe47a4de491f4aa xb4b05b124e47bc0f, float x13d4cb8d1bd20347)
	{
		double num = 1f - x13d4cb8d1bd20347;
		double num2 = Math.Pow(num, 2.0);
		double num3 = Math.Pow(x13d4cb8d1bd20347, 2.0);
		double num4 = (double)(-3f * xb4b05b124e47bc0f.xaf4e0fbe61814cf5.X) * num2 + (double)(3f * xb4b05b124e47bc0f.xc7cf0e43653f9c41.X) * num * (double)(1f - 3f * x13d4cb8d1bd20347) + (double)(3f * xb4b05b124e47bc0f.xf52fe1c3cad11afd.X * x13d4cb8d1bd20347 * (2f - 3f * x13d4cb8d1bd20347)) + (double)(3f * xb4b05b124e47bc0f.x2271dea312f4a835.X) * num3;
		double num5 = (double)(-3f * xb4b05b124e47bc0f.xaf4e0fbe61814cf5.Y) * num2 + (double)(3f * xb4b05b124e47bc0f.xc7cf0e43653f9c41.Y) * num * (double)(1f - 3f * x13d4cb8d1bd20347) + (double)(3f * xb4b05b124e47bc0f.xf52fe1c3cad11afd.Y * x13d4cb8d1bd20347 * (2f - 3f * x13d4cb8d1bd20347)) + (double)(3f * xb4b05b124e47bc0f.x2271dea312f4a835.Y) * num3;
		double num6 = (double)(6f * xb4b05b124e47bc0f.xaf4e0fbe61814cf5.X) * num - (double)(6f * xb4b05b124e47bc0f.xc7cf0e43653f9c41.X * (2f - 3f * x13d4cb8d1bd20347)) + (double)(6f * xb4b05b124e47bc0f.xf52fe1c3cad11afd.X * (1f - 3f * x13d4cb8d1bd20347)) + (double)(6f * xb4b05b124e47bc0f.x2271dea312f4a835.X * x13d4cb8d1bd20347);
		double num7 = (double)(6f * xb4b05b124e47bc0f.xaf4e0fbe61814cf5.Y) * num - (double)(6f * xb4b05b124e47bc0f.xc7cf0e43653f9c41.Y * (2f - 3f * x13d4cb8d1bd20347)) + (double)(6f * xb4b05b124e47bc0f.xf52fe1c3cad11afd.Y * (1f - 3f * x13d4cb8d1bd20347)) + (double)(6f * xb4b05b124e47bc0f.x2271dea312f4a835.Y * x13d4cb8d1bd20347);
		double num8 = Math.Pow(num4, 2.0);
		double num9 = Math.Pow(num5, 2.0);
		return Math.Abs((num4 * num7 - num6 * num5) / Math.Pow(num8 + num9, 1.5));
	}

	internal static double xc4e956a5affaf561(x9fe47a4de491f4aa xb4b05b124e47bc0f)
	{
		double num = 0.0;
		PointF pointF = x1966e8937604bce4(xb4b05b124e47bc0f, 0f);
		for (float num2 = 0.1f; num2 <= 1f; num2 += 0.1f)
		{
			PointF pointF2 = pointF;
			pointF = x1966e8937604bce4(xb4b05b124e47bc0f, num2);
			num += Math.Sqrt(Math.Pow(pointF2.X - pointF.X, 2.0) + Math.Pow(pointF2.Y - pointF.Y, 2.0));
		}
		return num;
	}

	internal static PointF x1966e8937604bce4(x9fe47a4de491f4aa xb4b05b124e47bc0f, float x13d4cb8d1bd20347)
	{
		float num = 1f - x13d4cb8d1bd20347;
		double num2 = Math.Pow(num, 2.0);
		double num3 = Math.Pow(num, 3.0);
		double num4 = Math.Pow(x13d4cb8d1bd20347, 2.0);
		double num5 = Math.Pow(x13d4cb8d1bd20347, 3.0);
		PointF result = new PointF((float)((double)xb4b05b124e47bc0f.xaf4e0fbe61814cf5.X * num3 + (double)(3f * x13d4cb8d1bd20347) * num2 * (double)xb4b05b124e47bc0f.xc7cf0e43653f9c41.X + 3.0 * num4 * (double)num * (double)xb4b05b124e47bc0f.xf52fe1c3cad11afd.X + num5 * (double)xb4b05b124e47bc0f.x2271dea312f4a835.X), (float)((double)xb4b05b124e47bc0f.xaf4e0fbe61814cf5.Y * num3 + (double)(3f * x13d4cb8d1bd20347) * num2 * (double)xb4b05b124e47bc0f.xc7cf0e43653f9c41.Y + 3.0 * num4 * (double)num * (double)xb4b05b124e47bc0f.xf52fe1c3cad11afd.Y + num5 * (double)xb4b05b124e47bc0f.x2271dea312f4a835.Y));
		return result;
	}
}
