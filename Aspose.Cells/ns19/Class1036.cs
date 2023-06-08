using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Aspose.Cells.Rendering;

namespace ns19;

internal class Class1036
{
	internal static readonly int int_0 = 1;

	internal static readonly int int_1 = 2;

	public static Interface42 smethod_0(int int_2, int int_3, int int_4, ImageFormat imageFormat_0, ImageOrPrintOptions imageOrPrintOptions_0, Stream stream_0, Interface6 interface6_0)
	{
		if (int_2 == int_0)
		{
			Interface42 @interface = null;
			if (imageFormat_0.Equals(ImageFormat.Emf))
			{
				@interface = new Class1041(int_3, int_4, imageOrPrintOptions_0, stream_0, interface6_0);
			}
			else
			{
				Bitmap bitmap = new Bitmap(int_3, int_4);
				Graphics graphics = Graphics.FromImage(bitmap);
				graphics.FillRectangle(new SolidBrush(Color.Empty), 0, 0, int_3, int_4);
				@interface = new Class1040(graphics, bitmap, imageFormat_0, imageOrPrintOptions_0, stream_0, interface6_0);
				@interface.imethod_1(new Class1042(graphics));
			}
			interface6_0.imethod_1(@interface);
			return @interface;
		}
		Class1032 @class = new Class1032(int_3, int_4, imageFormat_0, imageOrPrintOptions_0, stream_0, interface6_0);
		@class.imethod_1(new Class1034(@class));
		return @class;
	}
}
