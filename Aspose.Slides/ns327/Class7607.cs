using System;
using ns287;
using ns306;
using ns322;
using ns323;

namespace ns327;

internal class Class7607 : Class7456
{
	private static readonly Type type_0 = typeof(Class6997);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => typeof(Class6982);

	public override void Initialize()
	{
		method_11("align", Enum983.flag_0 | Enum983.flag_1);
		method_11("alt", Enum983.flag_0 | Enum983.flag_1);
		method_11("archive", Enum983.flag_0 | Enum983.flag_1);
		method_11("code", Enum983.flag_0 | Enum983.flag_1);
		method_11("codeBase", Enum983.flag_0 | Enum983.flag_1);
		method_11("height", Enum983.flag_0 | Enum983.flag_1);
		method_11("hspace", Enum983.flag_0 | Enum983.flag_1);
		method_11("name", Enum983.flag_0 | Enum983.flag_1);
		method_11("object", Enum983.flag_0 | Enum983.flag_1);
		method_11("vspace", Enum983.flag_0 | Enum983.flag_1);
		method_11("width", Enum983.flag_0 | Enum983.flag_1);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class6997 @class = (Class6997)instance.Value;
		switch (function)
		{
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
		case "get_archive":
			return method_3(@class.Archive);
		case "set_archive":
			@class.Archive = parameters[0].ToString();
			break;
		case "get_code":
			return method_3(@class.Code);
		case "set_code":
			@class.Code = parameters[0].ToString();
			break;
		case "get_codeBase":
			return method_3(@class.CodeBase);
		case "set_codeBase":
			@class.CodeBase = parameters[0].ToString();
			break;
		case "get_height":
			return method_3(@class.Height);
		case "set_height":
			@class.Height = parameters[0].ToString();
			break;
		case "get_hspace":
			return method_5(@class.Hspace);
		case "set_hspace":
			@class.Hspace = parameters[0].vmethod_4();
			break;
		case "get_name":
			return method_3(@class.Name);
		case "set_name":
			@class.Name = parameters[0].ToString();
			break;
		case "get_object":
			return method_3(@class.Object);
		case "set_object":
			@class.Object = parameters[0].ToString();
			break;
		case "get_vspace":
			return method_5(@class.Vspace);
		case "set_vspace":
			@class.Vspace = parameters[0].vmethod_4();
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
