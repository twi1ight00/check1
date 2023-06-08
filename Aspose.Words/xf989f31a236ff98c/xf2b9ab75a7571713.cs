using System;
using System.IO;
using System.Text;
using Aspose.Words.Fields;
using x13f1efc79617a47b;
using x884584cc69c5c378;
using xa604c4d210ae0581;
using xfbd1009a0cbb9842;

namespace xf989f31a236ff98c;

internal class xf2b9ab75a7571713
{
	internal const int x54dcf0b7bed40274 = 25;

	internal static x58bf2a36f9adf9a9 x7e54dea1c329122d(BinaryReader xe134235b3526fa75)
	{
		x58bf2a36f9adf9a9 x58bf2a36f9adf9a = new x58bf2a36f9adf9a9();
		long position = xe134235b3526fa75.BaseStream.Position;
		x409512556c3f2a9a x409512556c3f2a9a = new x409512556c3f2a9a(xe134235b3526fa75);
		if (x409512556c3f2a9a.xf280755e03a40325 == x409512556c3f2a9a.xd6696a1209486da5)
		{
			return x58bf2a36f9adf9a;
		}
		x855150d0664edd8d(xe134235b3526fa75, x58bf2a36f9adf9a);
		xe134235b3526fa75.BaseStream.Position = position + x409512556c3f2a9a.xf280755e03a40325;
		return x58bf2a36f9adf9a;
	}

	internal static void x377854a89e2ddb81(FormField x0ab8fc6e4b8e829c, BinaryWriter xbdfb620b7167944b)
	{
		long position = xbdfb620b7167944b.BaseStream.Position;
		x409512556c3f2a9a x409512556c3f2a9a = new x409512556c3f2a9a();
		x409512556c3f2a9a.x6210059f049f0d48(xbdfb620b7167944b);
		xc26afd5362f5c1ec(x0ab8fc6e4b8e829c.x58bf2a36f9adf9a9, x0ab8fc6e4b8e829c.xdda013621290d582, xbdfb620b7167944b);
		long position2 = xbdfb620b7167944b.BaseStream.Position;
		x409512556c3f2a9a.xf280755e03a40325 = (int)(position2 - position);
		xbdfb620b7167944b.BaseStream.Seek(position, SeekOrigin.Begin);
		x409512556c3f2a9a.x6210059f049f0d48(xbdfb620b7167944b);
		xbdfb620b7167944b.BaseStream.Seek(position2, SeekOrigin.Begin);
	}

	internal static x58bf2a36f9adf9a9 xded02c37c7e1688e(byte[] xf9a0d04800d70471)
	{
		x58bf2a36f9adf9a9 x58bf2a36f9adf9a = new x58bf2a36f9adf9a9();
		MemoryStream input = new MemoryStream(xf9a0d04800d70471);
		BinaryReader xe134235b3526fa = new BinaryReader(input, Encoding.Unicode);
		x855150d0664edd8d(xe134235b3526fa, x58bf2a36f9adf9a);
		return x58bf2a36f9adf9a;
	}

	internal static MemoryStream xef5c5351bf6fb1a9(FormField x0ab8fc6e4b8e829c)
	{
		MemoryStream memoryStream = new MemoryStream();
		BinaryWriter xbdfb620b7167944b = new BinaryWriter(memoryStream, Encoding.Unicode);
		xc26afd5362f5c1ec(x0ab8fc6e4b8e829c.x58bf2a36f9adf9a9, x0ab8fc6e4b8e829c.xdda013621290d582, xbdfb620b7167944b);
		return memoryStream;
	}

	private static void x855150d0664edd8d(BinaryReader xe134235b3526fa75, x58bf2a36f9adf9a9 x3db8cf25c83af70b)
	{
		uint num = xe134235b3526fa75.ReadUInt32();
		bool flag = num == uint.MaxValue;
		if (!flag)
		{
			xe134235b3526fa75.BaseStream.Seek(-4L, SeekOrigin.Current);
		}
		int num2 = xe134235b3526fa75.ReadUInt16();
		xdda013621290d582 xdda013621290d = (xdda013621290d582)(num2 & 3);
		int num3 = (num2 & 0x7C) >> 2;
		switch (xdda013621290d)
		{
		case xdda013621290d582.xfd2f38e457ba1955:
			if (num3 != 25)
			{
				x3db8cf25c83af70b.x4ac39a4f11664c6b = num3 != 0;
			}
			break;
		case xdda013621290d582.xca07ebdb4698a889:
			if (num3 != 25)
			{
				x3db8cf25c83af70b.xfeefd92fb9bd0678 = num3;
			}
			break;
		}
		x3db8cf25c83af70b.x0c2c83899c41d345 = (num2 & 0x80) != 0;
		x3db8cf25c83af70b.x5a70ee0d6c0cb151 = (num2 & 0x100) != 0;
		x3db8cf25c83af70b.x9f2c0dc847992f03 = (num2 & 0x200) == 0;
		x3db8cf25c83af70b.xbd91bc7364251d6d = (num2 & 0x400) == 0;
		x3db8cf25c83af70b.x98ed2e2b5602a6f1 = (TextFormFieldType)((num2 & 0x3800) >> 11);
		x3db8cf25c83af70b.x8cc2703314d01b16 = (num2 & 0x4000) != 0;
		bool flag2 = (num2 & 0x8000) != 0;
		x3db8cf25c83af70b.xc5c2fb4db5b8c3bd = xe134235b3526fa75.ReadUInt16();
		x3db8cf25c83af70b.x4bdafa5e724a058a = xe134235b3526fa75.ReadUInt16();
		if (!flag)
		{
			xe134235b3526fa75.ReadUInt16();
		}
		x3db8cf25c83af70b.x759aa16c2016a289 = x93b05c1ad709a695.x602d3c3fbfa56f51(xe134235b3526fa75, flag, xac1baf51b3e43d13: true);
		switch (xdda013621290d)
		{
		case xdda013621290d582.x09e38cfc94ebc64d:
		{
			string x5e1adcb28cb5f = x93b05c1ad709a695.x602d3c3fbfa56f51(xe134235b3526fa75, flag, xac1baf51b3e43d13: true);
			if (num3 != 25)
			{
				x3db8cf25c83af70b.x5e1adcb28cb5f299 = x5e1adcb28cb5f;
			}
			break;
		}
		case xdda013621290d582.xfd2f38e457ba1955:
			x3db8cf25c83af70b.x5e6597fb50c93e39 = xe134235b3526fa75.ReadUInt16() != 0;
			break;
		case xdda013621290d582.xca07ebdb4698a889:
			x3db8cf25c83af70b.x290a782f6c7cab2f = xe134235b3526fa75.ReadUInt16();
			break;
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("pfgcfhnchhedghldogcelgjehgafhghfggofeffgafmgjadhmekhcfbicfiikepikpfjndnjndekgdlkkdclpcjliopljdhmldompcfnbcmnhoco", 686958090)));
		}
		x3db8cf25c83af70b.xe8f8d8a7db32427b = x93b05c1ad709a695.x602d3c3fbfa56f51(xe134235b3526fa75, flag, xac1baf51b3e43d13: true);
		x3db8cf25c83af70b.x22f04e1437bdf856 = x93b05c1ad709a695.x602d3c3fbfa56f51(xe134235b3526fa75, flag, xac1baf51b3e43d13: true);
		x3db8cf25c83af70b.x50bd293cbfa8c01a = x93b05c1ad709a695.x602d3c3fbfa56f51(xe134235b3526fa75, flag, xac1baf51b3e43d13: true);
		x3db8cf25c83af70b.x6ebae521c5565993 = x93b05c1ad709a695.x602d3c3fbfa56f51(xe134235b3526fa75, flag, xac1baf51b3e43d13: true);
		x3db8cf25c83af70b.xedb00d3630ef56d1 = x93b05c1ad709a695.x602d3c3fbfa56f51(xe134235b3526fa75, flag, xac1baf51b3e43d13: true);
		if (xdda013621290d != xdda013621290d582.xca07ebdb4698a889 || !flag2)
		{
			return;
		}
		xe134235b3526fa75.ReadInt16();
		int num4;
		if (!flag)
		{
			num4 = xe134235b3526fa75.ReadInt16();
			xe134235b3526fa75.ReadInt16();
			xe134235b3526fa75.ReadInt16();
			xe134235b3526fa75.ReadInt16();
			xe134235b3526fa75.ReadBytes(num4 * 2);
		}
		else
		{
			num4 = xe134235b3526fa75.ReadInt32();
		}
		if (num4 <= 25)
		{
			for (int i = 0; i < num4; i++)
			{
				x3db8cf25c83af70b.xc055d178db9e8d17.Add(x93b05c1ad709a695.x602d3c3fbfa56f51(xe134235b3526fa75, flag, xac1baf51b3e43d13: false));
			}
		}
	}

	private static void xc26afd5362f5c1ec(x58bf2a36f9adf9a9 x3db8cf25c83af70b, xdda013621290d582 x41a6f30c104b75ee, BinaryWriter xbdfb620b7167944b)
	{
		xbdfb620b7167944b.Write(uint.MaxValue);
		int num = 0;
		num |= (int)x41a6f30c104b75ee;
		num |= x3f88a25febd23896(x3db8cf25c83af70b, x41a6f30c104b75ee) << 2;
		num |= (x3db8cf25c83af70b.x0c2c83899c41d345 ? 128 : 0);
		num |= (x3db8cf25c83af70b.x5a70ee0d6c0cb151 ? 256 : 0);
		num |= ((!x3db8cf25c83af70b.x9f2c0dc847992f03) ? 512 : 0);
		if (x41a6f30c104b75ee == xdda013621290d582.xfd2f38e457ba1955)
		{
			num |= ((!x3db8cf25c83af70b.xbd91bc7364251d6d) ? 1024 : 0);
		}
		if (x41a6f30c104b75ee == xdda013621290d582.x09e38cfc94ebc64d)
		{
			num |= (int)x3db8cf25c83af70b.x98ed2e2b5602a6f1 << 11;
		}
		num |= (x3db8cf25c83af70b.x8cc2703314d01b16 ? 16384 : 0);
		num |= ((x41a6f30c104b75ee == xdda013621290d582.xca07ebdb4698a889) ? 32768 : 0);
		xbdfb620b7167944b.Write((ushort)num);
		xbdfb620b7167944b.Write((ushort)x3db8cf25c83af70b.xc5c2fb4db5b8c3bd);
		xbdfb620b7167944b.Write((ushort)x3db8cf25c83af70b.x4bdafa5e724a058a);
		x93b05c1ad709a695.x4a3c44ae9b1cf5ab(x3db8cf25c83af70b.x759aa16c2016a289, 20, xbdfb620b7167944b, x5be1cad1d00af914: true, xac1baf51b3e43d13: true);
		switch (x41a6f30c104b75ee)
		{
		case xdda013621290d582.x09e38cfc94ebc64d:
			switch (x3db8cf25c83af70b.x98ed2e2b5602a6f1)
			{
			case TextFormFieldType.Regular:
			case TextFormFieldType.Number:
			case TextFormFieldType.Date:
			case TextFormFieldType.Calculated:
				x93b05c1ad709a695.x4a3c44ae9b1cf5ab(x3db8cf25c83af70b.x5e1adcb28cb5f299, 255, xbdfb620b7167944b, x5be1cad1d00af914: true, xac1baf51b3e43d13: true);
				break;
			case TextFormFieldType.CurrentDate:
			case TextFormFieldType.CurrentTime:
				x93b05c1ad709a695.x4a3c44ae9b1cf5ab("", 255, xbdfb620b7167944b, x5be1cad1d00af914: true, xac1baf51b3e43d13: true);
				break;
			default:
				throw new InvalidOperationException("Unknown text input type.");
			}
			break;
		case xdda013621290d582.xfd2f38e457ba1955:
			xbdfb620b7167944b.Write((ushort)(x3db8cf25c83af70b.x5e6597fb50c93e39 ? 1u : 0u));
			break;
		case xdda013621290d582.xca07ebdb4698a889:
			xbdfb620b7167944b.Write((ushort)x3db8cf25c83af70b.x290a782f6c7cab2f);
			break;
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("eiidkjpdejgeejnecjefhjlflicgkdjgnhahdihhdiohlhfilcmiogdjogkjhgbklgikagpkjbglkgnlmgemaglmcfcnibjn", 1812543535)));
		}
		x93b05c1ad709a695.x4a3c44ae9b1cf5ab(x3db8cf25c83af70b.xe8f8d8a7db32427b, 64, xbdfb620b7167944b, x5be1cad1d00af914: true, xac1baf51b3e43d13: true);
		x93b05c1ad709a695.x4a3c44ae9b1cf5ab(x3db8cf25c83af70b.x22f04e1437bdf856, 255, xbdfb620b7167944b, x5be1cad1d00af914: true, xac1baf51b3e43d13: true);
		x93b05c1ad709a695.x4a3c44ae9b1cf5ab(x3db8cf25c83af70b.x50bd293cbfa8c01a, 138, xbdfb620b7167944b, x5be1cad1d00af914: true, xac1baf51b3e43d13: true);
		x93b05c1ad709a695.x4a3c44ae9b1cf5ab(x3db8cf25c83af70b.x6ebae521c5565993, 32, xbdfb620b7167944b, x5be1cad1d00af914: true, xac1baf51b3e43d13: true);
		x93b05c1ad709a695.x4a3c44ae9b1cf5ab(x3db8cf25c83af70b.xedb00d3630ef56d1, 32, xbdfb620b7167944b, x5be1cad1d00af914: true, xac1baf51b3e43d13: true);
		if (x41a6f30c104b75ee == xdda013621290d582.xca07ebdb4698a889)
		{
			xbdfb620b7167944b.Write(ushort.MaxValue);
			xbdfb620b7167944b.Write((uint)x3db8cf25c83af70b.xc055d178db9e8d17.Count);
			for (int i = 0; i < x3db8cf25c83af70b.xc055d178db9e8d17.Count; i++)
			{
				x93b05c1ad709a695.x4a3c44ae9b1cf5ab(x3db8cf25c83af70b.xc055d178db9e8d17[i], int.MaxValue, xbdfb620b7167944b, x5be1cad1d00af914: true, xac1baf51b3e43d13: false);
			}
		}
	}

	internal static int x3f88a25febd23896(x58bf2a36f9adf9a9 x3db8cf25c83af70b, xdda013621290d582 x41a6f30c104b75ee)
	{
		switch (x41a6f30c104b75ee)
		{
		case xdda013621290d582.x09e38cfc94ebc64d:
			return 0;
		case xdda013621290d582.xfd2f38e457ba1955:
			if (x3db8cf25c83af70b.x7c5abf7ed147c26c)
			{
				if (!x3db8cf25c83af70b.x4ac39a4f11664c6b)
				{
					return 0;
				}
				return 1;
			}
			return 25;
		case xdda013621290d582.xca07ebdb4698a889:
			if (x3db8cf25c83af70b.x6cf648f1ac6f4032)
			{
				return x3db8cf25c83af70b.xfeefd92fb9bd0678;
			}
			return 25;
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("oknkemelolllolcmmljmbmanflhnegonhkfonkmonkdpfkkpffbaijiaijpabjgbfjnbkiecdelcejcdgjjdkiaemhheceoe", 1129753945)));
		}
	}
}
