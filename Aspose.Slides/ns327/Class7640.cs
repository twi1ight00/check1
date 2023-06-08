using System;
using ns287;
using ns305;
using ns306;
using ns322;
using ns323;

namespace ns327;

internal class Class7640 : Class7456
{
	private static readonly Type type_0 = typeof(Class6994);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => typeof(Class6982);

	public override void Initialize()
	{
		method_11("form", Enum983.flag_0);
		method_11("code", Enum983.flag_0 | Enum983.flag_1);
		method_11("align", Enum983.flag_0 | Enum983.flag_1);
		method_11("archive", Enum983.flag_0 | Enum983.flag_1);
		method_11("border", Enum983.flag_0 | Enum983.flag_1);
		method_11("codeBase", Enum983.flag_0 | Enum983.flag_1);
		method_11("codeType", Enum983.flag_0 | Enum983.flag_1);
		method_11("classId", Enum983.flag_0 | Enum983.flag_1);
		method_11("data", Enum983.flag_0 | Enum983.flag_1);
		method_11("declare", Enum983.flag_0 | Enum983.flag_1);
		method_11("height", Enum983.flag_0 | Enum983.flag_1);
		method_11("hspace", Enum983.flag_0 | Enum983.flag_1);
		method_11("name", Enum983.flag_0 | Enum983.flag_1);
		method_11("standby", Enum983.flag_0 | Enum983.flag_1);
		method_11("tabIndex", Enum983.flag_0 | Enum983.flag_1);
		method_11("type", Enum983.flag_0 | Enum983.flag_1);
		method_11("useMap", Enum983.flag_0 | Enum983.flag_1);
		method_11("vspace", Enum983.flag_0 | Enum983.flag_1);
		method_11("width", Enum983.flag_0 | Enum983.flag_1);
		method_11("contentDocument", Enum983.flag_0);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class6994 @class = (Class6994)instance.Value;
		switch (function)
		{
		case "get_form":
			return method_2(@class.Form, typeof(Class7009));
		case "get_code":
			return method_3(@class.Code);
		case "set_code":
			@class.Code = parameters[0].ToString();
			goto IL_0513;
		case "get_align":
			return method_3(@class.Align);
		case "set_align":
			@class.Align = parameters[0].ToString();
			goto IL_0513;
		case "get_archive":
			return method_3(@class.Archive);
		case "set_archive":
			@class.Archive = parameters[0].ToString();
			goto IL_0513;
		case "get_border":
			return method_3(@class.Border);
		case "set_border":
			@class.Border = parameters[0].ToString();
			goto IL_0513;
		case "get_codeBase":
			return method_3(@class.CodeBase);
		case "set_codeBase":
			@class.CodeBase = parameters[0].ToString();
			goto IL_0513;
		case "get_codeType":
			return method_3(@class.CodeType);
		case "set_codeType":
			@class.CodeType = parameters[0].ToString();
			goto IL_0513;
		case "get_classId":
			return method_3(@class.ClassId);
		case "set_classId":
			@class.ClassId = parameters[0].ToString();
			goto IL_0513;
		case "get_data":
			return method_3(@class.Data);
		case "set_data":
			@class.Data = parameters[0].ToString();
			goto IL_0513;
		case "get_declare":
			return method_6(@class.Declare);
		case "set_declare":
			@class.Declare = parameters[0].vmethod_2();
			goto IL_0513;
		case "get_height":
			return method_3(@class.Height);
		case "set_height":
			@class.Height = parameters[0].ToString();
			goto IL_0513;
		case "get_hspace":
			return method_5(@class.Hspace);
		case "set_hspace":
			@class.Hspace = parameters[0].vmethod_4();
			goto IL_0513;
		case "get_name":
			return method_3(@class.Name);
		case "set_name":
			@class.Name = parameters[0].ToString();
			goto IL_0513;
		case "get_standby":
			return method_3(@class.Standby);
		case "set_standby":
			@class.Standby = parameters[0].ToString();
			goto IL_0513;
		case "get_tabIndex":
			return method_5(@class.TabIndex);
		case "set_tabIndex":
			@class.TabIndex = parameters[0].vmethod_4();
			goto IL_0513;
		case "get_type":
			return method_3(@class.Type);
		case "set_type":
			@class.Type = parameters[0].ToString();
			goto IL_0513;
		case "get_useMap":
			return method_3(@class.UseMap);
		case "set_useMap":
			@class.UseMap = parameters[0].ToString();
			goto IL_0513;
		case "get_vspace":
			return method_5(@class.Vspace);
		case "set_vspace":
			@class.Vspace = parameters[0].vmethod_4();
			goto IL_0513;
		case "get_width":
			return method_3(@class.Width);
		case "set_width":
			@class.Width = parameters[0].ToString();
			goto IL_0513;
		default:
			throw new Exception89("unknown function");
		case "get_contentDocument":
			{
				return method_2(@class.ContentDocument, typeof(Class7046));
			}
			IL_0513:
			return base.Undefined;
		}
	}
}
