using System;
using System.Text;
using Aspose.Cells.Tables;

namespace ns27;

internal class Class546 : Class538
{
	internal Class546(TableStyle tableStyle_0)
	{
		method_2(2191);
		method_0(20);
		if (tableStyle_0.Name != null)
		{
			method_0((short)(base.Length + (short)(tableStyle_0.Name.Length * 2)));
		}
		byte_0 = new byte[base.Length];
		byte_0[0] = 143;
		byte_0[1] = 8;
		byte b = 0;
		if (tableStyle_0.method_2())
		{
			b = (byte)(b | 2u);
		}
		if (tableStyle_0.method_4())
		{
			b = (byte)(b | 4u);
		}
		byte_0[12] = b;
		TableStyleElementCollection tableStyleElements = tableStyle_0.TableStyleElements;
		Array.Copy(BitConverter.GetBytes(tableStyleElements.Count), 0, byte_0, 14, 4);
		int destinationIndex = 20;
		if (tableStyle_0.Name != null)
		{
			Array.Copy(BitConverter.GetBytes(tableStyle_0.Name.Length), 0, byte_0, 18, 2);
			byte[] bytes = Encoding.Unicode.GetBytes(tableStyle_0.Name);
			Array.Copy(bytes, 0, byte_0, destinationIndex, bytes.Length);
		}
	}
}
