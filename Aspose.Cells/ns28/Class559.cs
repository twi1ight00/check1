using System;
using Aspose.Cells.Pivot;
using ns2;
using ns27;
using ns45;

namespace ns28;

internal class Class559 : Class538
{
	private Class1160 class1160_0;

	internal Class559(Class1160 class1160_1)
	{
		method_2(241);
		class1160_0 = class1160_1;
		method_4();
	}

	internal void method_4()
	{
		int num = 24;
		num = 24 + Class1677.smethod_29(class1160_0.string_0);
		num += Class1677.smethod_29(class1160_0.string_1);
		num += Class1677.smethod_29(class1160_0.string_2);
		num += Class1677.smethod_29(class1160_0.string_3);
		num += Class1677.smethod_29(class1160_0.string_4);
		num += Class1677.smethod_29(class1160_0.string_5);
		method_0((short)num);
		byte_0 = new byte[base.Length];
		method_5();
	}

	private void method_5()
	{
		int num = 0;
		short num2 = 0;
		Array.Copy(BitConverter.GetBytes(class1160_0.short_0), 0, byte_0, 0, 2);
		num = 0 + 2;
		num2 = (short)((class1160_0.string_0 == null) ? (-1) : class1160_0.string_0.Length);
		Array.Copy(BitConverter.GetBytes(num2), 0, byte_0, num, 2);
		num2 = (short)((class1160_0.string_1 == null) ? (-1) : class1160_0.string_1.Length);
		Array.Copy(BitConverter.GetBytes(num2), 0, byte_0, num + 2, 2);
		num2 = (short)((class1160_0.string_2 == null) ? (-1) : class1160_0.string_2.Length);
		Array.Copy(BitConverter.GetBytes(num2), 0, byte_0, num + 4, 2);
		num += 6;
		Array.Copy(BitConverter.GetBytes(class1160_0.short_1), 0, byte_0, num, 2);
		PivotFieldCollection pageFields = class1160_0.pivotTable_0.PageFields;
		Array.Copy(BitConverter.GetBytes((short)pageFields.Count), 0, byte_0, num + 2, 2);
		Array.Copy(BitConverter.GetBytes((short)((pageFields.Count != 0) ? 1 : 0)), 0, byte_0, num + 4, 2);
		num += 6;
		Array.Copy(BitConverter.GetBytes(class1160_0.ushort_0), 0, byte_0, num, 2);
		Array.Copy(BitConverter.GetBytes(class1160_0.ushort_1), 0, byte_0, num + 2, 2);
		num += 4;
		num2 = (short)((class1160_0.string_3 == null) ? (-1) : class1160_0.string_3.Length);
		Array.Copy(BitConverter.GetBytes(num2), 0, byte_0, num, 2);
		num2 = (short)((class1160_0.string_4 == null) ? (-1) : class1160_0.string_4.Length);
		Array.Copy(BitConverter.GetBytes(num2), 0, byte_0, num + 2, 2);
		num2 = (short)((class1160_0.string_5 == null) ? (-1) : class1160_0.string_5.Length);
		Array.Copy(BitConverter.GetBytes(num2), 0, byte_0, num + 4, 2);
		num += 6;
		if (class1160_0.string_0 != null)
		{
			num += Class937.smethod_4(byte_0, num, class1160_0.string_0);
		}
		if (class1160_0.string_1 != null)
		{
			num += Class937.smethod_4(byte_0, num, class1160_0.string_1);
		}
		if (class1160_0.string_2 != null)
		{
			num += Class937.smethod_4(byte_0, num, class1160_0.string_2);
		}
		if (class1160_0.string_3 != null)
		{
			num += Class937.smethod_4(byte_0, num, class1160_0.string_3);
		}
		if (class1160_0.string_4 != null)
		{
			num += Class937.smethod_4(byte_0, num, class1160_0.string_4);
		}
		if (class1160_0.string_5 != null)
		{
			num += Class937.smethod_4(byte_0, num, class1160_0.string_5);
		}
	}
}
