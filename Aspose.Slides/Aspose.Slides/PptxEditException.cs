using System;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ClassInterface(ClassInterfaceType.None)]
[Guid("CDA3676D-3E25-49B6-9406-326ED1468804")]
[ComVisible(true)]
public class PptxEditException : PptxException
{
	public PptxEditException()
	{
	}

	public PptxEditException(string message)
		: base(message)
	{
	}

	public PptxEditException(string message, Exception exception)
		: base(message, exception)
	{
	}
}
