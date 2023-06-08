using System;
using System.Collections;
using System.Drawing;
using Aspose.Words;
using Aspose.Words.Drawing;
using x1c8faa688b1f0b0c;
using x59d6a4fc5007b7a4;
using x6a42c37b95e9caa1;
using x6c95d9cf46ff5f25;
using x99ec507695f2d4ff;

namespace x4adf554d20d941a6;

internal class xa67197c42bddc7dc : x56410a8dd70087c5, IComparable
{
	private readonly xcc8377767090013e x6ba0f85ec0f01e4f;

	private x3ee7f5c70fde3f94 x297d06efcc8aa140;

	private int x823c6b25cc2689d8 = -1;

	private xa67197c42bddc7dc x7801990773ef98b3;

	private xa67197c42bddc7dc xeca0238dce478771;

	private x00b4e2c077f699df x85953595c0e7ac6d;

	internal override int x1be93eed8950d961 => 1;

	internal override int xb0f146032f47c24e
	{
		get
		{
			if (base.x34251722ab416841.x109e3389933c23a8.xab6edfb47ff0b74c == WrapType.Inline)
			{
				return base.xb0f146032f47c24e;
			}
			return base.x887a0c79ecbe5ee3 + x79a071bfba0c5e7d;
		}
	}

	internal override int xbcd477821fdbd81b => x4574ea26106f0edb.x8d50b8a62ba1cd84((float)x6ba0f85ec0f01e4f.xb0f146032f47c24e);

	internal override int x887b872a95caaab5
	{
		get
		{
			if (x2ac6c66ecbcafe54)
			{
				return xc255c495fd9232ca.xdc1bf80853046136;
			}
			return x4574ea26106f0edb.x8d50b8a62ba1cd84((float)x6ba0f85ec0f01e4f.xdc1bf80853046136);
		}
	}

	internal override int x79a071bfba0c5e7d
	{
		get
		{
			if (!x1b4884baf08c8d62)
			{
				return Math.Max(0, base.x12c7317dc3e92ec0 + base.x705ed5f9769744e5.xbe1e23e7d5b43370);
			}
			return 0;
		}
	}

	internal override int x342336c67a7f5544 => 0;

	internal override int x3a04db961e36dc5b => 0;

	internal override StoryType xc0a853db762872fe => StoryType.Textbox;

	internal override int x5566e2d2acbd1fbe => 25604;

	internal override x4fdf549af9de6b97 x2d6658ad60c6ebe9
	{
		get
		{
			if (base.x2d6658ad60c6ebe9 == null)
			{
				xdc4867bff1715a4b x976d6143aeca9c = x3557aa8566455ba9.xb3b086e2e37b6e5b(this);
				xe6a5f3ec802a6d51 xe6a5f3ec802a6d = x3557aa8566455ba9.x2804a8815e0b23f5(this, x976d6143aeca9c);
				x42b8c317113a56e4 x42b8c317113a56e = new x42b8c317113a56e4(xe6a5f3ec802a6d);
				xa7492065dee59ad0 x5906905c888d3d = new xa7492065dee59ad0(this);
				x42b8c317113a56e.x6352d2f80acb683d(x5906905c888d3d);
				base.x2d6658ad60c6ebe9 = xe6a5f3ec802a6d.xc255c495fd9232ca;
			}
			return base.x2d6658ad60c6ebe9;
		}
		set
		{
			if (value == null)
			{
				x00b4e2c077f699df x00b4e2c077f699df2 = x9ade71c62908185e(x5aa7d09b258e0f23: false);
				if (x00b4e2c077f699df2 != null)
				{
					x398b3bd0acd94b61.x6fac24024cd1bb39(x00b4e2c077f699df2);
				}
			}
		}
	}

	internal override bool x2ac6c66ecbcafe54 => base.x34251722ab416841.x2ac6c66ecbcafe54;

	internal override bool x3032dc2ab2939cf9
	{
		get
		{
			switch (base.x34251722ab416841.x109e3389933c23a8.xab6edfb47ff0b74c)
			{
			case WrapType.TopBottom:
			case WrapType.Square:
			case WrapType.Tight:
				return true;
			default:
				return false;
			}
		}
	}

	internal Node x40212106aad8a8b0 => x6ba0f85ec0f01e4f.x40212106aad8a8b0;

	internal xa67197c42bddc7dc xd8cde6b694c3af46
	{
		get
		{
			return x7801990773ef98b3;
		}
		set
		{
			x7801990773ef98b3 = value;
		}
	}

	internal xa67197c42bddc7dc x92adfed6f1d8efe4
	{
		get
		{
			return xeca0238dce478771;
		}
		set
		{
			xeca0238dce478771 = value;
		}
	}

	internal string xc9bcfb2d9630b0c7 => x347b79f9c616f92c.x58c712b0d1d1c39b;

	internal xcc8377767090013e x347b79f9c616f92c => x6ba0f85ec0f01e4f;

	internal x00b4e2c077f699df x00b4e2c077f699df
	{
		get
		{
			return x9ade71c62908185e(x5aa7d09b258e0f23: true);
		}
		set
		{
			x85953595c0e7ac6d = value;
		}
	}

	internal bool x11261683cd6f7013
	{
		get
		{
			if (x40212106aad8a8b0 is Shape)
			{
				if (!x347b79f9c616f92c.x024a13cfae9ff232)
				{
					return xd8cde6b694c3af46 != null;
				}
				return true;
			}
			return false;
		}
	}

	internal xa67197c42bddc7dc(Node value)
	{
		x6ba0f85ec0f01e4f = xcc8377767090013e.x7a4c51050e4e7530(value);
		x6ba0f85ec0f01e4f.x291868888b5021b9(this);
	}

	internal override int x550cafc27071d020(bool x53fb38ed73772d62)
	{
		if (!x1b4884baf08c8d62)
		{
			return Math.Max(0, xbcd477821fdbd81b + base.x12c7317dc3e92ec0 - base.x705ed5f9769744e5.xbe1e23e7d5b43370);
		}
		return 0;
	}

	internal override x3ee7f5c70fde3f94 x0cdfd951d792f320(bool x5aa7d09b258e0f23)
	{
		if (x297d06efcc8aa140 == null && x5aa7d09b258e0f23)
		{
			x297d06efcc8aa140 = new x3ee7f5c70fde3f94(this);
		}
		return x297d06efcc8aa140;
	}

	internal override x56410a8dd70087c5 xa9d7e8f6fbdcbcfc(x56410a8dd70087c5 x7d95d971d8923f4c)
	{
		if (x7d95d971d8923f4c == null)
		{
			x7d95d971d8923f4c = new xa67197c42bddc7dc(x40212106aad8a8b0);
		}
		xa67197c42bddc7dc xa67197c42bddc7dc2 = (xa67197c42bddc7dc)x7d95d971d8923f4c;
		xa67197c42bddc7dc2.x772764427592d4bb = base.x772764427592d4bb;
		xa67197c42bddc7dc2.x823c6b25cc2689d8 = x823c6b25cc2689d8;
		xa67197c42bddc7dc2.x53111d6596d16a99 = x53111d6596d16a99;
		if (x297d06efcc8aa140 != null)
		{
			xa67197c42bddc7dc2.x297d06efcc8aa140 = x297d06efcc8aa140.x88419a4a590d9d13(xa67197c42bddc7dc2);
		}
		return base.xa9d7e8f6fbdcbcfc(x7d95d971d8923f4c);
	}

	internal override Point x588d7683a6d1fbd5()
	{
		if (base.x34251722ab416841.x109e3389933c23a8.x6f6877b222ed4153)
		{
			x109e3389933c23a8 x109e3389933c23a9 = xd4c1d21f07094800.x5f22ff83d28dc9ef(x109e3389933c23a8.xa04178fab0d78eb2(this));
			Rectangle x6ae4612a8469678e = x109e3389933c23a9.x6ae4612a8469678e;
			Point result = new Point(x6ae4612a8469678e.X, x6ae4612a8469678e.Y);
			if (x109e3389933c23a9.x752cfab9af626fd5)
			{
				x86accec882b7012a x86accec882b7012a2 = (x86accec882b7012a)xce4443deee105995(x954503abc583f675.x11db8fc7f469a2fc);
				if (x86accec882b7012a2.xc5464084edc8e226.x838c6c67b5953bb0.x133f2db9e5b5690d.xeb54885ba753f70e.x109e3389933c23a8.x6f6877b222ed4153)
				{
					Point point = x86accec882b7012a2.x2206903f9421fd4b();
					result.Offset(point.X, point.Y);
					Point point2 = x86accec882b7012a2.xc255c495fd9232ca.x2206903f9421fd4b();
					result.Offset(point2.X, point2.Y);
					Point location = xa38dda099d71aefb.xa1513663c12db78c(x86accec882b7012a2).Location;
					result.Offset(location.X, location.Y);
				}
				else
				{
					Point point3 = x86accec882b7012a2.x588d7683a6d1fbd5();
					result.Offset(point3.X, point3.Y);
				}
			}
			return result;
		}
		return base.x588d7683a6d1fbd5();
	}

	internal override void x7012609bcdb39574(x75b8b2f740aae644 x672ff13faf031f3d)
	{
		base.x7012609bcdb39574(x672ff13faf031f3d);
		x672ff13faf031f3d.x9b7df953ac1cd0f5(this);
	}

	internal xa67197c42bddc7dc x058e06676018641d()
	{
		xa67197c42bddc7dc xa67197c42bddc7dc2 = this;
		while (xa67197c42bddc7dc2.xd8cde6b694c3af46 != null)
		{
			xa67197c42bddc7dc2 = xa67197c42bddc7dc2.xd8cde6b694c3af46;
		}
		return xa67197c42bddc7dc2;
	}

	internal override void x52b190e626f65140()
	{
		if (x7801990773ef98b3 != null)
		{
			x7801990773ef98b3.x92adfed6f1d8efe4 = xeca0238dce478771;
		}
		if (xeca0238dce478771 != null)
		{
			xeca0238dce478771.xd8cde6b694c3af46 = x7801990773ef98b3;
		}
		x7801990773ef98b3 = null;
		xeca0238dce478771 = null;
		base.x52b190e626f65140();
	}

	internal bool x8da14380c3ea3537()
	{
		if (!x11261683cd6f7013)
		{
			return x2b3f292c0023faa6(this, null);
		}
		return true;
	}

	internal static bool x2b3f292c0023faa6(xa67197c42bddc7dc x5906905c888d3d98, Hashtable x6d394cddc56557db)
	{
		if (x5906905c888d3d98.xd181cfc9bf12b1ac)
		{
			return false;
		}
		if (NodeType.GroupShape == x5906905c888d3d98.x40212106aad8a8b0.NodeType)
		{
			x3ee7f5c70fde3f94 x3ee7f5c70fde3f95 = x5906905c888d3d98.x0cdfd951d792f320(x5aa7d09b258e0f23: false);
			x3ee7f5c70fde3f95.xb3a79d506b0e2f7f.x74f5a1ef3906e23c();
			while (x3ee7f5c70fde3f95.xb3a79d506b0e2f7f.x47f176deff0d42e2() && !x3ee7f5c70fde3f95.xb3a79d506b0e2f7f.x45ef6ccec2bafbfc)
			{
				if (x2b3f292c0023faa6((xa67197c42bddc7dc)x3ee7f5c70fde3f95.xb3a79d506b0e2f7f.x35cfcea4890f4e7d, x6d394cddc56557db) && x6d394cddc56557db == null)
				{
					return true;
				}
			}
		}
		else if (x5906905c888d3d98.xd8cde6b694c3af46 != null || x5906905c888d3d98.x347b79f9c616f92c.x024a13cfae9ff232)
		{
			x6d394cddc56557db?.Add(x5906905c888d3d98.x40212106aad8a8b0, x5906905c888d3d98);
			return true;
		}
		return false;
	}

	internal x00b4e2c077f699df x9ade71c62908185e(bool x5aa7d09b258e0f23)
	{
		if (x85953595c0e7ac6d == null && x5aa7d09b258e0f23)
		{
			x85953595c0e7ac6d = new x00b4e2c077f699df(this);
		}
		return x85953595c0e7ac6d;
	}

	public int CompareTo(object obj)
	{
		xa67197c42bddc7dc xa67197c42bddc7dc2 = (xa67197c42bddc7dc)obj;
		int num = base.x34251722ab416841.x39043a80f49a07e2.CompareTo(xa67197c42bddc7dc2.x34251722ab416841.x39043a80f49a07e2);
		if (num == 0)
		{
			num = -1;
		}
		return num;
	}
}
