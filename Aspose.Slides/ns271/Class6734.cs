namespace ns271;

internal class Class6734
{
	private readonly char char_0;

	private readonly int int_0;

	private readonly int int_1;

	private readonly int int_2;

	public char CharCode => char_0;

	public int OldGlyphIndex => int_0;

	public int AdvanceWidth => int_1;

	public int LeftSideBearing => int_2;

	public Class6734(char charCode, int oldGlyphIndex, int advanceWidth, int leftSideBearing)
	{
		char_0 = charCode;
		int_0 = oldGlyphIndex;
		int_1 = advanceWidth;
		int_2 = leftSideBearing;
	}
}
