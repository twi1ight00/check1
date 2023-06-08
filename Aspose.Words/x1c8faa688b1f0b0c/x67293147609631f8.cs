using System;
using System.Drawing;
using x6c95d9cf46ff5f25;

namespace x1c8faa688b1f0b0c;

internal struct x67293147609631f8
{
	private PointF x92be23f9da255ff5;

	private PointF x779a6174a9539acc;

	private PointF x1eb0f2079082dc31;

	public PointF xaf4e0fbe61814cf5
	{
		get
		{
			return x92be23f9da255ff5;
		}
		set
		{
			x92be23f9da255ff5 = value;
		}
	}

	public PointF x2f997a78d547d657
	{
		get
		{
			return x779a6174a9539acc;
		}
		set
		{
			x779a6174a9539acc = value;
		}
	}

	public PointF x2271dea312f4a835
	{
		get
		{
			return x1eb0f2079082dc31;
		}
		set
		{
			x1eb0f2079082dc31 = value;
		}
	}

	public float x1deebb03a3d03a50()
	{
		PointF pointF = new PointF(x92be23f9da255ff5.X - 2f * x779a6174a9539acc.X + x1eb0f2079082dc31.X, x92be23f9da255ff5.Y - 2f * x779a6174a9539acc.Y + x1eb0f2079082dc31.Y);
		if (pointF.IsEmpty)
		{
			return (float)Math.Sqrt(x37d2d88f96f87b47.x113cf57ce1569d99(x1eb0f2079082dc31.X - x92be23f9da255ff5.X) + x37d2d88f96f87b47.x113cf57ce1569d99(x1eb0f2079082dc31.Y - x92be23f9da255ff5.Y));
		}
		PointF pointF2 = new PointF(2f * x779a6174a9539acc.X - 2f * x92be23f9da255ff5.X, 2f * x779a6174a9539acc.Y - 2f * x92be23f9da255ff5.Y);
		float num = 4f * (pointF.X * pointF.X + pointF.Y * pointF.Y);
		float num2 = 4f * (pointF.X * pointF2.X + pointF.Y * pointF2.Y);
		float num3 = pointF2.X * pointF2.X + pointF2.Y * pointF2.Y;
		double num4 = 2.0 * Math.Sqrt(num + num2 + num3);
		double num5 = Math.Sqrt(num);
		double num6 = (double)(2f * num) * num5;
		double num7 = 2.0 * Math.Sqrt(num3);
		double num8 = (double)num2 / num5;
		return (float)((num6 * num4 + num5 * (double)num2 * (num4 - num7) + (double)(4f * num3 * num - num2 * num2) * Math.Log((2.0 * num5 + num8 + num4) / (num8 + num7))) / (4.0 * num6));
	}
}
