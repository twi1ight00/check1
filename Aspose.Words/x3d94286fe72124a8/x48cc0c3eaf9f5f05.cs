using System;
using System.Drawing;
using x6c95d9cf46ff5f25;

namespace x3d94286fe72124a8;

internal class x48cc0c3eaf9f5f05
{
	private float x0ec2f946403639f7;

	private float x301c1d1c0870d859;

	private bool x16e445e8252a64d8;

	internal float x73539c44b735b7aa
	{
		get
		{
			return x0ec2f946403639f7;
		}
		set
		{
			x0ec2f946403639f7 = value;
		}
	}

	internal float x8e8f6cc6a0756b05
	{
		get
		{
			return x301c1d1c0870d859;
		}
		set
		{
			x301c1d1c0870d859 = value;
		}
	}

	internal bool x4d29b8b35306c675 => x16e445e8252a64d8;

	internal x48cc0c3eaf9f5f05()
	{
	}

	internal x48cc0c3eaf9f5f05(PointF point1, PointF point2)
	{
		if (x37d2d88f96f87b47.xe1aec5445964a68c(point1.X, point2.X))
		{
			x16e445e8252a64d8 = true;
			x8e8f6cc6a0756b05 = point1.X;
		}
		else
		{
			x73539c44b735b7aa = (point1.Y - point2.Y) / (point1.X - point2.X);
			x8e8f6cc6a0756b05 = point1.Y - x73539c44b735b7aa * point1.X;
		}
	}

	internal float x29b834e8e9ff09ed(float x08db3aeabb253cb1)
	{
		if (!x4d29b8b35306c675)
		{
			return x73539c44b735b7aa * x08db3aeabb253cb1 + x8e8f6cc6a0756b05;
		}
		return x8e8f6cc6a0756b05;
	}

	internal bool xaaf7cfb8dd3fd335(PointF x2f7096dac971d6ec)
	{
		if (!x4d29b8b35306c675)
		{
			return x29b834e8e9ff09ed(x2f7096dac971d6ec.X) < x2f7096dac971d6ec.Y;
		}
		return x8e8f6cc6a0756b05 < x2f7096dac971d6ec.X;
	}

	internal x48cc0c3eaf9f5f05 x71e88a3412cd7edf(float xf7b90603456caad3)
	{
		float num;
		if (x73539c44b735b7aa == 0f)
		{
			num = xf7b90603456caad3;
		}
		else
		{
			float num2 = (float)Math.Abs(Math.Cos(Math.Atan(x73539c44b735b7aa)));
			num = xf7b90603456caad3 / num2;
		}
		x48cc0c3eaf9f5f05 x48cc0c3eaf9f5f6 = new x48cc0c3eaf9f5f05();
		x48cc0c3eaf9f5f6.x16e445e8252a64d8 = x4d29b8b35306c675;
		x48cc0c3eaf9f5f6.x73539c44b735b7aa = x73539c44b735b7aa;
		x48cc0c3eaf9f5f6.x8e8f6cc6a0756b05 = x8e8f6cc6a0756b05 + num;
		return x48cc0c3eaf9f5f6;
	}

	internal x48cc0c3eaf9f5f05 xe2785bbd7d56b3ec(PointF x2f7096dac971d6ec)
	{
		return xe2785bbd7d56b3ec(x2f7096dac971d6ec, x52b5c3dbae524a58: false);
	}

	internal x48cc0c3eaf9f5f05 xe2785bbd7d56b3ec(PointF x2f7096dac971d6ec, bool x52b5c3dbae524a58)
	{
		x48cc0c3eaf9f5f05 x48cc0c3eaf9f5f6 = new x48cc0c3eaf9f5f05();
		if (x4d29b8b35306c675)
		{
			if (x52b5c3dbae524a58 && !x37d2d88f96f87b47.xe1aec5445964a68c(x2f7096dac971d6ec.X, x8e8f6cc6a0756b05))
			{
				return null;
			}
			return new x48cc0c3eaf9f5f05(x2f7096dac971d6ec, new PointF(x2f7096dac971d6ec.X + 1f, x2f7096dac971d6ec.Y));
		}
		if (x73539c44b735b7aa == 0f)
		{
			if (x52b5c3dbae524a58 && !x37d2d88f96f87b47.xe1aec5445964a68c(x2f7096dac971d6ec.Y, x8e8f6cc6a0756b05))
			{
				return null;
			}
			x48cc0c3eaf9f5f6.x16e445e8252a64d8 = true;
			x48cc0c3eaf9f5f6.x8e8f6cc6a0756b05 = x2f7096dac971d6ec.X;
			return x48cc0c3eaf9f5f6;
		}
		if (x52b5c3dbae524a58 && !x37d2d88f96f87b47.xe1aec5445964a68c(x29b834e8e9ff09ed(x2f7096dac971d6ec.X), x2f7096dac971d6ec.Y))
		{
			return null;
		}
		x48cc0c3eaf9f5f6.x73539c44b735b7aa = -1f / x73539c44b735b7aa;
		x48cc0c3eaf9f5f6.x8e8f6cc6a0756b05 = x2f7096dac971d6ec.X * (x73539c44b735b7aa - x48cc0c3eaf9f5f6.x73539c44b735b7aa) + x8e8f6cc6a0756b05;
		return x48cc0c3eaf9f5f6;
	}

	internal x48cc0c3eaf9f5f05 xf4301eca7520f49c(PointF x2f7096dac971d6ec)
	{
		x48cc0c3eaf9f5f05 x48cc0c3eaf9f5f6 = new x48cc0c3eaf9f5f05();
		if (x4d29b8b35306c675)
		{
			x48cc0c3eaf9f5f6.x16e445e8252a64d8 = true;
			x48cc0c3eaf9f5f6.x8e8f6cc6a0756b05 = x2f7096dac971d6ec.X;
			return x48cc0c3eaf9f5f6;
		}
		x48cc0c3eaf9f5f6.x73539c44b735b7aa = x73539c44b735b7aa;
		x48cc0c3eaf9f5f6.x8e8f6cc6a0756b05 = x2f7096dac971d6ec.Y - x73539c44b735b7aa * x2f7096dac971d6ec.X;
		return x48cc0c3eaf9f5f6;
	}

	internal bool xbd0a2eed2aaf0366(PointF x2f7096dac971d6ec)
	{
		if (x4d29b8b35306c675)
		{
			return x37d2d88f96f87b47.xe1aec5445964a68c(x2f7096dac971d6ec.X, x8e8f6cc6a0756b05);
		}
		return x37d2d88f96f87b47.xe1aec5445964a68c(x2f7096dac971d6ec.Y, x29b834e8e9ff09ed(x2f7096dac971d6ec.X));
	}

	internal void x4a4f2059e53968cf(PointF x337e217cb3ba0627, float xf7b90603456caad3, PointF[] x7d95d971d8923f4c)
	{
		x4a4f2059e53968cf(x337e217cb3ba0627, xf7b90603456caad3, x7d95d971d8923f4c, xb29f645aa9b0f989: false);
	}

	internal bool x4a4f2059e53968cf(PointF x337e217cb3ba0627, float xf7b90603456caad3, PointF[] x7d95d971d8923f4c, bool xb29f645aa9b0f989)
	{
		if (xb29f645aa9b0f989 && !xbd0a2eed2aaf0366(x337e217cb3ba0627))
		{
			return false;
		}
		if (x4d29b8b35306c675)
		{
			ref PointF reference = ref x7d95d971d8923f4c[0];
			reference = new PointF(x337e217cb3ba0627.X, x337e217cb3ba0627.Y + xf7b90603456caad3);
			return true;
		}
		if (x73539c44b735b7aa < 0f)
		{
			xf7b90603456caad3 *= -1f;
		}
		double num = Math.Atan(x73539c44b735b7aa);
		float x = (float)(Math.Cos(num) * (double)xf7b90603456caad3 + (double)x337e217cb3ba0627.X);
		float y = (float)(Math.Sin(num) * (double)xf7b90603456caad3 + (double)x337e217cb3ba0627.Y);
		ref PointF reference2 = ref x7d95d971d8923f4c[0];
		reference2 = new PointF(x, y);
		return true;
	}

	internal static bool x33f7244befbb6e65(x48cc0c3eaf9f5f05 x7f5704d71690aff8, x48cc0c3eaf9f5f05 xef563966899b6b32)
	{
		if (x7f5704d71690aff8.x4d29b8b35306c675 && xef563966899b6b32.x4d29b8b35306c675)
		{
			return true;
		}
		if (x37d2d88f96f87b47.xe1aec5445964a68c(x7f5704d71690aff8.x73539c44b735b7aa, xef563966899b6b32.x73539c44b735b7aa) && !x7f5704d71690aff8.x4d29b8b35306c675 && !xef563966899b6b32.x4d29b8b35306c675)
		{
			return true;
		}
		return false;
	}

	internal static void x07aa36934bec95f1(x48cc0c3eaf9f5f05 x7f5704d71690aff8, x48cc0c3eaf9f5f05 xef563966899b6b32, PointF[] x6fa2570084b2ad39)
	{
		x07aa36934bec95f1(x7f5704d71690aff8, xef563966899b6b32, x6fa2570084b2ad39, xf6b46a641abf7d02: false);
	}

	internal static bool x07aa36934bec95f1(x48cc0c3eaf9f5f05 x7f5704d71690aff8, x48cc0c3eaf9f5f05 xef563966899b6b32, PointF[] x6fa2570084b2ad39, bool xf6b46a641abf7d02)
	{
		if (xf6b46a641abf7d02 && x33f7244befbb6e65(x7f5704d71690aff8, xef563966899b6b32))
		{
			return false;
		}
		float num;
		float y;
		if (x7f5704d71690aff8.x4d29b8b35306c675)
		{
			num = x7f5704d71690aff8.x8e8f6cc6a0756b05;
			y = xef563966899b6b32.x29b834e8e9ff09ed(num);
		}
		else if (xef563966899b6b32.x4d29b8b35306c675)
		{
			num = xef563966899b6b32.x8e8f6cc6a0756b05;
			y = x7f5704d71690aff8.x29b834e8e9ff09ed(num);
		}
		else
		{
			num = (xef563966899b6b32.x8e8f6cc6a0756b05 - x7f5704d71690aff8.x8e8f6cc6a0756b05) / (x7f5704d71690aff8.x73539c44b735b7aa - xef563966899b6b32.x73539c44b735b7aa);
			y = x7f5704d71690aff8.x73539c44b735b7aa * num + x7f5704d71690aff8.x8e8f6cc6a0756b05;
		}
		ref PointF reference = ref x6fa2570084b2ad39[0];
		reference = new PointF(num, y);
		return true;
	}

	internal static x48cc0c3eaf9f5f05 x45a443e47a0dd312(PointF x2f7096dac971d6ec, bool x294960ca9b3799f2)
	{
		return new x48cc0c3eaf9f5f05(x2f7096dac971d6ec, new PointF(x2f7096dac971d6ec.X + (float)(x294960ca9b3799f2 ? 1 : 0), x2f7096dac971d6ec.Y + (float)((!x294960ca9b3799f2) ? 1 : 0)));
	}
}
