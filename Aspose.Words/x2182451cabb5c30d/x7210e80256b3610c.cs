using System.Drawing;
using Aspose.Words.Drawing;
using x011d489fb9df7027;
using x1a62aaf14e3c5909;
using x556d8f9846e43329;
using x6c95d9cf46ff5f25;

namespace x2182451cabb5c30d;

internal class x7210e80256b3610c : x3b57052406b93b82
{
	private readonly ShapeBase x317be79405176667;

	private readonly bool x5c0098dceab7194c;

	private int x933fbdb4e4f6c448;

	private int x51556d800a83de54;

	private int xed5d42e5ec2e2a9e;

	private int xc8ff13cb9454e1a9;

	private x98e094d01e7e8323 xe6fc4ec5649515c0;

	private bool xcf3bebdb5c87801c;

	private bool x1d3badb6a1dd3224;

	private xf7125312c7ee115c xf7125312c7ee115c => x317be79405176667.xf7125312c7ee115c;

	internal x7210e80256b3610c(xe5e546ef5f0503b2 context, ShapeBase shape, bool shouldEndShape)
		: base(context)
	{
		x317be79405176667 = shape;
		x5c0098dceab7194c = shouldEndShape;
		x933fbdb4e4f6c448 = 0;
		x51556d800a83de54 = 0;
		xed5d42e5ec2e2a9e = 0;
		xc8ff13cb9454e1a9 = 0;
	}

	internal override void x41e7a76e7e854e6e(x03f56b37a0050a82 x153c99a852375422)
	{
		if (x28fcdc775a1d069c.xb778e4a87af27d7a)
		{
			x317be79405176667.xd06a0f106e67d743 = true;
		}
		x25099a8bbbd55d1c x3146d638ec = base.x1a55de3a01c1c82d.x3146d638ec378671;
		if (x3146d638ec == x25099a8bbbd55d1c.x9d3c3c4c9f15e637)
		{
			base.xe1410f585439c7d4.xb2930715346a6867();
			x1d3badb6a1dd3224 = true;
		}
		else
		{
			base.x41e7a76e7e854e6e(x153c99a852375422);
		}
	}

	internal override void xa4085ff83f9ddeeb()
	{
		switch (base.x1a55de3a01c1c82d.x3146d638ec378671)
		{
		case x25099a8bbbd55d1c.xa9993ed2e0c64574:
		case x25099a8bbbd55d1c.x0bd1211c8c0ee25f:
		case x25099a8bbbd55d1c.xf7c62d7842139957:
			x372eef8e657a52dd();
			if ((!x317be79405176667.xa170cce2bc40bdf5 || base.x1a55de3a01c1c82d.x3146d638ec378671 != x25099a8bbbd55d1c.xf7c62d7842139957) && x5c0098dceab7194c && x317be79405176667 != base.x2c8c6741422a1298.BackgroundShape && !x317be79405176667.xd06a0f106e67d743)
			{
				base.xe1410f585439c7d4.x63fb29d61f50770e(x317be79405176667);
			}
			break;
		case x25099a8bbbd55d1c.x9d3c3c4c9f15e637:
			base.xe1410f585439c7d4.x6c71b8bd0c5c4b9a();
			x1d3badb6a1dd3224 = false;
			break;
		default:
			base.xa4085ff83f9ddeeb();
			break;
		}
	}

	private void x372eef8e657a52dd()
	{
		if (x317be79405176667.IsTopLevel)
		{
			x5a479118db43fa5e.x45e7e197dcc9dd27(x317be79405176667, x933fbdb4e4f6c448, xed5d42e5ec2e2a9e, x51556d800a83de54, xc8ff13cb9454e1a9);
		}
		if (xe6fc4ec5649515c0 == null)
		{
			return;
		}
		xe6fc4ec5649515c0.x9c4f08d3e576056e();
		if (x317be79405176667.IsGroup)
		{
			x317be79405176667.CoordOrigin = new Point(xe6fc4ec5649515c0.x322b9608237bbe85, xe6fc4ec5649515c0.x9ffbaf9f6bbd17a6);
			x317be79405176667.x0ac950b592cc7720(new Size(xe6fc4ec5649515c0.x638f80cf1be349b4, xe6fc4ec5649515c0.xef90ff597efa30e4));
		}
		if (!x317be79405176667.IsTopLevel)
		{
			x5a479118db43fa5e.xe63b9d2198d90be1(x317be79405176667, xe6fc4ec5649515c0.x0654b5354ff47810, xe6fc4ec5649515c0.x8d139c8691518897, xe6fc4ec5649515c0.x91e9d99c90d99869, xe6fc4ec5649515c0.x4143970b8a1ffb81);
		}
		if (x0d299f323d241756.x5959bccb67bbf051(xe6fc4ec5649515c0.x1cdb46ecf83a213d))
		{
			if (xe6fc4ec5649515c0.x3ad5ef377b8a9d01)
			{
				xf7125312c7ee115c.xae20093bed1e48a8(4104, xe6fc4ec5649515c0.x1cdb46ecf83a213d);
			}
			else
			{
				xf7125312c7ee115c.xae20093bed1e48a8(4103, xe6fc4ec5649515c0.x1cdb46ecf83a213d);
			}
		}
		x30145fee5dd2eb06.x96bbefc795cf6d84(x317be79405176667.xf7125312c7ee115c);
		x317be79405176667.x8934557a18f73b70 = xcf3bebdb5c87801c && xe6fc4ec5649515c0.xac9731dd322f2036;
		if (x317be79405176667.x895b1223bcc162ac && !x317be79405176667.xf7125312c7ee115c.x263d579af1d0d43f(1980))
		{
			x317be79405176667.x0817d5cde9e19bf6(1980, true);
		}
	}

	internal override void xa2d8e36cb99ac0f4(x03f56b37a0050a82 x153c99a852375422)
	{
		if (x1d3badb6a1dd3224 && !x317be79405176667.xa170cce2bc40bdf5)
		{
			base.xa2d8e36cb99ac0f4(x153c99a852375422);
			return;
		}
		switch (x153c99a852375422.x1dafd189c5465293())
		{
		case "\\shplid":
			x317be79405176667.xea1e81378298fa81 = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\shpleft":
			x933fbdb4e4f6c448 = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\shpright":
			xed5d42e5ec2e2a9e = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\shptop":
			x51556d800a83de54 = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\shpbottom":
			xc8ff13cb9454e1a9 = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\shpbxignore":
			xf7125312c7ee115c.x52b190e626f65140(912);
			break;
		case "\\shpbyignore":
			xf7125312c7ee115c.x52b190e626f65140(914);
			break;
		case "\\shpz":
			x317be79405176667.ZOrder = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\shpfblwtxt":
			x317be79405176667.BehindText = x153c99a852375422.x1ad7968449b109cd();
			break;
		case "\\shpwr":
			if (x317be79405176667.WrapType != 0)
			{
				x317be79405176667.WrapType = (WrapType)x153c99a852375422.xd6f9e3c5ae6509d7();
			}
			break;
		case "\\shpwrk":
			x317be79405176667.WrapSide = (WrapSide)x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\shplockanchor":
			x317be79405176667.AnchorLocked = true;
			break;
		case "\\defshp":
			xcf3bebdb5c87801c = true;
			break;
		default:
			x1bc3c2ba1cc36a9a(x153c99a852375422);
			break;
		}
	}

	private void x1bc3c2ba1cc36a9a(x03f56b37a0050a82 x153c99a852375422)
	{
		object obj = x94f5d65be6ba39b4.x1349f6b2c2f5156d(x153c99a852375422.x1dafd189c5465293());
		if (obj != null)
		{
			x317be79405176667.RelativeHorizontalPosition = (RelativeHorizontalPosition)obj;
			return;
		}
		obj = x94f5d65be6ba39b4.xb223821a507a8658(x153c99a852375422.x1dafd189c5465293());
		if (obj != null)
		{
			x317be79405176667.RelativeVerticalPosition = (RelativeVerticalPosition)obj;
		}
	}

	internal override x77fb5b1d5c73757b x3e0bce851c12a688(xbf575e106f2f2373 x8d3f74e5f925679c)
	{
		switch (x8d3f74e5f925679c.x3146d638ec378671)
		{
		case x25099a8bbbd55d1c.x5d3b3ebc2b4d6f07:
		case x25099a8bbbd55d1c.x9d3c3c4c9f15e637:
			return this;
		case x25099a8bbbd55d1c.xe16353313317d8a8:
			if (xe6fc4ec5649515c0 == null)
			{
				xe6fc4ec5649515c0 = new x98e094d01e7e8323(x28fcdc775a1d069c, x317be79405176667);
			}
			return xe6fc4ec5649515c0;
		case x25099a8bbbd55d1c.x71d39fdf56861cca:
			if (x317be79405176667.ShapeType != ShapeType.TextBox)
			{
				return new xc201253ba36819ef(x28fcdc775a1d069c, (Shape)x317be79405176667);
			}
			return new xc201253ba36819ef(x28fcdc775a1d069c);
		default:
			return base.x3e0bce851c12a688(x8d3f74e5f925679c);
		}
	}
}
