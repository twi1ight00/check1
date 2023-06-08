namespace ns316;

internal sealed class Class7143
{
	public const int int_0 = 3;

	public const int int_1 = 2;

	public const int int_2 = 1;

	public const int int_3 = 0;

	public const string string_0 = "Red";

	public const string string_1 = "Green";

	public const string string_2 = "Blue";

	public const string string_3 = "Alpha";

	private string string_4;

	private int int_4;

	public static readonly Class7143 class7143_0 = new Class7143(2, "Red");

	public static readonly Class7143 class7143_1 = new Class7143(1, "Green");

	public static readonly Class7143 class7143_2 = new Class7143(0, "Blue");

	public static readonly Class7143 class7143_3 = new Class7143(3, "Alpha");

	public Class7143(int value, string name)
	{
		string_4 = name;
		int_4 = value;
	}

	public override string ToString()
	{
		return string_4;
	}

	public int method_0()
	{
		return int_4;
	}
}
