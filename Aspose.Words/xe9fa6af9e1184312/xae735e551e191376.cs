using Aspose.Words;
using x1c8faa688b1f0b0c;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;

namespace xe9fa6af9e1184312;

internal class xae735e551e191376
{
	private xae735e551e191376()
	{
	}

	internal static void x06b0e25aa6ad68a9(x95792ebebfd0979f x52608227a52a6472)
	{
		string xeaf1b27180c0557b = x52608227a52a6472.xd68abcd61e368af9("id", null);
		xb8e7e788f6d59708 xb8e7e788f6d = new xb8e7e788f6d59708();
		x1fdc4491fb4c3ee8 x28fcdc775a1d069c = x52608227a52a6472.x28fcdc775a1d069c;
		x28fcdc775a1d069c.x1fa9148f6731ff24(xb8e7e788f6d, xeaf1b27180c0557b);
		x28fcdc775a1d069c.xffdeeab52bfac6bd(xb8e7e788f6d);
		x4407ca4302a525f6(x28fcdc775a1d069c.xc9443bca5b0a56d8, x52608227a52a6472);
		if (xa853df7acdb217c8(x28fcdc775a1d069c.x8194fa1e2b16932f.xe6904a2e41fd856a(x9189d7a3c7720a79.x27a8d08d15edb975)))
		{
			while (x52608227a52a6472.x152cbadbfa8061b1("g"))
			{
				x152cbadbfa8061b1(x52608227a52a6472);
			}
		}
		else
		{
			x52608227a52a6472.IgnoreElement();
		}
		x28fcdc775a1d069c.xf5b0b9b6ff7ac462();
	}

	internal static void x152cbadbfa8061b1(x95792ebebfd0979f x52608227a52a6472)
	{
		switch (x52608227a52a6472.xa66385d80d4d296f)
		{
		case "defs":
			x18f8d6d1a9fa2e58(x52608227a52a6472);
			break;
		case "g":
			x06b0e25aa6ad68a9(x52608227a52a6472);
			break;
		case "path":
		case "rect":
		case "circle":
		case "ellipse":
		case "line":
		case "polyline":
		case "polygon":
			xca82d9cad5dab10a.x06b0e25aa6ad68a9(x52608227a52a6472);
			break;
		case "clipPath":
			xca82d9cad5dab10a.x9bc07b057f5926f2(x52608227a52a6472);
			break;
		case "text":
			x52608227a52a6472.x8a5fa4b54d19c49a.x06b0e25aa6ad68a9();
			break;
		case "use":
			xea0aef655028e8cd(x52608227a52a6472);
			break;
		case "image":
			x61655d0d58254c8b.x06b0e25aa6ad68a9(x52608227a52a6472);
			break;
		default:
			x52608227a52a6472.x785b2d167d8a3ca9(WarningType.UnexpectedContent, $"Element '{x52608227a52a6472.xa66385d80d4d296f}' is unexpected at this location and will be ignored");
			break;
		}
	}

	internal static void x18f8d6d1a9fa2e58(x95792ebebfd0979f x52608227a52a6472)
	{
		x52608227a52a6472.x28fcdc775a1d069c.xffdeeab52bfac6bd(new xb8e7e788f6d59708());
		while (x52608227a52a6472.x152cbadbfa8061b1("defs"))
		{
			x152cbadbfa8061b1(x52608227a52a6472);
		}
		x52608227a52a6472.x28fcdc775a1d069c.xf5b0b9b6ff7ac462();
	}

	private static void x4407ca4302a525f6(xb8e7e788f6d59708 x08ce8f4769eb3234, x95792ebebfd0979f x52608227a52a6472)
	{
		while (x52608227a52a6472.x1ac1960adc8c4c39())
		{
			switch (x52608227a52a6472.xa66385d80d4d296f)
			{
			case "transform":
				x08ce8f4769eb3234.x52dde376accdec7d = xf7e2753b1f50fb2b.xb3da63d0517cf3c6(x52608227a52a6472.xd2f68ee6f47e9dfb, x52608227a52a6472.x28fcdc775a1d069c);
				break;
			case "clip-path":
			{
				xab391c46ff9a0a38 x0e1bf8242ad = x52608227a52a6472.x28fcdc775a1d069c.x9ab4402f4f72ff94(x52608227a52a6472.xd2f68ee6f47e9dfb) as xab391c46ff9a0a38;
				x08ce8f4769eb3234.x0e1bf8242ad10272 = x0e1bf8242ad;
				break;
			}
			default:
				x52608227a52a6472.x28fcdc775a1d069c.x8194fa1e2b16932f.x1a417412416bdd23(x52608227a52a6472.xa66385d80d4d296f, x52608227a52a6472.xd2f68ee6f47e9dfb);
				break;
			}
		}
	}

	private static void xea0aef655028e8cd(x95792ebebfd0979f x52608227a52a6472)
	{
		x1fdc4491fb4c3ee8 x28fcdc775a1d069c = x52608227a52a6472.x28fcdc775a1d069c;
		xb8e7e788f6d59708 xb8e7e788f6d = new xb8e7e788f6d59708();
		string x585da4d9795fa = null;
		string xeaf1b27180c0557b = null;
		float num = 0f;
		float num2 = 0f;
		x54366fa5f75a02f7 x54366fa5f75a02f = null;
		while (x52608227a52a6472.x1ac1960adc8c4c39())
		{
			switch (x52608227a52a6472.xa66385d80d4d296f)
			{
			case "transform":
				x54366fa5f75a02f = xf7e2753b1f50fb2b.xb3da63d0517cf3c6(x52608227a52a6472.xd2f68ee6f47e9dfb, x28fcdc775a1d069c);
				break;
			case "href":
				x585da4d9795fa = x52608227a52a6472.xd2f68ee6f47e9dfb;
				break;
			case "id":
				xeaf1b27180c0557b = x52608227a52a6472.xd2f68ee6f47e9dfb;
				break;
			case "x":
				num = xf7e2753b1f50fb2b.xfd3c39adee96110c(x52608227a52a6472.xd2f68ee6f47e9dfb, x28fcdc775a1d069c);
				break;
			case "y":
				num2 = xf7e2753b1f50fb2b.xfd3c39adee96110c(x52608227a52a6472.xd2f68ee6f47e9dfb, x28fcdc775a1d069c);
				break;
			default:
				x28fcdc775a1d069c.xbbf9a1ead81dd3a1(WarningType.UnexpectedContent, $"Attribute '{x52608227a52a6472.xa66385d80d4d296f}' is unexpected and will be ignored");
				break;
			}
		}
		if (x54366fa5f75a02f != null)
		{
			xb8e7e788f6d.x52dde376accdec7d = x54366fa5f75a02f;
		}
		if (!x15e971129fd80714.x5ab3b42bd288ad29(num) || !x15e971129fd80714.x5ab3b42bd288ad29(num2))
		{
			if (x54366fa5f75a02f == null)
			{
				xb8e7e788f6d.x52dde376accdec7d = new x54366fa5f75a02f7();
			}
			xb8e7e788f6d.x52dde376accdec7d.xce92de628aa023cf(num, num2);
		}
		x28fcdc775a1d069c.x1fa9148f6731ff24(xb8e7e788f6d, xeaf1b27180c0557b);
		x28fcdc775a1d069c.xffdeeab52bfac6bd(xb8e7e788f6d);
		x28fcdc775a1d069c.x9ef787a55e8ffc34(x585da4d9795fa);
		x4407ca4302a525f6(xb8e7e788f6d, x52608227a52a6472);
		x28fcdc775a1d069c.xf5b0b9b6ff7ac462();
	}

	private static bool xa853df7acdb217c8(string xcf9e4e23ccc9a5e6)
	{
		if (xcf9e4e23ccc9a5e6 != "hidden")
		{
			return xcf9e4e23ccc9a5e6 != "collapse";
		}
		return false;
	}
}
