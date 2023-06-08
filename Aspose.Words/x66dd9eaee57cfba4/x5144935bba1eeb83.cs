using System;
using System.Collections;
using System.Drawing;
using System.IO;
using x45a758cd6bdecee3;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;

namespace x66dd9eaee57cfba4;

internal class x5144935bba1eeb83
{
	[Flags]
	private enum x31a0a15e356cef55
	{
		x5f613ac7cded8ac4 = 1,
		x8f4b7a37b0b6a6da = 2,
		xcb760fa337ed3e4a = 4,
		x013b55e98a6ae007 = 8,
		x40cace65622938cb = 0x20,
		xbfbf0963c2c969f5 = 0x40,
		x8b0e25edaa9d658e = 0x80,
		x61164e15c624793c = 0x100,
		x87ae1d2145f2016a = 0x200
	}

	private readonly xa8866d7566da0aa2 x7450cc1e48712286;

	private readonly bool x631b392d1f9f57ae;

	private x0839c6cc3465be05 x33fb6041857fa3d2;

	private x0839c6cc3465be05 xf78d10e0bf87730c;

	private MemoryStream xfa9338b24a8ae193;

	private MemoryStream xe369b832801df70f;

	private MemoryStream x71029bd9bd7cc7db;

	internal MemoryStream x8f64841d1796a33d => xfa9338b24a8ae193;

	internal MemoryStream xe173d615c7a9da13 => xe369b832801df70f;

	internal MemoryStream x25caa2389941bd02 => x71029bd9bd7cc7db;

	internal x5144935bba1eeb83(xa8866d7566da0aa2 reader, bool isLocaShort)
	{
		x7450cc1e48712286 = reader;
		x631b392d1f9f57ae = isLocaShort;
	}

	internal int x44ee2c4f3463a01c(x1d5a785c8d5b14ee xf3a9c0b07cdf0f67, x1d5a785c8d5b14ee xc90432236a82420e, x49a6906320d20269 x785a34523271d8fa, x09ce2c02826e31a6 x1c6a97d3a496e7e2)
	{
		x96322c21b2b46b4c(xf3a9c0b07cdf0f67);
		x5ead1a4ac4a78166(xc90432236a82420e, x785a34523271d8fa, x1c6a97d3a496e7e2);
		x26259b70e7e30718();
		return xf78d10e0bf87730c.x959ba539d7cca7fe.xd44988f225497f3a - 1;
	}

	internal Hashtable x134ce7d8db68e2e5(x1d5a785c8d5b14ee xf3a9c0b07cdf0f67, x1d5a785c8d5b14ee xc90432236a82420e, x09ce2c02826e31a6 x1c6a97d3a496e7e2, int xcb0ea7d30675ed7c)
	{
		x96322c21b2b46b4c(xf3a9c0b07cdf0f67);
		Hashtable hashtable = new Hashtable();
		x09ce2c02826e31a6 x09ce2c02826e31a = xd9607c4c5586382d(x1c6a97d3a496e7e2);
		for (int i = 0; i < x09ce2c02826e31a.xd44988f225497f3a; i++)
		{
			x5ddcd7f1136699aa x5ddcd7f1136699aa2 = new x5ddcd7f1136699aa(xcb0ea7d30675ed7c);
			int x67b20bf592a9191c = (int)x09ce2c02826e31a.x6d3720b962bd3112(i);
			xaa973db06e2f9a73(x67b20bf592a9191c, xc90432236a82420e, x5ddcd7f1136699aa2, null);
			hashtable[i] = x5ddcd7f1136699aa2;
		}
		return hashtable;
	}

	private void xaa973db06e2f9a73(int x67b20bf592a9191c, x1d5a785c8d5b14ee xc90432236a82420e, x5ddcd7f1136699aa x0ff2a0e3d912821b, x54366fa5f75a02f7 xa801ccff44b0c7eb)
	{
		x7450cc1e48712286.x9e418ad9a56d1cf5.Position = xc90432236a82420e.xf1d9b91c9700c401 + x33fb6041857fa3d2.x959ba539d7cca7fe.get_xe6d4b1b411ed94b5(x67b20bf592a9191c);
		short num = x7450cc1e48712286.x2e6b89ad8001e18f();
		x7450cc1e48712286.x9e418ad9a56d1cf5.Position -= 2L;
		if (xa801ccff44b0c7eb == null)
		{
			xa801ccff44b0c7eb = new x54366fa5f75a02f7();
		}
		if (num < 0)
		{
			x9db7f2e4ce30e2fe(x0ff2a0e3d912821b, xc90432236a82420e, xa801ccff44b0c7eb);
		}
		else
		{
			xa5501ad88a1f2c35(x0ff2a0e3d912821b, xa801ccff44b0c7eb);
		}
	}

	private void x9db7f2e4ce30e2fe(x5ddcd7f1136699aa x0ff2a0e3d912821b, x1d5a785c8d5b14ee xc90432236a82420e, x54366fa5f75a02f7 xa801ccff44b0c7eb)
	{
		x7450cc1e48712286.x2e6b89ad8001e18f();
		x7450cc1e48712286.x2e6b89ad8001e18f();
		x7450cc1e48712286.x2e6b89ad8001e18f();
		x7450cc1e48712286.x2e6b89ad8001e18f();
		x7450cc1e48712286.x2e6b89ad8001e18f();
		x31a0a15e356cef55 x31a0a15e356cef;
		do
		{
			x31a0a15e356cef = (x31a0a15e356cef55)x7450cc1e48712286.xdb264d863790ee7b();
			int x67b20bf592a9191c = x7450cc1e48712286.xdb264d863790ee7b();
			short num;
			short num2;
			if ((x31a0a15e356cef & x31a0a15e356cef55.x5f613ac7cded8ac4) != 0)
			{
				num = x7450cc1e48712286.x2e6b89ad8001e18f();
				num2 = x7450cc1e48712286.x2e6b89ad8001e18f();
			}
			else
			{
				num = x7450cc1e48712286.x672ed37ee25c078c();
				num2 = x7450cc1e48712286.x672ed37ee25c078c();
			}
			if ((x31a0a15e356cef & x31a0a15e356cef55.x8f4b7a37b0b6a6da) != 0)
			{
				xa801ccff44b0c7eb.xce92de628aa023cf(num, num2);
			}
			if ((x31a0a15e356cef & x31a0a15e356cef55.x013b55e98a6ae007) != 0)
			{
				xab81a06f030a7c54();
			}
			else if ((x31a0a15e356cef & x31a0a15e356cef55.xbfbf0963c2c969f5) != 0)
			{
				xab81a06f030a7c54();
				xab81a06f030a7c54();
			}
			else if ((x31a0a15e356cef & x31a0a15e356cef55.x8b0e25edaa9d658e) != 0)
			{
				xab81a06f030a7c54();
				xab81a06f030a7c54();
				xab81a06f030a7c54();
				xab81a06f030a7c54();
			}
			long position = x7450cc1e48712286.x9e418ad9a56d1cf5.Position;
			xaa973db06e2f9a73(x67b20bf592a9191c, xc90432236a82420e, x0ff2a0e3d912821b, xa801ccff44b0c7eb);
			x7450cc1e48712286.x9e418ad9a56d1cf5.Position = position;
		}
		while ((x31a0a15e356cef & x31a0a15e356cef55.x40cace65622938cb) != 0);
		if ((x31a0a15e356cef & x31a0a15e356cef55.x61164e15c624793c) != 0)
		{
			int x10f4d88af727adbc = x7450cc1e48712286.xdb264d863790ee7b();
			x7450cc1e48712286.x0f6807cca84a8e5b(x10f4d88af727adbc);
		}
	}

	private void xa5501ad88a1f2c35(x5ddcd7f1136699aa x0ff2a0e3d912821b, x54366fa5f75a02f7 xa801ccff44b0c7eb)
	{
		int num = x7450cc1e48712286.x2e6b89ad8001e18f();
		x7450cc1e48712286.x2e6b89ad8001e18f();
		x7450cc1e48712286.x2e6b89ad8001e18f();
		x7450cc1e48712286.x2e6b89ad8001e18f();
		x7450cc1e48712286.x2e6b89ad8001e18f();
		int[] array = new int[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = x7450cc1e48712286.xdb264d863790ee7b();
		}
		int num2 = 0;
		for (int j = 0; j < array.Length; j++)
		{
			num2 = 1 + ((num2 < array[j]) ? array[j] : num2);
		}
		int x10f4d88af727adbc = x7450cc1e48712286.xdb264d863790ee7b();
		x7450cc1e48712286.x0f6807cca84a8e5b(x10f4d88af727adbc);
		byte[] array2 = new byte[num2];
		for (int k = 0; k < num2; k++)
		{
			byte b = (array2[k] = (byte)x7450cc1e48712286.x672ed37ee25c078c());
			bool[] array3 = x0d299f323d241756.x1e86cfa3e4cb412a(array2[k]);
			if (array3[3])
			{
				int num3 = x7450cc1e48712286.x672ed37ee25c078c();
				for (int l = 0; l < num3; l++)
				{
					k++;
					array2[k] = b;
				}
			}
		}
		int[] array4 = new int[num2];
		for (int m = 0; m < num2; m++)
		{
			bool[] array5 = x0d299f323d241756.x1e86cfa3e4cb412a(array2[m]);
			if (array5[1])
			{
				array4[m] = x7450cc1e48712286.x672ed37ee25c078c() * (array5[4] ? 1 : (-1));
			}
			else
			{
				array4[m] = (array5[4] ? array4[m] : x7450cc1e48712286.x2e6b89ad8001e18f());
			}
		}
		int[] array6 = new int[num2];
		for (int n = 0; n < num2; n++)
		{
			bool[] array7 = x0d299f323d241756.x1e86cfa3e4cb412a(array2[n]);
			if (array7[2])
			{
				array6[n] = x7450cc1e48712286.x672ed37ee25c078c() * (array7[5] ? 1 : (-1));
			}
			else
			{
				array6[n] = (array7[5] ? array6[n] : x7450cc1e48712286.x2e6b89ad8001e18f());
			}
		}
		if (xa801ccff44b0c7eb != null)
		{
			PointF x2f7096dac971d6ec = new PointF(array4[0], array6[0]);
			x2f7096dac971d6ec = xa801ccff44b0c7eb.x5c785f1d561da269(x2f7096dac971d6ec);
			array4[0] = (int)x2f7096dac971d6ec.X;
			array6[0] = (int)x2f7096dac971d6ec.Y;
		}
		int num4 = 0;
		for (int num5 = 0; num5 < num2; num5++)
		{
			bool[] array8 = x0d299f323d241756.x1e86cfa3e4cb412a(array2[num5]);
			bool flag = array[num4] == num5;
			if (flag)
			{
				num4++;
			}
			x0ff2a0e3d912821b.x4d7474e8f1849803.xd6b6ed77479ef68c(array4[num5], array6[num5], array8[0], flag, num5 == 0);
		}
	}

	private float xab81a06f030a7c54()
	{
		short num = x7450cc1e48712286.x2e6b89ad8001e18f();
		int num2 = num >> 14;
		float num3 = (num & 0x3FFF) / 16383;
		return (float)num2 + num3;
	}

	private void x96322c21b2b46b4c(x1d5a785c8d5b14ee xf3a9c0b07cdf0f67)
	{
		x7450cc1e48712286.x9e418ad9a56d1cf5.Position = xf3a9c0b07cdf0f67.xf1d9b91c9700c401;
		x33fb6041857fa3d2 = x0839c6cc3465be05.x06b0e25aa6ad68a9(x7450cc1e48712286, xf3a9c0b07cdf0f67.x1be93eed8950d961, x631b392d1f9f57ae);
	}

	private void x26259b70e7e30718()
	{
		xfa9338b24a8ae193 = new MemoryStream();
		x73087173962e3778 xbdfb620b7167944b = new x73087173962e3778(xfa9338b24a8ae193);
		xf78d10e0bf87730c.x6210059f049f0d48(xbdfb620b7167944b);
	}

	private void x5ead1a4ac4a78166(x1d5a785c8d5b14ee xc90432236a82420e, x49a6906320d20269 x785a34523271d8fa, x09ce2c02826e31a6 xccf4043581d152c5)
	{
		x09ce2c02826e31a6 x09ce2c02826e31a = xd9607c4c5586382d(xccf4043581d152c5);
		xf78d10e0bf87730c = new x0839c6cc3465be05(x631b392d1f9f57ae);
		xe369b832801df70f = new MemoryStream();
		x73087173962e3778 x73087173962e = new x73087173962e3778(xe369b832801df70f);
		x71029bd9bd7cc7db = new MemoryStream();
		x73087173962e3778 xbdfb620b7167944b = new x73087173962e3778(x71029bd9bd7cc7db);
		for (int i = 0; i < x09ce2c02826e31a.xd44988f225497f3a; i++)
		{
			xf78d10e0bf87730c.x959ba539d7cca7fe.xd6b6ed77479ef68c((int)x73087173962e.x9e418ad9a56d1cf5.Position);
			int num = (int)x09ce2c02826e31a.x6d3720b962bd3112(i);
			x7450cc1e48712286.x9e418ad9a56d1cf5.Position = xc90432236a82420e.xf1d9b91c9700c401 + x33fb6041857fa3d2.x959ba539d7cca7fe.get_xe6d4b1b411ed94b5(num);
			int num2 = x33fb6041857fa3d2.x959ba539d7cca7fe.get_xe6d4b1b411ed94b5(num + 1) - x33fb6041857fa3d2.x959ba539d7cca7fe.get_xe6d4b1b411ed94b5(num);
			if (num2 > 0)
			{
				short num3 = x7450cc1e48712286.x2e6b89ad8001e18f();
				if (num3 < 0)
				{
					x73087173962e.xab5f6b7526efa5be(num3);
					byte[] array = x7450cc1e48712286.x0f6807cca84a8e5b(8);
					x73087173962e.x4c116b70372a3c6d(array, 0, array.Length);
					x31a0a15e356cef55 x31a0a15e356cef;
					do
					{
						x31a0a15e356cef = (x31a0a15e356cef55)x7450cc1e48712286.xdb264d863790ee7b();
						x73087173962e.xab5f6b7526efa5be((int)x31a0a15e356cef);
						int num4 = x7450cc1e48712286.xdb264d863790ee7b();
						object obj = xccf4043581d152c5.get_xe6d4b1b411ed94b5(num4);
						int num5;
						if (obj != null)
						{
							num5 = (int)obj;
						}
						else
						{
							int num6 = x09ce2c02826e31a.xf15263674eb297bb(x09ce2c02826e31a.xd44988f225497f3a - 1);
							num5 = num6 + 1;
							xccf4043581d152c5.xd6b6ed77479ef68c(num4, num5);
							x09ce2c02826e31a.xd6b6ed77479ef68c(num5, num4);
						}
						byte[] array2 = x7450cc1e48712286.x0f6807cca84a8e5b(xb25cd241358a4d85(x31a0a15e356cef));
						x73087173962e.xab5f6b7526efa5be(num5);
						x73087173962e.x4c116b70372a3c6d(array2, 0, array2.Length);
					}
					while ((x31a0a15e356cef & x31a0a15e356cef55.x40cace65622938cb) != 0);
					if ((x31a0a15e356cef & x31a0a15e356cef55.x61164e15c624793c) != 0)
					{
						int num7 = x7450cc1e48712286.xdb264d863790ee7b();
						byte[] array3 = x7450cc1e48712286.x0f6807cca84a8e5b(num7);
						x73087173962e.xab5f6b7526efa5be(num7);
						x73087173962e.x4c116b70372a3c6d(array3, 0, array3.Length);
					}
				}
				else
				{
					x7450cc1e48712286.x9e418ad9a56d1cf5.Position -= 2L;
					byte[] array4 = x7450cc1e48712286.x0f6807cca84a8e5b(num2);
					x73087173962e.x4c116b70372a3c6d(array4, 0, array4.Length);
				}
				if (x0d299f323d241756.x7e32f71c3f39b6bc(x73087173962e.x9e418ad9a56d1cf5.Position))
				{
					x73087173962e.xc351d479ff7ee789(0);
				}
			}
			x785a34523271d8fa.xc9b9fba2361cb131(num).x6210059f049f0d48(xbdfb620b7167944b);
		}
		xf78d10e0bf87730c.x959ba539d7cca7fe.xd6b6ed77479ef68c((int)x73087173962e.x9e418ad9a56d1cf5.Position);
	}

	private static int xb25cd241358a4d85(x31a0a15e356cef55 xebf45bdcaa1fd1e1)
	{
		int num = (((xebf45bdcaa1fd1e1 & x31a0a15e356cef55.x5f613ac7cded8ac4) != 0) ? 4 : 2);
		if ((xebf45bdcaa1fd1e1 & x31a0a15e356cef55.x013b55e98a6ae007) != 0)
		{
			num += 2;
		}
		else if ((xebf45bdcaa1fd1e1 & x31a0a15e356cef55.xbfbf0963c2c969f5) != 0)
		{
			num += 4;
		}
		else if ((xebf45bdcaa1fd1e1 & x31a0a15e356cef55.x8b0e25edaa9d658e) != 0)
		{
			num += 8;
		}
		return num;
	}

	private static x09ce2c02826e31a6 xd9607c4c5586382d(x09ce2c02826e31a6 x0e61d04ae1133cc9)
	{
		x09ce2c02826e31a6 x09ce2c02826e31a = new x09ce2c02826e31a6();
		for (int i = 0; i < x0e61d04ae1133cc9.xd44988f225497f3a; i++)
		{
			int num = x0e61d04ae1133cc9.xf15263674eb297bb(i);
			int xba08ce632055a1d = (int)x0e61d04ae1133cc9.x6d3720b962bd3112(i);
			x09ce2c02826e31a.xd6b6ed77479ef68c(xba08ce632055a1d, num);
		}
		return x09ce2c02826e31a;
	}
}
