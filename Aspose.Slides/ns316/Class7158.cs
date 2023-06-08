using System;

namespace ns316;

internal class Class7158 : Interface383
{
	public float float_0;

	public byte[] byte_0;

	public float float_1;

	public float float_2;

	public virtual byte[] LookupTable
	{
		get
		{
			method_0();
			return byte_0;
		}
	}

	public Class7158(float amplitude, float exponent, float offset)
	{
		float_1 = amplitude;
		float_0 = exponent;
		float_2 = offset;
	}

	private void method_0()
	{
		byte_0 = new byte[256];
		for (int i = 0; i <= 255; i++)
		{
			int num = (int)Math.Round(255.0 * ((double)float_1 * Math.Pow((float)i / 255f, float_0) + (double)float_2));
			if (num > 255)
			{
				num = 255;
			}
			else if (num < 0)
			{
				num = 0;
			}
			byte_0[i] = (byte)((uint)num & 0xFFu);
		}
	}
}
