using System;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ClassInterface(ClassInterfaceType.None)]
[Guid("b80025b6-795e-4513-9121-a42d351f9b3a")]
[ComVisible(true)]
public class PptException : Exception
{
	public PptException()
	{
	}

	public PptException(string message)
		: base(message)
	{
	}

	public PptException(string message, Exception exception)
		: base(message, exception)
	{
	}
}
