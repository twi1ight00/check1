using System;
using System.Runtime.InteropServices;

namespace C5;

[Serializable]
internal class DuplicateNotAllowedException : Exception
{
	[ComVisible(true)]
	public DuplicateNotAllowedException()
	{
	}

	[ComVisible(true)]
	public DuplicateNotAllowedException(string message)
		: base(message)
	{
	}
}
