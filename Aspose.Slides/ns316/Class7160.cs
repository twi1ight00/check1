namespace ns316;

internal class Class7160 : Interface383
{
	public static byte[] byte_0;

	public virtual byte[] LookupTable => byte_0;

	static Class7160()
	{
		byte_0 = new byte[256];
		for (int i = 0; i <= 255; i++)
		{
			byte_0[i] = (byte)i;
		}
	}
}
