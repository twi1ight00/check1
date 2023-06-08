using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace System.Data.Entity.Edm.Internal;

internal static class EdmUtil
{
	private const string StartCharacterExp = "[\\p{Ll}\\p{Lu}\\p{Lt}\\p{Lo}\\p{Lm}\\p{Nl}]";

	private const string OtherCharacterExp = "[\\p{Ll}\\p{Lu}\\p{Lt}\\p{Lo}\\p{Lm}\\p{Nl}\\p{Mn}\\p{Mc}\\p{Nd}\\p{Pc}\\p{Cf}]";

	private const string NameExp = "[\\p{Ll}\\p{Lu}\\p{Lt}\\p{Lo}\\p{Lm}\\p{Nl}][\\p{Ll}\\p{Lu}\\p{Lt}\\p{Lo}\\p{Lm}\\p{Nl}\\p{Mn}\\p{Mc}\\p{Nd}\\p{Pc}\\p{Cf}]{0,}";

	private static readonly Regex UndottedNameValidator = new Regex("^[\\p{Ll}\\p{Lu}\\p{Lt}\\p{Lo}\\p{Lm}\\p{Nl}][\\p{Ll}\\p{Lu}\\p{Lt}\\p{Lo}\\p{Lm}\\p{Nl}\\p{Mn}\\p{Mc}\\p{Nd}\\p{Pc}\\p{Cf}]{0,}$", RegexOptions.Compiled | RegexOptions.Singleline);

	internal static NotSupportedException NotSupported(string message)
	{
		return new NotSupportedException(message);
	}

	internal static bool EqualsOrdinal(this string string1, string string2)
	{
		return string.Equals(string1, string2, StringComparison.Ordinal);
	}

	internal static bool TryGetPrimitiveTypeKindFromString(string value, out EdmPrimitiveTypeKind typeKind)
	{
		switch (value)
		{
		case "Binary":
			typeKind = EdmPrimitiveTypeKind.Binary;
			return true;
		case "Boolean":
			typeKind = EdmPrimitiveTypeKind.Boolean;
			return true;
		case "Byte":
			typeKind = EdmPrimitiveTypeKind.Byte;
			return true;
		case "DateTime":
			typeKind = EdmPrimitiveTypeKind.DateTime;
			return true;
		case "DateTimeOffset":
			typeKind = EdmPrimitiveTypeKind.DateTimeOffset;
			return true;
		case "Decimal":
			typeKind = EdmPrimitiveTypeKind.Decimal;
			return true;
		case "Double":
			typeKind = EdmPrimitiveTypeKind.Double;
			return true;
		case "Guid":
			typeKind = EdmPrimitiveTypeKind.Guid;
			return true;
		case "Single":
			typeKind = EdmPrimitiveTypeKind.Single;
			return true;
		case "SByte":
			typeKind = EdmPrimitiveTypeKind.SByte;
			return true;
		case "Int16":
			typeKind = EdmPrimitiveTypeKind.Int16;
			return true;
		case "Int32":
			typeKind = EdmPrimitiveTypeKind.Int32;
			return true;
		case "Int64":
			typeKind = EdmPrimitiveTypeKind.Int64;
			return true;
		case "String":
			typeKind = EdmPrimitiveTypeKind.String;
			return true;
		case "Time":
			typeKind = EdmPrimitiveTypeKind.Time;
			return true;
		default:
			typeKind = EdmPrimitiveTypeKind.Binary;
			return false;
		}
	}

	internal static bool IsValidDataModelItemName(string name)
	{
		return IsValidUndottedName(name);
	}

	internal static bool IsValidQualifiedItemName(string name)
	{
		return IsValidDottedName(name);
	}

	/// <summary>
	///     Parsing code taken from System.dll's System.CodeDom.Compiler.CodeGenerator.IsValidLanguageIndependentIdentifier(string) method to avoid LinkDemand needed to call this method
	/// </summary>
	private static bool IsValidLanguageIndependentIdentifier(string value)
	{
		bool flag = false;
		bool nextMustBeStartChar = true;
		if (value.Length == 0)
		{
			return false;
		}
		foreach (char c in value)
		{
			switch (char.GetUnicodeCategory(c))
			{
			case UnicodeCategory.UppercaseLetter:
			case UnicodeCategory.LowercaseLetter:
			case UnicodeCategory.TitlecaseLetter:
			case UnicodeCategory.ModifierLetter:
			case UnicodeCategory.OtherLetter:
			case UnicodeCategory.LetterNumber:
				nextMustBeStartChar = false;
				break;
			case UnicodeCategory.NonSpacingMark:
			case UnicodeCategory.SpacingCombiningMark:
			case UnicodeCategory.DecimalDigitNumber:
			case UnicodeCategory.ConnectorPunctuation:
				if (nextMustBeStartChar && c != '_')
				{
					return false;
				}
				nextMustBeStartChar = false;
				break;
			default:
				if (!flag || !IsSpecialTypeChar(c, ref nextMustBeStartChar))
				{
					return false;
				}
				break;
			}
		}
		return true;
	}

	private static bool IsSpecialTypeChar(char ch, ref bool nextMustBeStartChar)
	{
		switch (ch)
		{
		case '$':
		case '&':
		case '*':
		case '+':
		case ',':
		case '-':
		case '.':
		case ':':
		case '<':
		case '>':
		case '[':
		case ']':
			nextMustBeStartChar = true;
			return true;
		case '`':
			return true;
		default:
			return false;
		}
	}

	/// <summary>
	/// </summary>
	/// <param name="name"> </param>
	/// <returns> </returns>
	private static bool IsValidUndottedName(string name)
	{
		if (!string.IsNullOrEmpty(name) && UndottedNameValidator.IsMatch(name))
		{
			return IsValidLanguageIndependentIdentifier(name);
		}
		return false;
	}

	private static bool IsValidDottedName(string name)
	{
		string[] array = name.Split('.');
		foreach (string name2 in array)
		{
			if (!IsValidUndottedName(name2))
			{
				return false;
			}
		}
		return true;
	}

	public static string StripInvalidCharacters(string value)
	{
		if (string.IsNullOrWhiteSpace(value))
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder(value.Length);
		bool flag = true;
		foreach (char c in value)
		{
			if (c == '.')
			{
				if (!flag)
				{
					stringBuilder.Append(c);
				}
				continue;
			}
			switch (char.GetUnicodeCategory(c))
			{
			case UnicodeCategory.UppercaseLetter:
			case UnicodeCategory.LowercaseLetter:
			case UnicodeCategory.TitlecaseLetter:
			case UnicodeCategory.ModifierLetter:
			case UnicodeCategory.OtherLetter:
			case UnicodeCategory.LetterNumber:
				flag = false;
				stringBuilder.Append(c);
				break;
			case UnicodeCategory.NonSpacingMark:
			case UnicodeCategory.SpacingCombiningMark:
			case UnicodeCategory.DecimalDigitNumber:
			case UnicodeCategory.ConnectorPunctuation:
				if (!flag)
				{
					stringBuilder.Append(c);
				}
				break;
			}
		}
		return stringBuilder.ToString();
	}
}
