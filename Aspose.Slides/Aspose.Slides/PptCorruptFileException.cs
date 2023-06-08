using System;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("685c7a71-77f6-463d-bfff-4d5461b3a9a9")]
[ComVisible(true)]
[ClassInterface(ClassInterfaceType.None)]
public class PptCorruptFileException : PptReadException
{
	public PptCorruptFileException()
	{
	}

	public PptCorruptFileException(string message)
		: base(message)
	{
	}

	public PptCorruptFileException(string message, Exception exception)
		: base(message, exception)
	{
	}
}
