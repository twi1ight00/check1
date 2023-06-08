using System;
using System.Text;
using Aspose.Cells;

namespace ns27;

internal class Class700 : Class538
{
	internal Class700(FileFormatType fileFormatType_1, string string_0)
	{
		method_2(4109);
		fileFormatType_0 = fileFormatType_1;
		if (string_0 != null && !(string_0 == ""))
		{
			if (string_0.Length > 255)
			{
				throw new CellsException(ExceptionType.InvalidData, "Series name is too long.");
			}
			byte[] bytes = Encoding.Unicode.GetBytes(string_0);
			method_0((short)(4 + bytes.Length));
			byte_0 = new byte[base.Length];
			byte_0[2] = (byte)string_0.Length;
			byte_0[3] = 1;
			Array.Copy(bytes, 0, byte_0, 4, bytes.Length);
		}
		else
		{
			method_0(4);
			byte_0 = new byte[4];
		}
	}
}
