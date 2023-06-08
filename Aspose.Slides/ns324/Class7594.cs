using System;
using ns305;
using ns322;
using ns323;

namespace ns324;

internal class Class7594 : Class7456
{
	private static readonly Type type_0 = typeof(Class7073);

	protected internal override Type Type => type_0;

	public override void Initialize()
	{
		method_10("setParameter");
		method_10("getParameter");
		method_10("canSetParameter");
		method_11("parameterNames", Enum983.flag_0);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class7073 @class = (Class7073)instance.Value;
		switch (function)
		{
		case "get_parameterNames":
			return method_2(@class.ParameterNames, typeof(Class7088));
		case "canSetParameter":
			if (parameters.Length != 2)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_6(@class.method_2(parameters[0].ToString(), parameters[1].vmethod_5()));
		case "getParameter":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_7(@class.method_1(parameters[0].ToString()));
		case "setParameter":
			if (parameters.Length != 2)
			{
				throw new Exception89("invalid arguments count.");
			}
			@class.method_0(parameters[0].ToString(), parameters[1].vmethod_5());
			return base.Undefined;
		default:
			throw new Exception89("unknown function");
		}
	}
}
