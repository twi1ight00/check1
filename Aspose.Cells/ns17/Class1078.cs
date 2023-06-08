using System;
using System.Collections;
using System.Text;
using ns16;

namespace ns17;

internal class Class1078
{
	private static char[][] char_0 = new char[76][]
	{
		new char[2] { 'ء', 'ﺀ' },
		new char[3] { 'آ', 'ﺁ', 'ﺂ' },
		new char[3] { 'أ', 'ﺃ', 'ﺄ' },
		new char[3] { 'ؤ', 'ﺅ', 'ﺆ' },
		new char[3] { 'إ', 'ﺇ', 'ﺈ' },
		new char[5] { 'ئ', 'ﺉ', 'ﺊ', 'ﺋ', 'ﺌ' },
		new char[3] { 'ا', 'ﺍ', 'ﺎ' },
		new char[5] { 'ب', 'ﺏ', 'ﺐ', 'ﺑ', 'ﺒ' },
		new char[3] { 'ة', 'ﺓ', 'ﺔ' },
		new char[5] { 'ت', 'ﺕ', 'ﺖ', 'ﺗ', 'ﺘ' },
		new char[5] { 'ث', 'ﺙ', 'ﺚ', 'ﺛ', 'ﺜ' },
		new char[5] { 'ج', 'ﺝ', 'ﺞ', 'ﺟ', 'ﺠ' },
		new char[5] { 'ح', 'ﺡ', 'ﺢ', 'ﺣ', 'ﺤ' },
		new char[5] { 'خ', 'ﺥ', 'ﺦ', 'ﺧ', 'ﺨ' },
		new char[3] { 'د', 'ﺩ', 'ﺪ' },
		new char[3] { 'ذ', 'ﺫ', 'ﺬ' },
		new char[3] { 'ر', 'ﺭ', 'ﺮ' },
		new char[3] { 'ز', 'ﺯ', 'ﺰ' },
		new char[5] { 'س', 'ﺱ', 'ﺲ', 'ﺳ', 'ﺴ' },
		new char[5] { 'ش', 'ﺵ', 'ﺶ', 'ﺷ', 'ﺸ' },
		new char[5] { 'ص', 'ﺹ', 'ﺺ', 'ﺻ', 'ﺼ' },
		new char[5] { 'ض', 'ﺽ', 'ﺾ', 'ﺿ', 'ﻀ' },
		new char[5] { 'ط', 'ﻁ', 'ﻂ', 'ﻃ', 'ﻄ' },
		new char[5] { 'ظ', 'ﻅ', 'ﻆ', 'ﻇ', 'ﻈ' },
		new char[5] { 'ع', 'ﻉ', 'ﻊ', 'ﻋ', 'ﻌ' },
		new char[5] { 'غ', 'ﻍ', 'ﻎ', 'ﻏ', 'ﻐ' },
		new char[5] { 'ـ', 'ـ', 'ـ', 'ـ', 'ـ' },
		new char[5] { 'ف', 'ﻑ', 'ﻒ', 'ﻓ', 'ﻔ' },
		new char[5] { 'ق', 'ﻕ', 'ﻖ', 'ﻗ', 'ﻘ' },
		new char[5] { 'ك', 'ﻙ', 'ﻚ', 'ﻛ', 'ﻜ' },
		new char[5] { 'ل', 'ﻝ', 'ﻞ', 'ﻟ', 'ﻠ' },
		new char[5] { 'م', 'ﻡ', 'ﻢ', 'ﻣ', 'ﻤ' },
		new char[5] { 'ن', 'ﻥ', 'ﻦ', 'ﻧ', 'ﻨ' },
		new char[5] { 'ه', 'ﻩ', 'ﻪ', 'ﻫ', 'ﻬ' },
		new char[3] { 'و', 'ﻭ', 'ﻮ' },
		new char[5] { 'ى', 'ﻯ', 'ﻰ', 'ﯨ', 'ﯩ' },
		new char[5] { 'ي', 'ﻱ', 'ﻲ', 'ﻳ', 'ﻴ' },
		new char[3] { 'ٱ', 'ﭐ', 'ﭑ' },
		new char[5] { 'ٹ', 'ﭦ', 'ﭧ', 'ﭨ', 'ﭩ' },
		new char[5] { 'ٺ', 'ﭞ', 'ﭟ', 'ﭠ', 'ﭡ' },
		new char[5] { 'ٻ', 'ﭒ', 'ﭓ', 'ﭔ', 'ﭕ' },
		new char[5] { 'پ', 'ﭖ', 'ﭗ', 'ﭘ', 'ﭙ' },
		new char[5] { 'ٿ', 'ﭢ', 'ﭣ', 'ﭤ', 'ﭥ' },
		new char[5] { 'ڀ', 'ﭚ', 'ﭛ', 'ﭜ', 'ﭝ' },
		new char[5] { 'ڃ', 'ﭶ', 'ﭷ', 'ﭸ', 'ﭹ' },
		new char[5] { 'ڄ', 'ﭲ', 'ﭳ', 'ﭴ', 'ﭵ' },
		new char[5] { 'چ', 'ﭺ', 'ﭻ', 'ﭼ', 'ﭽ' },
		new char[5] { 'ڇ', 'ﭾ', 'ﭿ', 'ﮀ', 'ﮁ' },
		new char[3] { 'ڈ', 'ﮈ', 'ﮉ' },
		new char[3] { 'ڌ', 'ﮄ', 'ﮅ' },
		new char[3] { 'ڍ', 'ﮂ', 'ﮃ' },
		new char[3] { 'ڎ', 'ﮆ', 'ﮇ' },
		new char[3] { 'ڑ', 'ﮌ', 'ﮍ' },
		new char[3] { 'ژ', 'ﮊ', 'ﮋ' },
		new char[5] { 'ڤ', 'ﭪ', 'ﭫ', 'ﭬ', 'ﭭ' },
		new char[5] { 'ڦ', 'ﭮ', 'ﭯ', 'ﭰ', 'ﭱ' },
		new char[5] { 'ک', 'ﮎ', 'ﮏ', 'ﮐ', 'ﮑ' },
		new char[5] { 'ڭ', 'ﯓ', 'ﯔ', 'ﯕ', 'ﯖ' },
		new char[5] { 'گ', 'ﮒ', 'ﮓ', 'ﮔ', 'ﮕ' },
		new char[5] { 'ڱ', 'ﮚ', 'ﮛ', 'ﮜ', 'ﮝ' },
		new char[5] { 'ڳ', 'ﮖ', 'ﮗ', 'ﮘ', 'ﮙ' },
		new char[3] { 'ں', 'ﮞ', 'ﮟ' },
		new char[5] { 'ڻ', 'ﮠ', 'ﮡ', 'ﮢ', 'ﮣ' },
		new char[5] { 'ھ', 'ﮪ', 'ﮫ', 'ﮬ', 'ﮭ' },
		new char[3] { 'ۀ', 'ﮤ', 'ﮥ' },
		new char[5] { 'ہ', 'ﮦ', 'ﮧ', 'ﮨ', 'ﮩ' },
		new char[3] { 'ۅ', 'ﯠ', 'ﯡ' },
		new char[3] { 'ۆ', 'ﯙ', 'ﯚ' },
		new char[3] { 'ۇ', 'ﯗ', 'ﯘ' },
		new char[3] { 'ۈ', 'ﯛ', 'ﯜ' },
		new char[3] { 'ۉ', 'ﯢ', 'ﯣ' },
		new char[3] { 'ۋ', 'ﯞ', 'ﯟ' },
		new char[5] { 'ی', 'ﯼ', 'ﯽ', 'ﯾ', 'ﯿ' },
		new char[5] { 'ې', 'ﯤ', 'ﯥ', 'ﯦ', 'ﯧ' },
		new char[3] { 'ے', 'ﮮ', 'ﮯ' },
		new char[3] { 'ۓ', 'ﮰ', 'ﮱ' }
	};

	internal static bool smethod_0(ArrayList arrayList_0)
	{
		foreach (Class1544 item in arrayList_0)
		{
			string string_ = item.string_0;
			foreach (char c in string_)
			{
				if ((c >= '\u0600' && c <= 'ۿ') || (c >= '\u0590' && c <= '\u05ff'))
				{
					return true;
				}
			}
		}
		return false;
	}

	internal static bool smethod_1(string string_0)
	{
		int num = 0;
		while (true)
		{
			if (num < string_0.Length)
			{
				char c = string_0[num];
				if ((c >= '\u0600' && c <= 'ۿ') || (c >= '\u0590' && c <= '\u05ff'))
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

	private static bool smethod_2(char char_1)
	{
		if (char_1 >= '\u064b' && char_1 <= '\u0655')
		{
			return true;
		}
		return char_1 == '\u0670';
	}

	private static char smethod_3(char char_1, int int_0)
	{
		if (char_1 >= 'ء' && char_1 <= 'ۓ')
		{
			int num = 0;
			int num2 = char_0.Length - 1;
			while (num <= num2)
			{
				int num3 = (num + num2) / 2;
				if (char_1 != char_0[num3][0])
				{
					if (char_1 < char_0[num3][0])
					{
						num2 = num3 - 1;
					}
					else
					{
						num = num3 + 1;
					}
					continue;
				}
				return char_0[num3][int_0 + 1];
			}
		}
		else if (char_1 >= 'ﻵ' && char_1 <= 'ﻻ')
		{
			return (char)(char_1 + int_0);
		}
		return char_1;
	}

	private static int smethod_4(char char_1)
	{
		if (char_1 >= 'ء' && char_1 <= 'ۓ' && !smethod_2(char_1))
		{
			int num = 0;
			int num2 = char_0.Length - 1;
			while (num <= num2)
			{
				int num3 = (num + num2) / 2;
				if (char_1 != char_0[num3][0])
				{
					if (char_1 < char_0[num3][0])
					{
						num2 = num3 - 1;
					}
					else
					{
						num = num3 + 1;
					}
					continue;
				}
				return char_0[num3].Length - 1;
			}
		}
		else if (char_1 == '\u200d')
		{
			return 4;
		}
		return 1;
	}

	private static int smethod_5(char char_1, Class1079 class1079_0)
	{
		int result = 0;
		if (class1079_0.char_0 == '\0')
		{
			return 0;
		}
		if (smethod_2(char_1))
		{
			result = 1;
			if (class1079_0.char_2 != 0 && char_1 != '\u0651')
			{
				result = 2;
			}
			switch (char_1)
			{
			case '\u0651':
				if (class1079_0.char_1 == '\0')
				{
					class1079_0.char_1 = '\u0651';
					break;
				}
				return 0;
			default:
				class1079_0.char_2 = char_1;
				break;
			case '\u0653':
			{
				char c = class1079_0.char_0;
				if (c == 'ا')
				{
					class1079_0.char_0 = 'آ';
					result = 2;
				}
				break;
			}
			case '\u0654':
				switch (class1079_0.char_0)
				{
				case 'و':
					class1079_0.char_0 = 'ؤ';
					result = 2;
					break;
				case 'ا':
					class1079_0.char_0 = 'أ';
					result = 2;
					break;
				default:
					class1079_0.char_1 = '\u0654';
					break;
				case 'ﻻ':
					class1079_0.char_0 = 'ﻷ';
					result = 2;
					break;
				case 'ى':
				case 'ي':
				case 'ی':
					class1079_0.char_0 = 'ئ';
					result = 2;
					break;
				}
				break;
			case '\u0655':
				switch (class1079_0.char_0)
				{
				default:
					class1079_0.char_1 = '\u0655';
					break;
				case 'ﻻ':
					class1079_0.char_0 = 'ﻹ';
					result = 2;
					break;
				case 'ا':
					class1079_0.char_0 = 'إ';
					result = 2;
					break;
				}
				break;
			}
			if (result == 1)
			{
				class1079_0.int_0++;
			}
			return result;
		}
		if (class1079_0.char_2 != 0)
		{
			return 0;
		}
		switch (class1079_0.char_0)
		{
		case 'ل':
			switch (char_1)
			{
			case 'آ':
				class1079_0.char_0 = 'ﻵ';
				class1079_0.int_1 = 2;
				result = 3;
				break;
			case 'أ':
				class1079_0.char_0 = 'ﻷ';
				class1079_0.int_1 = 2;
				result = 3;
				break;
			case 'إ':
				class1079_0.char_0 = 'ﻹ';
				class1079_0.int_1 = 2;
				result = 3;
				break;
			case 'ا':
				class1079_0.char_0 = 'ﻻ';
				class1079_0.int_1 = 2;
				result = 3;
				break;
			}
			break;
		case '\0':
			class1079_0.char_0 = char_1;
			class1079_0.int_1 = smethod_4(char_1);
			result = 1;
			break;
		}
		return result;
	}

	private static void smethod_6(StringBuilder stringBuilder_0, Class1079 class1079_0, int int_0)
	{
		if (class1079_0.char_0 == '\0')
		{
			return;
		}
		stringBuilder_0.Append(class1079_0.char_0);
		class1079_0.int_0--;
		if (class1079_0.char_1 != 0)
		{
			if ((int_0 & 1) == 0)
			{
				stringBuilder_0.Append(class1079_0.char_1);
				class1079_0.int_0--;
			}
			else
			{
				class1079_0.int_0--;
			}
		}
		if (class1079_0.char_2 != 0)
		{
			if ((int_0 & 1) == 0)
			{
				stringBuilder_0.Append(class1079_0.char_2);
				class1079_0.int_0--;
			}
			else
			{
				class1079_0.int_0--;
			}
		}
	}

	internal static void smethod_7(StringBuilder stringBuilder_0, int int_0)
	{
		int num;
		int num2 = (num = stringBuilder_0.Length);
		int num3 = 0;
		int num4 = 1;
		while (num4 < num2)
		{
			char c = '\0';
			if (((uint)int_0 & 4u) != 0)
			{
				switch (stringBuilder_0[num3])
				{
				case '\u064e':
					if (stringBuilder_0[num4] == '\u0651')
					{
						c = 'ﱠ';
					}
					break;
				case '\u064f':
					if (stringBuilder_0[num4] == '\u0651')
					{
						c = 'ﱡ';
					}
					break;
				case '\u0650':
					if (stringBuilder_0[num4] == '\u0651')
					{
						c = 'ﱢ';
					}
					break;
				case '\u0651':
					switch (stringBuilder_0[num4])
					{
					case '\u064c':
						c = 'ﱞ';
						break;
					case '\u064d':
						c = 'ﱟ';
						break;
					case '\u064e':
						c = 'ﱠ';
						break;
					case '\u064f':
						c = 'ﱡ';
						break;
					case '\u0650':
						c = 'ﱢ';
						break;
					}
					break;
				}
			}
			if (((uint)int_0 & 8u) != 0)
			{
				switch (stringBuilder_0[num3])
				{
				case 'ﻓ':
				{
					char c2 = stringBuilder_0[num4];
					if (c2 == 'ﻲ')
					{
						c = 'ﰲ';
					}
					break;
				}
				case 'ﺗ':
					switch (stringBuilder_0[num4])
					{
					case 'ﺨ':
						c = 'ﲣ';
						break;
					case 'ﺤ':
						c = 'ﲢ';
						break;
					case 'ﺠ':
						c = 'ﲡ';
						break;
					}
					break;
				case 'ﺑ':
					switch (stringBuilder_0[num4])
					{
					case 'ﺨ':
						c = 'ﲞ';
						break;
					case 'ﺤ':
						c = 'ﲝ';
						break;
					case 'ﺠ':
						c = 'ﲜ';
						break;
					}
					break;
				case 'ﻧ':
					switch (stringBuilder_0[num4])
					{
					case 'ﺨ':
						c = 'ﳔ';
						break;
					case 'ﺤ':
						c = 'ﳓ';
						break;
					case 'ﺠ':
						c = 'ﳒ';
						break;
					}
					break;
				case 'ﻨ':
					switch (stringBuilder_0[num4])
					{
					case 'ﺮ':
						c = 'ﲊ';
						break;
					case 'ﺰ':
						c = 'ﲋ';
						break;
					}
					break;
				case 'ﻣ':
					switch (stringBuilder_0[num4])
					{
					case 'ﺤ':
						c = 'ﳏ';
						break;
					case 'ﺠ':
						c = 'ﳎ';
						break;
					case 'ﻤ':
						c = 'ﳑ';
						break;
					case 'ﺨ':
						c = 'ﳐ';
						break;
					}
					break;
				case 'ﻟ':
					switch (stringBuilder_0[num4])
					{
					case 'ﻢ':
						c = 'ﱂ';
						break;
					case 'ﻤ':
						c = 'ﳌ';
						break;
					case 'ﺞ':
						c = 'ﰿ';
						break;
					case 'ﺠ':
						c = 'ﳉ';
						break;
					case 'ﺢ':
						c = 'ﱀ';
						break;
					case 'ﺤ':
						c = 'ﳊ';
						break;
					case 'ﺦ':
						c = 'ﱁ';
						break;
					case 'ﺨ':
						c = 'ﳋ';
						break;
					}
					break;
				}
			}
			if (c != 0)
			{
				stringBuilder_0[num3] = c;
				num--;
				num4++;
			}
			else
			{
				num3++;
				stringBuilder_0[num3] = stringBuilder_0[num4];
				num4++;
			}
		}
		stringBuilder_0.Length = num;
	}

	private static bool smethod_8(Class1079 class1079_0)
	{
		return class1079_0.int_1 > 2;
	}

	internal static void smethod_9(char[] char_1, StringBuilder stringBuilder_0, int int_0)
	{
		int num = 0;
		Class1079 class1079_ = new Class1079();
		Class1079 @class = new Class1079();
		int num3;
		while (num < char_1.Length)
		{
			char char_2 = char_1[num++];
			if (smethod_5(char_2, @class) == 0)
			{
				int num2 = smethod_4(char_2);
				num3 = ((num2 != 1) ? 2 : 0);
				if (smethod_8(class1079_))
				{
					num3++;
				}
				num3 %= @class.int_1;
				@class.char_0 = smethod_3(@class.char_0, num3);
				smethod_6(stringBuilder_0, class1079_, int_0);
				class1079_ = @class;
				@class = new Class1079();
				@class.char_0 = char_2;
				@class.int_1 = num2;
				@class.int_0++;
			}
		}
		num3 = (smethod_8(class1079_) ? 1 : 0);
		num3 %= @class.int_1;
		@class.char_0 = smethod_3(@class.char_0, num3);
		smethod_6(stringBuilder_0, class1079_, int_0);
		smethod_6(stringBuilder_0, @class, int_0);
	}

	internal static int smethod_10(char[] char_1, int int_0, int int_1, char[] char_2, int int_2, int int_3, int int_4)
	{
		char[] array = new char[int_1];
		for (int num = int_1 + int_0 - 1; num >= int_0; num--)
		{
			array[num - int_0] = char_1[num];
		}
		StringBuilder stringBuilder = new StringBuilder(int_1);
		smethod_9(array, stringBuilder, int_4);
		if (((uint)int_4 & 0xCu) != 0)
		{
			smethod_7(stringBuilder, int_4);
		}
		Array.Copy(stringBuilder.ToString().ToCharArray(), 0, char_2, int_2, stringBuilder.Length);
		return stringBuilder.Length;
	}
}
