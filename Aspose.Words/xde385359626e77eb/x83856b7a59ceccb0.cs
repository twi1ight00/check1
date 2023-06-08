using System;
using Aspose.Words;
using Aspose.Words.Tables;
using x6c95d9cf46ff5f25;
using x9db5f2e5af3d596e;

namespace xde385359626e77eb;

internal class x83856b7a59ceccb0
{
	private x83856b7a59ceccb0()
	{
	}

	internal static int xc15171e87e96e678(Table x1ec770899c98a268)
	{
		Cell firstCell = x1ec770899c98a268.FirstRow.FirstCell;
		int val = x76bc4aae22437efa(firstCell);
		int num = x0d1a18b5d715ec9f(firstCell);
		Cell lastCell = x1ec770899c98a268.FirstRow.LastCell;
		int val2 = x601b2abe4162500a(lastCell);
		int num2 = xf28a255d8eb73e58(lastCell);
		int num3 = x3db00d97e90fe1a6(x1ec770899c98a268, num2, num);
		int num4 = Math.Max(num / 2, val) + Math.Max(num2 / 2, val2) + num3;
		int num5 = x4574ea26106f0edb.x88bf16f2386d633e(xdce5f72473519d4e.x431837e8d8f834cd(x1ec770899c98a268));
		double num6;
		if (x1ec770899c98a268.x752cfab9af626fd5)
		{
			num6 = num5 + num3;
			Cell cell = (Cell)x1ec770899c98a268.xdfa6ecc6f742f086;
			if (cell.x133f2db9e5b5690d.AllowAutoFit)
			{
				num6 -= (double)(x76bc4aae22437efa(cell) + x601b2abe4162500a(cell));
				num6 -= (double)(num / 2 + num2 / 2);
			}
		}
		else if (x1ec770899c98a268.PreferredWidth.xa72bf798a679c0aa)
		{
			num5 -= x4574ea26106f0edb.x88bf16f2386d633e(x1ec770899c98a268.LeftIndent);
			num6 = num5 + num4;
		}
		else if (x1ec770899c98a268.PreferredWidth.x08428aa3999da322)
		{
			num6 = Math.Max(x1ec770899c98a268.PreferredWidth.xdf4645c89f0e47f6, num5 + num4);
		}
		else
		{
			if (!x1ec770899c98a268.PreferredWidth.x368bd9f7b8c336b4)
			{
				throw new InvalidOperationException("Unknown Preferred width.");
			}
			num6 = num5 + num4;
			num6 = num6 * x1ec770899c98a268.PreferredWidth.Value / 100.0;
		}
		num6 = x15e971129fd80714.xe193c76ba76a5afc(num6, 15.0, 31680.0);
		return (int)Math.Round(num6);
	}

	private static int x3db00d97e90fe1a6(Table x1ec770899c98a268, int x8cc48de2030b0466, int xfb3d359e98811b9c)
	{
		int xd2905906dc0619f = x1ec770899c98a268.FirstRow.xedb0eb766e25e0c9.xd2905906dc0619f2;
		if (xd2905906dc0619f == 0)
		{
			return 0;
		}
		return xfb3d359e98811b9c + x8cc48de2030b0466 + xd2905906dc0619f * 4;
	}

	internal static int xa576f3bf789274d1(Cell xe6de5e5fa2d44af5)
	{
		int num = 1;
		Cell xb2e852052ab1c1be = xe6de5e5fa2d44af5.xb2e852052ab1c1be;
		while (xb2e852052ab1c1be != null && xb2e852052ab1c1be.xf8cef531dae89ea3.x338a5e6ab7c5595e == CellMerge.Previous)
		{
			num++;
			xb2e852052ab1c1be = xb2e852052ab1c1be.xb2e852052ab1c1be;
		}
		return num;
	}

	internal static double xddfe984e273cbb83(Cell xe6de5e5fa2d44af5)
	{
		CellFormat cellFormat = xe6de5e5fa2d44af5.CellFormat;
		return cellFormat.LeftPadding + cellFormat.RightPadding + cellFormat.Borders[BorderType.Left].LineWidth + cellFormat.Borders[BorderType.Right].LineWidth;
	}

	internal static double x6b51de0344d46543(Table x1ec770899c98a268)
	{
		double num = x1ec770899c98a268.FirstRow.RowFormat.Borders[BorderType.Left].LineWidth + x1ec770899c98a268.FirstRow.RowFormat.Borders[BorderType.Right].LineWidth;
		return num + x1ec770899c98a268.CellSpacing * (double)(x1ec770899c98a268.xbd4adf8f33d07995() + 1);
	}

	private static object x48a52ca448018d5b(TableStyle x44ecfea61c937b8e, int xba08ce632055a1d9)
	{
		if (x44ecfea61c937b8e.xedb0eb766e25e0c9.x263d579af1d0d43f(xba08ce632055a1d9))
		{
			return x44ecfea61c937b8e.xedb0eb766e25e0c9.xf7866f89640a29a3(xba08ce632055a1d9);
		}
		if (x44ecfea61c937b8e.xe709b224f455b863 != 4095)
		{
			TableStyle x44ecfea61c937b8e2 = (TableStyle)x44ecfea61c937b8e.Styles.x1976fb6958cf7237(x44ecfea61c937b8e.xe709b224f455b863, x988fcf605f8efa7e: false);
			return x48a52ca448018d5b(x44ecfea61c937b8e2, xba08ce632055a1d9);
		}
		return xedb0eb766e25e0c9.x0095b789d636f3ae(xba08ce632055a1d9);
	}

	private static object x48a52ca448018d5b(Cell xe6de5e5fa2d44af5, int x8a876f92eb7549b4, int x6a25c2c73b067e40)
	{
		StyleCollection styles = xe6de5e5fa2d44af5.Document.Styles;
		xedb0eb766e25e0c9 xedb0eb766e25e0c = xe6de5e5fa2d44af5.x133f2db9e5b5690d.FirstRow.xedb0eb766e25e0c9;
		xf8cef531dae89ea3 xf8cef531dae89ea = xe6de5e5fa2d44af5.xf8cef531dae89ea3;
		object obj = xf8cef531dae89ea.xf7866f89640a29a3(x6a25c2c73b067e40);
		if (obj == null)
		{
			obj = xedb0eb766e25e0c.xf7866f89640a29a3(x8a876f92eb7549b4);
			if (obj == null)
			{
				if (!(styles.x1976fb6958cf7237(xedb0eb766e25e0c.x8301ab10c226b0c2, x988fcf605f8efa7e: false) is TableStyle x44ecfea61c937b8e))
				{
					return xedb0eb766e25e0c9.x0095b789d636f3ae(x8a876f92eb7549b4);
				}
				return x48a52ca448018d5b(x44ecfea61c937b8e, x8a876f92eb7549b4);
			}
		}
		return obj;
	}

	private static int x0d1a18b5d715ec9f(Cell xe6de5e5fa2d44af5)
	{
		Border border = (Border)x48a52ca448018d5b(xe6de5e5fa2d44af5, 4060, 3120);
		return x4574ea26106f0edb.x88bf16f2386d633e(border.LineWidth);
	}

	private static int xf28a255d8eb73e58(Cell xe6de5e5fa2d44af5)
	{
		Border border = (Border)x48a52ca448018d5b(xe6de5e5fa2d44af5, 4080, 3140);
		return x4574ea26106f0edb.x88bf16f2386d633e(border.LineWidth);
	}

	private static int x76bc4aae22437efa(Cell xe6de5e5fa2d44af5)
	{
		return (int)x48a52ca448018d5b(xe6de5e5fa2d44af5, 4020, 3090);
	}

	private static int x601b2abe4162500a(Cell xe6de5e5fa2d44af5)
	{
		return (int)x48a52ca448018d5b(xe6de5e5fa2d44af5, 4320, 3100);
	}
}
