using System.Collections;

namespace ns99;

internal class Class4504 : IEnumerable
{
	private bool bool_0;

	private Hashtable hashtable_0;

	public int Count => hashtable_0.Keys.Count;

	public bool IsReadOnly => bool_0;

	public Class4504()
	{
		hashtable_0 = new Hashtable();
	}

	public void Add(int glyphID)
	{
		hashtable_0.Add(glyphID, glyphID);
	}

	public void Remove(int glyphID)
	{
		hashtable_0.Remove(glyphID);
	}

	public bool Contains(int glyphID)
	{
		return hashtable_0.ContainsKey(glyphID);
	}

	public void Clear()
	{
		hashtable_0.Clear();
	}

	internal void method_0()
	{
		bool_0 = false;
	}

	internal void method_1()
	{
		bool_0 = true;
	}

	public IEnumerator GetEnumerator()
	{
		return hashtable_0.Keys.GetEnumerator();
	}
}
