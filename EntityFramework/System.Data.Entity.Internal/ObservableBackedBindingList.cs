using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace System.Data.Entity.Internal;

/// <summary>
///     Extends <see cref="T:System.Data.Entity.Internal.SortableBindingList`1" /> to create a sortable binding list that stays in
///     sync with an underlying <see cref="T:System.Collections.ObjectModel.ObservableCollection`1" />.  That is, when items are added
///     or removed from the binding list, they are added or removed from the ObservableCollecion, and
///     vice-versa.
/// </summary>
/// <typeparam name="T">The list element type.</typeparam>
internal class ObservableBackedBindingList<T> : SortableBindingList<T>
{
	private bool _addingNewInstance;

	private T _addNewInstance;

	private T _cancelNewInstance;

	private readonly ObservableCollection<T> _obervableCollection;

	private bool _inCollectionChanged;

	private bool _changingObservableCollection;

	/// <summary>
	///     Initializes a new instance of a binding list backed by the given <see cref="T:System.Collections.ObjectModel.ObservableCollection`1" />
	/// </summary>
	/// <param name="obervableCollection">The obervable collection.</param>
	public ObservableBackedBindingList(ObservableCollection<T> obervableCollection)
		: base(obervableCollection.ToList())
	{
		_obervableCollection = obervableCollection;
		_obervableCollection.CollectionChanged += ObservableCollectionChanged;
	}

	/// <summary>
	///     Creates a new item to be added to the binding list.
	/// </summary>
	/// <returns>The new item.</returns>
	protected override object AddNewCore()
	{
		_addingNewInstance = true;
		_addNewInstance = (T)base.AddNewCore();
		return _addNewInstance;
	}

	/// <summary>
	///     Cancels adding of a new item that was started with AddNew.
	/// </summary>
	/// <param name="itemIndex">Index of the item.</param>
	public override void CancelNew(int itemIndex)
	{
		if (itemIndex >= 0 && itemIndex < base.Count && object.Equals(base[itemIndex], _addNewInstance))
		{
			_cancelNewInstance = _addNewInstance;
			_addNewInstance = default(T);
			_addingNewInstance = false;
		}
		base.CancelNew(itemIndex);
	}

	/// <summary>
	///     Removes all items from the binding list and underlying ObservableCollection.
	/// </summary>
	protected override void ClearItems()
	{
		foreach (T item in base.Items)
		{
			RemoveFromObservableCollection(item);
		}
		base.ClearItems();
	}

	/// <summary>
	///     Ends the process of adding a new item that was started with AddNew.
	/// </summary>
	/// <param name="itemIndex">Index of the item.</param>
	public override void EndNew(int itemIndex)
	{
		if (itemIndex >= 0 && itemIndex < base.Count && object.Equals(base[itemIndex], _addNewInstance))
		{
			AddToObservableCollection(_addNewInstance);
			_addNewInstance = default(T);
			_addingNewInstance = false;
		}
		base.EndNew(itemIndex);
	}

	/// <summary>
	///     Inserts the item into the binding list at the given index.
	/// </summary>
	/// <param name="index">The index.</param>
	/// <param name="item">The item.</param>
	protected override void InsertItem(int index, T item)
	{
		base.InsertItem(index, item);
		if (!_addingNewInstance && index >= 0 && index <= base.Count)
		{
			AddToObservableCollection(item);
		}
	}

	/// <summary>
	///     Removes the item at the specified index.
	/// </summary>
	/// <param name="index">The index.</param>
	protected override void RemoveItem(int index)
	{
		if (index >= 0 && index < base.Count && object.Equals(base[index], _cancelNewInstance))
		{
			_cancelNewInstance = default(T);
		}
		else
		{
			RemoveFromObservableCollection(base[index]);
		}
		base.RemoveItem(index);
	}

	/// <summary>
	///     Sets the item into the list at the given position.
	/// </summary>
	/// <param name="index">The index to insert at.</param>
	/// <param name="item">The item.</param>
	protected override void SetItem(int index, T item)
	{
		T val = base[index];
		base.SetItem(index, item);
		if (index >= 0 && index < base.Count)
		{
			if (object.Equals(val, _addNewInstance))
			{
				_addNewInstance = default(T);
				_addingNewInstance = false;
			}
			else
			{
				RemoveFromObservableCollection(val);
			}
			AddToObservableCollection(item);
		}
	}

	/// <summary>
	///     Event handler to update the binding list when the underlying observable collection changes.
	/// </summary>
	/// <param name="sender">The sender.</param>
	/// <param name="e">Data indicating how the collection has changed.</param>
	private void ObservableCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
	{
		if (_changingObservableCollection)
		{
			return;
		}
		try
		{
			_inCollectionChanged = true;
			if (e.Action == NotifyCollectionChangedAction.Reset)
			{
				Clear();
			}
			if (e.Action == NotifyCollectionChangedAction.Remove || e.Action == NotifyCollectionChangedAction.Replace)
			{
				foreach (T oldItem in e.OldItems)
				{
					Remove(oldItem);
				}
			}
			if (e.Action != 0 && e.Action != NotifyCollectionChangedAction.Replace)
			{
				return;
			}
			foreach (T newItem in e.NewItems)
			{
				Add(newItem);
			}
		}
		finally
		{
			_inCollectionChanged = false;
		}
	}

	/// <summary>
	///     Adds the item to the underlying observable collection.
	/// </summary>
	/// <param name="item">The item.</param>
	private void AddToObservableCollection(T item)
	{
		if (!_inCollectionChanged)
		{
			try
			{
				_changingObservableCollection = true;
				_obervableCollection.Add(item);
			}
			finally
			{
				_changingObservableCollection = false;
			}
		}
	}

	/// <summary>
	///     Removes the item from the underlying from observable collection.
	/// </summary>
	/// <param name="item">The item.</param>
	private void RemoveFromObservableCollection(T item)
	{
		if (!_inCollectionChanged)
		{
			try
			{
				_changingObservableCollection = true;
				_obervableCollection.Remove(item);
			}
			finally
			{
				_changingObservableCollection = false;
			}
		}
	}
}
