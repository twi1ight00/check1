using System;

namespace ns322;

internal class Class7412 : Class7406
{
	public override void vmethod_26(Interface401 global)
	{
		Class7399 prototypeProperty = base.PrototypeProperty;
		prototypeProperty.method_0("constructor", this, Enum988.flag_2);
		prototypeProperty.method_0(Class7400.string_22.ToString(), new Class7424(this), Enum988.flag_2);
		prototypeProperty.method_0(Class7400.string_23.ToString(), new Class7423(this), Enum988.flag_2);
		prototypeProperty.method_0("toString", new Class7417(global, null, "toString", prototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("toLocaleString", new Class7417(global, null, "toLocaleString", prototypeProperty), Enum988.flag_2);
		prototypeProperty.vmethod_18(new Class7355(global, prototypeProperty, "length"));
	}

	public Class7400 method_4()
	{
		Class7400 @class = new Class7400(base.PrototypeProperty);
		@class.PrototypeProperty = base.Global.ObjectClass.method_4(@class);
		return @class;
	}

	public override Class7397 vmethod_25(Interface396 visitor, Class7398 that, Class7397[] parameters)
	{
		return visitor.imethod_36(vmethod_24(parameters, null, visitor));
	}

	public override Class7399 vmethod_24(Class7397[] parameters, Type[] genericArgs, Interface396 visitor)
	{
		Class7400 @class = method_4();
		for (int i = 0; i < parameters.Length - 1; i++)
		{
			string text = parameters[i].ToString();
			string[] array = text.Split(',');
			foreach (string text2 in array)
			{
				@class.Arguments.Add(text2.Trim());
			}
		}
		if (parameters.Length >= 1)
		{
			Class7380 class2 = Class7685.smethod_0(parameters[parameters.Length - 1].Value.ToString());
			@class.Statement = new Class7379(class2.Statements);
		}
		return @class;
	}

	public Class7412(Interface401 global, Class7399 prototype)
		: base(global, prototype)
	{
		base.Name = "Function";
		method_0(Class7400.string_25, prototype, Enum988.flag_1 | Enum988.flag_2 | Enum988.flag_3);
	}
}
