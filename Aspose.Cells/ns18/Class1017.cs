using System.Collections;

namespace ns18;

internal class Class1017 : IComparer
{
	public static readonly IComparer icomparer_0 = new Class1017();

	private Class1017()
	{
	}

	public int Compare(object x, object y)
	{
		return string.CompareOrdinal((string)x, (string)y);
	}
}
