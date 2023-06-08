using System;
using System.Runtime.InteropServices;

namespace C5;

[Serializable]
internal sealed class EventBlock<T>
{
	internal EventTypeEnum events;

	private event CollectionChangedHandler<T> collectionChanged;

	internal event CollectionChangedHandler<T> CollectionChanged
	{
		add
		{
			this.collectionChanged = (CollectionChangedHandler<T>)Delegate.Combine(this.collectionChanged, value);
			events |= EventTypeEnum.Changed;
		}
		remove
		{
			this.collectionChanged = (CollectionChangedHandler<T>)Delegate.Remove(this.collectionChanged, value);
			if (this.collectionChanged == null)
			{
				events &= ~EventTypeEnum.Changed;
			}
		}
	}

	private event CollectionClearedHandler<T> collectionCleared;

	internal event CollectionClearedHandler<T> CollectionCleared
	{
		add
		{
			this.collectionCleared = (CollectionClearedHandler<T>)Delegate.Combine(this.collectionCleared, value);
			events |= EventTypeEnum.Cleared;
		}
		remove
		{
			this.collectionCleared = (CollectionClearedHandler<T>)Delegate.Remove(this.collectionCleared, value);
			if (this.collectionCleared == null)
			{
				events &= ~EventTypeEnum.Cleared;
			}
		}
	}

	private event ItemsAddedHandler<T> itemsAdded;

	internal event ItemsAddedHandler<T> ItemsAdded
	{
		add
		{
			this.itemsAdded = (ItemsAddedHandler<T>)Delegate.Combine(this.itemsAdded, value);
			events |= EventTypeEnum.Added;
		}
		remove
		{
			this.itemsAdded = (ItemsAddedHandler<T>)Delegate.Remove(this.itemsAdded, value);
			if (this.itemsAdded == null)
			{
				events &= ~EventTypeEnum.Added;
			}
		}
	}

	private event ItemsRemovedHandler<T> itemsRemoved;

	internal event ItemsRemovedHandler<T> ItemsRemoved
	{
		add
		{
			this.itemsRemoved = (ItemsRemovedHandler<T>)Delegate.Combine(this.itemsRemoved, value);
			events |= EventTypeEnum.Removed;
		}
		remove
		{
			this.itemsRemoved = (ItemsRemovedHandler<T>)Delegate.Remove(this.itemsRemoved, value);
			if (this.itemsRemoved == null)
			{
				events &= ~EventTypeEnum.Removed;
			}
		}
	}

	private event ItemInsertedHandler<T> itemInserted;

	internal event ItemInsertedHandler<T> ItemInserted
	{
		add
		{
			this.itemInserted = (ItemInsertedHandler<T>)Delegate.Combine(this.itemInserted, value);
			events |= EventTypeEnum.Inserted;
		}
		remove
		{
			this.itemInserted = (ItemInsertedHandler<T>)Delegate.Remove(this.itemInserted, value);
			if (this.itemInserted == null)
			{
				events &= ~EventTypeEnum.Inserted;
			}
		}
	}

	private event ItemRemovedAtHandler<T> itemRemovedAt;

	internal event ItemRemovedAtHandler<T> ItemRemovedAt
	{
		add
		{
			this.itemRemovedAt = (ItemRemovedAtHandler<T>)Delegate.Combine(this.itemRemovedAt, value);
			events |= EventTypeEnum.RemovedAt;
		}
		remove
		{
			this.itemRemovedAt = (ItemRemovedAtHandler<T>)Delegate.Remove(this.itemRemovedAt, value);
			if (this.itemRemovedAt == null)
			{
				events &= ~EventTypeEnum.RemovedAt;
			}
		}
	}

	internal void raiseCollectionChanged(object sender)
	{
		if (this.collectionChanged != null)
		{
			this.collectionChanged(sender);
		}
	}

	internal void raiseCollectionCleared(object sender, bool full, int count)
	{
		if (this.collectionCleared != null)
		{
			this.collectionCleared(sender, new ClearedEventArgs(full, count));
		}
	}

	internal void raiseCollectionCleared(object sender, bool full, int count, int? start)
	{
		if (this.collectionCleared != null)
		{
			this.collectionCleared(sender, new ClearedRangeEventArgs(full, count, start));
		}
	}

	internal void raiseItemsAdded(object sender, T item, int count)
	{
		if (this.itemsAdded != null)
		{
			this.itemsAdded(sender, new ItemCountEventArgs<T>(item, count));
		}
	}

	internal void raiseItemsRemoved(object sender, T item, int count)
	{
		if (this.itemsRemoved != null)
		{
			this.itemsRemoved(sender, new ItemCountEventArgs<T>(item, count));
		}
	}

	internal void raiseItemInserted(object sender, T item, int index)
	{
		if (this.itemInserted != null)
		{
			this.itemInserted(sender, new ItemAtEventArgs<T>(item, index));
		}
	}

	internal void raiseItemRemovedAt(object sender, T item, int index)
	{
		if (this.itemRemovedAt != null)
		{
			this.itemRemovedAt(sender, new ItemAtEventArgs<T>(item, index));
		}
	}

	[ComVisible(true)]
	public EventBlock()
	{
	}
}
