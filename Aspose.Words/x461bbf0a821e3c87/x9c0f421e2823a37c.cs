using Aspose.Words;
using Aspose.Words.Tables;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;
using x9db5f2e5af3d596e;

namespace x461bbf0a821e3c87;

internal class x9c0f421e2823a37c
{
	private readonly Table xca6c0c37ef395ecd;

	private readonly bool x7fef75997c604ece;

	private readonly bool xe5bd2a5b6d3be420;

	private readonly bool x05d8c3449e2b6d97;

	private bool x361303c781b99af5;

	private bool xa7ce11df41e62a4d;

	private bool x506c68e016e3c7a1;

	private bool x5e71ccbd41ff3121;

	private bool xdd916f74606e7e8f;

	private bool x6cc0b57bfeb986a4;

	private Border xf663ae6df3f8dad8;

	private readonly x09ce2c02826e31a6 xe2d4e13e51c33460 = new x09ce2c02826e31a6();

	private readonly x95afcd205d57fc9c x00b023d6a2bf9648 = new x95afcd205d57fc9c();

	private int xc8da7cc3392a1eb6;

	private int x6337531efbb24471;

	private bool xdf1f0494abf58573;

	private bool xfb5cc8bab5258fee;

	private bool x23fdeda3959e559e;

	internal Table x3aafce4bafb29dc2 => xca6c0c37ef395ecd;

	internal int x5840ec53f70adb17 => xe2d4e13e51c33460.xd44988f225497f3a - 1;

	internal int xa672f280367330ca => x3a2949e4f384d864(0, x5840ec53f70adb17);

	internal xdf87e260e867a1a3 x39c11fce0571e063
	{
		get
		{
			if (xc8da7cc3392a1eb6 >= x00b023d6a2bf9648.Count)
			{
				return null;
			}
			return x00b023d6a2bf9648.get_xe6d4b1b411ed94b5(xc8da7cc3392a1eb6);
		}
	}

	internal x9546c9d5ffe8dc51 x1d23559baf0e4415
	{
		get
		{
			if (x39c11fce0571e063 == null || x6337531efbb24471 >= x5840ec53f70adb17)
			{
				return null;
			}
			return x39c11fce0571e063.x0d61f3263f0ff64b[x6337531efbb24471];
		}
	}

	internal bool x7e7b36d274a1403e => xdf1f0494abf58573;

	internal bool x0208a1cf186bdfeb
	{
		get
		{
			return x23fdeda3959e559e;
		}
		set
		{
			x23fdeda3959e559e = value;
		}
	}

	internal x9c0f421e2823a37c(Table tableNode, bool resolveInheritedBorders, bool populateEmptyPadBorders, bool resolveInheritedPaddings)
	{
		xca6c0c37ef395ecd = tableNode;
		x7fef75997c604ece = resolveInheritedBorders;
		xe5bd2a5b6d3be420 = populateEmptyPadBorders;
		x05d8c3449e2b6d97 = resolveInheritedPaddings;
		xad265ae7c3a3f1db();
		xebfec07ffbde48f9();
		xf954166840dce232();
		xf9fafeff67076a95();
		if (xfb5cc8bab5258fee)
		{
			x227750bf2ab566ff();
		}
	}

	internal void x550f875a2eea9b05()
	{
		xc8da7cc3392a1eb6 = 0;
	}

	internal void xc42fc0160c161943()
	{
		xc8da7cc3392a1eb6++;
	}

	internal void xbeec4ad54bcadf05()
	{
		x6337531efbb24471 = -1;
		x5d8b5df141c961ba();
	}

	internal void x5d8b5df141c961ba()
	{
		do
		{
			x6337531efbb24471++;
		}
		while (x1d23559baf0e4415 != null && x1d23559baf0e4415.xf8cef531dae89ea3.x61127d98597c4898);
	}

	internal int x3a2949e4f384d864(int xc0c4c459c6ccbd00)
	{
		return x3a2949e4f384d864(xc0c4c459c6ccbd00, 1);
	}

	private int x3a2949e4f384d864(int xd4f974c06ffa392b, int x10f4d88af727adbc)
	{
		return x10f006c778799280(xd4f974c06ffa392b + x10f4d88af727adbc) - x10f006c778799280(xd4f974c06ffa392b);
	}

	internal int[] x65afe16d1469539e()
	{
		int[] array = new int[xe2d4e13e51c33460.xd44988f225497f3a - 1];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = x3a2949e4f384d864(i);
		}
		return array;
	}

	internal int x10f006c778799280(int xc0c4c459c6ccbd00)
	{
		return xe2d4e13e51c33460.xf15263674eb297bb(xc0c4c459c6ccbd00);
	}

	private void xad265ae7c3a3f1db()
	{
		for (Row row = xca6c0c37ef395ecd.FirstRow; row != null; row = row.xebb8ac1152da9a1f)
		{
			int num = x7e893746467e468b(row);
			xe2d4e13e51c33460.set_xe6d4b1b411ed94b5(num, (object)null);
			foreach (Cell cell in row.Cells)
			{
				xf8cef531dae89ea3 xf8cef531dae89ea = cell.xf8cef531dae89ea3;
				num += xf8cef531dae89ea.xdc1bf80853046136;
				xe2d4e13e51c33460.set_xe6d4b1b411ed94b5(num, (object)null);
			}
		}
	}

	private void xebfec07ffbde48f9()
	{
		RowCollection rows = xca6c0c37ef395ecd.Rows;
		int count = rows.Count;
		for (int i = 0; i < count; i++)
		{
			xdf87e260e867a1a3 xdf87e260e867a1a4 = new xdf87e260e867a1a3(x5840ec53f70adb17, rows[i]);
			x00b023d6a2bf9648.Add(xdf87e260e867a1a4);
			x9a12b428d9701ee0(xdf87e260e867a1a4);
			CellCollection cells = xdf87e260e867a1a4.x888f9f147ebe6b41.Cells;
			int count2 = cells.Count;
			for (int j = 0; j < count2; j++)
			{
				Cell cell = cells[j];
				xf8cef531dae89ea3 xf8cef531dae89ea = cell.xf8cef531dae89ea3;
				int xdc1bf80853046136 = xf8cef531dae89ea.xdc1bf80853046136;
				if (xf8cef531dae89ea.x61127d98597c4898 && xdc1bf80853046136 == 0)
				{
					continue;
				}
				x9546c9d5ffe8dc51 x9546c9d5ffe8dc52 = x9546c9d5ffe8dc51.x3f6efc6c7757adcf(xf8cef531dae89ea, cell);
				int num = x68b517d4f87dd562(xdf87e260e867a1a4.x888f9f147ebe6b41, j);
				int num2 = xe2d4e13e51c33460.xf8af57cefd692401(num);
				int xba08ce632055a1d = num + xdc1bf80853046136;
				int num3 = xe2d4e13e51c33460.xf8af57cefd692401(xba08ce632055a1d);
				xdf87e260e867a1a4.x0d61f3263f0ff64b[num2] = x9546c9d5ffe8dc52;
				Cell x1725b053e96f3d2c = cell;
				Cell x1725b053e96f3d2c2 = cell;
				if (xf8cef531dae89ea.x338a5e6ab7c5595e == CellMerge.First)
				{
					for (int k = j + 1; k < count2; k++)
					{
						Cell cell2 = cells[k];
						if (cell2.xf8cef531dae89ea3.x338a5e6ab7c5595e != CellMerge.Previous)
						{
							break;
						}
						x1725b053e96f3d2c = cell2;
					}
				}
				if (xf8cef531dae89ea.x1a1dda35b3ae703d == CellMerge.First)
				{
					for (int l = i + 1; l < count; l++)
					{
						Cell cell3 = xde27420e867ffaf8(rows[l], num);
						if (cell3 == null || cell3.xf8cef531dae89ea3.x1a1dda35b3ae703d != CellMerge.Previous)
						{
							break;
						}
						x1725b053e96f3d2c2 = cell3;
					}
				}
				xf8cef531dae89ea3 xf8cef531dae89ea2 = x9546c9d5ffe8dc52.xf8cef531dae89ea3;
				xf8e35360de6e5568(xf8cef531dae89ea2, cell, 3110);
				xf8e35360de6e5568(xf8cef531dae89ea2, cell, 3120);
				xf8e35360de6e5568(xf8cef531dae89ea2, x1725b053e96f3d2c2, 3130);
				xf8e35360de6e5568(xf8cef531dae89ea2, x1725b053e96f3d2c, 3140);
				xf8e35360de6e5568(xf8cef531dae89ea2, cell, 3150);
				xf8e35360de6e5568(xf8cef531dae89ea2, cell, 3160);
				x2e186449d8ca9c32(xf8cef531dae89ea2, cell, 3070);
				x2e186449d8ca9c32(xf8cef531dae89ea2, cell, 3090);
				x2e186449d8ca9c32(xf8cef531dae89ea2, cell, 3080);
				x2e186449d8ca9c32(xf8cef531dae89ea2, cell, 3100);
				for (int m = num2 + 1; m < num3; m++)
				{
					xdf87e260e867a1a4.x0d61f3263f0ff64b[m] = x9546c9d5ffe8dc51.x64306b032bd977c9(xf8cef531dae89ea2, cell);
				}
				if (num3 - num2 > 1)
				{
					xdf1f0494abf58573 = true;
				}
			}
		}
	}

	private void xf8e35360de6e5568(xf8cef531dae89ea3 x8bc826ed14312244, Cell x1725b053e96f3d2c, int xba08ce632055a1d9)
	{
		xff12e519cb47306f(x7fef75997c604ece, x8bc826ed14312244, x1725b053e96f3d2c, xba08ce632055a1d9);
	}

	private void x2e186449d8ca9c32(xf8cef531dae89ea3 x8bc826ed14312244, Cell x1725b053e96f3d2c, int xba08ce632055a1d9)
	{
		xff12e519cb47306f(x05d8c3449e2b6d97, x8bc826ed14312244, x1725b053e96f3d2c, xba08ce632055a1d9);
	}

	private static void xff12e519cb47306f(bool x795930fcc5e05226, xf8cef531dae89ea3 x8bc826ed14312244, Cell x1725b053e96f3d2c, int xba08ce632055a1d9)
	{
		object obj = (x795930fcc5e05226 ? x1725b053e96f3d2c.x88f8929cb2b3ee50(xba08ce632055a1d9) : x1725b053e96f3d2c.x34f1b0fbc88f0b8a(xba08ce632055a1d9));
		if (obj != null)
		{
			x8bc826ed14312244.xae20093bed1e48a8(xba08ce632055a1d9, obj);
		}
	}

	private void x9a12b428d9701ee0(xdf87e260e867a1a3 xa806b754814b9ae0)
	{
		int xba08ce632055a1d = x7e893746467e468b(xa806b754814b9ae0.x888f9f147ebe6b41);
		int num = xe2d4e13e51c33460.xf8af57cefd692401(xba08ce632055a1d);
		for (int i = 0; i < num; i++)
		{
			xa806b754814b9ae0.x0d61f3263f0ff64b[i] = x9546c9d5ffe8dc51.xd0d8db66037c4103();
		}
		int xba08ce632055a1d2 = x68b517d4f87dd562(xa806b754814b9ae0.x888f9f147ebe6b41, xa806b754814b9ae0.x888f9f147ebe6b41.Cells.Count);
		int num2 = xe2d4e13e51c33460.xf8af57cefd692401(xba08ce632055a1d2);
		for (int j = num2; j < x5840ec53f70adb17; j++)
		{
			xa806b754814b9ae0.x0d61f3263f0ff64b[j] = x9546c9d5ffe8dc51.xd0d8db66037c4103();
		}
		if (num > 0 || num2 < x5840ec53f70adb17)
		{
			xdf1f0494abf58573 = true;
			xfb5cc8bab5258fee = true;
		}
	}

	private void xf954166840dce232()
	{
		for (int i = 0; i < x00b023d6a2bf9648.Count; i++)
		{
			int num = 1;
			for (int num2 = x5840ec53f70adb17 - 1; num2 >= 0; num2--)
			{
				x9546c9d5ffe8dc51 x9546c9d5ffe8dc52 = x00b023d6a2bf9648.get_xe6d4b1b411ed94b5(i).x0d61f3263f0ff64b[num2];
				switch (x9546c9d5ffe8dc52.xf8cef531dae89ea3.x338a5e6ab7c5595e)
				{
				case CellMerge.None:
				case CellMerge.First:
					x9546c9d5ffe8dc52.xf8cef531dae89ea3.xdc1bf80853046136 = x3a2949e4f384d864(num2, num);
					x9546c9d5ffe8dc52.x2f4795c5e4c1617e = num;
					num = 1;
					break;
				case CellMerge.Previous:
					num++;
					break;
				}
			}
		}
	}

	private void xf9fafeff67076a95()
	{
		for (int i = 0; i < x5840ec53f70adb17; i++)
		{
			int num = 1;
			for (int num2 = x00b023d6a2bf9648.Count - 1; num2 >= 0; num2--)
			{
				x9546c9d5ffe8dc51 x9546c9d5ffe8dc52 = x00b023d6a2bf9648.get_xe6d4b1b411ed94b5(num2).x0d61f3263f0ff64b[i];
				switch (x9546c9d5ffe8dc52.xf8cef531dae89ea3.x1a1dda35b3ae703d)
				{
				case CellMerge.None:
				case CellMerge.First:
					x9546c9d5ffe8dc52.xe9fd99df52338f59 = num;
					num = 1;
					break;
				case CellMerge.Previous:
					num++;
					break;
				}
			}
		}
	}

	private void x227750bf2ab566ff()
	{
		if (xe5bd2a5b6d3be420)
		{
			xedb0eb766e25e0c9 xedb0eb766e25e0c = xca6c0c37ef395ecd.FirstRow.xedb0eb766e25e0c9;
			x361303c781b99af5 = xedb0eb766e25e0c.xbc5dc59d0d9b620d(4060);
			xa7ce11df41e62a4d = xedb0eb766e25e0c.xbc5dc59d0d9b620d(4080);
			x506c68e016e3c7a1 = xedb0eb766e25e0c.xbc5dc59d0d9b620d(4050);
			x5e71ccbd41ff3121 = xedb0eb766e25e0c.xbc5dc59d0d9b620d(4070);
			xdd916f74606e7e8f = xedb0eb766e25e0c.xbc5dc59d0d9b620d(4090);
			x6cc0b57bfeb986a4 = xedb0eb766e25e0c.xbc5dc59d0d9b620d(4100);
			bool flag = x361303c781b99af5 || xa7ce11df41e62a4d || x506c68e016e3c7a1 || x5e71ccbd41ff3121 || xdd916f74606e7e8f || x6cc0b57bfeb986a4;
			xf663ae6df3f8dad8 = (flag ? new Border(LineStyle.None, 0, x26d9ecb4bdf0456d.x45260ad4b94166f2) : null);
		}
		for (int i = 0; i < x00b023d6a2bf9648.Count; i++)
		{
			xdf87e260e867a1a3 xdf87e260e867a1a4 = x00b023d6a2bf9648.get_xe6d4b1b411ed94b5(i);
			for (int j = 0; x9996e7f17d012e3b(xdf87e260e867a1a4.x0d61f3263f0ff64b[j], i, j); j++)
			{
			}
			int num = x5840ec53f70adb17 - 1;
			while (x9996e7f17d012e3b(xdf87e260e867a1a4.x0d61f3263f0ff64b[num], i, num))
			{
				num--;
			}
		}
	}

	private bool x9996e7f17d012e3b(x9546c9d5ffe8dc51 xe6de5e5fa2d44af5, int x3e0a106e44f5f6eb, int xacf07c4ed65954c1)
	{
		bool xccc3088817e63d2c = xe6de5e5fa2d44af5.xccc3088817e63d2c;
		if (xccc3088817e63d2c)
		{
			xf8cef531dae89ea3 xf8cef531dae89ea = xe6de5e5fa2d44af5.xf8cef531dae89ea3;
			bool flag = x3e0a106e44f5f6eb == 0;
			bool flag2 = x3e0a106e44f5f6eb == x00b023d6a2bf9648.Count - 1;
			bool flag3 = !flag && xcc0bea2b80d45c00(xf8cef531dae89ea, 3110, x00b023d6a2bf9648.get_xe6d4b1b411ed94b5(x3e0a106e44f5f6eb - 1).x0d61f3263f0ff64b[xacf07c4ed65954c1].xf8cef531dae89ea3, 3130);
			bool flag4 = !flag2 && xcc0bea2b80d45c00(xf8cef531dae89ea, 3130, x00b023d6a2bf9648.get_xe6d4b1b411ed94b5(x3e0a106e44f5f6eb + 1).x0d61f3263f0ff64b[xacf07c4ed65954c1].xf8cef531dae89ea3, 3110);
			if (xf663ae6df3f8dad8 != null)
			{
				if ((flag && x506c68e016e3c7a1) || (!flag && xdd916f74606e7e8f && !flag3))
				{
					xf8cef531dae89ea.xa8c2637cc4888928 = xf663ae6df3f8dad8;
				}
				if ((flag2 && x5e71ccbd41ff3121) || (!flag2 && xdd916f74606e7e8f && !flag4))
				{
					xf8cef531dae89ea.x79d902473861f242 = xf663ae6df3f8dad8;
				}
				bool flag5 = xacf07c4ed65954c1 == 0;
				bool flag6 = xacf07c4ed65954c1 == x5840ec53f70adb17 - 1;
				bool flag7 = !flag5 && xcc0bea2b80d45c00(xf8cef531dae89ea, 3120, x00b023d6a2bf9648.get_xe6d4b1b411ed94b5(x3e0a106e44f5f6eb).x0d61f3263f0ff64b[xacf07c4ed65954c1 - 1].xf8cef531dae89ea3, 3140);
				bool flag8 = !flag6 && xcc0bea2b80d45c00(xf8cef531dae89ea, 3140, x00b023d6a2bf9648.get_xe6d4b1b411ed94b5(x3e0a106e44f5f6eb).x0d61f3263f0ff64b[xacf07c4ed65954c1 + 1].xf8cef531dae89ea3, 3120);
				if ((flag5 && x361303c781b99af5) || (!flag5 && x6cc0b57bfeb986a4 && !flag7))
				{
					xf8cef531dae89ea.xaea087ab32102492 = xf663ae6df3f8dad8;
				}
				if ((flag6 && xa7ce11df41e62a4d) || (!flag6 && x6cc0b57bfeb986a4 && !flag8))
				{
					xf8cef531dae89ea.xd7a21e27974f626c = xf663ae6df3f8dad8;
				}
			}
		}
		return xccc3088817e63d2c;
	}

	private static bool xcc0bea2b80d45c00(xf8cef531dae89ea3 x6b8e154b42d5c1e3, int x2b84b762d8117746, xf8cef531dae89ea3 x50a18ad2656e7181, int x72b34ef15ee8c816)
	{
		object obj = x50a18ad2656e7181.xf7866f89640a29a3(x72b34ef15ee8c816);
		bool flag = obj != null;
		if (flag)
		{
			x6b8e154b42d5c1e3.xae20093bed1e48a8(x2b84b762d8117746, obj);
		}
		return flag;
	}

	private static int x7e893746467e468b(Row xdeeaa0712937b330)
	{
		xedb0eb766e25e0c9 xedb0eb766e25e0c = xdeeaa0712937b330.xedb0eb766e25e0c9;
		return xdeeaa0712937b330.ParentTable.x7ffcb3c8df4c42b3() + xedb0eb766e25e0c.x90aab2cbd2f48623;
	}

	private static int x68b517d4f87dd562(Row xdeeaa0712937b330, int x2238fe9b8f06bd9d)
	{
		int num = x7e893746467e468b(xdeeaa0712937b330);
		CellCollection cells = xdeeaa0712937b330.Cells;
		for (int i = 0; i < x2238fe9b8f06bd9d; i++)
		{
			num += cells[i].xf8cef531dae89ea3.xdc1bf80853046136;
		}
		return num;
	}

	private static Cell xde27420e867ffaf8(Row xe787f0bf93a4c343, int xa447fc54e41dfe06)
	{
		int num = x7e893746467e468b(xe787f0bf93a4c343);
		if (num <= xa447fc54e41dfe06)
		{
			CellCollection cells = xe787f0bf93a4c343.Cells;
			foreach (Cell item in cells)
			{
				if (num == xa447fc54e41dfe06)
				{
					return item;
				}
				num += item.xf8cef531dae89ea3.xdc1bf80853046136;
			}
		}
		return null;
	}
}
