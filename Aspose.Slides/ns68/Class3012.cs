using ns67;

namespace ns68;

internal sealed class Class3012
{
	internal Struct159 struct159_0;

	internal Class3012 class3012_0;

	internal Class3012 class3012_1;

	internal Class3012 class3012_2;

	internal double double_0;

	internal bool bool_0;

	internal bool bool_1;

	internal bool bool_2;

	private double double_1;

	private double double_2;

	public double X => double_1;

	public double Y => double_2;

	internal Class3012(Struct159 pt)
	{
		double_1 = pt.X;
		double_2 = pt.Y;
		struct159_0 = pt;
		class3012_1 = null;
		class3012_2 = null;
		bool_0 = false;
		bool_1 = false;
		class3012_0 = null;
		double_0 = 0.0;
		bool_2 = false;
	}

	internal Class3012(Struct159 pt, Class3012 insertAfterThat)
		: this(pt)
	{
		class3012_0 = insertAfterThat;
	}
}
