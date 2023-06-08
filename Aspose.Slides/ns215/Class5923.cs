using System.Collections;
using ns216;

namespace ns215;

internal class Class5923
{
	private int int_0;

	private float float_0;

	private float float_1;

	private Class5834 class5834_0;

	private readonly ArrayList arrayList_0 = new ArrayList();

	internal int Number
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	internal float Height
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
		}
	}

	internal float Width
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
		}
	}

	internal Class5834 Page => class5834_0;

	internal ArrayList ContentAreas => arrayList_0;

	internal Class5923(Class5834 page)
	{
		class5834_0 = page;
	}

	internal Class5924[] method_0()
	{
		return (Class5924[])ContentAreas.ToArray(typeof(Class5924));
	}
}
