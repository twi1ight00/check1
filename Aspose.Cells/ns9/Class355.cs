using System;
using Aspose.Cells;
using ns10;

namespace ns9;

internal class Class355 : Class316
{
	internal Class355()
	{
		int_0 = 175;
	}

	internal void method_6(DateTimeGroupItem dateTimeGroupItem_0)
	{
		byte_0 = new byte[24];
		Array.Copy(BitConverter.GetBytes((ushort)dateTimeGroupItem_0.Year), 0, byte_0, 0, 2);
		Array.Copy(BitConverter.GetBytes((ushort)dateTimeGroupItem_0.Month), 0, byte_0, 2, 2);
		Array.Copy(BitConverter.GetBytes(dateTimeGroupItem_0.Day), 0, byte_0, 4, 4);
		Array.Copy(BitConverter.GetBytes((ushort)dateTimeGroupItem_0.Hour), 0, byte_0, 8, 2);
		Array.Copy(BitConverter.GetBytes((ushort)dateTimeGroupItem_0.Minute), 0, byte_0, 10, 2);
		Array.Copy(BitConverter.GetBytes((ushort)dateTimeGroupItem_0.Second), 0, byte_0, 12, 2);
		Array.Copy(BitConverter.GetBytes(Class1224.smethod_22(dateTimeGroupItem_0.DateTimeGroupingType)), 0, byte_0, 20, 4);
	}
}
