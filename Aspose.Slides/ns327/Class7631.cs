using System;
using ns287;
using ns306;
using ns322;
using ns323;

namespace ns327;

internal class Class7631 : Class7456
{
	private static readonly Type type_0 = typeof(Class7018);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => typeof(Class6982);

	public override void Initialize()
	{
		method_11("form", Enum983.flag_0);
		method_11("prompt", Enum983.flag_0 | Enum983.flag_1);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class7018 @class = (Class7018)instance.Value;
		switch (function)
		{
		case "set_prompt":
			@class.Prompt = parameters[0].ToString();
			return base.Undefined;
		case "get_prompt":
			return method_3(@class.Prompt);
		default:
			throw new Exception89("unknown function");
		case "get_form":
			return method_2(@class.Form, typeof(Class7009));
		}
	}
}
