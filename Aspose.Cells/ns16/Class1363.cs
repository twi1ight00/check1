using System.Collections;

namespace ns16;

internal class Class1363
{
	internal Hashtable hashtable_0 = new Hashtable();

	internal void Add(Enum129 enum129_0, object object_0)
	{
		if (hashtable_0.ContainsKey(enum129_0))
		{
			hashtable_0.Remove(enum129_0);
		}
		hashtable_0.Add(enum129_0, object_0);
	}

	internal object method_0(Enum129 enum129_0)
	{
		return hashtable_0[enum129_0];
	}
}
