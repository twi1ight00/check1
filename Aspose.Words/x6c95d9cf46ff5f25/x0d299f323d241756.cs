using System;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using Aspose;
using x13f1efc79617a47b;
using xf9a9481c3f63a419;

namespace x6c95d9cf46ff5f25;

internal class x0d299f323d241756
{
	private static readonly char[] xe87f11a4e1a5b346 = new char[1] { ';' };

	private static readonly char[] x172a57be5d404d19 = new char[1] { ',' };

	private static readonly char[] x307f9fd06a46baed = new char[16]
	{
		'0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
		'A', 'B', 'C', 'D', 'E', 'F'
	};

	private x0d299f323d241756()
	{
	}

	public static void x3ae29f473f29ef2a(int xbcea506a33cf9111, byte[] xf9a0d04800d70471, int x374ea4fe62468d0f)
	{
		for (int i = 0; i < 4; i++)
		{
			xf9a0d04800d70471[x374ea4fe62468d0f + i] = (byte)xbcea506a33cf9111;
			xbcea506a33cf9111 >>= 8;
		}
	}

	public static void x244f57c2c3806fa8(uint xbcea506a33cf9111, Stream xcf18e5243f8d5fd3)
	{
		for (int i = 0; i < 4; i++)
		{
			xcf18e5243f8d5fd3.WriteByte((byte)xbcea506a33cf9111);
			xbcea506a33cf9111 >>= 8;
		}
	}

	public static void x01a74f169007d206(string xbcea506a33cf9111, Stream xcf18e5243f8d5fd3)
	{
		foreach (char c in xbcea506a33cf9111)
		{
			xcf18e5243f8d5fd3.WriteByte((byte)c);
		}
	}

	public static bool x7e32f71c3f39b6bc(long xbcea506a33cf9111)
	{
		return (xbcea506a33cf9111 & 1) != 0;
	}

	public static int xc82acf77a8e0e053(long xbcea506a33cf9111, int x4aea405f60556ff3)
	{
		long num = xbcea506a33cf9111 / x4aea405f60556ff3;
		if (xbcea506a33cf9111 % x4aea405f60556ff3 != 0)
		{
			num++;
		}
		return (int)num;
	}

	public static int x8b2ecf3d830a9342(long xbcea506a33cf9111, int x4aea405f60556ff3)
	{
		return xc82acf77a8e0e053(xbcea506a33cf9111, x4aea405f60556ff3) * x4aea405f60556ff3;
	}

	public static void xb66a70c14b63a912(Stream xcf18e5243f8d5fd3, int x278780fb19a87271)
	{
		int num = x8b2ecf3d830a9342(xcf18e5243f8d5fd3.Position, x278780fb19a87271);
		if (xcf18e5243f8d5fd3.Length < num)
		{
			xcf18e5243f8d5fd3.SetLength(num);
		}
		xcf18e5243f8d5fd3.Position = num;
	}

	public static byte[] x0c3d0a26320bf3c4(Stream xcf18e5243f8d5fd3, int x961016a387451f05)
	{
		long position = xcf18e5243f8d5fd3.Position;
		byte[] array = new byte[x961016a387451f05];
		xcf18e5243f8d5fd3.Read(array, 0, array.Length);
		xcf18e5243f8d5fd3.Position = position;
		return array;
	}

	public static void x3ad8e53785c39acd(Stream x23cda4cfdf81f2cf, Stream xedc894794186020d)
	{
		if (x23cda4cfdf81f2cf == null)
		{
			throw new ArgumentNullException("srcStream");
		}
		if (xedc894794186020d == null)
		{
			throw new ArgumentNullException("dstStream");
		}
		byte[] array = new byte[4096];
		while (true)
		{
			int num = x23cda4cfdf81f2cf.Read(array, 0, array.Length);
			if (num <= 0)
			{
				break;
			}
			xedc894794186020d.Write(array, 0, num);
		}
	}

	public static MemoryStream xbb72e91bbb228dbd(Stream x23cda4cfdf81f2cf)
	{
		if (x23cda4cfdf81f2cf is MemoryStream)
		{
			return (MemoryStream)x23cda4cfdf81f2cf;
		}
		MemoryStream memoryStream = new MemoryStream((int)x23cda4cfdf81f2cf.Length);
		x3ad8e53785c39acd(x23cda4cfdf81f2cf, memoryStream);
		return memoryStream;
	}

	public static byte[] xa0aed4cd3b3d5d92(Stream x23cda4cfdf81f2cf)
	{
		if (x23cda4cfdf81f2cf == null)
		{
			throw new ArgumentNullException("srcStream");
		}
		byte[] array = new byte[(int)x23cda4cfdf81f2cf.Length];
		using MemoryStream xedc894794186020d = new MemoryStream(array);
		x23cda4cfdf81f2cf.Position = 0L;
		x3ad8e53785c39acd(x23cda4cfdf81f2cf, xedc894794186020d);
		return array;
	}

	public static void x7f5367c19012457c(string xafe2f3653ee64ebc, Stream xedc894794186020d)
	{
		using Stream x23cda4cfdf81f2cf = File.OpenRead(xafe2f3653ee64ebc);
		x3ad8e53785c39acd(x23cda4cfdf81f2cf, xedc894794186020d);
	}

	public static byte[] xcd163eef5c6f46eb(string xafe2f3653ee64ebc)
	{
		using Stream x23cda4cfdf81f2cf = File.OpenRead(xafe2f3653ee64ebc);
		return xa0aed4cd3b3d5d92(x23cda4cfdf81f2cf);
	}

	[JavaThrows(true)]
	public static Stream x2f4c87e11bfb8f32()
	{
		return xed747ca236d86aa0.xe1cd764b6fb0d6f6("Aspose.Resources.NoImage.png");
	}

	[JavaThrows(true)]
	public static byte[] xcd6c2a9742c9220a()
	{
		using Stream x23cda4cfdf81f2cf = x2f4c87e11bfb8f32();
		return xa0aed4cd3b3d5d92(x23cda4cfdf81f2cf);
	}

	[JavaDelete("Don't need this logging method in Java.")]
	public static string xd0b98a7a416f4bca(object xa59bff7708de3a18, string xc15bd84e01929885)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("{0} Start\n", xc15bd84e01929885);
		Type type = xa59bff7708de3a18.GetType();
		FieldInfo[] fields = type.GetFields();
		FieldInfo[] array = fields;
		foreach (FieldInfo fieldInfo in array)
		{
			stringBuilder.AppendFormat("{0}:{1}, 0x{2:X}\n", fieldInfo.Name, fieldInfo.GetValue(xa59bff7708de3a18), fieldInfo.GetValue(xa59bff7708de3a18));
		}
		stringBuilder.AppendFormat("{0} End", xc15bd84e01929885);
		return stringBuilder.ToString();
	}

	public static bool x5959bccb67bbf051(string xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 != null)
		{
			return xbcea506a33cf9111.Length > 0;
		}
		return false;
	}

	public static string x3b67e683e83cab62(string xe4115acdf4fbfccc, int x961016a387451f05)
	{
		if (x961016a387451f05 > 0 && x5959bccb67bbf051(xe4115acdf4fbfccc))
		{
			if (x961016a387451f05 < xe4115acdf4fbfccc.Length)
			{
				if (x961016a387451f05 > "...".Length)
				{
					return xe4115acdf4fbfccc.Substring(0, x961016a387451f05 - "...".Length) + "...";
				}
				return xe4115acdf4fbfccc.Substring(0, x961016a387451f05);
			}
			return xe4115acdf4fbfccc;
		}
		return string.Empty;
	}

	public static string xe567645d42f42c56(string xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 == null)
		{
			return "";
		}
		return xbcea506a33cf9111;
	}

	public static void x48501aec8e48c869(string xbcea506a33cf9111, string xae050273e3024171)
	{
		if (!x5959bccb67bbf051(xbcea506a33cf9111))
		{
			throw new ArgumentException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("dhjdeiaeohhegdoeehffcimfehdgphkgehbhjgihpgphchgilbnilfejgfljagcknfjklfalnfhlgaolfefmfemmnpcnieknmeboaeiondpooofpkdnpkdeafokahccbmcjbmcacnchcpcocdneddcmdbcdembkeabbfcbifiapfmmfg", 1669675295)), xae050273e3024171);
		}
	}

	public static void x0aaaea7864a53f26(object xbcea506a33cf9111, string xae050273e3024171)
	{
		if (xbcea506a33cf9111 == null)
		{
			throw new ArgumentNullException(xae050273e3024171);
		}
	}

	public static void x9f9950877f77fc71(int xbcea506a33cf9111, int xd088075e67f6ea91, int xffd6352b2e5d70e3, string xae050273e3024171)
	{
		if (xbcea506a33cf9111 < xd088075e67f6ea91 || xbcea506a33cf9111 > xffd6352b2e5d70e3)
		{
			throw new ArgumentOutOfRangeException(xae050273e3024171, $"Expected a value between {xd088075e67f6ea91} and {xffd6352b2e5d70e3}.");
		}
	}

	public static void x14b71bdc94c08892(int xbcea506a33cf9111, string xae050273e3024171)
	{
		if (xbcea506a33cf9111 <= 0)
		{
			throw new ArgumentOutOfRangeException(xae050273e3024171, "Expected a positive value.");
		}
	}

	public static double x0b2d7be73d532b1c(double xbcea506a33cf9111, double x40eacaf8b0643384, double x84558e8cd912d047, double x2fbae2a8eacbd571, double xb2b9329906fc738e, bool x9199ed88324d69ff, string xae050273e3024171)
	{
		if (xbcea506a33cf9111 < x40eacaf8b0643384)
		{
			if (x9199ed88324d69ff)
			{
				throw new ArgumentOutOfRangeException(xae050273e3024171);
			}
			return x84558e8cd912d047;
		}
		if (xbcea506a33cf9111 > x2fbae2a8eacbd571)
		{
			if (x9199ed88324d69ff)
			{
				throw new ArgumentOutOfRangeException(xae050273e3024171);
			}
			return xb2b9329906fc738e;
		}
		return xbcea506a33cf9111;
	}

	public static int xa6ad07b252a1909e(double xbcea506a33cf9111)
	{
		long num = (long)xbcea506a33cf9111;
		return (int)num;
	}

	public static bool x94708db220d6095c(string xb41faee6912a2313)
	{
		foreach (char c in xb41faee6912a2313)
		{
			if (c > '\u007f')
			{
				return false;
			}
		}
		return true;
	}

	public static bool x263d579af1d0d43f(string xb41faee6912a2313, string xd30d8f5dec7a497f, bool x8b05b1454697839b)
	{
		if (x8b05b1454697839b)
		{
			xb41faee6912a2313 = xb41faee6912a2313.ToUpper();
			xd30d8f5dec7a497f = xd30d8f5dec7a497f.ToUpper();
		}
		return xb41faee6912a2313.IndexOf(xd30d8f5dec7a497f) >= 0;
	}

	public static bool x0fb62ca630231ea1(string xb41faee6912a2313)
	{
		foreach (char c in xb41faee6912a2313)
		{
			if (c != ' ')
			{
				return false;
			}
		}
		return true;
	}

	public static bool x70405672eb3bbb86(string xb41faee6912a2313)
	{
		foreach (char c in xb41faee6912a2313)
		{
			if (!char.IsWhiteSpace(c))
			{
				return false;
			}
		}
		return true;
	}

	public static bool x6df149467337111e(string xb41faee6912a2313)
	{
		foreach (char c in xb41faee6912a2313)
		{
			if (char.IsWhiteSpace(c))
			{
				return true;
			}
		}
		return false;
	}

	public static bool x6c589c7857d7d8d9(int xb867a42da3ae686d)
	{
		switch (xb867a42da3ae686d)
		{
		case 9:
		case 10:
		case 13:
		case 32:
			return true;
		default:
			return false;
		}
	}

	public static int xe3ec68422266caf1(char xbc30138fc52cbe85)
	{
		int num = ((xbc30138fc52cbe85 > '9') ? (x69b84707f222de4b(xbc30138fc52cbe85) + 10) : (xbc30138fc52cbe85 - 48));
		if (num < 0 || num > 15)
		{
			throw new ArgumentOutOfRangeException("digit");
		}
		return num;
	}

	public static int x69b84707f222de4b(char x2ee697aec58da9cc)
	{
		int num = x2ee697aec58da9cc - ((x2ee697aec58da9cc <= 'Z') ? 65 : 97);
		if (num < 0 || num > 25)
		{
			throw new ArgumentOutOfRangeException("letter");
		}
		return num;
	}

	public static bool x4083ed3571df5d9e(int xb867a42da3ae686d)
	{
		if (xb867a42da3ae686d < 97 || xb867a42da3ae686d > 122)
		{
			if (xb867a42da3ae686d >= 65)
			{
				return xb867a42da3ae686d <= 90;
			}
			return false;
		}
		return true;
	}

	public static bool xb8f085ba3fb39f54(char xb867a42da3ae686d)
	{
		if ((xb867a42da3ae686d < '0' || xb867a42da3ae686d > '9') && (xb867a42da3ae686d < 'A' || xb867a42da3ae686d > 'F'))
		{
			if (xb867a42da3ae686d >= 'a')
			{
				return xb867a42da3ae686d <= 'f';
			}
			return false;
		}
		return true;
	}

	public static bool xff96b3c50e8ffc1f(string xbcea506a33cf9111)
	{
		foreach (char xb867a42da3ae686d in xbcea506a33cf9111)
		{
			if (!xf95996ff451b85fa(xb867a42da3ae686d))
			{
				return false;
			}
		}
		return true;
	}

	public static bool x070f78755d5832a1(string xbcea506a33cf9111)
	{
		foreach (char xb867a42da3ae686d in xbcea506a33cf9111)
		{
			if (!xb8f085ba3fb39f54(xb867a42da3ae686d))
			{
				return false;
			}
		}
		return true;
	}

	public static string x482624a13e9e9d98(byte[] xf9a0d04800d70471, int xd4f974c06ffa392b, int x961016a387451f05, bool x2e6b322d68dfff21)
	{
		StringBuilder stringBuilder = new StringBuilder(x961016a387451f05 * 2);
		int num = ((!x2e6b322d68dfff21) ? 1 : (-1));
		if (x2e6b322d68dfff21)
		{
			xd4f974c06ffa392b += x961016a387451f05 - 1;
		}
		for (int i = 0; i < x961016a387451f05; i++)
		{
			stringBuilder.Append(xd7eddd4ee94f26bb(xf9a0d04800d70471[xd4f974c06ffa392b]));
			xd4f974c06ffa392b += num;
		}
		return stringBuilder.ToString();
	}

	public static char[] xd7eddd4ee94f26bb(byte xe7ebe10fa44d8d49)
	{
		return new char[2]
		{
			x307f9fd06a46baed[(xe7ebe10fa44d8d49 >> 4) & 0xF],
			x307f9fd06a46baed[xe7ebe10fa44d8d49 & 0xF]
		};
	}

	public static string x482624a13e9e9d98(byte[] xf9a0d04800d70471)
	{
		return x482624a13e9e9d98(xf9a0d04800d70471, 0, xf9a0d04800d70471.Length, x2e6b322d68dfff21: false);
	}

	public static bool x90637a473b1ceaaa(string x19218ffab70283ef, string xe7ebe10fa44d8d49)
	{
		return x27cd5f9641d9eb15.x90637a473b1ceaaa(x19218ffab70283ef, xe7ebe10fa44d8d49);
	}

	public static bool x25e9a0e7dc336c01(SizeF xac2c11ccc65c0b4f, SizeF x439d7faadefded61, bool x34eb37a12a81c6f3, double xc256ad1be81a2ec4)
	{
		if (x34eb37a12a81c6f3)
		{
			if ((double)Math.Abs(xac2c11ccc65c0b4f.Width - x439d7faadefded61.Height) <= xc256ad1be81a2ec4 && (double)Math.Abs(xac2c11ccc65c0b4f.Height - x439d7faadefded61.Width) <= xc256ad1be81a2ec4)
			{
				return true;
			}
		}
		else if ((double)Math.Abs(xac2c11ccc65c0b4f.Width - x439d7faadefded61.Width) <= xc256ad1be81a2ec4 && (double)Math.Abs(xac2c11ccc65c0b4f.Height - x439d7faadefded61.Height) <= xc256ad1be81a2ec4)
		{
			return true;
		}
		return false;
	}

	public static bool[] x1e86cfa3e4cb412a(byte xcdaeea7afaf570ff)
	{
		bool[] array = new bool[8];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = (xcdaeea7afaf570ff & (1 << i)) != 0;
		}
		return array;
	}

	public static byte[] x90000f01e9f4b628(Guid xb51cd75f17ace1ec)
	{
		byte[] array = xb51cd75f17ace1ec.ToByteArray();
		Array.Reverse(array, 0, 4);
		Array.Reverse(array, 4, 2);
		Array.Reverse(array, 6, 2);
		return array;
	}

	public static char[] x644019557e120d6e()
	{
		return xca004f56614e2431.xaccdf4f36d70782c() switch
		{
			',' => xe87f11a4e1a5b346, 
			_ => x172a57be5d404d19, 
		};
	}

	public static bool xd7d2f6dd32a72a3b(BinaryReader xe134235b3526fa75, int xc7367ec35e418063)
	{
		return xc7367ec35e418063 <= xe134235b3526fa75.BaseStream.Length - xe134235b3526fa75.BaseStream.Position;
	}

	public static PointF x7c91cffb7e0460c1(PointF x2f7096dac971d6ec, SizeF x374ea4fe62468d0f)
	{
		return new PointF(x2f7096dac971d6ec.X + x374ea4fe62468d0f.Width, x2f7096dac971d6ec.Y + x374ea4fe62468d0f.Height);
	}

	public static bool xf95996ff451b85fa(int xb867a42da3ae686d)
	{
		if (xb867a42da3ae686d >= 48)
		{
			return xb867a42da3ae686d <= 57;
		}
		return false;
	}

	public static StringCollection x67bd11727bb1eb41(string x1a37a0209eb19332, bool xa5c28c1d423983a7)
	{
		StringCollection stringCollection = new StringCollection();
		if (xa5c28c1d423983a7)
		{
			xc2f922619dae4ea8(stringCollection, x1a37a0209eb19332);
		}
		else
		{
			stringCollection.AddRange(Directory.GetFiles(x1a37a0209eb19332));
		}
		return stringCollection;
	}

	private static void xc2f922619dae4ea8(StringCollection x58c3a0df2fc736ea, string x1a37a0209eb19332)
	{
		x58c3a0df2fc736ea.AddRange(Directory.GetFiles(x1a37a0209eb19332));
		string[] directories = Directory.GetDirectories(x1a37a0209eb19332);
		foreach (string x1a37a0209eb19333 in directories)
		{
			xc2f922619dae4ea8(x58c3a0df2fc736ea, x1a37a0209eb19333);
		}
	}

	public static void x27d8ee3f0a83f46a(Exception xc3c70767499bc99a)
	{
	}

	public static bool x8613aad20adc128b(char[] x80de18ecf198e7a3, char xfb4377b82e1925d3)
	{
		foreach (char c in x80de18ecf198e7a3)
		{
			if (xfb4377b82e1925d3 == c)
			{
				return true;
			}
		}
		return false;
	}

	public static string xdd8b55ba4e7542c3(string xcdaeea7afaf570ff)
	{
		for (int num = xcdaeea7afaf570ff.Length - 1; num >= 0; num--)
		{
			if (char.IsDigit(xcdaeea7afaf570ff[num]))
			{
				return xcdaeea7afaf570ff.Substring(0, num + 1);
			}
		}
		return xcdaeea7afaf570ff;
	}

	public static Uri xece38db10adcf774(string xedb68c88eeeae8c4)
	{
		if (!x5959bccb67bbf051(xedb68c88eeeae8c4))
		{
			return null;
		}
		try
		{
			return new Uri(xedb68c88eeeae8c4);
		}
		catch (UriFormatException)
		{
			return null;
		}
	}

	public static void x40fc7e8a0d01195b(MemoryStream xcf18e5243f8d5fd3)
	{
		xcf18e5243f8d5fd3.Dispose();
	}

	public static string xed53f96588a7739b(string xf6987a1745781d6f)
	{
		char[] array = xf6987a1745781d6f.ToCharArray();
		Array.Reverse(array);
		return new string(array);
	}
}
