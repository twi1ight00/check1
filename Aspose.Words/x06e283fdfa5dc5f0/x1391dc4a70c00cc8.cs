using System.Drawing;
using x1c8faa688b1f0b0c;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;

namespace x06e283fdfa5dc5f0;

internal class x1391dc4a70c00cc8
{
	internal static xab391c46ff9a0a38 x993ecefe54fbc5b2(PointF x10aaa7cdfa38f254, PointF xca09b6c2b5b18485, float x9b0739496f8b5475, x26d9ecb4bdf0456d x6c50a99faab7d741)
	{
		return x993ecefe54fbc5b2(x10aaa7cdfa38f254, xca09b6c2b5b18485, new x31c19fcb724dfaf5(x6c50a99faab7d741, x9b0739496f8b5475));
	}

	internal static xab391c46ff9a0a38 x993ecefe54fbc5b2(PointF x10aaa7cdfa38f254, PointF xca09b6c2b5b18485, x31c19fcb724dfaf5 x90279591611601bc)
	{
		xab391c46ff9a0a38 xab391c46ff9a0a = xab391c46ff9a0a38.xb471d14948c54f27(x10aaa7cdfa38f254, xca09b6c2b5b18485);
		xab391c46ff9a0a.x9e5d5f9128c69a8f = x90279591611601bc;
		return xab391c46ff9a0a;
	}

	internal static xab391c46ff9a0a38 x6cd6f35dd96985c5(PointF x10aaa7cdfa38f254, PointF xca09b6c2b5b18485, float x9b0739496f8b5475, x26d9ecb4bdf0456d x6c50a99faab7d741, bool x294960ca9b3799f2)
	{
		xab391c46ff9a0a38 xab391c46ff9a0a = new xab391c46ff9a0a38(new x31c19fcb724dfaf5(x6c50a99faab7d741));
		float x961016a387451f = x1deebb03a3d03a50(x10aaa7cdfa38f254, xca09b6c2b5b18485, x294960ca9b3799f2);
		xab391c46ff9a0a.xd6b6ed77479ef68c(x9373151c34537b34(x10aaa7cdfa38f254, x961016a387451f, x9b0739496f8b5475, x294960ca9b3799f2));
		x323e603293c20c04(xab391c46ff9a0a, x10aaa7cdfa38f254, x961016a387451f, x9b0739496f8b5475 + 1.5f, x294960ca9b3799f2);
		return xab391c46ff9a0a;
	}

	internal static xab391c46ff9a0a38 x0229f5079884c4e4(PointF x10aaa7cdfa38f254, PointF xca09b6c2b5b18485, float x9b0739496f8b5475, x26d9ecb4bdf0456d x6c50a99faab7d741, bool x294960ca9b3799f2)
	{
		xab391c46ff9a0a38 xab391c46ff9a0a = new xab391c46ff9a0a38(new x31c19fcb724dfaf5(x6c50a99faab7d741));
		float x961016a387451f = x1deebb03a3d03a50(x10aaa7cdfa38f254, xca09b6c2b5b18485, x294960ca9b3799f2);
		PointF x10aaa7cdfa38f255;
		PointF x10aaa7cdfa38f256;
		if (x294960ca9b3799f2)
		{
			x10aaa7cdfa38f255 = new PointF(x10aaa7cdfa38f254.X, x10aaa7cdfa38f254.Y - x9b0739496f8b5475 * 0.25f);
			x10aaa7cdfa38f256 = new PointF(x10aaa7cdfa38f254.X, x10aaa7cdfa38f254.Y + x9b0739496f8b5475 * 0.25f);
		}
		else
		{
			x10aaa7cdfa38f255 = new PointF(x10aaa7cdfa38f254.X - x9b0739496f8b5475 * 0.25f, x10aaa7cdfa38f254.Y);
			x10aaa7cdfa38f256 = new PointF(x10aaa7cdfa38f254.X + x9b0739496f8b5475 * 0.25f, x10aaa7cdfa38f254.Y);
		}
		xab391c46ff9a0a.xd6b6ed77479ef68c(x9373151c34537b34(x10aaa7cdfa38f255, x961016a387451f, x9b0739496f8b5475 * 0.5f, x294960ca9b3799f2));
		xab391c46ff9a0a.xd6b6ed77479ef68c(x9373151c34537b34(x10aaa7cdfa38f256, x961016a387451f, x9b0739496f8b5475 * 0.5f, x294960ca9b3799f2));
		x323e603293c20c04(xab391c46ff9a0a, x10aaa7cdfa38f254, x961016a387451f, x9b0739496f8b5475 + 1.5f, x294960ca9b3799f2);
		return xab391c46ff9a0a;
	}

	private static x1cab6af0a41b70e2 x9373151c34537b34(PointF x10aaa7cdfa38f254, float x961016a387451f05, float x9b0739496f8b5475, bool x294960ca9b3799f2)
	{
		x1cab6af0a41b70e2 x1cab6af0a41b70e = new x1cab6af0a41b70e2();
		int num = (int)(x961016a387451f05 / x9b0739496f8b5475) + 2;
		float[] array = new float[num * 2];
		array[0] = x10aaa7cdfa38f254.X;
		array[1] = x10aaa7cdfa38f254.Y;
		if (x294960ca9b3799f2)
		{
			for (int i = 0; i < num - 1; i++)
			{
				array[i * 2 + 2] = x10aaa7cdfa38f254.X + (float)i * x9b0739496f8b5475 + x9b0739496f8b5475 / 2f;
				if (x0d299f323d241756.x7e32f71c3f39b6bc(i))
				{
					array[i * 2 + 3] = x10aaa7cdfa38f254.Y + x9b0739496f8b5475 / 2f;
				}
				else
				{
					array[i * 2 + 3] = x10aaa7cdfa38f254.Y - x9b0739496f8b5475 / 2f;
				}
			}
		}
		else
		{
			for (int j = 0; j < num - 1; j++)
			{
				if (x0d299f323d241756.x7e32f71c3f39b6bc(j))
				{
					array[j * 2 + 2] = x10aaa7cdfa38f254.X + x9b0739496f8b5475 / 2f;
				}
				else
				{
					array[j * 2 + 2] = x10aaa7cdfa38f254.X - x9b0739496f8b5475 / 2f;
				}
				array[j * 2 + 3] = x10aaa7cdfa38f254.Y + (float)j * x9b0739496f8b5475 + x9b0739496f8b5475 / 2f;
			}
		}
		x60c040f35bb272aa xda5bf54deb817e = new x60c040f35bb272aa(array);
		x1cab6af0a41b70e.xd6b6ed77479ef68c(xda5bf54deb817e);
		return x1cab6af0a41b70e;
	}

	internal static xab391c46ff9a0a38 x07cd9e4b459e78df(PointF x10aaa7cdfa38f254, PointF xca09b6c2b5b18485, float x9b0739496f8b5475, x26d9ecb4bdf0456d x6c50a99faab7d741, bool x294960ca9b3799f2)
	{
		xab391c46ff9a0a38 xab391c46ff9a0a = new xab391c46ff9a0a38(new x31c19fcb724dfaf5(x6c50a99faab7d741));
		float num = x9b0739496f8b5475 + 3f;
		PointF pointF = ((!x294960ca9b3799f2) ? new PointF(x10aaa7cdfa38f254.X + num / 2f, x10aaa7cdfa38f254.Y - num) : new PointF(x10aaa7cdfa38f254.X - num, x10aaa7cdfa38f254.Y + num / 2f));
		x1cab6af0a41b70e2 x1cab6af0a41b70e = new x1cab6af0a41b70e2();
		xab391c46ff9a0a.xd6b6ed77479ef68c(x1cab6af0a41b70e);
		float num2 = x1deebb03a3d03a50(x10aaa7cdfa38f254, xca09b6c2b5b18485, x294960ca9b3799f2);
		float num3 = num2 + num * 2f;
		int num4 = (int)(num3 * 2f) + 1;
		float[] array = new float[num4 * 2];
		array[0] = pointF.X;
		array[1] = pointF.Y;
		int xd1b6ee08a77d2c = 0;
		if (x294960ca9b3799f2)
		{
			float num5 = pointF.X;
			float num6 = num5 + num;
			for (int i = 0; i < num4 - 1; i++)
			{
				if ((i & 2) == 2)
				{
					if ((i & 1) == 1)
					{
						num6 += x1ca280db59737928(ref xd1b6ee08a77d2c);
						num5 = num6 - num;
					}
					array[i * 2 + 2] = num6;
					array[i * 2 + 3] = x10aaa7cdfa38f254.Y - num / 2f;
				}
				else
				{
					if ((i & 1) == 1)
					{
						num5 += x1ca280db59737928(ref xd1b6ee08a77d2c);
						num6 = num5 + num;
					}
					array[i * 2 + 2] = num5;
					array[i * 2 + 3] = x10aaa7cdfa38f254.Y + num / 2f;
				}
			}
		}
		else
		{
			float num7 = pointF.Y;
			float num8 = num7 + num;
			for (int j = 0; j < num4 - 1; j++)
			{
				if ((j & 2) == 2)
				{
					if ((j & 1) == 1)
					{
						num8 += x1ca280db59737928(ref xd1b6ee08a77d2c);
						num7 = num8 - num;
					}
					array[j * 2 + 2] = x10aaa7cdfa38f254.X - num / 2f;
					array[j * 2 + 3] = num8;
				}
				else
				{
					if ((j & 1) == 1)
					{
						num7 += x1ca280db59737928(ref xd1b6ee08a77d2c);
						num8 = num7 + num;
					}
					array[j * 2 + 2] = x10aaa7cdfa38f254.X + num / 2f;
					array[j * 2 + 3] = num7;
				}
			}
		}
		x60c040f35bb272aa xda5bf54deb817e = new x60c040f35bb272aa(array);
		x1cab6af0a41b70e.xd6b6ed77479ef68c(xda5bf54deb817e);
		x323e603293c20c04(xab391c46ff9a0a, x10aaa7cdfa38f254, num2, x9b0739496f8b5475, x294960ca9b3799f2);
		return xab391c46ff9a0a;
	}

	private static float x1ca280db59737928(ref int xd1b6ee08a77d2c75)
	{
		xd1b6ee08a77d2c75++;
		if (xd1b6ee08a77d2c75 % 5 == 0)
		{
			return 2.25f;
		}
		if (xd1b6ee08a77d2c75 % 6 == 0)
		{
			xd1b6ee08a77d2c75 = 0;
			return 2.25f;
		}
		return 0.75f;
	}

	private static void x323e603293c20c04(xab391c46ff9a0a38 xe125219852864557, PointF x10aaa7cdfa38f254, float x961016a387451f05, float x9b0739496f8b5475, bool x294960ca9b3799f2)
	{
		RectangleF x26545669838eb36e = ((!x294960ca9b3799f2) ? new RectangleF(x10aaa7cdfa38f254.X - x9b0739496f8b5475 / 2f, x10aaa7cdfa38f254.Y, x9b0739496f8b5475, x961016a387451f05) : new RectangleF(x10aaa7cdfa38f254.X, x10aaa7cdfa38f254.Y - x9b0739496f8b5475 / 2f, x961016a387451f05, x9b0739496f8b5475));
		xe125219852864557.x0e1bf8242ad10272 = xab391c46ff9a0a38.x7c89cd07f845b8e1(x26545669838eb36e);
	}

	private static float x1deebb03a3d03a50(PointF x10aaa7cdfa38f254, PointF xca09b6c2b5b18485, bool x294960ca9b3799f2)
	{
		if (x294960ca9b3799f2)
		{
			return xca09b6c2b5b18485.X - x10aaa7cdfa38f254.X;
		}
		return xca09b6c2b5b18485.Y - x10aaa7cdfa38f254.Y;
	}
}
