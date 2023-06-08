using System;
using System.Collections;
using System.Text;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using Aspose.Cells.Pivot;
using ns2;
using ns59;

namespace ns27;

internal class Class663 : Class538
{
	private ArrayList arrayList_0;

	internal Class663()
	{
		method_2(93);
	}

	internal void method_4(Shape shape_0, int int_0)
	{
		if (byte_0 == null)
		{
			method_0(70);
			byte_0 = new byte[base.Length];
			int num = method_23(shape_0);
			byte_0[8] = 1;
			byte_0[9] = 33;
			num += method_17(num, 100, 10);
			MsoDrawingType msoDrawingType = shape_0.MsoDrawingType;
			if (msoDrawingType == MsoDrawingType.ComboBox)
			{
				object obj = ((ComboBox)shape_0).method_69();
				if (obj is AutoFilter)
				{
					byte[] array = new byte[20]
					{
						19, 0, 238, 31, 0, 0, 0, 0, 4, 0,
						1, 3, 0, 0, 2, 0, 8, 0, 108, 0
					};
					Array.Copy(array, 0, byte_0, num, array.Length);
				}
				else if (obj is ValidationCollection)
				{
					byte[] array2 = new byte[20]
					{
						19, 0, 238, 31, 0, 0, 0, 0, 1, 0,
						1, 6, 0, 0, 2, 0, 8, 0, 64, 0
					};
					Array.Copy(array2, 0, byte_0, num, array2.Length);
				}
				else if (obj is PivotTable)
				{
					byte[] array3 = new byte[20]
					{
						19, 0, 238, 31, 0, 0, 0, 0, 0, 0,
						1, 1, 0, 0, 2, 0, 8, 0, 0, 0
					};
					Array.Copy(array3, 0, byte_0, num, array3.Length);
				}
			}
		}
		else
		{
			Array.Copy(BitConverter.GetBytes((ushort)int_0), 0, byte_0, 6, 2);
		}
	}

	internal void method_5(Shape shape_0)
	{
		switch (shape_0.MsoDrawingType)
		{
		case MsoDrawingType.OleObject:
			if (((OleObject)shape_0).method_82())
			{
				method_22((OleObject)shape_0);
				break;
			}
			goto default;
		case MsoDrawingType.ListBox:
			method_13((ListBox)shape_0);
			break;
		default:
			if (shape_0.method_28().arrayList_0 != null && shape_0.method_28().arrayList_0.Count != 0)
			{
				method_7(shape_0);
				break;
			}
			method_0(26);
			switch (shape_0.MsoDrawingType)
			{
			case MsoDrawingType.OleObject:
				method_22((OleObject)shape_0);
				break;
			case MsoDrawingType.Spinner:
			case MsoDrawingType.ScrollBar:
				method_14(shape_0);
				break;
			default:
			{
				byte[] array = shape_0.method_28().byte_0;
				if (array != null)
				{
					method_0((short)(base.Length + (short)array.Length));
				}
				byte_0 = new byte[base.Length];
				int num = method_23(shape_0);
				if (array != null)
				{
					Array.Copy(array, 0, byte_0, num, array.Length);
					num += array.Length;
				}
				break;
			}
			case MsoDrawingType.GroupBox:
				method_8((GroupBox)shape_0);
				break;
			case MsoDrawingType.Group:
				method_9((GroupShape)shape_0);
				break;
			}
			break;
		case MsoDrawingType.ComboBox:
			if (!shape_0.method_27().method_7().method_0())
			{
				method_12((ComboBox)shape_0);
			}
			else
			{
				method_7(shape_0);
			}
			break;
		case MsoDrawingType.CheckBox:
			method_11((CheckBox)shape_0);
			break;
		case MsoDrawingType.RadioButton:
			method_10((RadioButton)shape_0);
			break;
		}
	}

	internal int method_6(Shape shape_0)
	{
		int num = 0;
		if (shape_0.method_28().arrayList_0 != null && shape_0.method_28().arrayList_0.Count != 0)
		{
			foreach (byte[] item in shape_0.method_28().arrayList_0)
			{
				num += (short)item.Length;
			}
		}
		return num;
	}

	internal void method_7(Shape shape_0)
	{
		method_0(22);
		if (shape_0.method_28().arrayList_0 != null && shape_0.method_28().arrayList_0.Count != 0)
		{
			foreach (byte[] item in shape_0.method_28().arrayList_0)
			{
				method_0((short)(base.Length + (short)item.Length));
			}
		}
		byte_0 = new byte[base.Length];
		int num = method_23(shape_0);
		if (shape_0.method_28().arrayList_0 == null || shape_0.method_28().arrayList_0.Count == 0)
		{
			return;
		}
		foreach (byte[] item2 in shape_0.method_28().arrayList_0)
		{
			Array.Copy(item2, 0, byte_0, num, item2.Length);
			num += (short)item2.Length;
		}
	}

	internal void method_8(GroupBox groupBox_0)
	{
		method_0((short)(base.Length + 10));
		byte_0 = new byte[base.Length];
		int num = method_23(groupBox_0);
		byte_0[num] = 15;
		byte_0[num + 2] = 6;
		num += 4;
		if (!groupBox_0.Shadow)
		{
			byte_0[num + 4] = 1;
		}
		num += 6;
	}

	internal void method_9(GroupShape groupShape_0)
	{
		method_0((short)(base.Length + 6));
		byte_0 = new byte[base.Length];
		int num = method_23(groupShape_0);
		byte_0[num] = 6;
		byte_0[num + 2] = 2;
		num += 6;
	}

	internal void method_10(RadioButton radioButton_0)
	{
		method_0(72);
		byte[] array = radioButton_0.method_58();
		if (array != null)
		{
			method_0((short)(base.Length + (short)(11 + array.Length)));
		}
		if (radioButton_0.method_28().arrayList_0 != null && radioButton_0.method_28().arrayList_0.Count > 0)
		{
			foreach (byte[] item in radioButton_0.method_28().arrayList_0)
			{
				method_0((short)(base.Length + (short)item.Length));
			}
		}
		byte_0 = new byte[base.Length];
		int num = method_23(radioButton_0);
		byte_0[num] = 10;
		byte_0[num + 2] = 12;
		num += 4;
		if (radioButton_0.IsChecked)
		{
			byte_0[num] = 1;
		}
		if (array != null)
		{
			byte_0[num + 2] = 12;
			byte_0[num + 4] = 108;
			byte_0[num + 5] = 1;
		}
		byte_0[num + 10] = 3;
		num += 12;
		byte_0[num] = 11;
		byte_0[num + 2] = 6;
		num += 4;
		if (radioButton_0.IsChecked)
		{
			byte_0[num] = 88;
			byte_0[num + 1] = 14;
		}
		else
		{
			byte_0[num] = 240;
			byte_0[num + 1] = 37;
		}
		byte_0[num + 2] = 202;
		byte_0[num + 3] = 1;
		byte_0[num + 4] = 1;
		num += 6;
		if (array != null)
		{
			num += method_21(num, array);
		}
		byte_0[num] = 18;
		byte_0[num + 2] = 8;
		num += 4;
		if (radioButton_0.IsChecked)
		{
			byte_0[num] = 1;
		}
		if (radioButton_0.Shadow)
		{
			byte_0[num + 6] = 2;
		}
		else
		{
			byte_0[num + 6] = 3;
		}
		num += 8;
		byte_0[num] = 17;
		byte_0[num + 2] = 4;
		num += 4;
		byte_0[num + 2] = 1;
		num += 4;
		if (radioButton_0.method_28().arrayList_0 == null || radioButton_0.method_28().arrayList_0.Count <= 0)
		{
			return;
		}
		foreach (byte[] item2 in radioButton_0.method_28().arrayList_0)
		{
			Array.Copy(item2, 0, byte_0, num, item2.Length);
			num += (short)item2.Length;
		}
	}

	internal void method_11(CheckBox checkBox_0)
	{
		method_0((short)(base.Length + 54));
		CheckValueType checkValueType = checkBox_0.method_70();
		byte[] array = checkBox_0.method_58();
		if (array != null)
		{
			method_0((short)(base.Length + (short)(11 + array.Length)));
		}
		if (checkBox_0.method_28().arrayList_0 != null && checkBox_0.method_28().arrayList_0.Count > 0)
		{
			foreach (byte[] item in checkBox_0.method_28().arrayList_0)
			{
				method_0((short)(base.Length + (short)item.Length));
			}
		}
		byte_0 = new byte[base.Length];
		int num = method_23(checkBox_0);
		byte_0[num] = 10;
		byte_0[num + 2] = 12;
		num += 4;
		byte_0[num] = (byte)checkValueType;
		if (array != null)
		{
			byte_0[num + 2] = 12;
			byte_0[num + 4] = 201;
			byte_0[num + 5] = 1;
		}
		num += 12;
		if (array != null)
		{
			num += method_21(num, array);
		}
		if (checkBox_0.method_28().arrayList_0 != null && checkBox_0.method_28().arrayList_0.Count > 0)
		{
			foreach (byte[] item2 in checkBox_0.method_28().arrayList_0)
			{
				if (item2[0] == 4 && item2[1] == 0)
				{
					Array.Copy(item2, 0, byte_0, num, item2.Length);
					num += (short)item2.Length;
					break;
				}
			}
		}
		byte_0[num] = 18;
		byte_0[num + 2] = 8;
		num += 4;
		byte_0[num] = (byte)checkValueType;
		if (checkBox_0.Shadow)
		{
			byte_0[num + 6] = 2;
		}
		else
		{
			byte_0[num + 6] = 3;
		}
		num += 8;
		if (checkBox_0.method_28().arrayList_0 == null || checkBox_0.method_28().arrayList_0.Count <= 0)
		{
			return;
		}
		foreach (byte[] item3 in checkBox_0.method_28().arrayList_0)
		{
			if (item3[0] != 4 || item3[1] != 0)
			{
				Array.Copy(item3, 0, byte_0, num, item3.Length);
				num += (short)item3.Length;
				break;
			}
		}
	}

	internal void method_12(ComboBox comboBox_0)
	{
		method_0(70);
		if (comboBox_0.method_28().arrayList_0 != null && comboBox_0.method_28().arrayList_0.Count > 0)
		{
			foreach (byte[] item in comboBox_0.method_28().arrayList_0)
			{
				method_0((short)(base.Length + (short)item.Length));
			}
		}
		byte[] array2 = comboBox_0.method_58();
		if (array2 != null)
		{
			method_0((short)(base.Length + (short)(11 + array2.Length)));
		}
		int int_ = 0;
		byte[] array3 = comboBox_0.method_70();
		if (array3 != null)
		{
			int_ = comboBox_0.method_72();
			method_0((short)(base.Length + (short)(7 + array3.Length)));
		}
		short num = 0;
		if (comboBox_0.string_4 != null)
		{
			for (int i = 0; i < comboBox_0.string_4.Length; i++)
			{
				num = (short)(3 + comboBox_0.string_4[i].Length * 2);
				if (base.Length + num > 8224)
				{
					break;
				}
				method_0((short)(base.Length + num));
			}
		}
		byte_0 = new byte[base.Length];
		int num2 = method_23(comboBox_0);
		num2 += method_17(num2, 0, 8);
		if (comboBox_0.method_28().arrayList_0 != null && comboBox_0.method_28().arrayList_0.Count > 0)
		{
			foreach (byte[] item2 in comboBox_0.method_28().arrayList_0)
			{
				if (item2[0] == 4)
				{
					Array.Copy(item2, 0, byte_0, num2, item2.Length);
					num2 += (short)item2.Length;
					break;
				}
			}
		}
		if (array2 != null)
		{
			num2 += method_19(num2, array2);
		}
		if (comboBox_0.method_28().arrayList_0 != null && comboBox_0.method_28().arrayList_0.Count > 0)
		{
			foreach (byte[] item3 in comboBox_0.method_28().arrayList_0)
			{
				if (item3[0] != 4)
				{
					Array.Copy(item3, 0, byte_0, num2, item3.Length);
					num2 += (short)item3.Length;
					break;
				}
			}
		}
		num2 += method_20(num2, array3, int_, comboBox_0.SelectedIndex, comboBox_0.Shadow, 0, comboBox_0.DropDownLines, null, comboBox_0.string_4);
	}

	internal void method_13(ListBox listBox_0)
	{
		method_0(60);
		if (listBox_0.method_28().arrayList_0 != null && listBox_0.method_28().arrayList_0.Count > 0)
		{
			foreach (byte[] item in listBox_0.method_28().arrayList_0)
			{
				method_0((short)(base.Length + (short)item.Length));
			}
		}
		byte[] array2 = listBox_0.method_58();
		if (array2 != null)
		{
			method_0((short)(base.Length + (short)(11 + array2.Length)));
		}
		int num = 0;
		byte[] array3 = listBox_0.method_69();
		if (array3 != null)
		{
			num = listBox_0.ItemCount;
			method_0((short)(base.Length + (short)(7 + array3.Length)));
			if (listBox_0.SelectionType != 0)
			{
				method_0((short)(base.Length + (short)num));
			}
		}
		byte_0 = new byte[base.Length];
		int num2 = method_23(listBox_0);
		num2 += method_18(num2, listBox_0.method_74(), listBox_0.method_76(), listBox_0.method_78(), listBox_0.IncrementalChange, listBox_0.PageChange, listBox_0.Shadow);
		if (array2 != null)
		{
			num2 += method_19(num2, array2);
		}
		num2 += method_20(num2, array3, num, listBox_0.SelectedIndex, listBox_0.Shadow, (byte)listBox_0.SelectionType, -1, listBox_0.method_72(), null);
	}

	internal void method_14(Shape shape_0)
	{
		method_0((short)(base.Length + 24));
		byte[] array = null;
		array = ((shape_0.MsoDrawingType != MsoDrawingType.ScrollBar) ? ((Spinner)shape_0).method_58() : ((ScrollBar)shape_0).method_58());
		if (array != null)
		{
			method_0((short)(base.Length + (short)(11 + array.Length)));
		}
		byte_0 = new byte[base.Length];
		int num = method_23(shape_0);
		num = ((shape_0.MsoDrawingType != MsoDrawingType.ScrollBar) ? (num + method_15(num, (Spinner)shape_0)) : (num + method_16(num, (ScrollBar)shape_0)));
		if (array != null)
		{
			num += method_19(num, array);
		}
	}

	private int method_15(int int_0, Spinner spinner_0)
	{
		byte_0[int_0] = 12;
		byte_0[int_0 + 2] = 20;
		int_0 += 4;
		int_0 += 4;
		Array.Copy(BitConverter.GetBytes((ushort)spinner_0.CurrentValue), 0, byte_0, int_0, 2);
		Array.Copy(BitConverter.GetBytes((ushort)spinner_0.Min), 0, byte_0, int_0 + 2, 2);
		Array.Copy(BitConverter.GetBytes((ushort)spinner_0.Max), 0, byte_0, int_0 + 4, 2);
		Array.Copy(BitConverter.GetBytes((ushort)spinner_0.IncrementalChange), 0, byte_0, int_0 + 6, 2);
		Array.Copy(BitConverter.GetBytes((ushort)spinner_0.PageChange), 0, byte_0, int_0 + 8, 2);
		byte_0[int_0 + 12] = 16;
		if (spinner_0.Shadow)
		{
			byte_0[int_0 + 14] = 1;
		}
		else
		{
			byte_0[int_0 + 14] = 9;
		}
		return 24;
	}

	private int method_16(int int_0, ScrollBar scrollBar_0)
	{
		byte_0[int_0] = 12;
		byte_0[int_0 + 2] = 20;
		int_0 += 4;
		int_0 += 4;
		Array.Copy(BitConverter.GetBytes((ushort)scrollBar_0.CurrentValue), 0, byte_0, int_0, 2);
		Array.Copy(BitConverter.GetBytes((ushort)scrollBar_0.Min), 0, byte_0, int_0 + 2, 2);
		Array.Copy(BitConverter.GetBytes((ushort)scrollBar_0.Max), 0, byte_0, int_0 + 4, 2);
		Array.Copy(BitConverter.GetBytes((ushort)scrollBar_0.IncrementalChange), 0, byte_0, int_0 + 6, 2);
		Array.Copy(BitConverter.GetBytes((ushort)scrollBar_0.PageChange), 0, byte_0, int_0 + 8, 2);
		if (scrollBar_0.IsHorizontal)
		{
			byte_0[int_0 + 10] = 1;
		}
		byte_0[int_0 + 12] = 16;
		if (scrollBar_0.Shadow)
		{
			byte_0[int_0 + 14] = 1;
		}
		else
		{
			byte_0[int_0 + 14] = 9;
		}
		return 24;
	}

	private int method_17(int int_0, int int_1, int int_2)
	{
		byte_0[int_0] = 12;
		byte_0[int_0 + 2] = 20;
		int_0 += 4;
		Array.Copy(BitConverter.GetBytes((ushort)int_1), 0, byte_0, int_0 + 8, 2);
		byte_0[int_0 + 10] = 1;
		Array.Copy(BitConverter.GetBytes((ushort)int_2), 0, byte_0, int_0 + 12, 2);
		byte_0[int_0 + 16] = 16;
		byte_0[int_0 + 18] = 1;
		return 24;
	}

	private int method_18(int int_0, int int_1, int int_2, int int_3, int int_4, int int_5, bool bool_0)
	{
		byte_0[int_0] = 12;
		byte_0[int_0 + 2] = 20;
		int_0 += 4;
		int_0 += 4;
		Array.Copy(BitConverter.GetBytes((ushort)int_1), 0, byte_0, int_0, 2);
		Array.Copy(BitConverter.GetBytes((ushort)int_2), 0, byte_0, int_0 + 2, 2);
		Array.Copy(BitConverter.GetBytes((ushort)int_3), 0, byte_0, int_0 + 4, 2);
		Array.Copy(BitConverter.GetBytes((ushort)int_4), 0, byte_0, int_0 + 6, 2);
		Array.Copy(BitConverter.GetBytes((ushort)int_5), 0, byte_0, int_0 + 8, 2);
		byte_0[int_0 + 12] = 16;
		if (bool_0)
		{
			byte_0[int_0 + 14] = 1;
		}
		else
		{
			byte_0[int_0 + 14] = 9;
		}
		return 24;
	}

	private int method_19(int int_0, byte[] byte_1)
	{
		byte_0[int_0] = 14;
		byte_0[int_0 + 2] = (byte)(7 + byte_1.Length);
		int_0 += 4;
		byte_0[int_0] = (byte)byte_1.Length;
		byte_0[int_0 + 2] = 104;
		byte_0[int_0 + 3] = 42;
		byte_0[int_0 + 4] = 202;
		byte_0[int_0 + 5] = 1;
		Array.Copy(byte_1, 0, byte_0, int_0 + 6, byte_1.Length);
		return 11 + byte_1.Length;
	}

	private int method_20(int int_0, byte[] byte_1, int int_1, int int_2, bool bool_0, byte byte_2, int int_3, ArrayList arrayList_1, string[] string_0)
	{
		int num = int_0;
		byte_0[int_0] = 19;
		byte_0[int_0 + 2] = 238;
		byte_0[int_0 + 3] = 31;
		int_0 += 4;
		if (byte_1 != null)
		{
			Array.Copy(BitConverter.GetBytes((ushort)(byte_1.Length + 7)), 0, byte_0, int_0, 2);
			Array.Copy(BitConverter.GetBytes((ushort)byte_1.Length), 0, byte_0, int_0 + 2, 2);
			int_0 += 4;
			byte_0[int_0++] = 104;
			byte_0[int_0++] = 42;
			byte_0[int_0++] = 192;
			byte_0[int_0++] = 1;
			Array.Copy(byte_1, 0, byte_0, int_0, byte_1.Length);
			int_0 += byte_1.Length;
			byte_0[int_0++] = 240;
			if (int_1 != 0)
			{
				Array.Copy(BitConverter.GetBytes((ushort)int_1), 0, byte_0, int_0, 2);
			}
			int_0 += 2;
		}
		else
		{
			if (string_0 != null)
			{
				Array.Copy(BitConverter.GetBytes((ushort)string_0.Length), 0, byte_0, int_0 + 2, 2);
			}
			int_0 += 4;
		}
		if (byte_2 == 0 && int_2 != -1)
		{
			Array.Copy(BitConverter.GetBytes((ushort)(int_2 + 1)), 0, byte_0, int_0, 2);
		}
		byte b = (byte)(byte_2 << 4);
		if (string_0 != null && byte_1 == null)
		{
			b = (byte)(b | 2u);
		}
		if (!bool_0)
		{
			b = (byte)(b | 8u);
		}
		byte_0[int_0 + 2] = b;
		int_0 += 6;
		if (int_3 != -1)
		{
			Array.Copy(BitConverter.GetBytes((ushort)int_3), 0, byte_0, int_0 + 2, 2);
			int_0 += 6;
		}
		if (string_0 != null)
		{
			int_0 += 4;
			for (int i = 0; i < string_0.Length; i++)
			{
				if (int_0 >= base.Length)
				{
					int value = base.Length - (num + 4) - 1;
					Array.Copy(BitConverter.GetBytes(value), 0, byte_0, num + 2, 2);
					arrayList_0 = new ArrayList();
					byte[] array = new byte[8228];
					array[0] = 60;
					arrayList_0.Add(array);
					int num2 = 4;
					for (; i < string_0.Length; i++)
					{
						if (num2 + 3 + 2 * string_0.Length > array.Length)
						{
							Array.Copy(BitConverter.GetBytes(num2 - 4), 0, array, 2, 2);
							array = new byte[8228];
							array[0] = 60;
							arrayList_0.Add(array);
							num2 = 4;
						}
						Array.Copy(BitConverter.GetBytes((ushort)string_0[i].Length), 0, array, num2, 2);
						array[num2 + 2] = 1;
						Array.Copy(Encoding.Unicode.GetBytes(string_0[i]), 0, array, num2 + 3, string_0[i].Length * 2);
						num2 += 3 + string_0[i].Length * 2;
					}
					if (num2 > 4)
					{
						Array.Copy(BitConverter.GetBytes(num2 - 4), 0, array, 2, 2);
					}
				}
				else
				{
					Array.Copy(BitConverter.GetBytes((ushort)string_0[i].Length), 0, byte_0, int_0, 2);
					byte_0[int_0 + 2] = 1;
					Array.Copy(Encoding.Unicode.GetBytes(string_0[i]), 0, byte_0, int_0 + 3, string_0[i].Length * 2);
					int_0 += 3 + string_0[i].Length * 2;
				}
			}
		}
		if (byte_2 != 0 && arrayList_1 != null && arrayList_1.Count != 0)
		{
			foreach (ushort item in arrayList_1)
			{
				byte_0[int_0 + item] = 1;
			}
			int_0 += int_1;
		}
		return int_0 - num;
	}

	private int method_21(int int_0, byte[] byte_1)
	{
		byte_0[int_0] = 20;
		byte_0[int_0 + 2] = (byte)(7 + byte_1.Length);
		int_0 += 4;
		byte_0[int_0] = (byte)byte_1.Length;
		byte_0[int_0 + 2] = 184;
		byte_0[int_0 + 3] = 44;
		byte_0[int_0 + 4] = 202;
		byte_0[int_0 + 5] = 1;
		Array.Copy(byte_1, 0, byte_0, int_0 + 6, byte_1.Length);
		return 11 + byte_1.Length;
	}

	internal void method_22(OleObject oleObject_0)
	{
		method_0(26);
		int num = 0;
		byte[] array = null;
		bool flag = false;
		byte[] array2 = null;
		bool flag2;
		if (flag2 = oleObject_0.IsLink)
		{
			array2 = new byte[20]
			{
				9, 0, 16, 0, 14, 0, 7, 0, 232, 72,
				230, 4, 57, 0, 0, 0, 0, 0, 0, 0
			};
			int num2 = oleObject_0.method_89();
			if (num2 != -1)
			{
				Class1718 @class = oleObject_0.method_25().method_39()[num2];
				int num3 = -1;
				for (int i = 0; i < @class.method_0().Count; i++)
				{
					Class1653 class2 = (Class1653)@class.method_0()[i];
					if (class2.method_3() == oleObject_0.method_97())
					{
						num3 = i + 1;
						break;
					}
				}
				if (num3 != -1)
				{
					Array.Copy(BitConverter.GetBytes(num2), 0, array2, 13, 2);
					Array.Copy(BitConverter.GetBytes(num3), 0, array2, 15, 2);
					num = array2.Length - 4;
				}
				else
				{
					flag2 = false;
				}
			}
			else
			{
				flag2 = false;
			}
		}
		if (!flag2)
		{
			array = Class937.smethod_2(oleObject_0.ProgID);
			num = 21 + array.Length;
			if (flag = num % 2 != 0)
			{
				num++;
			}
		}
		method_0((short)(base.Length + (short)(12 + num + 4)));
		int num4 = method_6(oleObject_0);
		method_0((short)(base.Length + (short)num4));
		byte_0 = new byte[base.Length];
		int num5 = method_23(oleObject_0);
		byte_0[num5] = 7;
		byte_0[num5 + 2] = 2;
		byte_0[num5 + 4] = 2;
		num5 += 6;
		byte_0[num5] = 8;
		byte_0[num5 + 2] = 2;
		byte_0[num5 + 4] = oleObject_0.method_71();
		num5 += 6;
		if (flag2)
		{
			Array.Copy(array2, 0, byte_0, num5, array2.Length);
			num5 += array2.Length;
		}
		else
		{
			byte_0[num5] = 9;
			Array.Copy(BitConverter.GetBytes((ushort)num), 0, byte_0, num5 + 2, 2);
			num5 += 4;
			Array.Copy(BitConverter.GetBytes((ushort)(num - 6)), 0, byte_0, num5, 2);
			num5 += 2;
			byte[] array3 = new byte[12]
			{
				5, 0, 148, 14, 202, 1, 2, 220, 19, 168,
				1, 3
			};
			Array.Copy(array3, 0, byte_0, num5, array3.Length);
			num5 += array3.Length;
			Array.Copy(BitConverter.GetBytes((ushort)oleObject_0.ProgID.Length), 0, byte_0, num5, 2);
			byte_0[num5 + 2] = (byte)((array.Length != oleObject_0.ProgID.Length) ? 1u : 0u);
			num5 += 3;
			Array.Copy(array, 0, byte_0, num5, array.Length);
			num5 += array.Length;
			if (flag)
			{
				num5++;
			}
			Array.Copy(BitConverter.GetBytes(oleObject_0.method_97()), 0, byte_0, num5, 4);
			num5 += 4;
		}
		if (num4 == 0)
		{
			return;
		}
		foreach (byte[] item in oleObject_0.method_28().arrayList_0)
		{
			Array.Copy(item, 0, byte_0, num5, item.Length);
			num5 += item.Length;
		}
	}

	internal int method_23(Shape shape_0)
	{
		byte_0[0] = 21;
		byte_0[2] = 18;
		int num = 4;
		MsoDrawingType msoDrawingType = shape_0.MsoDrawingType;
		if (msoDrawingType == MsoDrawingType.OleObject)
		{
			byte_0[num] = 8;
		}
		else
		{
			byte_0[num] = (byte)shape_0.MsoDrawingType;
		}
		Array.Copy(BitConverter.GetBytes(shape_0.method_23()), 0, byte_0, num + 2, 2);
		if (shape_0.IsLocked)
		{
			byte_0[num + 4] |= 1;
		}
		if (shape_0.IsPrintable)
		{
			byte_0[num + 4] |= 16;
		}
		if (shape_0.method_28().method_6())
		{
			byte_0[num + 5] |= 1;
		}
		if (shape_0.method_28().method_2())
		{
			byte_0[num + 5] |= 32;
		}
		if (shape_0.method_28().method_4())
		{
			byte_0[num + 5] |= 64;
		}
		return num + 18;
	}

	internal void method_24(Class1725 class1725_0)
	{
		byte[] array = new byte[byte_0.Length + 4];
		Array.Copy(BitConverter.GetBytes(method_1()), 0, array, 0, 2);
		Array.Copy(BitConverter.GetBytes(base.Length), 0, array, 2, 2);
		Array.Copy(byte_0, 0, array, 4, byte_0.Length);
		class1725_0.method_3(array);
		if (arrayList_0 != null)
		{
			for (int i = 0; i < arrayList_0.Count; i++)
			{
				byte[] array2 = (byte[])arrayList_0[i];
				int num = BitConverter.ToInt16(array2, 2);
				class1725_0.method_1(array2, num + 4);
			}
		}
	}
}
