using System.Collections;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace ns18;

internal class Class1416
{
	private readonly Class1414 class1414_0;

	private Class1407 class1407_0;

	private readonly Stack stack_0;

	private readonly Class1408 class1408_0;

	private RectangleF rectangleF_0;

	private PointF pointF_0;

	internal Class1416(Class1414 class1414_1)
	{
		class1414_0 = class1414_1;
		class1407_0 = new Class1407(this);
		rectangleF_0 = Class1406.smethod_0();
		stack_0 = new Stack();
		if (class1414_0.method_2())
		{
			class1408_0 = new Class1408(bool_1: true);
			method_15();
		}
		else
		{
			class1408_0 = new Class1408(bool_1: false);
			method_16();
		}
	}

	internal void method_0()
	{
		stack_0.Push(class1407_0);
		class1407_0 = class1407_0.Clone();
	}

	internal void method_1()
	{
		class1407_0 = (Class1407)stack_0.Pop();
	}

	internal void method_2(PointF pointF_1)
	{
		rectangleF_0.Location = pointF_1;
	}

	internal void method_3(SizeF sizeF_0)
	{
		rectangleF_0.Size = sizeF_0;
	}

	[SpecialName]
	internal Class1414 method_4()
	{
		return class1414_0;
	}

	[SpecialName]
	internal Class1407 method_5()
	{
		return class1407_0;
	}

	[SpecialName]
	internal RectangleF method_6()
	{
		return rectangleF_0;
	}

	[SpecialName]
	internal void method_7(RectangleF rectangleF_1)
	{
		rectangleF_0 = rectangleF_1;
	}

	[SpecialName]
	internal PointF method_8()
	{
		return pointF_0;
	}

	[SpecialName]
	internal void method_9(PointF pointF_1)
	{
		pointF_0 = pointF_1;
	}

	[SpecialName]
	internal Class1408 method_10()
	{
		return class1408_0;
	}

	private void method_11(Color color_0)
	{
		Class1409 @class = new Class1409();
		if (color_0.IsEmpty)
		{
			@class.Style = Enum146.const_1;
		}
		else
		{
			@class.ForeColor = color_0;
		}
		class1408_0.Add(@class);
	}

	private void method_12(Color color_0)
	{
		Class1413 @class = new Class1413();
		if (color_0.IsEmpty)
		{
			@class.Style = Enum156.flag_5;
		}
		else
		{
			@class.Color = color_0;
		}
		class1408_0.Add(@class);
	}

	private void method_13(string string_0)
	{
		Class1411 @class = new Class1411();
		@class.method_6(string_0);
		class1408_0.Add(@class);
	}

	private void method_14()
	{
		Class1410 interface46_ = new Class1410();
		class1408_0.Add(interface46_);
	}

	private void method_15()
	{
		method_11(Color.White);
		method_11(Color.Black);
		method_11(Color.FromArgb(128, 128, 128));
		method_11(Color.FromArgb(64, 64, 64));
		method_11(Color.Black);
		method_11(Color.Empty);
		method_12(Color.White);
		method_12(Color.Black);
		method_12(Color.Empty);
		method_12(Color.Empty);
		method_13("MS Sans Serif");
		method_13("Courier");
		method_13("MS Sans Serif");
		method_13("Tahoma");
		method_13("MS Sans Serif");
		class1408_0.Add(new Class1412());
		method_13("MS Sans Serif");
		method_13("MS Sans Serif");
		method_14();
		method_14();
	}

	private void method_16()
	{
		for (uint num = 0u; num < class1414_0.method_9(); num++)
		{
			class1408_0.Add(null);
		}
	}
}
