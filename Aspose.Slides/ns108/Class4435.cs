namespace ns108;

internal class Class4435
{
	private byte[] byte_0;

	private byte byte_1;

	public uint uint_0;

	public uint uint_1;

	public byte byte_2;

	public byte[] Data
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

	public byte Format
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

	public byte method_0(int glyphIndex)
	{
		byte result = 0;
		int num = 0;
		switch (byte_1)
		{
		case 3:
		{
			if ((uint)(glyphIndex - uint_0) < uint_1)
			{
				result = byte_2;
				break;
			}
			int num2 = byte_0.Length;
			byte b = 0;
			uint num3 = 0u;
			uint num4 = 0u;
			num += 2;
			while (glyphIndex >= num3)
			{
				b = byte_0[num];
				num++;
				num4 = (uint)((ushort)(byte_0[num] << 8) | byte_0[num + 1]);
				num += 2;
				if (glyphIndex >= num4)
				{
					num3 = num4;
					if (num >= num2)
					{
						break;
					}
					continue;
				}
				result = b;
				uint_0 = num3;
				uint_1 = num4 - num3;
				byte_2 = b;
				break;
			}
			break;
		}
		case 0:
			result = byte_0[glyphIndex];
			break;
		}
		return result;
	}
}
