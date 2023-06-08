using System;
using x6c95d9cf46ff5f25;

namespace x66dd9eaee57cfba4;

internal class x3668d88d65d61a11 : x6c5a92230c2f59e2
{
	private readonly int xab1aa9a55818b87b;

	public int x448900fcb384c333 => xab1aa9a55818b87b;

	public x3668d88d65d61a11(int platformId, int encodingId, x09ce2c02826e31a6 charMap, int language)
		: base(platformId, encodingId, x1cdea779c7702949(charMap))
	{
		xab1aa9a55818b87b = language;
	}

	private static x09ce2c02826e31a6 x1cdea779c7702949(x09ce2c02826e31a6 xd1768ddee4fdb90a)
	{
		x09ce2c02826e31a6 x09ce2c02826e31a = new x09ce2c02826e31a6();
		for (int i = 0; i < xd1768ddee4fdb90a.xd44988f225497f3a; i++)
		{
			int num = xd1768ddee4fdb90a.xf15263674eb297bb(i);
			if (xdf3a1f89dca325a3.x3a26b5f116985446(num))
			{
				break;
			}
			x09ce2c02826e31a.xd6b6ed77479ef68c(num, xd1768ddee4fdb90a.x6d3720b962bd3112(i));
		}
		return x09ce2c02826e31a;
	}

	public static x3668d88d65d61a11 x06b0e25aa6ad68a9(xa8866d7566da0aa2 xe134235b3526fa75, x84845c0d8e00bf00 x8881638314931eaa)
	{
		x09ce2c02826e31a6 x09ce2c02826e31a = new x09ce2c02826e31a6();
		xe134235b3526fa75.x9e418ad9a56d1cf5.Position = x8881638314931eaa.xbe1e23e7d5b43370;
		xe134235b3526fa75.xdb264d863790ee7b();
		int num = xe134235b3526fa75.xdb264d863790ee7b();
		int language = xe134235b3526fa75.xdb264d863790ee7b();
		int num2 = xe134235b3526fa75.xdb264d863790ee7b();
		xe134235b3526fa75.xdb264d863790ee7b();
		xe134235b3526fa75.xdb264d863790ee7b();
		xe134235b3526fa75.xdb264d863790ee7b();
		int num3 = num2 / 2;
		int[] array = x4da4305d7439c6f2(xe134235b3526fa75, num3);
		xe134235b3526fa75.xdb264d863790ee7b();
		int[] array2 = x4da4305d7439c6f2(xe134235b3526fa75, num3);
		int[] array3 = x097eb7ae41ab0024(xe134235b3526fa75, num3);
		int[] array4 = x4da4305d7439c6f2(xe134235b3526fa75, num3);
		int num4 = (int)x8881638314931eaa.xbe1e23e7d5b43370 + num;
		int num5 = num4 - (int)xe134235b3526fa75.x9e418ad9a56d1cf5.Position;
		int num6 = num5 / 2;
		if (num4 + 4 <= xe134235b3526fa75.x9e418ad9a56d1cf5.Length)
		{
			num6 += 2;
		}
		int[] array5 = x4da4305d7439c6f2(xe134235b3526fa75, num6);
		for (int i = 0; i < num3; i++)
		{
			for (int j = array2[i]; j <= array[i]; j++)
			{
				int num7;
				if (j == 65535)
				{
					num7 = 0;
				}
				else
				{
					switch (array4[i])
					{
					case 0:
						num7 = (j + array3[i]) & 0xFFFF;
						if (num7 == 65535)
						{
							num7 = 0;
						}
						break;
					case 65535:
						num7 = 0;
						break;
					default:
					{
						int num8 = j - array2[i];
						int num9 = array4[i] / 2 + num8 - num3 + i;
						num7 = array5[num9];
						if (num7 != 0)
						{
							num7 = (num7 + array3[i]) & 0xFFFF;
						}
						break;
					}
					}
				}
				x09ce2c02826e31a.set_xe6d4b1b411ed94b5(j, (object)num7);
			}
		}
		return new x3668d88d65d61a11(x8881638314931eaa.xa6fc5ae695dd3435, x8881638314931eaa.xb120d6e4572c845b, x09ce2c02826e31a, language);
	}

	private static int[] x4da4305d7439c6f2(xa8866d7566da0aa2 xe134235b3526fa75, int x10f4d88af727adbc)
	{
		int[] array = new int[x10f4d88af727adbc];
		for (int i = 0; i < x10f4d88af727adbc; i++)
		{
			array[i] = xe134235b3526fa75.xdb264d863790ee7b();
		}
		return array;
	}

	private static int[] x097eb7ae41ab0024(xa8866d7566da0aa2 xe134235b3526fa75, int x10f4d88af727adbc)
	{
		int[] array = new int[x10f4d88af727adbc];
		for (int i = 0; i < x10f4d88af727adbc; i++)
		{
			array[i] = xe134235b3526fa75.x2e6b89ad8001e18f();
		}
		return array;
	}

	public override void Write(x73087173962e3778 writer)
	{
		_ = writer.x9e418ad9a56d1cf5.Position;
		writer.xab5f6b7526efa5be(4);
		bool flag = !base.xe6414aff183c47a1.xbc5dc59d0d9b620d(65535);
		int num = base.xe6414aff183c47a1.xd44988f225497f3a + (flag ? 1 : 0);
		int num2 = num * 2;
		int num3 = 2 << (int)Math.Floor(Math.Log(num) / Math.Log(2.0));
		int xbcea506a33cf = (int)(Math.Log((double)num3 / 2.0) / Math.Log(2.0));
		int xbcea506a33cf2 = 2 * num - num3;
		int[] array = new int[num];
		int[] array2 = new int[num];
		int[] array3 = new int[num];
		int[] x4a3f0a05c02f235f = new int[num];
		int[] array4 = new int[0];
		for (int i = 0; i < base.xe6414aff183c47a1.xd44988f225497f3a; i++)
		{
			int num4 = base.xe6414aff183c47a1.xf15263674eb297bb(i);
			int num5 = (int)base.xe6414aff183c47a1.x6d3720b962bd3112(i);
			array[i] = num4;
			array2[i] = num4;
			array3[i] = num5 - num4;
		}
		if (flag)
		{
			array[num - 1] = 65535;
			array2[num - 1] = 65535;
			array3[num - 1] = -65535;
		}
		int xbcea506a33cf3 = 16 + num2 * 4 + array4.Length * 2;
		writer.xab5f6b7526efa5be(xbcea506a33cf3);
		writer.xab5f6b7526efa5be(xab1aa9a55818b87b);
		writer.xab5f6b7526efa5be(num2);
		writer.xab5f6b7526efa5be(num3);
		writer.xab5f6b7526efa5be(xbcea506a33cf);
		writer.xab5f6b7526efa5be(xbcea506a33cf2);
		xb9f92e90912797d1(array, writer);
		writer.xab5f6b7526efa5be(0);
		xb9f92e90912797d1(array2, writer);
		xb9f92e90912797d1(array3, writer);
		xb9f92e90912797d1(x4a3f0a05c02f235f, writer);
		xb9f92e90912797d1(array4, writer);
	}

	private static void xb9f92e90912797d1(int[] x4a3f0a05c02f235f, x73087173962e3778 xbdfb620b7167944b)
	{
		foreach (int xbcea506a33cf in x4a3f0a05c02f235f)
		{
			xbdfb620b7167944b.xab5f6b7526efa5be(xbcea506a33cf);
		}
	}
}
