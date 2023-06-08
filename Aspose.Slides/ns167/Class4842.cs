using System.Drawing;
using ns224;
using ns234;
using ns235;

namespace ns167;

internal class Class4842
{
	internal static readonly Color color_0 = Color.LightGreen;

	internal static readonly Color color_1 = Color.DarkSeaGreen;

	internal static readonly Color color_2 = Color.LightSeaGreen;

	internal static readonly Color color_3 = Color.Blue;

	internal static readonly Color color_4 = Color.Red;

	internal static readonly Color color_5 = Color.Green;

	internal static void smethod_0(Class6216 targetPage, RectangleF rect, Color color)
	{
		Class6217 @class = Class6217.smethod_1(rect);
		@class.Pen = new Class6003(Class6153.smethod_1(color));
		targetPage.Add(@class);
	}
}
