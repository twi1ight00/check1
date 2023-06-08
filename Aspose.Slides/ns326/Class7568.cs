using System;
using ns322;
using ns323;
using ns73;

namespace ns326;

internal class Class7568 : Class7456
{
	private static readonly Type type_0 = typeof(Class4257);

	protected internal override Type Type => type_0;

	public override void Initialize()
	{
		method_11("top", Enum983.flag_0);
		method_11("right", Enum983.flag_0);
		method_11("bottom", Enum983.flag_0);
		method_11("left", Enum983.flag_0);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class4257 @class = (Class4257)instance.Value;
		return function switch
		{
			"get_left" => method_2(@class.Left, typeof(Class3680)), 
			"get_bottom" => method_2(@class.Bottom, typeof(Class3680)), 
			"get_right" => method_2(@class.Right, typeof(Class3680)), 
			"get_top" => method_2(@class.Top, typeof(Class3680)), 
			_ => throw new Exception89("unknown function"), 
		};
	}
}
