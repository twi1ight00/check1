using System.Collections;
using ns183;
using ns191;

namespace ns173;

internal class Class4941
{
	protected Hashtable hashtable_0;

	protected ArrayList arrayList_0;

	public virtual object vmethod_0(Class4941 ato)
	{
		if (hashtable_0 != null)
		{
			ato.hashtable_0 = (Hashtable)hashtable_0.Clone();
		}
		if (arrayList_0 != null)
		{
			ato.arrayList_0 = (ArrayList)arrayList_0.Clone();
		}
		return ato;
	}

	public void method_0(Class5619 name, string value)
	{
		if (hashtable_0 == null)
		{
			hashtable_0 = new Hashtable();
		}
		hashtable_0.Add(name, value);
	}

	public void method_1(Hashtable atts)
	{
		if (atts == null || atts.Count == 0)
		{
			return;
		}
		foreach (DictionaryEntry att in atts)
		{
			method_0((Class5619)att.Key, (string)att.Value);
		}
	}

	public string method_2(Class5619 name)
	{
		if (hashtable_0 != null)
		{
			return (string)hashtable_0[name];
		}
		return null;
	}

	public Hashtable method_3()
	{
		if (hashtable_0 != null)
		{
			return hashtable_0;
		}
		return new Hashtable();
	}

	private void method_4()
	{
		if (arrayList_0 == null)
		{
			arrayList_0 = new ArrayList();
		}
	}

	public void method_5(Interface239 attachment)
	{
		method_4();
		arrayList_0.Add(attachment);
	}

	public void method_6(ArrayList extensionAttachmentS)
	{
		method_4();
		foreach (object extensionAttachment in extensionAttachmentS)
		{
			arrayList_0.Add(extensionAttachment);
		}
	}

	public ArrayList method_7()
	{
		if (arrayList_0 != null)
		{
			return arrayList_0;
		}
		return new ArrayList();
	}

	public bool method_8()
	{
		if (arrayList_0 != null)
		{
			return arrayList_0.Count > 0;
		}
		return false;
	}
}
