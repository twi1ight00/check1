using System;
using Aspose.Words;
using Aspose.Words.Fonts;
using x13f1efc79617a47b;
using x2697283ff424107e;
using x28925c9b27b37a46;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;
using x7c4557e104065fc9;
using xf989f31a236ff98c;

namespace xce0136f05681c5e9;

internal class x4bff9bc5b8587d95
{
	private x4bff9bc5b8587d95()
	{
	}

	internal static xa3fc7dcdc8182ff6 x6ac3f9aa1b303bd0(xac4d96a62eaba39e x1a84eefd5d3e114a, bool xa4427eaecb321cf4, double x966a98c86f220d2e, bool x09585c411b119c0d, bool x1ebf5501f9a725fb, x4ef6b4f19b033b48 x1458787a87172e23, bool x37964b8beac948a3, IWarningCallback x57fef5933b41d0c2)
	{
		xa3fc7dcdc8182ff6 xa3fc7dcdc8182ff = new xa3fc7dcdc8182ff6();
		int num = 0;
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		double num2 = 0.0;
		bool flag4 = false;
		double num3 = 0.0;
		bool flag5 = false;
		x84bbacdc1fc0efd2 x84bbacdc1fc0efd = new x84bbacdc1fc0efd2(0, LineSpacingRule.AtLeast);
		bool flag6 = false;
		bool flag7 = (bool)x1a84eefd5d3e114a.xc3cc338a59c5293b(1560);
		bool flag8 = x1458787a87172e23 != x4ef6b4f19b033b48.x526d6c6f824cda87;
		Border border = null;
		Border border2 = null;
		Border border3 = null;
		int xff9e36c01267daf = x1a84eefd5d3e114a.xff9e36c01267daf0;
		for (int i = 0; i < xff9e36c01267daf; i++)
		{
			x1a84eefd5d3e114a.xee440186ba45615a(i, out var xba08ce632055a1d, out var xbcea506a33cf);
			switch (xba08ce632055a1d)
			{
			case 1020:
			{
				ParagraphAlignment paragraphAlignment = (ParagraphAlignment)xbcea506a33cf;
				if (paragraphAlignment == ParagraphAlignment.Left && flag7)
				{
					paragraphAlignment = ParagraphAlignment.Right;
				}
				if (paragraphAlignment != 0 || xa4427eaecb321cf4)
				{
					xa3fc7dcdc8182ff.xf0ca15702ca7498c("text-align", x495fdb45f3d92b70.x7f90501c33a75aa6(paragraphAlignment));
				}
				break;
			}
			case 1040:
			{
				bool flag11 = (bool)xbcea506a33cf;
				if (flag11 || xa4427eaecb321cf4)
				{
					xa3fc7dcdc8182ff.xf0ca15702ca7498c("page-break-inside", flag11 ? "avoid" : "auto");
				}
				break;
			}
			case 1050:
			{
				bool flag12 = (bool)xbcea506a33cf;
				if (flag12 || xa4427eaecb321cf4)
				{
					xa3fc7dcdc8182ff.xf0ca15702ca7498c("page-break-after", flag12 ? "avoid" : "auto");
				}
				break;
			}
			case 1060:
			{
				bool flag10 = (bool)xbcea506a33cf;
				if (flag10 || xa4427eaecb321cf4)
				{
					xa3fc7dcdc8182ff.xf0ca15702ca7498c("page-break-before", flag10 ? "always" : "auto");
				}
				break;
			}
			case 1120:
				num = (int)xbcea506a33cf;
				break;
			case 1150:
				flag = true;
				break;
			case 1160:
				flag2 = true;
				break;
			case 1170:
				flag3 = true;
				break;
			case 1650:
				x84bbacdc1fc0efd = (x84bbacdc1fc0efd2)xbcea506a33cf;
				flag6 = true;
				break;
			case 1200:
				num2 = x4574ea26106f0edb.x0e1fdb362561ddb2((int)xbcea506a33cf);
				flag4 = true;
				break;
			case 1220:
				num3 = x4574ea26106f0edb.x0e1fdb362561ddb2((int)xbcea506a33cf);
				flag5 = true;
				break;
			case 1390:
				border3 = (Border)xbcea506a33cf;
				if ((x1458787a87172e23 == x4ef6b4f19b033b48.x763219a89d453f55 || x1458787a87172e23 == x4ef6b4f19b033b48.x853425d3a03042f1) && !border3.xa157de8185757b11)
				{
					x30ff4cedcf2b2374.xad56ef88b1fac115(xa3fc7dcdc8182ff, border3, BorderType.Bottom, x82fdb3b4231a1374: false);
				}
				break;
			case 1350:
				border2 = (Border)xbcea506a33cf;
				if (!flag8 && !border2.xa157de8185757b11)
				{
					x30ff4cedcf2b2374.xad56ef88b1fac115(xa3fc7dcdc8182ff, border2, BorderType.Top, x82fdb3b4231a1374: true);
				}
				break;
			case 1360:
			{
				Border border5 = (Border)xbcea506a33cf;
				if (flag8)
				{
					x30ff4cedcf2b2374.x9a036a30e27cef5e(xa3fc7dcdc8182ff, border5, BorderType.Left);
				}
				else if (!border5.xa157de8185757b11)
				{
					x30ff4cedcf2b2374.xad56ef88b1fac115(xa3fc7dcdc8182ff, border5, BorderType.Left, x82fdb3b4231a1374: true);
				}
				break;
			}
			case 1370:
				border = (Border)xbcea506a33cf;
				if (!flag8 && !border.xa157de8185757b11)
				{
					x30ff4cedcf2b2374.xad56ef88b1fac115(xa3fc7dcdc8182ff, border, BorderType.Bottom, x82fdb3b4231a1374: true);
				}
				break;
			case 1380:
			{
				Border border4 = (Border)xbcea506a33cf;
				if (flag8)
				{
					x30ff4cedcf2b2374.x9a036a30e27cef5e(xa3fc7dcdc8182ff, border4, BorderType.Right);
				}
				else if (!border4.xa157de8185757b11)
				{
					x30ff4cedcf2b2374.xad56ef88b1fac115(xa3fc7dcdc8182ff, border4, BorderType.Right, x82fdb3b4231a1374: true);
				}
				break;
			}
			case 1460:
			{
				Shading shading = (Shading)xbcea506a33cf;
				if (!shading.xa157de8185757b11)
				{
					x4ce5248b91d2fbf7.xdd58192800f83cee(shading, xa3fc7dcdc8182ff);
				}
				break;
			}
			case 1470:
			{
				bool flag9 = (bool)xbcea506a33cf;
				if (!flag9 || xa4427eaecb321cf4)
				{
					int num4 = (flag9 ? 2 : 0);
					xa3fc7dcdc8182ff.x0973ec6da4c01c5e("widows", num4);
					xa3fc7dcdc8182ff.x0973ec6da4c01c5e("orphans", num4);
				}
				break;
			}
			case 1480:
			{
				TextOrientation xf65758d54b79fc7a = (TextOrientation)xbcea506a33cf;
				string text = x015eb412e40a664b.x142e13c6dfd73e82(xf65758d54b79fc7a);
				if (text != "lr-tb" || xa4427eaecb321cf4)
				{
					xa3fc7dcdc8182ff.xf0ca15702ca7498c("writing-mode", text);
				}
				break;
			}
			}
		}
		if (flag8 && border2 != null && border3 != null && (x1458787a87172e23 == x4ef6b4f19b033b48.x853425d3a03042f1 || border3.IsVisible))
		{
			x30ff4cedcf2b2374.x9a036a30e27cef5e(xa3fc7dcdc8182ff, border2, BorderType.Top);
		}
		double num5 = x4574ea26106f0edb.x0e1fdb362561ddb2((int)x1a84eefd5d3e114a.xc3cc338a59c5293b(1160));
		double num6 = x4574ea26106f0edb.x0e1fdb362561ddb2((int)x1a84eefd5d3e114a.xc3cc338a59c5293b(1150));
		double num7 = x4574ea26106f0edb.x0e1fdb362561ddb2((int)x1a84eefd5d3e114a.xc3cc338a59c5293b(1170));
		double num8 = (flag7 ? num6 : num5);
		double num9 = (flag7 ? num5 : num6);
		bool flag13 = (flag7 ? flag : flag2);
		bool flag14 = (flag7 ? flag2 : flag);
		if (!x1ebf5501f9a725fb)
		{
			if (!x37964b8beac948a3)
			{
				double num10 = num8;
				double num11 = num9;
				if (num8 < 0.0)
				{
					num8 = 0.0;
					flag13 = true;
				}
				if (num9 < 0.0)
				{
					num9 = 0.0;
					flag14 = true;
				}
				if (flag7)
				{
					double num12 = num9 + num7;
					if (num12 < 0.0)
					{
						num9 -= num12;
						flag14 = true;
					}
				}
				else
				{
					double num13 = num8 + num7;
					if (num13 < 0.0)
					{
						num8 -= num13;
						flag13 = true;
					}
				}
				if (num10 != num8)
				{
					x4edf5a654b83812d.xa3193a56fd4c92e5(x57fef5933b41d0c2, x8c927810a5dc8895: true, num10);
				}
				if (num11 != num9)
				{
					x4edf5a654b83812d.xa3193a56fd4c92e5(x57fef5933b41d0c2, x8c927810a5dc8895: false, num11);
				}
			}
			if (num != 0)
			{
				if (!flag2)
				{
					flag13 = num8 != 0.0;
				}
				if (!flag)
				{
					flag14 = num9 != 0.0;
				}
				if (!flag3)
				{
					flag3 = num7 != 0.0;
				}
			}
			if (flag3 && (num7 != 0.0 || xa4427eaecb321cf4))
			{
				xa3fc7dcdc8182ff.xd6d0700e6673d965("text-indent", num7, x0ec035c4a2d07fb6.x560cf35c28bc5a84);
			}
		}
		else
		{
			if (num5 != 0.0)
			{
				flag13 = true;
				num8 = 0.0;
			}
			if (num6 != 0.0)
			{
				flag14 = true;
				num9 = 0.0;
			}
		}
		if (flag8)
		{
			if (!x1ebf5501f9a725fb)
			{
				num9 -= num6;
				num8 -= num5;
			}
			num2 = 0.0;
			if (x1458787a87172e23 == x4ef6b4f19b033b48.x89f4b67282edaf4a)
			{
				num3 = 0.0;
			}
			if (border != null && ((border3 != null && border3.IsVisible) || x1458787a87172e23 == x4ef6b4f19b033b48.x89f4b67282edaf4a))
			{
				num3 += border.DistanceFromText;
			}
			if (num3 > 0.0)
			{
				xa3fc7dcdc8182ff.xd6d0700e6673d965("padding-bottom", num3, x0ec035c4a2d07fb6.x560cf35c28bc5a84);
			}
			num3 = 0.0;
		}
		if (flag8 || (flag4 && flag14 && flag5 && flag13))
		{
			xa3fc7dcdc8182ff.xfd7a4669c14e659a("margin", num2, num9, num3, num8, x0ec035c4a2d07fb6.x560cf35c28bc5a84);
		}
		else
		{
			if (flag4)
			{
				xa3fc7dcdc8182ff.xd6d0700e6673d965("margin-top", num2, x0ec035c4a2d07fb6.x560cf35c28bc5a84);
			}
			if (flag14)
			{
				xa3fc7dcdc8182ff.xd6d0700e6673d965("margin-right", num9, x0ec035c4a2d07fb6.x560cf35c28bc5a84);
			}
			if (flag5)
			{
				xa3fc7dcdc8182ff.xd6d0700e6673d965("margin-bottom", num3, x0ec035c4a2d07fb6.x560cf35c28bc5a84);
			}
			if (flag13)
			{
				xa3fc7dcdc8182ff.xd6d0700e6673d965("margin-left", num8, x0ec035c4a2d07fb6.x560cf35c28bc5a84);
			}
		}
		if (flag6)
		{
			switch (x84bbacdc1fc0efd.xea9485ec61071863)
			{
			case LineSpacingRule.Multiple:
			{
				double num15 = x4574ea26106f0edb.x984bdd10255a33a5(x84bbacdc1fc0efd.xd2f68ee6f47e9dfb);
				if (num15 != 1.0 || xa4427eaecb321cf4)
				{
					xc38718e486bd53b0(xa3fc7dcdc8182ff, num15, x966a98c86f220d2e);
				}
				break;
			}
			case LineSpacingRule.AtLeast:
			{
				double num14 = Math.Max(x4574ea26106f0edb.x0e1fdb362561ddb2(x84bbacdc1fc0efd.xd2f68ee6f47e9dfb), x966a98c86f220d2e);
				if (num14 != 0.0)
				{
					xa3fc7dcdc8182ff.xd6d0700e6673d965("line-height", num14, x0ec035c4a2d07fb6.x560cf35c28bc5a84);
				}
				break;
			}
			case LineSpacingRule.Exactly:
				xa3fc7dcdc8182ff.xd6d0700e6673d965("line-height", x4574ea26106f0edb.x0e1fdb362561ddb2(x84bbacdc1fc0efd.xd2f68ee6f47e9dfb), x0ec035c4a2d07fb6.x560cf35c28bc5a84);
				break;
			default:
				throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("hcjfndaghdhghdogfdfhkdmhocdinnjigcbjacijccpjgbgkommkobelibllgacmfajmiaankahnaaongleofamofadpjpjppoaaflha", 2020038866)));
			}
		}
		else if (x09585c411b119c0d)
		{
			x84bbacdc1fc0efd = (x84bbacdc1fc0efd2)x1a84eefd5d3e114a.xc3cc338a59c5293b(1650);
			if (x84bbacdc1fc0efd.xea9485ec61071863 == LineSpacingRule.Multiple)
			{
				double num16 = x4574ea26106f0edb.x984bdd10255a33a5(x84bbacdc1fc0efd.xd2f68ee6f47e9dfb);
				if (num16 != 1.0)
				{
					xc38718e486bd53b0(xa3fc7dcdc8182ff, num16, x966a98c86f220d2e);
				}
			}
		}
		return xa3fc7dcdc8182ff;
	}

	internal static void xcf7d87ab57988c1a(xf5ecf429e74b1c04 x1a84eefd5d3e114a, xa3fc7dcdc8182ff6 x36c843bef78b260f, x000f21cbda739311 xcb075c7088c3b520, bool xa4427eaecb321cf4, bool xb644687d42b4cb50, bool xf544375d86767c28, FontInfoCollection x4c33abf651adeb81, x9df536d98415d2d0 x8b1a40fd1ddfa567)
	{
		string x23baa165bca7b6ef = null;
		string x9765a88832769f = null;
		string x4681a4352e687cd = null;
		string xe1755e6a97c = null;
		double num = 0.0;
		bool flag = false;
		x7af53bbecc5ccdd5 x7af53bbecc5ccdd = x7af53bbecc5ccdd5.x139412b8dea2f02b;
		bool flag2 = false;
		x1eec46d494a92718 xbcea506a33cf = x1eec46d494a92718.x236cb0a4295bc034;
		x1eec46d494a92718 xbcea506a33cf2 = x1eec46d494a92718.x236cb0a4295bc034;
		x1eec46d494a92718 xbcea506a33cf3 = x1eec46d494a92718.x236cb0a4295bc034;
		x1eec46d494a92718 xbcea506a33cf4 = x1eec46d494a92718.x236cb0a4295bc034;
		x1eec46d494a92718 xbcea506a33cf5 = x1eec46d494a92718.x236cb0a4295bc034;
		x1eec46d494a92718 xbcea506a33cf6 = x1eec46d494a92718.x236cb0a4295bc034;
		Underline underline = Underline.None;
		bool flag3 = false;
		double num2 = 0.0;
		bool flag4 = false;
		x26d9ecb4bdf0456d x26d9ecb4bdf0456d = null;
		x26d9ecb4bdf0456d x26d9ecb4bdf0456d2 = null;
		Shading shading = null;
		int xe252973deea04dda = x1a84eefd5d3e114a.xe252973deea04dda;
		for (int i = 0; i < xe252973deea04dda; i++)
		{
			x1a84eefd5d3e114a.x16b3a875e7cc38ed(i, out var xba08ce632055a1d, out var xbcea506a33cf7);
			switch (xba08ce632055a1d)
			{
			case 20:
				x26d9ecb4bdf0456d2 = (x26d9ecb4bdf0456d)xbcea506a33cf7;
				break;
			case 60:
				xbcea506a33cf = x8c82f2069d14956a(xbcea506a33cf7, x1a84eefd5d3e114a, xba08ce632055a1d, xa4427eaecb321cf4);
				break;
			case 70:
			{
				x1eec46d494a92718 xbcea506a33cf8 = x8c82f2069d14956a(xbcea506a33cf7, x1a84eefd5d3e114a, xba08ce632055a1d, xa4427eaecb321cf4);
				if (xc28f5bc8d5b55be5(xbcea506a33cf8))
				{
					x36c843bef78b260f.xf0ca15702ca7498c("font-style", xc9cb9dce93741a96(xbcea506a33cf8) ? "italic" : "normal");
				}
				break;
			}
			case 80:
				xbcea506a33cf5 = x8c82f2069d14956a(xbcea506a33cf7, x1a84eefd5d3e114a, xba08ce632055a1d, xa4427eaecb321cf4);
				break;
			case 90:
				xbcea506a33cf2 = x8c82f2069d14956a(xbcea506a33cf7, x1a84eefd5d3e114a, xba08ce632055a1d, xa4427eaecb321cf4);
				break;
			case 110:
			{
				x1eec46d494a92718 xbcea506a33cf8 = x8c82f2069d14956a(xbcea506a33cf7, x1a84eefd5d3e114a, xba08ce632055a1d, xa4427eaecb321cf4);
				if (xc28f5bc8d5b55be5(xbcea506a33cf8))
				{
					x36c843bef78b260f.xf0ca15702ca7498c("font-variant", xc9cb9dce93741a96(xbcea506a33cf8) ? "small-caps" : "normal");
				}
				break;
			}
			case 120:
			{
				x1eec46d494a92718 xbcea506a33cf8 = x8c82f2069d14956a(xbcea506a33cf7, x1a84eefd5d3e114a, xba08ce632055a1d, xa4427eaecb321cf4);
				if (xc28f5bc8d5b55be5(xbcea506a33cf8))
				{
					x36c843bef78b260f.xf0ca15702ca7498c("text-transform", xc9cb9dce93741a96(xbcea506a33cf8) ? "uppercase" : "none");
				}
				break;
			}
			case 130:
			{
				x1eec46d494a92718 xbcea506a33cf8 = x8c82f2069d14956a(xbcea506a33cf7, x1a84eefd5d3e114a, xba08ce632055a1d, xa4427eaecb321cf4);
				if (xc28f5bc8d5b55be5(xbcea506a33cf8))
				{
					x36c843bef78b260f.xf0ca15702ca7498c("display", xc9cb9dce93741a96(xbcea506a33cf8) ? "none" : "inline");
				}
				break;
			}
			case 140:
				underline = (Underline)xbcea506a33cf7;
				flag3 = true;
				break;
			case 150:
			{
				double num3 = x4574ea26106f0edb.x0e1fdb362561ddb2((int)xbcea506a33cf7);
				if (num3 != 0.0 || xa4427eaecb321cf4)
				{
					x36c843bef78b260f.xd6d0700e6673d965("letter-spacing", num3, x0ec035c4a2d07fb6.x560cf35c28bc5a84);
				}
				break;
			}
			case 160:
				x26d9ecb4bdf0456d = (x26d9ecb4bdf0456d)xbcea506a33cf7;
				break;
			case 170:
				xbcea506a33cf3 = x8c82f2069d14956a(xbcea506a33cf7, x1a84eefd5d3e114a, xba08ce632055a1d, xa4427eaecb321cf4);
				break;
			case 180:
				xbcea506a33cf4 = x8c82f2069d14956a(xbcea506a33cf7, x1a84eefd5d3e114a, xba08ce632055a1d, xa4427eaecb321cf4);
				break;
			case 190:
				num = x4574ea26106f0edb.x4610495f80b4c267((int)xbcea506a33cf7);
				flag = true;
				break;
			case 200:
				num2 = x4574ea26106f0edb.x4610495f80b4c267((int)xbcea506a33cf7);
				flag4 = true;
				break;
			case 210:
				x7af53bbecc5ccdd = (x7af53bbecc5ccdd5)xbcea506a33cf7;
				flag2 = true;
				break;
			case 230:
				x23baa165bca7b6ef = (string)xbcea506a33cf7;
				break;
			case 240:
				xe1755e6a97c = (string)xbcea506a33cf7;
				break;
			case 270:
				x9765a88832769f = (string)xbcea506a33cf7;
				break;
			case 235:
				x4681a4352e687cd = (string)xbcea506a33cf7;
				break;
			case 300:
				xbcea506a33cf6 = x8c82f2069d14956a(xbcea506a33cf7, x1a84eefd5d3e114a, xba08ce632055a1d, xa4427eaecb321cf4);
				break;
			case 360:
			{
				Border border = (Border)xbcea506a33cf7;
				if (!border.xa157de8185757b11)
				{
					x30ff4cedcf2b2374.xad56ef88b1fac115(border, x36c843bef78b260f);
				}
				break;
			}
			case 370:
				shading = (Shading)xbcea506a33cf7;
				break;
			}
		}
		string text = xb7dbd7bb3ed97d5b.x4a59367ba6527b94(xcb075c7088c3b520, x23baa165bca7b6ef, x9765a88832769f, x4681a4352e687cd, xe1755e6a97c);
		if (text != null)
		{
			if (x4c33abf651adeb81 != null)
			{
				string xbcea506a33cf9 = x69e8b423c22edb61.x9a25366b9d393820(text, x4c33abf651adeb81);
				x0a4437fb7b6e1adb x0a4437fb7b6e1adb = new x0a4437fb7b6e1adb();
				x0a4437fb7b6e1adb.Add(xedac08b4826d3056.x94f5da15b32c4a50(text));
				x0a4437fb7b6e1adb.Add(xedac08b4826d3056.xe6e56b57a990d08c(xbcea506a33cf9));
				x36c843bef78b260f.x19f4b30676d8bb52("font-family", x0a4437fb7b6e1adb);
			}
			else
			{
				x36c843bef78b260f.x566936ceeb951bac("font-family", text);
			}
		}
		bool flag5 = false;
		if (flag || xb644687d42b4cb50)
		{
			flag5 = x7af53bbecc5ccdd != x7af53bbecc5ccdd5.x139412b8dea2f02b;
			if (!flag2)
			{
				x7af53bbecc5ccdd5 x7af53bbecc5ccdd2 = (x7af53bbecc5ccdd5)x1a84eefd5d3e114a.x2685f947206319cf(210);
				flag5 = x7af53bbecc5ccdd2 != x7af53bbecc5ccdd5.x139412b8dea2f02b;
			}
		}
		if (flag || flag5)
		{
			double num4 = num;
			if (!flag)
			{
				num4 = x4574ea26106f0edb.x4610495f80b4c267((int)x1a84eefd5d3e114a.x2685f947206319cf(190));
			}
			if (flag5)
			{
				num4 *= 2.0 / 3.0;
			}
			x36c843bef78b260f.xd6d0700e6673d965("font-size", num4, x0ec035c4a2d07fb6.x560cf35c28bc5a84);
		}
		if (xc28f5bc8d5b55be5(xbcea506a33cf) || xc28f5bc8d5b55be5(xbcea506a33cf2) || xc28f5bc8d5b55be5(xbcea506a33cf3) || xc28f5bc8d5b55be5(xbcea506a33cf4))
		{
			bool flag6 = xc9cb9dce93741a96(xbcea506a33cf) || xc9cb9dce93741a96(xbcea506a33cf2) || xc9cb9dce93741a96(xbcea506a33cf3) || xc9cb9dce93741a96(xbcea506a33cf4);
			x36c843bef78b260f.xf0ca15702ca7498c("font-weight", flag6 ? "bold" : "normal");
		}
		if (xf544375d86767c28)
		{
			bool flag7 = xc28f5bc8d5b55be5(xbcea506a33cf5) || xc28f5bc8d5b55be5(xbcea506a33cf6);
			if (flag3 || flag7)
			{
				x0a4437fb7b6e1adb x0a4437fb7b6e1adb2 = new x0a4437fb7b6e1adb();
				if (underline != 0)
				{
					x0a4437fb7b6e1adb2.Add(xedac08b4826d3056.xe6e56b57a990d08c("underline"));
				}
				if (flag7 && (xc9cb9dce93741a96(xbcea506a33cf5) || xc9cb9dce93741a96(xbcea506a33cf6)))
				{
					x0a4437fb7b6e1adb2.Add(xedac08b4826d3056.xe6e56b57a990d08c("line-through"));
				}
				if (x0a4437fb7b6e1adb2.Count == 0 && xa4427eaecb321cf4)
				{
					x0a4437fb7b6e1adb2.Add(xedac08b4826d3056.xe6e56b57a990d08c("none"));
				}
				x36c843bef78b260f.x5ae72a407a137e0b("text-decoration", x0a4437fb7b6e1adb2);
			}
		}
		if (flag4)
		{
			if (num2 != 0.0 || xa4427eaecb321cf4)
			{
				x36c843bef78b260f.xd6d0700e6673d965("vertical-align", num2, x0ec035c4a2d07fb6.x560cf35c28bc5a84);
			}
		}
		else if (flag2)
		{
			switch (x7af53bbecc5ccdd)
			{
			case x7af53bbecc5ccdd5.x1b1f4712a1a0c38c:
				x36c843bef78b260f.xf0ca15702ca7498c("vertical-align", "sub");
				break;
			case x7af53bbecc5ccdd5.xab66d68facbadf18:
				x36c843bef78b260f.xf0ca15702ca7498c("vertical-align", "super");
				break;
			default:
				if (xa4427eaecb321cf4)
				{
					x36c843bef78b260f.xf0ca15702ca7498c("vertical-align", "baseline");
				}
				break;
			}
		}
		if (x26d9ecb4bdf0456d != null)
		{
			xda717da2be964093(x36c843bef78b260f, x8b1a40fd1ddfa567.xa6dfa2703204e9f0(x26d9ecb4bdf0456d), xa4427eaecb321cf4);
		}
		else if (x1a84eefd5d3e114a is Inline)
		{
			xda717da2be964093(x36c843bef78b260f, x8b1a40fd1ddfa567.xa6dfa2703204e9f0(((Inline)x1a84eefd5d3e114a).xeedad81aaed42a76.x9b41425268471380), x2b1b430f0cdd82e7: false);
		}
		if (x26d9ecb4bdf0456d2 != null && !x26d9ecb4bdf0456d2.x7149c962c02931b3)
		{
			if (x26d9ecb4bdf0456d2 != x26d9ecb4bdf0456d.x8f02f53f1587477d || xa4427eaecb321cf4)
			{
				x36c843bef78b260f.xf4868abd18f579a7("background-color", x26d9ecb4bdf0456d2);
			}
		}
		else if (shading != null && !shading.xa157de8185757b11)
		{
			x4ce5248b91d2fbf7.xdd58192800f83cee(shading, x36c843bef78b260f);
		}
	}

	private static void xda717da2be964093(xa3fc7dcdc8182ff6 x36c843bef78b260f, x26d9ecb4bdf0456d x6c50a99faab7d741, bool x2b1b430f0cdd82e7)
	{
		if (x6c50a99faab7d741 != x26d9ecb4bdf0456d.x89fffa2751fdecbe || x2b1b430f0cdd82e7)
		{
			x36c843bef78b260f.xf4868abd18f579a7("color", x6c50a99faab7d741);
		}
	}

	private static x1eec46d494a92718 x8c82f2069d14956a(object xcad36d614e21a5e1, xf5ecf429e74b1c04 x20a08fe5d532d661, int xba08ce632055a1d9, bool xa4427eaecb321cf4)
	{
		bool flag = xcad36d614e21a5e1 == x9b28b1f7f0cc963f.xbbad6bbe73c6b1dc;
		bool flag2 = xcad36d614e21a5e1 == x9b28b1f7f0cc963f.x10a64d88e6f4fac9;
		if (!flag && !flag2 && !xa4427eaecb321cf4)
		{
			return x1eec46d494a92718.x236cb0a4295bc034;
		}
		bool flag3 = flag;
		if (flag2)
		{
			if (x20a08fe5d532d661 == null)
			{
				flag3 = true;
			}
			else
			{
				object obj = x20a08fe5d532d661.x2685f947206319cf(xba08ce632055a1d9);
				flag3 = obj == null || obj == x9b28b1f7f0cc963f.x12642456c7bf0815;
			}
		}
		if (!flag3)
		{
			return x1eec46d494a92718.x12642456c7bf0815;
		}
		return x1eec46d494a92718.xbbad6bbe73c6b1dc;
	}

	private static bool xc28f5bc8d5b55be5(x1eec46d494a92718 xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 != x1eec46d494a92718.x236cb0a4295bc034;
	}

	private static bool xc9cb9dce93741a96(x1eec46d494a92718 xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 == x1eec46d494a92718.xbbad6bbe73c6b1dc;
	}

	private static void xc38718e486bd53b0(xa3fc7dcdc8182ff6 x36c843bef78b260f, double x0383ec486664fa18, double x966a98c86f220d2e)
	{
		double num = Math.Round(x0383ec486664fa18 * 100.0);
		if (num == 100.0)
		{
			x36c843bef78b260f.xf0ca15702ca7498c("line-height", "normal");
		}
		else
		{
			x36c843bef78b260f.xb2275198aa955331("line-height", num);
		}
		if (x966a98c86f220d2e != 0.0)
		{
			x36c843bef78b260f.xd6d0700e6673d965("font-size", x966a98c86f220d2e, x0ec035c4a2d07fb6.x560cf35c28bc5a84);
		}
	}
}
