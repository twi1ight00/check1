using ns322;

namespace ns323;

internal abstract class Class7452 : Class7448
{
	private Class7406 class7406_0;

	protected internal abstract string TypeName { get; }

	internal Class7399 Prototype => class7406_0.PrototypeProperty;

	internal override void vmethod_0()
	{
		class7406_0 = (Class7406)base.Global[TypeName];
		Initialize();
	}

	protected void method_10(string name)
	{
		Prototype.method_0(name, new Class7405(base.Global, name, Prototype, vmethod_1), Enum988.flag_2);
	}

	protected virtual Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		return base.Undefined;
	}
}
