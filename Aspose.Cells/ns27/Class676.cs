using System;
using System.Text;
using Aspose.Cells;
using ns22;

namespace ns27;

internal class Class676 : Class538
{
	internal Class676()
	{
		method_2(2048);
	}

	[Attribute0(true)]
	internal void method_4(CellArea cellArea_0, string string_0)
	{
		byte[] bytes = Encoding.Unicode.GetBytes(string_0);
		method_0((short)(bytes.Length + 12));
		byte_0 = new byte[base.Length];
		byte_0[1] = 8;
		Array.Copy(BitConverter.GetBytes((ushort)cellArea_0.StartRow), 0, byte_0, 2, 2);
		Array.Copy(BitConverter.GetBytes((ushort)cellArea_0.EndRow), 0, byte_0, 4, 2);
		byte_0[6] = (byte)cellArea_0.StartColumn;
		byte_0[8] = (byte)cellArea_0.EndColumn;
		Array.Copy(bytes, 0, byte_0, 10, bytes.Length);
	}
}
