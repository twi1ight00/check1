using System;
using System.Text;
using Aspose.Cells.Pivot;
using ns2;
using ns45;
using ns59;

namespace ns28;

internal class Class1157
{
	internal static void smethod_0(Class1725 class1725_0, byte[] byte_0)
	{
		byte[] array = new byte[byte_0.Length + 8];
		array[4] = 100;
		array[0] = 100;
		array[5] = 8;
		array[1] = 8;
		Array.Copy(BitConverter.GetBytes((ushort)(byte_0.Length + 4)), 0, array, 2, 2);
		Array.Copy(byte_0, 0, array, 8, byte_0.Length);
		class1725_0.method_3(array);
	}

	internal static int smethod_1(byte[] byte_0, int int_0, byte byte_1, byte byte_2, object object_0, double double_0)
	{
		int num = int_0;
		byte_0[int_0++] = 100;
		byte_0[int_0++] = 8;
		int_0 += 2;
		byte_0[int_0++] = 100;
		byte_0[int_0++] = 8;
		byte_0[int_0++] = 0;
		byte_0[int_0++] = 0;
		byte_0[int_0++] = byte_1;
		byte_0[int_0++] = byte_2;
		switch (byte_1)
		{
		case 23:
		{
			byte b = byte_2;
			if (b == 25 && object_0 is PivotField)
			{
				PivotField pivotField = (PivotField)object_0;
				int num3 = 0;
				if (!pivotField.IsIncludeNewItemsInFilter)
				{
					num3 = 1;
				}
				int num4 = 0;
				if (pivotField.ShowCompact)
				{
					num4 = 1;
				}
				byte_0[int_0++] = (byte)((num4 << 3) + (num3 << 5));
				int_0 += 5;
			}
			break;
		}
		case 3:
			switch (byte_2)
			{
			case byte.MaxValue:
				byte_0[int_0] = 0;
				int_0 += 6;
				break;
			case 52:
				byte_0[int_0] = 1;
				int_0 += 6;
				break;
			case 0:
				Array.Copy(BitConverter.GetBytes((int)object_0), 0, byte_0, int_0, 4);
				int_0 += 6;
				break;
			}
			break;
		case 0:
			switch (byte_2)
			{
			case 30:
				int_0 += 6;
				byte_0[int_0++] = 50;
				int_0++;
				if (object_0 != null)
				{
					string text2 = (string)object_0;
					Array.Copy(BitConverter.GetBytes((short)text2.Length), 0, byte_0, int_0, 2);
					int_0 += 2;
					byte[] bytes = Encoding.Unicode.GetBytes(text2);
					Array.Copy(bytes, 0, byte_0, int_0, bytes.Length);
					int_0 += bytes.Length;
				}
				else
				{
					int_0 += 2;
				}
				break;
			case 25:
				byte_0[int_0++] = 159;
				byte_0[int_0++] = 0;
				byte_0[int_0++] = 64;
				int_0 += 3;
				break;
			case 0:
				if (object_0 is string)
				{
					string text = (string)object_0;
					Array.Copy(BitConverter.GetBytes((short)text.Length), 0, byte_0, int_0, 2);
					Array.Copy(BitConverter.GetBytes(0), 0, byte_0, int_0 + 2, 4);
					int_0 += 6;
					Array.Copy(BitConverter.GetBytes((short)text.Length), 0, byte_0, int_0, 2);
					int_0 += 2;
					int_0 += Class937.smethod_4(byte_0, int_0, text);
				}
				break;
			default:
				int_0 += 6;
				break;
			case 2:
				if (object_0 is PivotTable)
				{
					PivotTable pivotTable = (PivotTable)object_0;
					int num2 = 0;
					if (!pivotTable.EnableFieldList)
					{
						num2 = 1;
					}
					byte_0[int_0++] = 4;
					byte_0[int_0++] = (byte)(65 + (num2 << 2));
					byte_0[int_0++] = 64;
					int_0 += 3;
				}
				break;
			}
			break;
		}
		Array.Copy(BitConverter.GetBytes((short)(int_0 - num - 4)), 0, byte_0, num + 2, 2);
		return int_0 - num;
	}

	internal static int smethod_2(byte byte_0, byte byte_1, object object_0)
	{
		int num = 10;
		switch (byte_0)
		{
		case 23:
		{
			byte b = byte_1;
			if (b == 25)
			{
				num += 6;
			}
			break;
		}
		case 3:
			num += 6;
			if (byte_1 == 2)
			{
				num += 16;
			}
			break;
		case 0:
			switch (byte_1)
			{
			case 0:
				num += 8 + Class1677.smethod_29((string)object_0);
				break;
			case 2:
			case 25:
			case byte.MaxValue:
				num += 6;
				break;
			case 30:
				num = ((object_0 != null) ? (num + (10 + 2 * ((string)object_0).Length)) : (num + 10));
				break;
			}
			break;
		}
		return num;
	}

	internal static void smethod_3(Class1725 class1725_0, PivotTable pivotTable_0)
	{
		smethod_5(class1725_0, 0, 0, pivotTable_0, null, null);
		smethod_5(class1725_0, 0, 2, pivotTable_0, null, null);
		smethod_5(class1725_0, 0, 25, pivotTable_0, null, null);
		smethod_5(class1725_0, 0, 30, pivotTable_0, null, null);
		smethod_5(class1725_0, 0, 255, pivotTable_0, null, null);
	}

	internal static void smethod_4(Class1725 class1725_0, Class1141 class1141_0)
	{
		smethod_5(class1725_0, 3, 0, null, class1141_0, null);
		smethod_5(class1725_0, 3, 52, null, class1141_0, null);
		smethod_5(class1725_0, 3, 255, null, class1141_0, null);
	}

	internal static void smethod_5(Class1725 class1725_0, int int_0, int int_1, PivotTable pivotTable_0, Class1141 class1141_0, PivotField pivotField_0)
	{
		switch (int_0)
		{
		case 23:
			if (int_1 == 25)
			{
				smethod_6(class1725_0, pivotField_0);
			}
			break;
		case 3:
			switch (int_1)
			{
			case 255:
				smethod_14(class1725_0);
				break;
			case 52:
				smethod_9(class1725_0);
				break;
			case 0:
				smethod_8(class1725_0, class1141_0.int_6);
				break;
			}
			break;
		case 0:
			switch (int_1)
			{
			case 25:
				smethod_12(class1725_0);
				break;
			case 0:
				smethod_7(class1725_0, pivotTable_0.Name);
				break;
			case 2:
				smethod_11(class1725_0, pivotTable_0);
				break;
			case 255:
				smethod_13(class1725_0);
				break;
			case 30:
				smethod_10(class1725_0, pivotTable_0.PivotTableStyleName);
				break;
			}
			break;
		}
	}

	internal static void smethod_6(Class1725 class1725_0, PivotField pivotField_0)
	{
		byte[] array = new byte[smethod_2(23, 25, null)];
		_ = 0 + smethod_1(array, 0, 23, 25, pivotField_0, 0.0);
		class1725_0.method_3(array);
	}

	internal static void smethod_7(Class1725 class1725_0, string string_0)
	{
		byte[] array = new byte[smethod_2(0, 0, string_0)];
		_ = 0 + smethod_1(array, 0, 0, 0, string_0, 0.0);
		class1725_0.method_3(array);
	}

	internal static void smethod_8(Class1725 class1725_0, int int_0)
	{
		byte[] array = new byte[smethod_2(3, 0, int_0)];
		_ = 0 + smethod_1(array, 0, 3, 0, int_0, 0.0);
		class1725_0.method_3(array);
	}

	internal static void smethod_9(Class1725 class1725_0)
	{
		byte[] array = new byte[smethod_2(3, 52, null)];
		_ = 0 + smethod_1(array, 0, 3, 52, null, 0.0);
		class1725_0.method_3(array);
	}

	internal static void smethod_10(Class1725 class1725_0, string string_0)
	{
		byte[] array = new byte[smethod_2(0, 30, string_0)];
		_ = 0 + smethod_1(array, 0, 0, 30, string_0, 0.0);
		class1725_0.method_3(array);
	}

	internal static void smethod_11(Class1725 class1725_0, PivotTable pivotTable_0)
	{
		byte[] array = new byte[smethod_2(0, 2, null)];
		_ = 0 + smethod_1(array, 0, 0, 2, pivotTable_0, 0.0);
		class1725_0.method_3(array);
	}

	internal static void smethod_12(Class1725 class1725_0)
	{
		byte[] array = new byte[smethod_2(0, 25, null)];
		_ = 0 + smethod_1(array, 0, 0, 25, null, 0.0);
		class1725_0.method_3(array);
	}

	internal static void smethod_13(Class1725 class1725_0)
	{
		byte[] array = new byte[smethod_2(0, byte.MaxValue, null)];
		_ = 0 + smethod_1(array, 0, 0, byte.MaxValue, null, 0.0);
		class1725_0.method_3(array);
	}

	internal static void smethod_14(Class1725 class1725_0)
	{
		byte[] array = new byte[smethod_2(3, byte.MaxValue, null)];
		_ = 0 + smethod_1(array, 0, 3, byte.MaxValue, null, 0.0);
		class1725_0.method_3(array);
	}
}
