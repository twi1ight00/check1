using System.Collections;

namespace ns195;

internal class Class5693
{
	private Class5693()
	{
	}

	public static object smethod_0(ArrayList list)
	{
		if (list.Count != 0)
		{
			return list[list.Count - 1];
		}
		return null;
	}

	public static object smethod_1(ArrayList list)
	{
		object result = smethod_0(list);
		list.RemoveAt(list.Count - 1);
		return result;
	}

	public static void smethod_2(ArrayList dst, ArrayList src)
	{
		dst.AddRange(src);
	}
}
