using System.Runtime.CompilerServices;

namespace ns18;

internal class Class961 : Class938
{
	private Class1451 class1451_0;

	private Class1450 class1450_0;

	internal Class961(Class1440 class1440_1)
		: base(class1440_1)
	{
		class1450_0 = new Class1450();
		class1451_0 = new Class1451(class1440_1);
	}

	internal void method_4(string string_1)
	{
		class1450_0.Add(string_1);
	}

	public override void vmethod_1(Class1447 class1447_0)
	{
		class1447_0.method_24(this);
		class1447_0.method_9();
		class1447_0.method_11("/Type", "/Pages");
		class1447_0.method_16("/Count", class1450_0.Count);
		class1447_0.Write("/Kids");
		class1450_0.method_0(class1447_0);
		class1447_0.Write("/Resources");
		class1447_0.method_9();
		class1451_0.method_7(class1447_0);
		class1447_0.method_10();
		class1447_0.method_10();
		class1447_0.method_25();
		class1451_0.method_8(class1447_0);
	}

	[SpecialName]
	public Class1451 method_5()
	{
		return class1451_0;
	}
}
