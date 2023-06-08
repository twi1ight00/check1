using System;
using System.Collections;
using System.Collections.Generic;
using ns235;

namespace ns243;

internal abstract class Class6226 : Class6225, IEnumerable, IEnumerator
{
	private readonly List<Class6225> list_0 = new List<Class6225>();

	private int int_0 = -1;

	public virtual int Count => list_0.Count;

	public object Current => list_0[int_0];

	public virtual Class6225 vmethod_4(int index)
	{
		return list_0[index];
	}

	public virtual Class6225 vmethod_5(Class6225 node)
	{
		list_0.Add(node);
		return node;
	}

	public virtual void vmethod_6(Class6225 node)
	{
		list_0.Remove(node);
	}

	public virtual Class6225 vmethod_7(int pos, Class6225 node)
	{
		list_0.Insert(pos, node);
		return node;
	}

	public virtual void RemoveAt(int pos)
	{
		list_0.RemoveAt(pos);
	}

	public virtual void Clear()
	{
		list_0.Clear();
	}

	public IEnumerator GetEnumerator()
	{
		return this;
	}

	public bool MoveNext()
	{
		int_0++;
		if (int_0 >= list_0.Count)
		{
			Reset();
			return false;
		}
		return true;
	}

	public void Reset()
	{
		int_0 = -1;
	}

	public override Class6204[] vmethod_2()
	{
		List<Class6204> list = new List<Class6204>();
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Class6225 @class = (Class6225)enumerator.Current;
				Class6204[] collection = @class.vmethod_2();
				list.AddRange(collection);
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		return list.ToArray();
	}
}
