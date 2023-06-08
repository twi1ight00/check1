using System.Collections;
using System.IO;
using System.Text;
using Aspose.Words;
using Aspose.Words.Fields;
using Aspose.Words.Lists;
using Aspose.Words.Saving;
using Aspose.Words.Tables;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using xd2754ae26d400653;

namespace x722d80085b19d13f;

internal class xc045be5d79e471b9 : DocumentVisitor, x3d2908992e1d1667
{
	private DocumentBase xd1424e1a0bb4a72b;

	private TxtSaveOptions x1cb867f3d40f3203;

	private StringBuilder x800085dd555f7711;

	private readonly Stack x57f3e981e335642d = new Stack();

	private Stack xf44f3902f13b17a9;

	private static readonly char[] xc81ae9c624778be2 = new char[9] { '*', '>', '+', '-', 'o', '>', '+', '-', 'o' };

	private bool xecdf9a85423a24cd => x57f3e981e335642d.Count > 0;

	private x01f345749770e63a x8e63dd35709cb9ab
	{
		get
		{
			if (x57f3e981e335642d.Count <= 0)
			{
				return null;
			}
			return (x01f345749770e63a)x57f3e981e335642d.Peek();
		}
	}

	private SaveOutputParameters x8cac5adfe79bc025(x8556eed81191af11 x5ac1382edb7bf2c2)
	{
		xd586e0c16bdae7fc(x5ac1382edb7bf2c2.x2c8c6741422a1298, (TxtSaveOptions)x5ac1382edb7bf2c2.xf57de0fd37d5e97d);
		for (Node node = xd1424e1a0bb4a72b.FirstChild; node != null; node = node.NextSibling)
		{
			x51ee56decc29a9da((Section)node);
		}
		StreamWriter streamWriter = new StreamWriter(x5ac1382edb7bf2c2.xb8a774e0111d0fbe, x1cb867f3d40f3203.Encoding);
		streamWriter.Write(x800085dd555f7711.ToString());
		streamWriter.Flush();
		return new SaveOutputParameters("text/plain");
	}

	SaveOutputParameters x3d2908992e1d1667.xa2e0b7f7da663553(x8556eed81191af11 x5ac1382edb7bf2c2)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x8cac5adfe79bc025
		return this.x8cac5adfe79bc025(x5ac1382edb7bf2c2);
	}

	internal string xa45b9f6fb2389318(Node xda5bf54deb817e37, TxtSaveOptions xc27f01f21f67608c)
	{
		xd586e0c16bdae7fc(xda5bf54deb817e37.Document, xc27f01f21f67608c);
		xda5bf54deb817e37.Accept(this);
		return x800085dd555f7711.ToString();
	}

	private void x51ee56decc29a9da(Section xb32f8dd719a105db)
	{
		if (x1cb867f3d40f3203.ExportHeadersFooters)
		{
			x6075c9125351e131(xb32f8dd719a105db, HeaderFooterType.HeaderPrimary);
		}
		if (xb32f8dd719a105db.Body != null)
		{
			xf5a995748d89aa41(xb32f8dd719a105db.Body);
		}
		if (x1cb867f3d40f3203.ExportHeadersFooters)
		{
			x6075c9125351e131(xb32f8dd719a105db, HeaderFooterType.FooterPrimary);
		}
	}

	private void x6075c9125351e131(Section xb32f8dd719a105db, HeaderFooterType xa685fef1a31f5d4d)
	{
		HeaderFooter headerFooter = xb32f8dd719a105db.HeadersFooters[xa685fef1a31f5d4d];
		if (headerFooter != null)
		{
			xf5a995748d89aa41(headerFooter);
		}
	}

	private void xf5a995748d89aa41(Story x93d8434f027afd5a)
	{
		x93d8434f027afd5a.Accept(this);
	}

	private void xd586e0c16bdae7fc(DocumentBase x6beba47238e0ade6, TxtSaveOptions xc27f01f21f67608c)
	{
		xd1424e1a0bb4a72b = x6beba47238e0ade6;
		x1cb867f3d40f3203 = xc27f01f21f67608c;
		x800085dd555f7711 = new StringBuilder();
		if (xd1424e1a0bb4a72b is Document)
		{
			xf44f3902f13b17a9 = new Stack();
			xf44f3902f13b17a9.Push(null);
		}
	}

	public override VisitorAction VisitParagraphStart(Paragraph paragraph)
	{
		xf44f3902f13b17a9.Push(paragraph.xbc0119d7471ef12e ? paragraph.ListLabel : null);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitRun(Run run)
	{
		if (!base.x991897f13cf6aadc)
		{
			ListLabel listLabel = (ListLabel)xf44f3902f13b17a9.Peek();
			if (listLabel != null)
			{
				int i;
				for (i = 0; i < run.Text.Length; i++)
				{
					char c = run.Text[i];
					if (c != '\f' && c != '\u000e')
					{
						break;
					}
				}
				if (i > 0)
				{
					xe4fd28685b34ecc7(run.Text.Substring(0, i));
				}
				if (i < run.Text.Length)
				{
					xe4fd28685b34ecc7(xff2bb2b3436f4d08(listLabel));
					xe4fd28685b34ecc7(" ");
					xe4fd28685b34ecc7(run.Text.Substring(i));
					xf44f3902f13b17a9.Pop();
					xf44f3902f13b17a9.Push(null);
				}
			}
			else
			{
				xe4fd28685b34ecc7(run.Text);
			}
		}
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitFieldStart(FieldStart fieldStart)
	{
		x75be698bf0c3a5c5();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitFieldSeparator(FieldSeparator fieldSeparator)
	{
		x45277e5380a187db();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitFieldEnd(FieldEnd fieldEnd)
	{
		if (!fieldEnd.HasSeparator)
		{
			x45277e5380a187db();
		}
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitParagraphEnd(Paragraph paragraph)
	{
		if (!base.x991897f13cf6aadc)
		{
			ListLabel listLabel = (ListLabel)xf44f3902f13b17a9.Peek();
			if (listLabel != null)
			{
				xe4fd28685b34ecc7(xff2bb2b3436f4d08(listLabel));
			}
			xe4fd28685b34ecc7(x1cb867f3d40f3203.ParagraphBreak);
		}
		xf44f3902f13b17a9.Pop();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitTableStart(Table table)
	{
		x57f3e981e335642d.Push(new x01f345749770e63a(table, x8e63dd35709cb9ab, x1cb867f3d40f3203));
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitTableEnd(Table table)
	{
		if (x1cb867f3d40f3203.PreserveTableLayout && x57f3e981e335642d.Count == 1)
		{
			for (int i = 0; i < x8e63dd35709cb9ab.x734991a6e63a780b.xd44988f225497f3a; i++)
			{
				StringBuilder stringBuilder = x8e63dd35709cb9ab.x734991a6e63a780b.get_xe6d4b1b411ed94b5(i);
				x429e448e009d5091(stringBuilder.ToString());
				x429e448e009d5091(x1cb867f3d40f3203.ParagraphBreak);
			}
		}
		x57f3e981e335642d.Pop();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitRowStart(Row row)
	{
		if (x1cb867f3d40f3203.PreserveTableLayout)
		{
			x8e63dd35709cb9ab.x5e3f44647fcfb8fc(row);
		}
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitRowEnd(Row row)
	{
		if (x1cb867f3d40f3203.PreserveTableLayout)
		{
			x8e63dd35709cb9ab.xbdbbc98113b6b783();
		}
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitCellStart(Cell cell)
	{
		if (x1cb867f3d40f3203.PreserveTableLayout)
		{
			if (!x8e63dd35709cb9ab.xcbc713eb2e22657d(cell))
			{
				return VisitorAction.SkipThisNode;
			}
		}
		else if (cell.xf8cef531dae89ea3.x61127d98597c4898)
		{
			return VisitorAction.SkipThisNode;
		}
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitCellEnd(Cell cell)
	{
		if (x1cb867f3d40f3203.PreserveTableLayout)
		{
			x8e63dd35709cb9ab.x2a78a52ede7f4385();
		}
		return VisitorAction.Continue;
	}

	private void xe4fd28685b34ecc7(string xb41faee6912a2313)
	{
		if (x1cb867f3d40f3203.PreserveTableLayout && xecdf9a85423a24cd)
		{
			x8e63dd35709cb9ab.xe4fd28685b34ecc7(xb41faee6912a2313);
		}
		else
		{
			x429e448e009d5091(xb41faee6912a2313);
		}
	}

	private void x429e448e009d5091(string xb41faee6912a2313)
	{
		for (int i = 0; i < xb41faee6912a2313.Length; i++)
		{
			x800085dd555f7711.Append(x09d499c483428bd1.xa8b9c2cfa706a303(xb41faee6912a2313[i]));
		}
	}

	private string xff2bb2b3436f4d08(ListLabel x05e9825a1c0bb0a2)
	{
		if (!x1cb867f3d40f3203.SimplifyListLabels)
		{
			return x05e9825a1c0bb0a2.LabelString;
		}
		return xb9f94fcaf5375b41(x05e9825a1c0bb0a2.x4ededf5feccc72f8);
	}

	private static string xb9f94fcaf5375b41(xd269993cc48a63d2 x01b557925841ae51)
	{
		StringBuilder stringBuilder = new StringBuilder();
		ListLevel listLevel = x01b557925841ae51.x1b66e22d28c087af();
		if (listLevel.NumberStyle == NumberStyle.Bullet)
		{
			for (int i = 0; i < listLevel.x008c23e8f687bbd3; i++)
			{
				stringBuilder.Append("  ");
			}
			stringBuilder.Append(xc81ae9c624778be2[listLevel.x008c23e8f687bbd3]);
		}
		else
		{
			for (int j = 0; j <= listLevel.x008c23e8f687bbd3; j++)
			{
				stringBuilder.Append(x01b557925841ae51.x043aafba68f5c559(j));
				stringBuilder.Append('.');
			}
		}
		return stringBuilder.ToString();
	}
}
