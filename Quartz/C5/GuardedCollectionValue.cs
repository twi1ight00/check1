using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace C5;

internal class GuardedCollectionValue<T> : GuardedEnumerable<T>, ICollectionValue<T>, IEnumerable<T>, IEnumerable, IShowable, IFormattable
{
	private ProxyEventBlock<T> eventBlock;

	private ICollectionValue<T> collectionvalue;

	[ComVisible(true)]
	public virtual EventTypeEnum ListenableEvents
	{
		[ComVisible(true)]
		get
		{
			return collectionvalue.ListenableEvents;
		}
	}

	[ComVisible(true)]
	public virtual EventTypeEnum ActiveEvents
	{
		[ComVisible(true)]
		get
		{
			return collectionvalue.ActiveEvents;
		}
	}

	[ComVisible(true)]
	public virtual bool IsEmpty
	{
		[ComVisible(true)]
		get
		{
			return collectionvalue.IsEmpty;
		}
	}

	[ComVisible(true)]
	public virtual int Count
	{
		[ComVisible(true)]
		get
		{
			return collectionvalue.Count;
		}
	}

	[ComVisible(true)]
	public virtual Speed CountSpeed
	{
		[ComVisible(true)]
		get
		{
			return collectionvalue.CountSpeed;
		}
	}

	[ComVisible(true)]
	public event CollectionChangedHandler<T> CollectionChanged
	{
		[ComVisible(true)]
		add
		{
			(eventBlock ?? (eventBlock = new ProxyEventBlock<T>(this, collectionvalue))).CollectionChanged += value;
		}
		[ComVisible(true)]
		remove
		{
			if (eventBlock != null)
			{
				eventBlock.CollectionChanged -= value;
			}
		}
	}

	[ComVisible(true)]
	public event CollectionClearedHandler<T> CollectionCleared
	{
		[ComVisible(true)]
		add
		{
			(eventBlock ?? (eventBlock = new ProxyEventBlock<T>(this, collectionvalue))).CollectionCleared += value;
		}
		[ComVisible(true)]
		remove
		{
			if (eventBlock != null)
			{
				eventBlock.CollectionCleared -= value;
			}
		}
	}

	[ComVisible(true)]
	public event ItemsAddedHandler<T> ItemsAdded
	{
		[ComVisible(true)]
		add
		{
			(eventBlock ?? (eventBlock = new ProxyEventBlock<T>(this, collectionvalue))).ItemsAdded += value;
		}
		[ComVisible(true)]
		remove
		{
			if (eventBlock != null)
			{
				eventBlock.ItemsAdded -= value;
			}
		}
	}

	[ComVisible(true)]
	public event ItemInsertedHandler<T> ItemInserted
	{
		[ComVisible(true)]
		add
		{
			(eventBlock ?? (eventBlock = new ProxyEventBlock<T>(this, collectionvalue))).ItemInserted += value;
		}
		[ComVisible(true)]
		remove
		{
			if (eventBlock != null)
			{
				eventBlock.ItemInserted -= value;
			}
		}
	}

	[ComVisible(true)]
	public event ItemsRemovedHandler<T> ItemsRemoved
	{
		[ComVisible(true)]
		add
		{
			(eventBlock ?? (eventBlock = new ProxyEventBlock<T>(this, collectionvalue))).ItemsRemoved += value;
		}
		[ComVisible(true)]
		remove
		{
			if (eventBlock != null)
			{
				eventBlock.ItemsRemoved -= value;
			}
		}
	}

	[ComVisible(true)]
	public event ItemRemovedAtHandler<T> ItemRemovedAt
	{
		[ComVisible(true)]
		add
		{
			(eventBlock ?? (eventBlock = new ProxyEventBlock<T>(this, collectionvalue))).ItemRemovedAt += value;
		}
		[ComVisible(true)]
		remove
		{
			if (eventBlock != null)
			{
				eventBlock.ItemRemovedAt -= value;
			}
		}
	}

	[ComVisible(true)]
	public GuardedCollectionValue(ICollectionValue<T> collectionvalue)
		: base((IEnumerable<T>)collectionvalue)
	{
		this.collectionvalue = collectionvalue;
	}

	[ComVisible(true)]
	public virtual void CopyTo(T[] a, int i)
	{
		collectionvalue.CopyTo(a, i);
	}

	[ComVisible(true)]
	public virtual T[] ToArray()
	{
		return collectionvalue.ToArray();
	}

	[ComVisible(true)]
	public virtual void Apply(Act<T> a)
	{
		collectionvalue.Apply(a);
	}

	[ComVisible(true)]
	public virtual bool Exists(Fun<T, bool> filter)
	{
		return collectionvalue.Exists(filter);
	}

	[ComVisible(true)]
	public virtual bool Find(Fun<T, bool> filter, out T item)
	{
		return collectionvalue.Find(filter, out item);
	}

	[ComVisible(true)]
	public virtual bool All(Fun<T, bool> filter)
	{
		return collectionvalue.All(filter);
	}

	[ComVisible(true)]
	public virtual IEnumerable<T> Filter(Fun<T, bool> filter)
	{
		return collectionvalue.Filter(filter);
	}

	[ComVisible(true)]
	public virtual T Choose()
	{
		return collectionvalue.Choose();
	}

	[ComVisible(true)]
	public bool Show(StringBuilder stringbuilder, ref int rest, IFormatProvider formatProvider)
	{
		return collectionvalue.Show(stringbuilder, ref rest, formatProvider);
	}

	[ComVisible(true)]
	public string ToString(string format, IFormatProvider formatProvider)
	{
		return collectionvalue.ToString(format, formatProvider);
	}
}
