using System.Collections;

namespace ns322;

internal class Class7677 : IEnumerable, Interface397
{
	private Hashtable hashtable_0 = new Hashtable(5);

	public int Count => hashtable_0.Count;

	public IEnumerable Values => hashtable_0.Values;

	public Class7352 imethod_0(string name, Class7352 descriptor)
	{
		hashtable_0[name] = descriptor;
		return descriptor;
	}

	public void imethod_1(string name)
	{
		hashtable_0.Remove(name);
	}

	public Class7352 imethod_2(string name)
	{
		imethod_3(name, out var descriptor);
		return descriptor;
	}

	public bool imethod_3(string name, out Class7352 descriptor)
	{
		descriptor = null;
		bool result;
		if (result = hashtable_0.ContainsKey(name))
		{
			descriptor = (Class7352)hashtable_0[name];
		}
		return result;
	}

	public IEnumerator GetEnumerator()
	{
		return hashtable_0.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
