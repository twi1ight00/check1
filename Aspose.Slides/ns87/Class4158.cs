using ns73;
using ns84;

namespace ns87;

internal class Class4158 : Class4154
{
	private readonly Enum508 enum508_0;

	private readonly Class4338 class4338_0;

	public bool IsEnumValue => class4338_0 == null;

	public Class4337 Value => class4338_0;

	public Enum508 VoiceBalance => enum508_0;

	internal Class4158(Class3679 cssValue)
		: base(cssValue)
	{
		if (base.IsIdentValue)
		{
			enum508_0 = Class4342.smethod_0<Enum508>().imethod_3(method_0());
		}
		else
		{
			class4338_0 = Class4338.smethod_4(cssValue);
		}
	}
}
