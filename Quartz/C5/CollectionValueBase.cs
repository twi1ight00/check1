using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace C5;

[Serializable]
internal abstract class CollectionValueBase<T> : EnumerableBase<T>, ICollectionValue<T>, IEnumerable<T>, IEnumerable, IShowable, IFormattable
{
	protected class RaiseForRemoveAllHandler
	{
		private CollectionValueBase<T> collection;

		private CircularQueue<T> wasRemoved;

		private bool wasChanged;

		private bool mustFireRemoved;

		[ComVisible(true)]
		public readonly bool MustFire;

		[ComVisible(true)]
		public RaiseForRemoveAllHandler(CollectionValueBase<T> collection)
		{
			this.collection = collection;
			mustFireRemoved = (collection.ActiveEvents & EventTypeEnum.Removed) != 0;
			MustFire = (collection.ActiveEvents & (EventTypeEnum.Changed | EventTypeEnum.Removed)) != 0;
		}

		[ComVisible(true)]
		public void Remove(T item)
		{
			if (mustFireRemoved)
			{
				if (wasRemoved == null)
				{
					wasRemoved = new CircularQueue<T>();
				}
				wasRemoved.Enqueue(item);
			}
			if (!wasChanged)
			{
				wasChanged = true;
			}
		}

		[ComVisible(true)]
		public void Raise()
		{
			if (wasRemoved != null)
			{
				foreach (T item in wasRemoved)
				{
					collection.raiseItemsRemoved(item, 1);
				}
			}
			if (wasChanged)
			{
				collection.raiseCollectionChanged();
			}
		}
	}

	private EventBlock<T> eventBlock;

	[ComVisible(true)]
	public virtual EventTypeEnum ListenableEvents
	{
		[ComVisible(true)]
		get
		{
			return EventTypeEnum.None;
		}
	}

	[ComVisible(true)]
	public virtual EventTypeEnum ActiveEvents
	{
		[ComVisible(true)]
		get
		{
			if (eventBlock != null)
			{
				return eventBlock.events;
			}
			return EventTypeEnum.None;
		}
	}

	[ComVisible(true)]
	public abstract bool IsEmpty
	{
		[ComVisible(true)]
		get;
	}

	[ComVisible(true)]
	public abstract int Count
	{
		[ComVisible(true)]
		get;
	}

	[ComVisible(true)]
	public abstract Speed CountSpeed
	{
		[ComVisible(true)]
		get;
	}

	[ComVisible(true)]
	public virtual event CollectionChangedHandler<T> CollectionChanged
	{
		[ComVisible(true)]
		add
		{
			checkWillListen(EventTypeEnum.Changed);
			(eventBlock ?? (eventBlock = new EventBlock<T>())).CollectionChanged += value;
		}
		[ComVisible(true)]
		remove
		{
			checkWillListen(EventTypeEnum.Changed);
			if (eventBlock != null)
			{
				eventBlock.CollectionChanged -= value;
				if (eventBlock.events == EventTypeEnum.None)
				{
					eventBlock = null;
				}
			}
		}
	}

	[ComVisible(true)]
	public virtual event CollectionClearedHandler<T> CollectionCleared
	{
		[ComVisible(true)]
		add
		{
			checkWillListen(EventTypeEnum.Cleared);
			(eventBlock ?? (eventBlock = new EventBlock<T>())).CollectionCleared += value;
		}
		[ComVisible(true)]
		remove
		{
			checkWillListen(EventTypeEnum.Cleared);
			if (eventBlock != null)
			{
				eventBlock.CollectionCleared -= value;
				if (eventBlock.events == EventTypeEnum.None)
				{
					eventBlock = null;
				}
			}
		}
	}

	[ComVisible(true)]
	public virtual event ItemsAddedHandler<T> ItemsAdded
	{
		[ComVisible(true)]
		add
		{
			checkWillListen(EventTypeEnum.Added);
			(eventBlock ?? (eventBlock = new EventBlock<T>())).ItemsAdded += value;
		}
		[ComVisible(true)]
		remove
		{
			checkWillListen(EventTypeEnum.Added);
			if (eventBlock != null)
			{
				eventBlock.ItemsAdded -= value;
				if (eventBlock.events == EventTypeEnum.None)
				{
					eventBlock = null;
				}
			}
		}
	}

	[ComVisible(true)]
	public virtual event ItemsRemovedHandler<T> ItemsRemoved
	{
		[ComVisible(true)]
		add
		{
			checkWillListen(EventTypeEnum.Removed);
			(eventBlock ?? (eventBlock = new EventBlock<T>())).ItemsRemoved += value;
		}
		[ComVisible(true)]
		remove
		{
			checkWillListen(EventTypeEnum.Removed);
			if (eventBlock != null)
			{
				eventBlock.ItemsRemoved -= value;
				if (eventBlock.events == EventTypeEnum.None)
				{
					eventBlock = null;
				}
			}
		}
	}

	[ComVisible(true)]
	public virtual event ItemInsertedHandler<T> ItemInserted
	{
		[ComVisible(true)]
		add
		{
			checkWillListen(EventTypeEnum.Inserted);
			(eventBlock ?? (eventBlock = new EventBlock<T>())).ItemInserted += value;
		}
		[ComVisible(true)]
		remove
		{
			checkWillListen(EventTypeEnum.Inserted);
			if (eventBlock != null)
			{
				eventBlock.ItemInserted -= value;
				if (eventBlock.events == EventTypeEnum.None)
				{
					eventBlock = null;
				}
			}
		}
	}

	[ComVisible(true)]
	public virtual event ItemRemovedAtHandler<T> ItemRemovedAt
	{
		[ComVisible(true)]
		add
		{
			checkWillListen(EventTypeEnum.RemovedAt);
			(eventBlock ?? (eventBlock = new EventBlock<T>())).ItemRemovedAt += value;
		}
		[ComVisible(true)]
		remove
		{
			checkWillListen(EventTypeEnum.RemovedAt);
			if (eventBlock != null)
			{
				eventBlock.ItemRemovedAt -= value;
				if (eventBlock.events == EventTypeEnum.None)
				{
					eventBlock = null;
				}
			}
		}
	}

	private void checkWillListen(EventTypeEnum eventType)
	{
		if ((ListenableEvents & eventType) == 0)
		{
			throw new UnlistenableEventException();
		}
	}

	protected virtual void raiseCollectionChanged()
	{
		if (eventBlock != null)
		{
			eventBlock.raiseCollectionChanged(this);
		}
	}

	protected virtual void raiseCollectionCleared(bool full, int count)
	{
		if (eventBlock != null)
		{
			eventBlock.raiseCollectionCleared(this, full, count);
		}
	}

	protected virtual void raiseCollectionCleared(bool full, int count, int? offset)
	{
		if (eventBlock != null)
		{
			eventBlock.raiseCollectionCleared(this, full, count, offset);
		}
	}

	protected virtual void raiseItemsAdded(T item, int count)
	{
		if (eventBlock != null)
		{
			eventBlock.raiseItemsAdded(this, item, count);
		}
	}

	protected virtual void raiseItemsRemoved(T item, int count)
	{
		if (eventBlock != null)
		{
			eventBlock.raiseItemsRemoved(this, item, count);
		}
	}

	protected virtual void raiseItemInserted(T item, int index)
	{
		if (eventBlock != null)
		{
			eventBlock.raiseItemInserted(this, item, index);
		}
	}

	protected virtual void raiseItemRemovedAt(T item, int index)
	{
		if (eventBlock != null)
		{
			eventBlock.raiseItemRemovedAt(this, item, index);
		}
	}

	protected virtual void raiseForSetThis(int index, T value, T item)
	{
		if (ActiveEvents != 0)
		{
			raiseItemsRemoved(item, 1);
			raiseItemRemovedAt(item, index);
			raiseItemsAdded(value, 1);
			raiseItemInserted(value, index);
			raiseCollectionChanged();
		}
	}

	protected virtual void raiseForInsert(int i, T item)
	{
		if (ActiveEvents != 0)
		{
			raiseItemInserted(item, i);
			raiseItemsAdded(item, 1);
			raiseCollectionChanged();
		}
	}

	protected void raiseForRemove(T item)
	{
		if (ActiveEvents != 0)
		{
			raiseItemsRemoved(item, 1);
			raiseCollectionChanged();
		}
	}

	protected void raiseForRemove(T item, int count)
	{
		if (ActiveEvents != 0)
		{
			raiseItemsRemoved(item, count);
			raiseCollectionChanged();
		}
	}

	protected void raiseForRemoveAt(int index, T item)
	{
		if (ActiveEvents != 0)
		{
			raiseItemRemovedAt(item, index);
			raiseItemsRemoved(item, 1);
			raiseCollectionChanged();
		}
	}

	protected virtual void raiseForUpdate(T newitem, T olditem)
	{
		if (ActiveEvents != 0)
		{
			raiseItemsRemoved(olditem, 1);
			raiseItemsAdded(newitem, 1);
			raiseCollectionChanged();
		}
	}

	protected virtual void raiseForUpdate(T newitem, T olditem, int count)
	{
		if (ActiveEvents != 0)
		{
			raiseItemsRemoved(olditem, count);
			raiseItemsAdded(newitem, count);
			raiseCollectionChanged();
		}
	}

	protected virtual void raiseForAdd(T item)
	{
		if (ActiveEvents != 0)
		{
			raiseItemsAdded(item, 1);
			raiseCollectionChanged();
		}
	}

	protected virtual void raiseForRemoveAll(ICollectionValue<T> wasRemoved)
	{
		if ((ActiveEvents & EventTypeEnum.Removed) != 0)
		{
			foreach (T item in wasRemoved)
			{
				raiseItemsRemoved(item, 1);
			}
		}
		if (wasRemoved != null && wasRemoved.Count > 0)
		{
			raiseCollectionChanged();
		}
	}

	[Tested]
	[ComVisible(true)]
	public virtual void CopyTo(T[] array, int index)
	{
		if (index < 0 || index + Count > array.Length)
		{
			throw new ArgumentOutOfRangeException();
		}
		using IEnumerator<T> enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			T current = enumerator.Current;
			array[index++] = current;
		}
	}

	[ComVisible(true)]
	public virtual T[] ToArray()
	{
		T[] array = new T[Count];
		int num = 0;
		using IEnumerator<T> enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			T current = enumerator.Current;
			array[num++] = current;
		}
		return array;
	}

	[Tested]
	[ComVisible(true)]
	public virtual void Apply(Act<T> action)
	{
		using IEnumerator<T> enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			T current = enumerator.Current;
			action(current);
		}
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool Exists(Fun<T, bool> predicate)
	{
		using (IEnumerator<T> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				T current = enumerator.Current;
				if (predicate(current))
				{
					return true;
				}
			}
		}
		return false;
	}

	[ComVisible(true)]
	public virtual bool Find(Fun<T, bool> predicate, out T item)
	{
		using (IEnumerator<T> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				T current = enumerator.Current;
				if (predicate(current))
				{
					item = current;
					return true;
				}
			}
		}
		item = default(T);
		return false;
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool All(Fun<T, bool> predicate)
	{
		using (IEnumerator<T> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				T current = enumerator.Current;
				if (!predicate(current))
				{
					return false;
				}
			}
		}
		return true;
	}

	[ComVisible(true)]
	public virtual IEnumerable<T> Filter(Fun<T, bool> predicate)
	{
		using IEnumerator<T> enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			T item = enumerator.Current;
			if (predicate(item))
			{
				yield return item;
			}
		}
	}

	[ComVisible(true)]
	public abstract T Choose();

	[ComVisible(true)]
	public abstract override IEnumerator<T> GetEnumerator();

	[ComVisible(true)]
	public virtual bool Show(StringBuilder stringbuilder, ref int rest, IFormatProvider formatProvider)
	{
		return Showing.ShowCollectionValue(this, stringbuilder, ref rest, formatProvider);
	}

	[ComVisible(true)]
	public virtual string ToString(string format, IFormatProvider formatProvider)
	{
		return Showing.ShowString(this, format, formatProvider);
	}

	[ComVisible(true)]
	public override string ToString()
	{
		return ToString(null, null);
	}
}
