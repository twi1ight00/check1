using System.Collections;
using System.Reflection;
using Aspose.Words;

namespace x28925c9b27b37a46;

[DefaultMember("Item")]
internal class xe67988fee456098e : IEnumerable
{
	private Hashtable x82b70567a5f68f41 = new Hashtable();

	internal xa1e2a8ed32a026dd xe6d4b1b411ed94b5
	{
		get
		{
			return (xa1e2a8ed32a026dd)x82b70567a5f68f41[x781135a02d5b7a22];
		}
		set
		{
			x82b70567a5f68f41[x781135a02d5b7a22] = value;
		}
	}

	internal int xd44988f225497f3a => x82b70567a5f68f41.Count;

	internal xe67988fee456098e x8b61531c8ea35b85(DocumentBase xcdd91c46b8f58479, x15a33f6d96885286 x5ebbc4e56d2a7304)
	{
		xe67988fee456098e xe67988fee456098e2 = (xe67988fee456098e)MemberwiseClone();
		xe67988fee456098e2.x82b70567a5f68f41 = new Hashtable();
		foreach (DictionaryEntry item in x82b70567a5f68f41)
		{
			xa1e2a8ed32a026dd xa1e2a8ed32a026dd2 = (xa1e2a8ed32a026dd)item.Value;
			xa1e2a8ed32a026dd xa1e2a8ed32a026dd3 = (xa1e2a8ed32a026dd)xa1e2a8ed32a026dd2.x8b61531c8ea35b85(x7a5f12b98e34a590: true, x5ebbc4e56d2a7304);
			xa1e2a8ed32a026dd3.x3e229cd2762a6ef5(xcdd91c46b8f58479);
			xe67988fee456098e2.x82b70567a5f68f41.Add(item.Key, xa1e2a8ed32a026dd3);
		}
		return xe67988fee456098e2;
	}

	public IEnumerator GetEnumerator()
	{
		return x82b70567a5f68f41.Values.GetEnumerator();
	}
}
