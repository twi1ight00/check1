using System;
using System.Runtime.InteropServices;

namespace C5;

[Serializable]
internal class UnlistenableEventException : Exception
{
	[ComVisible(true)]
	public UnlistenableEventException()
	{
	}

	[ComVisible(true)]
	public UnlistenableEventException(string message)
		: base(message)
	{
	}
}
