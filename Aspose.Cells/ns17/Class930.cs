using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Aspose.Cells.Rendering;
using ns18;
using ns19;

namespace ns17;

internal class Class930
{
	internal static void smethod_0(Class456 class456_0, Stream stream_0, Class468 class468_0, ImageOrPrintOptions imageOrPrintOptions_0)
	{
		int[] array = new int[2] { 1, 1 };
		Bitmap image = Class1404.smethod_43(1, 1);
		array[0] = (int)(class456_0.double_1 * 96.0 + 0.9990000128746033) + 1;
		array[1] = (int)(class456_0.double_2 * 96.0 + 0.9990000128746033) + 1;
		Rectangle frameRect = new Rectangle(0, 0, array[0], array[1]);
		Graphics graphics = Graphics.FromImage(image);
		Metafile metafile = new Metafile(stream_0, graphics.GetHdc(), frameRect, MetafileFrameUnit.Pixel);
		Graphics graphics2 = Graphics.FromImage(metafile);
		graphics2.PageUnit = GraphicsUnit.Point;
		graphics2.Clear(Color.White);
		Class472 @class = (Class472)class468_0;
		@class.imageFormat_0 = imageOrPrintOptions_0.ChartImageType;
		@class.method_2(class456_0, graphics2);
		class468_0.vmethod_16();
		graphics2.Save();
		graphics2.Dispose();
		metafile.Dispose();
		stream_0.Seek(0L, SeekOrigin.Begin);
	}
}
