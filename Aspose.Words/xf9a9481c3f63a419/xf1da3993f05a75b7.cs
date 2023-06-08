using System;
using System.IO;
using Aspose;
using x6c95d9cf46ff5f25;
using xe8730a664ff488a4;

namespace xf9a9481c3f63a419;

[JavaManual("Manual porting by design.")]
internal class xf1da3993f05a75b7
{
	private xf1da3993f05a75b7()
	{
	}

	public static byte[] x4671919d08389f8e(byte[] x3b4efd51efae57c2, int x584b67d526f6b9d5, x2e6ebe7013ab34b9 x1306445c04667cc7)
	{
		using MemoryStream x23cda4cfdf81f2cf = new MemoryStream(x3b4efd51efae57c2);
		return x4671919d08389f8e(x23cda4cfdf81f2cf, x584b67d526f6b9d5, x1306445c04667cc7);
	}

	public static byte[] x4671919d08389f8e(Stream x23cda4cfdf81f2cf, int x584b67d526f6b9d5, x2e6ebe7013ab34b9 x1306445c04667cc7)
	{
		if (x584b67d526f6b9d5 == 0)
		{
			x584b67d526f6b9d5 = (int)x23cda4cfdf81f2cf.Length;
		}
		MemoryStream memoryStream = new MemoryStream(x584b67d526f6b9d5);
		using (Stream x23cda4cfdf81f2cf2 = x873097914bbc6b35(x1306445c04667cc7, x23cda4cfdf81f2cf, x1f770018e5e12789.x706f07a5eea59a53))
		{
			x0d299f323d241756.x3ad8e53785c39acd(x23cda4cfdf81f2cf2, memoryStream);
		}
		return memoryStream.ToArray();
	}

	public static byte[] x575db3fedeadea6b(byte[] x3b4efd51efae57c2, x2e6ebe7013ab34b9 x1306445c04667cc7)
	{
		using MemoryStream x23cda4cfdf81f2cf = new MemoryStream(x3b4efd51efae57c2);
		return x575db3fedeadea6b(x23cda4cfdf81f2cf, x1306445c04667cc7);
	}

	public static byte[] x575db3fedeadea6b(Stream x23cda4cfdf81f2cf, x2e6ebe7013ab34b9 x1306445c04667cc7)
	{
		using MemoryStream memoryStream = new MemoryStream();
		x575db3fedeadea6b(x23cda4cfdf81f2cf, memoryStream, x1306445c04667cc7);
		return memoryStream.ToArray();
	}

	public static int x575db3fedeadea6b(Stream x23cda4cfdf81f2cf, MemoryStream xedc894794186020d, x2e6ebe7013ab34b9 x1306445c04667cc7)
	{
		int num = (int)xedc894794186020d.Position;
		using (Stream xedc894794186020d2 = x873097914bbc6b35(x1306445c04667cc7, xedc894794186020d, x1f770018e5e12789.x2688d9218ffd4d00))
		{
			x0d299f323d241756.x3ad8e53785c39acd(x23cda4cfdf81f2cf, xedc894794186020d2);
		}
		return (int)xedc894794186020d.Position - num;
	}

	public static int x575db3fedeadea6b(byte[] xf9a0d04800d70471, int x374ea4fe62468d0f, int x10f4d88af727adbc, Stream xedc894794186020d, x2e6ebe7013ab34b9 x1306445c04667cc7)
	{
		int num = (int)xedc894794186020d.Position;
		using (Stream stream = x873097914bbc6b35(x1306445c04667cc7, xedc894794186020d, x1f770018e5e12789.x2688d9218ffd4d00))
		{
			stream.Write(xf9a0d04800d70471, x374ea4fe62468d0f, x10f4d88af727adbc);
		}
		return (int)xedc894794186020d.Position - num;
	}

	private static Stream x873097914bbc6b35(x2e6ebe7013ab34b9 x1306445c04667cc7, Stream xcf18e5243f8d5fd3, x1f770018e5e12789 x357ffcbc1f54653c)
	{
		return x1306445c04667cc7 switch
		{
			x2e6ebe7013ab34b9.x575db3fedeadea6b => new xdd609f761b3f07f0(xcf18e5243f8d5fd3, x357ffcbc1f54653c, leaveOpen: true), 
			x2e6ebe7013ab34b9.x1455a9a8b1cd9f39 => new xcb7f94e60ac944b2(xcf18e5243f8d5fd3, x357ffcbc1f54653c, leaveOpen: true), 
			_ => throw new InvalidOperationException("Unknown compression method specified."), 
		};
	}
}
