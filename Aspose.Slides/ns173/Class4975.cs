using System.Collections;

namespace ns173;

internal class Class4975 : Class4941
{
	private ArrayList arrayList_1 = new ArrayList();

	private Class4972 class4972_0;

	private string string_0;

	private string string_1;

	public Class4975(Class4972 title)
	{
		method_10(title);
	}

	public Class4972 method_9()
	{
		return class4972_0;
	}

	public void method_10(Class4972 titlE)
	{
		class4972_0 = titlE;
	}

	public void method_11(Class4974 page)
	{
		arrayList_1.Add(page);
	}

	public int method_12()
	{
		return arrayList_1.Count;
	}

	public Class4974 method_13(int idx)
	{
		return (Class4974)arrayList_1[idx];
	}

	public bool method_14(Class4974 page)
	{
		return page == method_13(0);
	}

	public string method_15()
	{
		return string_0;
	}

	public void method_16(string languagE)
	{
		if ("none" == languagE)
		{
			string_0 = null;
		}
		else
		{
			string_0 = languagE;
		}
	}

	public string method_17()
	{
		return string_1;
	}

	public void method_18(string countrY)
	{
		if ("none" == countrY)
		{
			string_1 = null;
		}
		else
		{
			string_1 = countrY;
		}
	}
}
