using System.Collections;
using System.IO;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Markup;
using x011d489fb9df7027;
using x1ba3a5ce73d4b39d;
using x26869753cb97bfe9;
using x28925c9b27b37a46;
using x38a89dee67fc7a16;
using x681ccae5509c120d;
using x6c95d9cf46ff5f25;
using x884584cc69c5c378;
using x9db5f2e5af3d596e;
using xa604c4d210ae0581;
using xaa035fc640f94856;
using xf989f31a236ff98c;
using xfbd1009a0cbb9842;

namespace x16f9a31f749b8bb1;

internal class x32eac27632acc346
{
	internal const char x557f5b7d1230e50b = '(';

	private readonly x0f8a9a895bdf560e xe1d718cca131846e;

	private readonly xa37c212c70888855 xa6639b49652ac6c4 = new xa37c212c70888855();

	private readonly x9e131021ba70185c x7a1a247785b9a739;

	private readonly x78bb7217a6ff15fc xc6d8a87b1bbf8525;

	private int xfe2617311442ef45;

	private int xa8b090df56e11773;

	private readonly x20ac4a93b671ea32 xd8f0d473818e0a63 = new x20ac4a93b671ea32();

	private readonly x6c5673d41bea0846 x337e608d97cebdb3 = new x6c5673d41bea0846();

	private readonly x2975a5323e39c83f x31200685fa92af4c = new x2975a5323e39c83f();

	private readonly x0770e06813c0963a xd5245259e5a9cc1b = new x0770e06813c0963a();

	private readonly x1201af27097d5fa4 x230c494550d9042a = new x1201af27097d5fa4();

	private readonly x74651bc3cfabd1ac x553effa5cb6ae0ee = new x74651bc3cfabd1ac();

	private readonly x635e3650835b8cd7 x57b1ae264ef35f80 = new x635e3650835b8cd7();

	private readonly x635e3650835b8cd7 x10bb9cd9d877e07b = new x635e3650835b8cd7();

	private readonly xded6f604f2712af1 xbf718b9feb2252ff = new xded6f604f2712af1();

	private readonly Stack xa224ac5c01b9d133 = new Stack();

	internal static bool x492f529cee830a40;

	internal x32eac27632acc346(x0f8a9a895bdf560e docReader)
		: this(docReader, x9e131021ba70185c.xc447809891322395)
	{
	}

	private x32eac27632acc346(x0f8a9a895bdf560e docReader, x9e131021ba70185c subDocType)
	{
		xe1d718cca131846e = docReader;
		x7a1a247785b9a739 = subDocType;
		xc6d8a87b1bbf8525 = new x78bb7217a6ff15fc(xe1d718cca131846e.xffb32620593acdf2);
	}

	internal void x1f490eac106aee12()
	{
		xe1d718cca131846e.xffb32620593acdf2.xf3a409990d06c568();
		x5fae2ca6576b2900(x101cddc73c4f8cc2.xa1e2a8ed32a026dd);
		x5fae2ca6576b2900(x101cddc73c4f8cc2.xeab6532eb0797a6e);
		x5fae2ca6576b2900(x101cddc73c4f8cc2.x1e0d716fba95db43);
		x5fae2ca6576b2900(x101cddc73c4f8cc2.x0affbe34bb1f8b8b);
		x5fae2ca6576b2900(x101cddc73c4f8cc2.x354a2c7b596483f1);
		x5fae2ca6576b2900(x101cddc73c4f8cc2.x281934d7c2c96a88);
		xfc72d4c9b765cad7 xfc72d4c9b765cad = xe1d718cca131846e.x9ff07c03a240dd5d(0);
		if (xfc72d4c9b765cad == null)
		{
			x3dc950453374051a("Section properties is missed, used defaults.");
			xfc72d4c9b765cad = new xfc72d4c9b765cad7();
		}
		xe1d718cca131846e.xffb32620593acdf2.xe95664527db59e6e(xfc72d4c9b765cad);
		x709a32d98832a838();
		xe1d718cca131846e.xffb32620593acdf2.xbaeac8c4c56306fe();
		x1f490eac106aee12(0, xe1d718cca131846e.x8aeace2bf92692ab.x3ab228b2748114ba);
		xe1d718cca131846e.xffb32620593acdf2.xa5e2284bda2bc317();
		xe1d718cca131846e.xffb32620593acdf2.xfdbe40d109da78d3();
		xe1d718cca131846e.xffb32620593acdf2.x3c06113138282067(xe1d718cca131846e.x6cb2cfca19c7adb6);
	}

	private void x709a32d98832a838()
	{
		x7319f5f5433dca3a(HeaderFooterType.HeaderEven);
		x7319f5f5433dca3a(HeaderFooterType.HeaderPrimary);
		x7319f5f5433dca3a(HeaderFooterType.FooterEven);
		x7319f5f5433dca3a(HeaderFooterType.FooterPrimary);
		x7319f5f5433dca3a(HeaderFooterType.HeaderFirst);
		x7319f5f5433dca3a(HeaderFooterType.FooterFirst);
	}

	private void x7319f5f5433dca3a(HeaderFooterType xa685fef1a31f5d4d)
	{
		xa6101120b8ed585e xa6101120b8ed585e = xe1d718cca131846e.x846eeecacc00f82b.x2eca87a66df00843(xfe2617311442ef45, xa685fef1a31f5d4d);
		if (xa6101120b8ed585e != null && xa6101120b8ed585e.x1be93eed8950d961 > 0)
		{
			x32eac27632acc346 x32eac27632acc347 = new x32eac27632acc346(xe1d718cca131846e, x9e131021ba70185c.x1ea60bde2b5d0d28);
			xe1d718cca131846e.xffb32620593acdf2.xe7d4c5256fad03b7(xa685fef1a31f5d4d);
			x32eac27632acc347.x1f490eac106aee12(xa6101120b8ed585e.x12cb12b5d2cad53d, xa6101120b8ed585e.x1be93eed8950d961);
			xe1d718cca131846e.xffb32620593acdf2.xac2ccec47108f993();
		}
	}

	private void x5fae2ca6576b2900(x101cddc73c4f8cc2 x4456ba69b7615914)
	{
		xa6101120b8ed585e xa6101120b8ed585e = xe1d718cca131846e.x846eeecacc00f82b.xe219bb8e6176962b(x4456ba69b7615914);
		if (xa6101120b8ed585e != null && xa6101120b8ed585e.x1be93eed8950d961 > 0)
		{
			x32eac27632acc346 x32eac27632acc347 = new x32eac27632acc346(xe1d718cca131846e, x9e131021ba70185c.x1ea60bde2b5d0d28);
			xe1d718cca131846e.xffb32620593acdf2.x18f818c15e0066f1(x4456ba69b7615914);
			x32eac27632acc347.x1f490eac106aee12(xa6101120b8ed585e.x12cb12b5d2cad53d, xa6101120b8ed585e.x1be93eed8950d961);
			xe1d718cca131846e.xffb32620593acdf2.x4365e55d32fd2636();
		}
	}

	private void x1f490eac106aee12(int x828697433249d659, int x961016a387451f05)
	{
		int num = xe1d718cca131846e.x8aeace2bf92692ab.x5172d05e08678764(x7a1a247785b9a739, x828697433249d659);
		x2fd8193539890aee(num);
		int num2 = xe1d718cca131846e.x8f4cc590b89c730d.x6e603e71a5cebe44(num);
		if (num2 == -1)
		{
			xbbf9a1ead81dd3a1(WarningType.DataLoss, "Cannot find a piece for the position, continue.");
			return;
		}
		int num3 = num - xe1d718cca131846e.x8f4cc590b89c730d.get_xe6d4b1b411ed94b5(num2).x76bcde38a5a4c721.x12cb12b5d2cad53d;
		int num4 = x961016a387451f05;
		while (num4 > 0 && num2 < xe1d718cca131846e.x8f4cc590b89c730d.xd44988f225497f3a)
		{
			xc77edd00162b84f4 xc77edd00162b84f = xe1d718cca131846e.x8f4cc590b89c730d.get_xe6d4b1b411ed94b5(num2);
			int num5 = xc77edd00162b84f.x90e1673346897dcf;
			int num6 = xc77edd00162b84f.x76bcde38a5a4c721.x1be93eed8950d961;
			if (num3 > 0)
			{
				num5 += num3 * ((!xc77edd00162b84f.x75b732ba9b2cd574) ? 1 : 2);
				num6 -= num3;
			}
			xe1d718cca131846e.x0f8a9a895bdf560e.BaseStream.Position = num5;
			num6 = ((num6 > num4) ? num4 : num6);
			BinaryReader binaryReader = (xc77edd00162b84f.x75b732ba9b2cd574 ? xe1d718cca131846e.x0f8a9a895bdf560e : xe1d718cca131846e.x5a4620c6b9a3bb66);
			char[] chars = binaryReader.ReadChars(num6);
			x98d75821045fe9bd xbb8131fb9e06f47f = new x98d75821045fe9bd(chars, new xa7539800dadf4e5b(xc77edd00162b84f, num3), num5);
			xbac2e778f3c6bad1(xbb8131fb9e06f47f);
			num4 -= num6;
			num2++;
			num3 = 0;
		}
		if (xa6639b49652ac6c4.Count > 0)
		{
			xb61b92627231b7a8(x708efeab5b620f36: new xb3ad27290106eaf4(new x1a78664fa10a3755(), new x6ace28180a74825a(), new xedb0eb766e25e0c9()), xbb8131fb9e06f47f: xa6639b49652ac6c4.get_xe6d4b1b411ed94b5(0), x459133b45d02f55a: 0);
		}
	}

	private void x2fd8193539890aee(int x9a7ea741c88e62b4)
	{
		x2b702525301ee74a x2b702525301ee74a = xe1d718cca131846e.x2b702525301ee74a;
		xd8f0d473818e0a63.xd586e0c16bdae7fc(xe1d718cca131846e, x2b702525301ee74a.x1213e861660862e7, x9a7ea741c88e62b4);
		x337e608d97cebdb3.xd586e0c16bdae7fc(xe1d718cca131846e, x2b702525301ee74a.x8a4e50b3272d2d52, x9a7ea741c88e62b4);
		x31a5ab258b5c21f3 x31a5ab258b5c21f = xe1d718cca131846e.x31a5ab258b5c21f3;
		x31200685fa92af4c.xd586e0c16bdae7fc(xe1d718cca131846e, x31a5ab258b5c21f.x1213e861660862e7, x9a7ea741c88e62b4);
		xd5245259e5a9cc1b.xd586e0c16bdae7fc(xe1d718cca131846e, x31a5ab258b5c21f.x8a4e50b3272d2d52, x9a7ea741c88e62b4);
		xe91a1cdf262fe886 xe91a1cdf262fe = xe1d718cca131846e.xe91a1cdf262fe886;
		x230c494550d9042a.xd586e0c16bdae7fc(xe1d718cca131846e, xe91a1cdf262fe.x1213e861660862e7, x9a7ea741c88e62b4);
		x553effa5cb6ae0ee.xd586e0c16bdae7fc(xe1d718cca131846e, xe91a1cdf262fe.x8a4e50b3272d2d52, x9a7ea741c88e62b4);
		xd452a5f78fa06e8b x766da124ec0eb8b = xe1d718cca131846e.x766da124ec0eb8b2;
		xd452a5f78fa06e8b xf926db502adbb = xe1d718cca131846e.xf926db502adbb667;
		x57b1ae264ef35f80.xd586e0c16bdae7fc(xe1d718cca131846e, x766da124ec0eb8b.xdf0c8cea9b2d73a3, x9a7ea741c88e62b4);
		x10bb9cd9d877e07b.xd586e0c16bdae7fc(xe1d718cca131846e, xf926db502adbb.xdf0c8cea9b2d73a3, x9a7ea741c88e62b4);
		xbf718b9feb2252ff.xd586e0c16bdae7fc(xe1d718cca131846e, xe1d718cca131846e.xd078c45cd488fe12.x6fa6e31d93cf837a, x9a7ea741c88e62b4);
	}

	private void xbac2e778f3c6bad1(x98d75821045fe9bd xbb8131fb9e06f47f)
	{
		int num = 0;
		for (int i = 0; i < xbb8131fb9e06f47f.xf73ef160527516c8.Length; i++)
		{
			char c = xbb8131fb9e06f47f.xf73ef160527516c8[i];
			if (c == '\r' && xe1d718cca131846e.x9ff07c03a240dd5d(xbb8131fb9e06f47f.xaa55b781867db091(i + 1)) != null)
			{
				c = '\f';
			}
			switch (c)
			{
			case '\f':
			{
				if (x7a1a247785b9a739 == x9e131021ba70185c.x69d28a4aeef83a6f || x7a1a247785b9a739 == x9e131021ba70185c.xd90ac7fcbe961761)
				{
					x3dc950453374051a("Section breaks are not allowed inside footnotes/endnotes by Aspose.Words.");
					break;
				}
				xfc72d4c9b765cad7 xfc72d4c9b765cad = xe1d718cca131846e.x9ff07c03a240dd5d(xbb8131fb9e06f47f.xaa55b781867db091(i + 1));
				if (xfc72d4c9b765cad == null)
				{
					break;
				}
				xb3ad27290106eaf4 x708efeab5b620f2 = x202d2c9935d7ab12(xbb8131fb9e06f47f, num, i);
				num = i + 1;
				if (x708efeab5b620f2.x12d5a57a1541e872.xb8414804f39a9e90 == 0)
				{
					xb61b92627231b7a8(xbb8131fb9e06f47f, i, x708efeab5b620f2);
					if (xc6d8a87b1bbf8525.xcb7eb66829544493 != 0)
					{
						x3dc950453374051a("Section breaks are not allowed inside tables by Aspose.Words.");
						break;
					}
					xe1d718cca131846e.xffb32620593acdf2.xa5e2284bda2bc317();
					xe1d718cca131846e.xffb32620593acdf2.xfdbe40d109da78d3();
					xfe2617311442ef45++;
					xe1d718cca131846e.xffb32620593acdf2.xe95664527db59e6e(xfc72d4c9b765cad);
					x709a32d98832a838();
					xe1d718cca131846e.xffb32620593acdf2.xbaeac8c4c56306fe();
				}
				break;
			}
			case '\a':
			case '\r':
				if (xdfc16e2f4120127c(xbb8131fb9e06f47f, i))
				{
					xb3ad27290106eaf4 x708efeab5b620f = x202d2c9935d7ab12(xbb8131fb9e06f47f, num, i);
					num = i + 1;
					xb61b92627231b7a8(xbb8131fb9e06f47f, i, x708efeab5b620f);
				}
				break;
			}
		}
		if (num < xbb8131fb9e06f47f.xf73ef160527516c8.Length)
		{
			xa6639b49652ac6c4.Add(new x98d75821045fe9bd(xbb8131fb9e06f47f, num, xbb8131fb9e06f47f.xf73ef160527516c8.Length));
		}
	}

	private bool xdfc16e2f4120127c(x98d75821045fe9bd xbb8131fb9e06f47f, int x459133b45d02f55a)
	{
		int x13d4cb8d1bd = xbb8131fb9e06f47f.x854ced39b93c1246(x459133b45d02f55a + 1);
		return xe1d718cca131846e.xf8b5e62cf3165594.x0ed62813cc2c183e(x13d4cb8d1bd) >= 0;
	}

	private xb3ad27290106eaf4 x202d2c9935d7ab12(x98d75821045fe9bd xbb8131fb9e06f47f, int xd8dbc186289870fa, int x459133b45d02f55a)
	{
		xa6639b49652ac6c4.Add(new x98d75821045fe9bd(xbb8131fb9e06f47f, xd8dbc186289870fa, x459133b45d02f55a + 1));
		return xe1d718cca131846e.x3b355689ee7596e9(xbb8131fb9e06f47f.x854ced39b93c1246(x459133b45d02f55a), xa6639b49652ac6c4.x4f0c985cdc1a8a55());
	}

	private void xb61b92627231b7a8(x98d75821045fe9bd xbb8131fb9e06f47f, int x459133b45d02f55a, xb3ad27290106eaf4 x708efeab5b620f36)
	{
		xc6d8a87b1bbf8525.xc3c9900b924c2d77(x708efeab5b620f36.x12d5a57a1541e872);
		if (x708efeab5b620f36.x12d5a57a1541e872.xd39cb952ead8cd7a)
		{
			int x2865e605e9fbfb = xbb8131fb9e06f47f.xaa55b781867db091(x459133b45d02f55a);
			xd8f0d473818e0a63.xbf11ac143fca6897(x2865e605e9fbfb);
			x337e608d97cebdb3.xbf11ac143fca6897(x2865e605e9fbfb);
		}
		else
		{
			xf59aaff7aa68ace1(x708efeab5b620f36.x1a78664fa10a3755);
		}
		xc6d8a87b1bbf8525.x3288e13b0258c322(x708efeab5b620f36.x12d5a57a1541e872, x708efeab5b620f36.xedb0eb766e25e0c9, xa6639b49652ac6c4.xed3e432f7c9bf846.x0defee75348dbb6e);
		xa6639b49652ac6c4.Clear();
	}

	private void xf59aaff7aa68ace1(x1a78664fa10a3755 x062aae8c9613eeaa)
	{
		xe1d718cca131846e.xffb32620593acdf2.x9df170cae7684fe6();
		bool flag = false;
		int num = xa6639b49652ac6c4.x2e39a445d52f6ea8();
		xeedad81aaed42a76 x789564759d = null;
		for (int i = 0; i < xa6639b49652ac6c4.Count; i++)
		{
			x98d75821045fe9bd x98d75821045fe9bd2 = xa6639b49652ac6c4.get_xe6d4b1b411ed94b5(i);
			int num2 = 0;
			while (num2 < x98d75821045fe9bd2.xf73ef160527516c8.Length)
			{
				_ = x98d75821045fe9bd2.xf73ef160527516c8[num2];
				int num3 = x98d75821045fe9bd2.x854ced39b93c1246(num2);
				xa52f2632c0ffdfaf xe08a26cc2b49f3aa;
				int num4 = xe1d718cca131846e.x0da3dbab8832b471(num3, x98d75821045fe9bd2.xa7539800dadf4e5b.xc77edd00162b84f4.x32939c68497cb083, out x789564759d, out xe08a26cc2b49f3aa);
				if (num4 == num3)
				{
					break;
				}
				int num5 = num4 - num3;
				if (num5 < ((!x98d75821045fe9bd2.x75b732ba9b2cd574) ? 1 : 2))
				{
					num5 = ((!x98d75821045fe9bd2.x75b732ba9b2cd574) ? 1 : 2);
					flag = true;
				}
				int num6 = num5 >> (x98d75821045fe9bd2.x75b732ba9b2cd574 ? 1 : 0);
				int num7 = x98d75821045fe9bd2.xf73ef160527516c8.Length - num2;
				num6 = ((num6 > num7) ? num7 : num6);
				bool x2ce649b040466d4d = num == num6;
				xdf2cafeb128b2de9(x789564759d, xe08a26cc2b49f3aa, x98d75821045fe9bd2, num2, num6, x2ce649b040466d4d);
				num2 += num6;
				num -= num6;
			}
		}
		if (flag)
		{
			x3dc950453374051a($"File is corrupted, data loss at FC: 0x{xa6639b49652ac6c4.get_xe6d4b1b411ed94b5(0).x854ced39b93c1246(0):x4}.");
		}
		xe1d718cca131846e.xffb32620593acdf2.xa1237507e66611c4(x062aae8c9613eeaa, x789564759d);
	}

	private void xdf2cafeb128b2de9(xeedad81aaed42a76 x789564759d365819, xa52f2632c0ffdfaf xe08a26cc2b49f3aa, x98d75821045fe9bd xbb8131fb9e06f47f, int xd4f974c06ffa392b, int x961016a387451f05, bool x2ce649b040466d4d)
	{
		if (!xe08a26cc2b49f3aa.xa1a25be53d0a44c8 && x961016a387451f05 == 1 && xbb8131fb9e06f47f.xf73ef160527516c8[xd4f974c06ffa392b] == '\u0015')
		{
			x3dc950453374051a($"Field char is invalid at FC: 0x{xbb8131fb9e06f47f.x854ced39b93c1246(xd4f974c06ffa392b):x4}.");
			xe08a26cc2b49f3aa.xa1a25be53d0a44c8 = true;
		}
		int num = xd4f974c06ffa392b;
		int i = xd4f974c06ffa392b;
		int num2 = xd4f974c06ffa392b + x961016a387451f05;
		bool flag = false;
		int num3 = xbb8131fb9e06f47f.xaa55b781867db091(i) - i;
		for (; i < num2; i++)
		{
			int num4 = i + num3;
			if (x57b1ae264ef35f80.xbe1e23e7d5b43370 == num4 || x10bb9cd9d877e07b.xbe1e23e7d5b43370 == num4)
			{
				flag = true;
			}
			if (!xe08a26cc2b49f3aa.xa1a25be53d0a44c8 && xd8f0d473818e0a63.xbe1e23e7d5b43370 != num4 && x337e608d97cebdb3.xbe1e23e7d5b43370 != num4 && x31200685fa92af4c.xbe1e23e7d5b43370 != num4 && xd5245259e5a9cc1b.xbe1e23e7d5b43370 != num4 && x230c494550d9042a.xbe1e23e7d5b43370 != num4 && x553effa5cb6ae0ee.xbe1e23e7d5b43370 != num4 && xbf718b9feb2252ff.xbe1e23e7d5b43370 != num4 && !flag)
			{
				continue;
			}
			xeedad81aaed42a76 x789564759d365820 = (xeedad81aaed42a76)x789564759d365819.x8b61531c8ea35b85();
			if (!xe08a26cc2b49f3aa.xa1a25be53d0a44c8 && i > num)
			{
				x81b156ace6c5ad7c(x789564759d365820, xbb8131fb9e06f47f, num, i - num);
				num = i;
			}
			xd8f0d473818e0a63.xbf11ac143fca6897(num4);
			if (x31200685fa92af4c.xbe1e23e7d5b43370 == x337e608d97cebdb3.xbe1e23e7d5b43370)
			{
				x337e608d97cebdb3.xbf11ac143fca6897(num4);
				x31200685fa92af4c.xbf11ac143fca6897(num4);
				xd5245259e5a9cc1b.xbf11ac143fca6897(num4);
			}
			else
			{
				x31200685fa92af4c.xbf11ac143fca6897(num4);
				xd5245259e5a9cc1b.xbf11ac143fca6897(num4);
				x337e608d97cebdb3.xbf11ac143fca6897(num4);
			}
			x230c494550d9042a.xbf11ac143fca6897(num4);
			x553effa5cb6ae0ee.xbf11ac143fca6897(num4);
			xbf718b9feb2252ff.xbf11ac143fca6897(num4);
			if (flag)
			{
				flag = false;
				if (x57b1ae264ef35f80.xbe1e23e7d5b43370 == num4)
				{
					x57b1ae264ef35f80.xbf11ac143fca6897(num4);
				}
				else
				{
					x10bb9cd9d877e07b.xbf11ac143fca6897(num4);
				}
				FootnoteType xd3526c7313d;
				x52ed50cf5d3a8cc6 x52ed50cf5d3a8cc = x2adeff278a565ab3(num4, out xd3526c7313d);
				if (x52ed50cf5d3a8cc != null && x69d502aaca08ee16(x52ed50cf5d3a8cc, xd3526c7313d, xbb8131fb9e06f47f, i, num2, xe08a26cc2b49f3aa, x789564759d365820))
				{
					num = num2;
				}
			}
			else if (xe08a26cc2b49f3aa.xa1a25be53d0a44c8)
			{
				x3fcc6938e0108016(xbb8131fb9e06f47f.xf73ef160527516c8[i], num4, x789564759d365820, xe08a26cc2b49f3aa);
				num = i + 1;
			}
		}
		if (x2ce649b040466d4d)
		{
			i--;
		}
		if (i > num)
		{
			x81b156ace6c5ad7c(x789564759d365819, xbb8131fb9e06f47f, num, i - num);
		}
	}

	private void x81b156ace6c5ad7c(xeedad81aaed42a76 x789564759d365819, x98d75821045fe9bd xbb8131fb9e06f47f, int xd4f974c06ffa392b, int x961016a387451f05)
	{
		if (x961016a387451f05 != 0)
		{
			string xb41faee6912a = new string(xbb8131fb9e06f47f.xf73ef160527516c8, xd4f974c06ffa392b, x961016a387451f05);
			x81b156ace6c5ad7c(xb41faee6912a, x789564759d365819);
		}
	}

	private void x81b156ace6c5ad7c(string xb41faee6912a2313, xeedad81aaed42a76 x789564759d365819)
	{
		xe1d718cca131846e.xffb32620593acdf2.x93a8c149d218a60f(xb41faee6912a2313, x789564759d365819);
	}

	private void x3fcc6938e0108016(char x12f11d52c2c4d003, int x2865e605e9fbfb80, xeedad81aaed42a76 x789564759d365819, xa52f2632c0ffdfaf xe08a26cc2b49f3aa)
	{
		int num = xe1d718cca131846e.x8aeace2bf92692ab.xe53581d2051aca20(x2865e605e9fbfb80);
		switch (x12f11d52c2c4d003)
		{
		case '\u0005':
			if (x7a1a247785b9a739 == x9e131021ba70185c.xc447809891322395)
			{
				x85b171006887a0b5(num, x789564759d365819);
			}
			else
			{
				xe1d718cca131846e.xffb32620593acdf2.x27442410230d2b1f(x12f11d52c2c4d003, x789564759d365819);
			}
			break;
		case '\u0001':
			if (xe08a26cc2b49f3aa.x1b36d8d878eccfb5)
			{
				xdb97c3f91e3ebdfb(x789564759d365819, xe08a26cc2b49f3aa.xf1d9b91c9700c401);
			}
			else if (xe08a26cc2b49f3aa.xc26441db92a14e8e)
			{
				x0d24986434a725c5(x789564759d365819, xe08a26cc2b49f3aa.xf1d9b91c9700c401);
			}
			else
			{
				xae86397ff5ef8e2c(x789564759d365819, xe08a26cc2b49f3aa.xf1d9b91c9700c401);
			}
			break;
		case '\b':
			xcba8faacb9b0c86d(num, x789564759d365819);
			break;
		case '\u0013':
		{
			xb96b10c688c10ef2 xb96b10c688c10ef2 = xe1d718cca131846e.x5c2107ebcbb7681b.xf1922831d211dc4f(x7a1a247785b9a739, num);
			if (xb96b10c688c10ef2 == null)
			{
				xb96b10c688c10ef2 = new xb96b10c688c10ef2(19, 0);
			}
			xe1d718cca131846e.xffb32620593acdf2.xcf72734b7092bebe(x789564759d365819, xb96b10c688c10ef2.x3146d638ec378671);
			break;
		}
		case '\u0014':
		{
			x71d39fdf56861cca xb7b1409b12ce2ee = null;
			if (xe08a26cc2b49f3aa.x9316383434e67238 && xe08a26cc2b49f3aa.xc26441db92a14e8e)
			{
				xb7b1409b12ce2ee = xe1d718cca131846e.x027f422ae4e5ea22(xe08a26cc2b49f3aa.xf1d9b91c9700c401);
			}
			xe1d718cca131846e.xffb32620593acdf2.x094e1db5f87bb62b(x789564759d365819, xb7b1409b12ce2ee);
			break;
		}
		case '\u0015':
		{
			bool x549b1a1bab8624ee = false;
			bool x0c07ecaa = false;
			xb96b10c688c10ef2 xb96b10c688c10ef = xe1d718cca131846e.x5c2107ebcbb7681b.xf1922831d211dc4f(x7a1a247785b9a739, num);
			if (xb96b10c688c10ef != null)
			{
				x549b1a1bab8624ee = xb96b10c688c10ef.x6e94079169d5a06e;
				x0c07ecaa = xb96b10c688c10ef.x991897f13cf6aadc;
			}
			xe1d718cca131846e.xffb32620593acdf2.x3bb349c77392b35c(x789564759d365819, x0c07ecaa, x549b1a1bab8624ee);
			break;
		}
		case '(':
			x789564759d365819.x51cf23ce6e71b84c = xe08a26cc2b49f3aa.x286bc11c91310715;
			x789564759d365819.xd08cbc518cf39317 = xe08a26cc2b49f3aa.x286bc11c91310715;
			x81b156ace6c5ad7c(xe08a26cc2b49f3aa.xe59d6d35c76d70aa.ToString(), x789564759d365819);
			break;
		case '<':
		{
			x847f8b50f8fc7450 x847f8b50f8fc = xe1d718cca131846e.x39a0e849afa5b554.xdde7b5f326d9a3e1(xa8b090df56e11773++);
			if (x847f8b50f8fc != null)
			{
				CustomXmlMarkup customXmlMarkup = new CustomXmlMarkup(xe1d718cca131846e.x2c8c6741422a1298, x847f8b50f8fc.x504f3d4040b356d7);
				customXmlMarkup.Element = x847f8b50f8fc.x2dcc7207ee287dbb;
				customXmlMarkup.Uri = x847f8b50f8fc.xb405a444ca77e2d4;
				customXmlMarkup.Placeholder = x847f8b50f8fc.xa3111ce09c95d2d1;
				foreach (CustomXmlProperty item in x847f8b50f8fc.x4e35c79189b28e26)
				{
					customXmlMarkup.Properties.Add(item);
				}
				xe1d718cca131846e.xffb32620593acdf2.xb595d21dbff3629b(customXmlMarkup);
				xa224ac5c01b9d133.Push(customXmlMarkup);
			}
			else
			{
				xbbf9a1ead81dd3a1(WarningType.DataLoss, $"Invalid Custom XML reference at 0x{x2865e605e9fbfb80:x4} occured while reading DOC file.");
			}
			break;
		}
		case '>':
			if (xa224ac5c01b9d133.Count > 0)
			{
				xa224ac5c01b9d133.Pop();
				xe1d718cca131846e.xffb32620593acdf2.x7eac7e2ac5d4302b();
			}
			break;
		default:
			xe1d718cca131846e.xffb32620593acdf2.x27442410230d2b1f(x12f11d52c2c4d003, x789564759d365819);
			break;
		}
	}

	private void xdb97c3f91e3ebdfb(xeedad81aaed42a76 x789564759d365819, int x6211ee450938c2c4)
	{
		if (x5c29822913be33c1.x7f8b7c1c90735bcf(xe1d718cca131846e.xffb32620593acdf2.x58c29d68a9c691d9()))
		{
			xe1d718cca131846e.x6215066365db5120.BaseStream.Position = x6211ee450938c2c4;
			x58bf2a36f9adf9a9 x3db8cf25c83af70b = xf2b9ab75a7571713.x7e54dea1c329122d(xe1d718cca131846e.x6215066365db5120);
			xe1d718cca131846e.xffb32620593acdf2.xd438a3a8968e57e1(x3db8cf25c83af70b, x789564759d365819);
		}
	}

	private void x0d24986434a725c5(xeedad81aaed42a76 x789564759d365819, int xe680f7e4e9e521a9)
	{
		x71d39fdf56861cca x71d39fdf56861cca = xe1d718cca131846e.x027f422ae4e5ea22(xe680f7e4e9e521a9);
		if (x71d39fdf56861cca != null)
		{
			Shape shape = new Shape(xe1d718cca131846e.x2c8c6741422a1298);
			shape.x88d1b78392d1a0ab(ShapeType.OleObject);
			shape.xeedad81aaed42a76 = x789564759d365819;
			shape.WrapType = WrapType.Inline;
			MemoryStream x763bd29719f4b2e = x71d39fdf56861cca.x763bd29719f4b2e4;
			if (x763bd29719f4b2e != null)
			{
				byte[] array = new byte[(int)(x763bd29719f4b2e.Length - 8)];
				x763bd29719f4b2e.Position = 0L;
				BinaryReader binaryReader = new BinaryReader(x763bd29719f4b2e);
				binaryReader.ReadUInt16();
				int num = binaryReader.ReadUInt16();
				int num2 = binaryReader.ReadUInt16();
				binaryReader.ReadUInt16();
				x763bd29719f4b2e.Read(array, 0, array.Length);
				shape.ImageData.x7a0cb9855dd2eab1(xdd1b8f14cc8ba86d.x300bc69d382eb52c(array, xa2745adfabe0c674.xe6a756f8b9f6fe18((int)((double)num / 2540.0 * 1963.0), (int)((double)num2 / 2540.0 * 1963.0), 1963.0, 1963.0)));
			}
			else
			{
				x3dc950453374051a("OLE 1.0 object stream 'META' is missing, possible image size problem.");
			}
			MemoryStream x6a0060cc731d = x71d39fdf56861cca.x6a0060cc731d6605;
			if (x6a0060cc731d != null)
			{
				BinaryReader binaryReader2 = new BinaryReader(x6a0060cc731d);
				x6a0060cc731d.Position = 12L;
				binaryReader2.ReadUInt16();
				binaryReader2.ReadUInt16();
				binaryReader2.ReadUInt16();
				binaryReader2.ReadUInt16();
				int xf6495da3f9ed2d9c = binaryReader2.ReadInt32();
				int xf6495da3f9ed2d9c2 = binaryReader2.ReadInt32();
				x6a0060cc731d.Position = 44L;
				int num3 = binaryReader2.ReadInt32();
				int num4 = binaryReader2.ReadInt32();
				binaryReader2.ReadInt32();
				binaryReader2.ReadInt32();
				binaryReader2.ReadInt32();
				binaryReader2.ReadInt32();
				shape.xf524ccc95fe8e714(x4574ea26106f0edb.x0e1fdb362561ddb2(xf6495da3f9ed2d9c) * (double)num3 / 1000.0);
				shape.x404ab2fc377ad1ed(x4574ea26106f0edb.x0e1fdb362561ddb2(xf6495da3f9ed2d9c2) * (double)num4 / 1000.0);
			}
			xe1d718cca131846e.xffb32620593acdf2.xa9993ed2e0c64574(shape);
		}
	}

	private void xae86397ff5ef8e2c(xeedad81aaed42a76 x789564759d365819, int x6211ee450938c2c4)
	{
		xe1d718cca131846e.x6215066365db5120.BaseStream.Position = x6211ee450938c2c4;
		x409512556c3f2a9a x409512556c3f2a9a = new x409512556c3f2a9a(xe1d718cca131846e.x6215066365db5120);
		if (x409512556c3f2a9a.xd6696a1209486da5 != 68)
		{
			x3dc950453374051a($"Invalid PICF structure at 0x{x6211ee450938c2c4:x4}, shape is ignored.");
			return;
		}
		switch (x409512556c3f2a9a.xd7349b4fe5e74804)
		{
		case x37604adeead3e2b5.x70848705d43bd4ad:
		{
			int count = x409512556c3f2a9a.xf280755e03a40325 - x409512556c3f2a9a.xd6696a1209486da5;
			byte[] array = xe1d718cca131846e.x6215066365db5120.ReadBytes(count);
			Shape shape = new Shape(xe1d718cca131846e.x2c8c6741422a1298, ShapeType.Image);
			shape.WrapType = WrapType.Inline;
			if (array.Length > 0)
			{
				shape.ImageData.x7a0cb9855dd2eab1(array);
			}
			shape.xeedad81aaed42a76 = x789564759d365819;
			x409512556c3f2a9a.x865b320f557323c1(shape);
			xe1d718cca131846e.xffb32620593acdf2.xa9993ed2e0c64574(shape);
			break;
		}
		case x37604adeead3e2b5.xbf10b131db29ad53:
		{
			int x9e4be1b404ab074b2 = x409512556c3f2a9a.xf280755e03a40325 - x409512556c3f2a9a.xd6696a1209486da5;
			x9ace1ae461aa5e98(x409512556c3f2a9a, x789564759d365819, x9e4be1b404ab074b2);
			break;
		}
		case x37604adeead3e2b5.x7634dd95e10c7658:
		{
			string text = x93b05c1ad709a695.x602d3c3fbfa56f51(xe1d718cca131846e.x6215066365db5120, x5be1cad1d00af914: false, xac1baf51b3e43d13: false);
			int x9e4be1b404ab074b = x409512556c3f2a9a.xf280755e03a40325 - x409512556c3f2a9a.xd6696a1209486da5 - text.Length - 1;
			x9ace1ae461aa5e98(x409512556c3f2a9a, x789564759d365819, x9e4be1b404ab074b);
			break;
		}
		default:
			x3dc950453374051a($"Invalid PICF structure at 0x{x6211ee450938c2c4:x4}, shape is ignored.");
			break;
		}
	}

	private void x9ace1ae461aa5e98(x409512556c3f2a9a x2ced84c6b9a55dad, xeedad81aaed42a76 x789564759d365819, int x9e4be1b404ab074b)
	{
		Shape shape = xe1d718cca131846e.xa5b547b6ce00aa54(x9e4be1b404ab074b);
		if (shape != null && !x11ac44beec2681a4(shape, x2ced84c6b9a55dad))
		{
			if (!x2ced84c6b9a55dad.x22ab5dfa6f12e902)
			{
				x3dc950453374051a("Invalid PICF structure, shape is ignored.");
				return;
			}
			shape.xeedad81aaed42a76 = x789564759d365819;
			x2ced84c6b9a55dad.x865b320f557323c1(shape);
			xda91849e0d4ce8fd(shape);
			xe1d718cca131846e.xffb32620593acdf2.xa9993ed2e0c64574(shape);
		}
	}

	private void xda91849e0d4ce8fd(ShapeBase x5770cdefd8931aa9)
	{
		if (xe1d718cca131846e.xb4fa721cfeafcddd)
		{
			x5770cdefd8931aa9.xd06a0f106e67d743 = true;
		}
		else if (x5770cdefd8931aa9.xd06a0f106e67d743)
		{
			x5770cdefd8931aa9.xd06a0f106e67d743 = false;
		}
	}

	private static bool x11ac44beec2681a4(Shape x5770cdefd8931aa9, x409512556c3f2a9a x2ced84c6b9a55dad)
	{
		if (!x5770cdefd8931aa9.IsImage)
		{
			return false;
		}
		if (x5770cdefd8931aa9.ImageData.HasImage)
		{
			return false;
		}
		if (x2ced84c6b9a55dad.x11973ad34d8be202 != xd372c62feb02ff45.x39fe35bdfe73f135 && x2ced84c6b9a55dad.x11973ad34d8be202 != 0)
		{
			return false;
		}
		return true;
	}

	private void xcba8faacb9b0c86d(int x1e5b3c79ded5dbc8, xeedad81aaed42a76 x789564759d365819)
	{
		x1238479da7c66191 x1238479da7c = xe1d718cca131846e.x56e5a2c6f7ef0a50(x7a1a247785b9a739);
		xac083244a6c1aa10 xac083244a6c1aa = x1238479da7c.x6704a7933d78741d(x1e5b3c79ded5dbc8);
		if (xac083244a6c1aa == null)
		{
			x3dc950453374051a("Couldn't get FSPA structure for shape, shape is ignored.");
			return;
		}
		ShapeBase shapeBase = xe1d718cca131846e.x344144ac57593f12(xac083244a6c1aa.x1f6ee650d037e627, x93b05c1ad709a695.x7625b7f02c65c1cd(x7a1a247785b9a739));
		if (shapeBase == null)
		{
			x3dc950453374051a("Couldn't get OfficeArt record for shape, shape is ignored.");
			return;
		}
		bool xc85a4e261cc10edf = xe1d718cca131846e.x8aeace2bf92692ab.x4debd6958bcd2b55 > x3a9e25666c8d1ee1.xe3cb3ab95828933e;
		xac083244a6c1aa.x865b320f557323c1(shapeBase, xc85a4e261cc10edf);
		shapeBase.xeedad81aaed42a76 = x789564759d365819;
		if (!shapeBase.IsGroup)
		{
			xda91849e0d4ce8fd(shapeBase);
		}
		xe1d718cca131846e.xffb32620593acdf2.xa9993ed2e0c64574(shapeBase);
		xbf2075e4ba4cb533(shapeBase);
	}

	private void xbf2075e4ba4cb533(ShapeBase x8739b0dd3627f37e)
	{
		if (x8739b0dd3627f37e.IsGroup)
		{
			GroupShape groupShape = (GroupShape)x8739b0dd3627f37e;
			for (Node node = groupShape.FirstChild; node != null; node = node.NextSibling)
			{
				xbf2075e4ba4cb533((ShapeBase)node);
			}
			return;
		}
		x1238479da7c66191 x1238479da7c = xe1d718cca131846e.x56e5a2c6f7ef0a50(x7a1a247785b9a739);
		xcc3ba13909434925 xcc3ba13909434925 = x1238479da7c.xdcd8f9af39d96c9b(x8739b0dd3627f37e.xea1e81378298fa81);
		if (xcc3ba13909434925 != null && xcc3ba13909434925.x1be93eed8950d961 > 0)
		{
			Shape x5770cdefd8931aa = (Shape)x8739b0dd3627f37e;
			xe1d718cca131846e.xffb32620593acdf2.xb2930715346a6867(x5770cdefd8931aa);
			x32eac27632acc346 x32eac27632acc347 = new x32eac27632acc346(xe1d718cca131846e, x93b05c1ad709a695.x991d17aba8ce15b3(x7a1a247785b9a739));
			x32eac27632acc347.x1f490eac106aee12(xcc3ba13909434925.x12cb12b5d2cad53d, xcc3ba13909434925.x1be93eed8950d961);
			xe1d718cca131846e.xffb32620593acdf2.x6c71b8bd0c5c4b9a(x5770cdefd8931aa);
		}
	}

	private x52ed50cf5d3a8cc6 x2adeff278a565ab3(int x2865e605e9fbfb80, out FootnoteType xd3526c7313d75391)
	{
		x52ed50cf5d3a8cc6 x52ed50cf5d3a8cc = null;
		xd3526c7313d75391 = FootnoteType.Footnote;
		if (x7a1a247785b9a739 == x9e131021ba70185c.xc447809891322395)
		{
			int x18d1054d = xe1d718cca131846e.x8aeace2bf92692ab.xe53581d2051aca20(x2865e605e9fbfb80);
			x52ed50cf5d3a8cc = xe1d718cca131846e.x766da124ec0eb8b2.xc7a616051c4c1712(x18d1054d);
			if (x52ed50cf5d3a8cc == null)
			{
				xd3526c7313d75391 = FootnoteType.Endnote;
				x52ed50cf5d3a8cc = xe1d718cca131846e.xf926db502adbb667.xc7a616051c4c1712(x18d1054d);
			}
		}
		return x52ed50cf5d3a8cc;
	}

	private bool x69d502aaca08ee16(x52ed50cf5d3a8cc6 xa374c2b6b8c56b41, FootnoteType xd3526c7313d75391, x98d75821045fe9bd xbb8131fb9e06f47f, int x714cba090602ea7f, int x93a01976e1aef789, xa52f2632c0ffdfaf xe08a26cc2b49f3aa, xeedad81aaed42a76 x789564759d365819)
	{
		xa374c2b6b8c56b41.x3769f8ef95e20cd1 = xbb8131fb9e06f47f.xf73ef160527516c8[x714cba090602ea7f] == '\u0002';
		if (!xa374c2b6b8c56b41.x3769f8ef95e20cd1 || xe08a26cc2b49f3aa.xa1a25be53d0a44c8)
		{
			string text = null;
			if (!xa374c2b6b8c56b41.x3769f8ef95e20cd1)
			{
				text = new string(xbb8131fb9e06f47f.xf73ef160527516c8, x714cba090602ea7f, x93a01976e1aef789 - x714cba090602ea7f);
				if (xe08a26cc2b49f3aa.xa1a25be53d0a44c8 && xe08a26cc2b49f3aa.xe59d6d35c76d70aa != 0 && text == "(")
				{
					text = new string(new char[1] { x09d499c483428bd1.xa8b9c2cfa706a303(xe08a26cc2b49f3aa.xe59d6d35c76d70aa) });
				}
			}
			xe1d718cca131846e.xffb32620593acdf2.x1f4dededb9314c98(xd3526c7313d75391, xa374c2b6b8c56b41.x3769f8ef95e20cd1, text, x789564759d365819);
			x32eac27632acc346 x32eac27632acc347 = new x32eac27632acc346(xe1d718cca131846e, xd452a5f78fa06e8b.xa339e023ec82f1e3(xd3526c7313d75391));
			x32eac27632acc347.x1f490eac106aee12(xa374c2b6b8c56b41.x12cb12b5d2cad53d, xa374c2b6b8c56b41.x1be93eed8950d961);
			xe1d718cca131846e.xffb32620593acdf2.x08d6c67017518c71();
			return true;
		}
		return false;
	}

	private void x85b171006887a0b5(int x3081c6893a24d3c4, xeedad81aaed42a76 x789564759d365819)
	{
		xe91a1cdf262fe886 xe91a1cdf262fe = xe1d718cca131846e.xe91a1cdf262fe886;
		int num = xe91a1cdf262fe.xeaa001c8a56a5789.xd888124d3245cd86(x3081c6893a24d3c4);
		if (num < 0)
		{
			x3dc950453374051a($"Invalid annotation reference at local CP: 0x{x3081c6893a24d3c4:x4}.");
			return;
		}
		xca838b0f1d157cd8 xca838b0f1d157cd = xe91a1cdf262fe.xeaa001c8a56a5789.get_xe6d4b1b411ed94b5(num);
		string x984160c7f = xe91a1cdf262fe.x1f819cfa8567ddba(xca838b0f1d157cd.x57653a46aad8df6a);
		xe1d718cca131846e.xffb32620593acdf2.x508bedf5d0984ae8(xca838b0f1d157cd.x745c3a5e8101c8d9, xca838b0f1d157cd.x660adf533ba4edef, x984160c7f, xca838b0f1d157cd.x242851e6278ed355, x789564759d365819);
		x32eac27632acc346 x32eac27632acc347 = new x32eac27632acc346(xe1d718cca131846e, x9e131021ba70185c.x937e050c63ea1527);
		int num2 = xe91a1cdf262fe.x3368fdcc844084ff.xed8a0d4499d6f292(num);
		int num3 = xe91a1cdf262fe.x3368fdcc844084ff.xed8a0d4499d6f292(num + 1);
		x32eac27632acc347.x1f490eac106aee12(num2, num3 - num2);
		xe1d718cca131846e.xffb32620593acdf2.x0d5864f2522edf7f();
	}

	private void x3dc950453374051a(string xc2358fbac7da3d45)
	{
		xbbf9a1ead81dd3a1(WarningType.UnexpectedContent, xc2358fbac7da3d45);
	}

	private void xbbf9a1ead81dd3a1(WarningType x43163d22e8cd5a71, string xc2358fbac7da3d45)
	{
		xe1d718cca131846e.xffb32620593acdf2.xbbf9a1ead81dd3a1(x43163d22e8cd5a71, xc2358fbac7da3d45);
	}
}
