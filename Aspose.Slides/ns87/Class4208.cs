using ns73;
using ns74;
using ns84;

namespace ns87;

internal class Class4208 : Class4154
{
	private readonly Class4337 class4337_0;

	private readonly Enum592 enum592_0;

	public bool IsEnumValue => class4337_0 == null;

	public Enum592 SpeechRate => enum592_0;

	public Class4337 Value => class4337_0;

	internal Class4208(Class3679 cssValue)
		: base(cssValue)
	{
		if (base.IsIdentValue)
		{
			enum592_0 = Class4342.smethod_0<Enum592>().imethod_3(method_0());
		}
		else
		{
			class4337_0 = Class4338.smethod_3((Class3681)cssValue);
		}
	}
}
