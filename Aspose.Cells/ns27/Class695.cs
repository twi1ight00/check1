using System;
using System.Collections;
using Aspose.Cells;
using ns2;

namespace ns27;

internal class Class695 : Class538
{
	internal Class695()
	{
		method_2(29);
	}

	internal void method_4(Class1732 class1732_0)
	{
		method_0((short)(9 + 6 * class1732_0.method_3().Count));
		byte_0 = new byte[base.Length];
		byte_0[0] = class1732_0.method_1();
		Array.Copy(BitConverter.GetBytes((ushort)class1732_0.method_5()), 0, byte_0, 1, 2);
		Array.Copy(BitConverter.GetBytes((ushort)class1732_0.method_7()), 0, byte_0, 3, 2);
		Array.Copy(BitConverter.GetBytes((ushort)class1732_0.method_9()), 0, byte_0, 5, 2);
		ArrayList arrayList = class1732_0.method_3();
		Array.Copy(BitConverter.GetBytes((ushort)arrayList.Count), 0, byte_0, 7, 2);
		int num = 9;
		for (int i = 0; i < arrayList.Count; i++)
		{
			CellArea cellArea = (CellArea)arrayList[i];
			Array.Copy(BitConverter.GetBytes((ushort)cellArea.StartRow), 0, byte_0, num, 2);
			Array.Copy(BitConverter.GetBytes((ushort)cellArea.EndRow), 0, byte_0, num + 2, 2);
			byte_0[num + 4] = (byte)cellArea.StartColumn;
			byte_0[num + 5] = (byte)cellArea.EndColumn;
			num += 6;
		}
	}
}
