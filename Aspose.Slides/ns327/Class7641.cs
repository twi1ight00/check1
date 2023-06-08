using System;
using ns287;
using ns306;
using ns322;
using ns323;

namespace ns327;

internal class Class7641 : Class7456
{
	private static readonly Type type_0 = typeof(Class7027);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => typeof(Class6982);

	public override void Initialize()
	{
		method_11("compact", Enum983.flag_0 | Enum983.flag_1);
		method_11("start", Enum983.flag_0 | Enum983.flag_1);
		method_11("type", Enum983.flag_0 | Enum983.flag_1);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class7027 @class = (Class7027)instance.Value;
		switch (function)
		{
		case "get_compact":
			return method_6(@class.Compact);
		case "set_compact":
			@class.Compact = parameters[0].vmethod_2();
			break;
		case "get_start":
			return method_5(@class.Start);
		case "set_start":
			@class.Start = parameters[0].vmethod_4();
			break;
		case "get_type":
			return method_3(@class.Type);
		case "set_type":
			@class.Type = parameters[0].ToString();
			break;
		default:
			throw new Exception89("unknown function");
		}
		return base.Undefined;
	}
}
