using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

[Serializable]
internal class WeakViewList<V> where V : class
{
	[Serializable]
	internal class Node
	{
		internal WeakReference weakview;

		internal Node prev;

		internal Node next;

		internal Node(V view)
		{
			weakview = new WeakReference(view);
		}
	}

	private Node start;

	internal Node Add(V view)
	{
		Node node = new Node(view);
		if (start != null)
		{
			start.prev = node;
			node.next = start;
		}
		start = node;
		return node;
	}

	internal void Remove(Node n)
	{
		if (n == start)
		{
			start = start.next;
			if (start != null)
			{
				start.prev = null;
			}
		}
		else
		{
			n.prev.next = n.next;
			if (n.next != null)
			{
				n.next.prev = n.prev;
			}
		}
	}

	[ComVisible(true)]
	public IEnumerator<V> GetEnumerator()
	{
		for (Node i = start; i != null; i = i.next)
		{
			object o = i.weakview.Target;
			V view = ((o is V) ? ((V)o) : null);
			if (view == null)
			{
				Remove(i);
			}
			else
			{
				yield return view;
			}
		}
	}

	[ComVisible(true)]
	public WeakViewList()
	{
	}
}
