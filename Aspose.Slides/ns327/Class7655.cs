using System;
using ns287;
using ns306;
using ns322;
using ns323;

namespace ns327;

internal class Class7655 : Class7456
{
	private static readonly Type type_0 = typeof(Class6993);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => typeof(Class6982);

	public override void Initialize()
	{
		method_10("createTHead");
		method_10("deleteTHead");
		method_10("createTFoot");
		method_10("deleteTFoot");
		method_10("createCaption");
		method_10("deleteCaption");
		method_10("insertRow");
		method_10("deleteRow");
		method_11("caption", Enum983.flag_0 | Enum983.flag_1);
		method_11("tHead", Enum983.flag_0 | Enum983.flag_1);
		method_11("tFoot", Enum983.flag_0 | Enum983.flag_1);
		method_11("rows", Enum983.flag_0 | Enum983.flag_1);
		method_11("tBodies", Enum983.flag_0 | Enum983.flag_1);
		method_11("align", Enum983.flag_0 | Enum983.flag_1);
		method_11("bgColor", Enum983.flag_0 | Enum983.flag_1);
		method_11("border", Enum983.flag_0 | Enum983.flag_1);
		method_11("cellPadding", Enum983.flag_0 | Enum983.flag_1);
		method_11("cellSpacing", Enum983.flag_0 | Enum983.flag_1);
		method_11("frame", Enum983.flag_0 | Enum983.flag_1);
		method_11("rules", Enum983.flag_0 | Enum983.flag_1);
		method_11("summary", Enum983.flag_0 | Enum983.flag_1);
		method_11("width", Enum983.flag_0 | Enum983.flag_1);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class6993 @class = (Class6993)instance.Value;
		switch (function)
		{
		case "get_caption":
			return method_2(@class.Caption, typeof(Class7037));
		case "get_tHead":
			return method_2(@class.THead, typeof(Class7041));
		case "get_tFoot":
			return method_2(@class.TFoot, typeof(Class7041));
		case "get_rows":
			return method_2(@class.Rows, typeof(Class7078));
		case "get_tBodies":
			return method_2(@class.TBodies, typeof(Class7078));
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
		case "get_border":
			return method_3(@class.Border);
		case "set_border":
			@class.Border = parameters[0].ToString();
			break;
		case "get_cellPadding":
			return method_3(@class.CellPadding);
		case "set_cellPadding":
			@class.CellPadding = parameters[0].ToString();
			break;
		case "get_cellSpacing":
			return method_3(@class.CellSpacing);
		case "set_cellSpacing":
			@class.CellSpacing = parameters[0].ToString();
			break;
		case "get_frame":
			return method_3(@class.Frame);
		case "set_frame":
			@class.Frame = parameters[0].ToString();
			break;
		case "get_rules":
			return method_3(@class.Rules);
		case "set_rules":
			@class.Rules = parameters[0].ToString();
			break;
		case "get_summary":
			return method_3(@class.Summary);
		case "set_summary":
			@class.Summary = parameters[0].ToString();
			break;
		case "get_width":
			return method_3(@class.Width);
		case "set_width":
			@class.Width = parameters[0].ToString();
			break;
		case "createTHead":
			return method_2(@class.method_54(), typeof(Class7041));
		case "deleteTHead":
			@class.method_55();
			break;
		case "createTFoot":
			return method_2(@class.method_56(), typeof(Class7041));
		case "deleteTFoot":
			@class.method_57();
			break;
		case "createCaption":
			return method_2(@class.method_58(), typeof(Class7037));
		case "deleteCaption":
			@class.method_59();
			break;
		case "insertRow":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_2(@class.method_61(parameters[0].vmethod_4()), typeof(Class7040));
		case "deleteRow":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			@class.method_62(parameters[0].vmethod_4());
			break;
		default:
			throw new Exception89("unknown function");
		case "set_caption":
		case "set_tHead":
		case "set_tFoot":
		case "set_rows":
		case "set_tBodies":
			break;
		}
		return base.Undefined;
	}
}
