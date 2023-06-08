using System;
using System.Runtime.InteropServices;

namespace C5;

[Serializable]
internal class NotAViewException : Exception
{
	[ComVisible(true)]
	public NotAViewException()
	{
	}

	[ComVisible(true)]
	public NotAViewException(string message)
		: base(message)
	{
	}
}
