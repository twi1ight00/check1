using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Aspose.Cells;
using Aspose.Cells.Charts;
using Aspose.Cells.Drawing;
using Aspose.Cells.Rendering;
using ns16;
using ns2;

namespace ns8;

internal class Class1482
{
	private Worksheet worksheet_0;

	private ArrayList arrayList_0;

	private ArrayList arrayList_1;

	private ArrayList arrayList_2;

	private ArrayList arrayList_3;

	private int int_0;

	private int int_1 = -1;

	private ArrayList arrayList_4 = new ArrayList();

	private Class1478 class1478_0;

	private Hashtable hashtable_0;

	private string string_0;

	internal Class1482(Class1478 class1478_1, Worksheet worksheet_1, Class1487 class1487_0, string string_1, string string_2, string string_3, string string_4, HtmlSaveOptions htmlSaveOptions_0)
	{
		hashtable_0 = new Hashtable(worksheet_1.Cells.Columns.Count);
		worksheet_0 = worksheet_1;
		class1478_0 = class1478_1;
		int_0 = method_7();
		int_1 = method_8();
		method_17();
		method_15();
		method_16();
		method_12();
		if (class1478_0.string_5 != null)
		{
			method_3(class1487_0, string_1, string_2, string_3, string_4, htmlSaveOptions_0);
		}
		string_0 = string_2;
	}

	[SpecialName]
	internal Worksheet method_0()
	{
		return worksheet_0;
	}

	[SpecialName]
	internal int method_1()
	{
		return int_1;
	}

	[SpecialName]
	internal int method_2()
	{
		return int_0;
	}

	private void method_3(Class1487 class1487_0, string string_1, string string_2, string string_3, string string_4, HtmlSaveOptions htmlSaveOptions_0)
	{
		ShapeCollection shapeCollection = worksheet_0.method_36();
		if (shapeCollection == null || shapeCollection.Count == 0)
		{
			return;
		}
		string text = "";
		IExportObjectListener exportObjectListener = class1478_0.method_2().ExportObjectListener;
		if (exportObjectListener == null)
		{
			text = class1478_0.method_17(string_1);
		}
		arrayList_3 = new ArrayList();
		Hashtable hashtable = class1478_0.method_5();
		for (int i = 0; i < shapeCollection.Count; i++)
		{
			Shape shape = shapeCollection[i];
			if (shape.method_33())
			{
				continue;
			}
			string text2 = null;
			if (exportObjectListener != null)
			{
				object obj = exportObjectListener.ExportObject(new ExportObjectEvent(shape));
				if (obj != null && obj is string)
				{
					text2 = (string)obj;
				}
			}
			else
			{
				switch (shape.MsoDrawingType)
				{
				case MsoDrawingType.Oval:
				{
					Oval shape_2 = (Oval)shape;
					text2 = "Oval_" + worksheet_0.Name + "_" + Class1618.smethod_80(i) + "." + method_5(htmlSaveOptions_0.ExportChartImageFormat);
					text2 = Class1486.smethod_7(text2);
					method_4(class1487_0, shape_2, htmlSaveOptions_0, text, string_2, text2);
					text2 = text + text2;
					break;
				}
				case MsoDrawingType.Chart:
				{
					Chart chart = ((ChartShape)shape).method_69();
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
							continue;
						}
					}
					catch
					{
						continue;
					}
					text2 = "Chart" + worksheet_0.Name + "_" + Class1618.smethod_80(i) + "." + method_5(htmlSaveOptions_0.ExportChartImageFormat);
					text2 = Class1486.smethod_7(text2);
					if (class1487_0.method_1() == SaveFormat.Html)
					{
						if (!class1478_0.method_2().ExportImagesAsBase64)
						{
							Directory.CreateDirectory(class1478_0.string_5);
							string filename = class1478_0.string_5 + text2;
							bitmap.Save(filename, htmlSaveOptions_0.ExportChartImageFormat);
						}
					}
					else
					{
						MemoryStream memoryStream = new MemoryStream();
						ImageOrPrintOptions imageOrPrintOptions = new ImageOrPrintOptions();
						imageOrPrintOptions.ChartImageType = htmlSaveOptions_0.ExportChartImageFormat;
						imageOrPrintOptions.ImageFormat = htmlSaveOptions_0.ExportChartImageFormat;
						chart.ToImage(memoryStream, imageOrPrintOptions);
						byte[] value = memoryStream.ToArray();
						class1487_0.method_3().Add(string_2 + text.Replace("\\", "/") + text2, value);
					}
					text2 = text + text2;
					break;
				}
				case MsoDrawingType.Group:
				{
					ImageOrPrintOptions options = new ImageOrPrintOptions();
					Bitmap bitmap2;
					try
					{
						bitmap2 = shape.ToImage(options);
						if (bitmap2 == null)
						{
							continue;
						}
					}
					catch
					{
						continue;
					}
					text2 = "Group" + worksheet_0.Name + "_" + Class1618.smethod_80(i) + ".jpg";
					text2 = Class1486.smethod_7(text2);
					if (class1487_0.method_1() == SaveFormat.Html)
					{
						if (!class1478_0.method_2().ExportImagesAsBase64)
						{
							Directory.CreateDirectory(class1478_0.string_5);
							string filename2 = class1478_0.string_5 + text2;
							bitmap2.Save(filename2, ImageFormat.Jpeg);
						}
					}
					else
					{
						MemoryStream memoryStream2 = new MemoryStream();
						ImageOrPrintOptions imageOrPrintOptions2 = new ImageOrPrintOptions();
						imageOrPrintOptions2.ChartImageType = ImageFormat.Jpeg;
						imageOrPrintOptions2.ImageFormat = ImageFormat.Jpeg;
						shape.ToImage(memoryStream2, imageOrPrintOptions2);
						byte[] value2 = memoryStream2.ToArray();
						class1487_0.method_3().Add(string_2 + text.Replace("\\", "/") + text2, value2);
					}
					text2 = text + text2;
					break;
				}
				case MsoDrawingType.CellsDrawing:
				{
					CellsDrawing shape_3 = (CellsDrawing)shape;
					text2 = "CellsDrawing_" + worksheet_0.Name + "_" + Class1618.smethod_80(i) + "." + method_5(htmlSaveOptions_0.ExportChartImageFormat);
					text2 = Class1486.smethod_7(text2);
					method_4(class1487_0, shape_3, htmlSaveOptions_0, text, string_2, text2);
					text2 = text + text2;
					break;
				}
				case MsoDrawingType.OleObject:
					if (hashtable != null && hashtable.Count > 0)
					{
						object obj4 = hashtable[((OleObject)shape).method_75() - 1];
						if (obj4 != null)
						{
							text2 = (string)obj4;
						}
					}
					break;
				case MsoDrawingType.Picture:
					if (hashtable != null && hashtable.Count > 0)
					{
						object obj2 = hashtable[((Picture)shape).method_70() - 1];
						if (obj2 != null)
						{
							text2 = (string)obj2;
						}
					}
					break;
				case MsoDrawingType.CheckBox:
					text2 = text + method_6(class1487_0, string_2, text, shape, i);
					break;
				case MsoDrawingType.RadioButton:
				{
					RadioButton shape_ = (RadioButton)shape;
					text2 = "RadioButton_" + worksheet_0.Name + "_" + Class1618.smethod_80(i) + "." + method_5(htmlSaveOptions_0.ExportChartImageFormat);
					text2 = Class1486.smethod_7(text2);
					method_4(class1487_0, shape_, htmlSaveOptions_0, text, string_2, text2);
					text2 = text + text2;
					break;
				}
				}
			}
			if (text2 != null)
			{
				arrayList_3.Add(new Class315(shape, i, text2));
			}
		}
		int count = arrayList_3.Count;
		Class315[] array = new Class315[count];
		for (int j = 0; j < count; j++)
		{
			Class315 @class = (Class315)arrayList_3[j];
			array[j] = @class;
		}
		IComparer comparer = new Class1481();
		Array.Sort(array, comparer);
		arrayList_3 = new ArrayList(count);
		for (int k = 0; k < count; k++)
		{
			arrayList_3.Add(array[k]);
		}
	}

	private void method_4(Class1487 class1487_0, Shape shape_0, HtmlSaveOptions htmlSaveOptions_0, string string_1, string string_2, string string_3)
	{
		if (class1487_0.method_1() == SaveFormat.Html)
		{
			if (!htmlSaveOptions_0.ExportImagesAsBase64)
			{
				Directory.CreateDirectory(class1478_0.string_5);
				string filename = class1478_0.string_5 + string_3;
				ImageOrPrintOptions imageOrPrintOptions = new ImageOrPrintOptions();
				imageOrPrintOptions.ChartImageType = htmlSaveOptions_0.ExportChartImageFormat;
				imageOrPrintOptions.ImageFormat = htmlSaveOptions_0.ExportChartImageFormat;
				shape_0.ToImage(imageOrPrintOptions)?.Save(filename, htmlSaveOptions_0.ExportChartImageFormat);
			}
		}
		else
		{
			MemoryStream memoryStream = new MemoryStream();
			ImageOrPrintOptions imageOrPrintOptions2 = new ImageOrPrintOptions();
			imageOrPrintOptions2.ChartImageType = htmlSaveOptions_0.ExportChartImageFormat;
			imageOrPrintOptions2.ImageFormat = htmlSaveOptions_0.ExportChartImageFormat;
			shape_0.ToImage(memoryStream, imageOrPrintOptions2);
			byte[] value = memoryStream.ToArray();
			class1487_0.method_3().Add(string_2 + string_1.Replace("\\", "/") + string_3, value);
		}
	}

	private string method_5(ImageFormat imageFormat_0)
	{
		return imageFormat_0.ToString();
	}

	private string method_6(Class1487 class1487_0, string string_1, string string_2, Shape shape_0, int int_2)
	{
		ImageOrPrintOptions imageOrPrintOptions = new ImageOrPrintOptions();
		imageOrPrintOptions.ImageFormat = ImageFormat.Png;
		string text = "CheckBox" + worksheet_0.Name + "_" + Class1618.smethod_80(int_2) + ".png";
		text = Class1486.smethod_7(text);
		Bitmap bitmap;
		try
		{
			bitmap = shape_0.ToImage(imageOrPrintOptions);
			if (bitmap == null)
			{
				return null;
			}
		}
		catch
		{
			return null;
		}
		if (class1487_0.method_1() == SaveFormat.Html)
		{
			if (!class1478_0.method_2().ExportImagesAsBase64)
			{
				Directory.CreateDirectory(class1478_0.string_5);
				string filename = class1478_0.string_5 + text;
				bitmap.Save(filename, ImageFormat.Png);
			}
		}
		else
		{
			MemoryStream memoryStream = new MemoryStream();
			ImageOrPrintOptions imageOrPrintOptions2 = new ImageOrPrintOptions();
			imageOrPrintOptions2.ChartImageType = ImageFormat.Png;
			imageOrPrintOptions2.ImageFormat = ImageFormat.Png;
			shape_0.ToImage(memoryStream, imageOrPrintOptions2);
			byte[] value = memoryStream.ToArray();
			class1487_0.method_3().Add(string_1 + string_2.Replace("\\", "/") + text, value);
		}
		return text;
	}

	private int method_7()
	{
		Cells cells = worksheet_0.Cells;
		int num = cells.method_20(0);
		if (cells.Rows.Count > 0)
		{
			int num2 = cells.Rows.GetRowByIndex(cells.Rows.Count - 1).int_0;
			if (num2 > num)
			{
				num = num2;
			}
		}
		Class1133 @class = worksheet_0.Cells.method_18();
		if (@class != null && @class.Count > 0)
		{
			CellArea cellArea = @class[@class.Count - 1];
			if (num < cellArea.EndRow)
			{
				num = cellArea.EndRow;
			}
		}
		ShapeCollection shapeCollection = worksheet_0.method_36();
		if (shapeCollection != null && shapeCollection.Count > 0)
		{
			for (int i = 0; i < shapeCollection.Count; i++)
			{
				Shape shape = shapeCollection[i];
				int lowerRightRow = shape.LowerRightRow;
				if (lowerRightRow > num)
				{
					num = lowerRightRow;
				}
			}
		}
		return num;
	}

	private int method_8()
	{
		Cells cells = worksheet_0.Cells;
		int num = cells.method_22(0);
		for (int i = 0; i < cells.Rows.Count; i++)
		{
			Row rowByIndex = cells.Rows.GetRowByIndex(i);
			int num2 = rowByIndex.method_0() - 1;
			while (num2 >= 0)
			{
				Cell cellByIndex = rowByIndex.GetCellByIndex(num2);
				Style style = cellByIndex.method_32();
				if (cellByIndex.Type == CellValueType.IsNull)
				{
					if (style == null || !Class1486.smethod_0(style, class1478_0.method_7()))
					{
						num2--;
						continue;
					}
					if (num < cellByIndex.Column)
					{
						num = cellByIndex.Column;
					}
					break;
				}
				int num3 = cellByIndex.Column;
				if (!style.IsTextWrapped && cellByIndex.Type == CellValueType.IsString)
				{
					string stringValue = cellByIndex.StringValue;
					new StringBuilder(stringValue.Length + 100);
					int num4 = 0;
					if (cellByIndex.IsRichText())
					{
						ArrayList arrayList = cellByIndex.method_69();
						for (int j = 0; j < arrayList.Count; j++)
						{
							Class1544 @class = (Class1544)arrayList[j];
							@class.int_0 = class1478_0.method_3().method_1(@class.font_0, @class.string_0);
							num4 += @class.int_0;
						}
					}
					else
					{
						num4 = class1478_0.method_3().method_0(cellByIndex.method_32(), stringValue);
					}
					int num5 = 0;
					for (int k = num3; k <= 255; k++)
					{
						num5 += GetColumnWidthPixel(k);
						if (num5 > num4 + 5)
						{
							num3 = k;
							break;
						}
					}
				}
				if (num < num3)
				{
					num = num3;
				}
				break;
			}
		}
		Class1133 class2 = worksheet_0.Cells.method_18();
		if (class2 != null)
		{
			for (int l = 0; l < class2.Count; l++)
			{
				CellArea cellArea = class2[l];
				if (num < cellArea.EndColumn)
				{
					num = cellArea.EndColumn;
				}
			}
		}
		ShapeCollection shapeCollection = worksheet_0.method_36();
		if (shapeCollection != null && shapeCollection.Count > 0)
		{
			int num6 = 0;
			for (int m = 0; m < shapeCollection.Count; m++)
			{
				Shape shape = shapeCollection[m];
				num6 = shape.LowerRightColumn;
				if (num6 > num)
				{
					num = num6;
				}
			}
		}
		return num;
	}

	private Class1477 method_9(Column column_0)
	{
		Class1477 @class = new Class1477();
		@class.int_0 = column_0.Index;
		@class.int_3 = column_0.method_5();
		@class.style_0 = column_0.method_13();
		@class.int_2 = GetColumnWidthPixel(column_0.Index);
		if (column_0.IsHidden || column_0.method_14())
		{
			@class.bool_0 = true;
			@class.int_2 = 0;
		}
		if (column_0.method_5() == 15 && @class.int_2 == worksheet_0.Cells.StandardWidthPixels)
		{
			@class.bool_1 = true;
		}
		return @class;
	}

	private Class1477 method_10(int int_2)
	{
		Class1477 @class = new Class1477();
		@class.int_0 = int_2;
		@class.int_3 = 15;
		@class.style_0 = worksheet_0.Workbook.DefaultStyle;
		@class.int_2 = worksheet_0.Cells.StandardWidthPixels;
		@class.bool_1 = true;
		return @class;
	}

	private Class1477 method_11(int int_2)
	{
		int num = worksheet_0.Cells.Columns.method_7(int_2);
		if (num == -1)
		{
			return method_10(int_2);
		}
		Column columnByIndex = worksheet_0.Cells.Columns.GetColumnByIndex(num);
		return method_9(columnByIndex);
	}

	private void method_12()
	{
		Class1477 @class = null;
		for (int i = 0; i <= int_1; i++)
		{
			Class1477 class2 = method_11(i);
			if (@class != null && @class.method_0(class2))
			{
				@class.int_1++;
				continue;
			}
			if (@class != null)
			{
				arrayList_4.Add(@class);
			}
			@class = class2;
		}
		if (@class != null)
		{
			arrayList_4.Add(@class);
		}
	}

	[SpecialName]
	internal ArrayList method_13()
	{
		return arrayList_4;
	}

	internal long method_14()
	{
		long num = 0L;
		for (int i = 0; i <= int_1; i++)
		{
			num += GetColumnWidthPixel(i);
		}
		return num;
	}

	private void method_15()
	{
		HyperlinkCollection hyperlinks = worksheet_0.Cells.Hyperlinks;
		int count = hyperlinks.Count;
		if (count == 0)
		{
			arrayList_1 = null;
			return;
		}
		Hyperlink[] array = new Hyperlink[count];
		for (int i = 0; i < count; i++)
		{
			Hyperlink hyperlink = hyperlinks[i];
			array[i] = hyperlink;
		}
		IComparer comparer = new Class1479();
		Array.Sort(array, comparer);
		arrayList_1 = new ArrayList(count);
		for (int j = 0; j < count; j++)
		{
			arrayList_1.Add(array[j]);
		}
	}

	private void method_16()
	{
		ArrayList arrayList = class1478_0.method_15();
		int count = arrayList.Count;
		if (count == 0)
		{
			arrayList_2 = null;
			return;
		}
		CellArea[] array = new CellArea[count];
		int num = 0;
		for (int i = 0; i < count; i++)
		{
			string sheetName = null;
			Hyperlink href = (Hyperlink)arrayList[i];
			if (Class1486.smethod_13(class1478_0.workbook_0.Worksheets, href, out sheetName, out var ca) && sheetName == worksheet_0.Name)
			{
				array[num] = ca;
				num++;
			}
		}
		if (num != 0)
		{
			IComparer comparer = new Class1476();
			Array.Sort(array, 0, num, comparer);
			arrayList_2 = new ArrayList(num);
			for (int j = 0; j < num; j++)
			{
				arrayList_2.Add(array[j]);
			}
		}
	}

	private void method_17()
	{
		Class1133 @class = worksheet_0.Cells.method_18();
		int count = @class.Count;
		if (count == 0)
		{
			arrayList_0 = null;
			return;
		}
		CellArea[] array = new CellArea[count];
		for (int i = 0; i < count; i++)
		{
			CellArea cellArea = @class[i];
			array[i] = cellArea;
		}
		IComparer comparer = new Class1476();
		Array.Sort(array, comparer);
		arrayList_0 = new ArrayList(count);
		for (int j = 0; j < count; j++)
		{
			arrayList_0.Add(array[j]);
		}
	}

	private void method_18(Class1480 class1480_0)
	{
		if (arrayList_0 == null)
		{
			return;
		}
		int num = class1480_0.method_3();
		int count = arrayList_0.Count;
		class1480_0.arrayList_0 = new ArrayList(count);
		ArrayList arrayList = new ArrayList(count);
		for (int i = 0; i < count; i++)
		{
			CellArea cellArea = (CellArea)arrayList_0[i];
			if (num >= cellArea.StartRow && num <= cellArea.EndRow)
			{
				class1480_0.arrayList_0.Add(cellArea);
				continue;
			}
			if (num < cellArea.StartRow)
			{
				break;
			}
			if (num > cellArea.EndRow)
			{
				arrayList.Add(cellArea);
			}
		}
		for (int j = 0; j < arrayList.Count; j++)
		{
			arrayList_0.Remove(arrayList[j]);
		}
		if (arrayList_0.Count == 0)
		{
			arrayList_0 = null;
		}
	}

	private void method_19(Class1480 class1480_0)
	{
		if (arrayList_2 == null)
		{
			return;
		}
		int num = class1480_0.method_3();
		int count = arrayList_2.Count;
		class1480_0.arrayList_2 = new ArrayList(count);
		ArrayList arrayList = new ArrayList(count);
		for (int i = 0; i < count; i++)
		{
			CellArea cellArea = (CellArea)arrayList_2[i];
			if (num >= cellArea.StartRow && num <= cellArea.EndRow)
			{
				class1480_0.arrayList_2.Add(cellArea);
				continue;
			}
			if (num < cellArea.StartRow)
			{
				break;
			}
			if (num > cellArea.EndRow)
			{
				arrayList.Add(cellArea);
			}
		}
		for (int j = 0; j < arrayList.Count; j++)
		{
			arrayList_2.Remove(arrayList[j]);
		}
		if (arrayList_2.Count == 0)
		{
			arrayList_2 = null;
		}
	}

	private void method_20(Class1480 class1480_0)
	{
		if (arrayList_1 == null)
		{
			return;
		}
		int num = class1480_0.method_3();
		int count = arrayList_1.Count;
		class1480_0.arrayList_1 = new ArrayList(count);
		ArrayList arrayList = new ArrayList(count);
		for (int i = 0; i < count; i++)
		{
			Hyperlink hyperlink = (Hyperlink)arrayList_1[i];
			CellArea area = hyperlink.Area;
			if (num >= area.StartRow && num <= area.EndRow)
			{
				class1480_0.arrayList_1.Add(hyperlink);
				continue;
			}
			if (num < area.StartRow)
			{
				break;
			}
			if (num > area.EndRow)
			{
				arrayList.Add(hyperlink);
			}
		}
		for (int j = 0; j < arrayList.Count; j++)
		{
			arrayList_1.Remove(arrayList[j]);
		}
		if (arrayList_1.Count == 0)
		{
			arrayList_1 = null;
		}
	}

	private void method_21(Class1480 class1480_0)
	{
		if (arrayList_3 == null)
		{
			return;
		}
		int num = class1480_0.method_3();
		int count = arrayList_3.Count;
		class1480_0.arrayList_3 = new ArrayList(count);
		ArrayList arrayList = new ArrayList(count);
		for (int i = 0; i < count; i++)
		{
			Class315 @class = (Class315)arrayList_3[i];
			if (num == @class.method_0())
			{
				class1480_0.arrayList_3.Add(@class);
			}
			else if (num < @class.method_0())
			{
				if (class1480_0.arrayList_0 == null)
				{
					break;
				}
				for (int j = 0; j < class1480_0.arrayList_0.Count; j++)
				{
					CellArea cellArea = (CellArea)class1480_0.arrayList_0[j];
					if (cellArea.StartRow <= @class.method_0() && cellArea.EndRow >= @class.method_0() && cellArea.StartColumn <= @class.method_1() && cellArea.EndColumn >= @class.method_1())
					{
						arrayList.Add(@class);
						class1480_0.arrayList_3.Add(@class);
					}
				}
			}
			else if (num > @class.method_0())
			{
				arrayList.Add(@class);
			}
		}
		for (int k = 0; k < arrayList.Count; k++)
		{
			arrayList_3.Remove(arrayList[k]);
		}
		if (arrayList_3.Count == 0)
		{
			arrayList_3 = null;
		}
	}

	internal Class1480 method_22(Row row_0, int int_2)
	{
		Class1480 @class = new Class1480(class1478_0, this, row_0, int_2, class1478_0.method_2(), string_0);
		method_18(@class);
		method_20(@class);
		method_19(@class);
		method_21(@class);
		return @class;
	}

	internal int method_23(int int_2, int int_3)
	{
		int num = 0;
		for (int i = int_2; i < int_3; i++)
		{
			num += GetColumnWidthPixel(i);
		}
		return num;
	}

	internal int GetColumnWidthPixel(int int_2)
	{
		object obj = hashtable_0[int_2];
		if (obj != null)
		{
			return (int)obj;
		}
		int columnWidthPixel = worksheet_0.Cells.GetColumnWidthPixel(int_2);
		hashtable_0[int_2] = columnWidthPixel;
		return columnWidthPixel;
	}
}
