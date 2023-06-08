namespace ns322;

internal class Class7420 : Class7400
{
	private Interface401 interface401_0;

	public Class7397 method_4(Class7398 target, Class7397[] parameters)
	{
		return interface401_0.StringClass.method_5("[object " + target._Class + "]");
	}

	public static Class7397 smethod_0(Class7398 target, Class7397[] parameters)
	{
		return target;
	}

	public Class7397 method_5(Class7398 target, Class7397[] parameters)
	{
		return interface401_0.BooleanClass.method_4(target.vmethod_10(parameters[0]));
	}

	public Class7397 method_6(Class7398 target, Class7397[] parameters)
	{
		if (target._Class != "Object")
		{
			return interface401_0.BooleanClass.False;
		}
		if (!method_3(target))
		{
			return interface401_0.BooleanClass.False;
		}
		return interface401_0.BooleanClass.True;
	}

	public Class7397 method_7(Class7398 target, Class7397[] parameters)
	{
		if (!target.vmethod_10(parameters[0]))
		{
			return interface401_0.BooleanClass.False;
		}
		Class7397 @class = target[parameters[0]];
		return interface401_0.BooleanClass.method_4((@class.Attributes & Enum988.flag_2) == 0);
	}

	public Class7397 method_8(Class7397[] parameters)
	{
		if (parameters[0]._Class != "Object")
		{
			throw new Exception88(interface401_0.TypeErrorClass.method_5());
		}
		return ((((parameters[0] is Class7399 @class) ? @class : Class7437.class7437_0)[Class7400.string_24] is Class7399 class2) ? class2 : Class7437.class7437_0)[Class7400.string_25];
	}

	public Class7397 method_9(Class7397[] parameters)
	{
		Class7397 @class = parameters[0];
		if (!(@class is Class7398))
		{
			throw new Exception88(interface401_0.TypeErrorClass.method_5());
		}
		string name = parameters[1].ToString();
		Class7352 currentDescriptor = Class7352.smethod_0(interface401_0, (Class7398)@class, name, parameters[2]);
		((Class7398)@class).vmethod_18(currentDescriptor);
		return @class;
	}

	public override Class7397 vmethod_25(Interface396 visitor, Class7398 that, Class7397[] parameters)
	{
		Class7397 result;
		if (string_21 == "toString")
		{
			result = method_4(that, parameters);
		}
		else if (string_21 == "toLocaleString")
		{
			result = method_4(that, parameters);
		}
		else if (string_21 == "valueOf")
		{
			result = smethod_0(that, parameters);
		}
		else if (string_21 == "hasOwnProperty")
		{
			result = method_5(that, parameters);
		}
		else if (string_21 == "isPrototypeOf")
		{
			result = method_6(that, parameters);
		}
		else if (string_21 == "propertyIsEnumerable")
		{
			result = method_7(that, parameters);
		}
		else if (string_21 == "getPrototypeOf")
		{
			result = method_8(parameters);
		}
		else if (string_21 == "defineProperty")
		{
			result = method_9(parameters);
		}
		else if (string_21 == "__lookupGetter__")
		{
			result = vmethod_21(that, parameters);
		}
		else
		{
			if (!(string_21 == "__lookupSetter__"))
			{
				throw new Exception89("unknown object function");
			}
			result = vmethod_22(that, parameters);
		}
		visitor.imethod_36(result);
		return result;
	}

	public override string ToString()
	{
		return $"function {base.Name}";
	}

	public Class7420(Interface401 global, string name, Class7399 prototype)
		: base(prototype)
	{
		string_21 = name;
		interface401_0 = global;
	}
}
