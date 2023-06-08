using ns73;
using ns84;

namespace ns87;

internal class Class4203 : Class4154
{
	private Enum582 enum582_0;

	private string string_0;

	public string StyleString => string_0;

	public Enum582 Style => enum582_0;

	public bool IsStyleStringDefined => string_0 != null;

	internal Class4203(Class3679 cssValue)
		: base(cssValue)
	{
		if (base.IsIdentValue)
		{
			enum582_0 = Class4342.smethod_0<Enum582>().imethod_3(method_0());
		}
		else
		{
			string_0 = method_0();
		}
	}
}
