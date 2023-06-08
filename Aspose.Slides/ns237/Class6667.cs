using System.IO;

namespace ns237;

internal class Class6667 : Class6662
{
	internal override Stream vmethod_0(Stream outputStream)
	{
		return new Stream6(outputStream);
	}

	internal override void vmethod_1(Class6679 writer)
	{
		writer.method_8("/Filter", "/RunLengthDecode");
	}
}
