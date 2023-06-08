using System;
using Aspose.Cells.Tables;
using ns10;

namespace ns9;

internal class Class338 : Class316
{
	internal Class338(TableStyle tableStyle_0)
	{
		int_0 = 510;
		int num = 6;
		byte_0 = new byte[(tableStyle_0.Name == null) ? (num + 4) : (num + (4 + tableStyle_0.Name.Length * 2))];
		byte[] sourceArray = new byte[4] { 255, 255, 255, 255 };
		byte b = 0;
		if (tableStyle_0.method_2())
		{
			b = (byte)(b | 2u);
		}
		if (tableStyle_0.method_4())
		{
			b = (byte)(b | 4u);
		}
		byte_0[0] = b;
		TableStyleElementCollection tableStyleElements = tableStyle_0.TableStyleElements;
		Array.Copy(BitConverter.GetBytes(tableStyleElements.Count), 0, byte_0, 2, 4);
		int num2 = 6;
		if (tableStyle_0.Name != null)
		{
			Class1217.smethod_7(byte_0, ref num2, tableStyle_0.Name);
			return;
		}
		Array.Copy(sourceArray, 0, byte_0, num2, 4);
		num2 += 4;
	}
}
