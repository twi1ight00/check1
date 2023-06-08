using System;
using System.Text;
using Aspose.Cells;
using ns2;

namespace ns27;

internal class Class543 : Class538
{
	internal Class543()
	{
		method_2(2175);
	}

	internal void method_4(Class1108 class1108_0, CellArea cellArea_0)
	{
		int num = 42;
		byte[] array = null;
		if (class1108_0.Type == Enum135.const_0)
		{
			string value = class1108_0.Value;
			if (value != null && value != "")
			{
				array = Encoding.Unicode.GetBytes(value);
				num += array.Length + 1;
			}
		}
		method_0((short)num);
		byte_0 = new byte[num];
		byte_0[0] = 127;
		byte_0[1] = 8;
		if (class1108_0.Order == SortOrder.Descending)
		{
			byte_0[12] |= 1;
		}
		switch (class1108_0.Type)
		{
		case Enum135.const_3:
			byte_0[12] |= 6;
			Array.Copy(BitConverter.GetBytes(Class1673.smethod_14(class1108_0.IconSetType)), 0, byte_0, 30, 4);
			Array.Copy(BitConverter.GetBytes(class1108_0.IconId), 0, byte_0, 34, 4);
			break;
		case Enum135.const_0:
			if (array != null)
			{
				Array.Copy(BitConverter.GetBytes(array.Length), 0, byte_0, 38, 4);
				array[42] = 1;
				Array.Copy(array, 0, byte_0, 43, array.Length);
			}
			break;
		}
		Array.Copy(BitConverter.GetBytes(cellArea_0.StartRow), 0, byte_0, 14, 4);
		Array.Copy(BitConverter.GetBytes(cellArea_0.EndRow), 0, byte_0, 18, 4);
		Array.Copy(BitConverter.GetBytes(cellArea_0.StartColumn), 0, byte_0, 22, 4);
		Array.Copy(BitConverter.GetBytes(cellArea_0.EndColumn), 0, byte_0, 26, 4);
	}
}
