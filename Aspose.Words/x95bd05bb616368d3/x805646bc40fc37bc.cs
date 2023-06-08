using System;
using x6c95d9cf46ff5f25;
using x8bb6b4f09b5230a5;
using x996431aaaaf00543;

namespace x95bd05bb616368d3;

internal class x805646bc40fc37bc : xaaf059f0543cf507, xccdea6f716a1a438
{
	private xb513d822d3b4388b x978001e980687119;

	private x9345853531733647 x317be79405176667;

	private x680f1b8709e9ba2a x8873baf13d517463;

	private x4bce37a68a46eb2b x6b145c91b525cad4;

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

	public x4bce37a68a46eb2b xd98a1954620007f2
	{
		get
		{
			if (x6b145c91b525cad4 == null)
			{
				x6b145c91b525cad4 = new xeac163f5930e8db6(base.xca687bd498227c89);
			}
			return x6b145c91b525cad4;
		}
		set
		{
			x6b145c91b525cad4 = value;
		}
	}

	public x805646bc40fc37bc(xe9481907c579c280 serviceLocator)
		: base(serviceLocator)
	{
	}

	public x9345853531733647 xda09af88ab899a50(xc1dcd6189d01216e xe134235b3526fa75)
	{
		x4c28ef76f151d171(xe134235b3526fa75);
		try
		{
			switch (xe134235b3526fa75.xa66385d80d4d296f)
			{
			case "sp":
			case "cxnSp":
				xfe4f7dca36c0076c();
				return x317be79405176667;
			default:
				return null;
			}
		}
		catch (Exception)
		{
			return null;
		}
	}

	private void xfe4f7dca36c0076c()
	{
		x317be79405176667 = new x9345853531733647();
		string xa66385d80d4d296f = x7450cc1e48712286.xa66385d80d4d296f;
		while (x7450cc1e48712286.x152cbadbfa8061b1(xa66385d80d4d296f))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "spPr":
				x8b9ff7d032a443a1.x0b4a2dc14730c8a4(x7450cc1e48712286, x317be79405176667);
				break;
			case "style":
				x317be79405176667.xfe2178c1f916f36c = x0d063d5b2af153d5.xda09af88ab899a50(x7450cc1e48712286);
				break;
			case "txSp":
				x317be79405176667.x97c4cdb7669669f2 = xd98a1954620007f2.xda09af88ab899a50(x7450cc1e48712286);
				break;
			case "extLst":
			case "nvSpPr":
				x10576afa17ca4f1f();
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
	}
}
