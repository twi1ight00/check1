using System.Drawing;

namespace ns73;

internal class Class4343
{
	private Class3680 class3680_0;

	private Class3680 class3680_1;

	private Class3680 class3680_2;

	private Class3680 class3680_3;

	public Class3680 Red => class3680_0;

	public Class3680 Green => class3680_1;

	public Class3680 Blue => class3680_2;

	public Class3680 Alpha => class3680_3;

	internal Class4343(Class3680 alpha, Class3680 red, Class3680 green, Class3680 blue)
	{
		class3680_3 = alpha;
		class3680_0 = red;
		class3680_1 = green;
		class3680_2 = blue;
	}

	internal Class4343(Class3680 red, Class3680 green, Class3680 blue)
		: this(Class3700.Class3702.class3685_6, red, green, blue)
	{
	}

	public Color method_0()
	{
		return Color.FromArgb((int)Alpha.vmethod_1(1), (int)Red.vmethod_1(1), (int)Green.vmethod_1(1), (int)Blue.vmethod_1(1));
	}
}
