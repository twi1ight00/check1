using System.IO;
using x45a758cd6bdecee3;
using x66dd9eaee57cfba4;
using x6c95d9cf46ff5f25;

namespace x49d934946ca8bab8;

internal class xaade977c63491e36
{
	public static void xa36a060aa30a1d52(x483dcea572fd1c73 x72b9ff189a8c8ffe, byte[] x79d59388da521e1a, byte[] xe65822bb53be3680, byte[] xad086f0b0726868e, xd3f6a3354dad6708 x4cbb0cc714782977)
	{
		using MemoryStream memoryStream = new MemoryStream(x79d59388da521e1a);
		using MemoryStream stream = new MemoryStream(xe65822bb53be3680);
		using MemoryStream stream2 = new MemoryStream(xad086f0b0726868e);
		xa8866d7566da0aa2 xb503e056d24acf4b = new xa8866d7566da0aa2(memoryStream);
		xa8866d7566da0aa2 x00d9b958934a461c = new xa8866d7566da0aa2(stream);
		xa8866d7566da0aa2 xefc6d8c19133ad = new xa8866d7566da0aa2(stream2);
		using MemoryStream memoryStream2 = new MemoryStream();
		x73087173962e3778 writer = new x73087173962e3778(memoryStream2);
		x0839c6cc3465be05 x0839c6cc3465be = new x0839c6cc3465be05();
		while (memoryStream.Position < memoryStream.Length)
		{
			x0839c6cc3465be.x959ba539d7cca7fe.xd6b6ed77479ef68c((int)memoryStream2.Position);
			xa117f86ce0e66a3e xa117f86ce0e66a3e = x2e45c35ff2ea86f5(xefc6d8c19133ad, x00d9b958934a461c, xb503e056d24acf4b);
			if (!xa117f86ce0e66a3e.x7149c962c02931b3)
			{
				xa117f86ce0e66a3e.Write(writer);
			}
			x0d299f323d241756.xb66a70c14b63a912(memoryStream2, 4);
		}
		x0839c6cc3465be.x959ba539d7cca7fe.xd6b6ed77479ef68c((int)memoryStream2.Position);
		x0839c6cc3465be.x6889630987e71a3d();
		x4cbb0cc714782977.x3ac3494a627eff42 = x0839c6cc3465be.x3ac3494a627eff42;
		x72b9ff189a8c8ffe.x53eb838d813e202e("glyf", memoryStream2.ToArray());
		x72b9ff189a8c8ffe.x53eb838d813e202e("loca", x0839c6cc3465be.x2797b998ab68f4ab());
	}

	private static xa117f86ce0e66a3e x2e45c35ff2ea86f5(xa8866d7566da0aa2 xefc6d8c19133ad46, xa8866d7566da0aa2 x00d9b958934a461c, xa8866d7566da0aa2 xb503e056d24acf4b)
	{
		short num = xb503e056d24acf4b.x2e6b89ad8001e18f();
		xb503e056d24acf4b.x9e418ad9a56d1cf5.Position -= 2L;
		return (num >= 0) ? x0745091f1a238ec6(xb503e056d24acf4b, x00d9b958934a461c, xefc6d8c19133ad46) : x1f21efa3c4a55b7f(xb503e056d24acf4b, x00d9b958934a461c, xefc6d8c19133ad46);
	}

	private static xa117f86ce0e66a3e x1f21efa3c4a55b7f(xa8866d7566da0aa2 xe134235b3526fa75, xa8866d7566da0aa2 x00d9b958934a461c, xa8866d7566da0aa2 xefc6d8c19133ad46)
	{
		short x1a1cb85d8c2525a = xe134235b3526fa75.x2e6b89ad8001e18f();
		xc6a9eccebd57cc06 xc6a9eccebd57cc = new xc6a9eccebd57cc06();
		xc6a9eccebd57cc.x1a1cb85d8c2525a3 = x1a1cb85d8c2525a;
		xc6a9eccebd57cc.x9462c8df936efa39 = xe134235b3526fa75.x2e6b89ad8001e18f();
		xc6a9eccebd57cc.x5b051452efe1bbe3 = xe134235b3526fa75.x2e6b89ad8001e18f();
		xc6a9eccebd57cc.x11f73230b9b436a7 = xe134235b3526fa75.x2e6b89ad8001e18f();
		xc6a9eccebd57cc.xbed6b6abe5a7fcce = xe134235b3526fa75.x2e6b89ad8001e18f();
		xc6a9eccebd57cc.xd6a36709f3831c3c(xe134235b3526fa75);
		if (xc6a9eccebd57cc.x61164e15c624793c)
		{
			xc6a9eccebd57cc.x935d836f6cc66869 = x10416ece8f302a4b(xe134235b3526fa75, x00d9b958934a461c, xefc6d8c19133ad46);
		}
		return xc6a9eccebd57cc;
	}

	private static xa117f86ce0e66a3e x0745091f1a238ec6(xa8866d7566da0aa2 xe134235b3526fa75, xa8866d7566da0aa2 x00d9b958934a461c, xa8866d7566da0aa2 xefc6d8c19133ad46)
	{
		short num = xe134235b3526fa75.x2e6b89ad8001e18f();
		x9154e21429180d32 x9154e21429180d = new x9154e21429180d32();
		bool flag = num == short.MaxValue;
		if (flag)
		{
			x9154e21429180d.x1a1cb85d8c2525a3 = xe134235b3526fa75.x2e6b89ad8001e18f();
			x9154e21429180d.x9462c8df936efa39 = xe134235b3526fa75.x2e6b89ad8001e18f();
			x9154e21429180d.x5b051452efe1bbe3 = xe134235b3526fa75.x2e6b89ad8001e18f();
			x9154e21429180d.x11f73230b9b436a7 = xe134235b3526fa75.x2e6b89ad8001e18f();
			x9154e21429180d.xbed6b6abe5a7fcce = xe134235b3526fa75.x2e6b89ad8001e18f();
		}
		else
		{
			x9154e21429180d.x1a1cb85d8c2525a3 = num;
		}
		if (x9154e21429180d.x1a1cb85d8c2525a3 > 0)
		{
			xd8cce4761dc846ee xd8cce4761dc846ee = new xd8cce4761dc846ee(x9154e21429180d.x1a1cb85d8c2525a3);
			int num2 = 0;
			for (int i = 0; i < x9154e21429180d.x1a1cb85d8c2525a3; i++)
			{
				num2 += xe8229b1c82e8af64(xe134235b3526fa75);
				xd8cce4761dc846ee.xd6b6ed77479ef68c(num2);
			}
			int num3 = num2 + 1;
			byte[] array = xe134235b3526fa75.x0f6807cca84a8e5b(num3);
			x9154e21429180d.x4d7474e8f1849803 = new xf50d3346568ee59f[num3];
			int num4 = 0;
			int num5 = 0;
			for (int j = 0; j < num3; j++)
			{
				x0fddf8d807b6807c x0fddf8d807b6807c2 = x0fddf8d807b6807c.x06b0e25aa6ad68a9(xe134235b3526fa75, array[j]);
				num4 += x0fddf8d807b6807c2.x8df91a2f90079e88;
				num5 += x0fddf8d807b6807c2.xc821290d7ecc08bf;
				xf50d3346568ee59f xf50d3346568ee59f = new xf50d3346568ee59f(x0fddf8d807b6807c2.x8df91a2f90079e88, x0fddf8d807b6807c2.xc821290d7ecc08bf, num4, num5, x0fddf8d807b6807c2.x3608e1d09b3fd55d, xd8cce4761dc846ee.x263d579af1d0d43f(j));
				x9154e21429180d.x4d7474e8f1849803[j] = xf50d3346568ee59f;
			}
			if (!flag)
			{
				x9154e21429180d.x55fe8a62afa91ade();
			}
			x9154e21429180d.x935d836f6cc66869 = x10416ece8f302a4b(xe134235b3526fa75, x00d9b958934a461c, xefc6d8c19133ad46);
		}
		return x9154e21429180d;
	}

	private static byte[] x10416ece8f302a4b(xa8866d7566da0aa2 xe134235b3526fa75, xa8866d7566da0aa2 x00d9b958934a461c, xa8866d7566da0aa2 xefc6d8c19133ad46)
	{
		ushort x987b32cf317aaf = xe8229b1c82e8af64(xe134235b3526fa75);
		ushort x10f4d88af727adbc = xe8229b1c82e8af64(xe134235b3526fa75);
		using MemoryStream memoryStream = new MemoryStream();
		x73087173962e3778 x73087173962e = new x73087173962e3778(memoryStream);
		short[] x6951f18dfa6468bf = xd0c28cd916ceec7c(x00d9b958934a461c, x987b32cf317aaf);
		xe7606e1c3f3a9c5c.x6edb0a9b31af09ae(x73087173962e, x6951f18dfa6468bf);
		byte[] array = xefc6d8c19133ad46.x0f6807cca84a8e5b(x10f4d88af727adbc);
		x73087173962e.x4c116b70372a3c6d(array, 0, array.Length);
		return memoryStream.ToArray();
	}

	private static short[] xd0c28cd916ceec7c(xa8866d7566da0aa2 xe134235b3526fa75, ushort x987b32cf317aaf62)
	{
		short[] array = new short[x987b32cf317aaf62];
		int num = 0;
		while (num < x987b32cf317aaf62)
		{
			switch (xe134235b3526fa75.x672ed37ee25c078c())
			{
			case 251:
			{
				short num3 = array[num - 2];
				array[num++] = num3;
				array[num++] = x44bde362232237f6(xe134235b3526fa75);
				array[num++] = num3;
				break;
			}
			case 252:
			{
				short num2 = array[num - 2];
				array[num++] = num2;
				array[num++] = x44bde362232237f6(xe134235b3526fa75);
				array[num++] = num2;
				array[num++] = x44bde362232237f6(xe134235b3526fa75);
				array[num++] = num2;
				break;
			}
			default:
				xe134235b3526fa75.x9e418ad9a56d1cf5.Position--;
				array[num++] = x44bde362232237f6(xe134235b3526fa75);
				break;
			}
		}
		return array;
	}

	private static ushort xe8229b1c82e8af64(xa8866d7566da0aa2 xe134235b3526fa75)
	{
		short num = xe134235b3526fa75.x672ed37ee25c078c();
		return num switch
		{
			253 => xe134235b3526fa75.xdb264d863790ee7b(), 
			255 => (ushort)(xe134235b3526fa75.x672ed37ee25c078c() + 253), 
			254 => (ushort)(xe134235b3526fa75.x672ed37ee25c078c() + 506), 
			_ => (ushort)num, 
		};
	}

	private static short x44bde362232237f6(xa8866d7566da0aa2 xe134235b3526fa75)
	{
		short num = xe134235b3526fa75.x672ed37ee25c078c();
		if (num == 253)
		{
			return xe134235b3526fa75.x2e6b89ad8001e18f();
		}
		short num2 = 1;
		if (num == 250)
		{
			num2 = -1;
			num = xe134235b3526fa75.x672ed37ee25c078c();
		}
		short num5;
		if (num == 255 || num == 254)
		{
			short num3 = xe134235b3526fa75.x672ed37ee25c078c();
			int num4 = ((num == 255) ? 1 : 2);
			num5 = (short)(num3 + 250 * num4);
		}
		else
		{
			num5 = num;
		}
		return (short)(num5 * num2);
	}
}
