using System;
using System.Collections;

namespace ns311;

internal class Class7127 : Interface379
{
	internal Hashtable hashtable_0 = new Hashtable();

	internal int[] int_0;

	internal int int_1;

	internal string string_0;

	internal Hashtable hashtable_1 = new Hashtable();

	internal ArrayList arrayList_0 = new ArrayList();

	internal static int int_2 = 2;

	internal static int int_3 = 3;

	internal static int int_4 = 1;

	internal static int int_5 = 0;

	private int int_6;

	private int int_7;

	public virtual string String
	{
		set
		{
			string_0 = value;
			method_0();
		}
	}

	public virtual string StringIter
	{
		set
		{
			method_0();
		}
	}

	public virtual Hashtable AllAttributeKeys => hashtable_1;

	public virtual IDictionary Attributes => (IDictionary)arrayList_0[int_1];

	public virtual int RunBounds
	{
		get
		{
			int num = int_1;
			do
			{
				num++;
			}
			while (int_0[num] == int_4);
			return num;
		}
	}

	public virtual int Start
	{
		get
		{
			int num = int_1;
			while (int_0[num] == int_4)
			{
				num--;
			}
			return num;
		}
	}

	public virtual int BeginIndex => int_6;

	public virtual int EndIndex => int_7;

	public virtual int Index
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	public Class7127()
	{
	}

	public Class7127(string name)
	{
		if (!AllAttributeKeys.ContainsKey(name))
		{
			AllAttributeKeys.Add(name, string.Empty);
		}
		string_0 = string.Empty;
		method_0();
	}

	public Class7127(Class7127 iterator)
	{
		method_1(iterator);
	}

	public virtual void vmethod_0(Class7127 iterator, object[] collection, int start, int end)
	{
		start = Math.Max(start, 0);
		end = Math.Min(end, string_0.Length);
		if (int_0[start] == int_3)
		{
			if (int_0[start - 1] == int_4)
			{
				int_0[start - 1] = int_3;
			}
			else
			{
				int_0[start - 1] = int_5;
			}
		}
		if (int_0[end + 1] == int_3)
		{
			int_0[end + 1] = int_5;
		}
		else if (int_0[end + 1] == int_4)
		{
			int_0[end + 1] = int_2;
		}
		for (int i = start; i <= end; i++)
		{
			int_0[i] = int_5;
			int num = Math.Min(i, collection.Length - 1);
			((IDictionary)arrayList_0[i]).Add(iterator, collection[num]);
		}
	}

	public virtual object vmethod_1(string attribute)
	{
		if (hashtable_1.ContainsKey(attribute))
		{
			return hashtable_1[attribute];
		}
		return null;
	}

	public virtual int imethod_3(Class7127 attribute)
	{
		int num = int_1;
		object obj = Attributes[attribute];
		if (obj == null)
		{
			do
			{
				num++;
			}
			while (((IDictionary)arrayList_0[num])[attribute] == null);
		}
		else
		{
			do
			{
				num++;
			}
			while (obj.Equals(((IDictionary)arrayList_0[num])[attribute]));
		}
		return num;
	}

	public virtual int imethod_4(Hashtable attributes)
	{
		int num = int_1;
		do
		{
			num++;
		}
		while (attributes.Equals(arrayList_0[num]));
		return num;
	}

	public virtual int imethod_5(Class7127 attribute)
	{
		int num = int_1 - 1;
		object obj = Attributes[attribute];
		try
		{
			if (obj == null)
			{
				while (((IDictionary)arrayList_0[num - 1])[attribute] == null)
				{
					num--;
				}
			}
			else
			{
				while (obj.Equals(((IDictionary)arrayList_0[num - 1])[attribute]))
				{
					num--;
				}
			}
		}
		catch (IndexOutOfRangeException ex)
		{
			_ = ex.Message;
		}
		return num;
	}

	public virtual int imethod_6(Hashtable attributes)
	{
		int num = int_1;
		try
		{
			while (attributes.Equals(arrayList_0[num - 1]))
			{
				num--;
			}
		}
		catch (IndexOutOfRangeException ex)
		{
			_ = ex.Message;
		}
		return num;
	}

	public virtual char imethod_7()
	{
		return (char)hashtable_0[int_1];
	}

	private void method_0()
	{
		hashtable_1 = new Hashtable();
		arrayList_0 = new ArrayList();
		for (int i = 0; i < string_0.Length; i++)
		{
			arrayList_0.Add(new Hashtable());
		}
		int_0 = new int[string_0.Length];
		for (int j = 0; j < int_0.Length; j++)
		{
			int_0[j] = int_5;
		}
	}

	private void method_1(Class7127 iterator)
	{
		hashtable_1 = iterator.AllAttributeKeys;
		int num = iterator.EndIndex - iterator.BeginIndex;
		arrayList_0 = new ArrayList(num);
		int_0 = new int[num];
		char c = iterator.imethod_8();
		char[] array = new char[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = c;
			int_0[i] = int_5;
			arrayList_0[i] = new Hashtable(iterator.Attributes);
			c = iterator.imethod_1();
		}
		string_0 = new string(array);
	}

	public virtual char imethod_8()
	{
		if (AllAttributeKeys.Count > 0)
		{
			return (char)AllAttributeKeys[0];
		}
		return '\0';
	}

	public virtual char imethod_0()
	{
		return (char)hashtable_0[hashtable_0.Count - 1];
	}

	public virtual char imethod_1()
	{
		if (int_1 + 1 <= hashtable_0.Count - 1)
		{
			return (char)hashtable_0[int_1 + 1];
		}
		return (char)hashtable_0[int_1];
	}

	public virtual char imethod_2()
	{
		if (int_1 - 1 >= 1)
		{
			return (char)hashtable_0[int_1 - 1];
		}
		return (char)hashtable_0[0];
	}

	public virtual char imethod_9(int position)
	{
		int_1 = position;
		if (hashtable_0.Count - 1 >= position && position >= 0)
		{
			return (char)hashtable_0[position];
		}
		return ' ';
	}
}
