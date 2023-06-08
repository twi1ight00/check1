using System.Drawing;

namespace ns18;

internal class Class1046
{
	internal int int_0;

	internal int int_1;

	internal Color color_0;

	internal Class1046(Class1420 class1420_0)
	{
		int_0 = class1420_0.ReadInt32();
		int_1 = class1420_0.ReadInt32();
		int red = (byte)(class1420_0.ReadUInt16() >> 8);
		int green = (byte)(class1420_0.ReadUInt16() >> 8);
		int blue = (byte)(class1420_0.ReadUInt16() >> 8);
		int alpha = (byte)(class1420_0.ReadUInt16() >> 8);
		color_0 = Color.FromArgb(alpha, red, green, blue);
	}
}
