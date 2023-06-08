using System;
using ns305;
using ns306;
using ns322;
using ns323;

namespace ns324;

internal class Class7590 : Class7456
{
	private static readonly Type type_0 = typeof(Class6982);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => typeof(Class6981);

	public override void Initialize()
	{
		method_11("id", Enum983.flag_0 | Enum983.flag_1);
		method_11("title", Enum983.flag_0 | Enum983.flag_1);
		method_11("lang", Enum983.flag_0 | Enum983.flag_1);
		method_11("dir", Enum983.flag_0 | Enum983.flag_1);
		method_11("className", Enum983.flag_0 | Enum983.flag_1);
		method_11("style", Enum983.flag_0 | Enum983.flag_1);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class6982 @class = (Class6982)instance.Value;
		switch (function)
		{
		case "get_id":
			return method_3(@class.Id);
		case "set_id":
			@class.Id = parameters[0].ToString();
			break;
		case "get_title":
			return method_3(@class.Title);
		case "set_title":
			@class.Title = parameters[0].ToString();
			break;
		case "get_lang":
			return method_3(@class.Lang);
		case "set_lang":
			@class.Lang = parameters[0].ToString();
			break;
		case "get_dir":
			return method_3(@class.Dir);
		case "set_dir":
			@class.Dir = parameters[0].ToString();
			break;
		case "get_className":
			return method_3(@class.ClassName);
		case "set_className":
			@class.ClassName = parameters[0].ToString();
			break;
		case "get_style":
			return method_3(@class.Style);
		case "set_style":
			@class.Style = parameters[0].ToString();
			break;
		default:
			throw new Exception89("unknown function");
		}
		return base.Undefined;
	}
}
