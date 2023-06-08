using ns73;
using ns84;

namespace ns87;

internal class Class4156 : Class4154
{
	private readonly Enum504 enum504_0;

	private readonly string string_0;

	public Enum504 TargetName => enum504_0;

	public string Name => string_0;

	internal Class4156(Class3679 cssValue)
		: base(cssValue)
	{
		if (base.IsStringValue)
		{
			string_0 = method_0();
			enum504_0 = Enum504.const_5;
		}
		else if (base.IsIdentValue)
		{
			enum504_0 = Class4342.smethod_0<Enum504>().imethod_3(method_0());
		}
	}
}
