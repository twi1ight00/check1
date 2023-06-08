using ns22;

namespace ns18;

internal class Class946 : Class938
{
	private static byte[] byte_0;

	public Class946(Class1440 class1440_1)
		: base(class1440_1)
	{
	}

	static Class946()
	{
		byte_0 = Class1186.smethod_4();
	}

	public override void vmethod_1(Class1447 class1447_0)
	{
		class1447_0.method_24(this);
		class1447_0.method_9();
		class1447_0.method_11("/Filter", "/FlateDecode");
		class1447_0.method_16("/N", 3);
		class1447_0.method_16("/Length", byte_0.Length);
		class1447_0.method_10();
		class1447_0.Write("stream\r\n");
		class1447_0.Write(byte_0, 0, byte_0.Length);
		class1447_0.Write("\r\nendstream\r\n");
		class1447_0.method_25();
	}
}
