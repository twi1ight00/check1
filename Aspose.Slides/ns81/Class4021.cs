namespace ns81;

internal abstract class Class4021 : Class4010, Interface81, Interface84
{
	public const string string_0 = "first-child";

	public const string string_1 = "last-child";

	public const string string_2 = "only-child";

	public const string string_3 = "first-of-type";

	public const string string_4 = "last-of-type";

	public const string string_5 = "only-of-type";

	public const string string_6 = "root";

	public const string string_7 = "enabled";

	public const string string_8 = "disabled";

	public const string string_9 = "checked";

	public const string string_10 = "empty";

	public const string string_11 = "valid";

	public const string string_12 = "invalid";

	public const string string_13 = "required";

	public const string string_14 = "optional";

	public const string string_15 = "in-range";

	public const string string_16 = "out-of-range";

	public const string string_17 = "read-only";

	public const string string_18 = "read-write";

	public const string string_19 = "indeterminate";

	public const string string_20 = "dir(";

	public const string string_21 = "not(";

	public const string string_22 = "nth-child(";

	public const string string_23 = "nth-last-child(";

	public const string string_24 = "nth-of-type(";

	public const string string_25 = "nth-last-of-type(";

	public const string string_26 = "lang(";

	private string string_27;

	public override int Specificity => 10;

	public override short ConditionType => 10;

	public override string ConditionText => ':' + string_27;

	public string ClassName => string_27;

	protected Class4021(string className)
	{
		string_27 = className;
	}
}
