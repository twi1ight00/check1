using System;
using System.Drawing;
using Aspose.Words;
using x6c95d9cf46ff5f25;

namespace x4adf554d20d941a6;

internal class x3ee7f5c70fde3f94 : xac6c82c74ce247fb
{
	private xa67197c42bddc7dc xd86e4bac41e028b8;

	internal override StoryType xfe6cdb7c00822bd9 => StoryType.Textbox;

	internal override bool x31fecf0961487c73 => false;

	internal override x398b3bd0acd94b61 x8b8a0a04b3aeaf3a
	{
		get
		{
			if (base.xa51d8d9790431b2b != null)
			{
				return base.xa51d8d9790431b2b.x8b8a0a04b3aeaf3a;
			}
			return null;
		}
		set
		{
			base.xa51d8d9790431b2b.x8b8a0a04b3aeaf3a = value;
		}
	}

	internal override x398b3bd0acd94b61 x7e2e5dd40daabc3b
	{
		get
		{
			if (base.xa51d8d9790431b2b != null)
			{
				return base.xa51d8d9790431b2b.x7e2e5dd40daabc3b;
			}
			return null;
		}
		set
		{
			base.xa51d8d9790431b2b.x7e2e5dd40daabc3b = value;
		}
	}

	internal xa67197c42bddc7dc x1452024de1251c74
	{
		get
		{
			return xd86e4bac41e028b8;
		}
		set
		{
			xd86e4bac41e028b8 = value;
		}
	}

	internal x3ee7f5c70fde3f94(xa67197c42bddc7dc anchor)
		: base(anchor.x2c8c6741422a1298)
	{
		xd86e4bac41e028b8 = anchor;
	}

	internal override x1073233de8252b3e x8db1e90bce56e416(x398b3bd0acd94b61 xd7e5673853e47af4)
	{
		throw new InvalidOperationException();
	}

	internal override void x7012609bcdb39574(x75b8b2f740aae644 x672ff13faf031f3d)
	{
		base.x7012609bcdb39574(x672ff13faf031f3d);
		x672ff13faf031f3d.xdcede94268fdbe18(this);
	}

	internal void xdff44e884fce055f(SizeF[] x66e167dd04a48f1c)
	{
		xec07da739623c926();
		int num = 0;
		x398b3bd0acd94b61 x398b3bd0acd94b62 = base.xa51d8d9790431b2b.x8b8a0a04b3aeaf3a;
		while (num < x66e167dd04a48f1c.Length && x398b3bd0acd94b62 != null)
		{
			int num2 = x4574ea26106f0edb.x8d50b8a62ba1cd84(x66e167dd04a48f1c[num].Width);
			int num3 = x4574ea26106f0edb.x8d50b8a62ba1cd84(x66e167dd04a48f1c[num].Height);
			if (num2 != x398b3bd0acd94b62.xdc1bf80853046136 || num3 != x398b3bd0acd94b62.xb0f146032f47c24e)
			{
				x398b3bd0acd94b62.xdc1bf80853046136 = num2;
				x398b3bd0acd94b62.xb0f146032f47c24e = num3;
				x398b3bd0acd94b62.x379ae16af0ba8e51(x6fcedf7742596b6c.xb3a3cb846e1136ea);
				x379ae16af0ba8e51();
			}
			num++;
			x398b3bd0acd94b62 = x398b3bd0acd94b62.xbc13914359462815;
		}
		xc3819e13f60dd8e6(xfad304b5f8f3bb5b: true);
	}

	private void xec07da739623c926()
	{
		xa67197c42bddc7dc xa67197c42bddc7dc2 = x1452024de1251c74;
		x00b4e2c077f699df x00b4e2c077f699df2 = (x00b4e2c077f699df)x8b8a0a04b3aeaf3a;
		if (x00b4e2c077f699df2 == null)
		{
			base.xa51d8d9790431b2b.xbc4db1b9481c1d31(null, null, xa67197c42bddc7dc2.x00b4e2c077f699df, x502d59bacbd3e16e: false);
		}
		xa67197c42bddc7dc xa67197c42bddc7dc3 = xa67197c42bddc7dc2;
		while (true)
		{
			if (xa67197c42bddc7dc3.x92adfed6f1d8efe4 != null && x00b4e2c077f699df2.xbc13914359462815 == null)
			{
				base.xa51d8d9790431b2b.xbc4db1b9481c1d31(x00b4e2c077f699df2, null, xa67197c42bddc7dc3.x92adfed6f1d8efe4.x00b4e2c077f699df, x502d59bacbd3e16e: false);
			}
			else if (xa67197c42bddc7dc3.x92adfed6f1d8efe4 == null)
			{
				break;
			}
			xa67197c42bddc7dc3 = xa67197c42bddc7dc3.x92adfed6f1d8efe4;
			x00b4e2c077f699df2 = (x00b4e2c077f699df)x00b4e2c077f699df2.xbc13914359462815;
		}
		while (x00b4e2c077f699df2.xbc13914359462815 != null)
		{
			base.xa51d8d9790431b2b.x844530889595db77(x00b4e2c077f699df2.xbc13914359462815);
		}
	}

	internal x3ee7f5c70fde3f94 x88419a4a590d9d13(xa67197c42bddc7dc xf0f5907c77eeefed)
	{
		x3ee7f5c70fde3f94 x3ee7f5c70fde3f95 = xf0f5907c77eeefed.x0cdfd951d792f320(x5aa7d09b258e0f23: true);
		xc99ce4f545e9c120.xc1d98b06788daae1(this, x3ee7f5c70fde3f95);
		return x3ee7f5c70fde3f95;
	}
}
