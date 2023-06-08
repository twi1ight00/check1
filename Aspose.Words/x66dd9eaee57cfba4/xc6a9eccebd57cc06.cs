using System;
using System.IO;
using x6c95d9cf46ff5f25;

namespace x66dd9eaee57cfba4;

internal class xc6a9eccebd57cc06 : xa117f86ce0e66a3e
{
	private const ushort x9db0dc070ffad4da = 1;

	private const ushort x10545fe9274437ed = 8;

	private const ushort xd39685a528038dbc = 32;

	private const ushort x2c371146d03bb558 = 64;

	private const ushort x83990fa3f64bb751 = 128;

	private const ushort xab639764e45be280 = 256;

	public byte[] xca0246c8b30f09fb;

	public byte[] x935d836f6cc66869;

	public bool x61164e15c624793c;

	public static xc6a9eccebd57cc06 x31a3f77e98668a51(xa8866d7566da0aa2 xe134235b3526fa75)
	{
		xc6a9eccebd57cc06 xc6a9eccebd57cc7 = new xc6a9eccebd57cc06();
		xc6a9eccebd57cc7.x1a1cb85d8c2525a3 = xe134235b3526fa75.x2e6b89ad8001e18f();
		if (xc6a9eccebd57cc7.x1a1cb85d8c2525a3 >= 0)
		{
			throw new InvalidOperationException("Invalid contours number.");
		}
		xc6a9eccebd57cc7.x9462c8df936efa39 = xe134235b3526fa75.x2e6b89ad8001e18f();
		xc6a9eccebd57cc7.x5b051452efe1bbe3 = xe134235b3526fa75.x2e6b89ad8001e18f();
		xc6a9eccebd57cc7.x11f73230b9b436a7 = xe134235b3526fa75.x2e6b89ad8001e18f();
		xc6a9eccebd57cc7.xbed6b6abe5a7fcce = xe134235b3526fa75.x2e6b89ad8001e18f();
		xc6a9eccebd57cc7.xd6a36709f3831c3c(xe134235b3526fa75);
		if (xc6a9eccebd57cc7.x61164e15c624793c)
		{
			ushort x10f4d88af727adbc = xe134235b3526fa75.xdb264d863790ee7b();
			xc6a9eccebd57cc7.x935d836f6cc66869 = xe134235b3526fa75.x0f6807cca84a8e5b(x10f4d88af727adbc);
		}
		return xc6a9eccebd57cc7;
	}

	public void xd6a36709f3831c3c(xa8866d7566da0aa2 xe134235b3526fa75)
	{
		using MemoryStream memoryStream = new MemoryStream();
		x73087173962e3778 x73087173962e = new x73087173962e3778(memoryStream);
		ushort num;
		do
		{
			num = xe134235b3526fa75.xdb264d863790ee7b();
			ushort xbcea506a33cf = xe134235b3526fa75.xdb264d863790ee7b();
			byte[] array = xe134235b3526fa75.x0f6807cca84a8e5b(x962408147d5083b6(num));
			x73087173962e.xb0c682b9901a2443(num);
			x73087173962e.xb0c682b9901a2443(xbcea506a33cf);
			x73087173962e.x4c116b70372a3c6d(array, 0, array.Length);
		}
		while (xa0ba419cefe3974d(num));
		x61164e15c624793c = x34a1a8908680c80d(num);
		xca0246c8b30f09fb = memoryStream.ToArray();
	}

	public override void Write(x73087173962e3778 writer)
	{
		base.Write(writer);
		writer.x4c116b70372a3c6d(xca0246c8b30f09fb, 0, xca0246c8b30f09fb.Length);
		if (x61164e15c624793c)
		{
			writer.xb0c682b9901a2443(x935d836f6cc66869.Length);
			writer.x4c116b70372a3c6d(x935d836f6cc66869, 0, x935d836f6cc66869.Length);
		}
	}

	private static int x962408147d5083b6(ushort xebf45bdcaa1fd1e1)
	{
		int num = (x26000ce44ebda9ea.x3c25c5b87860f214(xebf45bdcaa1fd1e1, 1) ? 4 : 2);
		if (x26000ce44ebda9ea.x3c25c5b87860f214(xebf45bdcaa1fd1e1, 8))
		{
			num += 2;
		}
		else if (x26000ce44ebda9ea.x3c25c5b87860f214(xebf45bdcaa1fd1e1, 64))
		{
			num += 4;
		}
		else if (x26000ce44ebda9ea.x3c25c5b87860f214(xebf45bdcaa1fd1e1, 128))
		{
			num += 8;
		}
		return num;
	}

	private static bool xa0ba419cefe3974d(ushort xebf45bdcaa1fd1e1)
	{
		return x26000ce44ebda9ea.x3c25c5b87860f214(xebf45bdcaa1fd1e1, 32);
	}

	private static bool x34a1a8908680c80d(ushort xebf45bdcaa1fd1e1)
	{
		return x26000ce44ebda9ea.x3c25c5b87860f214(xebf45bdcaa1fd1e1, 256);
	}
}
