using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Aspose.Cells.Charts;
using Aspose.Cells.Rendering;
using ns19;
using ns35;

namespace ns23;

internal class Class1304
{
	public static Bitmap ToImage(ImageOrPrintOptions imageOrPrintOptions_0, SparklineGroup sparklineGroup_0, Sparkline sparkline_0, int int_0, int int_1)
	{
		ImageFormat imageFormat = imageOrPrintOptions_0.ImageFormat;
		Interface6 interface6_ = new Class1298(imageOrPrintOptions_0, sparklineGroup_0, sparkline_0, int_0, int_1);
		return smethod_0(int_0, int_1, null, imageFormat, imageOrPrintOptions_0, interface6_)?.imethod_3();
	}

	public static void ToImage(string string_0, ImageOrPrintOptions imageOrPrintOptions_0, SparklineGroup sparklineGroup_0, Sparkline sparkline_0, int int_0, int int_1)
	{
		Interface42 @interface = null;
		if (!(string_0 == string.Empty) && string_0 != null)
		{
			ImageFormat imageFormat = imageOrPrintOptions_0.ImageFormat;
			imageFormat = Class872.smethod_0(Path.GetExtension(string_0), imageFormat);
			Interface6 interface6_ = new Class1298(string_0, imageOrPrintOptions_0, sparklineGroup_0, sparkline_0, int_0, int_1);
			using FileStream stream_ = new FileStream(string_0, FileMode.Create);
			smethod_0(int_0, int_1, stream_, imageFormat, imageOrPrintOptions_0, interface6_)?.imethod_2();
		}
	}

	public static void ToImage(Stream stream_0, ImageOrPrintOptions imageOrPrintOptions_0, SparklineGroup sparklineGroup_0, Sparkline sparkline_0, int int_0, int int_1)
	{
		if (stream_0 != null)
		{
			ImageFormat imageFormat = imageOrPrintOptions_0.ImageFormat;
			Interface6 interface6_ = new Class1298(stream_0, imageOrPrintOptions_0, sparklineGroup_0, sparkline_0, int_0, int_1);
			smethod_0(int_0, int_1, stream_0, imageFormat, imageOrPrintOptions_0, interface6_)?.imethod_2();
		}
	}

	private static Interface42 smethod_0(int int_0, int int_1, Stream stream_0, ImageFormat imageFormat_0, ImageOrPrintOptions imageOrPrintOptions_0, Interface6 interface6_0)
	{
		int int_2 = Class1036.int_0;
		return Class1036.smethod_0(int_2, int_0, int_1, imageFormat_0, imageOrPrintOptions_0, stream_0, interface6_0);
	}
}
