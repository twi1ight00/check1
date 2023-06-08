using System;
using ns305;
using ns322;
using ns323;

namespace ns324;

internal class Class7595 : Class7456
{
	private static readonly Type type_0 = typeof(Class7086);

	protected internal override Type Type => type_0;

	public override void Initialize()
	{
		method_11("severity", Enum983.flag_0);
		method_11("message", Enum983.flag_0);
		method_11("type", Enum983.flag_0);
		method_11("relatedException", Enum983.flag_0);
		method_11("relatedData", Enum983.flag_0);
		method_11("location", Enum983.flag_0);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class7086 @class = (Class7086)instance.Value;
		return function switch
		{
			"get_severity" => method_5((int)@class.Severity), 
			"get_message" => method_3(@class.Message), 
			"get_type" => method_3(@class.Type), 
			"get_relatedException" => method_7(@class.RelatedException), 
			"get_relatedData" => method_7(@class.RelatedData), 
			"get_location" => method_2(@class.Location, typeof(Class7087)), 
			_ => throw new Exception89("unknown function"), 
		};
	}
}
