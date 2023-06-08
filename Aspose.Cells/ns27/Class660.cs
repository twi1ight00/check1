using System;
using System.Text;

namespace ns27;

internal class Class660 : Class538
{
	internal Class660()
	{
		method_2(28);
	}

	internal void method_4(ushort ushort_0, byte byte_1, ushort ushort_1, bool bool_0, string string_0)
	{
		byte[] bytes = Encoding.Unicode.GetBytes(string_0);
		method_0((short)(12 + bytes.Length));
		byte_0 = new byte[base.Length];
		Array.Copy(BitConverter.GetBytes(ushort_0), 0, byte_0, 0, 2);
		byte_0[2] = byte_1;
		if (bool_0)
		{
			byte_0[4] = 2;
		}
		Array.Copy(BitConverter.GetBytes(ushort_1), 0, byte_0, 6, 2);
		Array.Copy(BitConverter.GetBytes((ushort)string_0.Length), 0, byte_0, 8, 2);
		byte_0[10] = 1;
		Array.Copy(bytes, 0, byte_0, 11, bytes.Length);
	}
}
