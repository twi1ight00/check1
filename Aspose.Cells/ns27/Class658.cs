using System;
using Aspose.Cells;
using ns2;

namespace ns27;

internal class Class658 : Class538
{
	internal Class658()
	{
		method_2(2196);
	}

	internal void method_4(Name name_0)
	{
		string text = name_0.method_16();
		string comment = name_0.Comment;
		method_0(16);
		byte[] array = Class1677.smethod_15(text);
		byte[] array2 = Class1677.smethod_15(comment);
		method_0((short)(base.Length + (short)(2 + array.Length + array2.Length)));
		byte_0 = new byte[base.Length];
		byte_0[0] = 148;
		byte_0[1] = 8;
		int num = 12;
		Array.Copy(BitConverter.GetBytes((ushort)text.Length), 0, byte_0, 12, 2);
		Array.Copy(BitConverter.GetBytes((ushort)comment.Length), 0, byte_0, 12 + 2, 2);
		num = 12 + 4;
		if (array.Length == text.Length)
		{
			byte_0[num++] = 0;
		}
		else
		{
			byte_0[num++] = 1;
		}
		Array.Copy(array, 0, byte_0, num, array.Length);
		num += array.Length;
		if (array2.Length == comment.Length)
		{
			byte_0[num++] = 0;
		}
		else
		{
			byte_0[num++] = 1;
		}
		Array.Copy(array2, 0, byte_0, num, array2.Length);
		num += array2.Length;
	}
}
