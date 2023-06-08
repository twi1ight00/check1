using System;
using Aspose.Words;
using Aspose.Words.Tables;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using x9db5f2e5af3d596e;
using xde385359626e77eb;

namespace x13cd31bb39e0b7ea;

internal class xb3eb29598c62ff6d
{
	private const int x1799fd4f718af272 = 63;

	private readonly bool xd48a1067279c361c;

	private readonly bool xf09f1ed7278871ec;

	private static readonly int x6bc4d60359aed480 = x4574ea26106f0edb.x88bf16f2386d633e(ConvertUtil.MillimeterToPoint(1.0));

	private readonly IWarningCallback xa056586c1f99e199;

	internal xb3eb29598c62ff6d(xaa6aac6156ffea29 saveActions, IWarningCallback warningCallback)
	{
		xd48a1067279c361c = (saveActions & xaa6aac6156ffea29.xdd7eca4a70bd2700) != 0;
		xf09f1ed7278871ec = (saveActions & xaa6aac6156ffea29.x0bdddc147ee0a81f) != 0;
		xa056586c1f99e199 = warningCallback;
	}

	internal VisitorAction xe35e18fbd2d5ad9e(Table x1ec770899c98a268)
	{
		if (x1ec770899c98a268.x73db39780c76cb8d)
		{
			x66f2271ac271c2df x66f2271ac271c2df = new x66f2271ac271c2df(x1ec770899c98a268);
			if (x66f2271ac271c2df.x7eab159619d586e1.Length == 0)
			{
				x1ec770899c98a268.xae19a615b411c9fa();
			}
		}
		if (xd48a1067279c361c)
		{
			x1ec770899c98a268.xdd7eca4a70bd2700();
		}
		x1ec770899c98a268.x148387b100b7e1c7();
		xc6c62007306636d9(x1ec770899c98a268);
		return VisitorAction.Continue;
	}

	internal VisitorAction xf7a3d740c38d9959(Row xa806b754814b9ae0)
	{
		if (xa806b754814b9ae0.Cells.Count >= 63)
		{
			x98b0e09ccece0a5a.x3dc950453374051a(xa056586c1f99e199, "Cell count per row must not exceed 63, document can have problem while opened in MS Word.");
		}
		return VisitorAction.Continue;
	}

	internal VisitorAction x49cd8bac108971e1(Table x1ec770899c98a268)
	{
		if (!x1ec770899c98a268.x73db39780c76cb8d)
		{
			xbbf9a1ead81dd3a1(WarningType.MinorFormattingLoss, "Empty table was removed.");
			x1ec770899c98a268.Remove();
		}
		return VisitorAction.Continue;
	}

	internal VisitorAction x73486983017b4ba2(Row xa806b754814b9ae0)
	{
		if (!xa806b754814b9ae0.x73db39780c76cb8d)
		{
			xbbf9a1ead81dd3a1(WarningType.MinorFormattingLoss, "Empty table row was removed.");
			xa806b754814b9ae0.Remove();
			return VisitorAction.Continue;
		}
		Cell firstCell = xa806b754814b9ae0.FirstCell;
		if (firstCell.xf8cef531dae89ea3.x338a5e6ab7c5595e == CellMerge.Previous)
		{
			firstCell.xf8cef531dae89ea3.x338a5e6ab7c5595e = CellMerge.First;
		}
		Cell lastCell = xa806b754814b9ae0.LastCell;
		if (lastCell.xf8cef531dae89ea3.x338a5e6ab7c5595e == CellMerge.First)
		{
			lastCell.xf8cef531dae89ea3.x338a5e6ab7c5595e = CellMerge.None;
		}
		x038093255c9df229(xa806b754814b9ae0);
		xa806b754814b9ae0.x47ab0b351d6caf1e();
		return VisitorAction.Continue;
	}

	private static void x038093255c9df229(Row xa806b754814b9ae0)
	{
		bool flag = true;
		bool flag2 = true;
		foreach (Cell cell in xa806b754814b9ae0.Cells)
		{
			flag &= cell.LastParagraph.x344511c4e4ce09da.xba4e1d8a3e3316c8;
			flag2 &= cell.LastParagraph.x344511c4e4ce09da.x0392c0938d22c790;
		}
		if (flag && !xa806b754814b9ae0.xedb0eb766e25e0c9.xba4e1d8a3e3316c8)
		{
			xa806b754814b9ae0.xedb0eb766e25e0c9.x18bb4aa7903ffced = new xc1b2bac943a0f541(x91bb72ac77aa7230.xf059562f878b500e, xa806b754814b9ae0.FirstCell.LastParagraph.x344511c4e4ce09da.x18bb4aa7903ffced.xb063bbfcfeade526, xa806b754814b9ae0.FirstCell.LastParagraph.x344511c4e4ce09da.x18bb4aa7903ffced.x242851e6278ed355);
		}
		if (flag2 && !xa806b754814b9ae0.xedb0eb766e25e0c9.x0392c0938d22c790)
		{
			xa806b754814b9ae0.xedb0eb766e25e0c9.x83da691dd3d974a6 = new xc1b2bac943a0f541(x91bb72ac77aa7230.x1f522a512716a2ae, xa806b754814b9ae0.FirstCell.LastParagraph.x344511c4e4ce09da.x83da691dd3d974a6.xb063bbfcfeade526, xa806b754814b9ae0.FirstCell.LastParagraph.x344511c4e4ce09da.x83da691dd3d974a6.x242851e6278ed355);
		}
	}

	internal VisitorAction x37f46648998425f0(Cell xe6de5e5fa2d44af5)
	{
		if (xf09f1ed7278871ec && !xe6de5e5fa2d44af5.xf8cef531dae89ea3.x263d579af1d0d43f(3020))
		{
			xe6de5e5fa2d44af5.xf8cef531dae89ea3.xce5b83b714f11fba = PreferredWidth.Auto;
		}
		xe6de5e5fa2d44af5.EnsureMinimum();
		if (xe6de5e5fa2d44af5.xf8cef531dae89ea3.xdca73a32969a2272())
		{
			xbbf9a1ead81dd3a1(WarningType.MinorFormattingLoss, "Invalid cell width, table layout updated.");
			xe6de5e5fa2d44af5.x133f2db9e5b5690d.xae19a615b411c9fa();
			xc6c62007306636d9(xe6de5e5fa2d44af5.x133f2db9e5b5690d);
		}
		return VisitorAction.Continue;
	}

	private static bool x0cfca4aa5137cb2d(Table x1ec770899c98a268)
	{
		if (x1ec770899c98a268.Rows.Count == 0)
		{
			return false;
		}
		if (x1ec770899c98a268.x6f6877b222ed4153)
		{
			return false;
		}
		if (x1ec770899c98a268.x752cfab9af626fd5)
		{
			if (!x1ec770899c98a268.PreferredWidth.x368bd9f7b8c336b4)
			{
				return x1ec770899c98a268.PreferredWidth.xa72bf798a679c0aa;
			}
			return true;
		}
		if (x1ec770899c98a268.AllowAutoFit)
		{
			return !x1ec770899c98a268.Document.xdade2366eaa6f915.xe322902ca0e695f5.GrowAutofit;
		}
		return x1ec770899c98a268.PreferredWidth.x368bd9f7b8c336b4;
	}

	private void xc6c62007306636d9(Table x1ec770899c98a268)
	{
		if (!x0cfca4aa5137cb2d(x1ec770899c98a268))
		{
			return;
		}
		int num = x1ec770899c98a268.xabc668f72c127bc3();
		int num2 = x83856b7a59ceccb0.xc15171e87e96e678(x1ec770899c98a268);
		if ((x1ec770899c98a268.PreferredWidth.x08428aa3999da322 && x1ec770899c98a268.PreferredWidth.xdf4645c89f0e47f6 >= num2) || num <= num2 + x6bc4d60359aed480)
		{
			return;
		}
		double num3 = (double)num2 / (double)num;
		if (!(num3 < 1.0) || x1ec770899c98a268.x132be151ef3fb907)
		{
			return;
		}
		xbbf9a1ead81dd3a1(WarningType.MinorFormattingLoss, "Table width exceed maximum allowed, table was resized.");
		foreach (Row row in x1ec770899c98a268.Rows)
		{
			foreach (Cell cell in row.Cells)
			{
				cell.xf8cef531dae89ea3.xdc1bf80853046136 = (int)Math.Round(num3 * (double)cell.xf8cef531dae89ea3.xdc1bf80853046136);
			}
		}
	}

	internal void xbbf9a1ead81dd3a1(WarningType x9f91de645a9fe01a, string xc2358fbac7da3d45)
	{
		if (xa056586c1f99e199 != null)
		{
			xa056586c1f99e199.Warning(new WarningInfo(x9f91de645a9fe01a, WarningSource.Validator, xc2358fbac7da3d45));
		}
	}
}
