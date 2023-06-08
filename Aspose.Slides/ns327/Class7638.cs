using System;
using ns287;
using ns306;
using ns322;
using ns323;

namespace ns327;

internal class Class7638 : Class7456
{
	private static readonly Type type_0 = typeof(Class7025);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => typeof(Class6982);

	public override void Initialize()
	{
		method_11("content", Enum983.flag_0 | Enum983.flag_1);
		method_11("httpEquiv", Enum983.flag_0 | Enum983.flag_1);
		method_11("name", Enum983.flag_0 | Enum983.flag_1);
		method_11("scheme", Enum983.flag_0 | Enum983.flag_1);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class7025 @class = (Class7025)instance.Value;
		switch (function)
		{
		case "get_content":
			return method_3(@class.Content);
		case "set_content":
			@class.Content = parameters[0].ToString();
			break;
		case "get_httpEquiv":
			return method_3(@class.HttpEquiv);
		case "set_httpEquiv":
			@class.HttpEquiv = parameters[0].ToString();
			break;
		case "get_name":
			return method_3(@class.Name);
		case "set_name":
			@class.Name = parameters[0].ToString();
			break;
		case "get_scheme":
			return method_3(@class.Scheme);
		case "set_scheme":
			@class.Scheme = parameters[0].ToString();
			break;
		default:
			throw new Exception89("unknown function");
		}
		return base.Undefined;
	}
}
