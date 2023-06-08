using System;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ClassInterface(ClassInterfaceType.None)]
[Guid("DAE5905C-5248-4960-986F-780BE8E416E9")]
[ComVisible(true)]
public class OOXMLCorruptFileException : OOXMLException
{
	public OOXMLCorruptFileException()
	{
	}

	public OOXMLCorruptFileException(string message)
		: base(message)
	{
	}

	public OOXMLCorruptFileException(string message, Exception exception)
		: base(message, exception)
	{
	}
}
