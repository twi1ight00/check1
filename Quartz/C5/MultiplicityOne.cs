using System.Runtime.InteropServices;

namespace C5;

internal class MultiplicityOne<K> : MappedCollectionValue<K, KeyValuePair<K, int>>
{
	[ComVisible(true)]
	public MultiplicityOne(ICollectionValue<K> coll)
		: base(coll)
	{
	}

	[ComVisible(true)]
	public override KeyValuePair<K, int> Map(K k)
	{
		return new KeyValuePair<K, int>(k, 1);
	}
}
