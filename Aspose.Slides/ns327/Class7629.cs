using System;
using ns287;
using ns306;
using ns322;
using ns323;

namespace ns327;

internal class Class7629 : Class7456
{
	private static readonly Type type_0 = typeof(Class7017);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => typeof(Class6982);

	public override void Initialize()
	{
		method_11("name", Enum983.flag_0 | Enum983.flag_1);
		method_11("align", Enum983.flag_0 | Enum983.flag_1);
		method_11("alt", Enum983.flag_0 | Enum983.flag_1);
		method_11("border", Enum983.flag_0 | Enum983.flag_1);
		method_11("height", Enum983.flag_0 | Enum983.flag_1);
		method_11("hspace", Enum983.flag_0 | Enum983.flag_1);
		method_11("isMap", Enum983.flag_0 | Enum983.flag_1);
		method_11("longDesc", Enum983.flag_0 | Enum983.flag_1);
		method_11("src", Enum983.flag_0 | Enum983.flag_1);
		method_11("useMap", Enum983.flag_0 | Enum983.flag_1);
		method_11("vspace", Enum983.flag_0 | Enum983.flag_1);
		method_11("width", Enum983.flag_0 | Enum983.flag_1);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class7017 @class = (Class7017)instance.Value;
		switch (function)
		{
		case "get_name":
			return method_3(@class.Name);
		case "set_name":
			@class.Name = parameters[0].ToString();
			break;
		case "get_align":
			return method_3(@class.Align);
		case "set_align":
			@class.Align = parameters[0].ToString();
			break;
		case "get_alt":
			return method_3(@class.Alt);
		case "set_alt":
			@class.Alt = parameters[0].ToString();
			break;
		case "get_border":
			return method_3(@class.Border);
		case "set_border":
			@class.Border = parameters[0].ToString();
			break;
		case "get_height":
			return method_5(@class.Height);
		case "set_height":
			@class.Height = parameters[0].vmethod_4();
			break;
		case "get_hspace":
			return method_5(@class.Hspace);
		case "set_hspace":
			@class.Hspace = parameters[0].vmethod_4();
			break;
		case "get_isMap":
			return method_6(@class.IsMap);
		case "set_isMap":
			@class.IsMap = parameters[0].vmethod_2();
			break;
		case "get_longDesc":
			return method_3(@class.LongDesc);
		case "set_longDesc":
			@class.LongDesc = parameters[0].ToString();
			break;
		case "get_src":
			return method_3(@class.Src);
		case "set_src":
			@class.Src = parameters[0].ToString();
			break;
		case "get_useMap":
			return method_3(@class.UseMap);
		case "set_useMap":
			@class.UseMap = parameters[0].ToString();
			break;
		case "get_vspace":
			return method_5(@class.Vspace);
		case "set_vspace":
			@class.Vspace = parameters[0].vmethod_4();
			break;
		case "get_width":
			return method_5(@class.Width);
		case "set_width":
			@class.Width = parameters[0].vmethod_4();
			break;
		default:
			throw new Exception89("unknown function");
		}
		return base.Undefined;
	}
}
