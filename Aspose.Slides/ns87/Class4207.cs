using ns73;
using ns74;
using ns84;

namespace ns87;

internal class Class4207 : Class4154
{
	private readonly Class4337 class4337_0;

	private readonly Enum591 enum591_0;

	public bool IsEnumValue => class4337_0 == null;

	public Enum591 Volume => enum591_0;

	public Class4337 Value => class4337_0;

	internal Class4207(Class3679 value)
		: base(value)
	{
		if (base.IsIdentValue)
		{
			enum591_0 = Class4342.smethod_0<Enum591>().imethod_3(method_0());
		}
		else
		{
			class4337_0 = Class4338.smethod_3((Class3681)value);
		}
	}
}
