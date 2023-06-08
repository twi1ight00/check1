using System.Collections;

namespace ns156;

internal class Class4714 : CollectionBase
{
	public Class4713 this[int index]
	{
		get
		{
			return (Class4713)base.List[index];
		}
		set
		{
			base.List[index] = value;
		}
	}

	public void Add(Class4713 item)
	{
		base.List.Add(item);
	}
}
