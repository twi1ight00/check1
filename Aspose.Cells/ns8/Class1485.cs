using System;
using System.Collections;
using System.IO;
using System.Text;
using Aspose.Cells;
using ns2;

namespace ns8;

internal class Class1485
{
	private Class1478 class1478_0;

	private string string_0;

	private SaveFormat saveFormat_0;

	private HtmlSaveOptions htmlSaveOptions_0;

	internal Class1485(Workbook workbook_0, Stream stream_0, string string_1, HtmlSaveOptions htmlSaveOptions_1)
	{
		saveFormat_0 = htmlSaveOptions_1.SaveFormat;
		htmlSaveOptions_0 = htmlSaveOptions_1;
		WorksheetCollection worksheets = workbook_0.Worksheets;
		smethod_0(worksheets);
		worksheets.method_27();
		class1478_0 = new Class1478(workbook_0, null, string_1, stream_0, htmlSaveOptions_1);
	}

	internal Class1485(Workbook workbook_0, Stream stream_0, HtmlSaveOptions htmlSaveOptions_1)
	{
		saveFormat_0 = htmlSaveOptions_1.SaveFormat;
		htmlSaveOptions_0 = htmlSaveOptions_1;
		WorksheetCollection worksheets = workbook_0.Worksheets;
		smethod_0(worksheets);
		worksheets.method_27();
		string fileName = workbook_0.FileName;
		string text = null;
		class1478_0 = new Class1478(workbook_0, (fileName == null || fileName == "") ? "c://main.mht" : (Path.GetDirectoryName(fileName) + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(fileName) + ".mht"), null, stream_0, htmlSaveOptions_1);
	}

	internal Class1485(Workbook workbook_0, string string_1, string string_2, HtmlSaveOptions htmlSaveOptions_1)
	{
		saveFormat_0 = htmlSaveOptions_1.SaveFormat;
		htmlSaveOptions_0 = htmlSaveOptions_1;
		string_0 = string_1;
		WorksheetCollection worksheets = workbook_0.Worksheets;
		smethod_0(worksheets);
		worksheets.method_27();
		class1478_0 = new Class1478(workbook_0, string_1, string_2, null, htmlSaveOptions_1);
	}

	private static void smethod_0(WorksheetCollection worksheetCollection_0)
	{
		if (Class972.smethod_0() == Enum134.const_0)
		{
			for (int i = 0; i < worksheetCollection_0.Count; i++)
			{
				worksheetCollection_0[i].IsSelected = false;
			}
			Worksheet worksheet = worksheetCollection_0[worksheetCollection_0.Add()];
			Class1677.smethod_36(worksheet);
			worksheet.Cells.Merge(3, 2, 1, 7);
			worksheet.Cells.Merge(6, 1, 1, 8);
			worksheet.Cells.Merge(8, 1, 1, 3);
			worksheet.Cells.Merge(10, 1, 1, 12);
			worksheet.Cells.Merge(12, 1, 1, 12);
			worksheet.Cells.Merge(14, 1, 1, 12);
			worksheet.Cells.Merge(15, 1, 1, 12);
		}
	}

	internal void method_0()
	{
		Stream stream = new MemoryStream();
		Encoding encoding = class1478_0.method_2().Encoding;
		if (encoding == null)
		{
			encoding = Encoding.UTF8;
		}
		Class434 @class = null;
		Class1487 class2 = null;
		string text = null;
		string text2 = null;
		string text3 = null;
		string text4 = null;
		string text5 = null;
		string text6 = null;
		ArrayList arrayList = null;
		string text7 = null;
		string text8 = Path.GetFileNameWithoutExtension(string_0);
		if (text8 == null || text8 == "")
		{
			string fileName = class1478_0.Workbook.FileName;
			text8 = ((fileName == null || fileName == "") ? "main" : Path.GetFileNameWithoutExtension(class1478_0.Workbook.FileName));
		}
		if (saveFormat_0 == SaveFormat.MHtml)
		{
			text = "----=_NextPart_aspose01.20120615";
			text2 = "file:///C:/aspose01/";
			text3 = "quoted-printable";
			text4 = "base64";
			text5 = "text/html; charset=\"" + Encoding.UTF8.WebName + "\"";
			text6 = "image/png";
			arrayList = new ArrayList();
			@class = new Class434(stream, encoding);
			class2 = @class.method_0(text);
			class2.method_2(SaveFormat.MHtml);
			class2.method_0(Encoding.UTF8);
			text = "--" + text;
		}
		if (class1478_0.string_5 != null && class1478_0.method_2().ExportObjectListener == null)
		{
			Class1467 class3 = new Class1467(class1478_0);
			class3.method_0(class2, text, text2 + text8 + "_files/", text4, text6, bool_0: false);
		}
		if (saveFormat_0 == SaveFormat.MHtml)
		{
			Class1468 class4 = new Class1468(class1478_0, text2);
			text7 = text8 + ".htm";
			class4.Write(class2, text, text2 + text7, text3, text5, htmlSaveOptions_0);
			if (arrayList != null)
			{
				arrayList.Add(text7);
				text2 = text2 + text8 + "_files/";
			}
		}
		if (class1478_0.string_5 != null && class1478_0.method_2().ExportObjectListener == null)
		{
			Class1467 class5 = new Class1467(class1478_0);
			class5.method_0(class2, text, text2, text4, text6, bool_0: true);
		}
		if (class1478_0.arrayList_1.Count <= 1)
		{
			if (saveFormat_0 != SaveFormat.MHtml)
			{
				Class1468 class6 = new Class1468(class1478_0, text2);
				text7 = text8 + ".htm";
				class6.Write(class2, text, text2 + text7, text3, text5, htmlSaveOptions_0);
				if (arrayList != null)
				{
					arrayList.Add(text7);
					text2 = text2 + text8 + "_files/";
				}
			}
			if (class2 != null && class2.method_3().Count > 0)
			{
				IDictionaryEnumerator enumerator = class2.method_3().GetEnumerator();
				while (enumerator.MoveNext())
				{
					Class1478.smethod_0(class2, text, (string)enumerator.Key, text4, text6);
					class2.Write(Convert.ToBase64String((byte[])enumerator.Value));
				}
			}
			if (@class != null)
			{
				Class1465 class7 = new Class1465(class1478_0);
				text7 = "filelist.xml";
				class7.Write(class2, text, text2 + text7, text3, text5);
				arrayList?.Add(text7);
				@class.method_1(text, bool_0: false);
				stream.Position = 0L;
				@class.method_3(string_0, stream, Encoding.UTF8, text);
			}
			return;
		}
		if (class1478_0.arrayList_1.Count > 1)
		{
			Class1487 class8 = null;
			try
			{
				text7 = "stylesheet.css";
				class8 = class1478_0.method_11(class2, text, text2 + text7, text3, text5);
				Class1469 class9 = new Class1469(class1478_0);
				class9.Write(class8);
				arrayList?.Add(text7);
			}
			finally
			{
				if (class8 != null && class2 == null)
				{
					for (int i = 0; i < class1478_0.arrayList_2.Count; i++)
					{
						Stream stream2 = (Stream)class1478_0.arrayList_2[i];
						class1478_0.istreamProvider_0.Close(null, stream2);
					}
				}
			}
			Class1471 class10 = new Class1471(class1478_0);
			text7 = "tabstrip.htm";
			class10.Write(class2, text, text2 + text7, text3, text5);
			arrayList?.Add(text7);
		}
		for (int j = 0; j < class1478_0.arrayList_1.Count; j++)
		{
			Class1472 class11 = new Class1472(class1478_0, j, text2);
			string value = class11.Write(class2, text, text2, text3, text5, htmlSaveOptions_0);
			arrayList?.Add(value);
		}
		if (class2 != null && class2.method_3().Count > 0)
		{
			IDictionaryEnumerator enumerator2 = class2.method_3().GetEnumerator();
			while (enumerator2.MoveNext())
			{
				Class1478.smethod_0(class2, text, (string)enumerator2.Key, text4, text6);
				class2.Write(Convert.ToBase64String((byte[])enumerator2.Value));
			}
		}
		Class1465 class12 = new Class1465(class1478_0);
		text7 = "filelist.xml";
		class12.Write(class2, text, text2 + text7, text3, text5);
		arrayList?.Add(text7);
		if (saveFormat_0 != SaveFormat.MHtml)
		{
			Class1468 class13 = new Class1468(class1478_0, text2);
			text7 = text8 + ".htm";
			class13.Write(class2, text, text2 + text7, text3, text5, htmlSaveOptions_0);
			if (arrayList != null)
			{
				arrayList.Add(text7);
				text2 = text2 + text8 + "_files/";
			}
		}
		if (@class != null)
		{
			@class.method_1(text, bool_0: false);
			stream.Position = 0L;
			@class.method_3(string_0, stream, Encoding.UTF8, text);
		}
	}

	internal void method_1(Stream stream_0)
	{
		Stream stream = new MemoryStream();
		Encoding encoding = class1478_0.method_2().Encoding;
		if (encoding == null)
		{
			encoding = Encoding.UTF8;
		}
		Class434 @class = null;
		Class1487 class2 = null;
		string text = null;
		string text2 = null;
		string text3 = null;
		string text4 = null;
		string text5 = null;
		string text6 = null;
		ArrayList arrayList = null;
		string text7 = null;
		string text8 = Path.GetFileNameWithoutExtension(string_0);
		if (text8 == null || text8 == "")
		{
			string fileName = class1478_0.Workbook.FileName;
			text8 = ((fileName == null || fileName == "") ? "main" : Path.GetFileNameWithoutExtension(class1478_0.Workbook.FileName));
		}
		if (saveFormat_0 == SaveFormat.MHtml)
		{
			text = "----=_NextPart_aspose01.20120615";
			text2 = "file:///C:/aspose01/";
			text3 = "quoted-printable";
			text4 = "base64";
			text5 = "text/html; charset=\"" + Encoding.UTF8.WebName + "\"";
			text6 = "image/png";
			arrayList = new ArrayList();
			@class = new Class434(stream, encoding);
			class2 = @class.method_0(text);
			class2.method_2(SaveFormat.MHtml);
			class2.method_0(Encoding.UTF8);
			text = "--" + text;
		}
		if (class1478_0.string_5 != null && class1478_0.method_2().ExportObjectListener == null)
		{
			Class1467 class3 = new Class1467(class1478_0);
			class3.method_0(class2, text, text2 + text8 + "_files/", text4, text6, bool_0: false);
		}
		Class1468 class4 = new Class1468(class1478_0, text2);
		text7 = text8 + ".htm";
		class4.Write(class2, text, text2 + text7, text3, text5, htmlSaveOptions_0);
		if (arrayList != null)
		{
			arrayList.Add(text7);
			text2 = text2 + text8 + "_files/";
		}
		if (class1478_0.string_5 != null && class1478_0.method_2().ExportObjectListener == null)
		{
			Class1467 class5 = new Class1467(class1478_0);
			class5.method_0(class2, text, text2, text4, text6, bool_0: true);
		}
		if (class1478_0.arrayList_1.Count <= 1)
		{
			if (class2 != null && class2.method_3().Count > 0)
			{
				IDictionaryEnumerator enumerator = class2.method_3().GetEnumerator();
				while (enumerator.MoveNext())
				{
					Class1478.smethod_0(class2, text, (string)enumerator.Key, text4, text6);
					class2.Write(Convert.ToBase64String((byte[])enumerator.Value));
				}
			}
			if (@class != null)
			{
				Class1465 class6 = new Class1465(class1478_0);
				text7 = "filelist.xml";
				class6.Write(class2, text, text2 + text7, text3, text5);
				arrayList?.Add(text7);
				@class.method_1(text, bool_0: false);
				stream.Position = 0L;
				@class.method_2(stream_0, stream, Encoding.UTF8, text);
			}
			return;
		}
		if (class1478_0.arrayList_1.Count > 1)
		{
			Class1487 class7 = null;
			try
			{
				text7 = "stylesheet.css";
				class7 = class1478_0.method_11(class2, text, text2 + text7, text3, text5);
				Class1469 class8 = new Class1469(class1478_0);
				class8.Write(class7);
				arrayList?.Add(text7);
			}
			finally
			{
				if (class7 != null && class2 == null)
				{
					for (int i = 0; i < class1478_0.arrayList_2.Count; i++)
					{
						Stream stream2 = (Stream)class1478_0.arrayList_2[i];
						class1478_0.istreamProvider_0.Close(null, stream2);
					}
				}
			}
			Class1471 class9 = new Class1471(class1478_0);
			text7 = "tabstrip.htm";
			class9.Write(class2, text, text2 + text7, text3, text5);
			arrayList?.Add(text7);
		}
		for (int j = 0; j < class1478_0.arrayList_1.Count; j++)
		{
			Class1472 class10 = new Class1472(class1478_0, j, text2);
			string value = class10.Write(class2, text, text2, text3, text5, htmlSaveOptions_0);
			arrayList?.Add(value);
		}
		if (class2 != null && class2.method_3().Count > 0)
		{
			IDictionaryEnumerator enumerator2 = class2.method_3().GetEnumerator();
			while (enumerator2.MoveNext())
			{
				Class1478.smethod_0(class2, text, (string)enumerator2.Key, text4, text6);
				class2.Write(Convert.ToBase64String((byte[])enumerator2.Value));
			}
		}
		Class1465 class11 = new Class1465(class1478_0);
		text7 = "filelist.xml";
		class11.Write(class2, text, text2 + text7, text3, text5);
		arrayList?.Add(text7);
		if (@class != null)
		{
			@class.method_1(text, bool_0: false);
			stream.Position = 0L;
			@class.method_2(stream_0, stream, Encoding.UTF8, text);
		}
	}
}
