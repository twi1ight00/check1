using System;
using ns287;
using ns305;
using ns306;
using ns322;
using ns323;

namespace ns327;

internal class Class7628 : Class7456
{
	private static readonly Type type_0 = typeof(Class7016);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => typeof(Class6982);

	public override void Initialize()
	{
		method_11("align", Enum983.flag_0 | Enum983.flag_1);
		method_11("frameBorder", Enum983.flag_0 | Enum983.flag_1);
		method_11("height", Enum983.flag_0 | Enum983.flag_1);
		method_11("longDesc", Enum983.flag_0 | Enum983.flag_1);
		method_11("marginHeight", Enum983.flag_0 | Enum983.flag_1);
		method_11("marginWidth", Enum983.flag_0 | Enum983.flag_1);
		method_11("name", Enum983.flag_0 | Enum983.flag_1);
		method_11("scrolling", Enum983.flag_0 | Enum983.flag_1);
		method_11("src", Enum983.flag_0 | Enum983.flag_1);
		method_11("width", Enum983.flag_0 | Enum983.flag_1);
		method_11("contentDocument", Enum983.flag_0);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class7016 @class = (Class7016)instance.Value;
		switch (function)
		{
		case "get_align":
			return method_3(@class.Align);
		case "set_align":
			@class.Align = parameters[0].ToString();
			goto IL_02d8;
		case "get_frameBorder":
			return method_3(@class.FrameBorder);
		case "set_frameBorder":
			@class.FrameBorder = parameters[0].ToString();
			goto IL_02d8;
		case "get_height":
			return method_3(@class.Height);
		case "set_height":
			@class.Height = parameters[0].ToString();
			goto IL_02d8;
		case "get_longDesc":
			return method_3(@class.LongDesc);
		case "set_longDesc":
			@class.LongDesc = parameters[0].ToString();
			goto IL_02d8;
		case "get_marginHeight":
			return method_3(@class.MarginHeight);
		case "set_marginHeight":
			@class.MarginHeight = parameters[0].ToString();
			goto IL_02d8;
		case "get_marginWidth":
			return method_3(@class.MarginWidth);
		case "set_marginWidth":
			@class.MarginWidth = parameters[0].ToString();
			goto IL_02d8;
		case "get_name":
			return method_3(@class.Name);
		case "set_name":
			@class.Name = parameters[0].ToString();
			goto IL_02d8;
		case "get_scrolling":
			return method_3(@class.Scrolling);
		case "set_scrolling":
			@class.Scrolling = parameters[0].ToString();
			goto IL_02d8;
		case "get_src":
			return method_3(@class.Src);
		case "set_src":
			@class.Src = parameters[0].ToString();
			goto IL_02d8;
		case "get_width":
			return method_3(@class.Width);
		case "set_width":
			@class.Width = parameters[0].ToString();
			goto IL_02d8;
		default:
			throw new Exception89("unknown function");
		case "get_contentDocument":
			{
				return method_2(@class.ContentDocument, typeof(Class7046));
			}
			IL_02d8:
			return base.Undefined;
		}
	}
}
