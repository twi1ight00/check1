using System.Collections;

namespace ns218;

internal class Class5968 : SortedList
{
	public Class5968()
		: this(isCaseSensitive: true)
	{
	}

	public Class5968(bool isCaseSensitive)
		: base(isCaseSensitive ? Class5969.icomparer_0 : Class5970.icomparer_0)
	{
	}
}
