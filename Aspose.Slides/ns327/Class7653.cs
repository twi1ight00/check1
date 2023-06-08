using System;
using ns287;
using ns306;
using ns322;
using ns323;

namespace ns327;

internal class Class7653 : Class7456
{
	private static readonly Type type_0 = typeof(Class7038);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => typeof(Class6982);

	public override void Initialize()
	{
		method_11("cellIndex", Enum983.flag_0);
		method_11("abbr", Enum983.flag_0 | Enum983.flag_1);
		method_11("align", Enum983.flag_0 | Enum983.flag_1);
		method_11("axis", Enum983.flag_0 | Enum983.flag_1);
		method_11("bgColor", Enum983.flag_0 | Enum983.flag_1);
		method_11("ch", Enum983.flag_0 | Enum983.flag_1);
		method_11("chOff", Enum983.flag_0 | Enum983.flag_1);
		method_11("colSpan", Enum983.flag_0 | Enum983.flag_1);
		method_11("headers", Enum983.flag_0 | Enum983.flag_1);
		method_11("height", Enum983.flag_0 | Enum983.flag_1);
		method_11("noWrap", Enum983.flag_0 | Enum983.flag_1);
		method_11("rowSpan", Enum983.flag_0 | Enum983.flag_1);
		method_11("scope", Enum983.flag_0 | Enum983.flag_1);
		method_11("vAlign", Enum983.flag_0 | Enum983.flag_1);
		method_11("width", Enum983.flag_0 | Enum983.flag_1);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class7038 @class = (Class7038)instance.Value;
		switch (function)
		{
		case "get_cellIndex":
			return method_5(@class.CellIndex);
		case "get_abbr":
			return method_3(@class.Abbr);
		case "set_abbr":
			@class.Abbr = parameters[0].ToString();
			break;
		case "get_align":
			return method_3(@class.Align);
		case "set_align":
			@class.Align = parameters[0].ToString();
			break;
		case "get_axis":
			return method_3(@class.Axis);
		case "set_axis":
			@class.Axis = parameters[0].ToString();
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
		case "get_colSpan":
			return method_5(@class.ColSpan);
		case "set_colSpan":
			@class.ColSpan = parameters[0].vmethod_4();
			break;
		case "get_headers":
			return method_3(@class.Headers);
		case "set_headers":
			@class.Headers = parameters[0].ToString();
			break;
		case "get_height":
			return method_3(@class.Height);
		case "set_height":
			@class.Height = parameters[0].ToString();
			break;
		case "get_noWrap":
			return method_6(@class.NoWrap);
		case "set_noWrap":
			@class.NoWrap = parameters[0].vmethod_2();
			break;
		case "get_rowSpan":
			return method_5(@class.RowSpan);
		case "set_rowSpan":
			@class.RowSpan = parameters[0].vmethod_4();
			break;
		case "get_scope":
			return method_3(@class.Scope);
		case "set_scope":
			@class.Scope = parameters[0].ToString();
			break;
		case "get_vAlign":
			return method_3(@class.VAlign);
		case "set_vAlign":
			@class.VAlign = parameters[0].ToString();
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
