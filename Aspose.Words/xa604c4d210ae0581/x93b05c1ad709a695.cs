using System;
using System.Collections;
using System.IO;
using System.Text;
using x13f1efc79617a47b;
using x1a62aaf14e3c5909;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;

namespace xa604c4d210ae0581;

internal class x93b05c1ad709a695
{
	private static readonly Encoding x25380d1c398dbd14;

	private static readonly Encoding xaa122dba3e5cfe53;

	private static readonly Hashtable x462a070e16afbac5;

	private static readonly Hashtable x9505b0ae46363b0c;

	private x93b05c1ad709a695()
	{
	}

	internal static Encoding x9cfd780d6fc703c5(bool x5be1cad1d00af914)
	{
		if (!x5be1cad1d00af914)
		{
			return xaa122dba3e5cfe53;
		}
		return x25380d1c398dbd14;
	}

	internal static string x602d3c3fbfa56f51(BinaryReader xe134235b3526fa75, bool x5be1cad1d00af914, bool xac1baf51b3e43d13)
	{
		if (x5be1cad1d00af914)
		{
			int num = xe134235b3526fa75.ReadUInt16() * 2;
			if (!x0d299f323d241756.xd7d2f6dd32a72a3b(xe134235b3526fa75, num))
			{
				num = 0;
			}
			byte[] bytes = xe134235b3526fa75.ReadBytes(num);
			string @string = x9cfd780d6fc703c5(x5be1cad1d00af914).GetString(bytes);
			if (xac1baf51b3e43d13)
			{
				xe134235b3526fa75.ReadUInt16();
			}
			return @string;
		}
		int count = xe134235b3526fa75.ReadByte();
		byte[] bytes2 = xe134235b3526fa75.ReadBytes(count);
		string string2 = x9cfd780d6fc703c5(x5be1cad1d00af914).GetString(bytes2);
		if (xac1baf51b3e43d13)
		{
			xe134235b3526fa75.ReadByte();
		}
		return string2;
	}

	internal static int x4a3c44ae9b1cf5ab(string xbcea506a33cf9111, int xc2ba209522132173, BinaryWriter xbdfb620b7167944b, bool x5be1cad1d00af914, bool xac1baf51b3e43d13)
	{
		int num = (int)xbdfb620b7167944b.BaseStream.Position;
		xbcea506a33cf9111 = ((xbcea506a33cf9111 != null) ? xbcea506a33cf9111 : "");
		if (xbcea506a33cf9111.Length > xc2ba209522132173)
		{
			xbcea506a33cf9111 = xbcea506a33cf9111.Substring(0, xc2ba209522132173);
		}
		if (x5be1cad1d00af914)
		{
			xbdfb620b7167944b.Write((ushort)xbcea506a33cf9111.Length);
			byte[] bytes = x9cfd780d6fc703c5(x5be1cad1d00af914: true).GetBytes(xbcea506a33cf9111);
			xbdfb620b7167944b.Write(bytes);
			if (xac1baf51b3e43d13)
			{
				xbdfb620b7167944b.Write((ushort)0);
			}
		}
		else
		{
			int num2 = (byte)Math.Min(xbcea506a33cf9111.Length, 255);
			xbdfb620b7167944b.Write((byte)num2);
			byte[] bytes2 = x9cfd780d6fc703c5(x5be1cad1d00af914: false).GetBytes(xbcea506a33cf9111);
			xbdfb620b7167944b.Write(bytes2, 0, num2);
			if (xac1baf51b3e43d13)
			{
				xbdfb620b7167944b.Write((byte)0);
			}
		}
		return (int)xbdfb620b7167944b.BaseStream.Position - num;
	}

	internal static string x9c35bca780965b65(BinaryReader xe134235b3526fa75, int x5808173d78349062)
	{
		int num = (int)xe134235b3526fa75.BaseStream.Position;
		int val = xe134235b3526fa75.ReadUInt16() * 2;
		val = Math.Min(val, x5808173d78349062 - 2);
		byte[] bytes = xe134235b3526fa75.ReadBytes(val);
		string @string = x25380d1c398dbd14.GetString(bytes);
		xe134235b3526fa75.BaseStream.Position = num + x5808173d78349062;
		return @string;
	}

	internal static void xb8560c54099c0da8(string xbcea506a33cf9111, BinaryWriter xbdfb620b7167944b, int x5808173d78349062)
	{
		int val = x5808173d78349062 / 2 - 1;
		int num = Math.Min(xbcea506a33cf9111.Length, val);
		xbdfb620b7167944b.Write((ushort)num);
		byte[] bytes = x25380d1c398dbd14.GetBytes(xbcea506a33cf9111);
		int num2 = num * 2;
		xbdfb620b7167944b.Write(bytes, 0, num2);
		int num3 = x5808173d78349062 - num2 - 2;
		xbdfb620b7167944b.Write(new byte[num3]);
	}

	internal static string x79739b9c4ddc2495(BinaryReader xe134235b3526fa75, int xdd29aa438e247cc8)
	{
		if (xdd29aa438e247cc8 == 0)
		{
			return string.Empty;
		}
		byte[] bytes = xe134235b3526fa75.ReadBytes(xdd29aa438e247cc8);
		return x25380d1c398dbd14.GetString(bytes, 0, xdd29aa438e247cc8 - 2);
	}

	internal static string xf30570713d4bb9fe(BinaryReader xe134235b3526fa75)
	{
		int xdd29aa438e247cc = xe134235b3526fa75.ReadInt32();
		return x79739b9c4ddc2495(xe134235b3526fa75, xdd29aa438e247cc);
	}

	internal static string xb22524c2ced95a77(BinaryReader xe134235b3526fa75)
	{
		int xdd29aa438e247cc = xe134235b3526fa75.ReadInt32() * 2;
		return x79739b9c4ddc2495(xe134235b3526fa75, xdd29aa438e247cc);
	}

	internal static int x535736a60cc73a33(string xbcea506a33cf9111, BinaryWriter xbdfb620b7167944b)
	{
		byte[] array = new byte[x10e05a5c8b6822db(xbcea506a33cf9111)];
		x25380d1c398dbd14.GetBytes(xbcea506a33cf9111, 0, xbcea506a33cf9111.Length, array, 0);
		xbdfb620b7167944b.Write(array);
		return array.Length;
	}

	internal static void x81fe2fd2de403f38(string xbcea506a33cf9111, BinaryWriter xbdfb620b7167944b)
	{
		xbdfb620b7167944b.Write(xb7cc0a3fee42858b(xbcea506a33cf9111));
		x535736a60cc73a33(xbcea506a33cf9111, xbdfb620b7167944b);
	}

	internal static void x6cb8814ac91c34fd(string xbcea506a33cf9111, BinaryWriter xbdfb620b7167944b)
	{
		xbdfb620b7167944b.Write(x10e05a5c8b6822db(xbcea506a33cf9111));
		x535736a60cc73a33(xbcea506a33cf9111, xbdfb620b7167944b);
	}

	internal static int x10e05a5c8b6822db(string xbcea506a33cf9111)
	{
		return xb7cc0a3fee42858b(xbcea506a33cf9111) * 2;
	}

	internal static int xb7cc0a3fee42858b(string xbcea506a33cf9111)
	{
		return xbcea506a33cf9111.Length + 1;
	}

	internal static string x988c97967ba0308c(BinaryReader xe134235b3526fa75, int xdd29aa438e247cc8)
	{
		if (xdd29aa438e247cc8 == 0)
		{
			return string.Empty;
		}
		byte[] bytes = xe134235b3526fa75.ReadBytes(xdd29aa438e247cc8);
		return xaa122dba3e5cfe53.GetString(bytes, 0, xdd29aa438e247cc8 - 1);
	}

	internal static string xc2f73d64c3b147ae(BinaryReader xe134235b3526fa75)
	{
		int xdd29aa438e247cc = xe134235b3526fa75.ReadInt32();
		return x988c97967ba0308c(xe134235b3526fa75, xdd29aa438e247cc);
	}

	internal static char[] xc391923d699d676a(BinaryReader xe134235b3526fa75, bool x5be1cad1d00af914, int x10f4d88af727adbc)
	{
		byte[] bytes = xe134235b3526fa75.ReadBytes(x5be1cad1d00af914 ? (x10f4d88af727adbc * 2) : x10f4d88af727adbc);
		return x9cfd780d6fc703c5(x5be1cad1d00af914).GetChars(bytes);
	}

	internal static string x943278277eb1810b(BinaryReader xe134235b3526fa75, int x961016a387451f05, int xc1690d3515e1ed6c)
	{
		byte[] bytes = xe134235b3526fa75.ReadBytes(x961016a387451f05 - 1);
		xe134235b3526fa75.ReadByte();
		return Encoding.GetEncoding(xc1690d3515e1ed6c).GetString(bytes);
	}

	internal static string x943278277eb1810b(BinaryReader xe134235b3526fa75, int xc1690d3515e1ed6c)
	{
		return x943278277eb1810b(xe134235b3526fa75, xe134235b3526fa75.ReadInt16(), xc1690d3515e1ed6c);
	}

	internal static string x58db9aaa4a730e59(BinaryReader xe134235b3526fa75, int xc1690d3515e1ed6c)
	{
		int x961016a387451f = xe134235b3526fa75.ReadInt32();
		return x58db9aaa4a730e59(xe134235b3526fa75, x961016a387451f, xc1690d3515e1ed6c);
	}

	internal static string x58db9aaa4a730e59(BinaryReader xe134235b3526fa75, int x961016a387451f05, int xc1690d3515e1ed6c)
	{
		if (x961016a387451f05 == 0)
		{
			return string.Empty;
		}
		byte[] bytes = xe134235b3526fa75.ReadBytes(x961016a387451f05 - 1);
		xe134235b3526fa75.ReadByte();
		return Encoding.GetEncoding(xc1690d3515e1ed6c).GetString(bytes);
	}

	internal static void xc5ce8fce9f54ef55(BinaryWriter xbdfb620b7167944b, string xb41faee6912a2313, int xc1690d3515e1ed6c, bool xfa1f910fa3313cee)
	{
		if (xfa1f910fa3313cee)
		{
			xbdfb620b7167944b.Write((short)(xb41faee6912a2313.Length + 1));
		}
		xbdfb620b7167944b.Write(Encoding.GetEncoding(xc1690d3515e1ed6c).GetBytes(xb41faee6912a2313));
		xbdfb620b7167944b.Write((byte)0);
	}

	internal static x9e131021ba70185c x991d17aba8ce15b3(x9e131021ba70185c x77b06614416ee4d3)
	{
		return x77b06614416ee4d3 switch
		{
			x9e131021ba70185c.xc447809891322395 => x9e131021ba70185c.xf79eacb7dc6313bb, 
			x9e131021ba70185c.x1ea60bde2b5d0d28 => x9e131021ba70185c.xda79e5b626eda365, 
			_ => throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("faomfbfnobmnpbdomakohbbpfbipdappppfailmajaebhpkbhaccaajcjkpciogdcpndipeenjlenocfmojfgnagfnhgnnogomfhnnmhcndihmkinmbjanijjhpjkmgkmmnkamelclllkgcmnkjmdlandlhnofonekfogkmolkdpdjkpljbafjianipagegbginbfjecpilcmicdmhjdciaefiheocoeohffnhmfhgdgggkgogbhpfihogphdggiifniofejbgljkacklfjknfalbfhldeoljafm", 1774505395))), 
		};
	}

	internal static xc40bef0fb61c8a3e x7625b7f02c65c1cd(x9e131021ba70185c x77b06614416ee4d3)
	{
		return x77b06614416ee4d3 switch
		{
			x9e131021ba70185c.xc447809891322395 => xc40bef0fb61c8a3e.xc447809891322395, 
			x9e131021ba70185c.x1ea60bde2b5d0d28 => xc40bef0fb61c8a3e.x1ea60bde2b5d0d28, 
			_ => throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("jppepahfdaofdbfgiamgkpchfpjhdabibphinooigkfjgpmjfpdkpnkkonblgoilhnplgogmlnnmanengnlnjncocijodnapfnhpjmopllfabima", 124473252))), 
		};
	}

	internal static x448900fcb384c333 x304e11a498f3b177(int xbcea506a33cf9111)
	{
		return (x448900fcb384c333)x682712679dbc585a.xce92de628aa023cf(x462a070e16afbac5, xbcea506a33cf9111, x448900fcb384c333.x9700aad9bba3ce4a);
	}

	internal static int xe9e31472d474c9fc(x448900fcb384c333 xbcea506a33cf9111)
	{
		return (int)x682712679dbc585a.xce92de628aa023cf(x9505b0ae46363b0c, xbcea506a33cf9111, 0);
	}

	static x93b05c1ad709a695()
	{
		x25380d1c398dbd14 = Encoding.Unicode;
		xaa122dba3e5cfe53 = Encoding.GetEncoding(1252);
		x462a070e16afbac5 = new Hashtable();
		x9505b0ae46363b0c = new Hashtable();
		x682712679dbc585a.x70fa1602ceccddee(new object[10]
		{
			0,
			x448900fcb384c333.x9700aad9bba3ce4a,
			1,
			x448900fcb384c333.x842d1848287ed735,
			2,
			x448900fcb384c333.x17d0d2ce7db80a64,
			3,
			x448900fcb384c333.x9cc16fa5cbd496eb,
			4,
			x448900fcb384c333.x9d43eda807ddf817
		}, x462a070e16afbac5, x9505b0ae46363b0c);
	}
}
