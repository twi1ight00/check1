using System;
using System.Collections;
using Aspose.Words.Tables;
using x1495530f35d79681;
using x1a3e96f4b89a7a77;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using x9db5f2e5af3d596e;

namespace xda075892eccab2ad;

internal class x88fc04b3ff226822
{
	private x88fc04b3ff226822()
	{
	}

	internal static void xd71f0ca619f1aa02(x873451caae5ad4ae xd07ce4b74c5774a7, Table x1ec770899c98a268)
	{
		xedb0eb766e25e0c9 xedb0eb766e25e0c = x1ec770899c98a268.xedb0eb766e25e0c9;
		ArrayList arrayList = xbdab5b753509fff5(xedb0eb766e25e0c.x6caf3a4fef2c9165);
		ArrayList arrayList2 = (xedb0eb766e25e0c.x0f53f53f15b61ef5 ? xbdab5b753509fff5(xedb0eb766e25e0c) : null);
		xd07ce4b74c5774a7.x2307058321cdb62f("w:tblGrid");
		foreach (int item in arrayList)
		{
			xd07ce4b74c5774a7.xc049ea80ee267201("w:gridCol", "w:w", item);
		}
		if (arrayList2 != null)
		{
			xd07ce4b74c5774a7.x2307058321cdb62f("w:tblGridChange");
			xd07ce4b74c5774a7.x2307058321cdb62f("w:tblGrid");
			foreach (int item2 in arrayList2)
			{
				xd07ce4b74c5774a7.xc049ea80ee267201("w:gridCol", "w:w", item2);
			}
			xd07ce4b74c5774a7.x2dfde153f4ef96d0();
			xd07ce4b74c5774a7.x2dfde153f4ef96d0();
		}
		xd07ce4b74c5774a7.x2dfde153f4ef96d0();
	}

	internal static void x0dd2d2739751e83b(x3c85359e1389ad43 xd19f1b93a822ffb3, xedb0eb766e25e0c9 xe193ceb565ecaa0a)
	{
		ArrayList arrayList = new ArrayList();
		xe193ceb565ecaa0a.xae20093bed1e48a8(5103, arrayList);
		while (xd19f1b93a822ffb3.x152cbadbfa8061b1("tblGrid"))
		{
			switch (xd19f1b93a822ffb3.xa66385d80d4d296f)
			{
			case "gridCol":
			{
				int num = 0;
				while (xd19f1b93a822ffb3.x1ac1960adc8c4c39())
				{
					string xa66385d80d4d296f;
					if ((xa66385d80d4d296f = xd19f1b93a822ffb3.xa66385d80d4d296f) != null && xa66385d80d4d296f == "w")
					{
						num = xd19f1b93a822ffb3.xeeed7b3df57c138f;
					}
				}
				arrayList.Add(num);
				break;
			}
			case "tblGridChange":
				x1e9ea5c68f15c1b5(xd19f1b93a822ffb3, xe193ceb565ecaa0a);
				break;
			default:
				xd19f1b93a822ffb3.IgnoreElement();
				break;
			}
		}
	}

	internal static void x37ae3bbd6d2584f4(Table x1ec770899c98a268)
	{
		x66f2271ac271c2df x66f2271ac271c2df = new x66f2271ac271c2df(x1ec770899c98a268, isRevision: false);
		x66f2271ac271c2df x66f2271ac271c2df2 = new x66f2271ac271c2df(x1ec770899c98a268, isRevision: true);
		x1ec770899c98a268.xedb0eb766e25e0c9.xae20093bed1e48a8(5103, new ArrayList(x66f2271ac271c2df.x7eab159619d586e1));
		foreach (Row row3 in x1ec770899c98a268.Rows)
		{
			x66f2271ac271c2df.xebb8ac1152da9a1f(row3);
			x20a9bc7f6003b899(row3.xedb0eb766e25e0c9, x66f2271ac271c2df);
			foreach (Cell cell3 in row3.Cells)
			{
				cell3.xf8cef531dae89ea3.xae20093bed1e48a8(3900, x66f2271ac271c2df.xb2e852052ab1c1be());
			}
		}
		if (xcd4bd3abd72ff2da.xf920f15ca6067ada(x66f2271ac271c2df.x7eab159619d586e1, x66f2271ac271c2df2.x7eab159619d586e1))
		{
			x1ec770899c98a268.xedb0eb766e25e0c9.x097e4f3c708bd29c();
			return;
		}
		if (x1ec770899c98a268.xedb0eb766e25e0c9.x5fb16e270c21db2e == null)
		{
			x1ec770899c98a268.xedb0eb766e25e0c9.x5fb16e270c21db2e = new x5fb16e270c21db2e(new xedb0eb766e25e0c9(), "", DateTime.MinValue);
		}
		x1ec770899c98a268.xedb0eb766e25e0c9.x6caf3a4fef2c9165.xae20093bed1e48a8(5103, new ArrayList(x66f2271ac271c2df2.x7eab159619d586e1));
		foreach (Row row4 in x1ec770899c98a268.Rows)
		{
			xedb0eb766e25e0c9 x6caf3a4fef2c = row4.xedb0eb766e25e0c9.x6caf3a4fef2c9165;
			x66f2271ac271c2df2.xebb8ac1152da9a1f(row4);
			x20a9bc7f6003b899(x6caf3a4fef2c, x66f2271ac271c2df2);
			foreach (Cell cell4 in row4.Cells)
			{
				cell4.xf8cef531dae89ea3.x6caf3a4fef2c9165.xae20093bed1e48a8(3900, x66f2271ac271c2df2.xb2e852052ab1c1be());
			}
		}
	}

	internal static void x6ce78ad60b4a67c9(Row xa806b754814b9ae0)
	{
		Table parentTable = xa806b754814b9ae0.ParentTable;
		if (!parentTable.xedb0eb766e25e0c9.x263d579af1d0d43f(5103))
		{
			xd640b83574a2dc1b(parentTable);
		}
		if (parentTable.xedb0eb766e25e0c9.x0f53f53f15b61ef5)
		{
			x6ce78ad60b4a67c9(xa806b754814b9ae0, x8251c6c98b26412e: false);
		}
		x6ce78ad60b4a67c9(xa806b754814b9ae0, x8251c6c98b26412e: true);
	}

	private static void x20a9bc7f6003b899(xedb0eb766e25e0c9 x0d9383c33dfa78ca, x66f2271ac271c2df xcc293b206a5085f0)
	{
		x0d9383c33dfa78ca.xae20093bed1e48a8(5104, xcc293b206a5085f0.x71e5b802707a5021);
		x0d9383c33dfa78ca.xae20093bed1e48a8(5105, xcc293b206a5085f0.x7390fcf53e1bd984);
		x0d9383c33dfa78ca.x90aab2cbd2f48623 = xcc293b206a5085f0.x0364c07ad4dcfe0c;
		x0d9383c33dfa78ca.xd29e69906712391d = xcc293b206a5085f0.x851fcfc17df82b1b;
	}

	private static void x6ce78ad60b4a67c9(Row xa806b754814b9ae0, bool x8251c6c98b26412e)
	{
		xedb0eb766e25e0c9 xedb0eb766e25e0c = (xedb0eb766e25e0c9)x873ddcd426037d62(xa806b754814b9ae0.xedb0eb766e25e0c9, x8251c6c98b26412e);
		xedb0eb766e25e0c9 xedb0eb766e25e0c2 = (xedb0eb766e25e0c9)x873ddcd426037d62(xa806b754814b9ae0.ParentTable.xedb0eb766e25e0c9, x8251c6c98b26412e);
		ArrayList arrayList = (ArrayList)xedb0eb766e25e0c2.xf7866f89640a29a3(5103);
		int num = (int)xedb0eb766e25e0c.xfe91eeeafcb3026a(5104);
		x20377da646339fb1(arrayList, xedb0eb766e25e0c, xa806b754814b9ae0, x8251c6c98b26412e);
		if (arrayList.Count <= 0)
		{
			return;
		}
		int num2 = num;
		foreach (Cell cell in xa806b754814b9ae0.Cells)
		{
			xf8cef531dae89ea3 xf8cef531dae89ea = cell.xf8cef531dae89ea3;
			int num3 = (int)x873ddcd426037d62(xf8cef531dae89ea, x8251c6c98b26412e).xfe91eeeafcb3026a(3900);
			int num4 = 0;
			int num5 = Math.Min(num2 + num3, arrayList.Count);
			while (num2 < num5)
			{
				num4 += (int)arrayList[num2++];
			}
			if (x8251c6c98b26412e)
			{
				xf8cef531dae89ea.x6caf3a4fef2c9165.xdc1bf80853046136 = num4;
			}
			else if (xf8cef531dae89ea.x0f53f53f15b61ef5)
			{
				xf8cef531dae89ea.xdc1bf80853046136 = num4;
			}
		}
	}

	private static x7f77ea92be0d9042 x873ddcd426037d62(x7f77ea92be0d9042 xe9707cb1ec88db49, bool xd442ed3daa9011d5)
	{
		if (xd442ed3daa9011d5)
		{
			x7f77ea92be0d9042 x7f77ea92be0d = (x7f77ea92be0d9042)xe9707cb1ec88db49.x8b61531c8ea35b85();
			x7f77ea92be0d.xcb395027497bc067();
			return x7f77ea92be0d;
		}
		return xe9707cb1ec88db49;
	}

	private static void x20377da646339fb1(ArrayList xcc293b206a5085f0, xedb0eb766e25e0c9 xca5c4a8c4595ee86, Row xa806b754814b9ae0, bool x8251c6c98b26412e)
	{
		int num = (int)xca5c4a8c4595ee86.xfe91eeeafcb3026a(5104);
		int num2 = 0;
		for (int i = 0; i < num; i++)
		{
			num2 += (int)xcc293b206a5085f0[i];
		}
		xedb0eb766e25e0c9 xedb0eb766e25e0c = ((xa806b754814b9ae0.xedb0eb766e25e0c9.x0f53f53f15b61ef5 && x8251c6c98b26412e) ? ((xedb0eb766e25e0c9)xa806b754814b9ae0.xedb0eb766e25e0c9.x5fb16e270c21db2e.xdf4bcc85da8f85b2) : xa806b754814b9ae0.xedb0eb766e25e0c9);
		xedb0eb766e25e0c.xae20093bed1e48a8(4250, num2);
	}

	private static void xd640b83574a2dc1b(Table x1ec770899c98a268)
	{
		ArrayList arrayList = new ArrayList();
		x1ec770899c98a268.xedb0eb766e25e0c9.xae20093bed1e48a8(5103, arrayList);
		foreach (Cell cell in x1ec770899c98a268.FirstRow.Cells)
		{
			cell.xf8cef531dae89ea3.xdca73a32969a2272();
			arrayList.Add(cell.xf8cef531dae89ea3.xdc1bf80853046136);
		}
	}

	private static void x1e9ea5c68f15c1b5(x3c85359e1389ad43 xd19f1b93a822ffb3, xedb0eb766e25e0c9 xe193ceb565ecaa0a)
	{
		while (xd19f1b93a822ffb3.x152cbadbfa8061b1("tblGridChange"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = xd19f1b93a822ffb3.xa66385d80d4d296f) != null && xa66385d80d4d296f == "tblGrid")
			{
				ArrayList xbcea506a33cf = (ArrayList)xe193ceb565ecaa0a.xf7866f89640a29a3(5103);
				if (xe193ceb565ecaa0a.x5fb16e270c21db2e == null)
				{
					xe193ceb565ecaa0a.x5fb16e270c21db2e = new x5fb16e270c21db2e(new xedb0eb766e25e0c9(), "", DateTime.MinValue);
				}
				xe193ceb565ecaa0a.x5fb16e270c21db2e.xdf4bcc85da8f85b2.xae20093bed1e48a8(5103, xbcea506a33cf);
				x0dd2d2739751e83b(xd19f1b93a822ffb3, xe193ceb565ecaa0a);
			}
			else
			{
				xd19f1b93a822ffb3.IgnoreElement();
			}
		}
	}

	private static ArrayList xbdab5b753509fff5(x7f77ea92be0d9042 xe193ceb565ecaa0a)
	{
		return (ArrayList)xe193ceb565ecaa0a.xf7866f89640a29a3(5103);
	}
}
