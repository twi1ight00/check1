using ns84;

namespace ns93;

internal class Class4325 : Class4305
{
	private float float_0;

	private float float_1;

	private float float_2;

	private float float_3;

	private float float_4;

	private float float_5;

	public float F => float_5;

	public float E => float_4;

	public float D => float_3;

	public float C => float_2;

	public float B => float_1;

	public float A => float_0;

	public Class4325(float a, float b, float c, float d, float e, float f)
		: base(Enum511.const_10)
	{
		float_0 = a;
		float_1 = b;
		float_2 = c;
		float_3 = d;
		float_4 = e;
		float_5 = f;
	}

	public override string ToString()
	{
		return string.Format(Class4337.cultureInfo_0, "matrix({0}, {1}, {2}, {3}, {4}, {5})", A, B, C, D, E, F);
	}
}
