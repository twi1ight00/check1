using System;
using ns287;
using ns306;
using ns322;
using ns323;

namespace ns327;

internal class Class7621 : Class7456
{
	private static readonly Type type_0 = typeof(Class7009);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => typeof(Class6982);

	public override void Initialize()
	{
		method_10("Submit");
		method_10("Reset");
		method_11("elements", Enum983.flag_0);
		method_11("length", Enum983.flag_0);
		method_11("name", Enum983.flag_0 | Enum983.flag_1);
		method_11("acceptCharset", Enum983.flag_0 | Enum983.flag_1);
		method_11("action", Enum983.flag_0 | Enum983.flag_1);
		method_11("enctype", Enum983.flag_0 | Enum983.flag_1);
		method_11("method", Enum983.flag_0 | Enum983.flag_1);
		method_11("target", Enum983.flag_0 | Enum983.flag_1);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class7009 @class = (Class7009)instance.Value;
		switch (function)
		{
		case "get_elements":
			return method_2(@class.Elements, typeof(Class7078));
		case "get_length":
			return method_5(@class.Length);
		case "get_name":
			return method_3(@class.Name);
		case "set_name":
			@class.Name = parameters[0].ToString();
			break;
		case "get_acceptCharset":
			return method_3(@class.AcceptCharset);
		case "set_acceptCharset":
			@class.AcceptCharset = parameters[0].ToString();
			break;
		case "get_action":
			return method_3(@class.Action);
		case "set_action":
			@class.Action = parameters[0].ToString();
			break;
		case "get_enctype":
			return method_3(@class.Enctype);
		case "set_enctype":
			@class.Enctype = parameters[0].ToString();
			break;
		case "get_method":
			return method_3(@class.Method);
		case "set_method":
			@class.Method = parameters[0].ToString();
			break;
		case "get_target":
			return method_3(@class.Target);
		case "set_target":
			@class.Target = parameters[0].ToString();
			break;
		default:
			throw new Exception89("unknown function");
		case "submit":
		case "reset":
			break;
		}
		return base.Undefined;
	}
}
