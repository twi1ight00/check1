using System.Collections;
using Aspose.Words;
using Aspose.Words.Fields;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace xfbd1009a0cbb9842;

internal class x985dd08fd338eeea : x6ed66b5cf8da2955
{
	private readonly Field x54c413cc80cb99d5;

	private readonly x6ed66b5cf8da2955 xb965f36a141de102;

	private string xf47d0d057a67ed4d;

	private readonly int x0346b68d3ecdf368;

	private readonly ArrayList x90c83a7fe2a76278 = new ArrayList();

	private readonly ArrayList xd5aedc6957abbd50 = new ArrayList();

	private int x36870d156bdb5a69;

	private int x5062c3c4298b687a;

	private string x0dd4a870916fd15e;

	internal ICollection x450f47a9028f884b => x90c83a7fe2a76278;

	internal ICollection x7261c103565fa212 => xd5aedc6957abbd50;

	internal string xc96d173d58dd8a20 => xf47d0d057a67ed4d;

	internal int x609daf39d0822544 => x36870d156bdb5a69;

	internal int x55913a1dc35ee24c => x5062c3c4298b687a;

	private bool x8960f26a439143cd => x90c83a7fe2a76278.Count == x0346b68d3ecdf368;

	internal string x2dd813bbd92bbe25 => x0dd4a870916fd15e;

	internal x985dd08fd338eeea(string fieldCode)
		: this(fieldCode, null)
	{
	}

	internal x985dd08fd338eeea(string fieldCode, x6ed66b5cf8da2955 switchResolver)
	{
		xb965f36a141de102 = switchResolver;
		x0346b68d3ecdf368 = x5c29822913be33c1.x4c08ecbb32dcf8cd(fieldCode);
		x1f490eac106aee12(new x2d380f6141585930(fieldCode, this));
		x36870d156bdb5a69 = 1024;
	}

	internal x985dd08fd338eeea(Field field)
	{
		x54c413cc80cb99d5 = field;
		xb965f36a141de102 = field as x6ed66b5cf8da2955;
		x0346b68d3ecdf368 = x5c29822913be33c1.x4c08ecbb32dcf8cd(field.Type);
		xa5816076ad98253b();
	}

	private void xa5816076ad98253b()
	{
		x2d380f6141585930 x2d380f61415859302 = new x2d380f6141585930(x54c413cc80cb99d5, this);
		x1f490eac106aee12(x2d380f61415859302);
		x36870d156bdb5a69 = x2d380f61415859302.x609daf39d0822544;
		x5062c3c4298b687a = x2d380f61415859302.x55913a1dc35ee24c;
	}

	private void x1f490eac106aee12(x2d380f6141585930 xbce90b56ab411c23)
	{
		xbce90b56ab411c23.x2408a6db33935c93(x0bc1a2ec253ad36c: false);
		xf47d0d057a67ed4d = xbce90b56ab411c23.xd420ac3415caa02b;
		string text = null;
		while (xbce90b56ab411c23.x2408a6db33935c93(x8960f26a439143cd))
		{
			if (xbce90b56ab411c23.x2af81d05318e5fe2)
			{
				if (text != null)
				{
					if (x5c29822913be33c1.x94810e522c4505da(text))
					{
						x0dd4a870916fd15e = "Error! Switch argument not specified.";
					}
					xf03314141e0fdd17(text);
					text = null;
				}
				if (x3ecf81e56889c4af(xbce90b56ab411c23.xd420ac3415caa02b) != 0)
				{
					text = xbce90b56ab411c23.xd420ac3415caa02b;
					if (x5c29822913be33c1.x5580509afa07e28e(text) && xd5aedc6957abbd50.Count > 0)
					{
						x0dd4a870916fd15e = "Error! Picture switch must be first formatting switch.";
					}
				}
			}
			else
			{
				x64629b07e6a0cb07 x64629b07e6a0cb8 = new x64629b07e6a0cb07(xbce90b56ab411c23.xd420ac3415caa02b, xbce90b56ab411c23.x5ba1f3ac6b17bc97());
				if (text == null || x3ecf81e56889c4af(text) != x9f6b815e19fa8f62.x47e3e032f7bd5d28)
				{
					x90c83a7fe2a76278.Add(x64629b07e6a0cb8);
					continue;
				}
				xf03314141e0fdd17(text, x64629b07e6a0cb8);
				text = null;
			}
		}
		if (text != null)
		{
			xf03314141e0fdd17(text);
		}
	}

	private void xf03314141e0fdd17(string x724fbd227bfb6eda)
	{
		xf03314141e0fdd17(x724fbd227bfb6eda, null);
	}

	private void xf03314141e0fdd17(string x724fbd227bfb6eda, x64629b07e6a0cb07 xddda620843637857)
	{
		xd5aedc6957abbd50.Add(new xcfa6f73a76d96956(x724fbd227bfb6eda, xddda620843637857));
	}

	internal bool xcc2d426b867d703d(string x724fbd227bfb6eda)
	{
		return xc930118a04c07c10(x724fbd227bfb6eda) != null;
	}

	internal x64629b07e6a0cb07 xd67eea2495e37631(string x724fbd227bfb6eda)
	{
		return xc930118a04c07c10(x724fbd227bfb6eda)?.x1745ba6c6d5efbc4;
	}

	internal string x6eba61762c5e83d7(string x724fbd227bfb6eda)
	{
		return x6eba61762c5e83d7(x724fbd227bfb6eda, xbd96676852fc71de: false);
	}

	internal string x6eba61762c5e83d7(string x724fbd227bfb6eda, bool xbd96676852fc71de)
	{
		string text = xd67eea2495e37631(x724fbd227bfb6eda)?.xd961adf06ad48c3f();
		if (text != null)
		{
			return text;
		}
		if (!xbd96676852fc71de)
		{
			return null;
		}
		return string.Empty;
	}

	internal int x38dcf39c0c123d8f(string x724fbd227bfb6eda)
	{
		if (!xcc2d426b867d703d(x724fbd227bfb6eda))
		{
			return -1;
		}
		int num = xca004f56614e2431.x912616ee70b2d94d(x6eba61762c5e83d7(x724fbd227bfb6eda));
		if (num == int.MinValue)
		{
			return 0;
		}
		return num;
	}

	internal x64629b07e6a0cb07 xdd7e5aab5232094a(int xc0c4c459c6ccbd00)
	{
		if (xc0c4c459c6ccbd00 < 0 || xc0c4c459c6ccbd00 >= x90c83a7fe2a76278.Count)
		{
			return null;
		}
		return (x64629b07e6a0cb07)x90c83a7fe2a76278[xc0c4c459c6ccbd00];
	}

	internal x7e263f21a73a027a xc1a7df85a9e87250(int x950ce1a20fc7ea38)
	{
		x64629b07e6a0cb07 x64629b07e6a0cb8 = xdd7e5aab5232094a(x950ce1a20fc7ea38);
		if (x64629b07e6a0cb8 != null)
		{
			return x64629b07e6a0cb8.x7d2e50686d249839;
		}
		Run run = new Run(x54c413cc80cb99d5.x2c8c6741422a1298);
		return new x7e263f21a73a027a(run, includeStart: true, run, includeEnd: false);
	}

	internal void x5ef2683f249bb7b2(int x950ce1a20fc7ea38, string x5d4886a12ee6dcbe)
	{
		if (x5d4886a12ee6dcbe != null)
		{
			string xf71d12b3e971e1e = xbe86a91b1d1cbdcd.xa12e146e281d0573(this, x950ce1a20fc7ea38, x5d4886a12ee6dcbe);
			x295cb4a1df7a5add(xf71d12b3e971e1e);
		}
		else if (x950ce1a20fc7ea38 < x90c83a7fe2a76278.Count)
		{
			if (x950ce1a20fc7ea38 < x90c83a7fe2a76278.Count - 1)
			{
				string xf71d12b3e971e1e2 = xbe86a91b1d1cbdcd.xa12e146e281d0573(this, x950ce1a20fc7ea38, string.Empty);
				x295cb4a1df7a5add(xf71d12b3e971e1e2);
			}
			else
			{
				string xf71d12b3e971e1e3 = xbe86a91b1d1cbdcd.xa49d2eb0863a229c(this);
				x295cb4a1df7a5add(xf71d12b3e971e1e3);
			}
		}
	}

	internal void x3a70a872b0ded8b0(string x724fbd227bfb6eda, bool xa1ca3186bd369811)
	{
		string xf71d12b3e971e1e = xbe86a91b1d1cbdcd.xe5d1e5e3ded2572a(this, x724fbd227bfb6eda, xa1ca3186bd369811);
		x295cb4a1df7a5add(xf71d12b3e971e1e);
	}

	internal void x3a70a872b0ded8b0(string x724fbd227bfb6eda, string xddda620843637857)
	{
		string xf71d12b3e971e1e = xbe86a91b1d1cbdcd.xe5d1e5e3ded2572a(this, x724fbd227bfb6eda, xddda620843637857, 0);
		x295cb4a1df7a5add(xf71d12b3e971e1e);
	}

	internal void x3a70a872b0ded8b0(string x724fbd227bfb6eda, string xddda620843637857, int xb53be37c1d09c26c)
	{
		string xf71d12b3e971e1e = xbe86a91b1d1cbdcd.xe5d1e5e3ded2572a(this, x724fbd227bfb6eda, xddda620843637857, xb53be37c1d09c26c);
		x295cb4a1df7a5add(xf71d12b3e971e1e);
	}

	private void x295cb4a1df7a5add(string xf71d12b3e971e1e5)
	{
		x54c413cc80cb99d5.x462912a00c2a2b88(xf71d12b3e971e1e5);
		x90c83a7fe2a76278.Clear();
		xd5aedc6957abbd50.Clear();
		xa5816076ad98253b();
	}

	internal string x642e37025c67edab(int xc0c4c459c6ccbd00)
	{
		return x642e37025c67edab(xc0c4c459c6ccbd00, x9fc40ce4428c62cc: true);
	}

	internal string x642e37025c67edab(int xc0c4c459c6ccbd00, bool x9fc40ce4428c62cc)
	{
		return x642e37025c67edab(xc0c4c459c6ccbd00, x9fc40ce4428c62cc, xbd96676852fc71de: false);
	}

	internal string x642e37025c67edab(int xc0c4c459c6ccbd00, bool x9fc40ce4428c62cc, bool xbd96676852fc71de)
	{
		x64629b07e6a0cb07 x64629b07e6a0cb8 = xdd7e5aab5232094a(xc0c4c459c6ccbd00);
		if (x64629b07e6a0cb8 == null)
		{
			if (!xbd96676852fc71de)
			{
				return null;
			}
			return string.Empty;
		}
		return x64629b07e6a0cb8.xd961adf06ad48c3f(x9fc40ce4428c62cc);
	}

	private xcfa6f73a76d96956 xc930118a04c07c10(string x724fbd227bfb6eda)
	{
		xcfa6f73a76d96956 result = null;
		foreach (xcfa6f73a76d96956 item in xd5aedc6957abbd50)
		{
			if (x0d299f323d241756.x90637a473b1ceaaa(item.x759aa16c2016a289, x724fbd227bfb6eda))
			{
				result = item;
			}
		}
		return result;
	}

	public x9f6b815e19fa8f62 x3ecf81e56889c4af(string x724fbd227bfb6eda)
	{
		if (x5c29822913be33c1.x94810e522c4505da(x724fbd227bfb6eda))
		{
			return x9f6b815e19fa8f62.x47e3e032f7bd5d28;
		}
		if (xb965f36a141de102 == null)
		{
			return x9f6b815e19fa8f62.xf6c17f648b65c793;
		}
		return xb965f36a141de102.x3ecf81e56889c4af(x724fbd227bfb6eda.ToLower());
	}
}
