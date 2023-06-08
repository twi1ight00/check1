using System;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Lists;
using x13f1efc79617a47b;
using x1495530f35d79681;
using x7c7a1dceb600404e;
using x909757d9fd2dd6ae;
using xd2754ae26d400653;
using xda075892eccab2ad;

namespace x79490184cecf12a1;

internal class xaf984aed49d14880
{
	private xaf984aed49d14880()
	{
	}

	internal static void x06b0e25aa6ad68a9(x11e1346c12ead315 xe134235b3526fa75)
	{
		x3c85359e1389ad43 x3c85359e1389ad = xe134235b3526fa75.x1b1aeab2a2e668c4("http://schemas.openxmlformats.org/officeDocument/2006/relationships/numbering");
		if (x3c85359e1389ad == null)
		{
			return;
		}
		while (x3c85359e1389ad.x152cbadbfa8061b1("numbering"))
		{
			switch (x3c85359e1389ad.xa66385d80d4d296f)
			{
			case "numPicBullet":
				x249515365b82ec39(xe134235b3526fa75);
				break;
			case "abstractNum":
				x6fec498aef211b7d(xe134235b3526fa75);
				break;
			case "num":
				x4de40c5cc460d893(xe134235b3526fa75);
				break;
			default:
				x3c85359e1389ad.IgnoreElement();
				break;
			}
		}
		xe134235b3526fa75.xc8ab4e294c74831b();
	}

	private static void x249515365b82ec39(x11e1346c12ead315 xe134235b3526fa75)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		int num = x3bcd232d01c.xe8602379c60acf13("numPicBulletId", 0);
		if (num != xe134235b3526fa75.x2c8c6741422a1298.Lists.xe10f375b4290d48f)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("lncabpjaioabgphbepoboofconmcgjddfnkdfobejniegnpemmgfinnfbieghmlgplchlmjhfhaibmhiemoiamfjjgmjfldkjkkkagblalilpjplikgmjknmgjenmjlnoiconijofeapdihpbjopbifajdmaeidbcikbeibcncicdipcmggdihndbceebhleahcfigjffgagbghgbgogagfhoemhkedibbki", 1178141323)));
		}
		while (x3bcd232d01c.x152cbadbfa8061b1("numPicBullet"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x3bcd232d01c.xa66385d80d4d296f) != null && xa66385d80d4d296f == "pict")
			{
				Shape x5770cdefd8931aa = (Shape)xcb00358ab5144003.x06b0e25aa6ad68a9(xe134235b3526fa75);
				xe134235b3526fa75.x2c8c6741422a1298.Lists.x2c0e9f8fa1946281(x5770cdefd8931aa);
			}
			else
			{
				x3bcd232d01c.IgnoreElement();
			}
		}
	}

	private static void x6fec498aef211b7d(x11e1346c12ead315 xe134235b3526fa75)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		DocumentBase x2c8c6741422a = xe134235b3526fa75.x2c8c6741422a1298;
		int num = 0;
		bool flag = false;
		int listDefId = 0;
		x902c8ac86fbaf048 listType = x902c8ac86fbaf048.x598f41525926b38a;
		int templateCode = 0;
		string x759aa16c2016a = null;
		string text = null;
		x178ff6dcbf808c38 x178ff6dcbf808c = null;
		while (x3bcd232d01c.x1ac1960adc8c4c39())
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x3bcd232d01c.xa66385d80d4d296f) != null && xa66385d80d4d296f == "abstractNumId")
			{
				num = x3bcd232d01c.x38637a30d8932f79;
			}
		}
		while (x3bcd232d01c.x152cbadbfa8061b1("abstractNum"))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "nsid":
				flag = true;
				listDefId = xc1b08afa36bf580c.xce5e5e71983ae08f(x3bcd232d01c.xbbfc54380705e01e());
				break;
			case "multiLevelType":
				listType = x4a909034643add70.xa7195da66e758014(x3bcd232d01c.xbbfc54380705e01e());
				break;
			case "tmpl":
				templateCode = xc1b08afa36bf580c.xce5e5e71983ae08f(x3bcd232d01c.xbbfc54380705e01e());
				break;
			case "name":
				x759aa16c2016a = x3bcd232d01c.xbbfc54380705e01e();
				break;
			case "styleLink":
				text = x3bcd232d01c.xbbfc54380705e01e();
				break;
			case "numStyleLink":
				text = x3bcd232d01c.xbbfc54380705e01e();
				break;
			case "lvl":
			{
				if (x178ff6dcbf808c == null)
				{
					x178ff6dcbf808c = new x178ff6dcbf808c38(x2c8c6741422a, listDefId, listType, templateCode);
					x178ff6dcbf808c.x759aa16c2016a289 = x759aa16c2016a;
				}
				int index = x3bcd232d01c.xe8602379c60acf13("ilvl", 0);
				x6be5fd852df3c504(x178ff6dcbf808c.x438a2a8db4b2d07b[index], xe134235b3526fa75);
				break;
			}
			}
		}
		if (x178ff6dcbf808c == null)
		{
			x178ff6dcbf808c = new x178ff6dcbf808c38(x2c8c6741422a, listDefId, listType, templateCode);
			x178ff6dcbf808c.x759aa16c2016a289 = x759aa16c2016a;
		}
		if (!flag)
		{
			x178ff6dcbf808c.xd0e9f66f8c4d99a4(num);
		}
		if (text != null)
		{
			x178ff6dcbf808c.xc657ea789af2c1f0 = xe134235b3526fa75.xc9b7340b035562c6(text, 12);
		}
		x2c8c6741422a.Lists.x3698cb58c2e87a72(x178ff6dcbf808c);
		xe134235b3526fa75.xd678422f2e2ad09e[num] = x178ff6dcbf808c;
	}

	private static void x6be5fd852df3c504(ListLevel x66bbd7ed8c65740d, x11e1346c12ead315 xe134235b3526fa75)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		bool x83b68d5fabfc1faa = false;
		while (x3bcd232d01c.x1ac1960adc8c4c39())
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "tplc":
				xc1b08afa36bf580c.xce5e5e71983ae08f(x3bcd232d01c.xd2f68ee6f47e9dfb);
				break;
			case "tentative":
				x83b68d5fabfc1faa = x3bcd232d01c.xc3be6b142c6aca84;
				break;
			}
		}
		x66bbd7ed8c65740d.x83b68d5fabfc1faa = x83b68d5fabfc1faa;
		x66bbd7ed8c65740d.StartAt = 0;
		while (x3bcd232d01c.x152cbadbfa8061b1("lvl"))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "start":
				x66bbd7ed8c65740d.xd62f9a1bfab2aceb(x3bcd232d01c.xb8ac33c25776194c());
				break;
			case "numFmt":
				x66bbd7ed8c65740d.NumberStyle = xc62574be95c1c918.x5dabea7b873aecb0(x3bcd232d01c.xbbfc54380705e01e());
				break;
			case "lvlRestart":
				x66bbd7ed8c65740d.xb90138cd78a1ba8e(x3bcd232d01c.xb8ac33c25776194c() - 1);
				break;
			case "pStyle":
				x66bbd7ed8c65740d.x4a1340b0df048976 = xe134235b3526fa75.xc9b7340b035562c6(x3bcd232d01c.xbbfc54380705e01e(), 4095);
				break;
			case "isLgl":
				x66bbd7ed8c65740d.IsLegal = x3bcd232d01c.xe04906126da94dd1();
				break;
			case "suff":
				x66bbd7ed8c65740d.TrailingCharacter = x4a909034643add70.xe7988d6d8f3f1ebb(x3bcd232d01c.xbbfc54380705e01e());
				break;
			case "lvlText":
				while (x3bcd232d01c.x1ac1960adc8c4c39())
				{
					switch (x3bcd232d01c.xa66385d80d4d296f)
					{
					case "val":
						x66bbd7ed8c65740d.xcf5f81ead54b5e79(x8c2aca2b99f2d0a5(x3bcd232d01c.xd2f68ee6f47e9dfb));
						break;
					case "null":
						if (x3bcd232d01c.xc3be6b142c6aca84)
						{
							x66bbd7ed8c65740d.xcf5f81ead54b5e79("");
						}
						break;
					}
				}
				break;
			case "lvlPicBulletId":
				x66bbd7ed8c65740d.x4d819daa8b29e86b = x3bcd232d01c.xb8ac33c25776194c();
				break;
			case "legacy":
				while (x3bcd232d01c.x1ac1960adc8c4c39())
				{
					switch (x3bcd232d01c.xa66385d80d4d296f)
					{
					case "legacy":
						x66bbd7ed8c65740d.xf9be1d0b8b44c7e8 = x3bcd232d01c.xc3be6b142c6aca84;
						break;
					case "legacySpace":
						x66bbd7ed8c65740d.x42bf8be828fc1b33 = x3bcd232d01c.xeeed7b3df57c138f;
						break;
					case "legacyIndent":
						x66bbd7ed8c65740d.x5cf63f659ff5ee9f = x3bcd232d01c.xeeed7b3df57c138f;
						break;
					}
				}
				break;
			case "lvlJc":
				x66bbd7ed8c65740d.Alignment = x4a909034643add70.x7fb9f8881a674951(x3bcd232d01c.xbbfc54380705e01e());
				break;
			case "pPr":
				xec45413ffc971f9d.x06b0e25aa6ad68a9(xe134235b3526fa75, x66bbd7ed8c65740d.x1a78664fa10a3755, x66bbd7ed8c65740d.xeedad81aaed42a76);
				break;
			case "rPr":
				x419d718f5b3e63d8.x06b0e25aa6ad68a9(xe134235b3526fa75, x66bbd7ed8c65740d.xeedad81aaed42a76);
				break;
			}
		}
	}

	private static void x4de40c5cc460d893(x11e1346c12ead315 xe134235b3526fa75)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		DocumentBase x2c8c6741422a = xe134235b3526fa75.x2c8c6741422a1298;
		int listId = x3bcd232d01c.xe8602379c60acf13("numId", 0);
		List list = new List(x2c8c6741422a, listId);
		while (x3bcd232d01c.x152cbadbfa8061b1("num"))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "abstractNumId":
			{
				x178ff6dcbf808c38 x178ff6dcbf808c = (x178ff6dcbf808c38)xe134235b3526fa75.xd678422f2e2ad09e[x3bcd232d01c.xb8ac33c25776194c()];
				if (x178ff6dcbf808c != null)
				{
					list.x1eac770549050632 = x178ff6dcbf808c.x1eac770549050632;
				}
				break;
			}
			case "lvlOverride":
			{
				int levelNumber = x3bcd232d01c.xe8602379c60acf13("ilvl", 0);
				x136abcf7d9c0eef3 x136abcf7d9c0eef = new x136abcf7d9c0eef3(x2c8c6741422a, levelNumber);
				x136abcf7d9c0eef.x33160172e2e7ff13 = false;
				x136abcf7d9c0eef.x178c863a9c967cd2 = false;
				while (x3bcd232d01c.x152cbadbfa8061b1("lvlOverride"))
				{
					switch (x3bcd232d01c.xa66385d80d4d296f)
					{
					case "startOverride":
						x136abcf7d9c0eef.x33160172e2e7ff13 = true;
						x136abcf7d9c0eef.x6da6130e001c6962 = x3bcd232d01c.xb8ac33c25776194c();
						break;
					case "lvl":
						x136abcf7d9c0eef.x178c863a9c967cd2 = true;
						x6be5fd852df3c504(x136abcf7d9c0eef.xf13a626e550cef8f, xe134235b3526fa75);
						break;
					}
				}
				list.x6047afa6812e47bc.Add(x136abcf7d9c0eef);
				break;
			}
			}
		}
		x2c8c6741422a.Lists.xa22e280934fc3004(list);
	}

	private static string x8c2aca2b99f2d0a5(string x2eebe5b22e29f252)
	{
		for (int i = 0; i < 10; i++)
		{
			x2eebe5b22e29f252 = x2eebe5b22e29f252.Replace("%" + (i + 1), ((char)i).ToString());
		}
		return x2eebe5b22e29f252;
	}
}
