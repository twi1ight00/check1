using System;
using ns287;
using ns306;
using ns322;
using ns323;

namespace ns327;

internal class Class7657 : Class7456
{
	private static readonly Type type_0 = typeof(Class7041);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => typeof(Class6982);

	public override void Initialize()
	{
		method_10("insertRow");
		method_10("deleteRow");
		method_11("align", Enum983.flag_0 | Enum983.flag_1);
		method_11("ch", Enum983.flag_0 | Enum983.flag_1);
		method_11("chOff", Enum983.flag_0 | Enum983.flag_1);
		method_11("vAlign", Enum983.flag_0 | Enum983.flag_1);
		method_11("rows", Enum983.flag_0);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class7041 @class = (Class7041)instance.Value;
		switch (function)
		{
		case "get_align":
			return method_3(@class.Align);
		case "set_align":
			@class.Align = parameters[0].ToString();
			break;
		case "get_ch":
			return method_3(@class.Ch);
		case "set_ch":
			@class.Ch = parameters[0].ToString();
			break;
		case "get_chOff":
			return method_3(@class.ChOff);
		case "set_chOff":
			@class.ChOff = parameters[0].ToString();
			break;
		case "get_vAlign":
			return method_3(@class.VAlign);
		case "set_vAlign":
			@class.VAlign = parameters[0].ToString();
			break;
		case "get_rows":
			return method_2(@class.Rows, typeof(Class7078));
		case "insertRow":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_2(@class.method_53(parameters[0].vmethod_4()), typeof(Class7040));
		case "deleteRow":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			@class.method_54(parameters[0].vmethod_4());
			break;
		default:
			throw new Exception89("unknown function");
		}
		return base.Undefined;
	}
}
