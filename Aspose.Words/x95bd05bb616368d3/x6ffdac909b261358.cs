using x0a3ff9616df4cd36;
using x6b8130194ad714f7;
using x6c95d9cf46ff5f25;
using x8bb6b4f09b5230a5;

namespace x95bd05bb616368d3;

internal class x6ffdac909b261358 : xaaf059f0543cf507, xe84bd94b5d81933a
{
	private xaeaeae8d38ef57bb x827e895033b76e5e;

	public xaeaeae8d38ef57bb xd98b6fc8af69e348
	{
		get
		{
			if (x827e895033b76e5e == null)
			{
				x827e895033b76e5e = new xd13db1e4c9fb8129(base.xca687bd498227c89);
			}
			return x827e895033b76e5e;
		}
		set
		{
			x827e895033b76e5e = value;
		}
	}

	public x6ffdac909b261358(xe9481907c579c280 serviceLocator)
		: base(serviceLocator)
	{
	}

	public x506b258dd39c6252 xda09af88ab899a50(xc1dcd6189d01216e xe134235b3526fa75)
	{
		x4c28ef76f151d171(xe134235b3526fa75);
		switch (xe134235b3526fa75.xa66385d80d4d296f)
		{
		case "biLevel":
			return x79bfd101636cbf9b();
		case "clrChange":
			return xe385ffb632910373();
		case "grayscl":
			return xfbb95760727fba1c();
		case "lum":
			return xfec7dcb2b332f23d();
		case "duotone":
			return x90b1694bffdb80ac();
		case "alphaBiLevel":
		case "alphaCeiling":
		case "alphaFloor":
		case "alphaInv":
		case "alphaMod":
		case "alphaModFix":
		case "alphaRepl":
		case "blur":
		case "clrRepl":
		case "fillOverlay":
		case "hsl":
		case "tint":
			x10576afa17ca4f1f();
			return null;
		default:
			xf4732ad4641eec1a();
			return null;
		}
	}

	private x5b7f4ffac3c08835 x79bfd101636cbf9b()
	{
		x5b7f4ffac3c08835 x5b7f4ffac3c = new x5b7f4ffac3c08835(base.xca687bd498227c89.x2898a4fa3477fa50);
		x5b7f4ffac3c.xd3f06edc344811a0 = new x55c6a66cc28d5b86(x7450cc1e48712286.x075a63114fe24ce9("thresh", 0.0));
		return x5b7f4ffac3c;
	}

	private xd096be68e56d04ab xe385ffb632910373()
	{
		xd096be68e56d04ab xd096be68e56d04ab = new xd096be68e56d04ab(base.xca687bd498227c89.x2898a4fa3477fa50);
		xd096be68e56d04ab.xf5442a8f9a3234d8 = x7450cc1e48712286.x9c1302ecb6c4f3a2("useA", xc6e85c82d0d89508: true);
		string xa66385d80d4d296f = x7450cc1e48712286.xa66385d80d4d296f;
		while (x7450cc1e48712286.x152cbadbfa8061b1(xa66385d80d4d296f))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "clrFrom":
				xd096be68e56d04ab.xe45d094267773d42 = xd98b6fc8af69e348.x07d1b52af8293592(x7450cc1e48712286);
				break;
			case "clrTo":
				xd096be68e56d04ab.xefc54b39ecf0f4f0 = xd98b6fc8af69e348.x07d1b52af8293592(x7450cc1e48712286);
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
		return xd096be68e56d04ab;
	}

	private x14681578a79d12dc xfbb95760727fba1c()
	{
		return new x14681578a79d12dc(base.xca687bd498227c89.x2898a4fa3477fa50);
	}

	private xb9219c89b0d3221b xfec7dcb2b332f23d()
	{
		xb9219c89b0d3221b xb9219c89b0d3221b = new xb9219c89b0d3221b(base.xca687bd498227c89.x2898a4fa3477fa50);
		xb9219c89b0d3221b.x6389c51ad2820f52 = new x55c6a66cc28d5b86(x7450cc1e48712286.x075a63114fe24ce9("bright", 0.0));
		xb9219c89b0d3221b.x4f7155e57c89d548 = new x55c6a66cc28d5b86(x7450cc1e48712286.x075a63114fe24ce9("contrast", 0.0));
		return xb9219c89b0d3221b;
	}

	private x2c421831b88cb0f0 x90b1694bffdb80ac()
	{
		x2c421831b88cb0f0 x2c421831b88cb0f = new x2c421831b88cb0f0(base.xca687bd498227c89.x2898a4fa3477fa50);
		string xa66385d80d4d296f = x7450cc1e48712286.xa66385d80d4d296f;
		if (x7450cc1e48712286.x152cbadbfa8061b1(xa66385d80d4d296f))
		{
			x2c421831b88cb0f.x55319f8d2729ba13 = xd98b6fc8af69e348.xda09af88ab899a50(x7450cc1e48712286);
		}
		if (x7450cc1e48712286.x152cbadbfa8061b1(xa66385d80d4d296f))
		{
			x2c421831b88cb0f.x94bdef4042073f5c = xd98b6fc8af69e348.xda09af88ab899a50(x7450cc1e48712286);
		}
		return x2c421831b88cb0f;
	}
}
