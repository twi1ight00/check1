namespace ns52;

internal class Class1135
{
	private byte[] byte_0;

	private byte[] byte_1;

	internal Class1135(byte[] modulus, byte[] exponent)
	{
		byte_0 = modulus;
		byte_1 = exponent;
	}

	internal void method_0(byte[] message, byte[] signature)
	{
		Class1136.smethod_3(byte_0, byte_1, message, signature);
	}
}
