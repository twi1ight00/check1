using System.Collections;
using Aspose.Words;

namespace x4adf554d20d941a6;

internal class xd2b37e4f3e3c273e
{
	private x4ddd0723770f9758 x2b3e4e21b6fe4564;

	private int x13c6a5a5db54d0f4;

	private int x26a0d196a41fbd47;

	private xad082dd52abba9b2 x00e87e6e597be3c9;

	private ArrayList xb3c9c0dd80ae77ff;

	private ArrayList x69556147a2b6e4f2;

	private int xbcd477821fdbd81b => x2b3e4e21b6fe4564.x851c2023f5f1cc29;

	private int x076e5e406ba8950e
	{
		get
		{
			if (x4c38e800e85b21ad.x69d28a4aeef83a6f != null)
			{
				return x00e87e6e597be3c9.x851c2023f5f1cc29;
			}
			return 0;
		}
	}

	private bool x18027e39cfbf9e3c
	{
		get
		{
			if (x4c38e800e85b21ad.x719d3883357016d7)
			{
				return x13c6a5a5db54d0f4 <= 0;
			}
			return false;
		}
	}

	private x852fe8bb5ac31098 x4c38e800e85b21ad => (x852fe8bb5ac31098)x2b3e4e21b6fe4564.xc255c495fd9232ca;

	internal bool xee89fee4f0415c13(x4ddd0723770f9758 xc3f0a044e1e9f77f, xad082dd52abba9b2 x47ee85793a48fdbd, int xcacfbb9f56d9c743, int xd284dd7d525c5491)
	{
		xd586e0c16bdae7fc(x47ee85793a48fdbd, xc3f0a044e1e9f77f, xcacfbb9f56d9c743, xd284dd7d525c5491);
		bool flag;
		do
		{
			int num = xbcd477821fdbd81b;
			if (num + x076e5e406ba8950e <= x26a0d196a41fbd47)
			{
				break;
			}
			flag = num <= 0;
			if (!flag)
			{
				if (x000b031f8a2d7cdb())
				{
					return true;
				}
				flag = num <= xbcd477821fdbd81b;
			}
			if (flag)
			{
				for (int i = 0; i < x69556147a2b6e4f2.Count; i++)
				{
					xb3c9c0dd80ae77ff.Add(x69556147a2b6e4f2[i]);
				}
				if (x4c38e800e85b21ad.x7149c962c02931b3)
				{
					num = x13c6a5a5db54d0f4;
				}
			}
			else if (xb3c9c0dd80ae77ff.Count <= 0)
			{
				num = xbcd477821fdbd81b;
			}
			if (xc56dca3c0536be3a(num))
			{
				return x2b3e4e21b6fe4564.xc3819e13f60dd8e6(x4c38e800e85b21ad, num, x3175070523842c98: true, x4097fa47409be495: false);
			}
		}
		while (!flag);
		return false;
	}

	private void xd586e0c16bdae7fc(xad082dd52abba9b2 x47ee85793a48fdbd, x4ddd0723770f9758 xc3f0a044e1e9f77f, int xcacfbb9f56d9c743, int xd284dd7d525c5491)
	{
		x00e87e6e597be3c9 = x47ee85793a48fdbd;
		x2b3e4e21b6fe4564 = xc3f0a044e1e9f77f;
		x13c6a5a5db54d0f4 = xcacfbb9f56d9c743;
		x26a0d196a41fbd47 = xd284dd7d525c5491;
		xb3c9c0dd80ae77ff = new ArrayList();
		x69556147a2b6e4f2 = x6c8c1f0759e63259();
	}

	private bool xc56dca3c0536be3a(int x4d5aabc7a55b12ba)
	{
		if (xb3c9c0dd80ae77ff.Count <= 0)
		{
			return false;
		}
		while (x076e5e406ba8950e > x13c6a5a5db54d0f4 && x26a0d196a41fbd47 < x4d5aabc7a55b12ba + x076e5e406ba8950e)
		{
			x16dabaa37d19a5ec x16dabaa37d19a5ec2 = (x16dabaa37d19a5ec)x4c38e800e85b21ad.x69d28a4aeef83a6f.x7e2e5dd40daabc3b.x332a8eedb847940d.x2cbc0fc707d2e1eb();
			if (!xb3c9c0dd80ae77ff.Contains(x16dabaa37d19a5ec2.x465c7a263669f01c) || x50963d4c1a8e5e9c())
			{
				break;
			}
		}
		int num = x076e5e406ba8950e;
		return x26a0d196a41fbd47 >= x4d5aabc7a55b12ba + num;
	}

	private bool x000b031f8a2d7cdb()
	{
		xb3c9c0dd80ae77ff.Clear();
		int num = xbcd477821fdbd81b;
		if (x2b3e4e21b6fe4564.xc3819e13f60dd8e6(x4c38e800e85b21ad, num - 1, x18027e39cfbf9e3c, x4097fa47409be495: false))
		{
			return true;
		}
		if (num > xbcd477821fdbd81b)
		{
			for (int num2 = x69556147a2b6e4f2.Count - 1; num2 >= 0; num2--)
			{
				x92361dccfa0347fd x92361dccfa0347fd2 = (x92361dccfa0347fd)x69556147a2b6e4f2[num2];
				if (x92361dccfa0347fd2.xce4443deee105995(x954503abc583f675.x4c38e800e85b21ad) != x4c38e800e85b21ad)
				{
					xb3c9c0dd80ae77ff.Add(x92361dccfa0347fd2);
					x69556147a2b6e4f2.RemoveAt(num2);
				}
			}
		}
		return false;
	}

	private ArrayList x6c8c1f0759e63259()
	{
		ArrayList arrayList = new ArrayList();
		x82f666dd53fed993 x82f666dd53fed994 = new x82f666dd53fed993(x4c38e800e85b21ad, StoryType.Footnotes, forward: true);
		while (true)
		{
			x92361dccfa0347fd x92361dccfa0347fd2 = x82f666dd53fed994.xbc13914359462815();
			if (x92361dccfa0347fd2 == null)
			{
				break;
			}
			arrayList.Add(x92361dccfa0347fd2);
		}
		return arrayList;
	}

	private bool x50963d4c1a8e5e9c()
	{
		int num = x076e5e406ba8950e;
		x00e87e6e597be3c9.xc3819e13f60dd8e6(x4c38e800e85b21ad.x69d28a4aeef83a6f, num - 1, x3175070523842c98: false, x4097fa47409be495: true);
		if (x4c38e800e85b21ad.x69d28a4aeef83a6f != null)
		{
			return num <= x076e5e406ba8950e;
		}
		return true;
	}
}
