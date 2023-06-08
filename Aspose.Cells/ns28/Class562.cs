using System;
using ns27;
using ns45;

namespace ns28;

internal class Class562 : Class538
{
	internal Class562(Class1162 class1162_0)
	{
		method_2(242);
		method_0(8);
		byte_0 = new byte[base.Length];
		Array.Copy(BitConverter.GetBytes(class1162_0.ushort_0), 0, byte_0, 0, 2);
		Array.Copy(BitConverter.GetBytes(class1162_0.ushort_1), 0, byte_0, 2, 2);
		Array.Copy(BitConverter.GetBytes(class1162_0.Function), 0, byte_0, 4, 2);
		Array.Copy(BitConverter.GetBytes((ushort)class1162_0.arrayList_0.Count), 0, byte_0, 6, 2);
	}
}
