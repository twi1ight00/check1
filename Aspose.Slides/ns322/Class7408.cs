using System;

namespace ns322;

internal class Class7408 : Class7406
{
	public override void vmethod_26(Interface401 global)
	{
		Class7399 prototypeProperty = base.PrototypeProperty;
		Class7356 @class = new Class7356(global, prototypeProperty, "length");
		@class.Enumerable = false;
		prototypeProperty.vmethod_18(@class);
		prototypeProperty.method_0("toString", new Class7401(global, "toString", prototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("toLocaleString", new Class7401(global, "toLocaleString", prototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("concat", new Class7401(global, "concat", prototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("join", new Class7401(global, "join", prototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("pop", new Class7401(global, "pop", prototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("push", new Class7401(global, "push", prototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("reverse", new Class7401(global, "reverse", prototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("shift", new Class7401(global, "shift", prototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("slice", new Class7401(global, "slice", prototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("sort", new Class7401(global, "sort", prototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("splice", new Class7401(global, "splice", prototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("unshift", new Class7401(global, "unshift", prototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("indexOf", new Class7401(global, "indexOf", prototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("lastIndexOf", new Class7401(global, "lastIndexOf", prototypeProperty), Enum988.flag_2);
	}

	public Class7427 method_4()
	{
		return new Class7427(base.PrototypeProperty);
	}

	public Class7427 method_5(Class7397[] data)
	{
		return new Class7427(base.PrototypeProperty).method_10(base.Global, data);
	}

	public override Class7399 vmethod_24(Class7397[] parameters, Type[] genericArgs, Interface396 visitor)
	{
		Class7427 @class = method_4();
		for (int i = 0; i < parameters.Length; i++)
		{
			@class.method_7(i, parameters[i]);
		}
		return @class;
	}

	public override Class7397 vmethod_25(Interface396 visitor, Class7398 that, Class7397[] parameters)
	{
		if (that != null && that as Interface401 != visitor.Global)
		{
			for (int i = 0; i < parameters.Length; i++)
			{
				that[i.ToString()] = parameters[i];
			}
			return visitor.imethod_36(that);
		}
		return visitor.imethod_36(vmethod_24(parameters, null, visitor));
	}

	public Class7408(Interface401 global)
		: base(global)
	{
		base.Name = "Array";
		method_0(Class7400.string_25, global.ObjectClass.method_4(this), Enum988.flag_1 | Enum988.flag_2 | Enum988.flag_3);
	}
}
