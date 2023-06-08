using System.Collections;

namespace ns179;

internal class Class5353
{
	private string string_0;

	private bool bool_0;

	private ArrayList arrayList_0;

	private Class5349 class5349_0;

	public Class5353(string title, bool show, Class5349 action)
	{
		string_0 = title;
		bool_0 = show;
		class5349_0 = action;
	}

	public string method_0()
	{
		return string_0;
	}

	public bool method_1()
	{
		return bool_0;
	}

	public Class5349 method_2()
	{
		return class5349_0;
	}

	public void method_3(Class5349 action)
	{
		class5349_0 = action;
	}

	public void method_4(Class5353 bookmark)
	{
		if (arrayList_0 == null)
		{
			arrayList_0 = new ArrayList();
		}
		arrayList_0.Add(bookmark);
	}

	public ArrayList method_5()
	{
		if (arrayList_0 == null)
		{
			return new ArrayList();
		}
		return arrayList_0;
	}
}
