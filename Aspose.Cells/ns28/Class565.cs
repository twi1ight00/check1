using System;
using System.Collections;
using ns22;
using ns27;

namespace ns28;

internal class Class565 : Class538
{
	internal Class565(ArrayList arrayList_0)
	{
		method_2(245);
		int num = 2 * arrayList_0.Count;
		method_0((short)num);
		byte_0 = new byte[base.Length];
		int num2 = 0;
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			Array.Copy(BitConverter.GetBytes(Class1179.smethod_4((int)arrayList_0[i])), 0, byte_0, num2, 2);
			num2 += 2;
		}
	}
}
