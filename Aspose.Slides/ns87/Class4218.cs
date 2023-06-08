using ns73;

namespace ns87;

internal class Class4218 : Class4154
{
	private string string_0;

	public string Uri => string_0;

	public bool None => string.IsNullOrEmpty(string_0);

	internal Class4218(Class3679 cssValue)
		: base(cssValue)
	{
		if (base.IsStringOrURIValue)
		{
			string_0 = method_0();
		}
	}
}
