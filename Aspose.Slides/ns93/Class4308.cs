using ns84;

namespace ns93;

internal class Class4308 : Class4305
{
	private float float_0;

	private float float_1;

	private float float_2;

	private float float_3;

	public float Angle => float_0;

	public float X => float_1;

	public float Y => float_2;

	public float Z => float_3;

	public Class4308(float x, float y, float z, float angle)
		: base(Enum511.const_16)
	{
		float_1 = x;
		float_2 = y;
		float_3 = z;
		float_0 = angle;
	}

	public override string ToString()
	{
		return string.Format(Class4337.cultureInfo_0, "rotate3d({0}, {1}, {2}, {3})", X, Y, Z, Angle);
	}
}
