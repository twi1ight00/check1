using System;
using ns27;
using ns45;

namespace ns28;

internal class Class572 : Class538
{
	internal Class572(Class1171 class1171_0)
	{
		method_2(240);
		method_0(8);
		if (class1171_0.method_16())
		{
			method_0((short)(base.Length + 4));
		}
		byte_0 = new byte[base.Length];
		byte_0[0] = class1171_0.byte_0;
		byte_0[1] = class1171_0.byte_1;
		Array.Copy(BitConverter.GetBytes(class1171_0.ushort_0), 0, byte_0, 2, 2);
		if (class1171_0.arrayList_0 != null)
		{
			Array.Copy(BitConverter.GetBytes((ushort)class1171_0.arrayList_0.Count), 0, byte_0, 6, 2);
		}
		if (class1171_0.method_16())
		{
			byte_0[8] = class1171_0.byte_2;
			byte_0[9] = class1171_0.byte_3;
			byte_0[10] = class1171_0.byte_4;
			byte_0[11] = class1171_0.byte_5;
		}
	}
}
