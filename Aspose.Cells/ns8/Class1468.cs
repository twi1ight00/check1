using System;
using System.Globalization;
using Aspose.Cells;
using Aspose.Cells.Properties;
using ns16;
using ns2;

namespace ns8;

internal class Class1468
{
	private Workbook workbook_0;

	private int int_0;

	private int int_1;

	private Worksheet worksheet_0;

	private Class1472 class1472_0;

	private bool bool_0;

	private Class1478 class1478_0;

	internal Class1468(Class1478 class1478_1, string string_0)
	{
		class1478_0 = class1478_1;
		workbook_0 = class1478_0.workbook_0;
		int count = class1478_0.arrayList_1.Count;
		switch (count)
		{
		case 1:
			worksheet_0 = (Worksheet)class1478_0.arrayList_1[0];
			class1472_0 = new Class1472(class1478_1, -1, string_0);
			break;
		case 0:
			bool_0 = true;
			break;
		}
		int activeSheetIndex = workbook_0.Worksheets.ActiveSheetIndex;
		for (int i = 0; i < count; i++)
		{
			Worksheet worksheet = (Worksheet)class1478_0.arrayList_1[i];
			if (worksheet.IsVisible)
			{
				int_1++;
			}
			if (worksheet.Index == activeSheetIndex)
			{
				int_0 = i;
			}
		}
	}

	internal void Write(Class1487 class1487_0, string string_0, string string_1, string string_2, string string_3, HtmlSaveOptions htmlSaveOptions_0)
	{
		Class1487 @class = class1478_0.method_10(class1487_0, string_0, string_1, string_2, string_3);
		try
		{
			if (bool_0)
			{
				method_0(@class);
				return;
			}
			@class.method_4(bool_0: true, bool_1: false);
			@class.method_9();
			@class.method_6();
			@class.method_10(class1478_0.method_0());
			method_3(@class);
			method_1(@class);
			method_4(@class);
			if (class1478_0.method_0())
			{
				method_5(@class);
			}
			else
			{
				method_2(@class);
			}
			method_6(@class);
			@class.method_7();
			if (class1478_0.method_0())
			{
				method_9(@class);
			}
			else
			{
				class1472_0.method_1(@class, string_0, string_1, string_2, string_3, htmlSaveOptions_0);
			}
			@class.method_5();
			@class.method_9();
			@class.Flush();
		}
		finally
		{
			if (!class1478_0.method_1() && @class != null && class1487_0 == null)
			{
				@class.Close();
			}
		}
	}

	private void method_0(Class1487 class1487_0)
	{
		class1487_0.method_4(bool_0: true, bool_1: false);
		class1487_0.method_9();
		class1487_0.method_6();
		class1487_0.method_10(bool_0: false);
		method_1(class1487_0);
		method_4(class1487_0);
		class1487_0.method_7();
		class1487_0.method_8("<body link=blue vlink=purple>");
		class1487_0.method_8("no sheets for display");
		class1487_0.method_8("</body>");
		class1487_0.method_5();
		class1487_0.method_9();
		class1487_0.Close();
	}

	private void method_1(Class1487 class1487_0)
	{
		if (class1478_0.string_4 != null && class1478_0.string_4.Length != 0)
		{
			string string_ = "<title>" + class1478_0.string_4 + "</title>";
			class1487_0.method_8(string_);
		}
	}

	private void method_2(Class1487 class1487_0)
	{
		class1487_0.method_8("<style>");
		class1487_0.method_8("<!--table");
		class1487_0.method_8(" {mso-displayed-decimal-separator:\"\\.\";");
		class1487_0.method_8(" mso-displayed-thousand-separator:\"\\,\";}");
		class1472_0.method_5(class1487_0);
		class1487_0.method_9();
		Class1469 @class = new Class1469(class1478_0);
		@class.Write(class1487_0);
		class1487_0.method_8("-->");
		class1487_0.method_8("</style>");
	}

	private void method_3(Class1487 class1487_0)
	{
		string text = (string)class1478_0.hashtable_1[class1478_0.string_6 + "/filelist.xml"];
		if (text != null)
		{
			class1487_0.method_8("<link rel=File-List href=\"" + text + "\">");
		}
		else
		{
			class1487_0.method_8("<link rel=File-List href=\"" + class1478_0.string_6 + "/filelist.xml\">");
		}
		class1487_0.method_8("<link rel=Edit-Time-Data href=\"" + class1478_0.string_6 + "/editdata.mso\">");
		class1487_0.method_8("<link rel=OLE-Object-Data href=\"" + class1478_0.string_6 + "/oledata.mso\">");
	}

	private void method_4(Class1487 class1487_0)
	{
		class1487_0.method_8("<!--[if gte mso 9]><xml>");
		class1487_0.method_8(" <o:DocumentProperties>");
		BuiltInDocumentPropertyCollection builtInDocumentProperties = class1478_0.workbook_0.Worksheets.BuiltInDocumentProperties;
		string title = builtInDocumentProperties.Title;
		if (title.Length > 0)
		{
			class1487_0.method_8("  <o:Title>" + Class1486.smethod_2(title) + "</o:Title>");
		}
		title = builtInDocumentProperties.Subject;
		if (title.Length > 0)
		{
			class1487_0.method_8("  <o:Subject>" + Class1486.smethod_2(title) + "</o:Subject>");
		}
		title = builtInDocumentProperties.Author;
		if (title.Length > 0)
		{
			class1487_0.method_8("  <o:Author>" + Class1486.smethod_2(title) + "</o:Author>");
		}
		title = builtInDocumentProperties.Keywords;
		if (title.Length > 0)
		{
			class1487_0.method_8("  <o:Keywords>" + Class1486.smethod_2(title) + "</o:Keywords>");
		}
		int revisionNumber = builtInDocumentProperties.RevisionNumber;
		if (revisionNumber > 0)
		{
			class1487_0.method_8("  <o:Revision>" + Class1618.smethod_80(revisionNumber) + "</o:Revision>");
		}
		double totalEditingTime = builtInDocumentProperties.TotalEditingTime;
		if (totalEditingTime > 0.0)
		{
			class1487_0.method_8("  <o:TotalTime>" + Class1618.smethod_79(totalEditingTime) + "</o:TotalTime>");
		}
		DateTime lastPrinted = builtInDocumentProperties.LastPrinted;
		if (lastPrinted > DateTime.MinValue)
		{
			title = lastPrinted.ToString("yyyy-MM-dd\\THH:mm:ss\\Z", CultureInfo.InvariantCulture);
			class1487_0.method_8("  <o:LastPrinted>" + title + "</o:LastPrinted>");
		}
		lastPrinted = builtInDocumentProperties.CreatedTime;
		if (lastPrinted > DateTime.MinValue)
		{
			title = lastPrinted.ToString("yyyy-MM-dd\\THH:mm:ss\\Z", CultureInfo.InvariantCulture);
			class1487_0.method_8("  <o:Created>" + title + "</o:Created>");
		}
		lastPrinted = builtInDocumentProperties.LastSavedTime;
		if (lastPrinted > DateTime.MinValue)
		{
			title = lastPrinted.ToString("yyyy-MM-dd\\THH:mm:ss\\Z", CultureInfo.InvariantCulture);
			class1487_0.method_8("  <o:LastSaved>" + title + "</o:LastSaved>");
		}
		revisionNumber = builtInDocumentProperties.Pages;
		if (revisionNumber > 0)
		{
			class1487_0.method_8("  <o:Pages>" + Class1618.smethod_80(revisionNumber) + "</o:Pages>");
		}
		revisionNumber = builtInDocumentProperties.Words;
		if (revisionNumber > 0)
		{
			class1487_0.method_8("  <o:Words>" + Class1618.smethod_80(revisionNumber) + "</o:Words>");
		}
		revisionNumber = builtInDocumentProperties.Characters;
		if (revisionNumber > 0)
		{
			class1487_0.method_8("  <o:Characters>" + Class1618.smethod_80(revisionNumber) + "</o:Characters>");
		}
		title = builtInDocumentProperties.Category;
		if (title.Length > 0)
		{
			class1487_0.method_8("  <o:Category>" + title + "</o:Category>");
		}
		title = builtInDocumentProperties.Manager;
		if (title.Length > 0)
		{
			class1487_0.method_8("  <o:Manager>" + Class1486.smethod_2(title) + "</o:Manager>");
		}
		title = builtInDocumentProperties.Company;
		if (title.Length > 0)
		{
			class1487_0.method_8("  <o:Company>" + Class1486.smethod_2(title) + "</o:Company>");
		}
		revisionNumber = builtInDocumentProperties.Bytes;
		if (revisionNumber > 0)
		{
			class1487_0.method_8("  <o:Bytes>" + Class1618.smethod_80(revisionNumber) + "</o:Bytes>");
		}
		revisionNumber = builtInDocumentProperties.Lines;
		if (revisionNumber > 0)
		{
			class1487_0.method_8("  <o:Lines>" + Class1618.smethod_80(revisionNumber) + "</o:Lines>");
		}
		revisionNumber = builtInDocumentProperties.Paragraphs;
		if (revisionNumber > 0)
		{
			class1487_0.method_8("  <o:Paragraphs>" + Class1618.smethod_80(revisionNumber) + "</o:Paragraphs>");
		}
		revisionNumber = builtInDocumentProperties.CharactersWithSpaces;
		if (revisionNumber > 0)
		{
			class1487_0.method_8("  <o:CharactersWithSpaces>" + Class1618.smethod_80(revisionNumber) + "</o:CharactersWithSpaces>");
		}
		class1487_0.method_8("</o:DocumentProperties>");
		class1487_0.method_8("</xml><![endif]-->");
	}

	private void method_5(Class1487 class1487_0)
	{
		class1487_0.method_8("<![if !supportTabStrip]>");
		for (int i = 1; i <= int_1; i++)
		{
			string text = (string)class1478_0.hashtable_1[class1478_0.string_6 + "/sheet" + Class1486.smethod_1(i, 3) + ".htm"];
			if (text != null)
			{
				class1487_0.method_8("<link id=\"shLink\" href=\"" + text + "\">");
				continue;
			}
			class1487_0.method_8("<link id=\"shLink\" href=\"" + class1478_0.string_6 + "/sheet" + Class1486.smethod_1(i, 3) + ".htm\">");
		}
		class1487_0.method_9();
		class1487_0.method_8("<link id=\"shLink\">");
		class1487_0.method_9();
		class1487_0.method_8("<script language=\"JavaScript\">");
		class1487_0.method_8("<!--");
		class1487_0.method_8(" var c_lTabs=" + Class1618.smethod_80(int_1) + ";");
		class1487_0.method_9();
		class1487_0.method_8(" var c_rgszSh=new Array(c_lTabs);");
		for (int j = 0; j < class1478_0.arrayList_1.Count; j++)
		{
			Worksheet worksheet = (Worksheet)class1478_0.arrayList_1[j];
			if (!worksheet.IsVisible)
			{
				break;
			}
			class1487_0.method_8(" c_rgszSh[" + Class1618.smethod_80(j) + "]=\"" + Class1486.smethod_6(worksheet.Name) + "\";");
		}
		class1487_0.method_9();
		class1487_0.method_9();
		class1487_0.method_9();
		Class1466.Write(class1487_0, int_0);
		class1487_0.method_8("</script>");
		class1487_0.method_8("<![endif]>");
	}

	private void method_6(Class1487 class1487_0)
	{
		class1487_0.method_8("<!--[if gte mso 9]><xml>");
		class1487_0.method_8(" <x:ExcelWorkbook>");
		class1487_0.method_8("  <x:ExcelWorksheets>");
		if (class1478_0.method_0())
		{
			for (int i = 0; i < class1478_0.arrayList_1.Count; i++)
			{
				Worksheet worksheet_ = (Worksheet)class1478_0.arrayList_1[i];
				method_7(class1487_0, worksheet_, i + 1);
			}
		}
		else
		{
			class1487_0.method_8("   <x:ExcelWorksheet>");
			class1487_0.method_8("    <x:Name>" + method_11(worksheet_0.Name) + "</x:Name>");
			class1472_0.method_6(class1487_0);
			class1472_0.method_0(class1487_0);
			class1487_0.method_8("   </x:ExcelWorksheet>");
		}
		class1487_0.method_8("  </x:ExcelWorksheets>");
		if (class1478_0.method_0())
		{
			string text = (string)class1478_0.hashtable_1[class1478_0.string_6 + "/stylesheet.css"];
			if (text != null)
			{
				class1487_0.method_8("  <x:Stylesheet HRef=\"" + text + "\"/>");
			}
			else
			{
				class1487_0.method_8("  <x:Stylesheet HRef=\"" + class1478_0.string_6 + "/stylesheet.css\"/>");
			}
		}
		method_8(class1487_0);
		class1487_0.method_8(" </x:ExcelWorkbook>");
		method_10(class1487_0);
		class1487_0.method_8("</xml><![endif]-->");
	}

	private void method_7(Class1487 class1487_0, Worksheet worksheet_1, int int_2)
	{
		class1487_0.method_8("   <x:ExcelWorksheet>");
		class1487_0.method_8("    <x:Name>" + method_11(worksheet_1.Name) + "</x:Name>");
		string text = (string)class1478_0.hashtable_1[class1478_0.string_6 + "/sheet" + Class1486.smethod_1(int_2, 3) + ".htm"];
		if (text != null)
		{
			class1487_0.method_8("    <x:WorksheetSource HRef=\"" + text + "\"/>");
		}
		else
		{
			class1487_0.method_8("    <x:WorksheetSource HRef=\"" + class1478_0.string_6 + "/sheet" + Class1486.smethod_1(int_2, 3) + ".htm\"/>");
		}
		class1487_0.method_8("   </x:ExcelWorksheet>");
	}

	private void method_8(Class1487 class1487_0)
	{
		WorksheetCollection worksheets = class1478_0.workbook_0.Worksheets;
		class1487_0.method_8("  <x:WindowHeight>" + Class1618.smethod_80(worksheets.Workbook.Settings.method_18()) + "</x:WindowHeight>");
		class1487_0.method_8("  <x:WindowWidth>" + Class1618.smethod_80(worksheets.Workbook.Settings.method_16()) + "</x:WindowWidth>");
		class1487_0.method_8("  <x:WindowTopX>" + Class1618.smethod_80(worksheets.Workbook.Settings.method_12()) + "</x:WindowTopX>");
		class1487_0.method_8("  <x:WindowTopY>" + Class1618.smethod_80(worksheets.Workbook.Settings.method_14()) + "</x:WindowTopY>");
		class1487_0.method_8("  <x:RefModeR1C1/>");
		class1487_0.method_8("  <x:TabRatio>" + Class1618.smethod_80(worksheets.Workbook.Settings.SheetTabBarWidth) + "</x:TabRatio>");
		class1487_0.method_8("  <x:ActiveSheet>" + Class1618.smethod_80(int_0) + "</x:ActiveSheet>");
		if (!worksheets.Workbook.Settings.IsHScrollBarVisible)
		{
			class1487_0.method_8("  <x:HideHorizontalScrollBar/>");
		}
		if (!worksheets.Workbook.Settings.IsVScrollBarVisible)
		{
			class1487_0.method_8("  <x:HideVerticalScrollBar/>");
		}
		if (!worksheets.Workbook.Settings.ShowTabs)
		{
			class1487_0.method_8("  <x:HideWorkbookTabs/>");
		}
	}

	private void method_9(Class1487 class1487_0)
	{
		class1487_0.method_8("    <frameset rows=\"*,39\" border=0 width=0 frameborder=no framespacing=0>");
		string text = (string)class1478_0.hashtable_1[class1478_0.string_6 + "/sheet" + Class1486.smethod_1(int_0 + 1, 3) + ".htm"];
		if (text != null)
		{
			class1487_0.method_8("     <frame src=\"" + text + "\" name=\"frSheet\">");
		}
		else
		{
			class1487_0.method_8("     <frame src=\"" + class1478_0.string_6 + "/sheet" + Class1486.smethod_1(int_0 + 1, 3) + ".htm\" name=\"frSheet\">");
		}
		class1487_0.method_8("     <frame src=\"" + class1478_0.string_6 + "/tabstrip.htm\" name=\"frTabs\" marginwidth=0 marginheight=0>");
		class1487_0.method_8("     <noframes>");
		class1487_0.method_8("      <body>");
		class1487_0.method_8("       <p>This page uses frames, but your browser doesn't support them.</p>");
		class1487_0.method_8("      </body>");
		class1487_0.method_8("     </noframes>");
		class1487_0.method_8("    </frameset>");
	}

	private void method_10(Class1487 class1487_0)
	{
		foreach (Name name in workbook_0.Worksheets.Names)
		{
			if (name.Type == Enum184.const_1 || string.Compare(name.Text, "Print_Area", ignoreCase: true) == 0 || string.Compare(name.Text, "PRINT_TITLES", ignoreCase: true) == 0)
			{
				continue;
			}
			string refersTo = name.RefersTo;
			if (refersTo == null || refersTo.Length <= 1)
			{
				continue;
			}
			refersTo = refersTo.Substring(1);
			if (refersTo.IndexOf("#REF!") != -1 || refersTo.Equals("{}"))
			{
				refersTo = "#REF!";
			}
			int num = -1;
			if (name.SheetIndex != 0)
			{
				for (int i = 0; i < class1478_0.arrayList_1.Count; i++)
				{
					Worksheet worksheet = (Worksheet)class1478_0.arrayList_1[i];
					if (name.SheetIndex - 1 == worksheet.SheetIndex)
					{
						num = i;
						break;
					}
				}
			}
			class1487_0.method_8(" <x:ExcelName>");
			class1487_0.method_8("  <x:Name>" + method_11(name.Text) + "</x:Name>");
			if (name.IsHidden)
			{
				class1487_0.method_8("  <x:Hidden/>");
			}
			if (num != -1)
			{
				class1487_0.method_8("  <x:SheetIndex>" + num + "</x:SheetIndex>");
			}
			class1487_0.method_8("  <x:Formula>" + method_11(refersTo) + "</x:Formula>");
			class1487_0.method_8(" </x:ExcelName>");
		}
	}

	private string method_11(string string_0)
	{
		return string_0.Replace("&", "&amp;");
	}
}
