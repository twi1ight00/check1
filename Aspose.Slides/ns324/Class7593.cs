using System;
using ns305;
using ns322;
using ns323;

namespace ns324;

internal class Class7593 : Class7456
{
	private static readonly Type type_0 = typeof(Class7049);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => typeof(Class6976);

	public override void Initialize()
	{
		method_11("name", Enum983.flag_0);
		method_11("entities", Enum983.flag_0);
		method_11("notations", Enum983.flag_0);
		method_11("publicId", Enum983.flag_0);
		method_11("systemId", Enum983.flag_0);
		method_11("internalSubset", Enum983.flag_0);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class7049 @class = (Class7049)instance.Value;
		return function switch
		{
			"get_name" => method_3(@class.Name), 
			"get_entities" => method_2(@class.Entities, typeof(Class7062)), 
			"get_notations" => method_2(@class.Notations, typeof(Class7062)), 
			"get_publicId" => method_3(@class.PublicId), 
			"get_systemId" => method_3(@class.SystemId), 
			"get_internalSubset" => method_3(@class.InternalSubset), 
			_ => throw new Exception89("unknown function"), 
		};
	}
}
