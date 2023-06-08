using System;
using System.Runtime.InteropServices;

namespace C5;

[Serializable]
internal class InvalidPriorityQueueHandleException : Exception
{
	[ComVisible(true)]
	public InvalidPriorityQueueHandleException()
	{
	}

	[ComVisible(true)]
	public InvalidPriorityQueueHandleException(string message)
		: base(message)
	{
	}
}
