using System.IO;
using ns233;

namespace ns237;

internal class Stream3 : Stream1
{
	private readonly Enum783 enum783_0;

	private readonly float float_0;

	private readonly int int_0;

	internal Stream3(Stream outputStream, Enum783 compression, float vRes, int widthPixels)
		: base(outputStream)
	{
		enum783_0 = compression;
		float_0 = vRes;
		int_0 = widthPixels;
	}

	public override void Write(byte[] srcBuffer, int srcOffset, int srcCount)
	{
		Class6139 @class = new Class6139();
		@class.Alignment = Enum782.const_1;
		@class.DontWriteRtc = false;
		@class.DontWriteEol = false;
		@class.method_0(srcBuffer, enum783_0, float_0, int_0, stream_0);
	}
}
