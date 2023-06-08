using Aspose.Cells;

namespace ns27;

internal class Class688 : Class538
{
	internal Class688()
	{
		method_2(2151);
	}

	internal void method_4(Protection protection_0)
	{
		method_0(23);
		byte_0 = new byte[base.Length];
		byte_0[0] = 103;
		byte_0[1] = 8;
		byte_0[12] = 2;
		byte_0[14] = 1;
		byte_0[15] = byte.MaxValue;
		byte_0[16] = byte.MaxValue;
		byte_0[17] = byte.MaxValue;
		byte_0[18] = byte.MaxValue;
		if (protection_0.AllowSelectingLockedCell)
		{
			byte_0[20] |= 4;
		}
		if (protection_0.AllowSelectingUnlockedCell)
		{
			byte_0[20] |= 64;
		}
		if (protection_0.AllowEditingObject)
		{
			byte_0[19] |= 1;
		}
		if (protection_0.AllowEditingScenario)
		{
			byte_0[19] |= 2;
		}
		if (protection_0.AllowFormattingCell)
		{
			byte_0[19] |= 4;
		}
		if (protection_0.AllowFormattingColumn)
		{
			byte_0[19] |= 8;
		}
		if (protection_0.AllowFormattingRow)
		{
			byte_0[19] |= 16;
		}
		if (protection_0.AllowInsertingColumn)
		{
			byte_0[19] |= 32;
		}
		if (protection_0.AllowInsertingHyperlink)
		{
			byte_0[19] |= 128;
		}
		if (protection_0.AllowInsertingRow)
		{
			byte_0[19] |= 64;
		}
		if (protection_0.AllowDeletingColumn)
		{
			byte_0[20] |= 1;
		}
		if (protection_0.AllowDeletingRow)
		{
			byte_0[20] |= 2;
		}
		if (protection_0.AllowSorting)
		{
			byte_0[20] |= 8;
		}
		if (protection_0.AllowFiltering)
		{
			byte_0[20] |= 16;
		}
		if (protection_0.AllowUsingPivotTable)
		{
			byte_0[20] |= 32;
		}
	}
}
