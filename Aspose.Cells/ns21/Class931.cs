using System.Drawing;
using System.Runtime.CompilerServices;
using Aspose.Cells.Drawing;
using ns2;
using ns52;

namespace ns21;

internal class Class931
{
	private Shape shape_0;

	internal Color ForeColor
	{
		get
		{
			Color color_ = Color.FromArgb(8421504);
			return method_0().GetColor(513, color_);
		}
	}

	internal double WeightPt
	{
		get
		{
			int num = method_0().method_4(527, 256);
			return num;
		}
	}

	public Class931(Shape shape_1)
	{
		shape_0 = shape_1;
	}

	[SpecialName]
	internal Class1711 method_0()
	{
		return shape_0.method_27().method_2();
	}

	[SpecialName]
	public Enum130 method_1()
	{
		return (Enum130)method_0().method_4(512, 0);
	}

	[SpecialName]
	internal Color method_2()
	{
		Color color_ = Color.FromArgb(13355979);
		return method_0().GetColor(514, color_);
	}

	[SpecialName]
	internal double method_3()
	{
		return method_0().method_7(516, 1f);
	}

	[SpecialName]
	internal double method_4()
	{
		int num = method_0().method_4(517, 25400);
		return (double)num / Class1391.double_0;
	}

	[SpecialName]
	internal double method_5()
	{
		int num = method_0().method_4(518, 25400);
		return (double)num / Class1391.double_0;
	}

	[SpecialName]
	internal double method_6()
	{
		int num = method_0().method_4(519, 25400);
		return (double)num / Class1391.double_0;
	}

	[SpecialName]
	internal double method_7()
	{
		int num = method_0().method_4(520, 25400);
		return (double)num / Class1391.double_0;
	}

	[SpecialName]
	internal double method_8()
	{
		return method_0().method_7(521, 1f);
	}

	[SpecialName]
	internal double method_9()
	{
		return method_0().method_7(522, 0f);
	}

	[SpecialName]
	internal double method_10()
	{
		return method_0().method_7(523, 0f);
	}

	[SpecialName]
	internal double method_11()
	{
		return method_0().method_7(524, 1f);
	}

	[SpecialName]
	internal double method_12()
	{
		return method_0().method_7(525, 0f);
	}

	[SpecialName]
	internal double method_13()
	{
		return method_0().method_7(526, 0f);
	}

	[SpecialName]
	internal double method_14()
	{
		int num = method_0().method_4(528, 0);
		return (double)num / Class1391.double_0;
	}

	[SpecialName]
	internal double method_15()
	{
		int num = method_0().method_4(529, 0);
		return (double)num / Class1391.double_0;
	}

	[SpecialName]
	internal bool method_16()
	{
		return method_0().method_5(575, 1, bool_0: false);
	}

	[SpecialName]
	internal bool method_17()
	{
		return method_0().method_5(575, 0, bool_0: false);
	}
}
