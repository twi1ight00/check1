using System;
using System.Runtime.InteropServices;

namespace C5;

internal class ItemAtEventArgs<T> : EventArgs
{
	[ComVisible(true)]
	public readonly T Item;

	[ComVisible(true)]
	public readonly int Index;

	[ComVisible(true)]
	public ItemAtEventArgs(T item, int index)
	{
		Item = item;
		Index = index;
	}

	[ComVisible(true)]
	public override string ToString()
	{
		return $"(ItemAtEventArgs {Index} '{Item}')";
	}
}
