using System;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[ClassInterface(ClassInterfaceType.None)]
[Guid("343A80FE-0550-4569-9062-B69BF9BD7E54")]
public class PptxUnsupportedFormatException : PptxReadException
{
	public PptxUnsupportedFormatException()
	{
	}

	public PptxUnsupportedFormatException(string message)
		: base(message)
	{
	}

	public PptxUnsupportedFormatException(string message, Exception exception)
		: base(message, exception)
	{
	}
}
