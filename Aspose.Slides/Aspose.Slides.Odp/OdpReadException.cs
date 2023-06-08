using System;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Odp;

[ClassInterface(ClassInterfaceType.None)]
[Guid("CF0AD269-23FD-4D9B-A9F8-4C8C5EFD237B")]
[ComVisible(true)]
public class OdpReadException : OdpException
{
	public OdpReadException()
	{
	}

	public OdpReadException(string message)
		: base(message)
	{
	}

	public OdpReadException(string message, Exception exception)
		: base(message, exception)
	{
	}
}
