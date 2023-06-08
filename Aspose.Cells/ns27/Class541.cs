using System;
using System.Text;
using Aspose.Cells;

namespace ns27;

internal class Class541 : Class538
{
	internal Class541()
	{
		method_2(2175);
		method_0(12);
	}

	internal void method_4(FilterColumn filterColumn_0, object object_0)
	{
		string text = object_0.ToString();
		byte[] bytes = Encoding.Unicode.GetBytes(text);
		method_0((short)(base.Length + (short)(11 + bytes.Length)));
		byte_0 = new byte[base.Length];
		int num = method_7(filterColumn_0.method_4().AutoFilter.method_7());
		byte_0[num] = 6;
		byte_0[num + 1] = 2;
		byte_0[num + 2] = (byte)(bytes.Length / 2);
		if (text.IndexOf('?') < 0 && text.IndexOf('*') < 0)
		{
			byte_0[num + 3] = 1;
		}
		num += 10;
		byte_0[num] = 1;
		num++;
		Array.Copy(bytes, 0, byte_0, num, bytes.Length);
	}

	internal void method_5(FilterColumn filterColumn_0, DateTimeGroupItem dateTimeGroupItem_0)
	{
		method_0((short)(base.Length + 24));
		byte_0 = new byte[base.Length];
		int num = method_7(filterColumn_0.method_4().AutoFilter.method_7());
		Array.Copy(BitConverter.GetBytes((short)dateTimeGroupItem_0.Year), 0, byte_0, num, 2);
		Array.Copy(BitConverter.GetBytes((short)dateTimeGroupItem_0.Month), 0, byte_0, num + 2, 2);
		Array.Copy(BitConverter.GetBytes(dateTimeGroupItem_0.Day), 0, byte_0, num + 4, 4);
		Array.Copy(BitConverter.GetBytes((short)dateTimeGroupItem_0.Hour), 0, byte_0, num + 8, 2);
		Array.Copy(BitConverter.GetBytes((short)dateTimeGroupItem_0.Minute), 0, byte_0, num + 10, 2);
		Array.Copy(BitConverter.GetBytes((short)dateTimeGroupItem_0.Second), 0, byte_0, num + 12, 2);
		num += 20;
		int num2 = 0;
		switch (dateTimeGroupItem_0.DateTimeGroupingType)
		{
		case DateTimeGroupingType.Day:
			num2 = 2;
			break;
		case DateTimeGroupingType.Hour:
			num2 = 3;
			break;
		case DateTimeGroupingType.Minute:
			num2 = 4;
			break;
		case DateTimeGroupingType.Month:
			num2 = 1;
			break;
		case DateTimeGroupingType.Second:
			num2 = 5;
			break;
		}
		if (num2 != 0)
		{
			Array.Copy(BitConverter.GetBytes(dateTimeGroupItem_0.Day), 0, byte_0, num, 4);
		}
	}

	internal void method_6(FilterColumn filterColumn_0)
	{
		method_0((short)(base.Length + 10));
		byte_0 = new byte[base.Length];
		int num = method_7(filterColumn_0.method_4().AutoFilter.method_7());
		byte_0[num] = 12;
		byte_0[num + 1] = 2;
	}

	private int method_7(CellArea cellArea_0)
	{
		byte_0[0] = 127;
		byte_0[1] = 8;
		byte_0[2] = 1;
		Array.Copy(BitConverter.GetBytes(cellArea_0.StartRow), 0, byte_0, 4, 2);
		Array.Copy(BitConverter.GetBytes(cellArea_0.EndRow), 0, byte_0, 6, 2);
		Array.Copy(BitConverter.GetBytes(cellArea_0.StartColumn), 0, byte_0, 8, 2);
		Array.Copy(BitConverter.GetBytes(cellArea_0.EndColumn), 0, byte_0, 10, 2);
		return 12;
	}
}
