using ns224;

namespace ns251;

internal class Class6320 : Class6292
{
	public override Class5998 imethod_0(Class5998 color)
	{
		return new Class5998(color.A, 255 - color.R, 255 - color.G, 255 - color.B);
	}

	public override Interface275 Clone()
	{
		return new Class6320();
	}
}
