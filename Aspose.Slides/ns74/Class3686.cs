using ns305;
using ns73;

namespace ns74;

internal class Class3686 : Class3681
{
	internal Class3680 class3680_0;

	internal Class3680 class3680_1;

	internal Class3680 class3680_2;

	internal Class3680 class3680_3;

	public override string CSSText
	{
		get
		{
			return "rect(" + class3680_0.CSSText + ", " + class3680_1.CSSText + ", " + class3680_2.CSSText + ", " + class3680_3.CSSText + ')';
		}
		set
		{
			throw new Exception73(Enum968.const_14);
		}
	}

	public Class3686(Class3680 top, Class3680 right, Class3680 bottom, Class3680 left)
		: base(24)
	{
		class3680_0 = top;
		class3680_1 = right;
		class3680_2 = bottom;
		class3680_3 = left;
	}

	public override Class4257 vmethod_5()
	{
		return new Class4257(class3680_0, class3680_1, class3680_2, class3680_3);
	}
}
