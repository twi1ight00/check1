using System;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("C647C67B-EF68-403B-AF3F-CCFF86320942")]
[ClassInterface(ClassInterfaceType.None)]
[ComVisible(true)]
public class PptxReadException : PptxException
{
	public PptxReadException()
	{
	}

	public PptxReadException(string message)
		: base(message)
	{
	}

	public PptxReadException(string message, Exception exception)
		: base(message, exception)
	{
	}
}
