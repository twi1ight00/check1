using ns73;
using ns84;

namespace ns87;

internal class Class4213 : Class4154
{
	private readonly Class4337 class4337_0;

	private readonly Enum631 enum631_0;

	public bool IsEnumValue => class4337_0 == null;

	public Class4337 Value => class4337_0;

	public Enum631 Align => enum631_0;

	internal Class4213(Class3679 cssValue)
		: base(cssValue)
	{
		if (base.IsIdentValue)
		{
			enum631_0 = Class4342.smethod_0<Enum631>().imethod_3(method_0());
		}
		else
		{
			class4337_0 = Class4338.smethod_4(cssValue);
		}
	}
}
