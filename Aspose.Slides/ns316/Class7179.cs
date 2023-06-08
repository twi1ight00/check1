using System;

namespace ns316;

internal class Class7179 : Interface383
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

	public Class7179(int[] values)
	{
		int_1 = values;
		int_0 = values.Length;
	}

	private void method_0()
	{
		byte_0 = new byte[256];
		for (int i = 0; i <= 255; i++)
		{
			float num = (float)(i * (int_0 - 1)) / 255f;
			int num2 = (int)Math.Floor(num);
			int num3 = ((num2 + 1 > int_0 - 1) ? (int_0 - 1) : (num2 + 1));
			float num4 = num - (float)num2;
			byte_0[i] = (byte)((uint)(int)((float)int_1[num2] + num4 * (float)(int_1[num3] - int_1[num2])) & 0xFFu);
		}
	}
}
