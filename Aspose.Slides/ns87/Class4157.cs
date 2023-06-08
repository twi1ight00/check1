using ns73;
using ns74;

namespace ns87;

internal class Class4157 : Class4154
{
	private bool bool_0;

	private bool bool_1;

	private int int_0;

	public bool Initial => bool_0;

	public bool Last => bool_1;

	public int Value => int_0;

	internal Class4157(Class3679 cssValue)
		: base(cssValue)
	{
		if (Class3700.Class3702.class3689_45 == cssValue)
		{
			bool_0 = true;
		}
		else if (Class3700.Class3702.class3689_89 == cssValue)
		{
			bool_1 = true;
		}
		else
		{
			int_0 = (int)Class4338.smethod_3((Class3681)cssValue).Value;
		}
	}
}
