namespace ns322;

internal class Class7409 : Class7406
{
	private Class7428 class7428_0;

	private Class7428 class7428_1;

	public Class7428 False
	{
		get
		{
			return class7428_0;
		}
		set
		{
			class7428_0 = value;
		}
	}

	public Class7428 True
	{
		get
		{
			return class7428_1;
		}
		set
		{
			class7428_1 = value;
		}
	}

	public override void vmethod_26(Interface401 global)
	{
		Class7399 prototypeProperty = base.PrototypeProperty;
		prototypeProperty.method_0("toString", new Class7402(global, "toString", prototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("toLocaleString", new Class7402(global, "toLocaleString", prototypeProperty), Enum988.flag_2);
	}

	public Class7428 method_4(bool value)
	{
		return new Class7428(value, base.PrototypeProperty);
	}

	public override Class7397 vmethod_25(Interface396 visitor, Class7398 that, Class7397[] parameters)
	{
		if (that != null && that as Interface401 != visitor.Global)
		{
			if (parameters.Length > 0)
			{
				that.Value = parameters[0].vmethod_2();
			}
			else
			{
				that.Value = false;
			}
			visitor.imethod_36(that);
		}
		else
		{
			visitor.imethod_36((parameters.Length > 0) ? new Class7428(parameters[0].vmethod_2(), base.PrototypeProperty) : new Class7428(value: false, base.PrototypeProperty));
		}
		return that;
	}

	public Class7409(Interface401 global)
		: base(global)
	{
		string_21 = "Boolean";
		method_0(Class7400.string_25, global.ObjectClass.method_4(this), Enum988.flag_1 | Enum988.flag_2 | Enum988.flag_3);
		True = method_4(value: true);
		False = method_4(value: false);
	}
}
