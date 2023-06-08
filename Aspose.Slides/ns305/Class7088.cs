using System.Collections;
using System.Collections.Generic;

namespace ns305;

internal class Class7088 : IEnumerable, IEnumerable<string>
{
	private List<string> list_0;

	public int Length => List.Count;

	private List<string> List
	{
		get
		{
			if (list_0 == null)
			{
				list_0 = new List<string>();
			}
			return list_0;
		}
	}

	internal Class7088()
	{
	}

	public string method_0(int index)
	{
		return List[index];
	}

	public bool Contains(string str)
	{
		return List.Contains(str);
	}

	public IEnumerator<string> GetEnumerator()
	{
		return List.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
