using System;
using System.Collections;
using Aspose.Cells;

namespace ns27;

internal class Class647 : Class538
{
	internal Class647(FileFormatType fileFormatType_1)
	{
		method_2(27);
		fileFormatType_0 = fileFormatType_1;
	}

	internal void method_4(HorizontalPageBreakCollection horizontalPageBreakCollection_0)
	{
		int count = horizontalPageBreakCollection_0.Count;
		method_0((short)(2 + 6 * count));
		byte_0 = new byte[base.Length];
		Array.Copy(BitConverter.GetBytes(count), 0, byte_0, 0, 2);
		SortedList sortedList = new SortedList(new Class1285());
		int num = 0;
		for (num = 0; num < count; num++)
		{
			HorizontalPageBreak horizontalPageBreak = horizontalPageBreakCollection_0[num];
			sortedList.Add(horizontalPageBreak, horizontalPageBreak);
		}
		num = 0;
		foreach (HorizontalPageBreak value in sortedList.Values)
		{
			Array.Copy(BitConverter.GetBytes((ushort)value.Row), 0, byte_0, 6 * num + 2, 2);
			Array.Copy(BitConverter.GetBytes(value.StartColumn), 0, byte_0, 6 * num + 4, 2);
			Array.Copy(BitConverter.GetBytes(value.EndColumn), 0, byte_0, 6 * num + 6, 2);
			num++;
		}
	}
}
