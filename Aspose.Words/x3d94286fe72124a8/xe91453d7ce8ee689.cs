using System.Drawing;
using x1c8faa688b1f0b0c;
using x6c95d9cf46ff5f25;

namespace x3d94286fe72124a8;

internal class xe91453d7ce8ee689
{
	private readonly x67293147609631f8 x086a4431cc15d09e;

	private readonly PointF xcca67f5cea5de66e;

	private readonly PointF x5e105f96b2e48233;

	private readonly PointF x57ed7dca62c4ea34;

	internal x67293147609631f8 x56b911bdb6515aed => x086a4431cc15d09e;

	internal PointF x1553750ef11ea3bd => xcca67f5cea5de66e;

	internal PointF x6327cc1340abe864 => x5e105f96b2e48233;

	internal PointF x57b4a37fc3a75e2d => x57ed7dca62c4ea34;

	internal xe91453d7ce8ee689(x67293147609631f8 curve)
	{
		x086a4431cc15d09e = curve;
		xcca67f5cea5de66e = new PointF(x03b0b48f8a5eef4d(curve, xbd83cce6637b3d29: true), x03b0b48f8a5eef4d(curve, xbd83cce6637b3d29: false));
		x5e105f96b2e48233 = new PointF(xac9a08e61a198ace(curve, xbd83cce6637b3d29: true), xac9a08e61a198ace(curve, xbd83cce6637b3d29: false));
		x57ed7dca62c4ea34 = curve.xaf4e0fbe61814cf5;
	}

	internal PointF x4e38d47a828e5204(float x3201d6d15a947682)
	{
		if (x3201d6d15a947682 < 0f || x3201d6d15a947682 > 1f)
		{
			return PointF.Empty;
		}
		if (x3201d6d15a947682 == 0f)
		{
			return x086a4431cc15d09e.xaf4e0fbe61814cf5;
		}
		if (x3201d6d15a947682 == 1f)
		{
			return x086a4431cc15d09e.x2271dea312f4a835;
		}
		float x = x73aa8903cd5258e6(x3201d6d15a947682, xbd83cce6637b3d29: true);
		float y = x73aa8903cd5258e6(x3201d6d15a947682, xbd83cce6637b3d29: false);
		return new PointF(x, y);
	}

	private float x73aa8903cd5258e6(float x3201d6d15a947682, bool xbd83cce6637b3d29)
	{
		float num = (xbd83cce6637b3d29 ? xcca67f5cea5de66e.X : xcca67f5cea5de66e.Y);
		float num2 = (xbd83cce6637b3d29 ? x5e105f96b2e48233.X : x5e105f96b2e48233.Y);
		float num3 = (xbd83cce6637b3d29 ? x57ed7dca62c4ea34.X : x57ed7dca62c4ea34.Y);
		return num * x37d2d88f96f87b47.x113cf57ce1569d99(x3201d6d15a947682) + x3201d6d15a947682 * num2 + num3;
	}

	private static float x03b0b48f8a5eef4d(x67293147609631f8 xb4b05b124e47bc0f, bool xbd83cce6637b3d29)
	{
		float[] array = x4ec23f34abd3389e(xb4b05b124e47bc0f, xbd83cce6637b3d29);
		float num = array[0];
		float num2 = array[1];
		float num3 = array[2];
		return num - 2f * num2 + num3;
	}

	private static float xac9a08e61a198ace(x67293147609631f8 xb4b05b124e47bc0f, bool xbd83cce6637b3d29)
	{
		float[] array = x4ec23f34abd3389e(xb4b05b124e47bc0f, xbd83cce6637b3d29);
		float num = array[0];
		float num2 = array[1];
		return -2f * num + 2f * num2;
	}

	private static float[] x4ec23f34abd3389e(x67293147609631f8 xb4b05b124e47bc0f, bool xbd83cce6637b3d29)
	{
		return new float[3]
		{
			xbd83cce6637b3d29 ? xb4b05b124e47bc0f.xaf4e0fbe61814cf5.X : xb4b05b124e47bc0f.xaf4e0fbe61814cf5.Y,
			xbd83cce6637b3d29 ? xb4b05b124e47bc0f.x2f997a78d547d657.X : xb4b05b124e47bc0f.x2f997a78d547d657.Y,
			xbd83cce6637b3d29 ? xb4b05b124e47bc0f.x2271dea312f4a835.X : xb4b05b124e47bc0f.x2271dea312f4a835.Y
		};
	}
}
