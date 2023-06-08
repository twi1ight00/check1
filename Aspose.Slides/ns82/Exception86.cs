using ns83;

namespace ns82;

internal class Exception86 : Exception77
{
	public int int_4;

	public Exception86()
	{
	}

	public Exception86(int expecting, Interface389 input)
		: base(input)
	{
		int_4 = expecting;
	}

	public override string ToString()
	{
		return "MismatchedTreeNodeException(" + UnexpectedType + "!=" + int_4 + ")";
	}
}
