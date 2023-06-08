using System.Collections;
using System.IO;
using Aspose.Words;
using x28925c9b27b37a46;
using xa604c4d210ae0581;

namespace x650fee20d618512c;

internal class x82218fbaaecee34a
{
	private BinaryReader x7450cc1e48712286;

	private Document x232be220f517f721;

	private readonly ArrayList x6d3dcf646f4b9060 = new ArrayList();

	private readonly ArrayList x86f1f75f329a6767 = new ArrayList();

	private readonly ArrayList x7387d0e00389fe8e = new ArrayList();

	private readonly x2e32c63bbdef0b37 xac9776cf3395e205 = new x2e32c63bbdef0b37();

	private readonly Hashtable x363aca92c8c8cfd6 = new Hashtable();

	internal void x06b0e25aa6ad68a9(BinaryReader xe134235b3526fa75, int x961016a387451f05, Document x6beba47238e0ade6)
	{
		if (x961016a387451f05 == 0)
		{
			return;
		}
		x7450cc1e48712286 = xe134235b3526fa75;
		x232be220f517f721 = x6beba47238e0ade6;
		int num = (int)xe134235b3526fa75.BaseStream.Position;
		int num2 = xe134235b3526fa75.ReadByte();
		if (num2 != 255)
		{
			return;
		}
		int num3 = num + x961016a387451f05;
		while (xe134235b3526fa75.BaseStream.Position < num3)
		{
			switch ((xbad2f8fb0a5ae5de)xe134235b3526fa75.ReadByte())
			{
			case xbad2f8fb0a5ae5de.xc0dc01aeb496e661:
				x203c26184c99fd9d();
				break;
			case xbad2f8fb0a5ae5de.x5b70c24c34bc8ea5:
				xb248ed305e57c5f8();
				break;
			case xbad2f8fb0a5ae5de.x4a34ac15d0cf5a52:
			case xbad2f8fb0a5ae5de.x20e99f3e074421d9:
				xc97bb0b7adb4c7cf();
				break;
			case xbad2f8fb0a5ae5de.x5aa06993c29b5645:
				x5f413034690fa8b2();
				break;
			case xbad2f8fb0a5ae5de.x2a59ec1579d34817:
				x201e1d77e4c90e42();
				break;
			case xbad2f8fb0a5ae5de.xcb573e59d7de41b0:
				xa2f7ab34efed664f();
				break;
			}
		}
		x99c7ba241e1500fa();
		x7e1657a9be4b3520();
		x1b4a399c59642001();
	}

	private void x203c26184c99fd9d()
	{
		int num = x7450cc1e48712286.ReadInt32();
		for (int i = 0; i < num; i++)
		{
			x86f1f75f329a6767.Add(new xa3bbbefaafbabdb0(x7450cc1e48712286));
		}
	}

	private void xb248ed305e57c5f8()
	{
		int num = x7450cc1e48712286.ReadInt32();
		for (int i = 0; i < num; i++)
		{
			x7387d0e00389fe8e.Add(new xa9acf11c040ca49c(x7450cc1e48712286));
		}
	}

	private void xc97bb0b7adb4c7cf()
	{
		int num = x7450cc1e48712286.ReadInt32();
		for (int i = 0; i < num; i++)
		{
			x6d3dcf646f4b9060.Add(new xe526d9d41a46b695(x7450cc1e48712286));
		}
	}

	private void x5f413034690fa8b2()
	{
		xac9776cf3395e205.x06b0e25aa6ad68a9(x7450cc1e48712286, (int)x7450cc1e48712286.BaseStream.Position, int.MaxValue);
	}

	private void x201e1d77e4c90e42()
	{
		int num = x7450cc1e48712286.ReadUInt16();
		for (int i = 0; i < num; i++)
		{
			xcb94ad13abd2d120();
		}
	}

	private void xcb94ad13abd2d120()
	{
		int num = x7450cc1e48712286.ReadUInt16();
		string value = x93b05c1ad709a695.x602d3c3fbfa56f51(x7450cc1e48712286, x5be1cad1d00af914: true, xac1baf51b3e43d13: true);
		x363aca92c8c8cfd6[num] = value;
	}

	private void xa2f7ab34efed664f()
	{
		x7450cc1e48712286.BaseStream.Position--;
		xcb573e59d7de41b0 xcb573e59d7de41b = new xcb573e59d7de41b0();
		x232be220f517f721.x1bb9c356aa4ee24d = xcb573e59d7de41b.x06b0e25aa6ad68a9(x7450cc1e48712286);
	}

	private void x99c7ba241e1500fa()
	{
		if (x86f1f75f329a6767.Count == 0)
		{
			return;
		}
		x232be220f517f721.x3829bffd91c3b45d = new ArrayList();
		foreach (xa3bbbefaafbabdb0 item in x86f1f75f329a6767)
		{
			x232be220f517f721.x3829bffd91c3b45d.Add(xac9776cf3395e205.xe2057a7a2a551874(item.x38bc81c86b855f93));
		}
	}

	private void x7e1657a9be4b3520()
	{
		if (x7387d0e00389fe8e.Count == 0)
		{
			return;
		}
		x232be220f517f721.x92fa7c4d9fc66489 = new ArrayList();
		foreach (xa9acf11c040ca49c item in x7387d0e00389fe8e)
		{
			xf5e19a19d8e0a0e6 value = ((!item.xac69d84f74b89ab0) ? new xf5e19a19d8e0a0e6(item.xd0d3234fea469d3e, xac9776cf3395e205.x6e6007b87273674e(item.x86926a67348adc78)) : new xf5e19a19d8e0a0e6());
			x232be220f517f721.x92fa7c4d9fc66489.Add(value);
		}
	}

	private void x1b4a399c59642001()
	{
		if (x6d3dcf646f4b9060.Count == 0)
		{
			return;
		}
		x232be220f517f721.xd971f86352b6d53c = new ArrayList();
		foreach (xe526d9d41a46b695 item in x6d3dcf646f4b9060)
		{
			x8ee6b62105cb1a44 value = item.xc3b9c8ea66b06532(x363aca92c8c8cfd6);
			x232be220f517f721.xd971f86352b6d53c.Add(value);
		}
	}
}
