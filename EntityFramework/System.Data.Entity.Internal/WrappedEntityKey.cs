using System.Collections.Generic;
using System.Data.Entity.Resources;
using System.Data.Metadata.Edm;
using System.Linq;

namespace System.Data.Entity.Internal;

/// <summary>
///     A wrapper around EntityKey that allows key/values pairs that have null values to
///     be used.  This allows Added entities with null key values to be searched for in
///     the ObjectStateManager.
/// </summary>
internal class WrappedEntityKey
{
	/// The key name/key value pairs, where some key values may be null
	private readonly IEnumerable<KeyValuePair<string, object>> _keyValuePairs;

	private readonly EntityKey _key;

	/// <summary>
	///     True if any of the key values are null, which means that the EntityKey will also be null.
	/// </summary>
	public bool HasNullValues => _key == null;

	/// <summary>
	///     An actual EntityKey, or null if any of the key values are null.
	/// </summary>
	public EntityKey EntityKey => _key;

	/// <summary>
	///     The key name/key value pairs of the key, in which some of the key values may be null.
	/// </summary>
	public IEnumerable<KeyValuePair<string, object>> KeyValuePairs => _keyValuePairs;

	/// <summary>
	///     Creates a new WrappedEntityKey instance.
	/// </summary>
	/// <param name="entitySet">The entity set that the key belongs to.</param>
	/// <param name="entitySetName">The fully qualified name of the given entity set.</param>
	/// <param name="keyValues">The key values, which may be null or contain null values.</param>
	/// <param name="keyValuesParamName">The name of the parameter passed for keyValue by the user, which is used when throwing exceptions.</param>
	public WrappedEntityKey(EntitySet entitySet, string entitySetName, object[] keyValues, string keyValuesParamName)
	{
		if (keyValues == null)
		{
			object[] array = new object[1];
			keyValues = array;
		}
		List<string> list = entitySet.ElementType.KeyMembers.Select((EdmMember m) => m.Name).ToList();
		if (list.Count != keyValues.Length)
		{
			throw new ArgumentException(Strings.DbSet_WrongNumberOfKeyValuesPassed, keyValuesParamName);
		}
		_keyValuePairs = list.Zip(keyValues, (string name, object value) => new KeyValuePair<string, object>(name, value));
		if (keyValues.All((object v) => v != null))
		{
			_key = new EntityKey(entitySetName, KeyValuePairs);
		}
	}
}
