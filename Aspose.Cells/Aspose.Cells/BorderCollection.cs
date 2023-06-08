using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using ns22;

namespace Aspose.Cells;

/// <summary>
///        Encapsulates a collection of <see cref="T:Aspose.Cells.Border" /> objects.
///        </summary>
/// <example>
///   <code>
///
///        [C#]
///
///        //Instantiating a Workbook object
///        Workbook workbook = new Workbook();
///
///        //Adding a new worksheet to the Excel object
///        workbook.Worksheets.Add();
///
///        //Obtaining the reference of the newly added worksheet by passing its sheet index
///        Worksheet worksheet = workbook.Worksheets[0];
///
///        //Accessing the "A1" cell from the worksheet
///        Cell cell = worksheet.Cells["A1"];
///
///        //Adding some value to the "A1" cell
///        cell.PutValue("Visit Aspose!");
///
///        Style style = cell.GetStyle();
///
///        //Setting the line style of the top border
///        style.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thick;
///
///        //Setting the color of the top border
///        style.Borders[BorderType.TopBorder].Color = Color.Black;
///
///        //Setting the line style of the bottom border
///        style.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thick;
///
///        //Setting the color of the bottom border
///        style.Borders[BorderType.BottomBorder].Color = Color.Black;
///
///        //Setting the line style of the left border
///        style.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thick;
///
///        //Setting the color of the left border
///        style.Borders[BorderType.LeftBorder].Color = Color.Black;
///
///        //Setting the line style of the right border
///        style.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thick;
///
///        //Setting the color of the right border
///        style.Borders[BorderType.RightBorder].Color = Color.Black;
///
///        cell.SetStyle(style);
///
///        //Saving the Excel file
///        workbook.Save("C:\\book1.xls");
///
///        [VB.NET]
///
///        'Instantiating a Workbook object
///        Dim workbook As Workbook = New Workbook()
///
///        'Adding a new worksheet to the Workbook object
///        workbook.Worksheets.Add()
///
///        'Obtaining the reference of the newly added worksheet by passing its sheet index
///        Dim worksheet As Worksheet = workbook.Worksheets(0)
///
///        'Accessing the "A1" cell from the worksheet
///        Dim cell As Cell = worksheet.Cells("A1")
///
///        'Adding some value to the "A1" cell
///        cell.PutValue("Visit Aspose!")
///
///        Dim style as Style = cell.GetStyle()
///
///        'Setting the line style of the top border
///        style.Borders(BorderType.TopBorder).LineStyle = CellBorderType.Thick
///
///        'Setting the color of the top border
///        style.Borders(BorderType.TopBorder).Color = Color.Black
///
///        'Setting the line style of the bottom border
///        style.Borders(BorderType.BottomBorder).LineStyle = CellBorderType.Thick
///
///        'Setting the color of the bottom border
///        style.Borders(BorderType.BottomBorder).Color = Color.Black
///
///        'Setting the line style of the left border
///        style.Borders(BorderType.LeftBorder).LineStyle = CellBorderType.Thick
///
///        'Setting the color of the left border
///        style.Borders(BorderType.LeftBorder).Color = Color.Black
///
///        'Setting the line style of the right border
///        style.Borders(BorderType.RightBorder).LineStyle = CellBorderType.Thick
///
///        'Setting the color of the right border
///        style.Borders(BorderType.RightBorder).Color = Color.Black
///
///        cell.SetStyle(style)
///
///        'Saving the Excel file
///        workbook.Save("C:\book1.xls")
///        </code>
/// </example>
[Serializable]
public class BorderCollection
{
	internal bool Outline;

	private Style m_Style;

	private Border[] borderList;

	/// <summary>
	///        Gets the <see cref="T:Aspose.Cells.Border" /> element at the specified index.
	///        </summary>
	/// <param name="borderType">The border to be retrieved.</param>
	/// <returns>The element at the specified index.</returns>
	public Border this[BorderType borderType]
	{
		get
		{
			switch (borderType)
			{
			case BorderType.BottomBorder:
				return borderList[0];
			case BorderType.LeftBorder:
				return borderList[3];
			case BorderType.RightBorder:
				return borderList[4];
			case BorderType.TopBorder:
				return borderList[5];
			default:
				return null;
			case BorderType.Horizontal:
				if (borderList[6] == null)
				{
					borderList[6] = new Border(this, BorderType.Horizontal);
				}
				return borderList[6];
			case BorderType.Vertical:
				if (borderList[7] == null)
				{
					borderList[7] = new Border(this, BorderType.Vertical);
				}
				return borderList[7];
			case BorderType.DiagonalUp:
				return borderList[2];
			case BorderType.DiagonalDown:
				return borderList[1];
			}
		}
	}

	/// <summary>
	///       Gets or sets the <see cref="T:System.Drawing.Color" /> of Diagonal lines.
	///       </summary>
	public Color DiagonalColor
	{
		get
		{
			if (borderList[2].LineStyle == CellBorderType.None)
			{
				return borderList[1].Color;
			}
			return borderList[2].Color;
		}
		set
		{
			InternalColor internalColor = new InternalColor(bool_0: false);
			if (!Class1178.smethod_0(value) && !(value == Color.Black))
			{
				internalColor.SetColor(ColorType.RGB, value.ToArgb());
			}
			else
			{
				internalColor.method_3(bool_0: true);
			}
			borderList[1].InternalColor = internalColor;
			borderList[2].InternalColor = internalColor;
		}
	}

	/// <summary>
	///       Gets or sets the style of Diagonal lines.
	///       </summary>
	public CellBorderType DiagonalStyle
	{
		get
		{
			if (borderList[2].LineStyle == CellBorderType.None)
			{
				return borderList[1].LineStyle;
			}
			return borderList[2].LineStyle;
		}
		set
		{
			borderList[1].LineStyle = value;
			borderList[2].LineStyle = value;
		}
	}

	internal Style ParentStyle => m_Style;

	internal BorderCollection(Style style_0)
	{
		m_Style = style_0;
		borderList = new Border[8];
		for (int i = 0; i < 6; i++)
		{
			Border border = new Border(this);
			switch (i)
			{
			case 0:
				border.method_1(BorderType.BottomBorder);
				break;
			case 1:
				border.method_1(BorderType.DiagonalDown);
				break;
			case 2:
				border.method_1(BorderType.DiagonalUp);
				break;
			case 3:
				border.method_1(BorderType.LeftBorder);
				break;
			case 4:
				border.method_1(BorderType.RightBorder);
				break;
			case 5:
				border.method_1(BorderType.TopBorder);
				break;
			}
			borderList[i] = border;
		}
	}

	[SpecialName]
	internal Border method_0()
	{
		return borderList[6];
	}

	[SpecialName]
	internal void method_1(Border border_0)
	{
		borderList[6] = border_0;
	}

	[SpecialName]
	internal Border method_2()
	{
		return borderList[7];
	}

	[SpecialName]
	internal void method_3(Border border_0)
	{
		borderList[7] = border_0;
	}

	[SpecialName]
	internal bool method_4()
	{
		if (borderList[0].LineStyle == CellBorderType.None && borderList[1].LineStyle == CellBorderType.None && borderList[2].LineStyle == CellBorderType.None && borderList[3].LineStyle == CellBorderType.None && borderList[4].LineStyle == CellBorderType.None && borderList[5].LineStyle == CellBorderType.None && (borderList[6] == null || borderList[6].LineStyle == CellBorderType.None))
		{
			if (borderList[7] != null)
			{
				return borderList[7].LineStyle != CellBorderType.None;
			}
			return false;
		}
		return true;
	}

	internal bool method_5(BorderCollection borderCollection_0, Workbook workbook_0, Workbook workbook_1)
	{
		if (borderCollection_0 == null)
		{
			return !method_4();
		}
		int num = 0;
		while (true)
		{
			if (num < 6)
			{
				Border border = borderList[num];
				Border border2 = borderCollection_0.borderList[num];
				if (border.LineStyle == border2.LineStyle)
				{
					if (border.LineStyle != 0 && border.InternalColor.method_14(border2.InternalColor, workbook_0, workbook_1))
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
		return false;
	}

	internal void method_6(CellBorderType cellBorderType_0, Color color_0)
	{
		for (int i = 0; i < 6; i++)
		{
			if (i != 1 && i != 2)
			{
				Border border = borderList[i];
				border.LineStyle = cellBorderType_0;
				border.Color = color_0;
			}
		}
	}

	/// <summary>
	///       Sets the <see cref="T:System.Drawing.Color" /> of all borders in the collection.
	///       </summary>
	/// <param name="color">Borders' <see cref="T:System.Drawing.Color" />.</param>
	public void SetColor(Color color)
	{
		for (int i = 0; i < 6; i++)
		{
			Border border = borderList[i];
			border.Color = color;
		}
	}

	/// <summary>
	///       Sets the style of all borders of the collection.
	///       </summary>
	/// <param name="style">Borders' style</param>
	public void SetStyle(CellBorderType style)
	{
		for (int i = 0; i < 6; i++)
		{
			Border border = borderList[i];
			border.LineStyle = style;
		}
	}

	[SpecialName]
	internal InternalColor method_7()
	{
		if (borderList[2].LineStyle == CellBorderType.None)
		{
			return borderList[1].InternalColor;
		}
		return borderList[2].InternalColor;
	}

	[SpecialName]
	internal byte method_8()
	{
		Border border = this[BorderType.DiagonalDown];
		Border border2 = this[BorderType.DiagonalUp];
		if (border.LineStyle != 0)
		{
			if (border2.LineStyle != 0)
			{
				return 3;
			}
			return 1;
		}
		if (border2.LineStyle != 0)
		{
			return 2;
		}
		return 0;
	}

	internal void Copy(BorderCollection borderCollection_0)
	{
		for (int i = 0; i < 6; i++)
		{
			Border border_ = borderCollection_0.borderList[i];
			Border border = borderList[i];
			border.Copy(border_);
		}
		for (int j = 6; j < 8; j++)
		{
			if (borderCollection_0.borderList[j] != null)
			{
				borderList[j] = new Border(this);
				borderList[j].Copy(borderCollection_0.borderList[j]);
			}
		}
	}
}
