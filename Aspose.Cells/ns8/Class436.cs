namespace ns8;

internal class Class436
{
	public static bool smethod_0(string string_0, string string_1)
	{
		if (string_1 == null)
		{
			return false;
		}
		if (string_0.StartsWith("--") && string_0.Substring(2).StartsWith(string_1))
		{
			return true;
		}
		return false;
	}

	public static string smethod_1(string string_0)
	{
		return string_0.Substring(string_0.IndexOf(":") + 1).Trim();
	}
}
