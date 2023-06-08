using ns73;
using ns84;

namespace ns87;

internal class Class4180 : Class4154
{
	private Class4338 class4338_0;

	private Enum544 enum544_0;

	private bool bool_0;

	public Class4338 Time => class4338_0;

	public Enum544 Rest => enum544_0;

	public bool None => bool_0;

	public bool IsTimeValue => class4338_0 != null;

	internal Class4180(Class3679 cssValue)
		: base(cssValue)
	{
		if (base.IsIdentValue)
		{
			if (Class3700.Class3702.class3689_4 == cssValue)
			{
				bool_0 = true;
			}
			else
			{
				enum544_0 = Class4342.smethod_0<Enum544>().imethod_3(method_0());
			}
		}
		else
		{
			class4338_0 = Class4338.smethod_4(cssValue);
		}
	}
}
