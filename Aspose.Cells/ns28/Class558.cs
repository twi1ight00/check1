using System;
using ns2;
using ns27;
using ns45;

namespace ns28;

internal class Class558 : Class538
{
	internal Class558()
	{
		method_2(197);
	}

	internal void method_4(Class1159 class1159_0)
	{
		method_0((short)(14 + ((class1159_0.string_1 != null) ? Class1677.smethod_29(class1159_0.Name) : 0)));
		byte_0 = new byte[base.Length];
		int num = 0;
		Array.Copy(BitConverter.GetBytes((short)class1159_0.pivotField_0.BaseIndex), 0, byte_0, 0, 2);
		Array.Copy(BitConverter.GetBytes((short)class1159_0.consolidationFunction_0), 0, byte_0, 0 + 2, 2);
		Array.Copy(BitConverter.GetBytes((ushort)class1159_0.pivotFieldDataDisplayFormat_0), 0, byte_0, 0 + 4, 2);
		Array.Copy(BitConverter.GetBytes((short)class1159_0.int_0), 0, byte_0, 0 + 6, 2);
		Array.Copy(BitConverter.GetBytes((short)class1159_0.int_1), 0, byte_0, 0 + 8, 2);
		Array.Copy(BitConverter.GetBytes(class1159_0.short_0), 0, byte_0, 0 + 10, 2);
		num = 0 + 12;
		if (class1159_0.string_1 == null)
		{
			byte_0[num++] = byte.MaxValue;
			byte_0[num++] = byte.MaxValue;
			return;
		}
		string name = class1159_0.Name;
		Array.Copy(BitConverter.GetBytes((short)name.Length), 0, byte_0, num, 2);
		num += 2;
		num += Class937.smethod_4(byte_0, num, name);
	}
}
