using ns73;
using ns84;

namespace ns87;

internal class Class4170 : Class4154
{
	private readonly Enum525 enum525_0;

	private readonly bool bool_0;

	public Enum525 Value => enum525_0;

	public bool IsAuto => bool_0;

	internal Class4170(Class3679 cssValue)
		: base(cssValue)
	{
		if (Class3700.Class3702.class3689_3 == cssValue)
		{
			bool_0 = true;
		}
		else
		{
			enum525_0 = Class4342.smethod_0<Enum525>().imethod_3(method_0());
		}
	}
}
