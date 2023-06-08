using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace C5;

[Serializable]
internal class TreeSet<T> : SequencedBase<T>, IIndexedSorted<T>, IIndexed<T>, IPersistentSorted<T>, ISorted<T>, ISequenced<T>, ICollection<T>, IExtensible<T>, ICloneable, System.Collections.Generic.ICollection<T>, IDirectedCollectionValue<T>, ICollectionValue<T>, IShowable, IFormattable, IDirectedEnumerable<T>, IEnumerable<T>, IEnumerable, IDisposable
{
	[Serializable]
	private class Node
	{
		[ComVisible(true)]
		public bool red = true;

		[ComVisible(true)]
		public T item;

		[ComVisible(true)]
		public Node left;

		[ComVisible(true)]
		public Node right;

		[ComVisible(true)]
		public int size = 1;

		[ComVisible(true)]
		public int generation;

		[ComVisible(true)]
		public int lastgeneration = -1;

		[ComVisible(true)]
		public Node oldref;

		[ComVisible(true)]
		public bool leftnode;

		internal static bool update(ref Node cursor, bool leftnode, Node child, int maxsnapid, int generation)
		{
			Node node = (leftnode ? cursor.left : cursor.right);
			if (child == node)
			{
				return false;
			}
			bool result = false;
			if (cursor.generation <= maxsnapid)
			{
				if (cursor.lastgeneration == -1)
				{
					cursor.leftnode = leftnode;
					cursor.lastgeneration = maxsnapid;
					cursor.oldref = node;
				}
				else if (cursor.leftnode != leftnode || cursor.lastgeneration < maxsnapid)
				{
					CopyNode(ref cursor, maxsnapid, generation);
					result = true;
				}
			}
			if (leftnode)
			{
				cursor.left = child;
			}
			else
			{
				cursor.right = child;
			}
			return result;
		}

		[ComVisible(true)]
		public static bool CopyNode(ref Node cursor, int maxsnapid, int generation)
		{
			if (cursor.generation <= maxsnapid)
			{
				cursor = (Node)cursor.MemberwiseClone();
				cursor.generation = generation;
				cursor.lastgeneration = -1;
				return true;
			}
			return false;
		}

		[ComVisible(true)]
		public Node()
		{
		}
	}

	internal class Enumerator : IEnumerator<T>, IDisposable, IEnumerator
	{
		private TreeSet<T> tree;

		private bool valid;

		private int stamp;

		private T current;

		private Node cursor;

		private Node[] path;

		private int level;

		private bool disposed;

		[Tested]
		[ComVisible(true)]
		public T Current
		{
			[Tested]
			[ComVisible(true)]
			get
			{
				if (valid)
				{
					return current;
				}
				throw new InvalidOperationException();
			}
		}

		object IEnumerator.Current => Current;

		[ComVisible(true)]
		public Enumerator(TreeSet<T> tree)
		{
			this.tree = tree;
			stamp = tree.stamp;
			path = new Node[2 * tree.blackdepth];
			cursor = new Node();
			cursor.right = tree.root;
		}

		[Tested]
		[ComVisible(true)]
		public bool MoveNext()
		{
			tree.modifycheck(stamp);
			if (cursor.right != null)
			{
				path[level] = (cursor = cursor.right);
				while (cursor.left != null)
				{
					path[++level] = (cursor = cursor.left);
				}
			}
			else
			{
				if (level == 0)
				{
					return valid = false;
				}
				cursor = path[--level];
			}
			current = cursor.item;
			return valid = true;
		}

		[Tested]
		[ComVisible(true)]
		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				current = default(T);
				cursor = null;
				path = null;
				disposed = true;
			}
		}

		~Enumerator()
		{
			Dispose(disposing: false);
		}

		bool IEnumerator.MoveNext()
		{
			return MoveNext();
		}

		void IEnumerator.Reset()
		{
			throw new Exception("The method or operation is not implemented.");
		}
	}

	internal class SnapEnumerator : IEnumerator<T>, IDisposable, IEnumerator
	{
		private TreeSet<T> tree;

		private bool valid;

		private int stamp;

		private T current;

		private Node cursor;

		private Node[] path;

		private int level;

		[Tested]
		[ComVisible(true)]
		public T Current
		{
			[Tested]
			[ComVisible(true)]
			get
			{
				if (valid)
				{
					return current;
				}
				throw new InvalidOperationException();
			}
		}

		object IEnumerator.Current => Current;

		[ComVisible(true)]
		public SnapEnumerator(TreeSet<T> tree)
		{
			this.tree = tree;
			stamp = tree.stamp;
			path = new Node[2 * tree.blackdepth];
			cursor = new Node();
			cursor.right = tree.root;
		}

		[Tested]
		[ComVisible(true)]
		public bool MoveNext()
		{
			tree.modifycheck(stamp);
			Node node = tree.right(cursor);
			if (node != null)
			{
				path[level] = (cursor = node);
				for (node = tree.left(cursor); node != null; node = tree.left(cursor))
				{
					path[++level] = (cursor = node);
				}
			}
			else
			{
				if (level == 0)
				{
					return valid = false;
				}
				cursor = path[--level];
			}
			current = cursor.item;
			return valid = true;
		}

		[Tested]
		void IDisposable.Dispose()
		{
			tree = null;
			valid = false;
			current = default(T);
			cursor = null;
			path = null;
		}

		bool IEnumerator.MoveNext()
		{
			return MoveNext();
		}

		void IEnumerator.Reset()
		{
			throw new Exception("The method or operation is not implemented.");
		}
	}

	private class Interval : DirectedCollectionValueBase<T>, IDirectedCollectionValue<T>, ICollectionValue<T>, IShowable, IFormattable, IDirectedEnumerable<T>, IEnumerable<T>, IEnumerable
	{
		private int start;

		private int length;

		private int stamp;

		private bool forwards;

		private TreeSet<T> tree;

		[ComVisible(true)]
		public override bool IsEmpty
		{
			[ComVisible(true)]
			get
			{
				return length == 0;
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
				return length;
			}
		}

		[ComVisible(true)]
		public override Speed CountSpeed
		{
			[ComVisible(true)]
			get
			{
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

		internal Interval(TreeSet<T> tree, int start, int count, bool forwards)
		{
			if (tree.isSnapShot)
			{
				throw new NotSupportedException("Indexing not supported for snapshots");
			}
			this.start = start;
			length = count;
			this.forwards = forwards;
			this.tree = tree;
			stamp = tree.stamp;
		}

		[ComVisible(true)]
		public override T Choose()
		{
			if (length == 0)
			{
				throw new NoSuchItemException();
			}
			return tree[start];
		}

		[Tested]
		[ComVisible(true)]
		public override IEnumerator<T> GetEnumerator()
		{
			tree.modifycheck(stamp);
			Node cursor = tree.root;
			Node[] path = new Node[2 * tree.blackdepth];
			int level = 0;
			int totaltogo = length;
			if (totaltogo == 0)
			{
				yield break;
			}
			if (forwards)
			{
				int i = start;
				while (true)
				{
					int num = ((cursor.left != null) ? cursor.left.size : 0);
					if (i > num)
					{
						i -= num + 1;
						cursor = cursor.right;
						continue;
					}
					if (i == num)
					{
						break;
					}
					path[level++] = cursor;
					cursor = cursor.left;
				}
				T current = cursor.item;
				while (totaltogo-- > 0)
				{
					yield return current;
					tree.modifycheck(stamp);
					if (cursor.right != null)
					{
						int num2 = level;
						Node right;
						cursor = (right = cursor.right);
						path[num2] = right;
						while (cursor.left != null)
						{
							int num3;
							level = (num3 = level + 1);
							Node left;
							cursor = (left = cursor.left);
							path[num3] = left;
						}
					}
					else
					{
						if (level == 0)
						{
							break;
						}
						int num4;
						level = (num4 = level - 1);
						cursor = path[num4];
					}
					current = cursor.item;
				}
				yield break;
			}
			int j = start + length - 1;
			while (true)
			{
				int num5 = ((cursor.left != null) ? cursor.left.size : 0);
				if (j > num5)
				{
					j -= num5 + 1;
					path[level++] = cursor;
					cursor = cursor.right;
					continue;
				}
				if (j == num5)
				{
					break;
				}
				cursor = cursor.left;
			}
			T current2 = cursor.item;
			while (totaltogo-- > 0)
			{
				yield return current2;
				tree.modifycheck(stamp);
				if (cursor.left != null)
				{
					int num6 = level;
					Node left2;
					cursor = (left2 = cursor.left);
					path[num6] = left2;
					while (cursor.right != null)
					{
						int num7;
						level = (num7 = level + 1);
						Node right2;
						cursor = (right2 = cursor.right);
						path[num7] = right2;
					}
				}
				else
				{
					if (level == 0)
					{
						break;
					}
					int num8;
					level = (num8 = level - 1);
					cursor = path[num8];
				}
				current2 = cursor.item;
			}
		}

		[Tested]
		[ComVisible(true)]
		public override IDirectedCollectionValue<T> Backwards()
		{
			return new Interval(tree, start, length, !forwards);
		}

		[Tested]
		IDirectedEnumerable<T> IDirectedEnumerable<T>.Backwards()
		{
			return Backwards();
		}
	}

	[Serializable]
	private class SnapRef
	{
		[ComVisible(true)]
		public SnapRef Prev;

		[ComVisible(true)]
		public SnapRef Next;

		[ComVisible(true)]
		public WeakReference Tree;

		[ComVisible(true)]
		public SnapRef(TreeSet<T> tree)
		{
			Tree = new WeakReference(tree);
		}

		[ComVisible(true)]
		public void Dispose()
		{
			Next.Prev = Prev;
			if (Prev != null)
			{
				Prev.Next = Next;
			}
			Next = (Prev = null);
		}
	}

	internal class Range : DirectedCollectionValueBase<T>, IDirectedCollectionValue<T>, ICollectionValue<T>, IShowable, IFormattable, IDirectedEnumerable<T>, IEnumerable<T>, IEnumerable
	{
		internal class Enumerator : IEnumerator<T>, IDisposable, IEnumerator
		{
			private bool valid;

			private bool ready = true;

			private IComparer<T> comparer;

			private T current;

			private Node cursor;

			private Node[] path;

			private int level;

			private Range range;

			private bool forwards;

			[Tested]
			[ComVisible(true)]
			public T Current
			{
				[Tested]
				[ComVisible(true)]
				get
				{
					if (valid)
					{
						return current;
					}
					throw new InvalidOperationException();
				}
			}

			object IEnumerator.Current => Current;

			[Tested]
			[ComVisible(true)]
			public Enumerator(Range range)
			{
				comparer = range.basis.comparer;
				path = new Node[2 * range.basis.blackdepth];
				this.range = range;
				forwards = range.direction == EnumerationDirection.Forwards;
				cursor = new Node();
				if (forwards)
				{
					cursor.right = range.basis.root;
				}
				else
				{
					cursor.left = range.basis.root;
				}
				range.basis.modifycheck(range.stamp);
			}

			private int compare(T i1, T i2)
			{
				return comparer.Compare(i1, i2);
			}

			[Tested]
			[ComVisible(true)]
			public bool MoveNext()
			{
				range.basis.modifycheck(range.stamp);
				if (!ready)
				{
					return false;
				}
				if (forwards)
				{
					if (!valid && range.haslowend)
					{
						cursor = cursor.right;
						while (cursor != null)
						{
							int num = compare(cursor.item, range.lowend);
							if (num > 0)
							{
								path[level++] = cursor;
								cursor = range.basis.left(cursor);
								continue;
							}
							if (num < 0)
							{
								cursor = range.basis.right(cursor);
								continue;
							}
							path[level] = cursor;
							break;
						}
						if (cursor == null)
						{
							if (level == 0)
							{
								return valid = (ready = false);
							}
							cursor = path[--level];
						}
					}
					else if (range.basis.right(cursor) != null)
					{
						path[level] = (cursor = range.basis.right(cursor));
						for (Node node = range.basis.left(cursor); node != null; node = range.basis.left(cursor))
						{
							path[++level] = (cursor = node);
						}
					}
					else
					{
						if (level == 0)
						{
							return valid = (ready = false);
						}
						cursor = path[--level];
					}
					current = cursor.item;
					if (range.hashighend && compare(current, range.highend) >= 0)
					{
						return valid = (ready = false);
					}
					return valid = true;
				}
				if (!valid && range.hashighend)
				{
					cursor = cursor.left;
					while (cursor != null)
					{
						int num2 = compare(cursor.item, range.highend);
						if (num2 < 0)
						{
							path[level++] = cursor;
							cursor = range.basis.right(cursor);
						}
						else
						{
							cursor = range.basis.left(cursor);
						}
					}
					if (cursor == null)
					{
						if (level == 0)
						{
							return valid = (ready = false);
						}
						cursor = path[--level];
					}
				}
				else if (range.basis.left(cursor) != null)
				{
					path[level] = (cursor = range.basis.left(cursor));
					for (Node node2 = range.basis.right(cursor); node2 != null; node2 = range.basis.right(cursor))
					{
						path[++level] = (cursor = node2);
					}
				}
				else
				{
					if (level == 0)
					{
						return valid = (ready = false);
					}
					cursor = path[--level];
				}
				current = cursor.item;
				if (range.haslowend && compare(current, range.lowend) < 0)
				{
					return valid = (ready = false);
				}
				return valid = true;
			}

			[Tested]
			[ComVisible(true)]
			public void Dispose()
			{
				comparer = null;
				current = default(T);
				cursor = null;
				path = null;
				range = null;
			}

			bool IEnumerator.MoveNext()
			{
				return MoveNext();
			}

			void IEnumerator.Reset()
			{
				throw new Exception("The method or operation is not implemented.");
			}
		}

		private int stamp;

		private int size;

		private TreeSet<T> basis;

		private T lowend;

		private T highend;

		private bool haslowend;

		private bool hashighend;

		private EnumerationDirection direction;

		[Tested]
		[ComVisible(true)]
		public override EnumerationDirection Direction
		{
			[Tested]
			[ComVisible(true)]
			get
			{
				return direction;
			}
		}

		[ComVisible(true)]
		public override bool IsEmpty
		{
			[ComVisible(true)]
			get
			{
				return size == 0;
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
				return size;
			}
		}

		[ComVisible(true)]
		public override Speed CountSpeed
		{
			[ComVisible(true)]
			get
			{
				return Speed.Constant;
			}
		}

		[Tested]
		[ComVisible(true)]
		public Range(TreeSet<T> basis, bool haslowend, T lowend, bool hashighend, T highend, EnumerationDirection direction)
		{
			this.basis = basis;
			stamp = basis.stamp;
			this.lowend = lowend;
			this.highend = highend;
			this.haslowend = haslowend;
			this.hashighend = hashighend;
			this.direction = direction;
			if (!basis.isSnapShot)
			{
				size = ((!haslowend) ? (hashighend ? basis.CountTo(highend) : basis.Count) : (hashighend ? basis.CountFromTo(lowend, highend) : basis.CountFrom(lowend)));
			}
		}

		[ComVisible(true)]
		public override T Choose()
		{
			if (size == 0)
			{
				throw new NoSuchItemException();
			}
			return lowend;
		}

		[Tested]
		[ComVisible(true)]
		public override IEnumerator<T> GetEnumerator()
		{
			return new Enumerator(this);
		}

		private bool inside(T item)
		{
			if (!haslowend || basis.comparer.Compare(item, lowend) >= 0)
			{
				if (hashighend)
				{
					return basis.comparer.Compare(item, highend) < 0;
				}
				return true;
			}
			return false;
		}

		private void checkstamp()
		{
			if (stamp < basis.stamp)
			{
				throw new CollectionModifiedException();
			}
		}

		private void syncstamp()
		{
			stamp = basis.stamp;
		}

		[Tested]
		[ComVisible(true)]
		public override IDirectedCollectionValue<T> Backwards()
		{
			Range range = (Range)MemberwiseClone();
			range.direction = ((direction == EnumerationDirection.Forwards) ? EnumerationDirection.Backwards : EnumerationDirection.Forwards);
			return range;
		}

		[Tested]
		IDirectedEnumerable<T> IDirectedEnumerable<T>.Backwards()
		{
			return Backwards();
		}
	}

	private IComparer<T> comparer;

	private Node root;

	private int blackdepth;

	private int[] dirs = new int[2];

	private Node[] path = new Node[2];

	private bool isSnapShot;

	private int generation;

	private bool isValid = true;

	private SnapRef snapList;

	[ComVisible(true)]
	public override EventTypeEnum ListenableEvents
	{
		[ComVisible(true)]
		get
		{
			return EventTypeEnum.Basic;
		}
	}

	[Tested]
	[ComVisible(true)]
	public bool AllowsDuplicates
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

	[Tested]
	[ComVisible(true)]
	public Speed ContainsSpeed
	{
		[Tested]
		[ComVisible(true)]
		get
		{
			return Speed.Log;
		}
	}

	[Tested]
	[ComVisible(true)]
	public T this[int i]
	{
		[Tested]
		[ComVisible(true)]
		get
		{
			return findNode(i).item;
		}
	}

	[ComVisible(true)]
	public virtual Speed IndexingSpeed
	{
		[ComVisible(true)]
		get
		{
			return Speed.Log;
		}
	}

	[Tested]
	[ComVisible(true)]
	public IDirectedCollectionValue<T> this[int start, int end]
	{
		[Tested]
		[ComVisible(true)]
		get
		{
			checkRange(start, end - start);
			return new Interval(this, start, end - start, forwards: true);
		}
	}

	[ComVisible(true)]
	public IComparer<T> Comparer
	{
		[ComVisible(true)]
		get
		{
			return comparer;
		}
	}

	private int maxsnapid
	{
		get
		{
			if (snapList != null)
			{
				return findLastLiveSnapShot();
			}
			return -1;
		}
	}

	private Node left(Node n)
	{
		if (isSnapShot && n.lastgeneration >= generation && n.leftnode)
		{
			return n.oldref;
		}
		return n.left;
	}

	private Node right(Node n)
	{
		if (isSnapShot && n.lastgeneration >= generation && !n.leftnode)
		{
			return n.oldref;
		}
		return n.right;
	}

	private void stackcheck()
	{
		while (dirs.Length < 2 * blackdepth)
		{
			dirs = new int[2 * dirs.Length];
			path = new Node[2 * dirs.Length];
		}
	}

	[ComVisible(true)]
	public TreeSet()
		: this(Comparer<T>.Default, EqualityComparer<T>.Default)
	{
	}

	[ComVisible(true)]
	public TreeSet(IComparer<T> comparer)
		: this(comparer, (IEqualityComparer<T>)new ComparerZeroHashCodeEqualityComparer<T>(comparer))
	{
	}

	[ComVisible(true)]
	public TreeSet(IComparer<T> comparer, IEqualityComparer<T> equalityComparer)
		: base(equalityComparer)
	{
		if (comparer == null)
		{
			throw new NullReferenceException("Item comparer cannot be null");
		}
		this.comparer = comparer;
	}

	private IEnumerator<T> getEnumerator(Node node, int origstamp)
	{
		if (node == null)
		{
			yield break;
		}
		if (node.left != null)
		{
			IEnumerator<T> child2 = getEnumerator(node.left, origstamp);
			while (child2.MoveNext())
			{
				modifycheck(origstamp);
				yield return child2.Current;
			}
		}
		modifycheck(origstamp);
		yield return node.item;
		if (node.right != null)
		{
			IEnumerator<T> child = getEnumerator(node.right, origstamp);
			while (child.MoveNext())
			{
				modifycheck(origstamp);
				yield return child.Current;
			}
		}
	}

	[Tested]
	[ComVisible(true)]
	public override T Choose()
	{
		if (!isValid)
		{
			throw new ViewDisposedException("Snapshot has been disposed");
		}
		if (size == 0)
		{
			throw new NoSuchItemException();
		}
		return root.item;
	}

	[Tested]
	[ComVisible(true)]
	public override IEnumerator<T> GetEnumerator()
	{
		if (!isValid)
		{
			throw new ViewDisposedException("Snapshot has been disposed");
		}
		if (isSnapShot)
		{
			return new SnapEnumerator(this);
		}
		return new Enumerator(this);
	}

	private bool addIterative(T item, ref T founditem, bool update, out bool wasfound)
	{
		wasfound = false;
		if (root == null)
		{
			root = new Node();
			root.red = false;
			blackdepth = 1;
			root.item = item;
			root.generation = generation;
			return true;
		}
		stackcheck();
		int num = 0;
		Node cursor = root;
		int num2;
		Node node;
		while (true)
		{
			num2 = comparer.Compare(cursor.item, item);
			if (num2 == 0)
			{
				founditem = cursor.item;
				bool flag = update;
				if (update)
				{
					Node.CopyNode(ref cursor, maxsnapid, generation);
					cursor.item = item;
				}
				while (num-- > 0)
				{
					if (flag)
					{
						Node child = cursor;
						cursor = path[num];
						Node.update(ref cursor, dirs[num] > 0, child, maxsnapid, generation);
					}
					path[num] = null;
				}
				if (update)
				{
					root = cursor;
				}
				return false;
			}
			node = ((num2 > 0) ? cursor.left : cursor.right);
			if (node == null)
			{
				break;
			}
			dirs[num] = num2;
			path[num++] = cursor;
			cursor = node;
		}
		node = new Node();
		node.item = item;
		node.generation = generation;
		Node.update(ref cursor, num2 > 0, node, maxsnapid, generation);
		cursor.size++;
		dirs[num] = num2;
		while (cursor.red)
		{
			Node cursor2 = cursor;
			cursor = path[--num];
			path[num] = null;
			Node.update(ref cursor, dirs[num] > 0, cursor2, maxsnapid, generation);
			cursor.size++;
			int num3 = dirs[num];
			Node node2 = ((num3 > 0) ? cursor.right : cursor.left);
			if (node2 != null && node2.red)
			{
				cursor2.red = false;
				Node.update(ref cursor, num3 < 0, node2, maxsnapid, generation);
				node2.red = false;
				if (num == 0)
				{
					root = cursor;
					blackdepth++;
					return true;
				}
				cursor.red = true;
				cursor2 = cursor;
				cursor = path[--num];
				Node.update(ref cursor, dirs[num] > 0, cursor2, maxsnapid, generation);
				path[num] = null;
				cursor.size++;
				continue;
			}
			int num4 = dirs[num + 1];
			cursor.red = true;
			if (num3 > 0)
			{
				if (num4 > 0)
				{
					Node.update(ref cursor, leftnode: true, cursor2.right, maxsnapid, generation);
					Node.update(ref cursor2, leftnode: false, cursor, maxsnapid, generation);
					cursor = cursor2;
				}
				else
				{
					Node cursor3 = cursor2.right;
					Node.update(ref cursor, leftnode: true, cursor3.right, maxsnapid, generation);
					Node.update(ref cursor2, leftnode: false, cursor3.left, maxsnapid, generation);
					Node.CopyNode(ref cursor3, maxsnapid, generation);
					cursor3.left = cursor2;
					cursor3.right = cursor;
					cursor = cursor3;
				}
			}
			else if (num4 < 0)
			{
				Node.update(ref cursor, leftnode: false, cursor2.left, maxsnapid, generation);
				Node.update(ref cursor2, leftnode: true, cursor, maxsnapid, generation);
				cursor = cursor2;
			}
			else
			{
				Node cursor4 = cursor2.left;
				Node.update(ref cursor, leftnode: false, cursor4.left, maxsnapid, generation);
				Node.update(ref cursor2, leftnode: true, cursor4.right, maxsnapid, generation);
				Node.CopyNode(ref cursor4, maxsnapid, generation);
				cursor4.right = cursor2;
				cursor4.left = cursor;
				cursor = cursor4;
			}
			cursor.red = false;
			Node node3 = cursor.right;
			cursor.size = (node3.size = ((node3.left != null) ? node3.left.size : 0) + ((node3.right != null) ? node3.right.size : 0) + 1);
			node3 = cursor.left;
			node3.size = ((node3.left != null) ? node3.left.size : 0) + ((node3.right != null) ? node3.right.size : 0) + 1;
			cursor.size += node3.size + 1;
			if (num == 0)
			{
				root = cursor;
				return true;
			}
			cursor2 = cursor;
			cursor = path[--num];
			path[num] = null;
			Node.update(ref cursor, dirs[num] > 0, cursor2, maxsnapid, generation);
			cursor.size++;
			break;
		}
		bool flag2 = true;
		while (num > 0)
		{
			Node child2 = cursor;
			cursor = path[--num];
			path[num] = null;
			if (flag2)
			{
				flag2 = Node.update(ref cursor, dirs[num] > 0, child2, maxsnapid, generation);
			}
			cursor.size++;
		}
		root = cursor;
		return true;
	}

	[Tested]
	[ComVisible(true)]
	public bool Add(T item)
	{
		if (!isValid)
		{
			throw new ViewDisposedException("Snapshot has been disposed");
		}
		updatecheck();
		T j = default(T);
		if (!add(item, ref j))
		{
			return false;
		}
		if (ActiveEvents != 0)
		{
			raiseForAdd(j);
		}
		return true;
	}

	[Tested]
	void System.Collections.Generic.ICollection<T>.Add(T item)
	{
		Add(item);
	}

	private bool add(T item, ref T j)
	{
		if (addIterative(item, ref j, update: false, out var wasfound))
		{
			size++;
			if (!wasfound)
			{
				j = item;
			}
			return true;
		}
		return false;
	}

	[Tested]
	[ComVisible(true)]
	public void AddAll<U>(IEnumerable<U> items) where U : T
	{
		if (!isValid)
		{
			throw new ViewDisposedException("Snapshot has been disposed");
		}
		updatecheck();
		int num = 0;
		T founditem = default(T);
		bool flag = (ActiveEvents & EventTypeEnum.Added) != 0;
		CircularQueue<T> circularQueue = (flag ? new CircularQueue<T>() : null);
		foreach (U item in items)
		{
			T val = (T)(object)item;
			if (addIterative(val, ref founditem, update: false, out var wasfound))
			{
				num++;
				if (flag)
				{
					circularQueue.Enqueue(wasfound ? founditem : val);
				}
			}
		}
		if (num == 0)
		{
			return;
		}
		size += num;
		if (flag)
		{
			foreach (T item2 in circularQueue)
			{
				raiseItemsAdded(item2, 1);
			}
		}
		if ((ActiveEvents & EventTypeEnum.Changed) != 0)
		{
			raiseCollectionChanged();
		}
	}

	[Tested]
	[ComVisible(true)]
	public void AddSorted<U>(IEnumerable<U> items) where U : T
	{
		if (size > 0)
		{
			AddAll(items);
			return;
		}
		if (!isValid)
		{
			throw new ViewDisposedException("Snapshot has been disposed");
		}
		updatecheck();
		addSorted(items, safe: true, raise: true);
	}

	private static Node maketreer(ref Node rest, int blackheight, int maxred, int red)
	{
		if (blackheight == 1)
		{
			Node node = rest;
			rest = rest.right;
			if (red > 0)
			{
				node.right = null;
				rest.left = node;
				node = rest;
				node.size = 1 + red;
				rest = rest.right;
				red--;
			}
			if (red > 0)
			{
				node.right = rest;
				rest = rest.right;
				node.right.right = null;
			}
			else
			{
				node.right = null;
			}
			node.red = false;
			return node;
		}
		maxred >>= 1;
		int num = ((red > maxred) ? maxred : red);
		Node node2 = maketreer(ref rest, blackheight - 1, maxred, num);
		Node node3 = rest;
		rest = rest.right;
		node3.left = node2;
		node3.red = false;
		node3.right = maketreer(ref rest, blackheight - 1, maxred, red - num);
		node3.size = (maxred << 1) - 1 + red;
		return node3;
	}

	private void addSorted<U>(IEnumerable<U> items, bool safe, bool raise) where U : T
	{
		IEnumerator<U> enumerator = items.GetEnumerator();
		if (size > 0)
		{
			throw new InternalException("This can't happen");
		}
		if (!enumerator.MoveNext())
		{
			return;
		}
		Node rest = new Node();
		Node node = rest;
		int num = 1;
		T x = (node.item = (T)(object)enumerator.Current);
		while (enumerator.MoveNext())
		{
			num++;
			node.right = new Node();
			node = node.right;
			node.item = (T)(object)enumerator.Current;
			if (safe)
			{
				if (comparer.Compare(x, node.item) >= 0)
				{
					throw new ArgumentException("Argument not sorted");
				}
				x = node.item;
			}
			node.generation = generation;
		}
		int num2 = 0;
		int num3 = num;
		int num4 = 1;
		while (num4 <= num3)
		{
			num3 -= num4;
			num4 <<= 1;
			num2++;
		}
		root = maketreer(ref rest, num2, num4, num3);
		blackdepth = num2;
		size = num;
		if (!raise)
		{
			return;
		}
		if ((ActiveEvents & EventTypeEnum.Added) != 0)
		{
			CircularQueue<T> circularQueue = new CircularQueue<T>();
			using (IEnumerator<T> enumerator2 = GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					T current = enumerator2.Current;
					circularQueue.Enqueue(current);
				}
			}
			foreach (T item in circularQueue)
			{
				raiseItemsAdded(item, 1);
			}
		}
		if ((ActiveEvents & EventTypeEnum.Changed) != 0)
		{
			raiseCollectionChanged();
		}
	}

	[Tested]
	[ComVisible(true)]
	public bool Contains(T item)
	{
		if (!isValid)
		{
			throw new ViewDisposedException("Snapshot has been disposed");
		}
		int num = 0;
		for (Node node = root; node != null; node = ((num < 0) ? right(node) : left(node)))
		{
			num = comparer.Compare(node.item, item);
			if (num == 0)
			{
				return true;
			}
		}
		return false;
	}

	[Tested]
	[ComVisible(true)]
	public bool Find(ref T item)
	{
		if (!isValid)
		{
			throw new ViewDisposedException("Snapshot has been disposed");
		}
		int num = 0;
		for (Node node = root; node != null; node = ((num < 0) ? right(node) : left(node)))
		{
			num = comparer.Compare(node.item, item);
			if (num == 0)
			{
				item = node.item;
				return true;
			}
		}
		return false;
	}

	[Tested]
	[ComVisible(true)]
	public bool FindOrAdd(ref T item)
	{
		if (!isValid)
		{
			throw new ViewDisposedException("Snapshot has been disposed");
		}
		updatecheck();
		if (addIterative(item, ref item, update: false, out var wasfound))
		{
			size++;
			if (ActiveEvents != 0 && !wasfound)
			{
				raiseForAdd(item);
			}
			return wasfound;
		}
		return true;
	}

	[Tested]
	[ComVisible(true)]
	public bool Update(T item)
	{
		T olditem = item;
		return Update(item, out olditem);
	}

	[ComVisible(true)]
	public bool Update(T item, out T olditem)
	{
		if (!isValid)
		{
			throw new ViewDisposedException("Snapshot has been disposed");
		}
		updatecheck();
		stackcheck();
		int num = 0;
		Node cursor = root;
		int num2 = 0;
		while (cursor != null)
		{
			num2 = comparer.Compare(cursor.item, item);
			if (num2 == 0)
			{
				Node.CopyNode(ref cursor, maxsnapid, generation);
				olditem = cursor.item;
				cursor.item = item;
				while (num > 0)
				{
					Node child = cursor;
					cursor = path[--num];
					path[num] = null;
					Node.update(ref cursor, dirs[num] > 0, child, maxsnapid, generation);
				}
				root = cursor;
				if (ActiveEvents != 0)
				{
					raiseForUpdate(item, olditem);
				}
				return true;
			}
			dirs[num] = num2;
			path[num++] = cursor;
			cursor = ((num2 < 0) ? cursor.right : cursor.left);
		}
		olditem = default(T);
		return false;
	}

	[Tested]
	[ComVisible(true)]
	public bool UpdateOrAdd(T item)
	{
		T olditem;
		return UpdateOrAdd(item, out olditem);
	}

	[ComVisible(true)]
	public bool UpdateOrAdd(T item, out T olditem)
	{
		if (!isValid)
		{
			throw new ViewDisposedException("Snapshot has been disposed");
		}
		updatecheck();
		olditem = default(T);
		if (addIterative(item, ref olditem, update: true, out var wasfound))
		{
			size++;
			if (ActiveEvents != 0)
			{
				raiseForAdd(wasfound ? olditem : item);
			}
			return wasfound;
		}
		if (ActiveEvents != 0)
		{
			raiseForUpdate(item, olditem, 1);
		}
		return true;
	}

	[Tested]
	[ComVisible(true)]
	public bool Remove(T item)
	{
		if (!isValid)
		{
			throw new ViewDisposedException("Snapshot has been disposed");
		}
		updatecheck();
		if (root == null)
		{
			return false;
		}
		int wasRemoved;
		bool flag = removeIterative(ref item, all: false, out wasRemoved);
		if (ActiveEvents != 0 && flag)
		{
			raiseForRemove(item);
		}
		return flag;
	}

	[Tested]
	[ComVisible(true)]
	public bool Remove(T item, out T removeditem)
	{
		if (!isValid)
		{
			throw new ViewDisposedException("Snapshot has been disposed");
		}
		updatecheck();
		removeditem = item;
		if (root == null)
		{
			return false;
		}
		int wasRemoved;
		bool flag = removeIterative(ref removeditem, all: false, out wasRemoved);
		if (ActiveEvents != 0 && flag)
		{
			raiseForRemove(item);
		}
		return flag;
	}

	private bool removeIterative(ref T item, bool all, out int wasRemoved)
	{
		wasRemoved = 0;
		stackcheck();
		int num = 0;
		Node node = root;
		while (true)
		{
			int num2 = comparer.Compare(node.item, item);
			if (num2 == 0)
			{
				item = node.item;
				wasRemoved = 1;
				return removeIterativePhase2(node, num);
			}
			Node node2 = ((num2 > 0) ? node.left : node.right);
			if (node2 == null)
			{
				break;
			}
			dirs[num] = num2;
			path[num++] = node;
			node = node2;
		}
		return false;
	}

	private bool removeIterativePhase2(Node cursor, int level)
	{
		if (size == 1)
		{
			clear();
			return true;
		}
		size--;
		int num = level;
		if (cursor.left != null && cursor.right != null)
		{
			dirs[level] = 1;
			path[level++] = cursor;
			cursor = cursor.left;
			while (cursor.right != null)
			{
				dirs[level] = -1;
				path[level++] = cursor;
				cursor = cursor.right;
			}
			Node.CopyNode(ref path[num], maxsnapid, generation);
			path[num].item = cursor.item;
		}
		Node node = ((cursor.right == null) ? cursor.left : cursor.right);
		bool flag = node == null && !cursor.red;
		if (node != null)
		{
			node.red = false;
		}
		if (level == 0)
		{
			root = node;
			return true;
		}
		level--;
		cursor = path[level];
		path[level] = null;
		int num2 = dirs[level];
		Node.update(ref cursor, num2 > 0, node, maxsnapid, generation);
		Node cursor2 = ((num2 > 0) ? cursor.right : cursor.left);
		cursor.size--;
		Node node2 = null;
		Node cursor3 = null;
		while (flag && !cursor2.red)
		{
			node2 = ((num2 > 0) ? cursor2.right : cursor2.left);
			if (node2 != null && node2.red)
			{
				break;
			}
			cursor3 = ((num2 > 0) ? cursor2.left : cursor2.right);
			if (cursor3 != null && cursor3.red)
			{
				break;
			}
			cursor2.red = true;
			if (level == 0)
			{
				cursor.red = false;
				blackdepth--;
				root = cursor;
				return true;
			}
			if (cursor.red)
			{
				cursor.red = false;
				flag = false;
				break;
			}
			Node child = cursor;
			cursor = path[--level];
			path[level] = null;
			num2 = dirs[level];
			cursor2 = ((num2 > 0) ? cursor.right : cursor.left);
			Node.update(ref cursor, num2 > 0, child, maxsnapid, generation);
			cursor.size--;
		}
		if (flag)
		{
			Node cursor4 = cursor;
			if (cursor2.red)
			{
				Node cursor5;
				Node node3;
				if (num2 > 0)
				{
					cursor3 = cursor2.left;
					node2 = cursor2.right;
					cursor5 = cursor3.left;
					node3 = cursor3.right;
				}
				else
				{
					cursor3 = cursor2.right;
					node2 = cursor2.left;
					cursor5 = cursor3.right;
					node3 = cursor3.left;
				}
				if (node3 != null && node3.red)
				{
					Node.CopyNode(ref cursor3, maxsnapid, generation);
					Node.update(ref cursor4, num2 < 0, cursor5, maxsnapid, generation);
					Node.update(ref cursor2, num2 > 0, cursor3, maxsnapid, generation);
					if (num2 > 0)
					{
						cursor3.left = cursor4;
						cursor4.right = cursor5;
					}
					else
					{
						cursor3.right = cursor4;
						cursor4.left = cursor5;
					}
					cursor = cursor2;
					cursor2.red = false;
					cursor3.red = true;
					node3.red = false;
					cursor.size = cursor4.size;
					cursor3.size = cursor.size - 1 - node2.size;
					cursor4.size = cursor3.size - 1 - node3.size;
				}
				else if (cursor5 != null && cursor5.red)
				{
					Node.CopyNode(ref cursor5, maxsnapid, generation);
					if (num2 > 0)
					{
						Node.update(ref cursor2, leftnode: true, cursor5, maxsnapid, generation);
						Node.update(ref cursor3, leftnode: true, cursor5.right, maxsnapid, generation);
						Node.update(ref cursor4, leftnode: false, cursor5.left, maxsnapid, generation);
						cursor5.left = cursor4;
						cursor5.right = cursor3;
					}
					else
					{
						Node.update(ref cursor2, leftnode: false, cursor5, maxsnapid, generation);
						Node.update(ref cursor3, leftnode: false, cursor5.left, maxsnapid, generation);
						Node.update(ref cursor4, leftnode: true, cursor5.right, maxsnapid, generation);
						cursor5.right = cursor4;
						cursor5.left = cursor3;
					}
					cursor = cursor2;
					cursor2.red = false;
					cursor.size = cursor4.size;
					cursor4.size = 1 + ((cursor4.left != null) ? cursor4.left.size : 0) + ((cursor4.right != null) ? cursor4.right.size : 0);
					cursor3.size = 1 + ((cursor3.left != null) ? cursor3.left.size : 0) + ((cursor3.right != null) ? cursor3.right.size : 0);
					cursor5.size = 1 + cursor4.size + cursor3.size;
				}
				else
				{
					Node.update(ref cursor4, num2 < 0, cursor3, maxsnapid, generation);
					Node.update(ref cursor2, num2 > 0, cursor4, maxsnapid, generation);
					cursor = cursor2;
					cursor2.red = false;
					cursor3.red = true;
					cursor.size = cursor4.size;
					cursor4.size -= node2.size + 1;
				}
			}
			else if (node2 != null && node2.red)
			{
				cursor3 = ((num2 > 0) ? cursor2.left : cursor2.right);
				Node.update(ref cursor4, num2 < 0, cursor3, maxsnapid, generation);
				Node.CopyNode(ref cursor2, maxsnapid, generation);
				if (num2 > 0)
				{
					cursor2.left = cursor4;
					cursor2.right = node2;
				}
				else
				{
					cursor2.right = cursor4;
					cursor2.left = node2;
				}
				cursor = cursor2;
				cursor.red = cursor4.red;
				cursor4.red = false;
				node2.red = false;
				cursor.size = cursor4.size;
				cursor4.size -= node2.size + 1;
			}
			else
			{
				if (cursor3 == null || !cursor3.red)
				{
					throw new InternalException("Case 1a can't happen here");
				}
				Node.CopyNode(ref cursor3, maxsnapid, generation);
				if (num2 > 0)
				{
					Node.update(ref cursor2, leftnode: true, cursor3.right, maxsnapid, generation);
					Node.update(ref cursor4, leftnode: false, cursor3.left, maxsnapid, generation);
					cursor3.left = cursor4;
					cursor3.right = cursor2;
				}
				else
				{
					Node.update(ref cursor2, leftnode: false, cursor3.left, maxsnapid, generation);
					Node.update(ref cursor4, leftnode: true, cursor3.right, maxsnapid, generation);
					cursor3.right = cursor4;
					cursor3.left = cursor2;
				}
				cursor = cursor3;
				cursor.red = cursor4.red;
				cursor4.red = false;
				cursor.size = cursor4.size;
				cursor4.size = 1 + ((cursor4.left != null) ? cursor4.left.size : 0) + ((cursor4.right != null) ? cursor4.right.size : 0);
				cursor2.size = 1 + ((cursor2.left != null) ? cursor2.left.size : 0) + ((cursor2.right != null) ? cursor2.right.size : 0);
			}
			if (level == 0)
			{
				root = cursor;
			}
			else
			{
				Node child2 = cursor;
				cursor = path[--level];
				path[level] = null;
				Node.update(ref cursor, dirs[level] > 0, child2, maxsnapid, generation);
				cursor.size--;
			}
		}
		while (level > 0)
		{
			Node node4 = cursor;
			cursor = path[--level];
			path[level] = null;
			if (node4 != ((dirs[level] > 0) ? cursor.left : cursor.right))
			{
				Node.update(ref cursor, dirs[level] > 0, node4, maxsnapid, generation);
			}
			cursor.size--;
		}
		root = cursor;
		return true;
	}

	[Tested]
	[ComVisible(true)]
	public void Clear()
	{
		if (!isValid)
		{
			throw new ViewDisposedException("Snapshot has been disposed");
		}
		updatecheck();
		if (size != 0)
		{
			int count = size;
			clear();
			if ((ActiveEvents & EventTypeEnum.Cleared) != 0)
			{
				raiseCollectionCleared(full: true, count);
			}
			if ((ActiveEvents & EventTypeEnum.Changed) != 0)
			{
				raiseCollectionChanged();
			}
		}
	}

	private void clear()
	{
		size = 0;
		root = null;
		blackdepth = 0;
	}

	[Tested]
	[ComVisible(true)]
	public void RemoveAll<U>(IEnumerable<U> items) where U : T
	{
		if (!isValid)
		{
			throw new ViewDisposedException("Snapshot has been disposed");
		}
		updatecheck();
		bool flag = (ActiveEvents & (EventTypeEnum.Changed | EventTypeEnum.Removed)) != 0;
		RaiseForRemoveAllHandler raiseForRemoveAllHandler = (flag ? new RaiseForRemoveAllHandler(this) : null);
		foreach (U item2 in items)
		{
			T val = (T)(object)item2;
			if (root != null)
			{
				T item = val;
				if (removeIterative(ref item, all: false, out var _) && flag)
				{
					raiseForRemoveAllHandler.Remove(item);
				}
				continue;
			}
			break;
		}
		if (flag)
		{
			raiseForRemoveAllHandler.Raise();
		}
	}

	[Tested]
	[ComVisible(true)]
	public void RetainAll<U>(IEnumerable<U> items) where U : T
	{
		if (!isValid)
		{
			throw new ViewDisposedException("Snapshot has been disposed");
		}
		updatecheck();
		TreeSet<T> treeSet = (TreeSet<T>)MemberwiseClone();
		T j = default(T);
		treeSet.clear();
		foreach (U item2 in items)
		{
			T item = (T)(object)item2;
			if (ContainsCount(item) > treeSet.ContainsCount(item))
			{
				treeSet.add(item, ref j);
			}
		}
		if (size == treeSet.size)
		{
			return;
		}
		CircularQueue<KeyValuePair<T, int>> circularQueue = null;
		if ((ActiveEvents & EventTypeEnum.Removed) != 0)
		{
			circularQueue = new CircularQueue<KeyValuePair<T, int>>();
			IEnumerator<KeyValuePair<T, int>> enumerator2 = ItemMultiplicities().GetEnumerator();
			foreach (KeyValuePair<T, int> item3 in treeSet.ItemMultiplicities())
			{
				while (enumerator2.MoveNext() && comparer.Compare(enumerator2.Current.Key, item3.Key) != 0)
				{
					circularQueue.Enqueue(enumerator2.Current);
				}
			}
			while (enumerator2.MoveNext())
			{
				circularQueue.Enqueue(enumerator2.Current);
			}
		}
		root = treeSet.root;
		size = treeSet.size;
		blackdepth = treeSet.blackdepth;
		if (circularQueue != null)
		{
			foreach (KeyValuePair<T, int> item4 in circularQueue)
			{
				raiseItemsRemoved(item4.Key, item4.Value);
			}
		}
		if ((ActiveEvents & EventTypeEnum.Changed) != 0)
		{
			raiseCollectionChanged();
		}
	}

	[Tested]
	[ComVisible(true)]
	public bool ContainsAll<U>(IEnumerable<U> items) where U : T
	{
		if (!isValid)
		{
			throw new ViewDisposedException("Snapshot has been disposed");
		}
		foreach (U item2 in items)
		{
			T item = (T)(object)item2;
			if (!Contains(item))
			{
				return false;
			}
		}
		return true;
	}

	[Tested]
	[ComVisible(true)]
	public IIndexedSorted<T> FindAll(Fun<T, bool> filter)
	{
		if (!isValid)
		{
			throw new ViewDisposedException("Snapshot has been disposed");
		}
		TreeSet<T> treeSet = new TreeSet<T>(comparer);
		IEnumerator<T> enumerator = GetEnumerator();
		Node rest = null;
		Node node = null;
		int num = 0;
		while (enumerator.MoveNext())
		{
			T current = enumerator.Current;
			if (filter(current))
			{
				if (rest == null)
				{
					rest = (node = new Node());
				}
				else
				{
					node.right = new Node();
					node = node.right;
				}
				node.item = current;
				num++;
			}
		}
		if (num == 0)
		{
			return treeSet;
		}
		int num2 = 0;
		int num3 = num;
		int num4 = 1;
		while (num4 <= num3)
		{
			num3 -= num4;
			num4 <<= 1;
			num2++;
		}
		treeSet.root = maketreer(ref rest, num2, num4, num3);
		treeSet.blackdepth = num2;
		treeSet.size = num;
		return treeSet;
	}

	[Tested]
	[ComVisible(true)]
	public IIndexedSorted<V> Map<V>(Fun<T, V> mapper, IComparer<V> c)
	{
		if (!isValid)
		{
			throw new ViewDisposedException("Snapshot has been disposed");
		}
		TreeSet<V> treeSet = new TreeSet<V>(c);
		if (size == 0)
		{
			return treeSet;
		}
		IEnumerator<T> enumerator = GetEnumerator();
		TreeSet<V>.Node rest = null;
		TreeSet<V>.Node node = null;
		V x = default(V);
		int num = 0;
		while (enumerator.MoveNext())
		{
			T current = enumerator.Current;
			V val = mapper(current);
			if (rest == null)
			{
				rest = (node = new TreeSet<V>.Node());
				num++;
			}
			else
			{
				int num2 = c.Compare(x, val);
				if (num2 >= 0)
				{
					throw new ArgumentException("mapper not monotonic");
				}
				node.right = new TreeSet<V>.Node();
				node = node.right;
				num++;
			}
			x = (node.item = val);
		}
		int num3 = 0;
		int num4 = num;
		int num5 = 1;
		while (num5 <= num4)
		{
			num4 -= num5;
			num5 <<= 1;
			num3++;
		}
		treeSet.root = TreeSet<V>.maketreer(ref rest, num3, num5, num4);
		treeSet.blackdepth = num3;
		treeSet.size = size;
		return treeSet;
	}

	[Tested]
	[ComVisible(true)]
	public int ContainsCount(T item)
	{
		if (!isValid)
		{
			throw new ViewDisposedException("Snapshot has been disposed");
		}
		if (!Contains(item))
		{
			return 0;
		}
		return 1;
	}

	[ComVisible(true)]
	public virtual ICollectionValue<T> UniqueItems()
	{
		if (!isValid)
		{
			throw new ViewDisposedException("Snapshot has been disposed");
		}
		return this;
	}

	[ComVisible(true)]
	public virtual ICollectionValue<KeyValuePair<T, int>> ItemMultiplicities()
	{
		if (!isValid)
		{
			throw new ViewDisposedException("Snapshot has been disposed");
		}
		return new MultiplicityOne<T>(this);
	}

	[Tested]
	[ComVisible(true)]
	public void RemoveAllCopies(T item)
	{
		Remove(item);
	}

	private Node findNode(int i)
	{
		if (isSnapShot)
		{
			throw new NotSupportedException("Indexing not supported for snapshots");
		}
		Node node = root;
		if (i >= 0 && i < size)
		{
			while (true)
			{
				int num = ((node.left != null) ? node.left.size : 0);
				if (i > num)
				{
					i -= num + 1;
					node = node.right;
					continue;
				}
				if (i == num)
				{
					break;
				}
				node = node.left;
			}
			return node;
		}
		throw new IndexOutOfRangeException();
	}

	[Tested]
	[ComVisible(true)]
	public int IndexOf(T item)
	{
		if (!isValid)
		{
			throw new ViewDisposedException("Snapshot has been disposed");
		}
		int upper;
		return indexOf(item, out upper);
	}

	private int indexOf(T item, out int upper)
	{
		if (isSnapShot)
		{
			throw new NotSupportedException("Indexing not supported for snapshots");
		}
		int num = 0;
		Node node = root;
		while (node != null)
		{
			int num2 = comparer.Compare(item, node.item);
			if (num2 < 0)
			{
				node = node.left;
				continue;
			}
			int num3 = ((node.left != null) ? node.left.size : 0);
			if (num2 == 0)
			{
				return upper = num + num3;
			}
			num = num + 1 + num3;
			node = node.right;
		}
		upper = ~num;
		return ~num;
	}

	[Tested]
	[ComVisible(true)]
	public int LastIndexOf(T item)
	{
		if (!isValid)
		{
			throw new ViewDisposedException("Snapshot has been disposed");
		}
		return IndexOf(item);
	}

	[Tested]
	[ComVisible(true)]
	public T RemoveAt(int i)
	{
		if (!isValid)
		{
			throw new ViewDisposedException("Snapshot has been disposed");
		}
		updatecheck();
		T val = removeAt(i);
		if (ActiveEvents != 0)
		{
			raiseForRemove(val);
		}
		return val;
	}

	private T removeAt(int i)
	{
		if (!isValid)
		{
			throw new ViewDisposedException("Snapshot has been disposed");
		}
		updatecheck();
		if (i < 0 || i >= size)
		{
			throw new IndexOutOfRangeException("Index out of range for sequenced collectionvalue");
		}
		while (dirs.Length < 2 * blackdepth)
		{
			dirs = new int[2 * dirs.Length];
			path = new Node[2 * dirs.Length];
		}
		int num = 0;
		Node node = root;
		while (true)
		{
			int num2 = ((node.left != null) ? node.left.size : 0);
			if (i > num2)
			{
				i -= num2 + 1;
				dirs[num] = -1;
				path[num++] = node;
				node = node.right;
				continue;
			}
			if (i == num2)
			{
				break;
			}
			dirs[num] = 1;
			path[num++] = node;
			node = node.left;
		}
		T item = node.item;
		removeIterativePhase2(node, num);
		return item;
	}

	[Tested]
	[ComVisible(true)]
	public void RemoveInterval(int start, int count)
	{
		if (!isValid)
		{
			throw new ViewDisposedException("Snapshot has been disposed");
		}
		if (start < 0 || count < 0 || start + count > size)
		{
			throw new ArgumentOutOfRangeException();
		}
		updatecheck();
		if (count != 0)
		{
			for (int i = 0; i < count; i++)
			{
				removeAt(start);
			}
			if ((ActiveEvents & EventTypeEnum.Cleared) != 0)
			{
				raiseCollectionCleared(full: false, count);
			}
			if ((ActiveEvents & EventTypeEnum.Changed) != 0)
			{
				raiseCollectionChanged();
			}
		}
	}

	[Tested]
	[ComVisible(true)]
	public override IDirectedCollectionValue<T> Backwards()
	{
		return RangeAll().Backwards();
	}

	[Tested]
	IDirectedEnumerable<T> IDirectedEnumerable<T>.Backwards()
	{
		return Backwards();
	}

	[Tested]
	[ComVisible(true)]
	public T FindMin()
	{
		if (!isValid)
		{
			throw new ViewDisposedException("Snapshot has been disposed");
		}
		if (size == 0)
		{
			throw new NoSuchItemException();
		}
		Node node = root;
		for (Node node2 = left(node); node2 != null; node2 = left(node))
		{
			node = node2;
		}
		return node.item;
	}

	[Tested]
	[ComVisible(true)]
	public T DeleteMin()
	{
		if (!isValid)
		{
			throw new ViewDisposedException("Snapshot has been disposed");
		}
		updatecheck();
		if (size == 0)
		{
			throw new NoSuchItemException();
		}
		stackcheck();
		T val = deleteMin();
		if (ActiveEvents != 0)
		{
			raiseItemsRemoved(val, 1);
			raiseCollectionChanged();
		}
		return val;
	}

	private T deleteMin()
	{
		int num = 0;
		Node node = root;
		while (node.left != null)
		{
			dirs[num] = 1;
			path[num++] = node;
			node = node.left;
		}
		T item = node.item;
		removeIterativePhase2(node, num);
		return item;
	}

	[Tested]
	[ComVisible(true)]
	public T FindMax()
	{
		if (!isValid)
		{
			throw new ViewDisposedException("Snapshot has been disposed");
		}
		if (size == 0)
		{
			throw new NoSuchItemException();
		}
		Node node = root;
		for (Node node2 = right(node); node2 != null; node2 = right(node))
		{
			node = node2;
		}
		return node.item;
	}

	[Tested]
	[ComVisible(true)]
	public T DeleteMax()
	{
		if (!isValid)
		{
			throw new ViewDisposedException("Snapshot has been disposed");
		}
		updatecheck();
		if (size == 0)
		{
			throw new NoSuchItemException();
		}
		stackcheck();
		T val = deleteMax();
		if (ActiveEvents != 0)
		{
			raiseItemsRemoved(val, 1);
			raiseCollectionChanged();
		}
		return val;
	}

	private T deleteMax()
	{
		int num = 0;
		Node node = root;
		while (node.right != null)
		{
			dirs[num] = -1;
			path[num++] = node;
			node = node.right;
		}
		T item = node.item;
		removeIterativePhase2(node, num);
		return item;
	}

	[ComVisible(true)]
	public bool TryPredecessor(T item, out T res)
	{
		if (!isValid)
		{
			throw new ViewDisposedException("Snapshot has been disposed");
		}
		Node node = root;
		Node node2 = null;
		while (node != null)
		{
			int num = comparer.Compare(node.item, item);
			if (num < 0)
			{
				node2 = node;
				node = right(node);
			}
			else if (num == 0)
			{
				for (node = left(node); node != null; node = right(node))
				{
					node2 = node;
				}
			}
			else
			{
				node = left(node);
			}
		}
		if (node2 == null)
		{
			res = default(T);
			return false;
		}
		res = node2.item;
		return true;
	}

	[ComVisible(true)]
	public bool TrySuccessor(T item, out T res)
	{
		if (!isValid)
		{
			throw new ViewDisposedException("Snapshot has been disposed");
		}
		Node node = root;
		Node node2 = null;
		while (node != null)
		{
			int num = comparer.Compare(node.item, item);
			if (num > 0)
			{
				node2 = node;
				node = left(node);
			}
			else if (num == 0)
			{
				for (node = right(node); node != null; node = left(node))
				{
					node2 = node;
				}
			}
			else
			{
				node = right(node);
			}
		}
		if (node2 == null)
		{
			res = default(T);
			return false;
		}
		res = node2.item;
		return true;
	}

	[ComVisible(true)]
	public bool TryWeakPredecessor(T item, out T res)
	{
		if (!isValid)
		{
			throw new ViewDisposedException("Snapshot has been disposed");
		}
		Node node = root;
		Node node2 = null;
		while (node != null)
		{
			int num = comparer.Compare(node.item, item);
			if (num < 0)
			{
				node2 = node;
				node = right(node);
				continue;
			}
			if (num == 0)
			{
				res = node.item;
				return true;
			}
			node = left(node);
		}
		if (node2 == null)
		{
			res = default(T);
			return false;
		}
		res = node2.item;
		return true;
	}

	[ComVisible(true)]
	public bool TryWeakSuccessor(T item, out T res)
	{
		if (!isValid)
		{
			throw new ViewDisposedException("Snapshot has been disposed");
		}
		Node node = root;
		Node node2 = null;
		while (node != null)
		{
			int num = comparer.Compare(node.item, item);
			if (num == 0)
			{
				res = node.item;
				return true;
			}
			if (num > 0)
			{
				node2 = node;
				node = left(node);
			}
			else
			{
				node = right(node);
			}
		}
		if (node2 == null)
		{
			res = default(T);
			return false;
		}
		res = node2.item;
		return true;
	}

	[Tested]
	[ComVisible(true)]
	public T Predecessor(T item)
	{
		if (TryPredecessor(item, out var res))
		{
			return res;
		}
		throw new NoSuchItemException();
	}

	[Tested]
	[ComVisible(true)]
	public T WeakPredecessor(T item)
	{
		if (TryWeakPredecessor(item, out var res))
		{
			return res;
		}
		throw new NoSuchItemException();
	}

	[Tested]
	[ComVisible(true)]
	public T Successor(T item)
	{
		if (TrySuccessor(item, out var res))
		{
			return res;
		}
		throw new NoSuchItemException();
	}

	[Tested]
	[ComVisible(true)]
	public T WeakSuccessor(T item)
	{
		if (TryWeakSuccessor(item, out var res))
		{
			return res;
		}
		throw new NoSuchItemException();
	}

	[Tested]
	[ComVisible(true)]
	public IDirectedCollectionValue<T> RangeFrom(T bot)
	{
		if (!isValid)
		{
			throw new ViewDisposedException("Snapshot has been disposed");
		}
		return new Range(this, haslowend: true, bot, hashighend: false, default(T), EnumerationDirection.Forwards);
	}

	[Tested]
	[ComVisible(true)]
	public IDirectedCollectionValue<T> RangeFromTo(T bot, T top)
	{
		if (!isValid)
		{
			throw new ViewDisposedException("Snapshot has been disposed");
		}
		return new Range(this, haslowend: true, bot, hashighend: true, top, EnumerationDirection.Forwards);
	}

	[Tested]
	[ComVisible(true)]
	public IDirectedCollectionValue<T> RangeTo(T top)
	{
		if (!isValid)
		{
			throw new ViewDisposedException("Snapshot has been disposed");
		}
		return new Range(this, haslowend: false, default(T), hashighend: true, top, EnumerationDirection.Forwards);
	}

	[Tested]
	[ComVisible(true)]
	public IDirectedCollectionValue<T> RangeAll()
	{
		if (!isValid)
		{
			throw new ViewDisposedException("Snapshot has been disposed");
		}
		return new Range(this, haslowend: false, default(T), hashighend: false, default(T), EnumerationDirection.Forwards);
	}

	[Tested]
	IDirectedEnumerable<T> ISorted<T>.RangeFrom(T bot)
	{
		return RangeFrom(bot);
	}

	[Tested]
	IDirectedEnumerable<T> ISorted<T>.RangeFromTo(T bot, T top)
	{
		return RangeFromTo(bot, top);
	}

	[Tested]
	IDirectedEnumerable<T> ISorted<T>.RangeTo(T top)
	{
		return RangeTo(top);
	}

	private int countTo(T item, bool strict)
	{
		if (isSnapShot)
		{
			throw new NotSupportedException("Indexing not supported for snapshots");
		}
		int num = 0;
		int num2 = 0;
		Node node = root;
		while (node != null)
		{
			num2 = comparer.Compare(item, node.item);
			if (num2 < 0)
			{
				node = node.left;
				continue;
			}
			int num3 = ((node.left != null) ? node.left.size : 0);
			if (num2 == 0)
			{
				if (!strict)
				{
					return num + num3 + 1;
				}
				return num + num3;
			}
			num = num + 1 + num3;
			node = node.right;
		}
		return num;
	}

	[Tested]
	[ComVisible(true)]
	public bool Cut(IComparable<T> c, out T low, out bool lowIsValid, out T high, out bool highIsValid)
	{
		if (!isValid)
		{
			throw new ViewDisposedException("Snapshot has been disposed");
		}
		Node node = root;
		Node node2 = null;
		Node node3 = null;
		bool result = false;
		while (node != null)
		{
			int num = c.CompareTo(node.item);
			if (num > 0)
			{
				node2 = node;
				node = right(node);
				continue;
			}
			if (num < 0)
			{
				node3 = node;
				node = left(node);
				continue;
			}
			result = true;
			Node node4 = left(node);
			while (node4 != null && c.CompareTo(node4.item) == 0)
			{
				node4 = left(node4);
			}
			if (node4 != null)
			{
				node2 = node4;
				node4 = right(node4);
				while (node4 != null)
				{
					if (c.CompareTo(node4.item) > 0)
					{
						node2 = node4;
						node4 = right(node4);
					}
					else
					{
						node4 = left(node4);
					}
				}
			}
			node4 = right(node);
			while (node4 != null && c.CompareTo(node4.item) == 0)
			{
				node4 = right(node4);
			}
			if (node4 == null)
			{
				break;
			}
			node3 = node4;
			node4 = left(node4);
			while (node4 != null)
			{
				if (c.CompareTo(node4.item) < 0)
				{
					node3 = node4;
					node4 = left(node4);
				}
				else
				{
					node4 = right(node4);
				}
			}
			break;
		}
		if (highIsValid = node3 != null)
		{
			high = node3.item;
		}
		else
		{
			high = default(T);
		}
		if (lowIsValid = node2 != null)
		{
			low = node2.item;
		}
		else
		{
			low = default(T);
		}
		return result;
	}

	[Tested]
	[ComVisible(true)]
	public int CountFrom(T bot)
	{
		if (!isValid)
		{
			throw new ViewDisposedException("Snapshot has been disposed");
		}
		return size - countTo(bot, strict: true);
	}

	[Tested]
	[ComVisible(true)]
	public int CountFromTo(T bot, T top)
	{
		if (!isValid)
		{
			throw new ViewDisposedException("Snapshot has been disposed");
		}
		if (comparer.Compare(bot, top) >= 0)
		{
			return 0;
		}
		return countTo(top, strict: true) - countTo(bot, strict: true);
	}

	[Tested]
	[ComVisible(true)]
	public int CountTo(T top)
	{
		if (!isValid)
		{
			throw new ViewDisposedException("Snapshot has been disposed");
		}
		return countTo(top, strict: true);
	}

	[Tested]
	[ComVisible(true)]
	public void RemoveRangeFrom(T low)
	{
		if (!isValid)
		{
			throw new ViewDisposedException("Snapshot has been disposed");
		}
		updatecheck();
		int num = CountFrom(low);
		if (num != 0)
		{
			stackcheck();
			CircularQueue<T> circularQueue = (((ActiveEvents & EventTypeEnum.Removed) != 0) ? new CircularQueue<T>() : null);
			for (int i = 0; i < num; i++)
			{
				T item = deleteMax();
				circularQueue?.Enqueue(item);
			}
			if (circularQueue != null)
			{
				raiseForRemoveAll(circularQueue);
			}
			else if ((ActiveEvents & EventTypeEnum.Changed) != 0)
			{
				raiseCollectionChanged();
			}
		}
	}

	[Tested]
	[ComVisible(true)]
	public void RemoveRangeFromTo(T low, T hi)
	{
		if (!isValid)
		{
			throw new ViewDisposedException("Snapshot has been disposed");
		}
		updatecheck();
		int num = CountFromTo(low, hi);
		if (num != 0)
		{
			CircularQueue<T> circularQueue = (((ActiveEvents & EventTypeEnum.Removed) != 0) ? new CircularQueue<T>() : null);
			for (int i = 0; i < num; i++)
			{
				T item = Predecessor(hi);
				removeIterative(ref item, all: false, out var _);
				circularQueue?.Enqueue(item);
			}
			if (circularQueue != null)
			{
				raiseForRemoveAll(circularQueue);
			}
			else if ((ActiveEvents & EventTypeEnum.Changed) != 0)
			{
				raiseCollectionChanged();
			}
		}
	}

	[Tested]
	[ComVisible(true)]
	public void RemoveRangeTo(T hi)
	{
		if (!isValid)
		{
			throw new ViewDisposedException("Snapshot has been disposed");
		}
		updatecheck();
		int num = CountTo(hi);
		if (num != 0)
		{
			stackcheck();
			CircularQueue<T> circularQueue = (((ActiveEvents & EventTypeEnum.Removed) != 0) ? new CircularQueue<T>() : null);
			for (int i = 0; i < num; i++)
			{
				T item = deleteMin();
				circularQueue?.Enqueue(item);
			}
			if (circularQueue != null)
			{
				raiseForRemoveAll(circularQueue);
			}
			else if ((ActiveEvents & EventTypeEnum.Changed) != 0)
			{
				raiseCollectionChanged();
			}
		}
	}

	private int findLastLiveSnapShot()
	{
		if (snapList == null)
		{
			return -1;
		}
		SnapRef prev = snapList.Prev;
		object obj = null;
		while (prev != null && (obj = prev.Tree.Target) == null)
		{
			prev = prev.Prev;
		}
		if (prev == null)
		{
			snapList = null;
			return -1;
		}
		if (snapList.Prev != prev)
		{
			snapList.Prev = prev;
			prev.Next = snapList;
		}
		return ((TreeSet<T>)obj).generation;
	}

	[Tested]
	[ComVisible(true)]
	public void Dispose()
	{
		if (!isValid)
		{
			return;
		}
		if (isSnapShot)
		{
			snapList.Dispose();
			snapDispose();
			return;
		}
		if (snapList != null)
		{
			for (SnapRef prev = snapList.Prev; prev != null; prev = prev.Prev)
			{
				if (prev.Tree.Target is TreeSet<T> treeSet)
				{
					treeSet.snapDispose();
				}
			}
		}
		snapList = null;
		Clear();
	}

	private void snapDispose()
	{
		root = null;
		dirs = null;
		path = null;
		comparer = null;
		isValid = false;
		snapList = null;
	}

	[Tested]
	[ComVisible(true)]
	public ISorted<T> Snapshot()
	{
		if (isSnapShot)
		{
			throw new InvalidOperationException("Cannot snapshot a snapshot");
		}
		TreeSet<T> treeSet = (TreeSet<T>)MemberwiseClone();
		SnapRef snapRef = new SnapRef(treeSet);
		treeSet.isReadOnlyBase = true;
		treeSet.isSnapShot = true;
		treeSet.snapList = snapRef;
		findLastLiveSnapShot();
		if (snapList == null)
		{
			snapList = new SnapRef(this);
		}
		SnapRef snapRef2 = (snapRef.Prev = snapList.Prev);
		if (snapRef2 != null)
		{
			snapRef2.Next = snapRef;
		}
		snapRef.Next = snapList;
		snapList.Prev = snapRef;
		generation++;
		return treeSet;
	}

	private void minidump(Node n, string space)
	{
		if (n != null)
		{
			minidump(n.right, space + "  ");
			Console.WriteLine(string.Format("{0} {4} (size={1}, items={8}, h={2}, gen={3}, id={6}){7}", space + n.item, n.size, 0, n.generation, n.red ? "RED" : "BLACK", 0, 0, (n.lastgeneration == -1) ? "" : string.Format(" [extra: lg={0}, c={1}, i={2}]", n.lastgeneration, n.leftnode ? "L" : "R", (n.oldref == null) ? "()" : string.Concat(n.oldref.item)), 1));
			minidump(n.left, space + "  ");
		}
	}

	[Tested(via = "Sawtooth")]
	[ComVisible(true)]
	public void dump()
	{
		dump("");
	}

	[Tested(via = "Sawtooth")]
	[ComVisible(true)]
	public void dump(string msg)
	{
		Console.WriteLine($">>>>>>>>>>>>>>>>>>> dump {msg} (count={size}, blackdepth={blackdepth}, depth={0}, gen={generation})");
		minidump(root, "");
		check("", Console.Out);
		Console.WriteLine("<<<<<<<<<<<<<<<<<<<");
	}

	private void dump(string msg, string err)
	{
		Console.WriteLine($">>>>>>>>>>>>>>>>>>> dump {msg} (count={size}, blackdepth={blackdepth}, depth={0}, gen={generation})");
		minidump(root, "");
		Console.Write(err);
		Console.WriteLine("<<<<<<<<<<<<<<<<<<<");
	}

	private bool massert(bool b, Node n, string m, TextWriter o)
	{
		if (!b)
		{
			o.WriteLine("*** Node (item={0}, id={1}): {2}", n.item, 0, m);
		}
		return b;
	}

	private bool rbminicheck(Node n, bool redp, TextWriter o, out T min, out T max, out int blackheight)
	{
		bool flag = true;
		flag = massert(!n.red || !redp, n, "RED parent of RED node", o) && flag;
		flag = massert(n.left == null || n.right != null || n.left.red, n, "Left child black, but right child empty", o) && flag;
		flag = massert(n.right == null || n.left != null || n.right.red, n, "Right child black, but left child empty", o) && flag;
		bool b = n.size == ((n.left != null) ? n.left.size : 0) + ((n.right != null) ? n.right.size : 0) + 1;
		flag = massert(b, n, "Bad size", o) && flag;
		min = (max = n.item);
		int blackheight2 = 0;
		int blackheight3 = 0;
		T min2;
		if (n.left != null)
		{
			flag = rbminicheck(n.left, n.red, o, out min, out min2, out blackheight2) && flag;
			flag = massert(comparer.Compare(n.item, min2) > 0, n, "Value not > all left children", o) && flag;
		}
		if (n.right != null)
		{
			flag = rbminicheck(n.right, n.red, o, out min2, out max, out blackheight3) && flag;
			flag = massert(comparer.Compare(n.item, min2) < 0, n, "Value not < all right children", o) && flag;
		}
		flag = massert(blackheight3 == blackheight2, n, "Different blackheights of children", o) && flag;
		blackheight = (n.red ? blackheight3 : (blackheight3 + 1));
		return flag;
	}

	private bool rbminisnapcheck(Node n, TextWriter o, out int size, out T min, out T max)
	{
		bool flag = true;
		min = (max = n.item);
		int num = 0;
		int num2 = 0;
		Node node = ((n.lastgeneration >= generation && n.leftnode) ? n.oldref : n.left);
		T min2;
		if (node != null)
		{
			flag = rbminisnapcheck(node, o, out num, out min, out min2) && flag;
			flag = massert(comparer.Compare(n.item, min2) > 0, n, "Value not > all left children", o) && flag;
		}
		node = ((n.lastgeneration >= generation && !n.leftnode) ? n.oldref : n.right);
		if (node != null)
		{
			flag = rbminisnapcheck(node, o, out num2, out min2, out max) && flag;
			flag = massert(comparer.Compare(n.item, min2) < 0, n, "Value not < all right children", o) && flag;
		}
		size = 1 + num + num2;
		return flag;
	}

	[Tested(via = "Sawtooth")]
	[ComVisible(true)]
	public bool Check(string name)
	{
		StringBuilder stringBuilder = new StringBuilder();
		TextWriter o = new StringWriter(stringBuilder);
		if (!check(name, o))
		{
			return true;
		}
		dump(name, stringBuilder.ToString());
		return false;
	}

	[Tested]
	[ComVisible(true)]
	public bool Check()
	{
		if (!isValid)
		{
			return true;
		}
		return Check("-");
	}

	private bool check(string msg, TextWriter o)
	{
		if (root != null)
		{
			T min;
			T max;
			if (isSnapShot)
			{
				bool flag = rbminisnapcheck(root, o, out var num, out min, out max);
				flag = massert(size == num, root, "bad snapshot size", o) && flag;
				return !flag;
			}
			bool flag2 = rbminicheck(root, redp: false, o, out min, out max, out var blackheight);
			flag2 = massert(blackheight == blackdepth, root, "bad blackh/d", o) && flag2;
			flag2 = massert(!root.red, root, "root is red", o) && flag2;
			flag2 = massert(root.size == size, root, "count!=root.size", o) && flag2;
			return !flag2;
		}
		return false;
	}

	[ComVisible(true)]
	public virtual object Clone()
	{
		TreeSet<T> treeSet = new TreeSet<T>(comparer, EqualityComparer);
		treeSet.AddSorted(this);
		return treeSet;
	}
}
