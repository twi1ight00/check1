using System.Collections;
using System.Runtime.CompilerServices;
using Aspose.Cells;

namespace ns2;

internal class Class1732
{
	private byte byte_0;

	private int int_0;

	private short short_0;

	private short short_1;

	private ArrayList arrayList_0;

	internal Class1732(int int_1)
	{
		byte_0 = (byte)int_1;
		arrayList_0 = new ArrayList();
	}

	internal void method_0(int int_1, int int_2)
	{
		int_0 = int_1;
		short_0 = (short)int_2;
		short_1 = -1;
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			CellArea cellArea = (CellArea)arrayList_0[i];
			if (int_1 >= cellArea.StartRow && int_1 <= cellArea.EndRow && int_2 >= cellArea.StartColumn && int_2 <= cellArea.EndColumn)
			{
				short_1 = (short)i;
				break;
			}
		}
		if (short_1 == -1)
		{
			CellArea cellArea2 = default(CellArea);
			cellArea2.StartRow = int_1;
			cellArea2.EndRow = int_1;
			cellArea2.StartColumn = int_2;
			cellArea2.EndColumn = int_2;
			short_1 = (short)arrayList_0.Count;
			arrayList_0.Add(cellArea2);
		}
	}

	[SpecialName]
	internal byte method_1()
	{
		return byte_0;
	}

	[SpecialName]
	internal void method_2(byte byte_1)
	{
		byte_0 = byte_1;
	}

	[SpecialName]
	public ArrayList method_3()
	{
		return arrayList_0;
	}

	[SpecialName]
	public void method_4(ArrayList arrayList_1)
	{
		arrayList_0 = arrayList_1;
	}

	[SpecialName]
	internal int method_5()
	{
		return int_0;
	}

	[SpecialName]
	internal void method_6(int int_1)
	{
		int_0 = int_1;
	}

	[SpecialName]
	internal int method_7()
	{
		return short_0;
	}

	[SpecialName]
	internal void method_8(int int_1)
	{
		short_0 = (short)int_1;
	}

	[SpecialName]
	internal int method_9()
	{
		return short_1;
	}

	[SpecialName]
	internal void method_10(int int_1)
	{
		short_1 = (short)int_1;
	}

	internal void Copy(Class1732 class1732_0)
	{
		short_0 = class1732_0.short_0;
		short_1 = class1732_0.short_1;
		int_0 = class1732_0.int_0;
		byte_0 = class1732_0.byte_0;
		for (int i = 0; i < class1732_0.arrayList_0.Count; i++)
		{
			arrayList_0.Add((CellArea)class1732_0.arrayList_0[i]);
		}
	}
}
