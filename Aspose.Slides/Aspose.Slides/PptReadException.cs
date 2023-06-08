using System;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[ClassInterface(ClassInterfaceType.None)]
[Guid("6d44cb3a-71fd-46af-848d-666abe7091fe")]
public class PptReadException : PptException
{
	public PptReadException()
	{
	}

	public PptReadException(string message)
		: base(message)
	{
	}

	public PptReadException(string message, Exception exception)
		: base(message, exception)
	{
	}
}
