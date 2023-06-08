using System;
using System.Text;
using ns22;

namespace ns27;

internal class Class683 : Class538
{
	internal Class683()
	{
		method_2(2136);
	}

	[Attribute0(true)]
	internal void SetDataSource(string string_0)
	{
		method_0((short)(8 + string_0.Length * 2));
		byte_0 = new byte[base.Length];
		byte_0[0] = 88;
		byte_0[1] = 8;
		byte_0[2] = 18;
		byte_0[6] = (byte)string_0.Length;
		byte_0[7] = 1;
		byte[] bytes = Encoding.Unicode.GetBytes(string_0);
		Array.Copy(bytes, 0, byte_0, 8, bytes.Length);
	}
}
