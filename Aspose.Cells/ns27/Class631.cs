using System;
using ns2;

namespace ns27;

internal class Class631 : Class538
{
	internal Class631()
	{
		method_2(35);
	}

	internal void method_4(Class1653 class1653_0)
	{
		byte[] array = null;
		array = ((!class1653_0.method_14()) ? Class1677.smethod_15(class1653_0.Name) : new byte[1] { (byte)class1653_0.int_1 });
		method_0((short)(8 + array.Length));
		if (class1653_0.method_12() != null)
		{
			method_0((short)(base.Length + (short)class1653_0.method_12().Length));
		}
		byte_0 = new byte[base.Length];
		Array.Copy(BitConverter.GetBytes(class1653_0.method_10()), 0, byte_0, 0, 2);
		Array.Copy(BitConverter.GetBytes(class1653_0.method_1()), 0, byte_0, 2, 4);
		if (class1653_0.method_14())
		{
			byte_0[6] = 1;
		}
		else
		{
			byte_0[6] = (byte)class1653_0.Name.Length;
			byte_0[7] = (byte)((array.Length != class1653_0.Name.Length) ? 1u : 0u);
		}
		Array.Copy(array, 0, byte_0, 8, array.Length);
		if (class1653_0.method_12() != null)
		{
			Array.Copy(class1653_0.method_12(), 0, byte_0, 8 + array.Length, class1653_0.method_12().Length);
		}
	}
}
