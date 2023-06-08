using System;
using System.Runtime.InteropServices;

namespace C5;

[Serializable]
internal class IncompatibleViewException : Exception
{
	[ComVisible(true)]
	public IncompatibleViewException()
	{
	}

	[ComVisible(true)]
	public IncompatibleViewException(string message)
		: base(message)
	{
	}
}
