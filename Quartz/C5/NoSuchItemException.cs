using System;
using System.Runtime.InteropServices;

namespace C5;

[Serializable]
internal class NoSuchItemException : Exception
{
	[ComVisible(true)]
	public NoSuchItemException()
	{
	}

	[ComVisible(true)]
	public NoSuchItemException(string message)
		: base(message)
	{
	}
}
