namespace ns108;

internal class Class4439
{
	private int int_0;

	private byte byte_0;

	private int[] int_1;

	private byte[] byte_1;

	private long long_0;

	private long long_1;

	public long IndexBeginOffset
	{
		get
		{
			return long_0;
		}
		set
		{
			long_0 = value;
		}
	}

	public long IndexEndOffset
	{
		get
		{
			return long_1;
		}
		set
		{
			long_1 = value;
		}
	}

	public int ObjectsCount
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public byte OffsetSize
	{
		get
		{
			return byte_0;
		}
		set
		{
			byte_0 = value;
		}
	}

	public int[] Offsets
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	public byte[] IndexData
	{
		get
		{
			return byte_1;
		}
		set
		{
			byte_1 = value;
		}
	}

	public void method_0(int elementIndex, out int offset, out int length)
	{
		int i;
		for (i = elementIndex + 1; i < ObjectsCount && Offsets[i] == 0; i++)
		{
		}
		length = Offsets[i] - Offsets[elementIndex];
		offset = Offsets[elementIndex] - 1;
	}
}
