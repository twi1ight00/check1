using System.Text;
using x6c95d9cf46ff5f25;

namespace xfbd1009a0cbb9842;

internal class xbe86a91b1d1cbdcd
{
	internal static string xa12e146e281d0573(x985dd08fd338eeea x0e59413709b18038, int x950ce1a20fc7ea38, string x5d4886a12ee6dcbe)
	{
		StringBuilder stringBuilder = x6ebd79be2a2f05e4(x0e59413709b18038);
		bool flag = false;
		for (int i = 0; i < x0e59413709b18038.x450f47a9028f884b.Count; i++)
		{
			if (i == x950ce1a20fc7ea38)
			{
				x917b69030691beda(stringBuilder, xc59a809ebd5357aa(x5d4886a12ee6dcbe));
				flag = true;
			}
			else
			{
				x917b69030691beda(stringBuilder, x0e59413709b18038.x642e37025c67edab(i, x9fc40ce4428c62cc: false));
			}
		}
		if (!flag)
		{
			int num = x950ce1a20fc7ea38 - x0e59413709b18038.x450f47a9028f884b.Count;
			for (int j = 0; j < num; j++)
			{
				x917b69030691beda(stringBuilder, "\"\"");
			}
			x917b69030691beda(stringBuilder, xc59a809ebd5357aa(x5d4886a12ee6dcbe));
		}
		x389d42024b777b05(stringBuilder, x0e59413709b18038);
		return stringBuilder.ToString();
	}

	internal static string xa49d2eb0863a229c(x985dd08fd338eeea x0e59413709b18038)
	{
		StringBuilder stringBuilder = x6ebd79be2a2f05e4(x0e59413709b18038);
		for (int i = 0; i < x0e59413709b18038.x450f47a9028f884b.Count - 1; i++)
		{
			x917b69030691beda(stringBuilder, x0e59413709b18038.x642e37025c67edab(i, x9fc40ce4428c62cc: false));
		}
		x389d42024b777b05(stringBuilder, x0e59413709b18038);
		return stringBuilder.ToString();
	}

	internal static string xe5d1e5e3ded2572a(x985dd08fd338eeea x0e59413709b18038, string x724fbd227bfb6eda, bool xa1ca3186bd369811)
	{
		StringBuilder stringBuilder = x6ebd79be2a2f05e4(x0e59413709b18038);
		xc9927d642dd90a74(stringBuilder, x0e59413709b18038);
		bool flag = false;
		foreach (xcfa6f73a76d96956 item in x0e59413709b18038.x7261c103565fa212)
		{
			if (x0d299f323d241756.x90637a473b1ceaaa(x724fbd227bfb6eda, item.x759aa16c2016a289))
			{
				if (xa1ca3186bd369811)
				{
					x917b69030691beda(stringBuilder, item.x633d57e35b6715a4());
					flag = true;
				}
			}
			else
			{
				x917b69030691beda(stringBuilder, item.x633d57e35b6715a4());
			}
		}
		if (xa1ca3186bd369811 && !flag)
		{
			x917b69030691beda(stringBuilder, x724fbd227bfb6eda);
		}
		return stringBuilder.ToString();
	}

	internal static string xe5d1e5e3ded2572a(x985dd08fd338eeea x0e59413709b18038, string x724fbd227bfb6eda, string xddda620843637857, int xb53be37c1d09c26c)
	{
		StringBuilder stringBuilder = x6ebd79be2a2f05e4(x0e59413709b18038);
		xc9927d642dd90a74(stringBuilder, x0e59413709b18038);
		int num = 0;
		bool flag = false;
		if (x5c29822913be33c1.x5580509afa07e28e(x724fbd227bfb6eda) && xddda620843637857 != null)
		{
			x917b69030691beda(stringBuilder, x724fbd227bfb6eda, xc59a809ebd5357aa(xddda620843637857));
			flag = true;
		}
		foreach (xcfa6f73a76d96956 item in x0e59413709b18038.x7261c103565fa212)
		{
			if (x0d299f323d241756.x90637a473b1ceaaa(x724fbd227bfb6eda, item.x759aa16c2016a289))
			{
				if (num == xb53be37c1d09c26c)
				{
					if (xddda620843637857 != null && !flag)
					{
						x917b69030691beda(stringBuilder, x724fbd227bfb6eda, xc59a809ebd5357aa(xddda620843637857));
						flag = true;
					}
				}
				else
				{
					x917b69030691beda(stringBuilder, item.x633d57e35b6715a4());
				}
				num++;
			}
			else
			{
				x917b69030691beda(stringBuilder, item.x633d57e35b6715a4());
			}
		}
		if (xddda620843637857 != null && !flag)
		{
			x917b69030691beda(stringBuilder, x724fbd227bfb6eda, xc59a809ebd5357aa(xddda620843637857));
		}
		return stringBuilder.ToString();
	}

	private static string xc59a809ebd5357aa(string xf6fec61b61cb58a0)
	{
		for (int i = 0; i < xf6fec61b61cb58a0.Length; i++)
		{
			if ((i <= 0 || xf6fec61b61cb58a0[i - 1] != '\\') && xf6fec61b61cb58a0[i] == '"')
			{
				xf6fec61b61cb58a0 = xf6fec61b61cb58a0.Insert(i, "\\");
			}
		}
		if (xf6fec61b61cb58a0.Length == 0 || x0d299f323d241756.x6df149467337111e(xf6fec61b61cb58a0))
		{
			xf6fec61b61cb58a0 = $"\"{xf6fec61b61cb58a0}\"";
		}
		return xf6fec61b61cb58a0;
	}

	private static StringBuilder x6ebd79be2a2f05e4(x985dd08fd338eeea x0e59413709b18038)
	{
		StringBuilder stringBuilder = new StringBuilder();
		x917b69030691beda(stringBuilder, x0e59413709b18038.xc96d173d58dd8a20);
		return stringBuilder;
	}

	private static void xc9927d642dd90a74(StringBuilder xd07ce4b74c5774a7, x985dd08fd338eeea x0e59413709b18038)
	{
		foreach (x64629b07e6a0cb07 item in x0e59413709b18038.x450f47a9028f884b)
		{
			x917b69030691beda(xd07ce4b74c5774a7, item.xd961adf06ad48c3f(x82dae5f27bd7d807: false));
		}
	}

	private static void x389d42024b777b05(StringBuilder xd07ce4b74c5774a7, x985dd08fd338eeea x0e59413709b18038)
	{
		foreach (xcfa6f73a76d96956 item in x0e59413709b18038.x7261c103565fa212)
		{
			x917b69030691beda(xd07ce4b74c5774a7, item.x633d57e35b6715a4());
		}
	}

	private static void x917b69030691beda(StringBuilder xd07ce4b74c5774a7, string xec7dcb687e97a7d7)
	{
		xd07ce4b74c5774a7.AppendFormat(" {0}", xec7dcb687e97a7d7);
	}

	private static void x917b69030691beda(StringBuilder xd07ce4b74c5774a7, string xec7dcb687e97a7d7, string x6ffd1fa6ed343720)
	{
		xd07ce4b74c5774a7.AppendFormat(" {0} {1}", xec7dcb687e97a7d7, x6ffd1fa6ed343720);
	}
}
