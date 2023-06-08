using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using Aspose.Cells;
using ns1;
using ns12;
using ns16;
using ns2;
using ns45;
using ns58;

namespace ns51;

internal class Class1272
{
	private static char[] char_0 = new char[11]
	{
		'+', '-', '*', '/', '<', '>', '=', '^', '&', '(',
		')'
	};

	private static string string_0 = "Invalid formula:";

	private int int_0;

	private ArrayList arrayList_0;

	private Cell cell_0;

	private int int_1;

	private int int_2;

	private WorksheetCollection worksheetCollection_0;

	private byte byte_0;

	private bool bool_0;

	[SpecialName]
	public void method_0(Cell cell_1)
	{
		cell_0 = cell_1;
	}

	internal void method_1(Cell cell_1, int int_3, int int_4, int int_5)
	{
		cell_0 = cell_1;
		int_1 = int_3;
		int_2 = int_4;
		byte_0 = (byte)int_5;
		int_0 = 0;
		arrayList_0 = new ArrayList();
	}

	[SpecialName]
	internal bool method_2()
	{
		return (byte_0 & 1) != 0;
	}

	[SpecialName]
	internal bool method_3()
	{
		return (byte_0 & 0x10) != 0;
	}

	[SpecialName]
	internal void method_4(bool bool_1)
	{
		if (bool_1)
		{
			byte_0 |= 16;
		}
		else
		{
			byte_0 &= 239;
		}
	}

	internal Class1272(WorksheetCollection worksheetCollection_1)
	{
		worksheetCollection_0 = worksheetCollection_1;
		int_0 = 0;
		arrayList_0 = new ArrayList();
	}

	internal byte[] method_5(Class1661 class1661_0, Enum227 enum227_0, Enum226 enum226_0, bool bool_1)
	{
		int num = method_6(class1661_0, enum227_0, enum226_0, bool_1: false);
		if (bool_0)
		{
			num += 4;
		}
		byte[] array = new byte[num + (bool_1 ? (8 + int_0) : 0)];
		int num2 = 0;
		int num3 = num;
		if (bool_1)
		{
			Array.Copy(BitConverter.GetBytes(num), 0, array, 0, 4);
			num2 = 4;
			num3 += 4;
		}
		if (bool_0)
		{
			array[num2++] = 25;
			array[num2++] = 1;
			num2 += 2;
			bool_0 = false;
		}
		num2 = CopyData(class1661_0, array, num2);
		if (bool_1 && int_0 != 0)
		{
			Array.Copy(BitConverter.GetBytes(int_0), 0, array, num3, 4);
			num3 += 4;
			for (int i = 0; i < arrayList_0.Count; i++)
			{
				byte[] array2 = (byte[])arrayList_0[i];
				Array.Copy(array2, 0, array, num3, array2.Length);
				num3 += array2.Length;
			}
			arrayList_0 = null;
			int_0 = 0;
		}
		return array;
	}

	private int method_6(Class1661 class1661_0, Enum227 enum227_0, Enum226 enum226_0, bool bool_1)
	{
		int num = 0;
		if (class1661_0.method_9() == null)
		{
			Enum227[] enum227_ = Class1663.enum227_2;
			enum227_ = method_8(class1661_0, enum227_0, enum226_0);
			if (class1661_0.Type != 0 && class1661_0.method_7() != null && class1661_0.method_7().Count > 0)
			{
				for (int i = 0; i < class1661_0.method_7().Count; i++)
				{
					Class1661 class1661_ = (Class1661)class1661_0.method_7()[i];
					Enum227 @enum = ((enum227_ != null && enum227_.Length != 0) ? ((i < enum227_.Length) ? enum227_[i] : enum227_[enum227_.Length - 1]) : Enum227.const_0);
					bool bool_2;
					if (!(bool_2 = bool_1))
					{
						switch (enum226_0)
						{
						case Enum226.const_0:
							bool_2 = @enum == Enum227.const_2;
							break;
						case Enum226.const_1:
							bool_2 = @enum == Enum227.const_2 || @enum == Enum227.const_0;
							break;
						case Enum226.const_2:
							bool_2 = @enum == Enum227.const_2 || @enum == Enum227.const_0;
							break;
						}
					}
					else if (@enum == Enum227.const_1)
					{
						@enum = Enum227.const_2;
					}
					num += method_6(class1661_, @enum, enum226_0, bool_2);
				}
			}
		}
		else
		{
			Enum227 enum227_2 = Enum227.const_1;
			if (bool_1)
			{
				enum227_2 = Enum227.const_2;
			}
			for (int j = 0; j < class1661_0.method_7().Count; j++)
			{
				Class1661 class1661_2 = (Class1661)class1661_0.method_7()[j];
				num += method_6(class1661_2, enum227_2, enum226_0, bool_1);
			}
		}
		int num2 = num + class1661_0.method_9().Length;
		switch (class1661_0.Type)
		{
		case Enum180.const_3:
		{
			string text;
			if ((text = class1661_0.method_3()) != null && text == "IF")
			{
				num2 += class1661_0.method_7().Count * 4;
			}
			break;
		}
		case Enum180.const_5:
			num2 += 4;
			break;
		case Enum180.const_7:
			num2 += class1661_0.method_7().Count - 1;
			break;
		}
		return num2;
	}

	internal int CopyData(Class1661 class1661_0, byte[] byte_1, int int_3)
	{
		switch (class1661_0.Type)
		{
		case Enum180.const_3:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count > 0)
			{
				string text;
				if ((text = class1661_0.method_3()) != null && text == "IF")
				{
					int num = 0;
					for (int k = 0; k < class1661_0.method_7().Count; k++)
					{
						Class1661 class1661_3 = (Class1661)class1661_0.method_7()[k];
						int_3 = CopyData(class1661_3, byte_1, int_3);
						switch (k)
						{
						case 0:
							byte_1[int_3] = 25;
							byte_1[int_3 + 1] = 2;
							int_3 += 4;
							num = int_3;
							break;
						case 1:
							byte_1[int_3] = 25;
							byte_1[int_3 + 1] = 8;
							if (class1661_0.method_7().Count > 2)
							{
								int_3 += 4;
								Array.Copy(BitConverter.GetBytes((ushort)(int_3 - num)), 0, byte_1, num - 2, 2);
								num = int_3;
							}
							else
							{
								byte_1[int_3 + 2] = 3;
								byte_1[int_3 + 3] = 0;
								int_3 += 4;
								Array.Copy(BitConverter.GetBytes((ushort)(int_3 - num)), 0, byte_1, num - 2, 2);
							}
							break;
						case 2:
							byte_1[int_3] = 25;
							byte_1[int_3 + 1] = 8;
							byte_1[int_3 + 2] = 3;
							byte_1[int_3 + 3] = 0;
							int_3 += 4;
							Array.Copy(BitConverter.GetBytes((ushort)(int_3 - num + 3)), 0, byte_1, num - 2, 2);
							break;
						}
					}
				}
				else
				{
					for (int l = 0; l < class1661_0.method_7().Count; l++)
					{
						Class1661 class1661_4 = (Class1661)class1661_0.method_7()[l];
						int_3 = CopyData(class1661_4, byte_1, int_3);
					}
				}
			}
			Array.Copy(class1661_0.method_9(), 0, byte_1, int_3, class1661_0.method_9().Length);
			int_3 += class1661_0.method_9().Length;
			break;
		case Enum180.const_5:
			Array.Copy(class1661_0.method_9(), 0, byte_1, int_3, class1661_0.method_9().Length);
			int_3 += class1661_0.method_9().Length;
			if (class1661_0.method_7() != null && class1661_0.method_7().Count > 0)
			{
				for (int m = 0; m < class1661_0.method_7().Count; m++)
				{
					Class1661 class1661_5 = (Class1661)class1661_0.method_7()[m];
					int_3 = CopyData(class1661_5, byte_1, int_3);
				}
			}
			if (class1661_0.method_9()[0] == 99)
			{
				byte_1[int_3] = 98;
			}
			else
			{
				byte_1[int_3] = 66;
			}
			if (class1661_0.method_7() == null)
			{
				byte_1[int_3 + 1] = 1;
			}
			else
			{
				byte_1[int_3 + 1] = (byte)(class1661_0.method_7().Count + 1);
			}
			byte_1[int_3 + 2] = byte.MaxValue;
			int_3 += 4;
			break;
		default:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count > 0)
			{
				for (int j = 0; j < class1661_0.method_7().Count; j++)
				{
					Class1661 class1661_2 = (Class1661)class1661_0.method_7()[j];
					int_3 = CopyData(class1661_2, byte_1, int_3);
				}
			}
			Array.Copy(class1661_0.method_9(), 0, byte_1, int_3, class1661_0.method_9().Length);
			int_3 += class1661_0.method_9().Length;
			break;
		case Enum180.const_7:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count > 0)
			{
				for (int i = 0; i < class1661_0.method_7().Count; i++)
				{
					Class1661 class1661_ = (Class1661)class1661_0.method_7()[i];
					int_3 = CopyData(class1661_, byte_1, int_3);
					if (i != 0)
					{
						byte_1[int_3++] = 16;
					}
				}
			}
			byte_1[int_3++] = 21;
			break;
		case Enum180.const_0:
			Array.Copy(class1661_0.method_9(), 0, byte_1, int_3, class1661_0.method_9().Length);
			int_3 += class1661_0.method_9().Length;
			break;
		}
		return int_3;
	}

	private void method_7(Class1661 class1661_0)
	{
		string text = class1661_0.method_3();
		if (text != null && text.Length != 0)
		{
			if (text[0] == '"')
			{
				text = text.Substring(1, text.Length - 2);
				if (text.Length == 0)
				{
					class1661_0.method_10(new byte[3]);
					class1661_0.method_9()[0] = 1;
					return;
				}
			}
			else
			{
				if (Class1673.smethod_8(text))
				{
					class1661_0.method_10(new byte[5]);
					class1661_0.method_9()[0] = 4;
					string key;
					if ((key = text) == null)
					{
						return;
					}
					if (Class1742.dictionary_80 == null)
					{
						Class1742.dictionary_80 = new Dictionary<string, int>(7)
						{
							{ "#DIV/0!", 0 },
							{ "#NULL!", 1 },
							{ "#N/A", 2 },
							{ "#NAME?", 3 },
							{ "#NUM!", 4 },
							{ "#REF!", 5 },
							{ "#VALUE!", 6 }
						};
					}
					if (Class1742.dictionary_80.TryGetValue(key, out var value))
					{
						switch (value)
						{
						case 0:
							class1661_0.method_9()[1] = 7;
							break;
						case 1:
							class1661_0.method_9()[1] = 0;
							break;
						case 2:
							class1661_0.method_9()[1] = 42;
							break;
						case 3:
							class1661_0.method_9()[1] = 29;
							break;
						case 4:
							class1661_0.method_9()[1] = 36;
							break;
						case 5:
							class1661_0.method_9()[1] = 23;
							break;
						case 6:
							class1661_0.method_9()[1] = 15;
							break;
						}
					}
					return;
				}
				if (Class1677.smethod_18(text))
				{
					double value2 = double.Parse(text, CultureInfo.InvariantCulture);
					class1661_0.method_10(new byte[9]);
					class1661_0.method_9()[0] = 0;
					Array.Copy(BitConverter.GetBytes(value2), 0, class1661_0.method_9(), 1, 8);
					return;
				}
				if (text.ToUpper().Equals("TRUE"))
				{
					class1661_0.method_10(new byte[2]);
					class1661_0.method_9()[0] = 2;
					class1661_0.method_9()[1] = 1;
					return;
				}
				if (text.ToUpper().Equals("FALSE"))
				{
					class1661_0.method_10(new byte[2]);
					class1661_0.method_9()[0] = 2;
					return;
				}
			}
			class1661_0.method_10(new byte[3 + text.Length * 2]);
			class1661_0.method_9()[0] = 1;
			Array.Copy(BitConverter.GetBytes(text.Length), 0, class1661_0.method_9(), 1, 2);
			Array.Copy(Encoding.Unicode.GetBytes(text), 0, class1661_0.method_9(), 3, text.Length * 2);
		}
		else
		{
			class1661_0.method_10(new byte[3]);
			class1661_0.method_9()[0] = 1;
		}
	}

	private Enum227[] method_8(Class1661 class1661_0, Enum227 enum227_0, Enum226 enum226_0)
	{
		string text = class1661_0.method_3();
		if (text == null)
		{
			class1661_0.method_10(Class1128.byte_4);
			return Class1663.enum227_3;
		}
		Enum227[] enum227_ = Class1663.enum227_3;
		switch (class1661_0.Type)
		{
		case Enum180.const_0:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0)
			{
				object obj = class1661_0.method_7()[0];
				if (obj == null)
				{
					class1661_0.method_10(new byte[15]);
					class1661_0.method_9()[0] = 96;
					int_0 += 8;
					arrayList_0.Add(new byte[8]);
					return Class1663.enum227_4;
				}
				if (obj is Class1661[][])
				{
					Class1661[][] array = (Class1661[][])obj;
					class1661_0.method_10(new byte[15]);
					if (enum227_0 == Enum227.const_1)
					{
						class1661_0.method_9()[0] = 64;
					}
					else
					{
						class1661_0.method_9()[0] = 96;
					}
					ArrayList arrayList = new ArrayList();
					int num2 = 8;
					for (int i = 0; i < array.Length; i++)
					{
						for (int j = 0; j < array[i].Length; j++)
						{
							Class1661 class2 = array[i][j];
							method_7(class2);
							arrayList.Add(class2.method_9());
							num2 += class2.method_9().Length;
						}
					}
					byte[] array2 = new byte[num2];
					arrayList_0.Add(array2);
					int_0 += num2;
					Array.Copy(BitConverter.GetBytes(array[0].Length), 0, array2, 0, 4);
					Array.Copy(BitConverter.GetBytes(array.Length), 0, array2, 4, 4);
					int num3 = 8;
					for (int k = 0; k < arrayList.Count; k++)
					{
						byte[] array3 = (byte[])arrayList[k];
						Array.Copy(array3, 0, array2, num3, array3.Length);
						num3 += array3.Length;
					}
				}
				return Class1663.enum227_4;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
		case Enum180.const_1:
		{
			string key2;
			if ((key2 = text.ToUpper()) != null)
			{
				if (Class1742.dictionary_81 == null)
				{
					Class1742.dictionary_81 = new Dictionary<string, int>(12)
					{
						{ "", 0 },
						{ "\"\"", 1 },
						{ "#NULL!", 2 },
						{ "#DIV/0!", 3 },
						{ "#VALUE!", 4 },
						{ "#REF!", 5 },
						{ "#NAME?", 6 },
						{ "#NUM!", 7 },
						{ "#N/A", 8 },
						{ "FALSE", 9 },
						{ "TRUE", 10 },
						{ "()", 11 }
					};
				}
				if (Class1742.dictionary_81.TryGetValue(key2, out var value2))
				{
					switch (value2)
					{
					case 0:
					case 1:
						class1661_0.method_10(new byte[3]);
						class1661_0.method_9()[0] = 23;
						return Class1663.enum227_2;
					case 2:
						class1661_0.method_10(new byte[2]);
						class1661_0.method_9()[0] = 28;
						class1661_0.method_9()[1] = 0;
						return Class1663.enum227_2;
					case 3:
						class1661_0.method_10(new byte[2]);
						class1661_0.method_9()[0] = 28;
						class1661_0.method_9()[1] = 7;
						return Class1663.enum227_2;
					case 4:
						class1661_0.method_10(new byte[2]);
						class1661_0.method_9()[0] = 28;
						class1661_0.method_9()[1] = 15;
						return Class1663.enum227_2;
					case 5:
						class1661_0.method_10(new byte[2]);
						class1661_0.method_9()[0] = 28;
						class1661_0.method_9()[1] = 23;
						return Class1663.enum227_2;
					case 6:
						class1661_0.method_10(new byte[2]);
						class1661_0.method_9()[0] = 28;
						class1661_0.method_9()[1] = 29;
						return Class1663.enum227_2;
					case 7:
						class1661_0.method_10(new byte[2]);
						class1661_0.method_9()[0] = 28;
						class1661_0.method_9()[1] = 36;
						return Class1663.enum227_2;
					case 8:
						class1661_0.method_10(new byte[2]);
						class1661_0.method_9()[0] = 28;
						class1661_0.method_9()[1] = 42;
						return Class1663.enum227_2;
					case 9:
						break;
					case 10:
						goto IL_043b;
					case 11:
						class1661_0.method_10(new byte[1]);
						class1661_0.method_9()[0] = 21;
						return new Enum227[1] { enum227_0 };
					default:
						goto IL_0482;
					}
					class1661_0.method_10(new byte[2]);
					class1661_0.method_9()[0] = 29;
					goto IL_048a;
				}
			}
			goto IL_0482;
		}
		default:
		{
			string key;
			if ((key = text) != null)
			{
				if (Class1742.dictionary_82 == null)
				{
					Class1742.dictionary_82 = new Dictionary<string, int>(263)
					{
						{ " ", 0 },
						{ "+", 1 },
						{ "-", 2 },
						{ "*", 3 },
						{ "/", 4 },
						{ "^", 5 },
						{ "&", 6 },
						{ ",", 7 },
						{ ":", 8 },
						{ "%", 9 },
						{ "()", 10 },
						{ "<", 11 },
						{ "=", 12 },
						{ "<=", 13 },
						{ ">=", 14 },
						{ ">", 15 },
						{ "<>", 16 },
						{ "ABS", 17 },
						{ "ACOS", 18 },
						{ "ACOSH", 19 },
						{ "ADDRESS", 20 },
						{ "ASC", 21 },
						{ "ASIN", 22 },
						{ "ASINH", 23 },
						{ "AND", 24 },
						{ "ARCTAN", 25 },
						{ "ATAN", 26 },
						{ "ATAN2", 27 },
						{ "ATANH", 28 },
						{ "AVEDEV", 29 },
						{ "AVERAGE", 30 },
						{ "AVERAGEA", 31 },
						{ "BETADIST", 32 },
						{ "BETAINV", 33 },
						{ "BINOMDIST", 34 },
						{ "CELL", 35 },
						{ "CEILING", 36 },
						{ "CHAR", 37 },
						{ "CHIDIST", 38 },
						{ "CHIINV", 39 },
						{ "CHITEST", 40 },
						{ "CHOOSE", 41 },
						{ "CLEAN", 42 },
						{ "CODE", 43 },
						{ "COLUMN", 44 },
						{ "COLUMNS", 45 },
						{ "COMBIN", 46 },
						{ "CONCATENATE", 47 },
						{ "CONFIDENCE", 48 },
						{ "CORREL", 49 },
						{ "COS", 50 },
						{ "COSH", 51 },
						{ "COUNT", 52 },
						{ "COUNTA", 53 },
						{ "COUNTBLANK", 54 },
						{ "COUNTIF", 55 },
						{ "COVAR", 56 },
						{ "CRITBINOM", 57 },
						{ "DATE", 58 },
						{ "DATEDIF", 59 },
						{ "DATESTRING", 60 },
						{ "DATEVALUE", 61 },
						{ "DAVERAGE", 62 },
						{ "DAYS360", 63 },
						{ "DCOUNT", 64 },
						{ "DCOUNTA", 65 },
						{ "DAY", 66 },
						{ "DB", 67 },
						{ "DDB", 68 },
						{ "DGET", 69 },
						{ "DEGREES", 70 },
						{ "DEVSQ", 71 },
						{ "DMAX", 72 },
						{ "DMIN", 73 },
						{ "DOLLAR", 74 },
						{ "DPRODUCT", 75 },
						{ "DSTDEV", 76 },
						{ "DSTDEVP", 77 },
						{ "DSUM", 78 },
						{ "DVAR", 79 },
						{ "DVARP", 80 },
						{ "ERROR.TYPE", 81 },
						{ "EVEN", 82 },
						{ "EXACT", 83 },
						{ "EXP", 84 },
						{ "EXPONDIST", 85 },
						{ "FACT", 86 },
						{ "FALSE", 87 },
						{ "FDIST", 88 },
						{ "FINV", 89 },
						{ "FIND", 90 },
						{ "FINDB", 91 },
						{ "FIXED", 92 },
						{ "FLOOR", 93 },
						{ "FORECAST", 94 },
						{ "FREQUENCY", 95 },
						{ "FTEST", 96 },
						{ "FV", 97 },
						{ "GAMMADIST", 98 },
						{ "GAMMAINV", 99 },
						{ "GAMMALN", 100 },
						{ "GEOMEAN", 101 },
						{ "GETPIVOTDATA", 102 },
						{ "HARMEAN", 103 },
						{ "HLOOKUP", 104 },
						{ "HOUR", 105 },
						{ "HYPERLINK", 106 },
						{ "HYPGEOMVERT", 107 },
						{ "IF", 108 },
						{ "INDEX", 109 },
						{ "INDIRECT", 110 },
						{ "INFO", 111 },
						{ "INT", 112 },
						{ "INTERCEPT", 113 },
						{ "IPMT", 114 },
						{ "IRR", 115 },
						{ "ISBLANK", 116 },
						{ "ISERR", 117 },
						{ "ISLOGICAL", 118 },
						{ "ISERROR", 119 },
						{ "ISNA", 120 },
						{ "ISNONTEXT", 121 },
						{ "ISNUMBER", 122 },
						{ "ISPMT", 123 },
						{ "ISREF", 124 },
						{ "ISTEXT", 125 },
						{ "KURT", 126 },
						{ "LARGE", 127 },
						{ "LEFT", 128 },
						{ "LEFTB", 129 },
						{ "LEN", 130 },
						{ "LENB", 131 },
						{ "LINEST", 132 },
						{ "LN", 133 },
						{ "LOG", 134 },
						{ "LOG10", 135 },
						{ "LOGNORMDIST", 136 },
						{ "LOGINV", 137 },
						{ "LOGEST", 138 },
						{ "NEGBINOMDIST", 139 },
						{ "LOOKUP", 140 },
						{ "LOWER", 141 },
						{ "MATCH", 142 },
						{ "MAX", 143 },
						{ "MAXA", 144 },
						{ "MEDIAN", 145 },
						{ "MDETERM", 146 },
						{ "MINVERSE", 147 },
						{ "MID", 148 },
						{ "MIDB", 149 },
						{ "MIN", 150 },
						{ "MINA", 151 },
						{ "MINUTE", 152 },
						{ "MIRR", 153 },
						{ "MMULT", 154 },
						{ "MOD", 155 },
						{ "MODE", 156 },
						{ "MONTH", 157 },
						{ "N", 158 },
						{ "NA", 159 },
						{ "NORMDIST", 160 },
						{ "NORMSDIST", 161 },
						{ "NORMINV", 162 },
						{ "NORMSINV", 163 },
						{ "NOT", 164 },
						{ "NOW", 165 },
						{ "NUMBERSTRING", 166 },
						{ "NPER", 167 },
						{ "NPV", 168 },
						{ "ODD", 169 },
						{ "OFFSET", 170 },
						{ "OR", 171 },
						{ "PEARSON", 172 },
						{ "PERCENTILE", 173 },
						{ "PERCENTRANK", 174 },
						{ "PERMUT", 175 },
						{ "PHONETIC", 176 },
						{ "PI", 177 },
						{ "PMT", 178 },
						{ "POISSON", 179 },
						{ "POWER", 180 },
						{ "PPMT", 181 },
						{ "PROB", 182 },
						{ "PRODUCT", 183 },
						{ "PROPER", 184 },
						{ "PV", 185 },
						{ "QUARTILE", 186 },
						{ "RADIANS", 187 },
						{ "RAND", 188 },
						{ "RANK", 189 },
						{ "RATE", 190 },
						{ "REPLACE", 191 },
						{ "REPLACEB", 192 },
						{ "REPT", 193 },
						{ "RIGHT", 194 },
						{ "RIGHTB", 195 },
						{ "ROMAN", 196 },
						{ "ROUND", 197 },
						{ "ROUNDDOWN", 198 },
						{ "ROUNDUP", 199 },
						{ "ROW", 200 },
						{ "ROWS", 201 },
						{ "RSQ", 202 },
						{ "SEARCH", 203 },
						{ "SEARCHB", 204 },
						{ "SECOND", 205 },
						{ "SIGN", 206 },
						{ "SIN", 207 },
						{ "SINH", 208 },
						{ "SKEW", 209 },
						{ "SLN", 210 },
						{ "SMALL", 211 },
						{ "SQRT", 212 },
						{ "STANDARDIZE", 213 },
						{ "STDEV", 214 },
						{ "STDEV.S", 215 },
						{ "_XLFN.STDEV.S", 216 },
						{ "STDEVA", 217 },
						{ "STDEVP", 218 },
						{ "STDEV.P", 219 },
						{ "_XLFN.STDEV.P", 220 },
						{ "STDEVPA", 221 },
						{ "STEYX", 222 },
						{ "SUBSTITUTE", 223 },
						{ "SUBTOTAL", 224 },
						{ "SUM", 225 },
						{ "SUMPRODUCT", 226 },
						{ "SUMIF", 227 },
						{ "SUMSQ", 228 },
						{ "SUMX2MY2", 229 },
						{ "SUMX2PY2", 230 },
						{ "SUMXMY2", 231 },
						{ "SYD", 232 },
						{ "T", 233 },
						{ "TAN", 234 },
						{ "TANH", 235 },
						{ "TDIST", 236 },
						{ "TEXT", 237 },
						{ "TIME", 238 },
						{ "TIMEVALUE", 239 },
						{ "TINV", 240 },
						{ "TODAY", 241 },
						{ "TRANSPOSE", 242 },
						{ "TREND", 243 },
						{ "TRIM", 244 },
						{ "TRIMMEAN", 245 },
						{ "TRUE", 246 },
						{ "TRUNC", 247 },
						{ "TTEST", 248 },
						{ "TYPE", 249 },
						{ "UPPER", 250 },
						{ "VALUE", 251 },
						{ "VAR", 252 },
						{ "VARA", 253 },
						{ "VARP", 254 },
						{ "VARPA", 255 },
						{ "VDB", 256 },
						{ "VLOOKUP", 257 },
						{ "WEEKDAY", 258 },
						{ "WEIBULL", 259 },
						{ "WIDECHAR", 260 },
						{ "YEAR", 261 },
						{ "ZTEST", 262 }
					};
				}
				if (Class1742.dictionary_82.TryGetValue(key, out var value))
				{
					switch (value)
					{
					case 0:
						break;
					case 1:
						goto IL_1814;
					case 2:
						goto IL_1880;
					case 3:
						goto IL_18ec;
					case 4:
						goto IL_1926;
					case 5:
						goto IL_1960;
					case 6:
						goto IL_199a;
					case 7:
						goto IL_19d4;
					case 8:
						goto IL_19ea;
					case 9:
						goto IL_1a24;
					case 10:
						goto IL_1a3a;
					case 11:
						goto IL_1a5a;
					case 12:
						goto IL_1a70;
					case 13:
						goto IL_1a86;
					case 14:
						goto IL_1a9c;
					case 15:
						goto IL_1ab2;
					case 16:
						goto IL_1ac8;
					case 17:
						goto IL_1ade;
					case 18:
						goto IL_1b13;
					case 19:
						goto IL_1b48;
					case 20:
						goto IL_1b80;
					case 21:
						goto IL_1b94;
					case 22:
						goto IL_1bcc;
					case 23:
						goto IL_1c01;
					case 24:
						goto IL_1c39;
					case 25:
						goto IL_1c6b;
					case 26:
						goto IL_1ca0;
					case 27:
						goto IL_1cd5;
					case 28:
						goto IL_1d0a;
					case 29:
						goto IL_1d42;
					case 30:
						goto IL_1d77;
					case 31:
						goto IL_1da8;
					case 32:
						goto IL_1ddd;
					case 33:
						goto IL_1e21;
					case 34:
						goto IL_1e65;
					case 35:
						goto IL_1e9d;
					case 36:
						goto IL_1ee0;
					case 37:
						goto IL_1f18;
					case 38:
						goto IL_1f4d;
					case 39:
						goto IL_1f85;
					case 40:
						goto IL_1fbd;
					case 41:
						goto IL_1ff5;
					case 42:
						goto IL_2028;
					case 43:
						goto IL_2060;
					case 44:
						goto IL_2095;
					case 45:
						goto IL_20c8;
					case 46:
						goto IL_20fd;
					case 47:
						goto IL_2135;
					case 48:
						goto IL_216b;
					case 49:
						goto IL_21a3;
					case 50:
						goto IL_21db;
					case 51:
						goto IL_2210;
					case 52:
						goto IL_2248;
					case 53:
						goto IL_2279;
					case 54:
						goto IL_22ae;
					case 55:
						goto IL_22e6;
					case 56:
						goto IL_231e;
					case 57:
						goto IL_2356;
					case 58:
						goto IL_238e;
					case 59:
						goto IL_23c3;
					case 60:
						goto IL_23fb;
					case 61:
						goto IL_2433;
					case 62:
						goto IL_246b;
					case 63:
						goto IL_24a0;
					case 64:
						goto IL_24e6;
					case 65:
						goto IL_251b;
					case 66:
						goto IL_2553;
					case 67:
						goto IL_2588;
					case 68:
						goto IL_25ce;
					case 69:
						goto IL_2614;
					case 70:
						goto IL_264c;
					case 71:
						goto IL_2684;
					case 72:
						goto IL_26ac;
					case 73:
						goto IL_26e1;
					case 74:
						goto IL_2716;
					case 75:
						goto IL_275c;
					case 76:
						goto IL_2794;
					case 77:
						goto IL_27c9;
					case 78:
						goto IL_2801;
					case 79:
						goto IL_2836;
					case 80:
						goto IL_286b;
					case 81:
						goto IL_28a3;
					case 82:
						goto IL_28db;
					case 83:
						goto IL_2913;
					case 84:
						goto IL_2948;
					case 85:
						goto IL_297d;
					case 86:
						goto IL_29b5;
					case 87:
						goto IL_29ed;
					case 88:
						goto IL_2a1f;
					case 89:
						goto IL_2a57;
					case 90:
						goto IL_2a8f;
					case 91:
						goto IL_2ad2;
					case 92:
						goto IL_2b18;
					case 93:
						goto IL_2b59;
					case 94:
						goto IL_2b91;
					case 95:
						goto IL_2bc9;
					case 96:
						goto IL_2c01;
					case 97:
						goto IL_2c39;
					case 98:
						goto IL_2c7a;
					case 99:
						goto IL_2cb2;
					case 100:
						goto IL_2cea;
					case 101:
						goto IL_2d22;
					case 102:
						goto IL_2d4a;
					case 103:
						goto IL_2d80;
					case 104:
						goto IL_2da8;
					case 105:
						goto IL_2de9;
					case 106:
						goto IL_2e1e;
					case 107:
						goto IL_2e64;
					case 108:
						goto IL_2e9c;
					case 109:
						goto IL_2ede;
					case 110:
						goto IL_2f1f;
					case 111:
						goto IL_2f6c;
					case 112:
						goto IL_2fa4;
					case 113:
						goto IL_2fd9;
					case 114:
						goto IL_3011;
					case 115:
						goto IL_3055;
					case 116:
						goto IL_3098;
					case 117:
						goto IL_30d0;
					case 118:
						goto IL_3105;
					case 119:
						goto IL_313d;
					case 120:
						goto IL_3171;
					case 121:
						goto IL_31a5;
					case 122:
						goto IL_31dd;
					case 123:
						goto IL_3215;
					case 124:
						goto IL_324d;
					case 125:
						goto IL_3282;
					case 126:
						goto IL_32b7;
					case 127:
						goto IL_32df;
					case 128:
						goto IL_3317;
					case 129:
						goto IL_335a;
					case 130:
						goto IL_33a0;
					case 131:
						goto IL_33d5;
					case 132:
						goto IL_340d;
					case 133:
						goto IL_344d;
					case 134:
						goto IL_345e;
					case 135:
						goto IL_349f;
					case 136:
						goto IL_34d4;
					case 137:
						goto IL_350c;
					case 138:
						goto IL_3544;
					case 139:
						goto IL_3585;
					case 140:
						goto IL_35bd;
					case 141:
						goto IL_3600;
					case 142:
						goto IL_3635;
					case 143:
						goto IL_3678;
					case 144:
						goto IL_36a9;
					case 145:
						goto IL_36de;
					case 146:
						goto IL_3713;
					case 147:
						goto IL_374b;
					case 148:
						goto IL_3783;
					case 149:
						goto IL_37b8;
					case 150:
						goto IL_37f0;
					case 151:
						goto IL_3821;
					case 152:
						goto IL_3856;
					case 153:
						goto IL_388b;
					case 154:
						goto IL_38c0;
					case 155:
						goto IL_38f8;
					case 156:
						goto IL_392d;
					case 157:
						goto IL_3955;
					case 158:
						goto IL_398a;
					case 159:
						goto IL_399e;
					case 160:
						goto IL_39af;
					case 161:
						goto IL_39e7;
					case 162:
						goto IL_3a1f;
					case 163:
						goto IL_3a57;
					case 164:
						goto IL_3a8f;
					case 165:
						goto IL_3ac4;
					case 166:
						goto IL_3af6;
					case 167:
						goto IL_3b2e;
					case 168:
						goto IL_3b6f;
					case 169:
						goto IL_3ba2;
					case 170:
						goto IL_3bda;
					case 171:
						goto IL_3c22;
					case 172:
						goto IL_3c54;
					case 173:
						goto IL_3c8c;
					case 174:
						goto IL_3cc4;
					case 175:
						goto IL_3d08;
					case 176:
						goto IL_3d40;
					case 177:
						goto IL_3d78;
					case 178:
						goto IL_3daa;
					case 179:
						goto IL_3deb;
					case 180:
						goto IL_3e23;
					case 181:
						goto IL_3e5b;
					case 182:
						goto IL_3e9f;
					case 183:
						goto IL_3ee3;
					case 184:
						goto IL_3f19;
					case 185:
						goto IL_3f4c;
					case 186:
						goto IL_3f8d;
					case 187:
						goto IL_3fc5;
					case 188:
						goto IL_3ffd;
					case 189:
						goto IL_402f;
					case 190:
						goto IL_4075;
					case 191:
						goto IL_40b6;
					case 192:
						goto IL_40eb;
					case 193:
						goto IL_4123;
					case 194:
						goto IL_4158;
					case 195:
						goto IL_419b;
					case 196:
						goto IL_41e1;
					case 197:
						goto IL_4227;
					case 198:
						goto IL_4297;
					case 199:
						goto IL_430a;
					case 200:
						goto IL_437d;
					case 201:
						goto IL_43af;
					case 202:
						goto IL_43e4;
					case 203:
						goto IL_441c;
					case 204:
						goto IL_445f;
					case 205:
						goto IL_44a5;
					case 206:
						goto IL_44da;
					case 207:
						goto IL_450f;
					case 208:
						goto IL_4544;
					case 209:
						goto IL_457c;
					case 210:
						goto IL_45a4;
					case 211:
						goto IL_45dc;
					case 212:
						goto IL_4614;
					case 213:
						goto IL_4649;
					case 214:
					case 215:
					case 216:
						goto IL_4681;
					case 217:
						goto IL_46b3;
					case 218:
					case 219:
					case 220:
						goto IL_46e8;
					case 221:
						goto IL_471d;
					case 222:
						goto IL_4752;
					case 223:
						goto IL_478a;
					case 224:
						goto IL_47cd;
					case 225:
						goto IL_4803;
					case 226:
						goto IL_4832;
					case 227:
						goto IL_4867;
					case 228:
						goto IL_48ad;
					case 229:
						goto IL_48e4;
					case 230:
						goto IL_491c;
					case 231:
						goto IL_4954;
					case 232:
						goto IL_498c;
					case 233:
						goto IL_49c4;
					case 234:
						goto IL_49fc;
					case 235:
						goto IL_4a31;
					case 236:
						goto IL_4a69;
					case 237:
						goto IL_4aa1;
					case 238:
						goto IL_4ad6;
					case 239:
						goto IL_4b0b;
					case 240:
						goto IL_4b43;
					case 241:
						goto IL_4b7b;
					case 242:
						goto IL_4bb0;
					case 243:
						goto IL_4be5;
					case 244:
						goto IL_4c26;
					case 245:
						goto IL_4c5b;
					case 246:
						goto IL_4c93;
					case 247:
						goto IL_4cc5;
					case 248:
						goto IL_4d0b;
					case 249:
						goto IL_4d43;
					case 250:
						goto IL_4d78;
					case 251:
						goto IL_4dad;
					case 252:
						goto IL_4de2;
					case 253:
						goto IL_4e15;
					case 254:
						goto IL_4e4b;
					case 255:
						goto IL_4e81;
					case 256:
						goto IL_4eb7;
					case 257:
						goto IL_4eed;
					case 258:
						goto IL_4f2e;
					case 259:
						goto IL_4f71;
					case 260:
						goto IL_4fa9;
					case 261:
						goto IL_4fe1;
					case 262:
						goto IL_5013;
					default:
						goto IL_5054;
					}
					if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
					{
						class1661_0.method_10(Class1128.byte_17);
						enum227_ = Class1663.enum227_3;
						goto IL_5082;
					}
					throw new CellsException(ExceptionType.Formula, string_0);
				}
			}
			goto IL_5054;
		}
		case Enum180.const_4:
			{
				int num = ((class1661_0.method_7() != null) ? class1661_0.method_7().Count : 0);
				if (num > 254)
				{
					throw new CellsException(ExceptionType.Formula, string_0);
				}
				class1661_0.method_10(new byte[4]);
				switch (enum227_0)
				{
				case Enum227.const_0:
					class1661_0.method_9()[0] = 34;
					break;
				case Enum227.const_1:
					class1661_0.method_9()[0] = 66;
					break;
				case Enum227.const_2:
					class1661_0.method_9()[0] = 98;
					break;
				}
				class1661_0.method_9()[1] = (byte)(num + 1);
				class1661_0.method_9()[2] = byte.MaxValue;
				return Class1663.enum227_3;
			}
			IL_23c3:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
			{
				enum227_ = method_17(class1661_0, 351, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_1ff5:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 1)
			{
				enum227_ = method_16(class1661_0, 100, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_3783:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
			{
				enum227_ = method_17(class1661_0, 31, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_4227:
			if (class1661_0.method_7() == null)
			{
				throw new CellsException(ExceptionType.Formula, string_0);
			}
			if (class1661_0.method_7().Count == 1)
			{
				Class1661 @class = new Class1661();
				@class.method_4("0");
				@class.Type = Enum180.const_1;
				class1661_0.method_1(@class);
			}
			if (class1661_0.method_7().Count != 2)
			{
				throw new CellsException(ExceptionType.Formula, string_0);
			}
			enum227_ = method_17(class1661_0, 27, enum227_0, enum226_0);
			goto IL_5082;
			IL_374b:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_16(class1661_0, 164, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_41e1:
			if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 1 || class1661_0.method_7().Count == 2))
			{
				enum227_ = method_16(class1661_0, 354, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_2ede:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 2 && class1661_0.method_7().Count <= 4)
			{
				enum227_ = method_16(class1661_0, 29, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_3713:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_16(class1661_0, 163, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_286b:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
			{
				enum227_ = method_17(class1661_0, 196, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_1d42:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0)
			{
				enum227_ = method_16(class1661_0, 269, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_5013:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 2 && class1661_0.method_7().Count <= 3)
			{
				enum227_ = method_16(class1661_0, 324, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_419b:
			if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 1 || class1661_0.method_7().Count == 2))
			{
				enum227_ = method_16(class1661_0, 209, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_238e:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
			{
				enum227_ = method_17(class1661_0, 65, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_2e64:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 4)
			{
				enum227_ = method_17(class1661_0, 289, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_2e9c:
			if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 2 || class1661_0.method_7().Count == 3))
			{
				enum227_ = method_16(class1661_0, 1, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_4fe1:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 69, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_2836:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
			{
				enum227_ = method_17(class1661_0, 47, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_4158:
			if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 1 || class1661_0.method_7().Count == 2))
			{
				enum227_ = method_16(class1661_0, 116, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_36a9:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0)
			{
				enum227_ = method_16(class1661_0, 362, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_4fa9:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 215, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_1926:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
			{
				class1661_0.method_10(Class1128.byte_8);
				enum227_ = Class1663.enum227_2;
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_3678:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0)
			{
				enum227_ = method_16(class1661_0, 7, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_1b13:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 99, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_4f71:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 4)
			{
				enum227_ = method_16(class1661_0, 302, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_4123:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
			{
				enum227_ = method_17(class1661_0, 30, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_2801:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
			{
				enum227_ = method_17(class1661_0, 41, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_5082:
			return enum227_;
			IL_4f2e:
			if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 1 || class1661_0.method_7().Count == 2))
			{
				enum227_ = method_16(class1661_0, 70, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_2e1e:
			if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 2 || class1661_0.method_7().Count == 1))
			{
				enum227_ = method_16(class1661_0, 359, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_1fbd:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
			{
				enum227_ = method_17(class1661_0, 306, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_40eb:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 4)
			{
				enum227_ = method_17(class1661_0, 207, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_3635:
			if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 2 || class1661_0.method_7().Count == 3))
			{
				enum227_ = method_16(class1661_0, 64, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_4eed:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 3 && class1661_0.method_7().Count <= 4)
			{
				enum227_ = method_16(class1661_0, 102, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_27c9:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
			{
				enum227_ = method_17(class1661_0, 195, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_40b6:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 4)
			{
				enum227_ = method_17(class1661_0, 119, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_3600:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 112, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_1ade:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 24, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_4eb7:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count > 0)
			{
				enum227_ = method_16(class1661_0, 222, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_231e:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
			{
				enum227_ = method_17(class1661_0, 308, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_4075:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 3 && class1661_0.method_7().Count <= 6)
			{
				enum227_ = method_16(class1661_0, 60, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_1d0a:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 234, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_4e81:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count > 0)
			{
				enum227_ = method_16(class1661_0, 365, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_35bd:
			if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 2 || class1661_0.method_7().Count == 3))
			{
				enum227_ = method_16(class1661_0, 28, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_2da8:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 3 && class1661_0.method_7().Count <= 4)
			{
				enum227_ = method_16(class1661_0, 101, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_2de9:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 71, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_4e4b:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count > 0)
			{
				enum227_ = method_16(class1661_0, 194, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_402f:
			if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 2 || class1661_0.method_7().Count == 3))
			{
				enum227_ = method_16(class1661_0, 216, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_1814:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0 && class1661_0.method_7().Count <= 2)
			{
				if (class1661_0.method_7().Count == 1)
				{
					class1661_0.method_10(Class1128.byte_0);
				}
				if (class1661_0.method_7().Count == 2)
				{
					class1661_0.method_10(Class1128.byte_5);
				}
				enum227_ = Class1663.enum227_2;
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_1f85:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
			{
				enum227_ = method_17(class1661_0, 275, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_4e15:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count > 0)
			{
				enum227_ = method_16(class1661_0, 367, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_1cd5:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
			{
				enum227_ = method_17(class1661_0, 97, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_1f4d:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
			{
				enum227_ = method_17(class1661_0, 274, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_3585:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
			{
				enum227_ = method_17(class1661_0, 292, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_4de2:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count > 0)
			{
				enum227_ = method_16(class1661_0, 46, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_2d80:
			if (class1661_0.method_7() == null)
			{
				throw new CellsException(ExceptionType.Formula, string_0);
			}
			enum227_ = method_16(class1661_0, 320, enum227_0, enum226_0);
			goto IL_5082;
			IL_22e6:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
			{
				enum227_ = method_17(class1661_0, 346, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_3ffd:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0)
			{
				throw new CellsException(ExceptionType.Formula, string_0);
			}
			enum227_ = method_17(class1661_0, 63, enum227_0, enum226_0);
			goto IL_5082;
			IL_4dad:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 33, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_3fc5:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 342, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_22ae:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 347, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_2794:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
			{
				enum227_ = method_17(class1661_0, 45, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_4d78:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 113, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_3544:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count <= 4 && class1661_0.method_7().Count >= 1)
			{
				enum227_ = method_16(class1661_0, 51, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_3f8d:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
			{
				enum227_ = method_17(class1661_0, 327, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_2d4a:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 2)
			{
				enum227_ = method_16(class1661_0, 358, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_4d43:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 86, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_350c:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
			{
				enum227_ = method_17(class1661_0, 291, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_275c:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
			{
				enum227_ = method_17(class1661_0, 189, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_4d0b:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 4)
			{
				enum227_ = method_17(class1661_0, 316, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_2d22:
			if (class1661_0.method_7() == null)
			{
				throw new CellsException(ExceptionType.Formula, string_0);
			}
			enum227_ = method_16(class1661_0, 319, enum227_0, enum226_0);
			goto IL_5082;
			IL_2716:
			if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 1 || class1661_0.method_7().Count == 2))
			{
				enum227_ = method_16(class1661_0, 204, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_3f4c:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 3 && class1661_0.method_7().Count <= 5)
			{
				enum227_ = method_16(class1661_0, 56, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_4cc5:
			if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 1 || class1661_0.method_7().Count == 2))
			{
				enum227_ = method_16(class1661_0, 197, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_1ca0:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 18, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_2cea:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 271, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_3f19:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count != 1)
			{
				throw new CellsException(ExceptionType.Formula, string_0);
			}
			enum227_ = method_17(class1661_0, 114, enum227_0, enum226_0);
			goto IL_5082;
			IL_34d4:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
			{
				enum227_ = method_17(class1661_0, 290, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_4c93:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0)
			{
				throw new CellsException(ExceptionType.Formula, string_0);
			}
			enum227_ = method_17(class1661_0, 34, enum227_0, enum226_0);
			goto IL_5082;
			IL_1a9c:
			class1661_0.method_10(Class1128.byte_14);
			enum227_ = Class1663.enum227_2;
			goto IL_5082;
			IL_3ee3:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 1)
			{
				enum227_ = method_16(class1661_0, 183, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_18ec:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
			{
				class1661_0.method_10(Class1128.byte_7);
				enum227_ = Class1663.enum227_2;
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_4c5b:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
			{
				enum227_ = method_17(class1661_0, 331, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_2279:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0)
			{
				enum227_ = method_16(class1661_0, 169, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_349f:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 23, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_26e1:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
			{
				enum227_ = method_17(class1661_0, 43, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_4c26:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 118, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_345e:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 1 && class1661_0.method_7().Count <= 2)
			{
				enum227_ = method_16(class1661_0, 109, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_2248:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0)
			{
				enum227_ = method_16(class1661_0, 0, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_3e9f:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 3 && class1661_0.method_7().Count <= 4)
			{
				enum227_ = method_16(class1661_0, 317, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_4be5:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 1 && class1661_0.method_7().Count <= 4)
			{
				enum227_ = method_16(class1661_0, 50, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_2356:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
			{
				enum227_ = method_17(class1661_0, 278, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_3e5b:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 4 && class1661_0.method_7().Count <= 6)
			{
				enum227_ = method_16(class1661_0, 168, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_2cb2:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
			{
				enum227_ = method_17(class1661_0, 287, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_1ac8:
			class1661_0.method_10(Class1128.byte_16);
			enum227_ = Class1663.enum227_2;
			goto IL_5082;
			IL_4bb0:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 83, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_340d:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0 && class1661_0.method_7().Count <= 4)
			{
				enum227_ = method_16(class1661_0, 49, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_1f18:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 111, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_344d:
			enum227_ = method_17(class1661_0, 22, enum227_0, enum226_0);
			goto IL_5082;
			IL_4b7b:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0)
			{
				throw new CellsException(ExceptionType.Formula, string_0);
			}
			enum227_ = method_17(class1661_0, 221, enum227_0, enum226_0);
			goto IL_5082;
			IL_1ab2:
			class1661_0.method_10(Class1128.byte_15);
			enum227_ = Class1663.enum227_2;
			goto IL_5082;
			IL_26ac:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
			{
				enum227_ = method_17(class1661_0, 44, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_3e23:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
			{
				enum227_ = method_17(class1661_0, 337, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_4b43:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
			{
				enum227_ = method_17(class1661_0, 332, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_3deb:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
			{
				enum227_ = method_17(class1661_0, 300, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_33d5:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 211, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_1a70:
			class1661_0.method_10(Class1128.byte_13);
			enum227_ = Class1663.enum227_2;
			goto IL_5082;
			IL_4b0b:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 141, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_2c7a:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 4)
			{
				enum227_ = method_17(class1661_0, 286, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_3daa:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 3 && class1661_0.method_7().Count <= 5)
			{
				enum227_ = method_16(class1661_0, 59, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_2684:
			if (class1661_0.method_7() == null)
			{
				throw new CellsException(ExceptionType.Formula, string_0);
			}
			enum227_ = method_16(class1661_0, 318, enum227_0, enum226_0);
			goto IL_5082;
			IL_4ad6:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
			{
				enum227_ = method_17(class1661_0, 66, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_33a0:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 32, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_1ee0:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
			{
				enum227_ = method_17(class1661_0, 288, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_2c39:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 3 && class1661_0.method_7().Count <= 5)
			{
				enum227_ = method_16(class1661_0, 57, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_4aa1:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
			{
				enum227_ = method_17(class1661_0, 48, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_3d78:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0)
			{
				throw new CellsException(ExceptionType.Formula, string_0);
			}
			enum227_ = method_17(class1661_0, 19, enum227_0, enum226_0);
			goto IL_5082;
			IL_1c6b:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_16(class1661_0, 18, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_2210:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 230, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_4a69:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
			{
				enum227_ = method_17(class1661_0, 301, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_2c01:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
			{
				enum227_ = method_17(class1661_0, 310, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_3d40:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 360, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_335a:
			if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 1 || class1661_0.method_7().Count == 2))
			{
				enum227_ = method_16(class1661_0, 208, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_4a31:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 231, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_264c:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 343, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_21db:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 16, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_2bc9:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
			{
				enum227_ = method_17(class1661_0, 252, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_49fc:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 17, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_3317:
			if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 1 || class1661_0.method_7().Count == 2))
			{
				enum227_ = method_16(class1661_0, 115, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_1a24:
			class1661_0.method_10(Class1128.byte_2);
			enum227_ = Class1663.enum227_2;
			goto IL_5082;
			IL_3d08:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
			{
				enum227_ = method_17(class1661_0, 299, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_49c4:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 130, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_3cc4:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 2 && class1661_0.method_7().Count <= 3)
			{
				enum227_ = method_17(class1661_0, 329, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_1e9d:
			if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 1 || class1661_0.method_7().Count == 2))
			{
				enum227_ = method_16(class1661_0, 125, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_1a5a:
			class1661_0.method_10(Class1128.byte_11);
			enum227_ = Class1663.enum227_2;
			goto IL_5082;
			IL_498c:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 4)
			{
				enum227_ = method_17(class1661_0, 143, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_32df:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
			{
				enum227_ = method_17(class1661_0, 325, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_2b91:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
			{
				enum227_ = method_17(class1661_0, 309, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_2614:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
			{
				enum227_ = method_17(class1661_0, 235, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_4954:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
			{
				enum227_ = method_17(class1661_0, 303, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_1c39:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0)
			{
				enum227_ = method_16(class1661_0, 36, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_19ea:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
			{
				class1661_0.method_10(Class1128.byte_19);
				enum227_ = Class1663.enum227_3;
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_3c8c:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
			{
				enum227_ = method_17(class1661_0, 328, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_491c:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
			{
				enum227_ = method_17(class1661_0, 305, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_3c54:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
			{
				enum227_ = method_17(class1661_0, 312, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_2b59:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
			{
				enum227_ = method_17(class1661_0, 285, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_25ce:
			if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 4 || class1661_0.method_7().Count == 5))
			{
				enum227_ = method_16(class1661_0, 144, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_48e4:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
			{
				enum227_ = method_17(class1661_0, 304, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_32b7:
			if (class1661_0.method_7() == null)
			{
				throw new CellsException(ExceptionType.Formula, string_0);
			}
			enum227_ = method_16(class1661_0, 322, enum227_0, enum226_0);
			goto IL_5082;
			IL_3c22:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0)
			{
				enum227_ = method_16(class1661_0, 37, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_1a86:
			class1661_0.method_10(Class1128.byte_12);
			enum227_ = Class1663.enum227_2;
			goto IL_5082;
			IL_48ad:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count > 30)
			{
				throw new CellsException(ExceptionType.Formula, string_0);
			}
			enum227_ = method_16(class1661_0, 321, enum227_0, enum226_0);
			goto IL_5082;
			IL_2b18:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 1 && class1661_0.method_7().Count <= 3)
			{
				enum227_ = method_16(class1661_0, 14, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_3282:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 127, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_1e65:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 4)
			{
				enum227_ = method_17(class1661_0, 273, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_4867:
			if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 2 || class1661_0.method_7().Count == 3))
			{
				enum227_ = method_16(class1661_0, 345, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_324d:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 105, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_1880:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0 && class1661_0.method_7().Count <= 2)
			{
				if (class1661_0.method_7().Count == 1)
				{
					class1661_0.method_10(Class1128.byte_1);
				}
				if (class1661_0.method_7().Count == 2)
				{
					class1661_0.method_10(Class1128.byte_6);
				}
				enum227_ = Class1663.enum227_2;
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_1a3a:
			class1661_0.method_10(Class1128.byte_3);
			enum227_ = new Enum227[1] { enum227_0 };
			goto IL_5082;
			IL_3bda:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 3 && class1661_0.method_7().Count <= 5)
			{
				enum227_ = method_16(class1661_0, 78, enum227_0, enum226_0);
				bool_0 = true;
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_4832:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0)
			{
				enum227_ = method_16(class1661_0, 228, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_3ba2:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 298, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_3215:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 4)
			{
				enum227_ = method_17(class1661_0, 350, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_1c01:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 232, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_4803:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0)
			{
				enum227_ = method_15(class1661_0, enum227_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_2588:
			if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 4 || class1661_0.method_7().Count == 5))
			{
				enum227_ = method_16(class1661_0, 247, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_3b6f:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 2)
			{
				enum227_ = method_16(class1661_0, 11, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_2ad2:
			if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 2 || class1661_0.method_7().Count == 3))
			{
				enum227_ = method_16(class1661_0, 205, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_47cd:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 2)
			{
				enum227_ = method_16(class1661_0, 344, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_31dd:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 128, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_216b:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
			{
				enum227_ = method_17(class1661_0, 277, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_21a3:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
			{
				enum227_ = method_17(class1661_0, 307, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_478a:
			if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 3 || class1661_0.method_7().Count == 4))
			{
				enum227_ = method_16(class1661_0, 120, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_1e21:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 3 && class1661_0.method_7().Count <= 5)
			{
				enum227_ = method_16(class1661_0, 272, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_31a5:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 190, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_1bcc:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 98, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_3b2e:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 3 && class1661_0.method_7().Count <= 5)
			{
				enum227_ = method_16(class1661_0, 58, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_4752:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
			{
				enum227_ = method_17(class1661_0, 314, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_3af6:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
			{
				enum227_ = method_17(class1661_0, 353, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_20fd:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
			{
				enum227_ = method_17(class1661_0, 276, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_2553:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 67, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_471d:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0)
			{
				enum227_ = method_16(class1661_0, 364, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_2135:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 1)
			{
				enum227_ = method_16(class1661_0, 336, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_3ac4:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0)
			{
				throw new CellsException(ExceptionType.Formula, string_0);
			}
			enum227_ = method_17(class1661_0, 74, enum227_0, enum226_0);
			goto IL_5082;
			IL_2a8f:
			if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 2 || class1661_0.method_7().Count == 3))
			{
				enum227_ = method_16(class1661_0, 124, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_46e8:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0)
			{
				enum227_ = method_16(class1661_0, 193, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_2a57:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
			{
				enum227_ = method_17(class1661_0, 282, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_3171:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 2, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_199a:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
			{
				class1661_0.method_10(Class1128.byte_10);
				enum227_ = Class1663.enum227_2;
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_46b3:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0)
			{
				enum227_ = method_16(class1661_0, 366, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_313d:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 3, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_24e6:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
			{
				enum227_ = method_17(class1661_0, 40, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_3a8f:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 38, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_4681:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0)
			{
				enum227_ = method_16(class1661_0, 12, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_3a57:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 296, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_5054:
			if (class1661_0.Type != Enum180.const_3 && class1661_0.Type != Enum180.const_4)
			{
				method_9(class1661_0, enum227_0);
				enum227_ = Class1663.enum227_2;
			}
			else
			{
				enum227_ = method_19(class1661_0, enum227_0, enum226_0);
			}
			goto IL_5082;
			IL_251b:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
			{
				enum227_ = method_17(class1661_0, 199, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_4649:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
			{
				enum227_ = method_17(class1661_0, 297, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_1ddd:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 3 && class1661_0.method_7().Count <= 5)
			{
				enum227_ = method_16(class1661_0, 270, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_3a1f:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
			{
				enum227_ = method_17(class1661_0, 295, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_3105:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 198, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_4614:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 20, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_2a1f:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
			{
				enum227_ = method_17(class1661_0, 281, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_20c8:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 77, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_19d4:
			class1661_0.method_10(Class1128.byte_18);
			enum227_ = Class1663.enum227_3;
			goto IL_5082;
			IL_45dc:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
			{
				enum227_ = method_17(class1661_0, 326, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_29ed:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0)
			{
				throw new CellsException(ExceptionType.Formula, string_0);
			}
			enum227_ = method_17(class1661_0, 35, enum227_0, enum226_0);
			goto IL_5082;
			IL_043b:
			class1661_0.method_10(new byte[2]);
			class1661_0.method_9()[0] = 29;
			class1661_0.method_9()[1] = 1;
			goto IL_048a;
			IL_39e7:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 294, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_45a4:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
			{
				enum227_ = method_17(class1661_0, 142, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_39af:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 4)
			{
				enum227_ = method_17(class1661_0, 293, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_3098:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 129, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_30d0:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 126, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_457c:
			if (class1661_0.method_7() == null)
			{
				throw new CellsException(ExceptionType.Formula, string_0);
			}
			enum227_ = method_16(class1661_0, 323, enum227_0, enum226_0);
			goto IL_5082;
			IL_24a0:
			if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 2 || class1661_0.method_7().Count == 3))
			{
				enum227_ = method_16(class1661_0, 220, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_048a:
			return Class1663.enum227_3;
			IL_4544:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 229, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_398a:
			enum227_ = method_17(class1661_0, 131, enum227_0, enum226_0);
			goto IL_5082;
			IL_3955:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 68, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_399e:
			enum227_ = method_17(class1661_0, 10, enum227_0, enum226_0);
			goto IL_5082;
			IL_450f:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 15, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_3055:
			if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 1 || class1661_0.method_7().Count == 2))
			{
				enum227_ = method_16(class1661_0, 62, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_29b5:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 184, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_2095:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count > 1)
			{
				throw new CellsException(ExceptionType.Formula, string_0);
			}
			enum227_ = method_16(class1661_0, 9, enum227_0, enum226_0);
			goto IL_5082;
			IL_44da:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 26, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_246b:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
			{
				enum227_ = method_17(class1661_0, 42, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_297d:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
			{
				enum227_ = method_17(class1661_0, 280, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_392d:
			if (class1661_0.method_7() == null)
			{
				throw new CellsException(ExceptionType.Formula, string_0);
			}
			enum227_ = method_16(class1661_0, 330, enum227_0, enum226_0);
			goto IL_5082;
			IL_44a5:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 73, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_0482:
			method_9(class1661_0, enum227_0);
			goto IL_048a;
			IL_3011:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 4 && class1661_0.method_7().Count <= 6)
			{
				enum227_ = method_16(class1661_0, 167, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_38f8:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
			{
				enum227_ = method_17(class1661_0, 39, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_445f:
			if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 2 || class1661_0.method_7().Count == 3))
			{
				enum227_ = method_16(class1661_0, 206, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_38c0:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
			{
				enum227_ = method_17(class1661_0, 165, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_2948:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 21, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_1b80:
			enum227_ = method_16(class1661_0, 219, enum227_0, enum226_0);
			goto IL_5082;
			IL_1b94:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 214, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_441c:
			if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 2 || class1661_0.method_7().Count == 3))
			{
				enum227_ = method_16(class1661_0, 82, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_388b:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
			{
				enum227_ = method_17(class1661_0, 61, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_36de:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0)
			{
				enum227_ = method_16(class1661_0, 227, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_2fd9:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
			{
				enum227_ = method_17(class1661_0, 311, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_43e4:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
			{
				enum227_ = method_17(class1661_0, 313, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_3856:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 72, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_1d77:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0)
			{
				enum227_ = method_16(class1661_0, 5, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_1da8:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0)
			{
				enum227_ = method_16(class1661_0, 361, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_43af:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 76, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_2433:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 140, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_3821:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0)
			{
				enum227_ = method_16(class1661_0, 363, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_2fa4:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 25, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_437d:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count > 1)
			{
				throw new CellsException(ExceptionType.Formula, string_0);
			}
			enum227_ = method_16(class1661_0, 8, enum227_0, enum226_0);
			goto IL_5082;
			IL_2913:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
			{
				enum227_ = method_17(class1661_0, 117, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_23fb:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 352, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_2028:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 162, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_430a:
			if (class1661_0.method_7() == null)
			{
				throw new CellsException(ExceptionType.Formula, string_0);
			}
			if (class1661_0.method_7().Count == 1)
			{
				Class1661 class3 = new Class1661();
				class3.method_4("0");
				class3.Type = Enum180.const_1;
				class1661_0.method_1(class3);
			}
			if (class1661_0.method_7().Count != 2)
			{
				throw new CellsException(ExceptionType.Formula, string_0);
			}
			enum227_ = method_17(class1661_0, 212, enum227_0, enum226_0);
			goto IL_5082;
			IL_37f0:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0)
			{
				enum227_ = method_16(class1661_0, 6, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_28db:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 279, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_2f6c:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_16(class1661_0, 244, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_1960:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
			{
				class1661_0.method_10(Class1128.byte_9);
				enum227_ = Class1663.enum227_2;
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_37b8:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
			{
				enum227_ = method_17(class1661_0, 210, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_2f1f:
			if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 1 || class1661_0.method_7().Count == 2))
			{
				enum227_ = method_16(class1661_0, 148, enum227_0, enum226_0);
				bool_0 = true;
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_4297:
			if (class1661_0.method_7() == null)
			{
				throw new CellsException(ExceptionType.Formula, string_0);
			}
			if (class1661_0.method_7().Count == 1)
			{
				Class1661 class4 = new Class1661();
				class4.method_4("0");
				class4.Type = Enum180.const_1;
				class1661_0.method_1(class4);
			}
			if (class1661_0.method_7().Count != 2)
			{
				throw new CellsException(ExceptionType.Formula, string_0);
			}
			enum227_ = method_17(class1661_0, 213, enum227_0, enum226_0);
			goto IL_5082;
			IL_1b48:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 233, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_2060:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 121, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
			IL_28a3:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
			{
				enum227_ = method_17(class1661_0, 261, enum227_0, enum226_0);
				goto IL_5082;
			}
			throw new CellsException(ExceptionType.Formula, string_0);
		}
	}

	private void method_9(Class1661 class1661_0, Enum227 enum227_0)
	{
		string text = class1661_0.method_3();
		if (text[0] == '"' && text[text.Length - 1] == '"')
		{
			try
			{
				int num = text.Length - 2;
				if (num > 255)
				{
					throw new CellsException(ExceptionType.Formula, string_0);
				}
				if (num == 0)
				{
					class1661_0.method_10(new byte[3]);
					class1661_0.method_9()[0] = 23;
				}
				else
				{
					if (worksheetCollection_0.Workbook.Settings.bool_0)
					{
						text = Class1618.smethod_8(text);
						num = text.Length - 2;
					}
					byte[] bytes = Encoding.Unicode.GetBytes(text);
					class1661_0.method_10(new byte[3 + num * 2]);
					class1661_0.method_9()[0] = 23;
					Array.Copy(BitConverter.GetBytes(num), 0, class1661_0.method_9(), 1, 2);
					Array.Copy(bytes, 2, class1661_0.method_9(), 3, num + num);
				}
				return;
			}
			catch
			{
				throw new CellsException(ExceptionType.Formula, "Invalid formula");
			}
		}
		if (Class1677.smethod_18(text))
		{
			double num2 = double.Parse(text, CultureInfo.InvariantCulture);
			if (!(num2 < 0.0) && !(num2 > 65535.0) && num2 - (double)(int)(ushort)num2 <= double.Epsilon)
			{
				ushort value = (ushort)num2;
				class1661_0.method_10(new byte[3]);
				class1661_0.method_9()[0] = 30;
				Array.Copy(BitConverter.GetBytes(value), 0, class1661_0.method_9(), 1, 2);
			}
			else
			{
				class1661_0.method_10(new byte[9]);
				class1661_0.method_9()[0] = 31;
				Array.Copy(BitConverter.GetBytes(num2), 0, class1661_0.method_9(), 1, 8);
			}
		}
		else if (method_23(class1661_0.method_3()))
		{
			int[] array = Class1303.smethod_0(worksheetCollection_0, class1661_0.method_3());
			class1661_0.method_10(new byte[7]);
			switch (enum227_0)
			{
			case Enum227.const_0:
				class1661_0.method_9()[0] = 57;
				break;
			case Enum227.const_1:
				class1661_0.method_9()[0] = 89;
				break;
			case Enum227.const_2:
				class1661_0.method_9()[0] = 121;
				break;
			}
			Array.Copy(BitConverter.GetBytes((ushort)array[0]), 0, class1661_0.method_9(), 1, 2);
			Array.Copy(BitConverter.GetBytes((ushort)array[1]), 0, class1661_0.method_9(), 3, 2);
		}
		else if (worksheetCollection_0.method_2() == null && method_22(class1661_0.method_3()))
		{
			class1661_0.method_10(Class1689.smethod_0(worksheetCollection_0, (cell_0 == null) ? (-1) : cell_0.method_4().method_3().Index, int_1, int_2, class1661_0.method_3(), enum227_0, out var InvalidTable));
			if (InvalidTable)
			{
				method_4(bool_1: true);
			}
		}
		else if (!CheckCell(class1661_0.method_3()))
		{
			class1661_0.method_10(method_11(class1661_0, enum227_0));
		}
		else
		{
			class1661_0.method_10(method_10(class1661_0, class1661_0.method_3(), enum227_0));
		}
	}

	internal byte[] method_10(Class1661 class1661_0, string string_1, Enum227 enum227_0)
	{
		int row = 0;
		int column = 0;
		bool isColumnAbsolute = false;
		bool isRowAbsolute = false;
		bool isRowOnly = false;
		bool isColumnOnly = false;
		try
		{
			int num = Class1660.smethod_1(string_1, '!');
			if (num == string_1.Length - 1)
			{
				return new byte[2] { 28, 23 };
			}
			byte[] array;
			if (num == -1)
			{
				if (!CellNameToIndex(string_1, out row, out column, isInArea: false, ref isRowAbsolute, ref isColumnAbsolute, ref isRowOnly, ref isColumnOnly))
				{
					return method_20(class1661_0, string_1, enum227_0);
				}
				array = new byte[7];
				Class1268.smethod_3(array, 1, row, int_1, isRowAbsolute, method_2());
				Class1268.smethod_5(array, 5, column, int_2, isColumnAbsolute, method_2());
				if (!isColumnAbsolute)
				{
					array[6] |= 64;
				}
				if (!isRowAbsolute)
				{
					array[6] |= 128;
				}
				if (method_2())
				{
					switch (enum227_0)
					{
					case Enum227.const_0:
						array[0] = 44;
						break;
					case Enum227.const_1:
						array[0] = 76;
						break;
					case Enum227.const_2:
						array[0] = 108;
						break;
					}
				}
				else
				{
					switch (enum227_0)
					{
					case Enum227.const_0:
						array[0] = 36;
						break;
					case Enum227.const_1:
						array[0] = 68;
						break;
					case Enum227.const_2:
						array[0] = 100;
						break;
					}
				}
				return array;
			}
			string text = "";
			if (num != 0)
			{
				text = string_1.Substring(0, num);
			}
			int num2 = -1;
			int[] array2 = Class1660.smethod_3(worksheetCollection_0, text);
			int num3 = array2[0];
			num2 = array2[1];
			int int_ = array2[2];
			string text2 = string_1.Substring(num + 1);
			if (num3 == -1)
			{
				return method_20(class1661_0, string_1, enum227_0);
			}
			if (!CellNameToIndex(text2, out row, out column, isInArea: false, ref isRowAbsolute, ref isColumnAbsolute, ref isRowOnly, ref isColumnOnly))
			{
				if (text2 == "#REF!")
				{
					array = new byte[9];
					switch (enum227_0)
					{
					case Enum227.const_0:
						array[0] = 60;
						break;
					case Enum227.const_1:
						array[0] = 92;
						break;
					case Enum227.const_2:
						array[0] = 124;
						break;
					}
					Array.Copy(BitConverter.GetBytes((ushort)num3), 0, array, 1, 2);
					return array;
				}
				return smethod_1(worksheetCollection_0, num2, num3, int_, text2, class1661_0.Type, enum227_0);
			}
			array = new byte[9];
			Class1268.smethod_3(array, 3, row, int_1, isRowAbsolute, method_2());
			Class1268.smethod_5(array, 7, column, int_2, isColumnAbsolute, method_2());
			if (!isColumnAbsolute)
			{
				array[8] |= 64;
			}
			if (!isRowAbsolute)
			{
				array[8] |= 128;
			}
			switch (enum227_0)
			{
			case Enum227.const_0:
				array[0] = 58;
				break;
			case Enum227.const_1:
				array[0] = 90;
				break;
			case Enum227.const_2:
				array[0] = 122;
				break;
			}
			Array.Copy(BitConverter.GetBytes((ushort)num3), 0, array, 1, 2);
			return array;
		}
		catch (Exception)
		{
			return method_20(class1661_0, string_1, enum227_0);
		}
	}

	private byte[] method_11(Class1661 class1661_0, Enum227 enum227_0)
	{
		int num = class1661_0.method_3().IndexOf(':');
		if (num == -1)
		{
			return method_10(class1661_0, class1661_0.method_3(), enum227_0);
		}
		int num2 = class1661_0.method_3().LastIndexOf(':');
		if (num != class1661_0.method_3().Length - 1 && class1661_0.method_3()[num + 1] == '\\')
		{
			num = num2;
		}
		int num3 = class1661_0.method_3().LastIndexOf('!');
		string text;
		string text2;
		if (num == num2)
		{
			text = class1661_0.method_3().Substring(0, num);
			text2 = class1661_0.method_3().Substring(num + 1).TrimEnd();
			if (text != null && text2 != null)
			{
				num3 = text.LastIndexOf('!');
				if (num3 == -1)
				{
					return method_12(class1661_0, text, text2, enum227_0);
				}
				return method_14(class1661_0, text, text2, num3, enum227_0);
			}
			return null;
		}
		if (num3 == -1)
		{
			string[] array = class1661_0.method_3().Split(':');
			ArrayList arrayList = new ArrayList();
			int num4 = 0;
			for (int i = 0; i < array.Length; i += 2)
			{
				byte[] array2 = null;
				array2 = ((i + 1 < array.Length) ? method_12(class1661_0, array[i], array[i + 1], enum227_0) : method_10(class1661_0, array[i], enum227_0));
				arrayList.Add(array2);
				num4 += array2.Length;
				if (i != 0)
				{
					num4++;
				}
			}
			byte[] array3 = new byte[num4];
			int num5 = 0;
			for (int j = 0; j < arrayList.Count; j++)
			{
				byte[] array4 = (byte[])arrayList[j];
				Array.Copy(array4, 0, array3, num5, array4.Length);
				num5 += array4.Length;
				if (j != 0)
				{
					array3[num5++] = 17;
				}
			}
			return array3;
		}
		string string_ = class1661_0.method_3().Substring(0, num3);
		text = class1661_0.method_3().Substring(num3 + 1, num2 - num3 - 1);
		text2 = class1661_0.method_3().Substring(num2 + 1);
		return method_13(class1661_0, string_, text, text2, enum227_0);
	}

	internal byte[] method_12(Class1661 class1661_0, string string_1, string string_2, Enum227 enum227_0)
	{
		byte[] array = new byte[13];
		bool isRowAbsolute = false;
		bool isColumnAbsolute = false;
		bool isRowOnly = false;
		bool isColumnOnly = false;
		bool isRowAbsolute2 = false;
		bool isColumnAbsolute2 = false;
		bool isRowOnly2 = false;
		bool isColumnOnly2 = false;
		try
		{
			int row;
			int column;
			bool flag = CellNameToIndex(string_1, out row, out column, isInArea: true, ref isRowAbsolute, ref isColumnAbsolute, ref isRowOnly, ref isColumnOnly);
			int row2;
			int column2;
			bool flag2 = CellNameToIndex(string_2, out row2, out column2, isInArea: true, ref isRowAbsolute2, ref isColumnAbsolute2, ref isRowOnly2, ref isColumnOnly2);
			if (!flag || !flag2 || isRowOnly != isRowOnly2 || isColumnOnly != isColumnOnly2)
			{
				if (enum227_0 != Enum227.const_2)
				{
					enum227_0 = Enum227.const_0;
				}
				class1661_0.method_4(string_1);
				class1661_0.method_10(null);
				byte[] array2 = method_10(class1661_0, class1661_0.method_3(), enum227_0);
				class1661_0.method_4(string_2);
				class1661_0.method_10(null);
				byte[] array3 = method_10(class1661_0, class1661_0.method_3(), enum227_0);
				array = new byte[array2.Length + array3.Length + 1];
				Array.Copy(array2, 0, array, 0, array2.Length);
				Array.Copy(array3, 0, array, array2.Length, array3.Length);
				array[array.Length - 1] = 17;
				return array;
			}
			if (isRowOnly)
			{
				Class1268.smethod_3(array, 1, row, int_1, isRowAbsolute, method_2());
				Class1268.smethod_3(array, 5, row2, int_1, isRowAbsolute2, method_2());
				Array.Copy(BitConverter.GetBytes(16383), 0, array, 11, 2);
				if (!isRowAbsolute)
				{
					array[10] |= 128;
				}
				if (!isRowAbsolute2)
				{
					array[12] |= 128;
				}
			}
			else if (isColumnOnly)
			{
				Array.Copy(BitConverter.GetBytes(1048575), 0, array, 5, 4);
				Class1268.smethod_5(array, 9, column, int_2, isColumnAbsolute, method_2());
				Class1268.smethod_5(array, 11, column2, int_2, isColumnAbsolute2, method_2());
				if (!isColumnAbsolute)
				{
					array[10] |= 64;
				}
				if (!isColumnAbsolute2)
				{
					array[12] |= 64;
				}
			}
			else
			{
				Class1268.smethod_3(array, 1, row, int_1, isRowAbsolute, method_2());
				Class1268.smethod_3(array, 5, row2, int_1, isRowAbsolute2, method_2());
				Class1268.smethod_5(array, 9, column, int_2, isColumnAbsolute, method_2());
				Class1268.smethod_5(array, 11, column2, int_2, isColumnAbsolute2, method_2());
				if (!isRowAbsolute)
				{
					array[10] |= 128;
				}
				if (!isColumnAbsolute)
				{
					array[10] |= 64;
				}
				if (!isRowAbsolute2)
				{
					array[12] |= 128;
				}
				if (!isColumnAbsolute2)
				{
					array[12] |= 64;
				}
			}
		}
		catch (Exception)
		{
			throw new CellsException(ExceptionType.Formula, string_0);
		}
		if (method_2())
		{
			switch (enum227_0)
			{
			case Enum227.const_0:
				array[0] = 45;
				break;
			case Enum227.const_1:
				array[0] = 77;
				break;
			case Enum227.const_2:
				array[0] = 109;
				break;
			}
		}
		else
		{
			switch (enum227_0)
			{
			case Enum227.const_0:
				array[0] = 37;
				break;
			case Enum227.const_1:
				array[0] = 69;
				break;
			case Enum227.const_2:
				array[0] = 101;
				break;
			}
		}
		return array;
	}

	private static string smethod_0(string string_1)
	{
		if (string_1[0] == '\'' && string_1[string_1.Length - 1] == '\'')
		{
			string_1 = string_1.Substring(1, string_1.Length - 2);
			string_1 = string_1.Replace("''", "'");
		}
		return string_1;
	}

	private byte[] method_13(Class1661 class1661_0, string string_1, string string_2, string string_3, Enum227 enum227_0)
	{
		try
		{
			string_1 = smethod_0(string_1);
			int[] array = Class1660.smethod_3(worksheetCollection_0, string_1);
			int num = array[0];
			byte[] array2 = new byte[15];
			Array.Copy(BitConverter.GetBytes((ushort)num), 0, array2, 1, 2);
			bool isRowAbsolute = false;
			bool isColumnAbsolute = false;
			bool isRowOnly = false;
			bool isColumnOnly = false;
			bool isRowAbsolute2 = false;
			bool isColumnAbsolute2 = false;
			bool isRowOnly2 = false;
			bool isColumnOnly2 = false;
			try
			{
				int row;
				int column;
				bool flag = CellNameToIndex(string_2, out row, out column, isInArea: true, ref isRowAbsolute, ref isColumnAbsolute, ref isRowOnly, ref isColumnOnly);
				int row2;
				int column2;
				bool flag2 = CellNameToIndex(string_3, out row2, out column2, isInArea: true, ref isRowAbsolute2, ref isColumnAbsolute2, ref isRowOnly2, ref isColumnOnly2);
				if (!flag || !flag2 || isRowOnly != isRowOnly2 || isColumnOnly != isColumnOnly2)
				{
					if (enum227_0 != Enum227.const_2)
					{
						enum227_0 = Enum227.const_0;
					}
					class1661_0.method_4(string_2);
					class1661_0.method_10(null);
					byte[] array3 = method_10(class1661_0, class1661_0.method_3(), enum227_0);
					class1661_0.method_4(string_3);
					class1661_0.method_10(null);
					byte[] array4 = method_10(class1661_0, class1661_0.method_3(), enum227_0);
					array2 = new byte[array3.Length + array4.Length + 1];
					Array.Copy(array3, 0, array2, 0, array3.Length);
					Array.Copy(array4, 0, array2, array3.Length, array4.Length);
					array2[array2.Length - 1] = 17;
					return array2;
				}
				if (isRowOnly)
				{
					Class1268.smethod_3(array2, 3, row, int_1, isRowAbsolute, method_2());
					Class1268.smethod_3(array2, 7, row2, int_1, isRowAbsolute2, method_2());
					Array.Copy(BitConverter.GetBytes(16383), 0, array2, 11, 2);
					if (!isRowAbsolute)
					{
						array2[12] |= 128;
					}
					if (!isRowAbsolute2)
					{
						array2[14] |= 128;
					}
				}
				else if (isColumnOnly)
				{
					Array.Copy(BitConverter.GetBytes(1048575), 0, array2, 7, 4);
					Class1268.smethod_5(array2, 11, column, int_2, isColumnAbsolute, method_2());
					Class1268.smethod_5(array2, 13, column2, int_2, isColumnAbsolute2, method_2());
					if (!isColumnAbsolute)
					{
						array2[12] |= 64;
					}
					if (!isColumnAbsolute2)
					{
						array2[14] |= 64;
					}
				}
				else
				{
					Class1268.smethod_3(array2, 3, row, int_1, isRowAbsolute, method_2());
					Class1268.smethod_3(array2, 7, row2, int_1, isRowAbsolute2, method_2());
					Class1268.smethod_5(array2, 11, column, int_2, isColumnAbsolute, method_2());
					Class1268.smethod_5(array2, 13, column2, int_2, isColumnAbsolute2, method_2());
					if (!isRowAbsolute)
					{
						array2[12] |= 128;
					}
					if (!isColumnAbsolute)
					{
						array2[12] |= 64;
					}
					if (!isRowAbsolute2)
					{
						array2[14] |= 128;
					}
					if (!isColumnAbsolute2)
					{
						array2[14] |= 64;
					}
				}
			}
			catch (Exception)
			{
				throw new CellsException(ExceptionType.Formula, string_0);
			}
			switch (enum227_0)
			{
			case Enum227.const_0:
				array2[0] = 59;
				break;
			case Enum227.const_1:
				array2[0] = 91;
				break;
			case Enum227.const_2:
				array2[0] = 123;
				break;
			}
			return array2;
		}
		catch (Exception)
		{
			throw new CellsException(ExceptionType.Formula, string_0);
		}
	}

	private byte[] method_14(Class1661 class1661_0, string string_1, string string_2, int int_3, Enum227 enum227_0)
	{
		if (string_2.IndexOf("!") != -1)
		{
			byte[] array = method_10(class1661_0, string_1, Enum227.const_0);
			byte[] array2 = method_10(class1661_0, string_2, Enum227.const_0);
			byte[] array3 = new byte[array.Length + array2.Length + 1];
			Array.Copy(array, array3, array.Length);
			Array.Copy(array2, 0, array3, array.Length, array2.Length);
			array3[array3.Length - 1] = 17;
			return array3;
		}
		int num = 0;
		if (worksheetCollection_0.method_39() != null && worksheetCollection_0.method_39().Count != 0)
		{
			for (int i = 0; i < worksheetCollection_0.method_39().Count; i++)
			{
				Class1718 @class = worksheetCollection_0.method_39()[i];
				if (@class.method_12())
				{
					num = i;
					break;
				}
			}
		}
		try
		{
			string string_3 = string_1.Substring(0, int_3);
			string_3 = smethod_0(string_3);
			int[] array4 = Class1660.smethod_3(worksheetCollection_0, string_3);
			int num2 = array4[0];
			if (num2 == -1)
			{
				num2 = worksheetCollection_0.method_32().method_8(num, -1);
			}
			byte[] array5 = new byte[15];
			Array.Copy(BitConverter.GetBytes((ushort)num2), 0, array5, 1, 2);
			string_1 = string_1.Substring(int_3 + 1);
			bool isRowAbsolute = false;
			bool isColumnAbsolute = false;
			bool isRowOnly = false;
			bool isColumnOnly = false;
			bool isRowAbsolute2 = false;
			bool isColumnAbsolute2 = false;
			bool isRowOnly2 = false;
			bool isColumnOnly2 = false;
			try
			{
				int row;
				int column;
				bool flag = CellNameToIndex(string_1, out row, out column, isInArea: true, ref isRowAbsolute, ref isColumnAbsolute, ref isRowOnly, ref isColumnOnly);
				int row2;
				int column2;
				bool flag2 = CellNameToIndex(string_2, out row2, out column2, isInArea: true, ref isRowAbsolute2, ref isColumnAbsolute2, ref isRowOnly2, ref isColumnOnly2);
				if (!flag || !flag2 || isRowOnly != isRowOnly2 || isColumnOnly != isColumnOnly2)
				{
					if (enum227_0 != Enum227.const_2)
					{
						enum227_0 = Enum227.const_0;
					}
					class1661_0.method_4(string_1);
					class1661_0.method_10(null);
					byte[] array6 = method_10(class1661_0, class1661_0.method_3(), enum227_0);
					class1661_0.method_4(string_2);
					class1661_0.method_10(null);
					byte[] array7 = method_10(class1661_0, class1661_0.method_3(), enum227_0);
					array5 = new byte[array6.Length + array7.Length + 1];
					Array.Copy(array6, 0, array5, 0, array6.Length);
					Array.Copy(array7, 0, array5, array6.Length, array7.Length);
					array5[array5.Length - 1] = 17;
					return array5;
				}
				if (isRowOnly)
				{
					Class1268.smethod_3(array5, 3, row, int_1, isRowAbsolute, method_2());
					Class1268.smethod_3(array5, 7, row2, int_1, isRowAbsolute2, method_2());
					Array.Copy(BitConverter.GetBytes(16383), 0, array5, 13, 2);
					if (!isRowAbsolute)
					{
						array5[12] |= 128;
					}
					if (!isRowAbsolute2)
					{
						array5[14] |= 128;
					}
				}
				else if (isColumnOnly)
				{
					Array.Copy(BitConverter.GetBytes(1048575), 0, array5, 7, 4);
					Class1268.smethod_5(array5, 11, column, int_2, isColumnAbsolute, method_2());
					Class1268.smethod_5(array5, 13, column2, int_2, isColumnAbsolute2, method_2());
					if (!isColumnAbsolute)
					{
						array5[12] |= 64;
					}
					if (!isColumnAbsolute2)
					{
						array5[14] |= 64;
					}
				}
				else
				{
					Class1268.smethod_3(array5, 3, row, int_1, isRowAbsolute, method_2());
					Class1268.smethod_3(array5, 7, row2, int_1, isRowAbsolute2, method_2());
					Class1268.smethod_5(array5, 11, column, int_2, isColumnAbsolute, method_2());
					Class1268.smethod_5(array5, 13, column2, int_2, isColumnAbsolute2, method_2());
					if (!isRowAbsolute)
					{
						array5[12] |= 128;
					}
					if (!isColumnAbsolute)
					{
						array5[12] |= 64;
					}
					if (!isRowAbsolute2)
					{
						array5[14] |= 128;
					}
					if (!isColumnAbsolute2)
					{
						array5[14] |= 64;
					}
				}
			}
			catch (Exception)
			{
				throw new CellsException(ExceptionType.Formula, string_0);
			}
			switch (enum227_0)
			{
			case Enum227.const_0:
				array5[0] = 59;
				break;
			case Enum227.const_1:
				array5[0] = 91;
				break;
			case Enum227.const_2:
				array5[0] = 123;
				break;
			}
			return array5;
		}
		catch (Exception)
		{
			throw new CellsException(ExceptionType.Formula, string_0);
		}
	}

	private Enum227[] method_15(Class1661 class1661_0, Enum227 enum227_0)
	{
		if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0)
		{
			if (class1661_0.method_7().Count > 255)
			{
				throw new CellsException(ExceptionType.Formula, string_0);
			}
			class1661_0.method_10(new byte[4]);
			if (enum227_0 == Enum227.const_2)
			{
				class1661_0.method_9()[0] = 98;
			}
			else
			{
				class1661_0.method_9()[0] = 66;
			}
			class1661_0.method_9()[1] = (byte)class1661_0.method_7().Count;
			class1661_0.method_9()[2] = 4;
		}
		else
		{
			class1661_0.method_10(new byte[4]);
			class1661_0.method_9()[0] = 25;
			class1661_0.method_9()[1] = 16;
		}
		return Class1663.enum227_3;
	}

	private Enum227[] method_16(Class1661 class1661_0, ushort ushort_0, Enum227 enum227_0, Enum226 enum226_0)
	{
		class1661_0.method_10(new byte[4]);
		switch (enum227_0)
		{
		case Enum227.const_0:
			class1661_0.method_9()[0] = 34;
			break;
		case Enum227.const_1:
			class1661_0.method_9()[0] = 66;
			break;
		case Enum227.const_2:
			class1661_0.method_9()[0] = 98;
			break;
		}
		if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0)
		{
			class1661_0.method_9()[1] = (byte)class1661_0.method_7().Count;
		}
		Array.Copy(BitConverter.GetBytes(ushort_0), 0, class1661_0.method_9(), 2, 2);
		return Class1660.smethod_23(ushort_0, enum226_0);
	}

	private Enum227[] method_17(Class1661 class1661_0, ushort ushort_0, Enum227 enum227_0, Enum226 enum226_0)
	{
		class1661_0.method_10(new byte[3]);
		if (method_2())
		{
			class1661_0.method_9()[0] = 33;
		}
		else
		{
			switch (enum227_0)
			{
			case Enum227.const_0:
				class1661_0.method_9()[0] = 33;
				break;
			case Enum227.const_1:
				if (Class1660.smethod_22(ushort_0, enum226_0) == Enum227.const_2 && class1661_0.method_5() != null)
				{
					class1661_0.method_9()[0] = 97;
				}
				else
				{
					class1661_0.method_9()[0] = 65;
				}
				break;
			case Enum227.const_2:
				class1661_0.method_9()[0] = 97;
				break;
			}
		}
		Array.Copy(BitConverter.GetBytes(ushort_0), 0, class1661_0.method_9(), 1, 2);
		return Class1660.smethod_23(ushort_0, enum226_0);
	}

	private void method_18(Class1661 class1661_0, string string_1, Enum227 enum227_0)
	{
		int num = -1;
		int num2 = -1;
		int num3 = -1;
		Class1303 @class = worksheetCollection_0.method_39();
		bool flag = false;
		bool flag2 = false;
		Class1718 class2 = null;
		for (int i = 0; i < @class.Count; i++)
		{
			class2 = @class[i];
			if (class2.method_14())
			{
				num = i;
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			class2 = new Class1718();
			class2.Type = Enum194.const_2;
			Class1653 class3 = new Class1653(class2);
			class3.method_21(string_1, bool_0: true);
			class2.method_0().Add(class3);
			num3 = 1;
			worksheetCollection_0.method_39().Add(class2);
			num2 = worksheetCollection_0.method_32().method_3((ushort)(worksheetCollection_0.method_39().Count - 1), 65534, 65534);
		}
		else
		{
			num2 = worksheetCollection_0.method_32().method_10(num, 65534, 65534);
			flag = true;
			for (int j = 0; j < class2.method_0().Count; j++)
			{
				Class1653 class4 = (Class1653)class2.method_0()[j];
				if (class4.Name.ToUpper() == string_1.ToUpper())
				{
					num3 = j + 1;
					flag2 = true;
					break;
				}
			}
			if (!flag2)
			{
				Class1653 class5 = new Class1653(class2);
				class5.method_21(string_1, bool_0: true);
				class2.method_0().Add(class5);
				num3 = class2.method_0().Count;
			}
		}
		byte[] array = new byte[7];
		Array.Copy(BitConverter.GetBytes((ushort)num2), 0, array, 1, 2);
		Array.Copy(BitConverter.GetBytes((ushort)num3), 0, array, 3, 2);
		switch (enum227_0)
		{
		case Enum227.const_0:
			array[0] = 57;
			break;
		case Enum227.const_1:
			array[0] = 89;
			break;
		case Enum227.const_2:
			array[0] = 121;
			break;
		}
		class1661_0.Type = Enum180.const_5;
		class1661_0.method_10(array);
	}

	private Enum227[] method_19(Class1661 class1661_0, Enum227 enum227_0, Enum226 enum226_0)
	{
		string text = class1661_0.method_3();
		bool flag = false;
		bool flag2 = false;
		if (text.StartsWith("_XLFN."))
		{
			text = text.Substring("_XLFN.".Length);
			flag2 = true;
		}
		else if (text.StartsWith("_XLL."))
		{
			text = text.Substring("_XLL.".Length);
			flag = true;
		}
		Class1663 @class = Class1663.smethod_4(text, enum226_0);
		if (@class != null && Class1663.smethod_5(@class.ushort_0))
		{
			if (!flag2)
			{
				class1661_0.string_2 = "_xlfn." + class1661_0.string_2;
			}
			@class = null;
		}
		if (@class == null)
		{
			if (flag)
			{
				class1661_0.Type = Enum180.const_5;
				class1661_0.string_2 = class1661_0.string_2.Substring("_XLL.".Length);
				method_18(class1661_0, class1661_0.string_2, enum227_0);
				return Class1663.enum227_3;
			}
			class1661_0.Type = Enum180.const_5;
			class1661_0.method_10(method_21(class1661_0, class1661_0.string_2, enum227_0));
			string text2;
			if ((text2 = text) != null && text2 == "COUNTIFS")
			{
				Enum227[] array = new Enum227[class1661_0.method_7().Count];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = ((i % 2 != 0) ? Enum227.const_1 : Enum227.const_0);
				}
				return array;
			}
			return Class1663.enum227_3;
		}
		if (@class.ushort_0 == 255)
		{
			class1661_0.Type = Enum180.const_5;
			method_18(class1661_0, class1661_0.string_2, enum227_0);
		}
		else if (@class.byte_0 != @class.byte_1)
		{
			class1661_0.method_10(new byte[4]);
			switch (enum227_0)
			{
			case Enum227.const_0:
				class1661_0.method_9()[0] = 34;
				break;
			case Enum227.const_1:
				class1661_0.method_9()[0] = 66;
				break;
			case Enum227.const_2:
				class1661_0.method_9()[0] = 98;
				break;
			}
			if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0)
			{
				class1661_0.method_9()[1] = (byte)class1661_0.method_7().Count;
			}
			Array.Copy(BitConverter.GetBytes(@class.ushort_0), 0, class1661_0.method_9(), 2, 2);
		}
		else
		{
			class1661_0.method_10(new byte[3]);
			if (method_2())
			{
				class1661_0.method_9()[0] = 33;
			}
			else
			{
				switch (enum227_0)
				{
				case Enum227.const_0:
					class1661_0.method_9()[0] = 33;
					break;
				case Enum227.const_1:
					if (@class.enum227_1 == Enum227.const_2 && class1661_0.method_5() != null)
					{
						class1661_0.method_9()[0] = 97;
					}
					else
					{
						class1661_0.method_9()[0] = 65;
					}
					break;
				case Enum227.const_2:
					class1661_0.method_9()[0] = 97;
					break;
				}
			}
			Array.Copy(BitConverter.GetBytes(@class.ushort_0), 0, class1661_0.method_9(), 1, 2);
		}
		return @class.enum227_0;
	}

	private byte[] method_20(Class1661 class1661_0, string string_1, Enum227 enum227_0)
	{
		worksheetCollection_0.method_36();
		string text = string_1.ToUpper();
		try
		{
			byte[] array;
			if (worksheetCollection_0.method_2() != null)
			{
				if (worksheetCollection_0.method_2() is Class1141)
				{
					Class1141 @class = (Class1141)worksheetCollection_0.method_2();
					int num = -1;
					num = @class.method_0(string_1);
					if (num == -1)
					{
						throw new CellsException(ExceptionType.PivotTable, "References,names,and arrays are not supported in the PivotTable formulas.");
					}
					array = new byte[6] { 24, 29, 0, 0, 0, 0 };
					Array.Copy(BitConverter.GetBytes(num), 0, array, 2, 4);
					return array;
				}
				if (worksheetCollection_0.method_2() is Class1148)
				{
					Class1148 class2 = (Class1148)worksheetCollection_0.method_2();
					int num2 = -1;
					num2 = class2.method_3(string_1);
					if (num2 == -1)
					{
						throw new CellsException(ExceptionType.PivotTable, "Pivot table can only refer to items in the same field as calcualted item");
					}
					array = new byte[6] { 24, 29, 0, 0, 0, 0 };
					Array.Copy(BitConverter.GetBytes(num2), 0, array, 2, 4);
					return array;
				}
			}
			if (class1661_0.Type == Enum180.const_3)
			{
				class1661_0.Type = Enum180.const_5;
			}
			int[] array2 = worksheetCollection_0.Names.method_10((cell_0 == null) ? (-1) : cell_0.method_4().method_3().Index, text, class1661_0.Type == Enum180.const_5, bool_1: true);
			int num3 = array2[0];
			int num4 = array2[1];
			if (num3 != -1)
			{
				array = new byte[7];
				Array.Copy(BitConverter.GetBytes((ushort)num3), 0, array, 1, 2);
				Array.Copy(BitConverter.GetBytes((ushort)(num4 + 1)), 0, array, 3, 2);
				switch (enum227_0)
				{
				case Enum227.const_0:
					array[0] = 57;
					break;
				case Enum227.const_1:
					array[0] = 89;
					break;
				case Enum227.const_2:
					array[0] = 121;
					break;
				}
			}
			else
			{
				array = new byte[5];
				Array.Copy(BitConverter.GetBytes((ushort)(num4 + 1)), 0, array, 1, 2);
				switch (enum227_0)
				{
				case Enum227.const_0:
					array[0] = 35;
					break;
				case Enum227.const_1:
					array[0] = 67;
					break;
				case Enum227.const_2:
					array[0] = 99;
					break;
				}
			}
			if (!bool_0)
			{
				Name name = worksheetCollection_0.Names[num4];
				byte[] array3 = name.method_2();
				if (array3 != null && array3.Length > 8 && array3[4] == 25 && array3[5] == 1)
				{
					bool_0 = true;
				}
			}
			return array;
		}
		catch (Exception)
		{
			throw new CellsException(ExceptionType.Formula, string_0);
		}
	}

	private byte[] method_21(Class1661 class1661_0, string string_1, Enum227 enum227_0)
	{
		class1661_0.Type = Enum180.const_5;
		worksheetCollection_0.method_36();
		try
		{
			int[] array = worksheetCollection_0.Names.method_10((cell_0 == null) ? (-1) : cell_0.method_4().method_3().Index, string_1, bool_0: true, bool_1: true);
			int num = array[0];
			int num2 = array[1];
			byte[] array2;
			if (num != -1)
			{
				array2 = new byte[7];
				Array.Copy(BitConverter.GetBytes((ushort)num), 0, array2, 1, 2);
				Array.Copy(BitConverter.GetBytes((ushort)(num2 + 1)), 0, array2, 3, 2);
				switch (enum227_0)
				{
				case Enum227.const_0:
					array2[0] = 57;
					break;
				case Enum227.const_1:
					array2[0] = 89;
					break;
				case Enum227.const_2:
					array2[0] = 121;
					break;
				}
			}
			else
			{
				array2 = new byte[5];
				Array.Copy(BitConverter.GetBytes((ushort)(num2 + 1)), 0, array2, 1, 2);
				switch (enum227_0)
				{
				case Enum227.const_0:
					array2[0] = 35;
					break;
				case Enum227.const_1:
					if (class1661_0.Type == Enum180.const_5)
					{
						array2[0] = 35;
					}
					else
					{
						array2[0] = 67;
					}
					break;
				case Enum227.const_2:
					array2[0] = 99;
					break;
				}
			}
			return array2;
		}
		catch (Exception)
		{
			throw new CellsException(ExceptionType.Formula, string_0);
		}
	}

	private bool method_22(string string_1)
	{
		if (string_1.Length > 0 && string_1[string_1.Length - 1] == ']')
		{
			return true;
		}
		return false;
	}

	private bool method_23(string string_1)
	{
		if (string_1.Length > 0 && string_1[0] != '\'' && string_1.IndexOf('|') != -1)
		{
			return true;
		}
		return false;
	}

	private bool CheckCell(string string_1)
	{
		for (int num = string_1.Length - 1; num >= 0; num--)
		{
			switch (string_1[num])
			{
			case '"':
			case '\'':
			{
				char c = string_1[num];
				num--;
				while (num >= 0 && string_1[num] != c)
				{
					num--;
				}
				break;
			}
			case ':':
				return false;
			case '!':
				return true;
			}
		}
		return true;
	}

	internal static byte[] smethod_1(WorksheetCollection worksheetCollection_1, int int_3, int int_4, int int_5, string string_1, Enum180 enum180_0, Enum227 enum227_0)
	{
		int num = worksheetCollection_1.method_36();
		byte[] array = null;
		int num2 = -1;
		if (int_3 == num)
		{
			num2 = worksheetCollection_1.Names.method_1(int_5, string_1);
		}
		else
		{
			if (string_1.Length > 2 && string_1[0] == '\'')
			{
				string_1 = string_1.Substring(1, string_1.Length - 2);
			}
			string_1 = string_1.ToUpper();
			Class1718 @class = worksheetCollection_1.method_39()[int_3];
			if (@class.method_0().Count > 0)
			{
				for (int i = 0; i < @class.method_0().Count; i++)
				{
					Class1653 class2 = (Class1653)@class.method_0()[i];
					if (class2.Name.ToUpper() == string_1)
					{
						num2 = i;
					}
				}
			}
			if (num2 == -1)
			{
				Class1653 class3 = new Class1653(@class);
				class3.Name = string_1;
				num2 = @class.method_0().Add(class3);
			}
		}
		array = new byte[7];
		switch (enum227_0)
		{
		case Enum227.const_0:
			array[0] = 57;
			break;
		case Enum227.const_1:
			array[0] = 89;
			break;
		case Enum227.const_2:
			array[0] = 121;
			break;
		}
		Array.Copy(BitConverter.GetBytes((ushort)int_4), 0, array, 1, 2);
		Array.Copy(BitConverter.GetBytes((ushort)(num2 + 1)), 0, array, 3, 2);
		return array;
	}

	internal static bool CellNameToIndex(string cellName, out int row, out int column, bool isInArea, ref bool isRowAbsolute, ref bool isColumnAbsolute, ref bool isRowOnly, ref bool isColumnOnly)
	{
		row = -1;
		column = -1;
		if (cellName.Length == 0)
		{
			return false;
		}
		char[] array = cellName.ToUpper().ToCharArray();
		for (int i = 0; i < array.Length; i++)
		{
			switch (array[i])
			{
			case '1':
			case '2':
			case '3':
			case '4':
			case '5':
			case '6':
			case '7':
			case '8':
			case '9':
				if (column == -1)
				{
					if (!isInArea)
					{
						return false;
					}
					isRowOnly = true;
				}
				if (i != 0 && array[i - 1] == '$')
				{
					isRowAbsolute = true;
				}
				row = array[i] - 48;
				for (i++; i < array.Length; i++)
				{
					if (char.IsDigit(array[i]))
					{
						row = row * 10 + array[i] - 48;
						continue;
					}
					return false;
				}
				row--;
				if (row > 1048575)
				{
					return false;
				}
				break;
			case 'A':
			case 'B':
			case 'C':
			case 'D':
			case 'E':
			case 'F':
			case 'G':
			case 'H':
			case 'I':
			case 'J':
			case 'K':
			case 'L':
			case 'M':
			case 'N':
			case 'O':
			case 'P':
			case 'Q':
			case 'R':
			case 'S':
			case 'T':
			case 'U':
			case 'V':
			case 'W':
			case 'X':
			case 'Y':
			case 'Z':
				if (column == -1)
				{
					int num = i;
					for (num++; num < array.Length && char.IsLetter(array[num]); num++)
					{
					}
					if (num == array.Length)
					{
						if (!isInArea)
						{
							return false;
						}
						isColumnOnly = true;
					}
					if (num - i <= 3)
					{
						if (i != 0 && array[i - 1] == '$')
						{
							isColumnAbsolute = true;
						}
						column = array[i] - 65 + 1;
						for (i++; i < num; i++)
						{
							column = column * 26 + array[i] - 65 + 1;
						}
						i--;
						column--;
						if (column > 16383)
						{
							return false;
						}
						break;
					}
					return false;
				}
				return false;
			case '$':
				break;
			default:
				return false;
			}
		}
		return true;
	}
}
