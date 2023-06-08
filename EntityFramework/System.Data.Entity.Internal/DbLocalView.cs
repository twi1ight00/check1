using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace System.Data.Entity.Internal;

/// <summary>
///     A local (in-memory) view of the entities in a DbSet.
///     This view contains Added entities and does not contain Deleted entities.  The view extends
///     from <see cref="T:System.Collections.ObjectModel.ObservableCollection`1" /> and hooks up events between the collection and the
///     state manager to keep the view in sync.
/// </summary>
/// <typeparam name="TEntity">The type of the entity.</typeparam>
[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Casing is intentional")]
[SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Justification = "Name is intentional")]
internal class DbLocalView<TEntity> : ObservableCollection<TEntity> where TEntity : class
{
	private readonly InternalContext _internalContext;

	private bool _inStateManagerChanged;

	private ObservableBackedBindingList<TEntity> _bindingList;

	/// <summary>
	///     Returns a cached binding list implementation backed by this ObservableCollection.
	/// </summary>
	/// <value>The binding list.</value>
	public ObservableBackedBindingList<TEntity> BindingList => _bindingList ?? (_bindingList = new ObservableBackedBindingList<TEntity>(this));

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.Data.Entity.Internal.DbLocalView`1" /> class for entities
	///     of the given generic type in the given internal context.
	/// </summary>
	/// <param name="internalContext">The internal context.</param>
	public DbLocalView(InternalContext internalContext)
	{
		_internalContext = internalContext;
		try
		{
			_inStateManagerChanged = true;
			foreach (TEntity localEntity in _internalContext.GetLocalEntities<TEntity>())
			{
				Add(localEntity);
			}
		}
		finally
		{
			_inStateManagerChanged = false;
		}
		_internalContext.RegisterObjectStateManagerChangedEvent(StateManagerChangedHandler);
	}

	/// <summary>
	///     Called by the <see cref="T:System.Collections.ObjectModel.ObservableCollection`1" /> base class when the collection changes.
	///     This method looks at the change made to the collection and reflects those changes in the
	///     state manager.
	/// </summary>
	/// <param name="e">The <see cref="T:System.Collections.Specialized.NotifyCollectionChangedEventArgs" /> instance containing the event data.</param>
	protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
	{
		if (!_inStateManagerChanged)
		{
			if (e.Action == NotifyCollectionChangedAction.Remove || e.Action == NotifyCollectionChangedAction.Replace)
			{
				foreach (TEntity oldItem in e.OldItems)
				{
					_internalContext.Set<TEntity>().Remove(oldItem);
				}
			}
			if (e.Action == NotifyCollectionChangedAction.Add || e.Action == NotifyCollectionChangedAction.Replace)
			{
				foreach (TEntity newItem in e.NewItems)
				{
					if (!_internalContext.EntityInContextAndNotDeleted(newItem))
					{
						_internalContext.Set<TEntity>().Add(newItem);
					}
				}
			}
		}
		base.OnCollectionChanged(e);
	}

	/// <summary>
	///     Handles events from the state manager for entities entering, leaving, or being marked as deleted.
	///     The local view is kept in sync with these changes.
	/// </summary>
	/// <param name="sender">The sender.</param>
	/// <param name="e">The <see cref="T:System.ComponentModel.CollectionChangeEventArgs" /> instance containing the event data.</param>
	private void StateManagerChangedHandler(object sender, CollectionChangeEventArgs e)
	{
		try
		{
			_inStateManagerChanged = true;
			if (e.Element is TEntity item)
			{
				if (e.Action == CollectionChangeAction.Remove && Contains(item))
				{
					Remove(item);
				}
				else if (e.Action == CollectionChangeAction.Add && !Contains(item))
				{
					Add(item);
				}
			}
		}
		finally
		{
			_inStateManagerChanged = false;
		}
	}

	/// <summary>
	///     Clears the items by calling remove on each item such that we get Remove events that
	///     can be tracked back to the state manager, rather than a single Reset event that we
	///     cannot deal with.
	/// </summary>
	protected override void ClearItems()
	{
		new List<TEntity>(this).ForEach(delegate(TEntity t)
		{
			Remove(t);
		});
	}

	/// <summary>
	///     Adds a contains check to the base implementation of InsertItem since we can't support
	///     duplicate entities in the set.
	/// </summary>
	/// <param name="index">The index at which to insert.</param>
	/// <param name="item">The item to insert.</param>
	protected override void InsertItem(int index, TEntity item)
	{
		if (!Contains(item))
		{
			base.InsertItem(index, item);
		}
	}
}
