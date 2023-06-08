namespace ns16;

internal class Class759
{
	public byte[] byte_0;

	public byte[] byte_1;

	public int int_0;

	public int int_1;

	public int int_2;

	public int int_3;

	public int int_4;

	public Class765 class765_0;

	public Class759(int int_5, Enum42 enum42_0, Enum43 enum43_0, int int_6)
	{
		byte_0 = new byte[int_5];
		int num = int_5 + (int_5 / 32768 + 1) * 5 * 2;
		byte_1 = new byte[num];
		class765_0 = new Class765();
		class765_0.method_4(enum42_0, bool_0: false);
		class765_0.byte_1 = byte_1;
		class765_0.byte_0 = byte_0;
		int_1 = int_6;
	}
}
