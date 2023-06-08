using ns84;

namespace ns93;

internal class Class4312 : Class4305
{
	private float float_0;

	private float float_1;

	public float X => float_0;

	public float Y => float_1;

	public Class4312(float x, float y)
		: base(Enum511.const_7)
	{
		float_0 = x;
		float_1 = y;
	}

	public Class4312(float skew)
		: this(skew, 0f)
	{
	}

	public override string ToString()
	{
		return string.Format(Class4337.cultureInfo_0, "skew({0}, {1})", new object[2] { X, Y });
	}
}
