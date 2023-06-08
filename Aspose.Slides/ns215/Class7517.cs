using System;
using ns216;
using ns217;
using ns322;
using ns323;

namespace ns215;

internal class Class7517 : Class7458
{
	internal static readonly Type type_0 = typeof(Class5834);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => Class7552.type_0;

	public override void Initialize()
	{
		method_11("blank", Enum983.flag_0 | Enum983.flag_1);
		method_11("initialNumber", Enum983.flag_0 | Enum983.flag_1);
		method_11("numbered", Enum983.flag_0 | Enum983.flag_1);
		method_11("relevant", Enum983.flag_0 | Enum983.flag_1);
		method_11("use", Enum983.flag_0 | Enum983.flag_1);
		method_11("usehref", Enum983.flag_0 | Enum983.flag_1);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		switch (function)
		{
		case "get_blank":
		case "set_blank":
			function += "OrNotBlank";
			break;
		}
		return base.vmethod_1(function, instance, parameters);
	}
}
