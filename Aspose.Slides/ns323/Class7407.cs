using ns322;

namespace ns323;

internal class Class7407 : Class7406
{
	private Delegate2787 delegate2787_0;

	public Class7407(Interface401 global, string typeName, Delegate2787 execute)
		: base(global)
	{
		base.Name = typeName;
		delegate2787_0 = execute;
		method_0(Class7400.string_25, global.ObjectClass.method_4(this), Enum988.flag_1 | Enum988.flag_2 | Enum988.flag_3);
	}

	public override void vmethod_26(Interface401 global)
	{
	}

	public void method_4(string name)
	{
		base.PrototypeProperty.method_0(name, new Class7405(base.Global, name, base.PrototypeProperty, delegate2787_0), Enum988.flag_1 | Enum988.flag_2 | Enum988.flag_3);
	}

	public void method_5(string name, Enum983 propertyAccessor)
	{
		Class7353 @class = new Class7353(base.Global, this, name);
		if ((propertyAccessor & Enum983.flag_0) == Enum983.flag_0)
		{
			@class.GetFunction = new Class7405(base.Global, "get_" + name, base.PrototypeProperty, delegate2787_0);
		}
		if ((propertyAccessor & Enum983.flag_1) == Enum983.flag_1)
		{
			@class.SetFunction = new Class7405(base.Global, "set_" + name, base.PrototypeProperty, delegate2787_0);
		}
		base.PrototypeProperty.vmethod_18(@class);
	}

	public Class7397 method_6(object value)
	{
		return new Class7399(value, base.PrototypeProperty);
	}

	public Class7397 method_7()
	{
		return new Class7399(base.PrototypeProperty);
	}
}
