using System;
using Aspose.Cells;
using ns10;

namespace ns9;

internal class Class325 : Class316
{
	internal Class325(int int_1, Comment comment_0)
	{
		int_0 = 635;
		byte_0 = new byte[36];
		CellArea cellArea_ = new CellArea
		{
			StartColumn = comment_0.Column,
			EndColumn = comment_0.Column,
			StartRow = comment_0.Row,
			EndRow = comment_0.Row
		};
		Array.Copy(BitConverter.GetBytes(int_1), 0, byte_0, 0, 4);
		Class1217.smethod_4(cellArea_, byte_0, 4);
	}
}
