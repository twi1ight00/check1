using System;
using Aspose.Cells;
using ns27;
using ns45;

namespace ns28;

internal class Class556 : Class538
{
	internal Class556(Class1141 class1141_0)
	{
		method_2(290);
		method_0(12);
		byte_0 = new byte[12];
		double doubleFromDateTime = CellsHelper.GetDoubleFromDateTime(class1141_0.dateTime_0, date1904: false);
		Array.Copy(BitConverter.GetBytes(doubleFromDateTime), 0, byte_0, 0, 8);
		Array.Copy(BitConverter.GetBytes((class1141_0.class988_0 != null) ? class1141_0.class988_0.Count : 0), 0, byte_0, 8, 4);
	}
}
