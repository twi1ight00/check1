using System;
using ns305;
using ns322;
using ns323;

namespace ns324;

internal class Class7668 : Class7456
{
	private static readonly Type type_0 = typeof(Class7095);

	protected internal override Type Type => type_0;

	public override void Initialize()
	{
		method_10("isDerivedFrom");
		method_11("typeName", Enum983.flag_0);
		method_11("typeNamespace", Enum983.flag_0);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class7095 @class = (Class7095)instance.Value;
		switch (function)
		{
		case "isDerivedFrom":
			if (parameters.Length != 3)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_6(@class.method_0(parameters[0].ToString(), parameters[1].ToString(), (Enum966)parameters[2].vmethod_4()));
		case "get_TypeNamespace":
			return method_3(@class.TypeNamespace);
		default:
			throw new Exception89("unknown function");
		case "get_TypeName":
			return method_3(@class.TypeName);
		}
	}
}
