using System;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Charts;

[ComVisible(true)]
[ClassInterface(ClassInterfaceType.None)]
[Guid("50A79AD9-B315-4CFE-A4C4-9EC32ADD5341")]
public class CannotCombine2DAnd3DChartsException : InvalidOperationException
{
	public CannotCombine2DAnd3DChartsException()
	{
	}

	public CannotCombine2DAnd3DChartsException(string message)
		: base(message)
	{
	}

	public CannotCombine2DAnd3DChartsException(string message, Exception exception)
		: base(message, exception)
	{
	}
}
