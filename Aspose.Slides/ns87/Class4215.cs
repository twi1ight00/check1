using System.Drawing;
using ns73;

namespace ns87;

internal class Class4215 : Class4154
{
	private readonly Class4343 class4343_0;

	private readonly bool bool_0;

	public bool Invert => bool_0;

	public Color Color => class4343_0.method_0();

	internal Class4343 CssColor => class4343_0;

	internal Class4215(Class3679 value)
		: base(value)
	{
		if (base.IsIdentValue)
		{
			bool_0 = true;
		}
		else
		{
			class4343_0 = method_2();
		}
	}
}
