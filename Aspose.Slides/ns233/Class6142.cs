using System.Collections;
using System.Drawing.Imaging;

namespace ns233;

internal static class Class6142
{
	private static readonly Hashtable hashtable_0;

	public static ImageCodecInfo smethod_0(ImageFormat format)
	{
		return (ImageCodecInfo)hashtable_0[format.Guid];
	}

	static Class6142()
	{
		hashtable_0 = new Hashtable();
		ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
		foreach (ImageCodecInfo imageCodecInfo in imageEncoders)
		{
			hashtable_0[imageCodecInfo.FormatID] = imageCodecInfo;
		}
	}
}
