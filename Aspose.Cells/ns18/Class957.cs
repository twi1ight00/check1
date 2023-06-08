namespace ns18;

internal class Class957 : Class938
{
	private Class939 class939_0;

	private Class954 class954_0;

	private Class939 class939_1;

	internal Class957(Class1440 class1440_1, Class954 class954_1)
		: base(class1440_1)
	{
		class954_0 = class954_1;
		if (class954_1.vmethod_6())
		{
			class939_1 = new Class939(class1440_1, bool_1: true);
		}
	}

	public override void vmethod_1(Class1447 class1447_0)
	{
		method_4(class1447_0);
		if (class954_0.vmethod_6())
		{
			class954_0.vmethod_3(class939_1.method_4());
			class939_0.vmethod_1(class1447_0);
			class939_1.method_4().Position = 0L;
			class939_1.vmethod_1(class1447_0);
		}
	}

	private void method_4(Class1447 class1447_0)
	{
		class1447_0.method_24(this);
		class1447_0.method_9();
		class1447_0.method_11("/Type", "/FontDescriptor");
		class1447_0.method_11("/FontName", $"/{class954_0.method_7()}");
		ushort ushort_ = class954_0.class1460_0.method_47().ushort_1;
		class1447_0.method_16("/StemV", (int)ushort_ / 65 * ((int)ushort_ / 65));
		class1447_0.method_16("/Descent", class954_0.method_8());
		class1447_0.method_16("/Ascent", class954_0.method_9());
		class1447_0.method_16("/CapHeight", class954_0.method_10());
		class1447_0.method_16("/Flags", class954_0.method_11());
		class1447_0.method_17("/ItalicAngle", class954_0.method_13());
		class1447_0.method_14("/FontBBox", class954_0.method_12());
		class1447_0.method_16("/FontWeight", ushort_);
		if (class954_0.vmethod_6())
		{
			class939_0 = new Class939(class1440_0);
			class939_0.WriteByte(128);
			class1447_0.method_11("/CIDSet", class939_0.method_1());
			class1447_0.method_11("/FontFile2", class939_1.method_1());
		}
		class1447_0.method_10();
		class1447_0.method_25();
	}
}
