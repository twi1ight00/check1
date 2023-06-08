using System;
using System.Drawing;
using Aspose.Words.Drawing;
using x6c95d9cf46ff5f25;

namespace x4adf554d20d941a6;

internal class x455088ba2e479f69 : x109e3389933c23a8
{
	internal override int xf8c20af9fe5edca0 => 25604;

	internal override Rectangle x7835973da2834a1b => base.x6ae4612a8469678e;

	internal override int xc13bc3847813c8aa => 0;

	internal override int x330b27a3d588a781 => 0;

	internal override int x5c43f9b06667f51f
	{
		get
		{
			WrapType xab6edfb47ff0b74c = xa9993ed2e0c64574.x34251722ab416841.x109e3389933c23a8.xab6edfb47ff0b74c;
			WrapType wrapType = xab6edfb47ff0b74c;
			double num = ((wrapType != WrapType.Tight) ? 19.5 : 10.5);
			if (!xa9993ed2e0c64574.x347b79f9c616f92c.x332b663769fd4483)
			{
				num -= 0.9;
			}
			return x4574ea26106f0edb.x8d50b8a62ba1cd84(num);
		}
	}

	protected override bool XMustBeInsidePage => xd510585a5c29c874;

	protected override bool YMustBeInsidePage => xd510585a5c29c874;

	private bool xd510585a5c29c874
	{
		get
		{
			if (base.x705ed5f9769744e5.x0fcdf9c7f9f2eb9e == RelativeHorizontalPosition.Column || base.x705ed5f9769744e5.x5d0ebb82ae68cc43 == RelativeVerticalPosition.Paragraph)
			{
				return base.x5a3440516914ae4b;
			}
			return false;
		}
	}

	private xa67197c42bddc7dc xa9993ed2e0c64574 => (xa67197c42bddc7dc)base.x1452024de1251c74;

	internal static x109e3389933c23a8 xdef7f68a22ec051d(x398b3bd0acd94b61 xd7e5673853e47af4)
	{
		if (!(xd7e5673853e47af4 is xa67197c42bddc7dc) || !((xa67197c42bddc7dc)xd7e5673853e47af4).x34251722ab416841.x109e3389933c23a8.x6f6877b222ed4153)
		{
			return null;
		}
		return new x455088ba2e479f69((xa67197c42bddc7dc)xd7e5673853e47af4);
	}

	internal override void xc3819e13f60dd8e6()
	{
	}

	protected override int FixNegativeOrigin(int origin)
	{
		if (!xd510585a5c29c874)
		{
			return origin;
		}
		return Math.Max(origin, 0);
	}

	protected override Rectangle GetBoundsImpl()
	{
		int x887b872a95caaab = xa9993ed2e0c64574.x887b872a95caaab5;
		int x = x795e09a07e435cf4(x887b872a95caaab);
		int xbcd477821fdbd81b = xa9993ed2e0c64574.xbcd477821fdbd81b;
		int y = x29b834e8e9ff09ed(xbcd477821fdbd81b);
		Rectangle xda73fcb97c77d = new Rectangle(x, y, x887b872a95caaab, xbcd477821fdbd81b);
		return x133db4697114502f(xda73fcb97c77d);
	}

	protected override Rectangle GetWrapBoundsImpl(Rectangle bounds)
	{
		int xc9ee264fd8d7484e = base.x705ed5f9769744e5.xc9ee264fd8d7484e;
		int x027754ea = base.x705ed5f9769744e5.x027754ea63804113;
		return new Rectangle(bounds.X - xc9ee264fd8d7484e, bounds.Y - x027754ea, bounds.Width + xc9ee264fd8d7484e + base.x705ed5f9769744e5.xb5465b18223f6375, bounds.Height + x027754ea + base.x705ed5f9769744e5.x4dc0360afcf78834);
	}

	internal override int xcc69ae5a5063e790()
	{
		xf6937c72cebe4ad1 xf6937c72cebe4ad2 = xa9993ed2e0c64574.x5a7799e1836857e3;
		while (xf6937c72cebe4ad2.xa573efc4845474fe != null && xf6937c72cebe4ad2.x3e8d56eefc6dfdad.xc255c495fd9232ca == xf6937c72cebe4ad2.xc255c495fd9232ca)
		{
			xf6937c72cebe4ad2 = xf6937c72cebe4ad2.xa573efc4845474fe;
		}
		int num = xa7a98231d4a67a0f.x80ac9fd414d4713b(xf6937c72cebe4ad2);
		if (xa7a98231d4a67a0f.xdd724c73394f5594(xf6937c72cebe4ad2))
		{
			return num + xf6937c72cebe4ad2.xe36d690dfc898f25;
		}
		return num + ((!base.x752cfab9af626fd5) ? xf6937c72cebe4ad2.xc255c495fd9232ca.x588d7683a6d1fbd5().Y : 0);
	}

	internal override bool xd62fa8ace7cbc0c9()
	{
		return true;
	}

	protected override Point GetColumnReference()
	{
		Point columnReference = base.GetColumnReference();
		if (!base.x38ced5a01a389303.x53111d6596d16a99.xf684fc5abe7ca67a)
		{
			return columnReference;
		}
		int num = columnReference.X;
		int num2 = columnReference.Y;
		xf6937c72cebe4ad1 xf6937c72cebe4ad2 = (xf6937c72cebe4ad1)base.x38ced5a01a389303.xc255c495fd9232ca;
		if (xa7a98231d4a67a0f.xb6299da20b77fe2a(xf6937c72cebe4ad2))
		{
			int x = xf6937c72cebe4ad2.x109e3389933c23a8.x6ae4612a8469678e.X;
			num2 += x - num;
			num = x;
		}
		else
		{
			x86accec882b7012a x86accec882b7012a2 = (x86accec882b7012a)xa9993ed2e0c64574.xce4443deee105995(x954503abc583f675.x11db8fc7f469a2fc);
			if (x86accec882b7012a2 != null)
			{
				if (xa9993ed2e0c64574.x34251722ab416841.x87119342b85a2a43)
				{
					num = x109e3389933c23a8.x588d7683a6d1fbd5(x86accec882b7012a2).X + x86accec882b7012a2.xc5464084edc8e226.xdfd0c9de0b4aa96a.xcad2e59522947ede;
					num2 = num + x86accec882b7012a2.xdc1bf80853046136 - x86accec882b7012a2.xc5464084edc8e226.xdfd0c9de0b4aa96a.x41c99cca24bc80be;
				}
			}
			else
			{
				xf6937c72cebe4ad1 x5a7799e1836857e = xa9993ed2e0c64574.x5a7799e1836857e3;
				int num3 = x83c11d12950654d8(xa9993ed2e0c64574, columnReference.X);
				if (num3 != 0)
				{
					int num4 = num2 - num;
					num = num3;
					num2 = num + num4;
				}
				switch (base.x705ed5f9769744e5.xab67cb9464a3325b)
				{
				case HorizontalAlignment.Left:
					num += x5a7799e1836857e.x406d8cd2af514771.xa79651e2f1a1416e.xc0741c7ff92cf1aa;
					break;
				case HorizontalAlignment.Right:
					num2 -= x5a7799e1836857e.x406d8cd2af514771.xa79651e2f1a1416e.x91e854e77522d9eb;
					break;
				}
			}
		}
		return new Point(num, num2);
	}

	private static int x83c11d12950654d8(xa67197c42bddc7dc xf0f5907c77eeefed, int x83fa4028abb3b9a3)
	{
		xf6937c72cebe4ad1 x5a7799e1836857e = xf0f5907c77eeefed.x5a7799e1836857e3;
		xd4c1d21f07094800 xd4c1d21f7094801 = x5a7799e1836857e.x776fd7c2f7270172().xd4c1d21f07094800;
		Point point = x109e3389933c23a8.x588d7683a6d1fbd5(x5a7799e1836857e);
		int num = 0;
		for (int i = 0; i < xd4c1d21f7094801.xd44988f225497f3a; i++)
		{
			x109e3389933c23a8 x109e3389933c23a9 = xd4c1d21f7094801.xaadb22af27962896(i);
			if (x5a7799e1836857e.x406d8cd2af514771 == x8e2cf08cf03da16f(x109e3389933c23a9) && xf0f5907c77eeefed.x3032dc2ab2939cf9)
			{
				continue;
			}
			bool flag = x109e3389933c23a9.x4b6965fe04aaacd8.X <= point.X;
			bool flag2 = x109e3389933c23a9.x4b6965fe04aaacd8.Right > x83fa4028abb3b9a3;
			if (xe8df3756f1b06c96(x109e3389933c23a9.x4b6965fe04aaacd8.Y, x109e3389933c23a9.x4b6965fe04aaacd8.Height, point.Y, x5a7799e1836857e.xb0f146032f47c24e) && flag && flag2)
			{
				int right = x109e3389933c23a9.x4b6965fe04aaacd8.Right;
				if (right > num)
				{
					num = right;
				}
			}
		}
		return num;
	}

	private static x8d9303345f12a846 x8e2cf08cf03da16f(x109e3389933c23a8 xdcf7b74ddd6caa25)
	{
		x8d9303345f12a846 result = null;
		if (xdcf7b74ddd6caa25.xf8c20af9fe5edca0 == 25604)
		{
			xa67197c42bddc7dc xa67197c42bddc7dc2 = (xa67197c42bddc7dc)xdcf7b74ddd6caa25.x1452024de1251c74;
			result = xa67197c42bddc7dc2.x406d8cd2af514771;
		}
		return result;
	}

	private static bool xe8df3756f1b06c96(int x7fb6a269eb062f77, int x53c7c6a8d2f13905, int x429da00e07106d3d, int x80dbc4e21c6bcd39)
	{
		int num = x7fb6a269eb062f77 + x53c7c6a8d2f13905 - 1;
		int num2 = x429da00e07106d3d + x80dbc4e21c6bcd39 - 1;
		bool flag = num < x429da00e07106d3d;
		bool flag2 = num2 < x7fb6a269eb062f77;
		if (!flag)
		{
			return !flag2;
		}
		return false;
	}

	private x455088ba2e479f69(xa67197c42bddc7dc anchor)
		: base(anchor, anchor.x34251722ab416841.x109e3389933c23a8, anchor, anchor)
	{
	}
}
