using System;
using x6c95d9cf46ff5f25;
using x8b1f7613579e78d0;
using x8bb6b4f09b5230a5;
using x996431aaaaf00543;

namespace x95bd05bb616368d3;

internal class xb90920c8e2771a6c : xaaf059f0543cf507, x4c5a30c65d58a9ce
{
	private xcac04f3919526f00 xc63c1886c6cccc78;

	private xb513d822d3b4388b x978001e980687119;

	private xf4c807956df6c3b9 x7fe7d8a792654901;

	private x680f1b8709e9ba2a x8873baf13d517463;

	public x680f1b8709e9ba2a x0d063d5b2af153d5
	{
		get
		{
			if (x8873baf13d517463 == null)
			{
				x8873baf13d517463 = new xe867eb7d550cc299(base.xca687bd498227c89);
			}
			return x8873baf13d517463;
		}
		set
		{
			x8873baf13d517463 = value;
		}
	}

	public xcac04f3919526f00 xfea0ad465c7d1afc
	{
		get
		{
			if (xc63c1886c6cccc78 == null)
			{
				xc63c1886c6cccc78 = new x53230d9c3453c662(base.xca687bd498227c89);
			}
			return xc63c1886c6cccc78;
		}
		set
		{
			xc63c1886c6cccc78 = value;
		}
	}

	public xb513d822d3b4388b x8b9ff7d032a443a1
	{
		get
		{
			if (x978001e980687119 == null)
			{
				x978001e980687119 = new xb513d822d3b4388b(base.xca687bd498227c89);
			}
			return x978001e980687119;
		}
		set
		{
			x978001e980687119 = value;
		}
	}

	public xb90920c8e2771a6c(xe9481907c579c280 serviceLocator)
		: base(serviceLocator)
	{
	}

	public xf4c807956df6c3b9 xda09af88ab899a50(xc1dcd6189d01216e xe134235b3526fa75)
	{
		try
		{
			x4c28ef76f151d171(xe134235b3526fa75);
			if (xe134235b3526fa75.xa66385d80d4d296f != "pic")
			{
				return null;
			}
			xdd1351c8666408d9();
			return x7fe7d8a792654901;
		}
		catch (Exception)
		{
			return null;
		}
	}

	private void xdd1351c8666408d9()
	{
		x7fe7d8a792654901 = new xf4c807956df6c3b9();
		string xa66385d80d4d296f = x7450cc1e48712286.xa66385d80d4d296f;
		while (x7450cc1e48712286.x152cbadbfa8061b1(xa66385d80d4d296f))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "blipFill":
				x7fe7d8a792654901.xc84061bfd839e5fa = (xb8c0a122dcc2f776)xfea0ad465c7d1afc.xda09af88ab899a50(x7450cc1e48712286);
				break;
			case "spPr":
				x8b9ff7d032a443a1.x0b4a2dc14730c8a4(x7450cc1e48712286, x7fe7d8a792654901);
				break;
			case "style":
				x7fe7d8a792654901.xfe2178c1f916f36c = x0d063d5b2af153d5.xda09af88ab899a50(x7450cc1e48712286);
				break;
			case "extLst":
			case "nvPicPr":
				x10576afa17ca4f1f();
				break;
			case "AlternateContent":
				x44ea761ba7ed7dbe(x7fe7d8a792654901);
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
	}

	private void x44ea761ba7ed7dbe(x162d67570d6be3e3 x5770cdefd8931aa9)
	{
		while (x7450cc1e48712286.x152cbadbfa8061b1("AlternateContent"))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "Choice":
				x10576afa17ca4f1f();
				break;
			case "Fallback":
				x1f1760fae05e9ab9(x5770cdefd8931aa9);
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
	}

	private void x1f1760fae05e9ab9(x162d67570d6be3e3 x5770cdefd8931aa9)
	{
		while (x7450cc1e48712286.x152cbadbfa8061b1("Fallback"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x7450cc1e48712286.xa66385d80d4d296f) != null && xa66385d80d4d296f == "blipFill")
			{
				((xf4c807956df6c3b9)x5770cdefd8931aa9).xc84061bfd839e5fa = (xb8c0a122dcc2f776)xfea0ad465c7d1afc.xda09af88ab899a50(x7450cc1e48712286);
			}
			else
			{
				xf4732ad4641eec1a();
			}
		}
	}
}
