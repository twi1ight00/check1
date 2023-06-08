using ns84;

namespace ns93;

internal class Class4319 : Class4305
{
	private float float_0;

	public float Angle => float_0;

	public Class4319(float angle)
		: base(Enum511.const_13)
	{
		float_0 = angle;
	}

	public override string ToString()
	{
		return string.Format(Class4337.cultureInfo_0, "rotateX({0})", new object[1] { Angle });
	}
}
