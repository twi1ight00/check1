using System;
using System.Text;
using ns11;
using ns22;

namespace ns27;

internal class Class635 : Class538
{
	public Class635()
	{
		method_2(47);
	}

	internal void method_4(Class1647 class1647_0)
	{
		method_0(54);
		byte_0 = new byte[54];
		byte_0[0] = 1;
		byte_0[2] = 1;
		byte_0[4] = 1;
		Array.Copy(class1647_0.method_6(), 0, byte_0, 6, 16);
		Array.Copy(class1647_0.byte_1, 0, byte_0, 22, 16);
		Array.Copy(class1647_0.byte_2, 0, byte_0, 38, 16);
	}

	internal void method_5(string string_0)
	{
		method_0(6);
		byte_0 = new byte[base.Length];
		Array.Copy(BitConverter.GetBytes(Class1637.smethod_2(string_0)), 0, byte_0, 2, 2);
		Array.Copy(BitConverter.GetBytes(Class1637.smethod_1(string_0)), 0, byte_0, 4, 2);
	}

	[Attribute0(true)]
	internal void method_6(Class1638 class1638_0)
	{
		method_0((short)(18 + class1638_0.byte_2.Length * 2 + class1638_0.byte_4.Length));
		int num = 36 + class1638_0.string_0.Length * 2 + 2;
		method_0((short)(base.Length + (short)num));
		byte_0 = new byte[base.Length];
		byte_0[0] = 1;
		byte_0[2] = 2;
		byte_0[4] = 2;
		byte_0[6] = 4;
		int num2 = 10;
		Array.Copy(BitConverter.GetBytes(num - 4), 0, byte_0, 10, 4);
		num2 = 10 + 4;
		byte_0[14] = 4;
		num2 = 14 + 8;
		Array.Copy(BitConverter.GetBytes(26625), 0, byte_0, 22, 4);
		num2 = 22 + 4;
		Array.Copy(BitConverter.GetBytes(32772), 0, byte_0, 26, 4);
		num2 = 26 + 4;
		Array.Copy(BitConverter.GetBytes(class1638_0.uint_4), 0, byte_0, 30, 4);
		num2 = 30 + 4;
		Array.Copy(BitConverter.GetBytes(class1638_0.uint_0), 0, byte_0, 34, 4);
		num2 = 34 + 12;
		byte[] bytes = Encoding.Unicode.GetBytes(class1638_0.string_0);
		Array.Copy(bytes, 0, byte_0, 46, bytes.Length);
		num2 = 46 + (bytes.Length + 2);
		Array.Copy(BitConverter.GetBytes(class1638_0.byte_2.Length), 0, byte_0, num2, 4);
		num2 += 4;
		Array.Copy(class1638_0.byte_2, 0, byte_0, num2, class1638_0.byte_2.Length);
		num2 += class1638_0.byte_2.Length;
		Array.Copy(class1638_0.byte_3, 0, byte_0, num2, class1638_0.byte_2.Length);
		num2 += class1638_0.byte_2.Length;
		Array.Copy(BitConverter.GetBytes(class1638_0.byte_4.Length), 0, byte_0, num2, 4);
		num2 += 4;
		Array.Copy(class1638_0.byte_4, 0, byte_0, num2, class1638_0.byte_4.Length);
	}
}
