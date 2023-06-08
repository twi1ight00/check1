using Aspose.Words.Drawing;
using x011d489fb9df7027;
using x7c7a1dceb600404e;

namespace x1a62aaf14e3c5909;

internal class x30145fee5dd2eb06
{
	private const int x63667b39f6e6f67f = 5;

	private const int xd2e119de2b28eefc = 6;

	private x30145fee5dd2eb06()
	{
	}

	internal static void x96bbefc795cf6d84(xf7125312c7ee115c xa5e8b8b5991a4e1d)
	{
		x449c0af4c304c651 x449c0af4c304c652 = x449c0af4c304c651.x3b937127917a796a;
		object obj = xa5e8b8b5991a4e1d.xf7866f89640a29a3(324);
		if (obj != null)
		{
			x449c0af4c304c652 = (x449c0af4c304c651)obj;
			xa5e8b8b5991a4e1d.x52b190e626f65140(324);
		}
		x08d932077485c285[] array = (x08d932077485c285[])xa5e8b8b5991a4e1d.xf7866f89640a29a3(325);
		if (array == null || array.Length == 0)
		{
			return;
		}
		x44f2b8bf33b16275[] array2 = (x44f2b8bf33b16275[])xa5e8b8b5991a4e1d.xf7866f89640a29a3(326);
		if (array2 != null && array2.Length > 0)
		{
			return;
		}
		ShapeType shapeType = (ShapeType)xa5e8b8b5991a4e1d.xf7866f89640a29a3(4155);
		if (shapeType == ShapeType.Arc)
		{
			array2 = x455959980d2f9263();
		}
		else
		{
			switch (x449c0af4c304c652)
			{
			case x449c0af4c304c651.x734991a6e63a780b:
				array2 = x7bc709365928ca8d(array);
				break;
			case x449c0af4c304c651.x3b937127917a796a:
				array2 = new x44f2b8bf33b16275[4]
				{
					new x44f2b8bf33b16275(x4dd8a59ec8974a5f.x01b2723108ff3dfe, 0),
					new x44f2b8bf33b16275(x4dd8a59ec8974a5f.xd0baff30d99dc152, array.Length - 1),
					new x44f2b8bf33b16275(x4dd8a59ec8974a5f.x8ffe90e7fbccfccd, 1),
					new x44f2b8bf33b16275(x4dd8a59ec8974a5f.x9fd888e65466818c, 0)
				};
				break;
			case x449c0af4c304c651.xed557ff242140283:
			{
				array2 = new x44f2b8bf33b16275[3]
				{
					new x44f2b8bf33b16275(x4dd8a59ec8974a5f.x01b2723108ff3dfe, 0),
					null,
					null
				};
				int segmentCount2 = (array.Length - 1) / 3;
				array2[1] = new x44f2b8bf33b16275(x4dd8a59ec8974a5f.x102c43569e36d6d1, segmentCount2);
				array2[2] = new x44f2b8bf33b16275(x4dd8a59ec8974a5f.x9fd888e65466818c, 0);
				break;
			}
			case x449c0af4c304c651.x91194ccf308cf8a8:
			{
				array2 = new x44f2b8bf33b16275[4]
				{
					new x44f2b8bf33b16275(x4dd8a59ec8974a5f.x01b2723108ff3dfe, 0),
					null,
					null,
					null
				};
				int segmentCount = (array.Length - 1) / 3;
				array2[1] = new x44f2b8bf33b16275(x4dd8a59ec8974a5f.x102c43569e36d6d1, segmentCount);
				array2[2] = new x44f2b8bf33b16275(x4dd8a59ec8974a5f.x8ffe90e7fbccfccd, 1);
				array2[3] = new x44f2b8bf33b16275(x4dd8a59ec8974a5f.x9fd888e65466818c, 0);
				break;
			}
			default:
				array2 = x7bc709365928ca8d(array);
				break;
			}
		}
		xa5e8b8b5991a4e1d.xae20093bed1e48a8(326, array2);
	}

	private static x44f2b8bf33b16275[] x455959980d2f9263()
	{
		xf7125312c7ee115c xf7125312c7ee115c = x6f6338c074d2d794.xc49bc34e8c134250(ShapeType.Arc);
		return (x44f2b8bf33b16275[])xf7125312c7ee115c.xf7866f89640a29a3(326);
	}

	private static x44f2b8bf33b16275[] x7bc709365928ca8d(x08d932077485c285[] x130960a25431bacb)
	{
		return new x44f2b8bf33b16275[3]
		{
			new x44f2b8bf33b16275(x4dd8a59ec8974a5f.x01b2723108ff3dfe, 0),
			new x44f2b8bf33b16275(x4dd8a59ec8974a5f.xd0baff30d99dc152, x130960a25431bacb.Length - 1),
			new x44f2b8bf33b16275(x4dd8a59ec8974a5f.x9fd888e65466818c, 0)
		};
	}

	internal static x44f2b8bf33b16275 x475eb9088d78b9cf(int xebf45bdcaa1fd1e1)
	{
		int num = (xebf45bdcaa1fd1e1 & 0xE000) >> 13;
		if (num == 5 || num == 6)
		{
			num = (xebf45bdcaa1fd1e1 & 0xFF00) >> 8;
			return new x44f2b8bf33b16275((x4dd8a59ec8974a5f)num, xebf45bdcaa1fd1e1 & 0xFF);
		}
		return new x44f2b8bf33b16275((x4dd8a59ec8974a5f)num, xebf45bdcaa1fd1e1 & 0x1FFF);
	}

	internal static int xeda895769860002f(x44f2b8bf33b16275 x37169c88a38f2f9b)
	{
		int x7bc0a12a325563e;
		if (x37169c88a38f2f9b.x4dd8a59ec8974a5f >= x4dd8a59ec8974a5f.x43ebc9f6fe642c26)
		{
			x7bc0a12a325563e = x37169c88a38f2f9b.x7bc0a12a325563e9;
			return x7bc0a12a325563e | ((int)x37169c88a38f2f9b.x4dd8a59ec8974a5f << 8);
		}
		x7bc0a12a325563e = x37169c88a38f2f9b.x7bc0a12a325563e9;
		return x7bc0a12a325563e | ((int)x37169c88a38f2f9b.x4dd8a59ec8974a5f << 13);
	}
}
