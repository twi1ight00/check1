using ns322;

namespace ns323;

internal class Class7454 : Class7448
{
	private string string_0;

	public override string Name => string_0;

	public Class7454(string functionName)
	{
		string_0 = functionName;
	}

	public override void Initialize()
	{
		base.Global[Name] = new Class7405(base.Global, Name, base.Global.FunctionClass.PrototypeProperty, vmethod_1);
	}

	protected virtual Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		return base.Undefined;
	}
}
