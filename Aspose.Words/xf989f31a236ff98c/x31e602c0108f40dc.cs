using System.IO;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace xf989f31a236ff98c;

internal class x31e602c0108f40dc : xd59a0d3f8248c4e8
{
	private readonly xfe2ff3c162b47c70 x8eb0c17fe73c1113;

	private readonly x00e0b1d9cd99a947 x435b26849f0d2436;

	internal x31e602c0108f40dc(string contentType, string uri, xfe2ff3c162b47c70 imageSaveType, x00e0b1d9cd99a947 transform)
		: base(null, contentType, uri)
	{
		x8eb0c17fe73c1113 = imageSaveType;
		x435b26849f0d2436 = transform;
	}

	internal override MemoryStream x878afbafb98bf640()
	{
		MemoryStream memoryStream = new MemoryStream();
		using (x3cd5d648729cd9b6 xe058541ca798c = x435b26849f0d2436.x063e61b390371e67())
		{
			x8aa64ac02744cab2.xe0b2c139dfb583c9(xe058541ca798c, memoryStream, x8eb0c17fe73c1113);
		}
		memoryStream.Position = 0L;
		return memoryStream;
	}
}
