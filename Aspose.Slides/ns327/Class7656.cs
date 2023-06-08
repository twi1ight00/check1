using System;
using ns287;
using ns306;
using ns322;
using ns323;

namespace ns327;

internal class Class7656 : Class7456
{
	private static readonly Type type_0 = typeof(Class7040);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => typeof(Class6982);

	public override void Initialize()
	{
		method_10("insertCell");
		method_10("deleteCell");
		method_11("rowIndex", Enum983.flag_0);
		method_11("sectionRowIndex", Enum983.flag_0);
		method_11("cells", Enum983.flag_0);
		method_11("align", Enum983.flag_0 | Enum983.flag_1);
		method_11("bgColor", Enum983.flag_0 | Enum983.flag_1);
		method_11("ch", Enum983.flag_0 | Enum983.flag_1);
		method_11("chOff", Enum983.flag_0 | Enum983.flag_1);
		method_11("vAlign", Enum983.flag_0 | Enum983.flag_1);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class7040 @class = (Class7040)instance.Value;
		switch (function)
		{
		case "get_rowIndex":
			return method_5(@class.RowIndex);
		case "get_sectionRowIndex":
			return method_5(@class.SectionRowIndex);
		case "get_cells":
			return method_2(@class.Cells, typeof(Class7078));
		case "get_align":
			return method_3(@class.Align);
		case "set_align":
			@class.Align = parameters[0].ToString();
			break;
		case "get_bgColor":
			return method_3(@class.BgColor);
		case "set_bgColor":
			@class.BgColor = parameters[0].ToString();
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
		case "insertCell":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_2(@class.method_53(parameters[0].vmethod_4()), typeof(Class7038));
		case "deleteCell":
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
