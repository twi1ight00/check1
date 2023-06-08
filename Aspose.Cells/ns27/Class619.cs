using System;
using System.Collections;
using System.Text;
using ns59;

namespace ns27;

internal class Class619 : Class538
{
	internal Class619()
	{
		method_2(60);
	}

	internal void method_4(string string_0, Class1725 class1725_0)
	{
		bool flag = true;
		byte[] array = Encoding.Unicode.GetBytes(string_0);
		for (int i = 0; i < array.Length / 2; i++)
		{
			if (array[2 * i + 1] != 0)
			{
				flag = false;
				break;
			}
		}
		if (flag)
		{
			byte[] array2 = new byte[string_0.Length];
			for (int j = 0; j < string_0.Length; j++)
			{
				array2[j] = array[2 * j];
			}
			array = array2;
		}
		int num = 0;
		int num2 = 0;
		while (true)
		{
			num2 = array.Length - num;
			if (num2 + 1 <= 8224)
			{
				break;
			}
			if (flag)
			{
				method_0(8224);
				byte_0 = new byte[base.Length];
				byte_0[0] = 0;
			}
			else
			{
				method_0(8223);
				byte_0 = new byte[base.Length];
				byte_0[0] = 1;
			}
			Array.Copy(array, num, byte_0, 1, base.Length - 1);
			num += base.Length - 1;
			vmethod_0(class1725_0);
		}
		method_0((short)(num2 + 1));
		byte_0 = new byte[base.Length];
		byte_0[0] = (byte)((!flag) ? 1u : 0u);
		Array.Copy(array, num, byte_0, 1, base.Length - 1);
	}

	internal void method_5(ArrayList arrayList_0)
	{
		method_0((short)(arrayList_0.Count * 8));
		byte_0 = new byte[base.Length];
		int num = 0;
		foreach (Struct85 item in arrayList_0)
		{
			Array.Copy(BitConverter.GetBytes((ushort)item.int_0), 0, byte_0, num, 2);
			Array.Copy(BitConverter.GetBytes((ushort)item.int_1), 0, byte_0, num + 2, 2);
			num += 8;
		}
	}
}
