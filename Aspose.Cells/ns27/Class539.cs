using System;
using Aspose.Cells;
using ns59;

namespace ns27;

internal class Class539 : Class538
{
	private Class538[] class538_0;

	internal Class539()
	{
		method_2(2174);
	}

	internal override void vmethod_0(Class1725 class1725_0)
	{
		base.vmethod_0(class1725_0);
		if (class538_0 != null)
		{
			Class538[] array = class538_0;
			foreach (Class538 @class in array)
			{
				@class.vmethod_0(class1725_0);
			}
		}
	}

	internal void method_4(FilterColumn filterColumn_0)
	{
		class538_0 = null;
		MultipleFilterCollection multipleFilterCollection = (MultipleFilterCollection)filterColumn_0.Filter;
		method_0(60);
		byte_0 = new byte[base.Length];
		int num = method_5(filterColumn_0);
		byte_0[num] = (byte)filterColumn_0.FieldIndex;
		num += 2;
		if (filterColumn_0.method_0())
		{
			byte_0[num] = 1;
		}
		num += 4;
		num += 8;
		int count = multipleFilterCollection.Count;
		int num2 = 0;
		foreach (object item in multipleFilterCollection)
		{
			if (item is DateTimeGroupItem)
			{
				num2++;
			}
		}
		count -= num2;
		if (multipleFilterCollection.MatchBlank)
		{
			count++;
		}
		Array.Copy(BitConverter.GetBytes(count), 0, byte_0, num, 4);
		num += 4;
		Array.Copy(BitConverter.GetBytes(num2), 0, byte_0, num, 4);
		num += 4;
		byte_0[num] = 8;
		num++;
		num += 5;
		Array.Copy(BitConverter.GetBytes(-1), 0, byte_0, num, 4);
		class538_0 = new Class538[count + num2];
		int num3 = 0;
		foreach (object item2 in multipleFilterCollection)
		{
			if (!(item2 is DateTimeGroupItem))
			{
				Class541 @class = new Class541();
				@class.method_4(filterColumn_0, item2);
				class538_0[num3++] = @class;
			}
		}
		if (multipleFilterCollection.MatchBlank)
		{
			Class541 class2 = new Class541();
			class2.method_6(filterColumn_0);
			class538_0[num3++] = class2;
		}
		foreach (object item3 in multipleFilterCollection)
		{
			if (item3 is DateTimeGroupItem)
			{
				Class541 class3 = new Class541();
				class3.method_5(filterColumn_0, (DateTimeGroupItem)item3);
				class538_0[num3++] = class3;
			}
		}
	}

	private int method_5(FilterColumn filterColumn_0)
	{
		byte_0[0] = 126;
		byte_0[1] = 8;
		byte_0[2] = 1;
		CellArea cellArea = filterColumn_0.method_4().AutoFilter.method_7();
		Array.Copy(BitConverter.GetBytes(cellArea.StartRow), 0, byte_0, 4, 2);
		Array.Copy(BitConverter.GetBytes(cellArea.EndRow), 0, byte_0, 6, 2);
		Array.Copy(BitConverter.GetBytes(cellArea.StartColumn), 0, byte_0, 8, 2);
		Array.Copy(BitConverter.GetBytes(cellArea.EndColumn), 0, byte_0, 10, 2);
		return 12;
	}
}
