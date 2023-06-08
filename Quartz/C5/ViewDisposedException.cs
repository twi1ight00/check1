using System;
using System.Runtime.InteropServices;

namespace C5;

[Serializable]
internal class ViewDisposedException : Exception
{
	[ComVisible(true)]
	public ViewDisposedException()
	{
	}

	[ComVisible(true)]
	public ViewDisposedException(string message)
		: base(message)
	{
	}
}
