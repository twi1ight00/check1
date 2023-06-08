using System.Drawing;
using ns284;

namespace ns296;

internal class Class6809 : Class6806
{
	private Color color_0;

	public Class6809(Class6983 element, Color color)
		: base(element)
	{
		color_0 = color;
	}

	public override string vmethod_0()
	{
		if (color_0.A == 0)
		{
			return Color.Transparent.Name;
		}
		return $"#{color_0.ToArgb() & 0xFFFFFF:x6}";
	}
}
