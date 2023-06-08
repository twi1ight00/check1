namespace ns18;

internal class Class768 : Class767
{
	private byte[] byte_1;

	public byte[] method_3()
	{
		return byte_1;
	}

	protected override bool vmethod_1()
	{
		if (byte_0[4] == 109 && byte_0[5] == 115 && byte_0[6] == 79 && byte_0[7] == 71)
		{
			int num = method_0();
			byte_1 = new byte[num - 11];
			method_2(11L);
			int num2 = 0;
			while (true)
			{
				if (num2 < byte_1.Length)
				{
					int num3 = stream_0.Read(byte_1, num2, byte_1.Length - num2);
					if (num3 <= 0)
					{
						break;
					}
					num2 += num3;
					continue;
				}
				return false;
			}
			byte_1 = null;
			return false;
		}
		method_1();
		return true;
	}
}
