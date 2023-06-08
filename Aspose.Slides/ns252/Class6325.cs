using System.Collections;

namespace ns252;

internal class Class6325 : Interface276
{
	private Interface277 interface277_0;

	private Hashtable hashtable_0 = new Hashtable();

	public Interface277 ParentBagProvider
	{
		get
		{
			return interface277_0;
		}
		set
		{
			interface277_0 = value;
		}
	}

	public object imethod_0(object key)
	{
		if (key == null)
		{
			return null;
		}
		object obj = hashtable_0[key];
		if (obj == null && ParentBagProvider != null)
		{
			Interface276 parentBag = ParentBagProvider.ParentBag;
			if (parentBag != null)
			{
				return parentBag.imethod_0(key);
			}
		}
		return obj;
	}

	public void imethod_1(object key, object value)
	{
		if (key != null)
		{
			hashtable_0[key] = value;
		}
	}
}
