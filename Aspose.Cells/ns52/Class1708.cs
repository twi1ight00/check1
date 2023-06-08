using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using ns12;
using ns2;

namespace ns52;

internal class Class1708
{
	internal ArrayList arrayList_0;

	private MsoDrawingType msoDrawingType_0;

	private bool bool_0;

	internal byte[] byte_0;

	private bool bool_1;

	private bool bool_2 = true;

	private bool bool_3 = true;

	private bool bool_4;

	internal bool IsLocked
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	internal bool IsPrinted
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	internal MsoDrawingType Type => msoDrawingType_0;

	internal Class1708(MsoDrawingType msoDrawingType_1)
	{
		msoDrawingType_0 = msoDrawingType_1;
		bool_0 = true;
		bool_1 = true;
	}

	internal void method_0(WorksheetCollection worksheetCollection_0, Worksheet worksheet_0, string string_0)
	{
		if (arrayList_0 != null && arrayList_0.Count > 0)
		{
			for (int i = 0; i < arrayList_0.Count; i++)
			{
				byte[] array = (byte[])arrayList_0[i];
				if (array[0] == 4)
				{
					return;
				}
			}
		}
		int num = string_0.LastIndexOf("!");
		int num2 = 0;
		int num3 = 0;
		int num4 = -1;
		int num5 = worksheetCollection_0.method_36();
		if (num == -1)
		{
			num2 = worksheetCollection_0.method_32().method_10(worksheetCollection_0.method_36(), 65534, 65534);
			num4 = -1;
		}
		else
		{
			string string_ = string_0.Substring(0, num);
			string_0 = string_0.Substring(num + 1);
			int[] array2 = Class1660.smethod_3(worksheetCollection_0, string_);
			if (array2 == null)
			{
				return;
			}
			num2 = array2[0];
			num5 = array2[1];
			num4 = array2[2];
		}
		if (num5 == worksheetCollection_0.method_36())
		{
			num3 = worksheetCollection_0.Names.method_0(num4, string_0);
			Name name = worksheetCollection_0.Names[num3];
			name.Type = Enum184.const_1;
			name.method_22(bool_0: true);
		}
		else
		{
			Class1718 @class = worksheetCollection_0.method_39()[num5];
			num3 = @class.method_2(worksheetCollection_0, string_0);
		}
		byte[] destinationArray = new byte[18]
		{
			4, 0, 14, 0, 7, 0, 0, 0, 0, 0,
			57, 0, 0, 0, 0, 0, 0, 0
		};
		Array.Copy(BitConverter.GetBytes(num2), 0, destinationArray, 11, 2);
		Array.Copy(BitConverter.GetBytes(num3 + 1), 0, destinationArray, 11 + 2, 2);
		byte_0 = destinationArray;
	}

	internal string method_1(WorksheetCollection worksheetCollection_0)
	{
		if (arrayList_0 != null && arrayList_0.Count > 0)
		{
			for (int i = 0; i < arrayList_0.Count; i++)
			{
				byte[] array = (byte[])arrayList_0[i];
				if (array[0] != 4)
				{
					continue;
				}
				BitConverter.ToUInt16(array, 4);
				int num = 10;
				int num2 = 0;
				if (array[10] == 25 && array[num + 1] == 64)
				{
					num += 4;
				}
				switch (array[num] & 0x1F)
				{
				case 25:
				{
					num++;
					int int_ = BitConverter.ToUInt16(array, num);
					num += 2;
					int num3 = worksheetCollection_0.method_32().method_12(int_);
					num2 = BitConverter.ToUInt16(array, num) - 1;
					if (num3 == worksheetCollection_0.method_36())
					{
						Name name2 = worksheetCollection_0.Names[num2];
						return "[0]!" + name2.Text;
					}
					Class1653 @class = (Class1653)worksheetCollection_0.method_39()[num3].method_0()[num2];
					if (num3 < worksheetCollection_0.method_36())
					{
						num3++;
					}
					return "[" + num3 + "]!" + @class.Name;
				}
				case 3:
				{
					num++;
					num2 = BitConverter.ToUInt16(array, num) - 1;
					Name name = worksheetCollection_0.Names[num2];
					return "[0]!" + name.Text;
				}
				}
			}
		}
		return null;
	}

	internal void Copy(Class1708 class1708_0)
	{
		bool_0 = class1708_0.bool_0;
		bool_1 = class1708_0.bool_1;
		bool_2 = class1708_0.bool_2;
		bool_3 = class1708_0.bool_3;
		if (class1708_0.arrayList_0 == null)
		{
			return;
		}
		arrayList_0 = new ArrayList();
		byte[] array = null;
		foreach (byte[] item in class1708_0.arrayList_0)
		{
			array = new byte[item.Length];
			Array.Copy(item, 0, array, 0, item.Length);
			arrayList_0.Add(array);
		}
	}

	[SpecialName]
	internal bool method_2()
	{
		return bool_2;
	}

	[SpecialName]
	internal void method_3(bool bool_5)
	{
		bool_2 = bool_5;
	}

	[SpecialName]
	internal bool method_4()
	{
		return bool_3;
	}

	[SpecialName]
	internal void method_5(bool bool_5)
	{
		bool_3 = bool_5;
	}

	[SpecialName]
	internal bool method_6()
	{
		return bool_4;
	}

	[SpecialName]
	internal void method_7(bool bool_5)
	{
		bool_4 = bool_5;
	}
}
