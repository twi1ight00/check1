using ns73;

namespace ns87;

internal class Class4196 : Class4154
{
	private bool bool_0;

	private string string_0;

	private bool bool_1;

	public bool None => bool_0;

	public string Value => string_0;

	public bool Normal => bool_1;

	internal Class4196(Class3679 cssValue)
		: base(cssValue)
	{
		if (Class3700.Class3702.class3689_4 == cssValue)
		{
			bool_0 = true;
		}
		else if (Class3700.Class3702.class3689_5 == cssValue)
		{
			bool_1 = true;
		}
		else
		{
			string_0 = method_0();
		}
	}
}
