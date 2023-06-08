using System;
using System.Drawing;
using Aspose.Words;
using x6c95d9cf46ff5f25;

namespace x4adf554d20d941a6;

internal class xa4342d41912fa853 : x109e3389933c23a8
{
	private int xd74c65b8d28b1740 = int.MinValue;

	private int x8918dc7c534575e5 = int.MinValue;

	private int x933fbdb4e4f6c448 = int.MinValue;

	private int x51556d800a83de54 = int.MinValue;

	private int xed5d42e5ec2e2a9e = int.MinValue;

	private int xc8ff13cb9454e1a9 = int.MinValue;

	private static readonly int x31bf8571b6aca769 = x4574ea26106f0edb.x8d50b8a62ba1cd84(72.0);

	internal override int xf8c20af9fe5edca0 => 21537;

	internal override int x5c43f9b06667f51f => x31bf8571b6aca769;

	protected override bool YMustBeInsidePage => true;

	internal static xa4342d41912fa853 xdef7f68a22ec051d(x398b3bd0acd94b61 xd7e5673853e47af4)
	{
		if (xa7a98231d4a67a0f.x1f634e91b242c296(xd7e5673853e47af4) <= 0)
		{
			return null;
		}
		x8d9303345f12a846 x8d9303345f12a847 = null;
		if (xd7e5673853e47af4 is x694f001896973fe3)
		{
			x694f001896973fe3 x694f001896973fe4 = (x694f001896973fe3)xd7e5673853e47af4;
			x8d9303345f12a847 = xa7a98231d4a67a0f.x6382c04c8adf7d6a(x694f001896973fe4.x838c6c67b5953bb0.x133f2db9e5b5690d);
		}
		else if (xd7e5673853e47af4 is xf6937c72cebe4ad1)
		{
			xf6937c72cebe4ad1 xf6937c72cebe4ad2 = (xf6937c72cebe4ad1)xd7e5673853e47af4;
			x8d9303345f12a847 = xf6937c72cebe4ad2.x406d8cd2af514771;
		}
		if (x8d9303345f12a847 == null)
		{
			return null;
		}
		x398b3bd0acd94b61 last = xa7a98231d4a67a0f.x2e70f507d5de690a(x8d9303345f12a847);
		x398b3bd0acd94b61 x398b3bd0acd94b62 = xa7a98231d4a67a0f.xb9a87c7e44673df1(x8d9303345f12a847);
		if (x398b3bd0acd94b62 is x694f001896973fe3)
		{
			x8d9303345f12a847 = xa7a98231d4a67a0f.x6382c04c8adf7d6a((x7c1e2b821e8b8220)x398b3bd0acd94b62.xce4443deee105995(x954503abc583f675.xa19781cfbe8b4961).x332a8eedb847940d.x332a8eedb847940d);
		}
		return new xa4342d41912fa853(x8d9303345f12a847, x398b3bd0acd94b62, last);
	}

	internal override void xc3819e13f60dd8e6()
	{
		int num = ((base.x705ed5f9769744e5.xdc1bf80853046136 > 0) ? base.x705ed5f9769744e5.xdc1bf80853046136 : base.x38ced5a01a389303.xc255c495fd9232ca.xdc1bf80853046136);
		int num2 = x00358ffa9c9f03fc(num);
		xd74c65b8d28b1740 = ((num2 < 0) ? num : num2);
		x8918dc7c534575e5 = x3cd290e44f1ea7e5();
		x933fbdb4e4f6c448 = 0;
		x51556d800a83de54 = 0;
		xed5d42e5ec2e2a9e = 0;
		xc8ff13cb9454e1a9 = 0;
		if (x144b45103587413e() != 0)
		{
			if (num2 >= 0)
			{
				x8918dc7c534575e5 = xd74c65b8d28b1740;
				xd74c65b8d28b1740 = base.xed3e432f7c9bf846.x9bcb07e204e30218 - base.x38ced5a01a389303.xc821290d7ecc08bf;
			}
			else
			{
				x379ae16af0ba8e51();
				x1d76cba86350fef5(x8918dc7c534575e5);
			}
		}
		Point point = xfceec69e0a13f319();
		x933fbdb4e4f6c448 += point.X;
		xed5d42e5ec2e2a9e += point.Y;
		x6a5dfbe40d9f2931();
		x886809912f189707();
	}

	internal override int xcc69ae5a5063e790()
	{
		for (x398b3bd0acd94b61 x398b3bd0acd94b62 = base.x38ced5a01a389303.x9b2bbd3d05bf558b(); x398b3bd0acd94b62 != null; x398b3bd0acd94b62 = x398b3bd0acd94b62.x9b2bbd3d05bf558b())
		{
			if (!xa7a98231d4a67a0f.xdd724c73394f5594(x398b3bd0acd94b62))
			{
				return x398b3bd0acd94b62.xc821290d7ecc08bf + x398b3bd0acd94b62.x319720dedc082a9d + base.x38ced5a01a389303.xc255c495fd9232ca.x588d7683a6d1fbd5().Y;
			}
		}
		return base.x38ced5a01a389303.xc255c495fd9232ca.x3dcafc2d758260e1 + base.x38ced5a01a389303.xc255c495fd9232ca.x588d7683a6d1fbd5().Y;
	}

	protected override Rectangle GetBoundsImpl()
	{
		int x = x795e09a07e435cf4(xd74c65b8d28b1740);
		int y = xfad6ddcd598b43e5(x29b834e8e9ff09ed(x8918dc7c534575e5));
		Rectangle xda73fcb97c77d = new Rectangle(x, y, xd74c65b8d28b1740, x8918dc7c534575e5);
		return x0db3a2811a364ada(xda73fcb97c77d);
	}

	protected override Rectangle GetWrapBoundsImpl(Rectangle bounds)
	{
		int num = x933fbdb4e4f6c448 + base.x705ed5f9769744e5.xc9ee264fd8d7484e;
		int num2 = x51556d800a83de54 + base.x705ed5f9769744e5.x027754ea63804113;
		return new Rectangle(bounds.X - num, bounds.Y - num2, bounds.Width + num + xed5d42e5ec2e2a9e + base.x705ed5f9769744e5.xb5465b18223f6375, bounds.Height + num2 + xc8ff13cb9454e1a9 + base.x705ed5f9769744e5.x4dc0360afcf78834);
	}

	private void x6a5dfbe40d9f2931()
	{
		int num = ((x144b45103587413e() != 0) ? xd74c65b8d28b1740 : x8918dc7c534575e5) - (base.xed3e432f7c9bf846.x9bcb07e204e30218 - base.x38ced5a01a389303.xc821290d7ecc08bf);
		if (num > 0)
		{
			base.xed3e432f7c9bf846.xb0f146032f47c24e += num;
		}
	}

	private int x144b45103587413e()
	{
		switch (base.x705ed5f9769744e5.x2c5926113e101674)
		{
		case TextOrientation.Upward:
			return -1;
		case TextOrientation.Downward:
		case TextOrientation.VerticalFarEast:
			return 1;
		default:
			return 0;
		}
	}

	private Point xfceec69e0a13f319()
	{
		x398b3bd0acd94b61 x398b3bd0acd94b62 = base.xed3e432f7c9bf846.xf34a54c031e96d83();
		int num = 0;
		int num2 = 0;
		xc63cc34daaa2e2d9 xc63cc34daaa2e2d10 = base.x38ced5a01a389303.x332a8eedb847940d;
		while (xc63cc34daaa2e2d10 != null && (x398b3bd0acd94b62 == null || xc63cc34daaa2e2d10 != x398b3bd0acd94b62.x332a8eedb847940d))
		{
			if (xc63cc34daaa2e2d10.x5a5e07e9fa12451a == x5a5e07e9fa12451a.xfdc1a17f479acc42)
			{
				num = Math.Max(num, ((x8d9303345f12a846)xc63cc34daaa2e2d10).xa79651e2f1a1416e.xb70a9d14469748bf.get_xe6d4b1b411ed94b5(BorderType.Left).x0b5855089a074d93);
				num2 = Math.Max(num2, ((x8d9303345f12a846)xc63cc34daaa2e2d10).xa79651e2f1a1416e.xb70a9d14469748bf.get_xe6d4b1b411ed94b5(BorderType.Right).x0b5855089a074d93);
			}
			xc63cc34daaa2e2d10 = xc63cc34daaa2e2d10.xbc13914359462815;
		}
		return new Point(num, num2);
	}

	private Point x8358385b8a6410dc()
	{
		int x = 0;
		if (base.x38ced5a01a389303.x954503abc583f675 == x954503abc583f675.x48cc0c3eaf9f5f05)
		{
			x = ((xf6937c72cebe4ad1)base.x38ced5a01a389303).x406d8cd2af514771.xa79651e2f1a1416e.xb70a9d14469748bf.get_xe6d4b1b411ed94b5(BorderType.Top).x0b5855089a074d93;
		}
		int y = 0;
		if (base.xed3e432f7c9bf846.x954503abc583f675 == x954503abc583f675.x48cc0c3eaf9f5f05)
		{
			y = ((xf6937c72cebe4ad1)base.xed3e432f7c9bf846).x406d8cd2af514771.xa79651e2f1a1416e.xb70a9d14469748bf.get_xe6d4b1b411ed94b5(BorderType.Bottom).x0b5855089a074d93;
		}
		return new Point(x, y);
	}

	private int x00358ffa9c9f03fc(int x9b0739496f8b5475)
	{
		x1d76cba86350fef5(x9b0739496f8b5475);
		bool flag = (base.x38ced5a01a389303 == base.xed3e432f7c9bf846 && base.x38ced5a01a389303.x954503abc583f675 == x954503abc583f675.x48cc0c3eaf9f5f05) || (base.x38ced5a01a389303.x954503abc583f675 == x954503abc583f675.xa19781cfbe8b4961 && base.xed3e432f7c9bf846.x954503abc583f675 == x954503abc583f675.xa19781cfbe8b4961 && base.x38ced5a01a389303.x332a8eedb847940d.x332a8eedb847940d == base.xed3e432f7c9bf846.x332a8eedb847940d.x332a8eedb847940d);
		if (base.x705ed5f9769744e5.xdc1bf80853046136 > 0 || !flag)
		{
			return -1;
		}
		if (base.x38ced5a01a389303.x954503abc583f675 == x954503abc583f675.x48cc0c3eaf9f5f05)
		{
			int num = base.x38ced5a01a389303.x8df91a2f90079e88 + xf6937c72cebe4ad1.x0ecd6606a49619ac((xf6937c72cebe4ad1)base.x38ced5a01a389303);
			if (num >= base.x38ced5a01a389303.xc255c495fd9232ca.xdc1bf80853046136)
			{
				return -1;
			}
			base.x38ced5a01a389303.xdc1bf80853046136 = num;
			return num;
		}
		int num2 = int.MinValue;
		int num3 = xa3a992e8cf81dabe.xb5e088b6b5dc233d(((x694f001896973fe3)base.x38ced5a01a389303).x838c6c67b5953bb0.x96ac59f61797f5b9);
		int num4 = xa3a992e8cf81dabe.xb5e088b6b5dc233d(((x694f001896973fe3)base.x38ced5a01a389303).x838c6c67b5953bb0.xc1277af2cd8d654e.x2f5fd09b3d327fb0);
		x398b3bd0acd94b61 x398b3bd0acd94b62 = base.xed3e432f7c9bf846.xf432ece93e450408();
		for (x398b3bd0acd94b61 x398b3bd0acd94b63 = base.x38ced5a01a389303; x398b3bd0acd94b63 != x398b3bd0acd94b62; x398b3bd0acd94b63 = x398b3bd0acd94b63.xf432ece93e450408())
		{
			x694f001896973fe3 x694f001896973fe4 = (x694f001896973fe3)x398b3bd0acd94b63;
			int xc0741c7ff92cf1aa = x694f001896973fe4.x838c6c67b5953bb0.x768f9befb545345a.xc0741c7ff92cf1aa;
			int val = x694f001896973fe4.xdc1bf80853046136 - xc0741c7ff92cf1aa - num3 - num4;
			num2 = Math.Max(num2, val);
		}
		return num2;
	}

	private void x1d76cba86350fef5(int x9b0739496f8b5475)
	{
		int xdc1bf80853046136 = base.x38ced5a01a389303.xc255c495fd9232ca.xdc1bf80853046136;
		base.x38ced5a01a389303.xc255c495fd9232ca.xdc1bf80853046136 = x9b0739496f8b5475;
		x71da84fff8849445 x71da84fff8849446 = new x71da84fff8849445();
		x398b3bd0acd94b61 x398b3bd0acd94b62 = base.xed3e432f7c9bf846.xf34a54c031e96d83();
		x398b3bd0acd94b61 x398b3bd0acd94b63;
		for (x398b3bd0acd94b63 = base.x38ced5a01a389303; x398b3bd0acd94b63 != x398b3bd0acd94b62; x398b3bd0acd94b63 = x398b3bd0acd94b63.xf34a54c031e96d83())
		{
			x398b3bd0acd94b63.x9e19f5bd0a6dd5b7(base.x38ced5a01a389303.xc255c495fd9232ca);
			x53cb1139c5c64ee6 x53cb1139c5c64ee7 = (x53cb1139c5c64ee6)x398b3bd0acd94b63;
			x53cb1139c5c64ee7.x109e3389933c23a8 = this;
			x71da84fff8849446.xc3819e13f60dd8e6(x53cb1139c5c64ee7, int.MaxValue, x3175070523842c98: true);
			x398b3bd0acd94b63 = (base.xed3e432f7c9bf846 = x71da84fff8849446.xed3e432f7c9bf846);
		}
		x07ff1d011cc765e7();
		base.x38ced5a01a389303.xc255c495fd9232ca.xdc1bf80853046136 = xdc1bf80853046136;
	}

	private void x07ff1d011cc765e7()
	{
		for (x398b3bd0acd94b61 x398b3bd0acd94b62 = base.x38ced5a01a389303; x398b3bd0acd94b62 != null; x398b3bd0acd94b62 = x398b3bd0acd94b62.xf432ece93e450408())
		{
			if (x398b3bd0acd94b62.x954503abc583f675 == x954503abc583f675.x48cc0c3eaf9f5f05)
			{
				xf6937c72cebe4ad1 xf6937c72cebe4ad2 = (xf6937c72cebe4ad1)x398b3bd0acd94b62;
				if (xf6937c72cebe4ad2.x406d8cd2af514771.xa79651e2f1a1416e.x9ba359ff37a3a63b != 0)
				{
					xad7715b8ed63de5f.x98e6d5779680da6e((xf6937c72cebe4ad1)x398b3bd0acd94b62);
				}
			}
			if (x398b3bd0acd94b62 == base.xed3e432f7c9bf846)
			{
				break;
			}
		}
	}

	private void x886809912f189707()
	{
		for (x398b3bd0acd94b61 x398b3bd0acd94b62 = base.x38ced5a01a389303; x398b3bd0acd94b62 != null; x398b3bd0acd94b62 = x398b3bd0acd94b62.xf432ece93e450408())
		{
			if (x398b3bd0acd94b62.x954503abc583f675 == x954503abc583f675.x48cc0c3eaf9f5f05)
			{
				xf6937c72cebe4ad1 xf6937c72cebe4ad2 = (xf6937c72cebe4ad1)x398b3bd0acd94b62;
				int xdc1bf80853046136 = xf6937c72cebe4ad2.xdc1bf80853046136;
				int xdc1bf808530461362 = xf6937c72cebe4ad2.xc255c495fd9232ca.xdc1bf80853046136;
				int num = ((x144b45103587413e() != 0) ? x8918dc7c534575e5 : xd74c65b8d28b1740);
				int xec140ac7dc20ef6e = xfd32adc83f7de856.x795e09a07e435cf4(xf6937c72cebe4ad2);
				int xdc1bf808530461363 = xfd32adc83f7de856.xc7c6550a888abaf3(xf6937c72cebe4ad2, num, xec140ac7dc20ef6e);
				xf6937c72cebe4ad2.xdc1bf80853046136 = xdc1bf808530461363;
				xf6937c72cebe4ad2.xc255c495fd9232ca.xdc1bf80853046136 = num;
				xad7715b8ed63de5f.xceaa36575b797b5b(xf6937c72cebe4ad2);
				xf6937c72cebe4ad2.xdc1bf80853046136 = xdc1bf80853046136;
				xf6937c72cebe4ad2.xc255c495fd9232ca.xdc1bf80853046136 = xdc1bf808530461362;
			}
			if (x398b3bd0acd94b62 == base.xed3e432f7c9bf846)
			{
				break;
			}
		}
	}

	private int x3cd290e44f1ea7e5()
	{
		int num = base.x705ed5f9769744e5.xb0f146032f47c24e;
		if (num <= 0)
		{
			int num2 = base.xed3e432f7c9bf846.x9bcb07e204e30218 - base.x38ced5a01a389303.xc821290d7ecc08bf;
			num = ((num == 0) ? num2 : Math.Max(-num, num2));
		}
		return Math.Min(num, base.xc255c495fd9232ca.xb0f146032f47c24e);
	}

	private int xfad6ddcd598b43e5(int x1e218ceaee1bb583)
	{
		int num = x1e218ceaee1bb583 + x8918dc7c534575e5 - base.xc255c495fd9232ca.xb0f146032f47c24e;
		if (num > 0)
		{
			x1e218ceaee1bb583 = Math.Max(0, x1e218ceaee1bb583 - num);
		}
		return x1e218ceaee1bb583;
	}

	private xa4342d41912fa853(x8d9303345f12a846 anchor, x398b3bd0acd94b61 first, x398b3bd0acd94b61 last)
		: base(anchor, anchor.xa79651e2f1a1416e.x109e3389933c23a8, first, last)
	{
	}
}
