using System;
using ns322;
using ns323;
using ns73;

namespace ns326;

internal class Class7569 : Class7456
{
	private static readonly Type type_0 = typeof(Interface94);

	protected internal override Type Type => type_0;

	public override void Initialize()
	{
		method_11("red", Enum983.flag_0);
		method_11("green", Enum983.flag_0);
		method_11("blue", Enum983.flag_0);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Interface94 @interface = (Interface94)instance.Value;
		return function switch
		{
			"get_blue" => method_2(@interface.imethod_2(), typeof(Class3680)), 
			"get_green" => method_2(@interface.imethod_1(), typeof(Class3680)), 
			"get_red" => method_2(@interface.imethod_0(), typeof(Class3680)), 
			_ => throw new Exception89("unknown function"), 
		};
	}
}
