using System;
using ns305;
using ns322;
using ns323;

namespace ns324;

internal class Class7585 : Class7456
{
	private static readonly Type type_0 = typeof(Class7045);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => typeof(Class6976);

	public override void Initialize()
	{
		method_11("name", Enum983.flag_0);
		method_11("specified", Enum983.flag_0);
		method_11("value", Enum983.flag_0 | Enum983.flag_1);
		method_11("ownerElement", Enum983.flag_0);
		method_11("schemaTypeInfo", Enum983.flag_0);
		method_11("isId", Enum983.flag_0);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class7045 @class = (Class7045)instance.Value;
		switch (function)
		{
		case "get_name":
			return method_3(@class.Name);
		case "get_specified":
			return method_6(@class.Specified);
		case "get_value":
			return method_3(@class.Value);
		case "set_value":
			@class.Value = parameters[0].ToString();
			return base.Undefined;
		case "get_ownerElement":
		{
			Class6976 ownerElement = @class.OwnerElement;
			if (ownerElement == null)
			{
				return base.Undefined;
			}
			return method_2(ownerElement, ownerElement.GetType());
		}
		case "get_schemaTypeInfo":
			return method_2(@class.SchemaTypeInfo, typeof(Class7095));
		default:
			throw new Exception89("unknown function");
		case "get_isId":
			return method_6(@class.IsId);
		}
	}
}
