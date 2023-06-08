using System;
using System.Collections;
using System.Text;

namespace ns96;

internal sealed class Class7205 : ICollection, IEnumerable, IDictionary
{
	private sealed class Class7206 : IEnumerator, IDictionaryEnumerator
	{
		internal enum Enum980
		{
			const_0,
			const_1,
			const_2
		}

		private Class7205 class7205_0;

		private ArrayList arrayList_0;

		private Enum980 enum980_0;

		private int int_0;

		private int int_1;

		private object object_0;

		private object object_1;

		public object Key
		{
			get
			{
				if (object_0 == null)
				{
					throw new InvalidOperationException("Enumeration has either not started or has already finished.");
				}
				return object_0;
			}
		}

		public object Value
		{
			get
			{
				if (object_0 == null)
				{
					throw new InvalidOperationException("Enumeration has either not started or has already finished.");
				}
				return object_1;
			}
		}

		public DictionaryEntry Entry
		{
			get
			{
				if (object_0 == null)
				{
					throw new InvalidOperationException("Enumeration has either not started or has already finished.");
				}
				return new DictionaryEntry(object_0, object_1);
			}
		}

		public object Current
		{
			get
			{
				if (object_0 == null)
				{
					throw new InvalidOperationException("Enumeration has either not started or has already finished.");
				}
				if (enum980_0 == Enum980.const_0)
				{
					return object_0;
				}
				if (enum980_0 == Enum980.const_1)
				{
					return object_1;
				}
				return new DictionaryEntry(object_0, object_1);
			}
		}

		internal Class7206()
		{
			int_0 = 0;
			object_0 = null;
			object_1 = null;
		}

		internal Class7206(Class7205 hashList, Enum980 mode)
		{
			class7205_0 = hashList;
			enum980_0 = mode;
			int_1 = hashList.int_0;
			arrayList_0 = hashList.arrayList_0;
			int_0 = 0;
			object_0 = null;
			object_1 = null;
		}

		public void Reset()
		{
			if (int_1 != class7205_0.int_0)
			{
				throw new InvalidOperationException("Collection was modified; enumeration operation may not execute.");
			}
			int_0 = 0;
			object_0 = null;
			object_1 = null;
		}

		public bool MoveNext()
		{
			if (int_1 != class7205_0.int_0)
			{
				throw new InvalidOperationException("Collection was modified; enumeration operation may not execute.");
			}
			if (int_0 < arrayList_0.Count)
			{
				object_0 = arrayList_0[int_0];
				object_1 = class7205_0[object_0];
				int_0++;
				return true;
			}
			object_0 = null;
			return false;
		}
	}

	private sealed class Class7207 : ICollection, IEnumerable
	{
		private Class7205 class7205_0;

		public bool IsSynchronized => class7205_0.IsSynchronized;

		public int Count => class7205_0.Count;

		public object SyncRoot => class7205_0.SyncRoot;

		internal Class7207()
		{
		}

		internal Class7207(Class7205 hashList)
		{
			class7205_0 = hashList;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("[");
			ArrayList arrayList_ = class7205_0.arrayList_0;
			for (int i = 0; i < arrayList_.Count; i++)
			{
				if (i > 0)
				{
					stringBuilder.Append(", ");
				}
				stringBuilder.Append(arrayList_[i]);
			}
			stringBuilder.Append("]");
			return stringBuilder.ToString();
		}

		public override bool Equals(object o)
		{
			if (o is Class7207 @class)
			{
				if (Count == 0 && @class.Count == 0)
				{
					return true;
				}
				if (Count == @class.Count)
				{
					for (int i = 0; i < Count; i++)
					{
						if (class7205_0.arrayList_0[i] == @class.class7205_0.arrayList_0[i] || class7205_0.arrayList_0[i].Equals(@class.class7205_0.arrayList_0[i]))
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		public override int GetHashCode()
		{
			return class7205_0.arrayList_0.GetHashCode();
		}

		public void CopyTo(Array array, int index)
		{
			class7205_0.method_0(array, index);
		}

		public IEnumerator GetEnumerator()
		{
			return new Class7206(class7205_0, Class7206.Enum980.const_0);
		}
	}

	private sealed class Class7208 : ICollection, IEnumerable
	{
		private Class7205 class7205_0;

		public bool IsSynchronized => class7205_0.IsSynchronized;

		public int Count => class7205_0.Count;

		public object SyncRoot => class7205_0.SyncRoot;

		internal Class7208()
		{
		}

		internal Class7208(Class7205 hashList)
		{
			class7205_0 = hashList;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("[");
			IEnumerator enumerator = new Class7206(class7205_0, Class7206.Enum980.const_1);
			if (enumerator.MoveNext())
			{
				stringBuilder.Append((enumerator.Current == null) ? "null" : enumerator.Current);
				while (enumerator.MoveNext())
				{
					stringBuilder.Append(", ");
					stringBuilder.Append((enumerator.Current == null) ? "null" : enumerator.Current);
				}
			}
			stringBuilder.Append("]");
			return stringBuilder.ToString();
		}

		public void CopyTo(Array array, int index)
		{
			class7205_0.method_1(array, index);
		}

		public IEnumerator GetEnumerator()
		{
			return new Class7206(class7205_0, Class7206.Enum980.const_1);
		}
	}

	private Hashtable hashtable_0 = new Hashtable();

	private ArrayList arrayList_0 = new ArrayList();

	private int int_0;

	public bool IsReadOnly => hashtable_0.IsReadOnly;

	public object this[object key]
	{
		get
		{
			return hashtable_0[key];
		}
		set
		{
			bool flag = !hashtable_0.Contains(key);
			hashtable_0[key] = value;
			if (flag)
			{
				arrayList_0.Add(key);
			}
			int_0++;
		}
	}

	public ICollection Values => new Class7208(this);

	public ICollection Keys => new Class7207(this);

	public bool IsFixedSize => hashtable_0.IsFixedSize;

	public bool IsSynchronized => hashtable_0.IsSynchronized;

	public int Count => hashtable_0.Count;

	public object SyncRoot => hashtable_0.SyncRoot;

	public Class7205()
		: this(-1)
	{
	}

	public Class7205(int capacity)
	{
		if (capacity < 0)
		{
			hashtable_0 = new Hashtable();
			arrayList_0 = new ArrayList();
		}
		else
		{
			hashtable_0 = new Hashtable(capacity);
			arrayList_0 = new ArrayList(capacity);
		}
		int_0 = 0;
	}

	public IDictionaryEnumerator GetEnumerator()
	{
		return new Class7206(this, Class7206.Enum980.const_2);
	}

	public void Remove(object key)
	{
		hashtable_0.Remove(key);
		arrayList_0.Remove(key);
		int_0++;
	}

	public bool Contains(object key)
	{
		return hashtable_0.Contains(key);
	}

	public void Clear()
	{
		hashtable_0.Clear();
		arrayList_0.Clear();
		int_0++;
	}

	public void Add(object key, object value)
	{
		hashtable_0.Add(key, value);
		arrayList_0.Add(key);
		int_0++;
	}

	public void CopyTo(Array array, int index)
	{
		int count = arrayList_0.Count;
		for (int i = 0; i < count; i++)
		{
			DictionaryEntry dictionaryEntry = new DictionaryEntry(arrayList_0[i], hashtable_0[arrayList_0[i]]);
			array.SetValue(dictionaryEntry, index++);
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new Class7206(this, Class7206.Enum980.const_2);
	}

	private void method_0(Array array, int index)
	{
		int count = arrayList_0.Count;
		for (int i = 0; i < count; i++)
		{
			array.SetValue(arrayList_0[i], index++);
		}
	}

	private void method_1(Array array, int index)
	{
		int count = arrayList_0.Count;
		for (int i = 0; i < count; i++)
		{
			array.SetValue(hashtable_0[arrayList_0[i]], index++);
		}
	}
}
