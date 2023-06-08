using System;
using System.Runtime.InteropServices;

namespace C5;

internal class ItemCountEventArgs<T> : EventArgs
{
	[ComVisible(true)]
	public readonly T Item;

	[ComVisible(true)]
	public readonly int Count;

	[ComVisible(true)]
	public ItemCountEventArgs(T item, int count)
	{
		Item = item;
		Count = count;
	}

	[ComVisible(true)]
	public override string ToString()
	{
		return $"(ItemCountEventArgs {Count} '{Item}')";
	}
}
