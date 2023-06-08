using System.Collections;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Aspose.Cells;
using ns16;

namespace ns8;

internal class Class1478
{
	internal Workbook workbook_0;

	internal string string_0;

	internal string string_1;

	internal string string_2;

	internal string string_3 = ".htm";

	internal string string_4;

	internal Stream stream_0;

	internal string string_5;

	internal string string_6;

	internal string string_7;

	internal ArrayList arrayList_0 = new ArrayList();

	internal ArrayList arrayList_1 = new ArrayList();

	private Class1473 class1473_0;

	private Class1536 class1536_0;

	private Style style_0;

	private Hashtable hashtable_0;

	private bool bool_0;

	internal string string_8;

	private HtmlSaveOptions htmlSaveOptions_0;

	internal IStreamProvider istreamProvider_0;

	internal Hashtable hashtable_1;

	internal ArrayList arrayList_2;

	private string string_9;

	private ArrayList arrayList_3 = new ArrayList();

	internal Workbook Workbook => workbook_0;

	[SpecialName]
	internal bool method_0()
	{
		return bool_0;
	}

	internal bool method_1()
	{
		if (stream_0 != null)
		{
			return true;
		}
		return false;
	}

	[SpecialName]
	internal HtmlSaveOptions method_2()
	{
		return htmlSaveOptions_0;
	}

	internal Class1478(Workbook workbook_1, string string_10, string string_11, Stream stream_1, HtmlSaveOptions htmlSaveOptions_1)
	{
		htmlSaveOptions_0 = htmlSaveOptions_1;
		string pageTitle = htmlSaveOptions_1.PageTitle;
		workbook_0 = workbook_1;
		istreamProvider_0 = htmlSaveOptions_1.ExportProviderFile;
		if (istreamProvider_0 == null)
		{
			istreamProvider_0 = new Class432();
		}
		hashtable_1 = new Hashtable();
		arrayList_2 = new ArrayList();
		class1473_0 = new Class1473(workbook_1);
		string_0 = string_11;
		stream_0 = stream_1;
		if (pageTitle != null && pageTitle.Length > 0)
		{
			string_4 = pageTitle;
		}
		if (string_4 == null)
		{
			string_4 = htmlSaveOptions_0.PageTitle;
		}
		class1536_0 = Class1536.smethod_0(workbook_1);
		style_0 = new Style(workbook_1.Worksheets);
		style_0.Copy(workbook_1.Worksheets.DefaultStyle);
		if (string_10 != null)
		{
			string_1 = Path.GetFileNameWithoutExtension(string_10);
			string extension = Path.GetExtension(string_10);
			if (!(extension.ToLower() == ".htm") && !(extension.ToLower() == ".html"))
			{
				if (!(extension.ToLower() == ".mht") && !(extension.ToLower() == ".mhtml"))
				{
					string_1 = Path.GetFileName(string_10);
				}
				else
				{
					string_1 = Path.GetFileNameWithoutExtension(string_10);
				}
			}
			else
			{
				string_3 = extension;
			}
			string_2 = string_1 + string_3;
			string_6 = string_1 + "_files";
			string_7 = Path.GetDirectoryName(string_10) + Path.DirectorySeparatorChar;
			string_5 = string_7 + string_6 + Path.DirectorySeparatorChar;
		}
		else
		{
			string text = htmlSaveOptions_0.AttachedFilesDirectory;
			if (text != null && text.Length > 1)
			{
				if (text[text.Length - 1] != Path.DirectorySeparatorChar)
				{
					text += Path.DirectorySeparatorChar;
				}
				string_5 = Path.GetDirectoryName(text) + Path.DirectorySeparatorChar;
			}
			else if (htmlSaveOptions_0.IsExpImageToTempDir)
			{
				string_5 = Path.GetTempPath();
			}
			else if (htmlSaveOptions_0.ExportObjectListener != null)
			{
				string_5 = "";
			}
			else
			{
				string_5 = null;
			}
			string_8 = htmlSaveOptions_0.AttachedFilesUrlPrefix;
		}
		method_8();
	}

	[SpecialName]
	internal Class1473 method_3()
	{
		return class1473_0;
	}

	[SpecialName]
	internal Class1536 method_4()
	{
		return class1536_0;
	}

	[SpecialName]
	internal Hashtable method_5()
	{
		return hashtable_0;
	}

	[SpecialName]
	internal void method_6(Hashtable hashtable_2)
	{
		hashtable_0 = hashtable_2;
	}

	[SpecialName]
	internal Style method_7()
	{
		return style_0;
	}

	private void method_8()
	{
		if (string_0 != null && string_0.Length > 0)
		{
			Worksheet worksheet = workbook_0.Worksheets[string_0];
			if (worksheet == null)
			{
				throw new CellsException(ExceptionType.SheetName, "sheet " + string_0 + " does not exist");
			}
			arrayList_1.Add(worksheet);
		}
		else
		{
			for (int i = 0; i < workbook_0.Worksheets.Count; i++)
			{
				Worksheet worksheet2 = workbook_0.Worksheets[i];
				if (worksheet2.IsVisible && (worksheet2.Type == SheetType.Worksheet || worksheet2.Type == SheetType.Chart))
				{
					arrayList_1.Add(worksheet2);
				}
			}
			for (int j = 0; j < workbook_0.Worksheets.Count; j++)
			{
				Worksheet worksheet3 = workbook_0.Worksheets[j];
				if (!worksheet3.IsVisible && (worksheet3.Type == SheetType.Worksheet || worksheet3.Type == SheetType.Chart))
				{
					arrayList_1.Add(worksheet3);
				}
			}
		}
		int count = arrayList_1.Count;
		if (count != 1 && count != 0)
		{
			bool_0 = true;
		}
		else
		{
			bool_0 = false;
		}
		method_16();
	}

	internal Class1487 method_9(Class1487 class1487_0, string string_10, string string_11, string string_12, string string_13)
	{
		if (class1487_0 == null)
		{
			string origPath = string_6 + "/tabstrip.htm";
			string key = origPath;
			Stream stream = istreamProvider_0.GetStream(ref origPath, string_5 + "tabstrip.htm");
			Encoding encoding = method_2().Encoding;
			if (encoding == null)
			{
				encoding = Encoding.UTF8;
			}
			class1487_0 = new Class1487(stream, encoding);
			hashtable_1.Add(key, origPath);
			arrayList_2.Add(stream);
		}
		else
		{
			smethod_0(class1487_0, string_10, string_11, string_12, string_13);
		}
		return class1487_0;
	}

	internal Class1487 method_10(Class1487 class1487_0, string string_10, string string_11, string string_12, string string_13)
	{
		if (class1487_0 == null)
		{
			Encoding encoding = method_2().Encoding;
			if (encoding == null)
			{
				encoding = Encoding.UTF8;
			}
			class1487_0 = ((stream_0 == null) ? new Class1487(string_7 + string_1 + string_3, encoding) : new Class1487(stream_0, encoding));
		}
		else
		{
			smethod_0(class1487_0, string_10, string_11, string_12, string_13);
		}
		return class1487_0;
	}

	public static void smethod_0(Class1487 class1487_0, string string_10, string string_11, string string_12, string string_13)
	{
		class1487_0.method_9();
		class1487_0.method_9();
		class1487_0.method_8(string_10);
		class1487_0.method_8("Content-Location: " + string_11);
		class1487_0.method_8("Content-Transfer-Encoding: " + string_12);
		class1487_0.method_8("Content-Type: " + string_13);
		class1487_0.method_9();
		class1487_0.method_9();
	}

	internal Class1487 method_11(Class1487 class1487_0, string string_10, string string_11, string string_12, string string_13)
	{
		if (class1487_0 == null)
		{
			string origPath = string_6 + "/stylesheet.css";
			string key = origPath;
			Stream stream = istreamProvider_0.GetStream(ref origPath, string_5 + "stylesheet.css");
			Encoding encoding = method_2().Encoding;
			if (encoding == null)
			{
				encoding = Encoding.UTF8;
			}
			class1487_0 = new Class1487(stream, encoding);
			hashtable_1.Add(key, origPath);
			arrayList_2.Add(stream);
		}
		else
		{
			smethod_0(class1487_0, string_10, string_11, string_12, string_13);
		}
		return class1487_0;
	}

	internal Class1487 method_12(Class1487 class1487_0, string string_10, string string_11, string string_12, string string_13)
	{
		if (class1487_0 == null)
		{
			string origPath = string_6 + "/filelist.xml";
			string key = origPath;
			Stream stream = istreamProvider_0.GetStream(ref origPath, string_5 + "filelist.xml");
			Encoding encoding = method_2().Encoding;
			if (encoding == null)
			{
				encoding = Encoding.UTF8;
			}
			class1487_0 = new Class1487(stream, encoding);
			hashtable_1.Add(key, origPath);
			arrayList_2.Add(stream);
		}
		else
		{
			smethod_0(class1487_0, string_10, string_11, string_12, string_13);
		}
		return class1487_0;
	}

	internal Class1487 method_13(string string_10, Class1487 class1487_0, string string_11, string string_12, string string_13, string string_14)
	{
		string_9 = string_12;
		string parsedPath = string_5 + string_10;
		if (class1487_0 == null)
		{
			string origPath = string_6 + "/" + string_10;
			string key = origPath;
			Stream stream = istreamProvider_0.GetStream(ref origPath, parsedPath);
			Encoding encoding = method_2().Encoding;
			if (encoding == null)
			{
				encoding = Encoding.UTF8;
			}
			class1487_0 = new Class1487(stream, encoding);
			hashtable_1.Add(key, origPath);
			arrayList_2.Add(stream);
		}
		else
		{
			smethod_0(class1487_0, string_11, string_12 + string_10, string_13, string_14);
		}
		return class1487_0;
	}

	internal string method_14(string string_10)
	{
		if (arrayList_1.Count <= 1)
		{
			return null;
		}
		int num = 0;
		while (true)
		{
			if (num < arrayList_1.Count)
			{
				Worksheet worksheet = (Worksheet)arrayList_1[num];
				if (worksheet.Name == string_10)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return "sheet" + Class1486.smethod_1(num + 1, 3) + ".htm";
	}

	internal ArrayList method_15()
	{
		return arrayList_3;
	}

	private void method_16()
	{
		for (int i = 0; i < arrayList_1.Count; i++)
		{
			Worksheet worksheet = (Worksheet)arrayList_1[i];
			if (worksheet.Cells.Hyperlinks.Count <= 0)
			{
				continue;
			}
			for (int j = 0; j < worksheet.Cells.Hyperlinks.Count; j++)
			{
				Hyperlink hyperlink = worksheet.Cells.Hyperlinks[j];
				try
				{
					if (hyperlink.method_5(workbook_0.Worksheets) == 2)
					{
						arrayList_3.Add(hyperlink);
					}
				}
				catch
				{
				}
			}
		}
	}

	internal string method_17(string string_10)
	{
		if (string_5 == null)
		{
			return "";
		}
		if (method_1() && string_10 == null)
		{
			if (string_8 != null)
			{
				return string_8;
			}
			return string_5;
		}
		if (!method_0())
		{
			return string_6 + Path.DirectorySeparatorChar;
		}
		return "";
	}
}
