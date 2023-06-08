namespace ns82;

internal class Exception19 : Exception17
{
	public string string_0;

	public string string_1;

	public Exception19()
	{
	}

	public Exception19(Interface107 input, string ruleName, string predicateText)
		: base(input)
	{
		string_0 = ruleName;
		string_1 = predicateText;
	}

	public override string ToString()
	{
		return "FailedPredicateException(" + string_0 + ",{" + string_1 + "}?)";
	}
}
