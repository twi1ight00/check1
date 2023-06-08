using System;
using System.IO;
using ns233;

namespace ns237;

internal class Class6663 : Class6662
{
	private readonly Enum891 enum891_0;

	private readonly Class6147 class6147_0;

	internal Class6663(Enum891 compression, Class6147 imageSize)
	{
		enum891_0 = compression;
		class6147_0 = imageSize;
	}

	internal override Stream vmethod_0(Stream outputStream)
	{
		Enum783 compression = ((enum891_0 == Enum891.const_7) ? Enum783.const_1 : Enum783.const_3);
		return new Stream3(outputStream, compression, (float)class6147_0.VerticalResolution, class6147_0.Width);
	}

	internal override void vmethod_1(Class6679 writer)
	{
		writer.method_8("/Filter", "/CCITTFaxDecode");
		writer.method_3("/DecodeParms <<");
		writer.method_18("/K", method_0());
		writer.method_18("/Columns", class6147_0.Width);
		writer.method_18("/Rows", class6147_0.Height);
		writer.method_3(">>");
	}

	private int method_0()
	{
		return enum891_0 switch
		{
			Enum891.const_7 => 0, 
			Enum891.const_8 => -1, 
			_ => throw new InvalidOperationException("Unexpected compression."), 
		};
	}
}
