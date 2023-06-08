using ns84;

namespace ns93;

internal class Class4324 : Class4305
{
	private float float_0;

	private float float_1;

	public float X => float_0;

	public float Y => float_1;

	public Class4324(float x, float y)
		: base(Enum511.const_0)
	{
		float_0 = x;
		float_1 = y;
	}

	public Class4324(float translate)
		: this(translate, 0f)
	{
	}

	public override string ToString()
	{
		return string.Format(Class4337.cultureInfo_0, "translate({0}, {1})", new object[2] { X, Y });
	}
}
