using System;
using System.Runtime.InteropServices;

namespace C5;

[Serializable]
internal class FixedSizeCollectionException : Exception
{
	[ComVisible(true)]
	public FixedSizeCollectionException()
	{
	}

	[ComVisible(true)]
	public FixedSizeCollectionException(string message)
		: base(message)
	{
	}
}
