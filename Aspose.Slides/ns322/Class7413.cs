namespace ns322;

internal class Class7413 : Class7406
{
	public override void vmethod_26(Interface401 global)
	{
		Class7399 prototypeProperty = base.PrototypeProperty;
		prototypeProperty.method_0("toString", new Class7419(global, "toString", prototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("toLocaleString", new Class7419(global, "toLocaleString", prototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("toFixed", new Class7419(global, "toFixed", prototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("toExponential", new Class7419(global, "toExponential", prototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("toPrecision", new Class7419(global, "toPrecision", prototypeProperty), Enum988.flag_2);
	}

	public Class7434 method_4(double value)
	{
		return new Class7434(value, base.PrototypeProperty);
	}

	public override Class7397 vmethod_25(Interface396 visitor, Class7398 that, Class7397[] parameters)
	{
		if (that != null && that as Interface401 != visitor.Global)
		{
			if (parameters.Length > 0)
			{
				that.Value = parameters[0].vmethod_3();
			}
			else
			{
				that.Value = 0;
			}
			return visitor.imethod_36(that);
		}
		if (parameters.Length > 0)
		{
			return visitor.imethod_36(method_4(parameters[0].vmethod_3()));
		}
		return visitor.imethod_36(method_4(0.0));
	}

	public Class7413(Interface401 global)
		: base(global)
	{
		base.Name = "Number";
		method_0(Class7400.string_25, global.ObjectClass.method_4(this), Enum988.flag_1 | Enum988.flag_2 | Enum988.flag_3);
		method_1("MAX_VALUE", method_4(double.MaxValue));
		method_1("MIN_VALUE", method_4(double.MinValue));
		method_1("NaN", method_4(double.NaN));
		method_1("POSITIVE_INFINITY", method_4(double.PositiveInfinity));
		method_1("NEGATIVE_INFINITY", method_4(double.NegativeInfinity));
	}
}
