using System.Collections;
using ns82;

namespace ns83;

internal class Class4380
{
	internal class Class4365 : Class4363
	{
		public string string_0;

		public bool bool_0;

		public Class4365(Interface86 payload)
			: base(payload)
		{
		}

		public override string ToString()
		{
			if (string_0 != null)
			{
				return "%" + string_0 + ":" + base.ToString();
			}
			return base.ToString();
		}
	}

	internal class Class4366 : Class4365
	{
		public Class4366(Interface86 payload)
			: base(payload)
		{
		}
	}

	public interface Interface109
	{
		void imethod_0(object t, object parent, int childIndex, IDictionary labels);
	}

	public abstract class Class4381 : Interface109
	{
		public void imethod_0(object t, object parent, int childIndex, IDictionary labels)
		{
			vmethod_0(t);
		}

		public abstract void vmethod_0(object t);
	}

	private sealed class Class4382 : Class4381
	{
		private IList ilist_0;

		public Class4382(IList list)
		{
			ilist_0 = list;
		}

		public override void vmethod_0(object t)
		{
			ilist_0.Add(t);
		}
	}

	private sealed class Class4383 : Interface109
	{
		private Class4380 class4380_0;

		private Class4365 class4365_0;

		private IList ilist_0;

		public Class4383(Class4380 owner, Class4365 pattern, IList list)
		{
			class4380_0 = owner;
			class4365_0 = pattern;
			ilist_0 = list;
		}

		public void imethod_0(object t, object parent, int childIndex, IDictionary labels)
		{
			if (class4380_0.method_10(t, class4365_0, null))
			{
				ilist_0.Add(t);
			}
		}
	}

	private sealed class Class4384 : Interface109
	{
		private Class4380 class4380_0;

		private Class4365 class4365_0;

		private Interface109 interface109_0;

		private Hashtable hashtable_0 = new Hashtable();

		public Class4384(Class4380 owner, Class4365 pattern, Interface109 visitor)
		{
			class4380_0 = owner;
			class4365_0 = pattern;
			interface109_0 = visitor;
		}

		public void imethod_0(object t, object parent, int childIndex, IDictionary unusedlabels)
		{
			hashtable_0.Clear();
			if (class4380_0.method_10(t, class4365_0, hashtable_0))
			{
				interface109_0.imethod_0(t, parent, childIndex, hashtable_0);
			}
		}
	}

	private class Class4370 : Class4369
	{
		public override object imethod_0(Interface86 payload)
		{
			return new Class4365(payload);
		}
	}

	protected Interface106 interface106_0;

	protected IDictionary idictionary_0;

	public Class4380(Interface106 adaptor)
	{
		interface106_0 = adaptor;
	}

	public Class4380(Interface106 adaptor, IDictionary tokenNameToTypeMap)
	{
		interface106_0 = adaptor;
		idictionary_0 = tokenNameToTypeMap;
	}

	public Class4380(Interface106 adaptor, string[] tokenNames)
	{
		interface106_0 = adaptor;
		idictionary_0 = smethod_0(tokenNames);
	}

	public Class4380(string[] tokenNames)
		: this(null, tokenNames)
	{
	}

	public static IDictionary smethod_0(string[] tokenNames)
	{
		IDictionary dictionary = new Hashtable();
		if (tokenNames == null)
		{
			return dictionary;
		}
		for (int i = Class4398.int_6; i < tokenNames.Length; i++)
		{
			string key = tokenNames[i];
			dictionary.Add(key, i);
		}
		return dictionary;
	}

	public int method_0(string tokenName)
	{
		if (idictionary_0 == null)
		{
			return 0;
		}
		object obj = idictionary_0[tokenName];
		if (obj != null)
		{
			return (int)obj;
		}
		return 0;
	}

	public IDictionary method_1(object t)
	{
		IDictionary dictionary = new Hashtable();
		method_2(t, dictionary);
		return dictionary;
	}

	protected void method_2(object t, IDictionary m)
	{
		if (t != null)
		{
			int num = interface106_0.imethod_14(t);
			IList list = m[num] as IList;
			if (list == null)
			{
				list = new ArrayList();
				m[num] = list;
			}
			list.Add(t);
			int num2 = interface106_0.imethod_25(t);
			for (int i = 0; i < num2; i++)
			{
				object t2 = interface106_0.imethod_22(t, i);
				method_2(t2, m);
			}
		}
	}

	public IList method_3(object t, int ttype)
	{
		IList list = new ArrayList();
		method_5(t, ttype, new Class4382(list));
		return list;
	}

	public IList method_4(object t, string pattern)
	{
		IList list = new ArrayList();
		Class4378 tokenizer = new Class4378(pattern);
		Class4379 @class = new Class4379(tokenizer, this, new Class4370());
		Class4365 class2 = (Class4365)@class.method_0();
		if (class2 != null && !class2.IsNil && !(class2.GetType() == typeof(Class4366)))
		{
			int type = class2.Type;
			method_5(t, type, new Class4383(this, class2, list));
			return list;
		}
		return null;
	}

	public static object smethod_1(object t, int ttype)
	{
		return null;
	}

	public static object smethod_2(object t, string pattern)
	{
		return null;
	}

	public void method_5(object t, int ttype, Interface109 visitor)
	{
		method_6(t, null, 0, ttype, visitor);
	}

	protected void method_6(object t, object parent, int childIndex, int ttype, Interface109 visitor)
	{
		if (t != null)
		{
			if (interface106_0.imethod_14(t) == ttype)
			{
				visitor.imethod_0(t, parent, childIndex, null);
			}
			int num = interface106_0.imethod_25(t);
			for (int i = 0; i < num; i++)
			{
				object t2 = interface106_0.imethod_22(t, i);
				method_6(t2, t, i, ttype, visitor);
			}
		}
	}

	public void method_7(object t, string pattern, Interface109 visitor)
	{
		Class4378 tokenizer = new Class4378(pattern);
		Class4379 @class = new Class4379(tokenizer, this, new Class4370());
		Class4365 class2 = (Class4365)@class.method_0();
		if (class2 != null && !class2.IsNil && !(class2.GetType() == typeof(Class4366)))
		{
			int type = class2.Type;
			method_5(t, type, new Class4384(this, class2, visitor));
		}
	}

	public bool method_8(object t, string pattern, IDictionary labels)
	{
		Class4378 tokenizer = new Class4378(pattern);
		Class4379 @class = new Class4379(tokenizer, this, new Class4370());
		Class4365 t2 = (Class4365)@class.method_0();
		return method_10(t, t2, labels);
	}

	public bool method_9(object t, string pattern)
	{
		return method_8(t, pattern, null);
	}

	private bool method_10(object t1, Class4365 t2, IDictionary labels)
	{
		if (t1 != null && t2 != null)
		{
			if (t2.GetType() != typeof(Class4366))
			{
				if (interface106_0.imethod_14(t1) != t2.Type)
				{
					return false;
				}
				if (t2.bool_0 && !interface106_0.imethod_16(t1).Equals(t2.Text))
				{
					return false;
				}
			}
			if (t2.string_0 != null && labels != null)
			{
				labels[t2.string_0] = t1;
			}
			int num = interface106_0.imethod_25(t1);
			int childCount = t2.ChildCount;
			if (num != childCount)
			{
				return false;
			}
			int num2 = 0;
			while (true)
			{
				if (num2 < num)
				{
					object t3 = interface106_0.imethod_22(t1, num2);
					Class4365 t4 = (Class4365)t2.imethod_1(num2);
					if (!method_10(t3, t4, labels))
					{
						break;
					}
					num2++;
					continue;
				}
				return true;
			}
			return false;
		}
		return false;
	}

	public object method_11(string pattern)
	{
		Class4378 tokenizer = new Class4378(pattern);
		Class4379 @class = new Class4379(tokenizer, this, interface106_0);
		return @class.method_0();
	}

	public static bool Equals(object t1, object t2, Interface106 adaptor)
	{
		return smethod_3(t1, t2, adaptor);
	}

	public new bool Equals(object t1, object t2)
	{
		return smethod_3(t1, t2, interface106_0);
	}

	protected static bool smethod_3(object t1, object t2, Interface106 adaptor)
	{
		if (t1 != null && t2 != null)
		{
			if (adaptor.imethod_14(t1) != adaptor.imethod_14(t2))
			{
				return false;
			}
			if (!adaptor.imethod_16(t1).Equals(adaptor.imethod_16(t2)))
			{
				return false;
			}
			int num = adaptor.imethod_25(t1);
			int num2 = adaptor.imethod_25(t2);
			if (num != num2)
			{
				return false;
			}
			int num3 = 0;
			while (true)
			{
				if (num3 < num)
				{
					object t3 = adaptor.imethod_22(t1, num3);
					object t4 = adaptor.imethod_22(t2, num3);
					if (!smethod_3(t3, t4, adaptor))
					{
						break;
					}
					num3++;
					continue;
				}
				return true;
			}
			return false;
		}
		return false;
	}
}
