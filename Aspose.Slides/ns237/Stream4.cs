using System.IO;
using ns234;

namespace ns237;

internal class Stream4 : Stream1
{
	internal Stream4(Stream outputStream)
		: base(outputStream)
	{
	}

	public override void Write(byte[] srcBuffer, int srcOffset, int srcCount)
	{
		Class6171.smethod_5(srcBuffer, srcOffset, srcCount, stream_0, Enum794.const_1);
	}
}
