namespace ns322;

internal class Class7415 : Class7406
{
	private Class7421 class7421_0;

	public override void vmethod_26(Interface401 global)
	{
		Class7399 prototypeProperty = base.PrototypeProperty;
		prototypeProperty.method_0("toString", new Class7421(global, "toString", prototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("toLocaleString", new Class7421(global, "toLocaleString", prototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("lastIndex", new Class7421(global, "lastIndex", prototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("exec", new Class7421(global, "exec", prototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("test", new Class7421(global, "test", prototypeProperty), Enum988.flag_2);
	}

	public Class7435 method_4()
	{
		return method_5(string.Empty, g: false, i: false, m: false);
	}

	public Class7435 method_5(string pattern, bool g, bool i, bool m)
	{
		Class7435 @class = new Class7435(pattern, g, i, m, base.PrototypeProperty);
		@class["source"] = base.Global.StringClass.method_5(pattern);
		@class["lastIndex"] = base.Global.NumberClass.method_4(0.0);
		@class["global"] = base.Global.BooleanClass.method_4(g);
		return @class;
	}

	public Class7397 method_6(Class7435 regexp, Class7397[] parameters)
	{
		return class7421_0.method_5(regexp, parameters);
	}

	public override Class7397 vmethod_25(Interface396 visitor, Class7398 that, Class7397[] parameters)
	{
		if (parameters.Length == 0)
		{
			return visitor.imethod_36(method_4());
		}
		return visitor.imethod_36(method_5(parameters[0].ToString(), g: false, i: false, m: false));
	}

	public Class7415(Interface401 global)
		: base(global)
	{
		string_21 = "RegExp";
		class7421_0 = new Class7421(global, null, base.PrototypeProperty);
		method_0(Class7400.string_25, global.ObjectClass.method_4(this), Enum988.flag_1 | Enum988.flag_2 | Enum988.flag_3);
	}
}
