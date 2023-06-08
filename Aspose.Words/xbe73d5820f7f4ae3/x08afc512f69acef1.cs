using System.Collections;
using System.Reflection;
using x6c95d9cf46ff5f25;

namespace xbe73d5820f7f4ae3;

[DefaultMember("Item")]
internal class x08afc512f69acef1
{
	private readonly ArrayList x54a0a38db48f7ac2;

	private readonly ArrayList x1ed9c734702d5388;

	private readonly ArrayList x713faf55bde4bfeb;

	internal x95973895507fea32 xe6d4b1b411ed94b5
	{
		get
		{
			if (xafd04c36a00d5bcf)
			{
				if (x0bfe184ad871a4c2)
				{
					x95973895507fea32 x95973895507fea33 = x3e3ec6dc2187f71b(x1ed9c734702d5388, xbd5a2e7a4ff749c9, xa79a9f649c74f4a4);
					if (x95973895507fea33 != null)
					{
						return x95973895507fea33;
					}
				}
				return x3e3ec6dc2187f71b(x54a0a38db48f7ac2, xbd5a2e7a4ff749c9, xa79a9f649c74f4a4);
			}
			return x3e3ec6dc2187f71b(x713faf55bde4bfeb, xbd5a2e7a4ff749c9, xa79a9f649c74f4a4);
		}
	}

	internal x95973895507fea32 xe6d4b1b411ed94b5
	{
		get
		{
			x95973895507fea32 x95973895507fea33 = this.get_xe6d4b1b411ed94b5(xbd5a2e7a4ff749c9, xa79a9f649c74f4a4, x0bfe184ad871a4c2, xafd04c36a00d5bcf: true);
			if (x95973895507fea33 == null)
			{
				return x3e3ec6dc2187f71b(x713faf55bde4bfeb, xbd5a2e7a4ff749c9, xa79a9f649c74f4a4);
			}
			return x95973895507fea33;
		}
	}

	internal x95973895507fea32 xe6d4b1b411ed94b5
	{
		get
		{
			if (xbd5a2e7a4ff749c9 == null)
			{
				return x3e3ec6dc2187f71b(x713faf55bde4bfeb, xa79a9f649c74f4a4);
			}
			x95973895507fea32 x95973895507fea33 = x3e3ec6dc2187f71b(x713faf55bde4bfeb, xbd5a2e7a4ff749c9, xa79a9f649c74f4a4);
			if (x95973895507fea33 == null)
			{
				x95973895507fea33 = x3e3ec6dc2187f71b(x54a0a38db48f7ac2, xbd5a2e7a4ff749c9, xa79a9f649c74f4a4);
			}
			if (x95973895507fea33 == null)
			{
				x95973895507fea33 = x3e3ec6dc2187f71b(x1ed9c734702d5388, xbd5a2e7a4ff749c9, xa79a9f649c74f4a4);
			}
			return x95973895507fea33;
		}
	}

	internal int xcf2fd36bc07b78ec => x713faf55bde4bfeb.Count;

	internal int xde4dcae228e536db => x1ed9c734702d5388.Count;

	internal int x21b629d0d9bfc031 => x54a0a38db48f7ac2.Count;

	internal x08afc512f69acef1()
	{
		x54a0a38db48f7ac2 = new ArrayList();
		x1ed9c734702d5388 = new ArrayList();
		x713faf55bde4bfeb = new ArrayList();
	}

	internal void xa9d636b00ff486b7()
	{
		x54a0a38db48f7ac2.Clear();
		x1ed9c734702d5388.Clear();
		x713faf55bde4bfeb.Clear();
	}

	internal int xd6b6ed77479ef68c(x95973895507fea32 xbcea506a33cf9111, bool x0bfe184ad871a4c2, bool xafd04c36a00d5bcf)
	{
		if (xafd04c36a00d5bcf)
		{
			if (x0bfe184ad871a4c2)
			{
				return x1ed9c734702d5388.Add(xbcea506a33cf9111);
			}
			return x54a0a38db48f7ac2.Add(xbcea506a33cf9111);
		}
		return x713faf55bde4bfeb.Add(xbcea506a33cf9111);
	}

	private static x95973895507fea32 x3e3ec6dc2187f71b(ArrayList x8a0b266419f09a55, string xa79a9f649c74f4a4)
	{
		foreach (x95973895507fea32 item in x8a0b266419f09a55)
		{
			if (item is x39cd0691137f3b40 && (item as x39cd0691137f3b40).x4ccc2e5631b8ba9c == xa79a9f649c74f4a4 && !x0d299f323d241756.x5959bccb67bbf051((item as x39cd0691137f3b40).x759aa16c2016a289))
			{
				return item;
			}
		}
		return null;
	}

	private static x95973895507fea32 x3e3ec6dc2187f71b(ArrayList x8a0b266419f09a55, string xbd5a2e7a4ff749c9, string xa79a9f649c74f4a4)
	{
		if (xa79a9f649c74f4a4 == null)
		{
			foreach (x95973895507fea32 item in x8a0b266419f09a55)
			{
				if (xbd5a2e7a4ff749c9 != null && item.x759aa16c2016a289 == xbd5a2e7a4ff749c9)
				{
					return item;
				}
			}
		}
		else
		{
			foreach (x95973895507fea32 item2 in x8a0b266419f09a55)
			{
				if (item2 is x39cd0691137f3b40 && xbd5a2e7a4ff749c9 != null && item2.x759aa16c2016a289 == xbd5a2e7a4ff749c9 && (item2 as x39cd0691137f3b40).x4ccc2e5631b8ba9c == xa79a9f649c74f4a4)
				{
					return item2;
				}
			}
		}
		return null;
	}

	internal x95973895507fea32 xe12908afde76bfa4(int xc0c4c459c6ccbd00)
	{
		return (x95973895507fea32)x713faf55bde4bfeb[xc0c4c459c6ccbd00];
	}

	internal x95973895507fea32 x039f29e111117566(int xc0c4c459c6ccbd00)
	{
		return (x95973895507fea32)x54a0a38db48f7ac2[xc0c4c459c6ccbd00];
	}

	internal x95973895507fea32 x9351b86239699645(int xc0c4c459c6ccbd00)
	{
		return (x95973895507fea32)x1ed9c734702d5388[xc0c4c459c6ccbd00];
	}
}
