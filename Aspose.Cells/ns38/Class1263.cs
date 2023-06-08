using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using Aspose.Cells;
using ns1;
using ns12;
using ns2;
using ns45;
using ns58;

namespace ns38;

internal class Class1263
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

	internal Class1263(WorksheetCollection worksheetCollection_1)
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
		byte[] array = new byte[num + (bool_1 ? 2 : 0)];
		int num2 = 0;
		if (bool_1)
		{
			Array.Copy(BitConverter.GetBytes(num), 0, array, 0, 2);
			num2 = 2;
		}
		if (bool_0)
		{
			array[num2++] = 25;
			array[num2++] = 1;
			num2 += 2;
			bool_0 = false;
		}
		num2 = CopyData(class1661_0, array, num2);
		if (int_0 != 0)
		{
			byte[] array2 = new byte[array.Length + int_0];
			Array.Copy(array, 0, array2, 0, array.Length);
			int num3 = array.Length;
			for (int i = 0; i < arrayList_0.Count; i++)
			{
				byte[] array3 = (byte[])arrayList_0[i];
				Array.Copy(array3, 0, array2, num3, array3.Length);
				num3 += array3.Length;
			}
			arrayList_0 = null;
			int_0 = 0;
			return array2;
		}
		return array;
	}

	private int method_6(Class1661 class1661_0, Enum227 enum227_0, Enum226 enum226_0, bool bool_1)
	{
		int num = 0;
		Enum227[] array = method_7(class1661_0, enum227_0, enum226_0);
		if (enum227_0 != Enum227.const_2 && bool_1)
		{
			switch (class1661_0.method_9()[0])
			{
			case 65:
			case 66:
			case 67:
			case 68:
			case 69:
			case 70:
			case 71:
			case 72:
			case 73:
			case 90:
			case 91:
			case 92:
			case 93:
				class1661_0.method_9()[0] += 32;
				break;
			}
		}
		if (class1661_0.Type != 0 && class1661_0.method_7() != null && class1661_0.method_7().Count > 0)
		{
			for (int i = 0; i < class1661_0.method_7().Count; i++)
			{
				Class1661 class1661_ = (Class1661)class1661_0.method_7()[i];
				Enum227 @enum = ((array != null && array.Length != 0) ? ((i < array.Length) ? array[i] : array[array.Length - 1]) : Enum227.const_0);
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
				num += method_6(class1661_, @enum, enum226_0, bool_2);
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

	private Enum227[] method_7(Class1661 class1661_0, Enum227 enum227_0, Enum226 enum226_0)
	{
		Enum227[] enum227_ = Class1663.enum227_3;
		if (class1661_0.Type == Enum180.const_4)
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
		if (class1661_0.Type == Enum180.const_0)
		{
			if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0)
			{
				object obj = class1661_0.method_7()[0];
				if (obj == null)
				{
					class1661_0.method_10(new byte[8]);
					class1661_0.method_9()[0] = 96;
					int_0 += 3;
					arrayList_0.Add(new byte[3]);
					return Class1663.enum227_4;
				}
				if (obj is Class1661[][])
				{
					Class1661[][] array = (Class1661[][])obj;
					class1661_0.method_10(new byte[8]);
					if (enum227_0 == Enum227.const_1)
					{
						class1661_0.method_9()[0] = 64;
					}
					else
					{
						class1661_0.method_9()[0] = 96;
					}
					ArrayList arrayList = new ArrayList();
					int num2 = 3;
					for (int i = 0; i < array.Length; i++)
					{
						for (int j = 0; j < array[i].Length; j++)
						{
							Class1661 @class = array[i][j];
							method_8(@class);
							arrayList.Add(@class.method_9());
							num2 += @class.method_9().Length;
						}
					}
					byte[] array2 = new byte[num2];
					arrayList_0.Add(array2);
					int_0 += num2;
					array2[0] = (byte)(array[0].Length - 1);
					Array.Copy(BitConverter.GetBytes((ushort)(array.Length - 1)), 0, array2, 1, 2);
					int num3 = 3;
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
		}
		string text = class1661_0.method_3();
		if (text == null)
		{
			class1661_0.method_10(new byte[1]);
			class1661_0.method_9()[0] = 22;
			return Class1663.enum227_3;
		}
		if (class1661_0.Type == Enum180.const_1)
		{
			string key;
			if ((key = text.ToUpper()) != null)
			{
				if (Class1742.dictionary_63 == null)
				{
					Class1742.dictionary_63 = new Dictionary<string, int>(12)
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
				if (Class1742.dictionary_63.TryGetValue(key, out var value))
				{
					switch (value)
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
						goto IL_04c7;
					case 11:
						class1661_0.method_10(new byte[1]);
						class1661_0.method_9()[0] = 21;
						return new Enum227[1] { enum227_0 };
					default:
						goto IL_050e;
					}
					class1661_0.method_10(new byte[2]);
					class1661_0.method_9()[0] = 29;
					goto IL_0516;
				}
			}
			goto IL_050e;
		}
		string key2;
		if ((key2 = text) != null)
		{
			if (Class1742.dictionary_64 == null)
			{
				Class1742.dictionary_64 = new Dictionary<string, int>(259)
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
					{ "STDEVA", 215 },
					{ "STDEVP", 216 },
					{ "STDEVPA", 217 },
					{ "STEYX", 218 },
					{ "SUBSTITUTE", 219 },
					{ "SUBTOTAL", 220 },
					{ "SUM", 221 },
					{ "SUMPRODUCT", 222 },
					{ "SUMIF", 223 },
					{ "SUMSQ", 224 },
					{ "SUMX2MY2", 225 },
					{ "SUMX2PY2", 226 },
					{ "SUMXMY2", 227 },
					{ "SYD", 228 },
					{ "T", 229 },
					{ "TAN", 230 },
					{ "TANH", 231 },
					{ "TDIST", 232 },
					{ "TEXT", 233 },
					{ "TIME", 234 },
					{ "TIMEVALUE", 235 },
					{ "TINV", 236 },
					{ "TODAY", 237 },
					{ "TRANSPOSE", 238 },
					{ "TREND", 239 },
					{ "TRIM", 240 },
					{ "TRIMMEAN", 241 },
					{ "TRUE", 242 },
					{ "TRUNC", 243 },
					{ "TTEST", 244 },
					{ "TYPE", 245 },
					{ "UPPER", 246 },
					{ "VALUE", 247 },
					{ "VAR", 248 },
					{ "VARA", 249 },
					{ "VARP", 250 },
					{ "VARPA", 251 },
					{ "VDB", 252 },
					{ "VLOOKUP", 253 },
					{ "WEEKDAY", 254 },
					{ "WEIBULL", 255 },
					{ "WIDECHAR", 256 },
					{ "YEAR", 257 },
					{ "ZTEST", 258 }
				};
			}
			if (Class1742.dictionary_64.TryGetValue(key2, out var value2))
			{
				switch (value2)
				{
				case 0:
					break;
				case 1:
					goto IL_185c;
				case 2:
					goto IL_18d1;
				case 3:
					goto IL_1946;
				case 4:
					goto IL_198a;
				case 5:
					goto IL_19ce;
				case 6:
					goto IL_1a12;
				case 7:
					goto IL_1a56;
				case 8:
					goto IL_1a77;
				case 9:
					goto IL_1abc;
				case 10:
					goto IL_1add;
				case 11:
					goto IL_1b08;
				case 12:
					goto IL_1b29;
				case 13:
					goto IL_1b4a;
				case 14:
					goto IL_1b6b;
				case 15:
					goto IL_1b8c;
				case 16:
					goto IL_1bad;
				case 17:
					goto IL_1bce;
				case 18:
					goto IL_1c03;
				case 19:
					goto IL_1c38;
				case 20:
					goto IL_1c70;
				case 21:
					goto IL_1c84;
				case 22:
					goto IL_1cbc;
				case 23:
					goto IL_1cf1;
				case 24:
					goto IL_1d29;
				case 25:
					goto IL_1d5b;
				case 26:
					goto IL_1d90;
				case 27:
					goto IL_1dc5;
				case 28:
					goto IL_1dfa;
				case 29:
					goto IL_1e32;
				case 30:
					goto IL_1e67;
				case 31:
					goto IL_1e98;
				case 32:
					goto IL_1ecd;
				case 33:
					goto IL_1f11;
				case 34:
					goto IL_1f55;
				case 35:
					goto IL_1f8d;
				case 36:
					goto IL_1fd0;
				case 37:
					goto IL_2008;
				case 38:
					goto IL_203d;
				case 39:
					goto IL_2075;
				case 40:
					goto IL_20ad;
				case 41:
					goto IL_20e5;
				case 42:
					goto IL_2118;
				case 43:
					goto IL_2150;
				case 44:
					goto IL_2185;
				case 45:
					goto IL_21b8;
				case 46:
					goto IL_21ed;
				case 47:
					goto IL_2225;
				case 48:
					goto IL_225b;
				case 49:
					goto IL_2293;
				case 50:
					goto IL_22cb;
				case 51:
					goto IL_2300;
				case 52:
					goto IL_2338;
				case 53:
					goto IL_2369;
				case 54:
					goto IL_239e;
				case 55:
					goto IL_23d6;
				case 56:
					goto IL_240e;
				case 57:
					goto IL_2446;
				case 58:
					goto IL_247e;
				case 59:
					goto IL_24b3;
				case 60:
					goto IL_24eb;
				case 61:
					goto IL_2523;
				case 62:
					goto IL_255b;
				case 63:
					goto IL_2590;
				case 64:
					goto IL_25d6;
				case 65:
					goto IL_260b;
				case 66:
					goto IL_2643;
				case 67:
					goto IL_2678;
				case 68:
					goto IL_26be;
				case 69:
					goto IL_2704;
				case 70:
					goto IL_273c;
				case 71:
					goto IL_2774;
				case 72:
					goto IL_279c;
				case 73:
					goto IL_27d1;
				case 74:
					goto IL_2806;
				case 75:
					goto IL_284c;
				case 76:
					goto IL_2884;
				case 77:
					goto IL_28b9;
				case 78:
					goto IL_28f1;
				case 79:
					goto IL_2926;
				case 80:
					goto IL_295b;
				case 81:
					goto IL_2993;
				case 82:
					goto IL_29cb;
				case 83:
					goto IL_2a03;
				case 84:
					goto IL_2a38;
				case 85:
					goto IL_2a6d;
				case 86:
					goto IL_2aa5;
				case 87:
					goto IL_2add;
				case 88:
					goto IL_2b0f;
				case 89:
					goto IL_2b47;
				case 90:
					goto IL_2b7f;
				case 91:
					goto IL_2bc2;
				case 92:
					goto IL_2c08;
				case 93:
					goto IL_2c49;
				case 94:
					goto IL_2c81;
				case 95:
					goto IL_2cb9;
				case 96:
					goto IL_2cf1;
				case 97:
					goto IL_2d29;
				case 98:
					goto IL_2d6a;
				case 99:
					goto IL_2da2;
				case 100:
					goto IL_2dda;
				case 101:
					goto IL_2e12;
				case 102:
					goto IL_2e3a;
				case 103:
					goto IL_2e70;
				case 104:
					goto IL_2e98;
				case 105:
					goto IL_2ed9;
				case 106:
					goto IL_2f0e;
				case 107:
					goto IL_2f54;
				case 108:
					goto IL_2f8c;
				case 109:
					goto IL_2fce;
				case 110:
					goto IL_300f;
				case 111:
					goto IL_305c;
				case 112:
					goto IL_3094;
				case 113:
					goto IL_30c9;
				case 114:
					goto IL_3101;
				case 115:
					goto IL_3145;
				case 116:
					goto IL_3188;
				case 117:
					goto IL_31c0;
				case 118:
					goto IL_31f5;
				case 119:
					goto IL_322d;
				case 120:
					goto IL_3261;
				case 121:
					goto IL_3295;
				case 122:
					goto IL_32cd;
				case 123:
					goto IL_3305;
				case 124:
					goto IL_333d;
				case 125:
					goto IL_3372;
				case 126:
					goto IL_33a7;
				case 127:
					goto IL_33cf;
				case 128:
					goto IL_3407;
				case 129:
					goto IL_344a;
				case 130:
					goto IL_3490;
				case 131:
					goto IL_34c5;
				case 132:
					goto IL_34fd;
				case 133:
					goto IL_353d;
				case 134:
					goto IL_354e;
				case 135:
					goto IL_358f;
				case 136:
					goto IL_35c4;
				case 137:
					goto IL_35fc;
				case 138:
					goto IL_3634;
				case 139:
					goto IL_3675;
				case 140:
					goto IL_36ad;
				case 141:
					goto IL_36f0;
				case 142:
					goto IL_3725;
				case 143:
					goto IL_3768;
				case 144:
					goto IL_3799;
				case 145:
					goto IL_37ce;
				case 146:
					goto IL_3803;
				case 147:
					goto IL_383b;
				case 148:
					goto IL_3873;
				case 149:
					goto IL_38a8;
				case 150:
					goto IL_38e0;
				case 151:
					goto IL_3911;
				case 152:
					goto IL_3946;
				case 153:
					goto IL_397b;
				case 154:
					goto IL_39b0;
				case 155:
					goto IL_39e8;
				case 156:
					goto IL_3a1d;
				case 157:
					goto IL_3a45;
				case 158:
					goto IL_3a7a;
				case 159:
					goto IL_3a8e;
				case 160:
					goto IL_3a9f;
				case 161:
					goto IL_3ad7;
				case 162:
					goto IL_3b0f;
				case 163:
					goto IL_3b47;
				case 164:
					goto IL_3b7f;
				case 165:
					goto IL_3bb4;
				case 166:
					goto IL_3be6;
				case 167:
					goto IL_3c1e;
				case 168:
					goto IL_3c5f;
				case 169:
					goto IL_3c92;
				case 170:
					goto IL_3cca;
				case 171:
					goto IL_3d0b;
				case 172:
					goto IL_3d3d;
				case 173:
					goto IL_3d75;
				case 174:
					goto IL_3dad;
				case 175:
					goto IL_3df1;
				case 176:
					goto IL_3e29;
				case 177:
					goto IL_3e61;
				case 178:
					goto IL_3e93;
				case 179:
					goto IL_3ed4;
				case 180:
					goto IL_3f0c;
				case 181:
					goto IL_3f44;
				case 182:
					goto IL_3f88;
				case 183:
					goto IL_3fcc;
				case 184:
					goto IL_4002;
				case 185:
					goto IL_4035;
				case 186:
					goto IL_4076;
				case 187:
					goto IL_40ae;
				case 188:
					goto IL_40e6;
				case 189:
					goto IL_4118;
				case 190:
					goto IL_415e;
				case 191:
					goto IL_419f;
				case 192:
					goto IL_41d4;
				case 193:
					goto IL_420c;
				case 194:
					goto IL_4241;
				case 195:
					goto IL_4284;
				case 196:
					goto IL_42ca;
				case 197:
					goto IL_4310;
				case 198:
					goto IL_4380;
				case 199:
					goto IL_43f3;
				case 200:
					goto IL_4466;
				case 201:
					goto IL_4498;
				case 202:
					goto IL_44cd;
				case 203:
					goto IL_4505;
				case 204:
					goto IL_4548;
				case 205:
					goto IL_458e;
				case 206:
					goto IL_45c3;
				case 207:
					goto IL_45f8;
				case 208:
					goto IL_462d;
				case 209:
					goto IL_4665;
				case 210:
					goto IL_468d;
				case 211:
					goto IL_46c5;
				case 212:
					goto IL_46fd;
				case 213:
					goto IL_4732;
				case 214:
					goto IL_476a;
				case 215:
					goto IL_479c;
				case 216:
					goto IL_47d1;
				case 217:
					goto IL_4806;
				case 218:
					goto IL_483b;
				case 219:
					goto IL_4873;
				case 220:
					goto IL_48b6;
				case 221:
					goto IL_48ec;
				case 222:
					goto IL_491b;
				case 223:
					goto IL_4950;
				case 224:
					goto IL_4996;
				case 225:
					goto IL_49cd;
				case 226:
					goto IL_4a05;
				case 227:
					goto IL_4a3d;
				case 228:
					goto IL_4a75;
				case 229:
					goto IL_4aad;
				case 230:
					goto IL_4ae5;
				case 231:
					goto IL_4b1a;
				case 232:
					goto IL_4b52;
				case 233:
					goto IL_4b8a;
				case 234:
					goto IL_4bbf;
				case 235:
					goto IL_4bf4;
				case 236:
					goto IL_4c2c;
				case 237:
					goto IL_4c64;
				case 238:
					goto IL_4c99;
				case 239:
					goto IL_4cce;
				case 240:
					goto IL_4d0f;
				case 241:
					goto IL_4d44;
				case 242:
					goto IL_4d7c;
				case 243:
					goto IL_4dae;
				case 244:
					goto IL_4df4;
				case 245:
					goto IL_4e2c;
				case 246:
					goto IL_4e61;
				case 247:
					goto IL_4e96;
				case 248:
					goto IL_4ecb;
				case 249:
					goto IL_4efe;
				case 250:
					goto IL_4f34;
				case 251:
					goto IL_4f6a;
				case 252:
					goto IL_4fa0;
				case 253:
					goto IL_4fd6;
				case 254:
					goto IL_5017;
				case 255:
					goto IL_505a;
				case 256:
					goto IL_5092;
				case 257:
					goto IL_50ca;
				case 258:
					goto IL_50fc;
				default:
					goto IL_513d;
				}
				if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
				{
					class1661_0.method_10(new byte[1]);
					class1661_0.method_9()[0] = 15;
					enum227_ = Class1663.enum227_3;
					goto IL_516b;
				}
				throw new CellsException(ExceptionType.Formula, string_0);
			}
		}
		goto IL_513d;
		IL_28f1:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
		{
			enum227_ = method_19(class1661_0, 41, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_45f8:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 15, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_28b9:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
		{
			enum227_ = method_19(class1661_0, 195, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_3372:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 127, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_2523:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 140, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_255b:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
		{
			enum227_ = method_19(class1661_0, 42, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_1abc:
		class1661_0.method_10(new byte[1]);
		class1661_0.method_9()[0] = 20;
		enum227_ = Class1663.enum227_2;
		goto IL_516b;
		IL_198a:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
		{
			class1661_0.method_10(new byte[1]);
			class1661_0.method_9()[0] = 6;
			enum227_ = Class1663.enum227_2;
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_18d1:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0 && class1661_0.method_7().Count <= 2)
		{
			class1661_0.method_10(new byte[1]);
			if (class1661_0.method_7().Count == 1)
			{
				class1661_0.method_9()[0] = 19;
			}
			if (class1661_0.method_7().Count == 2)
			{
				class1661_0.method_9()[0] = 4;
			}
			enum227_ = Class1663.enum227_2;
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_45c3:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 26, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_3b7f:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 38, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_1d29:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0)
		{
			enum227_ = method_18(class1661_0, 36, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_458e:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 73, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_3b0f:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
		{
			enum227_ = method_19(class1661_0, 295, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_3305:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 4)
		{
			enum227_ = method_19(class1661_0, 350, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_333d:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 105, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_2d29:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 3 && class1661_0.method_7().Count <= 5)
		{
			enum227_ = method_18(class1661_0, 57, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_3ad7:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 294, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_1b8c:
		class1661_0.method_10(new byte[1]);
		class1661_0.method_9()[0] = 13;
		enum227_ = Class1663.enum227_2;
		goto IL_516b;
		IL_2075:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
		{
			enum227_ = method_19(class1661_0, 275, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_4505:
		if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 2 || class1661_0.method_7().Count == 3))
		{
			enum227_ = method_18(class1661_0, 82, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_2cf1:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
		{
			enum227_ = method_19(class1661_0, 310, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_24eb:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 352, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_1add:
		class1661_0.method_10(new byte[1]);
		class1661_0.method_9()[0] = 21;
		enum227_ = new Enum227[1] { enum227_0 };
		goto IL_516b;
		IL_1a12:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
		{
			class1661_0.method_10(new byte[1]);
			class1661_0.method_9()[0] = 8;
			enum227_ = Class1663.enum227_2;
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_1a77:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
		{
			class1661_0.method_10(new byte[1]);
			class1661_0.method_9()[0] = 17;
			enum227_ = Class1663.enum227_3;
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_1946:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
		{
			class1661_0.method_10(new byte[1]);
			class1661_0.method_9()[0] = 5;
			enum227_ = Class1663.enum227_2;
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_19ce:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
		{
			class1661_0.method_10(new byte[1]);
			class1661_0.method_9()[0] = 7;
			enum227_ = Class1663.enum227_2;
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_4548:
		if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 2 || class1661_0.method_7().Count == 3))
		{
			enum227_ = method_18(class1661_0, 206, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_3b47:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 296, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_2884:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
		{
			enum227_ = method_19(class1661_0, 45, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_3a9f:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 4)
		{
			enum227_ = method_19(class1661_0, 293, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_32cd:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 128, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_44cd:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
		{
			enum227_ = method_19(class1661_0, 313, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_3a8e:
		enum227_ = method_19(class1661_0, 10, enum227_0, enum226_0);
		goto IL_516b;
		IL_4498:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 76, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_225b:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
		{
			enum227_ = method_19(class1661_0, 277, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_3a45:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 68, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_516b:
		return enum227_;
		IL_04c7:
		class1661_0.method_10(new byte[2]);
		class1661_0.method_9()[0] = 29;
		class1661_0.method_9()[1] = 1;
		goto IL_0516;
		IL_1ecd:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 3 && class1661_0.method_7().Count <= 5)
		{
			enum227_ = method_18(class1661_0, 270, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_1a56:
		class1661_0.method_10(new byte[1]);
		class1661_0.method_9()[0] = 16;
		enum227_ = Class1663.enum227_3;
		goto IL_516b;
		IL_185c:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0 && class1661_0.method_7().Count <= 2)
		{
			class1661_0.method_10(new byte[1]);
			if (class1661_0.method_7().Count == 1)
			{
				class1661_0.method_9()[0] = 18;
			}
			if (class1661_0.method_7().Count == 2)
			{
				class1661_0.method_9()[0] = 3;
			}
			enum227_ = Class1663.enum227_2;
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_1b08:
		class1661_0.method_10(new byte[1]);
		class1661_0.method_9()[0] = 9;
		enum227_ = Class1663.enum227_2;
		goto IL_516b;
		IL_513d:
		if (class1661_0.Type != Enum180.const_3 && class1661_0.Type != Enum180.const_4)
		{
			method_9(class1661_0, enum227_0);
			enum227_ = Class1663.enum227_2;
		}
		else
		{
			enum227_ = method_21(class1661_0, enum227_0, enum226_0);
		}
		goto IL_516b;
		IL_43f3:
		if (class1661_0.method_7() == null)
		{
			throw new CellsException(ExceptionType.Formula, string_0);
		}
		if (class1661_0.method_7().Count == 1)
		{
			Class1661 class2 = new Class1661();
			class2.method_4("0");
			class2.Type = Enum180.const_1;
			class1661_0.method_1(class2);
		}
		if (class1661_0.method_7().Count != 2)
		{
			throw new CellsException(ExceptionType.Formula, string_0);
		}
		enum227_ = method_19(class1661_0, 212, enum227_0, enum226_0);
		goto IL_516b;
		IL_3261:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 2, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_2cb9:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
		{
			enum227_ = method_19(class1661_0, 252, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_1b6b:
		class1661_0.method_10(new byte[1]);
		class1661_0.method_9()[0] = 12;
		enum227_ = Class1663.enum227_2;
		goto IL_516b;
		IL_050e:
		method_9(class1661_0, enum227_0);
		goto IL_0516;
		IL_0516:
		return Class1663.enum227_3;
		IL_284c:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
		{
			enum227_ = method_19(class1661_0, 189, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_3a7a:
		enum227_ = method_19(class1661_0, 131, enum227_0, enum226_0);
		goto IL_516b;
		IL_3295:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 190, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_4466:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count > 1)
		{
			throw new CellsException(ExceptionType.Formula, string_0);
		}
		enum227_ = method_18(class1661_0, 8, enum227_0, enum226_0);
		goto IL_516b;
		IL_3a1d:
		if (class1661_0.method_7() == null)
		{
			throw new CellsException(ExceptionType.Formula, string_0);
		}
		enum227_ = method_18(class1661_0, 330, enum227_0, enum226_0);
		goto IL_516b;
		IL_50fc:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 2 && class1661_0.method_7().Count <= 3)
		{
			enum227_ = method_18(class1661_0, 324, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_39e8:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
		{
			enum227_ = method_19(class1661_0, 39, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_1dfa:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 234, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_2c81:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
		{
			enum227_ = method_19(class1661_0, 309, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_1b4a:
		class1661_0.method_10(new byte[1]);
		class1661_0.method_9()[0] = 10;
		enum227_ = Class1663.enum227_2;
		goto IL_516b;
		IL_50ca:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 69, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_39b0:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
		{
			enum227_ = method_19(class1661_0, 165, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_2806:
		if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 1 || class1661_0.method_7().Count == 2))
		{
			enum227_ = method_18(class1661_0, 204, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_4380:
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
		enum227_ = method_19(class1661_0, 213, enum227_0, enum226_0);
		goto IL_516b;
		IL_5092:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 215, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_2c49:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
		{
			enum227_ = method_19(class1661_0, 285, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_397b:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
		{
			enum227_ = method_19(class1661_0, 61, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_322d:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 3, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_505a:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 4)
		{
			enum227_ = method_18(class1661_0, 302, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_4310:
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
		enum227_ = method_19(class1661_0, 27, enum227_0, enum226_0);
		goto IL_516b;
		IL_27d1:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
		{
			enum227_ = method_19(class1661_0, 43, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_31f5:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 198, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_5017:
		if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 1 || class1661_0.method_7().Count == 2))
		{
			enum227_ = method_18(class1661_0, 70, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_24b3:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
		{
			enum227_ = method_19(class1661_0, 351, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_31c0:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 126, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_3946:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 72, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_2225:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 1)
		{
			enum227_ = method_18(class1661_0, 336, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_4fd6:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 3 && class1661_0.method_7().Count <= 4)
		{
			enum227_ = method_18(class1661_0, 102, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_42ca:
		if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 1 || class1661_0.method_7().Count == 2))
		{
			enum227_ = method_18(class1661_0, 354, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_247e:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
		{
			enum227_ = method_19(class1661_0, 65, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_2008:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 111, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_1cf1:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 232, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_4fa0:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count > 0)
		{
			enum227_ = method_18(class1661_0, 222, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_3911:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0)
		{
			enum227_ = method_18(class1661_0, 363, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_4284:
		if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 1 || class1661_0.method_7().Count == 2))
		{
			enum227_ = method_18(class1661_0, 209, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_2c08:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 1 && class1661_0.method_7().Count <= 3)
		{
			enum227_ = method_18(class1661_0, 14, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_4f6a:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count > 0)
		{
			enum227_ = method_18(class1661_0, 365, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_3188:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 129, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_2bc2:
		if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 2 || class1661_0.method_7().Count == 3))
		{
			enum227_ = method_18(class1661_0, 205, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_21ed:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
		{
			enum227_ = method_19(class1661_0, 276, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_4f34:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count > 0)
		{
			enum227_ = method_18(class1661_0, 194, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_4241:
		if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 1 || class1661_0.method_7().Count == 2))
		{
			enum227_ = method_18(class1661_0, 116, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_3145:
		if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 1 || class1661_0.method_7().Count == 2))
		{
			enum227_ = method_18(class1661_0, 62, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_38e0:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0)
		{
			enum227_ = method_18(class1661_0, 6, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_4efe:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count > 0)
		{
			enum227_ = method_18(class1661_0, 367, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_2774:
		if (class1661_0.method_7() == null)
		{
			throw new CellsException(ExceptionType.Formula, string_0);
		}
		enum227_ = method_18(class1661_0, 318, enum227_0, enum226_0);
		goto IL_516b;
		IL_38a8:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
		{
			enum227_ = method_19(class1661_0, 210, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_279c:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
		{
			enum227_ = method_19(class1661_0, 44, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_4ecb:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count > 0)
		{
			enum227_ = method_18(class1661_0, 46, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_203d:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
		{
			enum227_ = method_19(class1661_0, 274, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_1c38:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 233, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_420c:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
		{
			enum227_ = method_19(class1661_0, 30, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_4e96:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 33, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_41d4:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 4)
		{
			enum227_ = method_19(class1661_0, 207, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_383b:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_18(class1661_0, 164, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_3873:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
		{
			enum227_ = method_19(class1661_0, 31, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_4e61:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 113, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_2446:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
		{
			enum227_ = method_19(class1661_0, 278, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_419f:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 4)
		{
			enum227_ = method_19(class1661_0, 119, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_1e98:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0)
		{
			enum227_ = method_18(class1661_0, 361, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_4e2c:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 86, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_3803:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_18(class1661_0, 163, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_1fd0:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
		{
			enum227_ = method_19(class1661_0, 288, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_3101:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 4 && class1661_0.method_7().Count <= 6)
		{
			enum227_ = method_18(class1661_0, 167, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_4df4:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 4)
		{
			enum227_ = method_19(class1661_0, 316, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_30c9:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
		{
			enum227_ = method_19(class1661_0, 311, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_273c:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 343, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_415e:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 3 && class1661_0.method_7().Count <= 6)
		{
			enum227_ = method_18(class1661_0, 60, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_4dae:
		if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 1 || class1661_0.method_7().Count == 2))
		{
			enum227_ = method_18(class1661_0, 197, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_2b7f:
		if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 2 || class1661_0.method_7().Count == 3))
		{
			enum227_ = method_18(class1661_0, 124, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_21b8:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 77, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_4118:
		if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 2 || class1661_0.method_7().Count == 3))
		{
			enum227_ = method_18(class1661_0, 216, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_37ce:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0)
		{
			enum227_ = method_18(class1661_0, 227, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_4d7c:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0)
		{
			throw new CellsException(ExceptionType.Formula, string_0);
		}
		enum227_ = method_19(class1661_0, 34, enum227_0, enum226_0);
		goto IL_516b;
		IL_2b47:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
		{
			enum227_ = method_19(class1661_0, 282, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_240e:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
		{
			enum227_ = method_19(class1661_0, 308, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_3799:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0)
		{
			enum227_ = method_18(class1661_0, 362, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_4d44:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
		{
			enum227_ = method_19(class1661_0, 331, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_2b0f:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
		{
			enum227_ = method_19(class1661_0, 281, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_3094:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 25, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_40e6:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0)
		{
			throw new CellsException(ExceptionType.Formula, string_0);
		}
		enum227_ = method_19(class1661_0, 63, enum227_0, enum226_0);
		goto IL_516b;
		IL_4d0f:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 118, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_40ae:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 342, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_305c:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_18(class1661_0, 244, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_1cbc:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 98, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_4cce:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 1 && class1661_0.method_7().Count <= 4)
		{
			enum227_ = method_18(class1661_0, 50, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_3768:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0)
		{
			enum227_ = method_18(class1661_0, 7, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_4076:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
		{
			enum227_ = method_19(class1661_0, 327, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_3725:
		if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 2 || class1661_0.method_7().Count == 3))
		{
			enum227_ = method_18(class1661_0, 64, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_1dc5:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
		{
			enum227_ = method_19(class1661_0, 97, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_4c99:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 83, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_2704:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
		{
			enum227_ = method_19(class1661_0, 235, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_4035:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 3 && class1661_0.method_7().Count <= 5)
		{
			enum227_ = method_18(class1661_0, 56, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_1e67:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0)
		{
			enum227_ = method_18(class1661_0, 5, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_4c64:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0)
		{
			throw new CellsException(ExceptionType.Formula, string_0);
		}
		enum227_ = method_19(class1661_0, 221, enum227_0, enum226_0);
		goto IL_516b;
		IL_23d6:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
		{
			enum227_ = method_19(class1661_0, 346, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_36f0:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 112, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_300f:
		if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 1 || class1661_0.method_7().Count == 2))
		{
			enum227_ = method_18(class1661_0, 148, enum227_0, enum226_0);
			bool_0 = true;
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_4c2c:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
		{
			enum227_ = method_19(class1661_0, 332, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_4002:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count != 1)
		{
			throw new CellsException(ExceptionType.Formula, string_0);
		}
		enum227_ = method_19(class1661_0, 114, enum227_0, enum226_0);
		goto IL_516b;
		IL_2add:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0)
		{
			throw new CellsException(ExceptionType.Formula, string_0);
		}
		enum227_ = method_19(class1661_0, 35, enum227_0, enum226_0);
		goto IL_516b;
		IL_2185:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count > 1)
		{
			throw new CellsException(ExceptionType.Formula, string_0);
		}
		enum227_ = method_18(class1661_0, 9, enum227_0, enum226_0);
		goto IL_516b;
		IL_4bf4:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 141, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_2150:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 121, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_3fcc:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 1)
		{
			enum227_ = method_18(class1661_0, 183, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_26be:
		if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 4 || class1661_0.method_7().Count == 5))
		{
			enum227_ = method_18(class1661_0, 144, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_4bbf:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
		{
			enum227_ = method_19(class1661_0, 66, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_239e:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 347, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_36ad:
		if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 2 || class1661_0.method_7().Count == 3))
		{
			enum227_ = method_18(class1661_0, 28, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_1bce:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 24, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_4b8a:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
		{
			enum227_ = method_19(class1661_0, 48, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_2fce:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 2 && class1661_0.method_7().Count <= 4)
		{
			enum227_ = method_18(class1661_0, 29, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_3675:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
		{
			enum227_ = method_19(class1661_0, 292, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_3f88:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 3 && class1661_0.method_7().Count <= 4)
		{
			enum227_ = method_18(class1661_0, 317, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_4b52:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
		{
			enum227_ = method_19(class1661_0, 301, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_2678:
		if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 4 || class1661_0.method_7().Count == 5))
		{
			enum227_ = method_18(class1661_0, 247, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_3f44:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 4 && class1661_0.method_7().Count <= 6)
		{
			enum227_ = method_18(class1661_0, 168, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_2f8c:
		if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 2 || class1661_0.method_7().Count == 3))
		{
			enum227_ = method_18(class1661_0, 1, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_4b1a:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 231, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_3634:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count <= 4 && class1661_0.method_7().Count >= 1)
		{
			enum227_ = method_18(class1661_0, 51, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_2369:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0)
		{
			enum227_ = method_18(class1661_0, 169, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_2aa5:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 184, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_4ae5:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 17, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_3f0c:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
		{
			enum227_ = method_19(class1661_0, 337, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_2f54:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 4)
		{
			enum227_ = method_19(class1661_0, 289, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_1f8d:
		if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 1 || class1661_0.method_7().Count == 2))
		{
			enum227_ = method_18(class1661_0, 125, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_4aad:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 130, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_2a6d:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
		{
			enum227_ = method_19(class1661_0, 280, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_3ed4:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
		{
			enum227_ = method_19(class1661_0, 300, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_1d90:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 18, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_4a75:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 4)
		{
			enum227_ = method_19(class1661_0, 143, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_2a38:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 21, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_35fc:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
		{
			enum227_ = method_19(class1661_0, 291, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_1e32:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0)
		{
			enum227_ = method_18(class1661_0, 269, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_4a3d:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
		{
			enum227_ = method_19(class1661_0, 303, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_35c4:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
		{
			enum227_ = method_19(class1661_0, 290, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_2a03:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
		{
			enum227_ = method_19(class1661_0, 117, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_3e93:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 3 && class1661_0.method_7().Count <= 5)
		{
			enum227_ = method_18(class1661_0, 59, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_4a05:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
		{
			enum227_ = method_19(class1661_0, 305, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_2643:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 67, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_3e61:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0)
		{
			throw new CellsException(ExceptionType.Formula, string_0);
		}
		enum227_ = method_19(class1661_0, 19, enum227_0, enum226_0);
		goto IL_516b;
		IL_260b:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
		{
			enum227_ = method_19(class1661_0, 199, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_49cd:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
		{
			enum227_ = method_19(class1661_0, 304, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_1b29:
		class1661_0.method_10(new byte[1]);
		class1661_0.method_9()[0] = 11;
		enum227_ = Class1663.enum227_2;
		goto IL_516b;
		IL_2f0e:
		if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 2 || class1661_0.method_7().Count == 1))
		{
			enum227_ = method_18(class1661_0, 359, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_358f:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 23, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_4996:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count > 30)
		{
			throw new CellsException(ExceptionType.Formula, string_0);
		}
		enum227_ = method_18(class1661_0, 321, enum227_0, enum226_0);
		goto IL_516b;
		IL_2118:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 162, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_354e:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 1 && class1661_0.method_7().Count <= 2)
		{
			enum227_ = method_18(class1661_0, 109, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_3e29:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 360, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_4950:
		if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 2 || class1661_0.method_7().Count == 3))
		{
			enum227_ = method_18(class1661_0, 345, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_3df1:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
		{
			enum227_ = method_19(class1661_0, 299, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_2e98:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 3 && class1661_0.method_7().Count <= 4)
		{
			enum227_ = method_18(class1661_0, 101, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_2338:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0)
		{
			enum227_ = method_18(class1661_0, 0, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_2ed9:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 71, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_491b:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0)
		{
			enum227_ = method_18(class1661_0, 228, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_3dad:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 2 && class1661_0.method_7().Count <= 3)
		{
			enum227_ = method_18(class1661_0, 329, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_353d:
		enum227_ = method_19(class1661_0, 22, enum227_0, enum226_0);
		goto IL_516b;
		IL_1d5b:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_18(class1661_0, 18, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_48ec:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0)
		{
			enum227_ = method_17(class1661_0, enum227_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_2993:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 261, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_29cb:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 279, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_34fd:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0 && class1661_0.method_7().Count <= 4)
		{
			enum227_ = method_18(class1661_0, 49, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_48b6:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 2)
		{
			enum227_ = method_18(class1661_0, 344, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_1f55:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 4)
		{
			enum227_ = method_19(class1661_0, 273, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_1c70:
		enum227_ = method_18(class1661_0, 219, enum227_0, enum226_0);
		goto IL_516b;
		IL_3d75:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
		{
			enum227_ = method_19(class1661_0, 328, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_4873:
		if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 3 || class1661_0.method_7().Count == 4))
		{
			enum227_ = method_18(class1661_0, 120, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_3d3d:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
		{
			enum227_ = method_19(class1661_0, 312, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_25d6:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
		{
			enum227_ = method_19(class1661_0, 40, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_1c03:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 99, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_1c84:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 214, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_483b:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
		{
			enum227_ = method_19(class1661_0, 314, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_3d0b:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0)
		{
			enum227_ = method_18(class1661_0, 37, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_3490:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 32, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_34c5:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 211, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_4806:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0)
		{
			enum227_ = method_18(class1661_0, 364, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_2e70:
		if (class1661_0.method_7() == null)
		{
			throw new CellsException(ExceptionType.Formula, string_0);
		}
		enum227_ = method_18(class1661_0, 320, enum227_0, enum226_0);
		goto IL_516b;
		IL_3cca:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 3 && class1661_0.method_7().Count <= 5)
		{
			enum227_ = method_18(class1661_0, 78, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_2590:
		if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 2 || class1661_0.method_7().Count == 3))
		{
			enum227_ = method_18(class1661_0, 220, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_47d1:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0)
		{
			enum227_ = method_18(class1661_0, 193, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_344a:
		if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 1 || class1661_0.method_7().Count == 2))
		{
			enum227_ = method_18(class1661_0, 208, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_2e12:
		if (class1661_0.method_7() == null)
		{
			throw new CellsException(ExceptionType.Formula, string_0);
		}
		enum227_ = method_18(class1661_0, 319, enum227_0, enum226_0);
		goto IL_516b;
		IL_2e3a:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 2)
		{
			enum227_ = method_18(class1661_0, 358, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_479c:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0)
		{
			enum227_ = method_18(class1661_0, 366, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_3c92:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 298, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_2300:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 230, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_22cb:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 16, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_476a:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0)
		{
			enum227_ = method_18(class1661_0, 12, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_2926:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
		{
			enum227_ = method_19(class1661_0, 47, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_3c5f:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 2)
		{
			enum227_ = method_18(class1661_0, 11, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_295b:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
		{
			enum227_ = method_19(class1661_0, 196, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_4732:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
		{
			enum227_ = method_19(class1661_0, 297, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_20ad:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
		{
			enum227_ = method_19(class1661_0, 306, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_3407:
		if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 1 || class1661_0.method_7().Count == 2))
		{
			enum227_ = method_18(class1661_0, 115, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_20e5:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 1)
		{
			enum227_ = method_18(class1661_0, 100, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_46fd:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 20, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_2dda:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 271, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_33cf:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
		{
			enum227_ = method_19(class1661_0, 325, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_3c1e:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 3 && class1661_0.method_7().Count <= 5)
		{
			enum227_ = method_18(class1661_0, 58, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_46c5:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
		{
			enum227_ = method_19(class1661_0, 326, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_1bad:
		class1661_0.method_10(new byte[1]);
		class1661_0.method_9()[0] = 14;
		enum227_ = Class1663.enum227_2;
		goto IL_516b;
		IL_3be6:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
		{
			enum227_ = method_19(class1661_0, 353, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_2293:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
		{
			enum227_ = method_19(class1661_0, 307, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_468d:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
		{
			enum227_ = method_19(class1661_0, 142, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_33a7:
		if (class1661_0.method_7() == null)
		{
			throw new CellsException(ExceptionType.Formula, string_0);
		}
		enum227_ = method_18(class1661_0, 322, enum227_0, enum226_0);
		goto IL_516b;
		IL_1f11:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 3 && class1661_0.method_7().Count <= 5)
		{
			enum227_ = method_18(class1661_0, 272, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_2da2:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
		{
			enum227_ = method_19(class1661_0, 287, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_4665:
		if (class1661_0.method_7() == null)
		{
			throw new CellsException(ExceptionType.Formula, string_0);
		}
		enum227_ = method_18(class1661_0, 323, enum227_0, enum226_0);
		goto IL_516b;
		IL_3bb4:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0)
		{
			throw new CellsException(ExceptionType.Formula, string_0);
		}
		enum227_ = method_19(class1661_0, 74, enum227_0, enum226_0);
		goto IL_516b;
		IL_2d6a:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 4)
		{
			enum227_ = method_19(class1661_0, 286, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
		IL_462d:
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			enum227_ = method_19(class1661_0, 229, enum227_0, enum226_0);
			goto IL_516b;
		}
		throw new CellsException(ExceptionType.Formula, string_0);
	}

	private void method_8(Class1661 class1661_0)
	{
		string text = class1661_0.method_3();
		if (text != null && text.Length != 0)
		{
			if (text[0] == '"')
			{
				text = text.Substring(1, text.Length - 2);
				if (text.Length == 0)
				{
					class1661_0.method_10(new byte[4]);
					class1661_0.method_9()[0] = 2;
					return;
				}
			}
			else
			{
				if (Class1673.smethod_8(text))
				{
					class1661_0.method_10(new byte[9]);
					class1661_0.method_9()[0] = 16;
					string key;
					if ((key = text) == null)
					{
						return;
					}
					if (Class1742.dictionary_65 == null)
					{
						Class1742.dictionary_65 = new Dictionary<string, int>(7)
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
					if (Class1742.dictionary_65.TryGetValue(key, out var value))
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
					class1661_0.method_9()[0] = 1;
					Array.Copy(BitConverter.GetBytes(value2), 0, class1661_0.method_9(), 1, 8);
					return;
				}
				if (text.ToUpper().Equals("TRUE"))
				{
					class1661_0.method_10(new byte[9]);
					class1661_0.method_9()[0] = 4;
					class1661_0.method_9()[1] = 1;
					return;
				}
				if (text.ToUpper().Equals("FALSE"))
				{
					class1661_0.method_10(new byte[9]);
					class1661_0.method_9()[0] = 4;
					return;
				}
			}
			class1661_0.method_10(new byte[4 + text.Length * 2]);
			class1661_0.method_9()[0] = 2;
			Array.Copy(BitConverter.GetBytes(text.Length), 0, class1661_0.method_9(), 1, 2);
			class1661_0.method_9()[3] = 1;
			Array.Copy(Encoding.Unicode.GetBytes(text), 0, class1661_0.method_9(), 4, text.Length * 2);
		}
		else
		{
			class1661_0.method_10(new byte[9]);
		}
	}

	private void method_9(Class1661 class1661_0, Enum227 enum227_0)
	{
		if (class1661_0.method_3()[0] == '"' && class1661_0.method_3()[class1661_0.method_3().Length - 1] == '"')
		{
			if (class1661_0.method_3().Length - 2 > 255)
			{
				throw new CellsException(ExceptionType.Formula, string_0);
			}
			if (class1661_0.method_3() == "\"\"")
			{
				class1661_0.method_10(new byte[3]);
				class1661_0.method_9()[0] = 23;
				return;
			}
			class1661_0.method_4(class1661_0.method_3().Substring(1, class1661_0.method_3().Length - 2));
			class1661_0.method_4(class1661_0.method_3().Replace("\"\"", "\""));
			byte[] array = Class1677.smethod_15(class1661_0.method_3());
			if (array.Length == class1661_0.method_3().Length)
			{
				class1661_0.method_10(new byte[array.Length + 3]);
			}
			else
			{
				array = Encoding.Unicode.GetBytes(class1661_0.method_3());
				class1661_0.method_10(new byte[array.Length + 3]);
				class1661_0.method_9()[2] = 1;
			}
			class1661_0.method_9()[1] = (byte)class1661_0.method_3().Length;
			Array.Copy(array, 0, class1661_0.method_9(), 3, array.Length);
			class1661_0.method_9()[0] = 23;
			return;
		}
		if (Class1677.smethod_18(class1661_0.method_3()))
		{
			double num = double.Parse(class1661_0.method_3(), CultureInfo.InvariantCulture);
			if (!(num < 0.0) && !(num > 65535.0) && num - (double)(int)(ushort)num <= double.Epsilon)
			{
				ushort value = (ushort)num;
				class1661_0.method_10(new byte[3]);
				class1661_0.method_9()[0] = 30;
				Array.Copy(BitConverter.GetBytes(value), 0, class1661_0.method_9(), 1, 2);
			}
			else
			{
				class1661_0.method_10(new byte[9]);
				class1661_0.method_9()[0] = 31;
				Array.Copy(BitConverter.GetBytes(num), 0, class1661_0.method_9(), 1, 8);
			}
			return;
		}
		if (class1661_0.method_3().IndexOf(',') == -1)
		{
			if (method_25(class1661_0.method_3()))
			{
				int[] array2 = Class1303.smethod_0(worksheetCollection_0, class1661_0.method_3());
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
				Array.Copy(BitConverter.GetBytes((ushort)array2[0]), 0, class1661_0.method_9(), 1, 2);
				Array.Copy(BitConverter.GetBytes((ushort)array2[1]), 0, class1661_0.method_9(), 3, 2);
			}
			else if (worksheetCollection_0.method_2() == null && method_24(class1661_0.method_3()))
			{
				class1661_0.method_10(Class1689.smethod_0(worksheetCollection_0, (cell_0 == null) ? (-1) : cell_0.method_4().method_3().Index, int_1, int_2, class1661_0.method_3(), enum227_0, out var InvalidTable));
				if (InvalidTable)
				{
					method_4(bool_1: true);
				}
			}
			else if (!CheckCell(class1661_0.method_3()))
			{
				class1661_0.method_10(method_12(class1661_0, enum227_0));
			}
			else
			{
				class1661_0.method_10(method_10(class1661_0, class1661_0.method_3(), enum227_0));
			}
			return;
		}
		string[] array3 = Class1660.smethod_17(class1661_0.method_3());
		if (array3 != null && array3.Length != 1)
		{
			ArrayList arrayList = new ArrayList();
			int num2 = 2;
			for (int i = 0; i < array3.Length; i++)
			{
				class1661_0.method_4(array3[i]);
				class1661_0.method_10(null);
				if (!CheckCell(class1661_0.method_3()))
				{
					class1661_0.method_10(method_12(class1661_0, enum227_0));
				}
				else
				{
					class1661_0.method_10(method_10(class1661_0, class1661_0.method_3(), enum227_0));
				}
				if (class1661_0.method_9() != null)
				{
					arrayList.Add(class1661_0.method_9());
					num2 += class1661_0.method_9().Length + 1;
				}
			}
			class1661_0.method_10(new byte[num2]);
			class1661_0.method_9()[0] = 41;
			Array.Copy(BitConverter.GetBytes((ushort)(num2 - 3)), 0, class1661_0.method_9(), 1, 2);
			int num3 = 3;
			for (int j = 0; j < arrayList.Count; j++)
			{
				byte[] array4 = (byte[])arrayList[j];
				Array.Copy(array4, 0, class1661_0.method_9(), num3, array4.Length);
				num3 += array4.Length;
				if (j > 0)
				{
					class1661_0.method_9()[num3] = 16;
					num3++;
				}
			}
		}
		else if (method_25(class1661_0.method_3()))
		{
			int[] array5 = Class1303.smethod_0(worksheetCollection_0, class1661_0.method_3());
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
			Array.Copy(BitConverter.GetBytes((ushort)array5[0]), 0, class1661_0.method_9(), 1, 2);
			Array.Copy(BitConverter.GetBytes((ushort)array5[1]), 0, class1661_0.method_9(), 3, 2);
		}
		else if (worksheetCollection_0.method_2() == null && method_24(class1661_0.method_3()))
		{
			class1661_0.method_10(Class1689.smethod_0(worksheetCollection_0, (cell_0 == null) ? (-1) : cell_0.method_4().method_3().Index, int_1, int_2, class1661_0.method_3(), enum227_0, out var InvalidTable2));
			if (InvalidTable2)
			{
				method_4(bool_1: true);
			}
		}
		else if (!CheckCell(class1661_0.method_3()))
		{
			class1661_0.method_10(method_12(class1661_0, enum227_0));
		}
		else
		{
			class1661_0.method_10(method_10(class1661_0, class1661_0.method_3(), enum227_0));
		}
	}

	internal byte[] method_10(Class1661 class1661_0, string string_1, Enum227 enum227_0)
	{
		if (worksheetCollection_0 != null && worksheetCollection_0.method_39() != null && worksheetCollection_0.method_39().Count != 0)
		{
			worksheetCollection_0.method_36();
		}
		int row = 0;
		int column = 0;
		bool isColumnAbsolute = false;
		bool isRowAbsolute = false;
		try
		{
			int num = string_1.LastIndexOf('!');
			if (num == string_1.Length - 1)
			{
				num = string_1.IndexOf('!');
			}
			byte[] array;
			if (num == -1)
			{
				bool isRowOnly = false;
				bool isColumnOnly = false;
				string_1 = string_1.ToUpper();
				if (!CellNameToIndex(string_1, out row, out column, isInArea: false, ref isRowAbsolute, ref isColumnAbsolute, ref isRowOnly, ref isColumnOnly))
				{
					return method_22(class1661_0, string_1, enum227_0);
				}
				array = new byte[5];
				if (method_2() && !isRowAbsolute)
				{
					if (row >= int_1)
					{
						Array.Copy(BitConverter.GetBytes((ushort)(row - int_1)), 0, array, 1, 2);
					}
					else
					{
						Array.Copy(BitConverter.GetBytes((ushort)(65535 - int_1 + row + 1)), 0, array, 1, 2);
					}
				}
				else
				{
					Array.Copy(BitConverter.GetBytes(row), 0, array, 1, 2);
				}
				if (method_2() && !isColumnAbsolute)
				{
					if (column >= int_2)
					{
						array[3] = (byte)(column - int_2);
					}
					else
					{
						array[3] = (byte)(255 - int_2 + column + 1);
					}
				}
				else
				{
					array[3] = (byte)column;
				}
				if (!isColumnAbsolute)
				{
					array[4] |= 64;
				}
				if (!isRowAbsolute)
				{
					array[4] |= 128;
				}
				if (method_2() && (!isColumnAbsolute || !isRowAbsolute))
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
			string string_2 = string_1.Substring(0, num);
			string_2 = method_14(string_2);
			string text = string_1.Substring(num + 1).ToUpper();
			int num2 = -1;
			int[] array2 = Class1660.smethod_3(worksheetCollection_0, string_2);
			int num3 = array2[0];
			num2 = array2[1];
			int int_ = array2[2];
			if (num3 == -1)
			{
				return method_22(class1661_0, string_1, enum227_0);
			}
			bool isRowOnly2 = false;
			bool isColumnOnly2 = false;
			if (!CellNameToIndex(text, out row, out column, isInArea: false, ref isRowAbsolute, ref isColumnAbsolute, ref isRowOnly2, ref isColumnOnly2))
			{
				if (text == "#REF!")
				{
					array = new byte[7];
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
				return smethod_0(worksheetCollection_0, num2, num3, int_, text, class1661_0.Type, enum227_0);
			}
			array = new byte[7];
			method_11(array, 3, row, column, isRowAbsolute, isColumnAbsolute);
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
			return method_22(class1661_0, string_1, enum227_0);
		}
	}

	internal void method_11(byte[] byte_1, int int_3, int int_4, int int_5, bool bool_1, bool bool_2)
	{
		if (method_2() && !bool_1)
		{
			if (int_4 >= int_1)
			{
				Array.Copy(BitConverter.GetBytes((ushort)(int_4 - int_1)), 0, byte_1, int_3, 2);
			}
			else
			{
				Array.Copy(BitConverter.GetBytes((ushort)(65535 - int_1 + int_4 + 1)), 0, byte_1, int_3, 2);
			}
		}
		else
		{
			Array.Copy(BitConverter.GetBytes(int_4), 0, byte_1, int_3, 2);
		}
		if (method_2() && !bool_2)
		{
			if (int_5 >= int_2)
			{
				byte_1[int_3 + 2] = (byte)(int_5 - int_2);
			}
			else
			{
				byte_1[int_3 + 2] = (byte)(255 - int_2 + int_5 + 1);
			}
		}
		else
		{
			byte_1[int_3 + 2] = (byte)int_5;
		}
		if (!bool_2)
		{
			byte_1[int_3 + 3] |= 64;
		}
		if (!bool_1)
		{
			byte_1[int_3 + 3] |= 128;
		}
	}

	private byte[] method_12(Class1661 class1661_0, Enum227 enum227_0)
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
					return method_13(class1661_0, text, text2, enum227_0);
				}
				return method_16(class1661_0, text, text2, num3, enum227_0);
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
				array2 = ((i + 1 < array.Length) ? method_13(class1661_0, array[i], array[i + 1], enum227_0) : method_10(class1661_0, array[i], enum227_0));
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
		string string_ = class1661_0.method_3().Substring(0, num);
		string string_2 = class1661_0.method_3().Substring(num + 1, num3 - num - 1);
		text = class1661_0.method_3().Substring(num3 + 1, num2 - num3 - 1);
		text2 = class1661_0.method_3().Substring(num2 + 1);
		return method_15(class1661_0, string_, string_2, text, text2, enum227_0);
	}

	internal byte[] method_13(Class1661 class1661_0, string string_1, string string_2, Enum227 enum227_0)
	{
		byte[] array = new byte[9];
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
				if (method_2() && !isRowAbsolute)
				{
					if (row >= int_1)
					{
						Array.Copy(BitConverter.GetBytes((ushort)(row - int_1)), 0, array, 1, 2);
					}
					else
					{
						Array.Copy(BitConverter.GetBytes((ushort)(65535 - int_1 + row + 1)), 0, array, 1, 2);
					}
				}
				else
				{
					Array.Copy(BitConverter.GetBytes(row), 0, array, 1, 2);
				}
				array[7] = byte.MaxValue;
				if (!isRowAbsolute)
				{
					array[6] |= 128;
				}
			}
			else if (isColumnOnly)
			{
				array[3] = byte.MaxValue;
				array[4] = byte.MaxValue;
				if (method_2() && !isColumnAbsolute)
				{
					if (column >= int_2)
					{
						array[5] = (byte)(column - int_2);
					}
					else
					{
						array[5] = (byte)(255 - int_2 + column + 1);
					}
				}
				else
				{
					array[5] = (byte)column;
				}
				if (!isColumnAbsolute)
				{
					array[6] |= 64;
				}
			}
			else
			{
				if (method_2() && !isRowAbsolute)
				{
					if (row >= int_1)
					{
						Array.Copy(BitConverter.GetBytes((ushort)(row - int_1)), 0, array, 1, 2);
					}
					else
					{
						Array.Copy(BitConverter.GetBytes((ushort)(65535 - int_1 + row + 1)), 0, array, 1, 2);
					}
				}
				else
				{
					Array.Copy(BitConverter.GetBytes(row), 0, array, 1, 2);
				}
				if (method_2() && !isColumnAbsolute)
				{
					if (column >= int_2)
					{
						array[5] = (byte)(column - int_2);
					}
					else
					{
						array[5] = (byte)(255 - int_2 + column + 1);
					}
				}
				else
				{
					array[5] = (byte)column;
				}
				if (!isRowAbsolute)
				{
					array[6] |= 128;
				}
				if (!isColumnAbsolute)
				{
					array[6] |= 64;
				}
			}
			if (isRowOnly2)
			{
				if (method_2() && !isRowAbsolute2)
				{
					if (row2 >= int_1)
					{
						Array.Copy(BitConverter.GetBytes((ushort)(row2 - int_1)), 0, array, 3, 2);
					}
					else
					{
						Array.Copy(BitConverter.GetBytes((ushort)(65535 - int_1 + row2 + 1)), 0, array, 3, 2);
					}
				}
				else
				{
					Array.Copy(BitConverter.GetBytes(row2), 0, array, 3, 2);
				}
				if (!isRowAbsolute2)
				{
					array[8] |= 128;
				}
			}
			else if (isColumnOnly2)
			{
				if (method_2() && !isColumnAbsolute2)
				{
					if (column2 >= int_2)
					{
						array[7] = (byte)(column2 - int_2);
					}
					else
					{
						array[7] = (byte)(255 - int_2 + column2 + 1);
					}
				}
				else
				{
					array[7] = (byte)column2;
				}
				if (!isColumnAbsolute2)
				{
					array[8] |= 64;
				}
			}
			else
			{
				if (method_2() && !isRowAbsolute2)
				{
					if (row2 >= int_1)
					{
						Array.Copy(BitConverter.GetBytes((ushort)(row2 - int_1)), 0, array, 3, 2);
					}
					else
					{
						Array.Copy(BitConverter.GetBytes((ushort)(65535 - int_1 + row2 + 1)), 0, array, 3, 2);
					}
				}
				else
				{
					Array.Copy(BitConverter.GetBytes(row2), 0, array, 3, 2);
				}
				if (method_2() && !isColumnAbsolute2)
				{
					if (column2 >= int_2)
					{
						array[7] = (byte)(column2 - int_2);
					}
					else
					{
						array[7] = (byte)(255 - int_2 + column2 + 1);
					}
				}
				else
				{
					array[7] = (byte)column2;
				}
				if (!isRowAbsolute2)
				{
					array[8] |= 128;
				}
				if (!isColumnAbsolute2)
				{
					array[8] |= 64;
				}
			}
		}
		catch (Exception)
		{
			throw new CellsException(ExceptionType.Formula, string_0);
		}
		if (method_2() && (!isColumnAbsolute2 || !isRowAbsolute2))
		{
			array[0] = 45;
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

	private string method_14(string string_1)
	{
		if (string_1[0] == '\'' && string_1[string_1.Length - 1] == '\'')
		{
			string_1 = string_1.Substring(1, string_1.Length - 2);
			string_1 = string_1.Replace("''", "'");
		}
		return string_1;
	}

	private byte[] method_15(Class1661 class1661_0, string string_1, string string_2, string string_3, string string_4, Enum227 enum227_0)
	{
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
			string string_5 = string_1;
			string_5 = method_14(string_5).ToUpper();
			bool flag = false;
			int num2 = 0;
			int num3 = 0;
			for (int j = 0; j < worksheetCollection_0.Count; j++)
			{
				if (worksheetCollection_0[j].Name.ToUpper() == string_5)
				{
					flag = true;
					num2 = j;
					break;
				}
			}
			if (!flag)
			{
				throw new CellsException(ExceptionType.Formula, "Invalid formula:" + class1661_0.method_3());
			}
			string_5 = string_2;
			string_5 = method_14(string_5).ToUpper();
			flag = false;
			for (int j = 0; j < worksheetCollection_0.Count; j++)
			{
				if (worksheetCollection_0[j].Name.ToUpper() == string_5)
				{
					num3 = j;
					flag = true;
					break;
				}
			}
			if (flag && num3 >= num2)
			{
				int num4 = worksheetCollection_0.method_32().method_10(num, num2, num3);
				if (num4 == -1)
				{
					num4 = worksheetCollection_0.method_32().method_3((ushort)num, (ushort)num2, (ushort)num3);
				}
				byte[] array = new byte[11];
				Array.Copy(BitConverter.GetBytes((ushort)num4), 0, array, 1, 2);
				bool isRowAbsolute = false;
				bool isColumnAbsolute = false;
				bool isRowOnly = false;
				bool isColumnOnly = false;
				try
				{
					CellNameToIndex(string_3, out var row, out var column, isInArea: true, ref isRowAbsolute, ref isColumnAbsolute, ref isRowOnly, ref isColumnOnly);
					if (isRowOnly)
					{
						if (method_2() && !isRowAbsolute)
						{
							if (row >= int_1)
							{
								Array.Copy(BitConverter.GetBytes((ushort)(row - int_1)), 0, array, 3, 2);
							}
							else
							{
								Array.Copy(BitConverter.GetBytes((ushort)(65535 - int_1 + row + 1)), 0, array, 3, 2);
							}
						}
						else
						{
							Array.Copy(BitConverter.GetBytes(row), 0, array, 3, 2);
						}
						array[9] = byte.MaxValue;
						if (!isRowAbsolute)
						{
							array[8] |= 128;
						}
					}
					else if (isColumnOnly)
					{
						array[5] = byte.MaxValue;
						array[6] = byte.MaxValue;
						if (method_2() && !isColumnAbsolute)
						{
							if (column >= int_2)
							{
								array[7] = (byte)(column - int_2);
							}
							else
							{
								array[7] = (byte)(255 - int_2 + column + 1);
							}
						}
						else
						{
							array[7] = (byte)column;
						}
						if (!isColumnAbsolute)
						{
							array[8] |= 64;
						}
					}
					else
					{
						if (method_2() && !isRowAbsolute)
						{
							if (row >= int_1)
							{
								Array.Copy(BitConverter.GetBytes((ushort)(row - int_1)), 0, array, 3, 2);
							}
							else
							{
								Array.Copy(BitConverter.GetBytes((ushort)(65535 - int_1 + row + 1)), 0, array, 3, 2);
							}
						}
						else
						{
							Array.Copy(BitConverter.GetBytes(row), 0, array, 3, 2);
						}
						if (method_2() && !isColumnAbsolute)
						{
							if (column >= int_2)
							{
								array[7] = (byte)(column - int_2);
							}
							else
							{
								array[7] = (byte)(255 - int_2 + column + 1);
							}
						}
						else
						{
							array[7] = (byte)column;
						}
						if (!isRowAbsolute)
						{
							array[8] |= 128;
						}
						if (!isColumnAbsolute)
						{
							array[8] |= 64;
						}
					}
					bool flag2 = isRowOnly;
					bool flag3 = isColumnOnly;
					isRowAbsolute = false;
					isColumnAbsolute = false;
					isRowOnly = false;
					isColumnOnly = false;
					CellNameToIndex(string_4, out row, out column, isInArea: true, ref isRowAbsolute, ref isColumnAbsolute, ref isRowOnly, ref isColumnOnly);
					if (flag2 != isRowOnly || flag3 != isColumnOnly)
					{
						throw new CellsException(ExceptionType.Formula, "Invalid formula.");
					}
					if (isRowOnly)
					{
						if (method_2() && !isRowAbsolute)
						{
							if (row >= int_1)
							{
								Array.Copy(BitConverter.GetBytes((ushort)(row - int_1)), 0, array, 5, 2);
							}
							else
							{
								Array.Copy(BitConverter.GetBytes((ushort)(65535 - int_1 + row + 1)), 0, array, 5, 2);
							}
						}
						else
						{
							Array.Copy(BitConverter.GetBytes(row), 0, array, 5, 2);
						}
						if (!isRowAbsolute)
						{
							array[10] |= 128;
						}
					}
					else if (isColumnOnly)
					{
						if (method_2() && !isColumnAbsolute)
						{
							if (column >= int_2)
							{
								array[9] = (byte)(column - int_2);
							}
							else
							{
								array[9] = (byte)(255 - int_2 + column + 1);
							}
						}
						else
						{
							array[9] = (byte)column;
						}
						if (!isColumnAbsolute)
						{
							array[10] |= 64;
						}
					}
					else
					{
						if (method_2() && !isRowAbsolute)
						{
							if (row >= int_1)
							{
								Array.Copy(BitConverter.GetBytes((ushort)(row - int_1)), 0, array, 5, 2);
							}
							else
							{
								Array.Copy(BitConverter.GetBytes((ushort)(65535 - int_1 + row + 1)), 0, array, 5, 2);
							}
						}
						else
						{
							Array.Copy(BitConverter.GetBytes(row), 0, array, 5, 2);
						}
						if (method_2() && !isColumnAbsolute)
						{
							if (column >= int_2)
							{
								array[9] = (byte)(column - int_2);
							}
							else
							{
								array[9] = (byte)(255 - int_2 + column + 1);
							}
						}
						else
						{
							array[9] = (byte)column;
						}
						if (!isRowAbsolute)
						{
							array[10] |= 128;
						}
						if (!isColumnAbsolute)
						{
							array[10] |= 64;
						}
					}
				}
				catch (Exception)
				{
					throw new CellsException(ExceptionType.Formula, string_0);
				}
				array[0] = 59;
				return array;
			}
			throw new CellsException(ExceptionType.Formula, "Invalid formula:" + cell_0);
		}
		catch (Exception)
		{
			throw new CellsException(ExceptionType.Formula, string_0);
		}
	}

	private byte[] method_16(Class1661 class1661_0, string string_1, string string_2, int int_3, Enum227 enum227_0)
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
			string_3 = method_14(string_3);
			int[] array4 = Class1660.smethod_3(worksheetCollection_0, string_3);
			int num2 = array4[0];
			if (num2 == -1)
			{
				num2 = worksheetCollection_0.method_32().method_8(num, -1);
			}
			byte[] array5 = new byte[11];
			Array.Copy(BitConverter.GetBytes((ushort)num2), 0, array5, 1, 2);
			string_1 = string_1.Substring(int_3 + 1);
			bool isRowAbsolute = false;
			bool isColumnAbsolute = false;
			bool isRowOnly = false;
			bool isColumnOnly = false;
			try
			{
				CellNameToIndex(string_1, out var row, out var column, isInArea: true, ref isRowAbsolute, ref isColumnAbsolute, ref isRowOnly, ref isColumnOnly);
				if (isRowOnly)
				{
					if (method_2() && !isRowAbsolute)
					{
						if (row >= int_1)
						{
							Array.Copy(BitConverter.GetBytes((ushort)(row - int_1)), 0, array5, 3, 2);
						}
						else
						{
							Array.Copy(BitConverter.GetBytes((ushort)(65535 - int_1 + row + 1)), 0, array5, 3, 2);
						}
					}
					else
					{
						Array.Copy(BitConverter.GetBytes(row), 0, array5, 3, 2);
					}
					array5[9] = byte.MaxValue;
					if (!isRowAbsolute)
					{
						array5[8] |= 128;
					}
				}
				else if (isColumnOnly)
				{
					array5[5] = byte.MaxValue;
					array5[6] = byte.MaxValue;
					if (method_2() && !isColumnAbsolute)
					{
						if (column >= int_2)
						{
							array5[7] = (byte)(column - int_2);
						}
						else
						{
							array5[7] = (byte)(255 - int_2 + column + 1);
						}
					}
					else
					{
						array5[7] = (byte)column;
					}
					if (!isColumnAbsolute)
					{
						array5[8] |= 64;
					}
				}
				else
				{
					if (method_2() && !isRowAbsolute)
					{
						if (row >= int_1)
						{
							Array.Copy(BitConverter.GetBytes((ushort)(row - int_1)), 0, array5, 3, 2);
						}
						else
						{
							Array.Copy(BitConverter.GetBytes((ushort)(65535 - int_1 + row + 1)), 0, array5, 3, 2);
						}
					}
					else
					{
						Array.Copy(BitConverter.GetBytes(row), 0, array5, 3, 2);
					}
					if (method_2() && !isColumnAbsolute)
					{
						if (column >= int_2)
						{
							array5[7] = (byte)(column - int_2);
						}
						else
						{
							array5[7] = (byte)(255 - int_2 + column + 1);
						}
					}
					else
					{
						array5[7] = (byte)column;
					}
					if (!isRowAbsolute)
					{
						array5[8] |= 128;
					}
					if (!isColumnAbsolute)
					{
						array5[8] |= 64;
					}
				}
				bool flag = isRowOnly;
				bool flag2 = isColumnOnly;
				isRowAbsolute = false;
				isColumnAbsolute = false;
				isRowOnly = false;
				isColumnOnly = false;
				CellNameToIndex(string_2, out row, out column, isInArea: true, ref isRowAbsolute, ref isColumnAbsolute, ref isRowOnly, ref isColumnOnly);
				if (flag != isRowOnly || flag2 != isColumnOnly)
				{
					throw new CellsException(ExceptionType.Formula, "Invalid formula.");
				}
				if (isRowOnly)
				{
					if (method_2() && !isRowAbsolute)
					{
						if (row >= int_1)
						{
							Array.Copy(BitConverter.GetBytes((ushort)(row - int_1)), 0, array5, 5, 2);
						}
						else
						{
							Array.Copy(BitConverter.GetBytes((ushort)(65535 - int_1 + row + 1)), 0, array5, 5, 2);
						}
					}
					else
					{
						Array.Copy(BitConverter.GetBytes(row), 0, array5, 5, 2);
					}
					if (!isRowAbsolute)
					{
						array5[10] |= 128;
					}
				}
				else if (isColumnOnly)
				{
					if (method_2() && !isColumnAbsolute)
					{
						if (column >= int_2)
						{
							array5[9] = (byte)(column - int_2);
						}
						else
						{
							array5[9] = (byte)(255 - int_2 + column + 1);
						}
					}
					else
					{
						array5[9] = (byte)column;
					}
					if (!isColumnAbsolute)
					{
						array5[10] |= 64;
					}
				}
				else
				{
					if (method_2() && !isRowAbsolute)
					{
						if (row >= int_1)
						{
							Array.Copy(BitConverter.GetBytes((ushort)(row - int_1)), 0, array5, 5, 2);
						}
						else
						{
							Array.Copy(BitConverter.GetBytes((ushort)(65535 - int_1 + row + 1)), 0, array5, 5, 2);
						}
					}
					else
					{
						Array.Copy(BitConverter.GetBytes(row), 0, array5, 5, 2);
					}
					if (method_2() && !isColumnAbsolute)
					{
						if (column >= int_2)
						{
							array5[9] = (byte)(column - int_2);
						}
						else
						{
							array5[9] = (byte)(255 - int_2 + column + 1);
						}
					}
					else
					{
						array5[9] = (byte)column;
					}
					if (!isRowAbsolute)
					{
						array5[10] |= 128;
					}
					if (!isColumnAbsolute)
					{
						array5[10] |= 64;
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

	private Enum227[] method_17(Class1661 class1661_0, Enum227 enum227_0)
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

	private Enum227[] method_18(Class1661 class1661_0, ushort ushort_0, Enum227 enum227_0, Enum226 enum226_0)
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

	private Enum227[] method_19(Class1661 class1661_0, ushort ushort_0, Enum227 enum227_0, Enum226 enum226_0)
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

	private void method_20(Class1661 class1661_0, string string_1, Enum227 enum227_0)
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
			class3.method_21(string_1, bool_0: false);
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
				class5.method_21(string_1, bool_0: false);
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

	private Enum227[] method_21(Class1661 class1661_0, Enum227 enum227_0, Enum226 enum226_0)
	{
		string text = class1661_0.method_3();
		if (text.StartsWith("_XLFN."))
		{
			text = text.Substring("_XLFN.".Length);
		}
		Class1663 @class = Class1663.smethod_4(text, enum226_0);
		if (@class != null)
		{
			ushort ushort_ = @class.ushort_0;
			if (ushort_ == 480)
			{
				@class = null;
			}
		}
		if (@class == null)
		{
			class1661_0.Type = Enum180.const_5;
			class1661_0.method_10(method_23(class1661_0, class1661_0.string_2, enum227_0));
			return Class1663.enum227_3;
		}
		if (@class.ushort_0 == 255)
		{
			class1661_0.Type = Enum180.const_5;
			method_20(class1661_0, class1661_0.string_2, enum227_0);
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

	private byte[] method_22(Class1661 class1661_0, string string_1, Enum227 enum227_0)
	{
		worksheetCollection_0.method_36();
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
			int[] array2 = worksheetCollection_0.Names.method_10((cell_0 == null) ? (-1) : cell_0.method_4().method_3().Index, string_1, class1661_0.Type == Enum180.const_5, bool_1: true);
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
			return array;
		}
		catch (Exception)
		{
			throw new CellsException(ExceptionType.Formula, string_0);
		}
	}

	private byte[] method_23(Class1661 class1661_0, string string_1, Enum227 enum227_0)
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

	private bool method_24(string string_1)
	{
		if (string_1.Length > 0 && string_1[0] == '[' && string_1[string_1.Length - 1] == ']')
		{
			return true;
		}
		return false;
	}

	private bool method_25(string string_1)
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
			case ':':
				return false;
			case '!':
				return true;
			}
		}
		return true;
	}

	internal static byte[] smethod_0(WorksheetCollection worksheetCollection_1, int int_3, int int_4, int int_5, string string_1, Enum180 enum180_0, Enum227 enum227_0)
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
		row = 0;
		column = 0;
		int num = 0;
		string columnName;
		if (cellName[0] == '$')
		{
			if (char.IsDigit(cellName, 1))
			{
				isRowAbsolute = true;
				isRowOnly = true;
				row = int.Parse(cellName.Substring(1)) - 1;
				return isInArea;
			}
			isColumnAbsolute = true;
			for (int i = 2; i < cellName.Length; i++)
			{
				if (char.IsDigit(cellName, i))
				{
					num = i;
					break;
				}
			}
			if (num == 0)
			{
				if (cellName.Length <= 4 && cellName.Length != 1)
				{
					isColumnOnly = true;
					column = CellsHelper.ColumnNameToIndex(cellName.Substring(1));
					return isInArea;
				}
				return false;
			}
			if (cellName[num - 1] == '$')
			{
				columnName = cellName.Substring(1, num - 2);
				isRowAbsolute = true;
			}
			else
			{
				columnName = cellName.Substring(1, num - 1);
			}
			row = int.Parse(cellName.Substring(num)) - 1;
			column = CellsHelper.ColumnNameToIndex(columnName);
			if (column > 255)
			{
				return false;
			}
			return true;
		}
		if (char.IsDigit(cellName, 0))
		{
			isRowOnly = true;
			row = int.Parse(cellName) - 1;
			return isInArea;
		}
		for (int j = 1; j < cellName.Length; j++)
		{
			if (char.IsDigit(cellName, j))
			{
				num = j;
				break;
			}
		}
		if (num == 0)
		{
			if (cellName.Length <= 3 && cellName.Length != 0)
			{
				isColumnOnly = true;
				column = CellsHelper.ColumnNameToIndex(cellName);
				return isInArea;
			}
			return false;
		}
		if (cellName[num - 1] == '$')
		{
			columnName = cellName.Substring(0, num - 1);
			isRowAbsolute = true;
		}
		else
		{
			columnName = cellName.Substring(0, num);
		}
		if (columnName.Length > 3)
		{
			return false;
		}
		string text = cellName.Substring(num);
		int num2 = 0;
		while (true)
		{
			if (num2 < text.Length)
			{
				if (!char.IsDigit(text, num2))
				{
					break;
				}
				num2++;
				continue;
			}
			row = int.Parse(text) - 1;
			column = CellsHelper.ColumnNameToIndex(columnName);
			if (column > 255)
			{
				return false;
			}
			return true;
		}
		return false;
	}
}
