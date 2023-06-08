using System;

namespace ns316;

internal class Class7155 : Interface383
{
	private int int_0;

	public byte[] byte_0;

	public int[] int_1;

	public virtual byte[] LookupTable
	{
		get
		{
			method_0();
			return byte_0;
		}
	}

	public Class7155(int[] table)
	{
		int_1 = table;
		int_0 = table.Length;
	}

	private void method_0()
	{
		byte_0 = new byte[256];
		for (int i = 0; i <= 255; i++)
		{
			int num = (int)Math.Floor((float)(i * int_0) / 255f);
			if (num == int_0)
			{
				num = int_0 - 1;
			}
			byte_0[i] = (byte)((uint)int_1[num] & 0xFFu);
		}
	}
}
