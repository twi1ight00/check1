using ns84;

namespace ns93;

internal class Class4321 : Class4305
{
	private float float_0;

	public float Value => float_0;

	public Class4321(float value)
		: base(Enum511.const_2)
	{
		float_0 = value;
	}

	public override string ToString()
	{
		return string.Format(Class4337.cultureInfo_0, "translateY({0})", new object[1] { float_0 });
	}
}
