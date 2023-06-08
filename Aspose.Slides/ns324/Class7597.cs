using System;
using ns305;
using ns322;
using ns323;

namespace ns324;

internal class Class7597 : Class7456
{
	private static readonly Type type_0 = typeof(Class7097);

	protected internal override Type Type => type_0;

	public override void Initialize()
	{
		method_10("hasFeature");
		method_10("createDocumentType");
		method_10("createDocument");
		method_10("getFeature");
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class7097 @class = (Class7097)instance.Value;
		switch (function)
		{
		case "getFeature":
			if (parameters.Length != 2)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_7(@class.imethod_3(parameters[0].ToString(), parameters[0].ToString()));
		case "createDocument":
			if (parameters.Length != 3)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_2(@class.imethod_0(parameters[0].ToString(), parameters[1].ToString(), (Class7049)parameters[1].vmethod_5()), typeof(Class7046));
		case "createDocumentType":
			if (parameters.Length != 3)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_2(@class.imethod_2(parameters[0].ToString(), parameters[1].ToString(), parameters[1].ToString()), typeof(Class7049));
		case "hasFeature":
			if (parameters.Length != 2)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_6(@class.imethod_1(parameters[0].ToString(), parameters[1].ToString()));
		default:
			throw new Exception89("unknown function");
		}
	}
}
