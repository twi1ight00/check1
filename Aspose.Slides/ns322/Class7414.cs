namespace ns322;

internal class Class7414 : Class7406
{
	public override void vmethod_26(Interface401 global)
	{
		Class7399 prototypeProperty = base.PrototypeProperty;
		Class7399 prototypeProperty2 = global.FunctionClass.PrototypeProperty;
		prototypeProperty.method_0("constructor", this, Enum988.flag_2);
		prototypeProperty.method_0("toString", new Class7420(global, "toString", prototypeProperty2), Enum988.flag_2);
		prototypeProperty.method_0("toLocaleString", new Class7420(global, "toString", prototypeProperty2), Enum988.flag_2);
		prototypeProperty.method_0("valueOf", new Class7420(global, "valueOf", prototypeProperty2), Enum988.flag_2);
		prototypeProperty.method_0("hasOwnProperty", new Class7420(global, "hasOwnProperty", prototypeProperty2), Enum988.flag_2);
		prototypeProperty.method_0("isPrototypeOf", new Class7420(global, "isPrototypeOf", prototypeProperty2), Enum988.flag_2);
		prototypeProperty.method_0("propertyIsEnumerable", new Class7420(global, "propertyIsEnumerable", prototypeProperty2), Enum988.flag_2);
		prototypeProperty.method_0("getPrototypeOf", new Class7420(global, "getPrototypeOf", prototypeProperty2), Enum988.flag_2);
		if (global.imethod_0(Enum987.flag_2))
		{
			prototypeProperty.method_0("defineProperty", new Class7420(global, "defineProperty", prototypeProperty2), Enum988.flag_2);
			prototypeProperty.method_0("__lookupGetter__", new Class7420(global, "__lookupGetter__", prototypeProperty2), Enum988.flag_2);
			prototypeProperty.method_0("__lookupSetter__", new Class7420(global, "__lookupSetter__", prototypeProperty2), Enum988.flag_2);
		}
	}

	public Class7399 method_4(Class7400 constructor)
	{
		Class7399 @class = new Class7399(base.PrototypeProperty);
		Class7359 class2 = new Class7359(@class, Class7400.string_24, constructor);
		class2.Enumerable = false;
		@class.vmethod_18(class2);
		return @class;
	}

	public Class7399 method_5(object value)
	{
		return new Class7399(value, base.PrototypeProperty);
	}

	public Class7399 method_6()
	{
		return method_5(null);
	}

	public Class7399 method_7(Class7399 prototype)
	{
		return new Class7399(prototype);
	}

	public override Class7397 vmethod_25(Interface396 visitor, Class7398 that, Class7397[] parameters)
	{
		if (parameters.Length > 0)
		{
			return parameters[0]._Class switch
			{
				"Boolean" => base.Global.BooleanClass.method_4(parameters[0].vmethod_2()), 
				"Number" => base.Global.NumberClass.method_4(parameters[0].vmethod_3()), 
				"String" => base.Global.StringClass.method_5(parameters[0].ToString()), 
				_ => parameters[0], 
			};
		}
		return method_4(this);
	}

	public Class7414(Interface401 global, Class7399 prototype, Class7399 rootPrototype)
		: base(global)
	{
		base.Name = "Object";
		method_0(Class7400.string_25, rootPrototype, Enum988.flag_1 | Enum988.flag_2 | Enum988.flag_3);
	}
}
