using System.Collections;

namespace ns99;

internal class Class4503 : IEnumerable
{
	private bool bool_0;

	private Hashtable hashtable_0;

	public int Count => hashtable_0.Keys.Count;

	public bool IsReadOnly => bool_0;

	public Class4503()
	{
		hashtable_0 = new Hashtable();
	}

	public void Add(string glyphName)
	{
		hashtable_0.Add(glyphName, glyphName);
	}

	public void Remove(string glyphName)
	{
		hashtable_0.Remove(glyphName);
	}

	public bool Contains(string glyphName)
	{
		return hashtable_0.ContainsKey(glyphName);
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
