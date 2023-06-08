using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

namespace C5;

[Serializable]
internal class HashedLinkedList<T> : SequencedBase<T>, IList<T>, IIndexed<T>, ISequenced<T>, ICollection<T>, IExtensible<T>, ICloneable, IDirectedCollectionValue<T>, ICollectionValue<T>, IShowable, IFormattable, IDirectedEnumerable<T>, IDisposable, IList, ICollection, System.Collections.Generic.IList<T>, System.Collections.Generic.ICollection<T>, IEnumerable<T>, IEnumerable
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

		internal int tag;

		internal TagGroup taggroup;

		internal bool precedes(Node that)
		{
			int num = taggroup.tag;
			int num2 = that.taggroup.tag;
			if (num >= num2)
			{
				if (num <= num2)
				{
					return tag < that.tag;
				}
				return false;
			}
			return true;
		}

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
			return $"Node: (item={item}, tag={tag})";
		}
	}

	[Serializable]
	private class TagGroup
	{
		internal int tag;

		internal int count;

		internal Node first;

		internal Node last;

		[ComVisible(true)]
		public override string ToString()
		{
			return $"TagGroup(tag={tag}, cnt={count}, fst={first}, lst={last})";
		}

		[ComVisible(true)]
		public TagGroup()
		{
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
			if (a.Endpoint != b.Endpoint)
			{
				if (!a.Endpoint.precedes(b.Endpoint))
				{
					return 1;
				}
				return -1;
			}
			return 0;
		}
	}

	private struct Position
	{
		[ComVisible(true)]
		public readonly HashedLinkedList<T> View;

		[ComVisible(true)]
		public bool Left;

		[ComVisible(true)]
		public readonly Node Endpoint;

		[ComVisible(true)]
		public Position(HashedLinkedList<T> view, bool left)
		{
			View = view;
			Left = left;
			Endpoint = (left ? view.startsentinel.next : view.endsentinel.prev);
		}

		[ComVisible(true)]
		public Position(Node node, int foo)
		{
			Endpoint = node;
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

		internal ViewHandler(HashedLinkedList<T> list)
		{
			leftEndIndex = (rightEndIndex = (leftEndIndex2 = (rightEndIndex2 = (viewCount = 0))));
			leftEnds = (rightEnds = null);
			if (list.views != null)
			{
				foreach (HashedLinkedList<T> view in list.views)
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

		internal void skipEndpoints(int removed, Node n)
		{
			if (viewCount > 0)
			{
				while (leftEndIndex < viewCount)
				{
					Position position;
					Position position2 = (position = leftEnds[leftEndIndex]);
					if (position2.Endpoint.prev.precedes(n))
					{
						HashedLinkedList<T> view = position.View;
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
					if (!position3.Endpoint.precedes(n))
					{
						break;
					}
					HashedLinkedList<T> view2 = position.View;
					view2.size -= removed;
					rightEndIndex++;
				}
			}
			if (viewCount > 0)
			{
				while (leftEndIndex2 < viewCount && leftEnds[leftEndIndex2].Endpoint.prev.precedes(n))
				{
					leftEndIndex2++;
				}
				while (rightEndIndex2 < viewCount && rightEnds[rightEndIndex2].Endpoint.next.precedes(n))
				{
					rightEndIndex2++;
				}
			}
		}

		internal void updateViewSizesAndCounts(int removed, Node n)
		{
			if (viewCount <= 0)
			{
				return;
			}
			while (leftEndIndex < viewCount)
			{
				Position position;
				Position position2 = (position = leftEnds[leftEndIndex]);
				if (position2.Endpoint.prev.precedes(n))
				{
					HashedLinkedList<T> view = position.View;
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
				if (position3.Endpoint.precedes(n))
				{
					HashedLinkedList<T> view2 = position.View;
					view2.size -= removed;
					rightEndIndex++;
					continue;
				}
				break;
			}
		}

		internal void updateSentinels(Node n, Node newstart, Node newend)
		{
			if (viewCount <= 0)
			{
				return;
			}
			while (leftEndIndex2 < viewCount)
			{
				Position position;
				Position position2 = (position = leftEnds[leftEndIndex2]);
				if (position2.Endpoint.prev.precedes(n))
				{
					HashedLinkedList<T> view = position.View;
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
				if (position3.Endpoint.next.precedes(n))
				{
					HashedLinkedList<T> view2 = position.View;
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

		private HashedLinkedList<T> list;

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

		internal Range(HashedLinkedList<T> list, int start, int count, bool forwards)
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

	private const int wordsize = 32;

	private const int lobits = 3;

	private const int hibits = 4;

	private const int losize = 8;

	private const int hisize = 16;

	private const int logwordsize = 5;

	private bool fIFO = true;

	private Node startsentinel;

	private Node endsentinel;

	private int? offset;

	private HashedLinkedList<T> underlying;

	private WeakViewList<HashedLinkedList<T>> views;

	private WeakViewList<HashedLinkedList<T>>.Node myWeakReference;

	private bool isValid = true;

	private HashDictionary<T, Node> dict;

	private int taggroups;

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

	private int Taggroups
	{
		get
		{
			if (underlying != null)
			{
				return underlying.taggroups;
			}
			return taggroups;
		}
		set
		{
			if (underlying == null)
			{
				taggroups = value;
			}
			else
			{
				underlying.taggroups = value;
			}
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
			Node value2 = get(index);
			T item = value2.item;
			if (itemequalityComparer.Equals(value, item))
			{
				value2.item = value;
				dict.Update(value, value2);
			}
			else
			{
				if (dict.FindOrAdd(value, ref value2))
				{
					throw new ArgumentException("Item already in indexed list");
				}
				dict.Remove(item);
				value2.item = value;
			}
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
			if (!offset.HasValue && underlying != null)
			{
				Node next = underlying.startsentinel;
				int num = 0;
				while (next != startsentinel)
				{
					next = next.next;
					num++;
				}
				offset = num;
			}
			return offset.Value;
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
			return Speed.Constant;
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
			return false;
		}
	}

	[ComVisible(true)]
	public virtual bool DuplicatesByCounting
	{
		[ComVisible(true)]
		get
		{
			return true;
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
		if (dict.Find(item, out node))
		{
			return insideview(node);
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

	private bool insideview(Node node)
	{
		if (underlying == null)
		{
			return true;
		}
		if (startsentinel.precedes(node))
		{
			return node.precedes(endsentinel);
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

	private void insert(int index, Node succ, T item)
	{
		Node value = new Node(item);
		if (dict.FindOrAdd(item, ref value))
		{
			throw new DuplicateNotAllowedException("Item already in indexed list");
		}
		insertNode(updateViews: true, succ, value);
	}

	private void insertNode(bool updateViews, Node succ, Node newnode)
	{
		newnode.next = succ;
		Node pred = (newnode.prev = succ.prev);
		succ.prev.next = newnode;
		succ.prev = newnode;
		size++;
		if (underlying != null)
		{
			underlying.size++;
		}
		settag(newnode);
		if (updateViews)
		{
			fixViewsAfterInsert(succ, pred, 1, 0);
		}
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
		removefromtaggroup(node);
		return node.item;
	}

	private bool dictremove(T item, out Node node)
	{
		if (underlying == null)
		{
			if (!dict.Remove(item, out node))
			{
				return false;
			}
		}
		else
		{
			if (!contains(item, out node))
			{
				return false;
			}
			dict.Remove(item);
		}
		return true;
	}

	private void fixViewsAfterInsert(Node succ, Node pred, int added, int realInsertionIndex)
	{
		if (views == null)
		{
			return;
		}
		foreach (HashedLinkedList<T> view in views)
		{
			if (view != this)
			{
				if (pred.precedes(view.startsentinel) || (view.startsentinel == pred && view.size > 0))
				{
					view.offset += added;
				}
				if (view.startsentinel.precedes(pred) && succ.precedes(view.endsentinel))
				{
					view.size += added;
				}
				if (view.startsentinel == pred && view.size > 0)
				{
					view.startsentinel = succ.prev;
				}
				if (view.endsentinel == succ)
				{
					view.endsentinel = pred.next;
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
		foreach (HashedLinkedList<T> view in views)
		{
			if (view != this)
			{
				if (view.startsentinel.precedes(node) && node.precedes(view.endsentinel))
				{
					view.size--;
				}
				if (!view.startsentinel.precedes(node))
				{
					view.offset--;
				}
				if (view.startsentinel == node)
				{
					view.startsentinel = node.prev;
				}
				if (view.endsentinel == node)
				{
					view.endsentinel = node.next;
				}
			}
		}
	}

	private MutualViewPosition viewPosition(HashedLinkedList<T> otherView)
	{
		Node node = otherView.startsentinel;
		Node node2 = otherView.endsentinel;
		Node next = startsentinel.next;
		Node prev = endsentinel.prev;
		Node next2 = node.next;
		Node prev2 = node2.prev;
		if (prev.precedes(next2) || prev2.precedes(next))
		{
			return MutualViewPosition.NonOverlapping;
		}
		if (size == 0 || (node.precedes(next) && prev.precedes(node2)))
		{
			return MutualViewPosition.Contains;
		}
		if (otherView.size == 0 || (startsentinel.precedes(next2) && prev2.precedes(endsentinel)))
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
		foreach (HashedLinkedList<T> view in views)
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
	public HashedLinkedList(IEqualityComparer<T> itemequalityComparer)
		: base(itemequalityComparer)
	{
		offset = 0;
		size = (stamp = 0);
		startsentinel = new Node(default(T));
		endsentinel = new Node(default(T));
		startsentinel.next = endsentinel;
		endsentinel.prev = startsentinel;
		startsentinel.taggroup = new TagGroup();
		startsentinel.taggroup.tag = int.MinValue;
		startsentinel.taggroup.count = 0;
		endsentinel.taggroup = new TagGroup();
		endsentinel.taggroup.tag = int.MaxValue;
		endsentinel.taggroup.count = 0;
		dict = new HashDictionary<T, Node>(itemequalityComparer);
	}

	[ComVisible(true)]
	public HashedLinkedList()
		: this(EqualityComparer<T>.Default)
	{
	}

	private TagGroup gettaggroup(Node pred, Node succ, out int lowbound, out int highbound)
	{
		TagGroup taggroup = pred.taggroup;
		TagGroup taggroup2 = succ.taggroup;
		if (taggroup == taggroup2)
		{
			lowbound = pred.tag + 1;
			highbound = succ.tag - 1;
			return taggroup;
		}
		if (taggroup.first != null)
		{
			lowbound = pred.tag + 1;
			highbound = int.MaxValue;
			return taggroup;
		}
		if (taggroup2.first != null)
		{
			lowbound = int.MinValue;
			highbound = succ.tag - 1;
			return taggroup2;
		}
		lowbound = int.MinValue;
		highbound = int.MaxValue;
		return new TagGroup();
	}

	private void settag(Node node)
	{
		Node prev = node.prev;
		Node next = node.next;
		TagGroup taggroup = prev.taggroup;
		TagGroup taggroup2 = next.taggroup;
		if (taggroup == taggroup2)
		{
			node.taggroup = taggroup;
			taggroup.count++;
			if (prev.tag + 1 == next.tag)
			{
				splittaggroup(taggroup);
			}
			else
			{
				node.tag = (prev.tag + 1) / 2 + (next.tag - 1) / 2;
			}
		}
		else if (taggroup.first != null)
		{
			node.taggroup = taggroup;
			taggroup.last = node;
			taggroup.count++;
			if (prev.tag == int.MaxValue)
			{
				splittaggroup(taggroup);
			}
			else
			{
				node.tag = prev.tag / 2 + 1073741823 + 1;
			}
		}
		else if (taggroup2.first != null)
		{
			node.taggroup = taggroup2;
			taggroup2.first = node;
			taggroup2.count++;
			if (next.tag == int.MinValue)
			{
				splittaggroup(node.taggroup);
			}
			else
			{
				node.tag = -1073741824 + (next.tag - 1) / 2;
			}
		}
		else
		{
			TagGroup tagGroup = new TagGroup();
			Taggroups = 1;
			node.taggroup = tagGroup;
			tagGroup.first = (tagGroup.last = node);
			tagGroup.count = 1;
		}
	}

	private void removefromtaggroup(Node node)
	{
		TagGroup taggroup = node.taggroup;
		if (--taggroup.count == 0)
		{
			Taggroups--;
			return;
		}
		if (node == taggroup.first)
		{
			taggroup.first = node.next;
		}
		if (node == taggroup.last)
		{
			taggroup.last = node.prev;
		}
		if (taggroup.count != 8 || Taggroups == 1)
		{
			return;
		}
		TagGroup taggroup2;
		Node prev;
		if ((prev = taggroup.first.prev) != startsentinel && (taggroup2 = prev.taggroup).count <= 8)
		{
			taggroup.first = taggroup2.first;
		}
		else
		{
			if ((prev = taggroup.last.next) == endsentinel || (taggroup2 = prev.taggroup).count > 8)
			{
				return;
			}
			taggroup.last = taggroup2.last;
		}
		Node node2 = taggroup2.first;
		int i = 0;
		for (int count = taggroup2.count; i < count; i++)
		{
			node2.taggroup = taggroup;
			node2 = node2.next;
		}
		taggroup.count += taggroup2.count;
		Taggroups--;
		node2 = taggroup.first;
		int j = 0;
		for (int count2 = taggroup.count; j < count2; j++)
		{
			node2.tag = j - 8 << 28;
			node2 = node2.next;
		}
	}

	private void splittaggroup(TagGroup taggroup)
	{
		Node node = taggroup.first;
		int tag = taggroup.first.prev.taggroup.tag;
		int tag2 = taggroup.last.next.taggroup.tag;
		int num = 28;
		int num2 = (taggroup.count - 1) / 16;
		int num3 = (int)(((double)tag2 + 0.0 - (double)tag) / (double)(num2 + 2));
		int num4 = tag;
		num3 = ((num3 == 0) ? 1 : num3);
		for (int i = 0; i < num2; i++)
		{
			TagGroup tagGroup = new TagGroup();
			num4 = (tagGroup.tag = ((num4 >= tag2 - num3) ? tag2 : (num4 + num3)));
			tagGroup.first = node;
			tagGroup.count = 16;
			for (int j = 0; j < 16; j++)
			{
				node.taggroup = tagGroup;
				node.tag = j - 8 << num;
				node = node.next;
			}
			tagGroup.last = node.prev;
		}
		int num5 = taggroup.count - 16 * num2;
		taggroup.first = node;
		taggroup.count = num5;
		num4 = (taggroup.tag = ((num4 >= tag2 - num3) ? tag2 : (num4 + num3)));
		num--;
		for (int k = 0; k < num5; k++)
		{
			node.tag = k - 16 << num;
			node = node.next;
		}
		taggroup.last = node.prev;
		Taggroups += num2;
		if (num4 == tag2)
		{
			redistributetaggroups(taggroup);
		}
	}

	private void redistributetaggroups(TagGroup taggroup)
	{
		TagGroup tagGroup = taggroup;
		TagGroup tagGroup2 = taggroup;
		double num = 1.0;
		double num2 = Math.Pow(Taggroups, 1.0 / 30.0);
		int num3 = 1;
		int num4 = 1;
		int num5 = 0;
		int num6 = 0;
		int num7 = 0;
		do
		{
			num3++;
			num5 = (1 << num3) - 1;
			num6 = ~num5;
			num7 = taggroup.tag & num6;
			TagGroup taggroup2;
			while ((taggroup2 = tagGroup.first.prev.taggroup).first != null && (taggroup2.tag & num6) == num7)
			{
				num4++;
				tagGroup = taggroup2;
			}
			while ((taggroup2 = tagGroup2.last.next.taggroup).last != null && (taggroup2.tag & num6) == num7)
			{
				num4++;
				tagGroup2 = taggroup2;
			}
			num *= num2;
		}
		while ((double)num4 > num);
		int tag = tagGroup.first.prev.taggroup.tag;
		int tag2 = tagGroup2.last.next.taggroup.tag;
		int num8 = tag2 / (num4 + 1) - tag / (num4 + 1);
		for (int i = 0; i < num4; i++)
		{
			tagGroup.tag = tag + (i + 1) * num8;
			tagGroup = tagGroup.last.next.taggroup;
		}
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
			foreach (HashedLinkedList<T> view in views)
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
		TagGroup tagGroup = null;
		int highbound = 0;
		int lowbound = 0;
		tagGroup = gettaggroup(node2, node, out lowbound, out highbound);
		try
		{
			foreach (U item in items)
			{
				T val = (T)(object)item;
				Node value = new Node(val, node2, null);
				if (!dict.FindOrAdd(val, ref value))
				{
					value.tag = ((lowbound < highbound) ? (++lowbound) : lowbound);
					value.taggroup = tagGroup;
					node2.next = value;
					num++;
					node2 = value;
					continue;
				}
				throw new DuplicateNotAllowedException("Item already in indexed list");
			}
		}
		finally
		{
			if (num != 0)
			{
				tagGroup.count += num;
				if (tagGroup != node3.taggroup)
				{
					tagGroup.first = node3.next;
				}
				if (tagGroup != node.taggroup)
				{
					tagGroup.last = node2;
				}
				node.prev = node2;
				node2.next = node;
				if (node2.tag == node2.prev.tag)
				{
					splittaggroup(tagGroup);
				}
				size += num;
				if (underlying != null)
				{
					underlying.size += num;
				}
				fixViewsAfterInsert(node, node3, num, 0);
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
		HashedLinkedList<V> retval = new HashedLinkedList<V>();
		return map(mapper, retval);
	}

	[ComVisible(true)]
	public IList<V> Map<V>(Fun<T, V> mapper, IEqualityComparer<V> equalityComparer)
	{
		validitycheck();
		HashedLinkedList<V> retval = new HashedLinkedList<V>(equalityComparer);
		return map(mapper, retval);
	}

	private IList<V> map<V>(Fun<T, V> mapper, HashedLinkedList<V> retval)
	{
		if (size == 0)
		{
			return retval;
		}
		int thestamp = stamp;
		Node next = startsentinel.next;
		HashedLinkedList<V>.Node next2 = retval.startsentinel;
		double num = 2147483647.0 / ((double)size + 1.0);
		int num2 = 1;
		HashedLinkedList<V>.TagGroup tagGroup = null;
		tagGroup = new HashedLinkedList<V>.TagGroup();
		retval.taggroups = 1;
		tagGroup.count = size;
		while (next != endsentinel)
		{
			V val = mapper(next.item);
			modifycheck(thestamp);
			next2.next = new HashedLinkedList<V>.Node(val, next2, null);
			next = next.next;
			next2 = next2.next;
			retval.dict.Add(val, next2);
			next2.taggroup = tagGroup;
			next2.tag = (int)(num * (double)num2++);
		}
		tagGroup.first = retval.startsentinel.next;
		tagGroup.last = next2;
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
		dict.Remove(val);
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
		dict.Remove(val);
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
		dict.Remove(val);
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
			views = new WeakViewList<HashedLinkedList<T>>();
		}
		HashedLinkedList<T> hashedLinkedList = (HashedLinkedList<T>)MemberwiseClone();
		hashedLinkedList.underlying = ((underlying != null) ? underlying : this);
		hashedLinkedList.offset = offset + start;
		hashedLinkedList.size = count;
		getPair(start - 1, start + count, out hashedLinkedList.startsentinel, out hashedLinkedList.endsentinel, new int[2] { -1, size }, new Node[2] { startsentinel, endsentinel });
		hashedLinkedList.myWeakReference = views.Add(hashedLinkedList);
		return hashedLinkedList;
	}

	[ComVisible(true)]
	public virtual IList<T> ViewOf(T item)
	{
		validitycheck();
		if (!contains(item, out var node))
		{
			return null;
		}
		HashedLinkedList<T> hashedLinkedList = (HashedLinkedList<T>)MemberwiseClone();
		hashedLinkedList.underlying = ((underlying != null) ? underlying : this);
		hashedLinkedList.offset = null;
		hashedLinkedList.startsentinel = node.prev;
		hashedLinkedList.endsentinel = node.next;
		hashedLinkedList.size = 1;
		return hashedLinkedList;
	}

	[ComVisible(true)]
	public virtual IList<T> LastViewOf(T item)
	{
		return ViewOf(item);
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
		if (!this.offset.HasValue)
		{
			try
			{
				getPair(offset - 1, offset + size, out startsentinel, out endsentinel, new int[2] { -1, base.size }, new Node[2] { startsentinel, endsentinel });
			}
			catch (NullReferenceException)
			{
				return false;
			}
		}
		else
		{
			if (offset + this.offset < 0 || offset + this.offset + size > underlying.size)
			{
				return false;
			}
			int value = this.offset.Value;
			getPair(offset - 1, offset + size, out startsentinel, out endsentinel, new int[4]
			{
				-value - 1,
				-1,
				base.size,
				underlying.size - value
			}, new Node[4] { underlying.startsentinel, startsentinel, endsentinel, underlying.endsentinel });
		}
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
			foreach (HashedLinkedList<T> view in views)
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
			dict[node.item] = node;
			dict[node2.item] = node2;
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
		int? num = offset + i;
		int? num2 = offset + size - 1 - i;
		while (poslow <= poshigh)
		{
			Position position;
			Position position2 = (position = positions[poslow]);
			if (position2.Endpoint == a)
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
			if (position3.Endpoint == b)
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
		if (underlying != null)
		{
			for (Node next = startsentinel.next; next != endsentinel; next = next.next)
			{
				next.taggroup.count--;
			}
		}
		Node node = startsentinel.next;
		Node node2 = startsentinel.next;
		endsentinel.prev.next = null;
		while (node2 != null)
		{
			Node next2 = node2.next;
			while (next2 != null && c.Compare(node2.item, next2.item) <= 0)
			{
				node2 = next2;
				next2 = node2.next;
			}
			node2.next = null;
			node.prev = next2;
			node = next2;
			if (c.Compare(endsentinel.prev.item, node2.item) <= 0)
			{
				endsentinel.prev = node2;
			}
			node2 = next2;
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
		Node next3 = startsentinel.next;
		Node node6 = endsentinel;
		int lowbound;
		int highbound;
		TagGroup tagGroup = gettaggroup(startsentinel, endsentinel, out lowbound, out highbound);
		int num = highbound / (size + 1) - lowbound / (size + 1);
		num = ((num == 0) ? 1 : num);
		if (underlying == null)
		{
			taggroups = 1;
		}
		while (next3 != node6)
		{
			lowbound = (next3.tag = ((lowbound + num > highbound) ? highbound : (lowbound + num)));
			tagGroup.count++;
			next3.taggroup = tagGroup;
			next3 = next3.next;
		}
		if (tagGroup != startsentinel.taggroup)
		{
			tagGroup.first = startsentinel.next;
		}
		if (tagGroup != endsentinel.taggroup)
		{
			tagGroup.last = endsentinel.prev;
		}
		if (lowbound == highbound)
		{
			splittaggroup(tagGroup);
		}
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
				dict[next.item] = next;
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
		if (!dict.Find(item, out var value) || !insideview(value))
		{
			return ~size;
		}
		value = startsentinel.next;
		int index = 0;
		if (find(item, ref value, ref index))
		{
			return index;
		}
		return ~size;
	}

	[Tested]
	[ComVisible(true)]
	public virtual int LastIndexOf(T item)
	{
		return IndexOf(item);
	}

	[Tested]
	[ComVisible(true)]
	public virtual T RemoveAt(int i)
	{
		updatecheck();
		T val = remove(get(i), i);
		dict.Remove(val);
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
			View(start, count).Clear();
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
			dict.Update(item, node);
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
		Node value = new Node(item);
		if (!dict.FindOrAdd(item, ref value))
		{
			insertNode(updateViews: true, endsentinel, value);
			(underlying ?? this).raiseForAdd(item);
			return false;
		}
		if (!insideview(value))
		{
			throw new ArgumentException("Item alredy in indexed list but outside view");
		}
		item = value.item;
		return true;
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
		Node value = new Node(item);
		if (dict.FindOrAdd(item, ref value))
		{
			if (!insideview(value))
			{
				throw new ArgumentException("Item in indexed list but outside view");
			}
			olditem = value.item;
			dict.Update(item, value);
			value.item = item;
			(underlying ?? this).raiseForUpdate(item, olditem);
			return true;
		}
		insertNode(updateViews: true, endsentinel, value);
		(underlying ?? this).raiseForAdd(item);
		olditem = default(T);
		return false;
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool Remove(T item)
	{
		updatecheck();
		int index = 0;
		if (!dictremove(item, out var node))
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
		if (!dictremove(item, out var node))
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
		foreach (U item2 in items)
		{
			T item = (T)(object)item2;
			if (dictremove(item, out var node))
			{
				if (mustFire)
				{
					raiseForRemoveAllHandler.Remove(node.item);
				}
				remove(node, 118);
			}
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
		for (Node next = startsentinel.next; next != endsentinel; next = next.next)
		{
			bool flag = predicate(next.item);
			updatecheck();
			if (flag)
			{
				dict.Remove(next.item);
				remove(next, 119);
				if (mustFire)
				{
					raiseForRemoveAllHandler.Remove(next.item);
				}
			}
		}
		raiseForRemoveAllHandler.Raise();
	}

	[Tested]
	[ComVisible(true)]
	public virtual void Clear()
	{
		updatecheck();
		if (size == 0)
		{
			return;
		}
		int count = size;
		if (underlying == null)
		{
			dict.Clear();
		}
		else
		{
			using IEnumerator<T> enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				T current = enumerator.Current;
				dict.Remove(current);
			}
		}
		clear();
		(underlying ?? this).raiseForRemoveInterval(Offset, count);
	}

	private void clear()
	{
		if (size == 0)
		{
			return;
		}
		ViewHandler viewHandler = new ViewHandler(this);
		if (viewHandler.viewCount > 0)
		{
			int num = 0;
			Node next = startsentinel.next;
			viewHandler.skipEndpoints(0, next);
			while (next != endsentinel)
			{
				num++;
				next = next.next;
				viewHandler.updateViewSizesAndCounts(num, next);
			}
			viewHandler.updateSentinels(endsentinel, startsentinel, endsentinel);
			if (underlying != null)
			{
				viewHandler.updateViewSizesAndCounts(num, underlying.endsentinel);
			}
		}
		if (underlying != null)
		{
			for (Node next2 = startsentinel.next; next2 != endsentinel; next2 = next2.next)
			{
				next2.next.prev = startsentinel;
				startsentinel.next = next2.next;
				removefromtaggroup(next2);
			}
		}
		else
		{
			taggroups = 0;
		}
		endsentinel.prev = startsentinel;
		startsentinel.next = endsentinel;
		if (underlying != null)
		{
			underlying.size -= size;
		}
		size = 0;
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
		HashSet<T> hashSet = new HashSet<T>(itemequalityComparer);
		using (IEnumerator<T> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				T current = enumerator.Current;
				hashSet.Add(current);
			}
		}
		foreach (U item2 in items)
		{
			T item = (T)(object)item2;
			hashSet.Remove(item);
		}
		Node next = startsentinel.next;
		while (next != endsentinel && hashSet.Count > 0)
		{
			if (hashSet.Contains(next.item))
			{
				dict.Remove(next.item);
				remove(next, 119);
				if (mustFire)
				{
					raiseForRemoveAllHandler.Remove(next.item);
				}
			}
			next = next.next;
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
		for (Node next = startsentinel.next; next != endsentinel; next = next.next)
		{
			bool flag = !predicate(next.item);
			updatecheck();
			if (flag)
			{
				dict.Remove(next.item);
				remove(next, 119);
				if (mustFire)
				{
					raiseForRemoveAllHandler.Remove(next.item);
				}
			}
		}
		raiseForRemoveAllHandler.Raise();
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool ContainsAll<U>(IEnumerable<U> items) where U : T
	{
		validitycheck();
		foreach (U item2 in items)
		{
			T item = (T)(object)item2;
			if (!contains(item, out var _))
			{
				return false;
			}
		}
		return true;
	}

	[Tested]
	[ComVisible(true)]
	public IList<T> FindAll(Fun<T, bool> filter)
	{
		validitycheck();
		int thestamp = stamp;
		HashedLinkedList<T> hashedLinkedList = new HashedLinkedList<T>();
		Node next = startsentinel.next;
		Node next2 = hashedLinkedList.startsentinel;
		double num = 2147483647.0 / ((double)size + 1.0);
		int num2 = 1;
		TagGroup tagGroup = new TagGroup();
		hashedLinkedList.taggroups = 1;
		while (next != endsentinel)
		{
			bool flag = filter(next.item);
			modifycheck(thestamp);
			if (flag)
			{
				next2.next = new Node(next.item, next2, null);
				next2 = next2.next;
				hashedLinkedList.size++;
				hashedLinkedList.dict.Add(next.item, next2);
				next2.taggroup = tagGroup;
				next2.tag = (int)(num * (double)num2++);
			}
			next = next.next;
		}
		if (hashedLinkedList.size > 0)
		{
			tagGroup.count = hashedLinkedList.size;
			tagGroup.first = hashedLinkedList.startsentinel.next;
			tagGroup.last = next2;
		}
		hashedLinkedList.endsentinel.prev = next2;
		next2.next = hashedLinkedList.endsentinel;
		return hashedLinkedList;
	}

	[Tested]
	[ComVisible(true)]
	public virtual int ContainsCount(T item)
	{
		if (!Contains(item))
		{
			return 0;
		}
		return 1;
	}

	[ComVisible(true)]
	public virtual ICollectionValue<T> UniqueItems()
	{
		return this;
	}

	[ComVisible(true)]
	public virtual ICollectionValue<KeyValuePair<T, int>> ItemMultiplicities()
	{
		return new MultiplicityOne<T>(this);
	}

	[Tested]
	[ComVisible(true)]
	public virtual void RemoveAllCopies(T item)
	{
		Remove(item);
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
		Node value = new Node(item);
		if (!dict.FindOrAdd(item, ref value))
		{
			insertNode(updateViews: true, endsentinel, value);
			(underlying ?? this).raiseForAdd(item);
			return true;
		}
		return false;
	}

	[Tested]
	[ComVisible(true)]
	public virtual void AddAll<U>(IEnumerable<U> items) where U : T
	{
		updatecheck();
		int num = 0;
		Node prev = endsentinel.prev;
		foreach (U item in items)
		{
			Node value = new Node((T)(object)item);
			if (!dict.FindOrAdd((T)(object)item, ref value))
			{
				insertNode(updateViews: false, endsentinel, value);
				num++;
			}
		}
		if (num > 0)
		{
			fixViewsAfterInsert(endsentinel, prev, num, 0);
			raiseForInsertAll(prev, size - num, num, insertion: false);
		}
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
		foreach (HashedLinkedList<T> view in views)
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
		int num2 = 0;
		int num3 = 9;
		int num4 = 0;
		TagGroup tagGroup = null;
		if (underlying == null)
		{
			TagGroup taggroup = startsentinel.taggroup;
			if (taggroup.count != 0 || taggroup.first != null || taggroup.last != null || taggroup.tag != int.MinValue)
			{
				Console.WriteLine("Bad startsentinel tag group: {0}", taggroup);
				flag = false;
			}
			taggroup = endsentinel.taggroup;
			if (taggroup.count != 0 || taggroup.first != null || taggroup.last != null || taggroup.tag != int.MaxValue)
			{
				Console.WriteLine("Bad endsentinel tag group: {0}", taggroup);
				flag = false;
			}
		}
		while (next != endsentinel)
		{
			num++;
			if (next.prev != node)
			{
				Console.WriteLine("Bad backpointer at node {0}", num);
				flag = false;
			}
			if (underlying == null)
			{
				if (!next.prev.precedes(next))
				{
					Console.WriteLine("node.prev.tag ({0}, {1}) >= node.tag ({2}, {3}) at index={4} item={5} ", next.prev.taggroup.tag, next.prev.tag, next.taggroup.tag, next.tag, num, next.item);
					flag = false;
				}
				if (next.taggroup != tagGroup)
				{
					if (next.taggroup.first != next)
					{
						string text = zeitem(next.taggroup.first);
						Console.WriteLine("Bad first pointer in taggroup: node.taggroup.first.item ({0}), node.item ({1}) at index={2} item={3}", text, next.item, num, next.item);
						flag = false;
					}
					if (tagGroup != null)
					{
						if (tagGroup.count != num2)
						{
							Console.WriteLine("Bad taggroupsize: oldtg.count ({0}) != taggroupsize ({1}) at index={2} item={3}", tagGroup.count, num2, num, next.item);
							flag = false;
						}
						if (num3 <= 8 && num2 <= 8)
						{
							Console.WriteLine("Two small taggroups in a row: oldtaggroupsize ({0}), taggroupsize ({1}) at index={2} item={3}", num3, num2, num, next.item);
							flag = false;
						}
						if (next.taggroup.tag <= tagGroup.tag)
						{
							Console.WriteLine("Taggroup tags not strictly increasing: oldtaggrouptag ({0}), taggrouptag ({1}) at index={2} item={3}", tagGroup.tag, next.taggroup.tag, num, next.item);
							flag = false;
						}
						if (tagGroup.last != next.prev)
						{
							Console.WriteLine("Bad last pointer in taggroup: oldtg.last.item ({0}), node.prev.item ({1}) at index={2} item={3}", tagGroup.last.item, next.prev.item, num, next.item);
							flag = false;
						}
						num3 = num2;
					}
					num4++;
					tagGroup = next.taggroup;
					num2 = 1;
				}
				else
				{
					num2++;
				}
			}
			node = next;
			next = next.next;
			if (next == null)
			{
				Console.WriteLine("Null next pointer at node {0}", num);
				return false;
			}
		}
		if (underlying == null && size == 0 && taggroups != 0)
		{
			Console.WriteLine("Bad taggroups for empty list: size={0}   taggroups={1}", size, taggroups);
			flag = false;
		}
		if (underlying == null && size > 0)
		{
			tagGroup = next.prev.taggroup;
			if (tagGroup != null)
			{
				if (tagGroup.count != num2)
				{
					Console.WriteLine("Bad taggroupsize: oldtg.count ({0}) != taggroupsize ({1}) at index={2} item={3}", tagGroup.count, num2, num, next.item);
					flag = false;
				}
				if (num3 <= 8 && num2 <= 8)
				{
					Console.WriteLine("Two small taggroups in a row: oldtaggroupsize ({0}), taggroupsize ({1}) at index={2} item={3}", num3, num2, num, next.item);
					flag = false;
				}
				if (next.taggroup.tag <= tagGroup.tag)
				{
					Console.WriteLine("Taggroup tags not strictly increasing: oldtaggrouptag ({0}), taggrouptag ({1}) at index={2} item={3}", tagGroup.tag, next.taggroup.tag, num, next.item);
					flag = false;
				}
				if (tagGroup.last != next.prev)
				{
					Console.WriteLine("Bad last pointer in taggroup: oldtg.last.item ({0}), node.prev.item ({1}) at index={2} item={3}", zeitem(tagGroup.last), zeitem(next.prev), num, next.item);
					flag = false;
				}
			}
			if (num4 != taggroups)
			{
				Console.WriteLine("seentaggroups ({0}) != taggroups ({1}) (at size {2})", num4, taggroups, size);
				flag = false;
			}
		}
		if (num != size)
		{
			Console.WriteLine("size={0} but enumeration gives {1} nodes ", size, num);
			flag = false;
		}
		flag = checkViews() && flag;
		if (!flag)
		{
			return false;
		}
		if (underlying == null)
		{
			if (size != dict.Count)
			{
				Console.WriteLine("list.size ({0}) != dict.Count ({1})", size, dict.Count);
				flag = false;
			}
			for (Node next2 = startsentinel.next; next2 != endsentinel; next2 = next2.next)
			{
				if (!dict.Find(next2.item, out var value))
				{
					Console.WriteLine("Item in list but not dict: {0}", next2.item);
					flag = false;
				}
				else if (next2 != value)
				{
					Console.WriteLine("Wrong node in dict for item: {0}", next2.item);
					flag = false;
				}
			}
		}
		return flag;
	}

	[ComVisible(true)]
	public virtual object Clone()
	{
		HashedLinkedList<T> hashedLinkedList = new HashedLinkedList<T>(itemequalityComparer);
		hashedLinkedList.AddAll(this);
		return hashedLinkedList;
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
