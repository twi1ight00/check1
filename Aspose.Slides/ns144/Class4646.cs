namespace ns144;

internal class Class4646
{
	private byte[] byte_0;

	private int int_0;

	private int int_1;

	public byte this[int index] => byte_0[index];

	public byte[] Program => byte_0;

	public int StartIndex => int_0;

	public int EndIndex => int_1;

	public Class4646(byte[] program)
	{
		byte_0 = program;
		int_0 = 0;
		int_1 = program.Length - 1;
	}

	public Class4646(byte[] program, int startIndex, int endIndex)
	{
		byte_0 = program;
		int_0 = startIndex;
		int_1 = endIndex;
	}
}
