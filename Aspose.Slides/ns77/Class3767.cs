using ns73;
using ns84;

namespace ns77;

internal class Class3767 : Class3737
{
	private Enum599? nullable_0;

	private string string_0;

	public override string Text => string_0;

	public Class3767(string name)
	{
		string_0 = name;
		if (Class4342.smethod_0<Enum599>().TryGetValue(name, out var value))
		{
			nullable_0 = value;
		}
	}

	public override bool imethod_0(Class3677 device)
	{
		if (!nullable_0.HasValue)
		{
			return false;
		}
		if (Enum599.const_1 == nullable_0)
		{
			return true;
		}
		return device.MediaType == nullable_0;
	}
}
