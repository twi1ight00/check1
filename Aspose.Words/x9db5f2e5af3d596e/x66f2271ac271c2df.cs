using System.Collections;
using Aspose.Words.Tables;
using x6c95d9cf46ff5f25;

namespace x9db5f2e5af3d596e;

internal class x66f2271ac271c2df
{
	private const int x3e049ebd90c60b37 = 1;

	private int[] xb398bdc5852d7902;

	private int xe55137f2e976e51a;

	private int[] xb79766cc91f2951a;

	private int x66401bbb81167b86;

	private int xa45f904df2eadee8;

	private int x883bd562949af7ee;

	private int xf54a8003057d59ef;

	private int x7c648a0adec8ace8;

	private readonly bool xbe2f900943fc4af3;

	internal int[] x7eab159619d586e1 => xb398bdc5852d7902;

	internal int x71e5b802707a5021 => x66401bbb81167b86;

	internal int x0364c07ad4dcfe0c => xa45f904df2eadee8;

	internal int x7390fcf53e1bd984 => x883bd562949af7ee;

	internal int x851fcfc17df82b1b => xf54a8003057d59ef;

	internal x66f2271ac271c2df(Table table)
		: this(table, isRevision: false)
	{
	}

	internal x66f2271ac271c2df(Table table, bool isRevision)
	{
		xbe2f900943fc4af3 = isRevision;
		x593cc24d41cfe6b9(table);
	}

	private xedb0eb766e25e0c9 x873ddcd426037d62(Row xa806b754814b9ae0)
	{
		xedb0eb766e25e0c9 xedb0eb766e25e0c10 = xa806b754814b9ae0.xedb0eb766e25e0c9;
		if (xbe2f900943fc4af3 && xedb0eb766e25e0c10.x0f53f53f15b61ef5)
		{
			xedb0eb766e25e0c10 = (xedb0eb766e25e0c9)xedb0eb766e25e0c10.x5fb16e270c21db2e.xdf4bcc85da8f85b2;
		}
		return xedb0eb766e25e0c10;
	}

	private xf8cef531dae89ea3 x873ddcd426037d62(Cell xe6de5e5fa2d44af5)
	{
		xf8cef531dae89ea3 xf8cef531dae89ea4 = xe6de5e5fa2d44af5.xf8cef531dae89ea3;
		if (xbe2f900943fc4af3 && xf8cef531dae89ea4.x0f53f53f15b61ef5)
		{
			xf8cef531dae89ea4 = (xf8cef531dae89ea3)xf8cef531dae89ea4.x5fb16e270c21db2e.xdf4bcc85da8f85b2;
		}
		return xf8cef531dae89ea4;
	}

	private void x593cc24d41cfe6b9(Table x1ec770899c98a268)
	{
		x09ce2c02826e31a6 x09ce2c02826e31a = new x09ce2c02826e31a6();
		int xc0741c7ff92cf1aa = x873ddcd426037d62(x1ec770899c98a268.FirstRow).xc0741c7ff92cf1aa;
		for (Row firstRow = x1ec770899c98a268.FirstRow; firstRow != null; firstRow = firstRow.xebb8ac1152da9a1f)
		{
			CellCollection cells = firstRow.Cells;
			int num = xc0741c7ff92cf1aa + x873ddcd426037d62(firstRow).x90aab2cbd2f48623;
			x09ce2c02826e31a.set_xe6d4b1b411ed94b5(num, (object)null);
			foreach (Cell item in cells)
			{
				num += x873ddcd426037d62(item).xdc1bf80853046136;
				x09ce2c02826e31a.set_xe6d4b1b411ed94b5(num, (object)null);
			}
		}
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < x09ce2c02826e31a.xd44988f225497f3a - 1; i++)
		{
			int num2 = x09ce2c02826e31a.xf15263674eb297bb(i + 1) - x09ce2c02826e31a.xf15263674eb297bb(i);
			if (num2 > 1)
			{
				arrayList.Add(num2);
			}
		}
		xb398bdc5852d7902 = new int[arrayList.Count];
		for (int j = 0; j < xb398bdc5852d7902.Length; j++)
		{
			xb398bdc5852d7902[j] = (int)arrayList[j];
		}
	}

	internal void xebb8ac1152da9a1f(Row xa806b754814b9ae0)
	{
		int num = 0;
		x7c648a0adec8ace8 = 0;
		xa45f904df2eadee8 = x873ddcd426037d62(xa806b754814b9ae0).x90aab2cbd2f48623;
		int num2 = 0;
		while (num2 < xa45f904df2eadee8 && num < xb398bdc5852d7902.Length)
		{
			num2 += xb398bdc5852d7902[num];
			num++;
		}
		x66401bbb81167b86 = num;
		CellCollection cells = xa806b754814b9ae0.Cells;
		xb79766cc91f2951a = new int[cells.Count];
		for (int i = 0; i < cells.Count; i++)
		{
			int num3 = x8c0a650cb99ccc15(num, x873ddcd426037d62(cells[i]).xdc1bf80853046136);
			xb79766cc91f2951a[i] = num3;
			num += num3;
		}
		xf54a8003057d59ef = x873ddcd426037d62(xa806b754814b9ae0).xd29e69906712391d;
		x883bd562949af7ee = xb398bdc5852d7902.Length - num;
		xe55137f2e976e51a++;
	}

	private int x8c0a650cb99ccc15(int xbeb0e74fd1e3aefb, int x9b0739496f8b5475)
	{
		int num = 0;
		while (x9b0739496f8b5475 > 1 && xbeb0e74fd1e3aefb < xb398bdc5852d7902.Length)
		{
			x9b0739496f8b5475 -= xb398bdc5852d7902[xbeb0e74fd1e3aefb];
			xbeb0e74fd1e3aefb++;
			num++;
		}
		return num;
	}

	internal int xb2e852052ab1c1be()
	{
		return xb79766cc91f2951a[x7c648a0adec8ace8++];
	}
}
