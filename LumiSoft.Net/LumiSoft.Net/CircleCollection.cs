using System.Collections.Generic;

namespace LumiSoft.Net;

public class CircleCollection<T>
{
	private Queue<T> m_pItems = null;

	public int Count => m_pItems.Count;

	public CircleCollection()
	{
		m_pItems = new Queue<T>();
	}

	public void Add(T item)
	{
		m_pItems.Enqueue(item);
	}

	public void Clear()
	{
		m_pItems.Clear();
	}

	public T Next()
	{
		T val = m_pItems.Dequeue();
		m_pItems.Enqueue(val);
		return val;
	}
}
