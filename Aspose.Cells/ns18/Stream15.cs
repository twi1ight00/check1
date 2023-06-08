using System.IO;
using ns16;

namespace ns18;

internal class Stream15 : Stream14
{
	private readonly Stream12 stream12_0;

	internal Stream15(Stream stream_1)
		: base(stream_1)
	{
		stream12_0 = new Stream12(stream_0, Enum44.const_0);
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		stream12_0.Write(buffer, offset, count);
		stream12_0.Flush();
		stream12_0.method_0();
	}
}
