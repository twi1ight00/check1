using System;
using System.Collections;
using System.IO;

namespace x4e7ae5a4b27b0834;

internal class xcb3ed34a3eba8ce2
{
	private int[] x7007a7b429dcf108;

	private byte[] x73f065a6b420cfe1;

	private int x35a5073ffeb125c5;

	public int x437e3b626c0fdd43 => x77df235b4d3e2bcd(x35a5073ffeb125c5, x73f065a6b420cfe1.Length);

	public int xd407167a86d34054 => x73f065a6b420cfe1.Length;

	public int x743de5a8c8cce84c => x35a5073ffeb125c5;

	internal int[] x4224683bf1441144 => x7007a7b429dcf108;

	private xcb3ed34a3eba8ce2()
	{
	}

	public xcb3ed34a3eba8ce2(ArrayList items)
	{
		if (items.Count == 0)
		{
			x73f065a6b420cfe1 = new byte[0];
			x7007a7b429dcf108 = new int[0];
			x35a5073ffeb125c5 = 0;
			return;
		}
		using MemoryStream memoryStream = new MemoryStream();
		x35a5073ffeb125c5 = items.Count;
		x7007a7b429dcf108 = new int[x35a5073ffeb125c5 + 1];
		x7007a7b429dcf108[0] = 1;
		for (int i = 0; i < x35a5073ffeb125c5; i++)
		{
			byte[] array = (byte[])items[i];
			memoryStream.Write(array, 0, array.Length);
			x7007a7b429dcf108[i + 1] = (int)memoryStream.Position + 1;
		}
		x73f065a6b420cfe1 = memoryStream.ToArray();
	}

	public static xcb3ed34a3eba8ce2 x06b0e25aa6ad68a9(xe2451c6b5635cb1b xe134235b3526fa75)
	{
		xcb3ed34a3eba8ce2 xcb3ed34a3eba8ce3 = new xcb3ed34a3eba8ce2();
		xcb3ed34a3eba8ce3.x35a5073ffeb125c5 = xe134235b3526fa75.x0646818fa18eea2f();
		if (xcb3ed34a3eba8ce3.x35a5073ffeb125c5 == 0)
		{
			xcb3ed34a3eba8ce3.x73f065a6b420cfe1 = new byte[0];
			xcb3ed34a3eba8ce3.x7007a7b429dcf108 = new int[0];
			return xcb3ed34a3eba8ce3;
		}
		short x6c83912428ceacb = xe134235b3526fa75.xe11775cf079e846f();
		xcb3ed34a3eba8ce3.x7007a7b429dcf108 = xe134235b3526fa75.xeff8397bc628aeba(x6c83912428ceacb, xcb3ed34a3eba8ce3.x35a5073ffeb125c5 + 1);
		xcb3ed34a3eba8ce3.x73f065a6b420cfe1 = xe134235b3526fa75.x0f6807cca84a8e5b(xcb3ed34a3eba8ce3.x7007a7b429dcf108[xcb3ed34a3eba8ce3.x35a5073ffeb125c5] - 1);
		return xcb3ed34a3eba8ce3;
	}

	public void x6210059f049f0d48(xc0e60c4cd8683899 xbdfb620b7167944b)
	{
		xbdfb620b7167944b.x49ac741484894752((ushort)x35a5073ffeb125c5);
		if (x35a5073ffeb125c5 != 0)
		{
			short num = xd250c5bb9d31a54d(x73f065a6b420cfe1.Length);
			xbdfb620b7167944b.xf9a7663e3fa37cc6(num);
			xbdfb620b7167944b.x5f3901d45fe874c1(x7007a7b429dcf108, num);
			xbdfb620b7167944b.x4c116b70372a3c6d(x73f065a6b420cfe1);
		}
	}

	public static int x77df235b4d3e2bcd(int x03a69b6bf16c508c, int x75a9c8b35c93c27a)
	{
		if (x03a69b6bf16c508c == 0)
		{
			return 2;
		}
		int num = xd250c5bb9d31a54d(x75a9c8b35c93c27a);
		return 3 + num * (x03a69b6bf16c508c + 1) + x75a9c8b35c93c27a;
	}

	private static short xd250c5bb9d31a54d(int x75a9c8b35c93c27a)
	{
		int num = x75a9c8b35c93c27a + 1;
		if (num < 256)
		{
			return 1;
		}
		if (num < 65536)
		{
			return 2;
		}
		if (num < 16777216)
		{
			return 3;
		}
		return 4;
	}

	public byte[] xe84e6ff66aac2a0e(int xc0c4c459c6ccbd00)
	{
		if (xc0c4c459c6ccbd00 < 0 || xc0c4c459c6ccbd00 > x35a5073ffeb125c5)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		int num = x7007a7b429dcf108[xc0c4c459c6ccbd00] - 1;
		int num2 = x7007a7b429dcf108[xc0c4c459c6ccbd00 + 1] - x7007a7b429dcf108[xc0c4c459c6ccbd00];
		byte[] array = new byte[num2];
		for (int i = 0; i < num2; i++)
		{
			array[i] = x73f065a6b420cfe1[num + i];
		}
		return array;
	}
}
