using System.Drawing;
using System.Drawing.Drawing2D;

namespace ns40;

internal class Class790
{
	internal static RectangleF smethod_0(GraphicsPath path)
	{
		return path.GetBounds();
	}

	internal static Size smethod_1(Size src)
	{
		return new Size(src.Width, src.Height);
	}

	internal static SizeF smethod_2(SizeF src)
	{
		return new SizeF(src.Width, src.Height);
	}

	internal static RectangleF smethod_3(RectangleF src)
	{
		return new RectangleF(src.X, src.Y, src.Width, src.Height);
	}

	internal static Rectangle smethod_4(Rectangle src)
	{
		return new Rectangle(src.X, src.Y, src.Width, src.Height);
	}

	internal static RectangleF smethod_5(Rectangle rect)
	{
		return rect;
	}

	internal static SizeF smethod_6(Size size)
	{
		return size;
	}

	internal static float[] smethod_7(Matrix source)
	{
		return source.Elements;
	}
}
