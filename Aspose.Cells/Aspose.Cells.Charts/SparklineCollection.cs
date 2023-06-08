using System.Collections;
using System.Runtime.CompilerServices;
using System.Text;
using ns2;
using ns7;

namespace Aspose.Cells.Charts;

/// <summary>
///       Encapsulates a collection of <see cref="T:Aspose.Cells.Charts.Sparkline" /> objects.
///       </summary>
public class SparklineCollection : CollectionBase
{
	private SparklineGroup sparklineGroup_0;

	/// <summary>
	///       Gets the <see cref="T:Aspose.Cells.Charts.Sparkline" /> element at the specified index.
	///       </summary>
	/// <param name="index">The zero based index of the element.</param>
	/// <returns>The element at the specified index.</returns>
	public Sparkline this[int index] => (Sparkline)base.InnerList[index];

	internal SparklineCollection(SparklineGroup sparklineGroup_1, string string_0, bool bool_0, CellArea cellArea_0)
	{
		sparklineGroup_0 = sparklineGroup_1;
		Reset(string_0, bool_0, cellArea_0);
	}

	internal SparklineCollection(SparklineGroup sparklineGroup_1)
	{
		sparklineGroup_0 = sparklineGroup_1;
	}

	internal void method_0(CellArea cellArea_0)
	{
		int num = method_6(cellArea_0);
		if (num != base.InnerList.Count)
		{
			throw new CellsException(ExceptionType.InvalidData, "Invalid Location range");
		}
		if (cellArea_0.StartColumn == cellArea_0.EndColumn)
		{
			for (int i = 0; i < num; i++)
			{
				Sparkline sparkline = (Sparkline)base.InnerList[i];
				sparkline.method_2(cellArea_0.StartRow + i);
				sparkline.method_3(cellArea_0.StartColumn);
			}
			return;
		}
		if (cellArea_0.StartRow == cellArea_0.EndRow)
		{
			for (int j = 0; j < num; j++)
			{
				Sparkline sparkline2 = (Sparkline)base.InnerList[j];
				sparkline2.method_2(cellArea_0.StartRow);
				sparkline2.method_3(cellArea_0.StartColumn + j);
			}
			return;
		}
		throw new CellsException(ExceptionType.InvalidData, "Location reference cells must in same column or row");
	}

	internal void Reset(string string_0, bool bool_0, CellArea cellArea_0)
	{
		Class1309 @class = new Class1309(method_3());
		@class.Values = string_0;
		@class.GetRange();
		if (bool_0)
		{
			if (@class.bool_2 != @class.bool_3)
			{
				throw new CellsException(ExceptionType.InvalidData, "The reference for the data range is invalid");
			}
		}
		else if (@class.bool_0 != @class.bool_1)
		{
			throw new CellsException(ExceptionType.InvalidData, "The reference for the data range is invalid");
		}
		int num = method_5(@class, bool_0);
		if (num != method_6(cellArea_0))
		{
			throw new CellsException(ExceptionType.InvalidData, "The reference for the location or data range is invalid");
		}
		base.InnerList.Clear();
		for (int i = 0; i < num; i++)
		{
			Sparkline value = new Sparkline(this);
			base.InnerList.Add(value);
		}
		method_7(@class, bool_0);
		method_0(cellArea_0);
	}

	[SpecialName]
	internal SparklineGroup method_1()
	{
		return sparklineGroup_0;
	}

	internal void method_2(Sparkline sparkline_0)
	{
		base.InnerList.Add(sparkline_0);
	}

	internal void Remove(object object_0)
	{
		base.InnerList.Remove(object_0);
	}

	[SpecialName]
	internal Worksheet method_3()
	{
		return sparklineGroup_0.SparklineGroupCollection.method_0();
	}

	[SpecialName]
	internal WorksheetCollection method_4()
	{
		return sparklineGroup_0.SparklineGroupCollection.method_0().Workbook.Worksheets;
	}

	private int method_5(Class1309 class1309_0, bool bool_0)
	{
		if (bool_0)
		{
			return class1309_0.int_3 - class1309_0.int_1 + 1;
		}
		return class1309_0.int_2 - class1309_0.int_0 + 1;
	}

	private int method_6(CellArea cellArea_0)
	{
		if (cellArea_0.StartColumn == cellArea_0.EndColumn)
		{
			return cellArea_0.EndRow - cellArea_0.StartRow + 1;
		}
		if (cellArea_0.StartRow != cellArea_0.EndRow)
		{
			throw new CellsException(ExceptionType.InvalidData, "Location reference cells must in same column or row");
		}
		return cellArea_0.EndColumn - cellArea_0.StartColumn + 1;
	}

	private void method_7(Class1309 class1309_0, bool bool_0)
	{
		int num = method_5(class1309_0, bool_0);
		if (num != base.InnerList.Count)
		{
			throw new CellsException(ExceptionType.InvalidData, "Invalid data range");
		}
		if (bool_0)
		{
			for (int i = 0; i < num; i++)
			{
				string text = method_9(class1309_0.int_0, class1309_0.bool_0, i + class1309_0.int_1, class1309_0.bool_2);
				string text2 = method_9(class1309_0.int_2, class1309_0.bool_1, i + class1309_0.int_1, class1309_0.bool_2);
				Sparkline sparkline = (Sparkline)base.InnerList[i];
				sparkline.DataRange = method_8(class1309_0.string_1) + "!" + text + ":" + text2;
			}
		}
		else
		{
			for (int j = 0; j < num; j++)
			{
				string text3 = method_9(j + class1309_0.int_0, class1309_0.bool_0, class1309_0.int_1, class1309_0.bool_2);
				string text4 = method_9(j + class1309_0.int_0, class1309_0.bool_0, class1309_0.int_3, class1309_0.bool_3);
				Sparkline sparkline2 = (Sparkline)base.InnerList[j];
				sparkline2.DataRange = method_8(class1309_0.string_1) + "!" + text3 + ":" + text4;
			}
		}
	}

	private string method_8(string string_0)
	{
		if (Class1677.smethod_21(string_0))
		{
			return "'" + string_0 + "'";
		}
		return string_0;
	}

	private string method_9(int int_0, bool bool_0, int int_1, bool bool_1)
	{
		Class1677.CheckCell(int_0, int_1);
		int_0++;
		StringBuilder stringBuilder = new StringBuilder();
		if (bool_1)
		{
			stringBuilder.Append("$");
		}
		stringBuilder.Append(CellsHelper.ColumnIndexToName(int_1));
		if (bool_0)
		{
			stringBuilder.Append("$");
		}
		stringBuilder.Append(int_0.ToString());
		return stringBuilder.ToString();
	}

	internal int InsertRows(Cells cells_0, int int_0, int int_1, bool bool_0)
	{
		for (int i = 0; i < base.InnerList.Count; i++)
		{
			Sparkline sparkline = (Sparkline)base.InnerList[i];
			if (sparkline.InsertRows(cells_0, int_0, int_1, bool_0))
			{
				Remove(sparkline);
			}
		}
		return base.Count;
	}

	internal int InsertColumns(Cells cells_0, int int_0, int int_1, bool bool_0)
	{
		for (int i = 0; i < base.InnerList.Count; i++)
		{
			Sparkline sparkline = (Sparkline)base.InnerList[i];
			if (sparkline.InsertColumns(cells_0, int_0, int_1, bool_0))
			{
				Remove(sparkline);
			}
		}
		return base.Count;
	}
}
