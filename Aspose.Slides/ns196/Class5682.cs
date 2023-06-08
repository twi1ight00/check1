namespace ns196;

internal class Class5682
{
	public static Class5682 class5682_0 = new Class5682("none");

	public static Class5682 class5682_1 = new Class5682("space-before");

	public static Class5682 class5682_2 = new Class5682("space-after");

	public static Class5682 class5682_3 = new Class5682("line-number");

	public static Class5682 class5682_4 = new Class5682("line-height");

	private string string_0;

	private Class5682(string name)
	{
		string_0 = name;
	}

	public override bool Equals(object obj)
	{
		return string_0 == ((Class5682)obj).string_0;
	}

	public override int GetHashCode()
	{
		if (string_0 == null)
		{
			return 0;
		}
		return string_0.GetHashCode();
	}

	public override string ToString()
	{
		return string_0;
	}
}
