using System;
using System.Runtime.InteropServices;

namespace C5;

[Serializable]
internal class NotComparableException : Exception
{
	[ComVisible(true)]
	public NotComparableException()
	{
	}

	[ComVisible(true)]
	public NotComparableException(string message)
		: base(message)
	{
	}
}
