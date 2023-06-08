using System;
using System.Collections;
using System.Globalization;
using System.Text;
using ns195;

namespace ns211;

internal class Class5662
{
	private interface Interface230
	{
		int[] imethod_0(long number, int one, int letterValue, string features, string language, string country);
	}

	private class Class5663 : Interface230
	{
		private int int_0;

		internal Class5663(int caseType)
		{
			int_0 = caseType;
		}

		public int[] imethod_0(long number, int one, int letterValue, string features, string language, string country)
		{
			ArrayList arrayList = new ArrayList();
			if (number >= 1000000000000L)
			{
				return null;
			}
			bool flag = smethod_4(features, "ordinal");
			if (number == 0L)
			{
				arrayList.Add(string_5[0]);
			}
			else if (flag && number < 10L)
			{
				arrayList.Add(string_9[(int)number]);
			}
			else
			{
				int num = (int)(number % 1000L);
				int num2 = (int)(number / 1000L % 1000L);
				int num3 = (int)(number / 1000000L % 1000L);
				int num4 = (int)(number / 1000000000L % 1000L);
				if (num4 > 0)
				{
					arrayList = smethod_0(arrayList, num4);
					if (flag && number % 1000000000L == 0L)
					{
						arrayList.Add(string_12[3]);
					}
					else
					{
						arrayList.Add(string_8[3]);
					}
				}
				if (num3 > 0)
				{
					arrayList = smethod_0(arrayList, num3);
					if (flag && number % 1000000L == 0L)
					{
						arrayList.Add(string_12[2]);
					}
					else
					{
						arrayList.Add(string_8[2]);
					}
				}
				if (num2 > 0)
				{
					arrayList = smethod_0(arrayList, num2);
					if (flag && number % 1000L == 0L)
					{
						arrayList.Add(string_12[1]);
					}
					else
					{
						arrayList.Add(string_8[1]);
					}
				}
				if (num > 0)
				{
					arrayList = smethod_1(arrayList, num, flag);
				}
			}
			arrayList = smethod_16(arrayList, int_0);
			return Class5593.smethod_0(smethod_18(arrayList, " "), 0, errorOnSubstitution: true);
		}

		private static ArrayList smethod_0(ArrayList wl, int number)
		{
			return smethod_1(wl, number, ordinal: false);
		}

		private static ArrayList smethod_1(ArrayList wl, int number, bool ordinal)
		{
			int num = number % 10;
			int num2 = number / 10 % 10;
			int num3 = number / 100 % 10;
			if (num3 > 0)
			{
				wl.Add(string_5[num3]);
				if (ordinal && number % 100 == 0)
				{
					wl.Add(string_12[0]);
				}
				else
				{
					wl.Add(string_8[0]);
				}
			}
			if (num2 > 0)
			{
				if (num2 == 1)
				{
					if (ordinal)
					{
						wl.Add(string_10[num]);
					}
					else
					{
						wl.Add(string_6[num]);
					}
				}
				else
				{
					if (ordinal && num == 0)
					{
						wl.Add(string_11[num2]);
					}
					else
					{
						wl.Add(string_7[num2]);
					}
					if (num > 0)
					{
						if (ordinal)
						{
							wl.Add(string_9[num]);
						}
						else
						{
							wl.Add(string_5[num]);
						}
					}
				}
			}
			else if (num > 0)
			{
				if (ordinal)
				{
					wl.Add(string_9[num]);
				}
				else
				{
					wl.Add(string_5[num]);
				}
			}
			return wl;
		}
	}

	private class Class5664 : Interface230
	{
		private int int_0;

		internal Class5664(int caseType)
		{
			int_0 = caseType;
		}

		public int[] imethod_0(long number, int one, int letterValue, string features, string language, string country)
		{
			ArrayList arrayList = new ArrayList();
			if (number >= 1000000000000L)
			{
				return null;
			}
			bool flag = smethod_4(features, "ordinal");
			if (number == 0L)
			{
				arrayList.Add(string_13[0]);
			}
			else if (flag && number <= 10L)
			{
				if (smethod_4(features, "female"))
				{
					arrayList.Add(string_18[(int)number]);
				}
				else
				{
					arrayList.Add(string_17[(int)number]);
				}
			}
			else
			{
				int num = (int)(number % 1000L);
				int num2 = (int)(number / 1000L % 1000L);
				int num3 = (int)(number / 1000000L % 1000L);
				int num4 = (int)(number / 1000000000L % 1000L);
				if (num4 > 0)
				{
					arrayList = smethod_0(arrayList, num4);
					if (num4 == 1)
					{
						arrayList.Add(string_16[5]);
					}
					else
					{
						arrayList.Add(string_16[6]);
					}
				}
				if (num3 > 0)
				{
					arrayList = smethod_0(arrayList, num3);
					if (num3 == 1)
					{
						arrayList.Add(string_16[3]);
					}
					else
					{
						arrayList.Add(string_16[4]);
					}
				}
				if (num2 > 0)
				{
					if (num2 > 1)
					{
						arrayList = smethod_0(arrayList, num2);
					}
					arrayList.Add(string_16[2]);
				}
				if (num > 0)
				{
					arrayList = smethod_0(arrayList, num);
				}
			}
			arrayList = smethod_16(arrayList, int_0);
			return Class5593.smethod_0(smethod_18(arrayList, " "), 0, errorOnSubstitution: true);
		}

		private static ArrayList smethod_0(ArrayList wl, int number)
		{
			int num = number % 10;
			int num2 = number / 10 % 10;
			int num3 = number / 100 % 10;
			if (num3 > 0)
			{
				if (num3 > 1)
				{
					wl.Add(string_13[num3]);
				}
				if (num3 > 1 && num2 == 0 && num == 0)
				{
					wl.Add(string_16[1]);
				}
				else
				{
					wl.Add(string_16[0]);
				}
			}
			if (num2 > 0)
			{
				if (num2 == 1)
				{
					wl.Add(string_14[num]);
				}
				else if (num2 < 7)
				{
					if (num == 1)
					{
						wl.Add(string_15[num2]);
						wl.Add("et");
						wl.Add(string_13[num]);
					}
					else
					{
						StringBuilder stringBuilder = new StringBuilder();
						stringBuilder.Append(string_15[num2]);
						if (num > 0)
						{
							stringBuilder.Append('-');
							stringBuilder.Append(string_13[num]);
						}
						wl.Add(stringBuilder.ToString());
					}
				}
				else
				{
					switch (num2)
					{
					case 7:
						if (num == 1)
						{
							wl.Add(string_15[6]);
							wl.Add("et");
							wl.Add(string_14[num]);
						}
						else
						{
							StringBuilder stringBuilder4 = new StringBuilder();
							stringBuilder4.Append(string_15[6]);
							stringBuilder4.Append('-');
							stringBuilder4.Append(string_14[num]);
							wl.Add(stringBuilder4.ToString());
						}
						break;
					case 8:
					{
						StringBuilder stringBuilder3 = new StringBuilder();
						stringBuilder3.Append(string_15[num2]);
						if (num > 0)
						{
							stringBuilder3.Append('-');
							stringBuilder3.Append(string_13[num]);
						}
						else
						{
							stringBuilder3.Append('s');
						}
						wl.Add(stringBuilder3.ToString());
						break;
					}
					case 9:
					{
						StringBuilder stringBuilder2 = new StringBuilder();
						stringBuilder2.Append(string_15[8]);
						stringBuilder2.Append('-');
						stringBuilder2.Append(string_14[num]);
						wl.Add(stringBuilder2.ToString());
						break;
					}
					}
				}
			}
			else if (num > 0)
			{
				wl.Add(string_13[num]);
			}
			return wl;
		}
	}

	private class Class5665 : Interface230
	{
		private int int_0;

		internal Class5665(int caseType)
		{
			int_0 = caseType;
		}

		public int[] imethod_0(long number, int one, int letterValue, string features, string language, string country)
		{
			ArrayList arrayList = new ArrayList();
			if (number >= 1000000000000L)
			{
				return null;
			}
			bool flag = smethod_4(features, "ordinal");
			if (number == 0L)
			{
				arrayList.Add(string_19[0]);
			}
			else if (flag && number <= 10L)
			{
				if (smethod_4(features, "female"))
				{
					arrayList.Add(string_26[(int)number]);
				}
				else
				{
					arrayList.Add(string_25[(int)number]);
				}
			}
			else
			{
				int num = (int)(number % 1000L);
				int num2 = (int)(number / 1000L % 1000L);
				int num3 = (int)(number / 1000000L % 1000L);
				int num4 = (int)(number / 1000000000L % 1000L);
				if (num4 > 0)
				{
					if (num4 > 1)
					{
						arrayList = smethod_0(arrayList, num4);
					}
					arrayList.Add(string_24[2]);
					arrayList.Add(string_24[4]);
				}
				if (num3 > 0)
				{
					if (num3 == 1)
					{
						arrayList.Add(string_24[0]);
					}
					else
					{
						arrayList = smethod_0(arrayList, num3);
					}
					if (num3 > 1)
					{
						arrayList.Add(string_24[4]);
					}
					else
					{
						arrayList.Add(string_24[3]);
					}
				}
				if (num2 > 0)
				{
					if (num2 > 1)
					{
						arrayList = smethod_0(arrayList, num2);
					}
					arrayList.Add(string_24[2]);
				}
				if (num > 0)
				{
					arrayList = smethod_0(arrayList, num);
				}
			}
			arrayList = smethod_16(arrayList, int_0);
			return Class5593.smethod_0(smethod_18(arrayList, " "), 0, errorOnSubstitution: true);
		}

		private static ArrayList smethod_0(ArrayList wl, int number)
		{
			int num = number % 10;
			int num2 = number / 10 % 10;
			int num3 = number / 100 % 10;
			if (num3 > 0)
			{
				if (num3 == 1 && num2 == 0 && num == 0)
				{
					wl.Add(string_24[1]);
				}
				else
				{
					wl.Add(string_23[num3]);
				}
			}
			if (num2 > 0)
			{
				switch (num2)
				{
				case 1:
					wl.Add(string_20[num]);
					break;
				case 2:
					wl.Add(string_21[num]);
					break;
				default:
					wl.Add(string_22[num2]);
					if (num > 0)
					{
						wl.Add("y");
						wl.Add(string_19[num]);
					}
					break;
				}
			}
			else if (num > 0)
			{
				wl.Add(string_19[num]);
			}
			return wl;
		}
	}

	private class Class5666 : Interface230
	{
		public int[] imethod_0(long number, int one, int letterValue, string features, string language, string country)
		{
			ArrayList arrayList = new ArrayList();
			if (number == 0L)
			{
				return null;
			}
			string[] array;
			int num;
			if (smethod_4(features, "unicode-number-forms"))
			{
				array = string_29;
				num = 199999;
			}
			else if (smethod_4(features, "large"))
			{
				array = string_28;
				num = 199999;
			}
			else
			{
				array = string_27;
				num = 4999;
			}
			if (number > num)
			{
				return null;
			}
			while (number > 0L)
			{
				int i = 0;
				for (int num2 = int_16.Length; i < num2; i++)
				{
					int num3 = int_16[i];
					if (number >= num3 && array[i] != null)
					{
						smethod_5(arrayList, new ArrayList(Class5593.smethod_0(array[i], 0, errorOnSubstitution: true)));
						number -= num3;
						break;
					}
				}
			}
			return one switch
			{
				73 => smethod_14((int[])arrayList.ToArray(typeof(int))), 
				105 => smethod_15((int[])arrayList.ToArray(typeof(int))), 
				_ => null, 
			};
		}
	}

	private class Class5667 : Interface230
	{
		public int[] imethod_0(long number, int one, int letterValue, string features, string language, string country)
		{
			return null;
		}
	}

	private class Class5668 : Interface230
	{
		public int[] imethod_0(long number, int one, int letterValue, string features, string language, string country)
		{
			if (one == 1488)
			{
				if (letterValue == int_0)
				{
					return smethod_2(number, one, int_17.Length, int_17);
				}
				if (letterValue == int_1)
				{
					if (number != 0L && number <= 1999L)
					{
						return smethod_0(number, features, country);
					}
					return null;
				}
				return null;
			}
			return null;
		}

		private static int[] smethod_0(long number, string features, string country)
		{
			ArrayList arrayList = new ArrayList();
			int[] int_ = int_17;
			int num = (int)(number / 1000L % 10L);
			int num2 = (int)(number / 100L % 10L);
			int num3 = (int)(number / 10L % 10L);
			int num4 = (int)(number / 1L % 10L);
			if (num > 0)
			{
				arrayList.Add(int_[num - 1]);
				arrayList.Add(1523);
			}
			switch (num2)
			{
			case 1:
			case 2:
			case 3:
			case 4:
				arrayList.Add(int_[18 + (num2 - 1)]);
				break;
			case 5:
			case 6:
			case 7:
			case 8:
				arrayList.Add(int_[21]);
				arrayList.Add(1524);
				arrayList.Add(int_[18 + (num2 - 5)]);
				break;
			case 9:
				arrayList.Add(int_[21]);
				arrayList.Add(int_[21]);
				arrayList.Add(1524);
				arrayList.Add(int_[18 + (num2 - 9)]);
				break;
			}
			switch (number)
			{
			case 15L:
				arrayList.Add(int_[8]);
				arrayList.Add(1524);
				arrayList.Add(int_[5]);
				break;
			case 16L:
				arrayList.Add(int_[8]);
				arrayList.Add(1524);
				arrayList.Add(int_[6]);
				break;
			default:
				if (num3 > 0)
				{
					arrayList.Add(int_[9 + (num3 - 1)]);
				}
				if (num4 > 0)
				{
					arrayList.Add(int_[num4 - 1]);
				}
				break;
			}
			return (int[])arrayList.ToArray(typeof(int));
		}
	}

	private class Class5669 : Interface230
	{
		public int[] imethod_0(long number, int one, int letterValue, string features, string language, string country)
		{
			switch (one)
			{
			case 1575:
			{
				int[] array = ((letterValue == int_1) ? int_18 : ((letterValue != int_0) ? int_18 : int_19));
				return smethod_2(number, one, array.Length, array);
			}
			case 1571:
				if (number != 0L && number <= 1999L)
				{
					return smethod_0(number, features, country);
				}
				return null;
			default:
				return null;
			}
		}

		private static int[] smethod_0(long number, string features, string country)
		{
			ArrayList arrayList = new ArrayList();
			int[] int_ = int_18;
			int num = (int)(number / 1000L % 10L);
			int num2 = (int)(number / 100L % 10L);
			int num3 = (int)(number / 10L % 10L);
			int num4 = (int)(number / 1L % 10L);
			if (num > 0)
			{
				arrayList.Add(int_[27 + (num - 1)]);
			}
			if (num2 > 0)
			{
				arrayList.Add(int_[18 + (num2 - 1)]);
			}
			if (num3 > 0)
			{
				arrayList.Add(int_[9 + (num3 - 1)]);
			}
			if (num4 > 0)
			{
				arrayList.Add(int_[num4 - 1]);
			}
			return (int[])arrayList.ToArray(typeof(int));
		}
	}

	private class Class5670 : Interface230
	{
		public int[] imethod_0(long number, int one, int letterValue, string features, string language, string country)
		{
			if (one == 12354 && letterValue == int_0)
			{
				return smethod_2(number, one, int_20.Length, int_20);
			}
			if (one == 12450 && letterValue == int_0)
			{
				return smethod_2(number, one, int_21.Length, int_21);
			}
			return null;
		}
	}

	private class Class5671 : Interface230
	{
		public int[] imethod_0(long number, int one, int letterValue, string features, string language, string country)
		{
			if (one == 3585 && letterValue == int_0)
			{
				return smethod_2(number, one, int_22.Length, int_22);
			}
			return null;
		}
	}

	public static int int_0 = 1;

	public static int int_1 = 2;

	private static int int_2 = 0;

	private static int int_3 = 1;

	private static int int_4 = 2;

	private static int[] int_5 = new int[1] { 49 };

	private static int[] int_6 = new int[1] { 46 };

	private static string string_0 = "eng";

	private int[] int_7;

	private int[] int_8;

	private int[][] int_9;

	private int[][] int_10;

	private int int_11;

	private int int_12;

	private int int_13;

	private string string_1;

	private string string_2;

	private string string_3;

	private static string[][] string_4 = new string[3][]
	{
		new string[2] { "eng", "en" },
		new string[3] { "fra", "fre", "fr" },
		new string[2] { "spa", "es" }
	};

	private static int[][] int_14 = new int[2][]
	{
		new int[2] { 65, 26 },
		new int[2] { 97, 26 }
	};

	private static int[][] int_15 = new int[12][]
	{
		new int[1] { 73 },
		new int[1] { 105 },
		new int[1] { 913 },
		new int[1] { 945 },
		new int[1] { 1488 },
		new int[1] { 1571 },
		new int[1] { 1575 },
		new int[1] { 3585 },
		new int[1] { 12354 },
		new int[1] { 12356 },
		new int[1] { 12450 },
		new int[1] { 12452 }
	};

	private static string[] string_5 = new string[10] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

	private static string[] string_6 = new string[10] { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };

	private static string[] string_7 = new string[10]
	{
		string.Empty,
		"ten",
		"twenty",
		"thirty",
		"forty",
		"fifty",
		"sixty",
		"seventy",
		"eighty",
		"ninety"
	};

	private static string[] string_8 = new string[4] { "hundred", "thousand", "million", "billion" };

	private static string[] string_9 = new string[10] { "none", "first", "second", "third", "fourth", "fifth", "sixth", "seventh", "eighth", "ninth" };

	private static string[] string_10 = new string[10] { "tenth", "eleventh", "twelfth", "thirteenth", "fourteenth", "fifteenth", "sixteenth", "seventeenth", "eighteenth", "nineteenth" };

	private static string[] string_11 = new string[10]
	{
		string.Empty,
		"tenth",
		"twentieth",
		"thirtieth",
		"fortieth",
		"fiftieth",
		"sixtieth",
		"seventieth",
		"eightieth",
		"ninetith"
	};

	private static string[] string_12 = new string[4] { "hundredth", "thousandth", "millionth", "billionth" };

	private static string[] string_13 = new string[10] { "zéro", "un", "deux", "trois", "quatre", "cinq", "six", "sept", "huit", "neuf" };

	private static string[] string_14 = new string[10] { "dix", "onze", "douze", "treize", "quatorze", "quinze", "seize", "dix-sept", "dix-huit", "dix-neuf" };

	private static string[] string_15 = new string[10]
	{
		string.Empty,
		"dix",
		"vingt",
		"trente",
		"quarante",
		"cinquante",
		"soixante",
		"soixante-dix",
		"quatre-vingt",
		"quatre-vingt-dix"
	};

	private static string[] string_16 = new string[7] { "cent", "cents", "mille", "million", "millions", "milliard", "milliards" };

	private static string[] string_17 = new string[10] { "premier", "deuxième", "troisième", "quatrième", "cinquième", "sixième", "septième", "huitième", "neuvième", "dixième" };

	private static string[] string_18 = new string[10] { "première", "deuxième", "troisième", "quatrième", "cinquième", "sixième", "septième", "huitième", "neuvième", "dixième" };

	private static string[] string_19 = new string[10] { "cero", "uno", "dos", "tres", "cuatro", "cinco", "seise", "siete", "ocho", "nueve" };

	private static string[] string_20 = new string[10] { "diez", "once", "doce", "trece", "catorce", "quince", "dieciséis", "diecisiete", "dieciocho", "diecinueve" };

	private static string[] string_21 = new string[10] { "veinte", "veintiuno", "veintidós", "veintitrés", "veinticuatro", "veinticinco", "veintiséis", "veintisiete", "veintiocho", "veintinueve" };

	private static string[] string_22 = new string[10]
	{
		string.Empty,
		"diez",
		"veinte",
		"treinta",
		"cuarenta",
		"cincuenta",
		"sesenta",
		"setenta",
		"ochenta",
		"noventa"
	};

	private static string[] string_23 = new string[10]
	{
		string.Empty,
		"ciento",
		"doscientos",
		"trescientos",
		"cuatrocientos",
		"quinientos",
		"seiscientos",
		"setecientos",
		"ochocientos",
		"novecientos"
	};

	private static string[] string_24 = new string[5] { "un", "cien", "mil", "millón", "millones" };

	private static string[] string_25 = new string[11]
	{
		"ninguno", "primero", "segundo", "tercero", "cuarto", "quinto", "sexto", "séptimo", "octavo", "novento",
		"décimo"
	};

	private static string[] string_26 = new string[11]
	{
		"ninguna", "primera", "segunda", "tercera", "cuarta", "quinta", "sexta", "séptima", "octava", "noventa",
		"décima"
	};

	private static int[] int_16 = new int[26]
	{
		100000, 90000, 50000, 40000, 10000, 9000, 5000, 4000, 1000, 900,
		500, 400, 100, 90, 50, 40, 10, 9, 8, 7,
		6, 5, 4, 3, 2, 1
	};

	private static string[] string_27 = new string[26]
	{
		null, null, null, null, null, null, null, null, "m", "cm",
		"d", "cd", "c", "xc", "l", "xl", "x", "ix", null, null,
		null, "v", "iv", null, null, "i"
	};

	private static string[] string_28 = new string[26]
	{
		"ↈ", "ↂↈ", "ↇ", "ↂↇ", "ↂ", "ↀↂ", "ↁ", "ↀↁ", "m", "cm",
		"d", "cd", "c", "xc", "l", "xl", "x", "ix", null, null,
		null, "v", "iv", null, null, "i"
	};

	private static string[] string_29 = new string[26]
	{
		"ↈ", "ↂↈ", "ↇ", "ↂↇ", "ↂ", "ↀↂ", "ↁ", "ↀↁ", "Ⅿ", "ⅭⅯ",
		"Ⅾ", "ⅭⅮ", "Ⅽ", "ⅩⅭ", "Ⅼ", "ⅩⅬ", "Ⅹ", "Ⅸ", "Ⅷ", "Ⅶ",
		"Ⅵ", "Ⅴ", "Ⅳ", "Ⅲ", "Ⅱ", "Ⅰ"
	};

	private static int[] int_17 = new int[27]
	{
		1488, 1489, 1490, 1491, 1492, 1493, 1494, 1495, 1496, 1497,
		1499, 1500, 1502, 1504, 1505, 1506, 1508, 1510, 1511, 1512,
		1513, 1514, 1498, 1501, 1503, 1507, 1509
	};

	private static int[] int_18 = new int[28]
	{
		1571, 1576, 1580, 1583, 1607, 1608, 1586, 1581, 1591, 1609,
		1603, 1604, 1605, 1606, 1587, 1593, 1601, 1589, 1602, 1585,
		1588, 1578, 1579, 1582, 1584, 1590, 1592, 1594
	};

	private static int[] int_19 = new int[28]
	{
		1571, 1576, 1578, 1579, 1580, 1581, 1582, 1583, 1584, 1585,
		1586, 1587, 1588, 1589, 1590, 1591, 1592, 1593, 1594, 1601,
		1602, 1603, 1604, 1605, 1606, 1607, 1608, 1609
	};

	private static int[] int_20 = new int[48]
	{
		12354, 12356, 12358, 12360, 12362, 12363, 12365, 12367, 12369, 12371,
		12373, 12375, 12377, 12379, 12381, 12383, 12385, 12388, 12390, 12392,
		12394, 12395, 12396, 12397, 12398, 12399, 12402, 12405, 12408, 12411,
		12414, 12415, 12416, 12417, 12418, 12420, 12422, 12424, 12425, 12426,
		12427, 12428, 12429, 12431, 12432, 12433, 12434, 12435
	};

	private static int[] int_21 = new int[48]
	{
		12450, 12452, 12454, 12456, 12458, 12459, 12461, 12463, 12465, 12467,
		12469, 12471, 12473, 12475, 12477, 12479, 12481, 12484, 12486, 12488,
		12490, 12491, 12492, 12493, 12494, 12495, 12498, 12501, 12504, 12507,
		12510, 12511, 12512, 12513, 12514, 12516, 12518, 12520, 12521, 12522,
		12523, 12524, 12525, 12527, 12528, 12529, 12530, 12531
	};

	private static int[] int_22 = new int[44]
	{
		3585, 3586, 3587, 3588, 3589, 3590, 3591, 3592, 3593, 3594,
		3595, 3596, 3597, 3598, 3599, 3600, 3601, 3602, 3603, 3604,
		3605, 3606, 3607, 3608, 3609, 3610, 3611, 3612, 3613, 3614,
		3615, 3616, 3617, 3618, 3619, 3621, 3623, 3624, 3625, 3626,
		3627, 3628, 3629, 3630
	};

	public Class5662(string format, int groupingSeparator, int groupingSize, int letterValue, string features, string language, string country)
	{
		int_11 = groupingSeparator;
		int_12 = groupingSize;
		int_13 = letterValue;
		string_1 = features;
		string_2 = language?.ToLower();
		string_3 = country?.ToLower();
		method_2(format);
	}

	public string method_0(long number)
	{
		ArrayList arrayList = new ArrayList();
		arrayList.Add(number);
		return method_1(arrayList);
	}

	public string method_1(ArrayList numbers)
	{
		ArrayList scalars = new ArrayList();
		if (int_7 != null)
		{
			smethod_5(scalars, new ArrayList(int_7));
		}
		method_3(scalars, numbers);
		if (int_8 != null)
		{
			smethod_5(scalars, new ArrayList(int_8));
		}
		return smethod_6(scalars);
	}

	private void method_2(string format)
	{
		ArrayList arrayList = new ArrayList();
		ArrayList arrayList2 = new ArrayList();
		if (format == null || format.Length == 0)
		{
			format = "1";
		}
		int num = int_2;
		ArrayList arrayList3 = new ArrayList();
		int[] array = Class5593.smethod_0(format, 0, errorOnSubstitution: true);
		int i = 0;
		for (int num2 = array.Length; i < num2; i++)
		{
			int num3 = array[i];
			int num4 = (smethod_0(num3) ? int_3 : int_4);
			if (num4 != num)
			{
				if (arrayList3.Count > 0)
				{
					if (num == int_3)
					{
						arrayList.Add(arrayList3.ToArray(typeof(int)));
					}
					else
					{
						arrayList2.Add(arrayList3.ToArray(typeof(int)));
					}
					arrayList3.Clear();
				}
				num = num4;
			}
			arrayList3.Add(num3);
		}
		if (arrayList3.Count > 0)
		{
			if (num == int_3)
			{
				arrayList.Add(arrayList3.ToArray(typeof(int)));
			}
			else
			{
				arrayList2.Add(arrayList3.ToArray(typeof(int)));
			}
		}
		if (arrayList2.Count != 0)
		{
			int_7 = (int[])arrayList2[0];
			arrayList2.Remove(0);
		}
		if (arrayList2.Count != 0)
		{
			int_8 = (int[])arrayList2[arrayList2.Count - 1];
			arrayList2.Remove(arrayList2.Count - 1);
		}
		int_10 = (int[][])arrayList2.ToArray(typeof(int[]));
		int_9 = (int[][])arrayList.ToArray(typeof(int[]));
	}

	private static bool smethod_0(int c)
	{
		switch (char.GetUnicodeCategory((char)c))
		{
		default:
			return false;
		case UnicodeCategory.UppercaseLetter:
		case UnicodeCategory.LowercaseLetter:
		case UnicodeCategory.TitlecaseLetter:
		case UnicodeCategory.ModifierLetter:
		case UnicodeCategory.OtherLetter:
		case UnicodeCategory.DecimalDigitNumber:
		case UnicodeCategory.LetterNumber:
		case UnicodeCategory.OtherNumber:
			return true;
		}
	}

	private void method_3(ArrayList scalars, ArrayList numbers)
	{
		int[] array = int_5;
		int num = 0;
		int num2 = int_9.Length;
		int num3 = 0;
		int num4 = int_10.Length;
		int num5 = 0;
		foreach (long number in numbers)
		{
			int[] separator = null;
			int[] array2;
			if (num < num2)
			{
				if (num5 > 0)
				{
					separator = ((num3 >= num4) ? int_6 : int_10[num3++]);
				}
				array2 = int_9[num++];
			}
			else
			{
				array2 = array;
			}
			smethod_5(scalars, new ArrayList(method_4(number, separator, array2)));
			array = array2;
			num5++;
		}
	}

	private int[] method_4(long number, int[] separator, int[] token)
	{
		ArrayList arrayList = new ArrayList();
		if (separator != null)
		{
			smethod_5(arrayList, new ArrayList(separator));
		}
		if (token != null)
		{
			smethod_5(arrayList, new ArrayList(method_5(number, token)));
		}
		return (int[])arrayList.ToArray(typeof(int));
	}

	private int[] method_5(long number, int[] token)
	{
		int[] array = null;
		if (number < 0L)
		{
			throw new ArgumentException("number must be non-negative");
		}
		if (token.Length == 1)
		{
			int num = token[0];
			switch (num)
			{
			case 49:
				array = method_6(number, 49, 1);
				break;
			case 87:
			case 119:
				array = method_8(number, (num != 87) ? 1 : 0);
				break;
			default:
				array = ((!smethod_9(num)) ? ((!smethod_10(num)) ? ((!smethod_12(num)) ? null : method_7(number, num)) : smethod_2(number, num, smethod_11(num), null)) : method_6(number, num, 1));
				break;
			}
		}
		else if (token.Length == 2 && token[0] == 87 && token[1] == 119)
		{
			array = method_8(number, 2);
		}
		else
		{
			if (!smethod_7(token))
			{
				throw new ArgumentException("invalid format token: \"" + Class5593.smethod_1(token) + "\"");
			}
			int one = token[token.Length - 1];
			array = method_6(number, one, token.Length);
		}
		if (array == null)
		{
			array = method_5(number, int_5);
		}
		return array;
	}

	private int[] method_6(long number, int one, int width)
	{
		ArrayList arrayList = new ArrayList();
		int num = one - 1;
		while (number > 0L)
		{
			long num2 = number % 10L;
			arrayList.Insert(0, num + (int)num2);
			number /= 10L;
		}
		while (width > arrayList.Count)
		{
			arrayList.Insert(0, num);
		}
		if (int_12 != 0 && int_11 != 0)
		{
			arrayList = smethod_1(arrayList, int_12, int_11);
		}
		return (int[])arrayList.ToArray(typeof(int));
	}

	private static ArrayList smethod_1(ArrayList sl, int groupingSize, int groupingSeparator)
	{
		if (sl.Count > groupingSize)
		{
			ArrayList arrayList = new ArrayList();
			int i = 0;
			int count = sl.Count;
			int num = 0;
			for (; i < count; i++)
			{
				int index = count - i - 1;
				if (num == groupingSize)
				{
					arrayList.Insert(0, groupingSeparator);
					num = 1;
				}
				else
				{
					num++;
				}
				arrayList.Insert(0, sl[index]);
			}
			return arrayList;
		}
		return sl;
	}

	private static int[] smethod_2(long number, int one, int @base, int[] map)
	{
		ArrayList arrayList = new ArrayList();
		if (number == 0L)
		{
			return null;
		}
		for (long num = number; num > 0L; num = (num - 1L) / @base)
		{
			int num2 = (int)((num - 1L) % @base);
			int num3 = ((map != null) ? map[num2] : (one + num2));
			arrayList.Insert(0, num3);
		}
		return (int[])arrayList.ToArray(typeof(int));
	}

	private int[] method_7(long number, int one)
	{
		return smethod_13(one, int_13, string_1, string_3)?.imethod_0(number, one, int_13, string_1, string_2, string_3);
	}

	private int[] method_8(long number, int caseType)
	{
		Interface230 @interface = null;
		@interface = (method_9("eng") ? new Class5663(caseType) : (method_9("spa") ? new Class5665(caseType) : ((!method_9("fra")) ? ((Interface230)new Class5663(caseType)) : ((Interface230)new Class5664(caseType)))));
		return @interface.imethod_0(number, 0, int_13, string_1, string_2, string_3);
	}

	private bool method_9(string iso3Code)
	{
		if (string_2 == null)
		{
			return false;
		}
		if (string_2.Equals(iso3Code))
		{
			return true;
		}
		return smethod_3(iso3Code, string_2);
	}

	private static bool smethod_3(string i3c, string lc)
	{
		string[][] array = string_4;
		int num = 0;
		string[] array2;
		while (true)
		{
			if (num < array.Length)
			{
				array2 = array[num];
				if (array2[0].Equals(i3c))
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		int num2 = 0;
		int num3 = array2.Length;
		while (true)
		{
			if (num2 < num3)
			{
				if (array2[num2].Equals(lc))
				{
					break;
				}
				num2++;
				continue;
			}
			return false;
		}
		return true;
	}

	private static bool smethod_4(string features, string feature)
	{
		if (features != null)
		{
			string[] array = features.Split(',');
			string[] array2 = array;
			foreach (string text in array2)
			{
				string[] array3 = text.Split('=');
				string text2 = array3[0];
				if (text2.Equals(feature))
				{
					return true;
				}
			}
		}
		return false;
	}

	private static void smethod_5(ArrayList scalars, ArrayList sa)
	{
		foreach (int item in sa)
		{
			scalars.Add(item);
		}
	}

	private static string smethod_6(ArrayList scalars)
	{
		int[] sa = (int[])scalars.ToArray(typeof(int));
		return Class5593.smethod_1(sa);
	}

	private static bool smethod_7(int[] token)
	{
		if (smethod_8(token[token.Length - 1]) != 1)
		{
			return false;
		}
		int num = 0;
		int num2 = token.Length - 1;
		while (true)
		{
			if (num < num2)
			{
				if (smethod_8(token[num]) != 0)
				{
					break;
				}
				num++;
				continue;
			}
			return true;
		}
		return false;
	}

	private static int smethod_8(int scalar)
	{
		char c = (char)scalar;
		if (char.GetUnicodeCategory(c) == UnicodeCategory.DecimalDigitNumber)
		{
			return (int)char.GetNumericValue(c);
		}
		return -1;
	}

	private static bool smethod_9(int s)
	{
		if (char.GetNumericValue((char)s) == 1.0 && char.GetNumericValue((char)(s - 1)) == 0.0)
		{
			return char.GetNumericValue((char)(s + 8)) == 9.0;
		}
		return false;
	}

	private static bool smethod_10(int s)
	{
		int[][] array = int_14;
		int num = 0;
		while (true)
		{
			if (num < array.Length)
			{
				int[] array2 = array[num];
				if (array2[0] == s)
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	private static int smethod_11(int s)
	{
		int[][] array = int_14;
		int num = 0;
		int[] array2;
		while (true)
		{
			if (num < array.Length)
			{
				array2 = array[num];
				if (array2[0] == s)
				{
					break;
				}
				num++;
				continue;
			}
			return 0;
		}
		return array2[1];
	}

	private static bool smethod_12(int s)
	{
		int[][] array = int_15;
		int num = 0;
		while (true)
		{
			if (num < array.Length)
			{
				int[] array2 = array[num];
				if (array2[0] == s)
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	private static Interface230 smethod_13(int one, int letterValue, string features, string country)
	{
		return one switch
		{
			73 => new Class5666(), 
			105 => new Class5666(), 
			913 => new Class5667(), 
			945 => new Class5667(), 
			1488 => new Class5668(), 
			1571 => new Class5669(), 
			1575 => new Class5669(), 
			3585 => new Class5671(), 
			12354 => new Class5670(), 
			12356 => new Class5670(), 
			12450 => new Class5670(), 
			12452 => new Class5670(), 
			_ => null, 
		};
	}

	private static int[] smethod_14(int[] sa)
	{
		int i = 0;
		for (int num = sa.Length; i < num; i++)
		{
			int num2 = sa[i];
			sa[i] = char.ToUpper((char)num2);
		}
		return sa;
	}

	private static int[] smethod_15(int[] sa)
	{
		int i = 0;
		for (int num = sa.Length; i < num; i++)
		{
			int num2 = sa[i];
			sa[i] = char.ToLower((char)num2);
		}
		return sa;
	}

	private static ArrayList smethod_16(ArrayList words, int caseType)
	{
		ArrayList arrayList = new ArrayList();
		foreach (string word in words)
		{
			arrayList.Add(smethod_17(word, (UnicodeCategory)caseType));
		}
		return arrayList;
	}

	private static string smethod_17(string word, UnicodeCategory caseType)
	{
		switch (caseType)
		{
		case UnicodeCategory.UppercaseLetter:
			return word.ToUpper();
		case UnicodeCategory.LowercaseLetter:
			return word.ToLower();
		case UnicodeCategory.TitlecaseLetter:
		{
			StringBuilder stringBuilder = new StringBuilder();
			int i = 0;
			for (int length = word.Length; i < length; i++)
			{
				string text = Class5479.smethod_0(word, i, i + 1);
				if (i == 0)
				{
					stringBuilder.Append(text.ToUpper());
				}
				else
				{
					stringBuilder.Append(text.ToLower());
				}
			}
			return stringBuilder.ToString();
		}
		default:
			return word;
		}
	}

	private static string smethod_18(ArrayList words, string separator)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (string word in words)
		{
			if (stringBuilder.Length > 0)
			{
				stringBuilder.Append(separator);
			}
			stringBuilder.Append(word);
		}
		return stringBuilder.ToString();
	}
}
