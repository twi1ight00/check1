using ns322;

namespace ns323;

internal abstract class Class7450 : Class7448
{
	internal override void vmethod_0()
	{
		Initialize();
	}

	protected void method_10(string name)
	{
		base.Global.method_0(name, new Class7405(base.Global, name, base.Global, vmethod_1), Enum988.flag_1 | Enum988.flag_2 | Enum988.flag_3);
	}

	protected void method_11(string name, Enum983 propertyAccessor)
	{
		Class7353 @class = new Class7353(base.Global, base.Global, name);
		if ((propertyAccessor & Enum983.flag_0) == Enum983.flag_0)
		{
			@class.GetFunction = new Class7405(base.Global, "get_" + name, base.Global, vmethod_1);
		}
		if ((propertyAccessor & Enum983.flag_1) == Enum983.flag_1)
		{
			@class.SetFunction = new Class7405(base.Global, "set_" + name, base.Global, vmethod_1);
		}
		base.Global.vmethod_18(@class);
	}

	protected virtual Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		return base.Undefined;
	}
}
