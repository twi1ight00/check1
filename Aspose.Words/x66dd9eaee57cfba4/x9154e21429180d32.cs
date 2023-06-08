using System;
using x6c95d9cf46ff5f25;

namespace x66dd9eaee57cfba4;

internal class x9154e21429180d32 : xa117f86ce0e66a3e
{
	private const byte xc4c3d2a01ce814fd = 1;

	private const byte xdb7c6870138b442f = 2;

	private const byte x7a14c7b51abff51d = 4;

	private const byte xad13a0ae24b0d64c = 8;

	private const byte x488404dd1abc260d = 16;

	private const byte x287b4884807f7d6e = 32;

	public xf50d3346568ee59f[] x4d7474e8f1849803;

	public byte[] x935d836f6cc66869;

	public static x9154e21429180d32 xe45a24eec57c3398(xa8866d7566da0aa2 xe134235b3526fa75)
	{
		x9154e21429180d32 x9154e21429180d33 = new x9154e21429180d32();
		x9154e21429180d33.x1a1cb85d8c2525a3 = xe134235b3526fa75.x2e6b89ad8001e18f();
		if (x9154e21429180d33.x1a1cb85d8c2525a3 < 0)
		{
			throw new InvalidOperationException("Invalid contours number.");
		}
		x9154e21429180d33.x9462c8df936efa39 = xe134235b3526fa75.x2e6b89ad8001e18f();
		x9154e21429180d33.x5b051452efe1bbe3 = xe134235b3526fa75.x2e6b89ad8001e18f();
		x9154e21429180d33.x11f73230b9b436a7 = xe134235b3526fa75.x2e6b89ad8001e18f();
		x9154e21429180d33.xbed6b6abe5a7fcce = xe134235b3526fa75.x2e6b89ad8001e18f();
		if (x9154e21429180d33.x7149c962c02931b3)
		{
			return x9154e21429180d33;
		}
		xd8cce4761dc846ee xd8cce4761dc846ee = new xd8cce4761dc846ee(x9154e21429180d33.x1a1cb85d8c2525a3);
		for (int i = 0; i < x9154e21429180d33.x1a1cb85d8c2525a3; i++)
		{
			xd8cce4761dc846ee.xd6b6ed77479ef68c(xe134235b3526fa75.xdb264d863790ee7b());
		}
		xd8cce4761dc846ee.xee9aac96ed24c7f9();
		int num = 1 + xd8cce4761dc846ee.get_xe6d4b1b411ed94b5(x9154e21429180d33.x1a1cb85d8c2525a3 - 1);
		int x10f4d88af727adbc = xe134235b3526fa75.xdb264d863790ee7b();
		x9154e21429180d33.x935d836f6cc66869 = xe134235b3526fa75.x0f6807cca84a8e5b(x10f4d88af727adbc);
		byte[] array = new byte[num];
		for (int j = 0; j < num; j++)
		{
			byte b = (array[j] = (byte)xe134235b3526fa75.x672ed37ee25c078c());
			if (x26000ce44ebda9ea.xf7735b522c02eb76(array[j], 8))
			{
				int num2 = xe134235b3526fa75.x672ed37ee25c078c();
				for (int k = 0; k < num2; k++)
				{
					array[++j] = b;
				}
			}
		}
		int[] array2 = new int[num];
		for (int l = 0; l < num; l++)
		{
			array2[l] = x90bf36a0d69c3549(xe134235b3526fa75, x26000ce44ebda9ea.xf7735b522c02eb76(array[l], 2), x26000ce44ebda9ea.xf7735b522c02eb76(array[l], 16));
		}
		int[] array3 = new int[num];
		for (int m = 0; m < num; m++)
		{
			array3[m] = x90bf36a0d69c3549(xe134235b3526fa75, x26000ce44ebda9ea.xf7735b522c02eb76(array[m], 4), x26000ce44ebda9ea.xf7735b522c02eb76(array[m], 32));
		}
		x9154e21429180d33.x4d7474e8f1849803 = new xf50d3346568ee59f[num];
		short num3 = 0;
		short num4 = 0;
		for (int n = 0; n < num; n++)
		{
			num3 = (short)(num3 + array2[n]);
			num4 = (short)(num4 + array3[n]);
			xf50d3346568ee59f xf50d3346568ee59f2 = new xf50d3346568ee59f(array2[n], array3[n], num3, num4, x26000ce44ebda9ea.xf7735b522c02eb76(array[n], 1), xd8cce4761dc846ee.x263d579af1d0d43f(n));
			x9154e21429180d33.x4d7474e8f1849803[n] = xf50d3346568ee59f2;
		}
		return x9154e21429180d33;
	}

	private static short x90bf36a0d69c3549(xa8866d7566da0aa2 xe134235b3526fa75, bool x91c11d7aa8b5fc54, bool xb18bda195911831f)
	{
		if (x91c11d7aa8b5fc54)
		{
			return (short)(xe134235b3526fa75.x672ed37ee25c078c() * (xb18bda195911831f ? 1 : (-1)));
		}
		if (!xb18bda195911831f)
		{
			return xe134235b3526fa75.x2e6b89ad8001e18f();
		}
		return 0;
	}

	public void x55fe8a62afa91ade()
	{
		if (x4d7474e8f1849803.Length != 0)
		{
			x9462c8df936efa39 = (short)x4d7474e8f1849803[0].x8df91a2f90079e88;
			x11f73230b9b436a7 = (short)x4d7474e8f1849803[0].x8df91a2f90079e88;
			x5b051452efe1bbe3 = (short)x4d7474e8f1849803[0].xc821290d7ecc08bf;
			xbed6b6abe5a7fcce = (short)x4d7474e8f1849803[0].xc821290d7ecc08bf;
			for (int i = 1; i < x4d7474e8f1849803.Length; i++)
			{
				x9462c8df936efa39 = Math.Min(x9462c8df936efa39, (short)x4d7474e8f1849803[i].x8df91a2f90079e88);
				x11f73230b9b436a7 = Math.Max(x11f73230b9b436a7, (short)x4d7474e8f1849803[i].x8df91a2f90079e88);
				x5b051452efe1bbe3 = Math.Min(x5b051452efe1bbe3, (short)x4d7474e8f1849803[i].xc821290d7ecc08bf);
				xbed6b6abe5a7fcce = Math.Max(xbed6b6abe5a7fcce, (short)x4d7474e8f1849803[i].xc821290d7ecc08bf);
			}
		}
	}

	public override void Write(x73087173962e3778 writer)
	{
		if (!base.x7149c962c02931b3)
		{
			base.Write(writer);
			x15564fee3a02d97b(writer);
			xc8b1db16332b7f32(writer);
			xbc141c5b04beb72e(writer);
		}
	}

	private void x15564fee3a02d97b(x73087173962e3778 xbdfb620b7167944b)
	{
		for (int i = 0; i < x4d7474e8f1849803.Length; i++)
		{
			if (x4d7474e8f1849803[i].x4792a30c8e2cad0a)
			{
				xbdfb620b7167944b.xb0c682b9901a2443(i);
			}
		}
	}

	private void xc8b1db16332b7f32(x73087173962e3778 xbdfb620b7167944b)
	{
		xbdfb620b7167944b.xb0c682b9901a2443(x935d836f6cc66869.Length);
		xbdfb620b7167944b.x4c116b70372a3c6d(x935d836f6cc66869, 0, x935d836f6cc66869.Length);
	}

	private void xbc141c5b04beb72e(x73087173962e3778 xbdfb620b7167944b)
	{
		byte[] xebf45bdcaa1fd1e = xd4fdf54ff19fee17();
		xbe7a3ad59790a41d(xbdfb620b7167944b, xebf45bdcaa1fd1e);
		x2849089606335fc6(xbdfb620b7167944b, xebf45bdcaa1fd1e);
		x9bf92f365e215243(xbdfb620b7167944b, xebf45bdcaa1fd1e);
	}

	private byte[] xd4fdf54ff19fee17()
	{
		byte[] array = new byte[x4d7474e8f1849803.Length];
		for (int i = 0; i < x4d7474e8f1849803.Length; i++)
		{
			byte b = 0;
			if (x4d7474e8f1849803[i].x3608e1d09b3fd55d)
			{
				b = (byte)(b + 1);
			}
			array[i] = b;
		}
		return array;
	}

	private void xbe7a3ad59790a41d(x73087173962e3778 xbdfb620b7167944b, byte[] xebf45bdcaa1fd1e1)
	{
		xbdfb620b7167944b.x4c116b70372a3c6d(xebf45bdcaa1fd1e1, 0, xebf45bdcaa1fd1e1.Length);
	}

	private void x2849089606335fc6(x73087173962e3778 xbdfb620b7167944b, byte[] xebf45bdcaa1fd1e1)
	{
		for (int i = 0; i < x4d7474e8f1849803.Length; i++)
		{
			xbdfb620b7167944b.xab5f6b7526efa5be(x4d7474e8f1849803[i].x44f1cfb897de980b);
		}
	}

	private void x9bf92f365e215243(x73087173962e3778 xbdfb620b7167944b, byte[] xebf45bdcaa1fd1e1)
	{
		for (int i = 0; i < x4d7474e8f1849803.Length; i++)
		{
			xbdfb620b7167944b.xab5f6b7526efa5be(x4d7474e8f1849803[i].x42aa3d9493e9841e);
		}
	}
}
