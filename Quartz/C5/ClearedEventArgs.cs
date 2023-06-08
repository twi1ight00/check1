using System;
using System.Runtime.InteropServices;

namespace C5;

internal class ClearedEventArgs : EventArgs
{
	[ComVisible(true)]
	public readonly bool Full;

	[ComVisible(true)]
	public readonly int Count;

	[ComVisible(true)]
	public ClearedEventArgs(bool full, int count)
	{
		Full = full;
		Count = count;
	}

	[ComVisible(true)]
	public override string ToString()
	{
		return $"(ClearedEventArgs {Count} {Full})";
	}
}
