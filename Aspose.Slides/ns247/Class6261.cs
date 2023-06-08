using System.Collections;
using ns218;

namespace ns247;

internal class Class6261 : IEnumerable
{
	private readonly Class5968 class5968_0;

	public int Count => class5968_0.Count;

	public Class6260 this[string name] => (Class6260)class5968_0[name];

	public Class6261()
	{
		class5968_0 = new Class5968(isCaseSensitive: false);
	}

	public void Add(Class6260 part)
	{
		class5968_0.Add(part.Name, part);
	}

	public bool Contains(string name)
	{
		return class5968_0.Contains(name);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return class5968_0.GetValueList().GetEnumerator();
	}
}
