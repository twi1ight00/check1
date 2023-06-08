using System;
using ns322;
using ns323;
using ns73;

namespace ns326;

internal class Class7574 : Class7456
{
	private static readonly Type type_0 = typeof(Interface72);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => typeof(Interface59);

	public override void Initialize()
	{
		method_11("selectorText", Enum983.flag_0 | Enum983.flag_1);
		method_11("style", Enum983.flag_0);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Interface72 @interface = (Interface72)instance.Value;
		return function switch
		{
			"get_style" => method_2(@interface.Style, typeof(Interface58)), 
			"set_selectorText" => throw new Exception89("Setting selectorText is not allowed."), 
			"get_selectorText" => method_3(@interface.SelectorText), 
			_ => throw new Exception89("unknown function"), 
		};
	}
}
