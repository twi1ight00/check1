using ns322;
using ns323;

namespace ns325;

internal class Class7451 : Class7450
{
	private Class7694 class7694_0;

	public Class7451(Class7694 obj)
	{
		class7694_0 = obj;
	}

	public override void Initialize()
	{
		method_11("Value", Enum983.flag_0 | Enum983.flag_1);
		method_10("Inc");
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		switch (function)
		{
		case "Inc":
			class7694_0.method_0();
			break;
		case "get_Value":
			return method_5(class7694_0.Value);
		case "set_Value":
			class7694_0.Value = parameters[0].vmethod_4();
			break;
		}
		return base.vmethod_1(function, instance, parameters);
	}
}
