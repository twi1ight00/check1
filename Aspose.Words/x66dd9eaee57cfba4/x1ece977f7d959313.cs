using System;
using System.Collections;
using System.Text;
using x6c95d9cf46ff5f25;

namespace x66dd9eaee57cfba4;

internal class x1ece977f7d959313 : xba15250b3f24fd3a
{
	internal const int x2d32dac78ff5c1fb = 65536;

	internal const int x4140519a508e3b89 = 131072;

	internal const int x7f51f237b0a3272d = 151552;

	internal const int x0ce332a138b1b320 = 196608;

	private const int xe2667216230c90bc = 258;

	internal int x77fa6322561797a0;

	internal int xb874556d20cb64ce;

	internal short xdcbf003433bf5549;

	internal short x4f562baf652b66fb;

	internal int x9ca90aa048385f9f;

	internal int xb879dbb7e03e44b5;

	internal int xdb21ba72141fd8f0;

	internal int xdb440d40c056ed62;

	internal int x725c6895ffb5faab;

	internal int xa35ec4dd324c39ac;

	internal int[] x0ae61ab86c87ce39;

	internal ArrayList x33994cad95b6c865;

	internal x1ece977f7d959313(xa8866d7566da0aa2 reader)
	{
		x77fa6322561797a0 = reader.x95ea7d23cc8ee04d();
		xb874556d20cb64ce = reader.x95ea7d23cc8ee04d();
		xdcbf003433bf5549 = reader.x2e6b89ad8001e18f();
		x4f562baf652b66fb = reader.x2e6b89ad8001e18f();
		x9ca90aa048385f9f = reader.x95ea7d23cc8ee04d();
		xb879dbb7e03e44b5 = reader.x95ea7d23cc8ee04d();
		xdb21ba72141fd8f0 = reader.x95ea7d23cc8ee04d();
		xdb440d40c056ed62 = reader.x95ea7d23cc8ee04d();
		x725c6895ffb5faab = reader.x95ea7d23cc8ee04d();
		switch (x77fa6322561797a0)
		{
		case 131072:
		{
			xa35ec4dd324c39ac = reader.xdb264d863790ee7b();
			x0ae61ab86c87ce39 = new int[xa35ec4dd324c39ac];
			int num = 0;
			for (int i = 0; i < x0ae61ab86c87ce39.Length; i++)
			{
				ushort num2 = reader.xdb264d863790ee7b();
				x0ae61ab86c87ce39[i] = num2;
				if (num2 <= 32767)
				{
					num = Math.Max(num2, num);
				}
			}
			int num3 = num - 258 + 1;
			num3 = ((num3 >= 0) ? num3 : 0);
			x33994cad95b6c865 = new ArrayList(num3);
			for (int j = 0; j < num3; j++)
			{
				x33994cad95b6c865.Add(x0950bf10fc55b12c(reader));
			}
			break;
		}
		default:
			throw new InvalidOperationException("Unexpected PostScript table version.");
		case 65536:
		case 196608:
			break;
		}
	}

	internal override void x6210059f049f0d48(x73087173962e3778 xbdfb620b7167944b)
	{
		xbdfb620b7167944b.x6ff7c65ed4805c27(x77fa6322561797a0);
		xbdfb620b7167944b.x6ff7c65ed4805c27(xb874556d20cb64ce);
		xbdfb620b7167944b.xab5f6b7526efa5be(xdcbf003433bf5549);
		xbdfb620b7167944b.xab5f6b7526efa5be(x4f562baf652b66fb);
		xbdfb620b7167944b.x6ff7c65ed4805c27(x9ca90aa048385f9f);
		xbdfb620b7167944b.x6ff7c65ed4805c27(xb879dbb7e03e44b5);
		xbdfb620b7167944b.x6ff7c65ed4805c27(xdb21ba72141fd8f0);
		xbdfb620b7167944b.x6ff7c65ed4805c27(xdb440d40c056ed62);
		xbdfb620b7167944b.x6ff7c65ed4805c27(x725c6895ffb5faab);
		switch (x77fa6322561797a0)
		{
		case 131072:
		{
			xbdfb620b7167944b.xab5f6b7526efa5be(xa35ec4dd324c39ac);
			int[] array = x0ae61ab86c87ce39;
			foreach (int xbcea506a33cf in array)
			{
				xbdfb620b7167944b.xab5f6b7526efa5be(xbcea506a33cf);
			}
			for (int j = 0; j < x33994cad95b6c865.Count; j++)
			{
				x3e6183454632ffc6((string)x33994cad95b6c865[j], xbdfb620b7167944b);
			}
			break;
		}
		default:
			throw new InvalidOperationException("Unexpected PostScript table version.");
		case 65536:
		case 196608:
			break;
		}
	}

	internal void xbb283a1aa30876b0(x09ce2c02826e31a6 x1c6a97d3a496e7e2)
	{
		xb879dbb7e03e44b5 = 0;
		xdb21ba72141fd8f0 = 0;
		xdb440d40c056ed62 = 0;
		x725c6895ffb5faab = 0;
		switch (x77fa6322561797a0)
		{
		case 131072:
			x95c03bb635ce90c3(x1c6a97d3a496e7e2);
			break;
		default:
			throw new InvalidOperationException("Unexpected PostScript table version.");
		case 65536:
		case 196608:
			break;
		}
	}

	private void x95c03bb635ce90c3(x09ce2c02826e31a6 x1c6a97d3a496e7e2)
	{
		int[] array = new int[x1c6a97d3a496e7e2.xd44988f225497f3a];
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < x1c6a97d3a496e7e2.xd44988f225497f3a; i++)
		{
			int num = x1c6a97d3a496e7e2.xf15263674eb297bb(i);
			int num2 = (int)x1c6a97d3a496e7e2.x6d3720b962bd3112(i);
			int num3 = x0ae61ab86c87ce39[num];
			if (num3 < 258 || num3 > 32767)
			{
				array[num2] = (ushort)num3;
				continue;
			}
			string value = (string)x33994cad95b6c865[num3 - 258];
			int num4 = arrayList.Add(value);
			array[num2] = (ushort)(num4 + 258);
		}
		xa35ec4dd324c39ac = (ushort)x1c6a97d3a496e7e2.xd44988f225497f3a;
		x0ae61ab86c87ce39 = array;
		x33994cad95b6c865 = arrayList;
	}

	private static string x0950bf10fc55b12c(xa8866d7566da0aa2 xe134235b3526fa75)
	{
		int x10f4d88af727adbc = xe134235b3526fa75.x672ed37ee25c078c();
		byte[] bytes = xe134235b3526fa75.x0f6807cca84a8e5b(x10f4d88af727adbc);
		Encoding aSCII = Encoding.ASCII;
		return aSCII.GetString(bytes);
	}

	private static void x3e6183454632ffc6(string xe4115acdf4fbfccc, x73087173962e3778 xbdfb620b7167944b)
	{
		if (xe4115acdf4fbfccc.Length > 255)
		{
			throw new InvalidOperationException("The PostScript glyph name is too long.");
		}
		Encoding aSCII = Encoding.ASCII;
		byte[] bytes = aSCII.GetBytes(xe4115acdf4fbfccc);
		xbdfb620b7167944b.xc351d479ff7ee789((byte)bytes.Length);
		xbdfb620b7167944b.x4c116b70372a3c6d(bytes, 0, bytes.Length);
	}
}
