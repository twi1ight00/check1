using System;
using ns215;
using ns322;
using ns323;

namespace ns217;

internal class Class7552 : Class7457
{
	internal static readonly Type type_0 = typeof(Class5781);

	internal static Class7552 class7552_0;

	protected internal override Type Type => type_0;

	protected override Type InheritedType => Class7558.type_0;

	public override void Initialize()
	{
		method_10("applyXSL");
		method_10("assignNode");
		method_10("clone");
		method_10("getAttribute");
		method_10("getElement");
		method_10("isPropertySpecified");
		method_10("loadXML");
		method_10("saveFilteredXML");
		method_10("saveXML");
		method_10("setAttribute");
		method_10("setElement");
		method_11("id", Enum983.flag_0);
		method_11("isContainer", Enum983.flag_0);
		method_11("isNull", Enum983.flag_0);
		method_11("model", Enum983.flag_0);
		method_11("ns", Enum983.flag_0 | Enum983.flag_1);
		method_11("oneOfChild", Enum983.flag_0);
		class7552_0 = this;
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class5781 @class = (Class5781)instance.Value;
		switch (function)
		{
		case "applyXSL":
			return base.Undefined;
		case "assignNode":
			return base.Undefined;
		case "clone":
			return base.Undefined;
		case "get_id":
			return method_3(@class.Id);
		case "get_isContainer":
			return method_6(@class.vmethod_0());
		case "get_isNull":
			return method_6(@class.vmethod_1());
		case "get_oneOfChild":
		{
			Class5781 class2 = @class.vmethod_2();
			if (class2 == null)
			{
				return base.Undefined;
			}
			return method_2(class2, class2.GetType());
		}
		default:
			throw new Exception89("unknown function");
		}
	}

	public static Class7397 smethod_0(string value)
	{
		return class7552_0.method_3(value);
	}
}
