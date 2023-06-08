using System.Runtime.CompilerServices;
using ns16;
using ns2;
using ns52;

namespace Aspose.Cells.Drawing;

/// <summary>
///       Represents the text frame in a Shape object.
///       </summary>
public class MsoTextFrame
{
	private Shape shape_0;

	/// <summary>
	///       Indicates if size of shape is adjusted automatically according to its content.
	///       </summary>
	public bool AutoSize
	{
		get
		{
			return method_0().method_5(191, 1, bool_0: false);
		}
		set
		{
			shape_0.method_62(Enum169.const_7);
			method_0().method_6(191, 1, value);
		}
	}

	/// <summary>
	///       Indicates whether the margin is auto calculated.
	///       </summary>
	public bool IsAutoMargin
	{
		get
		{
			return method_0().method_5(191, 3, bool_0: false);
		}
		set
		{
			method_0().method_6(191, 3, value);
		}
	}

	/// <summary>
	///       Returnt the left margin in unit of Points
	///       </summary>
	public double LeftMarginPt
	{
		get
		{
			return (double)method_1() / Class1391.double_0;
		}
		set
		{
			method_2((int)(value * Class1391.double_0 + 0.5));
		}
	}

	/// <summary>
	///       Returnt the right margin in unit of Points
	///       </summary>
	public double RightMarginPt
	{
		get
		{
			return (double)method_3() / Class1391.double_0;
		}
		set
		{
			method_4((int)(value * Class1391.double_0 + 0.5));
		}
	}

	/// <summary>
	///       Returnt the top margin in unit of Points
	///       </summary>
	public double TopMarginPt
	{
		get
		{
			return (double)method_5() / Class1391.double_0;
		}
		set
		{
			method_6((int)(value * Class1391.double_0 + 0.5));
		}
	}

	/// <summary>
	///       Returnt the bottom margin in unit of Points
	///       </summary>
	public double BottomMarginPt
	{
		get
		{
			return (double)method_7() / Class1391.double_0;
		}
		set
		{
			method_8((int)(value * Class1391.double_0 + 0.5));
		}
	}

	internal MsoTextFrame(Shape shape_1)
	{
		shape_0 = shape_1;
	}

	[SpecialName]
	internal Class1711 method_0()
	{
		return shape_0.method_27().method_2();
	}

	[SpecialName]
	internal int method_1()
	{
		return method_0().method_4(129, (int)(7.2 * Class1391.double_0 + 0.5));
	}

	[SpecialName]
	internal void method_2(int int_0)
	{
		method_0().method_1(129, Enum183.const_0, int_0);
	}

	[SpecialName]
	internal int method_3()
	{
		return method_0().method_4(131, (int)(7.2 * Class1391.double_0 + 0.5));
	}

	[SpecialName]
	internal void method_4(int int_0)
	{
		method_0().method_1(131, Enum183.const_0, int_0);
	}

	[SpecialName]
	internal int method_5()
	{
		return method_0().method_4(130, (int)(3.6 * Class1391.double_0 + 0.5));
	}

	[SpecialName]
	internal void method_6(int int_0)
	{
		method_0().method_1(130, Enum183.const_0, int_0);
	}

	[SpecialName]
	internal int method_7()
	{
		return method_0().method_4(132, (int)(3.6 * Class1391.double_0 + 0.5));
	}

	[SpecialName]
	internal void method_8(int int_0)
	{
		method_0().method_1(132, Enum183.const_0, int_0);
	}
}
