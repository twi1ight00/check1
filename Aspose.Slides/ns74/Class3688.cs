using ns305;
using ns73;

namespace ns74;

internal class Class3688 : Class3681
{
	private Class3680 class3680_0;

	private Class3680 class3680_1;

	private Class3680 class3680_2;

	private Class3680 class3680_3;

	public override string CSSText
	{
		get
		{
			return "rgb(" + class3680_0.CSSText + ", " + class3680_1.CSSText + ", " + class3680_2.CSSText + ')';
		}
		set
		{
			throw new Exception73(Enum968.const_14);
		}
	}

	public Class3688(Class3680 red, Class3680 green, Class3680 blue)
		: this(Class3700.Class3702.class3685_6, red, green, blue)
	{
	}

	public Class3688(Class3680 alpha, Class3680 red, Class3680 green, Class3680 blue)
		: base(25)
	{
		class3680_0 = red;
		class3680_1 = green;
		class3680_2 = blue;
		class3680_3 = alpha;
	}

	public static Class3688 smethod_0(float red, float green, float blue)
	{
		return new Class3688(Class3685.smethod_0(red, 1), Class3685.smethod_0(green, 1), Class3685.smethod_0(blue, 1));
	}

	public static Class3688 smethod_1(float alpha, float red, float green, float blue)
	{
		return new Class3688(Class3685.smethod_0(alpha, 1), Class3685.smethod_0(red, 1), Class3685.smethod_0(green, 1), Class3685.smethod_0(blue, 1));
	}

	public override Class4343 vmethod_6()
	{
		return new Class4343(class3680_3, class3680_0, class3680_1, class3680_2);
	}
}
