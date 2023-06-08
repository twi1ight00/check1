using System.IO;

namespace ns22;

internal class Class1185
{
	internal static string smethod_0(string string_0)
	{
		return Path.GetPathRoot(string_0);
	}

	internal static string smethod_1(string string_0)
	{
		return Path.GetFileName(string_0);
	}

	internal static string smethod_2(string string_0)
	{
		return Path.GetDirectoryName(string_0);
	}
}
