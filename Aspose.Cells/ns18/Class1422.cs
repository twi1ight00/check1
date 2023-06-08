using System.Drawing;

namespace ns18;

internal class Class1422
{
	public static Class454 smethod_0(Class465 class465_0)
	{
		Class1414 class1414_ = new Class1414(class465_0.method_3());
		return smethod_1(class1414_, class465_0.method_2(), class465_0.Size);
	}

	public static Class454 smethod_1(Class1414 class1414_0, PointF pointF_0, SizeF sizeF_0)
	{
		Class1416 class1416_ = new Class1416(class1414_0);
		Class1426 @class = new Class1426(class1416_);
		if (!class1414_0.method_1() && !class1414_0.method_3() && !class1414_0.method_4())
		{
			Class1428 class2 = new Class1428(class1416_, @class);
			class2.method_1(pointF_0, sizeF_0);
		}
		else
		{
			Class1418 class3 = new Class1419(class1416_, @class);
			class3.method_0(pointF_0, sizeF_0);
		}
		return @class.method_12();
	}
}
