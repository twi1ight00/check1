using System;
using Aspose.Cells;
using Aspose.Cells.Charts;
using ns59;
using ns7;

namespace ns27;

internal class Class592 : Class538
{
	internal Class592()
	{
		method_2(4177);
	}

	internal void method_4(int int_0)
	{
		method_0(8);
		byte_0 = new byte[8];
		byte_0[0] = (byte)int_0;
		byte_0[1] = 1;
	}

	internal void method_5()
	{
		method_0(8);
		byte_0 = new byte[8];
		byte_0[1] = 1;
	}

	internal void method_6(byte[] byte_1)
	{
		if (byte_1 == null)
		{
			method_0(8);
			byte_0 = new byte[8];
			byte_0[1] = 1;
		}
		else
		{
			method_0((short)(byte_1.Length + 6));
			byte_0 = new byte[base.Length];
			byte_0[1] = 2;
			Array.Copy(byte_1, 0, byte_0, 6, byte_1.Length);
		}
	}

	internal void method_7(DataLabels dataLabels_0, WorksheetCollection worksheetCollection_0, FileFormatType fileFormatType_1, byte[] byte_1)
	{
		method_0(6);
		if (byte_1 != null && byte_1.Length != 0)
		{
			method_0((short)(base.Length + byte_1.Length));
		}
		else
		{
			method_0((short)(base.Length + 2));
		}
		byte_0 = new byte[base.Length];
		byte_0[1] = 1;
		if (!dataLabels_0.NumberFormatLinked || dataLabels_0.ShowPercentage)
		{
			if (dataLabels_0.NumberFormat != null && dataLabels_0.NumberFormat != "")
			{
				byte_0[2] = 1;
				ushort value = (ushort)dataLabels_0.method_50();
				Array.Copy(BitConverter.GetBytes(value), 0, byte_0, 4, 2);
			}
			else if (dataLabels_0.method_50() > 0)
			{
				byte_0[2] = 1;
				Array.Copy(BitConverter.GetBytes(dataLabels_0.Number), 0, byte_0, 4, 2);
			}
			if (dataLabels_0.ShowPercentage && byte_0[2] != 1)
			{
				byte_0[2] = 1;
				byte_0[4] = 9;
			}
		}
		if (byte_1 != null && byte_1.Length != 0)
		{
			byte_0[1] = 2;
			Array.Copy(byte_1, 0, byte_0, 6, byte_1.Length);
		}
	}

	internal void method_8(Chart chart_0, Series series_0, WorksheetCollection worksheetCollection_0, int int_0, Class1725 class1725_0)
	{
		object obj = series_0.method_13();
		if (obj != null && (!(obj is string) || !((string)obj == "")))
		{
			if (obj is string)
			{
				method_0(8);
				byte_0 = new byte[8];
				byte_0[1] = 1;
				vmethod_0(class1725_0);
				method_11(worksheetCollection_0.method_23(), (string)obj, class1725_0);
			}
			else if (obj is byte[])
			{
				byte[] array = (byte[])obj;
				method_0((short)(6 + array.Length));
				byte_0 = new byte[base.Length];
				byte_0[1] = 2;
				Array.Copy(array, 0, byte_0, 6, array.Length);
				vmethod_0(class1725_0);
				int num = 2;
				int int_ = BitConverter.ToUInt16(array, 2 + 1);
				int_0 = worksheetCollection_0.method_32().method_13(int_);
				if (int_0 >= 0 && int_0 < worksheetCollection_0.Count)
				{
					Worksheet worksheet = worksheetCollection_0[int_0];
					Cells cells = worksheet.Cells;
					int int_2 = BitConverter.ToUInt16(array, num + 3);
					byte int_3 = array[num + 5];
					Cell cell = cells.GetCell(int_2, int_3, bool_2: false);
					string stringValue = cell.StringValue;
					method_11(worksheetCollection_0.method_23(), stringValue, class1725_0);
				}
				else if (series_0.string_0 != null)
				{
					method_11(worksheetCollection_0.method_23(), series_0.string_0, class1725_0);
				}
			}
		}
		else
		{
			method_0(8);
			byte_0 = new byte[8];
			byte_0[1] = 1;
			vmethod_0(class1725_0);
		}
	}

	internal void method_9(byte byte_1, Interface45 interface45_0, int int_0, Class1725 class1725_0, int int_1)
	{
		class1725_0.method_8(4177);
		if (interface45_0 == null)
		{
			class1725_0.method_8(8);
			class1725_0.WriteByte(byte_1);
			if (byte_1 != 2)
			{
				class1725_0.WriteByte(1);
			}
			else
			{
				class1725_0.WriteByte(0);
			}
			class1725_0.method_8(0);
			class1725_0.method_5(0);
			return;
		}
		switch (interface45_0.imethod_13())
		{
		default:
			throw new Exception("Invalid ASeries values/xvalues/bubble sizes.");
		case Enum126.const_2:
			class1725_0.method_8(15);
			class1725_0.WriteByte(byte_1);
			class1725_0.WriteByte(2);
			if (byte_1 == 1)
			{
				class1725_0.method_8(0);
				class1725_0.method_7((short)int_1);
			}
			else
			{
				class1725_0.method_5(0);
			}
			class1725_0.method_3(interface45_0.imethod_4());
			break;
		case Enum126.const_3:
			class1725_0.method_8(19);
			class1725_0.WriteByte(byte_1);
			class1725_0.WriteByte(2);
			if (byte_1 == 1)
			{
				class1725_0.method_8(0);
				class1725_0.method_7((short)int_1);
			}
			else
			{
				class1725_0.method_5(0);
			}
			class1725_0.method_3(interface45_0.imethod_4());
			break;
		case Enum126.const_4:
		case Enum126.const_5:
		{
			byte[] array = interface45_0.imethod_4();
			class1725_0.method_7((short)(array.Length + 6));
			class1725_0.WriteByte(byte_1);
			class1725_0.WriteByte(2);
			class1725_0.method_5(0);
			class1725_0.method_3(array);
			break;
		}
		case Enum126.const_1:
		case Enum126.const_6:
			class1725_0.method_8(8);
			class1725_0.WriteByte(byte_1);
			class1725_0.WriteByte(1);
			class1725_0.method_8(0);
			class1725_0.method_5(0);
			break;
		}
	}

	internal void method_10(Chart chart_0, Series series_0, WorksheetCollection worksheetCollection_0, int int_0, Class1725 class1725_0)
	{
		method_8(chart_0, series_0, worksheetCollection_0, int_0, class1725_0);
		method_9(1, series_0.method_16(), int_0, class1725_0, series_0.int_2);
		method_9(2, series_0.method_18(), int_0, class1725_0, 0);
		if (ChartCollection.smethod_17(series_0.Type))
		{
			method_9(3, series_0.method_20(), int_0, class1725_0, 0);
		}
		else
		{
			method_9(3, null, int_0, class1725_0, 0);
		}
	}

	private void method_11(FileFormatType fileFormatType_1, string string_0, Class1725 class1725_0)
	{
		Class700 @class = new Class700(fileFormatType_1, string_0);
		@class.vmethod_0(class1725_0);
	}
}
