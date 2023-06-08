using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Aspose.Slides;
using ns60;
using ns62;
using ns63;

namespace ns15;

internal class Class1045 : Class1043
{
	private static void smethod_13(Table targetTable, Class202 tableContext)
	{
		double[] array = new double[tableContext.ColumnsCount];
		double[] array2 = new double[tableContext.RowsCount];
		for (int i = 0; i < tableContext.ColumnsCount; i++)
		{
			array[i] = (double)tableContext.method_0(i) / 8.0;
		}
		for (int j = 0; j < tableContext.RowsCount; j++)
		{
			array2[j] = (double)tableContext.method_1(j) / 8.0;
		}
		targetTable.method_15(array, array2);
		Rectangle tableRectangle = tableContext.TableRectangle;
		targetTable.RawFrameImpl.vmethod_0((double)tableRectangle.X / 8.0, (double)tableRectangle.Y / 8.0, (double)tableRectangle.Width / 8.0, (double)tableRectangle.Height / 8.0);
	}

	private static void smethod_14(Table targetTable, Class202 tableContext)
	{
		int count = targetTable.Rows.Count;
		int count2 = targetTable.Columns.Count;
		Struct14[] horisontalLines = tableContext.HorisontalLines;
		for (int i = 0; i < horisontalLines.Length; i++)
		{
			Struct14 @struct = horisontalLines[i];
			Class2670 class2670_ = @struct.class2670_0;
			Rectangle rectangle_ = @struct.rectangle_0;
			Rectangle rectangle = tableContext.method_2(rectangle_);
			int num = rectangle.X;
			int y = rectangle.Y;
			int num2 = rectangle.Width;
			LineFormat lineFormat = new LineFormat(targetTable);
			Class1056.smethod_0(lineFormat, class2670_, tableContext.DeserializationContext, LineJoinStyle.Miter, flipLineStyle: false);
			while (num2 > 0)
			{
				if (y > 0)
				{
					((LineFormat)targetTable[num, y - 1].BorderBottom).method_0(lineFormat);
				}
				if (y < count)
				{
					((LineFormat)targetTable[num, y].BorderTop).method_0(lineFormat);
				}
				num++;
				num2--;
			}
		}
		Struct14[] verticalLines = tableContext.VerticalLines;
		for (int j = 0; j < verticalLines.Length; j++)
		{
			Struct14 struct2 = verticalLines[j];
			Class2670 class2670_ = struct2.class2670_0;
			Rectangle rectangle_ = struct2.rectangle_0;
			Rectangle rectangle = tableContext.method_2(rectangle_);
			int num = rectangle.X;
			int y = rectangle.Y;
			int num3 = rectangle.Height;
			LineFormat lineFormat2 = new LineFormat(targetTable);
			Class1056.smethod_0(lineFormat2, class2670_, tableContext.DeserializationContext, LineJoinStyle.Miter, flipLineStyle: false);
			while (num3 > 0)
			{
				if (num > 0)
				{
					((LineFormat)targetTable[num - 1, y].BorderRight).method_0(lineFormat2);
				}
				if (num < count2)
				{
					((LineFormat)targetTable[num, y].BorderLeft).method_0(lineFormat2);
				}
				y++;
				num3--;
			}
		}
		Struct14[] diagonalLines = tableContext.DiagonalLines;
		for (int k = 0; k < diagonalLines.Length; k++)
		{
			Struct14 struct3 = diagonalLines[k];
			Class2670 class2670_ = struct3.class2670_0;
			Rectangle rectangle_ = struct3.rectangle_0;
			Rectangle rectangle = tableContext.method_2(rectangle_);
			int num = rectangle.X;
			int y = rectangle.Y;
			int num2 = rectangle.Width;
			LineFormat lineFormat3 = new LineFormat(targetTable);
			Class1056.smethod_0(lineFormat3, class2670_, tableContext.DeserializationContext, LineJoinStyle.Miter, flipLineStyle: false);
			bool flag = class2670_.ShapeProp.FFlipH != class2670_.ShapeProp.FFlipV;
			int num4 = 1;
			if (flag)
			{
				num4 = -1;
				num += num2 - 1;
			}
			while (num2 > 0)
			{
				if (flag)
				{
					((LineFormat)targetTable[num, y].BorderDiagonalUp).method_0(lineFormat3);
				}
				else
				{
					((LineFormat)targetTable[num, y].BorderDiagonalDown).method_0(lineFormat3);
				}
				num += num4;
				y++;
				num2--;
			}
		}
	}

	private static void smethod_15(Table targetTable, Class202 tableContext)
	{
		Struct14[] tableCells = tableContext.TableCells;
		for (int i = 0; i < tableCells.Length; i++)
		{
			Struct14 @struct = tableCells[i];
			Class2670 class2670_ = @struct.class2670_0;
			Rectangle rectangle_ = @struct.rectangle_0;
			Rectangle rectangle = tableContext.method_2(rectangle_);
			Cell cell = (Cell)targetTable[rectangle.X, rectangle.Y];
			cell.NeedToUpdateSize = true;
			Class1052.smethod_0((FillFormat)cell.FillFormat, class2670_, tableContext.DeserializationContext);
			if (class2670_.Txid != 0)
			{
				Class2642 clientTextBox = class2670_.ClientTextBox;
				if (clientTextBox != null && clientTextBox.Header.IsContainer)
				{
					cell.textFrame_0 = Class1066.smethod_1(cell, class2670_, tableContext.DeserializationContext);
					_ = clientTextBox.TextType;
					smethod_17(cell);
				}
			}
			cell.int_1 = rectangle.Width;
			cell.int_0 = rectangle.Height;
			if (rectangle.Width > 1)
			{
				((LineFormat)cell.BorderRight).method_0((LineFormat)targetTable[rectangle.X + rectangle.Width - 1, rectangle.Y].BorderRight);
			}
			if (rectangle.Height > 1)
			{
				((LineFormat)cell.BorderBottom).method_0((LineFormat)targetTable[rectangle.X, rectangle.Y + rectangle.Height - 1].BorderBottom);
			}
			cell.method_1(mergeText: false);
		}
	}

	internal static void smethod_16(Table targetTable, Class2671 shapesGroupContainer, Class854 slideDeserializationContext)
	{
		Class1043.smethod_12(targetTable, shapesGroupContainer, slideDeserializationContext);
		Class202 tableContext = new Class202(shapesGroupContainer, slideDeserializationContext);
		smethod_13(targetTable, tableContext);
		smethod_14(targetTable, tableContext);
		smethod_15(targetTable, tableContext);
		targetTable.AlternativeText = "";
		targetTable.method_11(shapesGroupContainer.ShapeProp.Spid);
		if (shapesGroupContainer.ShapePrimaryOptions != null)
		{
			if (shapesGroupContainer.ShapePrimaryOptions.Properties[Enum426.const_19] is Class2930 @class)
			{
				UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
				char[] chars = unicodeEncoding.GetChars(@class.Value);
				if (chars != null && chars.Length > 0)
				{
					if (chars[chars.Length - 1] == '\0')
					{
						targetTable.AlternativeText = new string(chars, 0, chars.Length - 1);
					}
					else
					{
						targetTable.AlternativeText = new string(chars);
					}
				}
			}
			Class2930 class2 = shapesGroupContainer.ShapePrimaryOptions.Properties[Enum426.const_18] as Class2930;
			if (class2 != null)
			{
				UnicodeEncoding unicodeEncoding2 = new UnicodeEncoding();
				char[] chars2 = unicodeEncoding2.GetChars(class2.Value);
				if (chars2 != null && chars2.Length > 0)
				{
					if (chars2[chars2.Length - 1] == '\0')
					{
						targetTable.Name = new string(chars2, 0, chars2.Length - 1);
					}
					else
					{
						targetTable.Name = new string(chars2);
					}
				}
			}
			Class2911 class3 = shapesGroupContainer.ShapePrimaryOptions.Properties[Enum426.const_50] as Class2911;
			if (class2 != null)
			{
				targetTable.Hidden = (class3.Value & 2) != 0;
			}
			if (shapesGroupContainer.ClientData != null && shapesGroupContainer.ClientData.PlaceholderAtom != null && slideDeserializationContext.FrameToPlaceholder.TryGetValue(shapesGroupContainer, out var value))
			{
				Class1062.smethod_0(targetTable, value, slideDeserializationContext);
			}
		}
		Class2837 shapeTertiaryOptions = shapesGroupContainer.ShapeTertiaryOptions;
		if (shapeTertiaryOptions != null)
		{
			int[] rowHeights = shapeTertiaryOptions.RowHeights;
			int num = Math.Min(targetTable.rowCollection_0.Count, rowHeights.Length);
			for (int i = 0; i < num; i++)
			{
				targetTable.rowCollection_0[i].MinimalHeight = (double)rowHeights[i] / 8.0;
			}
		}
		targetTable.vmethod_6();
	}

	internal static void smethod_17(Cell cell)
	{
		ITextFrameFormat textFrameFormat = cell.textFrame_0.TextFrameFormat;
		if (!double.IsNaN(textFrameFormat.MarginLeft))
		{
			cell.MarginLeft = textFrameFormat.MarginLeft;
		}
		cell.MarginTop = 0.0;
		if (!double.IsNaN(textFrameFormat.MarginTop))
		{
			cell.MarginTop = textFrameFormat.MarginTop;
		}
		if (!double.IsNaN(textFrameFormat.MarginRight))
		{
			cell.MarginRight = textFrameFormat.MarginRight;
		}
		cell.MarginBottom = 0.0;
		if (!double.IsNaN(textFrameFormat.MarginBottom))
		{
			cell.MarginBottom = textFrameFormat.MarginBottom;
		}
		cell.TextAnchorType = ((textFrameFormat.AnchoringType != TextAnchorType.NotDefined) ? textFrameFormat.AnchoringType : TextAnchorType.Top);
		cell.AnchorCenter = textFrameFormat.CenterText == NullableBool.True;
		cell.TextVerticalType = ((textFrameFormat.TextVerticalType != TextVerticalType.NotDefined) ? textFrameFormat.TextVerticalType : TextVerticalType.Horizontal);
	}

	internal static bool smethod_18(Class2671 frame)
	{
		if (frame.ShapeTertiaryOptions != null && frame.ShapeTertiaryOptions.IsTable)
		{
			return true;
		}
		return false;
	}

	internal static void smethod_19(Table table, Class854 slideDeserializationContext)
	{
		ITextStyle newDefault = table.Presentation.DefaultTextStyle;
		MasterSlide masterSlide = null;
		if (table.Slide is Slide)
		{
			masterSlide = (MasterSlide)((Slide)table.Slide).MasterSlide;
			if (masterSlide != null && masterSlide.OtherStyle != null)
			{
				newDefault = masterSlide.OtherStyle;
			}
		}
		else if (table.Slide is LayoutSlide)
		{
			masterSlide = (MasterSlide)((LayoutSlide)table.Slide).MasterSlide;
			if (masterSlide != null && masterSlide.OtherStyle != null)
			{
				newDefault = masterSlide.OtherStyle;
			}
		}
		else if (table.Slide is MasterSlide)
		{
			masterSlide = (MasterSlide)table.Slide;
			if (masterSlide != null && masterSlide.OtherStyle != null)
			{
				newDefault = masterSlide.OtherStyle;
			}
		}
		TextStyle textStyle = null;
		Class854 @class = ((masterSlide != null) ? slideDeserializationContext.DeserializationContext.method_2(masterSlide.BaseSlidePPTUnsupportedProps.SlideId) : null);
		if (@class != null && @class.TxMasterStyles.ContainsKey(7))
		{
			textStyle = @class.TxMasterStyles[7];
		}
		TextStyle[] styles = ((textStyle == null) ? TextStyle.textStyle_0 : new TextStyle[1] { textStyle });
		for (int i = 0; i < table.rowCollection_0.Count; i++)
		{
			Row row = table.rowCollection_0.method_0(i);
			for (int j = 0; j < table.columnCollection_0.Count; j++)
			{
				Cell cell = row.vmethod_3(j);
				if (!cell.IsSlaveCell)
				{
					Class1070.smethod_3(styles, ((TextFrame)cell.TextFrame).textFrameFormat_0.textStyle_0);
					if (textStyle != null)
					{
						((TextFrame)cell.TextFrame).textFrameFormat_0.textStyle_0.method_5(textStyle, newDefault);
					}
				}
			}
		}
	}

	internal static void smethod_20(Table domTable, Class2671 odrawShgrContainer, Class856 pptSerializationContext)
	{
		Class2671 @class = new Class2671();
		odrawShgrContainer.Records.Add(@class);
		Class2670 class2 = new Class2670();
		@class.Records.Add(class2);
		class2.Records.Add(new Class2836((int)((double)domTable.X * 8.0), (int)((double)domTable.Y * 8.0), (int)((double)domTable.Width * 8.0), (int)((double)domTable.Height * 8.0)));
		Class2835 class3 = new Class2835();
		class2.Records.Add(class3);
		class3.Spid = pptSerializationContext.method_8(incFdgCsp: true);
		class3.FGroup = true;
		class3.FHaveMaster = false;
		class3.FFlipH = domTable.Frame.FlipH == NullableBool.True;
		class3.FFlipV = domTable.Frame.FlipV == NullableBool.True;
		class3.FHaveAnchor = true;
		Class2834 class4 = domTable.PPTUnsupportedProps.OfficeArtSpContainer_ShapePrimaryOptions;
		if (class4 == null)
		{
			class4 = new Class2834();
		}
		class2.Records.Add(class4);
		Class2837 class5 = domTable.PPTUnsupportedProps.OfficeArtSpContainer_ShapeTertiaryOptions;
		if (class5 == null)
		{
			class5 = new Class2837();
		}
		class2.Records.Add(class5);
		Class858.smethod_2(domTable.ShapeLock, class4);
		Class2922 class6 = (Class2922)class4.Properties[Enum426.const_50];
		if (class6 == null)
		{
			class4.Properties.Add(class6 = new Class2922());
		}
		class6.OfUsefHidden = true;
		class6.efHidden = domTable.Hidden;
		class6.ffPrint = false;
		class6.QfLayoutInCell = false;
		class6.WfAllowOverlap = false;
		if (!float.IsNaN(domTable.Rotation))
		{
			Class2911 property = new Class2911(Enum426.const_394, (uint)domTable.Rotation % 360u << 16);
			class4.Properties.method_0(property);
		}
		Class2930 property2 = new Class2930(Enum426.const_18, domTable.Name);
		class4.Properties.method_0(property2);
		class4.Properties.method_0(new Class2911(Enum426.const_404, 16777472u));
		if (class4.Properties.Count == 0)
		{
			class2.Records.Remove(class4);
		}
		Class2929 class7 = (Class2929)class5.Properties[Enum426.const_45];
		if (class7 == null)
		{
			class5.Properties.Add(class7 = new Class2929());
		}
		class7.AfIsTable = true;
		Class2934 class8 = new Class2934(Enum426.const_46, (ushort)domTable.Rows.Count, 4);
		class5.Properties.method_0(class8);
		for (int i = 0; i < domTable.Rows.Count; i++)
		{
			class8[i] = (ulong)(domTable.Rows[i].MinimalHeight * 8.0);
		}
		class5.Properties.Remove(Enum426.const_48);
		if (class5.Properties.Count == 0)
		{
			class2.Records.Remove(class5);
		}
		Class2742 class9 = new Class2742();
		class2.Records.Add(class9);
		class9.X = (int)(domTable.X * 8f);
		class9.Y = (int)(domTable.Y * 8f);
		class9.Height = (int)(domTable.Height * 8f);
		class9.Width = (int)(domTable.Width * 8f);
		if (domTable.Rows.Count < 1 || domTable.Columns.Count < 1)
		{
			return;
		}
		domTable.vmethod_6();
		int count = domTable.Columns.Count;
		int count2 = domTable.Rows.Count;
		int[] array = new int[count + 1];
		int[] array2 = new int[count2 + 1];
		double num = domTable.X;
		array[0] = (int)(num * 8.0);
		for (int j = 0; j < count; j++)
		{
			num += domTable.columnCollection_0.method_0(j).Width;
			array[j + 1] = (int)(num * 8.0);
		}
		num = domTable.Y;
		array2[0] = (int)(num * 8.0);
		for (int k = 0; k < count2; k++)
		{
			num += domTable.rowCollection_0.method_0(k).MinimalHeight;
			array2[k + 1] = (int)(num * 8.0);
		}
		Row row = null;
		Cell cell = null;
		for (int k = 0; k < domTable.Rows.Count; k++)
		{
			row = domTable.rowCollection_0.method_0(k);
			int j = 0;
			while (j < count)
			{
				cell = row.vmethod_3(j);
				if (cell.IsSlaveCell)
				{
					j += cell.BaseCell.ColSpan;
					continue;
				}
				Rectangle rectangle = new Rectangle(array[j], array2[k], array[j + cell.ColSpan] - array[j], array2[k + cell.RowSpan] - array2[k]);
				smethod_21(cell, rectangle, @class, pptSerializationContext);
				if (!cell.BorderDiagonalDown.IsFormatNotDefined)
				{
					smethod_23(@class.Records, cell.BorderDiagonalDown, rectangle, pptSerializationContext);
				}
				if (!cell.BorderDiagonalUp.IsFormatNotDefined)
				{
					smethod_23(@class.Records, cell.BorderDiagonalUp, rectangle, pptSerializationContext).ShapeProp.FFlipV = true;
				}
				j += cell.ColSpan;
			}
		}
		int num2 = 0;
		for (int j = 0; j <= count; j++)
		{
			ILineFormat lineFormat = null;
			for (int k = 0; k < count2; k++)
			{
				row = domTable.rowCollection_0.method_0(k);
				Cell firstCell = null;
				Cell secondCell = null;
				if (j > 0)
				{
					firstCell = row.vmethod_3(j - 1);
				}
				if (j < count)
				{
					secondCell = row.vmethod_3(j);
				}
				ILineFormat lineFormat2 = Table.smethod_2(firstCell, secondCell, vertical: true);
				if ((lineFormat2 != null) ? (!lineFormat2.Equals(lineFormat)) : (lineFormat != null))
				{
					if (lineFormat != null && !lineFormat.IsFormatNotDefined)
					{
						smethod_23(@class.Records, lineFormat, new Rectangle(array[j], num2, 0, array2[k] - num2), pptSerializationContext);
					}
					lineFormat = lineFormat2;
					num2 = array2[k];
				}
			}
			if (lineFormat != null && !lineFormat.IsFormatNotDefined)
			{
				smethod_23(@class.Records, lineFormat, new Rectangle(array[j], num2, 0, array2[count2] - num2), pptSerializationContext);
			}
		}
		for (int k = 0; k <= count2; k++)
		{
			ILineFormat lineFormat = null;
			Row row2 = null;
			if (k > 0)
			{
				row2 = domTable.rowCollection_0.method_0(k - 1);
			}
			Row row3 = null;
			if (k < count2)
			{
				row3 = domTable.rowCollection_0.method_0(k);
			}
			for (int j = 0; j < count; j++)
			{
				Cell firstCell2 = null;
				if (row2 != null)
				{
					firstCell2 = row2.vmethod_3(j);
				}
				Cell secondCell2 = null;
				if (row3 != null)
				{
					secondCell2 = row3.vmethod_3(j);
				}
				ILineFormat lineFormat3 = Table.smethod_2(firstCell2, secondCell2, vertical: false);
				if ((lineFormat3 != null) ? (!lineFormat3.Equals(lineFormat)) : (lineFormat != null))
				{
					if (lineFormat != null && !lineFormat.IsFormatNotDefined)
					{
						smethod_23(@class.Records, lineFormat, new Rectangle(num2, array2[k], array[j] - num2, 0), pptSerializationContext);
					}
					lineFormat = lineFormat3;
					num2 = array[j];
				}
			}
			if (lineFormat != null && !lineFormat.IsFormatNotDefined)
			{
				smethod_23(@class.Records, lineFormat, new Rectangle(num2, array2[k], array[count] - num2, 0), pptSerializationContext);
			}
		}
	}

	private static void smethod_21(Cell currentCell, Rectangle cellRectangle, Class2671 tableGroupShapeContainer, Class856 pptSerializationContext)
	{
		Class201 @class = new Class201(pptSerializationContext);
		Class2670 class2 = @class.method_0(tableGroupShapeContainer, addToContainer: true);
		Class2835 class3 = new Class2835();
		class2.Records.Add(class3);
		class3.Spid = pptSerializationContext.method_8(incFdgCsp: true);
		class3.FChild = true;
		class3.FHaveAnchor = true;
		class3.FHaveSpt = true;
		class3.ShapeType = Enum425.const_1;
		Class2834 class4 = new Class2834();
		Class2837 class5 = new Class2837();
		Class2924 class6 = new Class2924();
		class4.Properties.Add(class6);
		class6.HfUsefLockText = true;
		Class2922 class7 = (Class2922)class4.Properties[Enum426.const_50];
		if (class7 == null)
		{
			class4.Properties.Add(class7 = new Class2922());
		}
		class7.OfUsefHidden = true;
		class7.efHidden = false;
		class7.ffPrint = false;
		class7.QfLayoutInCell = false;
		class7.WfAllowOverlap = false;
		Class1052.smethod_1(currentCell.FillFormat, class4, class5, background: false, pptSerializationContext);
		smethod_22(currentCell);
		Class1066.smethod_15(currentCell.TextFrame.TextFrameFormat, class4, pptSerializationContext);
		if (class4.Properties.Count > 0)
		{
			class2.Records.Add(class4);
		}
		class5.Properties.Remove(Enum426.const_48);
		Class2741 class8 = new Class2741();
		class2.Records.Add(class8);
		class8.Rectangle = cellRectangle;
		Class1036.smethod_9(currentCell.TextFrame, null, Enum449.const_6, @class);
	}

	internal static void smethod_22(Cell cell)
	{
		ITextFrameFormat textFrameFormat = cell.textFrame_0.TextFrameFormat;
		if (!double.IsNaN(cell.MarginLeft))
		{
			textFrameFormat.MarginLeft = cell.MarginLeft;
		}
		if (!double.IsNaN(cell.MarginTop))
		{
			textFrameFormat.MarginTop = cell.MarginTop;
		}
		if (!double.IsNaN(cell.MarginRight))
		{
			textFrameFormat.MarginRight = cell.MarginRight;
		}
		if (!double.IsNaN(cell.MarginBottom))
		{
			textFrameFormat.MarginBottom = cell.MarginBottom;
		}
		textFrameFormat.AnchoringType = ((cell.TextAnchorType == TextAnchorType.Top) ? TextAnchorType.NotDefined : cell.TextAnchorType);
		textFrameFormat.CenterText = (cell.AnchorCenter ? NullableBool.True : NullableBool.NotDefined);
		textFrameFormat.TextVerticalType = ((cell.TextVerticalType == TextVerticalType.Horizontal) ? TextVerticalType.NotDefined : cell.TextVerticalType);
	}

	private static Class2670 smethod_23(List<Class2623> records, ILineFormat borderLineFormat, Rectangle shapeRect, Class856 pptSerializationContext)
	{
		Class2670 @class = new Class2670();
		records.Add(@class);
		@class.AutoInit = true;
		Class2835 shapeProp = @class.ShapeProp;
		shapeProp.Spid = pptSerializationContext.method_8(incFdgCsp: true);
		shapeProp.FChild = true;
		shapeProp.FHaveAnchor = true;
		shapeProp.FHaveSpt = true;
		shapeProp.ShapeType = Enum425.const_20;
		Class2834 class2 = new Class2834();
		@class.Records.Add(class2);
		Class2837 class3 = new Class2837();
		@class.Records.Add(class3);
		Class2924 class4 = new Class2924();
		class2.Properties.Add(class4);
		class4.HfUsefLockText = true;
		Class2922 class5 = (Class2922)class2.Properties[Enum426.const_50];
		if (class5 == null)
		{
			class2.Properties.Add(class5 = new Class2922());
		}
		class5.OfUsefHidden = true;
		class5.efHidden = false;
		class5.ffPrint = false;
		class5.QfLayoutInCell = false;
		class5.WfAllowOverlap = false;
		Class1056.smethod_2(borderLineFormat, @class, LineJoinStyle.Miter, pptSerializationContext);
		new Class2911(Enum426.const_419, 393216u);
		new Class2911(Enum426.const_80, 65536u);
		new Class2911(Enum426.const_119, 1048576u);
		if (class2.Properties.Count == 0)
		{
			@class.Records.Remove(class2);
		}
		class3.Properties.Remove(Enum426.const_48);
		if (class3.Properties.Count == 0)
		{
			@class.Records.Remove(class3);
		}
		Class2741 class6 = new Class2741();
		@class.Records.Add(class6);
		class6.Rectangle = shapeRect;
		return @class;
	}
}
