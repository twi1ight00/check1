using System.Collections;

namespace ns156;

internal class Class4726 : CollectionBase
{
	public Class4725 this[int index]
	{
		get
		{
			return (Class4725)base.List[index];
		}
		set
		{
			base.List[index] = value;
		}
	}

	public void Add(Class4725 item)
	{
		base.List.Add(item);
	}
}
