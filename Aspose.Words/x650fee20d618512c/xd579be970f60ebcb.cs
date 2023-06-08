using System.Collections;
using System.IO;
using Aspose.Words;
using x28925c9b27b37a46;
using xa604c4d210ae0581;

namespace x650fee20d618512c;

internal class xd579be970f60ebcb
{
	private Document x232be220f517f721;

	private BinaryWriter x9b287b671d592594;

	private readonly x2e32c63bbdef0b37 xac9776cf3395e205 = new x2e32c63bbdef0b37();

	private readonly ArrayList x363aca92c8c8cfd6 = new ArrayList();

	internal int x6210059f049f0d48(Document x6beba47238e0ade6, BinaryWriter xbdfb620b7167944b)
	{
		if (!x6beba47238e0ade6.HasMacros && !x6beba47238e0ade6.x55676d6d0c3d48c0)
		{
			return 0;
		}
		x232be220f517f721 = x6beba47238e0ade6;
		x9b287b671d592594 = xbdfb620b7167944b;
		int num = (int)xbdfb620b7167944b.BaseStream.Position;
		xbdfb620b7167944b.Write(byte.MaxValue);
		x96d57657eba49b51();
		x058a71c06a843aa1();
		x4f5abd6f008fa9a8();
		xddbc6a17a450a69f();
		x7177c3573364e52e();
		xdbc3d91b98d5f268();
		xbdfb620b7167944b.Write((byte)64);
		return (int)xbdfb620b7167944b.BaseStream.Position - num;
	}

	private void x96d57657eba49b51()
	{
		if (!x232be220f517f721.x6241a8bc689c088a)
		{
			return;
		}
		x9b287b671d592594.Write((byte)4);
		x9b287b671d592594.Write(x232be220f517f721.xd971f86352b6d53c.Count);
		foreach (x8ee6b62105cb1a44 item in x232be220f517f721.xd971f86352b6d53c)
		{
			xe526d9d41a46b695 xe526d9d41a46b696 = new xe526d9d41a46b695(item, x363aca92c8c8cfd6);
			xe526d9d41a46b696.x6210059f049f0d48(x9b287b671d592594);
		}
	}

	private void x058a71c06a843aa1()
	{
		if (!x232be220f517f721.xd4f5fcbd0eb0353a)
		{
			return;
		}
		x9b287b671d592594.Write((byte)2);
		x9b287b671d592594.Write(x232be220f517f721.x92fa7c4d9fc66489.Count);
		foreach (xf5e19a19d8e0a0e6 item in x232be220f517f721.x92fa7c4d9fc66489)
		{
			xa9acf11c040ca49c xa9acf11c040ca49c2 = new xa9acf11c040ca49c();
			xa9acf11c040ca49c2.xac69d84f74b89ab0 = item.x7bc28568bfa1ae1c == x74c5a2d6929342db.x4d0b9d4447ba7566;
			if (!xa9acf11c040ca49c2.xac69d84f74b89ab0)
			{
				xa9acf11c040ca49c2.xd0d3234fea469d3e = item.x7bc28568bfa1ae1c;
				xa9acf11c040ca49c2.x86926a67348adc78 = xac9776cf3395e205.xd44988f225497f3a;
				xac9776cf3395e205.x9d4ceecf381e0ab8(item.x09b3682d5c365bf7);
			}
			xa9acf11c040ca49c2.x6210059f049f0d48(x9b287b671d592594);
		}
	}

	private void x4f5abd6f008fa9a8()
	{
		if (x232be220f517f721.x3829bffd91c3b45d == null || x232be220f517f721.x3829bffd91c3b45d.Count == 0)
		{
			return;
		}
		x9b287b671d592594.Write((byte)1);
		x9b287b671d592594.Write(x232be220f517f721.x3829bffd91c3b45d.Count);
		foreach (string item in x232be220f517f721.x3829bffd91c3b45d)
		{
			xa3bbbefaafbabdb0 xa3bbbefaafbabdb = new xa3bbbefaafbabdb0();
			xa3bbbefaafbabdb.x86926a67348adc78 = x363aca92c8c8cfd6.Count;
			x363aca92c8c8cfd6.Add(item.ToUpper());
			xa3bbbefaafbabdb.x38bc81c86b855f93 = xac9776cf3395e205.xd44988f225497f3a;
			xac9776cf3395e205.x510567f1132da166(item);
			xa3bbbefaafbabdb.x6210059f049f0d48(x9b287b671d592594);
		}
	}

	private void xddbc6a17a450a69f()
	{
		if (xac9776cf3395e205.xd44988f225497f3a != 0)
		{
			x9b287b671d592594.Write((byte)16);
			xac9776cf3395e205.x6210059f049f0d48(x9b287b671d592594);
		}
	}

	private void x7177c3573364e52e()
	{
		int count = x363aca92c8c8cfd6.Count;
		if (count == 0)
		{
			return;
		}
		x9b287b671d592594.Write((byte)17);
		x9b287b671d592594.Write((ushort)count);
		int num = 0;
		foreach (string item in x363aca92c8c8cfd6)
		{
			x9b287b671d592594.Write((ushort)num++);
			x93b05c1ad709a695.x4a3c44ae9b1cf5ab(item, 255, x9b287b671d592594, x5be1cad1d00af914: true, xac1baf51b3e43d13: true);
		}
	}

	private void xdbc3d91b98d5f268()
	{
		xcb573e59d7de41b0 xcb573e59d7de41b = new xcb573e59d7de41b0();
		byte[] array = xcb573e59d7de41b.x9b103d78bb2b3bb6(x232be220f517f721.x1bb9c356aa4ee24d, (int)x9b287b671d592594.BaseStream.Position);
		if (array != null)
		{
			x9b287b671d592594.Write(array);
		}
	}
}
