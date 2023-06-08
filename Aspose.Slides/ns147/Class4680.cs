namespace ns147;

internal class Class4680
{
	private uint uint_0;

	private ushort ushort_0;

	private ushort ushort_1;

	private ushort ushort_2;

	private ushort ushort_3;

	public uint ScalerType => uint_0;

	public ushort NumTables => ushort_0;

	public ushort SearchRange => ushort_1;

	public ushort EntrySelector => ushort_2;

	public ushort RangeShift => ushort_3;

	internal Class4680(uint scalerType, ushort numTables, ushort searchRange, ushort entrySelector, ushort rangeShift)
	{
		uint_0 = scalerType;
		ushort_0 = numTables;
		ushort_1 = searchRange;
		ushort_2 = entrySelector;
		ushort_3 = rangeShift;
	}
}
