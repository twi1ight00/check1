using ns4;
using ns60;

namespace ns63;

internal class Class2763 : Class2760
{
	private int? nullable_0;

	public int Value
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

	public Class2763()
	{
		base.TimeVariantType = Enum400.const_1;
	}

	public Class2763(int value)
		: this()
	{
		base.RawValue = new byte[4];
		base.RawValue[0] = (byte)value;
		base.RawValue[1] = (byte)(((uint)value >> 8) & 0xFFu);
		base.RawValue[2] = (byte)(((uint)value >> 16) & 0xFFu);
		base.RawValue[3] = (byte)(((uint)value >> 24) & 0xFFu);
	}

	protected override void vmethod_5()
	{
		nullable_0 = Class1162.smethod_7(base.RawValue);
	}
}
