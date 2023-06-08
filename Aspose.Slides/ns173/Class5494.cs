using System.Collections;

namespace ns173;

internal class Class5494
{
	private Hashtable hashtable_0 = new Hashtable();

	private Hashtable hashtable_1 = new Hashtable();

	private ArrayList arrayList_0 = new ArrayList();

	private ArrayList arrayList_1 = new ArrayList();

	public void method_0(string id, Class4974 pv)
	{
		ArrayList arrayList = (ArrayList)hashtable_0[id];
		if (arrayList == null)
		{
			arrayList = new ArrayList();
			hashtable_0.Add(id, arrayList);
			arrayList.Add(pv);
			pv.method_20(id);
			if (!arrayList_0.Contains(id))
			{
				method_4(id, arrayList);
			}
		}
		else if (!arrayList.Contains(pv))
		{
			arrayList.Add(pv);
		}
	}

	public void method_1(string id)
	{
		arrayList_0.Add(id);
	}

	public void method_2(string id)
	{
		arrayList_1.Add(id);
		if (!arrayList_0.Contains(id))
		{
			return;
		}
		arrayList_0.Remove(id);
		ArrayList pages = (ArrayList)hashtable_0[id];
		ArrayList arrayList = (ArrayList)hashtable_1[id];
		if (arrayList == null)
		{
			return;
		}
		foreach (Interface160 item in arrayList)
		{
			item.imethod_4(id, pages);
		}
		hashtable_1.Remove(id);
	}

	public bool method_3(string id)
	{
		return arrayList_1.Contains(id);
	}

	private void method_4(string id, ArrayList pvList)
	{
		ArrayList arrayList = (ArrayList)hashtable_1[id];
		if (arrayList == null)
		{
			return;
		}
		foreach (Interface160 item in arrayList)
		{
			if (!arrayList_0.Contains(id))
			{
				item.imethod_4(id, pvList);
				continue;
			}
			return;
		}
		arrayList_1.Add(id);
		hashtable_1.Remove(id);
	}

	public void method_5(Class4974 pv)
	{
		string[] array = pv.imethod_3();
		if (array == null)
		{
			return;
		}
		string[] array2 = array;
		foreach (string text in array2)
		{
			ArrayList arrayList = (ArrayList)hashtable_0[text];
			if (arrayList != null && arrayList.Count != 0)
			{
				method_4(text, arrayList);
			}
		}
	}

	public ArrayList method_6(string id)
	{
		if (hashtable_0 != null && hashtable_0.Count != 0)
		{
			ArrayList arrayList = (ArrayList)hashtable_0[id];
			if (arrayList != null)
			{
				return arrayList;
			}
		}
		return new ArrayList();
	}

	public Class4974 method_7(string id)
	{
		ArrayList arrayList = method_6(id);
		if (arrayList != null && arrayList.Count != 0)
		{
			return (Class4974)arrayList[0];
		}
		return null;
	}

	public Class4974 method_8(string id)
	{
		ArrayList arrayList = method_6(id);
		if (arrayList != null && arrayList.Count != 0)
		{
			return (Class4974)arrayList[arrayList.Count - 1];
		}
		return null;
	}

	public void method_9(string idref, Interface160 res)
	{
		ArrayList arrayList = (ArrayList)hashtable_1[idref];
		if (arrayList == null)
		{
			arrayList = new ArrayList();
			hashtable_1.Add(idref, arrayList);
		}
		arrayList.Add(res);
	}
}
