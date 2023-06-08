namespace ns223;

internal class Class5985
{
	private readonly byte[] byte_0 = new byte[256];

	private int int_0;

	private int int_1;

	public void method_0(byte[] data)
	{
		method_3(data, 0, data.Length, data, 0);
	}

	public void method_1(byte[] dataIn, byte[] dataOut)
	{
		method_3(dataIn, 0, dataIn.Length, dataOut, 0);
	}

	public void method_2(byte[] data, int offset, int length)
	{
		method_3(data, offset, length, data, offset);
	}

	public void method_3(byte[] dataIn, int offset, int length, byte[] dataOut, int offOut)
	{
		int num = length + offset;
		for (int i = offset; i < num; i++)
		{
			int_0 = (int_0 + 1) & 0xFF;
			int_1 = (byte_0[int_0] + int_1) & 0xFF;
			byte b = byte_0[int_0];
			byte_0[int_0] = byte_0[int_1];
			byte_0[int_1] = b;
			dataOut[i - offset + offOut] = (byte)(dataIn[i] ^ byte_0[(byte_0[int_0] + byte_0[int_1]) & 0xFF]);
		}
	}

	public void method_4(byte[] key)
	{
		method_5(key, 0, key.Length);
	}

	public void method_5(byte[] key, int offset, int length)
	{
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < 256; i++)
		{
			byte_0[i] = (byte)i;
		}
		int_0 = 0;
		int_1 = 0;
		for (int j = 0; j < 256; j++)
		{
			num2 = (key[num + offset] + byte_0[j] + num2) & 0xFF;
			byte b = byte_0[j];
			byte_0[j] = byte_0[num2];
			byte_0[num2] = b;
			num = (num + 1) % length;
		}
	}
}
