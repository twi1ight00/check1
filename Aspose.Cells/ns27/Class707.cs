using System;
using ns2;
using ns59;

namespace ns27;

internal class Class707 : Class538
{
	private bool bool_0 = true;

	private int int_0;

	internal Class707(string string_0)
	{
		method_2(519);
		byte_0 = Class1677.smethod_15(string_0);
		int_0 = string_0.Length;
		if (byte_0 != null)
		{
			bool_0 = byte_0.Length == string_0.Length;
		}
	}

	internal override void vmethod_0(Class1725 class1725_0)
	{
		if (byte_0 == null)
		{
			byte_0 = new byte[7];
			byte_0[0] = 7;
			byte_0[1] = 2;
			byte_0[2] = 3;
			class1725_0.method_3(byte_0);
			return;
		}
		int num = 3 + byte_0.Length;
		byte[] array = new byte[7] { 7, 2, 0, 0, 0, 0, 0 };
		Array.Copy(BitConverter.GetBytes(int_0), 0, array, 4, 2);
		if (!bool_0)
		{
			array[6] = 1;
		}
		if (num < 8224)
		{
			Array.Copy(BitConverter.GetBytes(3 + byte_0.Length), 0, array, 2, 2);
			class1725_0.method_3(array);
			class1725_0.method_3(byte_0);
			return;
		}
		int num2 = (bool_0 ? 8221 : 8220);
		Array.Copy(BitConverter.GetBytes(3 + num2), 0, array, 2, 2);
		class1725_0.method_3(array);
		class1725_0.method_2(byte_0, 0, num2);
		int i = num2;
		num2 = (bool_0 ? 8223 : 8222);
		array = new byte[5] { 60, 0, 0, 0, 0 };
		if (!bool_0)
		{
			array[4] = 1;
		}
		for (; i < byte_0.Length; i += num2)
		{
			if (num2 > byte_0.Length - i)
			{
				num2 = byte_0.Length - i;
			}
			Array.Copy(BitConverter.GetBytes(1 + num2), 0, array, 2, 2);
			class1725_0.method_3(array);
			class1725_0.method_2(byte_0, i, num2);
		}
	}
}
