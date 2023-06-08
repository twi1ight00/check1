using System;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("625093FE-824B-4031-81C4-C2034905D2FC")]
[ClassInterface(ClassInterfaceType.None)]
[ComVisible(true)]
public class OOXMLException : Exception
{
	public OOXMLException()
	{
	}

	public OOXMLException(string message)
		: base(message)
	{
	}

	public OOXMLException(string message, Exception exception)
		: base(message, exception)
	{
	}
}
