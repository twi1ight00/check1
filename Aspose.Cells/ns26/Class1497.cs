using System.Runtime.CompilerServices;
using Aspose.Cells;
using ns15;

namespace ns26;

internal class Class1497
{
	private double double_0;

	private string string_0;

	private Enum212 enum212_0;

	internal double Width
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

	[SpecialName]
	internal Enum212 method_0()
	{
		return enum212_0;
	}

	[SpecialName]
	internal void method_1(Enum212 enum212_1)
	{
		enum212_0 = enum212_1;
	}

	internal Class1497()
	{
		enum212_0 = Enum212.const_0;
	}

	internal Class1497(Column column_0, double double_1)
	{
		double_0 = double_1;
		enum212_0 = Enum212.const_0;
	}

	internal Class1497(Cells cells_0, int int_0)
	{
		double_0 = cells_0.StandardWidthInch;
		string_0 = "co" + Class1516.smethod_13(int_0);
	}

	internal bool Equals(Column column_0, double double_1)
	{
		if (double_0.Equals(double_1))
		{
			return true;
		}
		return false;
	}
}
