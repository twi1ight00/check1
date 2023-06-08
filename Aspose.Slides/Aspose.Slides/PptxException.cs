using System;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[ClassInterface(ClassInterfaceType.None)]
[Guid("9BE14B96-EF22-494B-8F1F-A5C1CD3DD1BA")]
public class PptxException : OOXMLException
{
	public PptxException()
	{
	}

	public PptxException(string message)
		: base(message)
	{
	}

	public PptxException(string message, Exception exception)
		: base(message, exception)
	{
	}
}
