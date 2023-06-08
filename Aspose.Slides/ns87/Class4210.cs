using ns73;
using ns74;
using ns84;

namespace ns87;

internal class Class4210 : Class4154
{
	private readonly Enum597 enum597_0;

	private readonly Class4337 class4337_0;

	public Class4337 Frequency => class4337_0;

	public Enum597 Pitch => enum597_0;

	public bool IsEnumValue => class4337_0 == null;

	internal Class4210(Class3679 cssValue)
		: base(cssValue)
	{
		if (base.IsIdentValue)
		{
			enum597_0 = Class4342.smethod_0<Enum597>().imethod_3(method_0());
		}
		else
		{
			class4337_0 = Class4338.smethod_3((Class3681)cssValue);
		}
	}
}
