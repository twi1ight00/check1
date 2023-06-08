using System;
using ns322;
using ns323;
using ns73;

namespace ns326;

internal class Class7573 : Class7456
{
	private static readonly Type type_0 = typeof(Interface70);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => typeof(Interface59);

	public override void Initialize()
	{
		method_11("href", Enum983.flag_0);
		method_11("media", Enum983.flag_0);
		method_11("styleSheet", Enum983.flag_0);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Interface70 @interface = (Interface70)instance.Value;
		return function switch
		{
			"get_styleSheet" => method_2(@interface.StyleSheet, typeof(Interface76)), 
			"get_media" => method_2(@interface.Media, typeof(Interface79)), 
			"get_href" => method_3(@interface.Href), 
			_ => throw new Exception89("unknown function"), 
		};
	}
}
