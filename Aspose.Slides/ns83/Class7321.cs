using System.Collections;
using ns82;

namespace ns83;

internal class Class7321
{
	internal class Class7213 : Class7211
	{
		public string string_0;

		public bool bool_0;

		public Class7213(Interface392 payload)
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

	internal class Class7214 : Class7213
	{
		public Class7214(Interface392 payload)
			: base(payload)
		{
		}
	}

	public interface Interface390
	{
		void imethod_0(object t, object parent, int childIndex, IDictionary labels);
	}

	public abstract class Class7322 : Interface390
	{
		public void imethod_0(object t, object parent, int childIndex, IDictionary labels)
		{
			vmethod_0(t);
		}

		public abstract void vmethod_0(object t);
	}

	private sealed class Class7323 : Class7322
	{
		private IList ilist_0;

		public Class7323(IList list)
		{
			ilist_0 = list;
		}

		public override void vmethod_0(object t)
		{
			ilist_0.Add(t);
		}
	}

	private sealed class Class7324 : Interface390
	{
		private Class7321 class7321_0;

		private Class7213 class7213_0;

		private IList ilist_0;

		public Class7324(Class7321 owner, Class7213 pattern, IList list)
		{
			class7321_0 = owner;
			class7213_0 = pattern;
			ilist_0 = list;
		}

		public void imethod_0(object t, object parent, int childIndex, IDictionary labels)
		{
			if (class7321_0.method_10(t, class7213_0, null))
			{
				ilist_0.Add(t);
			}
		}
	}

	private sealed class Class7325 : Interface390
	{
		private Class7321 class7321_0;

		private Class7213 class7213_0;

		private Interface390 interface390_0;

		private Hashtable hashtable_0 = new Hashtable();

		public Class7325(Class7321 owner, Class7213 pattern, Interface390 visitor)
		{
			class7321_0 = owner;
			class7213_0 = pattern;
			interface390_0 = visitor;
		}

		public void imethod_0(object t, object parent, int childIndex, IDictionary unusedlabels)
		{
			hashtable_0.Clear();
			if (class7321_0.method_10(t, class7213_0, hashtable_0))
			{
				interface390_0.imethod_0(t, parent, childIndex, hashtable_0);
			}
		}
	}

	private class Class7218 : Class7217
	{
		public override object imethod_0(Interface392 payload)
		{
			return new Class7213(payload);
		}
	}

	protected Interface387 interface387_0;

	protected IDictionary idictionary_0;

	public Class7321(Interface387 adaptor)
	{
		interface387_0 = adaptor;
	}

	public Class7321(Interface387 adaptor, IDictionary tokenNameToTypeMap)
	{
		interface387_0 = adaptor;
		idictionary_0 = tokenNameToTypeMap;
	}

	public Class7321(Interface387 adaptor, string[] tokenNames)
	{
		interface387_0 = adaptor;
		idictionary_0 = smethod_0(tokenNames);
	}

	public Class7321(string[] tokenNames)
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
		for (int i = Class7346.int_6; i < tokenNames.Length; i++)
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
			int num = interface387_0.imethod_14(t);
			IList list = m[num] as IList;
			if (list == null)
			{
				list = new ArrayList();
				m[num] = list;
			}
			list.Add(t);
			int num2 = interface387_0.imethod_25(t);
			for (int i = 0; i < num2; i++)
			{
				object t2 = interface387_0.imethod_22(t, i);
				method_2(t2, m);
			}
		}
	}

	public IList method_3(object t, int ttype)
	{
		IList list = new ArrayList();
		method_5(t, ttype, new Class7323(list));
		return list;
	}

	public IList method_4(object t, string pattern)
	{
		IList list = new ArrayList();
		Class7232 tokenizer = new Class7232(pattern);
		Class7233 @class = new Class7233(tokenizer, this, new Class7218());
		Class7213 class2 = (Class7213)@class.method_0();
		if (class2 != null && !class2.IsNil && !(class2.GetType() == typeof(Class7214)))
		{
			int type = class2.Type;
			method_5(t, type, new Class7324(this, class2, list));
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

	public void method_5(object t, int ttype, Interface390 visitor)
	{
		method_6(t, null, 0, ttype, visitor);
	}

	protected void method_6(object t, object parent, int childIndex, int ttype, Interface390 visitor)
	{
		if (t != null)
		{
			if (interface387_0.imethod_14(t) == ttype)
			{
				visitor.imethod_0(t, parent, childIndex, null);
			}
			int num = interface387_0.imethod_25(t);
			for (int i = 0; i < num; i++)
			{
				object t2 = interface387_0.imethod_22(t, i);
				method_6(t2, t, i, ttype, visitor);
			}
		}
	}

	public void method_7(object t, string pattern, Interface390 visitor)
	{
		Class7232 tokenizer = new Class7232(pattern);
		Class7233 @class = new Class7233(tokenizer, this, new Class7218());
		Class7213 class2 = (Class7213)@class.method_0();
		if (class2 != null && !class2.IsNil && !(class2.GetType() == typeof(Class7214)))
		{
			int type = class2.Type;
			method_5(t, type, new Class7325(this, class2, visitor));
		}
	}

	public bool method_8(object t, string pattern, IDictionary labels)
	{
		Class7232 tokenizer = new Class7232(pattern);
		Class7233 @class = new Class7233(tokenizer, this, new Class7218());
		Class7213 t2 = (Class7213)@class.method_0();
		return method_10(t, t2, labels);
	}

	public bool method_9(object t, string pattern)
	{
		return method_8(t, pattern, null);
	}

	private bool method_10(object t1, Class7213 t2, IDictionary labels)
	{
		if (t1 != null && t2 != null)
		{
			if (t2.GetType() != typeof(Class7214))
			{
				if (interface387_0.imethod_14(t1) != t2.Type)
				{
					return false;
				}
				if (t2.bool_0 && !interface387_0.imethod_16(t1).Equals(t2.Text))
				{
					return false;
				}
			}
			if (t2.string_0 != null && labels != null)
			{
				labels[t2.string_0] = t1;
			}
			int num = interface387_0.imethod_25(t1);
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
					object t3 = interface387_0.imethod_22(t1, num2);
					Class7213 t4 = (Class7213)t2.imethod_1(num2);
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
		Class7232 tokenizer = new Class7232(pattern);
		Class7233 @class = new Class7233(tokenizer, this, interface387_0);
		return @class.method_0();
	}

	public static bool Equals(object t1, object t2, Interface387 adaptor)
	{
		return smethod_3(t1, t2, adaptor);
	}

	public new bool Equals(object t1, object t2)
	{
		return smethod_3(t1, t2, interface387_0);
	}

	protected static bool smethod_3(object t1, object t2, Interface387 adaptor)
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
