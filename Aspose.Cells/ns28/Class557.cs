using System;
using ns2;
using ns27;
using ns45;

namespace ns28;

internal class Class557 : Class538
{
	internal Class557(Class1141 class1141_0)
	{
		method_2(198);
		int num = 0;
		bool flag = Class1677.smethod_30(class1141_0.string_1);
		method_0((short)(21 + (flag ? class1141_0.string_1.Length : (class1141_0.string_1.Length * 2))));
		byte_0 = new byte[base.Length];
		Array.Copy(BitConverter.GetBytes(class1141_0.int_3), 0, byte_0, num, 4);
		if (class1141_0.int_6 == 0)
		{
			Array.Copy(BitConverter.GetBytes((ushort)1), 0, byte_0, num + 4, 2);
		}
		else
		{
			Array.Copy(BitConverter.GetBytes((ushort)class1141_0.int_6), 0, byte_0, num + 4, 2);
		}
		Array.Copy(BitConverter.GetBytes(class1141_0.ushort_0), 0, byte_0, num + 6, 2);
		num += 8;
		Array.Copy(BitConverter.GetBytes((ushort)class1141_0.int_8), 0, byte_0, num, 2);
		Array.Copy(BitConverter.GetBytes((ushort)class1141_0.int_1), 0, byte_0, num + 2, 2);
		if (class1141_0.arrayList_0 != null)
		{
			Array.Copy(BitConverter.GetBytes((ushort)class1141_0.arrayList_0.Count), 0, byte_0, num + 4, 2);
		}
		Array.Copy(BitConverter.GetBytes((ushort)1), 0, byte_0, num + 6, 2);
		num += 8;
		Array.Copy(BitConverter.GetBytes((ushort)class1141_0.pivotTableSourceType_0), 0, byte_0, num, 2);
		num += 2;
		string string_ = class1141_0.string_1;
		Array.Copy(BitConverter.GetBytes((short)string_.Length), 0, byte_0, num, 2);
		num += 2;
		num += Class937.smethod_4(byte_0, num, string_);
	}
}
