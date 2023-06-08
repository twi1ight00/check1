namespace ns18;

internal class Class952 : Class938
{
	private Class956 class956_0;

	private Class957 class957_0;

	internal Class952(Class1440 class1440_1, Class956 class956_1)
		: base(class1440_1)
	{
		class956_0 = class956_1;
		class957_0 = new Class957(class1440_1, class956_1);
	}

	public override void vmethod_1(Class1447 class1447_0)
	{
		method_4(class1447_0);
		class957_0.vmethod_1(class1447_0);
	}

	private void method_4(Class1447 class1447_0)
	{
		class1447_0.method_24(this);
		class1447_0.method_9();
		class1447_0.method_11("/Type", "/Font");
		class1447_0.method_11("/Subtype", "/CIDFontType2");
		class1447_0.method_11("/BaseFont", $"/{class956_0.method_7()}");
		class1447_0.method_11("/CIDToGIDMap", "/Identity");
		class1447_0.method_11("/FontDescriptor", class957_0.method_1());
		class1447_0.method_16("/DW", 1000);
		class1447_0.method_11("/W", class956_0.vmethod_4());
		class1447_0.Write("/CIDSystemInfo ");
		class1447_0.method_9();
		class1447_0.Write("/Ordering (Identity)/Registry (Adobe)/Supplement 0");
		class1447_0.method_10();
		class1447_0.method_10();
		class1447_0.method_25();
	}
}
