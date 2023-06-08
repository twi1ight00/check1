using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Aspose.Cells;
using Aspose.Cells.Pivot;
using ns2;

namespace ns45;

internal class Class1140 : CollectionBase
{
	public byte[] this[int int_0] => (byte[])base.InnerList[int_0];

	internal bool DisplayImmediateItems
	{
		get
		{
			return (method_2() & 0x100) != 0;
		}
		set
		{
			if (value)
			{
				method_3(method_2() | 0x100u);
			}
			else
			{
				method_3(method_2() & 0xFFFFFEFFu);
			}
		}
	}

	internal void Add(byte[] byte_0)
	{
		base.InnerList.Add(byte_0);
	}

	internal void method_0(Class1141 class1141_0)
	{
		byte[] array = null;
		array = new byte[8] { 3, 0, 1, 0, 0, 0, 0, 0 };
		Array.Copy(BitConverter.GetBytes(class1141_0.int_6), 0, array, 2, 4);
		base.InnerList.Add(array);
		array = new byte[24];
		array[0] = 3;
		array[1] = 2;
		byte[] array2 = array;
		byte[] array3 = array;
		byte[] array4 = array;
		array[11] = byte.MaxValue;
		array4[10] = byte.MaxValue;
		array3[9] = byte.MaxValue;
		array2[8] = byte.MaxValue;
		array[12] = 2;
		DateTime dateTime_ = class1141_0.dateTime_0;
		Array.Copy(BitConverter.GetBytes(CellsHelper.GetDoubleFromDateTime(dateTime_, date1904: false)), 0, array, 14, 8);
		base.InnerList.Add(array);
		array = new byte[8] { 3, 255, 0, 0, 0, 0, 0, 0 };
		base.InnerList.Add(array);
	}

	internal void method_1(PivotTable pivotTable_0)
	{
		byte[] array = null;
		string name = pivotTable_0.Name;
		int num = 10 + Class1677.smethod_29(name);
		array = new byte[num];
		Array.Copy(BitConverter.GetBytes((short)name.Length), 0, array, 2, 2);
		Array.Copy(BitConverter.GetBytes((short)name.Length), 0, array, 8, 2);
		Class937.smethod_4(array, 10, name);
		base.InnerList.Add(array);
		array = new byte[8] { 0, 2, 1, 65, 0, 0, 0, 0 };
		base.InnerList.Add(array);
		array = new byte[8] { 0, 255, 0, 0, 0, 0, 0, 0 };
		base.InnerList.Add(array);
	}

	[SpecialName]
	internal uint method_2()
	{
		foreach (byte[] inner in base.InnerList)
		{
			if (inner[0] == 0 && inner[1] == 2)
			{
				return BitConverter.ToUInt32(inner, 2);
			}
		}
		return 16641u;
	}

	[SpecialName]
	internal void method_3(uint uint_0)
	{
		int num = -1;
		byte[] array = null;
		int num2 = 0;
		while (true)
		{
			if (num2 < base.InnerList.Count)
			{
				array = (byte[])base.InnerList[num2];
				if (array[0] == 0 && array[1] == 2)
				{
					if (array[1] == 2)
					{
						break;
					}
					if (array[1] == byte.MaxValue)
					{
						num = num2;
					}
				}
				num2++;
				continue;
			}
			array = new byte[8] { 0, 2, 1, 65, 0, 0, 0, 0 };
			Array.Copy(BitConverter.GetBytes(uint_0), 0, array, 2, 4);
			if (num != -1)
			{
				base.InnerList.Insert(num, array);
				return;
			}
			base.InnerList.Add(array);
			array = new byte[8] { 0, 255, 0, 0, 0, 0, 0, 0 };
			base.InnerList.Add(array);
			return;
		}
		Array.Copy(BitConverter.GetBytes(uint_0), 0, array, 2, 4);
	}

	internal void Copy(Class1140 class1140_0)
	{
		for (int i = 0; i < class1140_0.Count; i++)
		{
			byte[] array = class1140_0[i];
			byte[] array2 = new byte[array.Length];
			Array.Copy(array, array2, array.Length);
			Add(array2);
		}
	}
}
