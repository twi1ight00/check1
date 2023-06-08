using System.Collections;

namespace x6c95d9cf46ff5f25;

internal class xa1fe40c1efb73872 : IComparer
{
	public static readonly IComparer xb9715d2f06b63cf0 = new xa1fe40c1efb73872();

	private xa1fe40c1efb73872()
	{
	}

	public int Compare(object a, object b)
	{
		return string.CompareOrdinal((string)a, (string)b);
	}
}
