using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using Aspose.Cells;
using Aspose.Cells.Pivot;
using ns1;
using ns16;
using ns2;
using ns28;
using ns59;

namespace ns45;

internal class Class1161
{
	private Class1141 class1141_0;

	internal string string_0;

	internal ushort ushort_0;

	internal ArrayList arrayList_0;

	internal string string_1;

	internal byte[] byte_0;

	internal ArrayList arrayList_1;

	internal ushort ushort_1;

	internal int int_0;

	internal int int_1;

	internal SxRng sxRng_0;

	internal int int_2;

	internal bool bool_0;

	internal bool bool_1;

	private byte byte_1;

	internal int Index
	{
		get
		{
			int num = 0;
			foreach (Class1161 item in class1141_0.arrayList_0)
			{
				if (item != this)
				{
					num++;
					continue;
				}
				return num;
			}
			return 0;
		}
	}

	[SpecialName]
	internal Class1141 method_0()
	{
		return class1141_0;
	}

	internal Class1161(Class1141 class1141_1)
	{
		class1141_0 = class1141_1;
		ushort_0 = 1025;
	}

	internal Class1161(Class1141 class1141_1, string string_2, bool bool_2)
	{
		if (string_2 != null && !(string_2 == ""))
		{
			class1141_0 = class1141_1;
			if (bool_2)
			{
				ushort_0 = 1025;
			}
			else
			{
				ushort_0 = 1026;
			}
			string_0 = string_2;
			return;
		}
		throw new CellsException(ExceptionType.PivotTable, "The PivotTable field name is invalid.");
	}

	internal Class1161(Class1141 class1141_1, string string_2, string string_3)
	{
		if (string_2 == null || string_2 == "")
		{
			throw new CellsException(ExceptionType.PivotTable, "The PivotTable field name is invalid.");
		}
		class1141_0 = class1141_1;
		ushort_0 = 33829;
		string_0 = string_2;
		string_1 = string_3;
		arrayList_1 = new ArrayList();
	}

	[SpecialName]
	internal string method_1()
	{
		try
		{
			if (byte_0 == null)
			{
				return string_1;
			}
			WorksheetCollection worksheetCollection_ = class1141_0.class1142_0.worksheetCollection_0;
			worksheetCollection_.method_3(class1141_0);
			string result = worksheetCollection_.method_4().method_3(0, byte_0, 0, 0, bool_0: false);
			worksheetCollection_.method_3(null);
			return result;
		}
		catch
		{
			return string_1;
		}
	}

	[SpecialName]
	internal bool method_2()
	{
		return (ushort_0 & 1) != 0;
	}

	[SpecialName]
	internal void method_3(bool bool_2)
	{
		if (bool_2)
		{
			ushort_0 &= 65532;
			ushort_0 |= 1;
		}
		else
		{
			ushort_0 &= 65532;
			ushort_0 |= 2;
		}
	}

	[SpecialName]
	internal bool method_4()
	{
		return (ushort_0 & 0x200) != 0;
	}

	[SpecialName]
	internal bool method_5()
	{
		if (!method_12())
		{
			return !method_14();
		}
		return false;
	}

	[SpecialName]
	internal bool method_6()
	{
		return (ushort_0 & 0x20) != 0;
	}

	[SpecialName]
	internal void method_7(bool bool_2)
	{
		if (bool_2)
		{
			ushort_0 |= 288;
		}
		else
		{
			ushort_0 &= 65439;
		}
	}

	[SpecialName]
	internal bool method_8()
	{
		return (ushort_0 & 0x40) != 0;
	}

	[SpecialName]
	internal void method_9(bool bool_2)
	{
		if (bool_2)
		{
			ushort_0 |= 352;
		}
		else
		{
			ushort_0 &= 65471;
		}
	}

	[SpecialName]
	internal bool method_10()
	{
		return (ushort_0 & 0x160) == 288;
	}

	[SpecialName]
	internal void method_11(bool bool_2)
	{
		if (bool_2)
		{
			ushort_0 &= 65471;
			ushort_0 |= 288;
		}
	}

	[SpecialName]
	internal bool method_12()
	{
		return (ushort_0 & 0x80) != 0;
	}

	[SpecialName]
	internal void method_13(bool bool_2)
	{
		if (bool_2)
		{
			ushort_0 |= 128;
		}
		else
		{
			ushort_0 &= 65407;
		}
	}

	[SpecialName]
	internal bool method_14()
	{
		return (ushort_0 & 0x800) != 0;
	}

	[SpecialName]
	internal void method_15(bool bool_2)
	{
		if (bool_2)
		{
			ushort_0 |= 2304;
		}
		else
		{
			ushort_0 &= 63487;
		}
	}

	[SpecialName]
	internal bool method_16()
	{
		return !method_14();
	}

	[SpecialName]
	internal bool method_17()
	{
		return (ushort_0 & 8) != 0;
	}

	[SpecialName]
	internal bool method_18()
	{
		return (ushort_0 & 0x8000) != 0;
	}

	[SpecialName]
	internal void method_19(bool bool_2)
	{
		if (bool_2)
		{
			ushort_0 |= 32768;
		}
		else
		{
			ushort_0 &= 32767;
		}
	}

	[SpecialName]
	internal bool method_20()
	{
		return (ushort_0 & 0x10) != 0;
	}

	[SpecialName]
	internal void method_21(bool bool_2)
	{
		if (bool_2)
		{
			ushort_0 |= 16;
		}
		else
		{
			ushort_0 &= 65519;
		}
	}

	[SpecialName]
	internal bool method_22()
	{
		return (ushort_0 & 0x9A0) == 2304;
	}

	[SpecialName]
	internal bool method_23()
	{
		return (ushort_0 & 0x9A0) == 288;
	}

	[SpecialName]
	internal bool method_24()
	{
		return (ushort_0 & 0x9A0) == 128;
	}

	[SpecialName]
	internal bool method_25()
	{
		if (!method_23() && !method_24())
		{
			return !method_22();
		}
		return false;
	}

	[SpecialName]
	internal bool method_26()
	{
		if (!method_22() && !method_23())
		{
			return true;
		}
		return method_29();
	}

	[SpecialName]
	internal bool method_27()
	{
		return (byte_1 & 0x10) != 0;
	}

	[SpecialName]
	internal void method_28(bool bool_2)
	{
		if (bool_2)
		{
			byte_1 |= 16;
		}
		else
		{
			byte_1 &= 239;
		}
	}

	[SpecialName]
	internal bool method_29()
	{
		if (arrayList_0 != null)
		{
			for (int i = 0; i < arrayList_0.Count; i++)
			{
				Class1158 @class = (Class1158)arrayList_0[i];
				if (@class == null || @class.object_0 == null)
				{
					return true;
				}
			}
		}
		return (byte_1 & 1) != 0;
	}

	[SpecialName]
	internal void method_30(bool bool_2)
	{
		if (bool_2)
		{
			byte_1 |= 1;
		}
		else
		{
			byte_1 &= 254;
		}
	}

	[SpecialName]
	internal bool method_31()
	{
		if (method_29())
		{
			if (arrayList_0 != null)
			{
				return arrayList_0.Count == 1;
			}
			return true;
		}
		return false;
	}

	[SpecialName]
	private int method_32()
	{
		int num = 0;
		if (arrayList_0 == null)
		{
			return num;
		}
		foreach (object item in arrayList_0)
		{
			if (item == null)
			{
				num += 4;
				continue;
			}
			object object_ = ((Class1158)item).object_0;
			if (object_ == null)
			{
				num += 4;
			}
			else if (object_ is string)
			{
				bool flag = false;
				num = ((!Class1673.smethod_9((string)object_, ref flag) || flag) ? (num + (6 + Class1677.smethod_29((string)object_))) : (num + 6));
			}
			else if (object_ is double)
			{
				num += 12;
			}
			else if (object_ is int)
			{
				num += 12;
			}
			else if (object_ is short)
			{
				num += 6;
			}
			else if (object_ is DateTime)
			{
				num += 12;
			}
			else if (object_ is bool)
			{
				num += 6;
			}
		}
		return num;
	}

	private int method_33(ArrayList arrayList_2)
	{
		int num = 0;
		if (arrayList_2 == null)
		{
			return num;
		}
		foreach (object item in arrayList_2)
		{
			if (item == null)
			{
				num += 4;
				continue;
			}
			object object_ = ((Class1158)item).object_0;
			if (object_ == null)
			{
				num += 4;
			}
			else if (object_ is string)
			{
				bool flag = false;
				num = ((!Class1673.smethod_9((string)object_, ref flag) || flag) ? (num + (6 + Class1677.smethod_29((string)object_))) : (num + 6));
			}
			else if (object_ is double)
			{
				num += 12;
			}
			else if (object_ is int)
			{
				num += 12;
			}
			else if (object_ is short)
			{
				num += 6;
			}
			else if (object_ is DateTime)
			{
				num += 12;
			}
			else if (object_ is bool)
			{
				num += 6;
			}
		}
		return num;
	}

	[SpecialName]
	private int method_34()
	{
		int num = 0;
		if (sxRng_0.arrayList_0 == null)
		{
			return num;
		}
		foreach (object item in sxRng_0.arrayList_0)
		{
			if (item == null)
			{
				num += 4;
				continue;
			}
			object object_ = ((Class1158)item).object_0;
			if (object_ == null)
			{
				num += 4;
			}
			else if (object_ is string)
			{
				bool flag = false;
				num = ((!Class1673.smethod_9((string)object_, ref flag) || flag) ? (num + (6 + Class1677.smethod_29((string)object_))) : (num + 6));
			}
			else if (object_ is double)
			{
				num += 12;
			}
			else if (object_ is int)
			{
				num += 12;
			}
			else if (object_ is short)
			{
				num += 6;
			}
			else if (object_ is DateTime)
			{
				num += 12;
			}
			else if (object_ is bool)
			{
				num += 6;
			}
		}
		return num;
	}

	internal void method_35(byte[] byte_2, ArrayList arrayList_2)
	{
		int num = 0;
		foreach (object item in arrayList_2)
		{
			if (item == null)
			{
				num += smethod_1(byte_2, num);
				continue;
			}
			object object_ = ((Class1158)item).object_0;
			if (object_ == null)
			{
				num += smethod_1(byte_2, num);
			}
			else if (object_ is string)
			{
				string text = (string)object_;
				string key;
				if ((key = text) != null)
				{
					if (Class1742.dictionary_54 == null)
					{
						Class1742.dictionary_54 = new Dictionary<string, int>(7)
						{
							{ "#DIV/0!", 0 },
							{ "#N/A", 1 },
							{ "#NAME?", 2 },
							{ "#NULL!", 3 },
							{ "#NUM!", 4 },
							{ "#REF!", 5 },
							{ "#VALUE!", 6 }
						};
					}
					if (Class1742.dictionary_54.TryGetValue(key, out var value))
					{
						switch (value)
						{
						case 0:
							num += smethod_0(byte_2, num, 7);
							continue;
						case 1:
							num += smethod_0(byte_2, num, 42);
							continue;
						case 2:
							num += smethod_0(byte_2, num, 29);
							continue;
						case 3:
							num += smethod_0(byte_2, num, 0);
							continue;
						case 4:
							num += smethod_0(byte_2, num, 36);
							continue;
						case 5:
							num += smethod_0(byte_2, num, 23);
							continue;
						case 6:
							num += smethod_0(byte_2, num, 15);
							continue;
						}
					}
				}
				num += smethod_2(byte_2, num, text);
			}
			else if (object_ is double)
			{
				num += smethod_3(byte_2, num, (double)object_);
			}
			else if (object_ is short)
			{
				num += smethod_4(byte_2, num, (short)object_);
			}
			else if (object_ is int)
			{
				num += smethod_3(byte_2, num, (int)object_);
			}
			else if (object_ is DateTime)
			{
				num += smethod_6(byte_2, num, (DateTime)object_);
			}
			else if (object_ is bool)
			{
				num += smethod_5(byte_2, num, (bool)object_);
			}
		}
	}

	internal void Write(Class1725 class1725_0)
	{
		Class560 @class = new Class560(this);
		@class.vmethod_0(class1725_0);
		Class561 class2 = new Class561(ushort_1);
		class2.vmethod_0(class1725_0);
		if (method_18())
		{
			Class563 class3 = new Class563(this);
			class3.vmethod_0(class1725_0);
			{
				foreach (Class1166 item in arrayList_1)
				{
					Class568 class4 = new Class568(item);
					class4.vmethod_0(class1725_0);
				}
				return;
			}
		}
		byte[] array = null;
		if (method_20())
		{
			if (sxRng_0 == null || sxRng_0.arrayList_0 == null)
			{
				return;
			}
			if (sxRng_0 != null)
			{
				array = new byte[method_34()];
				method_35(array, sxRng_0.arrayList_0);
				class1725_0.method_3(array);
			}
			Class571 class5 = new Class571(sxRng_0);
			class5.vmethod_0(class1725_0);
			ArrayList arrayList = new ArrayList();
			if (sxRng_0.pivotGroupByType_0 == PivotGroupByType.RangeOfValues)
			{
				Class1158 class6 = new Class1158();
				class6.object_0 = sxRng_0.double_0;
				arrayList.Add(class6);
				class6 = new Class1158();
				class6.object_0 = sxRng_0.double_1;
				arrayList.Add(class6);
				class6 = new Class1158();
				class6.object_0 = sxRng_0.double_2;
				arrayList.Add(class6);
				arrayList.AddRange(arrayList_0);
			}
			else
			{
				Class1158 class7 = new Class1158();
				class7.object_0 = sxRng_0.dateTime_0;
				arrayList.Add(class7);
				class7 = new Class1158();
				class7.object_0 = sxRng_0.dateTime_1;
				arrayList.Add(class7);
				class7 = new Class1158();
				class7.object_0 = (short)sxRng_0.double_2;
				arrayList.Add(class7);
				if (arrayList_0 != null)
				{
					arrayList.AddRange(arrayList_0);
				}
			}
			array = new byte[method_33(arrayList)];
			method_35(array, arrayList);
			class1725_0.method_3(array);
		}
		else if (arrayList_0 != null)
		{
			array = new byte[method_32()];
			method_35(array, arrayList_0);
			class1725_0.method_3(array);
		}
	}

	internal void method_36(int int_3)
	{
		int_1 = int_3;
	}

	internal static int smethod_0(byte[] byte_2, int int_3, byte byte_3)
	{
		byte_2[int_3++] = 203;
		byte_2[int_3++] = 0;
		byte_2[int_3++] = 2;
		byte_2[int_3++] = 0;
		byte_2[int_3++] = byte_3;
		byte_2[int_3++] = 0;
		return 6;
	}

	internal static int smethod_1(byte[] byte_2, int int_3)
	{
		byte_2[int_3++] = 207;
		byte_2[int_3++] = 0;
		byte_2[int_3++] = 0;
		byte_2[int_3++] = 0;
		return 4;
	}

	internal static int smethod_2(byte[] byte_2, int int_3, string string_2)
	{
		int num = int_3;
		byte_2[int_3++] = 205;
		byte_2[int_3++] = 0;
		int_3 += 2;
		int length = string_2.Length;
		Array.Copy(BitConverter.GetBytes((short)length), 0, byte_2, int_3, 2);
		int_3 += 2;
		int num2 = 0;
		if (string_2 == "")
		{
			Array.Copy(BitConverter.GetBytes((short)3), 0, byte_2, num + 2, 2);
			return 7;
		}
		num2 = Class937.smethod_4(byte_2, int_3, string_2);
		Array.Copy(BitConverter.GetBytes((short)(2 + num2)), 0, byte_2, num + 2, 2);
		return 4 + num2 + 2;
	}

	internal static int smethod_3(byte[] byte_2, int int_3, double double_0)
	{
		byte_2[int_3++] = 201;
		byte_2[int_3++] = 0;
		byte_2[int_3++] = 8;
		byte_2[int_3++] = 0;
		Array.Copy(BitConverter.GetBytes(double_0), 0, byte_2, int_3, 8);
		return 12;
	}

	internal static int smethod_4(byte[] byte_2, int int_3, short short_0)
	{
		byte_2[int_3++] = 204;
		byte_2[int_3++] = 0;
		byte_2[int_3++] = 2;
		byte_2[int_3++] = 0;
		Array.Copy(BitConverter.GetBytes(short_0), 0, byte_2, int_3, 2);
		return 6;
	}

	internal static int smethod_5(byte[] byte_2, int int_3, bool bool_2)
	{
		byte_2[int_3++] = 202;
		byte_2[int_3++] = 0;
		byte_2[int_3++] = 2;
		byte_2[int_3++] = 0;
		byte_2[int_3++] = (byte)(bool_2 ? 1u : 0u);
		byte_2[int_3++] = 0;
		return 6;
	}

	internal static int smethod_6(byte[] byte_2, int int_3, DateTime dateTime_0)
	{
		byte_2[int_3++] = 206;
		byte_2[int_3++] = 0;
		byte_2[int_3++] = 8;
		byte_2[int_3++] = 0;
		Array.Copy(BitConverter.GetBytes((ushort)dateTime_0.Year), 0, byte_2, int_3, 2);
		Array.Copy(BitConverter.GetBytes((ushort)dateTime_0.Month), 0, byte_2, int_3 + 2, 2);
		byte_2[int_3 + 4] = (byte)dateTime_0.Day;
		byte_2[int_3 + 5] = (byte)dateTime_0.Hour;
		byte_2[int_3 + 6] = (byte)dateTime_0.Minute;
		byte_2[int_3 + 7] = (byte)dateTime_0.Second;
		return 12;
	}

	internal string[] method_37()
	{
		string[] array = new string[3];
		ArrayList arrayList = new ArrayList();
		ArrayList arrayList2 = new ArrayList();
		foreach (object item in arrayList_0)
		{
			Class1158 @class = (Class1158)item;
			if (@class.object_0 is DateTime)
			{
				array[2] = "Calendar";
				arrayList.Add((DateTime)@class.object_0);
			}
			else if (@class.object_0 is int || @class.object_0 is double)
			{
				array[2] = "Number";
				arrayList2.Add((double)@class.object_0);
			}
		}
		if (array[2] != null && array[2].Equals("Calendar"))
		{
			arrayList.Sort();
			string text = ((DateTime)arrayList[0]).ToString("yyyy-MM-dd\\THH:mm:ss.fff", CultureInfo.InvariantCulture);
			string text2 = ((DateTime)arrayList[arrayList.Count - 1]).ToString("yyyy-MM-dd\\THH:mm:ss.fff", CultureInfo.InvariantCulture);
			array[0] = text;
			array[1] = text2;
		}
		else if (array[2] != null && array[2].Equals("Number"))
		{
			arrayList2.Sort();
			array[0] = arrayList2[0].ToString();
			array[1] = arrayList2[arrayList2.Count - 1].ToString();
		}
		return array;
	}

	internal object[] method_38(SxRng sxRng_1)
	{
		string[] array = method_37();
		if (array[2] != null)
		{
			if (array[2].Equals("Calendar"))
			{
				return new object[14]
				{
					"<" + array[0].Split('T')[0],
					"Jan",
					"Feb",
					"Mar",
					"Apr",
					"May",
					"Jun",
					"Jul",
					"Aug",
					"Sep",
					"Oct",
					"Nov",
					"Dec",
					">" + array[1].Split('T')[0]
				};
			}
			if (array[2].Equals("Number"))
			{
				double num = Class1618.smethod_85(array[0]);
				double num2 = Class1618.smethod_85(array[1]);
				double num3 = 0.1;
				if (array[0].IndexOf('.') == -1 || array[0].IndexOf('.') == -1)
				{
					num3 = 1.0;
				}
				if (num2 - num <= 2.0)
				{
					num3 = 0.1;
				}
				sxRng_1.double_2 = num3;
				int num4 = (int)((num2 - num) / num3) + 2;
				object[] array2 = new object[num4];
				array2[0] = "<" + num;
				if (num3 == 1.0)
				{
					for (int i = 1; i < num4 - 1; i++)
					{
						num2 = num + num3;
						if (i == num4 - 2)
						{
							array2[i] = num + "-" + num2;
						}
						else
						{
							array2[i] = num + "-" + (num2 - 1.0);
						}
						num = num2;
					}
				}
				else
				{
					for (int j = 1; j < num4 - 1; j++)
					{
						num2 = num + num3;
						array2[j] = num + "-" + num2;
						num = num2;
					}
				}
				array2[num4 - 1] = ">" + num2;
				return array2;
			}
		}
		return null;
	}

	internal object[] method_39(string string_2, string string_3, ArrayList arrayList_2, double double_0, PivotGroupByType pivotGroupByType_0)
	{
		if (arrayList_2.Count == 1)
		{
			switch (pivotGroupByType_0)
			{
			case PivotGroupByType.Days:
			{
				object[] array2 = new object[368];
				string text = "<" + string_2.Split('T')[0];
				string text2 = ">" + string_3.Split('T')[0];
				array2[0] = text;
				string[] array3 = new string[7] { "Jan", "Mar", "May", "Jul", "Aug", "Oct", "Dec" };
				int num4 = 0;
				for (int j = 0; j < array3.Length; j++)
				{
					switch (j)
					{
					case 1:
						num4 += 29;
						break;
					default:
						num4 += 30;
						break;
					case 0:
					case 4:
						break;
					}
					for (int k = 1; k <= 31; k++)
					{
						num4++;
						array2[num4] = k + "-" + array3[j];
					}
				}
				string[] array4 = new string[4] { "Apr", "Jun", "Sep", "Nov" };
				num4 = 60;
				for (int l = 0; l < array4.Length; l++)
				{
					num4 = ((l == 2) ? (num4 + 62) : (num4 + 31));
					for (int m = 1; m <= 30; m++)
					{
						num4++;
						array2[num4] = m + "-" + array4[l];
					}
				}
				num4 = 31;
				for (int n = 1; n <= 29; n++)
				{
					num4++;
					array2[num4] = n + "-Feb";
				}
				array2[367] = text2;
				return array2;
			}
			case PivotGroupByType.RangeOfValues:
			{
				double num = Class1618.smethod_85(string_2);
				double num2 = Class1618.smethod_85(string_3);
				int num3 = 0;
				num3 = (((int)((num2 - num) % double_0) == 0) ? ((int)((num2 - num) / double_0) + 2) : ((int)((num2 - num) / double_0) + 1 + 2));
				object[] array = new object[num3];
				array[0] = "<" + num;
				for (int i = 1; i < num3 - 1; i++)
				{
					num2 = num + double_0;
					array[i] = num + "-" + (num2 - 1.0);
					num = num2;
				}
				array[num3 - 1] = ">" + num2;
				return array;
			}
			}
		}
		string text3 = "<" + string_2.Split('T')[0];
		string text4 = ">" + string_3.Split('T')[0];
		switch (pivotGroupByType_0)
		{
		default:
			return null;
		case PivotGroupByType.Seconds:
		case PivotGroupByType.Minutes:
		{
			object[] array7 = new object[62];
			array7[0] = text3;
			for (int num11 = 0; num11 < 60; num11++)
			{
				if (num11 < 10)
				{
					array7[num11 + 1] = ":0" + num11;
				}
				else
				{
					array7[num11 + 1] = ":" + num11;
				}
			}
			array7[61] = text4;
			return array7;
		}
		case PivotGroupByType.Hours:
		{
			object[] array6 = new object[26];
			array6[0] = text3;
			array6[1] = "12 AM";
			for (int num9 = 1; num9 < 12; num9++)
			{
				array6[num9 + 1] = num9 + " AM";
			}
			array6[13] = "12 PM";
			for (int num10 = 1; num10 < 12; num10++)
			{
				array6[num10 + 13] = num10 + " PM";
			}
			array6[25] = text4;
			return array6;
		}
		case PivotGroupByType.Days:
		{
			object[] array8 = new object[368];
			array8[0] = text3;
			string[] array9 = new string[7] { "Jan", "Mar", "May", "Jul", "Aug", "Oct", "Dec" };
			int num12 = 0;
			for (int num13 = 0; num13 < array9.Length; num13++)
			{
				switch (num13)
				{
				case 1:
					num12 += 29;
					break;
				default:
					num12 += 30;
					break;
				case 0:
				case 4:
					break;
				}
				for (int num14 = 1; num14 <= 31; num14++)
				{
					num12++;
					array8[num12] = num14 + "-" + array9[num13];
				}
			}
			string[] array10 = new string[4] { "Apr", "Jun", "Sep", "Nov" };
			num12 = 60;
			for (int num15 = 0; num15 < array10.Length; num15++)
			{
				num12 = ((num15 == 2) ? (num12 + 62) : (num12 + 31));
				for (int num16 = 1; num16 <= 30; num16++)
				{
					num12++;
					array8[num12] = num16 + "-" + array10[num15];
				}
			}
			num12 = 31;
			for (int num17 = 1; num17 <= 29; num17++)
			{
				num12++;
				array8[num12] = num17 + "-Feb";
			}
			array8[367] = text4;
			return array8;
		}
		case PivotGroupByType.Months:
			return new object[14]
			{
				text3, "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep",
				"Oct", "Nov", "Dec", text4
			};
		case PivotGroupByType.Quarters:
			return new object[6] { text3, "Qtr1", "Qtr2", "Qtr3", "Qtr4", text4 };
		case PivotGroupByType.Years:
		{
			string text5 = "<" + string_2.Split('T')[0];
			string text6 = ">" + string_3.Split('T')[0];
			int num5 = 0;
			int num6 = 0;
			try
			{
				num5 = DateTime.Parse(string_2.Split('T')[0]).Year;
				num6 = DateTime.Parse(string_3.Split('T')[0]).Year;
			}
			catch (Exception)
			{
				throw new ArgumentException("Invalid start end years.");
			}
			int num7 = num6 - num5 + 1 + 2;
			object[] array5 = new object[num7];
			array5[0] = text5;
			for (int num8 = 1; num8 < num7 - 1; num8++)
			{
				array5[num8] = num5.ToString();
				num5++;
			}
			array5[num7 - 1] = text6;
			return array5;
		}
		}
	}
}
