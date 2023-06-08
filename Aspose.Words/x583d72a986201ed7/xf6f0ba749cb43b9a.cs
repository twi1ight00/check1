using System;
using System.Collections;
using System.IO;

namespace x583d72a986201ed7;

internal class xf6f0ba749cb43b9a
{
	private const int xbeac6e9a9c5b9185 = 4;

	private readonly StreamReader xed7d0a3c2aa225eb;

	private readonly xfa0fcb008e364b10 xaac660d0be269810;

	private ArrayList x27eb3ed41aea96de;

	internal xf6f0ba749cb43b9a(StreamReader streamReader)
	{
		if (streamReader == null)
		{
			throw new ArgumentNullException("streamReader");
		}
		xed7d0a3c2aa225eb = streamReader;
		xaac660d0be269810 = new xfa0fcb008e364b10();
	}

	internal x754c5b323f287239[] x06b0e25aa6ad68a9()
	{
		x27eb3ed41aea96de = new ArrayList();
		x754c5b323f287239 x754c5b323f287240 = null;
		x049d57bc3026d28f x049d57bc3026d28f2 = xa8adf7fbd1cf75d9();
		while (x049d57bc3026d28f2.x1658a038b1a3cb0a != xc987730810b89250.xeababaadceb43553)
		{
			switch (x049d57bc3026d28f2.x1658a038b1a3cb0a)
			{
			case xc987730810b89250.xee7b2961fe7e18f8:
				if (x754c5b323f287240 == null || x4d4cde93cc63704e(x754c5b323f287240, x049d57bc3026d28f2))
				{
					x754c5b323f287240 = xa8659d1da44e5c7e(x049d57bc3026d28f2);
				}
				else
				{
					x5dbecfa62e076ba0(x754c5b323f287240, x049d57bc3026d28f2);
				}
				break;
			case xc987730810b89250.xe493bb17b51d9657:
			case xc987730810b89250.xd61e751bec776f22:
				xa8659d1da44e5c7e(x049d57bc3026d28f2);
				x754c5b323f287240 = null;
				break;
			case xc987730810b89250.x5a110b852cbc731a:
				x754c5b323f287240 = xa8659d1da44e5c7e(x049d57bc3026d28f2);
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			x049d57bc3026d28f2 = xa8adf7fbd1cf75d9();
		}
		x754c5b323f287239[] array = new x754c5b323f287239[x27eb3ed41aea96de.Count];
		for (int i = 0; i < x27eb3ed41aea96de.Count; i++)
		{
			array[i] = (x754c5b323f287239)x27eb3ed41aea96de[i];
		}
		return array;
	}

	private x049d57bc3026d28f xa8adf7fbd1cf75d9()
	{
		string text = xed7d0a3c2aa225eb.ReadLine();
		if (text == null)
		{
			return new x049d57bc3026d28f(xc987730810b89250.xeababaadceb43553);
		}
		string text2 = text.Trim();
		if (text2 == "")
		{
			return new x049d57bc3026d28f(xc987730810b89250.xe493bb17b51d9657);
		}
		int num = xd80b4dc4a8f4d09f(text);
		x02344c8663635c5d x02344c8663635c5d2 = null;
		xc987730810b89250 lineType;
		if (x5ee9f443ae33bb69(text2))
		{
			lineType = xc987730810b89250.xd61e751bec776f22;
		}
		else
		{
			x02344c8663635c5d2 = x22bdad7984a6b53a(text2, num);
			if (x02344c8663635c5d2 != null)
			{
				lineType = xc987730810b89250.x5a110b852cbc731a;
				int i;
				for (i = x02344c8663635c5d2.xf9ad6fb78355fe13.Length; i < text2.Length && text2[i] == ' '; i++)
				{
				}
				text2 = text2.Remove(0, i);
				num += i;
			}
			else
			{
				lineType = xc987730810b89250.xee7b2961fe7e18f8;
			}
		}
		x049d57bc3026d28f x049d57bc3026d28f2 = new x049d57bc3026d28f(text2, num, lineType);
		x049d57bc3026d28f2.x17dbe5d89173a7b0 = x02344c8663635c5d2;
		return x049d57bc3026d28f2;
	}

	private int xd80b4dc4a8f4d09f(string x311e7a92306d7199)
	{
		int num = 0;
		int num2 = 0;
		bool flag = true;
		while (flag && num2 < x311e7a92306d7199.Length)
		{
			if (x311e7a92306d7199[num2] == ' ')
			{
				num++;
			}
			else if (x311e7a92306d7199[num2] == '\t')
			{
				num += 4;
			}
			else
			{
				flag = false;
			}
			num2++;
		}
		return num;
	}

	private x754c5b323f287239 xd5849bd60a97ec5d(x02344c8663635c5d x5b0e49f41ffdca3a)
	{
		x754c5b323f287239 x754c5b323f287240 = null;
		for (int num = x27eb3ed41aea96de.Count - 1; num >= 0; num--)
		{
			x754c5b323f287239 x754c5b323f287241 = (x754c5b323f287239)x27eb3ed41aea96de[num];
			if (x754c5b323f287241.x17dbe5d89173a7b0 != null && x754c5b323f287241.x17dbe5d89173a7b0.xaf9d631233913bfe(x5b0e49f41ffdca3a))
			{
				if (x754c5b323f287241.x17dbe5d89173a7b0.xdcf9aad638f5cf6f.xd625490738b93054 && x754c5b323f287241.x17dbe5d89173a7b0.x9d3073c05209cae2 == x5b0e49f41ffdca3a.x9d3073c05209cae2)
				{
					return x754c5b323f287241;
				}
				if (x754c5b323f287241.x17dbe5d89173a7b0.xdcf9aad638f5cf6f.xd573a87c8d2cd484 && (x754c5b323f287240 == null || Math.Abs(x754c5b323f287241.x17dbe5d89173a7b0.x9d3073c05209cae2 - x5b0e49f41ffdca3a.x9d3073c05209cae2) < Math.Abs(x754c5b323f287240.x17dbe5d89173a7b0.x9d3073c05209cae2 - x5b0e49f41ffdca3a.x9d3073c05209cae2)))
				{
					x754c5b323f287240 = x754c5b323f287241;
				}
			}
		}
		return x754c5b323f287240;
	}

	private x754c5b323f287239 x5a6e6f6540948025(x02344c8663635c5d x5b0e49f41ffdca3a)
	{
		x754c5b323f287239 x754c5b323f287240 = null;
		for (int num = x27eb3ed41aea96de.Count - 1; num >= 0; num--)
		{
			x754c5b323f287239 x754c5b323f287241 = (x754c5b323f287239)x27eb3ed41aea96de[num];
			if (x754c5b323f287241.x17dbe5d89173a7b0 != null)
			{
				x754c5b323f287240 = x754c5b323f287241;
				break;
			}
		}
		if (x754c5b323f287240 == null || !x5b0e49f41ffdca3a.xe4c57e682bcbf8f6(x754c5b323f287240.x17dbe5d89173a7b0))
		{
			return null;
		}
		return x754c5b323f287240;
	}

	private static bool x4d4cde93cc63704e(x754c5b323f287239 xa82250af367d9f87, x049d57bc3026d28f xaf72b66333e99107)
	{
		if (xaf72b66333e99107.xc0741c7ff92cf1aa <= xa82250af367d9f87.xc0741c7ff92cf1aa)
		{
			if (xa82250af367d9f87.xcc1289ff82fe7342 > 1)
			{
				return xaf72b66333e99107.xc0741c7ff92cf1aa != xa82250af367d9f87.xc0741c7ff92cf1aa;
			}
			return false;
		}
		return true;
	}

	private static void x5dbecfa62e076ba0(x754c5b323f287239 x31e6518f5e08db6c, x049d57bc3026d28f xaf72b66333e99107)
	{
		x31e6518f5e08db6c.xe4fd28685b34ecc7(xaf72b66333e99107.xf9ad6fb78355fe13);
		if (x31e6518f5e08db6c.xcc1289ff82fe7342 == 2)
		{
			x31e6518f5e08db6c.xc7d7e186f0ace1e0 = x31e6518f5e08db6c.xc0741c7ff92cf1aa - xaf72b66333e99107.xc0741c7ff92cf1aa;
			x31e6518f5e08db6c.xc0741c7ff92cf1aa = xaf72b66333e99107.xc0741c7ff92cf1aa;
		}
	}

	private static bool x5ee9f443ae33bb69(string x6035c8fd51760cd3)
	{
		if (x6035c8fd51760cd3.Length < 5 || (x6035c8fd51760cd3[0] != '*' && x6035c8fd51760cd3[0] != '-' && x6035c8fd51760cd3[0] != '=' && x6035c8fd51760cd3[0] != '~'))
		{
			return false;
		}
		foreach (char c in x6035c8fd51760cd3)
		{
			if (c != x6035c8fd51760cd3[0])
			{
				return false;
			}
		}
		return true;
	}

	private x754c5b323f287239 xa8659d1da44e5c7e(x049d57bc3026d28f xaf72b66333e99107)
	{
		x754c5b323f287239 x754c5b323f287240 = new x754c5b323f287239();
		x754c5b323f287240.xc0741c7ff92cf1aa = xaf72b66333e99107.xc0741c7ff92cf1aa;
		x754c5b323f287240.xe4fd28685b34ecc7(xaf72b66333e99107.xf9ad6fb78355fe13);
		x754c5b323f287240.x17dbe5d89173a7b0 = xaf72b66333e99107.x17dbe5d89173a7b0;
		x27eb3ed41aea96de.Add(x754c5b323f287240);
		return x754c5b323f287240;
	}

	private x02344c8663635c5d x22bdad7984a6b53a(string xb41faee6912a2313, int x66ecc62b6f177063)
	{
		x02344c8663635c5d x02344c8663635c5d2 = xaac660d0be269810.xdef7f68a22ec051d(xb41faee6912a2313);
		if (x02344c8663635c5d2 == null)
		{
			return null;
		}
		x02344c8663635c5d2.x9d3073c05209cae2 = x66ecc62b6f177063;
		x02344c8663635c5d2.x6d1fa38f0423e11b = xd5849bd60a97ec5d(x02344c8663635c5d2);
		x02344c8663635c5d2.x283d882f626f891a = x5a6e6f6540948025(x02344c8663635c5d2);
		if (x02344c8663635c5d2.x6d1fa38f0423e11b == null && !x02344c8663635c5d2.x2af9c342e0ce6158() && x02344c8663635c5d2.x283d882f626f891a == null)
		{
			return null;
		}
		return x02344c8663635c5d2;
	}
}
