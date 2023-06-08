using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using Aspose.Cells.Rendering;
using ns16;
using ns17;
using ns2;

namespace ns8;

internal class Class1480
{
	internal ArrayList arrayList_0;

	internal ArrayList arrayList_1;

	internal ArrayList arrayList_2;

	internal ArrayList arrayList_3;

	private int int_0 = -1;

	private Worksheet worksheet_0;

	private ArrayList arrayList_4 = new ArrayList();

	private Row row_0;

	private int int_1 = 1;

	private Class1482 class1482_0;

	private Class1478 class1478_0;

	private Class1473 class1473_0;

	internal bool bool_0;

	private HtmlSaveOptions htmlSaveOptions_0;

	private bool bool_1;

	private bool bool_2;

	private string string_0;

	internal Row Row => row_0;

	[SpecialName]
	public void method_0(string string_1)
	{
		string_0 = string_1;
	}

	internal Class1480(Class1478 class1478_1, Class1482 class1482_1, Row row_1, int int_2, HtmlSaveOptions htmlSaveOptions_1, string string_1)
	{
		class1478_0 = class1478_1;
		class1482_0 = class1482_1;
		worksheet_0 = class1482_1.method_0();
		int_0 = int_2;
		row_0 = row_1;
		class1473_0 = class1478_1.method_3();
		htmlSaveOptions_0 = htmlSaveOptions_1;
		bool_1 = htmlSaveOptions_0.HtmlCrossStringType != HtmlCrossType.Cross;
		bool_2 = htmlSaveOptions_0.HtmlCrossStringType == HtmlCrossType.FitToCell;
		string_0 = string_1;
	}

	[SpecialName]
	internal int method_1()
	{
		return int_1;
	}

	[SpecialName]
	internal void method_2(int int_2)
	{
		int_1 = int_2;
	}

	[SpecialName]
	internal int method_3()
	{
		return int_0;
	}

	[SpecialName]
	internal Class1482 method_4()
	{
		return class1482_0;
	}

	internal void method_5(Class1475 class1475_0)
	{
		method_12(class1475_0);
		if (arrayList_0 == null && arrayList_1 == null && arrayList_2 == null && arrayList_3 == null)
		{
			return;
		}
		int num = class1475_0.int_0;
		if (arrayList_0 != null)
		{
			for (int i = 0; i < arrayList_0.Count; i++)
			{
				CellArea cellArea = (CellArea)arrayList_0[i];
				if (num >= cellArea.StartColumn && num <= cellArea.EndColumn)
				{
					if (cellArea.StartRow == int_0 && cellArea.StartColumn == num)
					{
						class1475_0.bool_0 = true;
						class1475_0.int_1 = cellArea.EndRow - cellArea.StartRow + 1;
						class1475_0.int_2 = cellArea.EndColumn - cellArea.StartColumn + 1;
					}
					else
					{
						class1475_0.bool_1 = true;
					}
					break;
				}
			}
		}
		if (arrayList_1 != null)
		{
			for (int j = 0; j < arrayList_1.Count; j++)
			{
				Hyperlink hyperlink = (Hyperlink)arrayList_1[j];
				CellArea area = hyperlink.Area;
				if (num >= area.StartColumn && num <= area.EndColumn)
				{
					class1475_0.hyperlink_0 = hyperlink;
					break;
				}
			}
		}
		if (arrayList_2 != null)
		{
			for (int k = 0; k < arrayList_2.Count; k++)
			{
				CellArea cellArea_ = (CellArea)arrayList_2[k];
				if (num >= cellArea_.StartColumn && num <= cellArea_.EndColumn)
				{
					class1475_0.string_0 = Class1486.smethod_14(cellArea_);
					break;
				}
			}
		}
		if (arrayList_3 == null)
		{
			return;
		}
		for (int l = 0; l < arrayList_3.Count; l++)
		{
			Class315 @class = (Class315)arrayList_3[l];
			if (@class.method_1() == num || (class1475_0.bool_0 && @class.method_1() >= class1475_0.int_0 && @class.method_1() <= class1475_0.int_0 + class1475_0.int_2 - 1))
			{
				if (class1475_0.arrayList_0 == null)
				{
					class1475_0.arrayList_0 = new ArrayList();
				}
				class1475_0.arrayList_0.Add(@class);
			}
		}
	}

	internal void method_6(Cell cell_0)
	{
		method_7(cell_0.Column - 1);
		int count = arrayList_4.Count;
		Class1484 @class = null;
		if (count > 0)
		{
			@class = (Class1484)arrayList_4[count - 1];
		}
		Class1475 class2 = new Class1475(cell_0);
		method_5(class2);
		if (class2.bool_1 || class2.bool_0)
		{
			if (@class != null)
			{
				@class.bool_0 = false;
			}
			if (class2.bool_1)
			{
				return;
			}
		}
		if (@class != null && @class.bool_3 && (@class.int_4 == -1 || @class.int_4 >= class2.int_0) && method_13(@class, class2) && @class.int_3 == -1)
		{
			@class.int_1++;
		}
		else
		{
			method_9(class2);
		}
	}

	internal void method_7(int int_2)
	{
		int num = 0;
		int count = arrayList_4.Count;
		Class1484 @class = null;
		if (count > 0)
		{
			@class = (Class1484)arrayList_4[count - 1];
			num = @class.int_0 + @class.int_1;
		}
		for (int i = num; i <= int_2; i++)
		{
			Class1475 class2 = new Class1475(i);
			method_5(class2);
			if (class2.bool_1 || class2.bool_0)
			{
				if (@class != null)
				{
					@class.bool_0 = false;
				}
				if (class2.bool_1)
				{
					continue;
				}
			}
			if (@class != null && @class.bool_3 && (@class.int_4 == -1 || @class.int_4 >= class2.int_0) && method_13(@class, class2))
			{
				@class.int_1++;
			}
			else
			{
				@class = method_9(class2);
			}
		}
	}

	private void method_8(Class1484 class1484_0)
	{
		if (class1484_0.bool_2)
		{
			class1484_0.bool_3 = false;
			return;
		}
		Cell cell_ = class1484_0.cell_0;
		if (cell_ != null && cell_.Type != CellValueType.IsNull)
		{
			Style style_ = class1484_0.style_0;
			if (style_ != null && (style_.IsTextWrapped || style_.HorizontalAlignment == TextAlignmentType.Justify || style_.RotationAngle == 255 || style_.RotationAngle == 90))
			{
				class1484_0.bool_3 = false;
				return;
			}
			if (!bool_2 && cell_.method_57() != null && cell_.Type == CellValueType.IsString)
			{
				string stringValue = cell_.StringValue;
				new StringBuilder(stringValue.Length + 100);
				int num = 0;
				if (cell_.IsRichText())
				{
					ArrayList arrayList = cell_.method_69();
					for (int i = 0; i < arrayList.Count; i++)
					{
						Class1544 @class = (Class1544)arrayList[i];
						@class.int_0 = class1473_0.method_1(@class.font_0, @class.string_0);
						num += @class.int_0;
					}
				}
				else
				{
					num = class1473_0.method_0(class1484_0.style_0, stringValue);
				}
				int num2 = 0;
				for (int j = class1484_0.int_0; j <= class1482_0.method_1(); j++)
				{
					num2 += class1482_0.GetColumnWidthPixel(j);
					if (num2 > num + 3)
					{
						if (j > class1484_0.int_0)
						{
							class1484_0.bool_3 = true;
							class1484_0.int_4 = j;
						}
						return;
					}
				}
			}
			class1484_0.bool_3 = false;
		}
		else
		{
			class1484_0.bool_3 = true;
		}
	}

	private Class1484 method_9(Class1475 class1475_0)
	{
		Class1484 @class = new Class1484(this);
		arrayList_4.Add(@class);
		@class.cell_0 = class1475_0.cell_0;
		@class.int_0 = class1475_0.int_0;
		@class.int_3 = class1475_0.int_3;
		@class.style_0 = class1475_0.style_0;
		@class.bool_1 = class1475_0.bool_2;
		@class.int_1 = class1475_0.int_2;
		@class.int_2 = class1475_0.int_1;
		@class.hyperlink_0 = class1475_0.hyperlink_0;
		@class.bool_2 = class1475_0.bool_0;
		@class.arrayList_0 = class1475_0.arrayList_0;
		@class.string_0 = class1475_0.string_0;
		method_8(@class);
		if (@class.bool_2)
		{
			method_10(@class);
		}
		return @class;
	}

	private void method_10(Class1484 class1484_0)
	{
		if (!class1484_0.bool_2)
		{
			return;
		}
		int column = class1484_0.int_0 + class1484_0.int_1 - 1;
		int row = method_3() + class1484_0.int_2 - 1;
		Cell cell = worksheet_0.Cells.CheckCell(row, column);
		if (cell == null)
		{
			return;
		}
		Style style = cell.method_32();
		if (style == null)
		{
			return;
		}
		BorderCollection borderCollection = style.method_4();
		if (borderCollection != null)
		{
			Border border = borderCollection[BorderType.RightBorder];
			Border border2 = borderCollection[BorderType.BottomBorder];
			if (border.LineStyle != 0)
			{
				class1484_0.border_0 = border;
			}
			if (border2.LineStyle != 0)
			{
				class1484_0.border_1 = border2;
			}
		}
	}

	private void method_11(Class1475 class1475_0)
	{
		if (class1475_0.cell_0 != null && worksheet_0.conditionalFormattingCollection_0 != null && worksheet_0.conditionalFormattingCollection_0.Count != 0)
		{
			Class314 @class = Class1627.smethod_0(worksheet_0, class1475_0.cell_0, class1475_0.style_0, bool_0: true);
			class1475_0.style_0 = @class.style_1;
			Style style_ = @class.style_0;
			if (style_ != null)
			{
				class1475_0.bool_2 = true;
			}
		}
	}

	private void method_12(Class1475 class1475_0)
	{
		if (class1475_0.int_3 == -1)
		{
			Column column = worksheet_0.Cells.Columns[class1475_0.int_0];
			if (column != null && column.method_5() != -1)
			{
				class1475_0.int_3 = column.method_5();
				class1475_0.style_0 = column.method_13();
			}
			if (row_0 != null && row_0.method_10() != -1)
			{
				class1475_0.int_3 = row_0.method_10();
				class1475_0.style_0 = row_0.method_26();
			}
		}
		method_11(class1475_0);
	}

	private bool method_13(Class1484 class1484_0, Class1475 class1475_0)
	{
		if (!class1484_0.bool_0)
		{
			return false;
		}
		if (class1484_0.arrayList_0 == null && class1475_0.arrayList_0 == null)
		{
			Style style = ((class1484_0.cell_0 == null) ? null : class1484_0.cell_0.method_28());
			if (style != null && style.IsTextWrapped)
			{
				return false;
			}
			if (class1475_0.cell_0 != null && class1475_0.cell_0.method_57() != null)
			{
				return false;
			}
			Column column = worksheet_0.Cells.Columns[class1484_0.int_0];
			Column column2 = worksheet_0.Cells.Columns[class1475_0.int_0];
			if (column != null && column2 != null && column.IsHidden != column2.IsHidden)
			{
				return false;
			}
			Class1483 @class = new Class1483(class1478_0.method_7(), class1484_0.style_0, class1475_0.style_0);
			if (!@class.method_2())
			{
				return false;
			}
			if (!class1484_0.bool_1 && !class1475_0.bool_2 && class1484_0.int_3 == class1475_0.int_3)
			{
				return true;
			}
			if (!@class.method_0())
			{
				return false;
			}
			if (!@class.method_1())
			{
				return false;
			}
			class1484_0.border_0 = @class.method_10();
			return true;
		}
		return false;
	}

	internal ArrayList method_14()
	{
		if (method_30())
		{
			return method_31();
		}
		if (arrayList_4 == null || arrayList_4.Count == 0)
		{
			method_7(class1482_0.method_1());
		}
		ArrayList arrayList = new ArrayList(arrayList_4.Count);
		for (int i = 0; i < arrayList_4.Count; i++)
		{
			Class1484 class1484_ = (Class1484)arrayList_4[i];
			string value = method_15(class1484_);
			arrayList.Add(value);
		}
		return arrayList;
	}

	private string method_15(Class1484 class1484_0)
	{
		if (class1484_0.arrayList_0 != null && class1484_0.arrayList_0.Count != 0)
		{
			return method_16(class1484_0);
		}
		return method_24(class1484_0);
	}

	private string method_16(Class1484 class1484_0)
	{
		int count = class1484_0.arrayList_0.Count;
		string text = method_24(class1484_0);
		StringBuilder stringBuilder = new StringBuilder(100 * count + text.Length);
		method_19(stringBuilder, class1484_0, bool_3: false);
		string value = method_20(class1484_0);
		stringBuilder.Append(value);
		stringBuilder.Append(" align=left valign=top>");
		for (int num = count - 1; num >= 0; num--)
		{
			Class315 class315_ = (Class315)class1484_0.arrayList_0[num];
			string value2 = method_17(class315_, class1484_0);
			stringBuilder.Append(value2);
		}
		stringBuilder.Append("<span  style='mso-ignore:vglayout2'>");
		stringBuilder.Append("<table cellpadding=0 cellspacing=0>");
		stringBuilder.Append("<tr>");
		stringBuilder.Append(text);
		stringBuilder.Append("</tr>");
		stringBuilder.Append("</table>");
		stringBuilder.Append("</span>");
		stringBuilder.Append("</td>");
		return stringBuilder.ToString();
	}

	private string method_17(Class315 class315_0, Class1484 class1484_0)
	{
		StringBuilder stringBuilder = new StringBuilder(100);
		Shape shape = class315_0.method_2();
		int width = shape.Width;
		int height = shape.Height;
		int num = shape.Left;
		int num2 = shape.Top;
		if (class1484_0.bool_2)
		{
			if (class315_0.method_1() > class1484_0.int_0)
			{
				for (int i = class1484_0.int_0; i < class315_0.method_1(); i++)
				{
					num += class1482_0.GetColumnWidthPixel(i);
				}
			}
			if (class315_0.method_0() > method_3())
			{
				for (int j = method_3(); j < class315_0.method_0(); j++)
				{
					num2 += worksheet_0.Cells.GetRowHeightPixel(j);
				}
			}
		}
		stringBuilder.Append("<span style='mso-ignore:vglayout;position:absolute;z-index:1;margin-left:");
		stringBuilder.Append(Class1618.smethod_80(num));
		stringBuilder.Append("px;margin-top:");
		stringBuilder.Append(Class1618.smethod_80(num2));
		stringBuilder.Append("px;width:");
		stringBuilder.Append(Class1618.smethod_80(width));
		stringBuilder.Append("px;height:");
		stringBuilder.Append(Class1618.smethod_80(height));
		stringBuilder.Append("px'>");
		if (class1478_0.string_5 != null)
		{
			stringBuilder.Append("<img width=");
			stringBuilder.Append(Class1618.smethod_80(width));
			stringBuilder.Append(" height=");
			stringBuilder.Append(Class1618.smethod_80(height));
			if (htmlSaveOptions_0.ExportImagesAsBase64)
			{
				stringBuilder.Append(" src=\"");
				stringBuilder.Append("data:image/png;base64,");
				MemoryStream memoryStream = new MemoryStream();
				ImageOrPrintOptions imageOrPrintOptions = new ImageOrPrintOptions();
				imageOrPrintOptions.ChartImageType = ImageFormat.Png;
				imageOrPrintOptions.ImageFormat = ImageFormat.Png;
				shape.ToImage(memoryStream, imageOrPrintOptions);
				stringBuilder.Append(method_18(memoryStream));
				memoryStream.Close();
				stringBuilder.Append("\"");
			}
			else
			{
				stringBuilder.Append(" src=\"");
				if (string_0 == null)
				{
					stringBuilder.Append(class315_0.FileName.Replace("#", "%23"));
				}
				else
				{
					stringBuilder.Append((string_0 + class315_0.FileName).Replace("#", "%23"));
				}
				stringBuilder.Append("\"");
			}
			if (shape.Name != "")
			{
				stringBuilder.Append(" name='");
				stringBuilder.Append(shape.Name);
				stringBuilder.Append("'");
			}
			if (shape.MsoDrawingType == MsoDrawingType.CheckBox)
			{
				stringBuilder.Append(" shapeType='");
				stringBuilder.Append("checkbox");
				stringBuilder.Append("'");
			}
			if (shape.AlternativeText != "")
			{
				stringBuilder.Append(" alt=");
				stringBuilder.Append(shape.AlternativeText);
			}
			stringBuilder.Append(">");
		}
		stringBuilder.Append("</span>");
		return stringBuilder.ToString();
	}

	private string method_18(MemoryStream memoryStream_0)
	{
		string text = Convert.ToBase64String(memoryStream_0.GetBuffer(), 0, (int)memoryStream_0.Length);
		for (int length = text.Length; length >= 32768; length = text.Length)
		{
			double num = 0.0;
			double num2 = 0.0;
			Image image = Image.FromStream(memoryStream_0);
			if (image.Width >= image.Height)
			{
				num = image.Width - 80;
				num2 = num * (double)image.Height / (double)image.Width;
			}
			else if (image.Height >= image.Width)
			{
				num2 = image.Height - 50;
				num = num2 * (double)image.Width / (double)image.Height;
			}
			Bitmap bitmap = new Bitmap((int)num, (int)num2, image.PixelFormat);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.SmoothingMode = SmoothingMode.HighQuality;
			graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			graphics.DrawImage(image, 0, 0, bitmap.Width, bitmap.Height);
			memoryStream_0 = new MemoryStream();
			bitmap.Save(memoryStream_0, ImageFormat.Png);
			text = Convert.ToBase64String(memoryStream_0.GetBuffer(), 0, (int)memoryStream_0.Length);
		}
		return text;
	}

	private void method_19(StringBuilder stringBuilder_0, Class1484 class1484_0, bool bool_3)
	{
		stringBuilder_0.Append("<td");
		if (class1484_0.int_1 > 1)
		{
			stringBuilder_0.Append(" colspan=").Append(Class1618.smethod_80(class1484_0.int_1));
		}
		if (class1484_0.int_2 > 1)
		{
			stringBuilder_0.Append(" rowspan=").Append(Class1618.smethod_80(class1484_0.int_2));
		}
		if (class1484_0.method_0())
		{
			double double_ = class1484_0.method_3();
			stringBuilder_0.Append(" height=").Append(Class1618.smethod_80(class1473_0.method_6(double_)));
		}
		if (bool_3 && class1484_0.int_3 != 15 && class1484_0.int_3 != -1)
		{
			stringBuilder_0.Append(" class=x").Append(Class1618.smethod_80(class1484_0.int_3));
		}
		if (bool_0 || class1484_0.arrayList_0 != null)
		{
			int num = class1484_0.method_4();
			stringBuilder_0.Append(" width=").Append(Class1618.smethod_80(num));
		}
	}

	private string method_20(Class1484 class1484_0)
	{
		StringBuilder stringBuilder = new StringBuilder(100);
		stringBuilder.Append(" style='");
		if (class1484_0.int_1 > 1 && !class1484_0.bool_2)
		{
			stringBuilder.Append("mso-ignore:colspan");
		}
		if (class1484_0.bool_1)
		{
			stringBuilder.Append("mso-ignore:style;");
		}
		if (class1484_0.border_0 != null || class1484_0.border_1 != null)
		{
			if (class1484_0.border_0 != null)
			{
				string text = method_26(class1484_0.border_0, BorderType.RightBorder);
				if (text != null)
				{
					if (stringBuilder.Length > 8)
					{
						stringBuilder.Append(";");
					}
					stringBuilder.Append(text);
				}
			}
			if (class1484_0.border_1 != null)
			{
				string text2 = method_26(class1484_0.border_1, BorderType.BottomBorder);
				if (text2 != null)
				{
					if (stringBuilder.Length > 8)
					{
						stringBuilder.Append(";");
					}
					stringBuilder.Append(text2);
					stringBuilder.Append(";");
				}
			}
		}
		if (class1484_0.method_0())
		{
			if (stringBuilder.Length > 8)
			{
				stringBuilder.Append(";");
			}
			stringBuilder.Append("height:").Append(Class1618.smethod_79(class1484_0.method_3())).Append("pt");
		}
		if (!bool_0 && class1484_0.arrayList_0 == null)
		{
			class1484_0.method_4();
		}
		else
		{
			int num = class1484_0.method_4();
			if (stringBuilder.Length > 8)
			{
				stringBuilder.Append(";");
			}
			if (num != 0)
			{
				stringBuilder.Append("width:").Append(Class1618.smethod_79(class1473_0.method_7(num))).Append("pt");
				stringBuilder.Append(";");
			}
		}
		if (class1484_0.bool_1)
		{
			method_21(class1484_0, stringBuilder);
		}
		stringBuilder.Append("'");
		string text3 = stringBuilder.ToString();
		if (text3.Equals(" style=''"))
		{
			text3 = "";
		}
		return text3;
	}

	private void method_21(Class1484 class1484_0, StringBuilder stringBuilder_0)
	{
		StringBuilder stringBuilder = new StringBuilder(350);
		method_23(class1484_0.style_0.Font, stringBuilder);
		BorderCollection borderCollection = class1484_0.style_0.method_4();
		if (borderCollection != null && borderCollection.method_4())
		{
			string text = method_26(borderCollection[BorderType.TopBorder], BorderType.TopBorder);
			stringBuilder.Append(text + ";");
			text = method_26(borderCollection[BorderType.LeftBorder], BorderType.LeftBorder);
			stringBuilder.Append(text + ";");
			text = method_26(borderCollection[BorderType.BottomBorder], BorderType.BottomBorder);
			stringBuilder.Append(text + ";");
			text = method_26(borderCollection[BorderType.RightBorder], BorderType.RightBorder);
			stringBuilder.Append(text + ";");
		}
		method_22(class1484_0.style_0, stringBuilder);
		stringBuilder_0.Append(stringBuilder.ToString());
	}

	public void method_22(Style style_0, StringBuilder stringBuilder_0)
	{
		string text = "auto";
		string text2 = "auto";
		string text3 = "";
		switch (style_0.Pattern)
		{
		default:
			if (!style_0.BackgroundInternalColor.method_2())
			{
				text = "#" + Class1618.smethod_64(style_0.BackgroundColor);
			}
			if (!style_0.ForeInternalColor.method_2())
			{
				text2 = "#" + Class1618.smethod_64(style_0.ForegroundColor);
			}
			text3 = " " + Class1130.smethod_1(style_0.Pattern);
			break;
		case BackgroundType.Solid:
			if (!style_0.ForeInternalColor.method_2())
			{
				text = "#" + Class1618.smethod_64(style_0.ForegroundColor);
			}
			text3 = " none";
			break;
		case BackgroundType.None:
			break;
		}
		stringBuilder_0.Append("background:" + text + ";mso-pattern:" + text2 + text3);
	}

	private void method_23(Aspose.Cells.Font font_0, StringBuilder stringBuilder_0)
	{
		stringBuilder_0.Append("font-size:" + Class1618.smethod_80(font_0.Size) + "pt;").Append("color:#" + Class1618.smethod_64(font_0.Color) + ";");
		if (font_0.IsItalic)
		{
			stringBuilder_0.Append("font-style:italic;");
		}
		stringBuilder_0.Append("font-weight:" + Class1618.smethod_80(font_0.Weight) + ";").Append("text-decoration:");
		if (font_0.IsStrikeout)
		{
			stringBuilder_0.Append("line-through");
		}
		if (font_0.Underline != 0)
		{
			stringBuilder_0.Append(" underline");
		}
		if (!font_0.IsStrikeout && font_0.Underline == FontUnderlineType.None)
		{
			stringBuilder_0.Append("none");
		}
		stringBuilder_0.Append(";font-family:\"" + font_0.Name + "\";");
	}

	private string method_24(Class1484 class1484_0)
	{
		if (class1484_0.cell_0 == null)
		{
			return method_29(class1484_0);
		}
		StringBuilder stringBuilder = new StringBuilder(300);
		if (class1484_0.method_4() == 0 && htmlSaveOptions_0.HiddenColDisplayType == HtmlHiddenColDisplayType.Remove)
		{
			return null;
		}
		string value = method_20(class1484_0);
		method_19(stringBuilder, class1484_0, bool_3: true);
		string text = "";
		Cell cell_ = class1484_0.cell_0;
		if (cell_.method_57() != null && cell_.Type != CellValueType.IsNull)
		{
			string[] array = Class1486.smethod_8(cell_);
			if (array != null)
			{
				string text2 = array[0];
				text = array[1];
				string text3 = array[2];
				char c = text2[0];
				int num = class1482_0.method_23(class1484_0.int_0, class1484_0.int_0 + class1484_0.int_1);
				if (num == 0)
				{
					text = Class1486.smethod_24(text, htmlSaveOptions_0.ParseHtmlTagInCell);
				}
				if (num > 0)
				{
					if (c == 's')
					{
						if (bool_1 && class1484_0.style_0 != null && (class1484_0.style_0.IsTextWrapped || class1484_0.style_0.RotationAngle != 0 || class1484_0.style_0.HorizontalAlignment == TextAlignmentType.Justify))
						{
							bool_1 = false;
						}
						StringBuilder stringBuilder2 = new StringBuilder(text.Length + 100);
						if (cell_.IsRichText())
						{
							int num2 = 0;
							ArrayList arrayList = class1484_0.cell_0.method_69();
							bool flag = false;
							for (int i = 0; i < arrayList.Count; i++)
							{
								Class1544 @class = (Class1544)arrayList[i];
								if (i == 0 && class1484_0.style_0 != null)
								{
									class1484_0.style_0.method_40();
								}
								int int_ = -1;
								if (@class.font_0 != null && class1478_0.method_4().hashtable_0.ContainsKey(@class.font_0.method_21()))
								{
									int_ = (int)class1478_0.method_4().hashtable_0[@class.font_0.method_21()];
								}
								if (!bool_1)
								{
									string value2 = method_28(@class.font_0, int_, @class.string_0);
									stringBuilder2.Append(value2);
									continue;
								}
								@class.int_0 = class1473_0.method_1(@class.font_0, @class.string_0);
								if (!flag && num2 + @class.int_0 > num)
								{
									int num3 = num2 + @class.int_0 - num;
									int num4 = class1473_0.method_4(@class.font_0, @class.string_0, num3);
									if (num4 < 0)
									{
										num4 = 0;
									}
									if (num4 > 0)
									{
										string value3 = method_28(@class.font_0, int_, @class.string_0.Substring(0, num4));
										stringBuilder2.Append(value3);
									}
									stringBuilder2.Append("<span style='display:none'>");
									string value4 = method_28(@class.font_0, int_, @class.string_0.Substring(num4));
									stringBuilder2.Append(value4);
									flag = true;
								}
								else
								{
									string value5 = method_28(@class.font_0, int_, @class.string_0);
									stringBuilder2.Append(value5);
								}
								num2 += @class.int_0;
							}
							if (flag && bool_1)
							{
								stringBuilder2.Append("</span>");
							}
							text = stringBuilder2.ToString();
						}
						else
						{
							if (!bool_1)
							{
								text = Class1486.smethod_24(text, htmlSaveOptions_0.ParseHtmlTagInCell);
							}
							else
							{
								int num5 = class1473_0.method_0(class1484_0.style_0, text);
								if (num5 > num)
								{
									int num6 = class1473_0.method_2(class1484_0.style_0, text, num);
									if (num6 > 0)
									{
										string value6 = Class1486.smethod_24(text.Substring(0, num6), htmlSaveOptions_0.ParseHtmlTagInCell);
										stringBuilder2.Append(value6);
										if (htmlSaveOptions_0.ParseHtmlTagInCell)
										{
											stringBuilder2.Append("<span style='display:none'>");
										}
									}
									string value7 = Class1486.smethod_24(text.Substring(num6), htmlSaveOptions_0.ParseHtmlTagInCell);
									stringBuilder2.Append(value7);
									if (num6 > 0 && htmlSaveOptions_0.ParseHtmlTagInCell)
									{
										stringBuilder2.Append("</span>");
									}
									text = stringBuilder2.ToString();
								}
								else
								{
									text = Class1486.smethod_24(text, htmlSaveOptions_0.ParseHtmlTagInCell);
								}
							}
							if (class1484_0.style_0 != null)
							{
								Aspose.Cells.Font font = class1484_0.style_0.method_40();
								if (font != null)
								{
									if (font.IsSuperscript)
									{
										text = "<sup>" + text + "</sup>";
									}
									else if (font.IsSubscript)
									{
										text = "<sub>" + text + "</sub>";
									}
								}
							}
						}
					}
					else if (bool_1)
					{
						int num7 = class1473_0.method_0(class1484_0.style_0, text) + 3;
						if (num7 > num)
						{
							bool flag2 = true;
							object obj = cell_.method_57();
							int num8 = class1473_0.method_2(class1484_0.style_0, text, num);
							if (obj is double && class1484_0.method_1() && num8 > 0)
							{
								try
								{
									string string_ = text.Substring(0, num8);
									int intValue = cell_.IntValue;
									double num9 = Class1618.smethod_85(string_);
									if (num9 >= (double)intValue)
									{
										flag2 = false;
									}
								}
								catch
								{
								}
							}
							if (flag2)
							{
								int num10 = class1473_0.method_0(class1484_0.style_0, "#");
								int num11 = num / num10 + 1;
								StringBuilder stringBuilder3 = new StringBuilder(num11);
								for (int j = 0; j < num11; j++)
								{
									stringBuilder3.Append('#');
								}
								text = stringBuilder3.ToString();
							}
						}
					}
				}
				switch (c)
				{
				case 'n':
					stringBuilder.Append(" align=right");
					if (text3 != null)
					{
						stringBuilder.Append(" x:num=\"").Append(text3).Append("\"");
					}
					break;
				case 'b':
				case 'e':
					stringBuilder.Append(" align=center");
					stringBuilder.Append(" x:err=\"").Append(text3).Append("\"");
					break;
				}
			}
		}
		string formula = cell_.Formula;
		if (formula != null && formula.Length > 0)
		{
			if (cell_.IsInArray)
			{
				stringBuilder.Append(" x:arrayrange=\"" + cell_.Name + "\"");
			}
			stringBuilder.Append(" x:fmla=\"").Append(Class1486.smethod_2(formula)).Append("\"");
		}
		stringBuilder.Append(value);
		stringBuilder.Append(">");
		string text4 = method_25(class1484_0);
		if (text4 != null)
		{
			stringBuilder.Append(text4);
		}
		if (class1484_0.method_2())
		{
			StringBuilder stringBuilder4 = new StringBuilder(50);
			stringBuilder4.Append("<a ");
			if (class1484_0.string_0 != null)
			{
				stringBuilder4.Append("name=\"");
				stringBuilder4.Append(class1484_0.string_0);
				stringBuilder4.Append("\"");
			}
			if (class1484_0.hyperlink_0 != null)
			{
				string value8 = method_27(class1484_0.hyperlink_0);
				int num12 = class1484_0.hyperlink_0.method_5(class1478_0.workbook_0.Worksheets);
				stringBuilder4.Append("href=\"");
				if (class1478_0.method_0() && num12 == 1)
				{
					stringBuilder4.Append("../");
				}
				stringBuilder4.Append(value8);
				stringBuilder4.Append("\"");
				if (num12 == 0 || num12 == 1)
				{
					stringBuilder4.Append("target=\"_parent\"");
				}
			}
			stringBuilder4.Append(">");
			stringBuilder.Append(stringBuilder4.ToString());
		}
		stringBuilder.Append(text);
		if (class1484_0.method_2())
		{
			stringBuilder.Append("</a>");
		}
		if (text4 != null)
		{
			stringBuilder.Append("</font>");
		}
		stringBuilder.Append("</td>");
		return stringBuilder.ToString();
	}

	private string method_25(Class1484 class1484_0)
	{
		if (class1484_0.cell_0 != null && class1484_0.cell_0.Type == CellValueType.IsNumeric)
		{
			Color color_ = Color.Empty;
			switch (class1484_0.style_0.Number)
			{
			case 6:
			case 8:
			case 38:
			case 40:
				if (class1484_0.cell_0.DoubleValue < 0.0)
				{
					color_ = Color.Red;
				}
				break;
			case 0:
			{
				string custom = class1484_0.style_0.Custom;
				if (custom != null && custom != "")
				{
					color_ = Class1625.smethod_21(class1484_0.cell_0.DoubleValue, custom, color_);
				}
				break;
			}
			}
			if (!color_.IsEmpty)
			{
				return "<font color=\"#" + Class1618.smethod_64(color_) + "\" style='mso-ignore:color'>";
			}
			return null;
		}
		return null;
	}

	private string method_26(Border border_0, BorderType borderType_0)
	{
		StringBuilder stringBuilder = new StringBuilder(20);
		switch (borderType_0)
		{
		case BorderType.BottomBorder:
			stringBuilder.Append("border-bottom:");
			break;
		case BorderType.LeftBorder:
			stringBuilder.Append("border-left:");
			break;
		case BorderType.RightBorder:
			stringBuilder.Append("border-right:");
			break;
		default:
			return null;
		case BorderType.TopBorder:
			stringBuilder.Append("border-top:");
			break;
		}
		CellBorderType lineStyle = border_0.LineStyle;
		string value = Class1130.smethod_0(lineStyle);
		stringBuilder.Append(value);
		if (!border_0.InternalColor.method_2())
		{
			stringBuilder.Append(" #" + Class1618.smethod_64(border_0.Color));
		}
		else
		{
			stringBuilder.Append(" windowtext");
		}
		return stringBuilder.ToString();
	}

	private string method_27(Hyperlink hyperlink_0)
	{
		string sheetName = null;
		if (Class1486.smethod_13(class1478_0.workbook_0.Worksheets, hyperlink_0, out sheetName, out var ca))
		{
			if (sheetName == worksheet_0.Name)
			{
				sheetName = "";
			}
			string text = Class1486.smethod_14(ca);
			string text2 = class1478_0.method_14(sheetName);
			return text2 + text;
		}
		return hyperlink_0.Address;
	}

	private string method_28(Aspose.Cells.Font font_0, int int_2, string string_1)
	{
		string text = "";
		if (int_2 != -1)
		{
			text = text + "<font class=\"font" + Class1618.smethod_80(int_2) + "\">";
			if (font_0.IsSuperscript)
			{
				text += "<sup>";
			}
			else if (font_0.IsSubscript)
			{
				text += "<sub>";
			}
		}
		text += Class1486.smethod_24(string_1, htmlSaveOptions_0.ParseHtmlTagInCell);
		if (int_2 != -1)
		{
			if (font_0.IsSuperscript)
			{
				text += "</sup>";
			}
			else if (font_0.IsSubscript)
			{
				text += "</sub>";
			}
			text += "</font>";
		}
		return text;
	}

	private string method_29(Class1484 class1484_0)
	{
		StringBuilder stringBuilder = new StringBuilder(200);
		string value = method_20(class1484_0);
		method_19(stringBuilder, class1484_0, bool_3: true);
		stringBuilder.Append(value);
		stringBuilder.Append(">");
		if (class1484_0.string_0 != null)
		{
			stringBuilder.Append("<a name=\"");
			stringBuilder.Append(class1484_0.string_0);
			stringBuilder.Append("\">");
			stringBuilder.Append("</a>");
		}
		stringBuilder.Append("</td>");
		return stringBuilder.ToString();
	}

	internal bool method_30()
	{
		if (row_0 == null && arrayList_4.Count == 0 && (arrayList_0 == null || arrayList_0.Count == 0) && (arrayList_1 == null || arrayList_1.Count == 0) && (arrayList_2 == null || arrayList_2.Count == 0) && (arrayList_3 == null || arrayList_3.Count == 0))
		{
			return true;
		}
		return false;
	}

	internal ArrayList method_31()
	{
		ArrayList arrayList = class1482_0.method_13();
		ArrayList arrayList2 = new ArrayList(arrayList.Count);
		for (int i = 0; i < arrayList.Count; i++)
		{
			Class1477 @class = (Class1477)arrayList[i];
			StringBuilder stringBuilder = new StringBuilder(200);
			StringBuilder stringBuilder2 = new StringBuilder(100);
			stringBuilder.Append("  <td");
			stringBuilder2.Append(" style='");
			if (i == 0)
			{
				double double_ = method_32();
				stringBuilder.Append(" height=").Append(Class1618.smethod_80(class1473_0.method_6(double_)));
				stringBuilder2.Append("height:" + Class1618.smethod_79(double_) + "pt");
			}
			if (@class.int_1 > 1)
			{
				if (stringBuilder2.Length > 8)
				{
					stringBuilder2.Append(";");
				}
				stringBuilder.Append(" colspan=").Append(Class1618.smethod_80(@class.int_1));
				stringBuilder2.Append("mso-ignore:colspan;");
			}
			int int_ = @class.int_3;
			if (int_ != 15 && int_ != -1)
			{
				stringBuilder.Append(" class=x").Append(Class1618.smethod_80(int_));
			}
			if (stringBuilder2.Length > 8)
			{
				stringBuilder2.Append("'");
				stringBuilder.Append(stringBuilder2.ToString());
			}
			stringBuilder.Append("></td>");
			string value = stringBuilder.ToString();
			arrayList2.Add(value);
		}
		return arrayList2;
	}

	internal double method_32()
	{
		double num = 0.0;
		int num2 = method_3() + method_1();
		for (int i = method_3(); i < num2; i++)
		{
			num += worksheet_0.Cells.GetRowHeight(i);
		}
		return num;
	}
}
