using System.Drawing;
using ns224;

namespace ns234;

internal static class Class6153
{
	public static Color smethod_0(Class5998 drColor)
	{
		if (!drColor.IsEmpty)
		{
			return Color.FromArgb(drColor.method_1());
		}
		return Color.Empty;
	}

	public static Class5998 smethod_1(Color nativeColor)
	{
		return new Class5998(nativeColor.ToArgb());
	}
}
