using System;
using System.Collections;
using System.IO;
using System.Text;
using Aspose.Cells;
using Aspose.Cells.Pivot;
using ns2;
using ns22;
using ns57;
using ns59;

namespace ns45;

internal class Class1143
{
	private ushort ushort_0;

	private ushort ushort_1;

	private byte[] byte_0;

	private byte[] byte_1;

	private Class1141 class1141_0;

	private Class1723 class1723_0;

	private Worksheet worksheet_0;

	private Class1730 class1730_0;

	internal Class1143()
	{
		byte_0 = new byte[2];
	}

	internal void method_0(Class1141 class1141_1, Worksheet worksheet_1, Class1730 class1730_1)
	{
		class1730_0 = class1730_1;
		Class1317 class1317_ = class1730_1.class1317_0;
		Class1319 @class = class1317_.method_9().method_0("_SX_DB_CUR");
		if (@class != null)
		{
			string text = Class1025.smethod_6(class1141_1.int_6);
			MemoryStream stream = @class.GetStream(text);
			if (stream != null)
			{
				class1141_0 = class1141_1;
				@class.Remove(text);
				worksheet_0 = worksheet_1;
				method_1(stream);
			}
		}
	}

	private void method_1(MemoryStream memoryStream_0)
	{
		ArrayList arrayList = new ArrayList();
		class1141_0.arrayList_3 = arrayList;
		class1723_0 = new Class1723(memoryStream_0);
		while (true)
		{
			ushort_0 = class1723_0.method_2(byte_0);
			ushort num = ushort_0;
			if (num == 10)
			{
				break;
			}
			method_2();
			arrayList.Add(byte_1);
		}
		class1723_0.method_3(-2);
	}

	private void method_2()
	{
		class1730_0.method_74(class1723_0, ushort_0);
		byte_1 = class1730_0.method_105();
	}

	internal void Read(Class1141 class1141_1, Worksheet worksheet_1, Class1730 class1730_1)
	{
		class1730_0 = class1730_1;
		Class1317 class1317_ = class1730_1.class1317_0;
		Class1319 @class = class1317_.method_9().method_0("_SX_DB_CUR");
		if (@class != null)
		{
			string text = Class1025.smethod_6(class1141_1.int_6);
			MemoryStream stream = @class.GetStream(text);
			if (stream != null)
			{
				class1141_0 = class1141_1;
				@class.Remove(text);
				worksheet_0 = worksheet_1;
				method_4();
				method_6(stream);
			}
		}
	}

	[Attribute0(true)]
	private string method_3(byte[] byte_2, int int_0)
	{
		int num = BitConverter.ToUInt16(byte_1, int_0);
		string text = null;
		if (num == 0)
		{
			return null;
		}
		text = ((byte_1[int_0 + 2] != 0) ? Encoding.Unicode.GetString(byte_1, int_0 + 3, num * 2) : Encoding.ASCII.GetString(byte_1, int_0 + 3, num));
		if (text[0] == '\u0002')
		{
			return text.Substring(1);
		}
		return text;
	}

	private void method_4()
	{
		if (class1141_0.arrayList_2 == null)
		{
			return;
		}
		ArrayList arrayList = new ArrayList();
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		while (true)
		{
			if (num3 < class1141_0.arrayList_2.Count)
			{
				byte_1 = (byte[])class1141_0.arrayList_2[num3];
				ushort_0 = BitConverter.ToUInt16(byte_1, 0);
				switch (ushort_0)
				{
				case 2148:
				{
					byte[] array = new byte[byte_1.Length - 8];
					Array.Copy(byte_1, 8, array, 0, array.Length);
					class1141_0.class1140_0.Add(array);
					break;
				}
				case 208:
					class1141_0.int_0 = new int[BitConverter.ToInt16(byte_1, 4)][];
					class1141_0.bool_0 = (byte_1[9] & 0x80) != 0;
					if (!class1141_0.bool_0)
					{
						class1141_0.string_0 = new string[BitConverter.ToInt16(byte_1, 8)][];
					}
					else
					{
						class1141_0.string_0 = new string[1][];
					}
					break;
				case 209:
				{
					string[] array3 = (class1141_0.string_0[num2] = new string[BitConverter.ToUInt16(byte_1, 4)]);
					num3++;
					for (int j = 0; j < array3.Length; j++)
					{
						byte_1 = (byte[])class1141_0.arrayList_2[num3 + j];
						ushort_0 = BitConverter.ToUInt16(byte_1, 0);
						switch (ushort_0)
						{
						case 201:
							array3[j] = BitConverter.ToDouble(byte_1, 4).ToString();
							break;
						case 202:
							array3[j] = ((byte_1[4] != 0) ? "TRUE" : "FALSE");
							break;
						case 205:
						{
							string text3 = null;
							text3 = ((byte_1[6] != 0) ? Encoding.Unicode.GetString(byte_1, 7, byte_1.Length - 7) : Encoding.ASCII.GetString(byte_1, 7, byte_1.Length - 7));
							array3[j] = text3;
							break;
						}
						case 206:
							array3[j] = method_12(byte_1, 4).ToString();
							break;
						case 207:
							array3[j] = null;
							break;
						}
					}
					num2++;
					num3 += array3.Length - 1;
					break;
				}
				case 210:
				{
					int[] array2 = (class1141_0.int_0[num] = new int[(byte_1.Length - 4) / 2]);
					for (int i = 0; i < array2.Length; i++)
					{
						array2[i] = BitConverter.ToUInt16(byte_1, i * 2 + 4);
					}
					num++;
					break;
				}
				case 81:
				{
					string text4 = method_3(byte_1, 10);
					Worksheet worksheet2 = ((text4 == null || text4 == "") ? worksheet_0 : worksheet_0.method_2()[text4]);
					if (worksheet2 != null)
					{
						int num4 = BitConverter.ToUInt16(byte_1, 4);
						int num5 = BitConverter.ToUInt16(byte_1, 6);
						int num6 = byte_1[8];
						int num7 = byte_1[9];
						Range range2 = new Range(num4, num6, num5 - num4 + 1, num7 - num6 + 1, worksheet_0.Cells);
						string text5 = null;
						Class1139 class2 = new Class1139(string_2: (!Class1677.smethod_21(worksheet2.Name)) ? (worksheet2.Name + "!" + range2.method_1()) : ("'" + worksheet2.Name + "'!" + range2.method_1()), class1141_1: class1141_0, worksheet_1: worksheet2);
						class2.range_0 = range2;
						class2.range_1 = range2;
						arrayList.Add(class2);
						break;
					}
					return;
				}
				case 82:
				{
					int int_ = 6;
					string text = method_5(ref int_, byte_1[4]);
					if (text.StartsWith("="))
					{
						text = text.Substring(1);
					}
					string text2 = method_3(byte_1, int_);
					bool flag = text2 == null || text2 == "";
					bool flag2 = false;
					Worksheet worksheet = (flag ? worksheet_0 : worksheet_0.method_2()[text2]);
					if (worksheet != null)
					{
						int int_2 = (flag ? (-1) : worksheet.Index);
						Name name = worksheet_0.method_2().Names[text, int_2];
						Range range = null;
						if (name == null)
						{
							flag2 = true;
							name = worksheet_0.method_2().Names[text];
						}
						if (name != null)
						{
							if (flag2 && name.GetRange() != null)
							{
								worksheet = name.GetRange().Worksheet;
							}
							range = name.CreateRange();
							if (range != null)
							{
								string string_ = text;
								if (!flag)
								{
									string_ = ((!Class1677.smethod_21(worksheet.Name)) ? (worksheet.Name + "!" + range.method_1()) : ("'" + worksheet.Name + "'!" + range.method_1()));
								}
								Class1139 @class = new Class1139(class1141_0, worksheet, string_);
								@class.range_0 = range;
								@class.range_1 = range;
								arrayList.Add(@class);
								break;
							}
							class1141_0.string_3 = text;
							return;
						}
						class1141_0.string_3 = text;
						return;
					}
					return;
				}
				}
				num3++;
				continue;
			}
			class1141_0.arrayList_2 = null;
			if (arrayList.Count != 0)
			{
				class1141_0.class1139_0 = new Class1139[arrayList.Count];
				for (int k = 0; k < arrayList.Count; k++)
				{
					class1141_0.class1139_0[k] = (Class1139)arrayList[k];
				}
			}
			break;
		}
	}

	[Attribute0(true)]
	private string method_5(ref int int_0, int int_1)
	{
		string text = null;
		if (byte_1[int_0] == 0)
		{
			text = Encoding.ASCII.GetString(byte_1, int_0 + 1, int_1);
			int_0 += int_1 + 1;
		}
		else
		{
			text = Encoding.Unicode.GetString(byte_1, int_0 + 1, int_1 * 2);
			int_0 += int_1 * 2 + 1;
		}
		return text;
	}

	private void method_6(MemoryStream memoryStream_0)
	{
		class1723_0 = new Class1723(memoryStream_0);
		while (!class1723_0.method_0())
		{
			ushort_0 = class1723_0.method_2(byte_0);
			switch (ushort_0)
			{
			case 290:
			{
				method_11();
				class1141_0.dateTime_0 = CellsHelper.GetDateTimeFromDouble(BitConverter.ToDouble(byte_1, 0), worksheet_0.Workbook.Settings.Date1904);
				int num = BitConverter.ToUInt16(byte_1, 8);
				if (num != 0)
				{
					method_7(num);
				}
				break;
			}
			case 198:
				method_11();
				class1141_0.int_3 = BitConverter.ToInt32(byte_1, 0);
				class1141_0.int_6 = BitConverter.ToUInt16(byte_1, 4);
				class1141_0.ushort_0 = BitConverter.ToUInt16(byte_1, 6);
				class1141_0.int_8 = BitConverter.ToUInt16(byte_1, 8);
				class1141_0.int_1 = BitConverter.ToUInt16(byte_1, 10);
				class1141_0.int_2 = BitConverter.ToUInt16(byte_1, 12);
				class1141_0.pivotTableSourceType_0 = (PivotTableSourceType)byte_1[16];
				if (byte_1[20] == 0)
				{
					class1141_0.string_1 = Encoding.ASCII.GetString(byte_1, 21, byte_1.Length - 21);
				}
				else
				{
					class1141_0.string_1 = Encoding.Unicode.GetString(byte_1, 21, byte_1.Length - 21);
				}
				break;
			case 199:
				class1723_0.method_3(-2);
				method_8();
				break;
			case 200:
				class1723_0.method_3(-2);
				method_10();
				return;
			case 10:
				class1723_0.method_3(2);
				return;
			}
		}
		if (class1141_0.class1144_0 == null)
		{
			class1141_0.method_14(bool_2: false, 1);
		}
	}

	private void method_7(int int_0)
	{
		Class1148 @class = null;
		Class1166 class2 = null;
		Class1171 class3 = null;
		Class1162 class4 = null;
		while (true)
		{
			ushort_0 = class1723_0.method_2(byte_0);
			switch (ushort_0)
			{
			case 259:
				method_11();
				@class.int_1 = BitConverter.ToInt16(byte_1, 2);
				break;
			case 240:
				method_11();
				class3 = (@class.class1171_0 = new Class1171());
				class3.byte_0 = byte_1[0];
				class3.byte_1 = byte_1[1];
				class3.ushort_0 = BitConverter.ToUInt16(byte_1, 2);
				break;
			case 242:
				method_11();
				class4 = new Class1162();
				class3.arrayList_0.Add(class4);
				class4.ushort_0 = BitConverter.ToUInt16(byte_1, 0);
				class4.ushort_1 = BitConverter.ToUInt16(byte_1, 2);
				class4.Function = BitConverter.ToUInt16(byte_1, 4);
				break;
			case 245:
				method_11();
				if (class4.arrayList_0 == null)
				{
					class4.arrayList_0 = new ArrayList();
				}
				class4.arrayList_0.Add((int)BitConverter.ToUInt16(byte_1, 0));
				break;
			case 246:
				method_11();
				class2 = new Class1166();
				if (@class.class1169_0 == null)
				{
					@class.class1169_0 = new Class1169();
				}
				@class.class1169_0.Add(class2);
				class2.ushort_0 = BitConverter.ToUInt16(byte_1, 0);
				class2.ushort_1 = BitConverter.ToUInt16(byte_1, 2);
				class2.ushort_2 = BitConverter.ToUInt16(byte_1, 4);
				break;
			default:
				ushort_1 = class1723_0.method_2(byte_0);
				class1723_0.method_3(ushort_1);
				break;
			case 248:
			{
				method_11();
				Class1167 class5 = new Class1167();
				class2.method_1().Add(class5);
				class5.ushort_0 = BitConverter.ToUInt16(byte_1, 0);
				class5.ushort_1 = BitConverter.ToUInt16(byte_1, 2);
				class5.ushort_2 = BitConverter.ToUInt16(byte_1, 6);
				break;
			}
			case 249:
			{
				method_11();
				@class = new Class1148(class1141_0);
				if (class1141_0.class988_0 == null)
				{
					class1141_0.class988_0 = new Class988();
				}
				class1141_0.class988_0.Add(@class);
				int num = BitConverter.ToUInt16(byte_1, 0);
				@class.byte_0 = new byte[num];
				Array.Copy(byte_1, 4, @class.byte_0, 0, num);
				break;
			}
			case 10:
			case 199:
			case 200:
				class1723_0.method_3(-2);
				return;
			}
		}
	}

	internal void method_8()
	{
		Class1161 @class = null;
		while (!class1723_0.method_0())
		{
			ushort_0 = class1723_0.method_2(byte_0);
			switch (ushort_0)
			{
			case 199:
				method_11();
				@class = new Class1161(class1141_0);
				if (class1141_0.arrayList_0 == null)
				{
					class1141_0.arrayList_0 = new ArrayList();
				}
				class1141_0.arrayList_0.Add(@class);
				@class.ushort_0 = BitConverter.ToUInt16(byte_1, 0);
				@class.int_0 = BitConverter.ToUInt16(byte_1, 2);
				@class.method_36(BitConverter.ToUInt16(byte_1, 4));
				@class.int_2 = BitConverter.ToUInt16(byte_1, 12);
				if (byte_1[16] == 0)
				{
					@class.string_0 = Encoding.ASCII.GetString(byte_1, 17, byte_1.Length - 17);
				}
				else
				{
					@class.string_0 = Encoding.Unicode.GetString(byte_1, 17, byte_1.Length - 17);
				}
				if (!@class.method_2())
				{
					break;
				}
				@class.arrayList_0 = new ArrayList();
				@class.method_13(bool_2: false);
				if (@class.method_20())
				{
					SxRng sxRng_ = new SxRng(@class);
					@class.sxRng_0 = sxRng_;
					@class.sxRng_0.arrayList_0 = new ArrayList();
					@class.sxRng_0.int_0 = @class.int_1;
					if (@class.method_17())
					{
						@class.sxRng_0.int_1 = @class.int_0;
					}
				}
				break;
			case 200:
				class1723_0.method_3(-2);
				method_10();
				break;
			case 201:
			{
				method_11();
				Class1158 class3 = new Class1158();
				class3.object_0 = BitConverter.ToDouble(byte_1, 0);
				if (@class.method_20())
				{
					if (@class.sxRng_0 != null && @class.sxRng_0.arrayList_0 != null)
					{
						@class.sxRng_0.arrayList_0.Add(class3);
					}
				}
				else if (@class.arrayList_0 != null)
				{
					@class.arrayList_0.Add(class3);
				}
				break;
			}
			case 202:
			{
				method_11();
				Class1158 class3 = new Class1158();
				class3.object_0 = byte_1[0] != 0;
				if (@class.method_20())
				{
					if (@class.sxRng_0 != null && @class.sxRng_0.arrayList_0 != null)
					{
						@class.sxRng_0.arrayList_0.Add(class3);
					}
				}
				else if (@class.arrayList_0 != null)
				{
					@class.arrayList_0.Add(class3);
				}
				break;
			}
			case 203:
			{
				method_11();
				Class1158 class3 = new Class1158();
				switch (byte_1[0])
				{
				case 15:
					class3.object_0 = "#VALUE!";
					break;
				case 7:
					class3.object_0 = "#DIV/0!";
					break;
				case 0:
					class3.object_0 = "#NULL!";
					break;
				case 29:
					class3.object_0 = "#NAME?";
					break;
				case 23:
					class3.object_0 = "#REF!";
					break;
				case 42:
					class3.object_0 = "#N/A";
					break;
				case 36:
					class3.object_0 = "#NUM!";
					break;
				}
				if (@class.method_20())
				{
					if (@class.sxRng_0 != null && @class.sxRng_0.arrayList_0 != null)
					{
						@class.sxRng_0.arrayList_0.Add(class3);
					}
				}
				else if (@class.arrayList_0 != null)
				{
					@class.arrayList_0.Add(class3);
				}
				break;
			}
			case 204:
			{
				method_11();
				Class1158 class3 = new Class1158();
				class3.object_0 = BitConverter.ToInt16(byte_1, 0);
				if (@class.method_20())
				{
					if (@class.sxRng_0 != null && @class.sxRng_0.arrayList_0 != null)
					{
						@class.sxRng_0.arrayList_0.Add(class3);
					}
				}
				else if (@class.arrayList_0 != null)
				{
					@class.arrayList_0.Add(class3);
				}
				break;
			}
			case 205:
			{
				method_11();
				string text = null;
				if (byte_1[2] == 0)
				{
					int num2 = byte_1.Length - 3;
					byte[] array = new byte[num2 * 2];
					for (int i = 0; i < num2; i++)
					{
						array[i * 2] = byte_1[3 + i];
					}
					text = Encoding.Unicode.GetString(array, 0, num2 * 2);
				}
				else
				{
					text = Encoding.Unicode.GetString(byte_1, 3, byte_1.Length - 3);
				}
				Class1158 class3 = new Class1158();
				class3.object_0 = text;
				if (@class.method_20())
				{
					if (@class.sxRng_0 != null && @class.sxRng_0.arrayList_0 != null)
					{
						@class.sxRng_0.arrayList_0.Add(class3);
					}
				}
				else if (@class.arrayList_0 != null)
				{
					@class.arrayList_0.Add(class3);
				}
				if (!@class.method_20())
				{
					@class.method_13(bool_2: true);
				}
				break;
			}
			case 206:
			{
				method_11();
				Class1158 class3 = new Class1158();
				class3.object_0 = method_12(byte_1, 0);
				if (@class.method_20())
				{
					if (@class.sxRng_0 != null && @class.sxRng_0.arrayList_0 != null)
					{
						@class.sxRng_0.arrayList_0.Add(class3);
					}
				}
				else if (@class.arrayList_0 != null)
				{
					@class.arrayList_0.Add(class3);
				}
				break;
			}
			case 207:
			{
				class1723_0.method_3(2);
				Class1158 class3 = new Class1158();
				class3.object_0 = null;
				if (@class.method_20())
				{
					if (@class.sxRng_0 != null && @class.sxRng_0.arrayList_0 != null)
					{
						@class.sxRng_0.arrayList_0.Add(class3);
					}
				}
				else if (@class.arrayList_0 != null)
				{
					@class.arrayList_0.Add(class3);
				}
				break;
			}
			case 216:
				if (@class.sxRng_0 == null)
				{
					ushort_1 = class1723_0.method_2(byte_0);
					class1723_0.method_3(ushort_1);
					break;
				}
				method_11();
				@class.sxRng_0.bool_0 = (byte_1[0] & 1) != 0;
				@class.sxRng_0.bool_1 = (byte_1[0] & 2) != 0;
				@class.sxRng_0.pivotGroupByType_0 = Class1156.smethod_2((byte_1[0] & 0x1F) >> 2);
				Array.Copy(byte_1, @class.sxRng_0.byte_0, 2);
				method_9(@class);
				break;
			default:
				ushort_1 = class1723_0.method_2(byte_0);
				class1723_0.method_3(ushort_1);
				break;
			case 443:
				method_11();
				@class.ushort_1 = BitConverter.ToUInt16(byte_1, 0);
				break;
			case 249:
			{
				method_11();
				int num = BitConverter.ToUInt16(byte_1, 0);
				@class.byte_0 = new byte[num];
				Array.Copy(byte_1, 4, @class.byte_0, 0, num);
				@class.arrayList_1 = new ArrayList();
				break;
			}
			case 246:
			{
				method_11();
				Class1166 class2 = new Class1166();
				@class.arrayList_1.Add(class2);
				class2.ushort_0 = BitConverter.ToUInt16(byte_1, 0);
				class2.ushort_1 = BitConverter.ToUInt16(byte_1, 2);
				class2.ushort_2 = BitConverter.ToUInt16(byte_1, 4);
				break;
			}
			case 10:
				class1723_0.method_3(2);
				return;
			}
		}
	}

	private void method_9(Class1161 class1161_0)
	{
		int num = 0;
		while (!class1723_0.method_0())
		{
			ushort_0 = class1723_0.method_2(byte_0);
			switch (ushort_0)
			{
			case 204:
			{
				method_11();
				int num2 = BitConverter.ToInt16(byte_1, 0);
				if (num == 2)
				{
					class1161_0.sxRng_0.double_2 = num2;
				}
				num++;
				break;
			}
			case 206:
			{
				method_11();
				Class1158 @class = new Class1158();
				@class.object_0 = method_12(byte_1, 0);
				switch (num)
				{
				case 0:
					class1161_0.sxRng_0.dateTime_0 = (DateTime)@class.object_0;
					break;
				case 1:
					class1161_0.sxRng_0.dateTime_1 = (DateTime)@class.object_0;
					break;
				default:
					if (class1161_0.arrayList_0 != null)
					{
						class1161_0.arrayList_0.Add(@class);
					}
					break;
				}
				num++;
				break;
			}
			case 201:
			{
				method_11();
				Class1158 @class = new Class1158();
				@class.object_0 = BitConverter.ToDouble(byte_1, 0);
				switch (num)
				{
				case 0:
					class1161_0.sxRng_0.double_0 = (double)@class.object_0;
					break;
				case 1:
					class1161_0.sxRng_0.double_1 = (double)@class.object_0;
					break;
				case 2:
					class1161_0.sxRng_0.double_2 = (double)@class.object_0;
					break;
				default:
					if (class1161_0.arrayList_0 != null)
					{
						class1161_0.arrayList_0.Add(@class);
					}
					break;
				}
				num++;
				break;
			}
			default:
				class1723_0.method_3(-2);
				return;
			}
		}
	}

	private void method_10()
	{
		Class1144 @class = new Class1144(class1141_0, class1141_0.int_3, class1141_0.int_1);
		class1141_0.class1144_0 = @class;
		@class.method_0();
		int num = @class.method_2();
		int int_ = class1141_0.int_1;
		bool[] bool_ = @class.bool_0;
		bool[] bool_2 = @class.bool_1;
		int num2 = -1;
		int i = 0;
		while (!class1723_0.method_0())
		{
			ushort_0 = class1723_0.method_2(byte_0);
			switch (ushort_0)
			{
			case 200:
			{
				i = 0;
				num2++;
				method_11();
				if (num2 >= @class.arrayList_0.Count)
				{
					break;
				}
				if (ushort_1 == num)
				{
					int j = 0;
					for (int k = 0; k < ushort_1; k++)
					{
						for (; j < int_ && !bool_[j]; j++)
						{
						}
						((object[])@class.arrayList_0[num2])[j++] = (int)byte_1[k];
					}
					break;
				}
				int l = 0;
				for (int m = 0; m < ushort_1; m++)
				{
					for (; l < int_ && !bool_[l]; l++)
					{
					}
					if (l >= bool_2.Length)
					{
						break;
					}
					if (bool_2[l])
					{
						((object[])@class.arrayList_0[num2])[l++] = (int)BitConverter.ToUInt16(byte_1, m);
						m++;
					}
					else
					{
						((object[])@class.arrayList_0[num2])[l++] = (int)byte_1[m];
					}
				}
				break;
			}
			default:
				ushort_1 = class1723_0.method_2(byte_0);
				class1723_0.method_3(ushort_1);
				break;
			case 201:
			case 202:
			case 205:
			case 206:
			case 207:
			{
				for (; i < int_ && bool_[i]; i++)
				{
				}
				method_11();
				if (num2 >= @class.arrayList_0.Count)
				{
					break;
				}
				object[] array = (object[])@class.arrayList_0[num2];
				if (i < array.Length)
				{
					switch (ushort_0)
					{
					case 201:
						array[i++] = BitConverter.ToDouble(byte_1, 0);
						break;
					case 202:
						array[i++] = byte_1[0] != 0;
						break;
					case 205:
					{
						string text = null;
						text = ((byte_1[2] != 0) ? Encoding.Unicode.GetString(byte_1, 3, byte_1.Length - 3) : Encoding.ASCII.GetString(byte_1, 3, byte_1.Length - 3));
						array[i++] = text;
						break;
					}
					case 206:
						array[i++] = method_12(byte_1, 0);
						break;
					case 207:
						array[i++] = null;
						break;
					}
				}
				break;
			}
			case 10:
				class1723_0.method_3(2);
				return;
			}
		}
	}

	private void method_11()
	{
		ushort_1 = class1723_0.method_2(byte_0);
		if (ushort_1 != 0)
		{
			byte_1 = new byte[ushort_1];
			class1723_0.method_1(byte_1);
		}
	}

	private DateTime method_12(byte[] byte_2, int int_0)
	{
		int year = BitConverter.ToUInt16(byte_1, int_0);
		int month = BitConverter.ToUInt16(byte_1, 2 + int_0);
		byte b = byte_1[4 + int_0];
		DateTime dateTime = new DateTime(1900, 1, 1);
		return (b != 0) ? new DateTime(year, month, byte_1[4 + int_0], byte_1[5 + int_0], byte_1[6 + int_0], byte_1[7 + int_0]) : new DateTime(year, month, 1);
	}
}
