using ns84;

namespace ns93;

internal class Class4307 : Class4305
{
	private float float_0;

	private float float_1;

	private float float_2;

	public float X => float_0;

	public float Y => float_1;

	public float Z => float_2;

	public Class4307(float x, float y, float z)
		: base(Enum511.const_18)
	{
		float_0 = x;
		float_1 = y;
		float_2 = z;
	}

	public override string ToString()
	{
		return string.Format(Class4337.cultureInfo_0, "scale3d({0}, {1}, {2})", new object[3] { X, Y, Z });
	}
}
