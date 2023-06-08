using System;
using Aspose.Cells;

namespace ns9;

internal class Class378 : Class316
{
	internal Class378(Protection protection_0)
	{
		int_0 = 535;
		byte_0 = new byte[66];
		Array.Copy(BitConverter.GetBytes(protection_0.method_2()), 0, byte_0, 0, 2);
		if (!protection_0.AllowEditingContent)
		{
			byte_0[2] = 1;
		}
		if (protection_0.AllowEditingObject)
		{
			byte_0[6] = 1;
		}
		if (protection_0.AllowEditingScenario)
		{
			byte_0[10] = 1;
		}
		if (protection_0.AllowFormattingCell)
		{
			byte_0[14] = 1;
		}
		if (protection_0.AllowFormattingColumn)
		{
			byte_0[18] = 1;
		}
		if (protection_0.AllowFormattingRow)
		{
			byte_0[22] = 1;
		}
		if (protection_0.AllowInsertingColumn)
		{
			byte_0[26] = 1;
		}
		if (protection_0.AllowInsertingRow)
		{
			byte_0[30] = 1;
		}
		if (protection_0.AllowInsertingHyperlink)
		{
			byte_0[34] = 1;
		}
		if (protection_0.AllowDeletingColumn)
		{
			byte_0[38] = 1;
		}
		if (protection_0.AllowDeletingRow)
		{
			byte_0[42] = 1;
		}
		if (protection_0.AllowSelectingLockedCell)
		{
			byte_0[46] = 1;
		}
		if (protection_0.AllowSorting)
		{
			byte_0[50] = 1;
		}
		if (protection_0.AllowFiltering)
		{
			byte_0[54] = 1;
		}
		if (protection_0.AllowUsingPivotTable)
		{
			byte_0[58] = 1;
		}
		if (protection_0.AllowSelectingUnlockedCell)
		{
			byte_0[62] = 1;
		}
	}
}
