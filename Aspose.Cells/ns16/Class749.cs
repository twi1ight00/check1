using System.Collections.Generic;

namespace ns16;

internal class Class749 : IComparer<Class744>
{
	private bool bool_0;

	internal Class749(bool bool_1)
	{
		bool_0 = bool_1;
	}

	int IComparer<Class744>.Compare(Class744 x, Class744 y)
	{
		return string.Compare(x.FileName, x.FileName, !bool_0);
	}
}
