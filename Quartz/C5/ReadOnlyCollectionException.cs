using System;
using System.Runtime.InteropServices;

namespace C5;

[Serializable]
internal class ReadOnlyCollectionException : Exception
{
	[ComVisible(true)]
	public ReadOnlyCollectionException()
	{
	}

	[ComVisible(true)]
	public ReadOnlyCollectionException(string message)
		: base(message)
	{
	}
}
