using System.Collections;
using System.Drawing.Imaging;
using Aspose;

namespace x38a89dee67fc7a16;

[JavaDelete("Not needed on Java.")]
internal class x6a10b0e15f4796fb
{
	private static readonly Hashtable xdcd18ca08475289f;

	public static ImageCodecInfo xe9a31ec80cc211ff(ImageFormat x5786461d089b10a0)
	{
		return (ImageCodecInfo)xdcd18ca08475289f[x5786461d089b10a0.Guid];
	}

	static x6a10b0e15f4796fb()
	{
		xdcd18ca08475289f = new Hashtable();
		ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
		foreach (ImageCodecInfo imageCodecInfo in imageEncoders)
		{
			xdcd18ca08475289f[imageCodecInfo.FormatID] = imageCodecInfo;
		}
	}
}
