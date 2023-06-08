using System;
using Aspose.Words.Reporting;
using xb1090543d168d647;

namespace xe86f37adaccef1c3;

internal class xa60db17c10eefc60
{
	private readonly MailMerge x17e7624bcb28c892;

	private readonly xa11a4c48b53f49a6 xb94636afa262d297;

	private readonly int[] xfc613b5f0b49c769;

	internal xa60db17c10eefc60(MailMerge mailMerge, xa11a4c48b53f49a6 dataSource)
	{
		x17e7624bcb28c892 = mailMerge;
		xb94636afa262d297 = dataSource;
		int x8d29312d6fdcad = dataSource.x8d29312d6fdcad86;
		if (x8d29312d6fdcad < 0)
		{
			x126b5c2a2d17da0a();
		}
		xfc613b5f0b49c769 = ((x8d29312d6fdcad > 1) ? new int[x8d29312d6fdcad - 1] : null);
		xb92b9f52422fe898();
	}

	private void x126b5c2a2d17da0a()
	{
		throw new InvalidOperationException("Implementation of IMailMergeDataSourceCore is not valid.");
	}

	internal void xb92b9f52422fe898()
	{
		if (xfc613b5f0b49c769 != null)
		{
			for (int i = 0; i < xfc613b5f0b49c769.Length; i++)
			{
				xfc613b5f0b49c769[i] = -1;
			}
		}
	}

	internal int xef7b3bfee793d3d9(string x66ac3558868cc255, bool xdee369e356a49f3d)
	{
		if (!xdee369e356a49f3d)
		{
			return -1;
		}
		return xef7b3bfee793d3d9(xb94636afa262d297, x66ac3558868cc255);
	}

	private int xef7b3bfee793d3d9(xa11a4c48b53f49a6 xef1769c4fe6ae4ca, string x66ac3558868cc255)
	{
		int num = xef1769c4fe6ae4ca.x74b8d10dd9d29ac2(x66ac3558868cc255);
		if (num == -1)
		{
			if (!x17e7624bcb28c892.UseNonMergeFields || !x69c36a228a9b3b39.xe19ff57f82f3515e(xef1769c4fe6ae4ca))
			{
				x126b5c2a2d17da0a();
			}
			int num2 = x69c36a228a9b3b39.x85f795c533a8433f(x66ac3558868cc255);
			if (num2 == -1)
			{
				x126b5c2a2d17da0a();
			}
			string xde5031b4f06bf = x69c36a228a9b3b39.x08b8822c2b320c6a(x66ac3558868cc255, num2);
			xa11a4c48b53f49a6 xa11a4c48b53f49a7 = xef1769c4fe6ae4ca.x438eef0af7e648c2(xde5031b4f06bf);
			if (xa11a4c48b53f49a7 == null)
			{
				x126b5c2a2d17da0a();
			}
			string x66ac3558868cc256 = x69c36a228a9b3b39.x7a72474f72a62daf(x66ac3558868cc255, num2);
			return xef7b3bfee793d3d9(xa11a4c48b53f49a7, x66ac3558868cc256);
		}
		if (!x69c36a228a9b3b39.xda36a3450e67c2d7(xef1769c4fe6ae4ca, num))
		{
			x126b5c2a2d17da0a();
		}
		return xef7b3bfee793d3d9(xef1769c4fe6ae4ca, num);
	}

	private int xef7b3bfee793d3d9(xa11a4c48b53f49a6 xef1769c4fe6ae4ca, int x8e9b5f316bf9cf3d)
	{
		int num = -1;
		int num2 = x8e9b5f316bf9cf3d;
		while (num == -1 && num2 != 0)
		{
			num2--;
			if (xef1769c4fe6ae4ca == xb94636afa262d297)
			{
				num = xfc613b5f0b49c769[num2];
				if (num != -1)
				{
					break;
				}
			}
			if (!xef1769c4fe6ae4ca.x3f88a25febd23896(num2, out var x5fc53c4ffd3eb8c))
			{
				x126b5c2a2d17da0a();
			}
			num = xef7b3bfee793d3d9(x5fc53c4ffd3eb8c);
		}
		if (num == -1)
		{
			num = 0;
		}
		if (xef1769c4fe6ae4ca == xb94636afa262d297 && xfc613b5f0b49c769 != null)
		{
			for (int i = num2; i < x8e9b5f316bf9cf3d; i++)
			{
				xfc613b5f0b49c769[i] = num;
			}
		}
		return num;
	}

	private int xef7b3bfee793d3d9(object x5fc53c4ffd3eb8c9)
	{
		if (x5fc53c4ffd3eb8c9 == null || Convert.IsDBNull(x5fc53c4ffd3eb8c9))
		{
			return -1;
		}
		string text = x5fc53c4ffd3eb8c9.ToString();
		for (int num = text.Length - 1; num >= 0; num--)
		{
			switch (xd9a6b2b6ada137e6.x839a041aa1476aed(text[num]))
			{
			case xd2d2b731b30d7023.xed846b3bb18ccf39:
			case xd2d2b731b30d7023.x8e8f6cc6a0756b05:
				return 0;
			case xd2d2b731b30d7023.xc613adc4330033f3:
			case xd2d2b731b30d7023.x97338636ab2fccfa:
				return 1;
			}
		}
		return -1;
	}
}
