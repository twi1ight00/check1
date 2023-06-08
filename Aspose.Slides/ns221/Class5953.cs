namespace ns221;

internal class Class5953
{
	private int int_0;

	private int int_1;

	private int int_2;

	private byte[] byte_0;

	public int ByteIndex
	{
		get
		{
			return int_1;
		}
		set
		{
			Flush();
			method_2();
			int_1 = value;
		}
	}

	private bool IsByteEnded => int_0 == 1;

	public Class5953(byte[] bytes)
	{
		byte_0 = bytes;
		method_2();
	}

	public void method_0()
	{
		int_2 += (byte)int_0;
	}

	public void method_1()
	{
		if (IsByteEnded)
		{
			method_3();
			ByteIndex++;
		}
		else
		{
			int_0 >>= 1;
		}
	}

	public void Flush()
	{
		if (int_0 != 128 && int_1 < byte_0.Length)
		{
			method_3();
		}
	}

	private void method_2()
	{
		int_0 = 128;
		int_2 = 0;
	}

	private void method_3()
	{
		byte_0[ByteIndex] = (byte)int_2;
	}
}
