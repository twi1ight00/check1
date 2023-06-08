using System.Drawing;

namespace ns18;

internal class Class947 : Class938
{
	private Color color_0;

	private Color color_1;

	public Class947(Class1440 class1440_1, Color color_2, Color color_3)
		: base(class1440_1)
	{
		color_0 = color_2;
		color_1 = color_3;
	}

	public override void vmethod_1(Class1447 class1447_0)
	{
		class1447_0.method_24(this);
		class1447_0.method_9();
		class1447_0.method_16("/FunctionType", 2);
		class1447_0.method_11("/Domain", "[0 1]");
		class1447_0.method_11("/C0", $"[{Class1446.smethod_9(color_0)}]");
		class1447_0.method_11("/C1", $"[{Class1446.smethod_9(color_1)}]");
		class1447_0.method_11("/N", "1");
		class1447_0.method_10();
		class1447_0.method_25();
	}
}
