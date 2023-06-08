using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aspose.Cells;
using ns1;
using ns38;

namespace ns2;

internal class Class1653
{
	private ushort ushort_0;

	private Class1718 class1718_0;

	private string string_0;

	private int int_0;

	private byte[] byte_0;

	private string string_1;

	internal int int_1;

	private byte byte_1;

	internal int SheetIndex
	{
		get
		{
			return int_0 & 0xFFFF;
		}
		set
		{
			int_0 = value;
		}
	}

	internal string Name
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	[SpecialName]
	internal Class1718 method_0()
	{
		return class1718_0;
	}

	internal void Copy(Class1653 class1653_0)
	{
		ushort_0 = class1653_0.ushort_0;
		string_0 = class1653_0.string_0;
		int_0 = class1653_0.int_0;
		if (class1653_0.byte_0 != null)
		{
			byte_0 = new byte[class1653_0.byte_0.Length];
			Array.Copy(class1653_0.byte_0, byte_0, byte_0.Length);
		}
	}

	internal Class1653(Class1718 class1718_1)
	{
		class1718_0 = class1718_1;
	}

	[SpecialName]
	internal int method_1()
	{
		return int_0;
	}

	[SpecialName]
	internal void method_2(int int_2)
	{
		int_0 = int_2;
	}

	[SpecialName]
	internal int method_3()
	{
		return int_0;
	}

	[SpecialName]
	internal void method_4(int int_2)
	{
		int_0 = int_2;
	}

	[SpecialName]
	internal byte[] method_5()
	{
		return byte_0;
	}

	[SpecialName]
	internal void method_6(byte[] byte_2)
	{
		string_1 = null;
		byte_0 = byte_2;
	}

	internal string method_7(WorksheetCollection worksheetCollection_0)
	{
		if (string_1 == null && byte_0 != null)
		{
			string_1 = worksheetCollection_0.method_4().method_6(this);
		}
		return string_1;
	}

	internal void method_8(WorksheetCollection worksheetCollection_0, string string_2)
	{
		string_1 = string_2;
		if (string_2.Length == 0)
		{
			return;
		}
		if (string_2[0] == '=')
		{
			string_2 = string_2.Substring(1).Trim();
		}
		byte[] array = new byte[2] { 28, 23 };
		string key;
		if ((key = string_2) != null)
		{
			if (Class1742.dictionary_194 == null)
			{
				Class1742.dictionary_194 = new Dictionary<string, int>(7)
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
			if (Class1742.dictionary_194.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
				case 1:
				case 2:
				case 3:
				case 4:
				case 5:
				case 6:
					goto IL_04fb;
				}
			}
		}
		int num = string_2.LastIndexOf('!');
		if (num == -1)
		{
			string_1 = null;
		}
		else
		{
			string text = string_2.Substring(num + 1);
			if (text.ToUpper() != "#REF!")
			{
				string text2 = string_2.Substring(0, num);
				if (text2[0] == '\'')
				{
					text2 = text2.Substring(1, text2.Length - 2);
				}
				if (text2[0] == '[')
				{
					num = text2.LastIndexOf(']');
					text2 = text2.Substring(num + 1);
				}
				num = text2.IndexOf(':');
				int value3;
				int value2;
				if (num == -1)
				{
					value3 = (value2 = class1718_0.method_6(text2));
				}
				else
				{
					value3 = class1718_0.method_6(text2.Substring(0, num));
					value2 = class1718_0.method_6(text2.Substring(num + 1));
				}
				num = text.IndexOf(':');
				if (num == -1)
				{
					int row = 0;
					int column = 0;
					bool isRowAbsolute = false;
					bool isColumnAbsolute = false;
					bool isRowOnly = false;
					bool isColumnOnly = false;
					if (Class1263.CellNameToIndex(text, out row, out column, isInArea: false, ref isRowAbsolute, ref isColumnAbsolute, ref isRowOnly, ref isColumnOnly))
					{
						array = new byte[9] { 58, 0, 0, 0, 0, 0, 0, 0, 0 };
						Array.Copy(BitConverter.GetBytes(value3), 0, array, 1, 2);
						Array.Copy(BitConverter.GetBytes(value2), 0, array, 3, 2);
						Array.Copy(BitConverter.GetBytes((ushort)row), 0, array, 5, 2);
						array[7] = (byte)column;
						if (!isColumnAbsolute)
						{
							array[8] |= 64;
						}
						if (!isRowAbsolute)
						{
							array[8] |= 128;
						}
					}
				}
				else
				{
					int row2 = 0;
					int column2 = 0;
					int row3 = 0;
					int column3 = 0;
					bool isRowAbsolute2 = false;
					bool isColumnAbsolute2 = false;
					bool isRowOnly2 = false;
					bool isColumnOnly2 = false;
					bool isRowAbsolute3 = false;
					bool isColumnAbsolute3 = false;
					bool isRowOnly3 = false;
					bool isColumnOnly3 = false;
					if (Class1263.CellNameToIndex(text.Substring(0, num), out row2, out column2, isInArea: true, ref isRowAbsolute2, ref isColumnAbsolute2, ref isRowOnly2, ref isColumnOnly2) && Class1263.CellNameToIndex(text.Substring(num + 1), out row3, out column3, isInArea: true, ref isRowAbsolute3, ref isColumnAbsolute3, ref isRowOnly3, ref isColumnOnly3))
					{
						if (isRowOnly2)
						{
							if (isRowOnly3)
							{
								array = new byte[13]
								{
									59, 0, 0, 0, 0, 0, 0, 0, 0, 0,
									0, 0, 0
								};
								Array.Copy(BitConverter.GetBytes(value3), 0, array, 1, 2);
								Array.Copy(BitConverter.GetBytes(value2), 0, array, 3, 2);
								Array.Copy(BitConverter.GetBytes((ushort)row2), 0, array, 5, 2);
								Array.Copy(BitConverter.GetBytes((ushort)row3), 0, array, 7, 2);
								array[9] = 0;
								if (!isRowAbsolute2)
								{
									array[10] |= 128;
								}
								array[11] = byte.MaxValue;
								if (!isRowAbsolute3)
								{
									array[12] |= 128;
								}
							}
						}
						else if (isColumnOnly2)
						{
							if (isColumnOnly3)
							{
								array = new byte[13]
								{
									59, 0, 0, 0, 0, 0, 0, 0, 0, 0,
									0, 0, 0
								};
								Array.Copy(BitConverter.GetBytes(value3), 0, array, 1, 2);
								Array.Copy(BitConverter.GetBytes(value2), 0, array, 3, 2);
								Array.Copy(BitConverter.GetBytes((ushort)0), 0, array, 5, 2);
								Array.Copy(BitConverter.GetBytes(ushort.MaxValue), 0, array, 7, 2);
								array[9] = (byte)column2;
								if (!isColumnAbsolute2)
								{
									array[10] |= 64;
								}
								array[11] = (byte)column3;
								if (!isColumnAbsolute3)
								{
									array[12] |= 64;
								}
							}
						}
						else
						{
							array = new byte[13]
							{
								59, 0, 0, 0, 0, 0, 0, 0, 0, 0,
								0, 0, 0
							};
							Array.Copy(BitConverter.GetBytes(value3), 0, array, 1, 2);
							Array.Copy(BitConverter.GetBytes(value2), 0, array, 3, 2);
							Array.Copy(BitConverter.GetBytes((ushort)row2), 0, array, 5, 2);
							Array.Copy(BitConverter.GetBytes((ushort)row3), 0, array, 7, 2);
							array[9] = (byte)column2;
							if (!isColumnAbsolute2)
							{
								array[10] |= 64;
							}
							if (!isRowAbsolute2)
							{
								array[10] |= 128;
							}
							array[11] = (byte)column3;
							if (!isColumnAbsolute3)
							{
								array[12] |= 64;
							}
							if (!isRowAbsolute3)
							{
								array[12] |= 128;
							}
						}
					}
				}
			}
		}
		goto IL_04fb;
		IL_04fb:
		if (array != null)
		{
			if (worksheetCollection_0.Workbook.method_24())
			{
				byte_0 = new byte[array.Length + 4];
				Array.Copy(BitConverter.GetBytes(array.Length), 0, byte_0, 0, 4);
				Array.Copy(array, 0, byte_0, 4, array.Length);
			}
			else
			{
				byte_0 = new byte[array.Length + 2];
				Array.Copy(BitConverter.GetBytes(array.Length), 0, byte_0, 0, 2);
				Array.Copy(array, 0, byte_0, 2, array.Length);
			}
		}
	}

	internal bool method_9(bool bool_0, ref int int_2, ref int int_3, ref int int_4, ref int int_5, ref int int_6, ref int int_7)
	{
		if (byte_0 != null && byte_0.Length > 2)
		{
			if (bool_0)
			{
				int num = 4;
				switch (byte_0[4])
				{
				case 58:
				case 90:
				case 122:
					if (byte_0.Length == 13)
					{
						int_2 = BitConverter.ToUInt16(byte_0, num + 1);
						int_3 = BitConverter.ToUInt16(byte_0, num + 3);
						int_4 = BitConverter.ToUInt16(byte_0, num + 5);
						int_6 = byte_0[num + 7];
						int_5 = int_4;
						int_7 = int_6;
						return true;
					}
					break;
				case 59:
				case 91:
				case 123:
					if (byte_0.Length == 17)
					{
						int_2 = BitConverter.ToUInt16(byte_0, num + 1);
						int_3 = BitConverter.ToUInt16(byte_0, num + 3);
						int_4 = BitConverter.ToUInt16(byte_0, num + 5);
						int_5 = BitConverter.ToUInt16(byte_0, num + 7);
						int_6 = byte_0[num + 9];
						int_7 = byte_0[num + 11];
						return true;
					}
					break;
				}
			}
			else
			{
				int num2 = 2;
				switch (byte_0[2])
				{
				case 58:
				case 90:
				case 122:
					if (byte_0.Length == 11)
					{
						int_2 = BitConverter.ToUInt16(byte_0, num2 + 1);
						int_3 = BitConverter.ToUInt16(byte_0, num2 + 3);
						int_4 = BitConverter.ToUInt16(byte_0, num2 + 5);
						int_6 = byte_0[num2 + 7];
						int_5 = int_4;
						int_7 = int_6;
						return true;
					}
					break;
				case 59:
				case 91:
				case 123:
					if (byte_0.Length == 15)
					{
						int_2 = BitConverter.ToUInt16(byte_0, num2 + 1);
						int_3 = BitConverter.ToUInt16(byte_0, num2 + 3);
						int_4 = BitConverter.ToUInt16(byte_0, num2 + 5);
						int_5 = BitConverter.ToUInt16(byte_0, num2 + 7);
						int_6 = byte_0[num2 + 9];
						int_7 = byte_0[num2 + 11];
						return true;
					}
					break;
				}
			}
			return false;
		}
		return false;
	}

	[SpecialName]
	internal ushort method_10()
	{
		return ushort_0;
	}

	[SpecialName]
	internal void method_11(ushort ushort_1)
	{
		ushort_0 = ushort_1;
	}

	[SpecialName]
	internal byte[] method_12()
	{
		return byte_0;
	}

	[SpecialName]
	internal void method_13(byte[] byte_2)
	{
		byte_0 = byte_2;
	}

	[SpecialName]
	internal bool method_14()
	{
		return (ushort_0 & 1) != 0;
	}

	[SpecialName]
	internal bool method_15()
	{
		return (ushort_0 & 8) != 0;
	}

	[SpecialName]
	internal void method_16(bool bool_0)
	{
		if (bool_0)
		{
			ushort_0 |= 65528;
		}
		else
		{
			ushort_0 &= 65527;
		}
	}

	[SpecialName]
	internal bool method_17()
	{
		return (byte_1 & 1) != 0;
	}

	[SpecialName]
	internal void method_18(bool bool_0)
	{
		if (bool_0)
		{
			byte_1 |= 1;
		}
		else
		{
			byte_1 &= 254;
		}
	}

	[SpecialName]
	internal bool method_19()
	{
		return (byte_1 & 8) != 0;
	}

	[SpecialName]
	internal void method_20(bool bool_0)
	{
		if (bool_0)
		{
			byte_1 |= 8;
		}
		else
		{
			byte_1 &= 247;
		}
	}

	internal void method_21(string string_2, bool bool_0)
	{
		string_0 = string_2;
		if (bool_0)
		{
			byte_0 = new byte[6] { 2, 0, 0, 0, 28, 23 };
		}
		else
		{
			byte_0 = new byte[4] { 2, 0, 28, 23 };
		}
	}
}
