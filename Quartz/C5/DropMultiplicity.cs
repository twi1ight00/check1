using System.Runtime.InteropServices;

namespace C5;

internal class DropMultiplicity<K> : MappedCollectionValue<KeyValuePair<K, int>, K>
{
	[ComVisible(true)]
	public DropMultiplicity(ICollectionValue<KeyValuePair<K, int>> coll)
		: base(coll)
	{
	}

	[ComVisible(true)]
	public override K Map(KeyValuePair<K, int> kvp)
	{
		return kvp.Key;
	}
}
