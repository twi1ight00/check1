using System;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("65ed44d6-c14d-483b-bc07-50512d3c0b5e")]
[ClassInterface(ClassInterfaceType.None)]
[ComVisible(true)]
public class PptEditException : PptException
{
	public PptEditException()
	{
	}

	public PptEditException(string message)
		: base(message)
	{
	}

	public PptEditException(string message, Exception exception)
		: base(message, exception)
	{
	}
}
