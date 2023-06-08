using System;
using ns216;
using ns217;
using ns322;
using ns323;

namespace ns215;

internal class Class7537 : Class7458
{
	internal static readonly Type type_0 = typeof(Class5889);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => Class7552.type_0;

	public override void Initialize()
	{
		method_11("{default}", Enum983.flag_0 | Enum983.flag_1);
		method_11("maxChars", Enum983.flag_0 | Enum983.flag_1);
		method_11("use", Enum983.flag_0 | Enum983.flag_1);
		method_11("usehref", Enum983.flag_0 | Enum983.flag_1);
		method_11("value", Enum983.flag_0 | Enum983.flag_1);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class5889 @class = (Class5889)instance.Value;
		switch (function)
		{
		case "set_{default}":
		case "set_value":
			@class.Value = parameters[0].ToString();
			return base.Undefined;
		case "get_{default}":
		case "get_value":
			return method_3(@class.Value);
		default:
			return base.vmethod_1(function, instance, parameters);
		}
	}
}
