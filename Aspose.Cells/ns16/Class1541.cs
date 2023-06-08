using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using Aspose.Cells;
using Aspose.Cells.Charts;
using Aspose.Cells.Drawing;
using Aspose.Cells.Pivot;
using Aspose.Cells.Properties;
using Aspose.Cells.Tables;
using ns22;

namespace ns16;

internal class Class1541
{
	internal Worksheet worksheet_0;

	internal Workbook workbook_0;

	internal int int_0;

	internal int int_1;

	internal Class1540 class1540_0;

	internal ArrayList arrayList_0;

	internal string string_0;

	internal ArrayList arrayList_1;

	internal int int_2;

	private ArrayList arrayList_2;

	internal Hashtable hashtable_0 = new Hashtable();

	internal string string_1;

	internal Class1534 class1534_0 = new Class1534();

	internal Class1358 class1358_0;

	internal Class1534 class1534_1;

	internal ArrayList arrayList_3 = new ArrayList();

	internal ArrayList arrayList_4;

	internal string string_2;

	internal string string_3;

	internal string string_4;

	internal Hashtable hashtable_1 = new Hashtable();

	internal ArrayList arrayList_5 = new ArrayList();

	internal Hashtable hashtable_2 = new Hashtable();

	internal Class1541(Class1540 class1540_1, Worksheet worksheet_1, int int_3, int int_4)
	{
		class1540_0 = class1540_1;
		workbook_0 = class1540_1.workbook_0;
		worksheet_0 = worksheet_1;
		int_0 = int_3;
		int_1 = int_4;
		arrayList_1 = new ArrayList();
		arrayList_2 = new ArrayList();
		method_14();
		method_20();
		method_7();
		method_9();
		method_8();
		method_10();
		method_0();
		method_15();
		method_16();
		method_5();
		method_6();
		if (worksheet_0.Type == SheetType.Worksheet)
		{
			method_4();
		}
		method_13();
	}

	internal void method_0()
	{
		ListObjectCollection listObjects = worksheet_0.ListObjects;
		if (listObjects == null || listObjects.Count == 0)
		{
			return;
		}
		for (int i = 0; i < listObjects.Count; i++)
		{
			ListObject listObject = listObjects[i];
			if (listObject.byte_0 == null || listObject.byte_0.Length <= 0)
			{
				string string_ = "../tables/table" + class1540_0.method_7() + class1540_0.string_0;
				string value = method_22("http://schemas.openxmlformats.org/officeDocument/2006/relationships/table", string_);
				hashtable_2[listObject] = value;
			}
		}
	}

	internal void method_1()
	{
		if (workbook_0.class1558_0 == null)
		{
			return;
		}
		if (worksheet_0.method_36() != null)
		{
			workbook_0.class1558_0.method_5(worksheet_0.method_36().method_0());
		}
		for (int i = 0; i < worksheet_0.Charts.Count; i++)
		{
			Chart chart = worksheet_0.Charts[i];
			if (chart.method_16() != null)
			{
				workbook_0.class1558_0.method_5(chart.method_16().method_0());
			}
		}
		if (worksheet_0.class1557_0 != null)
		{
			workbook_0.class1558_0.method_5(worksheet_0.class1557_0.arrayList_10);
			if (worksheet_0.class1557_0.string_4 != null)
			{
				method_2();
			}
		}
	}

	private void method_2()
	{
		string text = worksheet_0.class1557_0.string_4;
		int length = text.Length;
		StringBuilder stringBuilder = new StringBuilder(length);
		for (int i = 0; i < length; i++)
		{
			char c = text[i];
			if (c == ' ' && text[i + 1] == 'r' && text[i + 2] == ':' && text[i + 3] == 'i' && text[i + 4] == 'd' && text[i + 5] == '=')
			{
				StringBuilder stringBuilder2 = new StringBuilder(3);
				int j;
				for (j = i + 7; j < length && text[j] != '"'; j++)
				{
					stringBuilder2.Append(text[j]);
				}
				string text2 = (string)hashtable_0[stringBuilder2.ToString()];
				if (text2 == null)
				{
					text2 = method_3(stringBuilder2.ToString());
				}
				if (text2 != null)
				{
					stringBuilder.Append(" r:id=\"").Append(text2).Append("\"");
				}
				else
				{
					stringBuilder.Append(" r:id=\"").Append(stringBuilder2.ToString()).Append("\"");
				}
				i = j;
			}
			else
			{
				stringBuilder.Append(c);
			}
		}
		worksheet_0.class1557_0.string_4 = stringBuilder.ToString();
	}

	private string method_3(string string_5)
	{
		ArrayList arrayList = worksheet_0.class1557_0.arrayList_4;
		int num = 0;
		Class1564 @class;
		while (true)
		{
			if (num < arrayList.Count)
			{
				@class = (Class1564)arrayList[num];
				if (@class.string_0 == string_5)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return @class.string_1;
	}

	[Attribute0(true)]
	private void method_4()
	{
		if (worksheet_0.method_52() != null)
		{
			int count = worksheet_0.method_52().Count;
			for (int i = 0; i < count; i++)
			{
				CustomProperty customProperty = worksheet_0.CustomProperties[i];
				Class1361 @class = new Class1361();
				@class.string_0 = customProperty.Name;
				@class.string_2 = "customProperty" + class1540_0.method_6() + ".bin";
				@class.string_1 = method_22("http://schemas.openxmlformats.org/officeDocument/2006/relationships/customProperty", "../" + @class.string_2);
				@class.byte_0 = Encoding.Unicode.GetBytes(customProperty.Value);
				arrayList_5.Add(@class);
				Class1530 class2 = new Class1530();
				class2.string_2 = "application/vnd.openxmlformats-officedocument.spreadsheetml.customProperty";
				class2.string_1 = "/xl/" + @class.string_2;
				class1540_0.arrayList_4.Add(class2);
			}
		}
	}

	private void method_5()
	{
		byte[] backgroundImage = worksheet_0.BackgroundImage;
		if (backgroundImage != null)
		{
			Image image = Image.FromStream(new MemoryStream(backgroundImage));
			int num = class1540_0.method_5();
			if (image.RawFormat.Equals(ImageFormat.Bmp))
			{
				string_2 = "image" + num + ".png";
			}
			else
			{
				string_2 = Class1618.smethod_45("image", num, image.RawFormat);
			}
			string_3 = method_22("http://schemas.openxmlformats.org/officeDocument/2006/relationships/image", "../media/" + string_2);
		}
	}

	private void method_6()
	{
		if (class1540_0.string_0 == ".bin")
		{
			return;
		}
		byte[] array = worksheet_0.PageSetup.method_4();
		bool flag = false;
		if (array != null && array.Length > 0)
		{
			string text = "/printerSettings/printerSettings" + class1540_0.int_7++ + ".bin";
			string text2 = method_22("http://schemas.openxmlformats.org/officeDocument/2006/relationships/printerSettings", ".." + text);
			string_4 = text2;
			flag = true;
			hashtable_1.Add("xl" + text, array);
			if (class1540_0.bool_3)
			{
				Class1530 @class = new Class1530();
				@class.string_1 = "/xl" + text;
				@class.string_2 = "application/vnd.openxmlformats-officedocument.spreadsheetml.printerSettings";
				@class.bool_0 = false;
				class1540_0.arrayList_4.Add(@class);
			}
		}
		if (worksheet_0.class1557_0 != null && worksheet_0.class1557_0.hashtable_1 != null && worksheet_0.class1557_0.hashtable_1.Count > 0)
		{
			IEnumerator enumerator = worksheet_0.class1557_0.hashtable_1.Keys.GetEnumerator();
			while (enumerator.MoveNext())
			{
				string key = (string)enumerator.Current;
				string text3 = "/printerSettings/printerSettings" + class1540_0.int_7++ + ".bin";
				string value = method_22("http://schemas.openxmlformats.org/officeDocument/2006/relationships/printerSettings", ".." + text3);
				hashtable_0.Add(key, value);
				hashtable_1.Add("xl" + text3, worksheet_0.class1557_0.hashtable_1[key]);
				if (class1540_0.bool_3)
				{
					Class1530 class2 = new Class1530();
					class2.string_1 = "/xl" + text3;
					class2.string_2 = "application/vnd.openxmlformats-officedocument.spreadsheetml.printerSettings";
					class2.bool_0 = false;
					class1540_0.arrayList_4.Add(class2);
				}
			}
			flag = true;
		}
		if (!flag || class1540_0.bool_3)
		{
			return;
		}
		int num = 0;
		while (true)
		{
			if (num < class1540_0.arrayList_4.Count)
			{
				Class1530 class3 = (Class1530)class1540_0.arrayList_4[num];
				if (!class3.bool_0 || !(class3.string_2 == "application/vnd.openxmlformats-officedocument.spreadsheetml.printerSettings") || class3.string_0 == null || !(class3.string_0.ToLower() == "bin"))
				{
					num++;
					continue;
				}
				break;
			}
			Class1530 class4 = new Class1530();
			class4.string_0 = "bin";
			class4.string_2 = "application/vnd.openxmlformats-officedocument.spreadsheetml.printerSettings";
			class4.bool_0 = true;
			class1540_0.arrayList_4.Add(class4);
			break;
		}
	}

	private void method_7()
	{
		if (method_17())
		{
			string_0 = "comments" + Class1618.smethod_80(int_0) + class1540_0.string_0;
			method_22("http://schemas.openxmlformats.org/officeDocument/2006/relationships/comments", "../" + string_0);
		}
	}

	private void method_8()
	{
		for (int i = 0; i < worksheet_0.Pictures.Count; i++)
		{
			Picture picture = worksheet_0.Pictures[i];
			if (picture.method_65() != null)
			{
				if (arrayList_4 == null)
				{
					arrayList_4 = new ArrayList();
				}
				Class527 @class = new Class527();
				@class.picture_0 = picture;
				if (picture.method_70() != 0)
				{
					@class.string_2 = (string)class1540_0.hashtable_0[picture.method_70()];
				}
				arrayList_4.Add(@class);
			}
		}
	}

	private void method_9()
	{
		int count = worksheet_0.OleObjects.Count;
		for (int i = 0; i < count; i++)
		{
			OleObject oleObject = worksheet_0.OleObjects[i];
			Class1538 @class = new Class1538();
			@class.oleObject_0 = oleObject;
			if (!oleObject.IsLink)
			{
				if (oleObject.method_79())
				{
					@class.string_2 = Path.GetFileName(oleObject.SourceFullName);
					@class.string_1 = method_22("http://schemas.openxmlformats.org/officeDocument/2006/relationships/package", "../embeddings/" + @class.string_2);
				}
				else
				{
					if (!oleObject.method_85() && oleObject.SourceFullName != null && !(oleObject.SourceFullName == ""))
					{
						@class.string_2 = oleObject.SourceFullName;
					}
					else
					{
						@class.string_2 = "oleObject_" + worksheet_0.Index + "_" + i + ".bin";
					}
					@class.string_1 = method_22("http://schemas.openxmlformats.org/officeDocument/2006/relationships/oleObject", "../embeddings/" + @class.string_2);
				}
			}
			if (oleObject.method_75() != -1)
			{
				@class.string_4 = (string)class1540_0.hashtable_0[oleObject.method_75()];
			}
			arrayList_3.Add(@class);
		}
	}

	private void method_10()
	{
		class1534_1 = new Class1534(this);
	}

	internal bool method_11()
	{
		int count = worksheet_0.OleObjects.Count;
		if (count > 0)
		{
			return true;
		}
		return false;
	}

	internal bool method_12()
	{
		int num = 0;
		while (true)
		{
			if (num < worksheet_0.Pictures.Count)
			{
				if (worksheet_0.Pictures[num].method_65() != null)
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	private void method_13()
	{
		if (worksheet_0.pivotTableCollection_0 != null && worksheet_0.pivotTableCollection_0.Count != 0)
		{
			for (int i = 0; i < worksheet_0.pivotTableCollection_0.Count; i++)
			{
				PivotTable key = worksheet_0.pivotTableCollection_0[i];
				int num = (int)class1540_0.hashtable_3[key];
				string string_ = "../pivotTables/pivotTable" + num + ".xml";
				method_22("http://schemas.openxmlformats.org/officeDocument/2006/relationships/pivotTable", string_);
			}
		}
	}

	private void method_14()
	{
		if (worksheet_0.class1557_0 != null)
		{
			ArrayList arrayList = worksheet_0.class1557_0.arrayList_4;
			for (int i = 0; i < arrayList.Count; i++)
			{
				Class1564 @class = (Class1564)arrayList[i];
				@class.string_0 = @class.string_1;
				method_21(@class.string_1, @class.string_2, @class.string_3);
			}
			arrayList = worksheet_0.class1557_0.arrayList_2;
			for (int j = 0; j < arrayList.Count; j++)
			{
				Class1550 class2 = (Class1550)arrayList[j];
				class2.string_3 = method_22("http://schemas.openxmlformats.org/officeDocument/2006/relationships/control", class2.string_2);
			}
		}
	}

	private void method_15()
	{
		class1358_0 = new Class1358(this);
		if (class1358_0.string_1 != null)
		{
			class1358_0.string_0 = method_22("http://schemas.openxmlformats.org/officeDocument/2006/relationships/drawing", "../drawings/" + class1358_0.string_1);
		}
	}

	private void method_16()
	{
		if (class1540_0.hashtable_1 == null || class1540_0.hashtable_1.Count == 0)
		{
			return;
		}
		class1534_0 = new Class1534();
		ShapeCollection shapeCollection = worksheet_0.PageSetup.method_32();
		if (shapeCollection == null || shapeCollection.Count == 0)
		{
			return;
		}
		foreach (Shape item in shapeCollection)
		{
			Picture picture = (Picture)item;
			if (class1540_0.hashtable_1.ContainsKey(picture.method_70()) && !class1534_0.hashtable_0.ContainsKey(picture.method_70()))
			{
				string text = "../media/" + (string)class1540_0.hashtable_1[picture.method_70()];
				string value = class1534_0.method_4("http://schemas.openxmlformats.org/officeDocument/2006/relationships/image", text);
				class1534_0.hashtable_0.Add(picture.method_70(), value);
			}
		}
		if (class1534_0.arrayList_0.Count == 0)
		{
			class1534_0 = new Class1534();
			return;
		}
		class1534_0.string_1 = "vmlDrawing" + Class1618.smethod_80(class1540_0.method_2()) + ".vml";
		string string_ = "../drawings/" + class1534_0.string_1;
		class1534_0.string_0 = method_22("http://schemas.openxmlformats.org/officeDocument/2006/relationships/vmlDrawing", string_);
	}

	internal bool method_17()
	{
		if (worksheet_0.Comments != null)
		{
			return worksheet_0.Comments.Count > 0;
		}
		return false;
	}

	internal bool method_18()
	{
		if (class1534_1.arrayList_1.Count > 0)
		{
			return true;
		}
		return false;
	}

	internal bool method_19()
	{
		if (worksheet_0.class1557_0 != null)
		{
			return worksheet_0.class1557_0.string_2 != null;
		}
		return false;
	}

	private void method_20()
	{
		if (worksheet_0.Hyperlinks == null || worksheet_0.Hyperlinks.Count < 1)
		{
			return;
		}
		int count = worksheet_0.Hyperlinks.Count;
		arrayList_0 = new ArrayList(count);
		for (int i = 0; i < count; i++)
		{
			Hyperlink hyperlink = worksheet_0.Hyperlinks[i];
			Class1537 @class = new Class1537();
			@class.hyperlink_0 = hyperlink;
			@class.int_0 = hyperlink.method_5(workbook_0.Worksheets);
			if (@class.int_0 == 0 || @class.int_0 == 1)
			{
				string text = hyperlink.Address.Replace(" ", "%20");
				if (@class.int_0 == 1 && text.IndexOf(":") != -1)
				{
					text = "file:///" + text;
				}
				@class.string_0 = method_23("http://schemas.openxmlformats.org/officeDocument/2006/relationships/hyperlink", text, "External");
			}
			arrayList_0.Add(@class);
		}
	}

	internal void method_21(string string_5, string string_6, string string_7)
	{
		int num = int.Parse(string_5.Substring(3, string_5.Length - 3));
		arrayList_2.Add(num);
		Class1564 value = new Class1564(string_5, string_6, string_7, null);
		arrayList_1.Add(value);
	}

	internal string method_22(string string_5, string string_6)
	{
		string text = "rId" + method_24();
		Class1564 value = new Class1564(text, string_5, string_6, null);
		arrayList_1.Add(value);
		return text;
	}

	private string method_23(string string_5, string string_6, string string_7)
	{
		string text = "rId" + method_24();
		Class1564 value = new Class1564(text, string_5, string_6, string_7);
		arrayList_1.Add(value);
		return text;
	}

	private int method_24()
	{
		int num = ++int_2;
		while (arrayList_2.Contains(num))
		{
			num = ++int_2;
		}
		return num;
	}
}
