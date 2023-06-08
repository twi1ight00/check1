using System;
using ns287;
using ns306;
using ns322;
using ns323;

namespace ns327;

internal class Class7642 : Class7456
{
	private static readonly Type type_0 = typeof(Class7028);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => typeof(Class6982);

	public override void Initialize()
	{
		method_11("disabled", Enum983.flag_0 | Enum983.flag_1);
		method_11("label", Enum983.flag_0 | Enum983.flag_1);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class7028 @class = (Class7028)instance.Value;
		switch (function)
		{
		case "set_label":
			@class.Label = parameters[0].ToString();
			goto IL_0070;
		case "get_label":
			return method_3(@class.Label);
		case "set_disabled":
			@class.Disabled = parameters[0].vmethod_2();
			goto IL_0070;
		default:
			throw new Exception89("unknown function");
		case "get_disabled":
			{
				return method_6(@class.Disabled);
			}
			IL_0070:
			return base.Undefined;
		}
	}
}
