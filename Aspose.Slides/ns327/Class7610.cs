using System;
using ns287;
using ns306;
using ns322;
using ns323;

namespace ns327;

internal class Class7610 : Class7456
{
	private static readonly Type type_0 = typeof(Class7000);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => typeof(Class6982);

	public override void Initialize()
	{
		method_11("color", Enum983.flag_0 | Enum983.flag_1);
		method_11("face", Enum983.flag_0 | Enum983.flag_1);
		method_11("size", Enum983.flag_0 | Enum983.flag_1);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class7000 @class = (Class7000)instance.Value;
		switch (function)
		{
		case "get_color":
			return method_3(@class.Color);
		case "set_color":
			@class.Color = parameters[0].ToString();
			break;
		case "get_face":
			return method_3(@class.Face);
		case "set_face":
			@class.Face = parameters[0].ToString();
			break;
		case "get_size":
			return method_5(@class.Size);
		case "set_size":
			@class.Size = parameters[0].vmethod_4();
			break;
		default:
			throw new Exception89("unknown function");
		}
		return base.Undefined;
	}
}
