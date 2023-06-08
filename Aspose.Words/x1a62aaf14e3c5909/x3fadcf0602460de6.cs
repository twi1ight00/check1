using System;
using System.Collections;
using Aspose.Words;
using Aspose.Words.Drawing;
using x011d489fb9df7027;
using x13f1efc79617a47b;
using x38a89dee67fc7a16;
using x5794c252ba25e723;
using x5f3520a4b31ea90f;
using x6c95d9cf46ff5f25;
using xf989f31a236ff98c;

namespace x1a62aaf14e3c5909;

internal class x3fadcf0602460de6
{
	private readonly x373059570f6cfe23 x8cedcaa9a62c6e39;

	private ShapeBase x317be79405176667;

	private xa5a62ee5bc98c41e xc93e07aa73eff702;

	private xa5a62ee5bc98c41e xa5fbce3914fd73c2;

	private int xc4e2003c69309d8c;

	private int x670f074c32dcc617;

	private int x90e61c98253a38ee;

	private int xd31a99b2bb9d950a;

	private int x14e085880624cc84;

	private int xf83075fa0713ab57;

	private int xe2d7e0df6cd24a4d;

	private int x8667a03db789e889;

	private int x3adbfebe6efecd72;

	private int xb591ae20372a536e;

	private int x1c15dc641ace292c;

	private int xdfdca9656f84302e;

	private int xc875caeaab18a855;

	private int x3259b06c95a65ce7;

	private int xf4ae6a382caa01b2;

	private int xb1656fc70be6a527;

	private int x1c7273576dd6d9e3;

	private int x9fdf1c0356fe4631;

	private int x0c27af9f52c1a764;

	private int x2545696f645ca690;

	private readonly Hashtable x696ed17637971453 = new Hashtable();

	internal x3fadcf0602460de6(x373059570f6cfe23 context)
	{
		x8cedcaa9a62c6e39 = context;
	}

	internal void x06b0e25aa6ad68a9(xa5a62ee5bc98c41e xa5ea04da0b735c3b, ShapeBase x5770cdefd8931aa9)
	{
		x317be79405176667 = x5770cdefd8931aa9;
		xc93e07aa73eff702 = xa5ea04da0b735c3b;
		xa5fbce3914fd73c2 = null;
		for (int i = 0; i < xa5ea04da0b735c3b.xd44988f225497f3a; i++)
		{
			xef8fbb0f103c0bb1 xef8fbb0f103c0bb2 = (xef8fbb0f103c0bb1)xa5ea04da0b735c3b.x6d3720b962bd3112(i);
			int num = xef8fbb0f103c0bb2.xea1e81378298fa81 & -64;
			switch (num)
			{
			case 0:
				xcd3de0b4406e4355(xef8fbb0f103c0bb2);
				break;
			case 64:
				x39eecf810e693be2(xef8fbb0f103c0bb2);
				break;
			case 128:
				xc3a6fb8513d320a3(xef8fbb0f103c0bb2);
				break;
			case 192:
				x8b44c7c6d3984196(xef8fbb0f103c0bb2);
				break;
			case 256:
				x264f3cba2f0b02e2(xef8fbb0f103c0bb2);
				break;
			case 320:
				x332f80d8a98a801c(xef8fbb0f103c0bb2);
				break;
			case 384:
				xcd21218c34904d8a(xef8fbb0f103c0bb2);
				break;
			case 448:
				xa8adf7fbd1cf75d9(xef8fbb0f103c0bb2, num);
				break;
			case 512:
				x81e7deb9c136b3d7(xef8fbb0f103c0bb2);
				break;
			case 576:
				xe103480a0a407feb(xef8fbb0f103c0bb2);
				break;
			case 640:
				xaf2a34e7cf340de7(xef8fbb0f103c0bb2);
				break;
			case 704:
				x1f5fffbba7bbb5b3(xef8fbb0f103c0bb2);
				break;
			case 768:
				xfe4f7dca36c0076c(xef8fbb0f103c0bb2);
				break;
			case 832:
				x8f98f0a173d360f1(xef8fbb0f103c0bb2);
				break;
			case 896:
				xebd2c89e8589560e(xef8fbb0f103c0bb2);
				break;
			case 1024:
				x37c02644f397e517(xef8fbb0f103c0bb2);
				break;
			case 1280:
				x3337a3b14df78af2(xef8fbb0f103c0bb2);
				break;
			case 1344:
			case 1408:
			case 1472:
			case 1536:
			case 1600:
				xa8adf7fbd1cf75d9(xef8fbb0f103c0bb2, num);
				break;
			case 1664:
				x8cedcaa9a62c6e39.x3dc950453374051a($"Unsupported OfficeArt property 0x{xef8fbb0f103c0bb2.xea1e81378298fa81:x4}, ignored.");
				break;
			case 1728:
				x9bc07b057f5926f2(xef8fbb0f103c0bb2);
				break;
			case 1792:
				x4efc87f607a9c606(xef8fbb0f103c0bb2);
				break;
			case 1856:
				x8cedcaa9a62c6e39.x3dc950453374051a($"Unsupported OfficeArt property 0x{xef8fbb0f103c0bb2.xea1e81378298fa81:x4}, ignored.");
				break;
			case 1920:
				x7e25ce646ac3d24c(xef8fbb0f103c0bb2);
				break;
			case 1984:
				x6cec198aa9f1df0b(xef8fbb0f103c0bb2);
				break;
			default:
				x99fcf901fef00ab9(xef8fbb0f103c0bb2.xea1e81378298fa81);
				break;
			case 4096:
				break;
			}
		}
		if (x317be79405176667.x895b1223bcc162ac && !x317be79405176667.xf7125312c7ee115c.x263d579af1d0d43f(1980))
		{
			x317be79405176667.x0817d5cde9e19bf6(1980, true);
		}
		x30145fee5dd2eb06.x96bbefc795cf6d84(x317be79405176667.xf7125312c7ee115c);
	}

	private void xcd3de0b4406e4355(xef8fbb0f103c0bb1 x5ca6b6e12a4d9043)
	{
		int x9a1915e0a5a745b = x5ca6b6e12a4d9043.x9a1915e0a5a745b7;
		int xea1e81378298fa = x5ca6b6e12a4d9043.xea1e81378298fa81;
		if (xea1e81378298fa == 4)
		{
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, x9a1915e0a5a745b);
		}
		else
		{
			x99fcf901fef00ab9(x5ca6b6e12a4d9043.xea1e81378298fa81);
		}
	}

	private void x39eecf810e693be2(xef8fbb0f103c0bb1 x5ca6b6e12a4d9043)
	{
		int x9a1915e0a5a745b = x5ca6b6e12a4d9043.x9a1915e0a5a745b7;
		int xea1e81378298fa = x5ca6b6e12a4d9043.xea1e81378298fa81;
		if (xea1e81378298fa == 127)
		{
			xbd23e47977ecf67d(x317be79405176667, 119, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 120, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 121, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 122, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 123, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 124, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 125, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 126, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 127, x9a1915e0a5a745b);
		}
		else
		{
			x99fcf901fef00ab9(x5ca6b6e12a4d9043.xea1e81378298fa81);
		}
	}

	private void xc3a6fb8513d320a3(xef8fbb0f103c0bb1 x5ca6b6e12a4d9043)
	{
		int x9a1915e0a5a745b = x5ca6b6e12a4d9043.x9a1915e0a5a745b7;
		switch (x5ca6b6e12a4d9043.xea1e81378298fa81)
		{
		case 138:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, x9a1915e0a5a745b);
			break;
		case 129:
		case 130:
		case 131:
		case 132:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, x9a1915e0a5a745b);
			break;
		case 133:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, (TextBoxWrapMode)x9a1915e0a5a745b);
			break;
		case 134:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, x9a1915e0a5a745b);
			break;
		case 135:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, (x69aaa2975337eae6)x9a1915e0a5a745b);
			break;
		case 136:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, (LayoutFlow)x9a1915e0a5a745b);
			break;
		case 137:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, (x05e2bbe26ab31299)x9a1915e0a5a745b);
			break;
		case 139:
		case 140:
		case 141:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, x9a1915e0a5a745b);
			break;
		case 191:
			xbd23e47977ecf67d(x317be79405176667, 187, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 188, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 189, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 190, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 191, x9a1915e0a5a745b);
			break;
		default:
			x99fcf901fef00ab9(x5ca6b6e12a4d9043.xea1e81378298fa81);
			break;
		case 128:
			break;
		}
	}

	private void x8b44c7c6d3984196(xef8fbb0f103c0bb1 x5ca6b6e12a4d9043)
	{
		int x9a1915e0a5a745b = x5ca6b6e12a4d9043.x9a1915e0a5a745b7;
		switch (x5ca6b6e12a4d9043.xea1e81378298fa81)
		{
		case 192:
		case 193:
		case 197:
		{
			x7dacc4d0459cdf99 x7dacc4d0459cdf100 = (x7dacc4d0459cdf99)x5ca6b6e12a4d9043;
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, x7dacc4d0459cdf100.xd2f68ee6f47e9dfb);
			break;
		}
		case 194:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, (TextPathAlignment)x9a1915e0a5a745b);
			break;
		case 195:
		case 196:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, x9a1915e0a5a745b);
			break;
		case 255:
			xbd23e47977ecf67d(x317be79405176667, 240, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 241, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 242, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 243, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 244, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 245, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 246, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 247, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 248, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 249, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 250, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 251, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 252, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 253, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 254, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 255, x9a1915e0a5a745b);
			break;
		default:
			x99fcf901fef00ab9(x5ca6b6e12a4d9043.xea1e81378298fa81);
			break;
		}
	}

	private void x264f3cba2f0b02e2(xef8fbb0f103c0bb1 x5ca6b6e12a4d9043)
	{
		int x9a1915e0a5a745b = x5ca6b6e12a4d9043.x9a1915e0a5a745b7;
		switch (x5ca6b6e12a4d9043.xea1e81378298fa81)
		{
		case 256:
		case 257:
		case 258:
		case 259:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, x9a1915e0a5a745b);
			break;
		case 260:
		{
			xd959c7c7ca733332 xd959c7c7ca733333 = x590497a2b838b652(x9a1915e0a5a745b);
			byte[] xf9a0d04800d = ((xd959c7c7ca733333 != null) ? xd959c7c7ca733333.xcc18177a965e0313 : x0d299f323d241756.xcd6c2a9742c9220a());
			Shape shape = (Shape)x317be79405176667;
			shape.ImageData.x7a0cb9855dd2eab1(xf9a0d04800d);
			break;
		}
		case 261:
		{
			x7dacc4d0459cdf99 x7dacc4d0459cdf100 = (x7dacc4d0459cdf99)x5ca6b6e12a4d9043;
			string xd2f68ee6f47e9dfb = x7dacc4d0459cdf100.xd2f68ee6f47e9dfb;
			xf3e451597d75ed26 xf3e451597d75ed27 = (xf3e451597d75ed26)(((xba3d4617457193ff)((x09ce2c02826e31a6)xc93e07aa73eff702).get_xe6d4b1b411ed94b5(262))?.x9a1915e0a5a745b7 ?? 0);
			int xba08ce632055a1d;
			if ((xf3e451597d75ed27 & xf3e451597d75ed26.x9f0fec941dc4b192) != 0)
			{
				if (xa4b4f402a21faddb(xd2f68ee6f47e9dfb))
				{
					xba08ce632055a1d = 4104;
				}
				else
				{
					x3dc950453374051a("Invalid link to file, moved to image description.");
					xba08ce632055a1d = 897;
				}
			}
			else
			{
				xba08ce632055a1d = 4103;
			}
			x317be79405176667.x0817d5cde9e19bf6(xba08ce632055a1d, xd2f68ee6f47e9dfb);
			break;
		}
		case 263:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, x195cb055715b526e.xfa7086ee0c6b6330(x9a1915e0a5a745b));
			break;
		case 264:
		case 265:
		case 266:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, x9a1915e0a5a745b);
			break;
		case 268:
		case 269:
		case 270:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, x9a1915e0a5a745b);
			break;
		case 282:
		case 283:
		case 285:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, x9a1915e0a5a745b);
			break;
		case 319:
			xbd23e47977ecf67d(x317be79405176667, 316, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 317, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 318, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 319, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 313, x9a1915e0a5a745b);
			break;
		default:
			x99fcf901fef00ab9(x5ca6b6e12a4d9043.xea1e81378298fa81);
			break;
		case 262:
		case 267:
		case 284:
		case 286:
		case 287:
			break;
		}
	}

	private static bool xa4b4f402a21faddb(string xc15bd84e01929885)
	{
		if (!x0d4d45882065c63e.x4602b59392dc27e9(xc15bd84e01929885) && !x0d4d45882065c63e.x7c12ca7e8a9abcb8(xc15bd84e01929885))
		{
			return x0d4d45882065c63e.xe06270bc72b12369(xc15bd84e01929885);
		}
		return true;
	}

	private void x332f80d8a98a801c(xef8fbb0f103c0bb1 x5ca6b6e12a4d9043)
	{
		int x9a1915e0a5a745b = x5ca6b6e12a4d9043.x9a1915e0a5a745b7;
		switch (x5ca6b6e12a4d9043.xea1e81378298fa81)
		{
		case 320:
			if (!x317be79405176667.IsGroup)
			{
				x317be79405176667.x06c65daad0c0656c = x9a1915e0a5a745b;
			}
			break;
		case 321:
			if (!x317be79405176667.IsGroup)
			{
				x317be79405176667.x399bb78ac51a4081 = x9a1915e0a5a745b;
			}
			break;
		case 322:
			if (!x317be79405176667.IsGroup)
			{
				x317be79405176667.xfe47e26e3b236632(x9a1915e0a5a745b - x317be79405176667.x06c65daad0c0656c);
			}
			break;
		case 323:
			if (!x317be79405176667.IsGroup)
			{
				x317be79405176667.x27bd4aa4cf0ce1aa(x9a1915e0a5a745b - x317be79405176667.x399bb78ac51a4081);
			}
			break;
		case 324:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, (x449c0af4c304c651)x9a1915e0a5a745b);
			break;
		case 325:
		{
			xf7d2bc4cd6535591 xf7d2bc4cd6535593 = (xf7d2bc4cd6535591)x5ca6b6e12a4d9043;
			x08d932077485c285[] array2 = xf7d2bc4cd6535593.xe512752f228eb379();
			if (array2 != null)
			{
				x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, array2);
			}
			break;
		}
		case 326:
		{
			xf7d2bc4cd6535591 xf7d2bc4cd6535598 = (xf7d2bc4cd6535591)x5ca6b6e12a4d9043;
			x44f2b8bf33b16275[] array7 = xf7d2bc4cd6535598.x1f564d9c310beda1();
			if (array7 != null)
			{
				x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, array7);
			}
			break;
		}
		case 327:
		case 328:
		case 329:
		case 330:
		case 331:
		case 332:
		case 333:
		case 334:
		case 335:
		case 336:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, x9a1915e0a5a745b);
			break;
		case 337:
		{
			xf7d2bc4cd6535591 xf7d2bc4cd6535597 = (xf7d2bc4cd6535591)x5ca6b6e12a4d9043;
			x08d932077485c285[] array6 = xf7d2bc4cd6535597.xe512752f228eb379();
			if (array6 != null)
			{
				x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, array6);
			}
			break;
		}
		case 338:
		{
			xf7d2bc4cd6535591 xf7d2bc4cd6535596 = (xf7d2bc4cd6535591)x5ca6b6e12a4d9043;
			int[] array5 = xf7d2bc4cd6535596.xaf14ff6cf5955691();
			if (array5 != null)
			{
				x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, array5);
			}
			break;
		}
		case 339:
		case 340:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, x9a1915e0a5a745b);
			break;
		case 341:
		{
			xf7d2bc4cd6535591 xf7d2bc4cd6535595 = (xf7d2bc4cd6535591)x5ca6b6e12a4d9043;
			x7efbe0a2dc0d335f[] array4 = xf7d2bc4cd6535595.xb6ff3138565feb6c();
			if (array4 != null)
			{
				x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, array4);
			}
			break;
		}
		case 342:
		{
			xf7d2bc4cd6535591 xf7d2bc4cd6535594 = (xf7d2bc4cd6535591)x5ca6b6e12a4d9043;
			x40937ad35b1cf5f7[] array3 = xf7d2bc4cd6535594.x767e62a423f94754();
			if (array3 != null)
			{
				x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, array3);
			}
			break;
		}
		case 343:
		{
			xf7d2bc4cd6535591 xf7d2bc4cd6535592 = (xf7d2bc4cd6535591)x5ca6b6e12a4d9043;
			xbc9979937c838d75[] array = xf7d2bc4cd6535592.xaf85c1a1ad8ed83a();
			if (array != null)
			{
				x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, array);
			}
			break;
		}
		case 344:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, (x3b504d8c866583dc)x9a1915e0a5a745b);
			break;
		case 377:
			x8cedcaa9a62c6e39.x3dc950453374051a($"Unsupported OfficeArt property 0x{x5ca6b6e12a4d9043.xea1e81378298fa81:x4}, ignored.");
			break;
		case 383:
			xbd23e47977ecf67d(x317be79405176667, 378, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 379, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 380, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 381, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 382, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 383, x9a1915e0a5a745b);
			break;
		default:
			x99fcf901fef00ab9(x5ca6b6e12a4d9043.xea1e81378298fa81);
			break;
		}
	}

	private void xcd21218c34904d8a(xef8fbb0f103c0bb1 x5ca6b6e12a4d9043)
	{
		int x9a1915e0a5a745b = x5ca6b6e12a4d9043.x9a1915e0a5a745b7;
		switch (x5ca6b6e12a4d9043.xea1e81378298fa81)
		{
		case 384:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, (xeba92971120d3e5a)x9a1915e0a5a745b);
			break;
		case 385:
		case 387:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, x195cb055715b526e.xfa7086ee0c6b6330(x9a1915e0a5a745b));
			break;
		case 386:
		case 388:
		case 389:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, x9a1915e0a5a745b);
			break;
		case 390:
		{
			xd959c7c7ca733332 xd959c7c7ca733333 = x590497a2b838b652(x9a1915e0a5a745b);
			if (xd959c7c7ca733333 != null)
			{
				x317be79405176667.x0817d5cde9e19bf6(4111, xd959c7c7ca733333.xcc18177a965e0313);
				x317be79405176667.x0817d5cde9e19bf6(4122, xd959c7c7ca733333.x10884bb8036bcee0);
			}
			break;
		}
		case 391:
		{
			x7dacc4d0459cdf99 x7dacc4d0459cdf100 = (x7dacc4d0459cdf99)x5ca6b6e12a4d9043;
			x317be79405176667.x0817d5cde9e19bf6(391, x7dacc4d0459cdf100.xd2f68ee6f47e9dfb);
			break;
		}
		case 392:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, x9a1915e0a5a745b);
			break;
		case 393:
		case 394:
		case 395:
		case 396:
		case 397:
		case 398:
		case 399:
		case 400:
		case 401:
		case 402:
		case 403:
		case 404:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, x9a1915e0a5a745b);
			break;
		case 405:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, (xd56eb9f05f589be5)x9a1915e0a5a745b);
			break;
		case 406:
			x8cedcaa9a62c6e39.x3dc950453374051a($"Unsupported OfficeArt property 0x{x5ca6b6e12a4d9043.xea1e81378298fa81:x4}, ignored.");
			break;
		case 407:
		{
			xf7d2bc4cd6535591 xf7d2bc4cd6535592 = (xf7d2bc4cd6535591)x5ca6b6e12a4d9043;
			x9fb6ff04f20b10d0[] array = xf7d2bc4cd6535592.x54f9561cb7ef62b1();
			if (array != null)
			{
				x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, array);
			}
			break;
		}
		case 408:
		case 409:
		case 410:
		case 411:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, x9a1915e0a5a745b);
			break;
		case 412:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, (xda3162397283dd69)x9a1915e0a5a745b);
			break;
		case 414:
		case 415:
		case 416:
		case 418:
		case 419:
		case 420:
		case 421:
		case 422:
		case 423:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, x9a1915e0a5a745b);
			break;
		case 417:
			x8cedcaa9a62c6e39.x3dc950453374051a($"Unsupported OfficeArt property 0x{x5ca6b6e12a4d9043.xea1e81378298fa81:x4}, ignored.");
			break;
		case 442:
			x8cedcaa9a62c6e39.x3dc950453374051a($"Unsupported OfficeArt property 0x{x5ca6b6e12a4d9043.xea1e81378298fa81:x4}, ignored.");
			break;
		case 447:
			xbd23e47977ecf67d(x317be79405176667, 443, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 444, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 445, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 446, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 447, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 441, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 442, x9a1915e0a5a745b);
			break;
		default:
			x99fcf901fef00ab9(x5ca6b6e12a4d9043.xea1e81378298fa81);
			break;
		}
	}

	private void xa8adf7fbd1cf75d9(xef8fbb0f103c0bb1 x5ca6b6e12a4d9043, int x6f02b6a80bf6b36f)
	{
		if (x6f02b6a80bf6b36f != 448)
		{
			return;
		}
		int x9a1915e0a5a745b = x5ca6b6e12a4d9043.x9a1915e0a5a745b7;
		switch (x5ca6b6e12a4d9043.xea1e81378298fa81)
		{
		case 448:
		case 450:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, x195cb055715b526e.xfa7086ee0c6b6330(x9a1915e0a5a745b));
			break;
		case 449:
		case 451:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, x9a1915e0a5a745b);
			break;
		case 452:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, (x6d4b101fe08bc376)x9a1915e0a5a745b);
			break;
		case 453:
		{
			xd959c7c7ca733332 xd959c7c7ca733333 = x590497a2b838b652(x9a1915e0a5a745b);
			if (xd959c7c7ca733333 != null)
			{
				x317be79405176667.x0817d5cde9e19bf6(4110, xd959c7c7ca733333.xcc18177a965e0313);
				x317be79405176667.x0817d5cde9e19bf6(4121, xd959c7c7ca733333.x10884bb8036bcee0);
			}
			break;
		}
		case 454:
		{
			x7dacc4d0459cdf99 x7dacc4d0459cdf100 = (x7dacc4d0459cdf99)x5ca6b6e12a4d9043;
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, x7dacc4d0459cdf100.xd2f68ee6f47e9dfb);
			break;
		}
		case 455:
		case 456:
		case 457:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, x9a1915e0a5a745b);
			break;
		case 458:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, (xd56eb9f05f589be5)x9a1915e0a5a745b);
			break;
		case 459:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, x9a1915e0a5a745b);
			break;
		case 460:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, x9a1915e0a5a745b);
			break;
		case 461:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, (ShapeLineStyle)x9a1915e0a5a745b);
			break;
		case 462:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, (DashStyle)x9a1915e0a5a745b);
			break;
		case 463:
			x8cedcaa9a62c6e39.x3dc950453374051a($"Unsupported OfficeArt property 0x{x5ca6b6e12a4d9043.xea1e81378298fa81:x4}, ignored.");
			break;
		case 464:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, (ArrowType)x9a1915e0a5a745b);
			break;
		case 465:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, (ArrowType)x9a1915e0a5a745b);
			break;
		case 466:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, (ArrowWidth)x9a1915e0a5a745b);
			break;
		case 467:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, (ArrowLength)x9a1915e0a5a745b);
			break;
		case 468:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, (ArrowWidth)x9a1915e0a5a745b);
			break;
		case 469:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, (ArrowLength)x9a1915e0a5a745b);
			break;
		case 470:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, (JoinStyle)x9a1915e0a5a745b);
			break;
		case 471:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, (EndCap)x9a1915e0a5a745b);
			break;
		case 473:
		case 474:
		case 475:
		case 476:
		case 477:
		case 478:
		case 479:
		case 481:
		case 482:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, x9a1915e0a5a745b);
			break;
		case 480:
			x8cedcaa9a62c6e39.x3dc950453374051a($"Unknown OfficeArt property found 0x{x5ca6b6e12a4d9043.xea1e81378298fa81:x4}, ignored.");
			break;
		case 504:
		case 505:
			x8cedcaa9a62c6e39.x3dc950453374051a($"Unknown OfficeArt property found 0x{x5ca6b6e12a4d9043.xea1e81378298fa81:x4}, ignored.");
			break;
		case 511:
			xbd23e47977ecf67d(x317be79405176667, 505, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 506, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 507, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 508, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 509, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 510, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 511, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 503, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 504, x9a1915e0a5a745b);
			break;
		default:
			x99fcf901fef00ab9(x5ca6b6e12a4d9043.xea1e81378298fa81);
			break;
		}
	}

	private void x81e7deb9c136b3d7(xef8fbb0f103c0bb1 x5ca6b6e12a4d9043)
	{
		int x9a1915e0a5a745b = x5ca6b6e12a4d9043.x9a1915e0a5a745b7;
		switch (x5ca6b6e12a4d9043.xea1e81378298fa81)
		{
		case 512:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, (x9a91f1235b1d8cac)x9a1915e0a5a745b);
			break;
		case 513:
		case 514:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, x195cb055715b526e.xfa7086ee0c6b6330(x9a1915e0a5a745b));
			break;
		case 515:
		case 516:
		case 517:
		case 518:
		case 519:
		case 520:
		case 521:
		case 522:
		case 523:
		case 524:
		case 525:
		case 526:
		case 527:
		case 528:
		case 529:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, x9a1915e0a5a745b);
			break;
		case 530:
		case 531:
		case 532:
		case 534:
		case 535:
		case 536:
		case 538:
		case 539:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, x9a1915e0a5a745b);
			break;
		case 533:
		case 537:
			x8cedcaa9a62c6e39.x3dc950453374051a($"Unknown OfficeArt property found 0x{x5ca6b6e12a4d9043.xea1e81378298fa81:x4}, ignored.");
			break;
		case 575:
			xbd23e47977ecf67d(x317be79405176667, 574, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 575, x9a1915e0a5a745b);
			break;
		case 540:
			x8cedcaa9a62c6e39.x3dc950453374051a($"Unsupported OfficeArt property 0x{x5ca6b6e12a4d9043.xea1e81378298fa81:x4}, ignored.");
			break;
		default:
			x99fcf901fef00ab9(x5ca6b6e12a4d9043.xea1e81378298fa81);
			break;
		}
	}

	private void xe103480a0a407feb(xef8fbb0f103c0bb1 x5ca6b6e12a4d9043)
	{
		int x9a1915e0a5a745b = x5ca6b6e12a4d9043.x9a1915e0a5a745b7;
		switch (x5ca6b6e12a4d9043.xea1e81378298fa81)
		{
		case 576:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, (x38c4fdd995570edc)x9a1915e0a5a745b);
			break;
		case 577:
		case 578:
		case 579:
		case 580:
		case 581:
		case 582:
		case 583:
		case 584:
		case 585:
		case 586:
		case 587:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, x9a1915e0a5a745b);
			break;
		case 639:
			xbd23e47977ecf67d(x317be79405176667, 639, x9a1915e0a5a745b);
			break;
		default:
			x99fcf901fef00ab9(x5ca6b6e12a4d9043.xea1e81378298fa81);
			break;
		}
	}

	private void xaf2a34e7cf340de7(xef8fbb0f103c0bb1 x5ca6b6e12a4d9043)
	{
		int x9a1915e0a5a745b = x5ca6b6e12a4d9043.x9a1915e0a5a745b7;
		switch (x5ca6b6e12a4d9043.xea1e81378298fa81)
		{
		case 640:
		case 641:
		case 642:
		case 643:
		case 644:
		case 645:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, x9a1915e0a5a745b);
			break;
		case 646:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, (x8755a9e2fca0996e)x9a1915e0a5a745b);
			break;
		case 647:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, x195cb055715b526e.xfa7086ee0c6b6330(x9a1915e0a5a745b));
			break;
		case 648:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, x9a1915e0a5a745b);
			break;
		case 649:
		case 650:
		case 651:
		case 653:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, x9a1915e0a5a745b);
			break;
		case 652:
			x8cedcaa9a62c6e39.x3dc950453374051a($"Unknown OfficeArt property found 0x{x5ca6b6e12a4d9043.xea1e81378298fa81:x4}, ignored.");
			break;
		case 703:
			xbd23e47977ecf67d(x317be79405176667, 700, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 701, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 702, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 703, x9a1915e0a5a745b);
			break;
		default:
			x99fcf901fef00ab9(x5ca6b6e12a4d9043.xea1e81378298fa81);
			break;
		}
	}

	private void x1f5fffbba7bbb5b3(xef8fbb0f103c0bb1 x5ca6b6e12a4d9043)
	{
		int x9a1915e0a5a745b = x5ca6b6e12a4d9043.x9a1915e0a5a745b7;
		switch (x5ca6b6e12a4d9043.xea1e81378298fa81)
		{
		case 704:
		case 705:
		case 706:
		case 707:
		case 708:
		case 709:
		case 710:
		case 711:
		case 712:
		case 714:
		case 715:
		case 716:
		case 717:
		case 718:
		case 719:
		case 720:
		case 721:
		case 722:
		case 723:
		case 724:
		case 725:
		case 726:
		case 727:
		case 728:
		case 729:
		case 730:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, x9a1915e0a5a745b);
			break;
		case 713:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, (xb156f8ae92094cbb)x9a1915e0a5a745b);
			break;
		case 767:
			xbd23e47977ecf67d(x317be79405176667, 763, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 764, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 765, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 766, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 767, x9a1915e0a5a745b);
			break;
		default:
			x99fcf901fef00ab9(x5ca6b6e12a4d9043.xea1e81378298fa81);
			break;
		}
	}

	private void xfe4f7dca36c0076c(xef8fbb0f103c0bb1 x5ca6b6e12a4d9043)
	{
		int x9a1915e0a5a745b = x5ca6b6e12a4d9043.x9a1915e0a5a745b7;
		switch (x5ca6b6e12a4d9043.xea1e81378298fa81)
		{
		case 771:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, (x5b865d49b2c8440d)x9a1915e0a5a745b);
			break;
		case 772:
		case 773:
		case 774:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, (x17abde5b32777816)x9a1915e0a5a745b);
			break;
		case 777:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, (xc586cb26186123d4)x9a1915e0a5a745b);
			break;
		case 778:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, (x76b42e09224005a0)x9a1915e0a5a745b);
			break;
		case 779:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, x9a1915e0a5a745b);
			break;
		case 831:
			xbd23e47977ecf67d(x317be79405176667, 826, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 827, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 828, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 830, x9a1915e0a5a745b);
			break;
		case 780:
		{
			x35c861f511323d4d x35c861f511323d4d2 = (x35c861f511323d4d)x5ca6b6e12a4d9043;
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, x35c861f511323d4d2.xc98e6be6ffd823ac);
			break;
		}
		default:
			x99fcf901fef00ab9(x5ca6b6e12a4d9043.xea1e81378298fa81);
			break;
		case 769:
			break;
		}
	}

	private void x8f98f0a173d360f1(xef8fbb0f103c0bb1 x5ca6b6e12a4d9043)
	{
		int x9a1915e0a5a745b = x5ca6b6e12a4d9043.x9a1915e0a5a745b7;
		switch (x5ca6b6e12a4d9043.xea1e81378298fa81)
		{
		case 832:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, (x9cda3ea77eff6f0d)x9a1915e0a5a745b);
			break;
		case 834:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, (x637e6856119e5fb2)x9a1915e0a5a745b);
			break;
		case 835:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, (xceb84165dedc0c2d)x9a1915e0a5a745b);
			break;
		case 833:
		case 836:
		case 837:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, x9a1915e0a5a745b);
			break;
		case 895:
			xbd23e47977ecf67d(x317be79405176667, 889, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 890, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 891, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 892, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 893, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 894, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 895, x9a1915e0a5a745b);
			break;
		default:
			x99fcf901fef00ab9(x5ca6b6e12a4d9043.xea1e81378298fa81);
			break;
		}
	}

	private void xebd2c89e8589560e(xef8fbb0f103c0bb1 x5ca6b6e12a4d9043)
	{
		int x9a1915e0a5a745b = x5ca6b6e12a4d9043.x9a1915e0a5a745b7;
		switch (x5ca6b6e12a4d9043.xea1e81378298fa81)
		{
		case 896:
		case 897:
		case 909:
		case 910:
		case 919:
		case 922:
		{
			x7dacc4d0459cdf99 x7dacc4d0459cdf100 = (x7dacc4d0459cdf99)x5ca6b6e12a4d9043;
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, x7dacc4d0459cdf100.xd2f68ee6f47e9dfb);
			break;
		}
		case 898:
		{
			x9bd10249890baaef x9bd10249890baaef2 = (x9bd10249890baaef)x5ca6b6e12a4d9043;
			x317be79405176667.HRef = x0d4d45882065c63e.x60ea34a7657b9f8a(x9bd10249890baaef2.x1d5cfa3bffdfb042, x9bd10249890baaef2.x2141cbc5929f5173);
			if (x0d299f323d241756.x5959bccb67bbf051(x9bd10249890baaef2.x42f4c234c9358072))
			{
				x317be79405176667.Target = x9bd10249890baaef2.x42f4c234c9358072;
			}
			break;
		}
		case 899:
		{
			xf7d2bc4cd6535591 xf7d2bc4cd6535592 = (xf7d2bc4cd6535591)x5ca6b6e12a4d9043;
			x08d932077485c285[] array = xf7d2bc4cd6535592.xe512752f228eb379();
			if (array != null)
			{
				x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, array);
			}
			break;
		}
		case 900:
		case 901:
		case 902:
		case 903:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, x9a1915e0a5a745b);
			break;
		case 911:
			x317be79405176667.HorizontalAlignment = (HorizontalAlignment)x9a1915e0a5a745b;
			break;
		case 912:
			x317be79405176667.RelativeHorizontalPosition = (RelativeHorizontalPosition)x9a1915e0a5a745b;
			break;
		case 913:
			x317be79405176667.VerticalAlignment = (VerticalAlignment)x9a1915e0a5a745b;
			break;
		case 914:
			x317be79405176667.RelativeVerticalPosition = (RelativeVerticalPosition)x9a1915e0a5a745b;
			break;
		case 915:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, x9a1915e0a5a745b);
			break;
		case 916:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, (x206d87dc07f8c9e2)x9a1915e0a5a745b);
			break;
		case 917:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, x9a1915e0a5a745b);
			break;
		case 920:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, x9a1915e0a5a745b);
			break;
		case 923:
		case 924:
		case 925:
		case 926:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, x195cb055715b526e.xfa7086ee0c6b6330(x9a1915e0a5a745b));
			break;
		case 927:
		case 928:
			x8cedcaa9a62c6e39.x3dc950453374051a($"Unsupported OfficeArt property 0x{x5ca6b6e12a4d9043.xea1e81378298fa81:x4}, ignored.");
			break;
		case 933:
			x8cedcaa9a62c6e39.x3dc950453374051a($"Unsupported OfficeArt property 0x{x5ca6b6e12a4d9043.xea1e81378298fa81:x4}, ignored.");
			break;
		case 937:
			x8cedcaa9a62c6e39.x3dc950453374051a($"Unsupported OfficeArt property 0x{x5ca6b6e12a4d9043.xea1e81378298fa81:x4}, ignored.");
			break;
		case 938:
			x8cedcaa9a62c6e39.x3dc950453374051a($"Unsupported OfficeArt property 0x{x5ca6b6e12a4d9043.xea1e81378298fa81:x4}, ignored.");
			break;
		case 959:
			xbd23e47977ecf67d(x317be79405176667, 953, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 954, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 955, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 956, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 957, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 958, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 959, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 944, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 945, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 946, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 947, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 948, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 950, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 951, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 952, x9a1915e0a5a745b);
			break;
		default:
			x99fcf901fef00ab9(x5ca6b6e12a4d9043.xea1e81378298fa81);
			break;
		case 904:
		case 918:
			break;
		}
	}

	private void x37c02644f397e517(xef8fbb0f103c0bb1 x5ca6b6e12a4d9043)
	{
		int x9a1915e0a5a745b = x5ca6b6e12a4d9043.x9a1915e0a5a745b7;
		int xea1e81378298fa = x5ca6b6e12a4d9043.xea1e81378298fa81;
		if (xea1e81378298fa == 1087)
		{
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, x9a1915e0a5a745b);
		}
		else
		{
			x99fcf901fef00ab9(x5ca6b6e12a4d9043.xea1e81378298fa81);
		}
	}

	private void x3337a3b14df78af2(xef8fbb0f103c0bb1 x5ca6b6e12a4d9043)
	{
		int x9a1915e0a5a745b = x5ca6b6e12a4d9043.x9a1915e0a5a745b7;
		switch (x5ca6b6e12a4d9043.xea1e81378298fa81)
		{
		case 1280:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, (x5e63bd35f6835a06)x9a1915e0a5a745b);
			break;
		case 1281:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, x9a1915e0a5a745b);
			break;
		case 1284:
		{
			xf7d2bc4cd6535591 xf7d2bc4cd6535593 = (xf7d2bc4cd6535591)x5ca6b6e12a4d9043;
			x580ae020787e37f2[] array2 = xf7d2bc4cd6535593.x82d97fa3a533f142();
			if (array2 != null)
			{
				x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, array2);
			}
			break;
		}
		case 1285:
		case 1286:
		case 1287:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, x9a1915e0a5a745b);
			break;
		case 1288:
		{
			xf7d2bc4cd6535591 xf7d2bc4cd6535592 = (xf7d2bc4cd6535591)x5ca6b6e12a4d9043;
			int[] array = xf7d2bc4cd6535592.xaf14ff6cf5955691();
			if (array != null)
			{
				x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, array);
			}
			break;
		}
		case 1289:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, x9a1915e0a5a745b);
			break;
		case 1343:
			xbd23e47977ecf67d(x317be79405176667, 1340, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 1341, x9a1915e0a5a745b);
			xbd23e47977ecf67d(x317be79405176667, 1342, x9a1915e0a5a745b);
			if (((uint)x9a1915e0a5a745b & (true ? 1u : 0u)) != 0)
			{
				x317be79405176667.WrapType = WrapType.Inline;
			}
			break;
		default:
			x99fcf901fef00ab9(x5ca6b6e12a4d9043.xea1e81378298fa81);
			break;
		}
	}

	private void x9bc07b057f5926f2(xef8fbb0f103c0bb1 x5ca6b6e12a4d9043)
	{
		int x9a1915e0a5a745b = x5ca6b6e12a4d9043.x9a1915e0a5a745b7;
		switch (x5ca6b6e12a4d9043.xea1e81378298fa81)
		{
		case 1728:
			x8cedcaa9a62c6e39.x3dc950453374051a($"Unsupported OfficeArt property 0x{x5ca6b6e12a4d9043.xea1e81378298fa81:x4}, ignored.");
			break;
		case 1791:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, x9a1915e0a5a745b);
			break;
		default:
			x99fcf901fef00ab9(x5ca6b6e12a4d9043.xea1e81378298fa81);
			break;
		}
	}

	private void x4efc87f607a9c606(xef8fbb0f103c0bb1 x5ca6b6e12a4d9043)
	{
		switch (x5ca6b6e12a4d9043.xea1e81378298fa81)
		{
		case 1792:
		{
			xb9d557c2e4fd83cd xb9d557c2e4fd83cd2 = (xb9d557c2e4fd83cd)x5ca6b6e12a4d9043;
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, xb9d557c2e4fd83cd2.xded2c9c41054f4dd);
			break;
		}
		case 1855:
		{
			x799c0394bad2756f x9a1915e0a5a745b = (x799c0394bad2756f)x5ca6b6e12a4d9043.x9a1915e0a5a745b7;
			if ((x9a1915e0a5a745b & x799c0394bad2756f.xa2f47110aebc3857) != 0)
			{
				x317be79405176667.x0817d5cde9e19bf6(1855, (x9a1915e0a5a745b & x799c0394bad2756f.x04253a50feaae58a) != 0);
			}
			break;
		}
		default:
			x99fcf901fef00ab9(x5ca6b6e12a4d9043.xea1e81378298fa81);
			break;
		}
	}

	private void x7e25ce646ac3d24c(xef8fbb0f103c0bb1 x5ca6b6e12a4d9043)
	{
		switch (x5ca6b6e12a4d9043.xea1e81378298fa81)
		{
		case 1921:
		case 1922:
		case 1923:
		case 1924:
		case 1925:
		case 1926:
		case 1927:
		case 1928:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, ((x7dacc4d0459cdf99)x5ca6b6e12a4d9043).xd2f68ee6f47e9dfb);
			break;
		case 1983:
			xbd23e47977ecf67d(x317be79405176667, 1981, x5ca6b6e12a4d9043.x9a1915e0a5a745b7);
			xbd23e47977ecf67d(x317be79405176667, 1980, x5ca6b6e12a4d9043.x9a1915e0a5a745b7);
			xbd23e47977ecf67d(x317be79405176667, 1982, x5ca6b6e12a4d9043.x9a1915e0a5a745b7);
			xbd23e47977ecf67d(x317be79405176667, 1983, x5ca6b6e12a4d9043.x9a1915e0a5a745b7);
			break;
		default:
			x99fcf901fef00ab9(x5ca6b6e12a4d9043.xea1e81378298fa81);
			break;
		}
	}

	private void x6cec198aa9f1df0b(xef8fbb0f103c0bb1 x5ca6b6e12a4d9043)
	{
		int x9a1915e0a5a745b = x5ca6b6e12a4d9043.x9a1915e0a5a745b7;
		switch (x5ca6b6e12a4d9043.xea1e81378298fa81)
		{
		case 1984:
		case 1985:
		case 1986:
		case 1987:
		case 1988:
		case 1989:
			x317be79405176667.x0817d5cde9e19bf6(x5ca6b6e12a4d9043.xea1e81378298fa81, x9a1915e0a5a745b);
			break;
		default:
			x99fcf901fef00ab9(x5ca6b6e12a4d9043.xea1e81378298fa81);
			break;
		}
	}

	private void x99fcf901fef00ab9(int x5b898c7a7c731e45)
	{
		x3dc950453374051a("Unknown OfficeArt property found 0x{0:x4}, ignored.", x5b898c7a7c731e45);
	}

	private static void xbd23e47977ecf67d(ShapeBase x5770cdefd8931aa9, int xba08ce632055a1d9, int xebf45bdcaa1fd1e1)
	{
		int num = x981769a9f803ee97.xfcd92fe8fb3b9dc7(xba08ce632055a1d9);
		int num2 = num << 16;
		if ((xebf45bdcaa1fd1e1 & num2) != 0)
		{
			bool flag = (xebf45bdcaa1fd1e1 & num) != 0;
			x5770cdefd8931aa9.x0817d5cde9e19bf6(xba08ce632055a1d9, flag);
		}
	}

	internal void x6210059f049f0d48(ShapeBase x5770cdefd8931aa9, xa5a62ee5bc98c41e xa5ea04da0b735c3b, xa5a62ee5bc98c41e x1f50e00a42ba64da, bool x2d304a31d2c4cd98)
	{
		x317be79405176667 = x5770cdefd8931aa9;
		xc93e07aa73eff702 = xa5ea04da0b735c3b;
		xa5fbce3914fd73c2 = x1f50e00a42ba64da;
		xc4e2003c69309d8c = 0;
		x670f074c32dcc617 = 0;
		x90e61c98253a38ee = 0;
		xd31a99b2bb9d950a = 0;
		x14e085880624cc84 = 0;
		xf83075fa0713ab57 = 0;
		xe2d7e0df6cd24a4d = 0;
		x8667a03db789e889 = 0;
		x3adbfebe6efecd72 = 0;
		xb591ae20372a536e = 0;
		x1c15dc641ace292c = 0;
		xdfdca9656f84302e = 0;
		xc875caeaab18a855 = 0;
		x3259b06c95a65ce7 = 0;
		xf4ae6a382caa01b2 = 0;
		xb1656fc70be6a527 = 0;
		x1c7273576dd6d9e3 = 0;
		x9fdf1c0356fe4631 = 0;
		x0c27af9f52c1a764 = 0;
		x2545696f645ca690 = 0;
		if (x2d304a31d2c4cd98)
		{
			xf4ae6a382caa01b2 = xc244c198e8d03992(xf4ae6a382caa01b2, x981769a9f803ee97.xfcd92fe8fb3b9dc7(831), xed7e1b20b1a14b86: true);
		}
		xf7125312c7ee115c xf7125312c7ee115c = x5770cdefd8931aa9.xf7125312c7ee115c;
		for (int i = 0; i < xf7125312c7ee115c.xd44988f225497f3a; i++)
		{
			int num = xf7125312c7ee115c.xf15263674eb297bb(i);
			object xbcea506a33cf = xf7125312c7ee115c.x6d3720b962bd3112(i);
			switch (num & -64)
			{
			case 0:
				xcf7a6694b0b373cb(num, xbcea506a33cf);
				break;
			case 64:
				xc57807e17cfa13d2(num, xbcea506a33cf);
				break;
			case 128:
				x636457dda93ec7a1(num, xbcea506a33cf);
				break;
			case 192:
				x4d69e4a647239da8(num, xbcea506a33cf);
				break;
			case 256:
				x27335b788ad093c5(num, xbcea506a33cf);
				break;
			case 320:
				xfd6e005351887f76(num, xbcea506a33cf);
				break;
			case 384:
				x1e8ae78ce4b0fda4(num, xbcea506a33cf);
				break;
			case 448:
				x25d0efbd7848eeb3(num, xbcea506a33cf);
				break;
			case 512:
				x96b1dbd43615bcc2(num, xbcea506a33cf);
				break;
			case 576:
				x7a5b8ef40a28c2da(num, xbcea506a33cf);
				break;
			case 640:
				x2d72f39789f4ea0d(num, xbcea506a33cf);
				break;
			case 704:
				x4c8829532c91e341(num, xbcea506a33cf);
				break;
			case 768:
				x1a2622a1866b8f97(num, xbcea506a33cf);
				break;
			case 832:
				xbf9e4ef3e3adf73c(num, xbcea506a33cf);
				break;
			case 896:
				xad015f0ee1de1139(num, xbcea506a33cf);
				break;
			case 1024:
				x61ed08dee0b22076(num, xbcea506a33cf);
				break;
			case 1280:
				x3e317d720ccf3cef(num, xbcea506a33cf);
				break;
			case 1728:
				xcdbd8c11285d9747(num, xbcea506a33cf);
				break;
			case 1984:
				x6ae29d42cfd28a78(num, xbcea506a33cf);
				break;
			case 4096:
				x03b704bb2df76cb7(num, xbcea506a33cf);
				break;
			case 1792:
				x8134ae42242fcd01(num, xbcea506a33cf);
				break;
			case 1920:
				x3c6b70afdb16685b(num, xbcea506a33cf);
				break;
			default:
				x99fcf901fef00ab9(num);
				break;
			}
		}
		xbe7a3ad59790a41d(xa5ea04da0b735c3b, 127, xc4e2003c69309d8c);
		xbe7a3ad59790a41d(xa5ea04da0b735c3b, 191, x670f074c32dcc617);
		xbe7a3ad59790a41d(xa5ea04da0b735c3b, 255, x90e61c98253a38ee);
		xbe7a3ad59790a41d(xa5ea04da0b735c3b, 383, xd31a99b2bb9d950a);
		xbe7a3ad59790a41d(xa5ea04da0b735c3b, 319, x14e085880624cc84);
		xbe7a3ad59790a41d(x1f50e00a42ba64da, 319, xf83075fa0713ab57);
		xbe7a3ad59790a41d(xa5ea04da0b735c3b, 447, xe2d7e0df6cd24a4d);
		xbe7a3ad59790a41d(x1f50e00a42ba64da, 447, x8667a03db789e889);
		xbe7a3ad59790a41d(xa5ea04da0b735c3b, 511, x3adbfebe6efecd72);
		xbe7a3ad59790a41d(x1f50e00a42ba64da, 511, xb591ae20372a536e);
		xbe7a3ad59790a41d(xa5ea04da0b735c3b, 575, x1c15dc641ace292c);
		xbe7a3ad59790a41d(xa5ea04da0b735c3b, 639, xdfdca9656f84302e);
		xbe7a3ad59790a41d(xa5ea04da0b735c3b, 703, xc875caeaab18a855);
		xbe7a3ad59790a41d(xa5ea04da0b735c3b, 767, x3259b06c95a65ce7);
		xbe7a3ad59790a41d(xa5ea04da0b735c3b, 831, xf4ae6a382caa01b2);
		xbe7a3ad59790a41d(xa5ea04da0b735c3b, 895, xb1656fc70be6a527);
		xbe7a3ad59790a41d(xa5ea04da0b735c3b, 959, x1c7273576dd6d9e3);
		xbe7a3ad59790a41d(x1f50e00a42ba64da, 959, x9fdf1c0356fe4631);
		xbe7a3ad59790a41d(x1f50e00a42ba64da, 1343, x0c27af9f52c1a764);
		xbe7a3ad59790a41d(xa5ea04da0b735c3b, 1983, x2545696f645ca690);
		x6db948ce85298c65(x5770cdefd8931aa9, xa5ea04da0b735c3b);
	}

	private static void x6db948ce85298c65(ShapeBase x5770cdefd8931aa9, xa5a62ee5bc98c41e xa5ea04da0b735c3b)
	{
		if (x5770cdefd8931aa9.ShapeType == ShapeType.CustomShape && !x5770cdefd8931aa9.xf7125312c7ee115c.x263d579af1d0d43f(325))
		{
			xf7d2bc4cd6535591 x46710263f0fedd = new xf7d2bc4cd6535591(325, new x08d932077485c285[0]);
			xa5ea04da0b735c3b.xd6b6ed77479ef68c(x46710263f0fedd);
		}
	}

	private void xcf7a6694b0b373cb(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		if (xba08ce632055a1d9 == 4)
		{
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, (int)xbcea506a33cf9111);
		}
		else
		{
			x99fcf901fef00ab9(xba08ce632055a1d9);
		}
	}

	private void xc57807e17cfa13d2(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		switch (xba08ce632055a1d9)
		{
		case 119:
		case 120:
		case 121:
		case 122:
		case 123:
		case 124:
		case 125:
		case 126:
		case 127:
			xc4e2003c69309d8c = xc244c198e8d03992(xc4e2003c69309d8c, x981769a9f803ee97.xfcd92fe8fb3b9dc7(xba08ce632055a1d9), (bool)xbcea506a33cf9111);
			break;
		default:
			x99fcf901fef00ab9(xba08ce632055a1d9);
			break;
		}
	}

	private void x636457dda93ec7a1(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		switch (xba08ce632055a1d9)
		{
		case 128:
		case 129:
		case 130:
		case 131:
		case 132:
		case 134:
		case 138:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, (int)xbcea506a33cf9111);
			break;
		case 133:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, (int)(TextBoxWrapMode)xbcea506a33cf9111);
			break;
		case 135:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, (int)(x69aaa2975337eae6)xbcea506a33cf9111);
			break;
		case 136:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, (int)(LayoutFlow)xbcea506a33cf9111);
			break;
		case 137:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, (int)(x05e2bbe26ab31299)xbcea506a33cf9111);
			break;
		case 139:
		case 140:
		case 141:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, (int)xbcea506a33cf9111);
			break;
		case 187:
		case 188:
		case 189:
		case 190:
		case 191:
			x670f074c32dcc617 = xc244c198e8d03992(x670f074c32dcc617, x981769a9f803ee97.xfcd92fe8fb3b9dc7(xba08ce632055a1d9), (bool)xbcea506a33cf9111);
			break;
		default:
			x99fcf901fef00ab9(xba08ce632055a1d9);
			break;
		}
	}

	private void x4d69e4a647239da8(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		switch (xba08ce632055a1d9)
		{
		case 192:
		case 193:
		case 197:
			xc93e07aa73eff702.x510567f1132da166(xba08ce632055a1d9, (string)xbcea506a33cf9111);
			break;
		case 194:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, (int)(TextPathAlignment)xbcea506a33cf9111);
			break;
		case 195:
		case 196:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, (int)xbcea506a33cf9111);
			break;
		case 240:
		case 241:
		case 242:
		case 243:
		case 244:
		case 245:
		case 246:
		case 247:
		case 248:
		case 249:
		case 250:
		case 251:
		case 252:
		case 253:
		case 254:
		case 255:
			x90e61c98253a38ee = xc244c198e8d03992(x90e61c98253a38ee, x981769a9f803ee97.xfcd92fe8fb3b9dc7(xba08ce632055a1d9), (bool)xbcea506a33cf9111);
			break;
		default:
			x99fcf901fef00ab9(xba08ce632055a1d9);
			break;
		}
	}

	private void x27335b788ad093c5(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		switch (xba08ce632055a1d9)
		{
		case 256:
		case 257:
		case 258:
		case 259:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, (int)xbcea506a33cf9111);
			break;
		case 263:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, x195cb055715b526e.x103636c839f725d7((x26d9ecb4bdf0456d)xbcea506a33cf9111));
			break;
		case 264:
		case 265:
		case 266:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, (int)xbcea506a33cf9111);
			break;
		case 267:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, (int)xbcea506a33cf9111);
			break;
		case 268:
		case 269:
		case 270:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, (int)xbcea506a33cf9111);
			break;
		case 282:
		case 283:
		case 285:
			xa5fbce3914fd73c2.x790922ad5280636d(xba08ce632055a1d9, (int)xbcea506a33cf9111);
			break;
		case 313:
			xf83075fa0713ab57 = xc244c198e8d03992(xf83075fa0713ab57, x981769a9f803ee97.xfcd92fe8fb3b9dc7(xba08ce632055a1d9), (bool)xbcea506a33cf9111);
			break;
		case 316:
		case 317:
		case 318:
		case 319:
			x14e085880624cc84 = xc244c198e8d03992(x14e085880624cc84, x981769a9f803ee97.xfcd92fe8fb3b9dc7(xba08ce632055a1d9), (bool)xbcea506a33cf9111);
			break;
		case 260:
		case 261:
			x317be79405176667.x0817d5cde9e19bf6(xba08ce632055a1d9, xbcea506a33cf9111);
			break;
		default:
			x99fcf901fef00ab9(xba08ce632055a1d9);
			break;
		}
	}

	private void xfd6e005351887f76(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		switch (xba08ce632055a1d9)
		{
		case 325:
		{
			xc93e07aa73eff702.x790922ad5280636d(324, 4);
			xf7d2bc4cd6535591 x46710263f0fedd7 = new xf7d2bc4cd6535591(xba08ce632055a1d9, (x08d932077485c285[])xbcea506a33cf9111);
			xc93e07aa73eff702.xd6b6ed77479ef68c(x46710263f0fedd7);
			break;
		}
		case 326:
		{
			xf7d2bc4cd6535591 x46710263f0fedd6 = new xf7d2bc4cd6535591(xba08ce632055a1d9, (x44f2b8bf33b16275[])xbcea506a33cf9111);
			xc93e07aa73eff702.xd6b6ed77479ef68c(x46710263f0fedd6);
			break;
		}
		case 327:
		case 328:
		case 329:
		case 330:
		case 331:
		case 332:
		case 333:
		case 334:
		case 335:
		case 336:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, (int)xbcea506a33cf9111);
			break;
		case 337:
		{
			xf7d2bc4cd6535591 x46710263f0fedd5 = new xf7d2bc4cd6535591(xba08ce632055a1d9, (x08d932077485c285[])xbcea506a33cf9111);
			xc93e07aa73eff702.xd6b6ed77479ef68c(x46710263f0fedd5);
			break;
		}
		case 338:
		{
			xf7d2bc4cd6535591 x46710263f0fedd4 = new xf7d2bc4cd6535591(xba08ce632055a1d9, (int[])xbcea506a33cf9111);
			xc93e07aa73eff702.xd6b6ed77479ef68c(x46710263f0fedd4);
			break;
		}
		case 339:
		case 340:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, (int)xbcea506a33cf9111);
			break;
		case 341:
		{
			xf7d2bc4cd6535591 x46710263f0fedd3 = new xf7d2bc4cd6535591(xba08ce632055a1d9, (x7efbe0a2dc0d335f[])xbcea506a33cf9111);
			xc93e07aa73eff702.xd6b6ed77479ef68c(x46710263f0fedd3);
			break;
		}
		case 342:
		{
			xf7d2bc4cd6535591 x46710263f0fedd2 = new xf7d2bc4cd6535591(xba08ce632055a1d9, (x40937ad35b1cf5f7[])xbcea506a33cf9111);
			xc93e07aa73eff702.xd6b6ed77479ef68c(x46710263f0fedd2);
			break;
		}
		case 343:
		{
			xf7d2bc4cd6535591 x46710263f0fedd = new xf7d2bc4cd6535591(xba08ce632055a1d9, (xbc9979937c838d75[])xbcea506a33cf9111);
			xc93e07aa73eff702.xd6b6ed77479ef68c(x46710263f0fedd);
			break;
		}
		case 344:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, (int)(x3b504d8c866583dc)xbcea506a33cf9111);
			break;
		case 378:
		case 379:
		case 380:
		case 381:
		case 382:
		case 383:
			xd31a99b2bb9d950a = xc244c198e8d03992(xd31a99b2bb9d950a, x981769a9f803ee97.xfcd92fe8fb3b9dc7(xba08ce632055a1d9), (bool)xbcea506a33cf9111);
			break;
		default:
			x99fcf901fef00ab9(xba08ce632055a1d9);
			break;
		}
	}

	private void x1e8ae78ce4b0fda4(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		switch (xba08ce632055a1d9)
		{
		case 384:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, (int)(xeba92971120d3e5a)xbcea506a33cf9111);
			break;
		case 385:
		case 387:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, x195cb055715b526e.x103636c839f725d7((x26d9ecb4bdf0456d)xbcea506a33cf9111));
			break;
		case 386:
		case 388:
		case 389:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, (int)xbcea506a33cf9111);
			break;
		case 391:
			xc93e07aa73eff702.x510567f1132da166(xba08ce632055a1d9, (string)xbcea506a33cf9111);
			break;
		case 392:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, (int)xbcea506a33cf9111);
			break;
		case 393:
		case 394:
		case 395:
		case 396:
		case 397:
		case 398:
		case 399:
		case 400:
		case 401:
		case 402:
		case 403:
		case 404:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, (int)xbcea506a33cf9111);
			break;
		case 405:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, (int)(xd56eb9f05f589be5)xbcea506a33cf9111);
			break;
		case 407:
		{
			xf7d2bc4cd6535591 x46710263f0fedd = new xf7d2bc4cd6535591(xba08ce632055a1d9, (x9fb6ff04f20b10d0[])xbcea506a33cf9111);
			xc93e07aa73eff702.xd6b6ed77479ef68c(x46710263f0fedd);
			break;
		}
		case 408:
		case 409:
		case 410:
		case 411:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, (int)xbcea506a33cf9111);
			break;
		case 412:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, (int)(xda3162397283dd69)xbcea506a33cf9111);
			break;
		case 414:
		case 415:
		case 416:
		case 418:
		case 419:
		case 420:
		case 421:
		case 422:
		case 423:
			xa5fbce3914fd73c2.x790922ad5280636d(xba08ce632055a1d9, (int)xbcea506a33cf9111);
			break;
		case 441:
		case 442:
			x8667a03db789e889 = xc244c198e8d03992(x8667a03db789e889, x981769a9f803ee97.xfcd92fe8fb3b9dc7(xba08ce632055a1d9), (bool)xbcea506a33cf9111);
			break;
		case 443:
		case 444:
		case 445:
		case 446:
		case 447:
			xe2d7e0df6cd24a4d = xc244c198e8d03992(xe2d7e0df6cd24a4d, x981769a9f803ee97.xfcd92fe8fb3b9dc7(xba08ce632055a1d9), (bool)xbcea506a33cf9111);
			break;
		default:
			x99fcf901fef00ab9(xba08ce632055a1d9);
			break;
		case 417:
			break;
		}
	}

	private void x25d0efbd7848eeb3(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		switch (xba08ce632055a1d9)
		{
		case 448:
		case 450:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, x195cb055715b526e.x103636c839f725d7((x26d9ecb4bdf0456d)xbcea506a33cf9111));
			break;
		case 449:
		case 451:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, (int)xbcea506a33cf9111);
			break;
		case 454:
			xc93e07aa73eff702.x510567f1132da166(xba08ce632055a1d9, (string)xbcea506a33cf9111);
			break;
		case 452:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, (int)(x6d4b101fe08bc376)xbcea506a33cf9111);
			break;
		case 455:
		case 456:
		case 457:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, (int)xbcea506a33cf9111);
			break;
		case 458:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, (int)(xd56eb9f05f589be5)xbcea506a33cf9111);
			break;
		case 459:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, (int)xbcea506a33cf9111);
			break;
		case 461:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, (int)(ShapeLineStyle)xbcea506a33cf9111);
			break;
		case 462:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, (int)(DashStyle)xbcea506a33cf9111);
			break;
		case 464:
		case 465:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, (int)(ArrowType)xbcea506a33cf9111);
			break;
		case 466:
		case 468:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, (int)(ArrowWidth)xbcea506a33cf9111);
			break;
		case 467:
		case 469:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, (int)(ArrowLength)xbcea506a33cf9111);
			break;
		case 470:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, (int)(JoinStyle)xbcea506a33cf9111);
			break;
		case 471:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, (int)(EndCap)xbcea506a33cf9111);
			break;
		case 460:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, (int)xbcea506a33cf9111);
			break;
		case 473:
		case 474:
		case 475:
		case 476:
		case 477:
		case 478:
		case 479:
		case 481:
		case 482:
			xa5fbce3914fd73c2.x790922ad5280636d(xba08ce632055a1d9, (int)xbcea506a33cf9111);
			break;
		case 503:
		case 504:
			xb591ae20372a536e = xc244c198e8d03992(xb591ae20372a536e, x981769a9f803ee97.xfcd92fe8fb3b9dc7(xba08ce632055a1d9), (bool)xbcea506a33cf9111);
			break;
		case 505:
		case 506:
		case 507:
		case 508:
		case 509:
		case 510:
		case 511:
			x3adbfebe6efecd72 = xc244c198e8d03992(x3adbfebe6efecd72, x981769a9f803ee97.xfcd92fe8fb3b9dc7(xba08ce632055a1d9), (bool)xbcea506a33cf9111);
			break;
		default:
			x99fcf901fef00ab9(xba08ce632055a1d9);
			break;
		}
	}

	private void x96b1dbd43615bcc2(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		switch (xba08ce632055a1d9)
		{
		case 512:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, (int)(x9a91f1235b1d8cac)xbcea506a33cf9111);
			break;
		case 513:
		case 514:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, x195cb055715b526e.x103636c839f725d7((x26d9ecb4bdf0456d)xbcea506a33cf9111));
			break;
		case 515:
		case 516:
		case 517:
		case 518:
		case 519:
		case 520:
		case 521:
		case 522:
		case 523:
		case 524:
		case 525:
		case 526:
		case 527:
		case 528:
		case 529:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, (int)xbcea506a33cf9111);
			break;
		case 530:
		case 531:
		case 532:
		case 534:
		case 535:
		case 536:
		case 538:
		case 539:
			xa5fbce3914fd73c2.x790922ad5280636d(xba08ce632055a1d9, (int)xbcea506a33cf9111);
			break;
		case 574:
		case 575:
			x1c15dc641ace292c = xc244c198e8d03992(x1c15dc641ace292c, x981769a9f803ee97.xfcd92fe8fb3b9dc7(xba08ce632055a1d9), (bool)xbcea506a33cf9111);
			break;
		default:
			x99fcf901fef00ab9(xba08ce632055a1d9);
			break;
		}
	}

	private void x7a5b8ef40a28c2da(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		switch (xba08ce632055a1d9)
		{
		case 576:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, (int)(x38c4fdd995570edc)xbcea506a33cf9111);
			break;
		case 577:
		case 578:
		case 579:
		case 580:
		case 581:
		case 582:
		case 583:
		case 584:
		case 585:
		case 586:
		case 587:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, (int)xbcea506a33cf9111);
			break;
		case 639:
			xdfdca9656f84302e = xc244c198e8d03992(xdfdca9656f84302e, x981769a9f803ee97.xfcd92fe8fb3b9dc7(xba08ce632055a1d9), (bool)xbcea506a33cf9111);
			break;
		default:
			x99fcf901fef00ab9(xba08ce632055a1d9);
			break;
		}
	}

	private void x2d72f39789f4ea0d(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		switch (xba08ce632055a1d9)
		{
		case 640:
		case 641:
		case 642:
		case 643:
		case 644:
		case 645:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, (int)xbcea506a33cf9111);
			break;
		case 646:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, (int)(x8755a9e2fca0996e)xbcea506a33cf9111);
			break;
		case 647:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, x195cb055715b526e.x103636c839f725d7((x26d9ecb4bdf0456d)xbcea506a33cf9111));
			break;
		case 648:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, (int)xbcea506a33cf9111);
			break;
		case 649:
		case 650:
		case 651:
		case 653:
			xa5fbce3914fd73c2.x790922ad5280636d(xba08ce632055a1d9, (int)xbcea506a33cf9111);
			break;
		case 700:
		case 701:
		case 702:
		case 703:
			xc875caeaab18a855 = xc244c198e8d03992(xc875caeaab18a855, x981769a9f803ee97.xfcd92fe8fb3b9dc7(xba08ce632055a1d9), (bool)xbcea506a33cf9111);
			break;
		default:
			x99fcf901fef00ab9(xba08ce632055a1d9);
			break;
		}
	}

	private void x4c8829532c91e341(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		switch (xba08ce632055a1d9)
		{
		case 704:
		case 705:
		case 706:
		case 707:
		case 708:
		case 709:
		case 710:
		case 711:
		case 712:
		case 714:
		case 715:
		case 716:
		case 717:
		case 718:
		case 719:
		case 720:
		case 721:
		case 722:
		case 723:
		case 724:
		case 725:
		case 726:
		case 727:
		case 728:
		case 729:
		case 730:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, (int)xbcea506a33cf9111);
			break;
		case 713:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, (int)(xb156f8ae92094cbb)xbcea506a33cf9111);
			break;
		case 763:
		case 764:
		case 765:
		case 766:
		case 767:
			x3259b06c95a65ce7 = xc244c198e8d03992(x3259b06c95a65ce7, x981769a9f803ee97.xfcd92fe8fb3b9dc7(xba08ce632055a1d9), (bool)xbcea506a33cf9111);
			break;
		default:
			x99fcf901fef00ab9(xba08ce632055a1d9);
			break;
		}
	}

	private void x1a2622a1866b8f97(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		switch (xba08ce632055a1d9)
		{
		case 771:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, (int)(x5b865d49b2c8440d)xbcea506a33cf9111);
			break;
		case 772:
		case 773:
		case 774:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, (int)(x17abde5b32777816)xbcea506a33cf9111);
			break;
		case 777:
			xa5fbce3914fd73c2.x790922ad5280636d(xba08ce632055a1d9, (int)(xc586cb26186123d4)xbcea506a33cf9111);
			break;
		case 778:
			xa5fbce3914fd73c2.x790922ad5280636d(xba08ce632055a1d9, (int)(x76b42e09224005a0)xbcea506a33cf9111);
			break;
		case 779:
			xa5fbce3914fd73c2.x790922ad5280636d(xba08ce632055a1d9, (int)xbcea506a33cf9111);
			break;
		case 780:
			xc93e07aa73eff702.xd6b6ed77479ef68c(new x35c861f511323d4d(780, (byte[])xbcea506a33cf9111));
			break;
		case 826:
		case 827:
		case 828:
		case 830:
			xf4ae6a382caa01b2 = xc244c198e8d03992(xf4ae6a382caa01b2, x981769a9f803ee97.xfcd92fe8fb3b9dc7(xba08ce632055a1d9), (bool)xbcea506a33cf9111);
			break;
		default:
			x99fcf901fef00ab9(xba08ce632055a1d9);
			break;
		}
	}

	private void xbf9e4ef3e3adf73c(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		switch (xba08ce632055a1d9)
		{
		case 832:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, (int)(x9cda3ea77eff6f0d)xbcea506a33cf9111);
			break;
		case 834:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, (int)(x637e6856119e5fb2)xbcea506a33cf9111);
			break;
		case 835:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, (int)(xceb84165dedc0c2d)xbcea506a33cf9111);
			break;
		case 833:
		case 836:
		case 837:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, (int)xbcea506a33cf9111);
			break;
		case 889:
		case 890:
		case 891:
		case 892:
		case 893:
		case 894:
		case 895:
			xb1656fc70be6a527 = xc244c198e8d03992(xb1656fc70be6a527, x981769a9f803ee97.xfcd92fe8fb3b9dc7(xba08ce632055a1d9), (bool)xbcea506a33cf9111);
			break;
		default:
			x99fcf901fef00ab9(xba08ce632055a1d9);
			break;
		}
	}

	private void xad015f0ee1de1139(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		switch (xba08ce632055a1d9)
		{
		case 896:
		case 897:
		case 909:
		{
			string xbcea506a33cf9113 = (string)xbcea506a33cf9111;
			if (x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf9113))
			{
				xc93e07aa73eff702.x510567f1132da166(xba08ce632055a1d9, xbcea506a33cf9113);
			}
			break;
		}
		case 910:
		case 919:
		case 922:
		{
			string xbcea506a33cf9112 = (string)xbcea506a33cf9111;
			if (x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf9112))
			{
				xa5fbce3914fd73c2.x510567f1132da166(xba08ce632055a1d9, xbcea506a33cf9112);
			}
			break;
		}
		case 898:
			if (x0d299f323d241756.x5959bccb67bbf051(x317be79405176667.HRef))
			{
				x9bd10249890baaef x46710263f0fedd2 = new x9bd10249890baaef(xba08ce632055a1d9, x317be79405176667.x8edafc3cf6e5431a, x317be79405176667.xffd5ab6c569c488d, x317be79405176667.Target);
				xc93e07aa73eff702.xd6b6ed77479ef68c(x46710263f0fedd2);
			}
			break;
		case 899:
		{
			xf7d2bc4cd6535591 x46710263f0fedd = new xf7d2bc4cd6535591(xba08ce632055a1d9, (x08d932077485c285[])xbcea506a33cf9111);
			xc93e07aa73eff702.xd6b6ed77479ef68c(x46710263f0fedd);
			break;
		}
		case 900:
		case 901:
		case 902:
		case 903:
			xc93e07aa73eff702.x790922ad5280636d(xba08ce632055a1d9, (int)xbcea506a33cf9111);
			break;
		case 911:
			xa5fbce3914fd73c2.x790922ad5280636d(xba08ce632055a1d9, (int)(HorizontalAlignment)xbcea506a33cf9111);
			break;
		case 912:
			xa5fbce3914fd73c2.x790922ad5280636d(xba08ce632055a1d9, (int)(RelativeHorizontalPosition)xbcea506a33cf9111);
			break;
		case 913:
		{
			VerticalAlignment verticalAlignment = (VerticalAlignment)xbcea506a33cf9111;
			if (verticalAlignment == VerticalAlignment.Inline)
			{
				verticalAlignment = VerticalAlignment.Top;
			}
			xa5fbce3914fd73c2.x790922ad5280636d(xba08ce632055a1d9, (int)verticalAlignment);
			break;
		}
		case 914:
			xa5fbce3914fd73c2.x790922ad5280636d(xba08ce632055a1d9, (int)(RelativeVerticalPosition)xbcea506a33cf9111);
			break;
		case 915:
			xa5fbce3914fd73c2.x790922ad5280636d(xba08ce632055a1d9, (int)xbcea506a33cf9111);
			break;
		case 916:
			xa5fbce3914fd73c2.x790922ad5280636d(xba08ce632055a1d9, (int)(x206d87dc07f8c9e2)xbcea506a33cf9111);
			break;
		case 920:
			xa5fbce3914fd73c2.x790922ad5280636d(xba08ce632055a1d9, (int)xbcea506a33cf9111);
			break;
		case 944:
		case 945:
		case 946:
		case 947:
		case 950:
		case 951:
		case 952:
			x9fdf1c0356fe4631 = xc244c198e8d03992(x9fdf1c0356fe4631, x981769a9f803ee97.xfcd92fe8fb3b9dc7(xba08ce632055a1d9), (bool)xbcea506a33cf9111);
			break;
		case 948:
		{
			bool flag = (bool)xbcea506a33cf9111;
			x9fdf1c0356fe4631 = xc244c198e8d03992(x9fdf1c0356fe4631, x981769a9f803ee97.xfcd92fe8fb3b9dc7(xba08ce632055a1d9), flag);
			if (flag)
			{
				xa5fbce3914fd73c2.x790922ad5280636d(917, x4574ea26106f0edb.x88bf16f2386d633e(x317be79405176667.Height));
				xa5fbce3914fd73c2.x790922ad5280636d(918, x4574ea26106f0edb.x88bf16f2386d633e(x317be79405176667.Width));
			}
			break;
		}
		case 953:
		case 955:
		case 956:
		case 957:
		case 958:
		case 959:
			x1c7273576dd6d9e3 = xc244c198e8d03992(x1c7273576dd6d9e3, x981769a9f803ee97.xfcd92fe8fb3b9dc7(xba08ce632055a1d9), (bool)xbcea506a33cf9111);
			break;
		case 954:
			if (!x317be79405176667.IsInline)
			{
				x1c7273576dd6d9e3 = xc244c198e8d03992(x1c7273576dd6d9e3, x981769a9f803ee97.xfcd92fe8fb3b9dc7(xba08ce632055a1d9), (bool)xbcea506a33cf9111);
			}
			break;
		default:
			x99fcf901fef00ab9(xba08ce632055a1d9);
			break;
		case 923:
		case 924:
		case 925:
		case 926:
			break;
		}
	}

	private void x61ed08dee0b22076(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		if (xba08ce632055a1d9 == 1087)
		{
			xa5fbce3914fd73c2.x790922ad5280636d(xba08ce632055a1d9, (int)xbcea506a33cf9111);
		}
		else
		{
			x99fcf901fef00ab9(xba08ce632055a1d9);
		}
	}

	private void x3e317d720ccf3cef(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		switch (xba08ce632055a1d9)
		{
		case 1280:
		{
			x5e63bd35f6835a06 x5e63bd35f6835a = (x5e63bd35f6835a06)xbcea506a33cf9111;
			if (x5e63bd35f6835a != x5e63bd35f6835a06.x20422d9e11f237e1)
			{
				xa5fbce3914fd73c2.x790922ad5280636d(xba08ce632055a1d9, (int)x5e63bd35f6835a);
			}
			break;
		}
		case 1281:
			xa5fbce3914fd73c2.x790922ad5280636d(xba08ce632055a1d9, (int)xbcea506a33cf9111);
			break;
		case 1284:
		{
			xf7d2bc4cd6535591 x46710263f0fedd2 = new xf7d2bc4cd6535591(xba08ce632055a1d9, (x580ae020787e37f2[])xbcea506a33cf9111);
			xa5fbce3914fd73c2.xd6b6ed77479ef68c(x46710263f0fedd2);
			break;
		}
		case 1285:
		case 1286:
		case 1287:
			xa5fbce3914fd73c2.x790922ad5280636d(xba08ce632055a1d9, (int)xbcea506a33cf9111);
			break;
		case 1288:
		{
			xf7d2bc4cd6535591 x46710263f0fedd = new xf7d2bc4cd6535591(xba08ce632055a1d9, (int[])xbcea506a33cf9111);
			xa5fbce3914fd73c2.xd6b6ed77479ef68c(x46710263f0fedd);
			break;
		}
		case 1289:
			xa5fbce3914fd73c2.x790922ad5280636d(xba08ce632055a1d9, (int)xbcea506a33cf9111);
			break;
		case 1340:
		case 1341:
		case 1342:
			x0c27af9f52c1a764 = xc244c198e8d03992(x0c27af9f52c1a764, x981769a9f803ee97.xfcd92fe8fb3b9dc7(xba08ce632055a1d9), (bool)xbcea506a33cf9111);
			break;
		default:
			x99fcf901fef00ab9(xba08ce632055a1d9);
			break;
		}
	}

	private void xcdbd8c11285d9747(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		if (xba08ce632055a1d9 == 1791)
		{
			xa5fbce3914fd73c2.x790922ad5280636d(xba08ce632055a1d9, (int)xbcea506a33cf9111);
		}
		else
		{
			x99fcf901fef00ab9(xba08ce632055a1d9);
		}
	}

	private void x6ae29d42cfd28a78(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		switch (xba08ce632055a1d9)
		{
		case 1984:
		case 1985:
		case 1986:
		case 1987:
		case 1988:
		case 1989:
			xa5fbce3914fd73c2.x790922ad5280636d(xba08ce632055a1d9, (int)xbcea506a33cf9111);
			break;
		default:
			x99fcf901fef00ab9(xba08ce632055a1d9);
			break;
		}
	}

	private void x03b704bb2df76cb7(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		switch (xba08ce632055a1d9)
		{
		case 4097:
			if (x317be79405176667.xac9731dd322f2036)
			{
				x0c27af9f52c1a764 = xc244c198e8d03992(x0c27af9f52c1a764, 1, xed7e1b20b1a14b86: true);
			}
			break;
		case 4125:
			if (!x317be79405176667.IsGroup)
			{
				xc93e07aa73eff702.x790922ad5280636d(320, (int)xbcea506a33cf9111);
			}
			break;
		case 4126:
			if (!x317be79405176667.IsGroup)
			{
				xc93e07aa73eff702.x790922ad5280636d(321, (int)xbcea506a33cf9111);
			}
			break;
		case 4127:
			if (!x317be79405176667.IsGroup)
			{
				xc93e07aa73eff702.x790922ad5280636d(322, x317be79405176667.x06c65daad0c0656c + (int)xbcea506a33cf9111);
			}
			break;
		case 4128:
			if (!x317be79405176667.IsGroup)
			{
				xc93e07aa73eff702.x790922ad5280636d(323, x317be79405176667.x399bb78ac51a4081 + (int)xbcea506a33cf9111);
			}
			break;
		case 4102:
		{
			int xbcea506a33cf9115 = x1c92b96361791977((byte[])xbcea506a33cf9111, x10884bb8036bcee0.x1a23317d325de634);
			xc93e07aa73eff702.x790922ad5280636d(260, xbcea506a33cf9115);
			break;
		}
		case 4104:
		{
			string xbcea506a33cf9116 = (string)xbcea506a33cf9111;
			if (x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf9116))
			{
				xc93e07aa73eff702.x510567f1132da166(261, xbcea506a33cf9116);
				int num = 2;
				Shape shape2 = (Shape)x317be79405176667;
				if (shape2.ImageData.IsLink)
				{
					num |= 8;
				}
				if (shape2.ImageData.IsLinkOnly)
				{
					num |= 4;
				}
				xc93e07aa73eff702.x790922ad5280636d(262, num);
			}
			break;
		}
		case 4103:
		{
			string xbcea506a33cf9114 = (string)xbcea506a33cf9111;
			if (x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf9114))
			{
				Shape shape = (Shape)x317be79405176667;
				if (!shape.ImageData.IsLink)
				{
					xc93e07aa73eff702.x510567f1132da166(261, (string)xbcea506a33cf9111);
				}
			}
			break;
		}
		case 4106:
			x0e6159e2ccae0f72(xa5fbce3914fd73c2, 923, (Border)xbcea506a33cf9111);
			break;
		case 4108:
			x0e6159e2ccae0f72(xa5fbce3914fd73c2, 925, (Border)xbcea506a33cf9111);
			break;
		case 4107:
			x0e6159e2ccae0f72(xa5fbce3914fd73c2, 924, (Border)xbcea506a33cf9111);
			break;
		case 4109:
			x0e6159e2ccae0f72(xa5fbce3914fd73c2, 926, (Border)xbcea506a33cf9111);
			break;
		case 4110:
		{
			x10884bb8036bcee0 x23d47efd6f338d0f2 = (x10884bb8036bcee0)x317be79405176667.xf7125312c7ee115c.xfe91eeeafcb3026a(4121);
			int xbcea506a33cf9113 = x1c92b96361791977((byte[])xbcea506a33cf9111, x23d47efd6f338d0f2);
			xc93e07aa73eff702.x790922ad5280636d(453, xbcea506a33cf9113);
			break;
		}
		case 4111:
		{
			x10884bb8036bcee0 x23d47efd6f338d0f = (x10884bb8036bcee0)x317be79405176667.xf7125312c7ee115c.xfe91eeeafcb3026a(4122);
			int xbcea506a33cf9112 = x1c92b96361791977((byte[])xbcea506a33cf9111, x23d47efd6f338d0f);
			xc93e07aa73eff702.x790922ad5280636d(390, xbcea506a33cf9112);
			break;
		}
		default:
			x99fcf901fef00ab9(xba08ce632055a1d9);
			break;
		case 1984:
		case 1985:
		case 1986:
		case 1987:
		case 1988:
		case 1989:
		case 4096:
		case 4098:
		case 4099:
		case 4112:
		case 4113:
		case 4114:
		case 4115:
		case 4116:
		case 4117:
		case 4118:
		case 4119:
		case 4120:
		case 4121:
		case 4122:
		case 4124:
		case 4129:
		case 4130:
		case 4131:
		case 4132:
		case 4140:
		case 4141:
		case 4142:
		case 4143:
		case 4144:
		case 4145:
		case 4146:
		case 4154:
		case 4155:
			break;
		}
	}

	private void x8134ae42242fcd01(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		switch (xba08ce632055a1d9)
		{
		case 1792:
		{
			xc93e07aa73eff702.xd6b6ed77479ef68c(new xb9d557c2e4fd83cd(1792, (byte[])xbcea506a33cf9111));
			x799c0394bad2756f x799c0394bad2756f2 = x799c0394bad2756f.xce8660972d795f80 | x799c0394bad2756f.x5d79b9170e821779 | x799c0394bad2756f.xa2f47110aebc3857;
			if (x317be79405176667.x04253a50feaae58a)
			{
				x799c0394bad2756f2 |= x799c0394bad2756f.x04253a50feaae58a;
			}
			xc93e07aa73eff702.x790922ad5280636d(1855, (int)x799c0394bad2756f2);
			break;
		}
		}
	}

	private void x3c6b70afdb16685b(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		switch (xba08ce632055a1d9)
		{
		case 1921:
		case 1922:
		case 1923:
		case 1924:
		case 1925:
		case 1926:
		case 1927:
		case 1928:
			xc93e07aa73eff702.x510567f1132da166(xba08ce632055a1d9, (string)xbcea506a33cf9111);
			break;
		case 1980:
		case 1981:
		case 1982:
		case 1983:
			x2545696f645ca690 = xc244c198e8d03992(x2545696f645ca690, x981769a9f803ee97.xfcd92fe8fb3b9dc7(xba08ce632055a1d9), (bool)xbcea506a33cf9111);
			break;
		}
	}

	private static void x0e6159e2ccae0f72(xa5a62ee5bc98c41e xa7606273ae5202b7, int xbec3668789aad87e, Border x14cf9593b86ecbaa)
	{
		if (!x14cf9593b86ecbaa.Equals(Border.x45260ad4b94166f2))
		{
			xa7606273ae5202b7.x790922ad5280636d(xbec3668789aad87e, x195cb055715b526e.x103636c839f725d7(x14cf9593b86ecbaa.x63b1a7c31a962459));
		}
	}

	private xd959c7c7ca733332 x590497a2b838b652(int xc8f6fc994c5e1a4f)
	{
		if (x8cedcaa9a62c6e39.x1824eec534cbacf7 == null)
		{
			x8cedcaa9a62c6e39.x3dc950453374051a("Invalid OfficeArt blip reference, ignored.");
			return null;
		}
		xfbb3f4be330f4086 xfbb3f4be330f4087 = x8cedcaa9a62c6e39.x1824eec534cbacf7.x590497a2b838b652(xc8f6fc994c5e1a4f);
		if (xfbb3f4be330f4087 != null)
		{
			return xfbb3f4be330f4087.x90c6e45466e5b849;
		}
		x8cedcaa9a62c6e39.x3dc950453374051a("Invalid OfficeArt blip reference, ignored.");
		return null;
	}

	private int x1c92b96361791977(byte[] x43e181e083db6cdf, x10884bb8036bcee0 x23d47efd6f338d0f)
	{
		Guid guid = x66cdafe77e7aa42b.x8341ba999ffebb91(x43e181e083db6cdf);
		object obj = x696ed17637971453[guid];
		if (x317be79405176667.IsInline || obj == null)
		{
			xd959c7c7ca733332 xd959c7c7ca733333;
			switch (xdd1b8f14cc8ba86d.x22bfb60fc9ca9282(x43e181e083db6cdf))
			{
			case xfe2ff3c162b47c70.x796ab23ce57ee1e0:
			case xfe2ff3c162b47c70.x6339cdb9e2b512c7:
			case xfe2ff3c162b47c70.xc2746d872ce402e9:
				xd959c7c7ca733333 = new x681808f408a7efac(guid, x43e181e083db6cdf, x23d47efd6f338d0f);
				break;
			case xfe2ff3c162b47c70.xd69df86e2a88ddb2:
			case xfe2ff3c162b47c70.xb5fe04c34562f438:
			case xfe2ff3c162b47c70.x26c36dd85013b919:
				xd959c7c7ca733333 = new x05e3661630595852(guid, x43e181e083db6cdf);
				break;
			default:
				throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("oeibmgpboggchbncjfedjgldofceafjeleafjfhfheofdefgmplgiedhkekhldbifdiipdpikofjadnjbdekcclkfcclacjlinpllbhmbcombcfnjbmnkadokbkogbbpamhpfappppfajanajpdbplkb", 1839994880)));
			}
			xfbb3f4be330f4086 xfbb3f4be330f4087 = new xfbb3f4be330f4086();
			xfbb3f4be330f4087.x1ea60bde2b5d0d28.x9834ddb0e0bd5996 = (int)xd959c7c7ca733333.x688d6f6524ba3c8b;
			xfbb3f4be330f4087.xff0ea9d348c6d812 = (int)((xd959c7c7ca733333.x688d6f6524ba3c8b != ImageType.Pict) ? xd959c7c7ca733333.x688d6f6524ba3c8b : ImageType.Wmf);
			xfbb3f4be330f4087.x3df0b33d2192d410 = (int)xd959c7c7ca733333.x688d6f6524ba3c8b;
			xfbb3f4be330f4087.x8601da8f676be405 = xd959c7c7ca733333.x0217cda8370c1f17.ToByteArray();
			xfbb3f4be330f4087.xffe521cc76054baf = 255;
			xfbb3f4be330f4087.xbbb4d81f327c96e5 = 1;
			xfbb3f4be330f4087.xcb09944671f5a4fd = x8cedcaa9a62c6e39.x1824eec534cbacf7 is x7036f104bc5c45f0;
			xfbb3f4be330f4087.x90c6e45466e5b849 = xd959c7c7ca733333;
			int num;
			if (x696ed17637971453[guid] != null)
			{
				num = (int)x696ed17637971453[guid];
				x8cedcaa9a62c6e39.x1824eec534cbacf7.xcfcc704945beca71(xfbb3f4be330f4087);
			}
			else
			{
				num = x8cedcaa9a62c6e39.x1824eec534cbacf7.xcfcc704945beca71(xfbb3f4be330f4087);
				x696ed17637971453.Add(guid, num);
			}
			return num;
		}
		int num2 = (int)obj;
		xfbb3f4be330f4086 xfbb3f4be330f4088 = x8cedcaa9a62c6e39.x1824eec534cbacf7.x590497a2b838b652(num2);
		xfbb3f4be330f4088.xbbb4d81f327c96e5++;
		return num2;
	}

	private void x3dc950453374051a(string xc2358fbac7da3d45, params object[] xce8d8c7e3c2c2426)
	{
		x8cedcaa9a62c6e39.x3dc950453374051a(string.Format(xc2358fbac7da3d45, xce8d8c7e3c2c2426));
	}

	private static void xbe7a3ad59790a41d(xa5a62ee5bc98c41e xa5ea04da0b735c3b, int xba08ce632055a1d9, int xbcea506a33cf9111)
	{
		if ((xbcea506a33cf9111 & 0xFFFF0000u) != 0)
		{
			xa5ea04da0b735c3b.x790922ad5280636d(xba08ce632055a1d9, xbcea506a33cf9111);
		}
	}

	private static int xc244c198e8d03992(int x82cc274dec6f4f4c, int x95031426e7695b13, bool xed7e1b20b1a14b86)
	{
		int num = x26000ce44ebda9ea.x5ef51986c8da8183(x82cc274dec6f4f4c, x95031426e7695b13, xed7e1b20b1a14b86);
		int num2 = x95031426e7695b13 << 16;
		return num | num2;
	}
}
