using System;

namespace ns322;

internal class Class7410 : Class7406
{
	private Class7403 class7403_0;

	protected Class7410(Interface401 global, bool initializeUTC)
		: base(global)
	{
		string_21 = "Date";
		method_0(Class7400.string_25, global.ObjectClass.method_4(this), Enum988.flag_1 | Enum988.flag_2 | Enum988.flag_3);
		method_0("parse", new Class7403(global, "parse", global.FunctionClass.PrototypeProperty), Enum988.flag_2);
		method_0("parseLocale", new Class7403(global, "parseLocale", global.FunctionClass.PrototypeProperty), Enum988.flag_2);
		method_0("UTC", new Class7403(global, "UTC", global.FunctionClass.PrototypeProperty), Enum988.flag_2);
	}

	public override void vmethod_26(Interface401 global)
	{
		Class7399 prototypeProperty = base.PrototypeProperty;
		prototypeProperty.method_0("UTC", new Class7403(global, "UTC", global.FunctionClass.PrototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("parse", new Class7403(global, "parse", global.FunctionClass.PrototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("parseLocale", new Class7403(global, "parseLocale", global.FunctionClass.PrototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("toString", new Class7403(global, "toString", base.PrototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("toDateString", new Class7403(global, "toDateString", base.PrototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("toTimeString", new Class7403(global, "toTimeString", base.PrototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("toLocaleString", new Class7403(global, "toLocaleString", base.PrototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("toLocaleDateString", new Class7403(global, "toLocaleDateString", base.PrototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("toLocaleTimeString", new Class7403(global, "toLocaleTimeString", base.PrototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("valueOf", new Class7403(global, "valueOf", base.PrototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("getTime", new Class7403(global, "getTime", base.PrototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("getFullYear", new Class7403(global, "getFullYear", base.PrototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("getUTCFullYear", new Class7403(global, "getUTCFullYear", base.PrototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("getMonth", new Class7403(global, "getMonth", base.PrototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("getUTCMonth", new Class7403(global, "getUTCMonth", base.PrototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("getDate", new Class7403(global, "getDate", base.PrototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("getUTCDate", new Class7403(global, "getUTCDate", base.PrototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("getDay", new Class7403(global, "getDay", base.PrototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("getUTCDay", new Class7403(global, "getUTCDay", base.PrototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("getHours", new Class7403(global, "getHours", base.PrototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("getUTCHours", new Class7403(global, "getUTCHours", base.PrototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("getMinutes", new Class7403(global, "getMinutes", base.PrototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("getUTCMinutes", new Class7403(global, "getUTCMinutes", base.PrototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("getSeconds", new Class7403(global, "getSeconds", base.PrototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("getUTCSeconds", new Class7403(global, "getUTCSeconds", base.PrototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("getMilliseconds", new Class7403(global, "getMilliseconds", base.PrototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("getUTCMilliseconds", new Class7403(global, "getUTCMilliseconds", base.PrototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("getTimezoneOffset", new Class7403(global, "getTimezoneOffset", base.PrototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("setTime", new Class7403(global, "setTime", base.PrototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("setMilliseconds", new Class7403(global, "setMilliseconds", base.PrototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("setUTCMilliseconds", new Class7403(global, "setUTCMilliseconds", base.PrototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("setSeconds", new Class7403(global, "setSeconds", base.PrototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("setUTCSeconds", new Class7403(global, "setUTCSeconds", base.PrototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("setMinutes", new Class7403(global, "setMinutes", base.PrototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("setUTCMinutes", new Class7403(global, "setUTCMinutes", base.PrototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("setHours", new Class7403(global, "setHours", base.PrototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("setUTCHours", new Class7403(global, "setUTCHours", base.PrototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("setDate", new Class7403(global, "setDate", base.PrototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("setUTCDate", new Class7403(global, "setUTCDate", base.PrototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("setMonth", new Class7403(global, "setMonth", base.PrototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("setUTCMonth", new Class7403(global, "setUTCMonth", base.PrototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("setFullYear", new Class7403(global, "setFullYear", base.PrototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("setUTCFullYear", new Class7403(global, "setUTCFullYear", base.PrototypeProperty), Enum988.flag_2);
		prototypeProperty.method_0("toUTCString", new Class7403(global, "toUTCString", base.PrototypeProperty), Enum988.flag_2);
	}

	public Class7429 method_4(double value)
	{
		return new Class7429(value, base.PrototypeProperty);
	}

	public Class7429 method_5(DateTime value)
	{
		return new Class7429(value.ToUniversalTime(), base.PrototypeProperty);
	}

	public override Class7397 vmethod_25(Interface396 visitor, Class7398 that, Class7397[] parameters)
	{
		Class7429 @class = class7403_0.method_7(parameters);
		if (that != null && that as Interface401 != visitor.Global)
		{
			return @class;
		}
		return visitor.imethod_36(class7403_0.method_9(@class, Class7397.class7397_0));
	}

	public Class7410(Interface401 global)
		: this(global, initializeUTC: true)
	{
		class7403_0 = new Class7403(global, null, base.PrototypeProperty);
	}
}
