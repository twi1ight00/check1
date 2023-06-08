using System;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Charts;

[ClassInterface(ClassInterfaceType.None)]
[Guid("3CB68FAC-D34E-444F-AF87-738E03F33D0D")]
[ComVisible(true)]
public class AxesCompositionNotCombinableException : InvalidOperationException
{
	public AxesCompositionNotCombinableException()
	{
	}

	public AxesCompositionNotCombinableException(string message)
		: base(message)
	{
	}

	public AxesCompositionNotCombinableException(string message, Exception exception)
		: base(message, exception)
	{
	}
}
