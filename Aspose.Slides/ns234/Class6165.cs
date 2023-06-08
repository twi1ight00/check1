using System.Globalization;

namespace ns234;

internal static class Class6165
{
	public static bool Equals(string a, int indexA, string b, int indexB, int length)
	{
		return string.Compare(a, indexA, b, indexB, length) == 0;
	}

	public static bool smethod_0(string a, string b)
	{
		return string.Compare(a, b, ignoreCase: true) == 0;
	}

	public static int smethod_1(string a, string b)
	{
		CompareInfo compareInfo = CultureInfo.CurrentCulture.CompareInfo;
		return compareInfo.Compare(a, b, CompareOptions.StringSort);
	}
}
