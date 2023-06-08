using ns73;

namespace ns87;

internal class Class4184 : Class4154
{
	private bool bool_0;

	private bool bool_1;

	private string string_0;

	public bool IsNormal => bool_0;

	public bool IsHere => bool_1;

	public string Identifier => string_0;

	internal Class4184(Class3679 cssValue)
		: base(cssValue)
	{
		if (Class3700.Class3702.class3689_5 == cssValue)
		{
			bool_0 = true;
		}
		else if (Class3700.Class3702.class3689_78 == cssValue)
		{
			bool_1 = true;
		}
		else
		{
			string_0 = method_0();
		}
	}
}
