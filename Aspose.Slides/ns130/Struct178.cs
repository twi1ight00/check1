using System.Runtime.CompilerServices;

namespace ns130;

internal struct Struct178
{
	public ushort ushort_0;

	public ushort ushort_1;

	[SpecialName]
	public static uint smethod_0(Struct178 value)
	{
		return (uint)((value.ushort_0 << 16) | value.ushort_1);
	}

	[SpecialName]
	public static Struct178 smethod_1(uint value)
	{
		Struct178 result = default(Struct178);
		result.ushort_1 = (ushort)value;
		result.ushort_0 = (ushort)(value >> 16);
		return result;
	}
}
