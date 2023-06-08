using System;
using ns60;

namespace ns63;

internal class Class2762 : Class2760
{
	private float? nullable_0;

	public float Value
	{
		get
		{
			if (!nullable_0.HasValue)
			{
				vmethod_5();
			}
			return nullable_0.Value;
		}
	}

	public Class2762()
	{
		base.TimeVariantType = Enum400.const_2;
	}

	public Class2762(float value)
		: this()
	{
		uint value2 = BitConverter.ToUInt32(BitConverter.GetBytes(value), 0);
		base.RawValue = BitConverter.GetBytes(value2);
	}

	protected override void vmethod_5()
	{
		nullable_0 = BitConverter.ToSingle(base.RawValue, 0);
	}
}
