using System;
using Aspose.Words.Tables;

namespace x2a6f63b6650e76c4;

internal class x886615a98e7e709b : x4e68fc46f3a05e16
{
	private readonly int x6d6da754f6f3a374;

	private readonly double x9aec3b1d30361563;

	private bool xb755fd17f2e27ffc;

	internal x886615a98e7e709b(xd554b53e829d5f97 range)
		: base(range)
	{
		switch (range.xdbfa333b4cd503e0)
		{
		case xb8f8d187f6793877.x2e8310e038e73798:
			x6d6da754f6f3a374 = -1;
			break;
		case xb8f8d187f6793877.x7af9190cf6099399:
			x6d6da754f6f3a374 = 1;
			break;
		default:
			x4e68fc46f3a05e16.x360ab359eefb8af4();
			break;
		}
		x9aec3b1d30361563 = x304932bd805c2938(xc83d0e6d4611cafd.x11db8fc7f469a2fc);
	}

	private static double x304932bd805c2938(Cell xe6de5e5fa2d44af5)
	{
		double num = 0.0;
		Row parentRow = xe6de5e5fa2d44af5.ParentRow;
		for (int i = 0; i <= xe6de5e5fa2d44af5.x59bc0096de497989; i++)
		{
			num += parentRow.Cells[i].CellFormat.Width;
		}
		return num;
	}

	protected override bool MoveToNextCell()
	{
		if (xb755fd17f2e27ffc)
		{
			return false;
		}
		bool flag = xc83d0e6d4611cafd.x6f0363886d340825(x6d6da754f6f3a374);
		if (flag)
		{
			flag = xf13c938343141e8d();
			if (!flag && Math.Abs(xc83d0e6d4611cafd.x9b1baea4e485d168 - x4517c2b411ea1d52.x89f700c5ff3d93e4.x9b1baea4e485d168) == 1)
			{
				xc83d0e6d4611cafd.x59bc0096de497989 = 0;
				flag = xc83d0e6d4611cafd.xa53526a8e4a7b443(x4517c2b411ea1d52.x89f700c5ff3d93e4.x59bc0096de497989);
				xb755fd17f2e27ffc = true;
			}
		}
		return flag;
	}

	private bool xf13c938343141e8d()
	{
		CellCollection cells = x4517c2b411ea1d52.x89f700c5ff3d93e4.x11db8fc7f469a2fc.x133f2db9e5b5690d.Rows[xc83d0e6d4611cafd.x9b1baea4e485d168].Cells;
		double num = 0.0;
		int i = 0;
		bool flag = false;
		for (; i < cells.Count; i++)
		{
			double num2 = num + cells[i].CellFormat.Width;
			flag = num2 >= x9aec3b1d30361563;
			if (flag)
			{
				break;
			}
			num = num2;
		}
		if (flag)
		{
			xc83d0e6d4611cafd = new xe02d79c539b6382d(cells[i]);
		}
		return flag;
	}
}
