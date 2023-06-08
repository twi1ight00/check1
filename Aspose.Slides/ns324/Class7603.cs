using System;
using ns305;
using ns322;
using ns323;

namespace ns324;

internal class Class7603 : Class7456
{
	private static readonly Type type_0 = typeof(Class7051);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => typeof(Class6976);

	public override void Initialize()
	{
		method_11("publicId", Enum983.flag_0);
		method_11("systemId", Enum983.flag_0);
		method_11("notationName", Enum983.flag_0);
		method_11("inputEncoding", Enum983.flag_0);
		method_11("xmlEncoding", Enum983.flag_0);
		method_11("xmlVersion", Enum983.flag_0);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class7051 @class = (Class7051)instance.Value;
		return function switch
		{
			"get_publicId" => method_3(@class.PublicId), 
			"get_systemId" => method_3(@class.SystemId), 
			"get_notationName" => method_3(@class.NotationName), 
			"get_inputEncoding" => method_3(@class.InputEncoding), 
			"get_xmlEncoding" => method_3(@class.XmlEncoding), 
			"get_xmlVersion" => method_3(@class.XmlVersion), 
			_ => throw new Exception89("unknown function"), 
		};
	}
}
