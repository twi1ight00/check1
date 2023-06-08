using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ns35;

internal class Class792
{
	public static readonly int int_0 = 1;

	public static readonly int int_1 = 2;

	public static Interface34 smethod_0()
	{
		return new Class797();
	}

	public static Interface32 smethod_1(int GraphcisType, int width, int height, ImageFormat format, Class806 imageOption, Stream SaveStream, Interface4 shapeDrawing)
	{
		if (GraphcisType == int_0)
		{
			Interface32 @interface = null;
			if (format.Equals(ImageFormat.Emf))
			{
				@interface = new Class796(width, height, imageOption, SaveStream, shapeDrawing);
			}
			else
			{
				Bitmap bitmap = new Bitmap(width, height);
				Graphics graphics = Graphics.FromImage(bitmap);
				graphics.FillRectangle(new SolidBrush(Color.Empty), 0, 0, width, height);
				@interface = new Class795(graphics, bitmap, format, imageOption, SaveStream, shapeDrawing);
				@interface.GraphicsTools = new Class797(graphics);
			}
			shapeDrawing.Graphics = @interface;
			return @interface;
		}
		return null;
	}
}
