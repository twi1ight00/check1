using System.Drawing;
using Aspose.Words;
using Aspose.Words.Drawing;
using x6c95d9cf46ff5f25;

namespace x4adf554d20d941a6;

internal class xa38dda099d71aefb : x109e3389933c23a8
{
	private static readonly int x0dfc5cfcd8168766 = x4574ea26106f0edb.x8d50b8a62ba1cd84(19.0);

	internal override int xf8c20af9fe5edca0 => 21595;

	internal override int x5c43f9b06667f51f => x0dfc5cfcd8168766;

	protected override bool YMustBeInsidePage
	{
		get
		{
			if (xc8d1bb1390d5266d)
			{
				return base.x705ed5f9769744e5.x5d0ebb82ae68cc43 != RelativeVerticalPosition.Paragraph;
			}
			return true;
		}
	}

	private bool xc8d1bb1390d5266d => ((x7c1e2b821e8b8220)base.x1452024de1251c74).x53111d6596d16a99.xfe6cdb7c00822bd9 == StoryType.MainText;

	internal static xa38dda099d71aefb xdef7f68a22ec051d(x398b3bd0acd94b61 xd7e5673853e47af4)
	{
		if (xa7a98231d4a67a0f.x1f634e91b242c296(xd7e5673853e47af4) >= 0)
		{
			return null;
		}
		x694f001896973fe3 x694f001896973fe4 = (x694f001896973fe3)xd7e5673853e47af4;
		return new xa38dda099d71aefb(x694f001896973fe4.x838c6c67b5953bb0.x133f2db9e5b5690d, x694f001896973fe4, x694f001896973fe4.x838c6c67b5953bb0.x133f2db9e5b5690d.xbc3a1ad7f75a88f9.xbc3a1ad7f75a88f9);
	}

	internal static Rectangle xa1513663c12db78c(x86accec882b7012a xe6de5e5fa2d44af5)
	{
		x7c1e2b821e8b8220 x133f2db9e5b5690d = xe6de5e5fa2d44af5.xc5464084edc8e226.x838c6c67b5953bb0.x133f2db9e5b5690d;
		x694f001896973fe3 x694f001896973fe4 = xe6de5e5fa2d44af5.x798272c9805cc00e.xefa751568d49862e();
		if (!x133f2db9e5b5690d.xeb54885ba753f70e.x109e3389933c23a8.x6f6877b222ed4153)
		{
			x694f001896973fe3 x694f001896973fe5 = x694f001896973fe4.x7467a47ca44f1964();
			Point point = x694f001896973fe4.x588d7683a6d1fbd5();
			return new Rectangle(point.X, point.Y, x694f001896973fe5.x9bcb07e204e30218 - x694f001896973fe4.xc821290d7ecc08bf, xe49914456d73f03a.xb2d321e96d093f95(x133f2db9e5b5690d));
		}
		x109e3389933c23a8 xdcf7b74ddd6caa = xdef7f68a22ec051d(x694f001896973fe4);
		x109e3389933c23a8 x109e3389933c23a9 = xd4c1d21f07094800.x5f22ff83d28dc9ef(xdcf7b74ddd6caa);
		if (x109e3389933c23a9.xc255c495fd9232ca is x86accec882b7012a)
		{
			x86accec882b7012a xe6de5e5fa2d44af6 = (x86accec882b7012a)x109e3389933c23a9.xc255c495fd9232ca;
			Rectangle rectangle = xa1513663c12db78c(xe6de5e5fa2d44af6);
			return new Rectangle(rectangle.X + x109e3389933c23a9.x6ae4612a8469678e.X, rectangle.Y + x109e3389933c23a9.x6ae4612a8469678e.Y, x109e3389933c23a9.x6ae4612a8469678e.Width, x109e3389933c23a9.x6ae4612a8469678e.Height);
		}
		return x109e3389933c23a9.x6ae4612a8469678e;
	}

	internal override void xc3819e13f60dd8e6()
	{
		for (x398b3bd0acd94b61 x398b3bd0acd94b62 = base.x38ced5a01a389303; x398b3bd0acd94b62 != null; x398b3bd0acd94b62 = x398b3bd0acd94b62.xf34a54c031e96d83())
		{
			x398b3bd0acd94b62.x9e19f5bd0a6dd5b7(base.x38ced5a01a389303.xc255c495fd9232ca);
			x694f001896973fe3 x694f001896973fe4 = (x694f001896973fe3)x398b3bd0acd94b62;
			x694f001896973fe4.x109e3389933c23a8 = this;
			x36d44214ff2c1e83.xc3819e13f60dd8e6(x694f001896973fe4);
			base.xed3e432f7c9bf846 = ((x7c1e2b821e8b8220)base.x1452024de1251c74).xbc3a1ad7f75a88f9.x7e2e5dd40daabc3b;
			if (x398b3bd0acd94b62 == base.xed3e432f7c9bf846)
			{
				break;
			}
		}
		x36d44214ff2c1e83.x082120bd09385f9a((x694f001896973fe3)base.x38ced5a01a389303);
	}

	internal override int xcc69ae5a5063e790()
	{
		x694f001896973fe3 x694f001896973fe4 = (x694f001896973fe3)base.x38ced5a01a389303;
		if (!x694f001896973fe4.xc0e56f2fca892328 || !x694f001896973fe4.x332a8eedb847940d.xc0e56f2fca892328)
		{
			return 0;
		}
		int num = ((!base.x752cfab9af626fd5) ? base.x38ced5a01a389303.xc255c495fd9232ca.x588d7683a6d1fbd5().Y : 0);
		for (x398b3bd0acd94b61 x398b3bd0acd94b62 = base.x38ced5a01a389303.x9b2bbd3d05bf558b(); x398b3bd0acd94b62 != null; x398b3bd0acd94b62 = x398b3bd0acd94b62.x9b2bbd3d05bf558b())
		{
			if (!xa7a98231d4a67a0f.xdd724c73394f5594(x398b3bd0acd94b62))
			{
				return x398b3bd0acd94b62.xc821290d7ecc08bf + x398b3bd0acd94b62.x319720dedc082a9d + num;
			}
		}
		return base.x38ced5a01a389303.xc255c495fd9232ca.x3dcafc2d758260e1 + num;
	}

	protected override int GetYCorrectionBottom()
	{
		int result = base.GetYCorrectionBottom();
		x7c1e2b821e8b8220 x7c1e2b821e8b8221 = (x7c1e2b821e8b8220)base.x1452024de1251c74;
		bool flag = !xc8d1bb1390d5266d;
		bool xbc841acfecc8b0b = x7c1e2b821e8b8221.x2c8c6741422a1298.x80f061859cd048ae.xde015839cc88f18d.xbc841acfecc8b0b8;
		if (flag && xbc841acfecc8b0b)
		{
			xb1f375aa1b12d10f xb1f375aa1b12d10f2 = (xb1f375aa1b12d10f)x7c1e2b821e8b8221.x53111d6596d16a99;
			if (!xb1f375aa1b12d10f2.x9391000fee92b9fe)
			{
				result = base.xa65184d44a47025b.x1d7b771e95a9abb5.xc821290d7ecc08bf + base.xa65184d44a47025b.x3c1c340351d94fbd.xf48cd6e82340ac70.x9c94a32b8fac5210;
			}
		}
		return result;
	}

	protected override Rectangle GetBoundsImpl()
	{
		x7c1e2b821e8b8220 x7c1e2b821e8b8221 = (x7c1e2b821e8b8220)base.x1452024de1251c74;
		int num = xe49914456d73f03a.xb2d321e96d093f95(x7c1e2b821e8b8221);
		int num2 = x795e09a07e435cf4(num);
		if (!base.x752cfab9af626fd5)
		{
			if (base.x705ed5f9769744e5.x0fcdf9c7f9f2eb9e == RelativeHorizontalPosition.Page && (base.x705ed5f9769744e5.xab67cb9464a3325b == HorizontalAlignment.Left || base.x705ed5f9769744e5.xab67cb9464a3325b == HorizontalAlignment.Right))
			{
				num2 -= xa3a992e8cf81dabe.xa1de765ea88f71a2(x7c1e2b821e8b8221.x5d6d04c35215bc51.x96ac59f61797f5b9);
				num2 += xa3a992e8cf81dabe.xb5e088b6b5dc233d(x7c1e2b821e8b8221.x5d6d04c35215bc51.xc1277af2cd8d654e.x2f5fd09b3d327fb0);
				num2 += ((base.x705ed5f9769744e5.xab67cb9464a3325b == HorizontalAlignment.Left) ? (-base.x705ed5f9769744e5.xc9ee264fd8d7484e) : base.x705ed5f9769744e5.xb5465b18223f6375);
			}
			else if (base.x705ed5f9769744e5.xab67cb9464a3325b == HorizontalAlignment.Right)
			{
				num2 += xa3a992e8cf81dabe.xb5e088b6b5dc233d(x7c1e2b821e8b8221.x5d6d04c35215bc51.xc1277af2cd8d654e.x2f5fd09b3d327fb0);
			}
			else if (base.x705ed5f9769744e5.xab67cb9464a3325b != HorizontalAlignment.Center)
			{
				num2 -= xa3a992e8cf81dabe.xa1de765ea88f71a2(x7c1e2b821e8b8221.x5d6d04c35215bc51.x96ac59f61797f5b9);
			}
		}
		int num3 = base.xed3e432f7c9bf846.x9bcb07e204e30218 - base.x38ced5a01a389303.xc821290d7ecc08bf;
		int y = ((base.x38ced5a01a389303.x332a8eedb847940d.xc0e56f2fca892328 && base.x38ced5a01a389303.xc0e56f2fca892328) ? x29b834e8e9ff09ed(num3) : ((base.xc255c495fd9232ca.x954503abc583f675 == x954503abc583f675.xa65184d44a47025b) ? ((xc7f90d9c7c51cede)base.xc255c495fd9232ca).xd985b37e5f570f69 : 0));
		Rectangle xda73fcb97c77d = new Rectangle(num2, y, num, num3);
		return x0db3a2811a364ada(xda73fcb97c77d);
	}

	protected override Rectangle GetWrapBoundsImpl(Rectangle bounds)
	{
		x387d31b7e6ea1182 x5d6d04c35215bc = ((x7c1e2b821e8b8220)base.x1452024de1251c74).x5d6d04c35215bc51;
		x56b4eac69b5fa65b x96ac59f61797f5b = x5d6d04c35215bc.x96ac59f61797f5b9;
		x56b4eac69b5fa65b x2f5fd09b3d327fb = x5d6d04c35215bc.xc1277af2cd8d654e.x2f5fd09b3d327fb0;
		int num = base.x705ed5f9769744e5.xc9ee264fd8d7484e + xa3a992e8cf81dabe.x084819436cb905ef(x96ac59f61797f5b, BorderType.Left) / 2;
		int x027754ea = base.x705ed5f9769744e5.x027754ea63804113;
		return new Rectangle(bounds.X - num, bounds.Y - x027754ea, bounds.Width + num + xa3a992e8cf81dabe.x084819436cb905ef(x2f5fd09b3d327fb, BorderType.Right) / 2 + base.x705ed5f9769744e5.xb5465b18223f6375, bounds.Height + x027754ea + base.x705ed5f9769744e5.x4dc0360afcf78834);
	}

	private xa38dda099d71aefb(x7c1e2b821e8b8220 anchor, x694f001896973fe3 first, x694f001896973fe3 last)
		: base(anchor, anchor.xeb54885ba753f70e.x109e3389933c23a8, x8bdb27e5414cff5e(anchor, first), x8fa20b9bf060a648(anchor, last))
	{
	}

	private static x398b3bd0acd94b61 x8bdb27e5414cff5e(x7c1e2b821e8b8220 xf0f5907c77eeefed, x398b3bd0acd94b61 x62584df2cb5d40dd)
	{
		if (x62584df2cb5d40dd != null)
		{
			return x62584df2cb5d40dd;
		}
		return xf0f5907c77eeefed.x5d6d04c35215bc51.x8b8a0a04b3aeaf3a;
	}

	private static x398b3bd0acd94b61 x8fa20b9bf060a648(x7c1e2b821e8b8220 xf0f5907c77eeefed, x398b3bd0acd94b61 x2aa5114a5da7d6c8)
	{
		if (x2aa5114a5da7d6c8 != null)
		{
			return x2aa5114a5da7d6c8;
		}
		return xf0f5907c77eeefed.xbc3a1ad7f75a88f9.x7e2e5dd40daabc3b;
	}
}
