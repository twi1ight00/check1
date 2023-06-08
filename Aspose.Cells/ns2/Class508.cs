using System.Drawing;
using Aspose.Cells;
using ns14;

namespace ns2;

internal class Class508 : Interface2
{
	private Palette palette_0;

	internal Class508(Palette palette_1)
	{
		palette_0 = palette_1;
	}

	public Color GetColor(int int_0)
	{
		if (int_0 > 0 && int_0 < 57)
		{
			return palette_0.GetColor(int_0 + 7);
		}
		return Color.Empty;
	}
}
