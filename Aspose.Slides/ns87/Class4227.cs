using ns73;
using ns74;
using ns84;

namespace ns87;

internal class Class4227 : Class4154
{
	private enum Enum603
	{
		const_0,
		const_1,
		const_2
	}

	private Enum610 enum610_0;

	private Enum626 enum626_0;

	private Class4337 class4337_0;

	private Enum603 enum603_0;

	public Class4337 ValueSize => class4337_0;

	public Enum626 RelativeSize => enum626_0;

	public Enum610 AbsoluteSize => enum610_0;

	public bool IsAbsoluteSize => enum603_0 == Enum603.const_0;

	public bool IsRelativeSize => enum603_0 == Enum603.const_1;

	public bool IsValueSize => enum603_0 == Enum603.const_2;

	internal Class4227(Class3679 value)
		: base(value)
	{
		if (base.IsIdentValue)
		{
			switch (((Class3680)value).CSSText)
			{
			case "larger":
			case "smaller":
				enum626_0 = Class4342.smethod_0<Enum626>().imethod_3(method_0());
				enum603_0 = Enum603.const_1;
				break;
			case "xx-small":
			case "x-small":
			case "small":
			case "medium":
			case "large":
			case "x-large":
			case "xx-large":
			case "xxx-large":
				enum610_0 = Class4342.smethod_0<Enum610>().imethod_3(method_0());
				enum603_0 = Enum603.const_0;
				break;
			}
		}
		else
		{
			class4337_0 = Class4338.smethod_3((Class3681)value);
			enum603_0 = Enum603.const_2;
		}
	}
}
