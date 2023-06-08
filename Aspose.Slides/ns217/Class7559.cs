using System;
using ns322;
using ns323;

namespace ns217;

internal class Class7559 : Class7456
{
	private static readonly Type type_0 = typeof(Class5908);

	protected internal override Type Type => type_0;

	public override void Initialize()
	{
		method_10("append");
		method_10("insert");
		method_10("item");
		method_10("namedItem");
		method_10("remove");
		method_11("length", Enum983.flag_0);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class5908 @class = (Class5908)instance.Value;
		switch (function)
		{
		case "append":
			@class.method_0((Class5781)parameters[0].vmethod_5());
			goto IL_0145;
		case "insert":
			@class.Insert((Class5781)parameters[0].vmethod_5(), (Class5781)parameters[1].vmethod_5());
			goto IL_0145;
		case "item":
		{
			Class5781 class3 = @class.method_1(parameters[0].vmethod_4());
			if (class3 == null)
			{
				return base.Undefined;
			}
			return method_2(class3, class3.GetType());
		}
		case "namedItem":
		{
			Class5781 class2 = @class.method_2(parameters[0].ToString());
			if (class2 == null)
			{
				return base.Undefined;
			}
			return method_2(class2, class2.GetType());
		}
		case "remove":
			@class.Remove((Class5781)parameters[0].vmethod_5());
			goto IL_0145;
		default:
			throw new Exception89("unknown function");
		case "get_length":
			{
				return method_5(@class.Length);
			}
			IL_0145:
			return base.Undefined;
		}
	}
}
