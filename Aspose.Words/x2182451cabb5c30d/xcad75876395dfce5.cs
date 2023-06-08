using System.Collections;
using Aspose.Words;
using x28925c9b27b37a46;

namespace x2182451cabb5c30d;

internal class xcad75876395dfce5
{
	private readonly StyleCollection x18c770831ef0bf38;

	private readonly Hashtable x1b44ada6da662c73 = new Hashtable();

	internal xcad75876395dfce5(StyleCollection styles)
	{
		x18c770831ef0bf38 = styles;
	}

	internal void x61a426bf2696399a()
	{
		for (int i = 0; i < x18c770831ef0bf38.Count; i++)
		{
			Style x44ecfea61c937b8e = x18c770831ef0bf38[i];
			x56aa7312dacf8de0(x44ecfea61c937b8e);
		}
	}

	private static Style x5b90e341480f6cd3(Style x44ecfea61c937b8e)
	{
		Style style = Style.xebcf83b00134300b(x44ecfea61c937b8e.Type);
		style.xeedad81aaed42a76 = x44ecfea61c937b8e.x856218fd0771d379(xecac24b19ed3a2b7.xe9e531d1a6725226);
		style.x1a78664fa10a3755 = x44ecfea61c937b8e.x2e12c5f9278ae233(xd9bc7f7e70d71e14.xe9e531d1a6725226);
		return style;
	}

	private void x56aa7312dacf8de0(Style x44ecfea61c937b8e)
	{
		int xe709b224f455b = x44ecfea61c937b8e.xe709b224f455b863;
		if (xe709b224f455b == 4095 || xe709b224f455b == x44ecfea61c937b8e.x8301ab10c226b0c2 || x952aadf9fc5cb198(x44ecfea61c937b8e))
		{
			return;
		}
		Style style = x18c770831ef0bf38.xf194004582627ed5(xe709b224f455b, 4095);
		if (style != null)
		{
			if (!x952aadf9fc5cb198(style))
			{
				x56aa7312dacf8de0(style);
			}
			Style style2 = x5b90e341480f6cd3(style);
			x44ecfea61c937b8e.xeedad81aaed42a76.x968eca275aff04e3(style2.xeedad81aaed42a76, 50);
			x44ecfea61c937b8e.x1a78664fa10a3755.x968eca275aff04e3(style2.x1a78664fa10a3755, 1000);
			x1b44ada6da662c73.Add(x44ecfea61c937b8e, null);
		}
	}

	private bool x952aadf9fc5cb198(Style x44ecfea61c937b8e)
	{
		return x1b44ada6da662c73.Contains(x44ecfea61c937b8e);
	}
}
