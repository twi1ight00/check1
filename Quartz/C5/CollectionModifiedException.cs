using System;
using System.Runtime.InteropServices;

namespace C5;

[Serializable]
internal class CollectionModifiedException : Exception
{
	[ComVisible(true)]
	public CollectionModifiedException()
	{
	}

	[ComVisible(true)]
	public CollectionModifiedException(string message)
		: base(message)
	{
	}
}
