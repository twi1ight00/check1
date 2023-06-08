using System;
using ns287;
using ns306;
using ns322;
using ns323;

namespace ns327;

internal class Class7648 : Class7456
{
	private static readonly Type type_0 = typeof(Class7033);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => typeof(Class6982);

	public override void Initialize()
	{
		method_11("cite", Enum983.flag_0 | Enum983.flag_1);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class7033 @class = (Class7033)instance.Value;
		switch (function)
		{
		case "set_cite":
			@class.Cite = parameters[0].ToString();
			return base.Undefined;
		default:
			throw new Exception89("unknown function");
		case "get_cite":
			return method_3(@class.Cite);
		}
	}
}
