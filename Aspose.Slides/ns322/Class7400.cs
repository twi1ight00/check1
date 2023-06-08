using System;
using System.Collections;

namespace ns322;

internal class Class7400 : Class7399
{
	protected string string_21;

	private Class7360 class7360_0;

	private IList ilist_0 = new ArrayList();

	private Class7438 class7438_0;

	public static string string_22 = "call";

	public static string string_23 = "apply";

	public static string string_24 = "constructor";

	public static string string_25 = "prototype";

	public string Name
	{
		get
		{
			return string_21;
		}
		set
		{
			string_21 = value;
		}
	}

	public Class7360 Statement
	{
		get
		{
			return class7360_0;
		}
		set
		{
			class7360_0 = value;
		}
	}

	public IList Arguments
	{
		get
		{
			return ilist_0;
		}
		set
		{
			ilist_0 = value;
		}
	}

	public Class7438 Scope
	{
		get
		{
			return class7438_0;
		}
		set
		{
			class7438_0 = value;
		}
	}

	public override int Length
	{
		get
		{
			return Arguments.Count;
		}
		set
		{
		}
	}

	public Class7399 PrototypeProperty
	{
		get
		{
			return this[string_25] as Class7399;
		}
		set
		{
			this[string_25] = value;
		}
	}

	public override object Value
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public override string _Class => "Function";

	public virtual bool vmethod_23(Class7399 inst)
	{
		if (inst != null && inst != Class7433.class7433_0 && inst != Class7433.class7433_0)
		{
			return PrototypeProperty.method_3(inst);
		}
		return false;
	}

	public virtual Class7399 vmethod_24(Class7397[] parameters, Type[] genericArgs, Interface396 visitor)
	{
		Class7399 @class = visitor.Global.ObjectClass.method_7(PrototypeProperty);
		visitor.imethod_37(this, @class, parameters);
		if (!(visitor.Result is Class7399))
		{
			return @class;
		}
		return visitor.Result as Class7399;
	}

	public virtual Class7397 vmethod_25(Interface396 visitor, Class7398 that, Class7397[] parameters)
	{
		Statement.vmethod_0((Interface395)visitor);
		return that;
	}

	public override bool vmethod_2()
	{
		return true;
	}

	public override double vmethod_3()
	{
		return 1.0;
	}

	public Class7400(Interface401 global)
		: this(global.FunctionClass.PrototypeProperty)
	{
	}

	public Class7400(Class7399 prototype)
		: base(prototype)
	{
		Statement = new Class7384();
		method_0(string_25, Class7433.class7433_0, Enum988.flag_2);
	}
}
