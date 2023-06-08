using System;
using System.Collections;
using System.Drawing;
using Aspose.Words.Drawing;
using x6c95d9cf46ff5f25;

namespace x4adf554d20d941a6;

internal class xd4c1d21f07094800
{
	private readonly ArrayList xba505b457f56974b = new ArrayList();

	private readonly ArrayList x6106277b3eb44c2e = new ArrayList();

	private ArrayList xfd700bb753225c14 = new ArrayList();

	private x1073233de8252b3e x437fa02210b98bec;

	internal int xd44988f225497f3a => xba505b457f56974b.Count;

	internal int xb162d4fead96642c => xfd700bb753225c14.Count;

	private bool xff089db645b3bd5a => x437fa02210b98bec.x954503abc583f675 == x954503abc583f675.xa65184d44a47025b;

	internal xd4c1d21f07094800(x1073233de8252b3e container)
	{
		x437fa02210b98bec = container;
	}

	internal bool x2a0cb95ab84ba877(x109e3389933c23a8 xdcf7b74ddd6caa25, bool x42cfb54f69c550b9)
	{
		if (!xdcf7b74ddd6caa25.x5a3440516914ae4b)
		{
			return false;
		}
		if (!xff089db645b3bd5a && xdcf7b74ddd6caa25.xb6ef83a1238c066c == xae532cfb203d8406.x53111d6596d16a99)
		{
			xdcf7b74ddd6caa25.x38ced5a01a389303.x776fd7c2f7270172().xd4c1d21f07094800.x2a0cb95ab84ba877(xdcf7b74ddd6caa25, x42cfb54f69c550b9: false);
			return false;
		}
		if (xff089db645b3bd5a && xdcf7b74ddd6caa25.xb6ef83a1238c066c == xae532cfb203d8406.x11db8fc7f469a2fc)
		{
			return false;
		}
		if (x96a84e8cc25a2cdb(xdcf7b74ddd6caa25, xba505b457f56974b))
		{
			return false;
		}
		if (xdcf7b74ddd6caa25.xf684fc5abe7ca67a || xdcf7b74ddd6caa25.xb6ef83a1238c066c == xae532cfb203d8406.x11db8fc7f469a2fc)
		{
			xba505b457f56974b.Add(xdcf7b74ddd6caa25);
			xe0a0cc2d5748f88c(xdcf7b74ddd6caa25, xe5de345c5f0199ed: false);
			if (x42cfb54f69c550b9)
			{
				x7a6c3ce5119332d0();
			}
			return true;
		}
		if (!x96a84e8cc25a2cdb(xdcf7b74ddd6caa25, x6106277b3eb44c2e))
		{
			x6106277b3eb44c2e.Add(xdcf7b74ddd6caa25);
		}
		xdcf7b74ddd6caa25.x2e6c3c7a54659350();
		return false;
	}

	private static bool x96a84e8cc25a2cdb(x109e3389933c23a8 xdcf7b74ddd6caa25, ArrayList xcc0a538745f4bb51)
	{
		int num = xc41ee226950f0131(xdcf7b74ddd6caa25.x1452024de1251c74, xcc0a538745f4bb51);
		bool flag = num >= 0;
		if (flag)
		{
			((x109e3389933c23a8)xcc0a538745f4bb51[num]).x58c5f64a4ef63e88(xdcf7b74ddd6caa25);
			xcc0a538745f4bb51[num] = xdcf7b74ddd6caa25;
		}
		return flag;
	}

	internal bool x0fa0e7c6939687d8()
	{
		if (x6106277b3eb44c2e.Count <= 0)
		{
			return false;
		}
		foreach (object item in x6106277b3eb44c2e)
		{
			x109e3389933c23a8 xdcf7b74ddd6caa = (x109e3389933c23a8)item;
			xe0a0cc2d5748f88c(xdcf7b74ddd6caa, xe5de345c5f0199ed: true);
		}
		bool result = xfd700bb753225c14.Count > 0;
		x7a6c3ce5119332d0();
		xba505b457f56974b.InsertRange(0, x6106277b3eb44c2e);
		x6106277b3eb44c2e.Clear();
		return result;
	}

	internal void xde11bc5d740d3ee3(object xf0f5907c77eeefed, bool x42cfb54f69c550b9)
	{
		if (!x263d579af1d0d43f(xf0f5907c77eeefed))
		{
			return;
		}
		for (int num = xd44988f225497f3a - 1; num >= 0; num--)
		{
			x109e3389933c23a8 x109e3389933c23a9 = xaadb22af27962896(num);
			xe0a0cc2d5748f88c(x109e3389933c23a9, xe5de345c5f0199ed: true);
			xba505b457f56974b.RemoveAt(num);
			if (x109e3389933c23a9.x1452024de1251c74 == xf0f5907c77eeefed)
			{
				break;
			}
		}
		if (x42cfb54f69c550b9)
		{
			x7a6c3ce5119332d0();
		}
	}

	internal void x7a6c3ce5119332d0()
	{
		for (int i = 0; i < xfd700bb753225c14.Count; i++)
		{
			x398b3bd0acd94b61 x398b3bd0acd94b62 = (x398b3bd0acd94b61)xfd700bb753225c14[i];
			x398b3bd0acd94b62.x379ae16af0ba8e51(x6fcedf7742596b6c.xa794cb4211c273f3);
		}
		x4026eea6591ad25f();
	}

	internal void x4026eea6591ad25f()
	{
		xfd700bb753225c14.Clear();
	}

	internal x3822c4a3772d4456 xbb13dc484690ae9a(Rectangle xc73143b3a0620b78, int xcbb242d049e2b480)
	{
		ArrayList arrayList = new ArrayList();
		arrayList.Add(xc73143b3a0620b78);
		int num = 1073741823;
		int num2 = xc73143b3a0620b78.Height;
		foreach (object item in xba505b457f56974b)
		{
			x109e3389933c23a8 x109e3389933c23a9 = (x109e3389933c23a8)item;
			if (x109e3389933c23a9.x5a3440516914ae4b && x109e3389933c23a9.x4b6965fe04aaacd8.IntersectsWith(xc73143b3a0620b78))
			{
				Rectangle xa95689ba4ef12ab = ((x109e3389933c23a9.x705ed5f9769744e5.xab6edfb47ff0b74c == WrapType.TopBottom) ? new Rectangle(xc73143b3a0620b78.X, x109e3389933c23a9.x4b6965fe04aaacd8.Y, xc73143b3a0620b78.Width, x109e3389933c23a9.x4b6965fe04aaacd8.Height) : x109e3389933c23a9.x4b6965fe04aaacd8);
				num = Math.Min(num, xa95689ba4ef12ab.Bottom);
				num2 = xfb7db80dca60ec9e(arrayList, xa95689ba4ef12ab, x109e3389933c23a9.x5c43f9b06667f51f, xcbb242d049e2b480, num2);
			}
		}
		return new x3822c4a3772d4456(arrayList, num2, num);
	}

	internal Rectangle xbb13dc484690ae9a(Rectangle xc73143b3a0620b78)
	{
		Rectangle rect = new Rectangle(xc73143b3a0620b78.X, xc73143b3a0620b78.Y, xc73143b3a0620b78.Width, xc73143b3a0620b78.Height);
		int num = xc73143b3a0620b78.Y + 1073741823;
		foreach (object item in xba505b457f56974b)
		{
			x109e3389933c23a8 x109e3389933c23a9 = (x109e3389933c23a8)item;
			if (x109e3389933c23a9.x5a3440516914ae4b && x109e3389933c23a9.x4b6965fe04aaacd8.IntersectsWith(xc73143b3a0620b78))
			{
				num = Math.Min(num, x109e3389933c23a9.x4b6965fe04aaacd8.Bottom);
				if (x109e3389933c23a9.x4b6965fe04aaacd8.IntersectsWith(rect))
				{
					rect = ((x109e3389933c23a9.x4b6965fe04aaacd8.X - rect.X <= x109e3389933c23a9.x5c43f9b06667f51f) ? ((rect.Right - x109e3389933c23a9.x4b6965fe04aaacd8.Right <= x109e3389933c23a9.x5c43f9b06667f51f) ? new Rectangle(rect.X, rect.Y, 0, 0) : new Rectangle(x109e3389933c23a9.x4b6965fe04aaacd8.Right, rect.Y, rect.Right - x109e3389933c23a9.x4b6965fe04aaacd8.Right, rect.Height)) : new Rectangle(rect.X, rect.Y, x109e3389933c23a9.x4b6965fe04aaacd8.X - rect.X, rect.Height));
				}
			}
		}
		int height = num - rect.Y;
		return new Rectangle(rect.X, rect.Y, rect.Width, height);
	}

	internal bool xc311ec83adde0d98(x3d1ad8ce75f0db3a xd3311d815ca25f02, bool x42cfb54f69c550b9)
	{
		xc63cc34daaa2e2d9 xc63cc34daaa2e2d10 = null;
		xc7f90d9c7c51cede xc7f90d9c7c51cede2 = xd3311d815ca25f02.x776fd7c2f7270172();
		for (int i = 0; i < xd44988f225497f3a; i++)
		{
			x109e3389933c23a8 x109e3389933c23a9 = xaadb22af27962896(i);
			if (xc41ee226950f0131(x109e3389933c23a9.x1452024de1251c74) >= 0 && x109e3389933c23a9.xf8c20af9fe5edca0 != 21537 && xc7f90d9c7c51cede2 != x109e3389933c23a9.x38ced5a01a389303.x776fd7c2f7270172())
			{
				xde11bc5d740d3ee3(x109e3389933c23a9.x1452024de1251c74, x42cfb54f69c550b9);
				if (xc63cc34daaa2e2d10 == null)
				{
					xc63cc34daaa2e2d10 = x109e3389933c23a9.x11cf6ba103816bb7().x332a8eedb847940d;
				}
			}
		}
		if (xc63cc34daaa2e2d10 != null)
		{
			xd3311d815ca25f02.x87d525e789cc7a5b = xc63cc34daaa2e2d10;
			return true;
		}
		return false;
	}

	internal bool xa54d8824ed6cee47()
	{
		x86accec882b7012a x86accec882b7012a2 = (x86accec882b7012a)x437fa02210b98bec;
		bool flag = false;
		for (int i = 0; i < xd44988f225497f3a; i++)
		{
			x109e3389933c23a8 x109e3389933c23a9 = xaadb22af27962896(i);
			switch (x109e3389933c23a9.xf8c20af9fe5edca0)
			{
			case 25604:
			{
				xa67197c42bddc7dc xa67197c42bddc7dc2 = (xa67197c42bddc7dc)x109e3389933c23a9.x1452024de1251c74;
				flag = xa67197c42bddc7dc2.xce4443deee105995(x954503abc583f675.x11db8fc7f469a2fc) != x86accec882b7012a2;
				if (flag)
				{
					x86accec882b7012a2.x87d525e789cc7a5b = xa67197c42bddc7dc2.x406d8cd2af514771;
				}
				break;
			}
			case 21595:
			{
				x7c1e2b821e8b8220 x7c1e2b821e8b8221 = (x7c1e2b821e8b8220)x109e3389933c23a9.x1452024de1251c74;
				flag = x7c1e2b821e8b8221.x5d6d04c35215bc51.x5d6d04c35215bc51.xce4443deee105995(x954503abc583f675.x11db8fc7f469a2fc) != x86accec882b7012a2;
				if (flag)
				{
					x86accec882b7012a2.x87d525e789cc7a5b = x7c1e2b821e8b8221;
				}
				break;
			}
			case 21537:
			{
				x8d9303345f12a846 x8d9303345f12a847 = (x8d9303345f12a846)x109e3389933c23a9.x1452024de1251c74;
				flag = x8d9303345f12a847.x927910b7aed705e2.xce4443deee105995(x954503abc583f675.x11db8fc7f469a2fc) != x86accec882b7012a2;
				if (flag)
				{
					x86accec882b7012a2.x87d525e789cc7a5b = x8d9303345f12a847;
				}
				break;
			}
			}
			if (flag)
			{
				x437fa02210b98bec.xc255c495fd9232ca.xa852dd9d7ca8f04d = true;
				xde11bc5d740d3ee3(x109e3389933c23a9.x1452024de1251c74, x42cfb54f69c550b9: true);
				return true;
			}
		}
		return false;
	}

	internal bool x263d579af1d0d43f(object xf0f5907c77eeefed)
	{
		return xc41ee226950f0131(xf0f5907c77eeefed) >= 0;
	}

	internal x109e3389933c23a8 xaadb22af27962896(int xc0c4c459c6ccbd00)
	{
		return xaadb22af27962896(xc0c4c459c6ccbd00, xba505b457f56974b);
	}

	private static x109e3389933c23a8 xaadb22af27962896(int xc0c4c459c6ccbd00, ArrayList xe21a6f0184704a38)
	{
		return (x109e3389933c23a8)xe21a6f0184704a38[xc0c4c459c6ccbd00];
	}

	internal x109e3389933c23a8 x9d08aad9f0890726(object xf0f5907c77eeefed)
	{
		int num = xc41ee226950f0131(xf0f5907c77eeefed);
		if (num >= 0)
		{
			return xaadb22af27962896(num);
		}
		return null;
	}

	internal int xc41ee226950f0131(object xf0f5907c77eeefed)
	{
		return xc41ee226950f0131(xf0f5907c77eeefed, xba505b457f56974b);
	}

	private static int xc41ee226950f0131(object xf0f5907c77eeefed, ArrayList xe21a6f0184704a38)
	{
		for (int num = xe21a6f0184704a38.Count - 1; num >= 0; num--)
		{
			x109e3389933c23a8 x109e3389933c23a9 = xaadb22af27962896(num, xe21a6f0184704a38);
			if (x109e3389933c23a9.xbd46d5308b22d9fd)
			{
				xe21a6f0184704a38.RemoveAt(num);
			}
			else if (x109e3389933c23a9.x1452024de1251c74 == xf0f5907c77eeefed)
			{
				return num;
			}
		}
		return -1;
	}

	internal Rectangle x37b1dbbad6246778()
	{
		int num = int.MaxValue;
		int num2 = int.MaxValue;
		int num3 = int.MinValue;
		int num4 = int.MinValue;
		for (int i = 0; i < xd44988f225497f3a; i++)
		{
			x109e3389933c23a8 x109e3389933c23a9 = xaadb22af27962896(i);
			num = Math.Min(num, x109e3389933c23a9.x6ae4612a8469678e.X);
			num2 = Math.Min(num2, x109e3389933c23a9.x6ae4612a8469678e.Y);
			num3 = Math.Max(num3, x109e3389933c23a9.x6ae4612a8469678e.X + x109e3389933c23a9.x6ae4612a8469678e.Width);
			num4 = Math.Max(num4, x109e3389933c23a9.x6ae4612a8469678e.Y + x109e3389933c23a9.x6ae4612a8469678e.Height);
		}
		return new Rectangle(num, num2, num3 - num, num4 - num2);
	}

	internal static x109e3389933c23a8 x5f22ff83d28dc9ef(x109e3389933c23a8 xdcf7b74ddd6caa25)
	{
		x1073233de8252b3e xc255c495fd9232ca = xdcf7b74ddd6caa25.xc255c495fd9232ca;
		xd4c1d21f07094800 xd4c1d21f7094801 = ((xc255c495fd9232ca.x954503abc583f675 == x954503abc583f675.x11db8fc7f469a2fc) ? ((x86accec882b7012a)xc255c495fd9232ca).xf9d5944b191eb276(x5aa7d09b258e0f23: false) : ((xc7f90d9c7c51cede)xc255c495fd9232ca).xf9d5944b191eb276(x5aa7d09b258e0f23: false));
		if (xd4c1d21f7094801 != null)
		{
			x109e3389933c23a8 x109e3389933c23a9 = xd4c1d21f7094801.x9d08aad9f0890726(xdcf7b74ddd6caa25.x1452024de1251c74);
			if (x109e3389933c23a9 != null)
			{
				return x109e3389933c23a9;
			}
		}
		return xdcf7b74ddd6caa25;
	}

	internal void xe0a0cc2d5748f88c(x109e3389933c23a8 xdcf7b74ddd6caa25, bool xe5de345c5f0199ed)
	{
		Rectangle x38e53f6678274e = xdcf7b74ddd6caa25.x4b6965fe04aaacd8;
		if (xe5de345c5f0199ed)
		{
			int num = x4574ea26106f0edb.x8d50b8a62ba1cd84(10.0);
			x38e53f6678274e = new Rectangle(x38e53f6678274e.X - num, x38e53f6678274e.Y - num, x38e53f6678274e.Width + 2 * num, x38e53f6678274e.Height + 2 * num);
		}
		xe0a0cc2d5748f88c(x38e53f6678274e, null);
	}

	internal bool xe0a0cc2d5748f88c(Rectangle x38e53f6678274e06, x398b3bd0acd94b61 x2aa5114a5da7d6c8)
	{
		bool flag = false;
		if (xff089db645b3bd5a)
		{
			xc7f90d9c7c51cede xc7f90d9c7c51cede2 = (xc7f90d9c7c51cede)x437fa02210b98bec;
			x852fe8bb5ac31098 x852fe8bb5ac31099 = (x852fe8bb5ac31098)(x2aa5114a5da7d6c8?.xce4443deee105995(x954503abc583f675.x4c38e800e85b21ad));
			for (x852fe8bb5ac31098 x852fe8bb5ac31100 = xc7f90d9c7c51cede2.xb78c16d5f2d4f2f7; x852fe8bb5ac31100 != null; x852fe8bb5ac31100 = ((x852fe8bb5ac31100 == x852fe8bb5ac31099) ? null : ((x852fe8bb5ac31098)x852fe8bb5ac31100.xf432ece93e450408())))
			{
				if (!x852fe8bb5ac31100.x7149c962c02931b3 && new Rectangle(x852fe8bb5ac31100.x588d7683a6d1fbd5(), x852fe8bb5ac31100.x56933a86bfcf89a1()).IntersectsWith(x38e53f6678274e06))
				{
					flag |= x794c475aa406dc23(x852fe8bb5ac31100, x38e53f6678274e06, x2aa5114a5da7d6c8);
				}
			}
		}
		else
		{
			flag |= x794c475aa406dc23(x437fa02210b98bec, x38e53f6678274e06, x2aa5114a5da7d6c8);
		}
		return flag;
	}

	private bool x794c475aa406dc23(x1073233de8252b3e xd3311d815ca25f02, Rectangle x26545669838eb36e, x398b3bd0acd94b61 x2aa5114a5da7d6c8)
	{
		Rectangle x26545669838eb36e2 = xd3311d815ca25f02.x39e5557bea338558();
		x26545669838eb36e2 = new Rectangle(xd3311d815ca25f02.x5c392d6ad6fe7e28, xd3311d815ca25f02.x3dcafc2d758260e1, x26545669838eb36e2.Width - xd3311d815ca25f02.x5c392d6ad6fe7e28 - xd3311d815ca25f02.xf159a68356fd5b23, (x26545669838eb36e2.Height == int.MinValue) ? 1073741823 : (x26545669838eb36e2.Height - xd3311d815ca25f02.x169ccf570c1dc425 - xd3311d815ca25f02.x3dcafc2d758260e1));
		x26545669838eb36e2 = x810500694b1cc056(xd3311d815ca25f02, x26545669838eb36e2);
		x26545669838eb36e = Rectangle.Intersect(x26545669838eb36e, x26545669838eb36e2);
		int num = 0;
		for (x398b3bd0acd94b61 x398b3bd0acd94b62 = xd3311d815ca25f02.x8b8a0a04b3aeaf3a; x398b3bd0acd94b62 != null; x398b3bd0acd94b62 = x398b3bd0acd94b62.xf432ece93e450408())
		{
			if (!xa7a98231d4a67a0f.xdd724c73394f5594(x398b3bd0acd94b62) && x398b3bd0acd94b62.xe5764fe5359a6d91)
			{
				Rectangle rect = xff9c835e07a70a6b(x398b3bd0acd94b62, xd3311d815ca25f02);
				if (x26545669838eb36e.IntersectsWith(rect))
				{
					xfd700bb753225c14.Add(x398b3bd0acd94b62);
					if (num >= 0)
					{
						num = 1;
					}
				}
				if (x398b3bd0acd94b62 == x2aa5114a5da7d6c8 && num <= 0)
				{
					num = -1;
				}
			}
		}
		if (num < 0 && xff9c835e07a70a6b(x2aa5114a5da7d6c8, xd3311d815ca25f02).Bottom > x26545669838eb36e.Y)
		{
			num = 1;
		}
		return num > 0;
	}

	private Rectangle xff9c835e07a70a6b(x398b3bd0acd94b61 xd7e5673853e47af4, x1073233de8252b3e xd3311d815ca25f02)
	{
		int num = ((xd7e5673853e47af4.x954503abc583f675 == x954503abc583f675.x48cc0c3eaf9f5f05) ? xa7a98231d4a67a0f.x80ac9fd414d4713b((xf6937c72cebe4ad1)xd7e5673853e47af4) : xd7e5673853e47af4.xc821290d7ecc08bf);
		int num2 = xd7e5673853e47af4.xc821290d7ecc08bf - num;
		Rectangle x26545669838eb36e = new Rectangle(xd3311d815ca25f02.x5c392d6ad6fe7e28, xd3311d815ca25f02.x3dcafc2d758260e1 + num, xd3311d815ca25f02.xdc1bf80853046136 - xd3311d815ca25f02.x5c392d6ad6fe7e28 - xd3311d815ca25f02.xf159a68356fd5b23, xd7e5673853e47af4.xb0f146032f47c24e + num2);
		return x810500694b1cc056(xd3311d815ca25f02, x26545669838eb36e);
	}

	private Rectangle x810500694b1cc056(x1073233de8252b3e xd3311d815ca25f02, Rectangle x26545669838eb36e)
	{
		if (!xff089db645b3bd5a)
		{
			return x26545669838eb36e;
		}
		Point point = xd3311d815ca25f02.x588d7683a6d1fbd5();
		return new Rectangle(x26545669838eb36e.X + point.X, x26545669838eb36e.Y + point.Y, x26545669838eb36e.Width, x26545669838eb36e.Height);
	}

	private static int xfb7db80dca60ec9e(ArrayList xc73463c8bc7be883, Rectangle xa95689ba4ef12ab6, int xa0fc1ad475b26580, int xcbb242d049e2b480, int x11ca0fea911df8ba)
	{
		int num = x11ca0fea911df8ba;
		int num2 = 0;
		while (num2 < xc73463c8bc7be883.Count)
		{
			int num3 = num2 + 1;
			Rectangle rect = (Rectangle)xc73463c8bc7be883[num2];
			if (xa95689ba4ef12ab6.IntersectsWith(rect))
			{
				int num4 = xa95689ba4ef12ab6.Y - rect.Y;
				if (num4 > xcbb242d049e2b480)
				{
					if (num4 < num)
					{
						num = num4;
					}
				}
				else
				{
					num3 = xfe26ff4ddb1766e1(xc73463c8bc7be883, num2, xa95689ba4ef12ab6, xa0fc1ad475b26580);
				}
			}
			num2 = num3;
		}
		return num;
	}

	private static int xfe26ff4ddb1766e1(ArrayList xc73463c8bc7be883, int xf79ad770682fea3a, Rectangle xa95689ba4ef12ab6, int xa0fc1ad475b26580)
	{
		Rectangle rectangle = (Rectangle)xc73463c8bc7be883[xf79ad770682fea3a];
		Rectangle rectangle2 = Rectangle.Empty;
		int num = xa95689ba4ef12ab6.X - rectangle.X;
		if (num > xa0fc1ad475b26580)
		{
			rectangle2 = new Rectangle(rectangle.X, rectangle.Y, num, rectangle.Height);
		}
		Rectangle rectangle3 = Rectangle.Empty;
		int num2 = rectangle.Right - xa95689ba4ef12ab6.Right;
		if (num2 > xa0fc1ad475b26580)
		{
			rectangle3 = new Rectangle(xa95689ba4ef12ab6.Right, rectangle.Y, num2, rectangle.Height);
		}
		if (rectangle2.IsEmpty && rectangle3.IsEmpty)
		{
			xc73463c8bc7be883.RemoveAt(xf79ad770682fea3a);
			return xf79ad770682fea3a;
		}
		if (!rectangle2.IsEmpty && !rectangle3.IsEmpty)
		{
			xc73463c8bc7be883[xf79ad770682fea3a] = rectangle2;
			xc73463c8bc7be883.Insert(xf79ad770682fea3a + 1, rectangle3);
			return xf79ad770682fea3a + 2;
		}
		xc73463c8bc7be883[xf79ad770682fea3a] = (rectangle2.IsEmpty ? rectangle3 : rectangle2);
		return xf79ad770682fea3a + 1;
	}

	private x109e3389933c23a8 xb31a205a2dd34bec(xc7f90d9c7c51cede xbbe2f7d7c86e0379, x1073233de8252b3e xd3311d815ca25f02, bool x42cfb54f69c550b9)
	{
		for (int i = 0; i < xd44988f225497f3a; i++)
		{
			x109e3389933c23a8 x109e3389933c23a9 = xaadb22af27962896(i);
			if (x109e3389933c23a9.xc255c495fd9232ca != xd3311d815ca25f02)
			{
				xde11bc5d740d3ee3(x109e3389933c23a9.x1452024de1251c74, x42cfb54f69c550b9);
				return x109e3389933c23a9;
			}
		}
		return null;
	}
}
