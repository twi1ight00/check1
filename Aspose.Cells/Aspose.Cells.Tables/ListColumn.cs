using System.Runtime.CompilerServices;
using System.Text;
using ns2;

namespace Aspose.Cells.Tables;

/// <summary>
///       Represents a column in a list.
///       </summary>
public class ListColumn
{
	private ListColumnCollection listColumnCollection_0;

	private string string_0;

	internal XmlColumnProperty xmlColumnProperty_0;

	internal int int_0;

	private string string_1;

	private int int_1;

	private TotalsCalculation totalsCalculation_0;

	private string string_2;

	private bool bool_0;

	private string string_3;

	private bool bool_1;

	internal byte[] byte_0;

	internal byte[] byte_1;

	internal int int_2;

	internal string string_4;

	internal string string_5;

	private string string_6;

	private string string_7;

	internal int[] int_3 = new int[3] { -1, -1, -1 };

	internal Style style_0;

	internal Style style_1;

	internal int int_4;

	internal int int_5 = -1;

	internal uint uint_0;

	private int int_6 = -1;

	/// <summary>
	///       Gets and sets the name of the column.
	///       </summary>
	/// <remarks>
	///       If sets the name of the column, the according cell' value will be changed too.
	///       </remarks>
	public string Name
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
			ListObject listObject = listColumnCollection_0.method_2();
			if (listObject.ShowHeaderRow)
			{
				Cells cells = listObject.method_12().method_4().Cells;
				cells.GetCell(listObject.StartRow, method_5(), bool_2: false).PutValue(value);
			}
		}
	}

	/// <summary>
	///       Gets and sets the type of calculation in the Totals row of the list column.
	///       </summary>
	public TotalsCalculation TotalsCalculation
	{
		get
		{
			return totalsCalculation_0;
		}
		set
		{
			if (totalsCalculation_0 == value)
			{
				return;
			}
			ListObject listObject = listColumnCollection_0.method_2();
			totalsCalculation_0 = value;
			if (listObject.ShowTotals)
			{
				Cells cells = listObject.method_12().method_4().Cells;
				Cell cell = cells.GetCell(listObject.EndRow, method_5(), bool_2: false);
				if (value == TotalsCalculation.None)
				{
					cell.PutValue((object)null);
				}
				else
				{
					cell.Formula = method_7(value);
				}
			}
		}
	}

	/// <summary>
	///       Gets the range of this list column.
	///       </summary>
	public Range Range
	{
		get
		{
			ListObject listObject = listColumnCollection_0.method_2();
			_ = listObject.StartColumn;
			_ = Index;
			_ = listObject.StartRow;
			_ = listObject.EndRow;
			return null;
		}
	}

	internal int Index => int_1;

	[SpecialName]
	internal bool method_0()
	{
		return listColumnCollection_0.method_2().method_53();
	}

	internal ListColumn(ListColumnCollection listColumnCollection_1, string string_8, int int_7)
	{
		string_0 = string_8;
		listColumnCollection_0 = listColumnCollection_1;
		int_1 = int_7;
	}

	internal ListColumn(ListColumnCollection listColumnCollection_1)
	{
		listColumnCollection_0 = listColumnCollection_1;
	}

	internal void Copy(ListColumn listColumn_0)
	{
		listColumnCollection_0.method_2().method_12().method_4()
			.method_2();
		string_0 = listColumn_0.string_0;
		int_1 = listColumn_0.int_1;
		string_5 = listColumn_0.string_5;
		string_4 = listColumn_0.string_4;
		totalsCalculation_0 = listColumn_0.totalsCalculation_0;
		string_3 = listColumn_0.string_3;
		bool_1 = listColumn_0.bool_1;
		bool_0 = listColumn_0.bool_0;
		string_2 = listColumn_0.string_2;
		string_7 = listColumn_0.string_7;
		string_6 = listColumn_0.string_6;
		for (int i = 0; i < listColumn_0.int_3.Length; i++)
		{
			int_3[i] = listColumn_0.int_3[i];
			if (listColumn_0.int_3[i] != -1 && method_1() != listColumn_0.method_1())
			{
				int_3[i] = method_1().method_56().Add(listColumn_0.method_1().method_56()[i]);
			}
		}
	}

	[SpecialName]
	private WorksheetCollection method_1()
	{
		return listColumnCollection_0.method_2().method_12().method_4()
			.method_2();
	}

	internal void method_2(string string_8)
	{
		string_0 = string_8;
	}

	internal void method_3(string string_8)
	{
		string_1 = string_8;
	}

	internal void method_4(int int_7)
	{
		int_1 = int_7;
	}

	[SpecialName]
	internal int method_5()
	{
		return listColumnCollection_0.method_2().StartColumn + Index;
	}

	internal void method_6(TotalsCalculation totalsCalculation_1)
	{
		totalsCalculation_0 = totalsCalculation_1;
	}

	internal void InsertRows(int int_7, int int_8)
	{
	}

	private string method_7(TotalsCalculation totalsCalculation_1)
	{
		StringBuilder stringBuilder = new StringBuilder("=subtotal(");
		int value = method_8(totalsCalculation_1);
		stringBuilder.Append(value);
		stringBuilder.Append(",");
		Range dataRange = listColumnCollection_0.method_2().DataRange;
		string value2 = CellsHelper.CellIndexToName(dataRange.FirstRow, method_5());
		stringBuilder.Append(value2);
		stringBuilder.Append(":");
		value2 = CellsHelper.CellIndexToName(dataRange.FirstRow + dataRange.RowCount - 1, method_5());
		stringBuilder.Append(value2);
		stringBuilder.Append(")");
		return stringBuilder.ToString();
	}

	private int method_8(TotalsCalculation totalsCalculation_1)
	{
		return totalsCalculation_1 switch
		{
			TotalsCalculation.Average => 101, 
			TotalsCalculation.Count => 103, 
			TotalsCalculation.CountNums => 102, 
			TotalsCalculation.Max => 104, 
			TotalsCalculation.Min => 105, 
			TotalsCalculation.Sum => 109, 
			TotalsCalculation.StdDev => 107, 
			TotalsCalculation.Var => 110, 
			_ => 109, 
		};
	}

	internal void method_9(string string_8, bool bool_2)
	{
		bool_0 = bool_2;
		string_2 = string_8;
	}

	[SpecialName]
	internal string method_10()
	{
		return string_2;
	}

	internal void method_11(string string_8, bool bool_2)
	{
		bool_1 = bool_2;
		string_3 = string_8;
	}

	[SpecialName]
	internal bool method_12()
	{
		return bool_1;
	}

	[SpecialName]
	internal string method_13()
	{
		return string_3;
	}

	[SpecialName]
	internal string method_14()
	{
		return string_6;
	}

	[SpecialName]
	internal void method_15(string string_8)
	{
		string_6 = string_8;
	}

	[SpecialName]
	internal string method_16()
	{
		return string_7;
	}

	[SpecialName]
	internal void method_17(string string_8)
	{
		string_7 = string_8;
	}

	internal Class1685 method_18(Style style_2)
	{
		if (style_2 != null)
		{
			Class1685 @class = new Class1685();
			@class.method_1(style_2);
			if (@class.Count < 1)
			{
				@class = null;
			}
			return @class;
		}
		return null;
	}

	[SpecialName]
	internal Style method_19()
	{
		if (style_0 == null)
		{
			style_0 = new Style(method_1());
			style_0.method_16(0);
		}
		return style_0;
	}

	[SpecialName]
	internal Style method_20()
	{
		if (style_1 == null)
		{
			style_1 = new Style(method_1());
			style_1.method_16(0);
		}
		return style_1;
	}

	[SpecialName]
	internal int method_21()
	{
		return int_6;
	}

	[SpecialName]
	internal void method_22(int int_7)
	{
		int_6 = int_7;
	}
}
