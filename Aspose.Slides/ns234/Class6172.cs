using System.IO;
using ns276;

namespace ns234;

internal class Class6172
{
	private readonly Class6752 class6752_0;

	private readonly Stream stream_0;

	public Class6172(Stream dstStream)
	{
		class6752_0 = new Class6752();
		class6752_0.CompressionLevel = Enum914.const_7;
		stream_0 = dstStream;
	}

	public void method_0(string fileName, Stream srcStream)
	{
		class6752_0.method_24(fileName, null, srcStream);
	}

	public void method_1(string fileName, byte[] data)
	{
		Class6751 @class = class6752_0.method_30(fileName, null, data);
		@class.CompressionMethod = 0;
	}

	public void method_2()
	{
		class6752_0.Save(stream_0);
	}
}
