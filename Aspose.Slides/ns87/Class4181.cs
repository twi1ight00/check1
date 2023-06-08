using ns73;

namespace ns87;

internal class Class4181 : Class4154
{
	private bool bool_0;

	private int int_0;

	public bool Initial => bool_0;

	public int Value => int_0;

	internal Class4181(Class3679 cssValue)
		: base(cssValue)
	{
		if (cssValue == Class3700.Class3702.class3689_45)
		{
			bool_0 = true;
		}
		else
		{
			int_0 = (int)Class4338.smethod_4(cssValue).Value;
		}
	}
}
