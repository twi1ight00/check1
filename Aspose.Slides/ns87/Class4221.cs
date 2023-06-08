using ns73;
using ns74;
using ns84;

namespace ns87;

internal class Class4221 : Class4154
{
	private readonly Class4337 class4337_0;

	private readonly Enum607 enum607_0;

	private readonly bool bool_0;

	public bool IsLengthValue => bool_0;

	public bool IsEnumValue => !bool_0;

	public Enum607 EnumValue => enum607_0;

	public Class4337 LengthValue => class4337_0;

	internal Class4221(Class3679 value)
		: base(value)
	{
		bool_0 = !base.IsIdentValue;
		if (!bool_0)
		{
			enum607_0 = Class4342.smethod_0<Enum607>().imethod_3(method_0());
		}
		else
		{
			class4337_0 = Class4338.smethod_3((Class3681)value);
		}
	}
}
