using System.Drawing;
using Aspose.Cells;
using ns12;
using ns18;
using ns2;
using ns22;

namespace ns44;

internal abstract class Class984
{
	[Attribute0(true)]
	public abstract Class454 vmethod_0(RectangleF rectangleF_0, double[] double_0, TextAlignmentType textAlignmentType_0);

	[Attribute0(true)]
	public abstract bool vmethod_1();

	public static object Calculate(Cell cell_0, ConditionalFormattingValue conditionalFormattingValue_0, CellArea cellArea_0, Class1658 class1658_0)
	{
		object obj = null;
		try
		{
			Class1661 class1661_ = cell_0.method_4().method_19().Formula.method_11(cell_0, conditionalFormattingValue_0.method_6(), -1);
			obj = class1658_0.method_2(class1661_, cell_0);
		}
		catch
		{
		}
		if (conditionalFormattingValue_0.Type == FormatConditionValueType.Percentile)
		{
			string string_ = "=PERCENTILE(" + CellsHelper.CellIndexToName(cellArea_0.StartRow, cellArea_0.StartColumn) + ":" + CellsHelper.CellIndexToName(cellArea_0.EndRow, cellArea_0.EndColumn) + "," + Class1025.smethod_8((double)obj / 100.0) + ")";
			byte[] byte_ = cell_0.method_4().method_19().Formula.method_3(string_, cell_0.Row, cell_0.Column, Enum226.const_0, Enum227.const_1, bool_0: true, bool_1: false);
			Class1661 class1661_2 = cell_0.method_4().method_19().Formula.method_11(cell_0, byte_, 0);
			obj = class1658_0.method_2(class1661_2, cell_0);
		}
		else if (conditionalFormattingValue_0.Type == FormatConditionValueType.Percent)
		{
			double num;
			if (conditionalFormattingValue_0.double_0 != double.MinValue)
			{
				num = conditionalFormattingValue_0.double_0;
			}
			else
			{
				string string_2 = "=Max(" + CellsHelper.CellIndexToName(cellArea_0.StartRow, cellArea_0.StartColumn) + ":" + CellsHelper.CellIndexToName(cellArea_0.EndRow, cellArea_0.EndColumn) + ")";
				byte[] byte_2 = cell_0.method_4().method_19().Formula.method_3(string_2, cell_0.Row, cell_0.Column, Enum226.const_0, Enum227.const_1, bool_0: true, bool_1: false);
				Class1661 class1661_3 = cell_0.method_4().method_19().Formula.method_11(cell_0, byte_2, 0);
				num = (conditionalFormattingValue_0.double_0 = (double)class1658_0.method_2(class1661_3, cell_0));
			}
			double num2;
			if (conditionalFormattingValue_0.double_1 != double.MaxValue)
			{
				num2 = conditionalFormattingValue_0.double_1;
			}
			else
			{
				string string_2 = "=Min(" + CellsHelper.CellIndexToName(cellArea_0.StartRow, cellArea_0.StartColumn) + ":" + CellsHelper.CellIndexToName(cellArea_0.EndRow, cellArea_0.EndColumn) + ")";
				byte[] byte_2 = cell_0.method_4().method_19().Formula.method_3(string_2, cell_0.Row, cell_0.Column, Enum226.const_0, Enum227.const_1, bool_0: true, bool_1: false);
				Class1661 class1661_3 = cell_0.method_4().method_19().Formula.method_11(cell_0, byte_2, 0);
				num2 = (conditionalFormattingValue_0.double_1 = (double)class1658_0.method_2(class1661_3, cell_0));
			}
			obj = (num - num2) * ((double)obj / 100.0) + num2;
		}
		else if (conditionalFormattingValue_0.Type != FormatConditionValueType.Max && conditionalFormattingValue_0.Type != FormatConditionValueType.AutomaticMax)
		{
			if (conditionalFormattingValue_0.Type == FormatConditionValueType.Min || conditionalFormattingValue_0.Type == FormatConditionValueType.AutomaticMin)
			{
				if (conditionalFormattingValue_0.double_1 != double.MaxValue)
				{
					obj = conditionalFormattingValue_0.double_1;
				}
				else
				{
					string string_3 = "=Min(" + CellsHelper.CellIndexToName(cellArea_0.StartRow, cellArea_0.StartColumn) + ":" + CellsHelper.CellIndexToName(cellArea_0.EndRow, cellArea_0.EndColumn) + ")";
					byte[] byte_3 = cell_0.method_4().method_19().Formula.method_3(string_3, cell_0.Row, cell_0.Column, Enum226.const_0, Enum227.const_1, bool_0: true, bool_1: false);
					Class1661 class1661_4 = cell_0.method_4().method_19().Formula.method_11(cell_0, byte_3, 0);
					obj = class1658_0.method_2(class1661_4, cell_0);
					conditionalFormattingValue_0.double_1 = (double)obj;
				}
			}
		}
		else if (conditionalFormattingValue_0.double_0 != double.MinValue)
		{
			obj = conditionalFormattingValue_0.double_0;
		}
		else
		{
			string string_4 = "=Max(" + CellsHelper.CellIndexToName(cellArea_0.StartRow, cellArea_0.StartColumn) + ":" + CellsHelper.CellIndexToName(cellArea_0.EndRow, cellArea_0.EndColumn) + ")";
			byte[] byte_4 = cell_0.method_4().method_19().Formula.method_3(string_4, cell_0.Row, cell_0.Column, Enum226.const_0, Enum227.const_1, bool_0: true, bool_1: false);
			Class1661 class1661_5 = cell_0.method_4().method_19().Formula.method_11(cell_0, byte_4, 0);
			obj = class1658_0.method_2(class1661_5, cell_0);
			conditionalFormattingValue_0.double_0 = (double)obj;
		}
		return obj;
	}
}
