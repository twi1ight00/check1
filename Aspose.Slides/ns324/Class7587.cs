using System;
using ns305;
using ns322;
using ns323;

namespace ns324;

internal class Class7587 : Class7456
{
	private static readonly Type type_0 = typeof(Class6977);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => typeof(Class6976);

	public override void Initialize()
	{
		method_10("substringData");
		method_10("appendData");
		method_10("insertData");
		method_10("deleteData");
		method_10("replaceData");
		method_11("data", Enum983.flag_0 | Enum983.flag_1);
		method_11("length", Enum983.flag_0);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class6977 @class = (Class6977)instance.Value;
		switch (function)
		{
		case "get_data":
			return method_3(@class.Data);
		case "set_data":
			@class.Data = parameters[0].ToString();
			break;
		case "get_length":
			return method_5(@class.Length);
		case "substringData":
			if (parameters.Length != 2)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_3(@class.vmethod_5(parameters[0].vmethod_4(), parameters[1].vmethod_4()));
		case "appendData":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			@class.vmethod_6(parameters[0].ToString());
			break;
		case "insertData":
			if (parameters.Length != 2)
			{
				throw new Exception89("invalid arguments count.");
			}
			@class.vmethod_7(parameters[0].vmethod_4(), parameters[1].ToString());
			break;
		case "deleteData":
			if (parameters.Length != 2)
			{
				throw new Exception89("invalid arguments count.");
			}
			@class.vmethod_8(parameters[0].vmethod_4(), parameters[1].vmethod_4());
			break;
		case "replaceData":
			if (parameters.Length != 3)
			{
				throw new Exception89("invalid arguments count.");
			}
			@class.vmethod_9(parameters[0].vmethod_4(), parameters[1].vmethod_4(), parameters[2].ToString());
			break;
		default:
			throw new Exception89("unknown function");
		}
		return base.Undefined;
	}
}
