using System.Collections;

namespace ns151;

internal class Class4699 : Hashtable
{
	public Hashtable this[int glyphIDHashCode]
	{
		get
		{
			if (base.ContainsKey(glyphIDHashCode))
			{
				return (Hashtable)base[glyphIDHashCode];
			}
			return null;
		}
	}

	public void Add(int glyphIDHashCode, Class4698 kerningData)
	{
		if (!base.ContainsKey(glyphIDHashCode))
		{
			base[glyphIDHashCode] = new Hashtable();
		}
		Hashtable hashtable = (Hashtable)base[glyphIDHashCode];
		if (!hashtable.ContainsKey(kerningData.int_0))
		{
			hashtable.Add(kerningData.int_0, kerningData);
		}
	}
}
