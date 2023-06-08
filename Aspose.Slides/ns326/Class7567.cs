using System;
using ns322;
using ns323;
using ns73;

namespace ns326;

internal class Class7567 : Class7456
{
	private static readonly Type type_0 = typeof(Class3698);

	protected internal override Type Type => type_0;

	public override void Initialize()
	{
		method_11("identifier", Enum983.flag_0);
		method_11("listStyle", Enum983.flag_0);
		method_11("separator", Enum983.flag_0);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class3698 @class = (Class3698)instance.Value;
		return function switch
		{
			"get_separator" => method_3(@class.Separator), 
			"get_listStyle" => method_3(@class.ListStyle), 
			"get_identifier" => method_3(@class.Identifier), 
			_ => throw new Exception89("unknown function"), 
		};
	}
}
