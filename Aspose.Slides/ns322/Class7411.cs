using System;

namespace ns322;

internal class Class7411 : Class7406
{
	private string string_26;

	public override void vmethod_26(Interface401 global)
	{
		Class7399 prototypeProperty = base.PrototypeProperty;
		prototypeProperty.method_0("name", global.StringClass.method_5(string_26), Enum988.flag_1 | Enum988.flag_2 | Enum988.flag_3);
		prototypeProperty.method_0("toString", new Class7404(global, "toString", prototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("toLocaleString", new Class7404(global, "toString", prototypeProperty), Enum988.flag_2);
	}

	public Class7430 method_4(string message)
	{
		Class7430 @class = new Class7430(base.Global);
		@class["message"] = base.Global.StringClass.method_5(message);
		return @class;
	}

	public Class7430 method_5()
	{
		return method_4(string.Empty);
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
			visitor.imethod_36(that);
		}
		else
		{
			visitor.imethod_36((parameters.Length > 0) ? method_4(parameters[0].ToString()) : method_5());
		}
		return that;
	}

	public override Class7399 vmethod_24(Class7397[] parameters, Type[] genericArgs, Interface396 visitor)
	{
		if (parameters != null && parameters.Length > 0)
		{
			return visitor.Global.ErrorClass.method_4(parameters[0].ToString());
		}
		return visitor.Global.ErrorClass.method_5();
	}

	public Class7411(Interface401 global, string errorType)
		: base(global)
	{
		string_26 = errorType;
		base.Name = errorType;
		method_0(Class7400.string_25, global.ObjectClass.method_4(this), Enum988.flag_1 | Enum988.flag_2 | Enum988.flag_3);
	}
}
