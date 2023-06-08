using System;

namespace C5;

[Serializable]
internal sealed class ProxyEventBlock<T>
{
	private ICollectionValue<T> proxy;

	private ICollectionValue<T> real;

	private CollectionChangedHandler<T> collectionChangedProxy;

	private CollectionClearedHandler<T> collectionClearedProxy;

	private ItemsAddedHandler<T> itemsAddedProxy;

	private ItemInsertedHandler<T> itemInsertedProxy;

	private ItemsRemovedHandler<T> itemsRemovedProxy;

	private ItemRemovedAtHandler<T> itemRemovedAtProxy;

	private event CollectionChangedHandler<T> collectionChanged;

	internal event CollectionChangedHandler<T> CollectionChanged
	{
		add
		{
			if (this.collectionChanged == null)
			{
				if (collectionChangedProxy == null)
				{
					collectionChangedProxy = delegate
					{
						this.collectionChanged(proxy);
					};
				}
				real.CollectionChanged += collectionChangedProxy;
			}
			this.collectionChanged = (CollectionChangedHandler<T>)Delegate.Combine(this.collectionChanged, value);
		}
		remove
		{
			this.collectionChanged = (CollectionChangedHandler<T>)Delegate.Remove(this.collectionChanged, value);
			if (this.collectionChanged == null)
			{
				real.CollectionChanged -= collectionChangedProxy;
			}
		}
	}

	private event CollectionClearedHandler<T> collectionCleared;

	internal event CollectionClearedHandler<T> CollectionCleared
	{
		add
		{
			if (this.collectionCleared == null)
			{
				if (collectionClearedProxy == null)
				{
					collectionClearedProxy = delegate(object sender, ClearedEventArgs e)
					{
						this.collectionCleared(proxy, e);
					};
				}
				real.CollectionCleared += collectionClearedProxy;
			}
			this.collectionCleared = (CollectionClearedHandler<T>)Delegate.Combine(this.collectionCleared, value);
		}
		remove
		{
			this.collectionCleared = (CollectionClearedHandler<T>)Delegate.Remove(this.collectionCleared, value);
			if (this.collectionCleared == null)
			{
				real.CollectionCleared -= collectionClearedProxy;
			}
		}
	}

	private event ItemsAddedHandler<T> itemsAdded;

	internal event ItemsAddedHandler<T> ItemsAdded
	{
		add
		{
			if (this.itemsAdded == null)
			{
				if (itemsAddedProxy == null)
				{
					itemsAddedProxy = delegate(object sender, ItemCountEventArgs<T> e)
					{
						this.itemsAdded(proxy, e);
					};
				}
				real.ItemsAdded += itemsAddedProxy;
			}
			this.itemsAdded = (ItemsAddedHandler<T>)Delegate.Combine(this.itemsAdded, value);
		}
		remove
		{
			this.itemsAdded = (ItemsAddedHandler<T>)Delegate.Remove(this.itemsAdded, value);
			if (this.itemsAdded == null)
			{
				real.ItemsAdded -= itemsAddedProxy;
			}
		}
	}

	private event ItemInsertedHandler<T> itemInserted;

	internal event ItemInsertedHandler<T> ItemInserted
	{
		add
		{
			if (this.itemInserted == null)
			{
				if (itemInsertedProxy == null)
				{
					itemInsertedProxy = delegate(object sender, ItemAtEventArgs<T> e)
					{
						this.itemInserted(proxy, e);
					};
				}
				real.ItemInserted += itemInsertedProxy;
			}
			this.itemInserted = (ItemInsertedHandler<T>)Delegate.Combine(this.itemInserted, value);
		}
		remove
		{
			this.itemInserted = (ItemInsertedHandler<T>)Delegate.Remove(this.itemInserted, value);
			if (this.itemInserted == null)
			{
				real.ItemInserted -= itemInsertedProxy;
			}
		}
	}

	private event ItemsRemovedHandler<T> itemsRemoved;

	internal event ItemsRemovedHandler<T> ItemsRemoved
	{
		add
		{
			if (this.itemsRemoved == null)
			{
				if (itemsRemovedProxy == null)
				{
					itemsRemovedProxy = delegate(object sender, ItemCountEventArgs<T> e)
					{
						this.itemsRemoved(proxy, e);
					};
				}
				real.ItemsRemoved += itemsRemovedProxy;
			}
			this.itemsRemoved = (ItemsRemovedHandler<T>)Delegate.Combine(this.itemsRemoved, value);
		}
		remove
		{
			this.itemsRemoved = (ItemsRemovedHandler<T>)Delegate.Remove(this.itemsRemoved, value);
			if (this.itemsRemoved == null)
			{
				real.ItemsRemoved -= itemsRemovedProxy;
			}
		}
	}

	private event ItemRemovedAtHandler<T> itemRemovedAt;

	internal event ItemRemovedAtHandler<T> ItemRemovedAt
	{
		add
		{
			if (this.itemRemovedAt == null)
			{
				if (itemRemovedAtProxy == null)
				{
					itemRemovedAtProxy = delegate(object sender, ItemAtEventArgs<T> e)
					{
						this.itemRemovedAt(proxy, e);
					};
				}
				real.ItemRemovedAt += itemRemovedAtProxy;
			}
			this.itemRemovedAt = (ItemRemovedAtHandler<T>)Delegate.Combine(this.itemRemovedAt, value);
		}
		remove
		{
			this.itemRemovedAt = (ItemRemovedAtHandler<T>)Delegate.Remove(this.itemRemovedAt, value);
			if (this.itemRemovedAt == null)
			{
				real.ItemRemovedAt -= itemRemovedAtProxy;
			}
		}
	}

	internal ProxyEventBlock(ICollectionValue<T> proxy, ICollectionValue<T> real)
	{
		this.proxy = proxy;
		this.real = real;
	}
}
