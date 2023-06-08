using System.Drawing;
using System.Runtime.InteropServices;

namespace ns38;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct32
{
	public static readonly float float_0 = 0.3f;

	public static readonly float float_1 = 0.5f;

	public static Color smethod_0(Color color, float correctionFactor)
	{
		if (correctionFactor == 0f)
		{
			return color;
		}
		float num = (int)color.R;
		float num2 = (int)color.G;
		float num3 = (int)color.B;
		if (correctionFactor < 0f)
		{
			correctionFactor = 1f + correctionFactor;
			num *= correctionFactor;
			num2 *= correctionFactor;
			num3 *= correctionFactor;
		}
		else
		{
			num = (255f - num) * correctionFactor + num;
			num2 = (255f - num2) * correctionFactor + num2;
			num3 = (255f - num3) * correctionFactor + num3;
		}
		return Color.FromArgb(color.A, (int)num, (int)num2, (int)num3);
	}
}
