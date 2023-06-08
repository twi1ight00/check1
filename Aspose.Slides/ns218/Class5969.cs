using System.Collections;

namespace ns218;

internal class Class5969 : IComparer
{
	public static readonly IComparer icomparer_0 = new Class5969();

	private Class5969()
	{
	}

	public int Compare(object a, object b)
	{
		return string.CompareOrdinal((string)a, (string)b);
	}
}
