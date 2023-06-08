using System;
using ns287;
using ns306;
using ns322;
using ns323;

namespace ns327;

internal class Class7634 : Class7456
{
	private static readonly Type type_0 = typeof(Class7021);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => typeof(Class6982);

	public override void Initialize()
	{
		method_11("type", Enum983.flag_0 | Enum983.flag_1);
		method_11("value", Enum983.flag_0 | Enum983.flag_1);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class7021 @class = (Class7021)instance.Value;
		switch (function)
		{
		case "set_value":
			@class.Value = parameters[0].vmethod_4();
			goto IL_0071;
		case "get_value":
			return method_5(@class.Value);
		case "set_type":
			@class.Type = parameters[0].ToString();
			goto IL_0071;
		default:
			throw new Exception89("unknown function");
		case "get_type":
			{
				return method_3(@class.Type);
			}
			IL_0071:
			return base.Undefined;
		}
	}
}
