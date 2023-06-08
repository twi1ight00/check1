using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

namespace C5;

[Serializable]
internal class LinkedList<T> : SequencedBase<T>, IList<T>, IIndexed<T>, ISequenced<T>, ICollection<T>, IExtensible<T>, ICloneable, IDisposable, IList, ICollection, System.Collections.Generic.IList<T>, System.Collections.Generic.ICollection<T>, IStack<T>, IQueue<T>, IDirectedCollectionValue<T>, ICollectionValue<T>, IShowable, IFormattable, IDirectedEnumerable<T>, IEnumerable<T>, IEnumerable
{
	[Serializable]
	private class Node
	{
		[ComVisible(true)]
		public Node prev;

		[ComVisible(true)]
		public Node next;

		[ComVisible(true)]
		public T item;

		[Tested]
		internal Node(T item)
		{
			this.item = item;
		}

		[Tested]
		internal Node(T item, Node prev, Node next)
		{
			this.item = item;
			this.prev = prev;
			this.next = next;
		}

		[ComVisible(true)]
		public override string ToString()
		{
			return $"Node(item={item})";
		}
	}

	private class PositionComparer : IComparer<Position>
	{
		private static PositionComparer _default;

		[ComVisible(true)]
		public static PositionComparer Default
		{
			[ComVisible(true)]
			get
			{
				return _default ?? (_default = new PositionComparer());
			}
		}

		private PositionComparer()
		{
		}

		[ComVisible(true)]
		public int Compare(Position a, Position b)
		{
			return a.Index.CompareTo(b.Index);
		}
	}

	private struct Position
	{
		[ComVisible(true)]
		public readonly LinkedList<T> View;

		[ComVisible(true)]
		public bool Left;

		[ComVisible(true)]
		public readonly int Index;

		[ComVisible(true)]
		public Position(LinkedList<T> view, bool left)
		{
			View = view;
			Left = left;
			Index = (left ? view.Offset : (view.Offset + view.size - 1));
		}

		[ComVisible(true)]
		public Position(int index)
		{
			Index = index;
			View = null;
			Left = false;
		}
	}

	private struct ViewHandler
	{
		private ArrayList<Position> leftEnds;

		private ArrayList<Position> rightEnds;

		private int leftEndIndex;

		private int rightEndIndex;

		private int leftEndIndex2;

		private int rightEndIndex2;

		internal readonly int viewCount;

		internal ViewHandler(LinkedList<T> list)
		{
			leftEndIndex = (rightEndIndex = (leftEndIndex2 = (rightEndIndex2 = (viewCount = 0))));
			leftEnds = (rightEnds = null);
			if (list.views != null)
			{
				foreach (LinkedList<T> view in list.views)
				{
					if (view != list)
					{
						if (leftEnds == null)
						{
							leftEnds = new ArrayList<Position>();
							rightEnds = new ArrayList<Position>();
						}
						leftEnds.Add(new Position(view, left: true));
						rightEnds.Add(new Position(view, left: false));
					}
				}
			}
			if (leftEnds != null)
			{
				viewCount = leftEnds.Count;
				leftEnds.Sort(PositionComparer.Default);
				rightEnds.Sort(PositionComparer.Default);
			}
		}

		internal void skipEndpoints(int removed, int realindex)
		{
			if (viewCount > 0)
			{
				while (leftEndIndex < viewCount)
				{
					Position position;
					Position position2 = (position = leftEnds[leftEndIndex]);
					if (position2.Index <= realindex)
					{
						LinkedList<T> view = position.View;
						view.offset -= removed;
						view.size += removed;
						leftEndIndex++;
						continue;
					}
					break;
				}
				while (rightEndIndex < viewCount)
				{
					Position position;
					Position position3 = (position = rightEnds[rightEndIndex]);
					if (position3.Index >= realindex)
					{
						break;
					}
					LinkedList<T> view2 = position.View;
					view2.size -= removed;
					rightEndIndex++;
				}
			}
			if (viewCount > 0)
			{
				while (leftEndIndex2 < viewCount && leftEnds[leftEndIndex2].Index <= realindex)
				{
					leftEndIndex2++;
				}
				while (rightEndIndex2 < viewCount && rightEnds[rightEndIndex2].Index < realindex - 1)
				{
					rightEndIndex2++;
				}
			}
		}

		internal void updateViewSizesAndCounts(int removed, int realindex)
		{
			if (viewCount <= 0)
			{
				return;
			}
			while (leftEndIndex < viewCount)
			{
				Position position;
				Position position2 = (position = leftEnds[leftEndIndex]);
				if (position2.Index <= realindex)
				{
					LinkedList<T> view = position.View;
					view.offset = view.Offset - removed;
					view.size += removed;
					leftEndIndex++;
					continue;
				}
				break;
			}
			while (rightEndIndex < viewCount)
			{
				Position position;
				Position position3 = (position = rightEnds[rightEndIndex]);
				if (position3.Index < realindex)
				{
					LinkedList<T> view2 = position.View;
					view2.size -= removed;
					rightEndIndex++;
					continue;
				}
				break;
			}
		}

		internal void updateSentinels(int realindex, Node newstart, Node newend)
		{
			if (viewCount <= 0)
			{
				return;
			}
			while (leftEndIndex2 < viewCount)
			{
				Position position;
				Position position2 = (position = leftEnds[leftEndIndex2]);
				if (position2.Index <= realindex)
				{
					LinkedList<T> view = position.View;
					view.startsentinel = newstart;
					leftEndIndex2++;
					continue;
				}
				break;
			}
			while (rightEndIndex2 < viewCount)
			{
				Position position;
				Position position3 = (position = rightEnds[rightEndIndex2]);
				if (position3.Index < realindex - 1)
				{
					LinkedList<T> view2 = position.View;
					view2.endsentinel = newend;
					rightEndIndex2++;
					continue;
				}
				break;
			}
		}
	}

	private class Range : DirectedCollectionValueBase<T>, IDirectedCollectionValue<T>, ICollectionValue<T>, IShowable, IFormattable, IDirectedEnumerable<T>, IEnumerable<T>, IEnumerable
	{
		private int start;

		private int count;

		private int rangestamp;

		private Node startnode;

		private Node endnode;

		private LinkedList<T> list;

		private bool forwards;

		[ComVisible(true)]
		public override bool IsEmpty
		{
			[ComVisible(true)]
			get
			{
				list.modifycheck(rangestamp);
				return count == 0;
			}
		}

		[Tested]
		[ComVisible(true)]
		public override int Count
		{
			[Tested]
			[ComVisible(true)]
			get
			{
				list.modifycheck(rangestamp);
				return count;
			}
		}

		[ComVisible(true)]
		public override Speed CountSpeed
		{
			[ComVisible(true)]
			get
			{
				list.modifycheck(rangestamp);
				return Speed.Constant;
			}
		}

		[Tested]
		[ComVisible(true)]
		public override EnumerationDirection Direction
		{
			[Tested]
			[ComVisible(true)]
			get
			{
				if (!forwards)
				{
					return EnumerationDirection.Backwards;
				}
				return EnumerationDirection.Forwards;
			}
		}

		internal Range(LinkedList<T> list, int start, int count, bool forwards)
		{
			this.list = list;
			rangestamp = ((list.underlying != null) ? list.underlying.stamp : list.stamp);
			this.start = start;
			this.count = count;
			this.forwards = forwards;
			if (count > 0)
			{
				startnode = list.get(start);
				endnode = list.get(start + count - 1);
			}
		}

		[ComVisible(true)]
		public override T Choose()
		{
			list.modifycheck(rangestamp);
			if (count > 0)
			{
				return startnode.item;
			}
			throw new NoSuchItemException();
		}

		[Tested]
		[ComVisible(true)]
		public override IEnumerator<T> GetEnumerator()
		{
			int togo = count;
			list.modifycheck(rangestamp);
			if (togo == 0)
			{
				yield break;
			}
			Node cursor = (forwards ? startnode : endnode);
			yield return cursor.item;
			while (true)
			{
				int num;
				togo = (num = togo - 1);
				if (num > 0)
				{
					cursor = (forwards ? cursor.next : cursor.prev);
					list.modifycheck(rangestamp);
					yield return cursor.item;
					continue;
				}
				break;
			}
		}

		[Tested]
		[ComVisible(true)]
		public override IDirectedCollectionValue<T> Backwards()
		{
			list.modifycheck(rangestamp);
			Range range = (Range)MemberwiseClone();
			range.forwards = !forwards;
			return range;
		}

		[Tested]
		IDirectedEnumerable<T> IDirectedEnumerable<T>.Backwards()
		{
			return Backwards();
		}
	}

	private bool fIFO = true;

	private Node startsentinel;

	private Node endsentinel;

	private int offset;

	private LinkedList<T> underlying;

	private WeakViewList<LinkedList<T>> views;

	private WeakViewList<LinkedList<T>>.Node myWeakReference;

	private bool isValid = true;

	[ComVisible(true)]
	public override EventTypeEnum ListenableEvents
	{
		[ComVisible(true)]
		get
		{
			if (underlying != null)
			{
				return EventTypeEnum.None;
			}
			return EventTypeEnum.All;
		}
	}

	[Tested]
	[ComVisible(true)]
	public virtual T First
	{
		[Tested]
		[ComVisible(true)]
		get
		{
			validitycheck();
			if (size == 0)
			{
				throw new NoSuchItemException();
			}
			return startsentinel.next.item;
		}
	}

	[Tested]
	[ComVisible(true)]
	public virtual T Last
	{
		[Tested]
		[ComVisible(true)]
		get
		{
			validitycheck();
			if (size == 0)
			{
				throw new NoSuchItemException();
			}
			return endsentinel.prev.item;
		}
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool FIFO
	{
		[Tested]
		[ComVisible(true)]
		get
		{
			validitycheck();
			return fIFO;
		}
		[Tested]
		[ComVisible(true)]
		set
		{
			updatecheck();
			fIFO = value;
		}
	}

	[ComVisible(true)]
	public virtual bool IsFixedSize
	{
		[ComVisible(true)]
		get
		{
			validitycheck();
			return false;
		}
	}

	[Tested]
	[ComVisible(true)]
	public virtual T this[int index]
	{
		[Tested]
		[ComVisible(true)]
		get
		{
			validitycheck();
			return get(index).item;
		}
		[Tested]
		[ComVisible(true)]
		set
		{
			updatecheck();
			Node node = get(index);
			T item = node.item;
			node.item = value;
			(underlying ?? this).raiseForSetThis(index, value, item);
		}
	}

	[ComVisible(true)]
	public virtual Speed IndexingSpeed
	{
		[ComVisible(true)]
		get
		{
			return Speed.Linear;
		}
	}

	[Tested]
	[ComVisible(true)]
	public virtual IList<T> Underlying
	{
		[Tested]
		[ComVisible(true)]
		get
		{
			validitycheck();
			return underlying;
		}
	}

	[ComVisible(true)]
	public virtual bool IsValid
	{
		[ComVisible(true)]
		get
		{
			return isValid;
		}
	}

	[Tested]
	[ComVisible(true)]
	public virtual int Offset
	{
		[Tested]
		[ComVisible(true)]
		get
		{
			validitycheck();
			return offset;
		}
	}

	[Tested]
	[ComVisible(true)]
	public IDirectedCollectionValue<T> this[int start, int count]
	{
		[Tested]
		[ComVisible(true)]
		get
		{
			validitycheck();
			checkRange(start, count);
			return new Range(this, start, count, forwards: true);
		}
	}

	[Tested]
	[ComVisible(true)]
	public virtual Speed ContainsSpeed
	{
		[Tested]
		[ComVisible(true)]
		get
		{
			return Speed.Linear;
		}
	}

	[Tested]
	[ComVisible(true)]
	public override int Count
	{
		[Tested]
		[ComVisible(true)]
		get
		{
			validitycheck();
			return size;
		}
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool AllowsDuplicates
	{
		[Tested]
		[ComVisible(true)]
		get
		{
			return true;
		}
	}

	[ComVisible(true)]
	public virtual bool DuplicatesByCounting
	{
		[ComVisible(true)]
		get
		{
			return false;
		}
	}

	bool ICollection.IsSynchronized => false;

	[Obsolete]
	object ICollection.SyncRoot
	{
		get
		{
			if (underlying == null)
			{
				return startsentinel;
			}
			return ((ICollection)underlying).SyncRoot;
		}
	}

	object IList.this[int index]
	{
		get
		{
			return this[index];
		}
		set
		{
			this[index] = (T)value;
		}
	}

	private bool equals(T i1, T i2)
	{
		return itemequalityComparer.Equals(i1, i2);
	}

	protected override void updatecheck()
	{
		validitycheck();
		base.updatecheck();
		if (underlying != null)
		{
			underlying.stamp++;
		}
	}

	private void validitycheck()
	{
		if (!isValid)
		{
			throw new ViewDisposedException();
		}
	}

	protected override void modifycheck(int stamp)
	{
		validitycheck();
		if (((underlying != null) ? underlying.stamp : base.stamp) != stamp)
		{
			throw new CollectionModifiedException();
		}
	}

	private bool contains(T item, out Node node)
	{
		for (node = startsentinel.next; node != endsentinel; node = node.next)
		{
			if (equals(item, node.item))
			{
				return true;
			}
		}
		return false;
	}

	private bool find(T item, ref Node node, ref int index)
	{
		while (node != endsentinel)
		{
			if (itemequalityComparer.Equals(item, node.item))
			{
				return true;
			}
			index++;
			node = node.next;
		}
		return false;
	}

	private bool dnif(T item, ref Node node, ref int index)
	{
		while (node != startsentinel)
		{
			if (itemequalityComparer.Equals(item, node.item))
			{
				return true;
			}
			index--;
			node = node.prev;
		}
		return false;
	}

	private Node get(int pos)
	{
		if (pos < 0 || pos >= size)
		{
			throw new IndexOutOfRangeException();
		}
		if (pos < size / 2)
		{
			Node next = startsentinel;
			for (int i = 0; i <= pos; i++)
			{
				next = next.next;
			}
			return next;
		}
		Node prev = endsentinel;
		for (int num = size; num > pos; num--)
		{
			prev = prev.prev;
		}
		return prev;
	}

	private int dist(int pos, out int nearest, int[] positions)
	{
		nearest = -1;
		int num = int.MaxValue;
		int result = num;
		for (int i = 0; i < positions.Length; i++)
		{
			int num2 = positions[i] - pos;
			if (num2 >= 0 && num2 < num)
			{
				nearest = i;
				num = num2;
				result = num2;
			}
			if (num2 < 0 && -num2 < num)
			{
				nearest = i;
				num = -num2;
				result = num2;
			}
		}
		return result;
	}

	private Node get(int pos, int[] positions, Node[] nodes)
	{
		int nearest;
		int num = dist(pos, out nearest, positions);
		Node node = nodes[nearest];
		if (num > 0)
		{
			for (int i = 0; i < num; i++)
			{
				node = node.prev;
			}
		}
		else
		{
			for (int num2 = 0; num2 > num; num2--)
			{
				node = node.next;
			}
		}
		return node;
	}

	private void getPair(int p1, int p2, out Node n1, out Node n2, int[] positions, Node[] nodes)
	{
		int nearest;
		int num = dist(p1, out nearest, positions);
		int num2 = ((num < 0) ? (-num) : num);
		int nearest2;
		int num3 = dist(p2, out nearest2, positions);
		int num4 = ((num3 < 0) ? (-num3) : num3);
		if (num2 < num4)
		{
			n1 = get(p1, positions, nodes);
			n2 = get(p2, new int[2]
			{
				positions[nearest2],
				p1
			}, new Node[2]
			{
				nodes[nearest2],
				n1
			});
		}
		else
		{
			n2 = get(p2, positions, nodes);
			n1 = get(p1, new int[2]
			{
				positions[nearest],
				p2
			}, new Node[2]
			{
				nodes[nearest],
				n2
			});
		}
	}

	private Node insert(int index, Node succ, T item)
	{
		Node node = new Node(item, succ.prev, succ);
		succ.prev.next = node;
		succ.prev = node;
		size++;
		if (underlying != null)
		{
			underlying.size++;
		}
		fixViewsAfterInsert(succ, node.prev, 1, Offset + index);
		return node;
	}

	private T remove(Node node, int index)
	{
		fixViewsBeforeSingleRemove(node, Offset + index);
		node.prev.next = node.next;
		node.next.prev = node.prev;
		size--;
		if (underlying != null)
		{
			underlying.size--;
		}
		return node.item;
	}

	private void fixViewsAfterInsert(Node succ, Node pred, int added, int realInsertionIndex)
	{
		if (views == null)
		{
			return;
		}
		foreach (LinkedList<T> view in views)
		{
			if (view != this)
			{
				if (view.Offset == realInsertionIndex && view.size > 0)
				{
					view.startsentinel = succ.prev;
				}
				if (view.Offset + view.size == realInsertionIndex)
				{
					view.endsentinel = pred.next;
				}
				if (view.Offset < realInsertionIndex && view.Offset + view.size > realInsertionIndex)
				{
					view.size += added;
				}
				if (view.Offset > realInsertionIndex || (view.Offset == realInsertionIndex && view.size > 0))
				{
					view.offset += added;
				}
			}
		}
	}

	private void fixViewsBeforeSingleRemove(Node node, int realRemovalIndex)
	{
		if (views == null)
		{
			return;
		}
		foreach (LinkedList<T> view in views)
		{
			if (view != this)
			{
				if (view.offset - 1 == realRemovalIndex)
				{
					view.startsentinel = node.prev;
				}
				if (view.offset + view.size == realRemovalIndex)
				{
					view.endsentinel = node.next;
				}
				if (view.offset <= realRemovalIndex && view.offset + view.size > realRemovalIndex)
				{
					view.size--;
				}
				if (view.offset > realRemovalIndex)
				{
					view.offset--;
				}
			}
		}
	}

	private void fixViewsBeforeRemove(int start, int count, Node first, Node last)
	{
		int num = start + count - 1;
		if (views == null)
		{
			return;
		}
		foreach (LinkedList<T> view in views)
		{
			if (view == this)
			{
				continue;
			}
			int num2 = view.Offset;
			int num3 = num2 + view.size - 1;
			if (start < num2 && num2 - 1 <= num)
			{
				view.startsentinel = first.prev;
			}
			if (start <= num3 + 1 && num3 < num)
			{
				view.endsentinel = last.next;
			}
			if (start < num2)
			{
				if (num < num2)
				{
					view.offset = num2 - count;
					continue;
				}
				view.offset = start;
				view.size = ((num < num3) ? (num3 - num) : 0);
			}
			else if (start <= num3)
			{
				view.size = ((num <= num3) ? (view.size - count) : (start - num2));
			}
		}
	}

	private MutualViewPosition viewPosition(LinkedList<T> otherView)
	{
		int num = offset + size;
		int num2 = otherView.offset;
		int num3 = otherView.size;
		int num4 = num2 + num3;
		if (num2 >= num || num4 <= offset)
		{
			return MutualViewPosition.NonOverlapping;
		}
		if (size == 0 || (num2 <= offset && num <= num4))
		{
			return MutualViewPosition.Contains;
		}
		if (num3 == 0 || (offset <= num2 && num4 <= num))
		{
			return MutualViewPosition.ContainedIn;
		}
		return MutualViewPosition.Overlapping;
	}

	private void disposeOverlappingViews(bool reverse)
	{
		if (views == null)
		{
			return;
		}
		foreach (LinkedList<T> view in views)
		{
			if (view == this)
			{
				continue;
			}
			switch (viewPosition(view))
			{
			case MutualViewPosition.ContainedIn:
				if (!reverse)
				{
					view.Dispose();
				}
				break;
			case MutualViewPosition.Overlapping:
				view.Dispose();
				break;
			}
		}
	}

	[ComVisible(true)]
	public LinkedList(IEqualityComparer<T> itemequalityComparer)
		: base(itemequalityComparer)
	{
		offset = 0;
		size = (stamp = 0);
		startsentinel = new Node(default(T));
		endsentinel = new Node(default(T));
		startsentinel.next = endsentinel;
		endsentinel.prev = startsentinel;
	}

	[ComVisible(true)]
	public LinkedList()
		: this(EqualityComparer<T>.Default)
	{
	}

	[ComVisible(true)]
	public virtual void Dispose()
	{
		Dispose(disposingUnderlying: false);
	}

	private void Dispose(bool disposingUnderlying)
	{
		if (!isValid)
		{
			return;
		}
		if (underlying != null)
		{
			isValid = false;
			if (!disposingUnderlying && views != null)
			{
				views.Remove(myWeakReference);
			}
			endsentinel = null;
			startsentinel = null;
			underlying = null;
			views = null;
			myWeakReference = null;
			return;
		}
		if (views != null)
		{
			foreach (LinkedList<T> view in views)
			{
				view.Dispose(disposingUnderlying: true);
			}
		}
		Clear();
	}

	[Tested]
	[ComVisible(true)]
	public virtual void Insert(int i, T item)
	{
		updatecheck();
		insert(i, (i == size) ? endsentinel : get(i), item);
		if (ActiveEvents != 0)
		{
			(underlying ?? this).raiseForInsert(i + Offset, item);
		}
	}

	[ComVisible(true)]
	public void Insert(IList<T> pointer, T item)
	{
		updatecheck();
		if (pointer == null || (pointer.Underlying ?? pointer) != (underlying ?? this))
		{
			throw new IncompatibleViewException();
		}
		Insert(pointer.Offset + pointer.Count - Offset, item);
	}

	[Tested]
	[ComVisible(true)]
	public virtual void InsertAll<U>(int i, IEnumerable<U> items) where U : T
	{
		insertAll(i, items, insertion: true);
	}

	private void insertAll<U>(int i, IEnumerable<U> items, bool insertion) where U : T
	{
		updatecheck();
		int num = 0;
		Node node = ((i == size) ? endsentinel : get(i));
		Node node2;
		Node node3 = (node2 = node.prev);
		foreach (U item2 in items)
		{
			T item = (T)(object)item2;
			Node node4 = (node2.next = new Node(item, node2, null));
			num++;
			node2 = node4;
		}
		if (num != 0)
		{
			node.prev = node2;
			node2.next = node;
			size += num;
			if (underlying != null)
			{
				underlying.size += num;
			}
			if (num > 0)
			{
				fixViewsAfterInsert(node, node3, num, offset + i);
				raiseForInsertAll(node3, i, num, insertion);
			}
		}
	}

	private void raiseForInsertAll(Node node, int i, int added, bool insertion)
	{
		if (ActiveEvents == EventTypeEnum.None)
		{
			return;
		}
		int num = Offset + i;
		if ((ActiveEvents & (EventTypeEnum.Added | EventTypeEnum.Inserted)) != 0)
		{
			for (int j = num; j < num + added; j++)
			{
				node = node.next;
				T item = node.item;
				if (insertion)
				{
					raiseItemInserted(item, j);
				}
				raiseItemsAdded(item, 1);
			}
		}
		raiseCollectionChanged();
	}

	[Tested]
	[ComVisible(true)]
	public virtual void InsertFirst(T item)
	{
		updatecheck();
		insert(0, startsentinel.next, item);
		if (ActiveEvents != 0)
		{
			(underlying ?? this).raiseForInsert(Offset, item);
		}
	}

	[Tested]
	[ComVisible(true)]
	public virtual void InsertLast(T item)
	{
		updatecheck();
		insert(size, endsentinel, item);
		if (ActiveEvents != 0)
		{
			(underlying ?? this).raiseForInsert(size - 1 + Offset, item);
		}
	}

	[Tested]
	[ComVisible(true)]
	public IList<V> Map<V>(Fun<T, V> mapper)
	{
		validitycheck();
		LinkedList<V> retval = new LinkedList<V>();
		return map(mapper, retval);
	}

	[ComVisible(true)]
	public IList<V> Map<V>(Fun<T, V> mapper, IEqualityComparer<V> equalityComparer)
	{
		validitycheck();
		LinkedList<V> retval = new LinkedList<V>(equalityComparer);
		return map(mapper, retval);
	}

	private IList<V> map<V>(Fun<T, V> mapper, LinkedList<V> retval)
	{
		if (size == 0)
		{
			return retval;
		}
		int thestamp = stamp;
		Node next = startsentinel.next;
		LinkedList<V>.Node next2 = retval.startsentinel;
		while (next != endsentinel)
		{
			V item = mapper(next.item);
			modifycheck(thestamp);
			next2.next = new LinkedList<V>.Node(item, next2, null);
			next = next.next;
			next2 = next2.next;
		}
		retval.endsentinel.prev = next2;
		next2.next = retval.endsentinel;
		retval.size = size;
		return retval;
	}

	[Tested]
	[ComVisible(true)]
	public virtual T Remove()
	{
		updatecheck();
		if (size == 0)
		{
			throw new NoSuchItemException("List is empty");
		}
		T val = (fIFO ? remove(startsentinel.next, 0) : remove(endsentinel.prev, size - 1));
		(underlying ?? this).raiseForRemove(val);
		return val;
	}

	[Tested]
	[ComVisible(true)]
	public virtual T RemoveFirst()
	{
		updatecheck();
		if (size == 0)
		{
			throw new NoSuchItemException("List is empty");
		}
		T val = remove(startsentinel.next, 0);
		if (ActiveEvents != 0)
		{
			(underlying ?? this).raiseForRemoveAt(Offset, val);
		}
		return val;
	}

	[Tested]
	[ComVisible(true)]
	public virtual T RemoveLast()
	{
		updatecheck();
		if (size == 0)
		{
			throw new NoSuchItemException("List is empty");
		}
		T val = remove(endsentinel.prev, size - 1);
		if (ActiveEvents != 0)
		{
			(underlying ?? this).raiseForRemoveAt(size + Offset, val);
		}
		return val;
	}

	[Tested]
	[ComVisible(true)]
	public virtual IList<T> View(int start, int count)
	{
		checkRange(start, count);
		validitycheck();
		if (views == null)
		{
			views = new WeakViewList<LinkedList<T>>();
		}
		LinkedList<T> linkedList = (LinkedList<T>)MemberwiseClone();
		linkedList.underlying = ((underlying != null) ? underlying : this);
		linkedList.offset = offset + start;
		linkedList.size = count;
		getPair(start - 1, start + count, out linkedList.startsentinel, out linkedList.endsentinel, new int[2] { -1, size }, new Node[2] { startsentinel, endsentinel });
		linkedList.myWeakReference = views.Add(linkedList);
		return linkedList;
	}

	[ComVisible(true)]
	public virtual IList<T> ViewOf(T item)
	{
		int index = 0;
		Node node = startsentinel.next;
		if (!find(item, ref node, ref index))
		{
			return null;
		}
		return View(index, 1);
	}

	[ComVisible(true)]
	public virtual IList<T> LastViewOf(T item)
	{
		int index = size - 1;
		Node node = endsentinel.prev;
		if (!dnif(item, ref node, ref index))
		{
			return null;
		}
		return View(index, 1);
	}

	[Tested]
	[ComVisible(true)]
	public IList<T> Slide(int offset)
	{
		if (!TrySlide(offset, size))
		{
			throw new ArgumentOutOfRangeException();
		}
		return this;
	}

	[ComVisible(true)]
	public IList<T> Slide(int offset, int size)
	{
		if (!TrySlide(offset, size))
		{
			throw new ArgumentOutOfRangeException();
		}
		return this;
	}

	[ComVisible(true)]
	public virtual bool TrySlide(int offset)
	{
		return TrySlide(offset, size);
	}

	[ComVisible(true)]
	public virtual bool TrySlide(int offset, int size)
	{
		updatecheck();
		if (underlying == null)
		{
			throw new NotAViewException("List not a view");
		}
		if (offset + this.offset < 0 || offset + this.offset + size > underlying.size)
		{
			return false;
		}
		int num = this.offset;
		getPair(offset - 1, offset + size, out startsentinel, out endsentinel, new int[4]
		{
			-num - 1,
			-1,
			base.size,
			underlying.size - num
		}, new Node[4] { underlying.startsentinel, startsentinel, endsentinel, underlying.endsentinel });
		base.size = size;
		this.offset += offset;
		return true;
	}

	[ComVisible(true)]
	public virtual IList<T> Span(IList<T> otherView)
	{
		if (otherView == null || (otherView.Underlying ?? otherView) != (underlying ?? this))
		{
			throw new IncompatibleViewException();
		}
		if (otherView.Offset + otherView.Count - Offset < 0)
		{
			return null;
		}
		return (underlying ?? this).View(Offset, otherView.Offset + otherView.Count - Offset);
	}

	[Tested]
	[ComVisible(true)]
	public virtual void Reverse()
	{
		updatecheck();
		if (size == 0)
		{
			return;
		}
		Position[] array = null;
		int poslow = 0;
		int poshigh = 0;
		if (views != null)
		{
			CircularQueue<Position> circularQueue = null;
			foreach (LinkedList<T> view in views)
			{
				if (view != this)
				{
					switch (viewPosition(view))
					{
					case MutualViewPosition.ContainedIn:
						(circularQueue ?? (circularQueue = new CircularQueue<Position>())).Enqueue(new Position(view, left: true));
						circularQueue.Enqueue(new Position(view, left: false));
						break;
					case MutualViewPosition.Overlapping:
						view.Dispose();
						break;
					}
				}
			}
			if (circularQueue != null)
			{
				array = circularQueue.ToArray();
				Sorting.IntroSort(array, 0, array.Length, PositionComparer.Default);
				poshigh = array.Length - 1;
			}
		}
		Node node = get(0);
		Node node2 = get(size - 1);
		for (int i = 0; i < size / 2; i++)
		{
			T item = node.item;
			node.item = node2.item;
			node2.item = item;
			if (array != null)
			{
				mirrorViewSentinelsForReverse(array, ref poslow, ref poshigh, node, node2, i);
			}
			node = node.next;
			node2 = node2.prev;
		}
		if (array != null && size % 2 != 0)
		{
			mirrorViewSentinelsForReverse(array, ref poslow, ref poshigh, node, node2, size / 2);
		}
		(underlying ?? this).raiseCollectionChanged();
	}

	private void mirrorViewSentinelsForReverse(Position[] positions, ref int poslow, ref int poshigh, Node a, Node b, int i)
	{
		int num = offset + i;
		int num2 = offset + size - 1 - i;
		while (poslow <= poshigh)
		{
			Position position;
			Position position2 = (position = positions[poslow]);
			if (position2.Index == num)
			{
				if (position.Left)
				{
					position.View.endsentinel = b.next;
				}
				else
				{
					position.View.startsentinel = b.prev;
					position.View.offset = num2;
				}
				poslow++;
				continue;
			}
			break;
		}
		while (poslow < poshigh)
		{
			Position position;
			Position position3 = (position = positions[poshigh]);
			if (position3.Index == num2)
			{
				if (position.Left)
				{
					position.View.endsentinel = a.next;
				}
				else
				{
					position.View.startsentinel = a.prev;
					position.View.offset = num;
				}
				poshigh--;
				continue;
			}
			break;
		}
	}

	[ComVisible(true)]
	public bool IsSorted()
	{
		return IsSorted(Comparer<T>.Default);
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool IsSorted(IComparer<T> c)
	{
		validitycheck();
		if (size <= 1)
		{
			return true;
		}
		Node next = startsentinel.next;
		T item = next.item;
		for (next = next.next; next != endsentinel; next = next.next)
		{
			if (c.Compare(item, next.item) > 0)
			{
				return false;
			}
			item = next.item;
		}
		return true;
	}

	[ComVisible(true)]
	public virtual void Sort()
	{
		Sort(Comparer<T>.Default);
	}

	[Tested]
	[ComVisible(true)]
	public virtual void Sort(IComparer<T> c)
	{
		updatecheck();
		if (size == 0)
		{
			return;
		}
		disposeOverlappingViews(reverse: false);
		Node node = startsentinel.next;
		Node node2 = startsentinel.next;
		endsentinel.prev.next = null;
		while (node2 != null)
		{
			Node next = node2.next;
			while (next != null && c.Compare(node2.item, next.item) <= 0)
			{
				node2 = next;
				next = node2.next;
			}
			node2.next = null;
			node.prev = next;
			node = next;
			if (c.Compare(endsentinel.prev.item, node2.item) <= 0)
			{
				endsentinel.prev = node2;
			}
			node2 = next;
		}
		while (startsentinel.next.prev != null)
		{
			Node node3 = startsentinel.next;
			Node node4 = null;
			while (node3 != null && node3.prev != null)
			{
				Node prev = node3.prev.prev;
				Node node5 = mergeRuns(node3, node3.prev, c);
				if (node4 != null)
				{
					node4.prev = node5;
				}
				else
				{
					startsentinel.next = node5;
				}
				node4 = node5;
				node3 = prev;
			}
			if (node3 != null)
			{
				node4.prev = node3;
			}
		}
		endsentinel.prev.next = endsentinel;
		startsentinel.next.prev = startsentinel;
		(underlying ?? this).raiseCollectionChanged();
	}

	private static Node mergeRuns(Node run1, Node run2, IComparer<T> c)
	{
		Node node;
		bool flag;
		if (c.Compare(run1.item, run2.item) <= 0)
		{
			node = run1;
			flag = true;
			run1 = run1.next;
		}
		else
		{
			node = run2;
			flag = false;
			run2 = run2.next;
		}
		Node node2 = node;
		node2.prev = null;
		while (run1 != null && run2 != null)
		{
			if (flag)
			{
				while (run1 != null && c.Compare(run2.item, run1.item) >= 0)
				{
					node = run1;
					run1 = node.next;
				}
				if (run1 != null)
				{
					node.next = run2;
					run2.prev = node;
					node = run2;
					run2 = node.next;
					flag = false;
				}
			}
			else
			{
				while (run2 != null && c.Compare(run1.item, run2.item) > 0)
				{
					node = run2;
					run2 = node.next;
				}
				if (run2 != null)
				{
					node.next = run1;
					run1.prev = node;
					node = run1;
					run1 = node.next;
					flag = true;
				}
			}
		}
		if (run1 != null)
		{
			node.next = run1;
			run1.prev = node;
		}
		else if (run2 != null)
		{
			node.next = run2;
			run2.prev = node;
		}
		return node2;
	}

	[ComVisible(true)]
	public virtual void Shuffle()
	{
		Shuffle(new C5Random());
	}

	[ComVisible(true)]
	public virtual void Shuffle(Random rnd)
	{
		updatecheck();
		if (size != 0)
		{
			disposeOverlappingViews(reverse: false);
			ArrayList<T> arrayList = new ArrayList<T>();
			arrayList.AddAll(this);
			arrayList.Shuffle(rnd);
			Node next = startsentinel.next;
			int num = 0;
			while (next != endsentinel)
			{
				next.item = arrayList[num++];
				next = next.next;
			}
			(underlying ?? this).raiseCollectionChanged();
		}
	}

	[Tested]
	[ComVisible(true)]
	public virtual int IndexOf(T item)
	{
		validitycheck();
		Node node = startsentinel.next;
		int index = 0;
		if (find(item, ref node, ref index))
		{
			return index;
		}
		return ~size;
	}

	[Tested]
	[ComVisible(true)]
	public virtual int LastIndexOf(T item)
	{
		validitycheck();
		Node node = endsentinel.prev;
		int index = size - 1;
		if (dnif(item, ref node, ref index))
		{
			return index;
		}
		return ~size;
	}

	[Tested]
	[ComVisible(true)]
	public virtual T RemoveAt(int i)
	{
		updatecheck();
		T val = remove(get(i), i);
		if (ActiveEvents != 0)
		{
			(underlying ?? this).raiseForRemoveAt(Offset + i, val);
		}
		return val;
	}

	[Tested]
	[ComVisible(true)]
	public virtual void RemoveInterval(int start, int count)
	{
		updatecheck();
		checkRange(start, count);
		if (count != 0)
		{
			Node node = get(start);
			Node node2 = get(start + count - 1);
			fixViewsBeforeRemove(start, count, node, node2);
			node.prev.next = node2.next;
			node2.next.prev = node.prev;
			if (underlying != null)
			{
				underlying.size -= count;
			}
			size -= count;
			if (ActiveEvents != 0)
			{
				(underlying ?? this).raiseForRemoveInterval(start + Offset, count);
			}
		}
	}

	private void raiseForRemoveInterval(int start, int count)
	{
		if (ActiveEvents != 0)
		{
			raiseCollectionCleared(size == 0, count, start);
			raiseCollectionChanged();
		}
	}

	[Tested]
	[ComVisible(true)]
	public override int GetSequencedHashCode()
	{
		validitycheck();
		return base.GetSequencedHashCode();
	}

	[Tested]
	[ComVisible(true)]
	public override bool SequencedEquals(ISequenced<T> that)
	{
		validitycheck();
		return base.SequencedEquals(that);
	}

	[Tested]
	[ComVisible(true)]
	public override IDirectedCollectionValue<T> Backwards()
	{
		return this[0, size].Backwards();
	}

	[Tested]
	IDirectedEnumerable<T> IDirectedEnumerable<T>.Backwards()
	{
		return Backwards();
	}

	[Tested]
	[ComVisible(true)]
	public override int GetUnsequencedHashCode()
	{
		validitycheck();
		return base.GetUnsequencedHashCode();
	}

	[Tested]
	[ComVisible(true)]
	public override bool UnsequencedEquals(ICollection<T> that)
	{
		validitycheck();
		return base.UnsequencedEquals(that);
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool Contains(T item)
	{
		validitycheck();
		Node node;
		return contains(item, out node);
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool Find(ref T item)
	{
		validitycheck();
		if (contains(item, out var node))
		{
			item = node.item;
			return true;
		}
		return false;
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool Update(T item)
	{
		T olditem;
		return Update(item, out olditem);
	}

	[ComVisible(true)]
	public virtual bool Update(T item, out T olditem)
	{
		updatecheck();
		if (contains(item, out var node))
		{
			olditem = node.item;
			node.item = item;
			(underlying ?? this).raiseForUpdate(item, olditem);
			return true;
		}
		olditem = default(T);
		return false;
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool FindOrAdd(ref T item)
	{
		updatecheck();
		if (Find(ref item))
		{
			return true;
		}
		Add(item);
		return false;
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool UpdateOrAdd(T item)
	{
		T olditem;
		return UpdateOrAdd(item, out olditem);
	}

	[ComVisible(true)]
	public virtual bool UpdateOrAdd(T item, out T olditem)
	{
		updatecheck();
		if (Update(item, out olditem))
		{
			return true;
		}
		Add(item);
		olditem = default(T);
		return false;
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool Remove(T item)
	{
		updatecheck();
		int index = 0;
		Node node = (fIFO ? startsentinel.next : endsentinel.prev);
		if (!(fIFO ? find(item, ref node, ref index) : dnif(item, ref node, ref index)))
		{
			return false;
		}
		T item2 = remove(node, index);
		(underlying ?? this).raiseForRemove(item2);
		return true;
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool Remove(T item, out T removeditem)
	{
		updatecheck();
		int index = 0;
		Node node = (fIFO ? startsentinel.next : endsentinel.prev);
		if (!(fIFO ? find(item, ref node, ref index) : dnif(item, ref node, ref index)))
		{
			removeditem = default(T);
			return false;
		}
		removeditem = node.item;
		remove(node, index);
		(underlying ?? this).raiseForRemove(removeditem);
		return true;
	}

	[Tested]
	[ComVisible(true)]
	public virtual void RemoveAll<U>(IEnumerable<U> items) where U : T
	{
		updatecheck();
		if (size == 0)
		{
			return;
		}
		RaiseForRemoveAllHandler raiseForRemoveAllHandler = new RaiseForRemoveAllHandler(underlying ?? this);
		bool mustFire = raiseForRemoveAllHandler.MustFire;
		HashBag<T> hashBag = new HashBag<T>(itemequalityComparer);
		hashBag.AddAll(items);
		ViewHandler viewHandler = new ViewHandler(this);
		int num = 0;
		int num2 = 0;
		int num3 = Offset;
		Node next = startsentinel.next;
		while (next != endsentinel)
		{
			while (next != endsentinel && !hashBag.Contains(next.item))
			{
				next = next.next;
				num++;
			}
			viewHandler.skipEndpoints(num2, num3 + num);
			Node prev = next.prev;
			while (next != endsentinel && hashBag.Remove(next.item))
			{
				if (mustFire)
				{
					raiseForRemoveAllHandler.Remove(next.item);
				}
				num2++;
				next = next.next;
				num++;
				viewHandler.updateViewSizesAndCounts(num2, num3 + num);
			}
			viewHandler.updateSentinels(num3 + num, prev, next);
			prev.next = next;
			next.prev = prev;
		}
		num = ((underlying != null) ? (underlying.size + 1 - num3) : (size + 1 - num3));
		viewHandler.updateViewSizesAndCounts(num2, num3 + num);
		size -= num2;
		if (underlying != null)
		{
			underlying.size -= num2;
		}
		raiseForRemoveAllHandler.Raise();
	}

	private void RemoveAll(Fun<T, bool> predicate)
	{
		updatecheck();
		if (size == 0)
		{
			return;
		}
		RaiseForRemoveAllHandler raiseForRemoveAllHandler = new RaiseForRemoveAllHandler(underlying ?? this);
		bool mustFire = raiseForRemoveAllHandler.MustFire;
		ViewHandler viewHandler = new ViewHandler(this);
		int num = 0;
		int num2 = 0;
		int num3 = Offset;
		Node next = startsentinel.next;
		while (next != endsentinel)
		{
			while (next != endsentinel && !predicate(next.item))
			{
				updatecheck();
				next = next.next;
				num++;
			}
			updatecheck();
			viewHandler.skipEndpoints(num2, num3 + num);
			Node prev = next.prev;
			while (next != endsentinel && predicate(next.item))
			{
				updatecheck();
				if (mustFire)
				{
					raiseForRemoveAllHandler.Remove(next.item);
				}
				num2++;
				next = next.next;
				num++;
				viewHandler.updateViewSizesAndCounts(num2, num3 + num);
			}
			updatecheck();
			viewHandler.updateSentinels(num3 + num, prev, next);
			prev.next = next;
			next.prev = prev;
		}
		num = ((underlying != null) ? (underlying.size + 1 - num3) : (size + 1 - num3));
		viewHandler.updateViewSizesAndCounts(num2, num3 + num);
		size -= num2;
		if (underlying != null)
		{
			underlying.size -= num2;
		}
		raiseForRemoveAllHandler.Raise();
	}

	[Tested]
	[ComVisible(true)]
	public virtual void Clear()
	{
		updatecheck();
		if (size != 0)
		{
			int count = size;
			clear();
			(underlying ?? this).raiseForRemoveInterval(Offset, count);
		}
	}

	private void clear()
	{
		if (size != 0)
		{
			fixViewsBeforeRemove(Offset, size, startsentinel.next, endsentinel.prev);
			endsentinel.prev = startsentinel;
			startsentinel.next = endsentinel;
			if (underlying != null)
			{
				underlying.size -= size;
			}
			size = 0;
		}
	}

	[Tested]
	[ComVisible(true)]
	public virtual void RetainAll<U>(IEnumerable<U> items) where U : T
	{
		updatecheck();
		if (size == 0)
		{
			return;
		}
		RaiseForRemoveAllHandler raiseForRemoveAllHandler = new RaiseForRemoveAllHandler(underlying ?? this);
		bool mustFire = raiseForRemoveAllHandler.MustFire;
		HashBag<T> hashBag = new HashBag<T>(itemequalityComparer);
		hashBag.AddAll(items);
		ViewHandler viewHandler = new ViewHandler(this);
		int num = 0;
		int num2 = 0;
		int num3 = Offset;
		Node next = startsentinel.next;
		while (next != endsentinel)
		{
			while (next != endsentinel && hashBag.Remove(next.item))
			{
				next = next.next;
				num++;
			}
			viewHandler.skipEndpoints(num2, num3 + num);
			Node prev = next.prev;
			while (next != endsentinel && !hashBag.Contains(next.item))
			{
				if (mustFire)
				{
					raiseForRemoveAllHandler.Remove(next.item);
				}
				num2++;
				next = next.next;
				num++;
				viewHandler.updateViewSizesAndCounts(num2, num3 + num);
			}
			viewHandler.updateSentinels(num3 + num, prev, next);
			prev.next = next;
			next.prev = prev;
		}
		num = ((underlying != null) ? (underlying.size + 1 - num3) : (size + 1 - num3));
		viewHandler.updateViewSizesAndCounts(num2, num3 + num);
		size -= num2;
		if (underlying != null)
		{
			underlying.size -= num2;
		}
		raiseForRemoveAllHandler.Raise();
	}

	private void RetainAll(Fun<T, bool> predicate)
	{
		updatecheck();
		if (size == 0)
		{
			return;
		}
		RaiseForRemoveAllHandler raiseForRemoveAllHandler = new RaiseForRemoveAllHandler(underlying ?? this);
		bool mustFire = raiseForRemoveAllHandler.MustFire;
		ViewHandler viewHandler = new ViewHandler(this);
		int num = 0;
		int num2 = 0;
		int num3 = Offset;
		Node next = startsentinel.next;
		while (next != endsentinel)
		{
			while (next != endsentinel && predicate(next.item))
			{
				updatecheck();
				next = next.next;
				num++;
			}
			updatecheck();
			viewHandler.skipEndpoints(num2, num3 + num);
			Node prev = next.prev;
			while (next != endsentinel && !predicate(next.item))
			{
				updatecheck();
				if (mustFire)
				{
					raiseForRemoveAllHandler.Remove(next.item);
				}
				num2++;
				next = next.next;
				num++;
				viewHandler.updateViewSizesAndCounts(num2, num3 + num);
			}
			updatecheck();
			viewHandler.updateSentinels(num3 + num, prev, next);
			prev.next = next;
			next.prev = prev;
		}
		num = ((underlying != null) ? (underlying.size + 1 - num3) : (size + 1 - num3));
		viewHandler.updateViewSizesAndCounts(num2, num3 + num);
		size -= num2;
		if (underlying != null)
		{
			underlying.size -= num2;
		}
		raiseForRemoveAllHandler.Raise();
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool ContainsAll<U>(IEnumerable<U> items) where U : T
	{
		validitycheck();
		HashBag<T> hashBag = new HashBag<T>(itemequalityComparer);
		hashBag.AddAll(items);
		if (hashBag.Count > size)
		{
			return false;
		}
		for (Node next = startsentinel.next; next != endsentinel; next = next.next)
		{
			hashBag.Remove(next.item);
		}
		return hashBag.IsEmpty;
	}

	[Tested]
	[ComVisible(true)]
	public IList<T> FindAll(Fun<T, bool> filter)
	{
		validitycheck();
		int thestamp = stamp;
		LinkedList<T> linkedList = new LinkedList<T>();
		Node next = startsentinel.next;
		Node next2 = linkedList.startsentinel;
		while (next != endsentinel)
		{
			bool flag = filter(next.item);
			modifycheck(thestamp);
			if (flag)
			{
				next2.next = new Node(next.item, next2, null);
				next2 = next2.next;
				linkedList.size++;
			}
			next = next.next;
		}
		linkedList.endsentinel.prev = next2;
		next2.next = linkedList.endsentinel;
		return linkedList;
	}

	[Tested]
	[ComVisible(true)]
	public virtual int ContainsCount(T item)
	{
		validitycheck();
		int num = 0;
		for (Node next = startsentinel.next; next != endsentinel; next = next.next)
		{
			if (itemequalityComparer.Equals(next.item, item))
			{
				num++;
			}
		}
		return num;
	}

	[ComVisible(true)]
	public virtual ICollectionValue<T> UniqueItems()
	{
		HashBag<T> hashBag = new HashBag<T>(itemequalityComparer);
		hashBag.AddAll(this);
		return hashBag.UniqueItems();
	}

	[ComVisible(true)]
	public virtual ICollectionValue<KeyValuePair<T, int>> ItemMultiplicities()
	{
		HashBag<T> hashBag = new HashBag<T>(itemequalityComparer);
		hashBag.AddAll(this);
		return hashBag.ItemMultiplicities();
	}

	[Tested]
	[ComVisible(true)]
	public virtual void RemoveAllCopies(T item)
	{
		updatecheck();
		if (size == 0)
		{
			return;
		}
		RaiseForRemoveAllHandler raiseForRemoveAllHandler = new RaiseForRemoveAllHandler(underlying ?? this);
		bool mustFire = raiseForRemoveAllHandler.MustFire;
		ViewHandler viewHandler = new ViewHandler(this);
		int num = 0;
		int num2 = 0;
		int num3 = Offset;
		Node next = startsentinel.next;
		while (next != endsentinel)
		{
			while (next != endsentinel && !itemequalityComparer.Equals(next.item, item))
			{
				next = next.next;
				num++;
			}
			viewHandler.skipEndpoints(num2, num3 + num);
			Node prev = next.prev;
			while (next != endsentinel && itemequalityComparer.Equals(next.item, item))
			{
				if (mustFire)
				{
					raiseForRemoveAllHandler.Remove(next.item);
				}
				num2++;
				next = next.next;
				num++;
				viewHandler.updateViewSizesAndCounts(num2, num3 + num);
			}
			viewHandler.updateSentinels(num3 + num, prev, next);
			prev.next = next;
			next.prev = prev;
		}
		num = ((underlying != null) ? (underlying.size + 1 - num3) : (size + 1 - num3));
		viewHandler.updateViewSizesAndCounts(num2, num3 + num);
		size -= num2;
		if (underlying != null)
		{
			underlying.size -= num2;
		}
		raiseForRemoveAllHandler.Raise();
	}

	[Tested]
	[ComVisible(true)]
	public override T Choose()
	{
		return First;
	}

	[ComVisible(true)]
	public override IEnumerable<T> Filter(Fun<T, bool> filter)
	{
		validitycheck();
		return base.Filter(filter);
	}

	[Tested]
	[ComVisible(true)]
	public override IEnumerator<T> GetEnumerator()
	{
		validitycheck();
		Node cursor = startsentinel.next;
		int enumeratorstamp = ((underlying != null) ? underlying.stamp : stamp);
		while (cursor != endsentinel)
		{
			modifycheck(enumeratorstamp);
			yield return cursor.item;
			cursor = cursor.next;
		}
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool Add(T item)
	{
		updatecheck();
		insert(size, endsentinel, item);
		(underlying ?? this).raiseForAdd(item);
		return true;
	}

	[Tested]
	[ComVisible(true)]
	public virtual void AddAll<U>(IEnumerable<U> items) where U : T
	{
		insertAll(size, items, insertion: false);
	}

	[Tested]
	[ComVisible(true)]
	public void Push(T item)
	{
		InsertLast(item);
	}

	[Tested]
	[ComVisible(true)]
	public T Pop()
	{
		return RemoveLast();
	}

	[Tested]
	[ComVisible(true)]
	public virtual void Enqueue(T item)
	{
		InsertLast(item);
	}

	[Tested]
	[ComVisible(true)]
	public virtual T Dequeue()
	{
		return RemoveFirst();
	}

	private bool checkViews()
	{
		if (underlying != null)
		{
			throw new InternalException(string.Concat(MethodBase.GetCurrentMethod(), " called on a view"));
		}
		if (views == null)
		{
			return true;
		}
		bool result = true;
		Node[] array = new Node[size + 2];
		int num = 0;
		for (Node next = startsentinel; next != null; next = next.next)
		{
			array[num++] = next;
		}
		foreach (LinkedList<T> view in views)
		{
			if (!view.isValid)
			{
				Console.WriteLine("Invalid view(hash {0}, offset {1}, size {2})", view.GetHashCode(), view.offset, view.size);
				result = false;
				continue;
			}
			if (view.Offset > size || view.Offset < 0)
			{
				Console.WriteLine("Bad view(hash {0}, offset {1}, size {2}), Offset > underlying.size ({2})", view.GetHashCode(), view.offset, view.size, size);
				result = false;
			}
			else if (view.startsentinel != array[view.Offset])
			{
				Console.WriteLine("Bad view(hash {0}, offset {1}, size {2}), startsentinel {3} should be {4}", view.GetHashCode(), view.offset, view.size, string.Concat(view.startsentinel, " ", view.startsentinel.GetHashCode()), string.Concat(array[view.Offset], " ", array[view.Offset].GetHashCode()));
				result = false;
			}
			if (view.Offset + view.size > size || view.Offset + view.size < 0)
			{
				Console.WriteLine("Bad view(hash {0}, offset {1}, size {2}), end index > underlying.size ({3})", view.GetHashCode(), view.offset, view.size, size);
				result = false;
			}
			else if (view.endsentinel != array[view.Offset + view.size + 1])
			{
				Console.WriteLine("Bad view(hash {0}, offset {1}, size {2}), endsentinel {3} should be {4}", view.GetHashCode(), view.offset, view.size, string.Concat(view.endsentinel, " ", view.endsentinel.GetHashCode()), string.Concat(array[view.Offset + view.size + 1], " ", array[view.Offset + view.size + 1].GetHashCode()));
				result = false;
			}
			if (view.views != views)
			{
				Console.WriteLine("Bad view(hash {0}, offset {1}, size {2}), wrong views list {3} <> {4}", view.GetHashCode(), view.offset, view.size, view.views.GetHashCode(), views.GetHashCode());
				result = false;
			}
			if (view.underlying != this)
			{
				Console.WriteLine("Bad view(hash {0}, offset {1}, size {2}), wrong underlying {3} <> this {4}", view.GetHashCode(), view.offset, view.size, view.underlying.GetHashCode(), GetHashCode());
				result = false;
			}
			_ = view.stamp;
			_ = stamp;
		}
		return result;
	}

	private string zeitem(Node node)
	{
		if (node != null)
		{
			return node.item.ToString();
		}
		return "(null node)";
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool Check()
	{
		bool flag = true;
		if (underlying != null)
		{
			return underlying.Check();
		}
		if (startsentinel == null)
		{
			Console.WriteLine("startsentinel == null");
			flag = false;
		}
		if (endsentinel == null)
		{
			Console.WriteLine("endsentinel == null");
			flag = false;
		}
		if (size == 0)
		{
			if (startsentinel != null && startsentinel.next != endsentinel)
			{
				Console.WriteLine("size == 0 but startsentinel.next != endsentinel");
				flag = false;
			}
			if (endsentinel != null && endsentinel.prev != startsentinel)
			{
				Console.WriteLine("size == 0 but endsentinel.prev != startsentinel");
				flag = false;
			}
		}
		if (startsentinel == null)
		{
			Console.WriteLine("NULL startsentinel");
			return flag;
		}
		int num = 0;
		Node next = startsentinel.next;
		Node node = startsentinel;
		while (next != endsentinel)
		{
			num++;
			if (next.prev != node)
			{
				Console.WriteLine("Bad backpointer at node {0}", num);
				flag = false;
			}
			node = next;
			next = next.next;
			if (next == null)
			{
				Console.WriteLine("Null next pointer at node {0}", num);
				return false;
			}
		}
		if (num != size)
		{
			Console.WriteLine("size={0} but enumeration gives {1} nodes ", size, num);
			flag = false;
		}
		return checkViews() && flag;
	}

	[ComVisible(true)]
	public virtual object Clone()
	{
		LinkedList<T> linkedList = new LinkedList<T>(itemequalityComparer);
		linkedList.AddAll(this);
		return linkedList;
	}

	void System.Collections.Generic.IList<T>.RemoveAt(int index)
	{
		RemoveAt(index);
	}

	void System.Collections.Generic.ICollection<T>.Add(T item)
	{
		Add(item);
	}

	void ICollection.CopyTo(Array arr, int index)
	{
		if (index < 0 || index + Count > arr.Length)
		{
			throw new ArgumentOutOfRangeException();
		}
		using IEnumerator<T> enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			T current = enumerator.Current;
			arr.SetValue(current, index++);
		}
	}

	int IList.Add(object o)
	{
		if (!Add((T)o))
		{
			return -1;
		}
		return Count - 1;
	}

	bool IList.Contains(object o)
	{
		return Contains((T)o);
	}

	int IList.IndexOf(object o)
	{
		return Math.Max(-1, IndexOf((T)o));
	}

	void IList.Insert(int index, object o)
	{
		Insert(index, (T)o);
	}

	void IList.Remove(object o)
	{
		Remove((T)o);
	}

	void IList.RemoveAt(int index)
	{
		RemoveAt(index);
	}
}
