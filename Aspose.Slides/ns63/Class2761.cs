using ns60;

namespace ns63;

internal class Class2761 : Class2760
{
	private bool? nullable_0;

	public bool Value
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

	public Class2761()
	{
		base.TimeVariantType = Enum400.const_0;
	}

	public Class2761(bool value)
		: this()
	{
		base.RawValue = new byte[0];
		base.RawValue[0] = (byte)(value ? 1u : 0u);
	}

	protected override void vmethod_5()
	{
		nullable_0 = base.RawValue[0] != 0;
	}
}
