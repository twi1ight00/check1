using System;
using ns287;
using ns306;
using ns322;
using ns323;

namespace ns327;

internal class Class7626 : Class7456
{
	private static readonly Type type_0 = typeof(Class7014);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => typeof(Class6982);

	public override void Initialize()
	{
		method_11("align", Enum983.flag_0 | Enum983.flag_1);
		method_11("noShade", Enum983.flag_0 | Enum983.flag_1);
		method_11("size", Enum983.flag_0 | Enum983.flag_1);
		method_11("width", Enum983.flag_0 | Enum983.flag_1);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class7014 @class = (Class7014)instance.Value;
		switch (function)
		{
		case "get_align":
			return method_3(@class.Align);
		case "set_align":
			@class.Align = parameters[0].ToString();
			break;
		case "get_noShade":
			return method_6(@class.NoShade);
		case "set_noShade":
			@class.NoShade = parameters[0].vmethod_2();
			break;
		case "get_size":
			return method_3(@class.Size);
		case "set_size":
			@class.Size = parameters[0].ToString();
			break;
		case "get_width":
			return method_3(@class.Width);
		case "set_width":
			@class.Width = parameters[0].ToString();
			break;
		default:
			throw new Exception89("unknown function");
		}
		return base.Undefined;
	}
}
