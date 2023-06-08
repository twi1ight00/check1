using System;
using System.Text;
using Aspose.Cells;
using ns22;

namespace ns27;

internal class Class636 : Class538
{
	[Attribute0(true)]
	internal Class636(Workbook workbook_0)
	{
		method_2(91);
		string text = workbook_0.Worksheets.Author;
		if (text == null)
		{
			text = "Aspose";
		}
		byte[] bytes = Encoding.ASCII.GetBytes(text);
		method_0((short)(7 + bytes.Length));
		byte_0 = new byte[base.Length];
		if (workbook_0.Settings.RecommendReadOnly)
		{
			byte_0[0] = 1;
		}
		Array.Copy(BitConverter.GetBytes(workbook_0.Settings.method_4()), 0, byte_0, 2, 2);
		byte_0[4] = (byte)bytes.Length;
		Array.Copy(bytes, 0, byte_0, 7, bytes.Length);
	}
}
