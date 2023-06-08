using System.Threading;

namespace Enyim.Collections;

/// <summary>
/// Implements a non-locking queue.
/// </summary>
/// <typeparam name="T"></typeparam>
public class InterlockedQueue<T>
{
	private class Node
	{
		public readonly T Value;

		public Node Next;

		public Node(T value)
		{
			Value = value;
		}
	}

	private Node headNode;

	private Node tailNode;

	/// <summary>
	/// Initializes a new instance of the <see cref="T:InterlockedQueue" /> class.
	/// </summary>
	public InterlockedQueue()
	{
		tailNode = (headNode = new Node(default(T)));
	}

	/// <summary>
	/// Removes and returns the item at the beginning of the <see cref="T:InterlockedQueue" />.
	/// </summary>
	/// <param name="value">The object that is removed from the beginning of the <see cref="T:InterlockedQueue" />.</param>
	/// <returns><value>true</value> if an item was successfully dequeued; otherwise <value>false</value>.</returns>
	public bool Dequeue(out T value)
	{
		while (true)
		{
			Node head = headNode;
			Node tail = tailNode;
			Node next = head.Next;
			if (!object.ReferenceEquals(headNode, head))
			{
				continue;
			}
			if (object.ReferenceEquals(head, tail))
			{
				if (object.ReferenceEquals(next, null))
				{
					value = default(T);
					return false;
				}
				Interlocked.CompareExchange(ref tailNode, next, tail);
			}
			else
			{
				value = next.Value;
				if (Interlocked.CompareExchange(ref headNode, next, head) == head)
				{
					break;
				}
			}
		}
		return true;
	}

	public bool Peek(out T value)
	{
		Node next;
		while (true)
		{
			Node head = headNode;
			Node tail = tailNode;
			next = head.Next;
			if (object.ReferenceEquals(headNode, head))
			{
				if (!object.ReferenceEquals(head, tail))
				{
					break;
				}
				if (object.ReferenceEquals(next, null))
				{
					value = default(T);
					return false;
				}
				Interlocked.CompareExchange(ref tailNode, next, tail);
			}
		}
		value = next.Value;
		return true;
	}

	/// <summary>
	/// Adds an object to the end of the <see cref="T:InterlockedQueue" />.
	/// </summary>
	/// <param name="value">The item to be added to the <see cref="T:InterlockedQueue" />. The value can be <value>null</value>.</param>
	public void Enqueue(T value)
	{
		Node valueNode = new Node(value);
		Node tail;
		while (true)
		{
			tail = tailNode;
			Node next = tail.Next;
			if (!object.ReferenceEquals(tail, tailNode))
			{
				continue;
			}
			if (object.ReferenceEquals(next, null))
			{
				if (object.ReferenceEquals(Interlocked.CompareExchange(ref tail.Next, valueNode, next), next))
				{
					break;
				}
			}
			else
			{
				Interlocked.CompareExchange(ref tailNode, next, tail);
			}
		}
		Interlocked.CompareExchange(ref tailNode, valueNode, tail);
	}
}
