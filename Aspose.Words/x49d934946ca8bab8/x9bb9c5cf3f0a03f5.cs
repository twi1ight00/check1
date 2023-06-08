using System.IO;
using x45a758cd6bdecee3;
using x66dd9eaee57cfba4;
using x6c95d9cf46ff5f25;

namespace x49d934946ca8bab8;

internal class x9bb9c5cf3f0a03f5
{
	private const short xb55284dd5f96ccd5 = 255;

	private const short x1a2629948d0dd6c8 = 248;

	private const short x01e755dffd45b7e2 = 247;

	private const short x73c9d493164ffd14 = 239;

	private const short x240b7d663c81edbb = 238;

	public static byte[] xf76803be5e9ee2aa(byte[] x1fcfa035bd2b2edc, byte[] xe65822bb53be3680, byte[] xad086f0b0726868e)
	{
		using MemoryStream stream = new MemoryStream(x1fcfa035bd2b2edc);
		xb9381f7c20d1401f xb9381f7c20d1401f = new xb9381f7c20d1401f(stream);
		xb9381f7c20d1401f.x43325fdd19b94194();
		xb9381f7c20d1401f.x98741c31b7c91763("head");
		xd3f6a3354dad6708 xd3f6a3354dad = xd3f6a3354dad6708.x06b0e25aa6ad68a9(xb9381f7c20d1401f.x7468be44f5498f9f);
		xb9381f7c20d1401f.x98741c31b7c91763("maxp");
		x52be9978b7030549 x52be9978b = new x52be9978b7030549(xb9381f7c20d1401f.x7468be44f5498f9f);
		xb9381f7c20d1401f.x98741c31b7c91763("hhea");
		xcfe8f756bd6386e3 xcfe8f756bd6386e = new xcfe8f756bd6386e3(xb9381f7c20d1401f.x7468be44f5498f9f);
		xb9381f7c20d1401f.x98741c31b7c91763("hmtx");
		x49a6906320d20269 x46ef2beff2d00b = new x49a6906320d20269(xb9381f7c20d1401f.x7468be44f5498f9f, xcfe8f756bd6386e.x68ab60d77e158693, x52be9978b.xf465816ce1e6196c);
		x483dcea572fd1c73 x483dcea572fd1c = new x483dcea572fd1c73(xb9381f7c20d1401f.xc3be943b246eeabb.x77fa6322561797a0);
		foreach (x1d5a785c8d5b14ee value in xb9381f7c20d1401f.x5eab864c00224c02.GetValueList())
		{
			switch (value.xd229d86af0f16fb0)
			{
			case "hdmx":
				x483dcea572fd1c.x53eb838d813e202e(value.xd229d86af0f16fb0, x5b0557d4a0ca4dc4(xb9381f7c20d1401f.xed7d554f6c638fb0(value.xd229d86af0f16fb0), x52be9978b.xf465816ce1e6196c, xd3f6a3354dad.x0b1ef6b23d680fe3, x46ef2beff2d00b));
				break;
			case "VDMX":
				x483dcea572fd1c.x53eb838d813e202e(value.xd229d86af0f16fb0, xd9ac597940231e4f(xb9381f7c20d1401f.xed7d554f6c638fb0(value.xd229d86af0f16fb0)));
				break;
			case "cvt ":
				x483dcea572fd1c.x53eb838d813e202e(value.xd229d86af0f16fb0, x07938d6006ab91ed(xb9381f7c20d1401f.xed7d554f6c638fb0(value.xd229d86af0f16fb0)));
				break;
			case "glyf":
				xaade977c63491e36.xa36a060aa30a1d52(x483dcea572fd1c, xb9381f7c20d1401f.xed7d554f6c638fb0(value.xd229d86af0f16fb0), xe65822bb53be3680, xad086f0b0726868e, xd3f6a3354dad);
				break;
			default:
				x483dcea572fd1c.x53eb838d813e202e(value.xd229d86af0f16fb0, xb9381f7c20d1401f.xed7d554f6c638fb0(value.xd229d86af0f16fb0));
				break;
			case "loca":
			case "head":
				break;
			}
		}
		x483dcea572fd1c.x53eb838d813e202e("head", xd3f6a3354dad.x2797b998ab68f4ab());
		return x483dcea572fd1c.x094a5f6342d60df4();
	}

	private static byte[] x07938d6006ab91ed(byte[] x89fb45eae1c0ead6)
	{
		using MemoryStream stream = new MemoryStream(x89fb45eae1c0ead6);
		xa8866d7566da0aa2 xa8866d7566da0aa = new xa8866d7566da0aa2(stream);
		ushort num = xa8866d7566da0aa.xdb264d863790ee7b();
		using MemoryStream memoryStream = new MemoryStream(num * 2);
		x73087173962e3778 x73087173962e = new x73087173962e3778(memoryStream);
		short num2 = 0;
		for (int i = 0; i < num; i++)
		{
			short num3 = xa8866d7566da0aa.x672ed37ee25c078c();
			int num4;
			if (num3 < 238)
			{
				num4 = num2 + num3;
			}
			else if (num3 >= 248 && num3 <= 255)
			{
				short num5 = xa8866d7566da0aa.x672ed37ee25c078c();
				int num6 = 238 * (num3 - 248 + 1) + num5;
				num4 = num2 + num6;
			}
			else if (num3 >= 239 && num3 <= 247)
			{
				short num7 = xa8866d7566da0aa.x672ed37ee25c078c();
				int num8 = -(238 * (num3 - 239) + num7);
				num4 = num2 + num8;
			}
			else
			{
				num4 = num2 + xa8866d7566da0aa.x2e6b89ad8001e18f();
			}
			if (num4 < -32768)
			{
				num4 += 65536;
			}
			else if (num4 > 32767)
			{
				num4 -= 65536;
			}
			x73087173962e.xab5f6b7526efa5be(num4);
			num2 = (short)num4;
		}
		return memoryStream.ToArray();
	}

	private static byte[] x5b0557d4a0ca4dc4(byte[] x89fb45eae1c0ead6, ushort x6f8e54aeb8581116, ushort x19a054211b2e9448, x49a6906320d20269 x46ef2beff2d00b82)
	{
		using MemoryStream stream = new MemoryStream(x89fb45eae1c0ead6);
		xa8866d7566da0aa2 xa8866d7566da0aa = new xa8866d7566da0aa2(stream);
		ushort num = xa8866d7566da0aa.xdb264d863790ee7b();
		if (num == ushort.MaxValue)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				x73087173962e3778 x73087173962e = new x73087173962e3778(memoryStream);
				x73087173962e.xb0c682b9901a2443(65535 - num);
				x73087173962e.x4c116b70372a3c6d(x89fb45eae1c0ead6, 2, x89fb45eae1c0ead6.Length - 2);
				return memoryStream.ToArray();
			}
		}
		x94af442f864d4b84 x94af442f864d4b = new x94af442f864d4b84();
		x94af442f864d4b.x77fa6322561797a0 = num;
		x94af442f864d4b.xf465816ce1e6196c = x6f8e54aeb8581116;
		ushort num2 = xa8866d7566da0aa.xdb264d863790ee7b();
		x94af442f864d4b.xdeadd99a9c48a92b = xa8866d7566da0aa.x95ea7d23cc8ee04d();
		x94af442f864d4b.x380b1e4ecae13f99 = new x33fe617fac5d9812[num2];
		for (int i = 0; i < num2; i++)
		{
			xc14a373217c35531 xc14a373217c35532 = xc14a373217c35531.x06b0e25aa6ad68a9(xa8866d7566da0aa);
			x33fe617fac5d9812 x33fe617fac5d = new x33fe617fac5d9812();
			x33fe617fac5d.x1e5325ab72cf7ec9 = xc14a373217c35532.x1e5325ab72cf7ec9;
			x33fe617fac5d.x7188c63c61c3d450 = xc14a373217c35532.x7188c63c61c3d450;
			x33fe617fac5d.x6a3e6a877109827c = new byte[x6f8e54aeb8581116];
			x94af442f864d4b.x380b1e4ecae13f99[i] = x33fe617fac5d;
		}
		x487dd273ba7db3d6 x487dd273ba7db3d7 = new x487dd273ba7db3d6(stream);
		for (int j = 0; j < num2; j++)
		{
			for (int k = 0; k < x6f8e54aeb8581116; k++)
			{
				int num3 = ((64 * x94af442f864d4b.x380b1e4ecae13f99[j].x7188c63c61c3d450 * x46ef2beff2d00b82.xc9b9fba2361cb131(k).xf58adb71a3d2dade + (int)x19a054211b2e9448 / 2) / (int)x19a054211b2e9448 + 32) / 64;
				short num4 = x487dd273ba7db3d7.x231ff899272d7d88();
				x94af442f864d4b.x380b1e4ecae13f99[j].x6a3e6a877109827c[k] = (byte)(num3 + num4);
			}
		}
		x94af442f864d4b.x6b4b68633a09765e();
		return x94af442f864d4b.x2797b998ab68f4ab();
	}

	private static byte[] xd9ac597940231e4f(byte[] x89fb45eae1c0ead6)
	{
		using MemoryStream stream = new MemoryStream(x89fb45eae1c0ead6);
		xa8866d7566da0aa2 xa8866d7566da0aa = new xa8866d7566da0aa2(stream);
		using MemoryStream memoryStream = new MemoryStream();
		x73087173962e3778 x73087173962e = new x73087173962e3778(memoryStream);
		ushort num = xa8866d7566da0aa.xdb264d863790ee7b();
		if (num == ushort.MaxValue || num == 65534)
		{
			x73087173962e.xb0c682b9901a2443(65535 - num);
			x73087173962e.x4c116b70372a3c6d(x89fb45eae1c0ead6, 2, x89fb45eae1c0ead6.Length - 2);
			return memoryStream.ToArray();
		}
		ushort num2 = xa8866d7566da0aa.xdb264d863790ee7b();
		ushort num3 = xa8866d7566da0aa.xdb264d863790ee7b();
		x73087173962e.xb0c682b9901a2443(num);
		x73087173962e.xb0c682b9901a2443(num2);
		x73087173962e.xb0c682b9901a2443(num3);
		x73087173962e.x4c116b70372a3c6d(xa8866d7566da0aa.x0f6807cca84a8e5b(num3 * 6));
		for (int i = 0; i < num2; i++)
		{
			ushort num4 = 8;
			ushort num5 = xa8866d7566da0aa.xdb264d863790ee7b();
			short num6 = xa8866d7566da0aa.x2e6b89ad8001e18f();
			short num7 = xa8866d7566da0aa.x2e6b89ad8001e18f();
			x65a1e30ff1e9db9b x65a1e30ff1e9db9b = new x65a1e30ff1e9db9b();
			x65a1e30ff1e9db9b.xdf5fff07e701314a = new x950617e8ee08573d[num5];
			x487dd273ba7db3d6 x487dd273ba7db3d7 = new x487dd273ba7db3d6(stream);
			for (int j = 0; j < num5; j++)
			{
				x65a1e30ff1e9db9b.xdf5fff07e701314a[j] = new x950617e8ee08573d();
				short num8 = x487dd273ba7db3d7.x231ff899272d7d88();
				short num9 = x487dd273ba7db3d7.x231ff899272d7d88();
				short num10 = x487dd273ba7db3d7.x231ff899272d7d88();
				x65a1e30ff1e9db9b.xdf5fff07e701314a[j].xfc62b168478dfcf3 = (ushort)(num4 + num8);
				int num11 = (x65a1e30ff1e9db9b.xdf5fff07e701314a[j].xfc62b168478dfcf3 * num6 + 1024) / 2048;
				int num12 = -(x65a1e30ff1e9db9b.xdf5fff07e701314a[j].xfc62b168478dfcf3 * num7 + 1024) / 2048;
				x65a1e30ff1e9db9b.xdf5fff07e701314a[j].xbed6b6abe5a7fcce = (short)(num11 + num9);
				x65a1e30ff1e9db9b.xdf5fff07e701314a[j].x5b051452efe1bbe3 = (short)(num12 + num10);
				num4 = (ushort)(num4 + 1);
			}
			x65a1e30ff1e9db9b.x6210059f049f0d48(x73087173962e);
		}
		return memoryStream.ToArray();
	}
}
