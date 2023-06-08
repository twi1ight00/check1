using ns73;
using ns84;

namespace ns87;

internal class Class4194 : Class4154
{
	private readonly Enum630 enum630_0;

	private readonly Class4195 class4195_0;

	private readonly bool bool_0;

	public Enum630 Value => enum630_0;

	public Class4195 Template => class4195_0;

	public bool IsTemplate => bool_0;

	internal Class4194(Class3679 cssValue)
		: base(cssValue)
	{
		if (base.IsIdentValue)
		{
			enum630_0 = Class4342.smethod_0<Enum630>().imethod_3(method_0());
			return;
		}
		bool_0 = true;
		class4195_0 = new Class4195(cssValue);
	}
}
