using System;
using System.Collections;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Tables;
using x13f1efc79617a47b;

namespace xde385359626e77eb;

internal class xdce5f72473519d4e
{
	private const double xd0a46c59d405891d = 1584.0;

	private Cell xc4328896523cc9f4;

	private Cell x1b3826a9f7977b35;

	private bool x31487d0887f08f2b;

	private double xc1cd5194f87a2614;

	private readonly Table x0f62a530ebbd1b7d;

	private x4c38e800e85b21ad[] x660741034f534cfd;

	private bool x044a7067a96c8a86 = true;

	private double xb0ef242fcce72c0e;

	private double xe6b3c9ff3e235af7;

	private x66ed6507f98b1be8 xc82a882776e30b62;

	private xa4369c8993e5e35e x81bf1fc4c9a6ef58;

	private ArrayList x9ebb3f3f99e4d0ce;

	private double x4e5af990e7597357;

	private int x7371b33543162018;

	private int x5745e31b23885473;

	private int x8c6321442dd06ede;

	private double x40b1befb6d815191;

	private double x354ff0a0e0bcbb70;

	private double x87766f56ff88394f;

	private double x7daa08a7cc637d21;

	private double xa15d56ce345a06f5;

	private ArrayList x88c9934cd61f7254;

	private readonly bool x915a590c7941b314;

	internal xdce5f72473519d4e(Table table)
	{
		if (table.ParentNode == null)
		{
			throw new InvalidOperationException("The table must be in the document tree before it can be updated.");
		}
		x0f62a530ebbd1b7d = table;
	}

	private xdce5f72473519d4e(Table table, bool suppressNestedTablesUpdates)
		: this(table)
	{
		x915a590c7941b314 = suppressNestedTablesUpdates;
	}

	internal x66ed6507f98b1be8 xadbaf0fef5a4f7fb()
	{
		xb7fad3d41ea414e7();
		if (x0f62a530ebbd1b7d.AllowAutoFit)
		{
			x77478a905c1527c3();
			xc4eb02b97204b660();
			xc7c9e48a1ef5c3cd();
			x1d35206a77c2596d();
		}
		if (!x915a590c7941b314)
		{
			xa3e911c327ec2f91();
		}
		return xc82a882776e30b62;
	}

	private void xb7fad3d41ea414e7()
	{
		if (x044a7067a96c8a86)
		{
			x244a028a20acef5b();
			xceba8ebf9e82a25a();
			xc95a1b61b51e15b7();
			xb6c02e0557955a39();
			x044a7067a96c8a86 = false;
		}
	}

	private void x244a028a20acef5b()
	{
		x81bf1fc4c9a6ef58 = new xa4369c8993e5e35e();
		x9ebb3f3f99e4d0ce = new ArrayList();
		x88c9934cd61f7254 = new ArrayList();
		xc4328896523cc9f4 = null;
		x1b3826a9f7977b35 = null;
		x31487d0887f08f2b = false;
		xc82a882776e30b62 = new x66ed6507f98b1be8();
		x7371b33543162018 = 0;
		x5745e31b23885473 = 0;
		x8c6321442dd06ede = 0;
		x660741034f534cfd = new x4c38e800e85b21ad[x0f62a530ebbd1b7d.xbd4adf8f33d07995()];
		for (int i = 0; i < x660741034f534cfd.Length; i++)
		{
			x660741034f534cfd[i] = new x4c38e800e85b21ad();
		}
	}

	private void xceba8ebf9e82a25a()
	{
		for (int i = 0; i < x660741034f534cfd.Length; i++)
		{
			x4c38e800e85b21ad x4c38e800e85b21ad2 = x660741034f534cfd[i];
			for (int j = 0; j < x0f62a530ebbd1b7d.Rows.Count; j++)
			{
				Cell cell = x0f62a530ebbd1b7d.xfeb19f1007c0b581(i, j);
				if (cell == null)
				{
					continue;
				}
				CellFormat cellFormat = cell.CellFormat;
				if (cellFormat.VerticalMerge == CellMerge.Previous)
				{
					continue;
				}
				switch (cellFormat.HorizontalMerge)
				{
				case CellMerge.None:
					x4c38e800e85b21ad2.x1b016f3311a00b82();
					xd7db49f79aa576a2(cell, x4c38e800e85b21ad2);
					break;
				case CellMerge.First:
					x4c38e800e85b21ad2.x1b016f3311a00b82();
					if (x83856b7a59ceccb0.xa576f3bf789274d1(cell) > 1)
					{
						x27f96ce0ec71b6e8(cell, i);
					}
					else
					{
						xd7db49f79aa576a2(cell, x4c38e800e85b21ad2);
					}
					break;
				default:
					throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("bnaghohgboogbofhpnmheodiinkihibjhmijgmpjkmgkhmnkihelcmllhlcmbmjmdlanokhnehon", 670589052)));
				case CellMerge.Previous:
					break;
				}
			}
			if (x4c38e800e85b21ad2.xce5b83b714f11fba.x08428aa3999da322 && x4c38e800e85b21ad2.x66ed6507f98b1be8.x9f4c543928c73298 > x4c38e800e85b21ad2.xce5b83b714f11fba.Value && xc4328896523cc9f4 != x1b3826a9f7977b35)
			{
				x4c38e800e85b21ad2.xce5b83b714f11fba = PreferredWidth.Auto;
				xc4328896523cc9f4 = null;
			}
			x4c38e800e85b21ad2.x66ed6507f98b1be8.x9f4c543928c73298 = Math.Max(x4c38e800e85b21ad2.x66ed6507f98b1be8.xf41d956c067e2b4d, x4c38e800e85b21ad2.x66ed6507f98b1be8.x9f4c543928c73298);
		}
	}

	private void x27f96ce0ec71b6e8(Cell xe6de5e5fa2d44af5, int xbeb0e74fd1e3aefb)
	{
		x9ebb3f3f99e4d0ce.Add(new xaa91b73537e83cd0(xe6de5e5fa2d44af5, xbeb0e74fd1e3aefb));
	}

	private void xd7db49f79aa576a2(Cell xe6de5e5fa2d44af5, x4c38e800e85b21ad xe3e287548b3d01f5)
	{
		x66ed6507f98b1be8 x66ed6507f98b1be9 = xb6f3586d2f1ff486(xe6de5e5fa2d44af5);
		if (x66ed6507f98b1be9.x9f4c543928c73298 > xe3e287548b3d01f5.x66ed6507f98b1be8.x9f4c543928c73298)
		{
			x1b3826a9f7977b35 = xe6de5e5fa2d44af5;
		}
		xe3e287548b3d01f5.x66ed6507f98b1be8.x295cb4a1df7a5add(x66ed6507f98b1be9);
		PreferredWidth preferredWidth = xe6de5e5fa2d44af5.CellFormat.PreferredWidth;
		switch (preferredWidth.Type)
		{
		case PreferredWidthType.Points:
		{
			if (!preferredWidth.x40aae25d22abf007 || xe3e287548b3d01f5.xce5b83b714f11fba.x368bd9f7b8c336b4)
			{
				break;
			}
			double num = preferredWidth.Value + xe6de5e5fa2d44af5.CellFormat.LeftPadding + xe6de5e5fa2d44af5.CellFormat.RightPadding;
			if (xe3e287548b3d01f5.xce5b83b714f11fba.x08428aa3999da322)
			{
				if (num > xe3e287548b3d01f5.xce5b83b714f11fba.Value || (num > xe3e287548b3d01f5.xce5b83b714f11fba.Value && xe6de5e5fa2d44af5 == x1b3826a9f7977b35))
				{
					xe3e287548b3d01f5.xce5b83b714f11fba = PreferredWidth.xb6bb25492776965a(num);
					xc4328896523cc9f4 = xe6de5e5fa2d44af5;
				}
			}
			else
			{
				xe3e287548b3d01f5.xce5b83b714f11fba = PreferredWidth.xb6bb25492776965a(num);
				xc4328896523cc9f4 = xe6de5e5fa2d44af5;
			}
			break;
		}
		case PreferredWidthType.Percent:
			x31487d0887f08f2b = true;
			if (preferredWidth.x40aae25d22abf007 && (!xe3e287548b3d01f5.xce5b83b714f11fba.x368bd9f7b8c336b4 || preferredWidth.Value > xe3e287548b3d01f5.xce5b83b714f11fba.Value))
			{
				xe3e287548b3d01f5.xce5b83b714f11fba = PreferredWidth.xb4e521ca3a7fd077(preferredWidth.Value);
			}
			break;
		}
	}

	private void xc95a1b61b51e15b7()
	{
		xe8eda03dc76b9eb7();
		for (int i = 0; i < x9ebb3f3f99e4d0ce.Count; i++)
		{
			x5b76ba5b001788ae x5b76ba5b001788ae2 = new x5b76ba5b001788ae();
			xaa91b73537e83cd0 xaa91b73537e83cd = (xaa91b73537e83cd0)x9ebb3f3f99e4d0ce[i];
			Cell x11db8fc7f469a2fc = xaa91b73537e83cd.x11db8fc7f469a2fc;
			x5b76ba5b001788ae2.x56410a8dd70087c5 = xaa91b73537e83cd.x56410a8dd70087c5;
			x5b76ba5b001788ae2.x84e55246091c35af = xaa91b73537e83cd.x59bc0096de497989;
			x5b76ba5b001788ae2.x36aa84abdd79bab8 = x5b76ba5b001788ae2.x84e55246091c35af;
			x5b76ba5b001788ae2.x8ce3e6655be86e9c = x11db8fc7f469a2fc.CellFormat.PreferredWidth;
			if (!x5b76ba5b001788ae2.x8ce3e6655be86e9c.x40aae25d22abf007)
			{
				x5b76ba5b001788ae2.x8ce3e6655be86e9c = PreferredWidth.Auto;
			}
			x5b76ba5b001788ae2.x50a36ed37ff140a1 = xb6f3586d2f1ff486(x11db8fc7f469a2fc);
			x5b76ba5b001788ae2.x50a36ed37ff140a1.xf41d956c067e2b4d += x0f62a530ebbd1b7d.CellSpacing;
			x5b76ba5b001788ae2.x50a36ed37ff140a1.x9f4c543928c73298 += x0f62a530ebbd1b7d.CellSpacing;
			x5b76ba5b001788ae2.xc2944b48b0421ad9 = new x66ed6507f98b1be8();
			x4d7e6312982bdc22(x5b76ba5b001788ae2);
			xe3af80428b051468(x5b76ba5b001788ae2);
			x7b57297b4b673c5a(x5b76ba5b001788ae2);
			x3f359eab3bddd98d(x5b76ba5b001788ae2);
		}
	}

	private void xe8eda03dc76b9eb7()
	{
		xc1cd5194f87a2614 = 0.0;
		x9ebb3f3f99e4d0ce.Sort(new x61ee2a433880804d());
		for (int i = 0; i < x660741034f534cfd.Length; i++)
		{
			x660741034f534cfd[i].x232d4eb2a20c13e8();
		}
	}

	private void x4d7e6312982bdc22(x5b76ba5b001788ae x0f7b23d1c393aed9)
	{
		while (x0f7b23d1c393aed9.x36aa84abdd79bab8 < x660741034f534cfd.Length && x0f7b23d1c393aed9.x56410a8dd70087c5 > 0)
		{
			x4c38e800e85b21ad x4c38e800e85b21ad2 = x660741034f534cfd[x0f7b23d1c393aed9.x36aa84abdd79bab8];
			switch (x4c38e800e85b21ad2.xce5b83b714f11fba.Type)
			{
			case PreferredWidthType.Auto:
				x0f7b23d1c393aed9.xee8d758bda1f0d56 = true;
				x0f7b23d1c393aed9.x4b7703e564d66180 = false;
				x0f7b23d1c393aed9.xeec3f07754e7ab19 = false;
				x4c38e800e85b21ad2.xaf2198f89f0119d3 = PreferredWidth.Auto;
				break;
			case PreferredWidthType.Points:
				if (x4c38e800e85b21ad2.xce5b83b714f11fba.x40aae25d22abf007)
				{
					x0f7b23d1c393aed9.xd768f8c222bb7e6e += x4c38e800e85b21ad2.xce5b83b714f11fba.Value;
					x0f7b23d1c393aed9.xeec3f07754e7ab19 = false;
					break;
				}
				x0f7b23d1c393aed9.xee8d758bda1f0d56 = true;
				x0f7b23d1c393aed9.x4b7703e564d66180 = false;
				x0f7b23d1c393aed9.xeec3f07754e7ab19 = false;
				x4c38e800e85b21ad2.xaf2198f89f0119d3 = PreferredWidth.Auto;
				break;
			case PreferredWidthType.Percent:
				x0f7b23d1c393aed9.x93c3a05d67e6c55d += x4c38e800e85b21ad2.xce5b83b714f11fba.Value;
				x0f7b23d1c393aed9.x4b7703e564d66180 = false;
				break;
			default:
				throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("mlgpcnnpmmeammlakmcbpmjbdmacchhcllocblfdhlmdnkdehlkeikbfnfifokpfalggeknggjehmflh", 916387431)));
			}
			x0f7b23d1c393aed9.xc2944b48b0421ad9.xf41d956c067e2b4d += x4c38e800e85b21ad2.x9ff98c6e27f967f5.xf41d956c067e2b4d;
			x0f7b23d1c393aed9.xc2944b48b0421ad9.x9f4c543928c73298 += x4c38e800e85b21ad2.x9ff98c6e27f967f5.x9f4c543928c73298;
			x0f7b23d1c393aed9.x50a36ed37ff140a1.xf41d956c067e2b4d -= x0f62a530ebbd1b7d.CellSpacing;
			x0f7b23d1c393aed9.x50a36ed37ff140a1.x9f4c543928c73298 -= x0f62a530ebbd1b7d.CellSpacing;
			x0f7b23d1c393aed9.x56410a8dd70087c5--;
			x0f7b23d1c393aed9.x36aa84abdd79bab8++;
		}
	}

	private void xe3af80428b051468(x5b76ba5b001788ae x0f7b23d1c393aed9)
	{
		if (!x0f7b23d1c393aed9.x8ce3e6655be86e9c.x368bd9f7b8c336b4)
		{
			return;
		}
		if (x0f7b23d1c393aed9.x93c3a05d67e6c55d > x0f7b23d1c393aed9.x8ce3e6655be86e9c.Value || x0f7b23d1c393aed9.xeec3f07754e7ab19)
		{
			x0f7b23d1c393aed9.x8ce3e6655be86e9c = PreferredWidth.Auto;
			return;
		}
		double num = Math.Max(x0f7b23d1c393aed9.xc2944b48b0421ad9.x9f4c543928c73298, x0f7b23d1c393aed9.x50a36ed37ff140a1.x9f4c543928c73298);
		xc1cd5194f87a2614 = Math.Max(xc1cd5194f87a2614, num * 100.0 / x0f7b23d1c393aed9.x8ce3e6655be86e9c.Value);
		double num2 = x0f7b23d1c393aed9.x8ce3e6655be86e9c.Value - x0f7b23d1c393aed9.x93c3a05d67e6c55d;
		double num3 = 0.0;
		for (int i = x0f7b23d1c393aed9.x84e55246091c35af; i < x0f7b23d1c393aed9.x36aa84abdd79bab8; i++)
		{
			x4c38e800e85b21ad x4c38e800e85b21ad2 = x660741034f534cfd[i];
			if (!x4c38e800e85b21ad2.xce5b83b714f11fba.x368bd9f7b8c336b4)
			{
				num3 += x4c38e800e85b21ad2.x9ff98c6e27f967f5.x9f4c543928c73298;
			}
		}
		for (int j = x0f7b23d1c393aed9.x84e55246091c35af; j < x0f7b23d1c393aed9.x36aa84abdd79bab8; j++)
		{
			if (!(num3 > 0.0))
			{
				break;
			}
			x4c38e800e85b21ad x4c38e800e85b21ad3 = x660741034f534cfd[j];
			if (!x4c38e800e85b21ad3.xce5b83b714f11fba.x368bd9f7b8c336b4)
			{
				int num4 = (int)(num2 * x4c38e800e85b21ad3.x9ff98c6e27f967f5.x9f4c543928c73298 / num3);
				num3 -= x4c38e800e85b21ad3.x9ff98c6e27f967f5.x9f4c543928c73298;
				num2 -= (double)num4;
				if (num4 > 0)
				{
					x4c38e800e85b21ad3.xaf2198f89f0119d3 = PreferredWidth.xb4e521ca3a7fd077(num4);
				}
				else
				{
					x4c38e800e85b21ad3.xaf2198f89f0119d3 = PreferredWidth.Auto;
				}
			}
		}
	}

	private void x7b57297b4b673c5a(x5b76ba5b001788ae x0f7b23d1c393aed9)
	{
		if (!(x0f7b23d1c393aed9.x50a36ed37ff140a1.xf41d956c067e2b4d > x0f7b23d1c393aed9.xc2944b48b0421ad9.xf41d956c067e2b4d))
		{
			return;
		}
		if (x0f7b23d1c393aed9.x4b7703e564d66180)
		{
			for (int i = x0f7b23d1c393aed9.x84e55246091c35af; i < x0f7b23d1c393aed9.x36aa84abdd79bab8; i++)
			{
				if (!(x0f7b23d1c393aed9.xd768f8c222bb7e6e > 0.0))
				{
					break;
				}
				x4c38e800e85b21ad x4c38e800e85b21ad2 = x660741034f534cfd[i];
				double num = Math.Max(x4c38e800e85b21ad2.x9ff98c6e27f967f5.xf41d956c067e2b4d, x0f7b23d1c393aed9.x50a36ed37ff140a1.xf41d956c067e2b4d * x4c38e800e85b21ad2.xce5b83b714f11fba.Value / x0f7b23d1c393aed9.xd768f8c222bb7e6e);
				x0f7b23d1c393aed9.xd768f8c222bb7e6e -= x4c38e800e85b21ad2.xce5b83b714f11fba.Value;
				x0f7b23d1c393aed9.x50a36ed37ff140a1.xf41d956c067e2b4d -= num;
				x4c38e800e85b21ad2.x9ff98c6e27f967f5.xf41d956c067e2b4d = num;
			}
			return;
		}
		double num2 = x0f7b23d1c393aed9.xc2944b48b0421ad9.xf41d956c067e2b4d;
		double num3 = x0f7b23d1c393aed9.xc2944b48b0421ad9.x9f4c543928c73298;
		for (int j = x0f7b23d1c393aed9.x84e55246091c35af; j < x0f7b23d1c393aed9.x36aa84abdd79bab8; j++)
		{
			if (!(num3 > 0.0))
			{
				break;
			}
			x4c38e800e85b21ad x4c38e800e85b21ad3 = x660741034f534cfd[j];
			if (x4c38e800e85b21ad3.xce5b83b714f11fba.x08428aa3999da322 && x0f7b23d1c393aed9.xee8d758bda1f0d56 && x0f7b23d1c393aed9.xd768f8c222bb7e6e <= x0f7b23d1c393aed9.x50a36ed37ff140a1.xf41d956c067e2b4d)
			{
				double num4 = Math.Max(x4c38e800e85b21ad3.x9ff98c6e27f967f5.xf41d956c067e2b4d, x4c38e800e85b21ad3.xce5b83b714f11fba.Value);
				x0f7b23d1c393aed9.xd768f8c222bb7e6e -= x4c38e800e85b21ad3.xce5b83b714f11fba.Value;
				num2 -= x4c38e800e85b21ad3.x9ff98c6e27f967f5.xf41d956c067e2b4d;
				num3 -= x4c38e800e85b21ad3.x9ff98c6e27f967f5.x9f4c543928c73298;
				x0f7b23d1c393aed9.x50a36ed37ff140a1.xf41d956c067e2b4d -= num4;
				x4c38e800e85b21ad3.x9ff98c6e27f967f5.xf41d956c067e2b4d = num4;
			}
		}
		for (int k = x0f7b23d1c393aed9.x84e55246091c35af; k < x0f7b23d1c393aed9.x36aa84abdd79bab8; k++)
		{
			if (!(num2 < x0f7b23d1c393aed9.x50a36ed37ff140a1.xf41d956c067e2b4d))
			{
				break;
			}
			if (!(num3 > 0.0))
			{
				break;
			}
			x4c38e800e85b21ad x4c38e800e85b21ad4 = x660741034f534cfd[k];
			if (!x4c38e800e85b21ad4.xce5b83b714f11fba.x08428aa3999da322 || !x0f7b23d1c393aed9.xee8d758bda1f0d56 || !(x0f7b23d1c393aed9.xd768f8c222bb7e6e <= x0f7b23d1c393aed9.x50a36ed37ff140a1.xf41d956c067e2b4d))
			{
				double val = Math.Max(x4c38e800e85b21ad4.x9ff98c6e27f967f5.xf41d956c067e2b4d, x0f7b23d1c393aed9.x50a36ed37ff140a1.xf41d956c067e2b4d * x4c38e800e85b21ad4.x9ff98c6e27f967f5.x9f4c543928c73298 / num3);
				val = Math.Min(val, x4c38e800e85b21ad4.x9ff98c6e27f967f5.xf41d956c067e2b4d + (x0f7b23d1c393aed9.x50a36ed37ff140a1.xf41d956c067e2b4d - num2));
				num2 -= x4c38e800e85b21ad4.x9ff98c6e27f967f5.xf41d956c067e2b4d;
				num3 -= x4c38e800e85b21ad4.x9ff98c6e27f967f5.x9f4c543928c73298;
				x0f7b23d1c393aed9.x50a36ed37ff140a1.xf41d956c067e2b4d -= val;
				x4c38e800e85b21ad4.x9ff98c6e27f967f5.xf41d956c067e2b4d = val;
			}
		}
	}

	private void x3f359eab3bddd98d(x5b76ba5b001788ae x0f7b23d1c393aed9)
	{
		if (!x0f7b23d1c393aed9.x8ce3e6655be86e9c.x368bd9f7b8c336b4)
		{
			if (!(x0f7b23d1c393aed9.x50a36ed37ff140a1.x9f4c543928c73298 > x0f7b23d1c393aed9.xc2944b48b0421ad9.x9f4c543928c73298))
			{
				return;
			}
			for (int i = x0f7b23d1c393aed9.x84e55246091c35af; i < x0f7b23d1c393aed9.x36aa84abdd79bab8; i++)
			{
				if (!(x0f7b23d1c393aed9.xc2944b48b0421ad9.x9f4c543928c73298 > 0.0))
				{
					break;
				}
				x4c38e800e85b21ad x4c38e800e85b21ad2 = x660741034f534cfd[i];
				double num = Math.Max(x4c38e800e85b21ad2.x9ff98c6e27f967f5.x9f4c543928c73298, x0f7b23d1c393aed9.x50a36ed37ff140a1.x9f4c543928c73298 * x4c38e800e85b21ad2.x9ff98c6e27f967f5.x9f4c543928c73298 / x0f7b23d1c393aed9.xc2944b48b0421ad9.x9f4c543928c73298);
				x0f7b23d1c393aed9.xc2944b48b0421ad9.x9f4c543928c73298 -= x4c38e800e85b21ad2.x9ff98c6e27f967f5.x9f4c543928c73298;
				x0f7b23d1c393aed9.x50a36ed37ff140a1.x9f4c543928c73298 -= num;
				x4c38e800e85b21ad2.x9ff98c6e27f967f5.x9f4c543928c73298 = num;
			}
		}
		else
		{
			for (int j = x0f7b23d1c393aed9.x84e55246091c35af; j < x0f7b23d1c393aed9.x36aa84abdd79bab8; j++)
			{
				x4c38e800e85b21ad x4c38e800e85b21ad3 = x660741034f534cfd[j];
				x4c38e800e85b21ad3.x66ed6507f98b1be8.x9f4c543928c73298 = Math.Max(x4c38e800e85b21ad3.x66ed6507f98b1be8.xf41d956c067e2b4d, x4c38e800e85b21ad3.x66ed6507f98b1be8.x9f4c543928c73298);
			}
		}
	}

	private void xb6c02e0557955a39()
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 100.0;
		for (int i = 0; i < x660741034f534cfd.Length; i++)
		{
			x4c38e800e85b21ad x4c38e800e85b21ad2 = x660741034f534cfd[i];
			xc82a882776e30b62.xf41d956c067e2b4d += x4c38e800e85b21ad2.x9ff98c6e27f967f5.xf41d956c067e2b4d;
			xc82a882776e30b62.x9f4c543928c73298 += x4c38e800e85b21ad2.x9ff98c6e27f967f5.x9f4c543928c73298;
			if (x4c38e800e85b21ad2.xaf2198f89f0119d3.x368bd9f7b8c336b4)
			{
				double num4 = Math.Min(x4c38e800e85b21ad2.xaf2198f89f0119d3.Value, num3);
				double val = x4c38e800e85b21ad2.x9ff98c6e27f967f5.x9f4c543928c73298 * 100.0 / Math.Max(num4, 1.0);
				num3 -= num4;
				num = Math.Max(num, val);
			}
			else
			{
				num2 += x4c38e800e85b21ad2.x9ff98c6e27f967f5.x9f4c543928c73298;
			}
		}
		if (x75abd0509e3c17c5())
		{
			num2 = (num2 * 100.0 + 50.0) / Math.Max(num3, 1.0);
			xc82a882776e30b62.x9f4c543928c73298 = Math.Max(xc82a882776e30b62.x9f4c543928c73298, num2);
			xc82a882776e30b62.x9f4c543928c73298 = Math.Max(xc82a882776e30b62.x9f4c543928c73298, num);
		}
		xc82a882776e30b62.x9f4c543928c73298 = Math.Max(xc82a882776e30b62.x9f4c543928c73298, xc1cd5194f87a2614);
		double num5 = x83856b7a59ceccb0.x6b51de0344d46543(x0f62a530ebbd1b7d);
		xc82a882776e30b62.xf41d956c067e2b4d += num5;
		xc82a882776e30b62.x9f4c543928c73298 += num5;
		if (x0f62a530ebbd1b7d.PreferredWidth.x08428aa3999da322 && x0f62a530ebbd1b7d.PreferredWidth.x40aae25d22abf007)
		{
			xc82a882776e30b62.xf41d956c067e2b4d = Math.Max(xc82a882776e30b62.xf41d956c067e2b4d, x0f62a530ebbd1b7d.PreferredWidth.Value);
			xc82a882776e30b62.x9f4c543928c73298 = xc82a882776e30b62.xf41d956c067e2b4d;
		}
		xc82a882776e30b62.xf41d956c067e2b4d = Math.Min(xc82a882776e30b62.xf41d956c067e2b4d, 1584.0);
		xc82a882776e30b62.x9f4c543928c73298 = Math.Min(xc82a882776e30b62.x9f4c543928c73298, 1584.0);
	}

	private bool x75abd0509e3c17c5()
	{
		bool result = true;
		Table table = x0f62a530ebbd1b7d;
		while (table != null)
		{
			PreferredWidth preferredWidth = table.PreferredWidth;
			if (!preferredWidth.x08428aa3999da322)
			{
				Node parentNode = x0f62a530ebbd1b7d.ParentNode;
				while (parentNode != null && parentNode.NodeType != NodeType.Cell)
				{
					parentNode = parentNode.ParentNode;
				}
				table = null;
				if (parentNode == null || parentNode.NodeType != NodeType.Cell)
				{
					continue;
				}
				Cell cell = (Cell)parentNode;
				PreferredWidth preferredWidth2 = cell.CellFormat.PreferredWidth;
				if (!preferredWidth2.x08428aa3999da322)
				{
					if (preferredWidth.x368bd9f7b8c336b4)
					{
						result = false;
					}
					else if (x83856b7a59ceccb0.xa576f3bf789274d1(cell) > 1 || cell.x133f2db9e5b5690d.PreferredWidth.xa72bf798a679c0aa)
					{
						result = false;
					}
					else
					{
						table = cell.x133f2db9e5b5690d;
					}
				}
			}
			else
			{
				table = null;
			}
		}
		return result;
	}

	internal static double x431837e8d8f834cd(Table x1ec770899c98a268)
	{
		Node xdfa6ecc6f742f = x1ec770899c98a268.xdfa6ecc6f742f086;
		double num;
		switch (xdfa6ecc6f742f.NodeType)
		{
		case NodeType.Body:
		case NodeType.HeaderFooter:
		case NodeType.Comment:
		case NodeType.Footnote:
		{
			Section section = (Section)xdfa6ecc6f742f.GetAncestor(NodeType.Section);
			PageSetup pageSetup = section.PageSetup;
			num = pageSetup.PageWidth - (pageSetup.LeftMargin + pageSetup.RightMargin);
			break;
		}
		case NodeType.Cell:
		{
			Cell cell = (Cell)xdfa6ecc6f742f;
			num = cell.CellFormat.Width;
			break;
		}
		case NodeType.Shape:
		{
			Shape shape = (Shape)xdfa6ecc6f742f;
			TextBox textBox = new TextBox(shape);
			num = shape.Width - (textBox.InternalMarginLeft + textBox.InternalMarginRight);
			Stroke stroke = shape.Stroke;
			if (stroke.On)
			{
				num -= stroke.Weight;
			}
			break;
		}
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("idfboembcedccfkchebdjdidedpdcegeadnemceffokfgdcgacjgobahfchhlbohdneiacmioadjmbkjmabkcbikfbpkmmfl", 23008483)));
		}
		return num;
	}

	private void x77478a905c1527c3()
	{
		xb0ef242fcce72c0e = x431837e8d8f834cd(x0f62a530ebbd1b7d) - x0f62a530ebbd1b7d.LeftIndent;
	}

	private void xc4eb02b97204b660()
	{
		PreferredWidth preferredWidth = x0f62a530ebbd1b7d.PreferredWidth;
		switch (preferredWidth.Type)
		{
		case PreferredWidthType.Auto:
			xa15d56ce345a06f5 = Math.Min(xb0ef242fcce72c0e, xc82a882776e30b62.x9f4c543928c73298);
			break;
		case PreferredWidthType.Points:
			if (preferredWidth.x40aae25d22abf007)
			{
				xa15d56ce345a06f5 = preferredWidth.Value;
			}
			else
			{
				xa15d56ce345a06f5 = Math.Min(xb0ef242fcce72c0e, xc82a882776e30b62.x9f4c543928c73298);
			}
			break;
		case PreferredWidthType.Percent:
			if (preferredWidth.x40aae25d22abf007)
			{
				xa15d56ce345a06f5 = xb0ef242fcce72c0e * preferredWidth.Value / 100.0;
			}
			else
			{
				xa15d56ce345a06f5 = Math.Min(xb0ef242fcce72c0e, xc82a882776e30b62.x9f4c543928c73298);
			}
			break;
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("deoojffpdfmpdfdabfkagfbbkeibjpobcegcidncodededldodcepcjeeopefdhfhdoflcfgnbmgdoch", 232648174)));
		}
		xe6b3c9ff3e235af7 = Math.Max(xa15d56ce345a06f5, xc82a882776e30b62.xf41d956c067e2b4d);
	}

	private void xc7c9e48a1ef5c3cd()
	{
		x51aaee836a366f91();
		x71395d249a551229();
		x03adc0f475318f3f();
		x604676b7478f8d25();
		x78a796b7013ca900();
		x284c10839a9d2983();
		x80ee1aca9f23effc();
		if (x4e5af990e7597357 < 0.0)
		{
			xcd9b8a4aced838df();
			x4a2dedaaba1ddf5f();
			x6be74e0f8782f149();
		}
	}

	private void x51aaee836a366f91()
	{
		x4e5af990e7597357 = xe6b3c9ff3e235af7 - x83856b7a59ceccb0.x6b51de0344d46543(x0f62a530ebbd1b7d);
		for (int i = 0; i < x660741034f534cfd.Length; i++)
		{
			x4c38e800e85b21ad x4c38e800e85b21ad2 = x660741034f534cfd[i];
			x4c38e800e85b21ad2.x9ff98c6e27f967f5.x9f4c543928c73298 = Math.Max(x4c38e800e85b21ad2.x9ff98c6e27f967f5.xf41d956c067e2b4d, x4c38e800e85b21ad2.x9ff98c6e27f967f5.x9f4c543928c73298);
			x4c38e800e85b21ad2.x93308e6d4fdc657d = x4c38e800e85b21ad2.x9ff98c6e27f967f5.xf41d956c067e2b4d;
			x4e5af990e7597357 -= x4c38e800e85b21ad2.x9ff98c6e27f967f5.xf41d956c067e2b4d;
			switch (x4c38e800e85b21ad2.xaf2198f89f0119d3.Type)
			{
			case PreferredWidthType.Auto:
				x7371b33543162018++;
				x40b1befb6d815191 += x4c38e800e85b21ad2.x9ff98c6e27f967f5.xf41d956c067e2b4d;
				x354ff0a0e0bcbb70 += x4c38e800e85b21ad2.x9ff98c6e27f967f5.x9f4c543928c73298;
				break;
			case PreferredWidthType.Points:
				x5745e31b23885473++;
				x87766f56ff88394f += x4c38e800e85b21ad2.x9ff98c6e27f967f5.x9f4c543928c73298;
				break;
			case PreferredWidthType.Percent:
				x8c6321442dd06ede++;
				x7daa08a7cc637d21 += x4c38e800e85b21ad2.xaf2198f89f0119d3.Value;
				break;
			}
		}
	}

	private void x71395d249a551229()
	{
		if (!(x4e5af990e7597357 > 0.0) || x8c6321442dd06ede <= 0)
		{
			return;
		}
		double num = xe6b3c9ff3e235af7 - x83856b7a59ceccb0.x6b51de0344d46543(x0f62a530ebbd1b7d);
		for (int i = 0; i < x660741034f534cfd.Length; i++)
		{
			x4c38e800e85b21ad x4c38e800e85b21ad2 = x660741034f534cfd[i];
			PreferredWidth xaf2198f89f0119d = x4c38e800e85b21ad2.xaf2198f89f0119d3;
			if (xaf2198f89f0119d.x368bd9f7b8c336b4)
			{
				double num2 = Math.Max(x4c38e800e85b21ad2.x9ff98c6e27f967f5.xf41d956c067e2b4d, xaf2198f89f0119d.Value * num / 100.0);
				x4e5af990e7597357 += x4c38e800e85b21ad2.x93308e6d4fdc657d - num2;
				x4c38e800e85b21ad2.x93308e6d4fdc657d = num2;
			}
		}
	}

	private void x03adc0f475318f3f()
	{
		if (!(x4e5af990e7597357 > 0.0))
		{
			return;
		}
		for (int i = 0; i < x660741034f534cfd.Length; i++)
		{
			x4c38e800e85b21ad x4c38e800e85b21ad2 = x660741034f534cfd[i];
			PreferredWidth xaf2198f89f0119d = x4c38e800e85b21ad2.xaf2198f89f0119d3;
			if (xaf2198f89f0119d.x08428aa3999da322 && xaf2198f89f0119d.Value > x4c38e800e85b21ad2.x93308e6d4fdc657d)
			{
				x4e5af990e7597357 += x4c38e800e85b21ad2.x93308e6d4fdc657d - xaf2198f89f0119d.Value;
				x4c38e800e85b21ad2.x93308e6d4fdc657d = xaf2198f89f0119d.Value;
			}
		}
	}

	private void x604676b7478f8d25()
	{
		if (!(x4e5af990e7597357 > 0.0) || x7371b33543162018 <= 0)
		{
			return;
		}
		x4e5af990e7597357 += x40b1befb6d815191;
		for (int i = 0; i < x660741034f534cfd.Length; i++)
		{
			x4c38e800e85b21ad x4c38e800e85b21ad2 = x660741034f534cfd[i];
			PreferredWidth xaf2198f89f0119d = x4c38e800e85b21ad2.xaf2198f89f0119d3;
			if (xaf2198f89f0119d.xa72bf798a679c0aa && x354ff0a0e0bcbb70 != 0.0)
			{
				double num = Math.Max(x4c38e800e85b21ad2.x93308e6d4fdc657d, x4e5af990e7597357 * x4c38e800e85b21ad2.x9ff98c6e27f967f5.x9f4c543928c73298 / x354ff0a0e0bcbb70);
				x4e5af990e7597357 -= num;
				x354ff0a0e0bcbb70 -= x4c38e800e85b21ad2.x9ff98c6e27f967f5.x9f4c543928c73298;
				x4c38e800e85b21ad2.x93308e6d4fdc657d = num;
			}
		}
	}

	private void x78a796b7013ca900()
	{
		if (!(x4e5af990e7597357 > 0.0) || !x31487d0887f08f2b || !(x7daa08a7cc637d21 < 100.0))
		{
			return;
		}
		for (int i = 0; i < x660741034f534cfd.Length; i++)
		{
			x4c38e800e85b21ad x4c38e800e85b21ad2 = x660741034f534cfd[i];
			PreferredWidth xaf2198f89f0119d = x4c38e800e85b21ad2.xaf2198f89f0119d3;
			if (xaf2198f89f0119d.x368bd9f7b8c336b4)
			{
				double num = x4e5af990e7597357 * xaf2198f89f0119d.Value / x7daa08a7cc637d21;
				x4e5af990e7597357 -= num;
				x7daa08a7cc637d21 -= xaf2198f89f0119d.Value;
				x4c38e800e85b21ad2.x93308e6d4fdc657d += num;
				if (x4e5af990e7597357 == 0.0 || x7daa08a7cc637d21 == 0.0)
				{
					break;
				}
			}
		}
	}

	private void x284c10839a9d2983()
	{
		if (!(x4e5af990e7597357 > 0.0) || x5745e31b23885473 <= 0)
		{
			return;
		}
		for (int i = 0; i < x660741034f534cfd.Length; i++)
		{
			x4c38e800e85b21ad x4c38e800e85b21ad2 = x660741034f534cfd[i];
			PreferredWidth xaf2198f89f0119d = x4c38e800e85b21ad2.xaf2198f89f0119d3;
			if (xaf2198f89f0119d.x08428aa3999da322)
			{
				double num = x4e5af990e7597357 * x4c38e800e85b21ad2.x9ff98c6e27f967f5.x9f4c543928c73298 / x87766f56ff88394f;
				x4e5af990e7597357 -= num;
				x87766f56ff88394f -= x4c38e800e85b21ad2.x9ff98c6e27f967f5.x9f4c543928c73298;
				x4c38e800e85b21ad2.x93308e6d4fdc657d += num;
			}
		}
	}

	private void x80ee1aca9f23effc()
	{
		if (x4e5af990e7597357 > 0.0)
		{
			int num = x660741034f534cfd.Length;
			int num2 = num;
			while (num2-- > 0)
			{
				double num3 = x4e5af990e7597357 / (double)num;
				x4e5af990e7597357 -= num3;
				num--;
				x660741034f534cfd[num2].x93308e6d4fdc657d += num3;
			}
		}
	}

	private void xcd9b8a4aced838df()
	{
		if (!(x4e5af990e7597357 < 0.0))
		{
			return;
		}
		double num = 0.0;
		for (int num2 = x660741034f534cfd.Length - 1; num2 >= 0; num2--)
		{
			x4c38e800e85b21ad x4c38e800e85b21ad2 = x660741034f534cfd[num2];
			if (x4c38e800e85b21ad2.xaf2198f89f0119d3.xa72bf798a679c0aa)
			{
				num += x4c38e800e85b21ad2.x93308e6d4fdc657d - x4c38e800e85b21ad2.x9ff98c6e27f967f5.xf41d956c067e2b4d;
			}
		}
		int num3 = x660741034f534cfd.Length - 1;
		while (num3 >= 0 && num > 0.0)
		{
			x4c38e800e85b21ad x4c38e800e85b21ad3 = x660741034f534cfd[num3];
			if (x4c38e800e85b21ad3.xaf2198f89f0119d3.xa72bf798a679c0aa)
			{
				double num4 = x4c38e800e85b21ad3.x93308e6d4fdc657d - x4c38e800e85b21ad3.x9ff98c6e27f967f5.xf41d956c067e2b4d;
				double num5 = x4e5af990e7597357 * num4 / num;
				x4c38e800e85b21ad3.x93308e6d4fdc657d += num5;
				x4e5af990e7597357 -= num5;
				num -= num4;
				if (x4e5af990e7597357 >= 0.0)
				{
					break;
				}
			}
			num3--;
		}
	}

	private void x4a2dedaaba1ddf5f()
	{
		if (!(x4e5af990e7597357 < 0.0))
		{
			return;
		}
		double num = 0.0;
		for (int num2 = x660741034f534cfd.Length - 1; num2 >= 0; num2--)
		{
			x4c38e800e85b21ad x4c38e800e85b21ad2 = x660741034f534cfd[num2];
			if (x4c38e800e85b21ad2.xaf2198f89f0119d3.x08428aa3999da322)
			{
				num += x4c38e800e85b21ad2.x93308e6d4fdc657d - x4c38e800e85b21ad2.x9ff98c6e27f967f5.xf41d956c067e2b4d;
			}
		}
		int num3 = x660741034f534cfd.Length - 1;
		while (num3 >= 0 && num > 0.0)
		{
			x4c38e800e85b21ad x4c38e800e85b21ad3 = x660741034f534cfd[num3];
			if (x4c38e800e85b21ad3.xaf2198f89f0119d3.x08428aa3999da322)
			{
				double num4 = x4c38e800e85b21ad3.x93308e6d4fdc657d - x4c38e800e85b21ad3.x9ff98c6e27f967f5.xf41d956c067e2b4d;
				double num5 = x4e5af990e7597357 * num4 / num;
				x4c38e800e85b21ad3.x93308e6d4fdc657d += num5;
				x4e5af990e7597357 -= num5;
				num -= num4;
				if (x4e5af990e7597357 >= 0.0)
				{
					break;
				}
			}
			num3--;
		}
	}

	private void x6be74e0f8782f149()
	{
		if (!(x4e5af990e7597357 < 0.0))
		{
			return;
		}
		double num = 0.0;
		for (int num2 = x660741034f534cfd.Length - 1; num2 >= 0; num2--)
		{
			x4c38e800e85b21ad x4c38e800e85b21ad2 = x660741034f534cfd[num2];
			if (x4c38e800e85b21ad2.xaf2198f89f0119d3.x368bd9f7b8c336b4)
			{
				num += x4c38e800e85b21ad2.x93308e6d4fdc657d - x4c38e800e85b21ad2.x9ff98c6e27f967f5.xf41d956c067e2b4d;
			}
		}
		int num3 = x660741034f534cfd.Length - 1;
		while (num3 >= 0 && num > 0.0)
		{
			x4c38e800e85b21ad x4c38e800e85b21ad3 = x660741034f534cfd[num3];
			if (x4c38e800e85b21ad3.xaf2198f89f0119d3.x368bd9f7b8c336b4)
			{
				double num4 = x4c38e800e85b21ad3.x93308e6d4fdc657d - x4c38e800e85b21ad3.x9ff98c6e27f967f5.xf41d956c067e2b4d;
				double num5 = x4e5af990e7597357 * num4 / num;
				x4c38e800e85b21ad3.x93308e6d4fdc657d += num5;
				x4e5af990e7597357 -= num5;
				num -= num4;
				if (x4e5af990e7597357 >= 0.0)
				{
					break;
				}
			}
			num3--;
		}
	}

	private x66ed6507f98b1be8 xb6f3586d2f1ff486(Cell xe6de5e5fa2d44af5)
	{
		x66ed6507f98b1be8 x66ed6507f98b1be9 = new x66ed6507f98b1be8();
		foreach (Node childNode in xe6de5e5fa2d44af5.ChildNodes)
		{
			xfc1a536570a870b3(childNode, x66ed6507f98b1be9);
		}
		x66ed6507f98b1be9.x9f4c543928c73298 = Math.Max(x66ed6507f98b1be9.xf41d956c067e2b4d, x66ed6507f98b1be9.x9f4c543928c73298);
		PreferredWidth preferredWidth = xe6de5e5fa2d44af5.CellFormat.PreferredWidth;
		if (preferredWidth.x08428aa3999da322 && preferredWidth.x40aae25d22abf007)
		{
			x66ed6507f98b1be9.x9f4c543928c73298 = Math.Max(x66ed6507f98b1be9.xf41d956c067e2b4d, preferredWidth.Value);
		}
		x66ed6507f98b1be9.xd6b6ed77479ef68c(x83856b7a59ceccb0.xddfe984e273cbb83(xe6de5e5fa2d44af5));
		return x66ed6507f98b1be9;
	}

	private void xfc1a536570a870b3(Node xb99e63b0fcf75db4, x66ed6507f98b1be8 x30fdecd22136d9de)
	{
		switch (xb99e63b0fcf75db4.NodeType)
		{
		case NodeType.Paragraph:
		{
			Paragraph x31e6518f5e08db6c = (Paragraph)xb99e63b0fcf75db4;
			x30fdecd22136d9de.x295cb4a1df7a5add(x81bf1fc4c9a6ef58.x7d880ef92b7e4841(x31e6518f5e08db6c));
			break;
		}
		case NodeType.Table:
		{
			Table table = (Table)xb99e63b0fcf75db4;
			xdce5f72473519d4e xdce5f72473519d4e2 = new xdce5f72473519d4e(table, suppressNestedTablesUpdates: true);
			x66ed6507f98b1be8 x6e304abf38447e = xdce5f72473519d4e2.xadbaf0fef5a4f7fb();
			x30fdecd22136d9de.x295cb4a1df7a5add(x6e304abf38447e);
			x88c9934cd61f7254.Add(table);
			break;
		}
		case NodeType.CustomXmlMarkup:
		case NodeType.StructuredDocumentTag:
		{
			CompositeNode compositeNode = (CompositeNode)xb99e63b0fcf75db4;
			for (Node node = compositeNode.xfe93db1ba6e25886; node != null; node = node.xa6890a1cb2b8896e)
			{
				xfc1a536570a870b3(node, x30fdecd22136d9de);
			}
			break;
		}
		}
	}

	private void x1d35206a77c2596d()
	{
		for (int i = 0; i < x0f62a530ebbd1b7d.Rows.Count; i++)
		{
			for (int j = 0; j < x660741034f534cfd.Length; j++)
			{
				Cell cell = x0f62a530ebbd1b7d.xfeb19f1007c0b581(j, i);
				if (cell != null)
				{
					double val = x70df481ca674b985(cell, j);
					val = Math.Min(val, 1584.0);
					cell.CellFormat.Width = val;
				}
			}
		}
	}

	private double x70df481ca674b985(Cell xe6de5e5fa2d44af5, int xbeb0e74fd1e3aefb)
	{
		switch (xe6de5e5fa2d44af5.CellFormat.HorizontalMerge)
		{
		case CellMerge.None:
			return x660741034f534cfd[xbeb0e74fd1e3aefb].x93308e6d4fdc657d;
		case CellMerge.First:
		{
			double num = 0.0;
			for (int i = 0; i < x83856b7a59ceccb0.xa576f3bf789274d1(xe6de5e5fa2d44af5); i++)
			{
				num += x660741034f534cfd[xbeb0e74fd1e3aefb + i].x93308e6d4fdc657d;
			}
			return num;
		}
		case CellMerge.Previous:
			return 0.0;
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("kbffadmfkcdgkckgicbhncihbcphanfiabnipaejdbljabckbmiklaalaahlkaolmpemhplmnlcn", 1624659141)));
		}
	}

	private void xa3e911c327ec2f91()
	{
		for (int i = 0; i < x88c9934cd61f7254.Count; i++)
		{
			Table table = (Table)x88c9934cd61f7254[i];
			table.xae19a615b411c9fa();
		}
	}
}
