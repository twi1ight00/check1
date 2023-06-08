using System;
using System.Collections;
using Aspose.Cells;

namespace ns27;

internal class Class717 : Class538
{
	internal Class717(FileFormatType fileFormatType_1)
	{
		method_2(26);
		fileFormatType_0 = fileFormatType_1;
	}

	internal void method_4(VerticalPageBreakCollection verticalPageBreakCollection_0)
	{
		int count = verticalPageBreakCollection_0.Count;
		method_0((short)(2 + 6 * count));
		byte_0 = new byte[base.Length];
		Array.Copy(BitConverter.GetBytes(count), 0, byte_0, 0, 2);
		SortedList sortedList = new SortedList(new Class1297());
		int num = 0;
		for (num = 0; num < count; num++)
		{
			VerticalPageBreak verticalPageBreak = verticalPageBreakCollection_0[num];
			sortedList.Add(verticalPageBreak, verticalPageBreak);
		}
		num = 0;
		foreach (VerticalPageBreak value in sortedList.Values)
		{
			Array.Copy(BitConverter.GetBytes((ushort)value.Column), 0, byte_0, 6 * num + 2, 2);
			Array.Copy(BitConverter.GetBytes((ushort)value.StartRow), 0, byte_0, 6 * num + 4, 2);
			Array.Copy(BitConverter.GetBytes((ushort)value.EndRow), 0, byte_0, 6 * num + 6, 2);
			num++;
		}
	}
}
