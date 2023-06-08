using System.Collections;
using Aspose.Words;
using Aspose.Words.Tables;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using xc76255e87e5986c6;

namespace x9db5f2e5af3d596e;

internal class x416e4f8cf09bfa33 : DocumentVisitor
{
	private Table x0f62a530ebbd1b7d;

	private x3dabda6865ed239d xd2714535f669c453;

	private xedb0eb766e25e0c9 x5cfd0db5f4629fa8;

	private xedb0eb766e25e0c9 xc1060b4ef26f6109;

	private xf8cef531dae89ea3 x002f6960fc1a5e01;

	private x1a78664fa10a3755 xe68a757ccd7e8555;

	private xeedad81aaed42a76 xc3f9d3002c942532;

	private Hashtable x07cb456fd10c5320;

	private int xadb37374b87237c6;

	private int x62f51b30eb3aba9f;

	private bool x1ec5abe245b2a37a;

	private bool x72e48fd4aee64464;

	private bool xf2886808d6693507;

	private bool x6ab00820cb9edb67;

	private bool x4645f32e4cda3ebe;

	private bool x47da585f8fbe3b94;

	private bool x20e9a01fb50fcf75;

	private bool x0548f697c9f3450e;

	private bool x7ad9a1b386898183;

	private bool x2a523a1b7b4d3ac4;

	private int xe55137f2e976e51a;

	private bool xcc2da71fbd40bea1;

	private bool x76c750ff7a498203;

	private bool x70ee12a09ffaa8b7;

	private bool xfcd5fe22add5854f;

	private int x7c648a0adec8ace8;

	private bool xc35070bf664d5971;

	private bool x9d8e1c6da8d2c7d0;

	private bool x080a4df928877465;

	private bool xe344b14fed4bf575;

	private readonly x3fe289a940a19980 x9d4c4b3c65e2c4b1 = new x3fe289a940a19980();

	private readonly x29528a1f47e15e06 x4189c5a5b15074c5 = new x29528a1f47e15e06();

	private readonly xc3994ab156e5a4d8 xd11ff8e6fb0e60b5 = new xc3994ab156e5a4d8();

	private readonly x8ef1b65a9a1dc584 x01a5fd9bd75a1ab7 = new x8ef1b65a9a1dc584();

	private readonly ArrayList xb53962b36be53403 = new ArrayList();

	internal bool x7bf5eff5886bf62d
	{
		get
		{
			if (xf2886808d6693507)
			{
				return xc35070bf664d5971;
			}
			return false;
		}
	}

	internal bool x90051ef41adb5c4e
	{
		get
		{
			if (x6ab00820cb9edb67)
			{
				return x9d8e1c6da8d2c7d0;
			}
			return false;
		}
	}

	internal bool x615f0f75c32fe5c6
	{
		get
		{
			if (x1ec5abe245b2a37a)
			{
				return xcc2da71fbd40bea1;
			}
			return false;
		}
	}

	internal bool xc38a36c90492fb4b
	{
		get
		{
			if (x72e48fd4aee64464)
			{
				return x76c750ff7a498203;
			}
			return false;
		}
	}

	internal bool xa21df877c07421b1
	{
		get
		{
			if (x4645f32e4cda3ebe && !x615f0f75c32fe5c6)
			{
				return !xc38a36c90492fb4b;
			}
			return false;
		}
	}

	internal bool xda759cf71bd19a46
	{
		get
		{
			if (x47da585f8fbe3b94 && !x7bf5eff5886bf62d)
			{
				return !x90051ef41adb5c4e;
			}
			return false;
		}
	}

	internal bool x38e9e51bd739d58c
	{
		get
		{
			if (x20e9a01fb50fcf75 && xf8ae08be4c79b9fd)
			{
				return x8572a52bc3947f29;
			}
			return false;
		}
	}

	internal bool xa5677c45667823b4
	{
		get
		{
			if (x0548f697c9f3450e && xf8ae08be4c79b9fd)
			{
				return x14cdcaa8751f776c;
			}
			return false;
		}
	}

	internal bool x100ce0150940c384
	{
		get
		{
			if (x7ad9a1b386898183 && x5fed4f8aefdd1554)
			{
				return x8572a52bc3947f29;
			}
			return false;
		}
	}

	internal bool x038a4f18df05be97
	{
		get
		{
			if (x2a523a1b7b4d3ac4 && x5fed4f8aefdd1554)
			{
				return x14cdcaa8751f776c;
			}
			return false;
		}
	}

	internal bool x8572a52bc3947f29 => xc35070bf664d5971;

	internal bool x14cdcaa8751f776c => x9d8e1c6da8d2c7d0;

	internal bool xf8ae08be4c79b9fd => xcc2da71fbd40bea1;

	internal bool x5fed4f8aefdd1554 => x76c750ff7a498203;

	internal bool x80c69d851e67ffef => x70ee12a09ffaa8b7;

	internal bool x7b8ac223ab90126f => xfcd5fe22add5854f;

	internal bool x6b72cdfa4d022bfb => x080a4df928877465;

	internal bool x368f3e249416e053 => xe344b14fed4bf575;

	internal int x158ff59a659cd9cf => xadb37374b87237c6;

	internal int xb959efa2095cdf90 => x62f51b30eb3aba9f;

	private int x417303cfd3e6006c
	{
		get
		{
			if (!x1ec5abe245b2a37a)
			{
				return xe55137f2e976e51a;
			}
			return xe55137f2e976e51a - 1;
		}
	}

	private int x72d3921e2f47371a
	{
		get
		{
			if (!xf2886808d6693507)
			{
				return x7c648a0adec8ace8;
			}
			return x7c648a0adec8ace8 - 1;
		}
	}

	internal x1b1ec609e70eb086 xf9d0412a4bc339b1
	{
		get
		{
			if (!x0d299f323d241756.x7e32f71c3f39b6bc(x417303cfd3e6006c / xadb37374b87237c6))
			{
				return x1b1ec609e70eb086.x1c2c1355ae6bd833;
			}
			return x1b1ec609e70eb086.x37435c29a5649292;
		}
	}

	internal x1b1ec609e70eb086 x54c776735d1f322d
	{
		get
		{
			if (!x0d299f323d241756.x7e32f71c3f39b6bc(x72d3921e2f47371a / x62f51b30eb3aba9f))
			{
				return x1b1ec609e70eb086.xa4e228fcd9490f45;
			}
			return x1b1ec609e70eb086.xbea9812efdcba147;
		}
	}

	internal x3dabda6865ed239d x3dabda6865ed239d => xd2714535f669c453;

	internal void xe0f695b229ca8b8a()
	{
		foreach (Node item in xb53962b36be53403)
		{
			switch (item.NodeType)
			{
			case NodeType.Row:
				((Row)item).xedb0eb766e25e0c9 = (xedb0eb766e25e0c9)((Row)item).xedb0eb766e25e0c9.x75eab24f5629a618;
				break;
			case NodeType.Cell:
				((Cell)item).xf8cef531dae89ea3 = (xf8cef531dae89ea3)((Cell)item).xf8cef531dae89ea3.x75eab24f5629a618;
				break;
			case NodeType.Paragraph:
				((Paragraph)item).x1a78664fa10a3755 = (x1a78664fa10a3755)((Paragraph)item).x1a78664fa10a3755.x75eab24f5629a618;
				((Paragraph)item).x344511c4e4ce09da = (xeedad81aaed42a76)((Paragraph)item).x344511c4e4ce09da.x75eab24f5629a618;
				break;
			case NodeType.Run:
				((Run)item).xeedad81aaed42a76 = (xeedad81aaed42a76)((Run)item).xeedad81aaed42a76.x75eab24f5629a618;
				break;
			}
		}
		xb53962b36be53403.Clear();
	}

	internal void x8810335244b90b9d(Table x1ec770899c98a268)
	{
		x0f62a530ebbd1b7d = x1ec770899c98a268;
		xd2714535f669c453 = x0f62a530ebbd1b7d.Document.x9bb3f6e28fa55f34();
		x1ec770899c98a268.Accept(this);
	}

	public override VisitorAction VisitTableStart(Table table)
	{
		if (table != x0f62a530ebbd1b7d)
		{
			return VisitorAction.SkipThisNode;
		}
		Row firstRow = table.FirstRow;
		if (firstRow == null)
		{
			return VisitorAction.SkipThisNode;
		}
		if (!(firstRow.Document.Styles.xf194004582627ed5(firstRow.xedb0eb766e25e0c9.x8301ab10c226b0c2, 11) is TableStyle tableStyle))
		{
			return VisitorAction.SkipThisNode;
		}
		x5cfd0db5f4629fa8 = tableStyle.x43aa3065eb22eea2();
		xc1060b4ef26f6109 = tableStyle.xaa572f7df92ef004();
		x002f6960fc1a5e01 = tableStyle.x0974156b728aa5fc();
		xe68a757ccd7e8555 = tableStyle.x2e12c5f9278ae233(xd9bc7f7e70d71e14.xe9e531d1a6725226);
		xc3f9d3002c942532 = tableStyle.x856218fd0771d379(xecac24b19ed3a2b7.xe9e531d1a6725226);
		x07cb456fd10c5320 = new Hashtable();
		foreach (xe12ab2f55355c7f0 item in tableStyle.x7205cb42c2f994a4)
		{
			x07cb456fd10c5320[item.x3146d638ec378671] = item;
		}
		xadb37374b87237c6 = x5cfd0db5f4629fa8.xe7fd45df80ad60af;
		x62f51b30eb3aba9f = x5cfd0db5f4629fa8.x06953b06b2d4248c;
		x24f114dc518ca62b(firstRow.xedb0eb766e25e0c9.x4be85718a3fc5cac);
		xe55137f2e976e51a = 0;
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitRowStart(Row row)
	{
		xcc2da71fbd40bea1 = row.IsFirstRow;
		x76c750ff7a498203 = row.IsLastRow;
		if (x4645f32e4cda3ebe)
		{
			x70ee12a09ffaa8b7 = x0f7b14705c79ae32(x417303cfd3e6006c, xadb37374b87237c6);
			xfcd5fe22add5854f = x8d0cd35fc6278047(x417303cfd3e6006c, xadb37374b87237c6);
		}
		x7c648a0adec8ace8 = 0;
		xc35070bf664d5971 = false;
		x9d8e1c6da8d2c7d0 = false;
		xedb0eb766e25e0c9 xedb0eb766e25e0c10 = new xedb0eb766e25e0c9();
		x5cfd0db5f4629fa8.xab3af626b1405ee8(xedb0eb766e25e0c10);
		xc1060b4ef26f6109.xab3af626b1405ee8(xedb0eb766e25e0c10);
		x9d4c4b3c65e2c4b1.x8810335244b90b9d(this, xedb0eb766e25e0c10);
		row.xedb0eb766e25e0c9.xab3af626b1405ee8(xedb0eb766e25e0c10);
		xedb0eb766e25e0c10.x75eab24f5629a618 = (xedb0eb766e25e0c9)row.xedb0eb766e25e0c9.x8b61531c8ea35b85();
		xb53962b36be53403.Add(row);
		row.xedb0eb766e25e0c9 = xedb0eb766e25e0c10;
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitRowEnd(Row row)
	{
		xe55137f2e976e51a++;
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitCellStart(Cell cell)
	{
		xc35070bf664d5971 = cell.IsFirstCell;
		x9d8e1c6da8d2c7d0 = cell.IsLastCell;
		if (x47da585f8fbe3b94)
		{
			x080a4df928877465 = x0f7b14705c79ae32(x72d3921e2f47371a, x62f51b30eb3aba9f);
			xe344b14fed4bf575 = x8d0cd35fc6278047(x72d3921e2f47371a, x62f51b30eb3aba9f);
		}
		xf8cef531dae89ea3 xf8cef531dae89ea4 = new xf8cef531dae89ea3();
		x002f6960fc1a5e01.xab3af626b1405ee8(xf8cef531dae89ea4);
		x4189c5a5b15074c5.x8810335244b90b9d(this, xf8cef531dae89ea4);
		cell.xf8cef531dae89ea3.xab3af626b1405ee8(xf8cef531dae89ea4);
		xf8cef531dae89ea4.x75eab24f5629a618 = (xf8cef531dae89ea3)cell.xf8cef531dae89ea3.x8b61531c8ea35b85();
		xb53962b36be53403.Add(cell);
		cell.xf8cef531dae89ea3 = xf8cef531dae89ea4;
		x7c648a0adec8ace8++;
		return VisitorAction.Continue;
	}

	private static bool x0f7b14705c79ae32(int xc0c4c459c6ccbd00, int x2e03c4070b030735)
	{
		int num = xc0c4c459c6ccbd00 / x2e03c4070b030735;
		return num * x2e03c4070b030735 == xc0c4c459c6ccbd00;
	}

	private static bool x8d0cd35fc6278047(int xc0c4c459c6ccbd00, int x2e03c4070b030735)
	{
		int num = xc0c4c459c6ccbd00 / x2e03c4070b030735;
		return num * x2e03c4070b030735 + x2e03c4070b030735 - 1 == xc0c4c459c6ccbd00;
	}

	public override VisitorAction VisitParagraphStart(Paragraph para)
	{
		if (para.xdfa6ecc6f742f086.NodeType != NodeType.Cell)
		{
			return VisitorAction.SkipThisNode;
		}
		x7dbbdff0e18dae2c(para);
		x3c24953856276101(para);
		return VisitorAction.Continue;
	}

	private void x7dbbdff0e18dae2c(Paragraph x41baca1d6c0c2e8e)
	{
		x1a78664fa10a3755 x1a78664fa10a = new x1a78664fa10a3755();
		xe68a757ccd7e8555.xab3af626b1405ee8(x1a78664fa10a);
		xd11ff8e6fb0e60b5.x8810335244b90b9d(this, x1a78664fa10a);
		x41baca1d6c0c2e8e.x1a78664fa10a3755.x75eab24f5629a618 = (x1a78664fa10a3755)x41baca1d6c0c2e8e.x1a78664fa10a3755.x8b61531c8ea35b85();
		xb53962b36be53403.Add(x41baca1d6c0c2e8e);
		x41baca1d6c0c2e8e.x7dbbdff0e18dae2c(x1a78664fa10a, xd9bc7f7e70d71e14.xe9e531d1a6725226);
		x41baca1d6c0c2e8e.x1a78664fa10a3755 = x1a78664fa10a;
	}

	private void x3c24953856276101(Paragraph x41baca1d6c0c2e8e)
	{
		xeedad81aaed42a76 xeedad81aaed42a = new xeedad81aaed42a76();
		xc3f9d3002c942532.xab3af626b1405ee8(xeedad81aaed42a, xd2714535f669c453);
		x01a5fd9bd75a1ab7.x8810335244b90b9d(this, xeedad81aaed42a);
		x41baca1d6c0c2e8e.x344511c4e4ce09da.x75eab24f5629a618 = (xeedad81aaed42a76)x41baca1d6c0c2e8e.x344511c4e4ce09da.x8b61531c8ea35b85();
		x41baca1d6c0c2e8e.x3c24953856276101(xeedad81aaed42a, xecac24b19ed3a2b7.x87415330d9d0754a | xecac24b19ed3a2b7.xe65081df606950cc);
		x41baca1d6c0c2e8e.x344511c4e4ce09da = xeedad81aaed42a;
	}

	private void x5f851b1938defe5f(Run xb0e5d73738e62f9e)
	{
		xeedad81aaed42a76 xeedad81aaed42a = new xeedad81aaed42a76();
		xc3f9d3002c942532.xab3af626b1405ee8(xeedad81aaed42a, xd2714535f669c453);
		x01a5fd9bd75a1ab7.x8810335244b90b9d(this, xeedad81aaed42a);
		xb0e5d73738e62f9e.xeedad81aaed42a76.x75eab24f5629a618 = (xeedad81aaed42a76)xb0e5d73738e62f9e.xeedad81aaed42a76.x8b61531c8ea35b85();
		xb53962b36be53403.Add(xb0e5d73738e62f9e);
		xecac24b19ed3a2b7 xecac24b19ed3a2b = xecac24b19ed3a2b7.xe65081df606950cc;
		if (!xb0e5d73738e62f9e.xadc83cc585a89881)
		{
			xecac24b19ed3a2b |= xecac24b19ed3a2b7.x87415330d9d0754a;
		}
		xb0e5d73738e62f9e.x5f851b1938defe5f(xeedad81aaed42a, xecac24b19ed3a2b);
		xb0e5d73738e62f9e.xeedad81aaed42a76 = xeedad81aaed42a;
	}

	private void x24f114dc518ca62b(TableStyleOptions xdfde339da46db651)
	{
		x1ec5abe245b2a37a = (xdfde339da46db651 & TableStyleOptions.FirstRow) != 0;
		x72e48fd4aee64464 = (xdfde339da46db651 & TableStyleOptions.LastRow) != 0;
		xf2886808d6693507 = (xdfde339da46db651 & TableStyleOptions.FirstColumn) != 0;
		x6ab00820cb9edb67 = (xdfde339da46db651 & TableStyleOptions.LastColumn) != 0;
		x4645f32e4cda3ebe = (xdfde339da46db651 & TableStyleOptions.RowBands) != 0 && xadb37374b87237c6 > 0;
		x47da585f8fbe3b94 = (xdfde339da46db651 & TableStyleOptions.ColumnBands) != 0 && x62f51b30eb3aba9f > 0;
		x20e9a01fb50fcf75 = x1ec5abe245b2a37a && xf2886808d6693507;
		x0548f697c9f3450e = x1ec5abe245b2a37a && x6ab00820cb9edb67;
		x7ad9a1b386898183 = x72e48fd4aee64464 && xf2886808d6693507;
		x2a523a1b7b4d3ac4 = x72e48fd4aee64464 && x6ab00820cb9edb67;
		x1ec5abe245b2a37a &= x67983e0dd0a90e0a(x1b1ec609e70eb086.x5d6d04c35215bc51) != null;
		x72e48fd4aee64464 &= x67983e0dd0a90e0a(x1b1ec609e70eb086.xbc3a1ad7f75a88f9) != null;
		xf2886808d6693507 &= x67983e0dd0a90e0a(x1b1ec609e70eb086.xb8e3e9a641be95c5) != null;
		x6ab00820cb9edb67 &= x67983e0dd0a90e0a(x1b1ec609e70eb086.xf59d22dcfa267bc1) != null;
	}

	public override VisitorAction VisitRun(Run run)
	{
		x5f851b1938defe5f(run);
		return VisitorAction.Continue;
	}

	internal xe12ab2f55355c7f0 x67983e0dd0a90e0a(x1b1ec609e70eb086 x43163d22e8cd5a71)
	{
		return (xe12ab2f55355c7f0)x07cb456fd10c5320[x43163d22e8cd5a71];
	}
}
