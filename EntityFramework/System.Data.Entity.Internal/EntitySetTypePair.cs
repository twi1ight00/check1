using System.Data.Metadata.Edm;

namespace System.Data.Entity.Internal;

/// <summary>
///     Helper class that extends Tuple to give the Item1 and Item2 properties more meaningful names.
/// </summary>
internal class EntitySetTypePair : Tuple<EntitySet, Type>
{
	/// <summary>
	///     The EntitySet part of the pair.
	/// </summary>
	public EntitySet EntitySet => base.Item1;

	/// <summary>
	///     The BaseType part of the pair.
	/// </summary>
	public Type BaseType => base.Item2;

	/// <summary>
	///     Creates a new pair of the given EntitySet and BaseType.
	/// </summary>
	public EntitySetTypePair(EntitySet entitySet, Type type)
		: base(entitySet, type)
	{
	}
}
