using System;

namespace ns61;

internal class Class2618
{
	private readonly float float_0;

	private readonly short short_0;

	private readonly ushort ushort_0;

	public float Value => float_0;

	public float Integral => short_0;

	public float Fractional => (int)ushort_0;

	public Class2618(uint value)
	{
		byte[] bytes = BitConverter.GetBytes(value);
		ushort_0 = (ushort)((bytes[1] << 8) + bytes[0]);
		short_0 = (short)((bytes[3] << 8) + bytes[2]);
		float_0 = (float)short_0 + (float)(int)ushort_0 / 65536f;
	}
}
