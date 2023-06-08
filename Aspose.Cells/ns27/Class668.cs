using System;
using ns59;

namespace ns27;

internal class Class668 : Class538
{
	internal Class668()
	{
		method_2(77);
	}

	internal void method_4(byte[] byte_1)
	{
		byte_0 = byte_1;
	}

	internal override void vmethod_0(Class1725 class1725_0)
	{
		byte[] array = new byte[6] { 77, 0, 0, 0, 0, 0 };
		if (byte_0.Length + 2 <= 8224)
		{
			Array.Copy(BitConverter.GetBytes(byte_0.Length + 2), 0, array, 2, 2);
			class1725_0.method_3(array);
			class1725_0.method_3(byte_0);
			return;
		}
		Array.Copy(BitConverter.GetBytes((short)8224), 0, array, 2, 2);
		class1725_0.method_3(array);
		class1725_0.method_1(byte_0, 8222);
		int num = 8222;
		array = new byte[4] { 60, 0, 0, 0 };
		int num2;
		while (true)
		{
			if (num < byte_0.Length)
			{
				num2 = byte_0.Length - num;
				if (num2 <= 8224)
				{
					break;
				}
				Array.Copy(BitConverter.GetBytes((short)8224), 0, array, 2, 2);
				class1725_0.method_3(array);
				class1725_0.method_2(byte_0, num, 8224);
				num += 8224;
				continue;
			}
			return;
		}
		Array.Copy(BitConverter.GetBytes(num2), 0, array, 2, 2);
		class1725_0.method_3(array);
		class1725_0.method_2(byte_0, num, num2);
		num += num2;
	}
}
