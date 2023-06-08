namespace ns82;

internal class Exception87 : Exception77
{
	public string string_0;

	public int int_4;

	public int int_5;

	public Exception87()
	{
	}

	public Exception87(string grammarDecisionDescription, int decisionNumber, int stateNumber, Interface388 input)
		: base(input)
	{
		string_0 = grammarDecisionDescription;
		int_4 = decisionNumber;
		int_5 = stateNumber;
	}

	public override string ToString()
	{
		if (interface388_0 is Interface391)
		{
			return "NoViableAltException('" + (char)UnexpectedType + "'@[" + string_0 + "])";
		}
		return "NoViableAltException(" + UnexpectedType + "@[" + string_0 + "])";
	}
}
