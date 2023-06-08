using System;
using ns287;
using ns306;
using ns322;
using ns323;

namespace ns327;

internal class Class7646 : Class7456
{
	private static readonly Type type_0 = typeof(Class7031);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => typeof(Class6982);

	public override void Initialize()
	{
		method_11("name", Enum983.flag_0 | Enum983.flag_1);
		method_11("type", Enum983.flag_0 | Enum983.flag_1);
		method_11("value", Enum983.flag_0 | Enum983.flag_1);
		method_11("valueType", Enum983.flag_0 | Enum983.flag_1);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class7031 @class = (Class7031)instance.Value;
		switch (function)
		{
		case "get_name":
			return method_3(@class.Name);
		case "set_name":
			@class.Name = parameters[0].ToString();
			break;
		case "get_type":
			return method_3(@class.Type);
		case "set_type":
			@class.Type = parameters[0].ToString();
			break;
		case "get_value":
			return method_3(@class.Value);
		case "set_value":
			@class.Value = parameters[0].ToString();
			break;
		case "get_valueType":
			return method_3(@class.ValueType);
		case "set_valueType":
			@class.ValueType = parameters[0].ToString();
			break;
		default:
			throw new Exception89("unknown function");
		}
		return base.Undefined;
	}
}
