using System;
using ns305;
using ns322;
using ns323;

namespace ns324;

internal class Class7665 : Class7456
{
	private static readonly Type type_0 = typeof(Class7054);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => typeof(Class6976);

	public override void Initialize()
	{
		method_11("publicId", Enum983.flag_0);
		method_11("systemId", Enum983.flag_0);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class7054 @class = (Class7054)instance.Value;
		return function switch
		{
			"get_systemId" => method_3(@class.SystemId), 
			"get_publicId" => method_3(@class.PublicId), 
			_ => throw new Exception89("unknown function"), 
		};
	}
}
