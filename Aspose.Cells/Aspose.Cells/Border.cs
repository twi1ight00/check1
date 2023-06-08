using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using ns22;

namespace Aspose.Cells;

/// <summary>
///       Encapsulates the object that represents the cell border.
///       </summary>
/// <example>
///   <code>
///       [C#]
///
///       int styleIndex = workbook.Styles.Add();
///       Style style = workbook.Styles[styleIndex];
///       //Set top border style and color
///       Border border = style.Borders[BorderType.TopBorder];
///       border.LineStyle = CellBorderType.Medium;
///       border.Color = Color.Red;
///       cell.SetStyle(style);
///
///       [Visual Basic]
///
///       Dim styleIndex as Integer = workbook.Styles.Add()
///       Dim style as Style = workbook.Styles[styleIndex]
///       'Set top border style and color
///       Dim border as Border = style.Borders(BorderType.TopBorder)
///       border.LineStyle = CellBorderType.Medium
///       border.Color = Color.Red
///       cell.SetStyle(style);
///       </code>
/// </example>
[Serializable]
public class Border
{
	private BorderCollection borders;

	internal InternalColor InternalColor;

	private BorderType borderType;

	private CellBorderType lineStyle;

	/// <summary>
	///       Gets or sets the <see cref="T:System.Drawing.Color" /> of the border.
	///       </summary>
	public Color Color
	{
		get
		{
			if (InternalColor.method_2())
			{
				return Color.Black;
			}
			return InternalColor.method_6(borders.ParentStyle.method_5().Workbook);
		}
		set
		{
			if (!Class1178.smethod_0(value) && !(value == Color.Black))
			{
				InternalColor.SetColor(ColorType.RGB, value.ToArgb());
			}
			else
			{
				InternalColor.method_3(bool_0: true);
			}
			InternalColor.method_8();
			if (!borders.ParentStyle.method_23())
			{
				borders.ParentStyle.method_24(bool_0: true);
			}
			switch (borderType)
			{
			case BorderType.BottomBorder:
			{
				Style parentStyle8 = borders.ParentStyle;
				parentStyle8.method_35(parentStyle8.method_34() | 0x8000000u);
				break;
			}
			case BorderType.LeftBorder:
			{
				Style parentStyle7 = borders.ParentStyle;
				parentStyle7.method_35(parentStyle7.method_34() | 0x1000000u);
				break;
			}
			case BorderType.RightBorder:
			{
				Style parentStyle6 = borders.ParentStyle;
				parentStyle6.method_35(parentStyle6.method_34() | 0x2000000u);
				break;
			}
			case BorderType.TopBorder:
			{
				Style parentStyle5 = borders.ParentStyle;
				parentStyle5.method_35(parentStyle5.method_34() | 0x4000000u);
				break;
			}
			case BorderType.Horizontal:
			{
				Style parentStyle4 = borders.ParentStyle;
				parentStyle4.method_35(parentStyle4.method_34() | 0x10000000u);
				break;
			}
			case BorderType.Vertical:
			{
				Style parentStyle3 = borders.ParentStyle;
				parentStyle3.method_35(parentStyle3.method_34() | 0x80000000u);
				break;
			}
			case BorderType.DiagonalUp:
			{
				Style parentStyle2 = borders.ParentStyle;
				parentStyle2.method_35(parentStyle2.method_34() | 0x20000000u);
				break;
			}
			case BorderType.DiagonalDown:
			{
				Style parentStyle = borders.ParentStyle;
				parentStyle.method_35(parentStyle.method_34() | 0x40000000u);
				break;
			}
			}
		}
	}

	/// <summary>
	///       Gets or sets the cell border type.
	///       </summary>
	public CellBorderType LineStyle
	{
		get
		{
			return lineStyle;
		}
		set
		{
			lineStyle = value;
			if (borders.ParentStyle != null)
			{
				borders.ParentStyle.method_24(bool_0: true);
			}
			switch (borderType)
			{
			case BorderType.BottomBorder:
			{
				Style parentStyle8 = borders.ParentStyle;
				parentStyle8.method_35(parentStyle8.method_34() | 0x8000000u);
				break;
			}
			case BorderType.LeftBorder:
			{
				Style parentStyle7 = borders.ParentStyle;
				parentStyle7.method_35(parentStyle7.method_34() | 0x1000000u);
				break;
			}
			case BorderType.RightBorder:
			{
				Style parentStyle6 = borders.ParentStyle;
				parentStyle6.method_35(parentStyle6.method_34() | 0x2000000u);
				break;
			}
			case BorderType.TopBorder:
			{
				Style parentStyle5 = borders.ParentStyle;
				parentStyle5.method_35(parentStyle5.method_34() | 0x4000000u);
				break;
			}
			case BorderType.Horizontal:
			{
				Style parentStyle4 = borders.ParentStyle;
				parentStyle4.method_35(parentStyle4.method_34() | 0x10000000u);
				break;
			}
			case BorderType.Vertical:
			{
				Style parentStyle3 = borders.ParentStyle;
				parentStyle3.method_35(parentStyle3.method_34() | 0x80000000u);
				break;
			}
			case BorderType.DiagonalUp:
			{
				Style parentStyle2 = borders.ParentStyle;
				parentStyle2.method_35(parentStyle2.method_34() | 0x20000000u);
				break;
			}
			case BorderType.DiagonalDown:
			{
				Style parentStyle = borders.ParentStyle;
				parentStyle.method_35(parentStyle.method_34() | 0x40000000u);
				break;
			}
			}
		}
	}

	internal Border(BorderCollection borderCollection_0)
	{
		borders = borderCollection_0;
		InternalColor = new InternalColor(bool_0: false);
		InternalColor.method_3(bool_0: true);
	}

	internal Border(BorderCollection borderCollection_0, BorderType borderType_0)
	{
		borders = borderCollection_0;
		InternalColor = new InternalColor(bool_0: false);
		InternalColor.method_3(bool_0: true);
		borderType = borderType_0;
	}

	[SpecialName]
	internal BorderType method_0()
	{
		return borderType;
	}

	[SpecialName]
	internal void method_1(BorderType borderType_0)
	{
		borderType = borderType_0;
	}

	internal void method_2(CellBorderType cellBorderType_0)
	{
		lineStyle = cellBorderType_0;
	}

	internal void Copy(Border border_0)
	{
		if (border_0.InternalColor.ColorType == ColorType.IndexedColor && border_0.borders.ParentStyle.method_5() != borders.ParentStyle.method_5())
		{
			InternalColor.SetColor(ColorType.RGB, border_0.InternalColor.method_7(border_0.borders.ParentStyle.method_5().Workbook));
		}
		else
		{
			InternalColor.method_19(border_0.InternalColor);
		}
		lineStyle = border_0.lineStyle;
	}

	internal bool method_3(Border border_0, Workbook workbook_0, Workbook workbook_1)
	{
		if (lineStyle != border_0.lineStyle)
		{
			return false;
		}
		if (lineStyle != 0 && InternalColor.method_14(border_0.InternalColor, workbook_0, workbook_1))
		{
			return false;
		}
		return true;
	}

	internal bool method_4(Border border_0)
	{
		if (lineStyle != border_0.lineStyle)
		{
			return false;
		}
		if (lineStyle != 0 && InternalColor.method_13(border_0.InternalColor))
		{
			return false;
		}
		return true;
	}
}
