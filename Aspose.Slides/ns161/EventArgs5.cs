using System;

namespace ns161;

internal class EventArgs5 : EventArgs
{
	private readonly int int_0;

	private readonly int int_1;

	public int Current => int_0;

	public int Total => int_1;

	internal EventArgs5(int progress, int total)
	{
		int_0 = progress;
		int_1 = total;
	}
}
