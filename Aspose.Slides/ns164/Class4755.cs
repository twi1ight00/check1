using System.Collections;
using ns165;

namespace ns164;

internal abstract class Class4755 : IEnumerable, IEnumerator
{
	private readonly ArrayList arrayList_0 = new ArrayList();

	private IEnumerator ienumerator_0;

	private Class4767 class4767_0;

	internal int Count => arrayList_0.Count;

	internal virtual Class4755 this[int index] => (Class4755)arrayList_0[index];

	internal Class4767 Attributes => class4767_0;

	public object Current => ienumerator_0.Current;

	internal Class4755(Class4767 formatAttributes)
	{
		class4767_0 = formatAttributes;
	}

	internal Class4755()
	{
		class4767_0 = new Class4767();
	}

	internal virtual void Add(Class4755 child)
	{
		arrayList_0.Add(child);
	}

	internal abstract void vmethod_0(Interface145 builder);

	public void Reset()
	{
		ienumerator_0.Reset();
	}

	public bool MoveNext()
	{
		return ienumerator_0.MoveNext();
	}

	public IEnumerator GetEnumerator()
	{
		ienumerator_0 = arrayList_0.GetEnumerator();
		Reset();
		return ienumerator_0;
	}
}
