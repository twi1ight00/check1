using System;
using System.Text;
using Aspose.Words.Drawing;
using x011d489fb9df7027;
using x13f1efc79617a47b;
using x1a3e96f4b89a7a77;
using xf9a9481c3f63a419;

namespace x7c7a1dceb600404e;

internal class x44b09cab0cde18f9
{
	private readonly x873451caae5ad4ae x800085dd555f7711;

	private readonly ShapeBase x317be79405176667;

	private bool x42742d86636447e1;

	private bool xb64d282a750a9573 = true;

	private bool x400b6ac97393911c = true;

	private bool xd12677a596d97b9e = true;

	private bool x6831bc5f7a359422 = true;

	private bool x5eb6e903594737c9;

	private bool x1b0f75351366952a;

	private int x68f9a60616f5cd75;

	private int xbf776433ff5e313d;

	private string x5342d4fe9c773bbc;

	private xbc9979937c838d75[] xb1a9109306172813;

	private x08d932077485c285[] x158170fffca516f1;

	private int[] x0b1e3910fd750ac4;

	private x08d932077485c285[] xc72926de6b6361e2;

	private x44f2b8bf33b16275[] x8981fd81e0974d02;

	private readonly string[] x3a34f26ba151e973 = new string[10];

	private x40937ad35b1cf5f7[] x92e4098d6aeaeb1a;

	private x7efbe0a2dc0d335f[] x751e80695ccd5699;

	internal x44b09cab0cde18f9(ShapeBase shape, x873451caae5ad4ae builder)
	{
		x800085dd555f7711 = builder;
		x317be79405176667 = shape;
	}

	internal void x4ac9f4b2e295bbfd(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		switch (xba08ce632055a1d9)
		{
		case 507:
			x42742d86636447e1 = (bool)xbcea506a33cf9111;
			break;
		case 383:
			xb64d282a750a9573 = (bool)xbcea506a33cf9111;
			break;
		case 380:
			x400b6ac97393911c = (bool)xbcea506a33cf9111;
			break;
		case 378:
			xd12677a596d97b9e = (bool)xbcea506a33cf9111;
			break;
		case 379:
			x6831bc5f7a359422 = (bool)xbcea506a33cf9111;
			break;
		case 382:
			x5eb6e903594737c9 = (bool)xbcea506a33cf9111;
			break;
		case 381:
			x1b0f75351366952a = (bool)xbcea506a33cf9111;
			break;
		case 339:
			x68f9a60616f5cd75 = (int)xbcea506a33cf9111;
			break;
		case 340:
			xbf776433ff5e313d = (int)xbcea506a33cf9111;
			break;
		case 344:
			x5342d4fe9c773bbc = xf4107e64edda7fac.x7b140f09cc82bec5((x3b504d8c866583dc)xbcea506a33cf9111);
			break;
		case 337:
			x158170fffca516f1 = (x08d932077485c285[])xbcea506a33cf9111;
			break;
		case 338:
			x0b1e3910fd750ac4 = (int[])xbcea506a33cf9111;
			break;
		case 343:
			xb1a9109306172813 = (xbc9979937c838d75[])xbcea506a33cf9111;
			break;
		case 326:
			x8981fd81e0974d02 = (x44f2b8bf33b16275[])xbcea506a33cf9111;
			break;
		case 325:
			xc72926de6b6361e2 = (x08d932077485c285[])xbcea506a33cf9111;
			break;
		case 342:
			x92e4098d6aeaeb1a = (x40937ad35b1cf5f7[])xbcea506a33cf9111;
			break;
		case 341:
			x751e80695ccd5699 = (x7efbe0a2dc0d335f[])xbcea506a33cf9111;
			break;
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
			x3a34f26ba151e973[xba08ce632055a1d9 - 327] = xca004f56614e2431.x754c3a5f03a2ce84((int)xbcea506a33cf9111);
			break;
		}
	}

	internal void xfe6dd186bf14d15a()
	{
		if (x317be79405176667.ShapeType == ShapeType.RoundRectangle)
		{
			return;
		}
		if (x317be79405176667.ShapeType == ShapeType.CustomShape)
		{
			if (x3a34f26ba151e973[0] == null)
			{
				x3a34f26ba151e973[0] = "-11796480";
			}
			if (x3a34f26ba151e973[2] == null)
			{
				x3a34f26ba151e973[2] = "5400";
			}
		}
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i <= 9; i++)
		{
			if (x3a34f26ba151e973[i] != null)
			{
				stringBuilder.Append(x3a34f26ba151e973[i]);
			}
			stringBuilder.Append(',');
		}
		x800085dd555f7711.xfb5ff561cb1d5db2("adj", stringBuilder.ToString().TrimEnd(','));
	}

	internal void xdc1601b12d681407()
	{
		if (xc72926de6b6361e2 == null || xc72926de6b6361e2.Length == 0 || x8981fd81e0974d02 == null || x8981fd81e0974d02.Length == 0)
		{
			return;
		}
		StringBuilder stringBuilder = new StringBuilder();
		int num = 0;
		for (int i = 0; i < x8981fd81e0974d02.Length; i++)
		{
			x44f2b8bf33b16275 x44f2b8bf33b = x8981fd81e0974d02[i];
			stringBuilder.Append(xf4107e64edda7fac.x437b754a74a299a7(x44f2b8bf33b.x4dd8a59ec8974a5f));
			int num2 = x44f2b8bf33b.x9b6c7f268832a67f();
			for (int j = 0; j < num2; j++)
			{
				if (num >= xc72926de6b6361e2.Length)
				{
					throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("anjnooaoaphojjoolnfpbomppndacokabnbbpmibeipbbngcplncnmedjlldcmcehljedmafblhfllofjlfgdgmgjkdhlkkhkfbiojiijjpiakgjljnjajekmjlkhjclljjlpdammihmkhomkifnlhmnoddo", 497408386)));
				}
				x08d932077485c285 x08d932077485c = xc72926de6b6361e2[num];
				stringBuilder.Append(x14b5d0319442bed7(x08d932077485c.x8df91a2f90079e88));
				stringBuilder.Append(',');
				stringBuilder.Append(x14b5d0319442bed7(x08d932077485c.xc821290d7ecc08bf));
				stringBuilder.Append(',');
				num++;
			}
			if (num2 > 0)
			{
				stringBuilder.Remove(stringBuilder.Length - 1, 1);
			}
		}
		x800085dd555f7711.x943f6be3acf634db("path", stringBuilder.ToString());
	}

	private string x14b5d0319442bed7(x06e4f09a90ca939a x3ddf36d606250c6f)
	{
		if (x3ddf36d606250c6f.x11f06dbf14c9ade8)
		{
			return "@" + x3ddf36d606250c6f.xd2f68ee6f47e9dfb;
		}
		return xca004f56614e2431.x697bc660ab38a504(x3ddf36d606250c6f.xd2f68ee6f47e9dfb);
	}

	internal void xf7b167486e3ffbc1()
	{
		if (x92e4098d6aeaeb1a != null)
		{
			x800085dd555f7711.x2307058321cdb62f("v:formulas");
			for (int i = 0; i < x92e4098d6aeaeb1a.Length; i++)
			{
				x40937ad35b1cf5f7 x5518c79299afe5d = x92e4098d6aeaeb1a[i];
				x800085dd555f7711.x2307058321cdb62f("v:f");
				x800085dd555f7711.xff520a0047c27122("eqn", x38d48b3457ae32e7(x5518c79299afe5d));
				x800085dd555f7711.x2dfde153f4ef96d0();
			}
			x800085dd555f7711.x2dfde153f4ef96d0();
		}
	}

	internal void x476b678a12519529()
	{
		if (x42742d86636447e1 || !xb64d282a750a9573 || !x400b6ac97393911c || !xd12677a596d97b9e || !x6831bc5f7a359422 || x5eb6e903594737c9 || x1b0f75351366952a || (x5342d4fe9c773bbc != null && x5342d4fe9c773bbc != "none") || (x158170fffca516f1 != null && x158170fffca516f1.Length > 0) || (x0b1e3910fd750ac4 != null && x0b1e3910fd750ac4.Length > 0) || xb1a9109306172813 != null)
		{
			x800085dd555f7711.x2307058321cdb62f("v:path");
			x800085dd555f7711.x31389f0c752f577e("arrowok", x42742d86636447e1, xc6e85c82d0d89508: false);
			x800085dd555f7711.x31389f0c752f577e("fillok", xb64d282a750a9573, xc6e85c82d0d89508: true);
			x800085dd555f7711.x31389f0c752f577e("strokeok", x400b6ac97393911c, xc6e85c82d0d89508: true);
			x800085dd555f7711.x31389f0c752f577e("shadowok", xd12677a596d97b9e, xc6e85c82d0d89508: true);
			x800085dd555f7711.x31389f0c752f577e("o:extrusionok", x6831bc5f7a359422, xc6e85c82d0d89508: true);
			x800085dd555f7711.x31389f0c752f577e("gradientshapeok", x5eb6e903594737c9, xc6e85c82d0d89508: false);
			x800085dd555f7711.x31389f0c752f577e("textpathok", x1b0f75351366952a, xc6e85c82d0d89508: false);
			if (x68f9a60616f5cd75 != 0 || xbf776433ff5e313d != 0)
			{
				x800085dd555f7711.x943f6be3acf634db("limo", $"{x68f9a60616f5cd75},{xbf776433ff5e313d}");
			}
			if (x158170fffca516f1 != null && x158170fffca516f1.Length > 0 && x5342d4fe9c773bbc == null)
			{
				x800085dd555f7711.x943f6be3acf634db("o:connecttype", "custom");
			}
			else
			{
				x800085dd555f7711.x25e28424582ee3ac("o:connecttype", x5342d4fe9c773bbc, "none");
			}
			x7cf4a4710c736923();
			xee9922ad52157d0f();
			x33b9333e50dc8d24();
			x800085dd555f7711.x2dfde153f4ef96d0();
		}
	}

	private void x7cf4a4710c736923()
	{
		if (x158170fffca516f1 != null && x158170fffca516f1.Length > 0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < x158170fffca516f1.Length; i++)
			{
				x08d932077485c285 x08d932077485c = x158170fffca516f1[i];
				stringBuilder.Append(x96a608c684b18682(x08d932077485c.x8df91a2f90079e88));
				stringBuilder.Append(',');
				stringBuilder.Append(x96a608c684b18682(x08d932077485c.xc821290d7ecc08bf));
				stringBuilder.Append(';');
			}
			stringBuilder.Remove(stringBuilder.Length - 1, 1);
			x800085dd555f7711.x943f6be3acf634db("o:connectlocs", stringBuilder.ToString());
		}
	}

	private void xee9922ad52157d0f()
	{
		if (x0b1e3910fd750ac4 != null && x0b1e3910fd750ac4.Length > 0)
		{
			StringBuilder stringBuilder = new StringBuilder(32);
			for (int i = 0; i < x0b1e3910fd750ac4.Length; i++)
			{
				int xbcea506a33cf = x0b1e3910fd750ac4[i];
				stringBuilder.Append(x64893267b789fd52.x933e1cb72ce52a40(xbcea506a33cf));
				stringBuilder.Append(',');
			}
			stringBuilder.Remove(stringBuilder.Length - 1, 1);
			x800085dd555f7711.x943f6be3acf634db("o:connectangles", stringBuilder.ToString());
		}
	}

	private void x33b9333e50dc8d24()
	{
		if (xb1a9109306172813 != null)
		{
			string xbcea506a33cf = x7e9ddc32d203e808(xb1a9109306172813);
			x800085dd555f7711.x943f6be3acf634db("textboxrect", xbcea506a33cf);
		}
		else if (!x317be79405176667.IsGroup && x317be79405176667.HasChildNodes)
		{
			if (x317be79405176667.ShapeType == ShapeType.TextBox)
			{
				string xbcea506a33cf2 = x7e9ddc32d203e808(((Shape)x317be79405176667).x055ad2518a1ca81c);
				x800085dd555f7711.x943f6be3acf634db("textboxrect", xbcea506a33cf2);
			}
			else
			{
				x800085dd555f7711.x943f6be3acf634db("textboxrect", "3163,3163,18437,18437");
			}
		}
	}

	private string x7e9ddc32d203e808(xbc9979937c838d75[] x329c1767dc4ae788)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < x329c1767dc4ae788.Length; i++)
		{
			xbc9979937c838d75 xbc9979937c838d = x329c1767dc4ae788[i];
			stringBuilder.Append(x96a608c684b18682(xbc9979937c838d.x72d92bd1aff02e37));
			stringBuilder.Append(',');
			stringBuilder.Append(x96a608c684b18682(xbc9979937c838d.xe360b1885d8d4a41));
			stringBuilder.Append(',');
			stringBuilder.Append(x96a608c684b18682(xbc9979937c838d.x419ba17a5322627b));
			stringBuilder.Append(',');
			stringBuilder.Append(x96a608c684b18682(xbc9979937c838d.x9bcb07e204e30218));
			if (i < x329c1767dc4ae788.Length - 1)
			{
				stringBuilder.Append(";");
			}
		}
		return stringBuilder.ToString();
	}

	private string x96a608c684b18682(x06e4f09a90ca939a xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111.x11f06dbf14c9ade8)
		{
			return "@" + xca004f56614e2431.x754c3a5f03a2ce84(xbcea506a33cf9111.xd2f68ee6f47e9dfb);
		}
		return xca004f56614e2431.x754c3a5f03a2ce84(xbcea506a33cf9111.xd2f68ee6f47e9dfb);
	}

	internal void xcf3c1593b79b7899()
	{
		if (x751e80695ccd5699 == null || x751e80695ccd5699.Length <= 0)
		{
			return;
		}
		x800085dd555f7711.x2307058321cdb62f("v:handles");
		for (int i = 0; i < x751e80695ccd5699.Length; i++)
		{
			x7efbe0a2dc0d335f x7efbe0a2dc0d335f = x751e80695ccd5699[i];
			x800085dd555f7711.x2307058321cdb62f("v:h");
			x6a7cfb4ddfc2b7a5("position", new x06e4f09a90ca939a(x7efbe0a2dc0d335f.x3b1bddb38a858693.x98a6bc3f2b64620b, isFormula: true), new x06e4f09a90ca939a(x7efbe0a2dc0d335f.x97a3447730c7ceb9.x98a6bc3f2b64620b, isFormula: true));
			if (x7efbe0a2dc0d335f.xcc2d426b867d703d)
			{
				x800085dd555f7711.xff520a0047c27122("switch", "");
			}
			if (x7efbe0a2dc0d335f.x7937f9e8f355e258)
			{
				x6a7cfb4ddfc2b7a5("polar", x7efbe0a2dc0d335f.xb6af3939c9fabf06, x7efbe0a2dc0d335f.x8d8e3bafebd1a122);
			}
			if (x7efbe0a2dc0d335f.x9183a138a4fced5c)
			{
				x6a7cfb4ddfc2b7a5("map", x7efbe0a2dc0d335f.xb6af3939c9fabf06, x7efbe0a2dc0d335f.x8d8e3bafebd1a122);
			}
			if (x7efbe0a2dc0d335f.x7ab55132a5c2e47e)
			{
				x6a7cfb4ddfc2b7a5("radiusrange", x7efbe0a2dc0d335f.x9462c8df936efa39, x7efbe0a2dc0d335f.x11f73230b9b436a7);
			}
			if (x7efbe0a2dc0d335f.x22dfdc5e2d91486e)
			{
				if (x7efbe0a2dc0d335f.x9462c8df936efa39.xd2f68ee6f47e9dfb != int.MinValue || x7efbe0a2dc0d335f.x11f73230b9b436a7.xd2f68ee6f47e9dfb != int.MaxValue)
				{
					x6a7cfb4ddfc2b7a5("xrange", x7efbe0a2dc0d335f.x9462c8df936efa39, x7efbe0a2dc0d335f.x11f73230b9b436a7);
				}
				if (x7efbe0a2dc0d335f.x5b051452efe1bbe3.xd2f68ee6f47e9dfb != int.MinValue || x7efbe0a2dc0d335f.xbed6b6abe5a7fcce.xd2f68ee6f47e9dfb != int.MaxValue)
				{
					x6a7cfb4ddfc2b7a5("yrange", x7efbe0a2dc0d335f.x5b051452efe1bbe3, x7efbe0a2dc0d335f.xbed6b6abe5a7fcce);
				}
			}
			x800085dd555f7711.x2dfde153f4ef96d0();
		}
		x800085dd555f7711.x2dfde153f4ef96d0();
	}

	private void x6a7cfb4ddfc2b7a5(string x9b87e99172a466ab, x06e4f09a90ca939a x08db3aeabb253cb1, x06e4f09a90ca939a x1e218ceaee1bb583)
	{
		x800085dd555f7711.xff520a0047c27122(x9b87e99172a466ab, x90ec9a92478260eb(x0425e61c529b6eff(x08db3aeabb253cb1), x0425e61c529b6eff(x1e218ceaee1bb583)));
	}

	private static string x90ec9a92478260eb(string x08db3aeabb253cb1, string x1e218ceaee1bb583)
	{
		return $"{x08db3aeabb253cb1},{x1e218ceaee1bb583}";
	}

	private static string x0425e61c529b6eff(x06e4f09a90ca939a xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111.x11f06dbf14c9ade8)
		{
			switch (xbcea506a33cf9111.xd2f68ee6f47e9dfb)
			{
			case 0:
				return "topLeft";
			case 1:
				return "bottomRight";
			case 2:
				return "center";
			default:
				if (xbcea506a33cf9111.xd2f68ee6f47e9dfb < 256)
				{
					return "@" + (xbcea506a33cf9111.xd2f68ee6f47e9dfb - 3);
				}
				return "#" + (xbcea506a33cf9111.xd2f68ee6f47e9dfb - 256);
			}
		}
		return xbcea506a33cf9111.xd2f68ee6f47e9dfb.ToString();
	}

	private string x38d48b3457ae32e7(x40937ad35b1cf5f7 x5518c79299afe5d9)
	{
		if (x5518c79299afe5d9.xca0517fe66f52202 == xca0517fe66f52202.xc90003e3c7f9589e && x5518c79299afe5d9.xe7e30aeba78bbcd2 == 0 && x5518c79299afe5d9.x7cc7f538a3b98861 == 0)
		{
			return x10261a535e7032a6("val", x80a45f3d64735669(x5518c79299afe5d9.xf63e76e85f8fbc50, x5518c79299afe5d9.x3a15c124e3abc8f7));
		}
		string text = xf4107e64edda7fac.x5a136d4ca10877a9(x5518c79299afe5d9.xca0517fe66f52202);
		switch (x5518c79299afe5d9.xca0517fe66f52202)
		{
		case xca0517fe66f52202.x474fa9db0a5aefbf:
		case xca0517fe66f52202.xe76aea2b7c5e5bbf:
			return x10261a535e7032a6(text, x80a45f3d64735669(x5518c79299afe5d9.xf63e76e85f8fbc50, x5518c79299afe5d9.x3a15c124e3abc8f7));
		case xca0517fe66f52202.x1a5e7a3f96903df8:
		case xca0517fe66f52202.xf41d956c067e2b4d:
		case xca0517fe66f52202.x9f4c543928c73298:
		case xca0517fe66f52202.xedf80090b89873d1:
		case xca0517fe66f52202.xc0b452cd0b4db635:
		case xca0517fe66f52202.xb979b67432fd6d34:
			return x10261a535e7032a6(text, x80a45f3d64735669(x5518c79299afe5d9.xf63e76e85f8fbc50, x5518c79299afe5d9.x3a15c124e3abc8f7), x80a45f3d64735669(x5518c79299afe5d9.xe7e30aeba78bbcd2, x5518c79299afe5d9.x6a7e7993810130e9));
		default:
			return x10261a535e7032a6(text, x80a45f3d64735669(x5518c79299afe5d9.xf63e76e85f8fbc50, x5518c79299afe5d9.x3a15c124e3abc8f7), x80a45f3d64735669(x5518c79299afe5d9.xe7e30aeba78bbcd2, x5518c79299afe5d9.x6a7e7993810130e9), x80a45f3d64735669(x5518c79299afe5d9.x7cc7f538a3b98861, x5518c79299afe5d9.x417ba1327575286a));
		}
	}

	private static string x10261a535e7032a6(params string[] xce8d8c7e3c2c2426)
	{
		StringBuilder stringBuilder = new StringBuilder(32);
		stringBuilder.Append(xce8d8c7e3c2c2426[0]);
		for (int i = 1; i < xce8d8c7e3c2c2426.Length; i++)
		{
			stringBuilder.Append(' ');
			stringBuilder.Append(xce8d8c7e3c2c2426[i]);
		}
		return stringBuilder.ToString();
	}

	private string x80a45f3d64735669(int xbcea506a33cf9111, bool xa76cb9c5bdf91339)
	{
		if (xa76cb9c5bdf91339)
		{
			switch (xbcea506a33cf9111)
			{
			case 320:
				return "xcenter";
			case 321:
				return "ycenter";
			case 322:
				return "width";
			case 323:
				return "height";
			case 339:
				return "xlimo";
			case 340:
				return "ylimo";
			case 508:
				return "lineDrawn";
			case 1271:
				return "pixelLineWidth";
			case 1272:
				return "pixelWidth";
			case 1273:
				return "pixelHeight";
			case 1276:
				return "emuWidth";
			case 1277:
				return "emuHeight";
			case 1278:
				return "emuWidth2";
			case 1279:
				return "emuHeight2";
			default:
				if (xbcea506a33cf9111 >= 1024)
				{
					return "@" + (xbcea506a33cf9111 - 1024);
				}
				if (xbcea506a33cf9111 >= 327 && xbcea506a33cf9111 <= 334)
				{
					return "#" + (xbcea506a33cf9111 - 327);
				}
				throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("hgifnhpfohggogngjgehchlhhgcilgjidgajbhhjjfojfffkoamkkfdlifklkebmefimaepmkegnndnngpdojelobdcpjdjppdaamchaeonakcfbmcmblnccmckcnbbdhbidpmodcbgeibneibefablffbcgjajglppgfmgh", 1229084690)));
			}
		}
		return xca004f56614e2431.x754c3a5f03a2ce84(xbcea506a33cf9111);
	}
}
