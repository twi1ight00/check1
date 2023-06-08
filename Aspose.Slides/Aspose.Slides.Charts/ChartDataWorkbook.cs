using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using ns21;
using ns276;
using ns33;
using ns34;
using ns42;
using ns43;
using ns49;

namespace Aspose.Slides.Charts;

public class ChartDataWorkbook : IChartDataWorkbook
{
	internal const string string_0 = "Aspose.Slides.DOM.resources.";

	internal const string string_1 = "urn:schemas-microsoft-com:office:office";

	internal Chart chart_0;

	internal Class834 class834_0;

	internal Class826 class826_0;

	internal Class818 class818_0;

	internal Class823 class823_0;

	internal Class824 class824_0;

	private Class739 class739_0;

	internal Class808 class808_0;

	internal Class805 class805_0;

	internal Class737 class737_0;

	private string string_2 = "http://schemas.openxmlformats.org/officeDocument/2006/relationships";

	internal Hashtable hashtable_0 = new Hashtable();

	private Enum22 enum22_0;

	private Class803 class803_0;

	private Class802 class802_0 = new Class802();

	private Class801 class801_0 = new Class801();

	internal Enum22 WorkbookType
	{
		get
		{
			return enum22_0;
		}
		set
		{
			enum22_0 = value;
		}
	}

	internal Class803 LoadOptions => class803_0;

	internal Class739 Worksheets => class739_0;

	internal Class802 StylesPartXLSXUnsupportedProps => class802_0;

	internal Class801 WorkbookPartXLSXUnsupportedProps => class801_0;

	internal void method_0(Class834 package)
	{
		class803_0 = new Class803();
		class739_0 = new Class739(this);
		class808_0 = new Class808(this);
		class834_0 = package;
		class826_0 = package.class826_0;
		class818_0 = class826_0.WorkbookElement;
		class823_0 = package.class823_0;
		class824_0 = package.class824_0;
		if (class823_0 != null)
		{
			Class810[] array = class823_0.SStElement.method_56("si", Class823.string_12);
			Class810[] array2 = array;
			foreach (Class810 @class in array2)
			{
				Class810 class2 = @class.method_57("t", Class823.string_12);
				if (class2 == null)
				{
					Class810 class3 = @class.method_57("r", Class823.string_12);
					if (class3 != null)
					{
						class2 = class3.method_57("t", Class823.string_12);
					}
				}
				class808_0.Add(class2.InnerText);
			}
		}
		class805_0 = new Class805(this);
		if (class824_0 != null && class824_0.NumFmtsElement != null)
		{
			class805_0.method_0(class824_0.NumFmtsElement);
		}
		class737_0 = new Class737(this);
		if (class824_0 != null && class824_0.CellXfsElement != null)
		{
			class737_0.method_0(class824_0.CellXfsElement);
		}
		foreach (Class827 item in package.list_1)
		{
			new ChartDataWorksheet(this, item.WorkSheetElement, class808_0);
		}
		Class810 class4 = class818_0.method_57("definedNames", class818_0.NamespaceURI);
		if (class4 != null)
		{
			Class810[] array3 = class4.method_56("definedName", class818_0.NamespaceURI);
			Class810[] array4 = array3;
			for (int j = 0; j < array4.Length; j++)
			{
				Class813 class5 = (Class813)array4[j];
				if (class5.DefinedName != "")
				{
					hashtable_0.Add(class5.DefinedName, class5.InnerText);
				}
			}
		}
		Class810 class6 = class818_0.method_57("sheets", class818_0.NamespaceURI);
		if (class6 == null)
		{
			return;
		}
		Class810[] array5 = class6.method_56("sheet", class818_0.NamespaceURI);
		Class810[] array6 = array5;
		foreach (Class810 class7 in array6)
		{
			string attribute = class7.GetAttribute("id", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
			Class1086 class8 = class834_0.method_5(class826_0.Relationships[attribute].Target);
			ChartDataWorksheet chartDataWorksheet = (ChartDataWorksheet)class8.object_0;
			if (chartDataWorksheet != null)
			{
				chartDataWorksheet.SheetId = (uint)class7.method_11("sheetId", "", 0);
				chartDataWorksheet.NameInternal = class7.method_5("name", "", "");
				chartDataWorksheet.IndexInternal = class739_0.Add(chartDataWorksheet);
			}
		}
	}

	internal ChartDataWorkbook(Stream stream, Chart parent)
	{
		try
		{
			method_1(stream);
		}
		catch (Exception2 exception)
		{
			throw new PptxReadException("Workbook reading aborted.", exception);
		}
	}

	private void method_1(Stream stream)
	{
		if (!stream.CanSeek)
		{
			byte[] array = new byte[4096];
			MemoryStream memoryStream = new MemoryStream(0);
			while (true)
			{
				int num = stream.Read(array, 0, array.Length);
				if (num == 0)
				{
					break;
				}
				memoryStream.Write(array, 0, num);
			}
			memoryStream.Seek(0L, SeekOrigin.Begin);
			stream = memoryStream;
		}
		else
		{
			stream.Seek(0L, SeekOrigin.Begin);
		}
		byte b = (byte)stream.ReadByte();
		stream.Seek(-1L, SeekOrigin.Current);
		if (b == 80)
		{
			if (Class257.bool_0)
			{
				method_0(new Class834(stream, privateStream: false));
				return;
			}
			class803_0 = new Class803();
			class739_0 = new Class739(this);
			class808_0 = new Class808(this);
			Class257 @class = new Class257();
			@class.method_0(this, stream);
		}
	}

	internal void Write(Stream stream)
	{
		using Class6752 @class = new Class6752();
		if (Class257.bool_0)
		{
			Class1087 context = new Class1087(@class, null);
			method_2(context);
			@class.Save(stream);
		}
		else
		{
			Class255 class2 = new Class255();
			class2.method_0(this, @class, Enum22.const_0);
			@class.Save(stream);
		}
	}

	internal ChartDataWorkbook(Chart parent)
	{
		chart_0 = parent;
		Stream stream = null;
		using (stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Aspose.Slides.DOM.resources.template.xlsx"))
		{
			if (stream == null)
			{
				throw new PptxException("Aspose.Slides.dll is broken.");
			}
			if (Class257.bool_0)
			{
				method_0(new Class834(stream, privateStream: false));
				return;
			}
			class803_0 = new Class803();
			class739_0 = new Class739(this);
			class808_0 = new Class808(this);
			Class257 @class = new Class257();
			@class.method_0(this, stream);
		}
	}

	private void method_2(Class1087 context)
	{
		int num = 1;
		foreach (ChartDataWorksheet worksheet in Worksheets)
		{
			context.method_1(worksheet.class827_0.class1086_0.string_0, "/xl/worksheets/sheet" + num++ + ".xml");
		}
		class808_0.Clear();
		foreach (ChartDataWorksheet worksheet2 in Worksheets)
		{
			worksheet2.method_1(context);
		}
		class824_0 = class834_0.class824_0;
		if (class824_0.CellXfsElement != null)
		{
			class824_0.DocumentElement.RemoveChild(class824_0.CellXfsElement);
		}
		if (class824_0.NumFmtsElement != null)
		{
			class824_0.DocumentElement.RemoveChild(class824_0.NumFmtsElement);
		}
		if (class805_0.Count > 0)
		{
			Class810 @class = class824_0.DocumentElement.method_1("numFmts", Class824.string_12);
			@class.Prefix = "";
			@class.method_13("count", "", class805_0.Count);
			class805_0.Save(@class);
		}
		if (class737_0.Count > 0)
		{
			Class810 refChild = class824_0.method_1("cellStyleXfs", Class824.string_12);
			Class810 class2 = new Class810("", "cellXfs", Class824.string_12, class824_0);
			class824_0.DocumentElement.InsertAfter(class2, refChild);
			class2.Prefix = "";
			class2.method_13("count", "", class737_0.Count);
			class737_0.Save(class2);
		}
		class823_0 = class834_0.class823_0;
		if (class823_0 != null)
		{
			class823_0.SStElement.RemoveAll();
			for (int i = 0; i < class808_0.Count; i++)
			{
				string text = class808_0[i];
				class823_0.SStElement.method_13("uniqueCount", "", (int)class808_0.uint_1);
				class823_0.SStElement.method_13("count", "", (int)class808_0.uint_0);
				Class810 class3 = class823_0.SStElement.method_0("si", Class823.string_12);
				class3.Prefix = "";
				Class810 class4 = class3.method_0("t", Class823.string_12);
				if (text.Trim() == "" || (text.Length > 0 && text[text.Length - 1] == ' '))
				{
					class4.SetAttribute("space", "", "preserve");
					class4.Attributes[0].Prefix = "xml";
				}
				class4.InnerText = text;
				class4.Prefix = "";
			}
		}
		Class810 class5 = class818_0.method_57("sheets", Class826.string_12);
		class5.RemoveAll();
		int num2 = 1;
		foreach (ChartDataWorksheet item in class739_0)
		{
			Class810 class6 = class5.method_0("sheet", Class826.string_12);
			Class1089 class7 = class826_0.Relationships.method_0("http://schemas.openxmlformats.org/officeDocument/2006/relationships/worksheet", item.class827_0.class1086_0.string_0);
			class6.SetAttribute("id", string_2, class7.Id);
			class6.method_13("sheetId", "", num2++);
			class6.method_8("name", "", item.Name, "");
		}
		Hashtable hashtable = new Hashtable(class834_0.sortedList_0.Count);
		Class1086 class8 = class834_0.method_5(Class834.smethod_4("/"));
		hashtable.Add(class8, class8);
		smethod_0(class834_0, class834_0.class1090_0, hashtable);
		byte[] array = new byte[65536];
		ArrayList arrayList = new ArrayList(class834_0.sortedList_0.Count);
		foreach (Class1086 value in hashtable.Values)
		{
			string text2 = context.method_3(value.string_0);
			if (text2 != null)
			{
				arrayList.Add(new DictionaryEntry(text2, value));
			}
		}
		arrayList.Sort(Class1154.class1154_1);
		using (MemoryStream memoryStream = new MemoryStream())
		{
			string fileName = "/[Content_Types].xml".Substring(1, "/[Content_Types].xml".Length - 1);
			XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
			xmlTextWriter.Formatting = (context.bool_0 ? Formatting.Indented : Formatting.None);
			xmlTextWriter.WriteStartDocument();
			xmlTextWriter.WriteStartElement("Types");
			xmlTextWriter.WriteAttributeString("xmlns", "http://schemas.openxmlformats.org/package/2006/content-types");
			Hashtable hashtable2 = new Hashtable();
			foreach (DictionaryEntry item2 in arrayList)
			{
				Class1086 class10 = (Class1086)item2.Value;
				string text3 = (string)item2.Key;
				int num3 = text3.LastIndexOf('.');
				if (num3 >= 0)
				{
					string key = text3.Substring(num3).ToLower();
					string text4 = (string)hashtable2[key];
					if (text4 == null)
					{
						hashtable2[key] = class10.string_1;
					}
					else if (text4 != "" && !(text4 == class10.string_1))
					{
						hashtable2[key] = "";
					}
				}
			}
			foreach (DictionaryEntry item3 in hashtable2)
			{
				string text5 = (string)item3.Value;
				if (text5 != "")
				{
					xmlTextWriter.WriteStartElement("Default");
					xmlTextWriter.WriteAttributeString("Extension", ((string)item3.Key).Substring(1));
					xmlTextWriter.WriteAttributeString("ContentType", text5);
					xmlTextWriter.WriteEndElement();
				}
			}
			foreach (DictionaryEntry item4 in arrayList)
			{
				Class1086 class11 = (Class1086)item4.Value;
				string text6 = (string)item4.Key;
				int num4 = text6.LastIndexOf('.');
				if (num4 >= 0)
				{
					string key2 = text6.Substring(num4).ToLower();
					string text7 = (string)hashtable2[key2];
					if (text7 != class11.string_1)
					{
						xmlTextWriter.WriteStartElement("Override");
						xmlTextWriter.WriteAttributeString("PartName", text6);
						xmlTextWriter.WriteAttributeString("ContentType", class11.string_1);
						xmlTextWriter.WriteEndElement();
					}
				}
			}
			xmlTextWriter.WriteEndElement();
			xmlTextWriter.WriteEndDocument();
			xmlTextWriter.Flush();
			context.ZipFile.method_30(fileName, null, memoryStream.ToArray());
		}
		foreach (DictionaryEntry item5 in arrayList)
		{
			string text8 = (string)item5.Key;
			string text9 = text8;
			text8 = text8.Substring(1, text8.Length - 1);
			Class1086 class12 = (Class1086)item5.Value;
			using MemoryStream memoryStream2 = new MemoryStream();
			if (class12.class822_0 != null)
			{
				smethod_1(context, memoryStream2, class12.class822_0);
			}
			else if (class12.class1090_0 != null)
			{
				class12.class1090_0.Save(context, memoryStream2, text9.Substring(0, text9.LastIndexOf('/') + 1));
			}
			else if (class12.byte_0 != null)
			{
				memoryStream2.Write(class12.byte_0, 0, class12.byte_0.Length);
			}
			else
			{
				if (class12.class6751_0 == null)
				{
					throw new PptxException("Internal saving error.");
				}
				using Stream stream = class12.class6751_0.method_19();
				while (true)
				{
					int num5 = stream.Read(array, 0, array.Length);
					if (num5 != 0)
					{
						memoryStream2.Write(array, 0, num5);
						continue;
					}
					break;
				}
			}
			context.ZipFile.method_30(text8, null, memoryStream2.ToArray());
		}
		foreach (Class1086 value2 in class834_0.sortedList_0.Values)
		{
			value2.class822_0?.method_0();
		}
	}

	private static void smethod_0(Class834 package, Class1090 rels, Hashtable found)
	{
		foreach (Class1089 rel in rels)
		{
			if (rel.External == NullableBool.True)
			{
				continue;
			}
			Class1086 class2 = package.method_5(rel.Target);
			if (class2 == null || found.Contains(class2))
			{
				continue;
			}
			found.Add(class2, class2);
			string name = Class834.smethod_4(class2.string_0);
			Class1086 class3 = package.method_5(name);
			if (class2.class822_0 != null)
			{
				class2.class822_0.vmethod_2();
				class3 = package.method_5(name);
				if (class2.class822_0.Relationships != null)
				{
					class2.class822_0.Relationships.method_2();
					smethod_2(class2.class822_0);
				}
				if (class3 == null && class2.class822_0.class1090_0 != null && class2.class822_0.class1090_0.ContainsUsedRelationships)
				{
					class3 = new Class1086(name);
					class3.string_1 = "application/vnd.openxmlformats-package.relationships+xml";
					class3.class1090_0 = class2.class822_0.class1090_0;
					package.method_7(class3);
				}
			}
			else
			{
				class3?.class1090_0.method_3(value: true);
			}
			if (class3 != null && class3.class1090_0.ContainsUsedRelationships)
			{
				found.Add(class3, class3);
				smethod_0(package, class3.class1090_0, found);
			}
		}
	}

	internal static void smethod_1(Class1087 context, Stream stream, XmlDocument document)
	{
		bool flag = false;
		if (document is Class822)
		{
			flag = ((Class822)document).bool_1;
		}
		Class822 @class = document as Class822;
		Stream stream2 = stream;
		if (@class != null && @class.bool_0)
		{
			stream2 = new MemoryStream();
		}
		XmlTextWriter xmlTextWriter = new XmlTextWriter(stream2, Encoding.UTF8);
		xmlTextWriter.Formatting = ((context.bool_0 && !flag) ? Formatting.Indented : Formatting.None);
		document.WriteTo(xmlTextWriter);
		xmlTextWriter.Flush();
		if (@class != null && @class.bool_0)
		{
			stream2.Seek(0L, SeekOrigin.Begin);
			Class822.smethod_1(stream2, stream);
			stream2.Close();
		}
	}

	internal static void smethod_2(Class822 document)
	{
		string text;
		if ((text = document.class1086_0.string_1) != null && text == "application/vnd.openxmlformats-officedocument.vmlDrawing")
		{
			smethod_4(document.DocumentElement, document.class1090_0, "urn:schemas-microsoft-com:office:office", "relid");
		}
		else
		{
			smethod_3(document.DocumentElement, document.class1090_0, "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
		}
	}

	private static void smethod_3(XmlElement elem, Class1090 rels, string namespaceURI)
	{
		foreach (XmlNode item in elem)
		{
			if (item is XmlElement)
			{
				smethod_3((XmlElement)item, rels, namespaceURI);
			}
		}
		foreach (XmlAttribute attribute in elem.Attributes)
		{
			if (attribute.NamespaceURI == namespaceURI && attribute.Value.Length > 0)
			{
				Class1089 @class = rels[attribute.Value];
				if (@class != null)
				{
					@class.Used = true;
				}
			}
		}
	}

	private static void smethod_4(XmlElement elem, Class1090 rels, string namespaceURI, string localName)
	{
		foreach (XmlNode item in elem)
		{
			if (item is XmlElement)
			{
				smethod_4((XmlElement)item, rels, namespaceURI, localName);
			}
		}
		foreach (XmlAttribute attribute in elem.Attributes)
		{
			if (attribute.NamespaceURI == namespaceURI && attribute.LocalName == localName && attribute.Value.Length > 0)
			{
				Class1089 @class = rels[attribute.Value];
				if (@class != null)
				{
					@class.Used = true;
				}
			}
		}
	}

	public IChartCellCollection GetCellCollection(string formula, bool skipHiddenCells)
	{
		ChartCellCollection chartCellCollection = new ChartCellCollection(chart_0);
		List<object[]> list = method_6(formula);
		string text = "";
		ChartDataWorksheet chartDataWorksheet = null;
		if (list.Count > 0)
		{
			text = (string)list[0][0];
			chartDataWorksheet = Worksheets[text];
		}
		foreach (object[] item in list)
		{
			int count = ((List<int>)item[1]).Count;
			for (int i = 0; i < count; i++)
			{
				int row = ((List<int>)item[1])[i];
				int col = ((List<int>)item[2])[i];
				ChartDataCell chartDataCell = chartDataWorksheet.Cells[row, col];
				if (!chartDataCell.IsHidden || !skipHiddenCells)
				{
					chartCellCollection.method_2(chartDataCell);
				}
			}
		}
		return chartCellCollection;
	}

	public IChartDataCell GetCell(string worksheetName, int row, int column)
	{
		ChartDataWorksheet chartDataWorksheet = method_5(worksheetName);
		return chartDataWorksheet.Cells[row, column];
	}

	public IChartDataCell GetCell(int worksheetIndex, int row, int column)
	{
		method_4(worksheetIndex);
		return Worksheets[worksheetIndex].Cells[row, column];
	}

	public IChartDataCell GetCell(int worksheetIndex, string cellName)
	{
		method_4(worksheetIndex);
		return Worksheets[worksheetIndex].Cells[cellName];
	}

	public IChartDataCell GetCell(int worksheetIndex, string cellName, object value)
	{
		method_4(worksheetIndex);
		ChartDataCell chartDataCell = Worksheets[worksheetIndex].Cells[cellName];
		chartDataCell.method_3(value);
		return chartDataCell;
	}

	public IChartDataCell GetCell(int worksheetIndex, int row, int column, object value)
	{
		method_4(worksheetIndex);
		ChartDataCell chartDataCell = Worksheets[worksheetIndex].Cells[row, column];
		chartDataCell.method_3(value);
		return chartDataCell;
	}

	public void Clear(int sheetIndex)
	{
		if (sheetIndex < Worksheets.Count)
		{
			Worksheets[sheetIndex].Cells.Clear();
		}
	}

	internal ChartDataCell method_3()
	{
		ChartDataWorksheet chartDataWorksheet = Worksheets["AUTO_DATA"];
		if (chartDataWorksheet == null)
		{
			chartDataWorksheet = Worksheets.Add("AUTO_DATA");
		}
		ChartDataCell chartDataCell = chartDataWorksheet.Cells["A1"];
		int num = ((chartDataCell.Value != null) ? (chartDataCell.IntValue + 1) : 0);
		ChartDataCell chartDataCell2 = chartDataWorksheet.Cells["A2"];
		int intValue = ((chartDataCell2.Value == null) ? 1 : (intValue = chartDataCell2.IntValue));
		if (num > 65535)
		{
			if (intValue >= 255)
			{
				throw new InvalidOperationException("You reached the limit of worksheet, but you are able to add data using ChartDataWorkbook.GetCell method");
			}
			num = 0;
			intValue++;
		}
		chartDataWorksheet.Cells["A1"].method_1(num);
		chartDataWorksheet.Cells["A2"].method_1(intValue);
		return chartDataWorksheet.Cells[num, intValue];
	}

	private ChartDataWorksheet method_4(int index)
	{
		if (index > Worksheets.Count - 1)
		{
			int num = index - (Worksheets.Count - 1);
			for (int i = 0; i < num; i++)
			{
				Worksheets.Add();
			}
		}
		return Worksheets[index];
	}

	internal ChartDataWorksheet method_5(string worksheetName)
	{
		ChartDataWorksheet chartDataWorksheet = null;
		foreach (ChartDataWorksheet worksheet in Worksheets)
		{
			if (worksheet.Name == worksheetName)
			{
				chartDataWorksheet = worksheet;
				break;
			}
		}
		if (chartDataWorksheet == null)
		{
			chartDataWorksheet = Worksheets.Add();
			chartDataWorksheet.NameInternal = worksheetName;
		}
		return chartDataWorksheet;
	}

	internal List<object[]> method_6(string s)
	{
		List<object> list = new List<object>();
		char[] separator = new char[2] { ',', ';' };
		string[] array = s.Split(separator, StringSplitOptions.RemoveEmptyEntries);
		int num = 1;
		string[] array2 = array;
		int num2 = 0;
		object obj;
		while (true)
		{
			if (num2 < array2.Length)
			{
				string text = array2[num2];
				if (text.IndexOf("$") >= 0)
				{
					string text2 = text.Replace(")", "");
					text2 = text2.Replace("(", "");
					if (text2.IndexOf("[") > -1 && text2.IndexOf("]") > text2.IndexOf("["))
					{
						text2 = text2.Remove(text2.IndexOf("["), text2.IndexOf("]") - text2.IndexOf("[") + 1);
					}
					char[] separator2 = new char[1] { '!' };
					string[] array3 = text2.Split(separator2, StringSplitOptions.RemoveEmptyEntries);
					if (array3.Length >= 2)
					{
						obj = hashtable_0[array3[1]];
						if (obj != null)
						{
							break;
						}
					}
					list.Add(array3[0]);
					char[] separator3 = new char[1] { ':' };
					string[] array4 = array3[1].Split(separator3, StringSplitOptions.RemoveEmptyEntries);
					if (array4.Length > 1)
					{
						int first = 0;
						int second = 0;
						int first2 = 0;
						int second2 = 0;
						method_9(array4[0], ref first, ref second);
						method_9(array4[1], ref first2, ref second2);
						int num3 = first2 - first + 1;
						int num4 = second2 - second + 1;
						num = num4;
						for (int i = 0; i < num4; i++)
						{
							for (int j = 0; j < num3; j++)
							{
								list.Add(first + j);
								list.Add(second + i);
							}
						}
					}
					else
					{
						int first3 = 0;
						int second3 = 0;
						method_9(array3[1], ref first3, ref second3);
						list.Add(first3);
						list.Add(second3);
					}
				}
				num2++;
				continue;
			}
			List<object[]> list2 = new List<object[]>();
			object[] array5 = null;
			int num5 = 0;
			foreach (object item in list)
			{
				if (typeof(string) == item.GetType())
				{
					string sheetName = (string)item;
					array5 = new object[4]
					{
						method_8(sheetName),
						new List<int>(),
						new List<int>(),
						num
					};
					list2.Add(array5);
				}
				else
				{
					if (num5 % 2 != 0)
					{
						((List<int>)array5[1]).Add((int)item);
					}
					else
					{
						((List<int>)array5[2]).Add((int)item);
					}
					num5++;
				}
			}
			return list2;
		}
		return method_6((string)obj);
	}

	internal bool method_7(string s)
	{
		char[] separator = new char[2] { ',', ';' };
		string[] array = s.Split(separator, StringSplitOptions.RemoveEmptyEntries);
		string[] array2 = array;
		int num = 0;
		while (true)
		{
			if (num < array2.Length)
			{
				string text = array2[num];
				string text2 = text.Replace(")", "");
				text2 = text2.Replace("(", "");
				if (text2.IndexOf("[") > -1 && text2.IndexOf("]") > text2.IndexOf("["))
				{
					text2 = text2.Remove(text2.IndexOf("["), text2.IndexOf("]") - text2.IndexOf("[") + 1);
				}
				char[] separator2 = new char[1] { '!' };
				string[] array3 = text2.Split(separator2, StringSplitOptions.RemoveEmptyEntries);
				if (array3.Length >= 2)
				{
					object obj = hashtable_0[array3[1]];
					if (obj != null)
					{
						return method_7((string)obj);
					}
					ChartDataWorksheet chartDataWorksheet = Worksheets[array3[0]];
					if (chartDataWorksheet == null)
					{
						break;
					}
				}
				num++;
				continue;
			}
			return true;
		}
		return false;
	}

	private string method_8(string sheetName)
	{
		if (sheetName.Length > 2 && sheetName.IndexOf("'") == 0 && sheetName.LastIndexOf("'") == sheetName.Length - 1)
		{
			return sheetName.Substring(1, sheetName.Length - 2);
		}
		return sheetName;
	}

	private void method_9(string s, ref int first, ref int second)
	{
		string text = s.ToUpper();
		char[] separator = new char[1] { '$' };
		string[] array = text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
		string text2 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		for (int i = 0; i < array[0].Length; i++)
		{
			first = (int)((double)first + Math.Pow(text2.Length, array[0].Length - i - 1) * (double)(text2.IndexOf(array[0][i]) + 1));
		}
		first--;
		second = int.Parse(array[1]) - 1;
	}
}
