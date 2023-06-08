using System;
using System.Globalization;
using System.Text;
using ns284;
using ns301;

namespace ns290;

internal class Class6940
{
	public static void smethod_0(Class6855 word, Enum940 transformType)
	{
		Class6892.smethod_0(word, "word");
		switch (transformType)
		{
		default:
			throw new ArgumentOutOfRangeException(string.Format(CultureInfo.InvariantCulture, "The transformType is out of range: {0}", new object[1] { transformType }));
		case Enum940.const_0:
			break;
		case Enum940.const_1:
			word.WordUndecoded = smethod_1(word.WordUndecoded);
			break;
		case Enum940.const_2:
			word.WordUndecoded = word.WordUndecoded.ToUpper(CultureInfo.InvariantCulture);
			break;
		case Enum940.const_3:
			word.WordUndecoded = word.WordUndecoded.ToLower(CultureInfo.InvariantCulture);
			break;
		}
	}

	private static string smethod_1(string word)
	{
		if (Class6973.smethod_0(word))
		{
			return word;
		}
		if (word.Length == 1)
		{
			word = word.ToUpper(CultureInfo.InvariantCulture);
			return word;
		}
		StringBuilder stringBuilder = new StringBuilder(word.ToLower(CultureInfo.InvariantCulture));
		stringBuilder[0] = char.ToUpper(stringBuilder[0], CultureInfo.InvariantCulture);
		word = stringBuilder.ToString();
		return word;
	}
}
