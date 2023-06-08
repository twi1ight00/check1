using System.Runtime.CompilerServices;

namespace Aspose.Cells.Tables;

/// <summary>
///       Represents the element of the table style.
///       </summary>
public class TableStyleElement
{
	private TableStyleElementCollection tableStyleElementCollection_0;

	private int int_0 = 1;

	private TableStyleElementType tableStyleElementType_0;

	private Style style_0;

	internal int int_1 = -1;

	/// <summary>
	///       Number of rows or columns in a single band of striping.
	///       Applies only when type is firstRowStripe, secondRowStripe, firstColumnStripe, or secondColumnStripe.
	///       </summary>
	public int Size
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	/// <summary>
	///       Gets the element type.
	///       </summary>
	public TableStyleElementType Type => tableStyleElementType_0;

	internal TableStyleElement(TableStyleElementCollection tableStyleElementCollection_1, TableStyleElementType tableStyleElementType_1)
	{
		tableStyleElementCollection_0 = tableStyleElementCollection_1;
		tableStyleElementType_0 = tableStyleElementType_1;
	}

	internal void Copy(TableStyleElement tableStyleElement_0)
	{
		int_0 = tableStyleElement_0.int_0;
		tableStyleElementType_0 = tableStyleElement_0.tableStyleElementType_0;
		if (tableStyleElement_0.int_1 != -1 && method_0() != tableStyleElement_0.method_0())
		{
			int_1 = method_0().method_56().Add(tableStyleElement_0.GetElementStyle());
		}
		else
		{
			int_1 = tableStyleElement_0.int_1;
		}
	}

	[SpecialName]
	private WorksheetCollection method_0()
	{
		return tableStyleElementCollection_0.method_0().method_0().method_4();
	}

	/// <summary>
	///       Gets the element style.
	///       </summary>
	/// <returns>Returns the <see cref="T:Aspose.Cells.Style" /> object.</returns>
	public Style GetElementStyle()
	{
		Style style = new Style(method_0());
		if (style_0 != null)
		{
			style.Copy(style_0);
			return style;
		}
		if (int_1 == -1)
		{
			return style;
		}
		Style style2 = method_0().method_56()[int_1];
		style.Copy(style2);
		return style;
	}

	/// <summary>
	///       Sets the element style.
	///       </summary>
	/// <param name="style">The element style.</param>
	public void SetElementStyle(Style style)
	{
		int_1 = method_0().method_56().Add(style);
	}

	internal Style method_1()
	{
		if (style_0 == null)
		{
			if (int_1 == -1)
			{
				return null;
			}
			return method_0().method_56()[int_1];
		}
		return style_0;
	}

	internal void method_2(Style style_1)
	{
		style_0 = style_1;
	}
}
