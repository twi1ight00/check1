using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace ns302;

internal class Class6911 : IEnumerable
{
	public class Class6912 : IEnumerator
	{
		private int int_0;

		private List<Class6908> list_0;

		public Class6908 Current => list_0[int_0];

		object IEnumerator.Current => Current;

		internal Class6912(List<Class6908> items)
		{
			list_0 = items;
			int_0 = -1;
		}

		public void Reset()
		{
			int_0 = -1;
		}

		public bool MoveNext()
		{
			int_0++;
			return int_0 < list_0.Count;
		}
	}

	private List<Class6908> list_0 = new List<Class6908>();

	private Class6908 class6908_0;

	public int Count => list_0.Count;

	public Class6908 this[int index] => list_0[index];

	public int this[Class6908 node]
	{
		get
		{
			int num = method_1(node);
			if (num == -1)
			{
				throw new ArgumentOutOfRangeException("node", string.Format(CultureInfo.InvariantCulture, "Node \"{0}\" was not found in the collection", new object[1] { node.OuterHtml }));
			}
			return num;
		}
	}

	internal Class6911(Class6908 parentnode)
	{
		class6908_0 = parentnode;
	}

	internal void Remove(int index)
	{
		Class6908 @class = null;
		Class6908 class2 = null;
		Class6908 class3 = list_0[index];
		if (index > 0)
		{
			class2 = list_0[index - 1];
		}
		if (index < list_0.Count - 1)
		{
			@class = list_0[index + 1];
		}
		list_0.RemoveAt(index);
		if (class2 != null)
		{
			if (@class == class2)
			{
				throw new InvalidProgramException("Unexpected error.");
			}
			class2.class6908_0 = @class;
		}
		if (@class != null)
		{
			@class.class6908_1 = class2;
		}
		class3.class6908_1 = null;
		class3.class6908_0 = null;
		class3.class6908_2 = null;
	}

	internal void method_0(Class6908 node)
	{
		Class6908 @class = null;
		if (list_0.Count > 0)
		{
			@class = list_0[list_0.Count - 1];
		}
		list_0.Add(node);
		node.class6908_1 = @class;
		node.class6908_0 = null;
		node.class6908_2 = class6908_0;
		if (@class != null)
		{
			if (@class == node)
			{
				throw new InvalidProgramException("Unexpected error.");
			}
			@class.class6908_0 = node;
		}
	}

	internal int method_1(Class6908 node)
	{
		int num = 0;
		while (true)
		{
			if (num < list_0.Count)
			{
				if (node == list_0[num])
				{
					break;
				}
				num++;
				continue;
			}
			return -1;
		}
		return num;
	}

	public Class6912 GetEnumerator()
	{
		return new Class6912(list_0);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
