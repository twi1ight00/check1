using System.Collections;

namespace ns99;

internal class Class4505 : IEnumerable
{
	internal Class4501 class4501_0;

	internal Class4500 class4500_0;

	internal Class4499 class4499_0;

	private ArrayList arrayList_0 = new ArrayList();

	public int Count => arrayList_0.Count;

	public Class4506 this[int index] => (Class4506)arrayList_0[index];

	internal Class4505()
	{
		class4501_0 = new Class4501();
		class4500_0 = new Class4500();
		class4499_0 = new Class4499();
	}

	public void Add(Class4506 glyphID)
	{
		arrayList_0.Add(glyphID);
		method_0(glyphID);
	}

	public void Remove(Class4506 glyphID)
	{
		arrayList_0.Remove(glyphID);
		method_1(glyphID);
	}

	public void Clear()
	{
		arrayList_0.Clear();
		method_2();
	}

	public bool Contains(Class4506 glyphID)
	{
		foreach (Class4506 item in arrayList_0)
		{
			if (item.Equals(glyphID))
			{
				return true;
			}
		}
		return false;
	}

	public IEnumerator GetEnumerator()
	{
		return arrayList_0.GetEnumerator();
	}

	private void method_0(Class4506 glyphId)
	{
		if (class4501_0 == null || class4501_0.Count == 0)
		{
			return;
		}
		foreach (Interface120 item in class4501_0)
		{
			item.imethod_0(this, new EventArgs3(glyphId));
		}
	}

	private void method_1(Class4506 glyphId)
	{
		if (class4500_0 == null || class4500_0.Count == 0)
		{
			return;
		}
		foreach (Interface122 item in class4500_0)
		{
			item.imethod_0(this, new EventArgs3(glyphId));
		}
	}

	private void method_2()
	{
		if (class4499_0 == null || class4499_0.Count == 0)
		{
			return;
		}
		foreach (Interface121 item in class4499_0)
		{
			item.imethod_0(this);
		}
	}
}
