namespace ns82;

internal class Exception27 : Exception17
{
	public string string_0;

	public int int_4;

	public int int_5;

	public Exception27()
	{
	}

	public Exception27(string grammarDecisionDescription, int decisionNumber, int stateNumber, Interface107 input)
		: base(input)
	{
		string_0 = grammarDecisionDescription;
		int_4 = decisionNumber;
		int_5 = stateNumber;
	}

	public override string ToString()
	{
		if (interface107_0 is Interface110)
		{
			return "NoViableAltException('" + (char)UnexpectedType + "'@[" + string_0 + "])";
		}
		return "NoViableAltException(" + UnexpectedType + "@[" + string_0 + "])";
	}
}
