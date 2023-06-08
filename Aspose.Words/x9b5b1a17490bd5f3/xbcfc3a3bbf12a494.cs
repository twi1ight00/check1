using Aspose.Words;
using Aspose.Words.Tables;
using x2697283ff424107e;
using x28925c9b27b37a46;
using x5794c252ba25e723;
using x643046e3f004c49f;
using x7c4557e104065fc9;
using x9db5f2e5af3d596e;

namespace x9b5b1a17490bd5f3;

internal class xbcfc3a3bbf12a494
{
	private readonly DocumentBuilder x800085dd555f7711;

	private string xb955fb6892b2a68f;

	private readonly xc118baa3bc102199 x0692e6d68a6b7f4b;

	private xb29ea580557e1fd7 xc90fcebf565aca41;

	private x4e51edddc028898f xb697767b913c1ad5;

	internal xbcfc3a3bbf12a494(DocumentBuilder builder, string alignment, xc118baa3bc102199 nodeProcessor)
	{
		x800085dd555f7711 = builder;
		xb955fb6892b2a68f = alignment;
		x0692e6d68a6b7f4b = nodeProcessor;
	}

	internal void x5b7cc3ed4565d299(x9d6b37cac59aa2e2 xda5bf54deb817e37, bool x4e90add18a439932)
	{
		xc90fcebf565aca41 = new xb29ea580557e1fd7(xda5bf54deb817e37, xb955fb6892b2a68f);
		x0692e6d68a6b7f4b.xa52974e202c7f831(xda5bf54deb817e37.x75658b3f8be4005c("dir", ""));
		if (xc90fcebf565aca41.Count == 0 || xc90fcebf565aca41.x5840ec53f70adb17 == 0)
		{
			return;
		}
		Table table = x800085dd555f7711.StartTable();
		x800085dd555f7711.ParagraphFormat.ClearFormatting();
		for (int i = 0; i < xc90fcebf565aca41.Count; i++)
		{
			x2e5bc8a8aa47e75f(xc90fcebf565aca41.get_xe6d4b1b411ed94b5(i));
		}
		x800085dd555f7711.EndTable();
		table.Bidi = x0692e6d68a6b7f4b.x711cb9f101fe04ce();
		table.Alignment = xc90fcebf565aca41.x78a8158ce97f2a67;
		if (xc90fcebf565aca41.xc6a8342933c4e987 != null)
		{
			table.PreferredWidth = xc90fcebf565aca41.xc6a8342933c4e987;
		}
		table.AllowAutoFit = true;
		double bottomPadding = (table.TopPadding = (table.RightPadding = (table.LeftPadding = ConvertUtil.PixelToPoint(xc90fcebf565aca41.xe644ac50cf36ac78))));
		table.BottomPadding = bottomPadding;
		double num4 = ConvertUtil.PixelToPoint(xc90fcebf565aca41.xd2905906dc0619f2 / 2.0);
		if (num4 != 0.0)
		{
			table.CellSpacing = num4;
		}
		xbb04898cf6b5ed4f.xd630de9b41e9eba0(xc5f6f2ca0aafd220.x664c130a09af677a(xda5bf54deb817e37), table);
		if (x67b4ee081215c4f4(table))
		{
			for (x9d6b37cac59aa2e2 x9d6b37cac59aa2e = xda5bf54deb817e37.xe98eb74983649df0; x9d6b37cac59aa2e != null; x9d6b37cac59aa2e = x9d6b37cac59aa2e.xdf54af9a52918039)
			{
				if (x9d6b37cac59aa2e.x1b809103b90e9c4f == x8be2136363630db4.x2dcc7207ee287dbb)
				{
					if (x9d6b37cac59aa2e.x759aa16c2016a289 == "caption")
					{
						x2997db7b9813d46e(table, xc90fcebf565aca41.x5840ec53f70adb17, x9d6b37cac59aa2e);
					}
					break;
				}
			}
			if (x4e90add18a439932)
			{
				table.xae19a615b411c9fa();
			}
		}
		x0692e6d68a6b7f4b.x56eaaac1a29f6398();
	}

	private static bool x67b4ee081215c4f4(Table x1ec770899c98a268)
	{
		Row lastRow = x1ec770899c98a268.LastRow;
		RowFormat rowFormat = lastRow.RowFormat;
		if (rowFormat.HeightRule != HeightRule.Auto && rowFormat.Height == 0.0)
		{
			if (x1ec770899c98a268.Rows.Count <= 1)
			{
				x1ec770899c98a268.Remove();
				return false;
			}
			lastRow.Remove();
		}
		return true;
	}

	private static void x2997db7b9813d46e(Table x1ec770899c98a268, int x5ddd6074bcb3c34a, x9d6b37cac59aa2e2 x1c2743f354837549)
	{
		DocumentBase document = x1ec770899c98a268.Document;
		string xfdc36fc0993ac5e = x1c2743f354837549.xfdc36fc0993ac5e4;
		string text = x1c2743f354837549.x75658b3f8be4005c("align", string.Empty).ToLower();
		string text2 = xc5f6f2ca0aafd220.x664c130a09af677a(x1c2743f354837549);
		Row row = new Row(document, new xedb0eb766e25e0c9());
		if (text == "bottom")
		{
			x1ec770899c98a268.xdf7453d9fdf3f262(row);
		}
		else
		{
			x1ec770899c98a268.PrependChild(row);
		}
		Cell cell = new Cell(document);
		row.xdf7453d9fdf3f262(cell);
		if (x5ddd6074bcb3c34a > 1)
		{
			cell.xf8cef531dae89ea3.x338a5e6ab7c5595e = CellMerge.First;
			int num = x5ddd6074bcb3c34a;
			while (--num > 0)
			{
				Cell cell2 = new Cell(document);
				cell2.xf8cef531dae89ea3.x338a5e6ab7c5595e = CellMerge.Previous;
				row.xdf7453d9fdf3f262(cell2);
			}
		}
		Paragraph paragraph = new Paragraph(document);
		cell.xdf7453d9fdf3f262(paragraph);
		Run run = new Run(document);
		paragraph.xdf7453d9fdf3f262(run);
		run.Text = xfdc36fc0993ac5e;
		switch (text)
		{
		case "right":
			paragraph.ParagraphFormat.Alignment = ParagraphAlignment.Right;
			break;
		default:
			paragraph.ParagraphFormat.Alignment = ParagraphAlignment.Center;
			break;
		case "left":
			break;
		}
		if (text2.Length != 0)
		{
			xa3fc7dcdc8182ff6 x44ecfea61c937b8e = new xa3fc7dcdc8182ff6(text2);
			x4edf5a654b83812d.xe7ce6487f5f217d1(x44ecfea61c937b8e, paragraph.ParagraphFormat);
			x69e8b423c22edb61.xff280c75a0537411(x44ecfea61c937b8e, run.Font, x032ab0a06188d97e: true);
		}
	}

	private void x2e5bc8a8aa47e75f(x4e51edddc028898f xa806b754814b9ae0)
	{
		xb697767b913c1ad5 = xa806b754814b9ae0;
		x0692e6d68a6b7f4b.xa52974e202c7f831(xa806b754814b9ae0.x40212106aad8a8b0.x75658b3f8be4005c("dir", ""));
		for (int i = 0; i < xa806b754814b9ae0.Count; i++)
		{
			xb8fe14fc671949f3(xa806b754814b9ae0.get_xe6d4b1b411ed94b5(i));
		}
		x0692e6d68a6b7f4b.x56eaaac1a29f6398();
		RowFormat rowFormat = x800085dd555f7711.RowFormat;
		((x8f424b921df6c21a)x800085dd555f7711).x90c1c4b3135f8e2d();
		if (xc90fcebf565aca41.xeae235558dc44397 > 0.0)
		{
			BorderCollection borders = rowFormat.Borders;
			double x9b0739496f8b = ConvertUtil.PixelToPoint(xc90fcebf565aca41.xeae235558dc44397);
			x7d0d24118b3cc46b(borders[BorderType.Left], x9b0739496f8b);
			x7d0d24118b3cc46b(borders[BorderType.Top], x9b0739496f8b);
			x7d0d24118b3cc46b(borders[BorderType.Bottom], x9b0739496f8b);
			x7d0d24118b3cc46b(borders[BorderType.Right], x9b0739496f8b);
		}
		PreferredWidth preferredWidth = x495fdb45f3d92b70.x844d4319ee50b6d6(xa806b754814b9ae0.x40212106aad8a8b0.x75658b3f8be4005c("height", ""));
		if (preferredWidth != null && preferredWidth.x08428aa3999da322)
		{
			rowFormat.Height = preferredWidth.Value;
			rowFormat.HeightRule = HeightRule.AtLeast;
		}
		Row x838c6c67b5953bb = x800085dd555f7711.CurrentParagraph.x838c6c67b5953bb0;
		x26d9ecb4bdf0456d x6c50a99faab7d = x26d9ecb4bdf0456d.x45260ad4b94166f2;
		if (x495fdb45f3d92b70.x722b70a5a6410b8c(xc90fcebf565aca41.x40212106aad8a8b0, "bgcolor", ref x6c50a99faab7d))
		{
			Shading shading = new Shading();
			shading.x0e18178ac4b2272f = x6c50a99faab7d;
			x838c6c67b5953bb.xedb0eb766e25e0c9.x554aca059bdf6d48 = shading;
		}
		xbb04898cf6b5ed4f.xf2f6387c918f554c(xc5f6f2ca0aafd220.x664c130a09af677a(xa806b754814b9ae0.x40212106aad8a8b0), x838c6c67b5953bb);
		x800085dd555f7711.EndRow();
	}

	private static void x7d0d24118b3cc46b(Border x14cf9593b86ecbaa, double x9b0739496f8b5475)
	{
		x14cf9593b86ecbaa.LineStyle = LineStyle.Outset;
		x14cf9593b86ecbaa.x63b1a7c31a962459 = x26d9ecb4bdf0456d.x45260ad4b94166f2;
		x14cf9593b86ecbaa.x3b83679cceee1fab(x9b0739496f8b5475);
	}

	private void xb8fe14fc671949f3(x5125118f43aba344 xe6de5e5fa2d44af5)
	{
		x800085dd555f7711.InsertCell();
		x800085dd555f7711.CellFormat.xc51abb79cd36bee7();
		x800085dd555f7711.CellFormat.HorizontalMerge = xe6de5e5fa2d44af5.x338a5e6ab7c5595e;
		x800085dd555f7711.CellFormat.VerticalMerge = xe6de5e5fa2d44af5.x1a1dda35b3ae703d;
		Cell xc5464084edc8e = x800085dd555f7711.CurrentParagraph.xc5464084edc8e226;
		if (xe6de5e5fa2d44af5.xc6a8342933c4e987 != null)
		{
			xc5464084edc8e.xf8cef531dae89ea3.xce5b83b714f11fba = xe6de5e5fa2d44af5.xc6a8342933c4e987;
		}
		if (xc90fcebf565aca41.xeae235558dc44397 > 0.0)
		{
			xc5464084edc8e.CellFormat.Borders.LineStyle = LineStyle.Outset;
			xc5464084edc8e.CellFormat.Borders.LineWidth = 0.75;
			xc5464084edc8e.CellFormat.Borders.x63b1a7c31a962459 = x26d9ecb4bdf0456d.x45260ad4b94166f2;
		}
		CellVerticalAlignment xc7e4cc9c69af8ff = CellVerticalAlignment.Center;
		if (!x495fdb45f3d92b70.x1cd02f5b4489bb3e(xe6de5e5fa2d44af5.x40212106aad8a8b0, ref xc7e4cc9c69af8ff))
		{
			x495fdb45f3d92b70.x1cd02f5b4489bb3e(xb697767b913c1ad5.x40212106aad8a8b0, ref xc7e4cc9c69af8ff);
		}
		x800085dd555f7711.CellFormat.VerticalAlignment = xc7e4cc9c69af8ff;
		x26d9ecb4bdf0456d x6c50a99faab7d = x26d9ecb4bdf0456d.x45260ad4b94166f2;
		bool flag = x495fdb45f3d92b70.x722b70a5a6410b8c(xe6de5e5fa2d44af5.x40212106aad8a8b0, "bgcolor", ref x6c50a99faab7d);
		if (!flag)
		{
			flag = x495fdb45f3d92b70.x722b70a5a6410b8c(xb697767b913c1ad5.x40212106aad8a8b0, "bgcolor", ref x6c50a99faab7d);
		}
		if (!flag)
		{
			flag = x495fdb45f3d92b70.x722b70a5a6410b8c(xc90fcebf565aca41.x40212106aad8a8b0, "bgcolor", ref x6c50a99faab7d);
		}
		if (flag)
		{
			x800085dd555f7711.CellFormat.Shading.x0e18178ac4b2272f = x6c50a99faab7d;
		}
		xbb04898cf6b5ed4f.xc8a57043e4e79a44(x664c130a09af677a(xe6de5e5fa2d44af5), x664c130a09af677a(xe6de5e5fa2d44af5.x4da4b13c8bf87e9a), x664c130a09af677a(xe6de5e5fa2d44af5.xf041dffa93734047), xc5464084edc8e);
		if (xe6de5e5fa2d44af5.x40212106aad8a8b0 != null)
		{
			x0692e6d68a6b7f4b.x53ed331c1f3b8fda(xe6de5e5fa2d44af5.x40212106aad8a8b0);
		}
	}

	private static string x664c130a09af677a(x5125118f43aba344 xe6de5e5fa2d44af5)
	{
		if (xe6de5e5fa2d44af5 == null || xe6de5e5fa2d44af5.x40212106aad8a8b0 == null)
		{
			return string.Empty;
		}
		return xc5f6f2ca0aafd220.x664c130a09af677a(xe6de5e5fa2d44af5.x40212106aad8a8b0);
	}
}
