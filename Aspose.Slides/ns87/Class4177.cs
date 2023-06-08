using ns73;
using ns84;

namespace ns87;

internal class Class4177 : Class4154
{
	private Enum528 enum528_0;

	private bool bool_0;

	public Enum528 Value => enum528_0;

	public bool CapsHeight => bool_0;

	internal Class4177(Class3679 cssValue)
		: base(cssValue)
	{
		if (cssValue == Class3700.Class3702.class3689_44)
		{
			bool_0 = true;
		}
		else
		{
			enum528_0 = Class4342.smethod_0<Enum528>().imethod_3(method_0());
		}
	}
}
