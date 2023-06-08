using System;
using System.IO;
using ns235;
using ns267;

namespace ns269;

internal class Class6629
{
	public void method_0(Stream stream, Class6204 node)
	{
		method_1(stream, node, serializeTtfFonts: false);
	}

	public void method_1(Stream stream, Class6204 node, bool serializeTtfFonts)
	{
		if (stream == null)
		{
			throw new ArgumentNullException("stream");
		}
		if (node == null)
		{
			throw new ArgumentNullException("node");
		}
		Class6616 @class = new Class6616(stream);
		@class.SerializeTtfFonts = serializeTtfFonts;
		@class.method_0().method_1(node);
	}

	public Class6204 method_2(Stream stream)
	{
		if (stream == null)
		{
			throw new ArgumentNullException("stream");
		}
		Class6616 @class = new Class6616(stream);
		return @class.method_1().method_0();
	}
}
