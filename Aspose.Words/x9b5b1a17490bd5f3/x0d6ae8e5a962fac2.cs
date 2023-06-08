using Aspose.Words;
using Aspose.Words.Lists;
using x643046e3f004c49f;
using x7c4557e104065fc9;

namespace x9b5b1a17490bd5f3;

internal class x0d6ae8e5a962fac2
{
	private readonly DocumentBuilder x800085dd555f7711;

	private int x3a7c3e067b17a2e5;

	private int xe0bd4bd0f02eff5d;

	private bool xbc1e965ee7f16022;

	private readonly List x870980ad82373217;

	internal int x51e5bb947db89a97 => xe0bd4bd0f02eff5d;

	internal List x6798e661271685a9 => x870980ad82373217;

	internal x0d6ae8e5a962fac2(DocumentBuilder builder, x9d6b37cac59aa2e2 listNode, int startLevel)
	{
		x800085dd555f7711 = builder;
		x3a7c3e067b17a2e5 = startLevel;
		xe0bd4bd0f02eff5d = startLevel;
		xbc1e965ee7f16022 = false;
		string x43163d22e8cd5a = listNode.x75658b3f8be4005c("type", "");
		x870980ad82373217 = x800085dd555f7711.Document.Lists.Add((listNode.x759aa16c2016a289 == "ol") ? xd427b8a5b3e8b09e(x43163d22e8cd5a) : x7dddd76e4e105b02(x43163d22e8cd5a));
		xa1992a3349e0751d(listNode);
	}

	internal bool x038e7b90f8869b95(x9d6b37cac59aa2e2 xf1d763d8caf5ec79)
	{
		bool flag = !xbc1e965ee7f16022 && xe0bd4bd0f02eff5d < 8;
		if (flag)
		{
			xe0bd4bd0f02eff5d++;
			xa1992a3349e0751d(xf1d763d8caf5ec79);
		}
		return flag;
	}

	private void xa1992a3349e0751d(x9d6b37cac59aa2e2 xf1d763d8caf5ec79)
	{
		ListLevel listLevel = x870980ad82373217.ListLevels[xe0bd4bd0f02eff5d];
		string text = xf1d763d8caf5ec79.x75658b3f8be4005c("type", "");
		if (xf1d763d8caf5ec79.x759aa16c2016a289 == "ol")
		{
			listLevel.NumberStyle = xdae3ed86d2af09e7(text);
			listLevel.NumberFormat = $"{(char)xe0bd4bd0f02eff5d}.";
			listLevel.xd62f9a1bfab2aceb(xf1d763d8caf5ec79.x75658b3f8be4005c("start", 1));
			listLevel.xeedad81aaed42a76.x52b190e626f65140(230);
			listLevel.xeedad81aaed42a76.x52b190e626f65140(235);
			listLevel.xeedad81aaed42a76.x52b190e626f65140(240);
			listLevel.xeedad81aaed42a76.x52b190e626f65140(270);
			return;
		}
		listLevel.NumberStyle = NumberStyle.Bullet;
		if (text.Length == 0)
		{
			text = x495fdb45f3d92b70.xc948ae21e4aca55a(xe0bd4bd0f02eff5d);
		}
		switch (text)
		{
		case "circle":
			listLevel.NumberFormat = "o";
			listLevel.xeedad81aaed42a76.x51cf23ce6e71b84c = "Courier New";
			listLevel.xeedad81aaed42a76.xd08cbc518cf39317 = "Courier New";
			break;
		case "square":
			listLevel.NumberFormat = "\uf0a7";
			listLevel.xeedad81aaed42a76.x51cf23ce6e71b84c = "Wingdings";
			listLevel.xeedad81aaed42a76.xd08cbc518cf39317 = "Wingdings";
			break;
		default:
			listLevel.NumberFormat = "\uf0b7";
			listLevel.xeedad81aaed42a76.x51cf23ce6e71b84c = "Symbol";
			listLevel.xeedad81aaed42a76.xd08cbc518cf39317 = "Symbol";
			break;
		}
	}

	internal bool x5eb52b44a2d563c0()
	{
		bool flag = xe0bd4bd0f02eff5d > x3a7c3e067b17a2e5;
		if (flag)
		{
			xe0bd4bd0f02eff5d--;
			xbc1e965ee7f16022 = true;
		}
		return flag;
	}

	internal void xcbea96666365f182(x9d6b37cac59aa2e2 xda5bf54deb817e37)
	{
		x800085dd555f7711.ListFormat.List = x870980ad82373217;
		x800085dd555f7711.ListFormat.ListLevelNumber = xe0bd4bd0f02eff5d;
	}

	private static ListTemplate x7dddd76e4e105b02(string x43163d22e8cd5a71)
	{
		return x43163d22e8cd5a71 switch
		{
			"disc" => ListTemplate.BulletDefault, 
			"circle" => ListTemplate.BulletCircle, 
			"square" => ListTemplate.BulletSquare, 
			_ => ListTemplate.BulletDefault, 
		};
	}

	private static ListTemplate xd427b8a5b3e8b09e(string x43163d22e8cd5a71)
	{
		return x43163d22e8cd5a71 switch
		{
			"1" => ListTemplate.NumberDefault, 
			"a" => ListTemplate.NumberLowercaseLetterDot, 
			"A" => ListTemplate.NumberUppercaseLetterDot, 
			"i" => ListTemplate.NumberLowercaseRomanDot, 
			"I" => ListTemplate.NumberUppercaseRomanDot, 
			_ => ListTemplate.NumberDefault, 
		};
	}

	private static NumberStyle xdae3ed86d2af09e7(string x43163d22e8cd5a71)
	{
		return x43163d22e8cd5a71 switch
		{
			"1" => NumberStyle.Arabic, 
			"a" => NumberStyle.LowercaseLetter, 
			"A" => NumberStyle.UppercaseLetter, 
			"i" => NumberStyle.LowercaseRoman, 
			"I" => NumberStyle.UppercaseRoman, 
			_ => NumberStyle.Arabic, 
		};
	}
}
