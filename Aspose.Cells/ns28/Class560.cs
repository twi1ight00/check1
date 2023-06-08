using System;
using ns2;
using ns27;
using ns45;

namespace ns28;

internal class Class560 : Class538
{
	internal Class560(Class1161 class1161_0)
	{
		method_2(199);
		bool flag = Class1677.smethod_30(class1161_0.string_0);
		method_0((short)(17 + (flag ? class1161_0.string_0.Length : (class1161_0.string_0.Length * 2))));
		byte_0 = new byte[base.Length];
		ushort num = class1161_0.ushort_0;
		if (class1161_0.method_29() && !class1161_0.method_12())
		{
			num = (ushort)(num | 0x80u);
		}
		if (class1161_0.method_14() && class1161_0.method_22())
		{
			num = (ushort)(num & 0xFBFFu);
		}
		int num2 = 0;
		Array.Copy(BitConverter.GetBytes(num), 0, byte_0, 0, 2);
		Array.Copy(BitConverter.GetBytes(class1161_0.int_0), 0, byte_0, 2, 2);
		if (class1161_0.method_18())
		{
			Array.Copy(BitConverter.GetBytes((short)class1161_0.Index), 0, byte_0, num2 + 4, 2);
		}
		else if (class1161_0.method_20())
		{
			Array.Copy(BitConverter.GetBytes((short)class1161_0.int_1), 0, byte_0, num2 + 4, 2);
		}
		else
		{
			Array.Copy(BitConverter.GetBytes((short)0), 0, byte_0, num2 + 4, 2);
		}
		num2 += 6;
		if (class1161_0.method_18())
		{
			Array.Copy(BitConverter.GetBytes((ushort)class1161_0.method_0().method_21()), 0, byte_0, num2, 2);
		}
		else if (class1161_0.method_20() && class1161_0.sxRng_0.arrayList_0 != null)
		{
			Array.Copy(BitConverter.GetBytes((ushort)class1161_0.sxRng_0.arrayList_0.Count), 0, byte_0, num2, 2);
		}
		else if (class1161_0.arrayList_0 == null)
		{
			Array.Copy(BitConverter.GetBytes((ushort)30), 0, byte_0, num2, 2);
		}
		else if (class1161_0.arrayList_0 != null)
		{
			Array.Copy(BitConverter.GetBytes((ushort)class1161_0.arrayList_0.Count), 0, byte_0, num2, 2);
		}
		if (class1161_0.method_20() && class1161_0.sxRng_0.arrayList_0 != null)
		{
			Array.Copy(BitConverter.GetBytes((short)class1161_0.sxRng_0.arrayList_0.Count), 0, byte_0, num2 + 2, 2);
		}
		else
		{
			Array.Copy(BitConverter.GetBytes((short)0), 0, byte_0, num2 + 2, 2);
		}
		Array.Copy(BitConverter.GetBytes((short)0), 0, byte_0, num2 + 4, 2);
		if (!class1161_0.method_18() && class1161_0.arrayList_0 != null)
		{
			if (class1161_0.method_20())
			{
				if (class1161_0.int_2 == 0)
				{
					Array.Copy(BitConverter.GetBytes((ushort)class1161_0.arrayList_0.Count), 0, byte_0, num2 + 6, 2);
				}
				else
				{
					Array.Copy(BitConverter.GetBytes((ushort)class1161_0.int_2), 0, byte_0, num2 + 6, 2);
				}
			}
			else
			{
				Array.Copy(BitConverter.GetBytes((ushort)class1161_0.arrayList_0.Count), 0, byte_0, num2 + 6, 2);
			}
		}
		else
		{
			Array.Copy(BitConverter.GetBytes((short)0), 0, byte_0, num2 + 6, 2);
		}
		num2 += 8;
		Array.Copy(BitConverter.GetBytes((ushort)class1161_0.string_0.Length), 0, byte_0, num2, 2);
		num2 += 2;
		num2 += Class937.smethod_4(byte_0, num2, class1161_0.string_0);
	}
}
