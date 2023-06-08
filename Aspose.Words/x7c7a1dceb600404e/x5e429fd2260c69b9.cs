using x011d489fb9df7027;
using x1a3e96f4b89a7a77;
using xda075892eccab2ad;
using xf9a9481c3f63a419;

namespace x7c7a1dceb600404e;

internal class x5e429fd2260c69b9
{
	private x873451caae5ad4ae x800085dd555f7711;

	private x2cd1f1f5e07462a8 x8cedcaa9a62c6e39;

	private string x4b874a3f1765ba1d;

	private int xda5fc4dfe72777af;

	private string x5d9fbd9603e9dee5;

	private string x29accc1eca023568;

	private string xa5f1622a8863fdf3;

	private string x591696bcdf019c27;

	private string xb9dc711ade7b5159;

	private string xceddf551c03a4846;

	private string x9cd56eb2fd67b8be;

	private x580ae020787e37f2[] xec45ed693315462c;

	internal string x5e63bd35f6835a06 => x4b874a3f1765ba1d;

	internal x5e429fd2260c69b9(x2cd1f1f5e07462a8 context, x873451caae5ad4ae builder)
	{
		x800085dd555f7711 = builder;
		x8cedcaa9a62c6e39 = context;
	}

	internal void x4ac9f4b2e295bbfd(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		xda5fc4dfe72777af++;
		switch (xba08ce632055a1d9)
		{
		case 1280:
			x4b874a3f1765ba1d = xf4107e64edda7fac.xbffdab98aae36b97((x5e63bd35f6835a06)xbcea506a33cf9111);
			xda5fc4dfe72777af--;
			break;
		case 1281:
			x5d9fbd9603e9dee5 = xca004f56614e2431.x754c3a5f03a2ce84((int)xbcea506a33cf9111);
			break;
		case 1285:
			x29accc1eca023568 = xca004f56614e2431.x754c3a5f03a2ce84((int)xbcea506a33cf9111);
			break;
		case 1286:
			xa5f1622a8863fdf3 = xca004f56614e2431.x754c3a5f03a2ce84((int)xbcea506a33cf9111);
			break;
		case 1287:
			x591696bcdf019c27 = xca004f56614e2431.x754c3a5f03a2ce84((int)xbcea506a33cf9111);
			break;
		case 1288:
			xb9dc711ade7b5159 = xc1b08afa36bf580c.xd3289958406a0272((int[])xbcea506a33cf9111);
			break;
		case 1340:
			xceddf551c03a4846 = x64893267b789fd52.xdd13b76d78255522(xbcea506a33cf9111);
			break;
		case 1341:
			x9cd56eb2fd67b8be = x64893267b789fd52.xdd13b76d78255522(xbcea506a33cf9111);
			break;
		case 1284:
			xec45ed693315462c = (x580ae020787e37f2[])xbcea506a33cf9111;
			break;
		}
	}

	internal void x524ce4a564445ccf()
	{
		if (xda5fc4dfe72777af <= 0)
		{
			return;
		}
		x800085dd555f7711.x2307058321cdb62f("o:diagram");
		x800085dd555f7711.x943f6be3acf634db("v:ext", "edit");
		x800085dd555f7711.x943f6be3acf634db("dgmstyle", x5d9fbd9603e9dee5);
		x800085dd555f7711.x943f6be3acf634db("dgmscalex", x29accc1eca023568);
		x800085dd555f7711.x943f6be3acf634db("dgmscaley", xa5f1622a8863fdf3);
		x800085dd555f7711.x943f6be3acf634db("dgmfontsize", x591696bcdf019c27);
		x800085dd555f7711.x943f6be3acf634db("constrainbounds", xb9dc711ade7b5159);
		x800085dd555f7711.x943f6be3acf634db("autoformat", xceddf551c03a4846);
		x800085dd555f7711.x943f6be3acf634db("reverse", x9cd56eb2fd67b8be);
		if (xec45ed693315462c != null && xec45ed693315462c.Length > 0)
		{
			x800085dd555f7711.x2307058321cdb62f("o:relationtable");
			x800085dd555f7711.x943f6be3acf634db("v:ext", "edit");
			x580ae020787e37f2[] array = xec45ed693315462c;
			foreach (x580ae020787e37f2 x580ae020787e37f in array)
			{
				x800085dd555f7711.x2307058321cdb62f("o:rel");
				x800085dd555f7711.x943f6be3acf634db("v:ext", "edit");
				x800085dd555f7711.x943f6be3acf634db("idsrc", x8cedcaa9a62c6e39.xb60a89e8f071915f(x580ae020787e37f.xda71bf6f7c07c3bc));
				x800085dd555f7711.x943f6be3acf634db("iddest", x8cedcaa9a62c6e39.xb60a89e8f071915f(x580ae020787e37f.x8e8f6cc6a0756b05));
				x800085dd555f7711.x943f6be3acf634db("idcntr", x8cedcaa9a62c6e39.xb60a89e8f071915f(x580ae020787e37f.x857912840ffd015f));
				x800085dd555f7711.x2dfde153f4ef96d0();
			}
			x800085dd555f7711.x2dfde153f4ef96d0();
		}
		x800085dd555f7711.x2dfde153f4ef96d0();
	}
}
