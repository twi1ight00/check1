using System.Collections.Generic;
using ns218;

namespace ns271;

internal class Class6660
{
	private int int_0;

	private int int_1;

	private readonly List<Class6659> list_0;

	private readonly float float_0;

	public Class6659 this[int index]
	{
		get
		{
			if (index >= 0 && index < list_0.Count)
			{
				return list_0[index];
			}
			return null;
		}
	}

	public int Count => list_0.Count;

	private Class6659 LastPoint => this[list_0.Count - 1];

	public Class6660()
		: this(1f)
	{
	}

	public Class6660(float scale)
	{
		list_0 = new List<Class6659>();
		float_0 = scale;
	}

	public void Add(int dx, int dy, bool isOnCurve, bool isEndOfCotour)
	{
		int num = Class5955.smethod_29((float)dx * float_0);
		int num2 = Class5955.smethod_29((float)dy * float_0);
		int_0 += num;
		int_1 += num2;
		Class6659 @class = new Class6659(num, num2, int_0, int_1, isOnCurve, isEndOfCotour);
		if (LastPoint == null || !LastPoint.IsEndOfContour || !@class.IsEndOfContour)
		{
			list_0.Add(@class);
		}
	}
}
