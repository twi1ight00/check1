using System;

namespace x4adf554d20d941a6;

internal class xa3d29140e8fff554
{
	private int x52d613e82f2f0170;

	private int x0f0abc56c6504ea3;

	private readonly x8d9303345f12a846 x2c9b21f64c8361c0;

	private int x8918dc7c534575e5;

	internal int x1fb2a875e6411ef2 => x52d613e82f2f0170;

	internal int x1e5325ab72cf7ec9 => x0f0abc56c6504ea3;

	internal int xb0f146032f47c24e
	{
		get
		{
			if (x8918dc7c534575e5 == int.MinValue)
			{
				x8918dc7c534575e5 = 0;
				for (xf6937c72cebe4ad1 xf6937c72cebe4ad2 = x2c9b21f64c8361c0.x927910b7aed705e2; xf6937c72cebe4ad2 != null; xf6937c72cebe4ad2 = xf6937c72cebe4ad2.xbb84c6a76faa71e6)
				{
					x8918dc7c534575e5 = Math.Max(x8918dc7c534575e5, xf6937c72cebe4ad2.x319720dedc082a9d);
				}
			}
			return x8918dc7c534575e5;
		}
	}

	internal xa3d29140e8fff554(x8d9303345f12a846 layout)
	{
		x2c9b21f64c8361c0 = layout;
	}

	internal void xb1de1ba20faeeff8()
	{
		x52d613e82f2f0170 = 0;
		x0f0abc56c6504ea3 = 0;
		x0f0abc56c6504ea3 = (x52d613e82f2f0170 = 0);
		int num = 0;
		xf0b374f4c0172a4c xf0b374f4c0172a4c2 = new xf0b374f4c0172a4c(x2c9b21f64c8361c0.x0eafd527bd1e778e, x2c9b21f64c8361c0.x2be2727bb322530e.x61712f0b4f5455af);
		xf0b374f4c0172a4c2.xcd61e66a5417dbee(x2c9b21f64c8361c0.x0eafd527bd1e778e, x2718ffc1fa17413a: false);
		while (!xf0b374f4c0172a4c2.x30d6662e83251ab4 && xf0b374f4c0172a4c2.x56410a8dd70087c5 != x2c9b21f64c8361c0.x2be2727bb322530e)
		{
			int x9b0739496f8b;
			int num2 = x4825f810a75088e3(xf0b374f4c0172a4c2, x0f0abc56c6504ea3, out x9b0739496f8b);
			x0f0abc56c6504ea3 += x9b0739496f8b;
			switch (num2)
			{
			case 10754:
				num = 0;
				continue;
			case 12803:
				num = x9b0739496f8b;
				break;
			case 9217:
				x9b0739496f8b += num;
				num = 0;
				break;
			}
			x52d613e82f2f0170 = Math.Max(x52d613e82f2f0170, x9b0739496f8b);
		}
		int num3 = x2c9b21f64c8361c0.xa79651e2f1a1416e.xc0741c7ff92cf1aa + x2c9b21f64c8361c0.xa79651e2f1a1416e.x91e854e77522d9eb + Math.Max(0, x2c9b21f64c8361c0.xa79651e2f1a1416e.xc7d7e186f0ace1e0);
		x52d613e82f2f0170 += num3;
		x0f0abc56c6504ea3 += num3;
	}

	private static int x4825f810a75088e3(xf0b374f4c0172a4c x887d55e3f220b5b9, int x0ec16e7032a0d6ea, out int x9b0739496f8b5475)
	{
		x9b0739496f8b5475 = 0;
		int num = x887d55e3f220b5b9.x56410a8dd70087c5.x5566e2d2acbd1fbe;
		if (10754 == num)
		{
			while (x887d55e3f220b5b9.x851fcfc17df82b1b != x887d55e3f220b5b9.x56410a8dd70087c5 && 10754 == x887d55e3f220b5b9.x56410a8dd70087c5.x5566e2d2acbd1fbe)
			{
				x9b0739496f8b5475 += x887d55e3f220b5b9.x56410a8dd70087c5.xdc1bf80853046136;
				x9b0739496f8b5475 += x887d55e3f220b5b9.x56410a8dd70087c5.x1be93eed8950d961 * 50;
				x887d55e3f220b5b9.xcd61e66a5417dbee(x887d55e3f220b5b9.x56410a8dd70087c5.x61712f0b4f5455af, x2718ffc1fa17413a: false);
			}
		}
		else if (x5566e2d2acbd1fbe.xfc6971c7d8314663(num) == xfc6971c7d8314663.x35078e8db43b001f || x5566e2d2acbd1fbe.xfc6971c7d8314663(num) == xfc6971c7d8314663.xf9ad6fb78355fe13)
		{
			while (x887d55e3f220b5b9.x851fcfc17df82b1b != x887d55e3f220b5b9.x56410a8dd70087c5 && (x5566e2d2acbd1fbe.xfc6971c7d8314663(num) == xfc6971c7d8314663.x35078e8db43b001f || x5566e2d2acbd1fbe.xfc6971c7d8314663(num) == xfc6971c7d8314663.xf9ad6fb78355fe13))
			{
				bool flag = x5566e2d2acbd1fbe.xfc6971c7d8314663(num) == xfc6971c7d8314663.x35078e8db43b001f;
				bool x3903fb3e01e2a14f;
				do
				{
					x9b0739496f8b5475 += x887d55e3f220b5b9.xc7c6550a888abaf3();
					x9b0739496f8b5475 += 50;
					flag |= 9217 == x887d55e3f220b5b9.x56410a8dd70087c5.x5566e2d2acbd1fbe && x887d55e3f220b5b9.x067d56aec20cdd99 == '-';
					x3903fb3e01e2a14f = x887d55e3f220b5b9.x3903fb3e01e2a14f;
					x887d55e3f220b5b9.x47f176deff0d42e2();
				}
				while (!flag && !x3903fb3e01e2a14f);
				if (flag)
				{
					break;
				}
				num = x887d55e3f220b5b9.x56410a8dd70087c5.x5566e2d2acbd1fbe;
			}
			num = 9217;
		}
		else
		{
			if (x5566e2d2acbd1fbe.x6634ed9c1dfbdfce(num) || x5566e2d2acbd1fbe.xbeeb36dfc51db07d(num))
			{
				x9b0739496f8b5475 = x887d55e3f220b5b9.x56410a8dd70087c5.xdc1bf80853046136;
				num = 10754;
			}
			else
			{
				x9b0739496f8b5475 = xc1231aad908a60dd.x38758cbbee49e4cb(x887d55e3f220b5b9.x56410a8dd70087c5.x5a7799e1836857e3, x887d55e3f220b5b9.x56410a8dd70087c5, x887d55e3f220b5b9.x56410a8dd70087c5.xc255c495fd9232ca.x8df91a2f90079e88 - x887d55e3f220b5b9.x56410a8dd70087c5.xc255c495fd9232ca.xc255c495fd9232ca.x5c392d6ad6fe7e28 + x0ec16e7032a0d6ea).xc23e48392ede9acb;
			}
			x887d55e3f220b5b9.xcd61e66a5417dbee(x887d55e3f220b5b9.x56410a8dd70087c5.x61712f0b4f5455af, x2718ffc1fa17413a: false);
		}
		return num;
	}
}
