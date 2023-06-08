using System.Drawing;
using System.Runtime.CompilerServices;

namespace ns18;

internal class Class948 : Class938
{
	private Class1440 class1440_1;

	private Class1199 class1199_0;

	private RectangleF rectangleF_0;

	internal Class947 class947_0;

	public Class948(Class1440 class1440_2, Class1199 class1199_1)
		: base(class1440_2)
	{
		class1199_0 = class1199_1;
		class947_0 = new Class947(class1440_2, class1199_1.method_1(), class1199_1.method_0());
		class1440_1 = class1440_2;
		rectangleF_0 = new RectangleF(class1199_1.method_3().X, class1199_1.method_3().Y, class1199_1.method_2().X - class1199_1.method_3().X, class1199_1.method_2().Y - class1199_1.method_3().Y);
	}

	[SpecialName]
	internal override Enum209 vmethod_0()
	{
		return Enum209.const_5;
	}

	internal void method_4(Class1447 class1447_0)
	{
		class1447_0.method_24(this);
		class1447_0.method_9();
		class1447_0.method_16("/ShadingType", 2);
		class1447_0.method_14("/Coords", rectangleF_0);
		class1447_0.method_11("/ColorSpace", "/DeviceRGB");
		class1447_0.method_11("/Function", class947_0.method_1());
		class1447_0.method_10();
		class1447_0.method_25();
		class947_0.vmethod_1(class1447_0);
	}

	public override void vmethod_1(Class1447 class1447_0)
	{
		method_4(class1447_0);
	}
}
