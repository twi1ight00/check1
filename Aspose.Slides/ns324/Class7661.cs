using System;
using ns305;
using ns322;
using ns323;

namespace ns324;

internal class Class7661 : Class7456
{
	private static readonly Type type_0 = typeof(Class7062);

	protected internal override Type Type => type_0;

	public override void Initialize()
	{
		method_10("getNamedItem");
		method_10("setNamedItem");
		method_10("removeNamedItem");
		method_10("item");
		method_10("getNamedItemNS");
		method_10("setNamedItemNS");
		method_10("removeNamedItemNS");
		method_11("length", Enum983.flag_0);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class7062 @class = (Class7062)instance.Value;
		switch (function)
		{
		case "getNamedItem":
		{
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			Class6976 class7 = @class.method_4(parameters[0].ToString());
			if (class7 == null)
			{
				return base.Undefined;
			}
			return method_2(class7, class7.GetType());
		}
		case "setNamedItem":
		{
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			Class6976 class3 = @class.method_5((Class6976)parameters[0].vmethod_5());
			if (class3 == null)
			{
				return base.Undefined;
			}
			return method_2(class3, class3.GetType());
		}
		case "removeNamedItem":
		{
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			Class6976 class8 = @class.method_6(parameters[0].ToString());
			if (class8 == null)
			{
				return base.Undefined;
			}
			return method_2(class8, class8.GetType());
		}
		case "item":
		{
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			Class6976 class5 = @class.method_7(parameters[0].vmethod_4());
			if (class5 == null)
			{
				return base.Undefined;
			}
			return method_2(class5, class5.GetType());
		}
		case "get_length":
			return method_5(@class.Length);
		case "getNamedItemNS":
		{
			if (parameters.Length != 2)
			{
				throw new Exception89("invalid arguments count.");
			}
			Class6976 class4 = @class.method_8(parameters[0].ToString(), parameters[1].ToString());
			if (class4 == null)
			{
				return base.Undefined;
			}
			return method_2(class4, class4.GetType());
		}
		case "setNamedItemNS":
		{
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			Class6976 class6 = @class.method_9((Class6976)parameters[0].vmethod_5());
			if (class6 == null)
			{
				return base.Undefined;
			}
			return method_2(class6, class6.GetType());
		}
		case "removeNamedItemNS":
		{
			if (parameters.Length != 2)
			{
				throw new Exception89("invalid arguments count.");
			}
			Class6976 class2 = @class.method_10(parameters[0].ToString(), parameters[1].ToString());
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
}
