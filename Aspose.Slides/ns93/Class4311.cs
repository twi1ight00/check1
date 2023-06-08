using ns84;

namespace ns93;

internal class Class4311 : Class4305
{
	private float float_0;

	public float Skew => float_0;

	public Class4311(float skew)
		: base(Enum511.const_8)
	{
		float_0 = skew;
	}

	public override string ToString()
	{
		return string.Format(Class4337.cultureInfo_0, "skewX({0})", new object[1] { float_0 });
	}
}
