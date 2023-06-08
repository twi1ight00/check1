using System.Collections;
using ns193;

namespace ns173;

internal class Class4938 : Class4937, Interface160
{
	private ArrayList arrayList_0 = new ArrayList();

	private string string_0;

	private bool bool_0 = true;

	private string string_1;

	private Class4974 class4974_0;

	private Hashtable hashtable_0 = new Hashtable();

	public Class4938(Class5164 bookmarkTree)
	{
		string_1 = null;
		int_4 = 2;
		bool_0 = true;
		for (int i = 0; i < bookmarkTree.method_48().Count; i++)
		{
			Class5162 bookmark = (Class5162)bookmarkTree.method_48()[i];
			method_2(method_8(bookmark));
		}
	}

	public Class4938(Class5162 bookmark)
	{
		string_0 = bookmark.method_48();
		bool_0 = bookmark.method_51();
		string_1 = bookmark.method_49();
	}

	private void method_0(string id, Class4938 bd)
	{
		ArrayList arrayList = (ArrayList)hashtable_0[id];
		if (arrayList == null)
		{
			arrayList = new ArrayList();
			hashtable_0.Add(id, arrayList);
		}
		arrayList.Add(bd);
	}

	public Class4938()
	{
		string_1 = null;
		int_4 = 2;
		bool_0 = true;
	}

	public Class4938(string title, bool showChildren, Class4974 pv, string idRef)
	{
		string_0 = title;
		bool_0 = showChildren;
		class4974_0 = pv;
		string_1 = idRef;
	}

	public string method_1()
	{
		return string_1;
	}

	public void method_2(Class4938 sub)
	{
		arrayList_0.Add(sub);
		if (sub.class4974_0 == null)
		{
			method_0(sub.method_1(), sub);
			string[] array = sub.imethod_3();
			string[] array2 = array;
			foreach (string id in array2)
			{
				method_0(id, sub);
			}
		}
	}

	public string method_3()
	{
		return string_0;
	}

	public bool method_4()
	{
		return bool_0;
	}

	public int method_5()
	{
		return arrayList_0.Count;
	}

	public Class4938 method_6(int count)
	{
		return (Class4938)arrayList_0[count];
	}

	public Class4974 method_7()
	{
		return class4974_0;
	}

	public bool imethod_2()
	{
		if (hashtable_0 != null)
		{
			return hashtable_0.Count == 0;
		}
		return true;
	}

	public string[] imethod_3()
	{
		string[] array = new string[hashtable_0.Keys.Count];
		hashtable_0.Keys.CopyTo(array, 0);
		return array;
	}

	public void imethod_4(string id, ArrayList pages)
	{
		if (id.Equals(string_1))
		{
			class4974_0 = (Class4974)pages[0];
		}
		ArrayList arrayList = (ArrayList)hashtable_0[id];
		if (arrayList != null)
		{
			foreach (Interface160 item in arrayList)
			{
				item.imethod_4(id, pages);
			}
		}
		hashtable_0.Remove(id);
	}

	public override string imethod_1()
	{
		return "Bookmarks";
	}

	private Class4938 method_8(Class5162 bookmark)
	{
		Class4938 @class = new Class4938(bookmark);
		for (int i = 0; i < bookmark.method_52().Count; i++)
		{
			Class5162 bookmark2 = (Class5162)bookmark.method_52()[i];
			@class.method_2(method_8(bookmark2));
		}
		return @class;
	}
}
