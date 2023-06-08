using System.Collections;
using System.Runtime.CompilerServices;

namespace ns8;

internal class Class725 : Class724
{
	protected ArrayList arrayList_0;

	public Class724 this[int int_0]
	{
		get
		{
			if (int_0 < arrayList_0.Count)
			{
				return (Class724)arrayList_0[int_0];
			}
			return null;
		}
	}

	public Class724 this[string string_2]
	{
		get
		{
			int num = 0;
			while (true)
			{
				if (num < arrayList_0.Count)
				{
					if (this[num] != null && this[num].Name.ToUpper().Equals(string_2.ToUpper()))
					{
						break;
					}
					num++;
					continue;
				}
				return null;
			}
			return this[num];
		}
	}

	public Class725()
		: base("", "")
	{
		arrayList_0 = new ArrayList();
	}

	public void Add(Class724 class724_0)
	{
		arrayList_0.Add(class724_0);
	}

	public void Clear()
	{
		arrayList_0.Clear();
	}

	[SpecialName]
	public ArrayList method_0()
	{
		return arrayList_0;
	}
}
