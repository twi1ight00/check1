using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Aspose.Cells;
using Aspose.Cells.Charts;
using ns16;

namespace ns8;

internal class Class1472
{
	private Workbook workbook_0;

	private Worksheet worksheet_0;

	private int int_0;

	private Class1478 class1478_0;

	private string string_0;

	internal Class1472(Class1478 class1478_1, int int_1, string string_1)
	{
		class1478_0 = class1478_1;
		int_0 = int_1;
		workbook_0 = class1478_1.workbook_0;
		if (int_1 != -1)
		{
			worksheet_0 = (Worksheet)class1478_1.arrayList_1[int_1];
		}
		else
		{
			worksheet_0 = (Worksheet)class1478_1.arrayList_1[0];
		}
		string_0 = string_1;
	}

	internal string Write(Class1487 class1487_0, string string_1, string string_2, string string_3, string string_4, HtmlSaveOptions htmlSaveOptions_0)
	{
		string_0 = string_2;
		workbook_0.method_30();
		if (int_0 == -1)
		{
			return null;
		}
		string text = "sheet" + Class1486.smethod_1(int_0 + 1, 3) + ".htm";
		Class1487 @class = null;
		try
		{
			@class = class1478_0.method_13(text, class1487_0, string_1, string_2, string_3, string_4);
			@class.method_4(bool_0: true, worksheet_0.DisplayRightToLeft);
			@class.method_9();
			@class.method_6();
			@class.method_10(bool_0: false);
			method_3(@class);
			method_4(@class);
			@class.method_8("<!--[if gte mso 9]><xml>");
			method_6(@class);
			method_0(@class);
			@class.method_8("</xml><![endif]-->");
			@class.method_7();
			@class.method_9();
			method_1(@class, string_1, string_2, string_3, string_4, htmlSaveOptions_0);
			@class.method_9();
			@class.method_5();
			@class.method_9();
			@class.Flush();
			return text;
		}
		finally
		{
			if (@class != null && class1487_0 == null)
			{
				for (int i = 0; i < class1478_0.arrayList_2.Count; i++)
				{
					Stream stream = (Stream)class1478_0.arrayList_2[i];
					class1478_0.istreamProvider_0.Close(null, stream);
				}
			}
		}
	}

	internal void method_0(Class1487 class1487_0)
	{
		ConditionalFormattingCollection conditionalFormattings = worksheet_0.ConditionalFormattings;
		for (int i = 0; i < conditionalFormattings.Count; i++)
		{
			FormatConditionCollection formatConditionCollection = conditionalFormattings[i];
			if (formatConditionCollection.Count == 0)
			{
				break;
			}
			class1487_0.method_8("   <x:ConditionalFormatting>");
			if (formatConditionCollection.arrayList_1 != null && formatConditionCollection.arrayList_1.Count > 0)
			{
				string text = Class1618.smethod_32(formatConditionCollection.arrayList_1, 0, formatConditionCollection.arrayList_1.Count);
				class1487_0.method_8("    <x:Range>" + text + "</x:Range>");
			}
			for (int j = 0; j < formatConditionCollection.Count; j++)
			{
				FormatCondition formatCondition = formatConditionCollection[j];
				class1487_0.method_8("    <x:Condition>");
				if (formatCondition.Type == FormatConditionType.CellValue && formatCondition.operatorType_0 != OperatorType.None)
				{
					string text2 = Class1486.smethod_23(formatCondition);
					if (text2 != null)
					{
						class1487_0.method_8("     <x:Qualifier>" + text2 + "</x:Qualifier>");
					}
				}
				class1487_0.method_8("     <x:Value1>" + Class1486.smethod_22(formatCondition.Formula1) + "</x:Value1>");
				if (formatCondition.operatorType_0 == OperatorType.Between || formatCondition.operatorType_0 == OperatorType.NotBetween)
				{
					class1487_0.method_8("     <x:Value2>" + Class1486.smethod_22(formatCondition.Formula2) + "</x:Value2>");
				}
				string text3 = Class1486.smethod_18(formatCondition);
				string text4 = "Style='" + text3 + "'/>";
				class1487_0.method_8("     <x:Format " + text4);
				class1487_0.method_8("    </x:Condition>");
			}
			class1487_0.method_8("   </x:ConditionalFormatting>");
		}
	}

	internal void method_1(Class1487 class1487_0, string string_1, string string_2, string string_3, string string_4, HtmlSaveOptions htmlSaveOptions_0)
	{
		class1487_0.method_8("<body link=blue vlink=purple>");
		class1487_0.method_9();
		if (class1478_0.string_0 != null)
		{
			class1487_0.method_8("<div align=center>");
			if (class1478_0.string_4 != null)
			{
				string text = "<h1 style='color:black;font-family:Arial;font-size:14.0pt;font-weight:800;font-style:normal'>" + class1478_0.string_4 + "</h1>";
				class1487_0.method_8(text);
			}
		}
		if (worksheet_0.Type == SheetType.Worksheet)
		{
			Class1470 @class = new Class1470(class1478_0, worksheet_0, class1487_0, string_1, string_0, string_3, string_4, htmlSaveOptions_0);
			@class.method_0(string_0);
			@class.Write();
		}
		else if (worksheet_0.Type == SheetType.Chart && class1478_0.string_5 != null)
		{
			method_2(class1487_0);
		}
		if (class1478_0.string_0 != null)
		{
			class1487_0.method_8("</div>");
		}
		class1487_0.method_9();
		class1487_0.method_8("</body>");
	}

	private void method_2(Class1487 class1487_0)
	{
		if (worksheet_0.Charts.Count == 0)
		{
			return;
		}
		Chart chart = worksheet_0.Charts[0];
		if (chart == null)
		{
			return;
		}
		Bitmap bitmap;
		try
		{
			bool flag = false;
			if (chart.ChartArea.Area.Formatting == FormattingType.None)
			{
				chart.ChartArea.Area.Formatting = FormattingType.Custom;
				chart.ChartArea.Area.ForegroundColor = Color.White;
				flag = true;
			}
			bitmap = chart.ToImage();
			if (flag)
			{
				chart.ChartArea.Area.Formatting = FormattingType.None;
			}
			if (bitmap == null)
			{
				return;
			}
		}
		catch
		{
			return;
		}
		string text = "Chart" + worksheet_0.Name + ".jpg";
		text = Class1486.smethod_7(text);
		string filename = class1478_0.string_5 + text;
		Directory.CreateDirectory(class1478_0.string_5);
		bitmap.Save(filename, ImageFormat.Jpeg);
		if (class1478_0.method_1())
		{
			text = ((class1478_0.string_8 == null) ? (class1478_0.string_5 + text) : (class1478_0.string_8 + text));
		}
		else if (!class1478_0.method_0())
		{
			text = class1478_0.string_6 + Path.DirectorySeparatorChar + text;
		}
		string text2 = "<img src=\"" + text + "\" alt=1>";
		class1487_0.method_8(text2);
	}

	private void method_3(Class1487 class1487_0)
	{
		class1487_0.method_8("<link id=Main-File rel=Main-File href=\"../" + class1478_0.string_2 + "\">");
		class1487_0.method_8("<link rel=File-List href=filelist.xml>");
		class1487_0.method_8("<link rel=Edit-Time-Data href=editdata.mso>");
	}

	private void method_4(Class1487 class1487_0)
	{
		class1487_0.method_8("<!--[if !mso]>");
		class1487_0.method_8("<style>");
		class1487_0.method_8("v\\\\:* {behavior:url(#default#VML);}");
		class1487_0.method_8("o\\\\:* {behavior:url(#default#VML);}");
		class1487_0.method_8("x\\\\:* {behavior:url(#default#VML);}");
		class1487_0.method_8(".shape {behavior:url(#default#VML);}");
		class1487_0.method_8("</style>");
		class1487_0.method_8("<![endif]-->");
		class1487_0.method_8("<link rel=Stylesheet href=stylesheet.css>");
		class1487_0.method_8("<style>");
		class1487_0.method_8("<!--table");
		class1487_0.method_8(" {mso-displayed-decimal-separator:\"\\.\";");
		class1487_0.method_8(" mso-displayed-thousand-separator:\"\\,\";}");
		method_5(class1487_0);
		class1487_0.method_8("-->");
		class1487_0.method_8("</style>");
		class1487_0.method_8("<![if !supportTabStrip]><script language=\"JavaScript\">");
		class1487_0.method_8("<!--");
		class1487_0.method_8("function fnUpdateTabs()");
		class1487_0.method_8(" {");
		class1487_0.method_8("  if (parent.window.g_iIEVer>=4) {");
		class1487_0.method_8("   if (parent.document.readyState==\"complete\"");
		class1487_0.method_8("    && parent.frames['frTabs'].document.readyState==\"complete\")");
		class1487_0.method_8("   parent.fnSetActiveSheet(" + Class1618.smethod_80(int_0) + ");");
		class1487_0.method_8("  else");
		class1487_0.method_8("   window.setTimeout(\"fnUpdateTabs();\",150);");
		class1487_0.method_8(" }");
		class1487_0.method_8("}");
		class1487_0.method_8("");
		class1487_0.method_8("if (window.name!=\"frSheet\")");
		class1487_0.method_8(" window.location.replace(\"../" + class1478_0.string_2 + "\");");
		class1487_0.method_8("else");
		class1487_0.method_8(" fnUpdateTabs();");
		class1487_0.method_8("//-->");
		class1487_0.method_8("</script>");
		class1487_0.method_8("<![endif]>");
	}

	internal void method_5(Class1487 class1487_0)
	{
		PageSetup pageSetup = worksheet_0.PageSetup;
		class1487_0.method_8("@page");
		class1487_0.method_8(" {");
		string text = pageSetup.GetHeader(0) + pageSetup.GetHeader(1) + pageSetup.GetHeader(2);
		string text2 = pageSetup.GetFooter(0) + pageSetup.GetFooter(1) + pageSetup.GetFooter(2);
		text = text.Trim();
		text2 = text2.Trim();
		if (text.Length > 0)
		{
			class1487_0.method_8(" mso-header-data:" + text + ";");
		}
		if (text2.Length > 0)
		{
			class1487_0.method_8(" mso-footer-data:" + text2 + ";");
		}
		string text3 = Class1618.smethod_79(pageSetup.TopMarginInch) + "in " + Class1618.smethod_79(pageSetup.RightMarginInch) + "in " + Class1618.smethod_79(pageSetup.BottomMarginInch) + "in " + Class1618.smethod_79(pageSetup.LeftMarginInch) + "in;";
		class1487_0.method_8(" margin:" + text3);
		class1487_0.method_8(" mso-header-margin:" + Class1618.smethod_79(pageSetup.HeaderMarginInch) + "in;");
		class1487_0.method_8(" mso-footer-margin:" + Class1618.smethod_79(pageSetup.FooterMarginInch) + "in;");
		if (!pageSetup.IsAutoFirstPageNumber)
		{
			class1487_0.method_8(" mso-page-numbers-start:" + Class1618.smethod_80(pageSetup.FirstPageNumber) + ";");
		}
		string text4 = ((pageSetup.Orientation == PageOrientationType.Landscape) ? "Landscape" : "Portrait");
		class1487_0.method_8(" mso-page-orientation:" + text4 + ";");
		if (pageSetup.CenterHorizontally)
		{
			class1487_0.method_8(" mso-horizontal-page-align:center;");
		}
		if (pageSetup.CenterVertically)
		{
			class1487_0.method_8(" mso-vertical-page-align:center;");
		}
		class1487_0.method_8(" }");
	}

	internal void method_6(Class1487 class1487_0)
	{
		long num = Class1486.smethod_12(worksheet_0.Cells.StandardWidthPixels);
		class1487_0.method_8("<x:WorksheetOptions>");
		class1487_0.method_8(" <x:StandardWidth>" + num + "</x:StandardWidth>");
		if (!worksheet_0.PageSetup.IsPercentScale)
		{
			class1487_0.method_8(" <x:FitToPage/>");
		}
		method_9(class1487_0);
		method_10(class1487_0);
		if (worksheet_0.IsSelected)
		{
			class1487_0.method_8(" <x:Selected/>");
		}
		if (!worksheet_0.IsVisible)
		{
			class1487_0.method_8(" <x:Visible>SheetHidden</x:Visible>");
		}
		if (!worksheet_0.IsGridlinesVisible)
		{
			class1487_0.method_8(" <x:DoNotDisplayGridlines/>");
		}
		if (!worksheet_0.IsRowColumnHeadersVisible)
		{
			class1487_0.method_8(" <x:DoNotDisplayHeadings/>");
		}
		if (worksheet_0.FirstVisibleColumn != 0)
		{
			class1487_0.method_8(" <x:LeftColumnVisible>" + Class1618.smethod_80(worksheet_0.FirstVisibleColumn) + "</x:LeftColumnVisible>");
		}
		if (worksheet_0.FirstVisibleRow != 0)
		{
			class1487_0.method_8(" <x:TopRowVisible>" + Class1618.smethod_80(worksheet_0.FirstVisibleRow) + "</x:TopRowVisible>");
		}
		method_8(class1487_0);
		if (worksheet_0.method_0() != null)
		{
			method_7(class1487_0);
		}
		class1487_0.method_8("</x:WorksheetOptions>");
	}

	private void method_7(Class1487 class1487_0)
	{
		Protection protection = worksheet_0.method_0();
		if (!protection.AllowEditingContent)
		{
			class1487_0.method_8(" <x:ProtectContents>True</x:ProtectContents>");
		}
		else
		{
			class1487_0.method_8(" <x:ProtectContents>False</x:ProtectContents>");
		}
		if (!protection.AllowEditingObject)
		{
			class1487_0.method_8(" <x:ProtectObjects>True</x:ProtectObjects>");
		}
		else
		{
			class1487_0.method_8(" <x:ProtectObjects>False</x:ProtectObjects>");
		}
		if (!protection.AllowEditingScenario)
		{
			class1487_0.method_8(" <x:ProtectScenarios>True</x:ProtectScenarios>");
		}
		else
		{
			class1487_0.method_8(" <x:ProtectScenarios>False</x:ProtectScenarios>");
		}
		if (!protection.AllowSelectingLockedCell || !protection.AllowSelectingUnlockedCell)
		{
			if (!protection.AllowSelectingLockedCell && !protection.AllowSelectingUnlockedCell)
			{
				class1487_0.method_8(" <x:EnableSelection>NoSelection</x:EnableSelection>");
			}
			else
			{
				class1487_0.method_8(" <x:EnableSelection>UnlockedCells</x:EnableSelection>");
			}
		}
		if (protection.AllowFormattingCell)
		{
			class1487_0.method_8(" <x:AllowFormatCells/>");
		}
		if (protection.AllowFormattingColumn)
		{
			class1487_0.method_8(" <x:AllowSizeCols/>");
		}
		if (protection.AllowFormattingRow)
		{
			class1487_0.method_8(" <x:AllowSizeRows/>");
		}
		if (protection.AllowInsertingColumn)
		{
			class1487_0.method_8(" <x:AllowInsertCols/>");
		}
		if (protection.AllowInsertingRow)
		{
			class1487_0.method_8(" <x:AllowInsertRows/>");
		}
		if (protection.AllowInsertingHyperlink)
		{
			class1487_0.method_8(" <x:AllowInsertHyperlinks/>");
		}
		if (protection.AllowDeletingColumn)
		{
			class1487_0.method_8(" <x:AllowDeleteCols/>");
		}
		if (protection.AllowDeletingRow)
		{
			class1487_0.method_8(" <x:AllowDeleteRows/>");
		}
		if (protection.AllowSorting)
		{
			class1487_0.method_8(" <x:AllowSort/>");
		}
		if (protection.AllowFiltering)
		{
			class1487_0.method_8(" <x:AllowFilter/>");
		}
		if (protection.AllowUsingPivotTable)
		{
			class1487_0.method_8(" <x:AllowUsePivotTables/>");
		}
	}

	private void method_8(Class1487 class1487_0)
	{
	}

	private void method_9(Class1487 class1487_0)
	{
		class1487_0.method_8(" <x:Print>");
		PageSetup pageSetup = worksheet_0.PageSetup;
		if (pageSetup.FitToPagesWide != 1)
		{
			class1487_0.method_8("  <x:FitWidth>" + Class1618.smethod_80(pageSetup.FitToPagesWide) + "</x:FitWidth>");
		}
		if (pageSetup.FitToPagesTall != 1)
		{
			class1487_0.method_8("  <x:FitHeight>" + Class1618.smethod_80(pageSetup.FitToPagesTall) + "</x:FitHeight>");
		}
		if (pageSetup.Order == PrintOrderType.OverThenDown)
		{
			class1487_0.method_8("  <x:LeftToRight/>");
		}
		if (pageSetup.BlackAndWhite)
		{
			class1487_0.method_8("  <x:BlackAndWhite/>");
		}
		if (pageSetup.PrintDraft)
		{
			class1487_0.method_8("  <x:DraftQuality/>");
		}
		class1487_0.method_8("  <x:PaperSizeIndex>" + Class1618.smethod_80((int)pageSetup.PaperSize) + "</x:PaperSizeIndex>");
		if (pageSetup.Zoom != 100)
		{
			class1487_0.method_8("  <x:Scale>" + Class1618.smethod_80(pageSetup.Zoom) + "</x:Scale>");
		}
		class1487_0.method_8("  <x:HorizontalResolution>" + Class1618.smethod_80(pageSetup.PrintQuality) + "</x:HorizontalResolution>");
		class1487_0.method_8("  <x:VerticalResolution>" + Class1618.smethod_80(pageSetup.PrintQuality) + "</x:VerticalResolution>");
		if (pageSetup.PrintHeadings)
		{
			class1487_0.method_8("  <x:RowColHeadings/>");
		}
		if (pageSetup.PrintComments == PrintCommentsType.PrintSheetEnd)
		{
			class1487_0.method_8("  <x:CommentsLayout>SheetEnd</x:CommentsLayout>");
		}
		else if (pageSetup.PrintComments == PrintCommentsType.PrintInPlace)
		{
			class1487_0.method_8("  <x:CommentsLayout>InPlace</x:CommentsLayout>");
		}
		if (pageSetup.PrintErrors == PrintErrorsType.PrintErrorsNA)
		{
			class1487_0.method_8("  <x:PrintErrors>NA</x:PrintErrors>");
		}
		else if (pageSetup.PrintErrors == PrintErrorsType.PrintErrorsDash)
		{
			class1487_0.method_8("  <x:PrintErrors>Dash</x:PrintErrors>");
		}
		else if (pageSetup.PrintErrors == PrintErrorsType.PrintErrorsBlank)
		{
			class1487_0.method_8("  <x:PrintErrors>Blank</x:PrintErrors>");
		}
		if (pageSetup.PrintGridlines)
		{
			class1487_0.method_8("  <x:Gridlines/>");
		}
		class1487_0.method_8(" </x:Print>");
	}

	private void method_10(Class1487 class1487_0)
	{
		int zoom = worksheet_0.Zoom;
		int num = 60;
		if (worksheet_0.IsPageBreakPreview)
		{
			class1487_0.method_8(" <x:ShowPageBreakZoom/>");
		}
		if (zoom != 100)
		{
			class1487_0.method_8(" <x:Zoom>" + Class1618.smethod_80(zoom) + "</x:Zoom>");
		}
		if (num != 60)
		{
			class1487_0.method_8(" <x:PageBreakZoom>" + Class1618.smethod_80(num) + "</x:PageBreakZoom>");
		}
	}
}
