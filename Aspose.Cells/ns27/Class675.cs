using System;
using System.Text;
using Aspose.Cells.Properties;
using ns22;
using ns59;

namespace ns27;

internal class Class675 : Class538
{
	internal static int int_0;

	private int int_1;

	[Attribute0(true)]
	internal Class675(CustomProperty customProperty_0)
	{
		method_2(1048);
		string name = customProperty_0.Name;
		string value = customProperty_0.Value;
		int_1 = 7 + name.Length + value.Length * 2;
		byte_0 = new byte[int_1];
		byte_0[1] = 16;
		Array.Copy(BitConverter.GetBytes(value.Length * 2), 0, byte_0, 2, 4);
		byte_0[6] = (byte)name.Length;
		Array.Copy(Encoding.ASCII.GetBytes(name), 0, byte_0, 7, name.Length);
		Array.Copy(Encoding.Unicode.GetBytes(value), 0, byte_0, name.Length + 7, value.Length * 2);
	}

	internal void method_4(Class1725 class1725_0)
	{
		if (int_1 < 8224)
		{
			method_0((short)int_1);
			base.vmethod_0(class1725_0);
			return;
		}
		byte[] array = new byte[4];
		Array.Copy(BitConverter.GetBytes(method_1()), 0, array, 0, 2);
		Array.Copy(BitConverter.GetBytes((short)8224), 0, array, 2, 2);
		class1725_0.method_3(array);
		class1725_0.method_2(byte_0, 0, 8224);
		int num = 8224;
		int num2;
		while (true)
		{
			num2 = byte_0.Length - num;
			if (num2 <= 8224)
			{
				break;
			}
			Array.Copy(BitConverter.GetBytes(1084), 0, array, 0, 2);
			Array.Copy(BitConverter.GetBytes((short)8224), 0, array, 2, 2);
			class1725_0.method_3(array);
			class1725_0.method_2(byte_0, num, 8224);
			num += 8224;
		}
		Array.Copy(BitConverter.GetBytes(1084), 0, array, 0, 2);
		Array.Copy(BitConverter.GetBytes(num2), 0, array, 2, 2);
		class1725_0.method_3(array);
		class1725_0.method_2(byte_0, num, num2);
		num2 = 0;
	}
}
