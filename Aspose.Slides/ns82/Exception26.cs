using ns83;

namespace ns82;

internal class Exception26 : Exception17
{
	public int int_4;

	public Exception26()
	{
	}

	public Exception26(int expecting, Interface108 input)
		: base(input)
	{
		int_4 = expecting;
	}

	public override string ToString()
	{
		return "MismatchedTreeNodeException(" + UnexpectedType + "!=" + int_4 + ")";
	}
}
