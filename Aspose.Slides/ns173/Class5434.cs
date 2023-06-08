using System.Collections;

namespace ns173;

internal class Class5434 : Interface160
{
	private bool bool_0;

	private string string_0;

	private Class4942 class4942_0;

	private ArrayList arrayList_0;

	public Class5434(string id, Class4942 a)
	{
		string_0 = id;
		class4942_0 = a;
	}

	public bool imethod_2()
	{
		return bool_0;
	}

	public string[] imethod_3()
	{
		return new string[1] { string_0 };
	}

	public void imethod_4(string id, ArrayList pages)
	{
		method_0(id, (Class4974)pages[0]);
	}

	public void method_0(string id, Class4974 pv)
	{
		if (string_0.Equals(id) && pv != null)
		{
			bool_0 = true;
			if (class4942_0 != null)
			{
				Class5757.Class5759 prop = new Class5757.Class5759(pv.method_19(), string_0);
				class4942_0.method_29(Class5757.int_0, prop);
				class4942_0 = null;
			}
			method_2(id, pv);
		}
	}

	public void method_1(Interface160 dependent)
	{
		if (arrayList_0 == null)
		{
			arrayList_0 = new ArrayList();
		}
		arrayList_0.Add(dependent);
	}

	private void method_2(string id, Class4974 pv)
	{
		if (arrayList_0 == null)
		{
			return;
		}
		ArrayList arrayList = new ArrayList();
		arrayList.Add(pv);
		foreach (Interface160 item in arrayList_0)
		{
			item.imethod_4(id, arrayList);
		}
	}
}
