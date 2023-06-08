using System.Collections;

namespace ns99;

internal class Class4485
{
	private Hashtable hashtable_0;

	public int this[string name]
	{
		get
		{
			return (int)hashtable_0[name];
		}
		set
		{
			hashtable_0[name] = value;
		}
	}

	public int Count => hashtable_0.Count;

	public ICollection Keys => hashtable_0.Keys;

	internal Class4485()
	{
		hashtable_0 = new Hashtable();
	}

	public void Add(string name, int code)
	{
		hashtable_0.Add(name, code);
	}

	public bool ContainsKey(string name)
	{
		return hashtable_0.ContainsKey(name);
	}
}
