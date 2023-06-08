using System;
using System.Collections;
using System.Drawing;
using System.IO;
using Aspose.Cells;
using Aspose.Cells.Charts;
using Aspose.Cells.Drawing;

namespace ns16;

internal class Class1358
{
	internal string string_0;

	internal string string_1;

	internal ArrayList arrayList_0 = new ArrayList();

	internal Hashtable hashtable_0 = new Hashtable();

	internal Hashtable hashtable_1 = new Hashtable();

	internal ArrayList arrayList_1 = new ArrayList();

	internal Class1540 class1540_0;

	internal Class1541 class1541_0;

	internal Chart chart_0;

	internal Shape[] shape_0;

	internal int int_0 = 1;

	internal ArrayList arrayList_2 = new ArrayList();

	internal int method_0(Shape shape_1)
	{
		if (shape_1.class1556_0 != null && shape_1.class1556_0.int_2 != -1)
		{
			return shape_1.class1556_0.int_2;
		}
		return int_0++;
	}

	internal Class1358(Class1533 class1533_0)
	{
		class1540_0 = class1533_0.class1540_0;
		chart_0 = class1533_0.chart_0;
		method_1(chart_0.method_16());
		shape_0 = method_4();
		if (shape_0 != null && shape_0.Length > 0)
		{
			string_1 = "drawing" + Class1618.smethod_80(class1540_0.method_3()) + ".xml";
		}
	}

	internal Class1358(Class1541 class1541_1)
	{
		class1541_0 = class1541_1;
		class1540_0 = class1541_1.class1540_0;
		Worksheet worksheet_ = class1541_1.worksheet_0;
		if (worksheet_.Type == SheetType.Chart)
		{
			Chart chart_ = worksheet_.Charts[0];
			method_6(chart_);
			string_1 = "drawing" + Class1618.smethod_80(class1540_0.method_3()) + ".xml";
		}
		else
		{
			method_1(worksheet_.method_36());
			shape_0 = method_4();
			if (shape_0 != null && shape_0.Length > 0)
			{
				string_1 = "drawing" + Class1618.smethod_80(class1540_0.method_3()) + ".xml";
			}
		}
		if (arrayList_0.Count == 0)
		{
			hashtable_0 = null;
		}
	}

	private void method_1(ShapeCollection shapeCollection_0)
	{
		if (shapeCollection_0 != null)
		{
			ArrayList arrayList = shapeCollection_0.method_0();
			if (arrayList != null && arrayList.Count > 0)
			{
				arrayList_0.AddRange(arrayList);
			}
		}
	}

	internal string method_2(byte[] byte_0)
	{
		if (byte_0 != null && byte_0.Length != 0)
		{
			Class1357 @class = new Class1357();
			@class.byte_0 = byte_0;
			Image image = Image.FromStream(new MemoryStream(byte_0));
			@class.string_0 = Class1618.smethod_45("image", class1540_0.method_5(), image.RawFormat);
			arrayList_2.Add(@class);
			@class.string_1 = method_8("http://schemas.openxmlformats.org/officeDocument/2006/relationships/image", "../media/" + @class.string_0, null);
			return @class.string_1;
		}
		return null;
	}

	private ShapeCollection method_3()
	{
		if (chart_0 != null)
		{
			return chart_0.method_16();
		}
		return class1541_0.worksheet_0.method_36();
	}

	private Shape[] method_4()
	{
		ShapeCollection shapeCollection = method_3();
		if (shapeCollection != null && shapeCollection.Count != 0)
		{
			int count = shapeCollection.Count;
			Shape[] array = new Shape[count];
			int num = 0;
			foreach (Shape item in shapeCollection)
			{
				if (item.class1556_0 != null && item.class1556_0.string_0 != null)
				{
					continue;
				}
				if (item.MsoDrawingType == MsoDrawingType.Picture)
				{
					Picture picture = (Picture)item;
					if (picture.method_65() != null && picture.method_65().Length > 0)
					{
						continue;
					}
					if (item.class1556_0 == null || item.class1556_0.string_3 == null)
					{
						if (picture.method_74())
						{
							if (!hashtable_0.ContainsKey(picture.SourceFullName))
							{
								string value = method_8("http://schemas.openxmlformats.org/officeDocument/2006/relationships/image", picture.SourceFullName, "External");
								hashtable_0.Add(picture.SourceFullName, value);
							}
						}
						else if (picture.method_70() == 0)
						{
							if (!hashtable_0.ContainsKey(picture.method_70()))
							{
								string string_ = "NULL";
								string value2 = method_8("http://schemas.openxmlformats.org/officeDocument/2006/relationships/image", string_, null);
								hashtable_0.Add(picture.method_70(), value2);
							}
						}
						else
						{
							if (!class1540_0.hashtable_0.ContainsKey(picture.method_70()))
							{
								continue;
							}
							if (!hashtable_0.ContainsKey(picture.method_70()))
							{
								string string_2 = "../media/" + (string)class1540_0.hashtable_0[picture.method_70()];
								string value3 = method_8("http://schemas.openxmlformats.org/officeDocument/2006/relationships/image", string_2, null);
								hashtable_0.Add(picture.method_70(), value3);
							}
						}
					}
					method_7(picture.Hyperlink);
				}
				else if (item.MsoDrawingType == MsoDrawingType.Chart)
				{
					Chart chart = ((ChartShape)item).Chart;
					method_6(chart);
				}
				if (item.Hyperlink != null)
				{
					method_7(item.Hyperlink);
				}
				if (!item.method_33() && (Class1618.smethod_233(item) || item.MsoDrawingType == MsoDrawingType.Picture || item.MsoDrawingType == MsoDrawingType.Chart || item.MsoDrawingType == MsoDrawingType.TextBox || item.MsoDrawingType == MsoDrawingType.Group || item.MsoDrawingType == MsoDrawingType.Unknown || item.MsoDrawingType == MsoDrawingType.CellsDrawing || item.MsoDrawingType == MsoDrawingType.Polygon))
				{
					array[num++] = item;
					method_5(item);
				}
			}
			Shape[] array2 = new Shape[num];
			Array.Copy(array, array2, num);
			return array2;
		}
		return null;
	}

	private void method_5(Shape shape_1)
	{
		if (shape_1.class1556_0 != null && shape_1.class1556_0.int_2 >= int_0)
		{
			int_0 = shape_1.class1556_0.int_2 + 1;
		}
	}

	private void method_6(Chart chart_1)
	{
		Class1533 @class = new Class1533(class1540_0, chart_1);
		class1540_0.int_0++;
		@class.int_0 = class1540_0.int_0;
		string string_ = "../charts/chart" + Class1618.smethod_80(@class.int_0) + ".xml";
		@class.string_0 = method_8("http://schemas.openxmlformats.org/officeDocument/2006/relationships/chart", string_, null);
		arrayList_1.Add(@class);
	}

	private void method_7(Hyperlink hyperlink_0)
	{
		if (hyperlink_0 == null)
		{
			return;
		}
		string text = null;
		int num = hyperlink_0.method_5(class1540_0.workbook_0.Worksheets);
		if (num != 0 && num != 1)
		{
			text = method_8("http://schemas.openxmlformats.org/officeDocument/2006/relationships/hyperlink", "#" + hyperlink_0.Address, null);
		}
		else
		{
			string text2 = hyperlink_0.Address.Replace(" ", "%20");
			if (num == 1 && text2.IndexOf(":") != -1)
			{
				text2 = "file:///" + text2;
			}
			text = method_8("http://schemas.openxmlformats.org/officeDocument/2006/relationships/hyperlink", text2, "External");
		}
		hashtable_1[hyperlink_0] = text;
	}

	internal string method_8(string string_2, string string_3, string string_4)
	{
		string text = "rId" + method_9();
		Class1564 value = new Class1564(text, string_2, string_3, string_4);
		arrayList_0.Add(value);
		return text;
	}

	private int method_9()
	{
		int num = arrayList_0.Count;
		int count = arrayList_0.Count;
		for (int i = 0; i < count; i++)
		{
			Class1564 @class = (Class1564)arrayList_0[i];
			try
			{
				int num2 = Class1618.smethod_87(@class.string_1.Substring(3));
				if (num2 > num)
				{
					num = num2;
				}
			}
			catch
			{
			}
		}
		return num + 1;
	}
}
