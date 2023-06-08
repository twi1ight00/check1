namespace ns18;

internal class Class940 : Class939
{
	private readonly byte[] byte_0;

	private readonly int int_1;

	private readonly int int_2;

	internal Class940(Class1440 class1440_1, byte[] byte_1, int int_3, int int_4)
		: base(class1440_1)
	{
		byte_0 = byte_1;
		int_1 = int_3;
		int_2 = int_4;
	}

	public override void vmethod_1(Class1447 class1447_0)
	{
		Write(byte_0, 0, byte_0.Length);
		base.vmethod_1(class1447_0);
	}

	internal override void vmethod_3(Class1447 class1447_0)
	{
		class1447_0.method_11("/Type", "/XObject");
		class1447_0.method_11("/Subtype", "/Image");
		class1447_0.method_16("/Width", int_1);
		class1447_0.method_16("/Height", int_2);
		class1447_0.method_11("/ColorSpace", "/DeviceGray");
		class1447_0.method_16("/BitsPerComponent", 8);
	}
}
