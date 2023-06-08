using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;

namespace ns18;

internal class Class1443
{
	private Matrix matrix_0 = new Matrix();

	private Class1439 class1439_0 = Class1439.smethod_0();

	private Class1439 class1439_1 = Class1439.smethod_0();

	private Color color_0 = Color.Black;

	private Color color_1 = Color.Black;

	private float float_0;

	private Class954 class954_0;

	private float float_1;

	private int int_0;

	private float float_2 = 1f;

	private int int_1;

	private int int_2;

	private float float_3 = 10f;

	private Class953 class953_0;

	internal Class954 TextFont => class954_0;

	internal Class1443()
	{
	}

	internal Class1443 Clone()
	{
		Class1443 @class = (Class1443)MemberwiseClone();
		@class.matrix_0 = matrix_0.Clone();
		return @class;
	}

	[SpecialName]
	internal Matrix method_0()
	{
		return matrix_0;
	}

	[SpecialName]
	internal Class1439 method_1()
	{
		return class1439_0;
	}

	[SpecialName]
	internal void method_2(Class1439 class1439_2)
	{
		class1439_0 = class1439_2;
	}

	[SpecialName]
	internal Class1439 method_3()
	{
		return class1439_1;
	}

	[SpecialName]
	internal void method_4(Class1439 class1439_2)
	{
		class1439_1 = class1439_2;
	}

	[SpecialName]
	internal Color method_5()
	{
		return color_0;
	}

	[SpecialName]
	internal void method_6(Color color_2)
	{
		color_0 = color_2;
	}

	[SpecialName]
	internal Color method_7()
	{
		return color_1;
	}

	[SpecialName]
	internal void method_8(Color color_2)
	{
		color_1 = color_2;
	}

	[SpecialName]
	internal float method_9()
	{
		return float_0;
	}

	[SpecialName]
	internal void method_10(float float_4)
	{
		float_0 = float_4;
	}

	[SpecialName]
	internal void method_11(Class954 class954_1)
	{
		class954_0 = class954_1;
	}

	[SpecialName]
	internal float method_12()
	{
		return float_1;
	}

	[SpecialName]
	internal void method_13(float float_4)
	{
		float_1 = float_4;
	}

	[SpecialName]
	internal int method_14()
	{
		return int_0;
	}

	[SpecialName]
	internal void method_15(int int_3)
	{
		int_0 = int_3;
	}

	[SpecialName]
	internal float method_16()
	{
		return float_2;
	}

	[SpecialName]
	internal void method_17(float float_4)
	{
		float_2 = float_4;
	}

	[SpecialName]
	internal int method_18()
	{
		return int_1;
	}

	[SpecialName]
	internal void method_19(int int_3)
	{
		int_1 = int_3;
	}

	[SpecialName]
	internal int method_20()
	{
		return int_2;
	}

	[SpecialName]
	internal void method_21(int int_3)
	{
		int_2 = int_3;
	}

	[SpecialName]
	internal float method_22()
	{
		return float_3;
	}

	[SpecialName]
	internal void method_23(float float_4)
	{
		float_3 = float_4;
	}

	[SpecialName]
	internal Class953 method_24()
	{
		return class953_0;
	}

	[SpecialName]
	internal void method_25(Class953 class953_1)
	{
		class953_0 = class953_1;
	}
}
