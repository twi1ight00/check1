using System.Runtime.CompilerServices;
using Aspose.Cells;
using ns15;

namespace ns26;

internal class Class1503
{
	private string string_0;

	private double double_0;

	private bool bool_0;

	private Enum212 enum212_0;

	internal string Name
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	internal double RowHeight
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	[SpecialName]
	internal bool method_0()
	{
		return bool_0;
	}

	[SpecialName]
	internal void method_1(bool bool_1)
	{
		bool_0 = bool_1;
	}

	[SpecialName]
	internal Enum212 method_2()
	{
		return enum212_0;
	}

	[SpecialName]
	internal void method_3(Enum212 enum212_1)
	{
		enum212_0 = enum212_1;
	}

	internal Class1503(Row row_0, double double_1)
	{
		double_0 = double_1;
		bool_0 = row_0.IsHeightMatched;
	}

	internal Class1503(Cells cells_0, int int_0)
	{
		string_0 = "ro" + Class1516.smethod_13(int_0);
		double_0 = cells_0.StandardHeight / 72.0;
		bool_0 = cells_0.IsDefaultRowHeightMatched;
	}

	internal Class1503()
	{
	}

	internal bool Equals(Row row_0, double double_1)
	{
		if (row_0.IsHeightMatched != bool_0)
		{
			return false;
		}
		if (!double_1.Equals(double_0))
		{
			return false;
		}
		return true;
	}
}
