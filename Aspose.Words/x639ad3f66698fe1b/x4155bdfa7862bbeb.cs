using System;
using Aspose.Words;
using x13f1efc79617a47b;
using x2845e7a1a7dc898b;
using x28925c9b27b37a46;
using x556d8f9846e43329;
using x5794c252ba25e723;
using xf989f31a236ff98c;

namespace x639ad3f66698fe1b;

internal class x4155bdfa7862bbeb
{
	private x9cb1edcd9725c81e x700b37a2d2434021;

	private bool xedd40d89418a6cac;

	private readonly x21f0d20d41203be1 x8cedcaa9a62c6e39;

	private readonly xbfd162a6d47f59a4 x800085dd555f7711;

	private readonly x2b0abd51168769c2 xafb8b5a255a53538;

	private readonly x148fd2848896e29d x7c2c00a4950be66f;

	internal x4155bdfa7862bbeb(x21f0d20d41203be1 context)
	{
		x8cedcaa9a62c6e39 = context;
		x800085dd555f7711 = context.xe1410f585439c7d4;
		xafb8b5a255a53538 = new x2b0abd51168769c2(context);
		x7c2c00a4950be66f = new x148fd2848896e29d(context);
	}

	internal void xbe6eb989f9cb1a2c(xeedad81aaed42a76 x789564759d365819)
	{
		if (x789564759d365819.x0f53f53f15b61ef5)
		{
			xeedad81aaed42a76 xeedad81aaed42a = (xeedad81aaed42a76)x789564759d365819.x8b61531c8ea35b85();
			xeedad81aaed42a.xcb395027497bc067();
			x6210059f049f0d48(xeedad81aaed42a, x00ce61b8358bb4cc: true);
			xeedad81aaed42a76 xeedad81aaed42a2 = (xeedad81aaed42a76)x789564759d365819.x8b61531c8ea35b85();
			object obj = xeedad81aaed42a2.xf7866f89640a29a3(14);
			object obj2 = xeedad81aaed42a2.xf7866f89640a29a3(12);
			object obj3 = xeedad81aaed42a2.xf7866f89640a29a3(40);
			object obj4 = xeedad81aaed42a2.xf7866f89640a29a3(30);
			xeedad81aaed42a2.x968eca275aff04e3(xeedad81aaed42a);
			if (obj != null)
			{
				xeedad81aaed42a2.xae20093bed1e48a8(14, obj);
			}
			if (obj2 != null)
			{
				xeedad81aaed42a2.xae20093bed1e48a8(12, obj2);
			}
			if (obj3 != null)
			{
				xeedad81aaed42a2.xae20093bed1e48a8(40, obj3);
			}
			if (obj4 != null)
			{
				xeedad81aaed42a2.xae20093bed1e48a8(30, obj4);
			}
			xac55650dda4d602e(xeedad81aaed42a2);
		}
		else
		{
			x6210059f049f0d48(x789564759d365819, x00ce61b8358bb4cc: true);
		}
	}

	internal void x6210059f049f0d48(xeedad81aaed42a76 x789564759d365819, bool x00ce61b8358bb4cc)
	{
		x700b37a2d2434021 = new x9cb1edcd9725c81e(x789564759d365819);
		xedd40d89418a6cac = x00ce61b8358bb4cc;
		if (x8cedcaa9a62c6e39.xf57de0fd37d5e97d.ExportCompactSize)
		{
			xafb8b5a255a53538.x6210059f049f0d48(x700b37a2d2434021, x6d06576acbe8f10a: true);
			x7c2c00a4950be66f.x74f5a1ef3906e23c();
		}
		else
		{
			xafb8b5a255a53538.x6210059f049f0d48(x700b37a2d2434021, x6d06576acbe8f10a: false);
			x7c2c00a4950be66f.x6210059f049f0d48(x700b37a2d2434021);
		}
		xce5a1df8430a74d8(x7c2c00a4950be66f.x7a10833b0359b21e);
		x8e884e5f726d1627();
	}

	internal static void x1bc2bcdcd4e18aad(x21f0d20d41203be1 x0f7b23d1c393aed9, bool x30187f754ccc677c, string x9e9070c6c983bbc0)
	{
		if (x9e9070c6c983bbc0 != null)
		{
			x0f7b23d1c393aed9.xe1410f585439c7d4.x4d14ee33f46b5913(x30187f754ccc677c ? "\\af" : "\\f", x0f7b23d1c393aed9.xc4e3012717edc490(x9e9070c6c983bbc0));
		}
	}

	private void xce5a1df8430a74d8(x000f21cbda739311 x6f02b6a80bf6b36f)
	{
		x1bc2bcdcd4e18aad(x8cedcaa9a62c6e39, x30187f754ccc677c: false, x700b37a2d2434021.xaf95fb496eb25433(x6f02b6a80bf6b36f));
	}

	private void xac55650dda4d602e(xeedad81aaed42a76 x789564759d365819)
	{
		x5fb16e270c21db2e x5fb16e270c21db2e = x789564759d365819.x5fb16e270c21db2e;
		x800085dd555f7711.x4d14ee33f46b5913("\\crauth", x8cedcaa9a62c6e39.x2086e697b5620586.xd6b6ed77479ef68c(x5fb16e270c21db2e.xb063bbfcfeade526));
		x800085dd555f7711.x4d14ee33f46b5913("\\crdate", xa0d3611565b2a1f2.x7c734cfcbb14646a(x5fb16e270c21db2e.x242851e6278ed355));
		x800085dd555f7711.x25d0efbd7848eeb3();
		x800085dd555f7711.xee60bff2900a72f2("\\*\\oldcprops");
		x6210059f049f0d48(x789564759d365819, x00ce61b8358bb4cc: true);
		x800085dd555f7711.xc8a13a52db0580ae();
	}

	private void x8e884e5f726d1627()
	{
		foreach (xfd5f3842a71dd76e item in x700b37a2d2434021.xdd2c7b955dcd3f70)
		{
			object xd2f68ee6f47e9dfb = item.xd2f68ee6f47e9dfb;
			switch (item.xb66f90d7e750b49e)
			{
			case 310:
				x800085dd555f7711.x4d14ee33f46b5913("\\animtext", Convert.ToInt32(xd2f68ee6f47e9dfb));
				break;
			case 120:
				x800085dd555f7711.xaf432784cda9acfa("\\caps", ((x9b28b1f7f0cc963f)xd2f68ee6f47e9dfb).x4e98cd0cf854343f());
				break;
			case 290:
				x800085dd555f7711.x4d14ee33f46b5913("\\charscalex", (int)xd2f68ee6f47e9dfb);
				break;
			case 200:
			{
				int num3 = (int)xd2f68ee6f47e9dfb;
				if (num3 > 0)
				{
					x800085dd555f7711.x4d14ee33f46b5913("\\up", num3);
				}
				else if (num3 < 0)
				{
					x800085dd555f7711.x4d14ee33f46b5913("\\dn", -num3);
				}
				break;
			}
			case 170:
				x800085dd555f7711.xaf432784cda9acfa("\\embo", ((x9b28b1f7f0cc963f)xd2f68ee6f47e9dfb).x4e98cd0cf854343f());
				break;
			case 150:
			{
				int xbcea506a33cf = (int)xd2f68ee6f47e9dfb;
				x800085dd555f7711.x4d14ee33f46b5913("\\expnd", (int)xa0d3611565b2a1f2.x401ef6809c021333(xbcea506a33cf));
				x800085dd555f7711.x4d14ee33f46b5913("\\expndtw", xbcea506a33cf);
				break;
			}
			case 180:
				x800085dd555f7711.xaf432784cda9acfa("\\impr", ((x9b28b1f7f0cc963f)xd2f68ee6f47e9dfb).x4e98cd0cf854343f());
				break;
			case 440:
				x800085dd555f7711.xb8aea59edd4060ce("\\noproof", ((x9b28b1f7f0cc963f)xd2f68ee6f47e9dfb).x4e98cd0cf854343f());
				break;
			case 90:
				x800085dd555f7711.xaf432784cda9acfa("\\outl", ((x9b28b1f7f0cc963f)xd2f68ee6f47e9dfb).x4e98cd0cf854343f());
				break;
			case 110:
				x800085dd555f7711.xaf432784cda9acfa("\\scaps", ((x9b28b1f7f0cc963f)xd2f68ee6f47e9dfb).x4e98cd0cf854343f());
				break;
			case 100:
				x800085dd555f7711.xaf432784cda9acfa("\\shad", ((x9b28b1f7f0cc963f)xd2f68ee6f47e9dfb).x4e98cd0cf854343f());
				break;
			case 210:
				x9c09d678e6890054((x7af53bbecc5ccdd5)xd2f68ee6f47e9dfb);
				break;
			case 130:
				x800085dd555f7711.xaf432784cda9acfa("\\v", ((x9b28b1f7f0cc963f)xd2f68ee6f47e9dfb).x4e98cd0cf854343f());
				break;
			case 132:
				x800085dd555f7711.xb8aea59edd4060ce("\\webhidden", ((x9b28b1f7f0cc963f)xd2f68ee6f47e9dfb).x4e98cd0cf854343f());
				break;
			case 50:
				if (xedd40d89418a6cac)
				{
					x800085dd555f7711.x4d14ee33f46b5913("\\cs", (int)xd2f68ee6f47e9dfb);
				}
				break;
			case 160:
				x800085dd555f7711.x4d14ee33f46b5913("\\cf", x8cedcaa9a62c6e39.xc15cf5804dbd5bbe((x26d9ecb4bdf0456d)xd2f68ee6f47e9dfb));
				break;
			case 40:
			{
				int num2 = (int)xd2f68ee6f47e9dfb;
				x8cedcaa9a62c6e39.x05d5755b32029482.xd6b6ed77479ef68c(num2);
				x800085dd555f7711.x4d14ee33f46b5913("\\insrsid", num2);
				break;
			}
			case 30:
			{
				int num = (int)xd2f68ee6f47e9dfb;
				x8cedcaa9a62c6e39.x05d5755b32029482.xd6b6ed77479ef68c(num);
				x800085dd555f7711.x4d14ee33f46b5913("\\charrsid", num);
				break;
			}
			case 20:
			{
				x26d9ecb4bdf0456d x6c50a99faab7d = x195cb055715b526e.x5ab07bb8554e00d9(x195cb055715b526e.xc3bcf5a9ad941428((x26d9ecb4bdf0456d)xd2f68ee6f47e9dfb));
				x800085dd555f7711.x4d14ee33f46b5913("\\highlight", x8cedcaa9a62c6e39.xc15cf5804dbd5bbe(x6c50a99faab7d));
				break;
			}
			case 450:
				x800085dd555f7711.x4d14ee33f46b5913("\\ulc", x8cedcaa9a62c6e39.xc15cf5804dbd5bbe((x26d9ecb4bdf0456d)xd2f68ee6f47e9dfb));
				break;
			case 80:
				x800085dd555f7711.xaf432784cda9acfa("\\strike", ((x9b28b1f7f0cc963f)xd2f68ee6f47e9dfb).x4e98cd0cf854343f());
				break;
			case 300:
				x800085dd555f7711.x5fdd0595d40cfe6d("\\striked", ((x9b28b1f7f0cc963f)xd2f68ee6f47e9dfb).x4e98cd0cf854343f());
				break;
			case 220:
				x800085dd555f7711.x4d14ee33f46b5913("\\kerning", (int)xd2f68ee6f47e9dfb);
				break;
			case 140:
				x800085dd555f7711.x4d14ee33f46b5913(x394368855a08b8ce.x8f47b77a97eefb62((Underline)xd2f68ee6f47e9dfb));
				break;
			case 45:
				x800085dd555f7711.x4d14ee33f46b5913("\\lbr", Convert.ToInt32(xd2f68ee6f47e9dfb), 0);
				break;
			case 360:
				x800085dd555f7711.x4d14ee33f46b5913("\\chbrdr");
				x4bf0725a1c29dbf0.x6210059f049f0d48(x8cedcaa9a62c6e39, (Border)xd2f68ee6f47e9dfb);
				break;
			case 370:
			{
				Shading shading = (Shading)xd2f68ee6f47e9dfb;
				xf2c041437cd4ab14.x6210059f049f0d48(x8cedcaa9a62c6e39, shading, "\\chshdng", "\\chcbpat", "\\chcfpat", x394368855a08b8ce.xac5a7a97f8b14aea(shading.Texture));
				break;
			}
			case 14:
				xecb2d7893396dd84((xc1b2bac943a0f541)xd2f68ee6f47e9dfb);
				break;
			case 12:
				xecb2d7893396dd84((xc1b2bac943a0f541)xd2f68ee6f47e9dfb);
				break;
			case 770:
				x800085dd555f7711.x4d14ee33f46b5913(x394368855a08b8ce.x4aee1264f35da812((x4a2f68a519ee2183)xd2f68ee6f47e9dfb));
				break;
			case 780:
				x800085dd555f7711.x4d14ee33f46b5913(x394368855a08b8ce.x84544ae95693fd62((xf80d6ac0b6a56f39)xd2f68ee6f47e9dfb));
				break;
			default:
				throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("jhfbpimbdidcdjkciibdkhidfhpddigebhnengefgclfegcgehjgbhahmghhagohgffiggmicgdjafkjiabkoeikffpkppflbenlheemjdlmcecnfejnldaoodhomcoogdfpgcmpccdajoja", 1093801252)));
			}
		}
	}

	private void x9c09d678e6890054(x7af53bbecc5ccdd5 xbcea506a33cf9111)
	{
		switch (xbcea506a33cf9111)
		{
		case x7af53bbecc5ccdd5.x1b1f4712a1a0c38c:
			x800085dd555f7711.x4d14ee33f46b5913("\\sub");
			break;
		case x7af53bbecc5ccdd5.xab66d68facbadf18:
			x800085dd555f7711.x4d14ee33f46b5913("\\super");
			break;
		case x7af53bbecc5ccdd5.x139412b8dea2f02b:
			break;
		}
	}

	private void xecb2d7893396dd84(xc1b2bac943a0f541 xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 != null)
		{
			switch (xbcea506a33cf9111.x3146d638ec378671)
			{
			case x91bb72ac77aa7230.xf059562f878b500e:
				x800085dd555f7711.x4d14ee33f46b5913("\\revised");
				x800085dd555f7711.x4d14ee33f46b5913("\\revauth", x8cedcaa9a62c6e39.x2086e697b5620586.xd6b6ed77479ef68c(xbcea506a33cf9111.xb063bbfcfeade526));
				x800085dd555f7711.x4d14ee33f46b5913("\\revdttm", xa0d3611565b2a1f2.x7c734cfcbb14646a(xbcea506a33cf9111.x242851e6278ed355));
				break;
			case x91bb72ac77aa7230.x1f522a512716a2ae:
				x800085dd555f7711.x4d14ee33f46b5913("\\deleted");
				x800085dd555f7711.x4d14ee33f46b5913("\\revauthdel", x8cedcaa9a62c6e39.x2086e697b5620586.xd6b6ed77479ef68c(xbcea506a33cf9111.xb063bbfcfeade526));
				x800085dd555f7711.x4d14ee33f46b5913("\\revdttmdel", xa0d3611565b2a1f2.x7c734cfcbb14646a(xbcea506a33cf9111.x242851e6278ed355));
				break;
			}
		}
	}
}
