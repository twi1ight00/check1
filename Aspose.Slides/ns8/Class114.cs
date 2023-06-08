using System.Collections;
using System.Collections.Generic;
using ns56;

namespace ns8;

internal class Class114 : IEnumerable, IEnumerable<Class115>
{
	private List<Class115> list_0 = new List<Class115>();

	public Class115 method_0(Class837 target, Enum305 type)
	{
		foreach (Class115 item in list_0)
		{
			if (item.Target == target && item.Type == type)
			{
				return item;
			}
		}
		Class115 @class = new Class115(target, type, target.method_31(type), target.method_32(type));
		list_0.Add(@class);
		return @class;
	}

	public IEnumerator<Class115> GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return list_0.GetEnumerator();
	}
}
