namespace ns82;

internal class Exception79 : Exception77
{
	public string string_0;

	public string string_1;

	public Exception79()
	{
	}

	public Exception79(Interface388 input, string ruleName, string predicateText)
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
