using System.Runtime.InteropServices;

namespace C5;

internal class ClearedRangeEventArgs : ClearedEventArgs
{
	[ComVisible(true)]
	public readonly int? Start;

	[ComVisible(true)]
	public ClearedRangeEventArgs(bool full, int count, int? start)
		: base(full, count)
	{
		Start = start;
	}

	[ComVisible(true)]
	public override string ToString()
	{
		return $"(ClearedRangeEventArgs {Count} {Full} {Start})";
	}
}
