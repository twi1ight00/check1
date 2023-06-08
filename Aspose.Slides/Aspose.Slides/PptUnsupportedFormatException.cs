using System;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ClassInterface(ClassInterfaceType.None)]
[Guid("d8dcb7fd-b04c-417a-8969-d3eb4f492659")]
[ComVisible(true)]
public class PptUnsupportedFormatException : PptReadException
{
	public PptUnsupportedFormatException()
	{
	}

	public PptUnsupportedFormatException(string message)
		: base(message)
	{
	}

	public PptUnsupportedFormatException(string message, Exception exception)
		: base(message, exception)
	{
	}
}
