using ns84;

namespace ns93;

internal class Class4315 : Class4305
{
	private float float_0;

	public float Scale => float_0;

	public Class4315(float scale)
		: base(Enum511.const_5)
	{
		float_0 = scale;
	}

	public override string ToString()
	{
		return string.Format(Class4337.cultureInfo_0, "scaleX({0})", new object[1] { Scale });
	}
}
