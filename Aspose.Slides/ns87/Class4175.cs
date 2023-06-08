using ns73;
using ns74;
using ns84;

namespace ns87;

internal class Class4175 : Class4154
{
	private Enum539 enum539_0;

	private string string_0;

	public Enum539 Type => enum539_0;

	public string Feature => string_0;

	internal Class4175(Class3679 cssValue)
		: base(cssValue)
	{
		if (cssValue is Class3694)
		{
			Class3694 @class = (Class3694)cssValue;
			enum539_0 = Class4342.smethod_0<Enum539>().imethod_3(@class.method_0());
			string_0 = @class.method_1()[0].CSSText;
		}
		else
		{
			enum539_0 = Class4342.smethod_0<Enum539>().imethod_3(cssValue.CSSText);
		}
	}
}
