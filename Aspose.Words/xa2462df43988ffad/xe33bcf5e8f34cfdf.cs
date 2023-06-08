using Aspose.Words.Drawing;
using x011d489fb9df7027;
using x3d94286fe72124a8;
using x6c95d9cf46ff5f25;
using x7c7a1dceb600404e;
using xbe73d5820f7f4ae3;
using xf9a9481c3f63a419;

namespace xa2462df43988ffad;

internal class xe33bcf5e8f34cfdf
{
	private readonly x9c77c7e782b62883 x800085dd555f7711;

	private readonly x40937ad35b1cf5f7[] x0afb0c9314aab293;

	private int[] xb5980fa32530d05c;

	internal xe33bcf5e8f34cfdf(xdb0bf9f81de4b38c writer)
	{
		x800085dd555f7711 = writer.xe1410f585439c7d4;
		x0afb0c9314aab293 = null;
	}

	internal void xb613ad2f230a7d2c(Shape x5770cdefd8931aa9)
	{
		xbb857c9fc36f5054.xcbe65b21f4ea2cf5 = 1.0;
		if (xbb857c9fc36f5054.x67ec5097b5f33a4e(x5770cdefd8931aa9.x133d653c1b9b01f2, x5770cdefd8931aa9.xc97e136f0019c237))
		{
			xbb857c9fc36f5054.x943cf6ea563cd0a9(x5770cdefd8931aa9.x133d653c1b9b01f2, x5770cdefd8931aa9.xc97e136f0019c237);
		}
		xb5980fa32530d05c = x04c28a4b961182d2.x5fed11ea6295c1d5(x5770cdefd8931aa9);
		if (x5770cdefd8931aa9.ShapeType == ShapeType.RoundRectangle)
		{
			x0b4bc35270b416b2(x5770cdefd8931aa9);
			return;
		}
		x9c77c7e782b62883 x9c77c7e782b62884 = x800085dd555f7711;
		x9c77c7e782b62884.x2307058321cdb62f("draw:enhanced-geometry");
		xbc28ec0aea901443(x5770cdefd8931aa9);
		xeeefc12a0d73d473(x5770cdefd8931aa9);
		x9c77c7e782b62884.x2dfde153f4ef96d0("draw:enhanced-geometry");
	}

	private void xbc28ec0aea901443(Shape x5770cdefd8931aa9)
	{
		x800085dd555f7711.x943f6be3acf634db("draw:type", "non-primitive");
		object obj = x5770cdefd8931aa9.xf7125312c7ee115c.xf7866f89640a29a3(241);
		if (obj != null && (bool)obj)
		{
			x800085dd555f7711.x943f6be3acf634db("draw:text-path", "true");
		}
		x925a2204f5efcb96(x5770cdefd8931aa9);
		x95fe41a89f81be9c(x5770cdefd8931aa9);
		x9d46d4df29eb7fd6(x5770cdefd8931aa9);
		xb00f1a0804e0a0b6(x5770cdefd8931aa9);
		if (x5770cdefd8931aa9.FlipOrientation == FlipOrientation.Horizontal || x5770cdefd8931aa9.FlipOrientation == FlipOrientation.Both)
		{
			x800085dd555f7711.x943f6be3acf634db("draw:mirror-horizontal", "true");
		}
		if (x5770cdefd8931aa9.FlipOrientation == FlipOrientation.Vertical || x5770cdefd8931aa9.FlipOrientation == FlipOrientation.Both)
		{
			x800085dd555f7711.x943f6be3acf634db("draw:mirror-vertical", "true");
		}
		x1e9d12d35ae30e7c(x5770cdefd8931aa9.xf7125312c7ee115c);
		object obj2 = x5770cdefd8931aa9.xf7125312c7ee115c.xf7866f89640a29a3(344);
		if (obj2 != null)
		{
			x800085dd555f7711.x943f6be3acf634db("draw:glue-point-type", x0eb9a864413f34de.x88b5247903a7524e((x3b504d8c866583dc)obj2));
		}
		x529e737305906d9e(x5770cdefd8931aa9.xfc928672852cc4c4(337));
		x1a83e4d746f40c55(x5770cdefd8931aa9.xfc928672852cc4c4(338));
	}

	private void x529e737305906d9e(object x948f4ec9f6546110)
	{
		if (x948f4ec9f6546110 != null)
		{
			string text = "";
			x08d932077485c285[] array = (x08d932077485c285[])x948f4ec9f6546110;
			foreach (x08d932077485c285 x08d932077485c in array)
			{
				text = $"{text} {x9dc204bb8ae2f5f6(x08d932077485c.x8df91a2f90079e88)} {x9dc204bb8ae2f5f6(x08d932077485c.xc821290d7ecc08bf)}";
			}
			x800085dd555f7711.x943f6be3acf634db("draw:glue-points", text.Trim(' '));
		}
	}

	private void x1a83e4d746f40c55(object x7a45b3bdf4e46c29)
	{
		if (x7a45b3bdf4e46c29 != null)
		{
			string text = "";
			int[] array = (int[])x7a45b3bdf4e46c29;
			foreach (int xbcea506a33cf in array)
			{
				text = $"{text}, {xbb857c9fc36f5054.xbbf121f4b9daf886(xbcea506a33cf)}";
			}
			x800085dd555f7711.x943f6be3acf634db("draw:glue-point-leaving-directions", text.Trim(", ".ToCharArray()));
		}
	}

	private void x1e9d12d35ae30e7c(xf7125312c7ee115c xa5e8b8b5991a4e1d)
	{
		object obj = xa5e8b8b5991a4e1d.xf7866f89640a29a3(700);
		if (obj == null || !(bool)obj)
		{
			return;
		}
		int xbcea506a33cf = 50;
		int xbcea506a33cf2 = 14745600;
		int num = 0;
		int num2 = 0;
		int num3 = 5;
		int num4 = 457200;
		int num5 = 0;
		bool flag = false;
		bool flag2 = false;
		int xbcea506a33cf3 = 19661;
		int num6 = 0;
		int num7 = 1;
		int xbcea506a33cf4 = 1260000;
		int xbcea506a33cf5 = -1260000;
		int xbcea506a33cf6 = 9000000;
		int num8 = 32768;
		int num9 = -32768;
		bool flag3 = true;
		xb156f8ae92094cbb xb156f8ae92094cbb = xb156f8ae92094cbb.xec144c1134066890;
		bool flag4 = true;
		bool flag5 = true;
		int xbcea506a33cf7 = 39322;
		int xbcea506a33cf8 = 50000;
		int xbcea506a33cf9 = 0;
		int xbcea506a33cf10 = 10000;
		bool flag6 = false;
		int xbcea506a33cf11 = 39322;
		int xbcea506a33cf12 = -50000;
		int xbcea506a33cf13 = 0;
		int xbcea506a33cf14 = 10000;
		int num10 = 0;
		int num11 = 0;
		int num12 = 0;
		bool flag7 = false;
		for (int i = 0; i < xa5e8b8b5991a4e1d.xd44988f225497f3a; i++)
		{
			int num13 = xa5e8b8b5991a4e1d.xf15263674eb297bb(i);
			object obj2 = xa5e8b8b5991a4e1d.x6d3720b962bd3112(i);
			if (obj2 != null)
			{
				switch (num13)
				{
				case 764:
					flag7 = (bool)obj2;
					break;
				case 710:
					num10 = (int)obj2;
					break;
				case 711:
					num11 = (int)obj2;
					break;
				case 712:
					num12 = (int)obj2;
					break;
				case 703:
					flag4 = (bool)obj2;
					break;
				case 766:
					flag5 = (bool)obj2;
					break;
				case 726:
					xbcea506a33cf7 = (int)obj2;
					break;
				case 723:
					xbcea506a33cf8 = (int)obj2;
					break;
				case 724:
					xbcea506a33cf9 = (int)obj2;
					break;
				case 725:
					xbcea506a33cf10 = (int)obj2;
					break;
				case 767:
					flag6 = (bool)obj2;
					break;
				case 730:
					xbcea506a33cf11 = (int)obj2;
					break;
				case 727:
					xbcea506a33cf12 = (int)obj2;
					break;
				case 728:
					xbcea506a33cf13 = (int)obj2;
					break;
				case 729:
					xbcea506a33cf14 = (int)obj2;
					break;
				case 713:
					xb156f8ae92094cbb = (xb156f8ae92094cbb)obj2;
					break;
				case 640:
					num6 = (int)obj2;
					break;
				case 765:
					flag3 = (bool)obj2;
					break;
				case 718:
					num8 = (int)obj2;
					break;
				case 719:
					num9 = (int)obj2;
					break;
				case 715:
					xbcea506a33cf4 = (int)obj2;
					break;
				case 716:
					xbcea506a33cf5 = (int)obj2;
					break;
				case 717:
					xbcea506a33cf6 = (int)obj2;
					break;
				case 641:
					num7 = (int)obj2;
					break;
				case 705:
					num = (int)obj2;
					break;
				case 704:
					num2 = (int)obj2;
					break;
				case 701:
					flag = (bool)obj2;
					break;
				case 647:
					flag2 = true;
					break;
				case 722:
					xbcea506a33cf3 = (int)obj2;
					break;
				case 645:
					num4 = (int)obj2;
					break;
				case 644:
					num5 = (int)obj2;
					break;
				case 642:
					num3 = (int)obj2;
					break;
				case 721:
					xbcea506a33cf = (int)obj2;
					break;
				case 720:
					xbcea506a33cf2 = (int)obj2;
					break;
				}
			}
		}
		x800085dd555f7711.x943f6be3acf634db("draw:extrusion", "true");
		if ((num10 != 0 || num11 != 0 || num12 != 0) && !flag7)
		{
			x800085dd555f7711.x943f6be3acf634db("draw:extrusion-rotation-center", $"({xbb857c9fc36f5054.xbbf121f4b9daf886(num10)} {xbb857c9fc36f5054.xbbf121f4b9daf886(num11)} {xbb857c9fc36f5054.xbbf121f4b9daf886(num12)})");
		}
		x800085dd555f7711.x943f6be3acf634db("draw:extrusion-light-face", flag4 ? "" : "false");
		x800085dd555f7711.x943f6be3acf634db("draw:extrusion-first-light-harsh", flag5 ? "true" : "false");
		x800085dd555f7711.x943f6be3acf634db("draw:extrusion-first-light-level", xbb857c9fc36f5054.xbbf121f4b9daf886(xbcea506a33cf7));
		x800085dd555f7711.x943f6be3acf634db("draw:extrusion-first-light-direction", $"({xbb857c9fc36f5054.xbbf121f4b9daf886(xbcea506a33cf8)} {xbb857c9fc36f5054.xbbf121f4b9daf886(xbcea506a33cf9)} {xbb857c9fc36f5054.xbbf121f4b9daf886(xbcea506a33cf10)})");
		x800085dd555f7711.x943f6be3acf634db("draw:extrusion-second-light-harsh", flag6 ? "true" : "false");
		x800085dd555f7711.x943f6be3acf634db("draw:extrusion-second-light-level", xbb857c9fc36f5054.xbbf121f4b9daf886(xbcea506a33cf11));
		x800085dd555f7711.x943f6be3acf634db("draw:extrusion-second-light-direction", $"({xbb857c9fc36f5054.xbbf121f4b9daf886(xbcea506a33cf12)} {xbb857c9fc36f5054.xbbf121f4b9daf886(xbcea506a33cf13)} {xbb857c9fc36f5054.xbbf121f4b9daf886(xbcea506a33cf14)})");
		if (num8 != 32768 || num9 != -32768)
		{
			x800085dd555f7711.x943f6be3acf634db("draw:extrusion-origin", $"{xbb857c9fc36f5054.xbbf121f4b9daf886(num8)} {xbb857c9fc36f5054.xbbf121f4b9daf886(num9)}");
		}
		x800085dd555f7711.x943f6be3acf634db("draw:extrusion-viewpoint", $"({xbb857c9fc36f5054.xacaf194810069dc6(xbcea506a33cf4)} {xbb857c9fc36f5054.xacaf194810069dc6(xbcea506a33cf5)} {xbb857c9fc36f5054.xacaf194810069dc6(xbcea506a33cf6)})");
		x800085dd555f7711.x943f6be3acf634db("dr3d:shade-mode", (xb156f8ae92094cbb == xb156f8ae92094cbb.x1d03f9dbb48b31c4) ? "draft" : "");
		x800085dd555f7711.x943f6be3acf634db("dr3d:projection", flag3 ? "" : "perspective");
		if (num != 0 || num2 != 0)
		{
			x800085dd555f7711.x943f6be3acf634db("draw:extrusion-rotation-angle", $"{xbb857c9fc36f5054.xbbf121f4b9daf886(num)} {xbb857c9fc36f5054.xbbf121f4b9daf886(num2)}");
		}
		x800085dd555f7711.x943f6be3acf634db("draw:extrusion-skew", $"{xca004f56614e2431.x754c3a5f03a2ce84(xbcea506a33cf)} {xbb857c9fc36f5054.xbbf121f4b9daf886(xbcea506a33cf2)}");
		if (num4 != 457200 || num5 != 0)
		{
			x800085dd555f7711.x943f6be3acf634db("draw:extrusion-depth", string.Format("{0} {1}", xbb857c9fc36f5054.xacaf194810069dc6(num4), (num5 > num4) ? "0.5" : xca004f56614e2431.xcadee4aea45827c2(x4574ea26106f0edb.xa23e6b6c3169521d(num5))));
		}
		x800085dd555f7711.x943f6be3acf634db("draw:extrusion-color", flag2 ? "true" : "");
		x800085dd555f7711.x943f6be3acf634db("draw:extrusion-specularity", (num6 == 0) ? "" : xbb857c9fc36f5054.x663fc381a64fb64e(num6));
		x800085dd555f7711.x943f6be3acf634db("draw:extrusion-diffusion", (num7 == 1) ? "" : xbb857c9fc36f5054.x663fc381a64fb64e(num7));
		x800085dd555f7711.x943f6be3acf634db("draw:extrusion-metal", flag ? "true" : "");
		x800085dd555f7711.x943f6be3acf634db("draw:extrusion-brightness", xbb857c9fc36f5054.x663fc381a64fb64e(xbcea506a33cf3));
		if (num3 != 5)
		{
			x800085dd555f7711.x943f6be3acf634db("draw:extrusion-shininess", $"{xca004f56614e2431.x754c3a5f03a2ce84(num3 * 10)}%");
		}
	}

	private void xeeefc12a0d73d473(Shape x5770cdefd8931aa9)
	{
		x7efbe0a2dc0d335f[] x89e0f1069b9786a = x5770cdefd8931aa9.x89e0f1069b9786a1;
		if (x89e0f1069b9786a == null)
		{
			return;
		}
		x9c77c7e782b62883 x9c77c7e782b62884 = x800085dd555f7711;
		foreach (x7efbe0a2dc0d335f x7efbe0a2dc0d335f in x89e0f1069b9786a)
		{
			x9c77c7e782b62884.x2307058321cdb62f("draw:handle");
			x800085dd555f7711.x943f6be3acf634db("draw:handle-position", xea399d3ec64d10fe(x5770cdefd8931aa9, x7efbe0a2dc0d335f.x3b1bddb38a858693, x7efbe0a2dc0d335f.x97a3447730c7ceb9));
			if (x7efbe0a2dc0d335f.x2f612cdfb1f62c32)
			{
				x800085dd555f7711.x943f6be3acf634db("draw:handle-mirror-horizontal", x7efbe0a2dc0d335f.x2f612cdfb1f62c32);
			}
			if (x7efbe0a2dc0d335f.x916221819f469b19)
			{
				x800085dd555f7711.x943f6be3acf634db("draw:handle-mirror-vertical", x7efbe0a2dc0d335f.x916221819f469b19);
			}
			if (x7efbe0a2dc0d335f.xcc2d426b867d703d)
			{
				x800085dd555f7711.x943f6be3acf634db("draw:handle-switched", x7efbe0a2dc0d335f.xcc2d426b867d703d);
			}
			if (x7efbe0a2dc0d335f.x22dfdc5e2d91486e)
			{
				if (x7efbe0a2dc0d335f.x9462c8df936efa39.xd2f68ee6f47e9dfb != int.MinValue)
				{
					x5608f1c82143a373("draw:handle-range-x-minimum", x5770cdefd8931aa9, x7efbe0a2dc0d335f.x9462c8df936efa39, x361c1895f4aacdca: true);
				}
				if (x7efbe0a2dc0d335f.x11f73230b9b436a7.xd2f68ee6f47e9dfb != int.MaxValue)
				{
					x5608f1c82143a373("draw:handle-range-x-maximum", x5770cdefd8931aa9, x7efbe0a2dc0d335f.x11f73230b9b436a7, x361c1895f4aacdca: true);
				}
				if (x7efbe0a2dc0d335f.x5b051452efe1bbe3.xd2f68ee6f47e9dfb != int.MinValue)
				{
					x5608f1c82143a373("draw:handle-range-y-minimum", x5770cdefd8931aa9, x7efbe0a2dc0d335f.x5b051452efe1bbe3, x361c1895f4aacdca: false);
				}
				if (x7efbe0a2dc0d335f.xbed6b6abe5a7fcce.xd2f68ee6f47e9dfb != int.MaxValue)
				{
					x5608f1c82143a373("draw:handle-range-y-maximum", x5770cdefd8931aa9, x7efbe0a2dc0d335f.xbed6b6abe5a7fcce, x361c1895f4aacdca: false);
				}
			}
			x9c77c7e782b62884.x2dfde153f4ef96d0("draw:handle");
		}
	}

	private void x5608f1c82143a373(string xb591dc602a67d872, Shape x5770cdefd8931aa9, x06e4f09a90ca939a x13d4cb8d1bd20347, bool x361c1895f4aacdca)
	{
		x800085dd555f7711.x943f6be3acf634db(xb591dc602a67d872, xd1d55a8650981cc4(x5770cdefd8931aa9, x13d4cb8d1bd20347, x361c1895f4aacdca));
	}

	private string xea399d3ec64d10fe(Shape x5770cdefd8931aa9, x98655ffe05324a50 x08db3aeabb253cb1, x98655ffe05324a50 x1e218ceaee1bb583)
	{
		return $"{xd1d55a8650981cc4(x5770cdefd8931aa9, x08db3aeabb253cb1, x361c1895f4aacdca: true)} {xd1d55a8650981cc4(x5770cdefd8931aa9, x1e218ceaee1bb583, x361c1895f4aacdca: false)}";
	}

	private string xd1d55a8650981cc4(Shape x5770cdefd8931aa9, x06e4f09a90ca939a x13d4cb8d1bd20347, bool x361c1895f4aacdca)
	{
		if (!x13d4cb8d1bd20347.x11f06dbf14c9ade8)
		{
			return xca004f56614e2431.x754c3a5f03a2ce84(x13d4cb8d1bd20347.xd2f68ee6f47e9dfb);
		}
		switch (x13d4cb8d1bd20347.xd2f68ee6f47e9dfb)
		{
		case 0:
			if (!x361c1895f4aacdca)
			{
				return "top";
			}
			return "left";
		case 1:
			if (!x361c1895f4aacdca)
			{
				return "bottom";
			}
			return "right";
		case 2:
			return xca004f56614e2431.x754c3a5f03a2ce84(x361c1895f4aacdca ? (x5770cdefd8931aa9.x06c65daad0c0656c + x5770cdefd8931aa9.x133d653c1b9b01f2 / 2) : (x5770cdefd8931aa9.x399bb78ac51a4081 + x5770cdefd8931aa9.xc97e136f0019c237 / 2));
		default:
		{
			if (x13d4cb8d1bd20347.xd2f68ee6f47e9dfb >= 256)
			{
				return $"${xca004f56614e2431.x754c3a5f03a2ce84(x13d4cb8d1bd20347.xd2f68ee6f47e9dfb - 256)}";
			}
			int num = ((x0afb0c9314aab293 != null) ? x0afb0c9314aab293.Length : 0);
			if (x5770cdefd8931aa9.x821a79f393210107 != null)
			{
				if (x13d4cb8d1bd20347.xd2f68ee6f47e9dfb - 3 < num + x5770cdefd8931aa9.x821a79f393210107.Length)
				{
					return xca004f56614e2431.x754c3a5f03a2ce84(xb5980fa32530d05c[x13d4cb8d1bd20347.xd2f68ee6f47e9dfb - 3]);
				}
				return xca004f56614e2431.x754c3a5f03a2ce84(x13d4cb8d1bd20347.xd2f68ee6f47e9dfb);
			}
			return null;
		}
		}
	}

	private string xd1d55a8650981cc4(Shape x5770cdefd8931aa9, x98655ffe05324a50 x13d4cb8d1bd20347, bool x361c1895f4aacdca)
	{
		switch (x13d4cb8d1bd20347.x3146d638ec378671)
		{
		case xc548449aaa21fea5.x58d2ccae3c5cfd08:
			return xca004f56614e2431.x754c3a5f03a2ce84(x361c1895f4aacdca ? (x5770cdefd8931aa9.x06c65daad0c0656c + x5770cdefd8931aa9.x133d653c1b9b01f2 / 2) : (x5770cdefd8931aa9.x399bb78ac51a4081 + x5770cdefd8931aa9.xc97e136f0019c237 / 2));
		case xc548449aaa21fea5.xd93f803ca02a4434:
			if (!x361c1895f4aacdca)
			{
				return "top";
			}
			return "left";
		case xc548449aaa21fea5.xff654ea4df290dd7:
			if (!x361c1895f4aacdca)
			{
				return "bottom";
			}
			return "right";
		case xc548449aaa21fea5.xfaab97dd0218026f:
			return $"${xca004f56614e2431.x754c3a5f03a2ce84(x13d4cb8d1bd20347.xd2f68ee6f47e9dfb)}";
		case xc548449aaa21fea5.x40937ad35b1cf5f7:
			return xca004f56614e2431.x754c3a5f03a2ce84(xb5980fa32530d05c[x13d4cb8d1bd20347.xd2f68ee6f47e9dfb]);
		default:
			return xca004f56614e2431.x754c3a5f03a2ce84(x13d4cb8d1bd20347.xd2f68ee6f47e9dfb);
		}
	}

	private void xb00f1a0804e0a0b6(Shape x5770cdefd8931aa9)
	{
		xbc9979937c838d75[] x055ad2518a1ca81c = x5770cdefd8931aa9.x055ad2518a1ca81c;
		if (x055ad2518a1ca81c != null && x055ad2518a1ca81c.Length > 0)
		{
			xbc9979937c838d75 xbc9979937c838d = x055ad2518a1ca81c[(x055ad2518a1ca81c.Length != 1) ? 1u : 0u];
			string xbcea506a33cf = $"{x9dc204bb8ae2f5f6(xbc9979937c838d.x72d92bd1aff02e37)} {x9dc204bb8ae2f5f6(xbc9979937c838d.xe360b1885d8d4a41)} {x9dc204bb8ae2f5f6(xbc9979937c838d.x419ba17a5322627b)} {x9dc204bb8ae2f5f6(xbc9979937c838d.x9bcb07e204e30218)}";
			x800085dd555f7711.x943f6be3acf634db("draw:text-areas", xbcea506a33cf);
		}
	}

	private void x925a2204f5efcb96(Shape x5770cdefd8931aa9)
	{
		string text = "";
		for (int i = 0; i < 10; i++)
		{
			object obj = x5770cdefd8931aa9.xf7125312c7ee115c.xf7866f89640a29a3(327 + i);
			if (obj == null)
			{
				xf7125312c7ee115c xf7125312c7ee115c = x6f6338c074d2d794.xc49bc34e8c134250(x5770cdefd8931aa9.ShapeType);
				if (xf7125312c7ee115c != null)
				{
					obj = xf7125312c7ee115c.xf7866f89640a29a3(327 + i);
				}
			}
			if (obj != null)
			{
				int xbcea506a33cf = xbb857c9fc36f5054.x01c5989f49b62737((int)obj);
				text = $"{text} {xca004f56614e2431.x754c3a5f03a2ce84(xbcea506a33cf)}";
			}
		}
		x800085dd555f7711.x943f6be3acf634db("draw:modifiers", text.Trim());
	}

	private void x95fe41a89f81be9c(ShapeBase x5770cdefd8931aa9)
	{
		x800085dd555f7711.x943f6be3acf634db("svg:viewBox", $"{0} {0} {xbb857c9fc36f5054.x01c5989f49b62737(x5770cdefd8931aa9.x133d653c1b9b01f2)} {xbb857c9fc36f5054.x01c5989f49b62737(x5770cdefd8931aa9.xc97e136f0019c237)}");
	}

	private void x9d46d4df29eb7fd6(Shape x5770cdefd8931aa9)
	{
		x44f2b8bf33b16275[] xa31cfc0117535bfa = x5770cdefd8931aa9.xa31cfc0117535bfa;
		x08d932077485c285[] xdbed53246e7dd53a = x5770cdefd8931aa9.xdbed53246e7dd53a;
		if (xdbed53246e7dd53a == null)
		{
			return;
		}
		string text = "";
		string text2 = "";
		int num = 0;
		foreach (x44f2b8bf33b16275 x44f2b8bf33b in xa31cfc0117535bfa)
		{
			if (x44f2b8bf33b.x4dd8a59ec8974a5f == x4dd8a59ec8974a5f.xf6c17f648b65c793)
			{
				continue;
			}
			string text3 = x0eb9a864413f34de.x15fdc88864a318d9(x44f2b8bf33b.x4dd8a59ec8974a5f);
			if (x0d299f323d241756.x5959bccb67bbf051(text3))
			{
				int num2 = x44f2b8bf33b.x9b6c7f268832a67f();
				if (text2 != text3 && ((!(text3 == "X") && !(text3 == "Y")) || (!(text2 == "X") && !(text2 == "Y"))))
				{
					text = $"{text} {text3}";
				}
				for (int j = num; j < num + num2; j++)
				{
					x08d932077485c285 x08d932077485c = xdbed53246e7dd53a[j];
					bool x792e5fa15c19db = (x44f2b8bf33b.x4dd8a59ec8974a5f == x4dd8a59ec8974a5f.x8dc4eedb9f218057 || x44f2b8bf33b.x4dd8a59ec8974a5f == x4dd8a59ec8974a5f.x350c7c4c4aeebe37) && (j - num + 1) % 3 == 0;
					text = $"{text} {x9dc204bb8ae2f5f6(x08d932077485c.x8df91a2f90079e88, x792e5fa15c19db)} {x9dc204bb8ae2f5f6(x08d932077485c.xc821290d7ecc08bf, x792e5fa15c19db)}";
				}
				num += num2;
				text2 = text3;
			}
		}
		x800085dd555f7711.x943f6be3acf634db("draw:enhanced-path", text.Trim());
	}

	private string x9dc204bb8ae2f5f6(x06e4f09a90ca939a x3ddf36d606250c6f, bool x792e5fa15c19db66)
	{
		int num = (x3ddf36d606250c6f.x11f06dbf14c9ade8 ? xb5980fa32530d05c[x3ddf36d606250c6f.xd2f68ee6f47e9dfb] : x3ddf36d606250c6f.xd2f68ee6f47e9dfb);
		num = ((!x792e5fa15c19db66) ? xbb857c9fc36f5054.x01c5989f49b62737(num) : (num / 65536));
		return xca004f56614e2431.x754c3a5f03a2ce84(num);
	}

	private string x9dc204bb8ae2f5f6(x06e4f09a90ca939a x3ddf36d606250c6f)
	{
		return x9dc204bb8ae2f5f6(x3ddf36d606250c6f, x792e5fa15c19db66: false);
	}

	private void x0b4bc35270b416b2(Shape x5770cdefd8931aa9)
	{
		x9c77c7e782b62883 x9c77c7e782b62884 = x800085dd555f7711;
		x9c77c7e782b62884.x2307058321cdb62f("draw:enhanced-geometry");
		x9c77c7e782b62884.x943f6be3acf634db("draw:type", "non-primitive");
		object obj = x5770cdefd8931aa9.xf7125312c7ee115c.xf7866f89640a29a3(327);
		double num = 46.0;
		int num2 = (int)((double)((obj != null) ? ((int)obj) : 0) * num);
		int num3 = (int)(21600.0 * num);
		string xbcea506a33cf = string.Format("M {0} 0 X 0 {0} L 0 {1} Y {0} {2} L {1} {2} X {2} {1} L {2} {0} Y {1} 0 Z N", num2, num3 - num2, num3);
		x9c77c7e782b62884.x943f6be3acf634db("draw:modifiers", num2);
		x9c77c7e782b62884.x943f6be3acf634db("svg:viewBox", string.Format("0 0 {0} {0}", num3));
		x9c77c7e782b62884.x943f6be3acf634db("draw:enhanced-path", xbcea506a33cf);
		xb00f1a0804e0a0b6(x5770cdefd8931aa9);
		x9c77c7e782b62884.x2dfde153f4ef96d0("draw:enhanced-geometry");
	}
}
