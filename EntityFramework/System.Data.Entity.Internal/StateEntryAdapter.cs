using System.Collections.Generic;
using System.Data.Metadata.Edm;
using System.Data.Objects;

namespace System.Data.Entity.Internal;

/// <summary>
///     This is a temporary adapter class that wraps an <see cref="T:System.Data.Objects.ObjectStateEntry" /> and
///     presents it as an <see cref="T:System.Data.Entity.Internal.IEntityStateEntry" />.  This class will be removed once
///     we roll into the System.Data.Entity assembly.  See <see cref="T:System.Data.Entity.Internal.IEntityStateEntry" />
///     for more details.
/// </summary>
internal class StateEntryAdapter : IEntityStateEntry
{
	private readonly ObjectStateEntry _stateEntry;

	public object Entity => _stateEntry.Entity;

	public EntityState State => _stateEntry.State;

	public DbUpdatableDataRecord CurrentValues => _stateEntry.CurrentValues;

	public EntitySetBase EntitySet => _stateEntry.EntitySet;

	public EntityKey EntityKey => _stateEntry.EntityKey;

	public StateEntryAdapter(ObjectStateEntry stateEntry)
	{
		_stateEntry = stateEntry;
	}

	public void ChangeState(EntityState state)
	{
		_stateEntry.ChangeState(state);
	}

	public DbUpdatableDataRecord GetUpdatableOriginalValues()
	{
		return _stateEntry.GetUpdatableOriginalValues();
	}

	public IEnumerable<string> GetModifiedProperties()
	{
		return _stateEntry.GetModifiedProperties();
	}

	public void SetModifiedProperty(string propertyName)
	{
		_stateEntry.SetModifiedProperty(propertyName);
	}
}
