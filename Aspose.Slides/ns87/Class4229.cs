using ns73;
using ns84;

namespace ns87;

internal class Class4229 : Class4154
{
	private readonly Enum629 enum629_0;

	private string string_0;

	public string Url => string_0;

	public Enum629 Type => enum629_0;

	internal Class4229(Class3679 cssValue)
		: base(cssValue)
	{
		if (base.IsStringOrURIValue)
		{
			enum629_0 = Enum629.const_17;
			string_0 = method_0();
		}
		else
		{
			enum629_0 = Class4342.smethod_0<Enum629>().imethod_3(method_0());
		}
	}
}
