using System;
using ns27;
using ns45;

namespace ns28;

internal class Class563 : Class538
{
	internal Class563(Class1148 class1148_0)
	{
		method_2(249);
		if (class1148_0.byte_0 != null)
		{
			method_0((short)(class1148_0.byte_0.Length + 4));
		}
		else
		{
			method_0(4);
		}
		byte_0 = new byte[base.Length];
		if (class1148_0.byte_0 != null)
		{
			Array.Copy(BitConverter.GetBytes((ushort)class1148_0.byte_0.Length), 0, byte_0, 0, 2);
		}
		if (class1148_0.class1169_0 != null)
		{
			Array.Copy(BitConverter.GetBytes((ushort)class1148_0.class1169_0.Count), 0, byte_0, 2, 2);
		}
		if (class1148_0.byte_0 != null)
		{
			Array.Copy(class1148_0.byte_0, 0, byte_0, 4, class1148_0.byte_0.Length);
		}
	}

	internal Class563(Class1161 class1161_0)
	{
		method_2(249);
		if (class1161_0.byte_0 != null)
		{
			method_0((short)(class1161_0.byte_0.Length + 4));
		}
		else
		{
			method_0(4);
		}
		byte_0 = new byte[base.Length];
		if (class1161_0.byte_0 != null)
		{
			Array.Copy(BitConverter.GetBytes((ushort)class1161_0.byte_0.Length), 0, byte_0, 0, 2);
		}
		if (class1161_0.arrayList_1 != null)
		{
			Array.Copy(BitConverter.GetBytes((ushort)class1161_0.arrayList_1.Count), 0, byte_0, 2, 2);
		}
		if (class1161_0.byte_0 != null)
		{
			Array.Copy(class1161_0.byte_0, 0, byte_0, 4, class1161_0.byte_0.Length);
		}
	}
}
