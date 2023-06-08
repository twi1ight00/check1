using System;
using Aspose.Words;
using Aspose.Words.Lists;

namespace xd2754ae26d400653;

internal class x67af7bcbfd57c02b
{
	internal const string x9566a841c952dfd4 = "Symbol";

	internal const char x2dd7b7faad3ec5a8 = '\uf0b7';

	internal const string x2e48326248335fcf = "\uf0b7";

	internal const char xf672997f20773e8e = '\uf0a8';

	internal const string x7a50fa4a1ba494ee = "\uf0a8";

	internal const string x8e268f9a37e91d3b = "Courier New";

	internal const char xd128e12bc186b8dc = 'o';

	internal const string xa6d47d35d9ff79c5 = "o";

	internal const string xd6f9965874112948 = "Wingdings";

	internal const char xa435ea0897f752ac = '\uf0a7';

	internal const string xfc83d498fcb69c1e = "\uf0a7";

	internal const char xf91e27bdaa3357b4 = '\uf076';

	internal const string x4c99c4defe9553ef = "\uf076";

	internal const char x27fc388599f817a4 = '\uf0d8';

	internal const string xa70efe83d5c70c08 = "\uf0d8";

	internal const char x037a5e66e5645e89 = '\uf0fc';

	internal const string xd78baeb7c8b6f473 = "\uf0fc";

	private static readonly char[] xb3618bd8f76728c9 = new char[7] { '\uf0b7', '\uf0a8', 'o', '\uf0a7', '\uf076', '\uf0d8', '\uf0fc' };

	private static readonly string[] x883aa02070fcd857 = new string[7] { "Symbol", "Symbol", "Courier New", "Wingdings", "Wingdings", "Wingdings", "Wingdings" };

	private x67af7bcbfd57c02b()
	{
	}

	internal static List x28d01548f153fdbe(ListCollection x7d45a69b707b1582, ListTemplate x7d5e66859bb4a86f)
	{
		return x7d5e66859bb4a86f switch
		{
			ListTemplate.BulletDefault => xb1f839538f5d2c98(x7d45a69b707b1582), 
			ListTemplate.BulletCircle => xb1f839538f5d2c98(x7d45a69b707b1582, "o", "Courier New"), 
			ListTemplate.BulletSquare => xb1f839538f5d2c98(x7d45a69b707b1582, "\uf0a7", "Wingdings"), 
			ListTemplate.BulletDiamonds => xb1f839538f5d2c98(x7d45a69b707b1582, "\uf076", "Wingdings"), 
			ListTemplate.BulletArrowHead => xb1f839538f5d2c98(x7d45a69b707b1582, "\uf0d8", "Wingdings"), 
			ListTemplate.BulletTick => xb1f839538f5d2c98(x7d45a69b707b1582, "\uf0fc", "Wingdings"), 
			ListTemplate.NumberDefault => xcdb6412d04969b27(x7d45a69b707b1582), 
			ListTemplate.NumberArabicParenthesis => xcdb6412d04969b27(x7d45a69b707b1582, NumberStyle.Arabic, "\0)", ListLevelAlignment.Left), 
			ListTemplate.NumberUppercaseRomanDot => xcdb6412d04969b27(x7d45a69b707b1582, NumberStyle.UppercaseRoman, "\0.", ListLevelAlignment.Right), 
			ListTemplate.NumberUppercaseLetterDot => xcdb6412d04969b27(x7d45a69b707b1582, NumberStyle.UppercaseLetter, "\0.", ListLevelAlignment.Left), 
			ListTemplate.NumberLowercaseLetterParenthesis => xcdb6412d04969b27(x7d45a69b707b1582, NumberStyle.LowercaseLetter, "\0)", ListLevelAlignment.Left), 
			ListTemplate.NumberLowercaseLetterDot => xcdb6412d04969b27(x7d45a69b707b1582, NumberStyle.LowercaseLetter, "\0.", ListLevelAlignment.Left), 
			ListTemplate.NumberLowercaseRomanDot => xcdb6412d04969b27(x7d45a69b707b1582, NumberStyle.LowercaseRoman, "\0.", ListLevelAlignment.Right), 
			ListTemplate.OutlineNumbers => x59891d08264ec749(x7d45a69b707b1582), 
			ListTemplate.OutlineLegal => x3393f946fe2710d5(x7d45a69b707b1582), 
			ListTemplate.OutlineBullets => x483937481a73136f(x7d45a69b707b1582), 
			ListTemplate.OutlineHeadingsArticleSection => x8d830aedf4582b92(x7d45a69b707b1582), 
			ListTemplate.OutlineHeadingsLegal => xfcc2d2029cadcd21(x7d45a69b707b1582), 
			ListTemplate.OutlineHeadingsNumbers => x893ba770715b8373(x7d45a69b707b1582), 
			ListTemplate.OutlineHeadingsChapter => xb20c3d8fe3f5cf35(x7d45a69b707b1582), 
			_ => throw new ArgumentException("template"), 
		};
	}

	internal static string x7bf00b1e5eb813c8(char x3fa3314c5f8a4689)
	{
		int num = xb3618bd8f76728c9.Length;
		while (--num >= 0)
		{
			if (x3fa3314c5f8a4689 == xb3618bd8f76728c9[num])
			{
				return x883aa02070fcd857[num];
			}
		}
		return null;
	}

	private static List xb1f839538f5d2c98(ListCollection x7d45a69b707b1582)
	{
		List list = x7d45a69b707b1582.xcf5f82306ceb0bff(x902c8ac86fbaf048.x598f41525926b38a);
		xa3841eca93630cb2(list, 0, "Symbol", "\uf0b7", 720, 720, -360);
		xa3841eca93630cb2(list, 1, "Courier New", "o", 1440, 1440, -360);
		xa3841eca93630cb2(list, 2, "Wingdings", "\uf0a7", 2160, 2160, -360);
		xa3841eca93630cb2(list, 3, "Symbol", "\uf0b7", 2880, 2880, -360);
		xa3841eca93630cb2(list, 4, "Courier New", "o", 3600, 3600, -360);
		xa3841eca93630cb2(list, 5, "Wingdings", "\uf0a7", 4320, 4320, -360);
		xa3841eca93630cb2(list, 6, "Symbol", "\uf0b7", 5040, 5040, -360);
		xa3841eca93630cb2(list, 7, "Courier New", "o", 5760, 5760, -360);
		xa3841eca93630cb2(list, 8, "Wingdings", "\uf0a7", 6480, 6480, -360);
		return list;
	}

	private static List xb1f839538f5d2c98(ListCollection x7d45a69b707b1582, string xae58d1571db7bd98, string x5e1be00635c86a9b)
	{
		List list = xb1f839538f5d2c98(x7d45a69b707b1582);
		list.ListLevels[0].NumberFormat = xae58d1571db7bd98;
		list.ListLevels[0].xeedad81aaed42a76.x51cf23ce6e71b84c = x5e1be00635c86a9b;
		list.ListLevels[0].xeedad81aaed42a76.xd08cbc518cf39317 = x5e1be00635c86a9b;
		return list;
	}

	private static List xcdb6412d04969b27(ListCollection x7d45a69b707b1582)
	{
		List list = x7d45a69b707b1582.xcf5f82306ceb0bff(x902c8ac86fbaf048.x598f41525926b38a);
		xb9afeab740e736fe(list, 0, NumberStyle.Arabic, "\0.", ListLevelAlignment.Left, 720, 720, -360);
		xb9afeab740e736fe(list, 1, NumberStyle.LowercaseLetter, "\u0001.", ListLevelAlignment.Left, 1440, 1440, -360);
		xb9afeab740e736fe(list, 2, NumberStyle.LowercaseRoman, "\u0002.", ListLevelAlignment.Right, 2160, 2160, -180);
		xb9afeab740e736fe(list, 3, NumberStyle.Arabic, "\u0003.", ListLevelAlignment.Left, 2880, 2880, -360);
		xb9afeab740e736fe(list, 4, NumberStyle.LowercaseLetter, "\u0004.", ListLevelAlignment.Left, 3600, 3600, -360);
		xb9afeab740e736fe(list, 5, NumberStyle.LowercaseRoman, "\u0005.", ListLevelAlignment.Right, 4320, 4320, -180);
		xb9afeab740e736fe(list, 6, NumberStyle.Arabic, "\u0006.", ListLevelAlignment.Left, 5040, 5040, -360);
		xb9afeab740e736fe(list, 7, NumberStyle.LowercaseLetter, "\a.", ListLevelAlignment.Left, 5760, 5760, -360);
		xb9afeab740e736fe(list, 8, NumberStyle.LowercaseRoman, "\b.", ListLevelAlignment.Right, 6480, 6480, -180);
		return list;
	}

	private static List xcdb6412d04969b27(ListCollection x7d45a69b707b1582, NumberStyle x4adcabe371968216, string xae58d1571db7bd98, ListLevelAlignment xf80d83c50d4508b0)
	{
		List list = xcdb6412d04969b27(x7d45a69b707b1582);
		list.ListLevels[0].NumberStyle = x4adcabe371968216;
		list.ListLevels[0].NumberFormat = xae58d1571db7bd98;
		list.ListLevels[0].Alignment = xf80d83c50d4508b0;
		return list;
	}

	private static List x59891d08264ec749(ListCollection x7d45a69b707b1582)
	{
		List list = x7d45a69b707b1582.xcf5f82306ceb0bff(x902c8ac86fbaf048.x7e86ac926e2dc940);
		xb9afeab740e736fe(list, 0, NumberStyle.Arabic, "\0)", ListLevelAlignment.Left, 360, 360, -360);
		xb9afeab740e736fe(list, 1, NumberStyle.LowercaseLetter, "\u0001)", ListLevelAlignment.Left, 720, 720, -360);
		xb9afeab740e736fe(list, 2, NumberStyle.LowercaseRoman, "\u0002)", ListLevelAlignment.Left, 1080, 1080, -360);
		xb9afeab740e736fe(list, 3, NumberStyle.Arabic, "(\u0003)", ListLevelAlignment.Left, 1440, 1440, -360);
		xb9afeab740e736fe(list, 4, NumberStyle.LowercaseLetter, "(\u0004)", ListLevelAlignment.Left, 1800, 1800, -360);
		xb9afeab740e736fe(list, 5, NumberStyle.LowercaseRoman, "(\u0005)", ListLevelAlignment.Left, 2160, 2160, -360);
		xb9afeab740e736fe(list, 6, NumberStyle.Arabic, "\u0006.", ListLevelAlignment.Left, 2520, 2520, -360);
		xb9afeab740e736fe(list, 7, NumberStyle.LowercaseLetter, "\a.", ListLevelAlignment.Left, 2880, 2880, -360);
		xb9afeab740e736fe(list, 8, NumberStyle.LowercaseRoman, "\b.", ListLevelAlignment.Left, 3240, 3240, -360);
		return list;
	}

	private static List x3393f946fe2710d5(ListCollection x7d45a69b707b1582)
	{
		List list = x7d45a69b707b1582.xcf5f82306ceb0bff(x902c8ac86fbaf048.x7e86ac926e2dc940);
		xb9afeab740e736fe(list, 0, NumberStyle.Arabic, "\0.", ListLevelAlignment.Left, 360, 360, -360);
		xb9afeab740e736fe(list, 1, NumberStyle.Arabic, "\0.\u0001.", ListLevelAlignment.Left, 792, 792, -432);
		xb9afeab740e736fe(list, 2, NumberStyle.Arabic, "\0.\u0001.\u0002.", ListLevelAlignment.Left, 1440, 1224, -504);
		xb9afeab740e736fe(list, 3, NumberStyle.Arabic, "\0.\u0001.\u0002.\u0003.", ListLevelAlignment.Left, 1800, 1728, -648);
		xb9afeab740e736fe(list, 4, NumberStyle.Arabic, "\0.\u0001.\u0002.\u0003.\u0004.", ListLevelAlignment.Left, 2520, 2232, -792);
		xb9afeab740e736fe(list, 5, NumberStyle.Arabic, "\0.\u0001.\u0002.\u0003.\u0004.\u0005.", ListLevelAlignment.Left, 2880, 2736, -936);
		xb9afeab740e736fe(list, 6, NumberStyle.Arabic, "\0.\u0001.\u0002.\u0003.\u0004.\u0005.\u0006.", ListLevelAlignment.Left, 3600, 3240, -1080);
		xb9afeab740e736fe(list, 7, NumberStyle.Arabic, "\0.\u0001.\u0002.\u0003.\u0004.\u0005.\u0006.\a.", ListLevelAlignment.Left, 3960, 3744, -1224);
		xb9afeab740e736fe(list, 8, NumberStyle.Arabic, "\0.\u0001.\u0002.\u0003.\u0004.\u0005.\u0006.\a.\b.", ListLevelAlignment.Left, 4680, 4320, -1440);
		return list;
	}

	private static List x483937481a73136f(ListCollection x7d45a69b707b1582)
	{
		List list = x7d45a69b707b1582.xcf5f82306ceb0bff(x902c8ac86fbaf048.x7e86ac926e2dc940);
		xa3841eca93630cb2(list, 0, "Wingdings", "\uf076", 360, 360, -360);
		xa3841eca93630cb2(list, 1, "Wingdings", "\uf0d8", 720, 720, -360);
		xa3841eca93630cb2(list, 2, "Wingdings", "\uf0a7", 1080, 1080, -360);
		xa3841eca93630cb2(list, 3, "Symbol", "\uf0b7", 1440, 1440, -360);
		xa3841eca93630cb2(list, 4, "Symbol", "\uf0a8", 1800, 1800, -360);
		xa3841eca93630cb2(list, 5, "Wingdings", "\uf0d8", 2160, 2160, -360);
		xa3841eca93630cb2(list, 6, "Wingdings", "\uf0a7", 2520, 2520, -360);
		xa3841eca93630cb2(list, 7, "Symbol", "\uf0b7", 2880, 2880, -360);
		xa3841eca93630cb2(list, 8, "Symbol", "\uf0a8", 3240, 3240, -360);
		return list;
	}

	private static List x8d830aedf4582b92(ListCollection x7d45a69b707b1582)
	{
		List list = x7d45a69b707b1582.xcf5f82306ceb0bff(x902c8ac86fbaf048.x7e86ac926e2dc940);
		xb9afeab740e736fe(list, 0, NumberStyle.UppercaseRoman, "Article \0.", ListLevelAlignment.Left, 1800, 0, 0, 1, ListTrailingCharacter.Tab);
		xb9afeab740e736fe(list, 1, NumberStyle.LeadingZero, "Section \0.\u0001", ListLevelAlignment.Left, 1800, 0, 0, 2, ListTrailingCharacter.Tab);
		list.ListLevels[1].IsLegal = true;
		xb9afeab740e736fe(list, 2, NumberStyle.LowercaseLetter, "(\u0002)", ListLevelAlignment.Left, 720, 720, -432, 3, ListTrailingCharacter.Tab);
		xb9afeab740e736fe(list, 3, NumberStyle.LowercaseRoman, "(\u0003)", ListLevelAlignment.Right, 864, 864, -144, 4, ListTrailingCharacter.Tab);
		xb9afeab740e736fe(list, 4, NumberStyle.Arabic, "\u0004)", ListLevelAlignment.Left, 1008, 1008, -432, 5, ListTrailingCharacter.Tab);
		xb9afeab740e736fe(list, 5, NumberStyle.LowercaseLetter, "\u0005)", ListLevelAlignment.Left, 1152, 1152, -432, 6, ListTrailingCharacter.Tab);
		xb9afeab740e736fe(list, 6, NumberStyle.LowercaseRoman, "\u0006)", ListLevelAlignment.Right, 1296, 1296, -288, 7, ListTrailingCharacter.Tab);
		xb9afeab740e736fe(list, 7, NumberStyle.LowercaseLetter, "\a.", ListLevelAlignment.Left, 1440, 1440, -432, 8, ListTrailingCharacter.Tab);
		xb9afeab740e736fe(list, 8, NumberStyle.LowercaseRoman, "\b.", ListLevelAlignment.Right, 1584, 1584, -144, 9, ListTrailingCharacter.Tab);
		return list;
	}

	private static List xfcc2d2029cadcd21(ListCollection x7d45a69b707b1582)
	{
		List list = x7d45a69b707b1582.xcf5f82306ceb0bff(x902c8ac86fbaf048.x7e86ac926e2dc940);
		xb9afeab740e736fe(list, 0, NumberStyle.Arabic, "\0", ListLevelAlignment.Left, 432, 432, -432, 1, ListTrailingCharacter.Tab);
		xb9afeab740e736fe(list, 1, NumberStyle.Arabic, "\0.\u0001", ListLevelAlignment.Left, 576, 576, -576, 2, ListTrailingCharacter.Tab);
		xb9afeab740e736fe(list, 2, NumberStyle.Arabic, "\0.\u0001.\u0002", ListLevelAlignment.Left, 720, 720, -720, 3, ListTrailingCharacter.Tab);
		xb9afeab740e736fe(list, 3, NumberStyle.Arabic, "\0.\u0001.\u0002.\u0003", ListLevelAlignment.Left, 864, 864, -864, 4, ListTrailingCharacter.Tab);
		xb9afeab740e736fe(list, 4, NumberStyle.Arabic, "\0.\u0001.\u0002.\u0003.\u0004", ListLevelAlignment.Left, 1008, 1008, -1008, 5, ListTrailingCharacter.Tab);
		xb9afeab740e736fe(list, 5, NumberStyle.Arabic, "\0.\u0001.\u0002.\u0003.\u0004.\u0005", ListLevelAlignment.Left, 1152, 1152, -1152, 6, ListTrailingCharacter.Tab);
		xb9afeab740e736fe(list, 6, NumberStyle.Arabic, "\0.\u0001.\u0002.\u0003.\u0004.\u0005.\u0006", ListLevelAlignment.Left, 1296, 1296, -1296, 7, ListTrailingCharacter.Tab);
		xb9afeab740e736fe(list, 7, NumberStyle.Arabic, "\0.\u0001.\u0002.\u0003.\u0004.\u0005.\u0006.\a", ListLevelAlignment.Left, 1440, 1440, -1440, 8, ListTrailingCharacter.Tab);
		xb9afeab740e736fe(list, 8, NumberStyle.Arabic, "\0.\u0001.\u0002.\u0003.\u0004.\u0005.\u0006.\a.\b", ListLevelAlignment.Left, 1584, 1584, -1584, 9, ListTrailingCharacter.Tab);
		return list;
	}

	private static List x893ba770715b8373(ListCollection x7d45a69b707b1582)
	{
		List list = x7d45a69b707b1582.xcf5f82306ceb0bff(x902c8ac86fbaf048.x7e86ac926e2dc940);
		xb9afeab740e736fe(list, 0, NumberStyle.UppercaseRoman, "\0.", ListLevelAlignment.Left, 360, 0, 0, 1, ListTrailingCharacter.Tab);
		xb9afeab740e736fe(list, 1, NumberStyle.UppercaseLetter, "\u0001.", ListLevelAlignment.Left, 1080, 720, 0, 2, ListTrailingCharacter.Tab);
		xb9afeab740e736fe(list, 2, NumberStyle.Arabic, "\u0002.", ListLevelAlignment.Left, 1800, 1440, 0, 3, ListTrailingCharacter.Tab);
		xb9afeab740e736fe(list, 3, NumberStyle.LowercaseLetter, "\u0003)", ListLevelAlignment.Left, 2520, 2160, 0, 4, ListTrailingCharacter.Tab);
		xb9afeab740e736fe(list, 4, NumberStyle.Arabic, "(\u0004)", ListLevelAlignment.Left, 3240, 2880, 0, 5, ListTrailingCharacter.Tab);
		xb9afeab740e736fe(list, 5, NumberStyle.LowercaseLetter, "(\u0005)", ListLevelAlignment.Left, 3960, 3600, 0, 6, ListTrailingCharacter.Tab);
		xb9afeab740e736fe(list, 6, NumberStyle.LowercaseRoman, "(\u0006)", ListLevelAlignment.Left, 4680, 4320, 0, 7, ListTrailingCharacter.Tab);
		xb9afeab740e736fe(list, 7, NumberStyle.LowercaseLetter, "(\a)", ListLevelAlignment.Left, 5400, 5040, 0, 8, ListTrailingCharacter.Tab);
		xb9afeab740e736fe(list, 8, NumberStyle.LowercaseRoman, "(\b)", ListLevelAlignment.Left, 6120, 5760, 0, 9, ListTrailingCharacter.Tab);
		return list;
	}

	private static List xb20c3d8fe3f5cf35(ListCollection x7d45a69b707b1582)
	{
		List list = x7d45a69b707b1582.xcf5f82306ceb0bff(x902c8ac86fbaf048.x7e86ac926e2dc940);
		xb9afeab740e736fe(list, 0, NumberStyle.Arabic, "Chapter \0", ListLevelAlignment.Left, 0, 0, 0, 1, ListTrailingCharacter.Space);
		xb9afeab740e736fe(list, 1, NumberStyle.None, "", ListLevelAlignment.Left, 0, 0, 0, 2, ListTrailingCharacter.Nothing);
		xb9afeab740e736fe(list, 2, NumberStyle.None, "", ListLevelAlignment.Left, 0, 0, 0, 3, ListTrailingCharacter.Nothing);
		xb9afeab740e736fe(list, 3, NumberStyle.None, "", ListLevelAlignment.Left, 0, 0, 0, 4, ListTrailingCharacter.Nothing);
		xb9afeab740e736fe(list, 4, NumberStyle.None, "", ListLevelAlignment.Left, 0, 0, 0, 5, ListTrailingCharacter.Nothing);
		xb9afeab740e736fe(list, 5, NumberStyle.None, "", ListLevelAlignment.Left, 0, 0, 0, 6, ListTrailingCharacter.Nothing);
		xb9afeab740e736fe(list, 6, NumberStyle.None, "", ListLevelAlignment.Left, 0, 0, 0, 7, ListTrailingCharacter.Nothing);
		xb9afeab740e736fe(list, 7, NumberStyle.None, "", ListLevelAlignment.Left, 0, 0, 0, 8, ListTrailingCharacter.Nothing);
		xb9afeab740e736fe(list, 8, NumberStyle.None, "", ListLevelAlignment.Left, 0, 0, 0, 9, ListTrailingCharacter.Nothing);
		return list;
	}

	private static void xa3841eca93630cb2(List x8a0b266419f09a55, int xb53acfe332ad6e91, string x9e9070c6c983bbc0, string x3fa3314c5f8a4689, int x0fc6ad48eb0d9433, int x66ecc62b6f177063, int x11b1c592f6041b8e)
	{
		ListLevel listLevel = x8a0b266419f09a55.ListLevels[xb53acfe332ad6e91];
		listLevel.StartAt = 1;
		listLevel.NumberStyle = NumberStyle.Bullet;
		listLevel.NumberFormat = x3fa3314c5f8a4689;
		listLevel.Alignment = ListLevelAlignment.Left;
		listLevel.TrailingCharacter = ListTrailingCharacter.Tab;
		listLevel.x42bf8be828fc1b33 = -x11b1c592f6041b8e;
		listLevel.x969abf858b3fe7e8 = true;
		listLevel.x4a1340b0df048976 = 4095;
		listLevel.RestartAfterLevel = xb53acfe332ad6e91 - 1;
		listLevel.x1a78664fa10a3755.xc0741c7ff92cf1aa = x66ecc62b6f177063;
		listLevel.x1a78664fa10a3755.xc7d7e186f0ace1e0 = x11b1c592f6041b8e;
		TabStopCollection tabStopCollection = new TabStopCollection();
		tabStopCollection.HasTolerances = true;
		listLevel.x1a78664fa10a3755.x8df6f6ca274123b0 = tabStopCollection;
		TabStop tabStop = new TabStop(x0fc6ad48eb0d9433, TabAlignment.List, TabLeader.None);
		tabStopCollection.Add(tabStop);
		listLevel.xeedad81aaed42a76.x51cf23ce6e71b84c = x9e9070c6c983bbc0;
		listLevel.xeedad81aaed42a76.xd08cbc518cf39317 = x9e9070c6c983bbc0;
	}

	private static void xb9afeab740e736fe(List x8a0b266419f09a55, int xb53acfe332ad6e91, NumberStyle x3f5f7cef69e188c0, string x2eebe5b22e29f252, ListLevelAlignment x4ec4022180cbf8f4, int x0fc6ad48eb0d9433, int x66ecc62b6f177063, int x11b1c592f6041b8e)
	{
		xb9afeab740e736fe(x8a0b266419f09a55, xb53acfe332ad6e91, x3f5f7cef69e188c0, x2eebe5b22e29f252, x4ec4022180cbf8f4, x0fc6ad48eb0d9433, x66ecc62b6f177063, x11b1c592f6041b8e, 4095, ListTrailingCharacter.Tab);
	}

	private static void xb9afeab740e736fe(List x8a0b266419f09a55, int xb53acfe332ad6e91, NumberStyle x3f5f7cef69e188c0, string x2eebe5b22e29f252, ListLevelAlignment x4ec4022180cbf8f4, int x0fc6ad48eb0d9433, int x66ecc62b6f177063, int x11b1c592f6041b8e, int x3a325eef850ab096, ListTrailingCharacter xe07a0f5d2b7645df)
	{
		ListLevel listLevel = x8a0b266419f09a55.ListLevels[xb53acfe332ad6e91];
		listLevel.StartAt = 1;
		listLevel.NumberStyle = x3f5f7cef69e188c0;
		listLevel.NumberFormat = x2eebe5b22e29f252;
		listLevel.Alignment = x4ec4022180cbf8f4;
		listLevel.TrailingCharacter = xe07a0f5d2b7645df;
		listLevel.x42bf8be828fc1b33 = -x11b1c592f6041b8e;
		listLevel.x969abf858b3fe7e8 = true;
		listLevel.x4a1340b0df048976 = x3a325eef850ab096;
		listLevel.RestartAfterLevel = xb53acfe332ad6e91 - 1;
		listLevel.x1a78664fa10a3755.xc0741c7ff92cf1aa = x66ecc62b6f177063;
		listLevel.x1a78664fa10a3755.xc7d7e186f0ace1e0 = x11b1c592f6041b8e;
		TabStopCollection tabStopCollection = new TabStopCollection();
		tabStopCollection.HasTolerances = true;
		listLevel.x1a78664fa10a3755.x8df6f6ca274123b0 = tabStopCollection;
		if (xe07a0f5d2b7645df == ListTrailingCharacter.Tab)
		{
			TabStop tabStop = new TabStop(x0fc6ad48eb0d9433, TabAlignment.List, TabLeader.None);
			tabStopCollection.Add(tabStop);
		}
	}
}
