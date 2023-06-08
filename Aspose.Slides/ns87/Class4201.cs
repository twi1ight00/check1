using ns73;

namespace ns87;

internal class Class4201 : Class4154
{
	private bool bool_0;

	private bool bool_1;

	private int? nullable_0;

	public bool None => bool_0;

	public bool All => bool_1;

	public int? Digit => nullable_0;

	internal Class4201(Class3679 cssValue)
		: base(cssValue)
	{
		if (!base.IsListValue)
		{
			if (Class3700.Class3702.class3689_85 == cssValue)
			{
				bool_1 = true;
			}
			else
			{
				bool_0 = true;
			}
		}
	}
}
