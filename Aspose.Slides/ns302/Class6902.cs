using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using ns301;

namespace ns302;

internal class Class6902 : IEnumerable
{
	public class Class6903 : IEnumerator
	{
		private int int_0;

		private IList<Class6901> ilist_0;

		public Class6901 Current => ilist_0[int_0];

		object IEnumerator.Current => Current;

		internal Class6903(IList<Class6901> items)
		{
			ilist_0 = items;
			int_0 = -1;
		}

		public void Reset()
		{
			int_0 = -1;
		}

		public bool MoveNext()
		{
			int_0++;
			return int_0 < ilist_0.Count;
		}
	}

	internal Hashtable hashtable_0 = new Hashtable();

	private List<Class6901> list_0 = new List<Class6901>();

	private Class6908 class6908_0;

	public int Count => list_0.Count;

	public Class6901 this[string name]
	{
		get
		{
			Class6892.smethod_0(name, "name");
			return hashtable_0[name.ToLower(CultureInfo.InvariantCulture)] as Class6901;
		}
	}

	public Class6901 this[int index] => list_0[index];

	internal Class6902(Class6908 ownernode)
	{
		class6908_0 = ownernode;
	}

	public Class6901 method_0(Class6901 newAttribute)
	{
		Class6892.smethod_0(newAttribute, "newAttribute");
		hashtable_0[newAttribute.Name] = newAttribute;
		list_0.Add(newAttribute);
		class6908_0.bool_1 = true;
		class6908_0.bool_2 = true;
		return newAttribute;
	}

	public Class6903 GetEnumerator()
	{
		return new Class6903(list_0);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
