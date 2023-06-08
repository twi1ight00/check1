using System.Collections;
using System.IO;
using Aspose.Cells;
using Aspose.Cells.Charts;
using Aspose.Cells.Drawing;

namespace ns16;

internal class Class1558
{
	internal Workbook workbook_0;

	internal Class1553 class1553_0;

	internal ArrayList arrayList_0 = new ArrayList();

	internal bool bool_0;

	internal string string_0;

	internal bool bool_1;

	internal bool bool_2;

	internal string string_1;

	internal ArrayList arrayList_1 = new ArrayList();

	internal ArrayList arrayList_2 = new ArrayList();

	internal Class1364 class1364_0;

	internal ArrayList arrayList_3 = new ArrayList();

	internal ArrayList arrayList_4 = new ArrayList();

	internal Class1363 class1363_0 = new Class1363();

	internal bool bool_3;

	internal Class1558(Workbook workbook_1)
	{
		workbook_0 = workbook_1;
		class1364_0 = new Class1364(this);
	}

	internal void method_0()
	{
		for (int i = 0; i < arrayList_2.Count; i++)
		{
			string string_ = (string)arrayList_2[i];
			if (!method_1(string_) && !method_3(string_))
			{
				method_4(string_);
			}
		}
	}

	private bool method_1(string string_2)
	{
		string_2 = Path.GetFileName(string_2);
		for (int i = 0; i < arrayList_4.Count; i++)
		{
			Class1366 @class = (Class1366)arrayList_4[i];
			for (int j = 0; j < @class.arrayList_0.Count; j++)
			{
				Class1564 class2 = (Class1564)@class.arrayList_0[j];
				string fileName = Path.GetFileName(class2.string_3);
				if (string_2 == fileName)
				{
					return true;
				}
			}
		}
		return false;
	}

	private bool method_2(ShapeCollection shapeCollection_0, string string_2)
	{
		if (shapeCollection_0 != null)
		{
			ArrayList arrayList = shapeCollection_0.method_0();
			if (arrayList != null)
			{
				for (int i = 0; i < arrayList.Count; i++)
				{
					Class1564 @class = (Class1564)arrayList[i];
					string fileName = Path.GetFileName(@class.string_3);
					if (string_2 == fileName)
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	private bool method_3(string string_2)
	{
		string_2 = Path.GetFileName(string_2);
		WorksheetCollection worksheets = workbook_0.Worksheets;
		int num = 0;
		while (true)
		{
			if (num < worksheets.Count)
			{
				Worksheet worksheet = worksheets[num];
				if (method_2(worksheet.method_36(), string_2))
				{
					break;
				}
				if (worksheet.Charts != null)
				{
					for (int i = 0; i < worksheet.Charts.Count; i++)
					{
						Chart chart = worksheet.Charts[0];
						if (method_2(chart.method_16(), string_2))
						{
							return true;
						}
					}
				}
				if (worksheet.class1557_0 != null)
				{
					IEnumerator enumerator = worksheet.class1557_0.arrayList_10.GetEnumerator();
					while (enumerator.MoveNext())
					{
						Class1564 @class = (Class1564)enumerator.Current;
						string fileName = Path.GetFileName(@class.string_3);
						if (string_2 == fileName)
						{
							return true;
						}
					}
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	internal void method_4(string string_2)
	{
		Class1366 @class = null;
		for (int i = 0; i < arrayList_4.Count; i++)
		{
			Class1366 class2 = (Class1366)arrayList_4[i];
			if (class2.string_1 == string_2 || Path.GetFileName(class2.string_1) == string_2)
			{
				@class = class2;
				break;
			}
		}
		if (@class != null)
		{
			arrayList_4.Remove(@class);
		}
	}

	internal void method_5(ICollection icollection_0)
	{
		if (icollection_0 == null)
		{
			return;
		}
		IEnumerator enumerator = icollection_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Class1564 @class = (Class1564)enumerator.Current;
			string fileName = Path.GetFileName(@class.string_3);
			string text = Class1618.smethod_175(@class.string_3);
			ArrayList arrayList = arrayList_4;
			for (int i = 0; i < arrayList.Count; i++)
			{
				Class1366 class2 = (Class1366)arrayList[i];
				string fileName2 = Path.GetFileName(class2.string_1);
				string text2 = Class1618.smethod_175(class2.string_1);
				if (fileName == fileName2 && text == text2)
				{
					string fileName3 = Path.GetFileName(class2.string_2);
					@class.string_3 = Class1618.smethod_174(@class.string_3, fileName3);
				}
			}
		}
	}

	internal bool method_6(string string_2)
	{
		int count = arrayList_1.Count;
		int num = 0;
		while (true)
		{
			if (num < count)
			{
				string text = (string)arrayList_1[num];
				if (text == string_2)
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

	internal Class1530 method_7(string string_2)
	{
		int num = 0;
		Class1530 @class;
		while (true)
		{
			if (num < arrayList_0.Count)
			{
				@class = (Class1530)arrayList_0[num];
				if (@class.string_2 == string_2)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return @class;
	}

	internal void method_8()
	{
		class1364_0.method_0();
	}

	internal void RemoveDigitallySign()
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			Class1530 @class = (Class1530)arrayList_0[i];
			if (@class.string_2 == "application/vnd.openxmlformats-package.digital-signature-origin" || @class.string_2 == "application/vnd.openxmlformats-package.digital-signature-xmlsignature+xml")
			{
				arrayList.Add(@class);
			}
		}
		foreach (object item in arrayList)
		{
			arrayList_0.Remove(item);
		}
		arrayList.Clear();
		for (int j = 0; j < arrayList_3.Count; j++)
		{
			Class1564 class2 = (Class1564)arrayList_3[j];
			if (class2.string_2 == "http://schemas.openxmlformats.org/package/2006/relationships/digital-signature/origin")
			{
				arrayList.Add(class2);
			}
		}
		foreach (object item2 in arrayList)
		{
			arrayList_3.Remove(item2);
		}
		bool_3 = false;
	}
}
