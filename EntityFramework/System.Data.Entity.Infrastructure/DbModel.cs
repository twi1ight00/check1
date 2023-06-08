using System.Data.Entity.Edm.Db.Mapping;
using System.Diagnostics.CodeAnalysis;

namespace System.Data.Entity.Infrastructure;

/// <summary>
///     Represents an Entity Data Model (EDM) created by the <see cref="T:System.Data.Entity.DbModelBuilder" />.
///     The Compile method can be used to go from this EDM representation to a <see cref="T:System.Data.Entity.Infrastructure.DbCompiledModel" />
///     which is a compiled snapshot of the model suitable for caching and creation of
///     <see cref="T:System.Data.Entity.DbContext" /> or <see cref="T:System.Data.Objects.ObjectContext" /> instances.
/// </summary>
[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
public class DbModel
{
	private readonly DbDatabaseMapping _databaseMapping;

	private readonly DbModelBuilder _cachedModelBuilder;

	internal DbDatabaseMapping DatabaseMapping => _databaseMapping;

	/// <summary>
	/// A snapshot of the <see cref="T:System.Data.Entity.DbModelBuilder" /> that was used to create this compiled model.
	/// </summary>
	internal DbModelBuilder CachedModelBuilder => _cachedModelBuilder;

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.Data.Entity.Infrastructure.DbModel" /> class.
	/// </summary>
	internal DbModel(DbDatabaseMapping databaseMapping, DbModelBuilder modelBuilder)
	{
		_databaseMapping = databaseMapping;
		_cachedModelBuilder = modelBuilder;
	}

	/// <summary>
	///     Creates a <see cref="T:System.Data.Entity.Infrastructure.DbCompiledModel" /> for this mode which is a compiled snapshot
	///     suitable for caching and creation of <see cref="T:System.Data.Entity.DbContext" /> instances.
	/// </summary>
	/// <returns>The compiled model.</returns>
	public DbCompiledModel Compile()
	{
		return new DbCompiledModel(this);
	}
}
