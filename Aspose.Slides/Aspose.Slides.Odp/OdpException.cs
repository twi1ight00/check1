using System;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Odp;

[ComVisible(true)]
[Guid("7223E594-64C5-4583-BC33-975F198378B0")]
[ClassInterface(ClassInterfaceType.None)]
public class OdpException : Exception
{
	public OdpException()
	{
	}

	public OdpException(string message)
		: base(message)
	{
	}

	public OdpException(string message, Exception exception)
		: base(message, exception)
	{
	}
}
