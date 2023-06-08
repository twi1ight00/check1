using System;
using System.Text;
using Aspose.Cells;
using ns22;
using ns59;

namespace ns27;

internal class Class608 : Class538
{
	private int int_0;

	private short short_2;

	[Attribute0(true)]
	internal Class608(short short_3, string string_0, FileFormatType fileFormatType_1)
	{
		method_2(133);
		int_0 = 0;
		short_2 = short_3;
		fileFormatType_0 = fileFormatType_1;
		byte[] bytes = Encoding.Unicode.GetBytes(string_0);
		bool flag = false;
		for (int i = 0; i < bytes.Length; i++)
		{
			if (i % 2 == 0)
			{
				if (bytes[i] > 127)
				{
					flag = true;
					break;
				}
			}
			else if (bytes[i] != 0)
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			byte_0 = new byte[2 * string_0.Length + 2];
			byte_0[0] = (byte)string_0.Length;
			byte_0[1] = 1;
			Array.Copy(bytes, 0, byte_0, 2, bytes.Length);
			method_0((short)(8 + 2 * string_0.Length));
			return;
		}
		byte_0 = new byte[string_0.Length + 2];
		byte_0[0] = (byte)string_0.Length;
		byte[] array = new byte[string_0.Length];
		byte_0[1] = 0;
		for (int j = 0; j < array.Length; j++)
		{
			array[j] = bytes[2 * j];
		}
		Array.Copy(array, 0, byte_0, 2, array.Length);
		method_0((short)(8 + string_0.Length));
	}

	internal override void vmethod_0(Class1725 class1725_0)
	{
		class1725_0.method_7(method_1());
		class1725_0.method_7(base.Length);
		class1725_0.method_5(int_0);
		class1725_0.method_7(short_2);
		class1725_0.method_3(byte_0);
	}
}
