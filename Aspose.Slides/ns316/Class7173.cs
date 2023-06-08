namespace ns316;

internal class Class7173 : Interface383
{
	public float float_0;

	public byte[] byte_0;

	public float float_1;

	public virtual byte[] LookupTable
	{
		get
		{
			method_0();
			return byte_0;
		}
	}

	public Class7173(float slope, float meet)
	{
		float_1 = slope;
		float_0 = meet;
	}

	public Class7173()
	{
	}

	private void method_0()
	{
		byte_0 = new byte[256];
		float num = float_0 * 255f + 0.5f;
		for (int i = 0; i <= 255; i++)
		{
			int num2 = (int)(float_1 * (float)i + num);
			if (num2 < 0)
			{
				num2 = 0;
			}
			else if (num2 > 255)
			{
				num2 = 255;
			}
			byte_0[i] = (byte)(0xFFu & (uint)num2);
		}
	}
}
