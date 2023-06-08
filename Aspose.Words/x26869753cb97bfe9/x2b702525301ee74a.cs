using System.Collections;
using System.Collections.Specialized;
using System.IO;
using xa604c4d210ae0581;
using xf9a9481c3f63a419;

namespace x26869753cb97bfe9;

internal class x2b702525301ee74a
{
	private class x1c522cbb74a81647 : xa38071b52e850907
	{
		private readonly x2b702525301ee74a x8cedcaa9a62c6e39;

		public x1c522cbb74a81647(x2b702525301ee74a context)
		{
			x8cedcaa9a62c6e39 = context;
		}

		private void xb10f2c5426ecd7f6(BinaryReader xe134235b3526fa75, int xd59ec9a3f7a434cb, int x115e8b3958ad070b)
		{
			x8cedcaa9a62c6e39.xf47d9022f2504162.xd6b6ed77479ef68c(xd59ec9a3f7a434cb, new x32102a17bbcfaefa());
		}

		void xa38071b52e850907.xa6a789f0e88511c3(BinaryReader xe134235b3526fa75, int xd59ec9a3f7a434cb, int x115e8b3958ad070b)
		{
			//ILSpy generated this explicit interface implementation from .override directive in xb10f2c5426ecd7f6
			this.xb10f2c5426ecd7f6(xe134235b3526fa75, xd59ec9a3f7a434cb, x115e8b3958ad070b);
		}
	}

	private class x0267227b8ac7dc43 : xa38071b52e850907
	{
		private readonly x2b702525301ee74a x8cedcaa9a62c6e39;

		public x0267227b8ac7dc43(x2b702525301ee74a context)
		{
			x8cedcaa9a62c6e39 = context;
		}

		private void xb10f2c5426ecd7f6(BinaryReader xe134235b3526fa75, int xd59ec9a3f7a434cb, int x115e8b3958ad070b)
		{
			string text = x8cedcaa9a62c6e39.xe905f7b98c1c65f8[x8cedcaa9a62c6e39.x821d54c0137f779d.x23719734cf1f138c];
			short num = xe134235b3526fa75.ReadInt16();
			ushort flags = xe134235b3526fa75.ReadUInt16();
			xc1570bebc52c316e xccb63ca5f63dc = new xc1570bebc52c316e(text, num, flags);
			x8cedcaa9a62c6e39.x821d54c0137f779d.xd6b6ed77479ef68c(xd59ec9a3f7a434cb, xccb63ca5f63dc);
			x8cedcaa9a62c6e39.x239072c02f6ea939(num).x759aa16c2016a289 = text;
		}

		void xa38071b52e850907.xa6a789f0e88511c3(BinaryReader xe134235b3526fa75, int xd59ec9a3f7a434cb, int x115e8b3958ad070b)
		{
			//ILSpy generated this explicit interface implementation from .override directive in xb10f2c5426ecd7f6
			this.xb10f2c5426ecd7f6(xe134235b3526fa75, xd59ec9a3f7a434cb, x115e8b3958ad070b);
		}
	}

	internal const string x03e91c00508ced00 = "_PictureBullets";

	private readonly StringCollection xe905f7b98c1c65f8 = new StringCollection();

	private readonly xc9072e4c3fa520ad x821d54c0137f779d = new xc9072e4c3fa520ad(0);

	private readonly xc9072e4c3fa520ad xf47d9022f2504162 = new xc9072e4c3fa520ad(0);

	private readonly IDictionary x3ac56b140628448c = xd51c34d05311eee3.xdb04a310bbb29cff();

	internal int xd44988f225497f3a => x821d54c0137f779d.x23719734cf1f138c;

	internal xc9072e4c3fa520ad x1213e861660862e7 => x821d54c0137f779d;

	internal xc9072e4c3fa520ad x8a4e50b3272d2d52 => xf47d9022f2504162;

	internal x2b702525301ee74a()
	{
	}

	internal x2b702525301ee74a(x8aeace2bf92692ab fib, BinaryReader tableStreamReader)
	{
		xaf807f6784ee1743.x06b0e25aa6ad68a9(tableStreamReader, fib.x955a03f821588c52.xb4807e9f07ed3c31, xe905f7b98c1c65f8);
		tableStreamReader.BaseStream.Seek(fib.x955a03f821588c52.xa372789f960e60eb.xe53f0e68147463d1, SeekOrigin.Begin);
		x759e32a03439237a.x06b0e25aa6ad68a9(tableStreamReader, fib.x955a03f821588c52.xa372789f960e60eb.x04c290dc4d04369c, 0, new x1c522cbb74a81647(this), "Plcfbkl");
		tableStreamReader.BaseStream.Seek(fib.x955a03f821588c52.xe8da7f5fa0796e15.xe53f0e68147463d1, SeekOrigin.Begin);
		x759e32a03439237a.x06b0e25aa6ad68a9(tableStreamReader, fib.x955a03f821588c52.xe8da7f5fa0796e15.x04c290dc4d04369c, 4, new x0267227b8ac7dc43(this), "Plcfbkf");
		x821d54c0137f779d.xd6b6ed77479ef68c(int.MaxValue);
		xf47d9022f2504162.xd6b6ed77479ef68c(int.MaxValue);
		x832ada9dc5213057(fib);
	}

	private void x832ada9dc5213057(x8aeace2bf92692ab xf0c8411938a86cbf)
	{
		xa6101120b8ed585e xa6101120b8ed585e = new xa6101120b8ed585e(0, xf0c8411938a86cbf.x3ab228b2748114ba);
		for (int i = 0; i < x821d54c0137f779d.x23719734cf1f138c; i++)
		{
			int x30cc7819189f11b = x79564b4c249bb9b5(i);
			if (xa6101120b8ed585e.x263d579af1d0d43f(x30cc7819189f11b))
			{
				xc1570bebc52c316e xc1570bebc52c316e2 = x261adce1963ad007(i);
				int xe3e69311d96d25cd = xc1570bebc52c316e2.xe3e69311d96d25cd;
				int x30cc7819189f11b2 = xe189bae9bcd4ad86(xe3e69311d96d25cd);
				if (!xa6101120b8ed585e.x263d579af1d0d43f(x30cc7819189f11b2))
				{
					xf47d9022f2504162.x6d93cc54d095824a(xe3e69311d96d25cd, xa6101120b8ed585e.x9fd888e65466818c - 1);
				}
			}
		}
	}

	internal void x6210059f049f0d48(x8aeace2bf92692ab xf0c8411938a86cbf, BinaryWriter xfd86a6b02a8cb849, int xcd57a8d236c77fa5)
	{
		xf0c8411938a86cbf.x955a03f821588c52.xb4807e9f07ed3c31.xe53f0e68147463d1 = (int)xfd86a6b02a8cb849.BaseStream.Position;
		xf0c8411938a86cbf.x955a03f821588c52.xb4807e9f07ed3c31.x04c290dc4d04369c = xaf807f6784ee1743.x6210059f049f0d48(xfd86a6b02a8cb849, xe905f7b98c1c65f8);
		xf0c8411938a86cbf.x955a03f821588c52.xe8da7f5fa0796e15.xe53f0e68147463d1 = (int)xfd86a6b02a8cb849.BaseStream.Position;
		xf0c8411938a86cbf.x955a03f821588c52.xe8da7f5fa0796e15.x04c290dc4d04369c = x5f5aa9273fa3b8c8(xfd86a6b02a8cb849, xcd57a8d236c77fa5);
		xf0c8411938a86cbf.x955a03f821588c52.xa372789f960e60eb.xe53f0e68147463d1 = (int)xfd86a6b02a8cb849.BaseStream.Position;
		xf0c8411938a86cbf.x955a03f821588c52.xa372789f960e60eb.x04c290dc4d04369c = xcb116498bbcd5ab4(xfd86a6b02a8cb849, xcd57a8d236c77fa5);
	}

	internal void xf3280842efde82ac(x2b702525301ee74a x50a18ad2656e7181, int x03d82212f016d5f9)
	{
		for (int i = 0; i < x50a18ad2656e7181.x821d54c0137f779d.x23719734cf1f138c; i++)
		{
			int num = x50a18ad2656e7181.x79564b4c249bb9b5(i);
			xc1570bebc52c316e xc1570bebc52c316e2 = x50a18ad2656e7181.x261adce1963ad007(i);
			xffb003338cfde846(x03d82212f016d5f9 + num, xc1570bebc52c316e2.x759aa16c2016a289, xc1570bebc52c316e2.x586b7652ac7cefe0);
		}
		for (int j = 0; j < x50a18ad2656e7181.xf47d9022f2504162.x23719734cf1f138c; j++)
		{
			int num2 = x50a18ad2656e7181.xe189bae9bcd4ad86(j);
			x32102a17bbcfaefa x32102a17bbcfaefa2 = x50a18ad2656e7181.x239072c02f6ea939(j);
			x1ff8ac05a72bd9dd(x03d82212f016d5f9 + num2, x32102a17bbcfaefa2.x759aa16c2016a289);
		}
	}

	private int x79564b4c249bb9b5(int xc0c4c459c6ccbd00)
	{
		return x821d54c0137f779d.xed8a0d4499d6f292(xc0c4c459c6ccbd00);
	}

	private int xe189bae9bcd4ad86(int xc0c4c459c6ccbd00)
	{
		return xf47d9022f2504162.xed8a0d4499d6f292(xc0c4c459c6ccbd00);
	}

	private xc1570bebc52c316e x261adce1963ad007(int xc0c4c459c6ccbd00)
	{
		return (xc1570bebc52c316e)x821d54c0137f779d.xe84e6ff66aac2a0e(xc0c4c459c6ccbd00);
	}

	private x32102a17bbcfaefa x239072c02f6ea939(int xc0c4c459c6ccbd00)
	{
		return (x32102a17bbcfaefa)xf47d9022f2504162.xe84e6ff66aac2a0e(xc0c4c459c6ccbd00);
	}

	internal void xffb003338cfde846(int x18d1054d82981887, string xc15bd84e01929885, int xebf45bdcaa1fd1e1)
	{
		xe905f7b98c1c65f8.Add(xc15bd84e01929885);
		int num = x821d54c0137f779d.xd6b6ed77479ef68c(x18d1054d82981887, new xc1570bebc52c316e(xc15bd84e01929885, -1, (ushort)xebf45bdcaa1fd1e1));
		x3ac56b140628448c.Add(xc15bd84e01929885, num);
	}

	internal void x1ff8ac05a72bd9dd(int x18d1054d82981887, string xc15bd84e01929885)
	{
		int xe3e69311d96d25cd = xf47d9022f2504162.xd6b6ed77479ef68c(x18d1054d82981887, new x32102a17bbcfaefa(xc15bd84e01929885));
		int xc0c4c459c6ccbd = xfb633602001b8e10(xc15bd84e01929885);
		x261adce1963ad007(xc0c4c459c6ccbd).xe3e69311d96d25cd = xe3e69311d96d25cd;
	}

	private int x5f5aa9273fa3b8c8(BinaryWriter xbdfb620b7167944b, int xcd57a8d236c77fa5)
	{
		if (x821d54c0137f779d.x23719734cf1f138c == 0)
		{
			return 0;
		}
		long position = xbdfb620b7167944b.BaseStream.Position;
		for (int i = 0; i < x821d54c0137f779d.x23719734cf1f138c; i++)
		{
			xbdfb620b7167944b.Write(x79564b4c249bb9b5(i));
		}
		xbdfb620b7167944b.Write(xcd57a8d236c77fa5);
		for (int j = 0; j < x821d54c0137f779d.x23719734cf1f138c; j++)
		{
			xc1570bebc52c316e xc1570bebc52c316e2 = x261adce1963ad007(j);
			xbdfb620b7167944b.Write((short)xc1570bebc52c316e2.xe3e69311d96d25cd);
			xbdfb620b7167944b.Write((ushort)xc1570bebc52c316e2.x586b7652ac7cefe0);
		}
		return (int)(xbdfb620b7167944b.BaseStream.Position - position);
	}

	private int xcb116498bbcd5ab4(BinaryWriter xbdfb620b7167944b, int xcd57a8d236c77fa5)
	{
		if (xf47d9022f2504162.x23719734cf1f138c == 0)
		{
			return 0;
		}
		long position = xbdfb620b7167944b.BaseStream.Position;
		for (int i = 0; i < xf47d9022f2504162.x23719734cf1f138c; i++)
		{
			xbdfb620b7167944b.Write(xe189bae9bcd4ad86(i));
		}
		xbdfb620b7167944b.Write(xcd57a8d236c77fa5);
		return (int)(xbdfb620b7167944b.BaseStream.Position - position);
	}

	private int xfb633602001b8e10(string xc15bd84e01929885)
	{
		object obj = x3ac56b140628448c[xc15bd84e01929885];
		if (obj != null)
		{
			return (int)obj;
		}
		return -1;
	}
}
