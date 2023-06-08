using System;

namespace ns322;

internal class Class7432 : Class7399
{
	public const string string_21 = "object";

	private Interface401 interface401_0;

	public Interface401 Global => interface401_0;

	public override string _Class => "object";

	public Class7432(Interface401 global)
		: base(global.ObjectClass.PrototypeProperty)
	{
		interface401_0 = global;
		this["abs"] = new Class7418(global, "abs", global.ObjectClass.PrototypeProperty);
		this["acos"] = new Class7418(global, "acos", global.ObjectClass.PrototypeProperty);
		this["asin"] = new Class7418(global, "asin", global.ObjectClass.PrototypeProperty);
		this["atan"] = new Class7418(global, "atan", global.ObjectClass.PrototypeProperty);
		this["atan2"] = new Class7418(global, "atan2", global.ObjectClass.PrototypeProperty);
		this["ceil"] = new Class7418(global, "ceil", global.ObjectClass.PrototypeProperty);
		this["cos"] = new Class7418(global, "cos", global.ObjectClass.PrototypeProperty);
		this["exp"] = new Class7418(global, "exp", global.ObjectClass.PrototypeProperty);
		this["floor"] = new Class7418(global, "floor", global.ObjectClass.PrototypeProperty);
		this["log"] = new Class7418(global, "log", global.ObjectClass.PrototypeProperty);
		this["max"] = new Class7418(global, "max", global.ObjectClass.PrototypeProperty);
		this["min"] = new Class7418(global, "min", global.ObjectClass.PrototypeProperty);
		this["pow"] = new Class7418(global, "pow", global.ObjectClass.PrototypeProperty);
		this["random"] = new Class7418(global, "random", global.ObjectClass.PrototypeProperty);
		this["round"] = new Class7418(global, "round", global.ObjectClass.PrototypeProperty);
		this["sin"] = new Class7418(global, "sin", global.ObjectClass.PrototypeProperty);
		this["sqrt"] = new Class7418(global, "sqrt", global.ObjectClass.PrototypeProperty);
		this["tan"] = new Class7418(global, "tan", global.ObjectClass.PrototypeProperty);
		this["E"] = global.NumberClass.method_4(Math.E);
		this["LN2"] = global.NumberClass.method_4(Math.Log(2.0));
		this["LN10"] = global.NumberClass.method_4(Math.Log(10.0));
		this["LOG2E"] = global.NumberClass.method_4(Math.Log(Math.E, 2.0));
		this["PI"] = global.NumberClass.method_4(Math.PI);
		this["SQRT1_2"] = global.NumberClass.method_4(Math.Sqrt(0.5));
		this["SQRT2"] = global.NumberClass.method_4(Math.Sqrt(2.0));
	}
}
