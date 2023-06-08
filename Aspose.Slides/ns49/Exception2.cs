using System;
using Aspose.Slides.Warnings;

namespace ns49;

internal class Exception2 : Exception
{
	internal IWarningInfo iwarningInfo_0;

	public Exception2(IWarningInfo warningInfo)
	{
		iwarningInfo_0 = warningInfo;
	}
}
