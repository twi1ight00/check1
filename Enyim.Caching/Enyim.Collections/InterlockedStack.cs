using System.Threading;

namespace Enyim.Collections;

/// <summary>
/// Implements a non-locking stack.
/// </summary>
/// <typeparam name="TItem"></typeparam>
public class InterlockedStack<TItem>
{
	private class Node
	{
		public readonly TItem Value;

		public Node Next;

		public Node(TItem value)
		{
			Value = value;
		}
	}

	private Node head;

	public InterlockedStack()
	{
		head = new Node(default(TItem));
	}

	public void Push(TItem item)
	{
		Node node = new Node(item);
		do
		{
			node.Next = head.Next;
		}
		while (Interlocked.CompareExchange(ref head.Next, node, node.Next) != node.Next);
	}

	public bool TryPop(out TItem value)
	{
		value = default(TItem);
		Node node;
		do
		{
			node = head.Next;
			if (node == null)
			{
				return false;
			}
		}
		while (Interlocked.CompareExchange(ref head.Next, node.Next, node) != node);
		value = node.Value;
		return true;
	}
}
