using System;
using System.Collections;
using System.Collections.Generic;

namespace ns237;

internal class Class6551 : ICollection, IEnumerable
{
	private class Class6552
	{
		private Enum872 enum872_0;

		private readonly string string_0;

		private int int_0 = -1;

		public string Name => string_0;

		public Enum872 Rule
		{
			get
			{
				return enum872_0;
			}
			set
			{
				enum872_0 = value;
			}
		}

		public Class6552(string name, Enum872 rule)
		{
			Rule = rule;
			string_0 = name;
		}

		public bool Equals(string fontName)
		{
			return GetHashCode() == fontName.ToUpper().GetHashCode();
		}

		public override bool Equals(object obj)
		{
			Class6552 @class = obj as Class6552;
			if (object.ReferenceEquals(null, @class))
			{
				return false;
			}
			if (object.ReferenceEquals(this, @class))
			{
				return true;
			}
			return GetHashCode() == @class.GetHashCode();
		}

		public override int GetHashCode()
		{
			if (int_0 == -1)
			{
				int_0 = Name.ToUpper().GetHashCode();
			}
			return int_0;
		}
	}

	private List<Class6552> list_0 = new List<Class6552>();

	public Enum872 this[string name]
	{
		get
		{
			return method_1(name).Rule;
		}
		set
		{
			method_0(name, value);
		}
	}

	public int Count => list_0.Count;

	object ICollection.SyncRoot => ((ICollection)list_0).SyncRoot;

	bool ICollection.IsSynchronized => ((ICollection)list_0).IsSynchronized;

	public void Add(string name, Enum872 rule)
	{
		Add(new Class6552(name, rule));
	}

	public void Remove(string name)
	{
		Class6552 @class = method_1(name);
		if (@class != null)
		{
			list_0.Remove(@class);
		}
	}

	public bool Contains(string name)
	{
		return method_1(name) != null;
	}

	private void Add(Class6552 fontException)
	{
		list_0.Add(fontException);
	}

	private void method_0(string name, Enum872 rule)
	{
		Class6552 @class = method_1(name);
		if (@class == null)
		{
			Add(name, rule);
		}
		else
		{
			@class.Rule = rule;
		}
	}

	private Class6552 method_1(string name)
	{
		foreach (Class6552 item in list_0)
		{
			if (item.Equals(name))
			{
				return item;
			}
		}
		return null;
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	void ICollection.CopyTo(Array array, int index)
	{
		((ICollection)list_0).CopyTo(array, index);
	}
}
