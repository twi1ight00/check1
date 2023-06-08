using System;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("0d7dadd4-98ba-4eeb-a7bb-05df27c4d091")]
[ClassInterface(ClassInterfaceType.None)]
public class PptxCorruptFileException : PptxReadException
{
	public PptxCorruptFileException()
	{
	}

	public PptxCorruptFileException(string message)
		: base(message)
	{
	}

	public PptxCorruptFileException(string message, Exception exception)
		: base(message, exception)
	{
	}
}
