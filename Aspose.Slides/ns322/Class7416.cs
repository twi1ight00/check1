namespace ns322;

internal class Class7416 : Class7406
{
	public override void vmethod_26(Interface401 global)
	{
		Class7399 prototypeProperty = base.PrototypeProperty;
		prototypeProperty.method_0("split", new Class7422(global, "split", prototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("replace", new Class7422(global, "replace", prototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("toString", new Class7422(global, "toString", prototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("toLocaleString", new Class7422(global, "toLocaleString", prototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("match", new Class7422(global, "match", prototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("localeCompare", new Class7422(global, "localeCompare", prototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("substring", new Class7422(global, "substring", prototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("substr", new Class7422(global, "substr", prototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("search", new Class7422(global, "search", prototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("valueOf", new Class7422(global, "valueOf", prototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("concat", new Class7422(global, "concat", prototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("charAt", new Class7422(global, "charAt", prototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("charCodeAt", new Class7422(global, "charCodeAt", prototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("lastIndexOf", new Class7422(global, "lastIndexOf", prototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("indexOf", new Class7422(global, "indexOf", prototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("toLowerCase", new Class7422(global, "toLowerCase", prototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("toLocaleLowerCase", new Class7422(global, "toLocaleLowerCase", prototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("toUpperCase", new Class7422(global, "toUpperCase", prototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("toLocaleUpperCase", new Class7422(global, "toLocaleUpperCase", prototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("slice", new Class7422(global, "slice", prototypeProperty), Enum988.flag_2);
		prototypeProperty.vmethod_18(new Class7357(global, prototypeProperty, "length"));
	}

	public Class7436 method_4()
	{
		return method_5(string.Empty);
	}

	public Class7436 method_5(string value)
	{
		return new Class7436(value, base.PrototypeProperty);
	}

	public override Class7397 vmethod_25(Interface396 visitor, Class7398 that, Class7397[] parameters)
	{
		if (that != null && that as Interface401 != visitor.Global)
		{
			if (parameters.Length > 0)
			{
				that.Value = parameters[0].ToString();
			}
			else
			{
				that.Value = string.Empty;
			}
			return visitor.imethod_36(that);
		}
		if (parameters.Length > 0)
		{
			return visitor.imethod_36(base.Global.StringClass.method_5(parameters[0].ToString()));
		}
		return visitor.imethod_36(base.Global.StringClass.method_5(string.Empty));
	}

	public Class7416(Interface401 global)
		: base(global)
	{
		method_0(Class7400.string_25, global.ObjectClass.method_4(this), Enum988.flag_1 | Enum988.flag_2 | Enum988.flag_3);
		base.Name = "String";
		this["fromCharCode"] = new Class7422(global, "fromCharCode", base.PrototypeProperty);
	}
}
