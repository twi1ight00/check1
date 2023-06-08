using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System.Data.Entity.Internal;

/// <summary>
///     Helper class that extends Tuple to give the Item1 and Item2 properties more meaningful names.
/// </summary>
[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Casing is intentional")]
internal class DbContextTypesInitializersPair : Tuple<Dictionary<Type, List<string>>, Action<DbContext>>
{
	/// <summary>
	///     The entity types part of the pair.
	/// </summary>
	public Dictionary<Type, List<string>> EntityTypeToPropertyNameMap => base.Item1;

	/// <summary>
	///     The DbSet properties initializer part of the pair.
	/// </summary>
	public Action<DbContext> SetsInitializer => base.Item2;

	/// <summary>
	///     Creates a new pair of the given set of entity types and DbSet initializer delegate.
	/// </summary>
	public DbContextTypesInitializersPair(Dictionary<Type, List<string>> entityTypeToPropertyNameMap, Action<DbContext> setsInitializer)
		: base(entityTypeToPropertyNameMap, setsInitializer)
	{
	}
}
