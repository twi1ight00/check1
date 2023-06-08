namespace ns122;

internal class Class4551
{
	private byte[] byte_0;

	private int int_0;

	public byte[] Buffer => byte_0;

	public int DataBytesCount => int_0;

	public Class4551(int maxLength)
	{
		byte_0 = new byte[maxLength];
	}

	public void method_0(byte value)
	{
		byte_0[int_0++] = value;
	}
}
