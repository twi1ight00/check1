using System;
using System.IO;
using System.Text;
using Aspose.Words;
using x13f1efc79617a47b;
using x5f3520a4b31ea90f;
using x6c95d9cf46ff5f25;
using xb92b7270f78a4e8d;
using xcf014befd8b52c3b;

namespace xc8ef30c5dc53a453;

internal class x414106297e729800
{
	private readonly Random xa69bdc19d203240d = new Random();

	private byte[] xa53af6f501ef3cfc;

	internal void xcc381ffa3ede662f(xd8c3135513b9115b x84378c276c4cd7e2, string x51bb737361e07832, string xe8e4b5871d71a79a)
	{
		Stream input = x84378c276c4cd7e2.x29e7ace4c90f74cd.xb3b34047219bdc2a(x51bb737361e07832);
		BinaryReader binaryReader = new BinaryReader(input);
		switch ((xa28da04a3e363556)binaryReader.ReadInt32())
		{
		case xa28da04a3e363556.x87c6e8b751d15100:
		case xa28da04a3e363556.xd4a83f9d5c663199:
		case xa28da04a3e363556.x51a3b752f386bc73:
			throw new UnsupportedFileFormatException("The document is encrypted using the RC4 CryptoAPI Encryption and this not currently supported.");
		default:
			throw new InvalidOperationException("Unexpected encryption version.");
		case xa28da04a3e363556.x005b3497e4ca1670:
			if (!x34c52f11773929a9(binaryReader, xe8e4b5871d71a79a))
			{
				throw new IncorrectPasswordException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("joiekppeepgfmknfnoegfplggochfpjhkoaipnhifooiiofjbjmjondkmmkklnbliniljnplomgmomnmnlenghlnmlcodmjongapdlhpflophkfaalmaaldbnkkbnjbcijicgkpcnfgd", 852314261)));
			}
			x27d5a61d335f14b4(x84378c276c4cd7e2, x51bb737361e07832);
			break;
		}
	}

	internal void x34c2fd9630dc4e80(BinaryWriter xbdfb620b7167944b, string xe8e4b5871d71a79a)
	{
		xbdfb620b7167944b.Write(65537);
		xcb01dc186c493bcc(xbdfb620b7167944b, xe8e4b5871d71a79a);
	}

	internal void x246b032720dd4c0d(xd8c3135513b9115b x84378c276c4cd7e2, string x51bb737361e07832)
	{
		x27d5a61d335f14b4(x84378c276c4cd7e2, x51bb737361e07832);
	}

	private void x27d5a61d335f14b4(xd8c3135513b9115b x84378c276c4cd7e2, string x51bb737361e07832)
	{
		x005b3497e4ca1670 x70247fb88dc09b = new x005b3497e4ca1670();
		xd78390ba78d1e48a(x70247fb88dc09b, x84378c276c4cd7e2, x51bb737361e07832, 52);
		xd78390ba78d1e48a(x70247fb88dc09b, x84378c276c4cd7e2, "WordDocument", 68);
		xd78390ba78d1e48a(x70247fb88dc09b, x84378c276c4cd7e2, "Data", 0);
	}

	private void xd78390ba78d1e48a(x005b3497e4ca1670 x70247fb88dc09b25, xd8c3135513b9115b x84378c276c4cd7e2, string x6b3767cca34443a2, int x53749c8463b1d9db)
	{
		Stream stream = (MemoryStream)x84378c276c4cd7e2.x29e7ace4c90f74cd[x6b3767cca34443a2];
		if (stream != null)
		{
			byte[] buffer = new byte[x53749c8463b1d9db];
			stream.Position = 0L;
			stream.Read(buffer, 0, x53749c8463b1d9db);
			x8aea8dfcbb5b5cc5(x70247fb88dc09b25, stream);
			stream.Position = 0L;
			stream.Write(buffer, 0, x53749c8463b1d9db);
		}
	}

	private void x8aea8dfcbb5b5cc5(x005b3497e4ca1670 x70247fb88dc09b25, Stream xcf18e5243f8d5fd3)
	{
		if (xcf18e5243f8d5fd3 == null)
		{
			return;
		}
		xcf18e5243f8d5fd3.Position = 0L;
		uint num = 0u;
		x3ef08f31ab7d3e00(x70247fb88dc09b25, num);
		byte[] array = new byte[16];
		int num2 = 0;
		while (num2 < xcf18e5243f8d5fd3.Length)
		{
			int num3 = xcf18e5243f8d5fd3.Read(array, 0, array.Length);
			x70247fb88dc09b25.xcc381ffa3ede662f(array, num3);
			xcf18e5243f8d5fd3.Position -= num3;
			xcf18e5243f8d5fd3.Write(array, 0, num3);
			num2 += num3;
			if (num2 % 512 == 0)
			{
				num++;
				x3ef08f31ab7d3e00(x70247fb88dc09b25, num);
			}
		}
		xcf18e5243f8d5fd3.Position = 0L;
	}

	private void x3ef08f31ab7d3e00(x005b3497e4ca1670 x70247fb88dc09b25, uint xe413319369b234aa)
	{
		byte[] array = new byte[16];
		Array.Copy(xa53af6f501ef3cfc, 0, array, 0, 5);
		Array.Copy(BitConverter.GetBytes(xe413319369b234aa), 0, array, 5, 4);
		x70247fb88dc09b25.xb04c56f3a10310d3(xca828a8ec02ab940(array, 9));
	}

	private x005b3497e4ca1670 x782857723f21af8b(string xe8e4b5871d71a79a, byte[] xfe758ab07df158bc)
	{
		byte[] bytes = Encoding.Unicode.GetBytes((xe8e4b5871d71a79a == null) ? "" : xe8e4b5871d71a79a);
		xa53af6f501ef3cfc = xca828a8ec02ab940(bytes);
		byte[] array = new byte[336];
		for (int i = 0; i < 16; i++)
		{
			Array.Copy(xa53af6f501ef3cfc, 0, array, i * 21, 5);
			Array.Copy(xfe758ab07df158bc, 0, array, i * 21 + 5, 16);
		}
		xa53af6f501ef3cfc = xca828a8ec02ab940(array);
		x005b3497e4ca1670 x005b3497e4ca = new x005b3497e4ca1670();
		x3ef08f31ab7d3e00(x005b3497e4ca, 0u);
		return x005b3497e4ca;
	}

	private bool x34c52f11773929a9(BinaryReader xe134235b3526fa75, string xe8e4b5871d71a79a)
	{
		byte[] xfe758ab07df158bc = xe134235b3526fa75.ReadBytes(16);
		byte[] array = xe134235b3526fa75.ReadBytes(16);
		byte[] array2 = xe134235b3526fa75.ReadBytes(16);
		x005b3497e4ca1670 x005b3497e4ca = x782857723f21af8b(xe8e4b5871d71a79a, xfe758ab07df158bc);
		x005b3497e4ca.xcc381ffa3ede662f(array, 16);
		x005b3497e4ca.xcc381ffa3ede662f(array2, 16);
		return xcd4bd3abd72ff2da.x5fa70910f253aafa(xca828a8ec02ab940(array), array2, 16);
	}

	private void xcb01dc186c493bcc(BinaryWriter xbdfb620b7167944b, string xe8e4b5871d71a79a)
	{
		byte[] array = xff897bbc0ce9fc68(16);
		byte[] array2 = xff897bbc0ce9fc68(16);
		x005b3497e4ca1670 x005b3497e4ca = x782857723f21af8b(xe8e4b5871d71a79a, array);
		byte[] array3 = new byte[16];
		byte[] array4 = new byte[16];
		x005b3497e4ca.x246b032720dd4c0d(array2, array3);
		x005b3497e4ca.x246b032720dd4c0d(xca828a8ec02ab940(array2), array4);
		xbdfb620b7167944b.Write(array);
		xbdfb620b7167944b.Write(array3);
		xbdfb620b7167944b.Write(array4);
	}

	private byte[] xff897bbc0ce9fc68(int x10f4d88af727adbc)
	{
		byte[] array = new byte[x10f4d88af727adbc];
		xa69bdc19d203240d.NextBytes(array);
		return array;
	}

	private static byte[] xca828a8ec02ab940(byte[] xf9a0d04800d70471)
	{
		x1e72f71e14224f7d x1e72f71e14224f7d = new x1e72f71e14224f7d();
		x1e72f71e14224f7d.x295cb4a1df7a5add(xf9a0d04800d70471, xf9a0d04800d70471.Length);
		x1e72f71e14224f7d.x20098fa15e62301f();
		return x1e72f71e14224f7d.x7a569e28d68fded6;
	}

	private static byte[] xca828a8ec02ab940(byte[] xf9a0d04800d70471, int x961016a387451f05)
	{
		x1e72f71e14224f7d x1e72f71e14224f7d = new x1e72f71e14224f7d();
		x1e72f71e14224f7d.x295cb4a1df7a5add(xf9a0d04800d70471, x961016a387451f05);
		x1e72f71e14224f7d.x20098fa15e62301f();
		return x1e72f71e14224f7d.x7a569e28d68fded6;
	}
}
