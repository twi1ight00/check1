using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace System.Data.Entity.ModelConfiguration.Design.PluralizationServices;

internal static class PluralizationServiceUtil
{
	internal static bool DoesWordContainSuffix(string word, IEnumerable<string> suffixes, CultureInfo culture)
	{
		if (suffixes.Any((string s) => word.EndsWith(s, ignoreCase: true, culture)))
		{
			return true;
		}
		return false;
	}

	internal static bool TryGetMatchedSuffixForWord(string word, IEnumerable<string> suffixes, CultureInfo culture, out string matchedSuffix)
	{
		matchedSuffix = null;
		if (DoesWordContainSuffix(word, suffixes, culture))
		{
			matchedSuffix = suffixes.First((string s) => word.EndsWith(s, ignoreCase: true, culture));
			return true;
		}
		return false;
	}

	internal static bool TryInflectOnSuffixInWord(string word, IEnumerable<string> suffixes, Func<string, string> operationOnWord, CultureInfo culture, out string newWord)
	{
		newWord = null;
		if (TryGetMatchedSuffixForWord(word, suffixes, culture, out var _))
		{
			newWord = operationOnWord(word);
			return true;
		}
		return false;
	}
}
