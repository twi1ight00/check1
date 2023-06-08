using System;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ClassInterface(ClassInterfaceType.None)]
[ComVisible(true)]
[Guid("50f7b82c-f4c2-4ddb-bee1-a8d0790e59db")]
public class InvalidPasswordException : Exception
{
	public InvalidPasswordException()
	{
	}

	public InvalidPasswordException(string message)
		: base(message)
	{
	}

	public InvalidPasswordException(string message, Exception exception)
		: base(message, exception)
	{
	}
}
