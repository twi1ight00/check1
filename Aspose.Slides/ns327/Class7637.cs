using System;
using ns287;
using ns306;
using ns322;
using ns323;

namespace ns327;

internal class Class7637 : Class7456
{
	private static readonly Type type_0 = typeof(Class7024);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => typeof(Class6982);

	public override void Initialize()
	{
		method_11("compact", Enum983.flag_0 | Enum983.flag_1);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class7024 @class = (Class7024)instance.Value;
		switch (function)
		{
		case "set_compact":
			@class.Compact = parameters[0].vmethod_2();
			return base.Undefined;
		default:
			throw new Exception89("unknown function");
		case "get_compact":
			return method_6(@class.Compact);
		}
	}
}